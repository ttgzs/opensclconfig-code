// 
//  HistoryEditor.cs
//  
//  Author:
//       Daniel Espinosa <esodan@gmail.com>
//  
//  Copyright (c) 2010 Daniel Espinosa
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

namespace OpenSASUI
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class HistoryEditor : Gtk.Bin
	{

		private OpenSCL.Object sclfile;
		
		public HistoryEditor ()
		{
			this.Init();
		}
		
		public HistoryEditor (OpenSCL.Object sclfile)
		{
			this.Init();
			
		}
		
		private void Init()
		{
			this.Build ();
			
			Gtk.ListStore model = new Gtk.ListStore (GLib.GType.Int, // Item index
			                                         GLib.GType.String, //version,
			                                         GLib.GType.String, //revision,
			                                         GLib.GType.String, //what,
			                                         GLib.GType.String, //when,
			                                         GLib.GType.String, //who,
			                                         GLib.GType.String); //why
			                                         
			this.history.Model = model;
			this.history.AppendColumn (Mono.Unix.Catalog.GetString("Version"), 
			                   new Gtk.CellRendererText (), "text", 1);
			this.history.AppendColumn (Mono.Unix.Catalog.GetString("Revision"), 
			                   new Gtk.CellRendererText (), "text", 2);
			this.history.AppendColumn (Mono.Unix.Catalog.GetString("What"), 
			                   new Gtk.CellRendererText (), "text", 3);
			this.history.AppendColumn (Mono.Unix.Catalog.GetString("When"), 
			                   new Gtk.CellRendererText (), "text", 4);
			this.history.AppendColumn (Mono.Unix.Catalog.GetString("Who"), 
			                   new Gtk.CellRendererText (), "text", 5);
			this.history.AppendColumn (Mono.Unix.Catalog.GetString("Why"), 
			                   new Gtk.CellRendererText (), "text", 6);
			this.history.GetColumn(0).Resizable = true;
			this.history.GetColumn(1).Resizable = true;
			this.history.GetColumn(2).Resizable = true;
			this.history.GetColumn(3).Resizable = true;
			this.history.GetColumn(4).Resizable = true;
			this.history.GetColumn(5).Resizable = true;
			
			this.Sensitive = false;
		}
		
		private bool FillHistory (OpenSCL.Object sclfile)
		{
			if (sclfile != null) {
				if (sclfile.RevisionHistory != null)
				{
					Gtk.ListStore model = (Gtk.ListStore) this.history.Model;
					for (int i = 0; i < sclfile.RevisionHistory.GetLength(0); i++) {
						model.AppendValues(i,
						                   sclfile.RevisionHistory[i].version,
						                   sclfile.RevisionHistory[i].revision,
						                   sclfile.RevisionHistory[i].what,
						                   sclfile.RevisionHistory[i].when,
						                   sclfile.RevisionHistory[i].who,
						                   sclfile.RevisionHistory[i].why);
					}
						
				}
				return true;
			}
			else
				return false;
		}
		
		public void Clear ()
		{
			Gtk.TreeIter iter;
			Gtk.ListStore model = (Gtk.ListStore) this.history.Model;
			while (model.GetIterFirst(out iter))
				model.Remove(ref iter);
			this.Sensitive = false;
		}
		
		public	OpenSCL.Object SclFile
		{
			get {
				return this.sclfile;
			}
			set {
				if (value != null) {
					this.Clear();
					if (this.FillHistory (value)) {
						this.sclfile = value;
						this.Sensitive = true;
					}
				}
			}
		}
	}
}
