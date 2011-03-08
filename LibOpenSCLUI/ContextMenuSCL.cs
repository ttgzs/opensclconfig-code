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
using System.Reflection;
using System.Windows.Forms;
using IEC61850.SCL;

namespace OpenSCL.UI
{
	/// <summary>
	/// Description of ContextMenuSCL.
	/// </summary>
	public class ContextMenuSCL
	{
		private TreeNode treeSCL;		
		private ContextMenuStrip contextMenuStrip;					
		private TreeViewSCL treeViewSCL;
		private ObjectManagement objectManagement;			
		
		/// <summary>
		/// Description of the ContextMenuSCL component.
		/// </summary>
		public ContextMenuSCL()
		{
			this.contextMenuStrip = new ContextMenuStrip();
			this.treeViewSCL = new TreeViewSCL();
			this.objectManagement = new ObjectManagement();			
		}
		
		/// <summary>
		/// This method creates a context menu that has all the possible options for the selected node
		/// like insert, delete or edit. This menu will be displayed every time that a node is selected
		/// (using the left button on the mouse) and pressing the right button on the mouse.
		/// </summary>		
		/// <param name="treeSCL">
		/// Selected node.
		/// </param>
		/// <returns>
		/// A Context menu created.
		/// </returns>
		public ContextMenuStrip GetContextMenuSCL(TreeNode treeSCL)		
		{		 	
			this.treeSCL = treeSCL;
			object sCLObject = treeSCL.Tag;			
			ToolStripMenuItem insertOption = new ToolStripMenuItem();											
			if(sCLObject !=null)
			{			
				if(sCLObject.GetType().Name == "tServer")
				{					
					insertOption.DropDownItems.AddRange(new ToolStripItem[] {
				          this.GenerateSubMenuItemInsert("Communication", "Communication")});
				}
				/*
				// Edit Custom XML Attributes
				if(sCLObject is tBaseElement)
					this.GenerateMenuItemCustomAttributes(this.contextMenuStrip);
					*/
				//An insert option is added to allow create another node of the same type.
				if(sCLObject.GetType().IsArray)
				{							
					string nameSCLToInsert = (sCLObject as Array).GetValue(0).GetType().Name;	
					//Eliminating some nodes types from the insert menu that will be displayed.					
					if(!this.treeViewSCL.SearchUPForType(treeSCL, typeof(tDataTypeTemplates)) && 
					   !this.treeViewSCL.SearchUPForType(treeSCL, typeof(tCommunication)) &&
					   this.ValidateObjectsForInsert(treeSCL.Tag.GetType()))
					{
						insertOption.DropDownItems.AddRange(new ToolStripItem[] {
				          this.GenerateSubMenuItemInsert(nameSCLToInsert, nameSCLToInsert)});					
					}					
				}
				else
				{						
					PropertyInfo[] attributesInformation;
					attributesInformation = sCLObject.GetType().GetProperties();									
					//It shows the Edit option on the ContextMenu
					if(this.ValidateObjectsForEditing(sCLObject.GetType()))
					{
						this.GenerateMenuItemEdit(this.contextMenuStrip);
					}
					foreach (PropertyInfo attributeInformation in attributesInformation) 
	        		{       
						//Eliminating some nodes types from the insert menu that will be displayed.
						if(!this.treeViewSCL.ValidateObjectPrimitive(attributeInformation) && 						   
						   !this.treeViewSCL.SearchUPForType(treeSCL, typeof(tDataTypeTemplates)) &&
						   !this.treeViewSCL.SearchUPForType(treeSCL, typeof(tCommunication)) &&
						   this.ValidateObjectsForInsert(treeSCL.Tag.GetType()))
        				{    	    				
    	    				TreeNode Node = treeSCL.Nodes[attributeInformation.PropertyType.Name];
	        				// If the variable is an Array type then an insert option will be added to create more nodes of the same type.	        				
	        				if(attributeInformation.PropertyType.BaseType.Name.Equals("Array"))
	        				{   	    					        	
        						if(Node==null)
    		    		    	{       							
        							insertOption.DropDownItems.AddRange(new ToolStripItem[] {
		                            this.GenerateSubMenuItemInsert(attributeInformation.PropertyType.Name ,attributeInformation.Name)});
        						}    
        					}
        					//If the selected node does not have a child node (an object), this function adds the insert option to create it.        					
        					else
        					{        						        				    		    		    					
    		    		    	if(Node==null)
    		    		    	{
    		    		    		if(attributeInformation.PropertyType.ToString() != typeof(tDataTypeTemplates).ToString() &&
    		    		    		   attributeInformation.PropertyType.ToString() != typeof(tCommunication).ToString())
    		    		    		{
    		    		    			insertOption.DropDownItems.AddRange(new ToolStripItem[] {
				                    		this.GenerateSubMenuItemInsert(attributeInformation.PropertyType.Name, attributeInformation.Name)});
    		    		    		}
    		    		    	}      			
        					}        			
        				}        		
					}				  					 					
				}
				if(insertOption.DropDownItems.Count>0)
				{
					this.GenerateMenuItemInsert(this.contextMenuStrip, insertOption);
				}					
				if(!this.treeViewSCL.SearchUPForType(treeSCL, typeof(tDataTypeTemplates)) &&					
				   !this.treeViewSCL.SearchUPForType(treeSCL, typeof(tCommunication)) &&
				   this.ValidateObjectsForDelete(treeSCL.Tag.GetType()))
				{					
					this.GenerateMenuItemRemove(this.contextMenuStrip);	
				}	
			}				
			return this.contextMenuStrip;
		}
				
