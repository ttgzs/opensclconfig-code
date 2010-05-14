
using System;

namespace OpenSASUI
{

	[System.ComponentModel.ToolboxItem(true)]
	public class GSEListViewer : OpenSASUI.CommViewer
	{

		public GSEListViewer ()
		{
			this.Init();
		}
		
		protected override void UpdateList ()
		{
			if (this.sclfile == null)
				return;
			if (this.sclfile.Subnetworks == null)
				return;
			if (this.subnetwork >= 0 && this.subnetwork > this.sclfile.Subnetworks.GetLength(0))
				return;
			if (this.sclfile.Subnetworks[this.subnetwork].ConnectedAP == null)
				return;
			
			Gtk.TreeStore gsemodel = (Gtk.TreeStore) this.InfoTreeView.Model;
			Gtk.TreeIter iter;
			this.Clear(true);
			// Fill GSE table
			string appid = "";
			string mac;
			int appidIndex;
			int macIndex;
			for (int i = 0; i < this.sclfile.Subnetworks[this.subnetwork].ConnectedAP.GetLength(0); i++) {
				if (this.sclfile.Subnetworks[this.subnetwork].ConnectedAP[i].GSE != null) {
					
					for (int j = 0; j < this.sclfile.Subnetworks[this.subnetwork]
					     					.ConnectedAP[i].GSE.GetLength(0); j++) {
						if(this.ied >= 0) {
							string iedname = this.sclfile.Subnetworks[this.subnetwork]
					     					.ConnectedAP[i].iedName;
							IEC61850.SCL.tIED ied = this.sclfile.GetIED(this.ied);
							if(ied == null)
								return;
							if(!ied.name.Equals(iedname))
								continue;
						}
						
						appid = "";
						mac = "";
						appidIndex = -1;
						macIndex = -1;
						
						if (this.sclfile.Subnetworks[this.subnetwork]
						    	.ConnectedAP[i].GSE[j].Address != null) {
							
							if (this.sclfile.Subnetworks[this.subnetwork]
							    	.ConnectedAP[i].GSE[j].Address.P != null) {
								
								for ( int k = 0; k < this.sclfile.Subnetworks[this.subnetwork].
								     					ConnectedAP[i].GSE[j].Address.P.GetLength(0); 
								     	k++) {
									
									IEC61850.SCL.tP t = this.sclfile.Subnetworks[this.subnetwork]
																.ConnectedAP[i].GSE[j].Address.P[k];
									
									if (t.typeEnum == IEC61850.SCL.tPTypeEnum.APPID)
										appidIndex = k;
									if (t.typeEnum == IEC61850.SCL.tPTypeEnum.MAC_Address)
										macIndex = k;
								}
								
								IEC61850.SCL.tGSE gse = this.sclfile.Subnetworks[this.subnetwork]
																.ConnectedAP[i].GSE[j];
								
								if (appidIndex >= 0)
									appid += gse.Address.P[appidIndex].Value;
								
								if (macIndex >= 0)
									mac += gse.Address.P[macIndex].Value;
								
								gsemodel.AppendValues (appid, mac,
								                       this.sclfile.Subnetworks[this.subnetwork]
								                       			.ConnectedAP[i].iedName,
								                       i, 
								                       gse.ldInst, gse.cbName);
							}
						}
					}
				}
			}
		}
		
		protected override void UpdateGSETypes ()
		{
			Gtk.TreeIter iter;
			Gtk.TreeStore gsemodel = (Gtk.TreeStore) this.InfoTreeView.Model;
			bool l = gsemodel.GetIterFirst(out iter);
			
			while (l) {
				string iedname, apname, ldinst, cbname;
				iedname = (string) gsemodel.GetValue (iter, 2);
				ldinst = (string) gsemodel.GetValue (iter, 4);
				cbname = (string) gsemodel.GetValue (iter, 5);
				int ied = this.sclfile.GetIED(iedname);
				IEC61850.SCL.tGSEControl gsec = this.sclfile.GetGSEControl (ied, ldinst, cbname);
				if (gsec == null)
					break;
				else {
					if (gsec.type == IEC61850.SCL.tGSEControlTypeEnum.GOOSE) 
						gsemodel.SetValue (iter, 6, "GOOSE");
					else
						if (gsec.type == IEC61850.SCL.tGSEControlTypeEnum.GSSE)
							gsemodel.SetValue (iter, 6, "GSSE");
						else
							gsemodel.SetValue (iter, 6, Mono.Unix.Catalog.GetString("Unknown"));
				}
				l = gsemodel.IterNext(ref iter);
			}
		}
						
