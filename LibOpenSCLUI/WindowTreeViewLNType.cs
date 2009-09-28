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
			this.treeView1.Nodes.Add(treeViewLNType.GetTreeNodeTypesLNs(this.lN));
			this.treeView1.Nodes[0].Expand();
			this.bandModify = false;
		}
		
		/// <summary>
		/// This event is activated when an attribute box is checked or not. If the box is checked then the attributes 
		/// of that data could be modified by the user, otherwise the attributes only could be visualized.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void showChecked(object sender, TreeViewEventArgs e)
		{			
			this.propertyGridLNType.SelectedObject = e.Node.Tag;				
			if(e.Node.Checked == true)
			{
				if(e.Node.Parent.Checked == false)
				{
					e.Node.Parent.Checked = true;
				}
				this.propertyGridLNType.Enabled = true;
			}
			else
			{
				this.propertyGridLNType.Enabled = false;
			}
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
			//OpenSCL.Object Object = new OpenSCL.Object(); 	
			if(this.bandModify)
			{				
				AutomataForValidateToTreeNode automataForValidateToTreeNode;
				if(this.treeNodeLN.Parent.Parent.Tag is tAccessPoint)
				{
					automataForValidateToTreeNode = new AutomataForValidateToTreeNode(this.treeNodeLN, "-DOI/%&lnType->&....type->^-id=&iedType=;%%*0");				
					automataForValidateToTreeNode.InterpretString();				
				}
				else if(this.treeNodeLN.Tag is LN0)
				{
					automataForValidateToTreeNode = new AutomataForValidateToTreeNode(this.treeNodeLN, "-DOI/%&lnType->&......type->^-id=&iedType=;%%*0");																													
					automataForValidateToTreeNode.InterpretString();
				}	
				else if(this.treeNodeLN.Parent.Parent.Tag is tLDevice)
				{							
					automataForValidateToTreeNode = new AutomataForValidateToTreeNode(this.treeNodeLN, "-DOI/%&lnType->&.......type->^-id=&iedType=;%%*0");				
					automataForValidateToTreeNode.InterpretString();
				}		
			}
			this.treeViewLNType.EmptyTreeNodeLNType();		
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
		void TreeView1AfterSelect(object sender, TreeViewEventArgs e)
		{			
			if(e.Node.Tag is tDA||e.Node.Tag is tBDA)
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
		}		
		
		/// <summary>
		/// This method refresh the main SCL Tree using the values of the data selected on the LN specified.
		/// </summary>
		public void ReloadLNType()
		{
			this.bandModify = true;
			this.treeView1.Nodes.Clear();
			this.treeViewLNType = new TreeViewLNType(this.treeNodeLN, this.sCL.Configuration);			
			this.treeView1.Nodes.Add(treeViewLNType.ReloadLNType(this.lN));
			this.treeView1.Nodes[0].Expand();
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
		void TreeView1AfterCheck(object sender, TreeViewEventArgs e)
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
	}
}
