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
	public class TopDataObjectTypeNode : GenericNode
	{
		private tDataTypeTemplates templates;

		public TopDataObjectTypeNode (tDataTypeTemplates dt)
		{
			if (dt == null) return;

			Name = "Data Objects Types";
			Tag = dt.DOType;
			templates = dt;
			var cxm = new System.Windows.Forms.ContextMenuStrip ();
			var add_dot = new System.Windows.Forms.ToolStripMenuItem ("Add Data Object Type", null, 
			                                                        on_add_dot);
			cxm.Items.Add (add_dot);
			base.ContextMenuStrip = cxm;
			update_nodes ();
		}

		void update_nodes ()
		{
			var dot = templates.DOType;
			System.Console.WriteLine ("Number elements to add: "+dot.Length);
			Nodes.Clear ();
			for (int i = 0; i < dot.Length; i++) {
				var n = new DataObjectTypeNode (dot[i]);
				Nodes.Add (n);
			}
		}

		private void on_add_dot (object sender, EventArgs args)
		{
			templates.AddDOType (null);
			update_nodes ();
		}
	}
}

