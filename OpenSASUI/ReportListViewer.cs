
using System;

namespace OpenSASUI
{

	[System.ComponentModel.ToolboxItem(true)]
	public class ReportListViewer : OpenSASUI.CommViewer
	{

		public ReportListViewer ()
		{
			// Setup Report table information
			Gtk.TreeStore reportmodel = new Gtk.TreeStore(typeof(string), // Report's Name 0
			                                           typeof(string), // Report ID 1
			                                           typeof(string), // IED/LD/LN 2
				                                       typeof(string), // DataSet Reference 3
			                                           typeof(int), // IED Index  4
				                                       typeof(int), // AP Index  5
			                                           typeof(int), // LD Index 6
			                                           typeof(int),// LN Index If < 0 is the LD's LN0 7
			                                           typeof(int),// Report Index 8
			                                           typeof(string)); // Report's Description 9
			                                           
			reportmodel.SetSortFunc (0, (Gtk.TreeIterCompareFunc) comparestring_c0);
			reportmodel.SetSortFunc (1, (Gtk.TreeIterCompareFunc) comparestring_c1);
			reportmodel.SetSortFunc (2, (Gtk.TreeIterCompareFunc) comparestring_c2);
			reportmodel.SetSortFunc (3, (Gtk.TreeIterCompareFunc) comparestring_c3);
			this.InfoTreeView.Model = reportmodel;
			                                         
			this.InfoTreeView.AppendColumn (Mono.Unix.Catalog.GetString("Name"),
			                               new Gtk.CellRendererText (), "text", 0);
			this.InfoTreeView.AppendColumn (Mono.Unix.Catalog.GetString("ID"),
			                               new Gtk.CellRendererText (), "text", 1);
			this.InfoTreeView.AppendColumn (Mono.Unix.Catalog.GetString("IED.LD.LN"),
			                               new Gtk.CellRendererText (), "text", 2);
			this.InfoTreeView.AppendColumn (Mono.Unix.Catalog.GetString("DataSet Ref."),
			                               new Gtk.CellRendererText (), "text", 3);
			this.InfoTreeView.AppendColumn (Mono.Unix.Catalog.GetString("Description"),
			                               new Gtk.CellRendererText (), "text", 9);
			
			this.InfoTreeView.GetColumn(0).Clickable = true;
			this.InfoTreeView.GetColumn(0).SortColumnId = 0;
			this.InfoTreeView.GetColumn(0).SortIndicator = true;
			this.InfoTreeView.GetColumn(0).Resizable = true;
			this.InfoTreeView.GetColumn(1).Clickable = true;
			this.InfoTreeView.GetColumn(1).SortColumnId = 1;
			this.InfoTreeView.GetColumn(1).SortIndicator = true;
			this.InfoTreeView.GetColumn(1).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.InfoTreeView.GetColumn(1).Resizable = true;
			this.InfoTreeView.GetColumn(2).Clickable = true;
			this.InfoTreeView.GetColumn(2).SortColumnId = 2;
			this.InfoTreeView.GetColumn(2).SortIndicator = true;
			this.InfoTreeView.GetColumn(2).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.InfoTreeView.GetColumn(2).Resizable = true;
			this.InfoTreeView.GetColumn(3).Clickable = true;
			this.InfoTreeView.GetColumn(3).SortColumnId = 2;
			this.InfoTreeView.GetColumn(3).SortIndicator = true;
			this.InfoTreeView.GetColumn(3).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.InfoTreeView.GetColumn(3).Resizable = true;
			
			this.InfoTreeView.Selection.Changed += HandleInformationtreeviewSelectionhandleChanged;
			
			this.UpdateListButton.Clicked += HandleUpdatehandleClicked;
			
			
		}
		
		void HandleInformationtreeviewSelectionhandleChanged (object sender, EventArgs e)
		{
			Gtk.TreeIter seliter;
			Gtk.TreeSelection sel = (Gtk.TreeSelection) sender;
			
			if(sel.GetSelected(out seliter)) {
				Gtk.TreeStore model = (Gtk.TreeStore) this.InfoTreeView.Model;
				int iedIndex = (int) model.GetValue(seliter, 4);
				int apIndex = (int) model.GetValue(seliter, 5);
				int ldIndex = (int) model.GetValue(seliter, 6);
				int lnIndex = (int) model.GetValue(seliter, 7);
				int repIndex = (int) model.GetValue(seliter, 8);
				
				// Clear DataSet information
				Gtk.TreeIter iter;
				Gtk.TreeStore dsmodel = (Gtk.TreeStore) this.DetailsTreeView.Model;
				while(dsmodel.GetIterFirst(out iter))
				      dsmodel.Remove(ref iter);
				// Get DataSet Information from LN and Report information
				if (iedIndex >= 0 && apIndex >= 0 && ldIndex >= 0 && repIndex >= 0) {
					IEC61850.SCL.tDataSet ds;
					int dsIndex;
					if (lnIndex < 0 ) { // Is the LN0
						ds = this.sclfile.GetLN0ReportControlDataSet (iedIndex, apIndex, 
						                                    ldIndex, repIndex);
						dsIndex = this.sclfile.GetLN0ReportControlDataSetIndex(iedIndex, apIndex, 
						                                    ldIndex, repIndex);
						this.FillModelDataSetInfo(ds, dsIndex, dsmodel);
					}
					else { // It is a LN
						ds = this.sclfile.GetLNReportControlDataSet(iedIndex, apIndex, 
                                                            ldIndex, lnIndex, repIndex);
						dsIndex = this.sclfile.GetLNReportControlDataSetIndex(iedIndex, apIndex, 
						                                    ldIndex, lnIndex, repIndex);
						this.FillModelDataSetInfo(ds, dsIndex, dsmodel);
					}
					this.DetailsTreeView.ExpandAll();					
				}
			}
		}
		
