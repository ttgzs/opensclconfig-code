//
//  TopIedNode.cs
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
	public class TopIedNode : GenericNode
	{
		private SCL scl;
		public TopIedNode (SCL s)
		{
			if (s == null) return;

			Name = "Configured IEDs";
			Tag = s.IED;
			scl = s;
			var cxm = new System.Windows.Forms.ContextMenuStrip ();
			var add_dta = new System.Windows.Forms.ToolStripMenuItem ("Add IED", 
			                                                        null, on_add_ied);
			cxm.Items.Add (add_dta);
			base.ContextMenuStrip = cxm;

			update_nodes ();
			this.Expand ();
		}

		private void on_add_ied (object sender, EventArgs args)
		{
			scl.AddIED (null);
			update_nodes ();
		}

		void update_nodes ()
		{
			var ieds = scl.IED;
			Nodes.Clear ();
			for (int i = 0; i < ieds.Length; i++) {
				var n = new IedNode (ieds[i], scl.DataTypeTemplates);
				n.Updated += (sender, what) => { OnUpdated (what); };
				Nodes.Add (n);
			}
		}
	}
}

