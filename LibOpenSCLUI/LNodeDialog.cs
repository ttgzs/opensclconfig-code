// LibOpenSCLUI
//
// Copyright (C) 2009 Comisión Federal de Electricidad
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 3 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

using System;
using System.Windows.Forms;
using IEC61850.SCL;

namespace OpenSCL.UI
{
	/// <summary>
	/// Description of tSubstation.
	/// </summary>
	public partial class LNodeDialog : Form
	{
		private TreeNode treeSCL;
		private SCL sCL;
		private object nodeSCL;
		private tLNode LNodeSCL;
		private TreeViewSCL treeViewSCL;
		private ObjectManagement objectManagement = new ObjectManagement();
		
		public LNodeDialog()
		{
			InitializeComponent();
		}
		
		void TSubstationLoad(object sender, EventArgs e)
		{
			this.treeViewSCL = new TreeViewSCL();
		}
		
		public void CreatetLNode(TreeNode treeSCL, SCL sCLObject)
		{
			this.treeSCL = treeSCL;
			this.sCL = sCLObject;
			this.nodeSCL =sCLObject;
			
			if(this.sCL.IED!=null)
			{
				for( int a = 0; a < this.sCL.IED.Length; a++ )
				{
					if( this.sCL.IED[a].AccessPoint != null)
					{
						for(int b= 0;  b < this.sCL.IED[a].AccessPoint.Length; b++ )
						{
							if(this.sCL.IED[a].AccessPoint[b].Server != null)
							{
								for( int c =0; c < this.sCL.IED[a].AccessPoint[b].Server.LDevice.Length; c++)
								{
									if(this.sCL.IED[a].AccessPoint[b].Server.LDevice[c].LN != null)
									{
										for( int d = 0; d < this.sCL.IED[a].AccessPoint[b].Server.LDevice[c].LN.Length; d++)
										{
											this.LNodeSCL = new tLNode();
											this.LNodeSCL.ldInst = this.sCL.IED[a].AccessPoint[b].Server.LDevice[c].inst.ToString();
											this.LNodeSCL.iedName = this.sCL.IED[a].name;
											this.LNodeSCL.lnInst = this.sCL.IED[a].AccessPoint[b].Server.LDevice[c].LN[d].inst.ToString();
											this.LNodeSCL.lnClass = this.sCL.IED[a].AccessPoint[b].Server.LDevice[c].LN[d].lnClass;
											this.LNodeSCL.lnType = this.sCL.IED[a].AccessPoint[b].Server.LDevice[c].LN[d].lnType;
											this.comboBoxtLNode.Items.Add( new LNodeComboBox(this.LNodeSCL) );
										}
									}
								}
							}
							if(this.sCL.IED[a].AccessPoint[b].LN != null)
							{
								for(int d = 0; d < this.sCL.IED[a].AccessPoint[b].LN.Length; d++)
								{
									this.LNodeSCL = new tLNode();
									this.LNodeSCL.iedName = this.sCL.IED[a].name;
									this.LNodeSCL.lnInst = this.sCL.IED[a].AccessPoint[b].LN[d].inst.ToString();
									this.LNodeSCL.lnClass = this.sCL.IED[a].AccessPoint[b].LN[d].lnClass;
									this.LNodeSCL.lnType = this.sCL.IED[a].AccessPoint[b].LN[d].lnType;
									this.comboBoxtLNode.Items.Add( new LNodeComboBox(this.LNodeSCL) );
								}
							}
						}
					}
				}
			}
			this.comboBoxtLNode.DisplayMember = "DisplayLNodes";
		}
		
		public void ButtonOKClick(object sender, EventArgs e)
		{
			object lN = this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(this.treeSCL.TreeView.SelectedNode, typeof(tSubstation)).Tag;
			if(this.comboBoxtLNode.Items.Count > 0)
			{
				tLNode[] LNodes = new tLNode[this.comboBoxtLNode.Items.Count];
				for(int x = 0; x < this.comboBoxtLNode.Items.Count; x++)
				{
					LNodes[x] = (this.comboBoxtLNode.Items[x] as LNodeComboBox).LNodes;					
				}
				if(this.LNodeSCL != null)
				{
					this.LNodeSCL = null;
				}
				else
				{
					this.LNodeSCL = new tLNode();
				}	
				this.LNodeSCL = LNodes[this.comboBoxtLNode.SelectedIndex];
				this.objectManagement.AddObjectToArrayObjectOfParentObject(this.LNodeSCL, lN);
				treeViewSCL.GetNodesItemOfArray((lN as tSubstation).LNode, lN.GetType(), this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(this.treeSCL.TreeView.SelectedNode, typeof(tSubstation)));
			}
			this.Close();
		}
		
		public void ButtonCANCELClick(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		void ComboBoxtLNodeSelectedValueChanged(object sender, EventArgs e)
		{
			this.textBoxiedName.Text = (this.comboBoxtLNode.Items[comboBoxtLNode.SelectedIndex] as LNodeComboBox).LNodes.iedName.ToString();
			this.textBoxldInst.Text =   (this.comboBoxtLNode.Items[comboBoxtLNode.SelectedIndex] as LNodeComboBox).LNodes.ldInst.ToString();
			this.textBoxlnInst.Text =  (this.comboBoxtLNode.Items[comboBoxtLNode.SelectedIndex] as LNodeComboBox).LNodes.lnInst.ToString();
			this.textBoxlnClass.Text =  (this.comboBoxtLNode.Items[comboBoxtLNode.SelectedIndex] as LNodeComboBox).LNodes.lnClass.ToString();
			this.textBoxlnType.Text =  (this.comboBoxtLNode.Items[comboBoxtLNode.SelectedIndex] as LNodeComboBox).LNodes.lnType.ToString();
		}
	}

	class LNodeComboBox
	{
		public tLNode LNodes;
		public LNodeComboBox( tLNode LNodes )
		{
			this.LNodes = LNodes;
		}		
		public string DisplayLNodes
		{
			get
			{	
				if(this.LNodes.ldInst != "")
				{
					return this.LNodes.iedName + "$" + this.LNodes.ldInst + "$" + this.LNodes.lnInst  + this.LNodes.lnClass + this.LNodes.lnType;
				}
				return this.LNodes.iedName +  "$" + this.LNodes.lnInst  + this.LNodes.lnClass + this.LNodes.lnType;
			}
		}
	}
}

