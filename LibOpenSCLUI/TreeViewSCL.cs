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
using System.Collections;
using IEC61850.SCL;

namespace OpenSCL.UI
{	
	/// <summary>
	/// This class creates a graphical component called "treeNode" using a SCL object.
	/// </summary>
	public class TreeViewSCL
	{				
		TreeNode node;
		ObjectManagement objectManagement;
		private TreeNode treeReferenced; 	
		private Type typeNode;
		private Type dataType;	 		
		
		public TreeViewSCL()
		{
			this.objectManagement = new ObjectManagement();			
		}
		
		/// <summary>
		/// This method creates a graphical component called "tree" 
		/// using a SCL object where every class represent a node.		
		/// </summary>
		/// <param name="nameTreeNode">
		/// Name of the TreeNode that will be created.
		/// </param>
		/// <param name="sCLObject">
		/// SCL object that will be used to creates the TreeNode
		/// </param>
		/// <returns>
		/// A TreeNode of SCL object.
		/// </returns>
		/// <remarks>
		/// This method uses other methods and himself to creates the TreeNode. 
		/// To create the treeNode, an sCLObject is getting and it's associated to a node
		/// using the name of the sCLObject that will be added to the tree.
		/// Este metodo llama a otros metodos y asi mismo para generar el árbol. 			
		/// </remarks>
		public TreeNode GetTreeNodeSCL(string nameTreeNode, object sCLObject)
		{		
			TreeNode treeSCL = new TreeNode();			
			if(string.IsNullOrEmpty(nameTreeNode))
			{
				return treeSCL;
			}
			else
			{				
				node = new TreeNode();				
				treeSCL.Text = nameTreeNode;
				treeSCL.Name = "root";										
				node.Name = sCLObject.GetType().Name.ToString();
	            node.Text = sCLObject.GetType().Name.ToString();
                node.Tag = sCLObject;
        	    treeSCL.Nodes.Add(node);				
        	    AddNodesToTreeSCL(sCLObject, treeSCL);
			}
        	return treeSCL;
		}
		
		/// <summary>
		/// This method creates the nodes that will added to a tree using an SCL object.		
		/// </summary>
		/// <param name="sCLObject">
		/// SCL object that will be used to creates a tree.
		/// </param>
		/// <param name="treeSCL">
		/// Tree created.
		/// </param>		
		public void GetNodes(object sCLObject, TreeNode treeSCL)
		{			
			node = new TreeNode();
            node.Name = sCLObject.GetType().Name.ToString();
            node.Text = GetName(sCLObject, sCLObject.GetType().Name.ToString());
            node.Tag = sCLObject;
            treeSCL.Nodes.Add(node);       
			AddNodesToTreeSCL(sCLObject, treeSCL);       	
		}
		
