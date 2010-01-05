// 
//  SclEditor.cs
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

namespace LibOpenSCLUIGtk
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class SclEditor : Gtk.Bin
	{

		private void Init()
		{
			this.Build ();
			this.scltree.Selection.Changed += HandleScltreeSelectionhandleChanged;
		}

		void HandleScltreeSelectionhandleChanged (object sender, EventArgs e)
		{
			Gtk.TreeIter seliter;
			Gtk.TreeSelection sel = (Gtk.TreeSelection) sender;
			sel.GetSelected(out seliter);
			
			Gtk.TreePath path = this.scltree.Model.GetPath(seliter);
			
			// Edit/Show Current Selected IED 
			if (path.Indices.GetLength(0) > 2)
			{
				if (path.Indices[1] == 3)
				{
					int iednum = (int) this.scltree.Model.GetValue(seliter, 1);
					this.notebook.Page = 1;
					this.deviceeditor.SetIED(this.scltree.SclFile, iednum);
				}
			}
			//this.notebook.Page = 0;
		}
		
		public SclEditor ()
		{
			this.Init();
		}
		
		public SclEditor (OpenSCL.Object sclfile)
		{
			this.Init();
			this.scltree.SclFile = sclfile;
		}
		
		public OpenSCL.Object SclFile
		{
			get {
				return this.scltree.SclFile;
			}
			set {
				this.scltree.SclFile = value;
				this.notebook.Page = 0;
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
	}
}