		void Init()
		{
			// Setup GSE table information
			Gtk.TreeStore gsemodel = new Gtk.TreeStore(typeof(string), // APPID 0
			                                           typeof(string), // MAC 1
			                                           typeof(string), // IED 2
			                                           typeof(int), // ConnectedAP  3
			                                           typeof(string), // LD Instance 4
			                                           typeof(string),// ControlBlock 5
			                                           typeof(string)); // GSE Type 6
			                                           
			gsemodel.SetSortFunc (0, (Gtk.TreeIterCompareFunc) comparestring_c0);
			gsemodel.SetSortFunc (1, (Gtk.TreeIterCompareFunc) compare_mac);
			gsemodel.SetSortFunc (2, (Gtk.TreeIterCompareFunc) comparestring_c2);
			gsemodel.SetSortFunc (4, (Gtk.TreeIterCompareFunc) comparestring_c4);
			gsemodel.SetSortFunc (5, (Gtk.TreeIterCompareFunc) comparestring_c5);
			gsemodel.SetSortFunc (6, (Gtk.TreeIterCompareFunc) comparestring_c6);
			this.InfoTreeView.Model = gsemodel;
			                                         
			this.InfoTreeView.AppendColumn (Mono.Unix.Catalog.GetString("IED Name"),
			                               new Gtk.CellRendererText (), "text", 2);
			this.InfoTreeView.AppendColumn (Mono.Unix.Catalog.GetString("LD Instance"),
			                               new Gtk.CellRendererText (), "text", 4);
			this.InfoTreeView.AppendColumn (Mono.Unix.Catalog.GetString("MAC Address"),
			                               new Gtk.CellRendererText (), "text", 1);
			this.InfoTreeView.AppendColumn (Mono.Unix.Catalog.GetString("Application ID"),
			                               new Gtk.CellRendererText (), "text", 0);
			this.InfoTreeView.AppendColumn (Mono.Unix.Catalog.GetString("Control Block Name"),
			                               new Gtk.CellRendererText (), "text", 5);
			this.InfoTreeView.AppendColumn (Mono.Unix.Catalog.GetString("GSE Type"),
			                               new Gtk.CellRendererText (), "text", 6);
			
			this.InfoTreeView.GetColumn(0).Clickable = true;
			this.InfoTreeView.GetColumn(0).SortColumnId = 0;
			this.InfoTreeView.GetColumn(0).SortIndicator = true;
			this.InfoTreeView.GetColumn(0).Sizing = Gtk.TreeViewColumnSizing.Autosize;
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
			this.InfoTreeView.GetColumn(3).SortColumnId = 4;
			this.InfoTreeView.GetColumn(3).SortIndicator = true;
			this.InfoTreeView.GetColumn(3).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.InfoTreeView.GetColumn(3).Resizable = true;
			this.InfoTreeView.GetColumn(4).Clickable = true;
			this.InfoTreeView.GetColumn(4).SortColumnId = 5;
			this.InfoTreeView.GetColumn(4).SortIndicator = true;
			this.InfoTreeView.GetColumn(4).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.InfoTreeView.GetColumn(4).Resizable = true;
			this.InfoTreeView.GetColumn(5).Clickable = true;
			this.InfoTreeView.GetColumn(5).SortColumnId = 6;
			this.InfoTreeView.GetColumn(5).SortIndicator = true;
			this.InfoTreeView.GetColumn(5).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.InfoTreeView.GetColumn(5).Resizable = true;
			
			this.InfoTreeView.SearchColumn = 2;
						
			this.InfoTreeView.Selection.Changed += HandleInformationtreeviewSelectionhandleChanged;
			
		}
		
