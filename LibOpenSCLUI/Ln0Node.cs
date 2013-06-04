//
//  Ln0Node.cs
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
	public class Ln0Node : GenericNode
	{
		public Ln0Node (tLN0 ln)
		{
			if (ln == null) return;

			Name = "LN0";
			Tag = ln;
			if (ln.DataSet != null) {
				var n = new TopDataSetNode (ln.DataSet);
				Nodes.Add (n);
			}
			if (ln.GSEControl != null) {
				var n = new TopGseControlNode (ln.GSEControl);
				Nodes.Add (n);
			}
			if (ln.LogControl != null) {
				var n = new TopLogControlNode (ln.LogControl);
				Nodes.Add (n);
			}
			if (ln.ReportControl != null) {
				var n = new TopReportControlNode (ln.ReportControl);
				Nodes.Add (n);
			}
			if (ln.SampledValueControl != null) {
				var n = new TopSampleValuesNode (ln.SampledValueControl);
				Nodes.Add (n);
			}
		}
	}
}

