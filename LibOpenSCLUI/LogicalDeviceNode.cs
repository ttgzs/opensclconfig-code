//
//  LdNode.cs
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
	public class LogicalDeviceNode : GenericNode
	{
		public LogicalDeviceNode (tLDevice ld)
		{
			if (ld == null) return;

			Tag = ld;
			update_name ();
			update_nodes ();
			ld.PropertyChanged  += new PropertyChangedEventHandler (on_changed);

		}

		void update_name ()
		{
			var ld = ((tLDevice) Tag);
			Name = ld.inst;
		}

		void update_nodes ()
		{
			var ld = ((tLDevice) Tag);
			if (ld.LN0 != null) {
				var n = new Ln0Node (ld.LN0);
				Nodes.Add (n);
			}
			if (ld.LN != null) {
				var n = new TopLogicalNodeNode (ld);
				n.Updated += (sender, what) => { OnUpdated (what); };
				Nodes.Add (n);
			}
		}

		private void on_ln_changed (object sender, PropertyChangedEventArgs e)
		{
		}

		private void on_changed (object sender, PropertyChangedEventArgs e)
		{
			update_name ();
		}
	}
}