		void HandleInformationtreeviewSelectionhandleChanged (object sender, EventArgs e)
		{
			Gtk.TreeIter seliter;
			Gtk.TreeSelection sel = (Gtk.TreeSelection) sender;
			
			if(sel.GetSelected(out seliter)) {
				Gtk.TreeStore model = (Gtk.TreeStore) this.InfoTreeView.Model;
				string iedname = (string) model.GetValue(seliter, 2);
				int ap = (int) model.GetValue(seliter, 3);
				string ldinst = (string) model.GetValue(seliter, 4);
				string cbname = (string) model.GetValue(seliter, 5);
				// Clear DataSet information
				Gtk.TreeIter iter;
				Gtk.TreeStore dsmodel = (Gtk.TreeStore) this.DetailsTreeView.Model;
				while(dsmodel.GetIterFirst(out iter))
				      dsmodel.Remove(ref iter);
				
				int iedIndex = this.sclfile.GetIED(iedname);
				if (iedIndex >= 0) {
					int gsedsetIndex = this.sclfile.GetGSEControlDataSetIndex(iedIndex, ldinst, cbname);
					
					// Get Sugested GSE suscriptions
					iter = dsmodel.AppendValues("Suscriptions", "",
					                     "List of IED 'sugested' to be suscribed to this GSE",
					                     -1, gsedsetIndex);
					IEC61850.SCL.tGSEControl gc = this.sclfile.GetGSEControl(iedIndex, ldinst, cbname);
					if (gc != null) {
						if (gc.IEDName != null) {
							for (int s = 0; s < gc.IEDName.GetLength(0); s++) {
								dsmodel.AppendValues(iter, gc.IEDName[s],"", -1, gsedsetIndex);
							}	
						}
						else {
							dsmodel.AppendValues(iter, "<<<<NO SUGESTIONS>>>>");
							this.DetailsTreeView.ExpandRow(dsmodel.GetPath(iter), false);
						}
					}
					// Get DataSet
					IEC61850.SCL.tDataSet 
						gsedset = this.sclfile.GetGSEControlDataSet(iedIndex, ldinst, cbname);
					if (gsedset != null) {
						this.FillModelDataSetInfo(gsedset, gsedsetIndex, dsmodel);
						dsmodel.GetIterFirst(out iter);
						dsmodel.IterNext(ref iter);
						this.DetailsTreeView.ExpandRow(dsmodel.GetPath(iter), false);
					}
				}
			}
		}
		
		protected int compare_mac (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			string s1 = (string) this.InfoTreeView.Model.GetValue (a, 1);
			string s2 = (string) this.InfoTreeView.Model.GetValue (b, 1);
			string[] ts1 = { "" };
			string[] ts2 = { "" };
			
			if (s1.Contains (":")) {
				ts1 = s1.Split (':');
				ts2 = s2.Split (':');
			}
			if (s1.Contains ("-")) {
				ts1 = s1.Split ('-');
				ts2 = s2.Split ('-');
			}
			// If a has more members than b, then not compare and return 0 as being equal
			if (ts1.GetLength(0) > ts2.GetLength(0))
				return 0;
			
			// This will compare member by member
			int res = 0;
			for (int i = 0; i < ts1.GetLength(0); i++) {
				string m1 = "0x";
				m1 += ts1[i];
				string m2 = "0x";
				m2 += ts2[i];
				int va = int.Parse (ts1[i], System.Globalization.NumberStyles.HexNumber);
				int vb = int.Parse (ts2[i], System.Globalization.NumberStyles.HexNumber);
				res = va - vb;
				if (res != 0)
					break;
			}			
			return res;
		}
	}
}