		/// <summary>
		/// This method creates and adds nodes to a tree according to status of the TreeNode.		
		/// </summary>
		/// <param name="sCLObject">
		/// SCL object that will be used to create a treeNode
		/// </param>
		/// <param name="treeSCL">
		/// Tree created that contains the SCL objects added.
		/// </param>
		private void AddNodesToTreeSCL(object sCLObject,TreeNode treeSCL)
		{
			//object valueAttributeObject;
			//Array valuesAttributeObject;
			PropertyInfo[] attributesInformation = sCLObject.GetType().GetProperties();        	        	        	        										                 							
        	foreach (PropertyInfo attributeInformation in attributesInformation) 
        	{        		
	        	if(!this.ValidateObjectPrimitive(attributeInformation))
    	    	{
        			// If the variable is an Array type then a pooling of every item is made, and it 
        			// will be sent to a method that adds it in some node of the tree.    
        			if(attributeInformation.PropertyType.BaseType.Name.Equals("Array"))
        			{
		       			Array valuesAttributeObject = sCLObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, sCLObject, null ) as  Array;        				
		       			if(valuesAttributeObject!=null && (valuesAttributeObject as Array).GetValue(0) != null)
        				{
        					this.GetNodesItemOfArray(attributeInformation, valuesAttributeObject,  treeSCL.Nodes[sCLObject.GetType().Name.ToString()]);
        				}     				
        			}
        			// If the variable is an Object type then a method will be called to
        			// add it to a node of the tree.        			
	        		else
    	    		{        				
        				object valueAttributeObject = sCLObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, sCLObject, null );				        			        						
        				if(valueAttributeObject!=null)
        				{        					
        					this.GetNodes(valueAttributeObject, treeSCL.Nodes[sCLObject.GetType().Name.ToString()]);
        				}        					
        			}        			
        		}        			
    	    }				
		}
		
		/// <summary>
		/// This method creates a node using the value of the name's variable of the SCL
		/// object (that contains an object's array) and adds it to a treeNode. Also invokes 
		/// a method to create the nodes according to the object's array that contains that 
		/// variable.
		/// </summary>
		/// <param name="attributeInformation">
		/// Name of the variable's properties to create the node.
		/// </param>
		/// <param name="valuesAttributeObject">
		/// Array of objects to create the node and adds to the tree.
		/// </param>
		/// <param name="treeSCL">
		/// TreeNode created using the SCL object.
		/// </param>		
		private void GetNodesItemOfArray(PropertyInfo attributeInformation, Array valuesAttributeObject, TreeNode treeSCL)
		{			
			node = new TreeNode();
			node.Name = attributeInformation.PropertyType.Name;
            node.Text = GetName(valuesAttributeObject, attributeInformation.Name );//attributeInformation.Name;            
            node.Tag = valuesAttributeObject;
			treeSCL.Nodes.Add(node);
			for(int x = 0;  valuesAttributeObject!=null && x <valuesAttributeObject.GetLength(0); x++)
        	{
        		this.GetNodesArray(valuesAttributeObject.GetValue(x),  treeSCL.Nodes[attributeInformation.PropertyType.Name],x);
        	}        				
		}
		
		/// <summary>
		/// This method associate the items of an array with a node and add them to the tree.
		/// </summary>
		/// <param name="itemSCLObject">
		/// Item of the array that will be added to the tree.
		/// </param>
		/// <param name="treeSCL">
		/// Tree created using the items of the array.
		/// </param>
		/// <param name="index">
		/// Item's position that will be added to the tree.
		/// </param>
		private void GetNodesArray(object itemSCLObject, TreeNode treeSCL, int index)
		{		
			node = new TreeNode();
			object valueAttributeObject;
			Array valuesAttributeObject;
			PropertyInfo[] attributesInformation = itemSCLObject.GetType().GetProperties();        	        	        	        													
			node.Name = itemSCLObject.GetType().Name.ToString()+index;
			node.Text = GetName(itemSCLObject, itemSCLObject.GetType().Name.ToString());//itemSCLObject.GetType().Name.ToString();
            node.Tag = itemSCLObject;
            treeSCL.Nodes.Add(node);			
			AttributeReferences references = new AttributeReferences();
			references.Insert(itemSCLObject,node);
        	foreach (PropertyInfo attributeInformation in attributesInformation) 
        	{        		
        		if(!this.ValidateObjectPrimitive(attributeInformation))
        		{
        			//If the variable is an Array type then it has to pool every item that belongs to the Array and it will be 
        			//sent to a method where will be associated to a node of a tree.        		        			        			
        			if(attributeInformation.PropertyType.BaseType.Name.Equals("Array"))
        			{
        				valuesAttributeObject = itemSCLObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, itemSCLObject, null ) as  Array;        				
        				if(valuesAttributeObject!=null && (valuesAttributeObject as Array).GetValue(0) != null)
        				{
        					this.GetNodesItemOfArray(attributeInformation, valuesAttributeObject,  treeSCL.Nodes[itemSCLObject.GetType().Name.ToString()+index]);
        				}  				
        			}
        			//If the variable is an object type, then it will use this method to associate it with a node of the tree.
        			else
        			{        				
        				valueAttributeObject = itemSCLObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, itemSCLObject, null );				        			        						
        				if(valueAttributeObject!=null)
        				{        					
        					this.GetNodes(valueAttributeObject, treeSCL.Nodes[itemSCLObject.GetType().Name.ToString()+index]);
        				}
        			}        			
        		}
        	}	        	
		}
	
		/// <summary>
		/// This method validates if the variable is a primitive type.		
		/// </summary>
		/// <param name="attributeInformation">
		/// Information of the variable.
		/// </param>
		/// <returns>
		/// If the variable is of primitive type,this method returns a True, 
		/// otherwise, it returns a False.
		/// </returns>
		/// <remarks>
		/// The variable's type is compared to a list of data type that are 
		/// considered a primitive type for this project.		
		/// </remarks>
		public bool ValidateObjectPrimitive(PropertyInfo attributeInformation)
		{
			bool result = false;
			switch(attributeInformation.PropertyType.Name.ToString())
        	{
				case "UInt32":
				case "String":
				case "Boolean":
				case "Int32":
				case "Int64":
				case "XmlNode[]":
				case "tText":
				case "Decimal":
				case "XmlElement[]":
				case "XmlAttribute[]":
				case "XmlNode":
				case "tDurationInMilliSec":
				case "tServiceYesNo":
					result = true;
        		 	break;      
        		default:
        		 	switch(attributeInformation.PropertyType.BaseType.Name.ToString())
        		 	{        			 	
        		 		case "Enum":
        		 			result = true;	
        		    		break;
        		 	}
        		 	break;
			}
			return result;	
		}
		
		/// <summary>
		/// This method removes the node from the tree and all his objects according to the conditions provided.		
		/// </summary>
		/// <param name="nodePossibleRemove">
		/// Node that will be eliminated from the tree and his object definition because it has all the conditions provided.  
		/// </param>
		public void Remove(TreeNode nodePossibleRemove)
		{			
			object objectParent, objectToRemove;
			if(nodePossibleRemove.Parent!=null&&nodePossibleRemove.Parent.Tag.GetType().IsArray)
			{
				objectParent = nodePossibleRemove.Parent.Parent.Tag;
				objectToRemove = nodePossibleRemove.Tag;
				int indexOfObject = nodePossibleRemove.Parent.Nodes.IndexOf(nodePossibleRemove);
				if(objectParent!=null && this.objectManagement.RemoveObjectOfArrayObjectOfParentObject(objectToRemove, indexOfObject, objectParent))					
				{						
					nodePossibleRemove = nodePossibleRemove.Parent;
					nodePossibleRemove.Nodes.RemoveAt(indexOfObject);											
					if(nodePossibleRemove.Nodes.Count==0)
					{
						TreeNode TNRemove = nodePossibleRemove;
						nodePossibleRemove = nodePossibleRemove.Parent;
						nodePossibleRemove.Nodes.Remove(TNRemove);
					}
				}
				else
				{
					MessageBox.Show("Not saved !!!");
				}	
			}
			else
			{
				objectParent = nodePossibleRemove.Parent.Tag;
				objectToRemove = nodePossibleRemove.Tag;
				if(this.objectManagement.DeleteSCLObject(objectToRemove, objectParent))
				{
					nodePossibleRemove.Tag = null;
					nodePossibleRemove.Parent.Nodes.Remove(nodePossibleRemove);											
				}
				else
				{
					MessageBox.Show("Not saved !!!");
				}
			}
		}	
		
		/// <summary>
		/// This method adds a node to the tree and it creates all the objects required.	
		/// </summary>
		/// <param name="nodePossibleInsert">
		/// Node that will be added to the tree.  
		/// </param>
		/// <param name="namePropertyPossibleInsert">
		/// Properties name related to the inserted node. 
		/// </param>
		/// <param name="typePropertyPossibleInsert">
		/// Type of the property of the node that will be added to the tree.
		/// </param>
		public void Insert(TreeNode nodePossibleInsert, string namePropertyPossibleInsert, string typePropertyPossibleInsert)
		{			
			object objectParent, objectToInsert;
			TreeNode node = new TreeNode();
			if(nodePossibleInsert.Tag.GetType().IsArray)
			{				
				objectParent = nodePossibleInsert.Parent.Tag;
				objectToInsert = this.objectManagement.CreateObject(typePropertyPossibleInsert);
				string attributeName = nodePossibleInsert.Text;		
								
				if(!objectManagement.AddItemToArray(objectToInsert, attributeName, objectParent))
   				{
					MessageBox.Show(objectToInsert.GetType().Name+" is not saved");
   				}
				else
				{	
					node.Name = typePropertyPossibleInsert+nodePossibleInsert.Nodes.Count.ToString();
					node.Text = GetName(objectToInsert, namePropertyPossibleInsert);
					node.Tag = objectToInsert;			
					nodePossibleInsert.Nodes.Add(node);
				}
			}
			else
			{
				objectParent = nodePossibleInsert.Tag;
				objectToInsert = this.objectManagement.FindVariable(objectParent, namePropertyPossibleInsert);				
				MemberInfo[] objectToInsertInfo = objectParent.GetType().FindMembers(
   							MemberTypes.Property, 
   							BindingFlags.Public | 
   							BindingFlags.Instance,
   							Type.FilterName, namePropertyPossibleInsert);					
				if(objectToInsertInfo!=null&&objectToInsertInfo.Length>0&&(objectToInsertInfo[0] as PropertyInfo).PropertyType.IsArray)				
				{
					string nameObjectToInsert = (objectToInsertInfo[0] as PropertyInfo).PropertyType.Name;						
					nameObjectToInsert = nameObjectToInsert.Substring(0,typePropertyPossibleInsert.IndexOf('['));
					objectToInsert = this.objectManagement.CreateObject(nameObjectToInsert);
					if(!objectManagement.AddItemToArray(objectToInsert, namePropertyPossibleInsert, objectParent))
					{
						MessageBox.Show(objectParent.GetType().Name+" is not saved");   						
   					}
					else
					{						
						Array array  = objectParent.GetType().InvokeMember(namePropertyPossibleInsert, BindingFlags.Instance | BindingFlags.Public |
              			BindingFlags.GetProperty | BindingFlags.GetField, null, objectParent, null) as Array;						
						node.Name = typePropertyPossibleInsert;
						node.Text =  GetName(array, namePropertyPossibleInsert);
						node.Tag = array;			
						nodePossibleInsert.Nodes.Add(node);
						TreeNode sonNode = new TreeNode();
						sonNode.Name = objectToInsert.GetType().Name+"0";
						sonNode.Text = GetName(objectToInsert, objectToInsert.GetType().Name);
						sonNode.Tag = objectToInsert;								
						nodePossibleInsert.Nodes[typePropertyPossibleInsert].Nodes.Add(sonNode);						
					}
				}
				else
				{
					//Object that will be added and it is not an array type.
					objectToInsert = this.objectManagement.CreateObject(typePropertyPossibleInsert);
					if(!objectManagement.AddObjectToSCLObject(objectToInsert, namePropertyPossibleInsert, objectParent))
					{
						MessageBox.Show(objectParent.GetType().Name+" is not saved");   						
					} 
					else
					{
						node.Name = typePropertyPossibleInsert;
						node.Text =  GetName(objectToInsert, namePropertyPossibleInsert);
						node.Tag = objectToInsert;			
						nodePossibleInsert.TreeView.SelectedNode.Nodes.Add(node);						
					}
				}
			}
		}
		
		/// <summary>
		/// This method searchs and returns the TreeNode that contains on his tag the base type of an object 
		/// specified on the typeSCLToSearch variable. 
		/// </summary>
		/// <param name="nodeSCL">
		/// TreeNode where the search will start.
		/// </param>
		/// <param name="typeSCLToSearch">
		/// Base Type that will be look for on the TreeNode Tags.
		/// </param>
		/// <returns>
		/// A TreeNode that contents on his tag the base type of an object specified on the typeSCLToSearch variable. 
		/// </returns>        
        public TreeNode SearchUPForBaseTypeAndGetSCLTreeNode(TreeNode nodeSCL, Type typeSCLToSearch)
        {
            TreeNode tAux = nodeSCL;

            while (tAux != null) 
            {
                if (tAux.Tag != null && tAux.Tag.GetType().BaseType != null && (tAux.Tag.GetType().BaseType == (typeSCLToSearch) || (tAux.Tag.GetType().BaseType.BaseType == (typeSCLToSearch))))
                    return tAux;
                else
                    tAux = tAux.Parent;
            
            }
            
            return null;                            
        }
		
		/// <summary>
		/// This method search a tag of an specific type.
		/// </summary>
		/// <param name="nodeSCL">
		/// TreeNode where the search will be made.
		/// </param>
		/// <param name="typeSCLToSearch">
		/// Type that will be look at on the TreeNode Tag.
		/// </param>
		/// <returns>
		/// If the type is found then it returns a true value otherwise a false value is returned.
		/// </returns>        
        public bool SearchUPForType(TreeNode nodeSCL, Type typeSCLToSearch)
        {
            TreeNode tAux = nodeSCL;

            while(tAux != null)
            {
                if (tAux.Tag != null && tAux.Tag.GetType() == typeSCLToSearch)            
                    return true;
                else
                    tAux = tAux.Parent;
            
            }
            return false;                            
        }
		
		/// <summary>
		/// This method creates an SCL project using the creation of a new tree with the main nodes
		/// </summary>
		/// <returns>
		/// A new treenode to display in the main window
		/// </returns>
		public TreeNode NewTreeNode()
        {
			TreeNode newTreeNodeSCL = new TreeNode();	
			TreeNode Node = new TreeNode();				
            newTreeNodeSCL.Text = "New";
            newTreeNodeSCL.Name = "root";            
            Node.Text ="SCL";
            Node.Name = "SCL";
            OpenSCL.Object sc = new OpenSCL.Object();            
            sc.Configuration = new SCL();
            Node.Tag =sc.Configuration;
            TreeNode subNodeinNodeRoot = new TreeNode();
            subNodeinNodeRoot.Text = "Header";
            subNodeinNodeRoot.Name = "tHeader";
			sc.Configuration.Header = new tHeader();
			subNodeinNodeRoot.Tag = sc.Configuration.Header;
            Node.Nodes.Add(subNodeinNodeRoot);
            newTreeNodeSCL.Nodes.Add(Node);
            return newTreeNodeSCL;
        }
		
		/// <summary>
		/// Seeks a node with two variables into its tag
		/// </summary>
		/// <param name="tree2">
		/// The Collection of nodes to star to seek
		/// </param>
		/// <param name="apName">
		/// First Variable to compare
		/// </param>
		/// <param name="iedName">
		/// Second variable to compare
		/// </param>		
		/// <returns>
		/// if match booth variables treenode founded is returned otherwise returns a null treenode
		/// </returns>
		public TreeNode SeekAssociation(TreeNodeCollection tree2, string apName, string iedName)
		{
			foreach(TreeNode treeAux in tree2)
			{
			    if (treeAux.Tag != null && treeAux.Tag is tConnectedAP) {
					tConnectedAP ap = (tConnectedAP) treeAux.Tag;
					if (ap.apName.Equals(apName) && ap.iedName.Equals(iedName))
						treeReferenced = treeAux;
				}
				SeekAssociation(treeAux.Nodes, apName, iedName);
			}			
			return treeReferenced;	
		}			
		
		/// <summary>
		/// This method creates a node referenced to the last element that was inserted to the array
		/// and adds an specified node to it.
		/// </summary>
		/// <param name="valuesArray">
		/// Array used to creates his nodes.
		/// </param>
		/// <param name="parentType">
		/// SCL object that contains the array.
		/// </param>
		/// <param name="treeSCL">
		/// Tree where the nodes will be insert.
		/// </param>	
		public void GetNodesItemOfArray(Array valuesArray, Type parentType, TreeNode treeSCL)
		{
			PropertyInfo attributeInformation = this.objectManagement.GetProperty((valuesArray as Array).GetValue(0).GetType(), parentType);
			bool band1 = true, band2 = true;
			if(treeSCL.Nodes!=null)
			{
				band1 = treeSCL.Nodes[attributeInformation.PropertyType.Name] == null;
			}
			if(treeSCL.Parent.Nodes!=null)
			{
				band2 = treeSCL.Parent.Nodes[attributeInformation.PropertyType.Name] == null;
			}
			if(treeSCL.Nodes!=null && band1 && band2)
			{
				this.GetNodesItemOfArray(attributeInformation , valuesArray, treeSCL);
			}
			else
			{
				if(!band1)
				{
					this.GetNodesArray(valuesArray.GetValue((valuesArray as Array).Length-1),  treeSCL.Nodes[attributeInformation.PropertyType.Name],(valuesArray as Array).Length-1);
				}
				else if(!band2)
				{
					this.GetNodesArray(valuesArray.GetValue((valuesArray as Array).Length-1),  treeSCL.Parent.Nodes[attributeInformation.PropertyType.Name],(valuesArray as Array).Length-1);
				}
			}
		}		

		/// <summary>
		/// This method gets the value of the node to set a name to it.
		/// </summary>
		/// <param name="sCLObject">
		/// SCL object where will be look the attribute.
		/// </param>
		/// <param name="textPossible">
		/// Possible name to set to an specific node
		/// </param>
		/// <returns>
		/// A string that contains the name that will be set to the node
		/// </returns>
		public string GetName(object sCLObject, string textPossible)
		{
			if((sCLObject is tNaming))
			{

                object foundVariable = this.objectManagement.FindVariable(sCLObject, "name");

				if(foundVariable!=null && foundVariable.ToString()!="null")
				{
					textPossible = foundVariable.ToString();
				}

                foundVariable = this.objectManagement.FindVariable(sCLObject, "cbName");

				if(foundVariable!=null && foundVariable.ToString()!="null")
				{
					textPossible = foundVariable.ToString();
				}
			}

            object foundInst = this.objectManagement.FindVariable(sCLObject, "inst");
            object foundLnClass = this.objectManagement.FindVariable(sCLObject, "lnClass");

			if(sCLObject is tLN && foundLnClass!= null && foundInst.ToString()!= "null")
			{
                textPossible = this.objectManagement.FindVariable(sCLObject, "prefix").ToString() + foundLnClass.ToString() + foundInst.ToString();
			}
			if(sCLObject is tLDevice && foundInst!= null  && foundInst.ToString()!="null")
            {
				textPossible = ((tLDevice)sCLObject).inst;
				if (textPossible == null)
					textPossible = "NoInstanceLogicalDevice";
			}
			if(sCLObject is tIDNaming)
			{	
				textPossible = this.objectManagement.FindVariable(sCLObject, "id").ToString();
			}
			return textPossible;
		}
        
		/// <summary>
		/// This method searchs a type of an SCL object on the tree.		
		/// </summary>
		/// <param name="nodeSCL">
		/// Node of the tree where the search will start.
		/// </param>
		/// <param name="typeSCLToSearch">
		/// Type of the SCL object.
		/// </param>
		/// <returns>
		/// If the object is found then a node is returned, otherwise a null value will be returned.
		/// </returns>        
        public TreeNode SearchUPForTypeAndGetSCLTreeNode(TreeNode nodeSCL, Type typeSCLToSearch)
        {
            TreeNode tAux = nodeSCL;

            while (tAux != null)
            {

                if (tAux.Tag != null && (tAux.Tag.GetType() == typeSCLToSearch))
                    return tAux;
                else
                    tAux = tAux.Parent;
            }

            return null;
        }		
		
		//New
		/// <summary>
		/// Seeks a node with two variables into its tag
		/// </summary>
		/// <param name="tree2">
		/// The Collection of nodes to star to seek
		/// </param>
		/// <param name="apName">
		/// First Variable to compare
		/// </param>
		/// <param name="iedName">
		/// Second variable to compare
		/// </param>
		/// <param name="var1">
		/// name of the property to check
		/// </param>
		/// <param name="var2">
		/// name of second property to check
		/// </param>
		/// <returns>
		/// if match booth variables treenode founded is returned otherwise returns a null treenode
		/// </returns>
		public TreeNode SeekAssociation(TreeNodeCollection tree2, string apName, string iedName, string var1, string var2)
		{		
			foreach(TreeNode t2 in tree2)
			{
				if(t2.Tag != null)
				{					
					 dataType = t2.Tag.GetType();	
				}				
				if(t2.Tag != null &&  dataType.Name== "tConnectedAP")
				{	
					if((this.objectManagement.FindVariable(t2.Tag, var1).ToString() == apName) && 
					   (this.objectManagement.FindVariable(t2.Tag, var2).ToString() == iedName))
					{
						this.treeReferenced = t2;
						return this.treeReferenced;							
					}					
				}				
				SeekAssociation(t2.Nodes, apName, iedName, "apName", "iedName");
			}			
			return this.treeReferenced;	
		}		

		/// <summary>
		/// Método para buscar un nodo con una sola variable
		/// </summary>
		/// <param name="tree2">
		/// Nodes a buscar
		/// </param>
		/// <param name="value_">
		/// valor que compararemos
		/// </param>
		/// <param name="varName_">
		/// nombre de la variable a buscar
		/// </param>
		/// <param name="condition">
		/// el nombre del nodo que tendra que ser para comparar
		/// </param>
		/// <returns>
		/// 
		/// </returns>
		public TreeNode SeekAssociation(TreeNodeCollection tree2, string value_, string varName_, string condition)
		{		
			foreach(TreeNode t2 in tree2)
			{
				if(t2.Tag != null)
				{					
					 dataType = t2.Tag.GetType();	
				}				
				if(t2.Tag != null &&  dataType.Name == condition)
				{
					if(this.objectManagement.FindVariable(t2.Tag, varName_).ToString() == value_)
					{
						this.treeReferenced = t2;					
					}										
				}				
				SeekAssociation(t2.Nodes, value_, varName_, condition);
			}			
			return this.treeReferenced;	
		}			
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sCL">
		/// 
		/// </param>
		/// <param name="treeSCL">
		/// 
		/// </param>
		public void CreateCommNode(SCL sCL, TreeNode treeSCL)
		{				
			if(sCL.Communication == null)
			{				
				tCommunication communication = new tCommunication();
				this.objectManagement.AddObjectToSCLObject(communication , sCL);
				TreeNode nodeComm = new TreeNode();				
				nodeComm.Name = "tCommunication";
				nodeComm.Tag = sCL.Communication;
				nodeComm.Text = "tCommunication";				
				treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes.Add(nodeComm);
				
			}
			if(treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"]==null)	
			{					
					TreeNode nodeSubNetwork = new TreeNode();
					nodeSubNetwork.Name = "tSubNetwork[]";
					nodeSubNetwork.Tag = sCL.Communication.SubNetwork;
					nodeSubNetwork.Text = "SubNetwork";
					treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes.Add(nodeSubNetwork);

			tSubNetwork subnetwork = new tSubNetwork();					
			this.objectManagement.AddObjectToArrayObjectOfParentObject(subnetwork, sCL.Communication);
			this.objectManagement.AddObjectToSCLObject(sCL.Communication.SubNetwork, sCL);					
			TreeNode nodetSubNetwork = new TreeNode();			
			nodetSubNetwork.Name = subnetwork.name; 
			nodetSubNetwork.Text = "tSubNetwork";
			treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes.Add(nodetSubNetwork);
					
			}							
		}				
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sCL">
		/// 
		/// </param>
		/// <param name="treeSCL">
		/// 
		/// </param>
		/// <param name="apName">
		/// 
		/// </param>
		/// <param name="iedName">
		/// 
		/// </param>
		/// <param name="posSubnet">
		/// 
		/// </param>
		public void CreateConnectedNode(SCL sCL, TreeNode treeSCL, string apName, string iedName, int posSubnet)
		{
			tConnectedAP tConnected = new tConnectedAP();
			tConnected.apName = apName;
			tConnected.iedName = iedName;	
			this.objectManagement.AddObjectToArrayObjectOfParentObject(tConnected,sCL.Communication.SubNetwork[posSubnet]);
			TreeNode nodeComm = new TreeNode();			
			nodeComm.Name = "tConnectedAP[]";
			nodeComm.Tag = sCL.Communication.SubNetwork[posSubnet].ConnectedAP;
			nodeComm.Text = "ConnectedAP";
			treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[posSubnet].Nodes.Add(nodeComm);													
			TreeNode nodetConnected = new TreeNode();			
			nodetConnected.Name = "tConnectedAP"+iedName+apName;
			nodetConnected.Tag = tConnected;
			nodetConnected.Text = "tConnectedAP";
			treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[posSubnet].Nodes["tConnectedAP[]"].Nodes.Add(nodetConnected);			
			AttributeReferences refe = new AttributeReferences();
			refe.Insert(tConnected, treeSCL.TreeView.SelectedNode);
		}				
		
		/// <summary>
		/// Removes The Goose or SMV Node from LN0 and Communication, needs the name of the selectedGOOSE or selectedSMV
		/// </summary>
		/// <param name="treeSCL">
		/// the node as reference
		/// </param>
		/// <param name="gseName">
		/// the name of GSE to be deleted
		/// </param>
		public void RemoveGSEandSMV(TreeNode treeSCL, string nameOfObject, string condition)
		{
			TreeViewSCL tr =  new TreeViewSCL();
			TreeNode nodeToRemove;		
			SCL sCL = (SCL) treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Tag;
			for(int i=0; i<sCL.Communication.SubNetwork.Length; i++)
			{
				nodeToRemove = tr.SeekAssociation(treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[i].Nodes, nameOfObject ,"cbName", condition);				
				if(nodeToRemove!=null && nodeToRemove.Parent!= null)
				{ 
					if(nameOfObject == objectManagement.FindVariable(nodeToRemove.Tag, "cbName").ToString())
					{
						tr.Remove(nodeToRemove);
					}	
				}				
			}
			tr.Remove(treeSCL.TreeView.SelectedNode);
		}				
		/// <summary>
		/// Gets the selected dataset from object
		/// </summary>
		/// <param name="treeSCL">current node</param>
		/// <param name="objDat">object that contains dataset</param>
		/// <returns>the index wich should be selected into combobox</returns>
		public int getDataSetSelected(TreeNode treeSCL, object objDat)
		{
			ArrayList aL = new ArrayList();
			//tGSEControl gseC = (tGSEControl) objDat;
			aL = getDataset(treeSCL);
			for(int i=0; i<aL.Count ; i++)
			{
				if(this.objectManagement.FindVariable(objDat, "datSet").ToString() == aL[i].ToString())
				{
					return i;
				}
			}
			return 0;
		}
		
		/// <summary>
		/// Gets the name of dataset from current lDevice
		/// </summary>
		/// <param name="treeSCL">Current Node</param>
		/// <returns>an array of the dataset, 0 if ther is not any dataset</returns>
		public ArrayList getDataset(TreeNode treeSCL)
		{
			TreeNode nodeLDevice = SearchUPForTypeAndGetSCLTreeNode(treeSCL.TreeView.SelectedNode, typeof(tLDevice));
			tLDevice ld = (tLDevice) nodeLDevice.Tag;
			ArrayList a = new ArrayList();
			for(int k=0; ld.LN0.DataSet!=null && k<ld.LN0.DataSet.Length; k++)
			{
				a.Add(ld.LN0.DataSet[k].name);
			}
			if(ld.LN!=null)
			{
				for(int i = 0; i<ld.LN.Length; i++)
				{
					if(ld.LN[i].DataSet!=null)
					{
						for(int j=0; j<ld.LN[i].DataSet.Length;j++)
						{
							a.Add(ld.LN[i].DataSet[j].name);
						}
					}
				}
			}
			return a;
		}

        
	}
}


        
		
