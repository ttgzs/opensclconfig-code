//
//  SclViewerTree.cs
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
	/// <summary>
	/// Scl viewer tree.
	/// Since: 0.4.0
	/// </summary>
	public class SclViewerTree : TreeView
	{
		private SCL _scl;
		private TreeNode root;
		private GenericNode commNode;
		private GenericNode dttemplNode;
		private GenericNode iedNode;
		private GenericNode subNode;

		public enum WhatUpdated {
			LogicalNodeAdded,
			LogicalNodeTypeAdded
		}

		public SclViewerTree ()
		{
		}

		public SCL scl {
			get { return _scl; }
			set {
				_scl = value;
				this.Nodes.Clear ();
				add_nodes ();
			}
		}

		public string title {
			get { return root.Text; }
			set { root.Text = value; }
		}

		void add_nodes ()
		{
			root = new TreeNode ();
			root.Name = "SCL";
			root.Expand ();
			this.Nodes.Add (root);
			AddSubstationNode ();
			AddCommunicationNode ();
			AddIEDNode ();
			AddDataTypeTemplatesNode ();
			iedNode.Updated += new GenericNode.UpdatedHander (on_iednode_update);
		}

		void AddCommunicationNode ()
		{
			if (this.scl.Communication != null) {
				commNode = new CommunicationNode (this.scl.Communication);
				root.Nodes.Add (commNode);
			}
		}

		void AddIEDNode ()
		{
			if (this.scl.IED != null) {
				iedNode = new TopIedNode (this.scl);
				root.Nodes.Add (iedNode);
			}
		}

		void AddDataTypeTemplatesNode ()
		{
			if (this.scl.DataTypeTemplates != null) {
				dttemplNode = new DataTypeTemplateNode (this.scl.DataTypeTemplates);
				root.Nodes.Add (dttemplNode);
			}
		}

		void on_iednode_update (object sender, WhatUpdated what)
		{
			if (what == WhatUpdated.LogicalNodeAdded)
				((DataTypeTemplateNode)dttemplNode).update_nodes (DataTypeTemplateNode.UpdateContext.All);
			if (what == WhatUpdated.LogicalNodeTypeAdded)
				((DataTypeTemplateNode)dttemplNode).update_nodes (DataTypeTemplateNode.UpdateContext.LogicalNodes);
		}

		void AddSubstationNode ()
		{
			if (this.scl.Substation != null) {
				subNode = new TopSubstationNode (this.scl.Substation);
				root.Nodes.Add (subNode);
			}
		}
	}
}

