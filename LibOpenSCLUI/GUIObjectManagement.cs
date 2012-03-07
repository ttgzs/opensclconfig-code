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
	/// Description of GUIObjectManagement.
	/// </summary>
	public class Utils
	{
		public object ObjectReturnedinAfterSelect;																																																		
		public TreeViewSCL treeViewSCL;
		private ObjectManagement objectManagement;
   		
		public Utils()
		{
			this.objectManagement = new ObjectManagement();
			this.treeViewSCL = new TreeViewSCL();
		}
   		
		/// <summary>
		/// This method updates the attributes of the propertyGrid when a Node of the tree is selected.
		/// </summary>
		/// <returns>
		/// The object that contains the information of the node selected.
		/// </returns>
		public object UpdatePropertyGrid(object NodetreeViewFile)
		{        			
            if (NodetreeViewFile != null && ! NodetreeViewFile.GetType().IsArray)
            {
                string clase = "IEC61850.SCL." + NodetreeViewFile.GetType().Name.ToString() + "Hierachy";
                Type TypeClass = Type.GetType(clase);
                if (TypeClass != null)
                {
                    object HierachyClass = Activator.CreateInstance(TypeClass);
                    if (HierachyClass != null)
                    {
                        this.objectManagement.EmptySourcetoDestinyObject(NodetreeViewFile, HierachyClass);
                        ObjectReturnedinAfterSelect = HierachyClass;                       
                    }                    
                    else
                        ObjectReturnedinAfterSelect = NodetreeViewFile;                        
                }
                else
                        ObjectReturnedinAfterSelect = NodetreeViewFile;                        
            }
            return ObjectReturnedinAfterSelect;	        
		}	
		
		/// <summary>
		/// This method updates the SCL tree using the SCL object that contains the clases of the 
		/// IED imported.
		/// </summary>
		/// <param name="treeViewProject">
		/// TreeView of the main SCL where the new nodes of the IED file will be insert.
		/// </param>
		/// <param name="scl">
		/// SCL object created using the deserializer method on the ICD or CID file of the IED to import.
		/// </param>
		public void ImportIEDUI(TreeView treeViewProject, SCL scl)
		{
			TreeView treeViewSCLProject;
			TreeViewSCL treeViewSCL = new TreeViewSCL();
			TreeNode sCLObject;
			treeViewSCLProject = treeViewProject;
			TreeNode treeViewToImport = new TreeNode();					
			treeViewToImport = treeViewSCL.GetTreeNodeSCL("TreeNodeToImport",scl);			
			
			if(scl.Substation != null)
			{
				sCLObject = treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes["tSubstation[]"];
				if(sCLObject !=null)
				{
					treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes.RemoveByKey("tSubstation[]");					
					treeViewSCL.GetNodesItemOfArray((treeViewSCLProject.Nodes["root"].Nodes["SCL"].Tag as SCL).Substation, treeViewSCLProject.Nodes["root"].Nodes["SCL"].Tag.GetType(), treeViewSCLProject.Nodes["root"].Nodes["SCL"]);
				}	
				else
				{						
					TreeNode node = new TreeNode();
					node.Name = "tSubstation[]";
					node.Text = "Substation";
					node.Tag =  scl.Header;						
					treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes.Add(node);
					
					this.CopyNodes(treeViewToImport.Nodes["SCL"].Nodes["tSubstation[]"], treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes["tSubstation[]"], sCLObject);
				}
			}
			if(scl.Header!=null)
			{
				sCLObject = treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes["tHeader"];					
				if(sCLObject !=null)
				{
					treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes.RemoveByKey("tHeader");					
					treeViewSCL.GetNodes((treeViewSCLProject.Nodes["root"].Nodes["SCL"].Tag as SCL).Header, treeViewSCLProject.Nodes["root"].Nodes["SCL"]);
				}	
				else
				{						
					TreeNode node = new TreeNode();
					node.Name = "tHeader";
					node.Text = "Header";
					node.Tag =  scl.Header;						
					treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes.Add(node);					
					this.CopyNodes(treeViewToImport.Nodes["SCL"].Nodes["tHeader"], treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes["tHeader"], sCLObject);
				}
			}			
			if(scl.IED!=null)
			{
				sCLObject = treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes["tIED[]"];					
				if(sCLObject !=null)
				{
					treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes.RemoveByKey("tIED[]");					
					treeViewSCL.GetNodesItemOfArray((treeViewSCLProject.Nodes["root"].Nodes["SCL"].Tag as SCL).IED, 
					                                treeViewSCLProject.Nodes["root"].Nodes["SCL"].Tag.GetType(), 
					                                treeViewSCLProject.Nodes["root"].Nodes["SCL"]);
				}	
				else
				{						
					TreeNode nodeIED = new TreeNode();
					nodeIED.Name = "tIED[]";
					nodeIED.Text = "IED";
					nodeIED.Tag =  scl.IED;						
					treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes.Add(nodeIED);
					
					this.CopyNodes(treeViewToImport.Nodes["SCL"].Nodes["tIED[]"], treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes["tIED[]"], sCLObject);
				}
			}					
			if(scl.Communication!=null)
			{
				sCLObject = treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"];					
				if(sCLObject !=null)
				{
					treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes.RemoveByKey("tCommunication");					
					treeViewSCL.GetNodes((treeViewSCLProject.Nodes["root"].Nodes["SCL"].Tag as SCL).Communication, treeViewSCLProject.Nodes["root"].Nodes["SCL"]);
				}	
				else
				{						
					TreeNode nodeCommunication = new TreeNode();
					nodeCommunication.Name = "tCommunication";
					nodeCommunication.Text = "Communication";
					nodeCommunication.Tag =  scl.Communication;						
					treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes.Add(nodeCommunication);					
					this.CopyNodes(treeViewToImport.Nodes["SCL"].Nodes["tCommunication"], treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"], sCLObject);
				}
			}				
			if(scl.DataTypeTemplates!=null)
			{
				sCLObject = treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes["tDataTypeTemplates"];
				if(sCLObject !=null)
				{						
					this.CopyNodes(treeViewToImport.Nodes["SCL"].Nodes["tDataTypeTemplates"].Nodes["tLNodeType[]"], treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes["tDataTypeTemplates"].Nodes["tLNodeType[]"], sCLObject);
					this.CopyNodes(treeViewToImport.Nodes["SCL"].Nodes["tDataTypeTemplates"].Nodes["tDOType[]"], treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes["tDataTypeTemplates"].Nodes["tDOType[]"], sCLObject);
					this.CopyNodes(treeViewToImport.Nodes["SCL"].Nodes["tDataTypeTemplates"].Nodes["tDAType[]"], treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes["tDataTypeTemplates"].Nodes["tDAType[]"], sCLObject);
					this.CopyNodes(treeViewToImport.Nodes["SCL"].Nodes["tDataTypeTemplates"].Nodes["tEnumType[]"], treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes["tDataTypeTemplates"].Nodes["tEnumType[]"], sCLObject);
				}		
				else
				{
					TreeNode nodeDataTypeTemplates = new TreeNode();
					nodeDataTypeTemplates.Name = "tDataTypeTemplates";
					nodeDataTypeTemplates.Text = "DataTypeTemplates";
					nodeDataTypeTemplates.Tag =  scl.DataTypeTemplates;						
					treeViewSCLProject.Nodes["root"].Nodes["SCL"].Nodes.Add(nodeDataTypeTemplates);					
					this.CopyNodes(treeViewToImport.Nodes["SCL"].Nodes["tDataTypeTemplates"], treeViewProject.Nodes["root"].Nodes["SCL"].Nodes["tDataTypeTemplates"], sCLObject);
				}
			}			
		}	
		
		/// <summary>
		/// This method allows to create a new item of the history to identify when the file of an IED was imported.		
		/// </summary>
		/// <param name="treeViewProject">
		/// TreeView of the main SCL where the new nodes of the History will be insert.
		/// </param>
		/// <param name="objectSCLProject">
		/// SCL object of the project file.
		/// </param>		
		public void CreateHistory(TreeView treeViewProject, SCL objectSCLProject)
		{
			TreeViewSCL treeViewSCL = new TreeViewSCL();
			TreeNode sCLObject;
			
			if(objectSCLProject.Header == null)
			{
				objectSCLProject.Header = new tHeader();
			}			
			HistoryDialog historyDlg = new HistoryDialog(objectSCLProject.Header);
			historyDlg.ShowDialog();
			if (historyDlg.DialogResult == DialogResult.OK)
			{
				sCLObject = treeViewProject.Nodes["root"].Nodes["SCL"].Nodes["tHeader"];
				if(sCLObject==null)
				{
					treeViewSCL.GetNodes(objectSCLProject.Header, treeViewProject.Nodes["root"].Nodes["SCL"]);
				}
				else
				{
					treeViewSCL.GetNodesItemOfArray(objectSCLProject.Header.History, objectSCLProject.Header.GetType(), sCLObject);
				}				
			}	
			historyDlg.Dispose();			
		}	
		
		/// <summary>
		/// This method copies the nodes from a source treenode to another TreeNode destiny.		
		/// </summary>
		/// <param name="nodeSource">
		/// TreeNode that contains the origin nodes.		
		/// </param>
		/// <param name="nodeDestiny">
		/// TreeNode that contains the final nodes.
		/// </param>
		private void CopyNodes(TreeNode nodeSource, TreeNode nodeDestiny, TreeNode sCLObject)
		{
			if(nodeSource != null)
			{				
				if(nodeDestiny != null)
				{													
					TreeNode[] myTreeNodeArray = new TreeNode[nodeSource.Nodes.Count];
					nodeSource.Nodes.CopyTo(myTreeNodeArray, 0);
					nodeDestiny.Nodes.AddRange(myTreeNodeArray);
				}
				else
				{
					sCLObject.Nodes.Add(nodeSource);					
				}				
			}				
		}	
		
		public static void AddTPTreeNode(tP tp, TreeNode p) {
			TreeNode treenode1 = new TreeNode();
			treenode1 = new TreeNode();				
			treenode1.Name = tp.typeEnum.ToString();
			treenode1.Tag = tp;
			treenode1.Text = tp.typeEnum.ToString();
			p.Nodes.Add(treenode1);
		}
		
		public void AddTPTreeNode(object tagNode, string name, string text, object address, TreeNode p)		
		{
			TreeNode treenode1 = new TreeNode();
			this.objectManagement.AddObjectToArrayObjectOfParentObject(tagNode, address);		
			treenode1 = new TreeNode();				
			treenode1.Name = name;
			treenode1.Tag = tagNode;
			treenode1.Text = text;
			p.Nodes.Add(treenode1);
		}
   		
		public void CreateIED(SCL sCL, TreeNode nodeSCL)
		{		
			tIED iED = new tIED();	
			iED.configVersion = "0";
			this.objectManagement.AddObjectToArrayObjectOfParentObject(iED, sCL);
			tAccessPoint accessPoint = new tAccessPoint();
			this.objectManagement.AddObjectToArrayObjectOfParentObject(accessPoint, iED);
			accessPoint.Server = new tServer();
			accessPoint.Server.Authentication = new tServerAuthentication();
			tLDevice lDevice = new tLDevice();
			this.objectManagement.AddObjectToArrayObjectOfParentObject(lDevice, accessPoint.Server);
			lDevice.LN0 = new LN0();
			tLN lN = new tLN();
			lN.lnType = "LPHD1";
			lN.inst = 1;			
			lN.lnClass = tLNClassEnum.LPHD.ToString();
			this.objectManagement.AddObjectToArrayObjectOfParentObject(lN, lDevice);			
			this.treeViewSCL.GetNodesItemOfArray(sCL.IED, sCL.GetType(), nodeSCL.TreeView.Nodes["root"].Nodes["SCL"]);
			this.CreatingDependenciesLN(sCL, sCL.IED[sCL.IED.Length-1].AccessPoint[0].Server
			                            .LDevice[0].LN0, nodeSCL.TreeView.Nodes["root"].Nodes["SCL"]
			                            .Nodes["tIED[]"].Nodes[sCL.IED.Length-1].Nodes["tAccessPoint[]"]
			                            .Nodes[0].Nodes["tServer"].Nodes["tLDevice[]"].Nodes[0].Nodes["LN0"]);
			this.CreatingDependenciesLN(sCL, sCL.IED[sCL.IED.Length-1].AccessPoint[0].Server
			                            .LDevice[0].LN[0], nodeSCL.TreeView.Nodes["root"].Nodes["SCL"]
			                            .Nodes["tIED[]"].Nodes[sCL.IED.Length-1].Nodes["tAccessPoint[]"]
			                            .Nodes[0].Nodes["tServer"].Nodes["tLDevice[]"].Nodes[0].Nodes["tLN[]"].Nodes[0]);
		}
		
		private void CreatingDependenciesLN(SCL sCL, tAnyLN anyLN, TreeNode nodeAnyLN)
		{
			bool band = false;
			int i = 0;
			for(; sCL.DataTypeTemplates != null && sCL.DataTypeTemplates.LNodeType !=null && i < sCL.DataTypeTemplates.LNodeType.Length; i++)
			{
				if(sCL.DataTypeTemplates.LNodeType[i].id.Equals(anyLN.lnType))
				{
					band = true;
					break;
				}
			}			
			//Español: Se hace un cargado de los valore que conforman al LNodeType 20/11/2009
			if(band)
			{
				TreeViewLNType treeViewLNType = new TreeViewLNType(nodeAnyLN, sCL);				
				treeViewLNType.ReloadLNType(anyLN);
				treeViewLNType.EmptyTreeNodeLNType(false);				
			}
			//Español: Se hace una creación de los valore que conforman al LNodeType 20/11/2009
			else
			{
				TreeViewLNType treeViewLNType = new TreeViewLNType(nodeAnyLN, sCL);
				treeViewLNType.GetTreeNodeTypesLNs(anyLN);
				treeViewLNType.EmptyTreeNodeLNType(false);
			}		
		}
	}	   			
}
