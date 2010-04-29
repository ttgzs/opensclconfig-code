
using System;
using OpenSCL;

namespace OpenSASUI
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class GSEditor : Gtk.Bin
	{

		private OpenSCL.Object sclfile;
		private int ied;
		private int subnetwork;
		private bool update;
		
		public GSEditor ()
		{
			this.Init();
			this.ied = -1;
			this.subnetwork = -1;
			this.update = false;
		}
		
		public bool SetSubnetwork (OpenSCL.Object sclfile, int subnet, bool update)
		{
			return this.InitGSE(sclfile, subnet, -1, update);
		}
		
		public bool SetIED (OpenSCL.Object sclfile, int subnet, int ied, bool update)
		{
			return this.InitGSE(sclfile, subnet, ied, update);
		}
		
		private bool InitGSE (OpenSCL.Object sclfile, int subnet, int ied, bool update)
		{
			if (sclfile == null)
				return false;
			if (sclfile.Subnetworks == null)
				return false;
			if (subnet < 0 || subnet > sclfile.Subnetworks.GetLength(0))
				return false;
			
			this.ied = ied;
			this.subnetwork = subnet;
			this.sclfile = sclfile;
			this.update = update;
			if(update) {
				this.UpdateGSE();
				this.UpdateGSETypes();
				this.updategsetype.Visible = false;
			}

			this.gsetreeview.Sensitive = true;
			this.updategse.Sensitive = true;
			
			return true;
		}
		
		public bool Update {
			get {
				return this.update;
			}
			set {
				this.update = value;
			}
		}
		
		void UpdateGSE ()
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
			this.Clear();
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
		
		void UpdateGSETypes ()
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
		
		protected virtual void OnActivatedGSETypes (object sender, System.EventArgs e)
		{
			this.UpdateGSETypes();
		}
		
		public void Clear ()
		{
			Gtk.TreeIter iter;
			// GSE Viewer
			Gtk.TreeStore gsemodel = (Gtk.TreeStore) this.gsetreeview.Model;
			while (gsemodel.GetIterFirst(out iter))
				gsemodel.Remove(ref iter);
			// GSE's DataSet Viewer
			Gtk.TreeStore gsedsmodel = (Gtk.TreeStore) this.gsedetailstreeview.Model;
			while (gsedsmodel.GetIterFirst(out iter))
				gsedsmodel.Remove(ref iter);
			
			this.gsetreeview.Sensitive = false;
			this.gsetreeview.GetColumn(5).Visible = false;
			this.updategse.Sensitive = false;
		}
		
		
		void HandleUpdategsehandleClicked (object sender, EventArgs e)
		{
			this.UpdateGSE();
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
		
		void Init()
		{
			this.Build ();
			
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
			                                         
			this.gsetreeview.AppendColumn (Mono.Unix.Catalog.GetString("IED Name"),
			                               new Gtk.CellRendererText (), "text", 2);
			this.gsetreeview.AppendColumn (Mono.Unix.Catalog.GetString("LD Instance"),
			                               new Gtk.CellRendererText (), "text", 4);
			this.gsetreeview.AppendColumn (Mono.Unix.Catalog.GetString("MAC Address"),
			                               new Gtk.CellRendererText (), "text", 1);
			this.gsetreeview.AppendColumn (Mono.Unix.Catalog.GetString("Application ID"),
			                               new Gtk.CellRendererText (), "text", 0);
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
			this.updategsetype.Clicked += OnActivatedGSETypes;
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

		private int comparestring (object tree, Gtk.TreeIter a, Gtk.TreeIter b, int column)
		{
			string s1 = (string) this.gsetreeview.Model.GetValue (a, column);
			string s2 = (string) this.gsetreeview.Model.GetValue (b, column);
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
		
		public OpenSCL.Object SclFile {
			get {
				return this.sclfile;
			}
		}
		

	}
}
