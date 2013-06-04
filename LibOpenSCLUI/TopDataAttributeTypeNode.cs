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

namespace OpenSCL.UI
{
	public class TopDataAttributeTypeNode : GenericNode
	{
		tDataTypeTemplates templates;

		public TopDataAttributeTypeNode (tDAType[] dat, tDataTypeTemplates dt)
		{
			if (dat == null) return;

			Name = "Data Attributes Type";
			Tag = dat;
			templates = dt;
			update_nodes ();
			var cxm = new System.Windows.Forms.ContextMenuStrip ();
			var add_dta = new System.Windows.Forms.ToolStripMenuItem ("Add Data Type Attribute", 
			                                                        null, on_add_dta);
			cxm.Items.Add (add_dta);
			base.ContextMenuStrip = cxm;
		}
		private void on_add_dta (object sender, EventArgs args)
		{
			templates.AddDAType (null);
			update_nodes ();
		}
		private void update_nodes ()
		{
			Nodes.Clear ();
			var dat = ((tDAType[]) Tag);
			for (int i = 0; i < dat.Length; i++) {
				var n = new DataAttributeTypeNode (dat[i]);
				Nodes.Add (n);
			}
		}
	}
}

