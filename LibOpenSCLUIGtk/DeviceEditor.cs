// 
//  DeviceEditor.cs
//  
//  Author:
//       Nombre completo <Dirección de correo electrónico>
//  
//  Copyright (c) 2010 Nombre completo
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using OpenSCL;
using IEC61850.SCL;
using GLib;

namespace LibOpenSCLUIGtk
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class DeviceEditor : Gtk.Bin
	{
		private int numied;
		private OpenSCL.Object sclfile;
		
		private void Init()
		{
			this.Build ();
			Gtk.TreeStore model = new Gtk.TreeStore (GLib.GType.String, 
			                                         GLib.GType.Int, 
			                                         GLib.GType.String);
			Gtk.TreeIter root = model.AppendNode();
			model.SetValues(root,
			                "Logical Devices",
			                0,
			                "Add Logical Devices");
			this.treeview.Model = model;
			
			this.treeview.AppendColumn ("Logical Devices", new Gtk.CellRendererText (), "text", 0);
			this.treeview.AppendColumn ("Description", new Gtk.CellRendererText (), "text", 2);
			
			this.treeview.Selection.Changed += HandleTreeviewSelectionhandleChanged;
			this.treeview.RowActivated += HandleTreeviewRowActivated;
			
			Gtk.ListStore ldmodel = new Gtk.ListStore(GLib.GType.String, GLib.GType.Int, GLib.GType.Int);
			this.ldlist.Model = ldmodel;
			this.ldlist.Changed += HandleLdlistChanged;
			
			this.notebook.Page = 0; // Select IED tab
		}

		void HandleTreeviewRowActivated (object o, Gtk.RowActivatedArgs args)
		{
			this.notebook.Page = 2;
		}

		void HandleLdlistChanged (object sender, EventArgs e)
		{
			Gtk.TreeIter seliter;
			if (this.ldlist.GetActiveIter(out seliter))
			{
				Gtk.ListStore ldmodel = (Gtk.ListStore) this.ldlist.Model;
				int apnum = (int) ldmodel.GetValue(seliter, 1);
				int ldnum = (int) ldmodel.GetValue(seliter, 2);
				this.ldedit.ChangeLD(apnum, ldnum);
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
				
				Gtk.TreePath path = model.GetPath(seliter);
				
				if (path.Indices.GetLength(0) > 1)
				{
					Gtk.TreeIter apiter;
					
					int numld = (int) model.GetValue(seliter, 1);
					Gtk.TreePath ph = this.treeview.Model.GetPath(seliter);
					ph.Up();
					model.GetIter (out apiter, ph);
					int apindex = (int) model.GetValue(apiter, 1);
					this.ldedit.SetLD(this.sclfile, this.numied, apindex, numld);
					Gtk.TreeIter ldlistiter;
					int[] lds = { numld };
					Gtk.TreePath ldph = new Gtk.TreePath(lds);
					ldmodel.GetIter(out ldlistiter, ldph);
					this.ldlist.SetActiveIter(ldlistiter);				
				}
			}
		}
		
		public DeviceEditor ()
		{
			this.Init();
		}
		
		public DeviceEditor (OpenSCL.Object sclfile, int numied)
		{
			this.Init();
			this.SetIED(sclfile, numied);
		}
		
		public void SetIED (OpenSCL.Object sclfile, int iednum)
		{
			this.numied = iednum;
			this.sclfile = sclfile;
			
			tIED ied = this.sclfile.GetIED(numied);
			string info = "Name: ";
			info += ied.name;
			
			info += "\nManufacturer: ";
			info += ied.manufacturer;
			
			info += "\nConfig. Version: ";
			info += ied.configVersion;
			info += "\n";
			
			this.DeviceInformationLabel.Text = info;
			this.iedname.Text = ied.name;
			this.iedmanufacturer.Entry.Text = ied.manufacturer;
			this.iedconfigrevision.Text = ied.configVersion;
			string desc = "";
			
			desc += ied.desc;
			
			this.DeviceDescription.Text = desc;
			
			// Populate Tree Model
			Gtk.TreeStore model = (Gtk.TreeStore) this.treeview.Model;
			Gtk.ListStore ldmodel = (Gtk.ListStore) this.ldlist.Model;
			// Flush All
			Gtk.TreeIter root;
			while (model.GetIterFirst(out root))
				model.Remove(ref root);
			
			Gtk.TreeIter rootap = model.AppendValues("Access Points", 0, "");
			for (int i = 0; i < ied.AccessPoint.GetLength(0); i++) {
				Gtk.TreeIter ap = model.AppendValues(rootap, ied.AccessPoint[i].name,
				                   i,
				                   ied.AccessPoint[i].desc);
				if (ied.AccessPoint[i].Server != null)
				{
					for (int j = 0; j < ied.AccessPoint[i].Server.LDevice.GetLength(0); j++) {
						string lddesc = "";
						lddesc = ied.AccessPoint[i].Server.LDevice[j].desc;
						
						string name = "";
						name += ied.AccessPoint[i].Server.LDevice[j].ldName;
						name += ied.AccessPoint[i].Server.LDevice[j].inst;
						
						if(name.Length == 0)
							name = "LD (No Name)";
						
						model.AppendValues(ap, name, j, lddesc);
						
						string ldref = "AccessPoint(";
						ldref += ied.AccessPoint[i].name;
						ldref += ")/";
						ldref += name;
						ldmodel.AppendValues(ldref, i, j);
					}
				}
			}
			this.treeview.ExpandAll();
			this.notebook.Page = 0; // Select General IED viewer
		}
	}
}
