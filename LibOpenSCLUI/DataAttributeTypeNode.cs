//
//  DataAttributeTypeNode.cs
//
//  Author:
//       Daniel Espinosa <esodan@gmail.com>
//
//  Copyright (c) 2013 Daniel Espinosa
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
using System.ComponentModel;

namespace OpenSCL.UI
{
	public class DataAttributeTypeNode : GenericNode
	{
		private tDAType dat;
		public DataAttributeTypeNode (tDAType dat)
		{
			if (dat == null)
				return;

			Tag = dat;
			this.dat = dat;
			dat.PropertyChanged += (sender, e) => {
				update_name (); };
			var cxm = new System.Windows.Forms.ContextMenuStrip ();
			var add_dta = new System.Windows.Forms.ToolStripMenuItem ("Add Attribute", 
			                                                        null, on_add_attr);
			add_dta.ToolTipText = "Sets this attribute to be a Struct type\n" +
				"Update 'id' if an Enum Type is required";
			cxm.Items.Add (add_dta);
			base.ContextMenuStrip = cxm;

			update_name ();
			update_nodes ();
			Expand ();
		}

		public void update_nodes ()
		{
			Nodes.Clear ();
			if (dat.BDA != null) {
				for (int i = 0; i < dat.BDA.Length; i++) {
					var n = new BasicAttributeNode (dat.BDA[i]);
					Nodes.Add (n);
				}
			}
		}

		private void update_name ()
		{
			string s = "";
			if (dat.iedType != null || dat.iedType != "")
				s += dat.iedType + " / ";
			Name = s + dat.id;
		}

		private void on_add_attr (object sender, EventArgs args)
		{
			dat.AddBasicAttribute (null);
			update_nodes ();
		}
	}
}

