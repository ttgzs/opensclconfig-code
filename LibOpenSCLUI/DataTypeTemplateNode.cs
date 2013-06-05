//
//  DataTypeTemplateNode.cs
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
	public class DataTypeTemplateNode : GenericNode
	{
		System.Windows.Forms.ToolStripMenuItem add_lnt;
		System.Windows.Forms.ToolStripMenuItem add_dot;
		System.Windows.Forms.ToolStripMenuItem add_dta;

		public DataTypeTemplateNode (tDataTypeTemplates dt)
		{
			if (dt == null) return;

			Name = "Data Type Templates";
			Tag = dt;

			var cxm = new System.Windows.Forms.ContextMenuStrip ();
			add_lnt = new System.Windows.Forms.ToolStripMenuItem ("Add Logical Node Type Container", null, 
			                                                        on_add_lnt);
			add_dot = new System.Windows.Forms.ToolStripMenuItem ("Add Data Object Type Container", null, 
			                                                        on_add_dot);
			add_dta = new System.Windows.Forms.ToolStripMenuItem ("Add Data Type Attribute Container", 
			                                                        null, on_add_dta);
			cxm.Items.Add (add_lnt);
			cxm.Items.Add (add_dot);
			cxm.Items.Add (add_dta);
			base.ContextMenuStrip = cxm;

			update_nodes ();
		}

		private void on_add_dta (object sender, EventArgs args)
		{
			var dt = ((tDataTypeTemplates)Tag);
			if (dt.DAType == null) {
				dt.AddDAType (null);
				add_dta.Enabled = false;
				update_nodes ();
			}
		}

		private void on_add_dot (object sender, EventArgs args)
		{
			var dt = ((tDataTypeTemplates)Tag);
			if (dt.DOType == null) {
				dt.AddDOType (null);
				update_nodes ();
			}
		}

		private void on_add_lnt (object sender, EventArgs args)
		{
			var dt = ((tDataTypeTemplates)Tag);
			if (dt.LNodeType == null) {
				dt.AddLNodeType (null);
				update_nodes ();
			}
		}

		private void update_nodes ()
		{
			var dt = ((tDataTypeTemplates) Tag);
			Nodes.Clear ();
			if (dt.DOType != null) {
				var n = new TopDataObjectTypeNode (dt);
				Nodes.Add (n);
				add_dot.Enabled = false;
			}
			if (dt.DAType != null) {
				var n = new TopDataAttributeTypeNode (dt);
				Nodes.Add (n);
				add_dta.Enabled = false;
			}
			if (dt.LNodeType != null) {
				var n = new TopLogicalNodeTypeNode (dt);
				Nodes.Add (n);
				add_lnt.Enabled = false;
			}
		}
	}
}

