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

namespace OpenSCL.UI
{
	public class LogicalDeviceNode : GenericNode
	{
		public LogicalDeviceNode (tLDevice ld)
		{
			if (ld == null) return;

			Name = ld.inst;
			Tag = ld;
			if (ld.LN0 != null) {
				var n = new Ln0Node (ld.LN0);
				Nodes.Add (n);
			}
			if (ld.LN != null) {
				var n = new TopLogicalNodeNode (ld.LN);
				Nodes.Add (n);
			}
		}
	}
}

