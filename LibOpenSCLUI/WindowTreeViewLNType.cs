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
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using IEC61850.SCL;

namespace OpenSCL.UI
{
	/// <summary>
	/// This class displays a window to select the attributes of an LN type specified.
	/// </summary>
	public partial class WindowTreeViewLNType : Form
	{	
		private TreeViewLNType treeViewLNType;
		private TreeNode treeNodeLN;
		private object lN;	
		private bool bandModify;		
		private OpenSCL.Object sCL = new OpenSCL.Object();
		private TreeNode nodeSelected;
		private ObjectManagement objectManagement;
		
		/// <summary>
		/// This method inicializes the values.
		/// </summary>
		/// <param name="treeNodeLN">
		/// treeNode that contains the LN data that will be used to create them.		
		/// </param>
		/// <param name="sCL">
		/// Main SCL class that will get the data selected.
		/// </param>
		/// <param name="lN">
		/// LN selected.
		/// </param>
		/// <param name="title">
		/// Title of the window.
		/// </param>
		public WindowTreeViewLNType(TreeNode treeNodeLN, SCL sCLObject, object lN, string title)
		{
			this.treeNodeLN= treeNodeLN;
			this.sCL.Configuration = sCLObject;			
			this.lN = lN;
			// Calling InitializeComponent() is required for Windows Forms designer support.
			InitializeComponent();
			this.Text = title;
			this.label1.ForeColor = Color.Blue;					
			this.treeViewLNType = new TreeViewLNType(this.treeNodeLN, this.sCL.Configuration);			
			this.treeLN.Nodes.Add(treeViewLNType.GetTreeNodeTypesLNs(this.lN));
			this.treeLN.Nodes[0].Expand();
			this.bandModify = false;
			this.objectManagement =new ObjectManagement();
		}		
		
		/// <summary>
		/// This event close the window of the LN type selected.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void ButtonCancelClick(object sender, EventArgs e)
		{
			this.Close();			
		}
		
		/// <summary>
		/// This event creates the nodes on the main SCL TreeNode according to the Data selected.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void ButtonOkClick(object sender, EventArgs e)
		{					
			AutomataForValidateToTreeNode automataForValidateToTreeNode;
			if(treeNodeLN.Nodes.Count != 0)
			{
				RegularExpressionTree regularExpressionTree = new RegularExpressionTree();
				automataForValidateToTreeNode = new AutomataForValidateToTreeNode(treeNodeLN.Nodes[0], regularExpressionTree.GetRegExpToDelete(treeNodeLN.Nodes[0]));
				automataForValidateToTreeNode.InterpretString();
			}
			if(this.bandModify)
			{				
				automataForValidateToTreeNode = new AutomataForValidateToTreeNode(this.treeNodeLN, "-DOI/%&*0");
				automataForValidateToTreeNode.InterpretString();				
				this.treeViewLNType.EmptyTreeNodeLNType(true);
			}
			else
			{
				this.treeViewLNType.EmptyTreeNodeLNType(false);
			}			
			this.Close();
		}
		
		/// <summary>
		/// This event shows the attributes of the data selected on the treeNode in the propertyGrid object.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void TreeLNAfterSelect(object sender, TreeViewEventArgs e)
		{			
			if(e.Node.Tag is tDA||e.Node.Tag is tBDA || e.Node.Tag is DOData)
			{
				this.propertyGridLNType.SelectedObject = e.Node.Tag;
				if(e.Node.Checked == true)
				{
					this.propertyGridLNType.Enabled = true;	
				}
				else
				{
					this.propertyGridLNType.Enabled = false;
				}				
			}
			if(e.Node.Tag is ctlModels)
			{
				this.nodeSelected = e.Node;
			}           
		}		
		
		/// <summary>
		/// This method refresh the main SCL Tree using the values of the data selected on the LN specified.
		/// </summary>
		public void ReloadLNType()
		{
			this.bandModify = true;
			this.treeLN.Nodes.Clear();
			this.treeViewLNType = new TreeViewLNType(this.treeNodeLN, this.sCL.Configuration);			
			this.treeLN.Nodes.Add(treeViewLNType.ReloadLNType(this.lN));
			this.treeLN.Nodes[0].Expand();
		}
		
