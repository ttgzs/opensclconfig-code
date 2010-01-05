// 
//  LDEdit.cs
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
using IEC61850.SCL;
using Mono.Unix;


namespace LibOpenSCLUIGtk
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class LDEdit : Gtk.Bin
	{
		private int ldindex;
		private int iedindex;
		private int apindex;
		private OpenSCL.Object sclfile;
		
		private void Init()
		{
			this.Build ();
			this.ldindex = -1;
			this.iedindex = -1;
			this.apindex = -1;
			// LN tree View
			Gtk.TreeStore model = new Gtk.TreeStore (GLib.GType.String , GLib.GType.Int, GLib.GType.String);
			Gtk.TreeIter root = model.AppendNode();
			model.SetValues(root,
			                "No Logical Nodes",
			                0,
			                "Add new Logical Nodes");
			this.lntreeview.Model = model;
			
			this.lntreeview.AppendColumn ("LN Class", new Gtk.CellRendererText (), "text", 0);
			this.lntreeview.AppendColumn ("Description", new Gtk.CellRendererText (), "text", 2);
			
			this.lntreeview.Selection.Changed += HandleLntreeviewSelectionhandleChanged;
			
			// DO tree View
			Gtk.TreeStore domodel = new Gtk.TreeStore (GLib.GType.String , GLib.GType.Int, GLib.GType.String);
			this.dotreeview.Model = domodel;
			
			this.dotreeview.AppendColumn ("Data Object", new Gtk.CellRendererText (), "text", 0);
			this.dotreeview.AppendColumn ("Description", new Gtk.CellRendererText (), "text", 2);
		}

		void HandleLntreeviewSelectionhandleChanged (object sender, EventArgs e)
		{
			Gtk.TreeIter seliter;
			Gtk.TreeSelection sel = (Gtk.TreeSelection) sender;
			if (sel.GetSelected(out seliter))
			{
				Gtk.TreeStore model = (Gtk.TreeStore) this.lntreeview.Model;
				Gtk.TreeStore domodel = (Gtk.TreeStore) this.dotreeview.Model;
				
				Gtk.TreePath path = model.GetPath(seliter);
				
				int i = (int) model.GetValue (seliter, 1);
				// Remove Nodes on DOI view
				
				Gtk.TreeIter iter;
				while(domodel.GetIterFirst(out iter))
					domodel.Remove(ref iter);
				// Fill DOI information
				if (this.LogicalDevice.LN[i].DOI != null)
				{
					for (int j = 0; j < this.LogicalDevice.LN[i].DOI.GetLength(0); j++)
						domodel.AppendValues (this.LogicalDevice.LN[i].DOI[j].name,
						                    j, this.LogicalDevice.LN[i].DOI[j].desc);
				}
				else
					model.AppendValues("No DOI Information", 0,
					                   "Sugestion: See at Data Type Templates");
			}
		}
		
		public LDEdit ()
		{
			this.Init();
		}
		
		public LDEdit (OpenSCL.Object sclfile, int numied, int numap, int numld)
		{
			this.Init();
			this.SetLD(sclfile, numied, numap, numld);
		}
		
		
		private tLDevice LogicalDevice
		{
			get {
				return this.sclfile.GetLogicalDevice(this.iedindex, this.apindex, this.ldindex);
			}
		}
		
		private bool SelectLD (int numied, int numap, int numld)
		{
			if (this.sclfile.GetLogicalDevice(numied, numap, numld) == null)
				return false;
			
			this.iedindex = numied;
			this.apindex = numap;
			this.ldindex = numld;
			
			this.ldname.Text = this.LogicalDevice.ldName;
			this.ldinstance.Text = this.LogicalDevice.inst;
			// Delete All LN
			Gtk.TreeIter lniter;
			Gtk.TreeStore lnmodel = (Gtk.TreeStore) this.lntreeview.Model;
			
			while (this.lntreeview.Model.GetIterFirst(out lniter))
			{
				lnmodel.Remove(ref lniter);
			}
			//Populate Logical Nodes
			if (this.LogicalDevice.LN != null)
			{
			    for (int i = 0; i < this.LogicalDevice.LN.GetLength(0); i++)
				{
					lnmodel.AppendValues(this.LogicalDevice.LN[i].lnClass, i, 
					                     this.LogicalDevice.LN[i].desc);
				}
				return true;
			}
			else 
				return false;
		}
		
		public bool SetLD (OpenSCL.Object sclfile, int numied, int numap, int numld)
		{
			if (sclfile == null)
				return false;
			this.sclfile = sclfile;
			return this.SelectLD(numied, numap, numld);
		}
		
		public bool ChangeLD (int apIndex, int ldIndex)
		{
			return this.SelectLD (this.iedindex, apIndex, ldIndex);
		}
	}
}
