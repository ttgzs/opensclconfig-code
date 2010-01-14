// 
//  open-scl-treeview.cs
//  
//  Author:
//       Daniel Espinosa <esodan@gmail.com>
//  
//  Copyright (c) 2009 Daniel Espinosa
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
using Gtk;
using GLib;
using OpenSCL;

namespace OpenSCLUIGtk
{
	[System.ComponentModel.ToolboxItem(true)]
	public class SclTree : Gtk.TreeView
	{
		private OpenSCL.Object sclfile;
		private bool header_updated;
		private bool substation_updated;
		private bool ieds_updated;
		private bool communication_updated;
		
		private void Init ()
		{
			TreeStore model = new TreeStore (GLib.GType.String , GLib.GType.Int, GLib.GType.String);
			Gtk.TreeIter root = model.AppendNode();
			model.SetValues(root,
			                "No File Loaded",
			                0,
			                "Open or create a new SCL file");
			this.Model = model;
			
			this.AppendColumn ("Element", new Gtk.CellRendererText (), "text", 0);
			this.AppendColumn ("Description", new Gtk.CellRendererText (), "text", 2);
			this.GetColumn(0).Sizing = TreeViewColumnSizing.Autosize;
			
			this.Selection.Changed += HandleSelectionhandleChanged;
			
			header_updated = false;
			substation_updated = false;
			ieds_updated = false;
			communication_updated = false;
		}
		public SclTree ()
		{
			this.Init();
		}

		void HandleSelectionhandleChanged (object sender, EventArgs e)
		{
			Gtk.TreeIter seliter;
			Gtk.TreeSelection sel = (Gtk.TreeSelection) sender;
			if (sel.GetSelected(out seliter))
			{
				
				/*
				string txtdbg = "Selection Changed to: ";
				txtdbg += seliter.ToString();
				Gtk.MessageDialog debug = new Gtk.MessageDialog(null, 
				                                                DialogFlags.DestroyWithParent,
				                                                MessageType.Info,
				                                                ButtonsType.Close,
				                                                txtdbg);
				debug.Run();
				debug.Destroy();
				*/
				
				Gtk.TreePath path = this.Model.GetPath(seliter);
				
				
				if (path.Indices.GetLength(0) > 1)
				{
					int pos = path.Indices[1];
					
					switch (pos) {
					case 0: // Header
					{
						if (!this.header_updated)
						{
							if (this.sclfile.RevisionHistory != null)
							{
								Gtk.TreeStore model = (Gtk.TreeStore) this.Model;
								for (int i = 0; i < this.sclfile.RevisionHistory.GetLength(0); i++) {
																		
									string desc = "Version: ";
									desc += this.sclfile.RevisionHistory[i].version;
									desc += " Rv: ";
									desc += this.sclfile.RevisionHistory[i].revision;
									desc += " Desc: ";
									desc += this.sclfile.RevisionHistory[i].what;
									desc += " / By: ";
									desc += this.sclfile.RevisionHistory[i].who;
									desc += " / Reason: ";
									desc += this.sclfile.RevisionHistory[i].why;
									
									model.AppendValues(seliter,
								                   this.sclfile.RevisionHistory[i].when,
								                   i,
								                   desc);
								}
								
							}
							else
							{
								// FIXME: Set to RED the Header Node because no Revisión Information found
							}
							this.header_updated = true;
						}
					}
						break;
					case 1: // Substation
					{
						if (!substation_updated && this.sclfile.Substation != null)
						{
							Gtk.TreeStore model = (Gtk.TreeStore) this.Model;
							for (int i = 0; i < this.sclfile.Substation.GetLength(0); i++) {
								string desc;
								if (this.sclfile.Substation[i].desc != null)
									desc = this.sclfile.Substation[i].desc;
								else
									desc = "";
								
								model.AppendValues(seliter,
								                   this.sclfile.Substation[i].name,
								                   i,
								                   desc);
							}
							this.substation_updated = true;
						}
					}
						break;
					case 2: // Communication
					{
						if (!communication_updated && this.sclfile.Subnetworks != null)
						{
							Gtk.TreeStore model = (Gtk.TreeStore) this.Model;
							for (int i = 0; i < this.sclfile.Subnetworks.GetLength(0); i++) {
								string desc;
								if (this.sclfile.Subnetworks[i].desc != null)
									desc = this.sclfile.Subnetworks[i].desc;
								else
									desc = "";
								
								model.AppendValues (seliter,
								                    this.sclfile.Subnetworks[i].name,
								                    i,
								                    desc);
							}
							communication_updated = true;
						}
					}
						break;
					case 3: // IEDs
					{
						if (!ieds_updated && this.sclfile.Devices != null)
						{
							Gtk.TreeStore model = (Gtk.TreeStore) this.Model;
							for (int i = 0; i < this.sclfile.Devices.GetLength(0); i++) {
								string desc = " / Config. Version: ";
								desc += this.sclfile.Devices[i].configVersion;
								desc += "Manufacturer: ";
								desc += this.sclfile.Devices[i].manufacturer;
								desc += " / Description: ";
								desc += this.sclfile.Devices[i].desc;
								
								model.AppendValues(seliter,
								                   this.sclfile.Devices[i].name,
								                   i,
								                   desc);
							}
							ieds_updated = true;
						}
					}
						break;
					default:
					break;
					}
				}
			}
		}
		
		public SclTree (OpenSCL.Object scl)
		{
			this.Init();
			this.SclFile = scl;
		}
		
		public SclTree (string path)
		{
			this.SclFile = new OpenSCL.Object(path);
		}
		
		public OpenSCL.Object SclFile {
			get
			{
				return this.sclfile;
			}
			set
			{
				Gtk.TreeIter root;
				string desc;
				
				this.sclfile = value;
				// Free All nodes on TreeModel
				Gtk.TreeStore model = (Gtk.TreeStore) this.Model;
				while (model.GetIterFirst(out root))
					model.Remove(ref root);
				// SCL file information at root element
				if (this.sclfile.HaveRevisionInformation ())
				{
					desc = "Version: ";
					desc += this.sclfile.Version;
					desc += " Revision: ";
					desc += this.sclfile.Revision;
					desc += " Desc.: ";
					desc += this.sclfile.Description;
				}
				else
					desc = "";
				
				root = model.AppendValues(this.sclfile.id, 0, desc);
				model.AppendValues(root, 
                                    "Header",
                                    1,
                                    "Version and History Information");
				
				model.AppendValues(root, 
                                    "Substation",
                                    2,
                                    "Substation Information");
				
				model.AppendValues(root, 
	                                "Communication",
	                                3,
	                                "Communications Information");
				
				model.AppendValues(root, 
                                    "Devices (IED)",
                                    4,
                                    "IEDs configured in this file");
				
				this.ieds_updated = false;
				this.header_updated = false;
				this.substation_updated = false;
				this.communication_updated = false;
				this.ExpandAll();
			}
		}
	}
}