		// Reports listed are searched on LN0 and LN on each IED and its LDs
		// no reports are searched on other LNs
		void HandleUpdatehandleClicked (object sender, EventArgs e)
		{
			this.UpdateList();
		}
		
		protected override void UpdateList()
		{
			if (this.sclfile == null)
				return;
			if (this.sclfile.Devices == null)
				return;
						
			Gtk.TreeStore model = (Gtk.TreeStore) this.InfoTreeView.Model;
			Gtk.TreeIter iter;
			// Clear Reports table
			while (model.GetIterFirst(out iter))
				model.Remove(ref iter);
			// Fill Reports table
			string id = "";
			string name = "";
			string reference = "";
			string desc = "";
			string dataset = "";
			int iedIndex;
			int apIndex;
			int lnIndex;
			
			// Scan IED's reports
			for (int i = 0; i < this.sclfile.Devices.GetLength(0); i++) {
				if (this.sclfile.Devices[i].AccessPoint != null) {
					
					for (int j = 0; j < this.sclfile.Devices[i].AccessPoint.GetLength(0); j++) {
						
						if (this.sclfile.Devices[i].AccessPoint[j].Server != null) {
							
							if (this.sclfile.Devices[i].AccessPoint[j].Server.LDevice != null) {
								
								for ( int k = 0; k < this.sclfile.Devices[i]
								     						.AccessPoint[j].Server.LDevice.GetLength(0); 
								     	k++) {
									
									// Reports at LN0
									if (this.sclfile.Devices[i].AccessPoint[j].Server.LDevice[k].LN0 != null) {
										if (this.sclfile.Devices[i].AccessPoint[j]
										    	.Server.LDevice[k].LN0.ReportControl != null) {
											for (int l = 0; l < this.sclfile.Devices[i].AccessPoint[j]
										    						.Server.LDevice[k].LN0.ReportControl.GetLength(0);
											     l++) {
												IEC61850.SCL.tReportControl rep = this.sclfile.Devices[i].AccessPoint[j]
										    										.Server.LDevice[k].LN0.ReportControl[l];
												name = "" + rep.name;
												id = "" + rep.rptID;
												desc = "" + rep.desc;
												dataset = "" + rep.datSet;
												reference = "" + this.sclfile.Devices[i].name;
												reference += "(";
												reference += this.sclfile.Devices[i].AccessPoint[j].name;
												reference += ").";
												reference += this.sclfile.Devices[i].AccessPoint[j].Server.LDevice[k].inst;
												reference += ".LN0";
												
												model.AppendValues(name, id, reference, dataset, 
												                   i, j, k, -1, // LN to -1 represents the LN0
												                   l, desc);
											}
										}
									}
									
									// Reports at LN
									if (this.sclfile.Devices[i].AccessPoint[j].Server.LDevice[k].LN != null) {
										
										for (int m = 0; m < this.sclfile.Devices[i].AccessPoint[j]
											    	.Server.LDevice[k].LN.GetLength(0);
										     m++) {
											
											if (this.sclfile.Devices[i].AccessPoint[j]
											    .Server.LDevice[k].LN[m].ReportControl != null) {
												
												for (int l = 0; l < this.sclfile.Devices[i].AccessPoint[j]
											    						.Server.LDevice[k].LN[m].ReportControl.GetLength(0);
												     l++) {
													
													IEC61850.SCL.tReportControl rep = this.sclfile.Devices[i].AccessPoint[j]
											    										.Server.LDevice[k].LN[m].ReportControl[l];
													name = "" + rep.name;
													id = "" + rep.rptID;
													desc = "" + rep.desc;
													dataset = "" + rep.datSet;
													reference = "" + this.sclfile.Devices[i].name;
													reference += "(";
													reference += this.sclfile.Devices[i].AccessPoint[j].name;
													reference += ").";
													reference += this.sclfile.Devices[i].AccessPoint[j]
																	.Server.LDevice[k].inst;
													reference += ".";
													reference += this.sclfile.Devices[i].AccessPoint[j]
																	.Server.LDevice[k].LN[m].prefix;
													reference += this.sclfile.Devices[i].AccessPoint[j]
																	.Server.LDevice[k].LN[m].lnClass;
													reference += this.sclfile.Devices[i].AccessPoint[j]
																	.Server.LDevice[k].LN[m].inst;
													
													model.AppendValues(name, id, reference, dataset, 
												                   i, j, k, m, l, desc);
												}
											}
										}
									}
									
								}
							}
						}
					}
				}
			}
			// FIXME: Search Reports on Other LNs
		}
	}
}