		/// <summary>
		/// This method will create the insert option on the Context menu. 		
		/// </summary>
		/// <param name="contextMenuStrip">
		/// Context menu created.
		/// </param>
		/// <param name="insertOption">
		/// Insert option that will be included on the Context Menu.
		/// </param>
		private void GenerateMenuItemInsert(ContextMenuStrip contextMenuStrip, ToolStripMenuItem insertOption)
		{
			insertOption.Name = "insertOption";			
			insertOption.Text = "Insert";		
			contextMenuStrip.Items.Add(insertOption);		
		}
						
		/// <summary>
		/// This method will create an element that will be added to a submenu and it will 
		/// be displayed when the insert option was selected.	
		/// </summary>
		/// <param name="nametypeSCLToInsert">
		/// Name of the element that will be added on the submenu.
		/// </param>
		/// <returns>
		/// Element that will be included on the submenu.
		/// </returns>
		/// <remarks>
		/// This method is related to the event when a click is made on the submenu.
		/// </remarks>
		private ToolStripMenuItem GenerateSubMenuItemInsert(string nameSCLToInsert, string nameSCLToShow)
		{			
			ToolStripMenuItem ts = new ToolStripMenuItem();			
			ts.Text = nameSCLToShow;				
			ts.Name = nameSCLToInsert;									
			ts.Click += new System.EventHandler(this.clickInsertSCL);
			return ts;
		}
		
