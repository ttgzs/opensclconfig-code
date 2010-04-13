
using System;
using OpenSCL;
using IEC61850.SCL;

namespace OpenSASUI
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class IEDEditor : Gtk.Bin, IContainer
	{
		private int numied;
		private OpenSCL.Object sclfile;
		private OpenSASUI.IContainer container;
		
		private void Init()
		{
			this.Build ();
			Gtk.TreeStore model = new Gtk.TreeStore (GLib.GType.String, 
			                                         GLib.GType.Int, 
			                                         GLib.GType.String);
			Gtk.TreeIter root = model.AppendNode();
			model.SetValues(root,
			                Mono.Unix.Catalog.GetString("Logical Devices"),
			                0,
			                Mono.Unix.Catalog.GetString("Add Logical Devices"));
			this.treeview.Model = model;
			
			this.treeview.AppendColumn (Mono.Unix.Catalog.GetString("Logical Devices"),
			                            new Gtk.CellRendererText (), "text", 0);
			this.treeview.AppendColumn (Mono.Unix.Catalog.GetString("Description"),
			                            new Gtk.CellRendererText (), "text", 2);
			this.treeview.GetColumn(0).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			
			this.treeview.Selection.Changed += HandleTreeviewSelectionhandleChanged;
			this.treeview.RowActivated += HandleTreeviewRowActivated;
			
			Gtk.ListStore ldmodel = new Gtk.ListStore(GLib.GType.String, GLib.GType.Int, GLib.GType.Int);
			this.ldlist.Model = ldmodel;
			this.ldlist.Changed += HandleLdlistChanged;
			
			Gtk.ListStore apmodel = new Gtk.ListStore(GLib.GType.String, GLib.GType.Int, GLib.GType.Int);
			this.accesspointlist.Model = apmodel;
			this.accesspointlist.Changed += HandleAccesspointlisthandleChanged;
			
			
			this.notebook.Page = 0; // Select IED tab
			this.Sensitive = false;
		}

		void HandleAccesspointlisthandleChanged (object sender, EventArgs e)
		{
			Gtk.ListStore apmodel = (Gtk.ListStore) this.accesspointlist.Model;
			Gtk.TreeIter sel;
			if (this.accesspointlist.GetActiveIter(out sel)) {
				int ap = (int) apmodel.GetValue(sel, 1);
				this.accesspointeditor.SetAP(this.sclfile, this.numied, ap, this);
			}
		}

		void HandleTreeviewRowActivated (object o, Gtk.RowActivatedArgs args)
		{
			Gtk.TreeIter seliter;
			Gtk.TreeSelection sel = this.treeview.Selection;
			if (sel.GetSelected(out seliter)) {
				Gtk.TreeStore model = (Gtk.TreeStore) this.treeview.Model;
				Gtk.TreePath path = model.GetPath(seliter);
				if (path.Indices.GetLength(0) == 3) 
					this.notebook.Page = 2;
				if (path.Indices.GetLength(0) == 2)
					this.notebook.Page = 1;
			}
		}

		void HandleLdlistChanged (object sender, EventArgs e)
		{
			Gtk.TreeIter seliter;
			if (this.ldlist.GetActiveIter(out seliter))
			{
				Gtk.ListStore ldmodel = (Gtk.ListStore) this.ldlist.Model;
				int apnum = (int) ldmodel.GetValue(seliter, 1);
				int ldnum = (int) ldmodel.GetValue(seliter, 2);
				this.ldedit.SetLD(this.sclfile, this.numied, apnum, ldnum);
			}
		}

		void HandleTreeviewSelectionhandleChanged (object sender, EventArgs e)
		{
			Gtk.TreeIter seliter;
			Gtk.TreeSelection sel = (Gtk.TreeSelection) sender;
			if (sel.GetSelected(out seliter))
			{
				Gtk.TreeStore model = (Gtk.TreeStore) this.treeview.Model;
				Gtk.ListStore ldmodel = (Gtk.ListStore) this.ldlist.Model;
				Gtk.ListStore apmodel = (Gtk.ListStore) this.accesspointlist.Model;
				
				Gtk.TreePath path = model.GetPath(seliter);
				
				Gtk.TreeIter apiter;
				int apindex = -1;
							
				if (path.Depth == 2)
				{
					int numld = (int) model.GetValue(seliter, 1);
					Gtk.TreePath ph = this.treeview.Model.GetPath(seliter);
					ph.Up();
					model.GetIter (out apiter, ph);
					apindex = (int) model.GetValue(apiter, 1);
					this.ldedit.SetLD(this.sclfile, this.numied, apindex, numld);
					
					Gtk.TreeIter ldlistiter;
					int[] lds = { numld };
					Gtk.TreePath ldph = new Gtk.TreePath(lds);
					ldmodel.GetIter(out ldlistiter, ldph);
					this.ldlist.SetActiveIter(ldlistiter);
				}
				
				if (path.Indices.GetLength(0) == 1) {
					apindex = (int) model.GetValue(seliter, 1);
				}
				
				int[] aps = { apindex };
				Gtk.TreePath apph = new Gtk.TreePath(aps);
				apmodel.GetIter(out apiter, apph);
				this.accesspointlist.SetActiveIter(apiter);
				this.accesspointeditor.SetAP(this.sclfile, this.numied, apindex, this);
			}
		}
		
		public IEDEditor ()
		{
			this.Init ();
		}
		
		public IEDEditor (OpenSCL.Object sclfile, int numied, OpenSASUI.IContainer topcontainer)
		{
			this.Init();
			this.SetIED(sclfile, numied, topcontainer);
		}
		
		private bool SelectIED (OpenSCL.Object sclfile, int iednum)
		{
			Gtk.TreeIter iter;
			
			this.Clear();
			
			tIED ied = sclfile.GetIED(iednum);
			
			if (ied == null)
				return false;
			if (ied.AccessPoint == null)
				return false;
			
			string info = Mono.Unix.Catalog.GetString("Name: ");
			info += ied.name;
			
			info += Mono.Unix.Catalog.GetString("\nManufacturer: ");
			info += ied.manufacturer;
			
			info += Mono.Unix.Catalog.GetString("\nConfig. Version: ");
			info += ied.configVersion;
			info += "\n";
			
			this.DeviceInformationLabel.Text = info;
			this.iedname.Text = ied.name;
			if (ied.manufacturer != null)
				this.iedmanufacturer.Entry.Text = ied.manufacturer;
			else {
				this.iedmanufacturer.Model.GetIterFirst(out iter);
				this.iedmanufacturer.SetActiveIter(iter);
			}
			
			this.iedconfigrevision.Text = ied.configVersion;
			string desc = "";
			
			desc += ied.desc;
			
			this.DeviceDescription.Text = desc;
			
			// Populate Tree Model
			Gtk.TreeStore model = (Gtk.TreeStore) this.treeview.Model;
			Gtk.ListStore ldmodel = (Gtk.ListStore) this.ldlist.Model;
			
			// Append AP and LD to treeview
			Gtk.TreeIter rootap = model.AppendValues(Mono.Unix.Catalog.GetString("Access Points"),
			                                         0, "");
			for (int i = 0; i < ied.AccessPoint.GetLength(0); i++) {
				Gtk.TreeIter apiter = model.AppendValues(rootap, ied.AccessPoint[i].name,
				                   i,
				                   ied.AccessPoint[i].desc);
				if (ied.AccessPoint[i].Server != null)
				{
					for (int j = 0; j < ied.AccessPoint[i].Server.LDevice.GetLength(0); j++) {
						string lddesc = "";
						lddesc = ied.AccessPoint[i].Server.LDevice[j].desc;
						
						string name = "";
						name += ied.AccessPoint[i].Server.LDevice[j].inst;
						
						if(name.Length == 0)
							name = Mono.Unix.Catalog.GetString("LD (No Name)");
						
						model.AppendValues(apiter, name, j, lddesc);
						
						string ldref = Mono.Unix.Catalog.GetString("AccessPoint(");
						ldref += ied.AccessPoint[i].name;
						ldref += ")/";
						ldref += name;
						ldmodel.AppendValues(ldref, i, j);
					}
				}
			}
			
			
			// Populate Access Point list
			Gtk.ListStore apmodel = (Gtk.ListStore) this.accesspointlist.Model;
			for (int j = 0; j < ied.AccessPoint.GetLength(0); j++) {
				apmodel.AppendValues(ied.AccessPoint[j].name, j,
				                     ied.AccessPoint[j].desc);
			}
			
			int apindex = -1;
			if (apmodel.GetIterFirst(out iter)) {
				this.accesspointlist.SetActiveIter(iter);
				apindex = (int) apmodel.GetValue (iter, 1);
				this.accesspointeditor.SetAP(this.sclfile, this.numied, apindex, this);
			}
			
			if (ldmodel.GetIterFirst(out iter)) {
				this.ldlist.SetActiveIter(iter);
				int fldnum = (int) ldmodel.GetValue(iter, 1);
				this.ldedit.SetLD(this.sclfile, this.numied, apindex, fldnum);
			}
			// Private
			
			// finishing
			this.treeview.ExpandAll();
			//this.notebook.Page = 0; // Select General IED viewer
			
			return true;
		}
		
		public bool SetIED (OpenSCL.Object sclfile, int iedIndex, OpenSASUI.IContainer topcontainer)
		{
			this.numied = iedIndex;
			this.sclfile = sclfile;
			this.container = topcontainer;
				
			if (this.SelectIED(sclfile, iedIndex)) {
				this.Sensitive = true;
				return true;
			}
			else {
				Gtk.MessageDialog msg = new Gtk.MessageDialog(null, Gtk.DialogFlags.DestroyWithParent,
				                                              Gtk.MessageType.Error, Gtk.ButtonsType.Close,
				                                              false, 
				                                              Mono.Unix.Catalog.GetString("Error on Set IED %i"),
				                                              iedIndex);
				msg.Run();
				this.numied = -1;
				this.sclfile = null;
				
				return false;
			}
		}
		
		public bool ChangeIED (int iedIndex)
		{
			if (this.SelectIED (this.sclfile, iedIndex)) {
				this.numied = iedIndex;
				return true;
			}
			else
				return false;
		}
		
		public void Clear ()
		{
			// Flush All
			Gtk.TreeStore model = (Gtk.TreeStore) this.treeview.Model;
			Gtk.ListStore ldmodel = (Gtk.ListStore) this.ldlist.Model;
			Gtk.TreeIter iter;
			while (model.GetIterFirst(out iter))
				model.Remove(ref iter);
			while (ldmodel.GetIterFirst(out iter))
				ldmodel.Remove(ref iter);
			// Remove rows form AP list
			Gtk.ListStore apmodel = (Gtk.ListStore) this.accesspointlist.Model;
			while (apmodel.GetIterFirst(out iter))
			       apmodel.Remove(ref iter);
			
			this.Sensitive = false;
		}
		
		// Interface OpenSASUI.IContainer
		public void Reset ()
		{
			if (this.ChangeIED(this.numied))
				this.Sensitive = true;
		}
	}
}