		/// <summary>
		/// This event check the attributes that are required and don't allow modify them.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void TreeLNAfterCheck(object sender, TreeViewEventArgs e)
		{	
			if( e.Node.Name == "root")
			{
				if(e.Node.Checked == false)
					e.Node.Checked = true;
			}
			else
			{
				bool flag = false;
				if(e.Node.Parent != null)
				{
					object elementOfLNtype = e.Node.Parent.Tag;
					PropertyInfo[] attributesInformation = elementOfLNtype.GetType().GetProperties();
					foreach (PropertyInfo attributeInformation in attributesInformation)
					{
						if(attributeInformation.Name.Equals(e.Node.Name))
						{
							foreach (object AttributeRestriction in attributeInformation.GetCustomAttributes(typeof(RequiredAttribute), true))
							{
								flag = true;
							}
							if(flag == true)
							{
								if(e.Node.Checked == false & flag == true )
									e.Node.Checked = true;
							}
						}
					}
				}
			}	
		}
		
		/// <summary>
		/// This event enable/disable data according to the value of the ctlModel attribute selected.
		/// </summary>
		/// <param name="s">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void PropertyLNTypeValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			if(e.ChangedItem.PropertyDescriptor.PropertyType.Name.Equals("ctlModelsEnum"))
			{
				if(this.nodeSelected != null)
				{
					switch(e.ChangedItem.Value.ToString())
					{
						case "status_only":
							if(this.nodeSelected.Parent.Parent.Nodes["SBO"]!=null)
							{
								this.nodeSelected.Parent.Parent.Nodes.RemoveByKey("SBO");
							}
							if(this.nodeSelected.Parent.Parent.Nodes["SBOw"]!=null)
							{
								this.nodeSelected.Parent.Parent.Nodes.RemoveByKey("SBOw");
							}
							if(this.nodeSelected.Parent.Parent.Nodes["Oper"]!=null)
							{
								this.nodeSelected.Parent.Parent.Nodes.RemoveByKey("Oper");
							}
							if(this.nodeSelected.Parent.Parent.Nodes["Cancel"]!=null)
							{
								this.nodeSelected.Parent.Parent.Nodes.RemoveByKey("Cancel");
							}
							break;
						case "direct_with_normal_security":
							if(this.nodeSelected.Parent.Parent.Nodes["SBO"]!=null)
							{
								this.nodeSelected.Parent.Parent.Nodes.RemoveByKey("SBO");
							}
							if(this.nodeSelected.Parent.Parent.Nodes["SBOw"]!=null)
							{
								this.nodeSelected.Parent.Parent.Nodes.RemoveByKey("SBOw");
							}
							if(this.nodeSelected.Parent.Parent.Nodes["Cancel"]!=null)
							{
								this.nodeSelected.Parent.Parent.Nodes.RemoveByKey("Cancel");
							}
							this.CreateNode("Oper");
							break;
						case "sbo_with_normal_security":
							if(this.nodeSelected.Parent.Parent.Nodes["SBOw"]!=null)
							{
								this.nodeSelected.Parent.Parent.Nodes.RemoveByKey("SBOw");
							}
							this.CreateNode("SBO");
							this.CreateNode("Oper");
							this.CreateNode("Cancel");
							break;
						case "sbo_with_enhanced_security" :
							if(this.nodeSelected.Parent.Parent.Nodes["SBO"]!=null)
							{
								this.nodeSelected.Parent.Parent.Nodes.RemoveByKey("SBO");
							}
							this.CreateNode("SBOw");
							this.CreateNode("Oper");
							this.CreateNode("Cancel");
							break;
						case "direct_with_enhanced_security" :
							{
								this.nodeSelected.Parent.Parent.Nodes.RemoveByKey("SBO");
							}
							if(this.nodeSelected.Parent.Parent.Nodes["SBOw"]!=null)
							{
								this.nodeSelected.Parent.Parent.Nodes.RemoveByKey("SBOw");
							}
							this.CreateNode("Oper");
							this.CreateNode("Cancel");
							break;
					}
				}
			}
		}
		
		/// <summary>
		/// This event select the information for the selected node.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void TreeLNBeforeCheck(object sender, TreeViewCancelEventArgs e)
		{
			this.nodeSelected = e.Node;				
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="nameDAToAdd">
		/// 
		/// </param>
		private void CreateNode(string nameDAToAdd)
		{
			if(this.nodeSelected.Parent.Parent.Nodes[nameDAToAdd]==null)
			{
				object objectDA = this.objectManagement.FindVariable(this.nodeSelected.Parent.Parent.Tag, nameDAToAdd);
				this.objectManagement.FindVariableAndSetValue(objectDA,"Visible", true);
				PropertyInfo property = this.nodeSelected.Parent.Parent.Tag.GetType().GetProperty(nameDAToAdd);
				this.treeViewLNType.AddNodesOfArray(property, objectDA, this.nodeSelected.Parent.Parent);
			}
		}	
	}
}
