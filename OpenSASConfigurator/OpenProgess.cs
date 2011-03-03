// 
//  OpenProgess.cs
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

namespace OpenSASConfigurator
{


	public partial class OpenProgess : Gtk.Window
	{

		public OpenProgess (Gtk.Window parent, string filename) : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.progressbar.Fraction = 0.01;
			this.progressbar.PulseStep = 0.003;
			this.progressbar.Text = "Loading file...";
			this.label.Text = "Opening SCL File: ";
			this.label.Text += filename;
			this.Modal = true;
			this.TransientFor = parent;
			this.SetPosition(Gtk.WindowPosition.CenterOnParent);
			this.Decorated = false;
		}
		
		public void Pulse()
		{
			this.progressbar.Pulse();
		}
		
		public string TextBar {
			get { return this.progressbar.Text; }
			set { this.progressbar.Text = value; }
		}
		
		public string Label {
			get { return this.label.Text; }
			set { this.label.Text = value; }
		}
	}
}
