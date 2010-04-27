
using System;

namespace OpenSASUI
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class SclCommManager : Gtk.Bin
	{
		private OpenSCL.Object sclfile;
		private int subnetwork;
		
		private int comparestring (object tree, Gtk.TreeIter a, Gtk.TreeIter b, int column)
		{
			string s1 = (string) this.iptreeview.Model.GetValue (a, column);
			string s2 = (string) this.iptreeview.Model.GetValue (b, column);
			if (s1 != null || s2 != null)
				return s1.CompareTo(s2);
			else
				return 0;
		}
		
		private int comparestring_c0 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			return comparestring (tree, a, b, 0);
		}
		
		private int comparestring_c1 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			return comparestring (tree, a, b, 1);
		}
		
		private int comparestring_c2 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			return comparestring (tree, a, b, 2);
		}
		
		private int comparestring_c3 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			return comparestring (tree, a, b, 3);
		}
		
		private int comparestring_c4 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			return comparestring (tree, a, b, 4);
		}
		
		private int comparestring_c5 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			return comparestring (tree, a, b, 5);
		}
		
		private int comparestring_c6 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			return comparestring (tree, a, b, 6);
		}
		
		private int comparestring_c7 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			return comparestring (tree, a, b, 7);
		}
		
		private int compare_ip (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			string s1 = (string) this.iptreeview.Model.GetValue (a, 0);
			string s2 = (string) this.iptreeview.Model.GetValue (b, 0);
			string[] ts1;
			string[] ts2;
			
			if (s1.Contains (":")) {
				// Is a IPv6 address
				ts1 = s1.Split (':');
				ts2 = s2.Split (':');
			}
			else {
				// Is a IPv4 address
				ts1 = s1.Split ('.');
				ts2 = s2.Split ('.');
			}
			// If a has more members than b, then not compare and return 0 as being equal
			if (ts1.GetLength(0) > ts2.GetLength(0))
				return 0;
			
			// This will compare member by member
			int res = 0;
			for (int i = 0; i < ts1.GetLength(0); i++) {
				int va = int.Parse(ts1[i]);
				int vb = int.Parse (ts2[i]);
				res = va - vb;
				if (res != 0)
					break;
			}
			
			return res;
		}
		
		private int compare_mac (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			string s1 = (string) this.gsetreeview.Model.GetValue (a, 1);
			string s2 = (string) this.gsetreeview.Model.GetValue (b, 1);
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
		
		private void Init ()
		{
			this.Build ();
			
			// Setup TCP/IP table information
			Gtk.TreeStore ipmodel = new Gtk.TreeStore(typeof(string), // IP 0
			                                          typeof(int), // IP index 1
			                                          typeof(string), // IP MASK 2
			                                          typeof(int), // IP MASK index 3
			                                          typeof(string), // IP GATEWAY 4
			                                          typeof(int), // IP GATEWAY index 5
			                                          typeof(int), // ConnectedAP num 6
			                                          typeof(string), // IED Name 7
			                                          typeof(string)); // IED description 8
			
			ipmodel.SetSortFunc (0, (Gtk.TreeIterCompareFunc) compare_ip);
			ipmodel.SetSortFunc (7, (Gtk.TreeIterCompareFunc) comparestring_c7);
			this.iptreeview.Model = ipmodel;
			this.iptreeview.AppendColumn (Mono.Unix.Catalog.GetString("IP Address"),
			                              new Gtk.CellRendererText (), "text", 0);
			this.iptreeview.AppendColumn (Mono.Unix.Catalog.GetString("SubNetwork Mask"),
			                              new Gtk.CellRendererText (), "text", 2);
			this.iptreeview.AppendColumn (Mono.Unix.Catalog.GetString("IED Name"),
			                              new Gtk.CellRendererText (), "text", 7);
			this.iptreeview.AppendColumn (Mono.Unix.Catalog.GetString("Description"), new Gtk.CellRendererText (), "text", 8);
			
			this.iptreeview.GetColumn(0).Clickable = true;
			this.iptreeview.GetColumn(0).SortColumnId = 0;
			this.iptreeview.GetColumn(0).SortIndicator = true;
			this.iptreeview.GetColumn(0).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.iptreeview.GetColumn(2).Clickable = true;
			this.iptreeview.GetColumn(2).SortColumnId = 7;
			this.iptreeview.GetColumn(2).SortIndicator = true;
			this.iptreeview.GetColumn(2).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			
			this.ipupdate.Clicked += HandleIpupdatehandleClicked;
			
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
			this.gsetreeview.Model = gsemodel;
			                                         
			this.gsetreeview.AppendColumn (Mono.Unix.Catalog.GetString("Application ID"),
			                               new Gtk.CellRendererText (), "text", 0);
			this.gsetreeview.AppendColumn (Mono.Unix.Catalog.GetString("MAC Address"),
			                               new Gtk.CellRendererText (), "text", 1);
			this.gsetreeview.AppendColumn (Mono.Unix.Catalog.GetString("IED Name"),
			                               new Gtk.CellRendererText (), "text", 2);
			this.gsetreeview.AppendColumn (Mono.Unix.Catalog.GetString("LD Instance"),
			                               new Gtk.CellRendererText (), "text", 4);
			this.gsetreeview.AppendColumn (Mono.Unix.Catalog.GetString("Control Block Name"),
			                               new Gtk.CellRendererText (), "text", 5);
			this.gsetreeview.AppendColumn (Mono.Unix.Catalog.GetString("GSE Type"),
			                               new Gtk.CellRendererText (), "text", 6);
			
			this.gsetreeview.GetColumn(0).Clickable = true;
			this.gsetreeview.GetColumn(0).SortColumnId = 0;
			this.gsetreeview.GetColumn(0).SortIndicator = true;
			this.gsetreeview.GetColumn(0).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.gsetreeview.GetColumn(0).Resizable = true;
			this.gsetreeview.GetColumn(1).Clickable = true;
			this.gsetreeview.GetColumn(1).SortColumnId = 1;
			this.gsetreeview.GetColumn(1).SortIndicator = true;
			this.gsetreeview.GetColumn(1).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.gsetreeview.GetColumn(1).Resizable = true;
			this.gsetreeview.GetColumn(2).Clickable = true;
			this.gsetreeview.GetColumn(2).SortColumnId = 2;
			this.gsetreeview.GetColumn(2).SortIndicator = true;
			this.gsetreeview.GetColumn(2).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.gsetreeview.GetColumn(2).Resizable = true;
			this.gsetreeview.GetColumn(3).Clickable = true;
			this.gsetreeview.GetColumn(3).SortColumnId = 4;
			this.gsetreeview.GetColumn(3).SortIndicator = true;
			this.gsetreeview.GetColumn(3).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.gsetreeview.GetColumn(3).Resizable = true;
			this.gsetreeview.GetColumn(4).Clickable = true;
			this.gsetreeview.GetColumn(4).SortColumnId = 5;
			this.gsetreeview.GetColumn(4).SortIndicator = true;
			this.gsetreeview.GetColumn(4).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.gsetreeview.GetColumn(4).Resizable = true;
			this.gsetreeview.GetColumn(5).Clickable = true;
			this.gsetreeview.GetColumn(5).SortColumnId = 6;
			this.gsetreeview.GetColumn(5).SortIndicator = true;
			this.gsetreeview.GetColumn(5).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.gsetreeview.GetColumn(5).Resizable = true;
			this.gsetreeview.GetColumn(5).Visible = false; // Hide this column until GSE is updated
														   // from IED's LLN0
			this.gsetreeview.SearchColumn = 2;
			
			this.updategse.Clicked += HandleUpdategsehandleClicked;
			this.gsetreeview.Selection.Changed += HandleGsetreeviewSelectionhandleChanged;
			// Setup GSE's DataSet table information
			Gtk.TreeStore gsedsetmodel = new Gtk.TreeStore(typeof(string), // FCDA / DataSet name 0
			                                            typeof(string), // desc 1
			                                            typeof(int), // FCDA Index 2
			                                            typeof(int)); // DataSet Index 3
			this.gsedetailstreeview.AppendColumn (Mono.Unix.Catalog.GetString("DataSet/IED"),
			                               new Gtk.CellRendererText (), "text", 0);
			this.gsedetailstreeview.AppendColumn (Mono.Unix.Catalog.GetString("FC/Desc"),
			                               new Gtk.CellRendererText (), "text", 1);
			this.gsedetailstreeview.Model = gsedsetmodel;
			this.gsedetailstreeview.GetColumn(0).Resizable = true;
			this.gsedetailstreeview.GetColumn(1).Resizable = true;
			
			
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
			this.reportstreeview.Model = reportmodel;
			                                         
			this.reportstreeview.AppendColumn (Mono.Unix.Catalog.GetString("Name"),
			                               new Gtk.CellRendererText (), "text", 0);
			this.reportstreeview.AppendColumn (Mono.Unix.Catalog.GetString("ID"),
			                               new Gtk.CellRendererText (), "text", 1);
			this.reportstreeview.AppendColumn (Mono.Unix.Catalog.GetString("IED.LD.LN"),
			                               new Gtk.CellRendererText (), "text", 2);
			this.reportstreeview.AppendColumn (Mono.Unix.Catalog.GetString("DataSet Ref."),
			                               new Gtk.CellRendererText (), "text", 3);
			this.reportstreeview.AppendColumn (Mono.Unix.Catalog.GetString("Description"),
			                               new Gtk.CellRendererText (), "text", 9);
			
			this.reportstreeview.GetColumn(0).Clickable = true;
			this.reportstreeview.GetColumn(0).SortColumnId = 0;
			this.reportstreeview.GetColumn(0).SortIndicator = true;
			this.reportstreeview.GetColumn(0).Resizable = true;
			this.reportstreeview.GetColumn(1).Clickable = true;
			this.reportstreeview.GetColumn(1).SortColumnId = 1;
			this.reportstreeview.GetColumn(1).SortIndicator = true;
			this.reportstreeview.GetColumn(1).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.reportstreeview.GetColumn(1).Resizable = true;
			this.reportstreeview.GetColumn(2).Clickable = true;
			this.reportstreeview.GetColumn(2).SortColumnId = 2;
			this.reportstreeview.GetColumn(2).SortIndicator = true;
			this.reportstreeview.GetColumn(2).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.reportstreeview.GetColumn(2).Resizable = true;
			this.reportstreeview.GetColumn(3).Clickable = true;
			this.reportstreeview.GetColumn(3).SortColumnId = 2;
			this.reportstreeview.GetColumn(3).SortIndicator = true;
			this.reportstreeview.GetColumn(3).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.reportstreeview.GetColumn(3).Resizable = true;
			
			this.reportstreeview.Selection.Changed += HandleReportstreeviewSelectionhandleChanged;
			
			this.updatereports.Clicked += HandleUpdatereportshandleClicked;
			
			
			// Setup Report's DataSet table information
			Gtk.TreeStore rdsetmodel = new Gtk.TreeStore(typeof(string), // FCDA / DataSet name 0
			                                            typeof(string), // desc 1
			                                            typeof(int), // FCDA Index 2
			                                            typeof(int)); // DataSet Index 3
			
			this.dsetreportreeview.AppendColumn (Mono.Unix.Catalog.GetString("Data Reference"),
			                               new Gtk.CellRendererText (), "text", 0);
			this.dsetreportreeview.AppendColumn (Mono.Unix.Catalog.GetString("FC/Desc"),
			                               new Gtk.CellRendererText (), "text", 1);
			this.dsetreportreeview.Model = rdsetmodel;
			this.dsetreportreeview.GetColumn(0).Resizable = true;
			this.dsetreportreeview.GetColumn(1).Resizable = true;
			
			
			this.ipupdate.Sensitive = false;
			this.iptreeview.Sensitive = false;
			
			this.updategse.Sensitive = false;
			this.gsetreeview.Sensitive = false;
			
			this.updatereports.Sensitive = false;
			this.reportstreeview.Sensitive = false;
			this.dsetreportreeview.Sensitive = false;
			
			this.notebook1.Page = 0;
		}

		void HandleGsetreeviewSelectionhandleChanged (object sender, EventArgs e)
		{
			Gtk.TreeIter seliter;
			Gtk.TreeSelection sel = (Gtk.TreeSelection) sender;
			
			if(sel.GetSelected(out seliter)) {
				Gtk.TreeStore model = (Gtk.TreeStore) this.gsetreeview.Model;
				string iedname = (string) model.GetValue(seliter, 2);
				int ap = (int) model.GetValue(seliter, 3);
				string ldinst = (string) model.GetValue(seliter, 4);
				string cbname = (string) model.GetValue(seliter, 5);
				// Clear DataSet information
				Gtk.TreeIter iter;
				Gtk.TreeStore dsmodel = (Gtk.TreeStore) this.gsedetailstreeview.Model;
				while(dsmodel.GetIterFirst(out iter))
				      dsmodel.Remove(ref iter);
				
				int iedIndex = this.sclfile.GetIED(iedname);
				if (iedIndex >= 0) {
					int gsedsetIndex = this.sclfile.GetGSEControlDataSetIndex(iedIndex, ldinst, cbname);
					
					// Get Sugested GSE suscriptions
					iter = dsmodel.AppendValues("Suscriptions", 
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
							this.gsedetailstreeview.ExpandRow(dsmodel.GetPath(iter), false);
						}
					}
					
					
					// Get DataSet
					IEC61850.SCL.tDataSet 
						gsedset = this.sclfile.GetGSEControlDataSet(iedIndex, ldinst, cbname);
					if (gsedset != null) {
						this.FillModelDataSetInfo(gsedset, gsedsetIndex, dsmodel);
						dsmodel.GetIterFirst(out iter);
						dsmodel.IterNext(ref iter);
						this.gsedetailstreeview.ExpandRow(dsmodel.GetPath(iter), false);
					}
				}
			}
		}

		void HandleReportstreeviewSelectionhandleChanged (object sender, EventArgs e)
		{
			Gtk.TreeIter seliter;
			Gtk.TreeSelection sel = (Gtk.TreeSelection) sender;
			
			if(sel.GetSelected(out seliter)) {
				Gtk.TreeStore model = (Gtk.TreeStore) this.reportstreeview.Model;
				int iedIndex = (int) model.GetValue(seliter, 4);
				int apIndex = (int) model.GetValue(seliter, 5);
				int ldIndex = (int) model.GetValue(seliter, 6);
				int lnIndex = (int) model.GetValue(seliter, 7);
				int repIndex = (int) model.GetValue(seliter, 8);
				
				// Clear DataSet information
				Gtk.TreeIter iter;
				Gtk.TreeStore dsmodel = (Gtk.TreeStore) this.dsetreportreeview.Model;
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
					this.dsetreportreeview.ExpandAll();					
				}
			}
		}
		
		private void FillModelDataSetInfo(IEC61850.SCL.tDataSet ds, int dsIndex, Gtk.TreeStore dsmodel)
		{
			if (!(ds == null || dsIndex < 0)) {
				string name = "" + ds.name;
				string desc = "" + ds.desc;
				Gtk.TreeIter dsIter;
				
				dsIter = dsmodel.AppendValues(name, desc, -1, dsIndex);
				if (ds.FCDA != null) {
					for (int j = 0; j < ds.FCDA.GetLength(0); j++) {
						string t = "";
						if (ds.FCDA[j].ldInst != null)
							if(ds.FCDA[j].ldInst.Length > 0) {
								t += ds.FCDA[j].ldInst + ".";
						}
						else
							t += "[NO LD DEFINED].";
						
						if (ds.FCDA[j].lnClass != null)
							if (ds.FCDA[j].lnClass.Length > 0) {
								t += ds.FCDA[j].prefix;
								t += ds.FCDA[j].lnClass;
								t += ds.FCDA[j].lnInst + ".";
							}
						else
							t += "[NO LN INFO].";
						if (ds.FCDA[j].doName != null)
							if (ds.FCDA[j].doName.Length > 0)
								t += ds.FCDA[j].doName;
						else
							t += "[NO DATA OBJECT INFO]";
						if (ds.FCDA[j].daName != null)
							if (ds.FCDA[j].daName.Length > 0)
								t += "." + ds.FCDA[j].daName;
						
						dsmodel.AppendValues(dsIter, t, ds.FCDA[j].fc.ToString(), j, dsIndex);
					}
				}
			}
			else
				dsmodel.AppendValues("NO DataSet REFERENCE IS SET");
		}
		
		// Reports listed are searched on LN0 and LN on each IED and its LDs
		// no reports are searched on other LNs
		void HandleUpdatereportshandleClicked (object sender, EventArgs e)
		{
			if (this.sclfile == null)
				return;
			if (this.sclfile.Devices == null)
				return;
						
			Gtk.TreeStore model = (Gtk.TreeStore) this.reportstreeview.Model;
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

		void HandleUpdategsehandleClicked (object sender, EventArgs e)
		{
			if (this.sclfile == null)
				return;
			if (this.sclfile.Subnetworks == null)
				return;
			if (this.subnetwork >= 0 && this.subnetwork > this.sclfile.Subnetworks.GetLength(0))
				return;
			if (this.sclfile.Subnetworks[this.subnetwork].ConnectedAP == null)
				return;
			
			Gtk.TreeStore gsemodel = (Gtk.TreeStore) this.gsetreeview.Model;
			Gtk.TreeIter iter;
			// Clear GSE table
			while (gsemodel.GetIterFirst(out iter))
				gsemodel.Remove(ref iter);
			// Fill GSE table
			string appid = "";
			string mac;
			int appidIndex;
			int macIndex;
			for (int i = 0; i < this.sclfile.Subnetworks[this.subnetwork].ConnectedAP.GetLength(0); i++) {
				if (this.sclfile.Subnetworks[this.subnetwork].ConnectedAP[i].GSE != null) {
					
					for (int j = 0; j < this.sclfile.Subnetworks[this.subnetwork]
					     					.ConnectedAP[i].GSE.GetLength(0); j++) {
						
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

		
		void HandleIpupdatehandleClicked (object sender, EventArgs e)
		{
			Gtk.TreeStore ipmodel = (Gtk.TreeStore) this.iptreeview.Model;
			Gtk.TreeIter iter;
			// Clear IP table
			while (ipmodel.GetIterFirst(out iter))
				ipmodel.Remove(ref iter);
			// Fill IP table
			for (int i = 0; i < sclfile.Subnetworks[this.subnetwork].ConnectedAP.GetLength(0); i++) {
				string ip = "";
				string ipmask = "";
				string ipgatew = "";
				string iedname = "";
				string ieddesc = "";
				// Search for IP tPType
				int ipindex = -1;
				int maskindex = -1;
				int gatewindex = -1;
				if (sclfile.Subnetworks[this.subnetwork].ConnectedAP[i].Address != null) {
					for (int j = 0; j < sclfile.Subnetworks[this.subnetwork].ConnectedAP[i].Address.P.GetLength(0); j++) {
						if (sclfile.Subnetworks[this.subnetwork]
						    .ConnectedAP[i].Address.P[j].typeEnum == IEC61850.SCL.tPTypeEnum.IP)
							ipindex = j;
						if (sclfile.Subnetworks[this.subnetwork]
						    .ConnectedAP[i].Address.P[j].typeEnum == IEC61850.SCL.tPTypeEnum.IP_SUBNET)
							maskindex = j;
						if (sclfile.Subnetworks[this.subnetwork]
						    .ConnectedAP[i].Address.P[j].typeEnum == IEC61850.SCL.tPTypeEnum.IP_GATEWAY)
							gatewindex = j;
						
					}
					if (ipindex >= 0)
						ip += sclfile.Subnetworks[this.subnetwork]
						    .ConnectedAP[i].Address.P[ipindex].Value;
					if (maskindex >= 0)
						ipmask += sclfile.Subnetworks[this.subnetwork]
						    .ConnectedAP[i].Address.P[maskindex].Value;
					if (gatewindex >= 0)
						ipgatew += sclfile.Subnetworks[this.subnetwork]
						    .ConnectedAP[i].Address.P[gatewindex].Value;
					if (sclfile.Subnetworks[this.subnetwork].ConnectedAP[i].iedName != null)
						iedname += sclfile.Subnetworks[this.subnetwork].ConnectedAP[i].iedName;
					
					if (sclfile.Subnetworks[this.subnetwork].ConnectedAP[i].apName != null) {
						iedname += " (";
						iedname += sclfile.Subnetworks[this.subnetwork].ConnectedAP[i].apName;
						iedname += ")";
					}
					
					ipmodel.AppendValues(ip, ipindex, ipmask, maskindex,
					                     ipgatew, gatewindex, i,
					                     iedname, "");
				}
			}
		}

		public SclCommManager ()
		{
			this.subnetwork = -1;
			this.Init();
		}
		public SclCommManager (OpenSCL.Object sclfile, int subnet)
		{
			this.subnetwork = -1;
			this.Init();
			this.SetSubnetwork(sclfile, subnet);
		}
		
		public bool SelectSubnetwork (OpenSCL.Object sclfile, int subnet)
		{
			if (sclfile == null)
				return false;
			if (sclfile.Subnetworks == null)
				return false;
			if (subnet < 0 && subnet > sclfile.Subnetworks.GetLength(0))
				return false;
			if (sclfile.Subnetworks[subnet].ConnectedAP == null)
				return false;
			if (!this.subnetworkeditor1.SetSubnetwork(this.sclfile, this.subnetwork))
				return false;
			
			this.Clear();
			
			this.ipupdate.Sensitive = true;
			this.iptreeview.Sensitive = true;
			
			this.gsetreeview.Sensitive = true;
			this.updategse.Sensitive = true;
			
			this.reportstreeview.Sensitive = true;
			this.dsetreportreeview.Sensitive = true;
			this.updatereports.Sensitive = true;
			
			return true;
		}
		
		public bool SetSubnetwork (OpenSCL.Object sclfile, int subnet)
		{
			this.sclfile = sclfile;
			this.subnetwork = subnet;
			if (SelectSubnetwork(sclfile, subnet)) 
				return true;
			else {
				this.sclfile = null;
				this.subnetwork = -1;
				this.Clear();
				return false;
			}
		}
		
		public bool ChangeSubnetwork (int subnet)
		{
			this.subnetwork = subnet;
			int s = subnet;
			if (SelectSubnetwork(this.sclfile, subnet))
				return true;
			else {
				this.subnetwork = s;
				return SelectSubnetwork (this.sclfile, s);
			}
		}
		
		public void Clear ()
		{
			Gtk.TreeIter iter;
			// IP viewer
			Gtk.TreeStore ipmodel = (Gtk.TreeStore) this.iptreeview.Model;
			while (ipmodel.GetIterFirst(out iter))
				ipmodel.Remove(ref iter);
			// GSE Viewer
			Gtk.TreeStore gsemodel = (Gtk.TreeStore) this.gsetreeview.Model;
			while (gsemodel.GetIterFirst(out iter))
				gsemodel.Remove(ref iter);
			// GSE's DataSet Viewer
			Gtk.TreeStore gsedsmodel = (Gtk.TreeStore) this.gsedetailstreeview.Model;
			while (gsedsmodel.GetIterFirst(out iter))
				gsedsmodel.Remove(ref iter);
			// Report Viewer
			Gtk.TreeStore repmodel = (Gtk.TreeStore) this.reportstreeview.Model;
			while (repmodel.GetIterFirst(out iter))
				repmodel.Remove(ref iter);
			// Report's DataSet Viewer
			Gtk.TreeStore dsrepmodel = (Gtk.TreeStore) this.dsetreportreeview.Model;
			while (dsrepmodel.GetIterFirst(out iter))
				dsrepmodel.Remove(ref iter);
			
			this.ipupdate.Sensitive = false;
			this.iptreeview.Sensitive = false;
			this.gsetreeview.Sensitive = false;
			this.updatedatasets.Sensitive = false;
			this.gsetreeview.GetColumn(5).Visible = false;
			this.updategse.Sensitive = false;
		}
		protected virtual void OnActivatedGSETypes (object sender, System.EventArgs e)
		{
			Gtk.TreeIter iter;
			Gtk.TreeStore gsemodel = (Gtk.TreeStore) this.gsetreeview.Model;
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
			this.gsetreeview.GetColumn(5).Visible = true;
		}
		
	}
}
