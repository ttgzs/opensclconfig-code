
using System;

namespace OpenSASUI
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class SclEditor : Gtk.Bin, IContainer
	{
		private void Init()
		{
			this.Build ();
			this.scltreeview.Selection.Changed += HandleScltreeviewSelectionhandleChanged;
		}

		void HandleScltreeviewSelectionhandleChanged (object sender, EventArgs e)
		{
			Gtk.TreeIter seliter;
			Gtk.TreeSelection sel = (Gtk.TreeSelection) sender;
			
			if(sel.GetSelected(out seliter)) {
			
				Gtk.TreePath path = this.scltreeview.Model.GetPath(seliter);
				
				if (path.Indices.GetLength(0) > 2)
				{
					// Edit/Show Current Selected IED 
					if (path.Indices[1] == 3)
					{
						int iednum = (int) this.scltreeview.Model.GetValue(seliter, 1);
						this.iededitor.SetIED(this.scltreeview.SclFile, iednum, this);
						this.notebook2.Page = 1;
					}
					// Show Communications Subnetwork
					if (path.Indices[1] == 2) {
						int subnet = (int) this.scltreeview.Model.GetValue(seliter, 1);
						this.sclcommmanager.SetSubnetwork (this.scltreeview.SclFile, subnet);
						this.notebook2.Page = 2;
					}
						
				}
				//this.notebook.Page = 0;
			}
		}

		
		public SclEditor ()
		{
			this.Init();
		}
		
		public SclEditor (OpenSCL.Object sclfile)
		{
			this.Init();
			this.SclFile = sclfile;
		}
		
		public OpenSCL.Object SclFile
		{
			get {
				return this.scltreeview.SclFile;
			}
			set {
				this.Clear();
				if (value != null) {
					this.scltreeview.SclFile = value;
					this.notebook2.Page = 0;
				}
			}
		}
		
		/// <summary>
		/// This container can be used to set a custom widget, when no edition anything
		/// on SCL files.
		/// </summary>
		public Gtk.Container Container
		{
			get {
				return (Gtk.Container) this.NothingContainer;
			}
		}
		
		public void Clear () 
		{
			this.sclcommmanager.Clear();
			this.scltreeview.Clear();
			this.iededitor.Clear();
		}
		
		// Interface OpenSASUI.IContainer
		public void Reset ()
		{
			this.SclFile = this.scltreeview.SclFile;
		}
	}
}
