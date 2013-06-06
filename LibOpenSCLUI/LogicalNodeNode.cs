//
//  LogicalNodeNode.cs
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
using System.Windows.Forms;

namespace OpenSCL.UI
{
	public class LogicalNodeNode : GenericNode
	{
		tLDevice ld;
		int index;
		public LogicalNodeNode (int index, tLDevice d)
		{
			if (d == null) return;
			ld = d;
			this.index = index;
			Tag = d.LN[index];
			update_name ();
			d.LN[index].PropertyChanged += new PropertyChangedEventHandler (on_changed);
		}

		void update_name ()
		{
			var ln = ld.LN[index];
			Name = ln.prefix + ln.lnClass + ln.inst;
		}

		private void on_changed (object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "lnClass" ||
				e.PropertyName == "prefix" ||
				e.PropertyName == "inst") {
				update_name ();
				var h = ld.find_duplicated_ln ();
				if (h.Count > 0) {
					string t = "";
					foreach (object item in h.Keys) {
						t += "  " + (string)item + "\n";
					}
					MessageBox.Show ("This Logical Nodes is Duplated\n\n" + t,
					                "Duplicated Logical Node",
				                    MessageBoxButtons.OK,
					                MessageBoxIcon.Exclamation);
				}
			}

			if (e.PropertyName == "lnType") {
				var h = ld.find_invalid_lntypes ();
				if (h.Count > 0) {
					if (MessageBox.Show ("This Logical Node Type: " 
					                 + ld.LN[index].lnType
					                 + " is invalid.\n\n"
					                 + "Do you want to create a new Template LN?",
					                "Invalid Logical Node Type",
				                    MessageBoxButtons.YesNo,
					                MessageBoxIcon.Exclamation) == DialogResult.Yes)
					{
						int i = ld.templates.AddLNodeType (null);
						if (i != -1) {
							ld.templates.LNodeType[i].id = ld.LN[index].lnType;
						}
						OnUpdated (SclViewerTree.WhatUpdated.LogicalNodeTypeAdded);
					}
				}
			}
		}
	}
}

