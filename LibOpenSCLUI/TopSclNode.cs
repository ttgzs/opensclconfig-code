//
//  TopSclNode.cs
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
using System.Windows.Forms;

namespace OpenSCL.UI
{
	public class TopSclNode : GenericNode
	{
		SCL _scl;
		CommunicationNode commNode;
		TopIedNode iedNode;
		DataTypeTemplateNode templatesNode;
		TopSubstationNode substationNode;
		ToolStripMenuItem add_comm;
		ToolStripMenuItem add_ied;
		ToolStripMenuItem add_tml;
		ToolStripMenuItem add_sb;

		public enum UpdateContext {
			All,
			Substation,
			Communication,
			Ied,
			Templates
		}

		public enum WhatUpdated {
			LogicalNodeAdded,
			LogicalNodeTypeAdded
		}

		public TopSclNode ()
		{
			var cxm = new System.Windows.Forms.ContextMenuStrip ();
			add_comm = new System.Windows.Forms.ToolStripMenuItem ("Add Subnetwork", null, 
			                                                        on_add_comm);
			add_ied = new System.Windows.Forms.ToolStripMenuItem ("Add IED", null, 
			                                                        on_add_ied);
			add_tml = new System.Windows.Forms.ToolStripMenuItem ("Add Templates", null, 
			                                                        on_add_templates);
			add_sb = new System.Windows.Forms.ToolStripMenuItem ("Add Substation Description", null, 
			                                                        on_add_substation);
			cxm.Items.Add (add_comm);
			cxm.Items.Add (add_ied);
			cxm.Items.Add (add_tml);
			cxm.Items.Add (add_sb);
			base.ContextMenuStrip = cxm;
		}

		public SCL scl { 
			get {
				return _scl;
			} 
			set {
				_scl = value;
				Tag = scl;
				update_nodes (UpdateContext.All);
			}
		}

		public void update_nodes (UpdateContext ctx)
		{
			if (ctx == UpdateContext.Communication || ctx == UpdateContext.All) {
				if (this.scl.Communication != null) {
					commNode = new CommunicationNode (this.scl.Communication);
					add_comm.Enabled = false;
					Nodes.Add (commNode);
				}
			}

			if (ctx == UpdateContext.Ied || ctx == UpdateContext.All) {
				if (this.scl.IED != null) {
					iedNode = new TopIedNode (this.scl);
					iedNode.Updated += new GenericNode.UpdatedHander (on_iednode_update);
					add_ied.Enabled = false;
					Nodes.Add (iedNode);
				}
			}

			if (ctx == UpdateContext.Substation || ctx == UpdateContext.All) {
				if (this.scl.Substation != null) {
					substationNode = new TopSubstationNode (this.scl.Substation);
					add_sb.Enabled = false;
					Nodes.Add (substationNode);
				}
			}

			if (ctx == UpdateContext.Templates || ctx == UpdateContext.All) {
				if (this.scl.DataTypeTemplates != null) {
				templatesNode = new DataTypeTemplateNode (this.scl.DataTypeTemplates);
				add_tml.Enabled = false;
				Nodes.Add (templatesNode);
			}
			}

		}

		void on_iednode_update (object sender, WhatUpdated what)
		{
			if (what == WhatUpdated.LogicalNodeAdded)
				((DataTypeTemplateNode)templatesNode).update_nodes (DataTypeTemplateNode.UpdateContext.All);
			if (what == WhatUpdated.LogicalNodeTypeAdded)
				((DataTypeTemplateNode)templatesNode).update_nodes (DataTypeTemplateNode.UpdateContext.LogicalNodes);
		}

		private void on_add_comm (object sender, EventArgs args)
		{
			if (scl.Communication == null) {
				scl.Communication = new tCommunication ();
				scl.Communication.AddSubNetwork (null);
			}
			update_nodes (UpdateContext.Communication);
		}

		private void on_add_ied (object sender, EventArgs args)
		{
			if (scl.IED == null) {
				scl.AddIED (null);
			}
			update_nodes (UpdateContext.Ied);
		}

		private void on_add_templates (object sender, EventArgs args)
		{
			if (scl.DataTypeTemplates == null) {
				scl.DataTypeTemplates = new tDataTypeTemplates ();
				scl.DataTypeTemplates.AddLNodeType (null);
			}
			update_nodes (UpdateContext.Templates);
		}

		private void on_add_substation (object sender, EventArgs args)
		{
			if (scl.Substation == null) {

			}
			update_nodes (UpdateContext.Substation);
		}
	}
}

