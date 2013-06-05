//
//  DataObjectNode.cs
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

namespace OpenSCL.UI
{
	public class DataObjectTypeNode : GenericNode
	{
		public DataObjectTypeNode (tDOType dot)
		{
			if (dot == null) return;
			string s = "";
			if (dot.iedType != null || dot.iedType != "")
				s += dot.iedType + " / ";
			Name = s + dot.id + " [" + dot.cdc + "]";
			Tag = dot;
			var cxm = new System.Windows.Forms.ContextMenuStrip ();
			var add_da = new System.Windows.Forms.ToolStripMenuItem ("Add Attribute", null, 
			                                                        on_add_da);
			cxm.Items.Add (add_da);
			base.ContextMenuStrip = cxm;
			update_nodes ();
		}

		private void on_add_da (object sender, EventArgs args)
		{
			var dot = ((tDOType) Tag);
			dot.AddDA (null);
			update_nodes ();
		}

		private void update_nodes ()
		{
			var dot = ((tDOType) Tag);
			Nodes.Clear ();
			if (dot.DA != null) {
				for (int i = 0; i < dot.DA.Length; i++) {
					var n = new DataAttributeNode (dot.DA [i]);
					Nodes.Add (n);
				}
			}
			if (dot.SDO != null) {
				for (int i = 0; i < dot.SDO.Length; i++) {
					var n = new SourceDataObjectNode (dot.SDO [i]);
					Nodes.Add (n);
				}
			}
		}
	}
}

