//
//  LogicalNodeTypeNode.cs
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
	public class LogicalNodeTypeNode : GenericNode
	{
		public LogicalNodeTypeNode (tLNodeType lnt)
		{
			if (lnt == null) return;
			Tag = lnt;
			update_name ();
			lnt.PropertyChanged += new PropertyChangedEventHandler (on_changed);
		}

		private void update_name ()
		{
			var lnt = ((tLNodeType) Tag);
			string s = "";
			if (lnt.iedType != null || lnt.iedType != "")
				s += lnt.iedType + " / ";
			Name = s + lnt.id + " [" + lnt.lnClass + "]";
		}

		private void on_changed (object sender, PropertyChangedEventArgs e)
		{
			update_name ();
		}
	}
}

