
using System;
using OpenSCL;
using IEC61850.SCL;

namespace OpenSASUI
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class APEditor : Gtk.Bin
	{
		private OpenSCL.Object sclfile;
		private int numied;
		private int numap;
		private System.Collections.ArrayList connectedap;
		
		private void Init ()
		{
			this.Build ();
			
			Gtk.TreeStore aplnmodel = new Gtk.TreeStore (GLib.GType.String, 
			                                         GLib.GType.Int, 
			                                         GLib.GType.String);
			this.aplntreeview.Model = aplnmodel;
			this.aplntreeview.AppendColumn (Mono.Unix.Catalog.GetString("Logical Devices"),
			                                new Gtk.CellRendererText (), "text", 0);
			this.aplntreeview.AppendColumn (Mono.Unix.Catalog.GetString("Description"),
			                                new Gtk.CellRendererText (), "text", 2);
			
			
			Gtk.TreeStore phymodel = new Gtk.TreeStore (GLib.GType.String, 
			                                         GLib.GType.Int, 
			                                         GLib.GType.String);
			this.physicaltreeview.Model = phymodel;
			this.physicaltreeview.AppendColumn (Mono.Unix.Catalog.GetString("Parameter"),
			                                    new Gtk.CellRendererText (), "text", 0);
			this.physicaltreeview.AppendColumn (Mono.Unix.Catalog.GetString("Description"),
			                                    new Gtk.CellRendererText (), "text", 2);
			this.physicaltreeview.Selection.Changed += HandlePhysicaltreeviewSelectionhandleChanged;
			
			Gtk.TreeStore addressmodel = new Gtk.TreeStore (typeof(string), 
			                                         typeof(int),
			                                         typeof(IEC61850.SCL.tPTypeEnum), 
			                                         typeof(string));
			this.addresstreeview.Model = addressmodel;
			this.addresstreeview.AppendColumn (Mono.Unix.Catalog.GetString("Parameter"),
			                                   new Gtk.CellRendererText (), "text", 0);
			this.addresstreeview.AppendColumn (Mono.Unix.Catalog.GetString("Description"),
			                                   new Gtk.CellRendererText (), "text", 3);
			this.addresstreeview.Selection.Changed += HandleAddresstreeviewSelectionhandleChanged;
			
			Gtk.ListStore subnetmodel = new Gtk.ListStore (GLib.GType.String, 
					                                       GLib.GType.Int, 
					                                       GLib.GType.String,
			                                               GLib.GType.Int);
			this.subnetworklist.Model = subnetmodel;
			this.subnetworklist.Changed += HandleSubnetworklisthandleChanged;
			
			Gtk.ListStore tpmodel = new Gtk.ListStore (typeof(string), 
			                                         typeof(IEC61850.SCL.tPTypeEnum));
			this.tplist.Model = tpmodel;
			
			this.notebook.Page = 0; // Show the Address Tab
			
			this.accesspointdetails.Expanded = false;
			this.accesspointdetails.Sensitive = false;
			this.connectiondetails.Expanded = false;
			this.connectiondetails.Sensitive = false;
			this.aplndetails.Expanded = false;
		}

		void HandleAddresstreeviewSelectionhandleChanged (object sender, EventArgs e)
		{
			Gtk.TreeSelection sel = (Gtk.TreeSelection) sender;
			Gtk.TreeIter seliter;
			if (sel.GetSelected(out seliter) && this.sclfile != null) {
				Gtk.TreeStore model = (Gtk.TreeStore) this.addresstreeview.Model;
				int tpindex = (int) model.GetValue(seliter, 1);
				IEC61850.SCL.tPTypeEnum tpdata = (IEC61850.SCL.tPTypeEnum) model.GetValue(seliter, 2);
				
				Gtk.TreeIter siter;
				Gtk.ListStore submodel = (Gtk.ListStore) this.subnetworklist.Model;
				this.subnetworklist.GetActiveIter(out siter);
				int subnet = (int) submodel.GetValue(siter, 1);
				int conap = (int) submodel.GetValue(siter, 3);
				
				IEC61850.SCL.tAddress 
					address = this.sclfile.GetIEDAddress (subnet, conap);
				this.addressvalue.Text = address.P[tpindex].Value;
				
				Gtk.ListStore tpmodel = (Gtk.ListStore) this.tplist.Model;
				Gtk.TreeIter tpiter;
				if (tpmodel.GetIterFirst(out tpiter)) {
					while (true) {
						IEC61850.SCL.tPTypeEnum tp = (IEC61850.SCL.tPTypeEnum) tpmodel.GetValue (tpiter, 1);
						if (tp.Equals((IEC61850.SCL.tPTypeEnum) tpdata)) {
							this.tplist.SetActiveIter(tpiter);
							break;
						}
						if (!tpmodel.IterNext(ref tpiter))
							break;
					}
				}
			}
		}

		void HandlePhysicaltreeviewSelectionhandleChanged (object sender, EventArgs e)
		{
			
		}

		void HandleSubnetworklisthandleChanged (object sender, EventArgs e)
		{
			Gtk.ListStore submodel = (Gtk.ListStore) this.subnetworklist.Model;
			Gtk.TreeIter siter;
			if (this.subnetworklist.GetActiveIter (out siter) && this.sclfile != null) {
				int subn = (int) submodel.GetValue (siter, 1);
				if (!(subn < 0)) {
					int cap = (int) submodel.GetValue (siter, 3);
					IEC61850.SCL.tConnectedAP connap = this.sclfile.GetIEDConnectedAP(subn, cap);
					if (connap != null) {
						// Remove all Address
						Gtk.TreeStore addmodel = (Gtk.TreeStore) this.addresstreeview.Model;
						Gtk.TreeIter aiter;
						while(addmodel.GetIterFirst(out aiter))
							addmodel.Remove(ref aiter);
						
						// Fill Adress List
						if (connap.Address.P != null) {
							for (int i = 0; i < connap.Address.P.GetLength(0); i++) {
								string text = this.sclfile.GetPDescription(connap.Address.P[i].type);
								string name = this.sclfile.GetPName(connap.Address.P[i].type);
								addmodel.AppendValues(name, i, 
								                      connap.Address.P[i].type,
								                      text);
							}
						}
						// Select first element
						addmodel.GetIterFirst(out aiter);
						this.addresstreeview.Selection.SelectIter(aiter);
						
						this.accesspointdetails.Sensitive = true;
						this.connectiondetails.Sensitive = true;
						this.connectiondetails.Expanded = true;
					}
				}
				else {
					this.connectiondetails.Expanded = false;
					this.connectiondetails.Sensitive = false;
				}
			}
		}
		
		public APEditor ()
		{
			this.Init ();
		}
		public APEditor  (OpenSCL.Object sclfile, int iedIndex, int apIndex)
		{
			this.Init();
			this.SetAP (sclfile, iedIndex, apIndex);
		}
		
		
		private bool SelectAP (OpenSCL.Object sclfile, int iedIndex, int apIndex)
		{
			if (sclfile == null)
				return false;
			
			IEC61850.SCL.tAccessPoint ap = sclfile.GetAP (iedIndex, apIndex);
			
			if (ap == null)
				return false;
			this.Clear();
			
			this.connectedap = sclfile.GetIEDConnectedAP (iedIndex);
			
			this.accesspointname.Text = ap.name;
			this.accesspointdesc.Text = ap.desc;
			this.accesspointisrouter.Active = ap.router;
			this.accesspointisclock.Active = ap.clock;
			
			Gtk.TreeStore aplnmodel = (Gtk.TreeStore) this.aplntreeview.Model;
			
			// Populate AP's LN list
			if (ap.LN != null) {
				for (int i = 0; i < ap.LN.GetLength(0); i++) {
					string ln = "";
					ln += ap.LN[i].prefix;
					ln += ap.LN[i].lnClass;
					ln += ap.LN[i].inst;
					aplnmodel.AppendValues(ln, i, ap.LN[i].desc);
				}
			}
			
			// Fill Subnetworks
			Gtk.ListStore subnetmodel = (Gtk.ListStore) this.subnetworklist.Model;
			Gtk.TreeIter siter, sel;
			subnetmodel.AppendValues(Mono.Unix.Catalog.GetString("No Subnetwork"),
			                         -1, 
			                         Mono.Unix.Catalog.GetString("This AP is not connected to any Subnetwork"),
			                         -1);
			if (sclfile.Subnetworks != null) {
				for (int i = 0; i < sclfile.Subnetworks.GetLength(0); i++) {
					subnetmodel.AppendValues(sclfile.Subnetworks[i].name, i,
				    	  		             sclfile.Subnetworks[i].desc, -1);
				}
			}
			
			// Search for ConnectedAP to a Subnetwork
			bool l = subnetmodel.GetIterFirst(out siter);
			sel = siter;
			while (l) {
				for (int j = 0; j < this.connectedap.Count; j++) {
					OpenSCL.IEDConnectedAP cap = (OpenSCL.IEDConnectedAP) this.connectedap[j];
					if (cap.subnetwork == (int) subnetmodel.GetValue (siter, 1)) {
						sel = siter;
						subnetmodel.SetValue(siter, 3, cap.connectedap);
					}
				}
				l = subnetmodel.IterNext(ref siter);
			}
			this.subnetworklist.SetActiveIter (sel);
			
			// Add tPTypes to tplist combobox
			Gtk.ListStore tpmodel = (Gtk.ListStore) this.tplist.Model;
			
			tpmodel.AppendValues(sclfile.GetPName (IEC61850.SCL.tPTypeEnum.APPID)
			                     , IEC61850.SCL.tPTypeEnum.APPID);
			tpmodel.AppendValues(sclfile.GetPName (IEC61850.SCL.tPTypeEnum.IP)
			                     , IEC61850.SCL.tPTypeEnum.IP);
			tpmodel.AppendValues(sclfile.GetPName (IEC61850.SCL.tPTypeEnum.IP_GATEWAY)
			                     , IEC61850.SCL.tPTypeEnum.IP_GATEWAY);
			tpmodel.AppendValues(sclfile.GetPName (IEC61850.SCL.tPTypeEnum.IP_SUBNET)
			                     , IEC61850.SCL.tPTypeEnum.IP_SUBNET);
			tpmodel.AppendValues(sclfile.GetPName (IEC61850.SCL.tPTypeEnum.MAC_Address)
			                     , IEC61850.SCL.tPTypeEnum.MAC_Address);
			tpmodel.AppendValues(sclfile.GetPName (IEC61850.SCL.tPTypeEnum.OSI_AE_Invoke)
			                     , IEC61850.SCL.tPTypeEnum.OSI_AE_Invoke);
			tpmodel.AppendValues(sclfile.GetPName (IEC61850.SCL.tPTypeEnum.OSI_AE_Qualifier)
			                     , IEC61850.SCL.tPTypeEnum.OSI_AE_Qualifier);
			tpmodel.AppendValues(sclfile.GetPName (IEC61850.SCL.tPTypeEnum.OSI_AP_Invoke)
			                     , IEC61850.SCL.tPTypeEnum.OSI_AP_Invoke);
			tpmodel.AppendValues(sclfile.GetPName (IEC61850.SCL.tPTypeEnum.OSI_AP_Title)
			                     , IEC61850.SCL.tPTypeEnum.OSI_AP_Title);
			tpmodel.AppendValues(sclfile.GetPName (IEC61850.SCL.tPTypeEnum.OSI_NSAP)
			                     , IEC61850.SCL.tPTypeEnum.OSI_NSAP);
			tpmodel.AppendValues(sclfile.GetPName (IEC61850.SCL.tPTypeEnum.OSI_PSEL)
			                     , IEC61850.SCL.tPTypeEnum.OSI_PSEL);
			tpmodel.AppendValues(sclfile.GetPName (IEC61850.SCL.tPTypeEnum.OSI_SSEL)
			                     , IEC61850.SCL.tPTypeEnum.OSI_SSEL);
			tpmodel.AppendValues(sclfile.GetPName (IEC61850.SCL.tPTypeEnum.OSI_TSEL)
			                     , IEC61850.SCL.tPTypeEnum.OSI_TSEL);
			tpmodel.AppendValues(sclfile.GetPName (IEC61850.SCL.tPTypeEnum.VLAN_ID)
			                     , IEC61850.SCL.tPTypeEnum.VLAN_ID);
			tpmodel.AppendValues(sclfile.GetPName (IEC61850.SCL.tPTypeEnum.VLAN_PRIORITY)
			                     , IEC61850.SCL.tPTypeEnum.VLAN_PRIORITY);
			
			this.accesspointdetails.Sensitive = true;
			return true;
		}
		
		public bool SetAP (OpenSCL.Object sclfile, int iedIndex, int apIndex)
		{
			if (sclfile == null)
				return false;
			
			this.sclfile = sclfile;
			if (this.SelectAP(sclfile, iedIndex, apIndex)) {
				this.numied = iedIndex;
				this.numap = apIndex;
				this.Sensitive = true;
				return true;
			}
			else {
				this.sclfile = null;
				this.numied = -1;
				this.numap = -1;
				this.Clear();
				return false;
			}
		}
		
		public bool ChangeAP (int apIndex)
		{
			this.numap = apIndex;
			
			if (this.SelectAP(this.sclfile, this.numied, apIndex)) {
				return true;
			}
			else {
				this.Clear();
				this.numap = -1;
				this.numied = -1;
				this.sclfile = null;
				
				return false;
			}
		}
		
		public void Clear () 
		{
			// AP Details
			this.accesspointdesc.Text = "";
			this.accesspointname.Text = "";
			this.accesspointisclock.Active = false;
			this.accesspointisrouter.Active = false;
			this.accesspointdetails.Expanded = false;
			this.accesspointdetails.Sensitive = false;
			this.connectiondetails.Expanded = false;
			this.connectiondetails.Sensitive = false;
			
			// Subnetwork
			Gtk.TreeIter iter;
			Gtk.ListStore subnetmodel = (Gtk.ListStore) this.subnetworklist.Model;
			while(subnetmodel.GetIterFirst(out iter))
				subnetmodel.Remove(ref iter);
			
			// AP LN
			Gtk.TreeStore lnmodel = (Gtk.TreeStore) this.aplntreeview.Model;
			while (lnmodel.GetIterFirst(out iter))
				lnmodel.Remove(ref iter);
			
			// AP Address
			Gtk.TreeStore addmodel = (Gtk.TreeStore) this.physicaltreeview.Model;
			while (addmodel.GetIterFirst(out iter))
				addmodel.Remove(ref iter);
			this.addressvalue.Text = "";
			
			// TP list
			Gtk.ListStore tpmodel = (Gtk.ListStore) this.tplist.Model;
			while (tpmodel.GetIterFirst (out iter))
				tpmodel.Remove(ref iter);
			this.Sensitive = false;
		}
	}
}
