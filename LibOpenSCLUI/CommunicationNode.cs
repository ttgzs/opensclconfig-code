//
//  CommunicationNode.cs
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
using System.Windows.Forms;
using IEC61850.SCL;

namespace OpenSCL.UI
{
	public class CommunicationNode : GenericNode
	{
		public CommunicationNode (tCommunication c)
		{
			Name = "Substation Networks";
			Tag = c;
			if (c.SubNetwork != null) {
				for (int i = 0; i < c.SubNetwork.Length; i++) {
					var sn = new SubnetworkNode (c.SubNetwork [i]);
					this.Nodes.Add (sn);
				}
				this.Expand ();
			}
		}

		public void AddSubnetwork (tSubNetwork sn)
		{
			var comm = (tCommunication) Tag;
			int i = comm.AddSubNetwork (sn);
			var n = new TreeNode ();
			n.Tag = comm.SubNetwork[i];
			n.Text = comm.SubNetwork[i].name;
			n.Name = comm.SubNetwork[i].name;
			this.Nodes.Add (n);
		}
	}
}