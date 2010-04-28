
using System;
using OpenSCL;
using IEC61850.SCL;

namespace OpenSASUI
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class APEditor : Gtk.Bin, IContainer
	{
		private OpenSCL.Object sclfile;
		private int numied;
		private int numap;
		private System.Collections.ArrayList connectedap;
		private OpenSASUI.IContainer container;
		
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
			
			Gtk.TreeStore addressmodel = new Gtk.TreeStore (typeof(string), // Type text
			                                         typeof(int), // TP index
			                                         typeof(IEC61850.SCL.tPTypeEnum), // Type type 
			                                         typeof(string)); // TP description
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
			// Add pre-defined types
			IEC61850.SCL.tPType type = new IEC61850.SCL.tPType();
			for (int t = 0; t < (int) IEC61850.SCL.tPTypeEnum.EXTENSION; t++) {
				type.typeEnum = (IEC61850.SCL.tPTypeEnum) t;
				tpmodel.AppendValues(type.type, type.typeEnum);
			}
			
			this.notebook.Page = 0; // Show the Address Tab
			
			this.accesspointdetails.Expanded = false;
			this.accesspointdetails.Sensitive = false;
			this.connectiondetails.Expanded = false;
			this.connectiondetails.Sensitive = false;
			this.aplndetails.Expanded = false;
			
			//Edition signals
			this.addressvalue.Activated += HandleAddressvaluehandleActivated;
			this.tplist.Changed += HandleTplisthandleChanged;
			this.tplist.Entry.Activated += HandleTplistEntryhandleActivated;
			this.accesspointname.Activated += HandleAccesspointnamehandleActivated;
			this.accesspointdesc.Activated += HandleAccesspointdeschandleActivated;
			this.accesspointisclock.Toggled += HandleAccesspointisclockhandleToggled;
			this.accesspointisrouter.Toggled += HandleAccesspointisrouterhandleToggled;
		}

		
		void HandleAccesspointisrouterhandleToggled (object sender, EventArgs e)
		{
			if (this.sclfile != null) {
				IEC61850.SCL.tAccessPoint ap = this.sclfile.GetAP(this.numied, this.numap);
				if (ap != null)
					ap.router = this.accesspointisrouter.Active;
			}
		}

		void HandleAccesspointisclockhandleToggled (object sender, EventArgs e)
		{
			if (this.sclfile != null) {
				IEC61850.SCL.tAccessPoint ap = this.sclfile.GetAP(this.numied, this.numap);
				if (ap != null)
					ap.clock = this.accesspointisclock.Active;
			}
		}

		void HandleAccesspointdeschandleActivated (object sender, EventArgs e)
		{
			if (this.sclfile != null) {
				IEC61850.SCL.tAccessPoint ap = this.sclfile.GetAP(this.numied, this.numap);
				if (ap != null)
					ap.desc = this.accesspointdesc.Text;
			}
		}

		void HandleAccesspointnamehandleActivated (object sender, EventArgs e)
		{
			if (this.sclfile != null) {
				Gtk.TreeIter siter;
				Gtk.ListStore submodel = (Gtk.ListStore) this.subnetworklist.Model;
				
				if (this.subnetworklist.GetActiveIter(out siter)) {
					int subnetIndex = (int) submodel.GetValue(siter, 1);
					int conapIndex = (int) submodel.GetValue(siter, 3);
					IEC61850.SCL.tAccessPoint
							ap = this.sclfile.GetAP(this.numied, this.numap);
					IEC61850.SCL.tConnectedAP 
						conap = this.sclfile.GetConnectedAP (subnetIndex, conapIndex);
					if (ap != null && conap != null)
						if (!ap.name.Equals(this.accesspointname.Text)) {
						ap.name = this.accesspointname.Text;
						conap.apName = ap.name;
						this.container.Reset();
					}
				}
			}
		}

		void HandleAddressvaluehandleActivated (object sender, EventArgs e)
		{
			Gtk.TreeSelection sel = this.addresstreeview.Selection;
			Gtk.TreeIter seliter;
			if (sel.GetSelected(out seliter) && this.sclfile != null) {
				Gtk.TreeStore model = (Gtk.TreeStore) this.addresstreeview.Model;
				int tpindex = (int) model.GetValue(seliter, 1);
				
				Gtk.TreeIter siter;
				Gtk.ListStore submodel = (Gtk.ListStore) this.subnetworklist.Model;
				if (this.subnetworklist.GetActiveIter(out siter)) {
					int subnet = (int) submodel.GetValue(siter, 1);
					int conap = (int) submodel.GetValue(siter, 3);
					
					IEC61850.SCL.tP
						p = this.sclfile.GetPAddress(subnet, conap, tpindex);
					if (p != null)
						if (!p.Value.Equals (this.addressvalue.Text))
							p.Value = this.addressvalue.Text;
				}
			}	
		}
		
		void ChangeAddressTPType (IEC61850.SCL.tP tp)
		{
			Gtk.TreeSelection sel = this.addresstreeview.Selection;
			Gtk.TreeIter seliter;
			if (sel.GetSelected(out seliter) && this.sclfile != null) {
				Gtk.TreeStore model = (Gtk.TreeStore) this.addresstreeview.Model;
				int tpindex = (int) model.GetValue(seliter, 1);
				
				Gtk.TreeIter siter;
				Gtk.ListStore submodel = (Gtk.ListStore) this.subnetworklist.Model;
				if (this.subnetworklist.GetActiveIter(out siter)) {
					int subnet = (int) submodel.GetValue(siter, 1);
					int conap = (int) submodel.GetValue(siter, 3);
						
					IEC61850.SCL.tP 
						p = this.sclfile.GetPAddress (subnet, conap, tpindex);
					if (p != null) 
						if (!p.type.Equals(tp.type)) {
							p.type = tp.type;
							model.SetValue(seliter, 0, p.type);
							model.SetValue(seliter, 2, p.typeEnum);
							model.SetValue(seliter, 3, p.Description);
						}
				}
			}
		}
	
		void HandleTplisthandleChanged (object sender, EventArgs e)
		{
			Gtk.ListStore tpmodel = (Gtk.ListStore) this.tplist.Model;
			Gtk.TreeIter tpiter;
			
			if (this.tplist.GetActiveIter(out tpiter)) {
			
				IEC61850.SCL.tP tp = new IEC61850.SCL.tP();
				tp.type = (string) tpmodel.GetValue (tpiter, 0);
				this.ChangeAddressTPType(tp);
			}
			
		}

		void HandleTplistEntryhandleActivated (object sender, EventArgs e)
		{
			IEC61850.SCL.tP tp = new IEC61850.SCL.tP();
			tp.type = this.tplist.Entry.Text;
			this.AddressCheckCustomTP(tp);
			this.ChangeAddressTPType(tp);
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
				
				IEC61850.SCL.tP
					p = this.sclfile.GetPAddress (subnet, conap, tpindex);
				
				if(p != null)
					this.addressvalue.Text = p.Value;
				
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
		
		void AddressCheckCustomTP(IEC61850.SCL.tP tp)
		{
			// Check For Custom Types to add at tp list
			if (tp.typeEnum == tPTypeEnum.EXTENSION) {
				Gtk.ListStore tpmodel = (Gtk.ListStore) this.tplist.Model;
				// Search for this custom type
				bool exist = false;
				Gtk.TreeIter s;
				bool cont = tpmodel.GetIterFirst(out s);
				while (cont) {
					string t = (string) tpmodel.GetValue(s, 0);
					if (t.Equals(tp.type)) {
						exist = true;
						break;
					}
					Gtk.TreePath path = tpmodel.GetPath(s);
					path.Next();
					cont = tpmodel.GetIter(out s, path);
				}
				if(!exist) {
					tpmodel.AppendValues(tp.type, 
					                     tp.typeEnum);
				}
			}
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
						
						Gtk.ListStore tpmodel = (Gtk.ListStore) this.tplist.Model;
						
						// Remove all Address
						Gtk.TreeStore addmodel = (Gtk.TreeStore) this.addresstreeview.Model;
						Gtk.TreeIter aiter;
						while(addmodel.GetIterFirst(out aiter))
							addmodel.Remove(ref aiter);
						
						// Fill Adress List
						if (connap.Address.P != null) {
							for (int i = 0; i < connap.Address.P.GetLength(0); i++) {
								string text = connap.Address.P[i].Description;
								string name = connap.Address.P[i].type;
								addmodel.AppendValues(name, i, 
								                      connap.Address.P[i].typeEnum,
								                      text);
								// Check tP to be added
								this.AddressCheckCustomTP(connap.Address.P[i]);
							}
						}
						// Select first element
						addmodel.GetIterFirst(out aiter);
						this.addresstreeview.Selection.SelectIter(aiter);
						IEC61850.SCL.tPTypeEnum type;
						type = (IEC61850.SCL.tPTypeEnum) this.addresstreeview.Model.GetValue(aiter, 2);
						Gtk.TreeIter tpiter;
						if (tpmodel.GetIterFirst(out tpiter)) {
							while (true) {
								IEC61850.SCL.tPTypeEnum tp = (IEC61850.SCL.tPTypeEnum) 
																tpmodel.GetValue (tpiter, 1);
								if (tp.Equals(type)) {
									this.tplist.SetActiveIter(tpiter);
									break;
								}
								if (!tpmodel.IterNext(ref tpiter))
									break;
							}
						}
						
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
			this.SetAP (sclfile, iedIndex, apIndex, this);
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
			
			this.accesspointdetails.Sensitive = true;
			return true;
		}
		
		public bool SetAP (OpenSCL.Object sclfile, int iedIndex, int apIndex, OpenSASUI.IContainer topcontainer)
		{
			if (sclfile == null)
				return false;
			
			this.sclfile = sclfile;
			if (this.SelectAP(sclfile, iedIndex, apIndex)) {
				this.numied = iedIndex;
				this.numap = apIndex;
				this.Sensitive = true;
				this.container = topcontainer;
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
			
			this.Sensitive = false;
		}
		
		// Interface OpenSASUI.IContainer
		
		public void Reset ()
		{
			this.ChangeAP(this.numap);
		}
	}
}
