//
//  TopLogicalNodeTypeNode.cs
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
	public class TopLogicalNodeTypeNode : GenericNode
	{
		tDataTypeTemplates templates;
		public TopLogicalNodeTypeNode (tDataTypeTemplates dt)
		{
			if (dt==null) return;
			Name = "Logical Nodes Types";
			Tag = dt.LNodeType;
			templates = dt;

			var cxm = new System.Windows.Forms.ContextMenuStrip ();
			var add_lnt = new System.Windows.Forms.ToolStripMenuItem ("Add Logical Node Type", null, 
			                                                        on_add_lnt);
			cxm.Items.Add (add_lnt);
			base.ContextMenuStrip = cxm;

			update_nodes ();

		}
		private void on_add_lnt (object sender, EventArgs args)
		{
			templates.AddLNodeType (null);
			update_nodes ();
		}

		private void update_nodes ()
		{
			Nodes.Clear ();
			var lnt = templates.LNodeType;
			for (int i = 0; i < lnt.Length; i++) {
				var n = new LogicalNodeTypeNode (lnt [i]);
				Nodes.Add (n);
			}
		}
	}
}

