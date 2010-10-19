// 
//  SclEditor.cs
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
				
				if (path.Indices.GetLength(0) > 1) {
					if (path.Indices[1] == 0) {
						this.notebook2.Page = 3;
						this.historyeditor.SclFile = this.SclFile;
					}
				}
				
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