		/// <summary>
		/// Event that will be used when an option of the insert submenu is selected.		
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		private void clickInsertSCL(object sender, EventArgs e)
		{			
			ToolStripMenuItem ts = (ToolStripMenuItem) sender;			
			WindowTreeViewLNType windowTreeViewLNType;		
			OpenSCL.Object sCL = new OpenSCL.Object();
			sCL.Configuration = (SCL) this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Tag;		
			string apName;
			string iedName;	
			TreeNode objectFound = null;				
			switch(ts.Name)
			{
				case "Communication":								
					apName = this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Tag, "name").ToString();
					iedName = this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Parent.Tag, "name").ToString();					
					if(sCL.Configuration.Communication != null && sCL.Configuration.Communication.SubNetwork!= null)
					{					
						objectFound = this.treeViewSCL.SeekAssociation(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes, apName, iedName);						
					}				
					CommunicationDialog comm = new CommunicationDialog(this.treeSCL.TreeView.SelectedNode, sCL.Configuration, iedName, apName, objectFound);					
					comm.ShowDialog();	
					break;						
				case  "tGSEControl":										
					if(this.treeViewSCL.getDataset(this.treeSCL).Count==0)
					{
						MessageBox.Show("The SCL file should have at least one DataSet configured on this Device");
						break;
					}
					GSEDialog gSEDlg = new GSEDialog(this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Tag, "inst").ToString(), 
					                                 this.treeSCL.TreeView.SelectedNode.Parent, this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Parent.Parent.Parent.Tag, "name").ToString(), 
					                                 this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Tag, "name").ToString());
					gSEDlg.ShowDialog();
					break;					
				case  "tGSEControl[]":
					if(this.treeViewSCL.getDataset(this.treeSCL).Count==0)//victor
					{
						MessageBox.Show("The SCL file should have at least one DataSet configured on this Device");
						break;
					}
					gSEDlg = new GSEDialog(this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Tag, "inst").ToString(), 
					                       this.treeSCL.TreeView.SelectedNode, this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Parent.Parent.Tag, "name").ToString(), 
					                       this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Parent.Parent.Parent.Parent.Tag, "name").ToString());
					gSEDlg.ShowDialog();									
					break;					
				case  "tSampledValueControl":					
					if(this.treeViewSCL.getDataset(this.treeSCL).Count==0)//victor
					{
						MessageBox.Show("The SCL file should have at least one DataSet configured on this Device");
						break;
					}
					SMVDialog smvDlg = new SMVDialog(this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Tag, "inst").ToString(), 
					                                 this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Parent.Parent.Parent.Tag, "name").ToString(), 
					                                 this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Tag, "name").ToString(), 
					                                 this.treeSCL.TreeView.SelectedNode.Parent);
					smvDlg.ShowDialog();
					break;
				case  "tSampledValueControl[]":
					if(this.treeViewSCL.getDataset(this.treeSCL).Count==0)
					{
						MessageBox.Show("The SCL file should have at least one DataSet configured on this Device");
						break;
					}
					smvDlg = new SMVDialog(this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Tag, "inst").ToString(), 
					                                 this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Parent.Parent.Tag, "name").ToString(), 
					                                 this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Parent.Parent.Parent.Parent.Tag, "name").ToString(), 
					                                 this.treeSCL.TreeView.SelectedNode);
					smvDlg.ShowDialog();
					break;	
				case "tDOI[]":
					windowTreeViewLNType = new WindowTreeViewLNType(this.treeSCL.TreeView.SelectedNode, 
				                                                sCL.Configuration, 
				                                                this.treeSCL.TreeView.SelectedNode.Tag, 
				                                                "Edit Logical Node's Data Objects");
					windowTreeViewLNType.ShowDialog();
					break;
				case "tDataSet[]":
				case "tDataSet":
					DataSetDialog dataSetDlg = new DataSetDialog();
					dataSetDlg.CreateDataSet(this.treeSCL.TreeView.SelectedNode, sCL.Configuration);
					dataSetDlg.ShowDialog();
					break;				
				case "tIED":
					Utils utils = new Utils();
					utils.CreateIED(sCL.Configuration, this.treeSCL);
					break;				
				case"tLNode[]":
				case"tLNode":
					LNodeDialog LNodeDlg = new LNodeDialog();
					LNodeDlg.CreatetLNode(this.treeSCL.TreeView.SelectedNode, sCL.Configuration);
					LNodeDlg.ShowDialog();
					break;
				default:
					this.treeViewSCL.Insert(this.treeSCL.TreeView.SelectedNode, ts.Text, ts.Name);
				break;
			}							
		}				
			
		/// <summary>
		/// This method will create the remove option to delete nodes of the Context menu.
		/// </summary>
		/// <param name="contextMenuStrip">
		/// Context menú created.
		/// </param>
		/// <param name="removerOption">
		/// Remove opcion included on the Context Menu.
		/// </param>
		private void GenerateMenuItemRemove(ContextMenuStrip contextMenuStrip)
		{
			ToolStripMenuItem removeOption = new ToolStripMenuItem();
			removeOption.Name = "removeOption";
			removeOption.Text = "Remove";
			removeOption.Click+= new System.EventHandler(this.clickMenuRemoveSCL);
			contextMenuStrip.Items.Add(removeOption);			
		}	
		
		/// <summary>
		/// This event deletes a selected node.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		public void clickMenuRemoveSCL(object sender, EventArgs e)
		{				
			WindowTreeViewLNType windowTreeViewLNType;
			OpenSCL.Object sCL = new OpenSCL.Object();
			sCL.Configuration = (SCL) this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Tag;	
			if(!this.treeSCL.TreeView.SelectedNode.Tag.GetType().Equals(typeof(SCL)))
			{				
				switch(this.treeSCL.TreeView.SelectedNode.Tag.GetType().Name)
				{	
					case "tDOI[]":
					case "tDOI":										
					case "tDAI[]":					
					case "tDAI":
					case "tSDI[]":
					case "tSDI":
					case "tVal[]":	
					case "tVal":
						this.treeSCL = this.treeViewSCL.SearchUPForBaseTypeAndGetSCLTreeNode(this.treeSCL.TreeView.SelectedNode,(typeof(tAnyLN)));							
						if(this.treeSCL!=null)
						{
							windowTreeViewLNType = new WindowTreeViewLNType(this.treeSCL, sCL.Configuration, this.treeSCL.Tag, "Edit");
							windowTreeViewLNType.ReloadLNType();
							windowTreeViewLNType.ShowDialog();
							}
							else
							{
								MessageBox.Show("It doesn't load the class");
							}
						break;				
					case "tGSEControl": 
						treeViewSCL.RemoveGSEandSMV(this.treeSCL, this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Tag, "name").ToString(), "tGSE");
						break;
					case "tSampledValueControl": 
						treeViewSCL.RemoveGSEandSMV(this.treeSCL, this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Tag, "name").ToString(), "tSMV");
						break;	
					default:
						if(MessageBox.Show("Warning!, Do you want to remove this node?", "Removing Node", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly, false) == DialogResult.Yes)
						{
							AutomataForValidateToTreeNode automataForValidateToTreeNode;											
							RegularExpressionTree regularExpressionTree = new RegularExpressionTree();
							automataForValidateToTreeNode = new AutomataForValidateToTreeNode(this.treeSCL.TreeView.SelectedNode, regularExpressionTree.GetRegExpToDelete(this.treeSCL.TreeView.SelectedNode));
							automataForValidateToTreeNode.InterpretString();												
						}
						break;					
				}				
			}
			else
			{
				MessageBox.Show("Warning!, The SCL node can not be removed!!!");
			} 					
		}				

		/// <summary>
		/// This method will create the edit option to modify nodes from the Context menu.
		/// </summary>
		/// <param name="contextMenuStrip">
		/// Context menú created.
		/// </param>
		private void GenerateMenuItemEdit(ContextMenuStrip contextMenuStrip)
		{
			ToolStripMenuItem editOption = new ToolStripMenuItem();
			editOption.Name = "editOption";
			editOption.Text = "Edit";
			editOption.Click+= new EventHandler(EditOption_Click);
			contextMenuStrip.Items.Add(editOption);
		}
		
		private void GenerateMenuItemCustomAttributes(ContextMenuStrip contextMenuStrip)
		{
			ToolStripMenuItem customAttrOption = new ToolStripMenuItem();
			customAttrOption.Name = "CustomAttrOption";
			customAttrOption.Text = "Add/Edit Custom Attribute";
			customAttrOption.Click+= new EventHandler(CustomAttrOption_Click);
			contextMenuStrip.Items.Add(customAttrOption);
		}
		
		/// <summary>
		/// This method validates if the selected node should show an edit menu.		
		/// </summary>
		/// <param name="sCLType">
		/// Object type that is contained on the selected node.
		/// </param>
		/// <returns>
		/// If the object should show an edit menu then it returns a true value otherwise a 
		/// false value is returned.
		/// </returns>
		private bool ValidateObjectsForEditing(Type sCLType)
		{
			switch(sCLType.Name)
			{
				case "tLN":
				case "LN0":
				case "tPrivate":
				case "tDataSet":
				case "tGSEControl":
				case "tSampledValueControl":
					return true;
			}
			return false;
		}
			
		/// <summary>
		/// This method validates if the selected node should show the delete menu.		
		/// </summary>
		/// <param name="sCLType">
		/// Object type that is contained on the selected node.
		/// </param>
		/// <returns>
		/// If the object should show a delete menu then it returns a true value otherwise a 
		/// false value is returned.
		/// </returns>
		private bool ValidateObjectsForDelete(Type sCLType)
		{
			switch(sCLType.Name)
			{
				case "tDOI[]":
				case "tDOI":
				case "tDAI[]":
				case "tDAI":
				case "tSDI[]":
				case "tSDI":
				case "tVal[]":
				case "tVal":
				case "tDataSet":
				case "tFCDA[]":
				case "tFCDA":
					return false;
			}
			return true;
		}	
			
		/// <summary>
		/// This method validates if the selected node should show the insert menu.		
		/// </summary>
		/// <param name="sCLType">
		/// Object type that is contained on the selected node.
		/// </param>
		/// <returns>
		/// If the object should show an insert menu then it returns a true value otherwise a 
		/// false value is returned. 
		/// </returns>
		private bool ValidateObjectsForInsert(Type sCLType)
		{
			switch(sCLType.Name)
			{
				case "tDOI[]":
				case "tDOI":
				case "tDAI[]":
				case "tDAI":
				case "tSDI[]":
				case "tSDI":
				case "tVal[]":
				case "tVal":
				case "tDataSet":
				case "tFCDA[]":
					return false;
			}
			return true;
		}
			
		/// <summary>
		/// This event edit a selected node.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		private void EditOption_Click(object sender, EventArgs e)
		{
			OpenSCL.Object sCL = new OpenSCL.Object();
			sCL.Configuration = (SCL) this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Tag;
			if(treeSCL.Tag is tPrivate)
			{
				PrivateDialog windowsPrivate = new PrivateDialog(treeSCL.Tag as tPrivate);
				windowsPrivate.ShowDialog();
				windowsPrivate.Dispose();
			}
			else if(treeSCL.Tag is tAnyLN)
			{
				WindowTreeViewLNType windowTreeViewLNType = new WindowTreeViewLNType(this.treeSCL, sCL.Configuration, this.treeSCL.Tag, "Edit");
				windowTreeViewLNType.ReloadLNType();
				windowTreeViewLNType.ShowDialog();
			}
			else if(treeSCL.Tag is tDataSet)
			{
				DataSetDialog windowDataSet = new DataSetDialog();
				windowDataSet.ReloadDataSet(treeSCL, sCL.Configuration);
				windowDataSet.Show();				
			}
			else if(treeSCL.Tag is tGSEControl)
			{					
				if(this.treeViewSCL.getDataset(this.treeSCL).Count==0)//victor
				{
					MessageBox.Show("The SCL file should have at least one DataSet configured on this Device");
					
				}
				else
				{
					GSEDialog gseDlg = new GSEDialog(this.treeSCL.TreeView.SelectedNode, this.treeSCL, this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Parent.Parent.Parent.Parent.Tag, "name").ToString(), 
				                                 this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Tag, "name").ToString(), this.treeSCL.TreeView.SelectedNode.Tag);
					gseDlg.ShowDialog();
				}
			}
			else if(treeSCL.Tag is tSampledValueControl)
			{
				object opt = null;	
				if(this.treeSCL.TreeView.SelectedNode.FirstNode!=null)
				{
					opt = this.treeSCL.TreeView.SelectedNode.FirstNode.Tag;
				}
				if(this.treeViewSCL.getDataset(this.treeSCL).Count==0)
				{
					MessageBox.Show("The SCL file should have at least one DataSet configured on this Device");					
				}
				else
				{
					SMVDialog smvDlg = new SMVDialog(this.treeSCL, this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Parent.Parent.Parent.Parent.Tag, "name").ToString(), 
				                                 this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Tag, "name").ToString(), 
				                                 this.treeSCL.TreeView.SelectedNode.Tag, opt,
				                                 this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Parent.Parent.Parent.Tag, "inst").ToString()); //victor
					smvDlg.ShowDialog();
				}
			}
		}
		
		private void CustomAttrOption_Click(object sender, EventArgs e)
		{
			OpenSCL.Object sCL = new OpenSCL.Object();
			sCL.Configuration = (SCL) this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Tag;
			if(treeSCL.Tag is tBaseElement) {
				CustomAttributeDialog custAttrDlg = new CustomAttributeDialog(sCL.Configuration,
				                                                              treeSCL.Tag as  tBaseElement);
				DialogResult res =  custAttrDlg.ShowDialog();
				
				if (res == DialogResult.OK) {
					
				}
			}
		}
	}
}
