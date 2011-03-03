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

namespace OpenSASUI
{
	[System.ComponentModel.ToolboxItem(true)]
	public class SclTreeView : Gtk.TreeView
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
			                Mono.Unix.Catalog.GetString("No File Loaded"),
			                0,
			                Mono.Unix.Catalog.GetString("Open or create a new SCL file"));
			this.Model = model;
			
			this.AppendColumn (Mono.Unix.Catalog.GetString("Element"), 
			                   new Gtk.CellRendererText (), "text", 0);
			this.AppendColumn (Mono.Unix.Catalog.GetString("Description"), 
			                   new Gtk.CellRendererText (), "text", 2);
			this.GetColumn(0).Sizing = TreeViewColumnSizing.Autosize;
			this.GetColumn(0).Resizable = true;
			this.GetColumn(1).Sizing = TreeViewColumnSizing.Autosize;
			this.GetColumn(1).Resizable = true;
			
			this.Selection.Changed += HandleSelectionhandleChanged;
			
			header_updated = false;
			substation_updated = false;
			ieds_updated = false;
			communication_updated = false;
		}
		public SclTreeView ()
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
							this.ExpandRow(path, false);
							this.substation_updated = true;
						}
					}
						break;
					case 2: // Communication
					{
						if (!communication_updated && this.sclfile.Configuration.Communication != null)
						{
							if (this.sclfile.Subnetworks != null) {
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
								this.ExpandRow(path, false);
								communication_updated = true;
							}
						}
					}
						break;
					case 3: // IEDs
					{
						if (!ieds_updated && this.sclfile.Devices != null)
						{
							
							Gtk.TreeStore model = (Gtk.TreeStore) this.Model;
							// add number of configured IEDs
							string ieddes = (string) model.GetValue(seliter, 2);
							ieddes += " (";
							ieddes += this.sclfile.Devices.GetLength(0);
							ieddes += ")";
							model.SetValue(seliter, 2, ieddes);
							// Add IEDs
							for (int i = 0; i < this.sclfile.Devices.GetLength(0); i++) {
								string desc = Mono.Unix.Catalog.GetString("Config. Version: ");
								desc += this.sclfile.Devices[i].configVersion;
								desc += Mono.Unix.Catalog.GetString(" / Manufacturer: ");
								desc += this.sclfile.Devices[i].manufacturer;
								desc += Mono.Unix.Catalog.GetString(" / Description: ");
								desc += this.sclfile.Devices[i].desc;
								
								model.AppendValues(seliter,
								                   this.sclfile.Devices[i].name,
								                   i,
								                   desc);
							}
							this.ExpandRow(path, false);
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
		
		public SclTreeView (OpenSCL.Object scl)
		{
			this.Init();
			this.SclFile = scl;
		}
		
		public SclTreeView (string path)
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
				
				
				this.sclfile = value;
				this.Clear();
				if (sclfile != null) {
					Gtk.TreeIter root;
					string desc;
					// SCL file information at root element
					if (this.sclfile.HaveRevisionInformation ())
					{
						desc = Mono.Unix.Catalog.GetString("Version: ");
						desc += this.sclfile.Version;
						desc += Mono.Unix.Catalog.GetString(" Revision: ");
						desc += this.sclfile.Revision;
						desc += Mono.Unix.Catalog.GetString(" Desc.: ");
						desc += this.sclfile.Description;
					}
					else
						desc = "";
					Gtk.TreeStore model = (Gtk.TreeStore) this.Model;
					root = model.AppendValues(this.sclfile.id, 0, desc);
					model.AppendValues(root, 
	                                    Mono.Unix.Catalog.GetString("History"),
	                                    1,
	                                    Mono.Unix.Catalog.GetString("Version and History Information"));
					
					model.AppendValues(root, 
	                                    Mono.Unix.Catalog.GetString("Substation"),
	                                    2,
	                                    Mono.Unix.Catalog.GetString("Substation Information"));
					
					model.AppendValues(root, 
		                                Mono.Unix.Catalog.GetString("Communication"),
		                                3,
		                                Mono.Unix.Catalog.GetString("Communications Information"));
					
					model.AppendValues(root, 
	                                    Mono.Unix.Catalog.GetString("Devices (IED)"),
	                                    4,
	                                    Mono.Unix.Catalog.GetString("IEDs configured in this file"));
					
					this.ieds_updated = false;
					this.header_updated = false;
					this.substation_updated = false;
					this.communication_updated = false;
					this.ExpandAll();
					this.Sensitive = true;
				}
			}
		}
		
		public void Clear()
		{
			// Free All nodes on TreeModel
			Gtk.TreeIter iter;
			Gtk.TreeStore model = (Gtk.TreeStore) this.Model;
			while (model.GetIterFirst(out iter))
				model.Remove(ref iter);
			this.Sensitive = false;
		}
	}
}
