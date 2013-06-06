//
//  IedNode.cs
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
	public class IedNode : GenericNode
	{
		tDataTypeTemplates templates;
		tIED ied;
		public IedNode (tIED ied, tDataTypeTemplates dt)
		{
			if (ied == null) return;

			Name = ied.name;
			templates = dt;
			this.ied = ied;
			Tag = ied;
			ied.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler (on_changed);

			var cxm = new System.Windows.Forms.ContextMenuStrip ();
			var addld = new System.Windows.Forms.ToolStripMenuItem ("Add Access Point", null, on_add_ap);
			cxm.Items.Add (addld);
			base.ContextMenuStrip = cxm;

			update_nodes ();
		}

		public void update_nodes ()
		{
			Nodes.Clear ();
			if (ied.AccessPoint != null) {
				for (int i = 0; i < ied.AccessPoint.Length; i++) {
					var n = new AccessPointNode (i, ied, templates);
					n.Updated += (sender, what) => { OnUpdated (what); };
					Nodes.Add (n);
				}
			}
		}

		public void on_add_ap (object sender, EventArgs args)
		{
			int i = ied.AddAP (null);
			var n = new AccessPointNode (i, ied, templates);
			Nodes.Add (n);
		}

		private void on_changed (object sender,
		                         System.ComponentModel.PropertyChangedEventArgs e)
		{
			Name = ((tIED) Tag).name;
		}
	}
}

