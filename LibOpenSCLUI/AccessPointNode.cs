//
//  AccessPointNode.cs
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
	public class AccessPointNode : GenericNode
	{
		tIED ied;
		int iap;
		tDataTypeTemplates templates;

		public AccessPointNode (int iap, tIED ied, tDataTypeTemplates dt)
		{
			if (ied == null || dt == null || ied == null) return;

			Tag = ied.AccessPoint[iap];
			this.ied = ied;
			this.iap = iap;
			this.templates = dt;

			ied.AccessPoint[iap].PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler (on_changed);
			update_name ();
			update_nodes ();
			var cxm = new System.Windows.Forms.ContextMenuStrip ();
			var addld = new System.Windows.Forms.ToolStripMenuItem ("Add Logical Device", null, on_add_ld);
			cxm.Items.Add (addld);
			base.ContextMenuStrip = cxm;
		}

		public void update_name ()
		{
			Name = "AccessPoint: " + ied.AccessPoint[iap].name;
		}

		public void on_add_ld (object sender, EventArgs args)
		{
			int i = ied.AddLDevice (null, ied.AccessPoint[iap].name, templates);
			var n = new LogicalDeviceNode (ied.AccessPoint[iap].Server.LDevice[i]);
			Nodes.Add (n);
			update_nodes ();
		}

		private void update_nodes ()
		{
			var ap = ((tAccessPoint) Tag);
			Nodes.Clear ();
			if (ap.Server != null) {
				if (ap.Server.LDevice != null) {
					for (int i = 0; i < ap.Server.LDevice.Length; i++) {
						if (ap.Server.LDevice[i].templates == null)
							ap.Server.LDevice[i].templates = templates;
						var n = new LogicalDeviceNode (ap.Server.LDevice [i]);
						n.Updated += (sender, what) => { OnUpdated (what); };
						Nodes.Add (n);
					}
					Expand ();
				}
			}
		}

		private void on_changed (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			update_name ();
		}
	}
}

