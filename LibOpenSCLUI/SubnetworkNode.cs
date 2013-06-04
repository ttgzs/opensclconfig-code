//
//  SubnetworkNode.cs
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
	public class SubnetworkNode : GenericNode
	{
		public SubnetworkNode (tSubNetwork sn)
		{
			if (sn == null) return;

			Name = sn.name;
			Tag = sn;

			if (sn.ConnectedAP != null) {
				for (int i = 0; i < sn.ConnectedAP.Length; i++) {
					var n = new ConnectedApNode (sn.ConnectedAP [i]);
					this.Nodes.Add (n);
				}
			}
		}
	}
}

