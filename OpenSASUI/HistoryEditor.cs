
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
