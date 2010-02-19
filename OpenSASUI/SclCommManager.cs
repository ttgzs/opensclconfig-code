
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
		
		private int comparestring_c2 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			return comparestring (tree, a, b, 2);
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
			this.gsetreeview.GetColumn(1).Clickable = true;
			this.gsetreeview.GetColumn(1).SortColumnId = 1;
			this.gsetreeview.GetColumn(1).SortIndicator = true;
			this.gsetreeview.GetColumn(1).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.gsetreeview.GetColumn(2).Clickable = true;
			this.gsetreeview.GetColumn(2).SortColumnId = 2;
			this.gsetreeview.GetColumn(2).SortIndicator = true;
			this.gsetreeview.GetColumn(2).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.gsetreeview.GetColumn(3).Clickable = true;
			this.gsetreeview.GetColumn(3).SortColumnId = 4;
			this.gsetreeview.GetColumn(3).SortIndicator = true;
			this.gsetreeview.GetColumn(3).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.gsetreeview.GetColumn(4).Clickable = true;
			this.gsetreeview.GetColumn(4).SortColumnId = 5;
			this.gsetreeview.GetColumn(4).SortIndicator = true;
			this.gsetreeview.GetColumn(4).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.gsetreeview.GetColumn(5).Clickable = true;
			this.gsetreeview.GetColumn(5).SortColumnId = 6;
			this.gsetreeview.GetColumn(5).SortIndicator = true;
			this.gsetreeview.GetColumn(5).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.gsetreeview.GetColumn(5).Visible = false; // Hide this column until GSE is updated
														   // from IED's LLN0
			
			this.updategse.Clicked += HandleUpdategsehandleClicked;
			
			this.ipupdate.Sensitive = false;
			this.iptreeview.Sensitive = false;
			this.gsetreeview.Sensitive = false;
			this.updategse.Sensitive = false;
			this.notebook1.Page = 0;
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
			this.Init();
			this.SetSubnetwork(sclfile, subnet);
		}
		
		public bool SelectSubnetwork (OpenSCL.Object sclfile, 
		                           int subnet)
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
			
			this.ipupdate.Sensitive = false;
			this.iptreeview.Sensitive = false;
			this.gsetreeview.Sensitive = false;
			this.updategse.Sensitive = false;
			this.gsetreeview.GetColumn(5).Visible = false;
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
