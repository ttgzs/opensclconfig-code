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
		ObjectManagement objectManagement;
		private TreeNode treeReferenced;
		private Type dataType;
		private TreeNode root;
		private TreeNode node;
		private TreeNode commNode;
		private TreeNode dttemplNode;
		private TreeNode iedNode;
		private TreeNode subNode;
		
		public TreeViewSCL()
		{
			this.objectManagement = new ObjectManagement();			
		}
		
		public OpenSCL.Object scl { get; set; }
		public TreeView tree { get; set; }
		
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
		public TreeNode GetTreeNodeSCL (string nameTreeNode, SCL scl)
		{		
			if (this.scl == null) {
				var oscl = new OpenSCL.Object ();
				oscl.Configuration = scl;
				this.scl = oscl;
			}
			TreeNode treeSCL = new TreeNode ();			
			if(!string.IsNullOrEmpty (nameTreeNode))
			{				
				root = new TreeNode ();
				treeSCL.Text = nameTreeNode;
				treeSCL.Name = "root";
				root.Name = this.scl.Configuration.GetType ().Name.ToString ();
	            root.Text = this.scl.Configuration.GetType ().Name.ToString ();
                root.Tag = this.scl.Configuration; // FIXME: Not useful
        	    treeSCL.Nodes.Add(root);
				// Add system nodes
			}
        	return treeSCL;
		}

		public void AddCommunicationNode ()
		{
			if (this.scl.Configuration.Communication != null)
				commNode = AddSclNode (this.scl.Configuration.Communication, node, -1);
		}

		public void AddNetworkNode ()
		{
			if (this.scl.Configuration.Communication.SubNetwork != null)
					AddSclArrayNodes (this.scl.Configuration.Communication.SubNetwork, commNode, -1);
		}

		public void AddDataTypeTemplatesNode ()
		{
			if (this.scl.Configuration.DataTypeTemplates != null)
				dttemplNode = AddSclNode (this.scl.Configuration.DataTypeTemplates, node, -1);
		}

		public void AddTopSclNodes (TreeNode node)
		{
			AddCommunicationNode ();
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
		       			Array valuesAttributeObject = sCLObject.GetType()
														.InvokeMember(attributeInformation.Name, 
							              								BindingFlags.GetField 
							              								| BindingFlags.GetProperty, 
							              								null, sCLObject, 
							              								null ) as  Array;        				
		       			if(valuesAttributeObject != null 
						   && (valuesAttributeObject as Array).GetValue(0) != null)
        				{
        					this.GetNodesItemOfArray (attributeInformation, valuesAttributeObject,  
							                         treeSCL.Nodes[sCLObject.GetType().Name.ToString()]);
        				}     				
        			}
        			// If the variable is an Object type then a method will be called to
        			// add it to a node of the tree.        			
	        		else
    	    		{
						object valueAttributeObject;
						if (attributeInformation.Name.Equals ("Chars"))
							valueAttributeObject = sCLObject;
						else 
							valueAttributeObject = sCLObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, sCLObject, null );				        			        						
        				
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
		private void GetNodesItemOfArray(PropertyInfo attributeInformation, 
		                                 Array valuesAttributeObject, TreeNode treeSCL)
		{
			AddSclArrayNodes ((object []) valuesAttributeObject, treeSCL, -1);
//			node = new TreeNode();
//			node.Name = attributeInformation.PropertyType.Name;
//            node.Text = GetName(valuesAttributeObject, attributeInformation.Name );//attributeInformation.Name;            
//            node.Tag = valuesAttributeObject;
//			treeSCL.Nodes.Add(node);
//			for(int x = 0;  valuesAttributeObject!=null && x <valuesAttributeObject.GetLength(0); x++)
//        	{
//        		this.GetNodesArray(valuesAttributeObject.GetValue(x),  treeSCL.Nodes[attributeInformation.PropertyType.Name],x);
//        	}
		}

		/// <summary>
		/// Adds the node.
		/// </summary>
		/// <returns>
		/// The node.
		/// </returns>
		/// <param name='obj'>
		/// Object.
		/// </param>
		/// <param name='node'>
		/// Node.
		/// </param>
		/// <param name='index'>
		/// Index. Set to -1 if you whant to avoid to add an index to the node's name.
		/// </param>
		public TreeNode AddSclNode (object obj, TreeNode node, int index)
		{
			string sufix = "";
			if (index >= 0)
				sufix = index.ToString ();
			TreeNode n = new TreeNode ();
			if (!(obj is Array))
				n.Tag = obj;
			n.Name = obj.GetType ().Name + sufix;
			n.Text = OpenSCL.Utility.GetSCLName (obj) + sufix;
			node.Nodes.Add (node);
			return n;
		}

		/// <summary>
		/// Adds a node for an array and nodes for each elements in the array.
		/// </summary>
		/// <param name='objs'>
		/// Objects.
		/// </param>
		/// <param name='node'>
		/// Node.
		/// </param>
		public TreeNode AddSclArrayNodes (Array objs, TreeNode node, int index)
		{
			TreeNode n = AddSclNode (objs, node, index);
			for (int i = 0; i < objs.Length; i++) {
				AddSclNode (objs.GetValue (i), node, i);
			}
			return n;
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
		private void GetNodesArray (object itemSCLObject, TreeNode treeSCL, int index)
		{
			if (itemSCLObject is Array)
				AddSclArrayNodes ((object[]) itemSCLObject,treeSCL, index);
			else
				AddSclNode (itemSCLObject, treeSCL, index);

//			node = new TreeNode ();
//			if (itemSCLObject is string) {
//				this.GetNodes(itemSCLObject, treeSCL.Nodes[(string)itemSCLObject]);
//			}
//			object valueAttributeObject;
//			Array valuesAttributeObject;
//			PropertyInfo[] attributesInformation = itemSCLObject.GetType ().GetProperties ();        	        	        	        													
//			node.Name = itemSCLObject.GetType ().Name.ToString () + index;
//			node.Text = GetName (itemSCLObject, itemSCLObject.GetType ().Name.ToString ());//itemSCLObject.GetType().Name.ToString();
//			node.Tag = itemSCLObject;
//			treeSCL.Nodes.Add (node);
//			AttributeReferences references = new AttributeReferences ();
//			references.Insert (itemSCLObject, node);
//
//        	foreach (PropertyInfo attributeInformation in attributesInformation) 
//        	{        		
//        		if(!this.ValidateObjectPrimitive(attributeInformation))
//        		{
//        			//If the variable is an Array type then it has to pool every item that belongs to the Array and it will be 
//        			//sent to a method where will be associated to a node of a tree.        		        			        			
//        			if(attributeInformation.PropertyType.BaseType.Name.Equals("Array"))
//        			{
//        				valuesAttributeObject = itemSCLObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, itemSCLObject, null ) as  Array;        				
//        				if(valuesAttributeObject!=null && (valuesAttributeObject as Array).GetValue(0) != null)
//        				{
//        					this.GetNodesItemOfArray(attributeInformation, valuesAttributeObject,  treeSCL.Nodes[itemSCLObject.GetType().Name.ToString()+index]);
//        				}  				
//        			}
//        			//If the variable is an object type, then it will use this method to associate it with a node of the tree.
//        			else
//        			{  
//						try {
//        					valueAttributeObject = itemSCLObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, itemSCLObject, null );
//						}
//						catch {
//							valueAttributeObject = itemSCLObject;
//							System.Console.Out.WriteLine ("Error to Add a node for object: " +
//						                              itemSCLObject.GetType ().ToString ()
//							                              + " with Attribute: " + attributeInformation.Name);
//						}
//        				if(valueAttributeObject!=null)
//        				{        					
//        					this.GetNodes(valueAttributeObject, treeSCL.Nodes[itemSCLObject.GetType().Name.ToString()+index]);
//        				}
//        			}        			
//        		}
//        	}	        	
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
		public bool Insert (TreeNode nodePossibleInsert, string namePropertyPossibleInsert, 
		                   string typePropertyPossibleInsert)
		{			
			bool ret = true;
			object objectParent, objectToInsert;
			TreeNode node = new TreeNode ();
			if(nodePossibleInsert.Tag.GetType ().IsArray)
			{				
				objectParent = nodePossibleInsert.Parent.Tag;
				objectToInsert = this.objectManagement.CreateObject (typePropertyPossibleInsert);
				string attributeName = nodePossibleInsert.Text;		
								
				if(!objectManagement.AddItemToArray (objectToInsert, attributeName, objectParent))
   				{
					MessageBox.Show (objectToInsert.GetType ().Name + " is not saved");
					ret = false;
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
				objectToInsert = this.objectManagement.FindVariable (objectParent, namePropertyPossibleInsert);				
				MemberInfo[] objectToInsertInfo = objectParent.GetType ().FindMembers (
   							MemberTypes.Property, 
   							BindingFlags.Public | 
   							BindingFlags.Instance,
   							Type.FilterName, namePropertyPossibleInsert);					
				if(objectToInsertInfo != null
				   && objectToInsertInfo.Length >0 
				   && (objectToInsertInfo[0] as PropertyInfo).PropertyType.IsArray)				
				{
					string nameObjectToInsert = (objectToInsertInfo[0] as PropertyInfo).PropertyType.Name;						
					nameObjectToInsert = nameObjectToInsert.Substring(0,typePropertyPossibleInsert.IndexOf('['));
					objectToInsert = this.objectManagement.CreateObject(nameObjectToInsert);
					if(!objectManagement.AddItemToArray(objectToInsert, namePropertyPossibleInsert, objectParent))
					{
						MessageBox.Show(objectParent.GetType().Name+" is not saved");
						ret = false;
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
					objectToInsert = this.objectManagement.CreateObject (typePropertyPossibleInsert);
					if(!objectManagement.AddObjectToSCLObject (objectToInsert, namePropertyPossibleInsert, objectParent))
					{
						MessageBox.Show(objectParent.GetType ().Name+" is not saved");
						ret = false;
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
			return ret;
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
			return OpenSCL.Utility.GetSCLName (sCLObject);
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
			if(treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNet[]"]==null)	
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
		
		
		// New API
		
		public bool AddGSEControlNode (string iedname, string apname, 
		                               string ldinst, tGSEControl gsec)
		{
			if (scl == null || tree == null)
				return false;
			
			var ln0n = GetLN0Node (iedname, apname, ldinst);
			if (ln0n == null) {
				return false;
			}
			else {
				bool found = false;
				TreeNode agsec = new TreeNode ();
				agsec.Name = "tGSEControl[]";
				agsec.Text = "GSE Control Blocks";
				System.Console.WriteLine ("Searching GSE[]...");
				foreach (TreeNode n in ln0n.Nodes) {
					if (n.Name.Equals ("tGSEControl[]")) {
						found = true;
						agsec = n;
						break;
					}
				}
				if (!found) {
					ln0n.Nodes.Add (agsec);
				}
				TreeNode nn = new TreeNode ();
				nn.Name = "tGSEControl";
				nn.Text = gsec.name;
				nn.Tag = gsec;
				agsec.Nodes.Add (nn);
				return true;
			}
		}
		
        public bool AddGSENode (string iedname, string apname, string ldname,
		                        tGSE gse)
		{
			if (scl == null || tree == null)
				return false;
			
			var ncap = GetConnectedAPNode (iedname, apname);
			if (ncap == null)
				return false;
			
			TreeNode gsea = new TreeNode ();
			gsea.Name = "tGSE[]";
			gsea.Text = "Generic Station Events";
			gsea.ToolTipText = "GOOSE Messages Published by this IED";
			bool found = false;
			foreach (TreeNode n in ncap.Nodes) {
				System.Console.WriteLine ("Node in ncap = " + n.Name);
				if (n.Name.Equals ("tGSE[]")) {
					found = true;
					gsea = n;
				}
				if (!found) {
					ncap.Nodes.Add (gsea);
				}
			}
			TreeNode ngse = new TreeNode ();
			ngse.Name = "tGSEControl";
			ngse.Text = gse.cbName;
			ngse.Tag = gse;
			gsea.Nodes.Add (ngse);
			return true;
		}
		
		public TreeNode GetLN0Node (string iedname, string apname, string ldname)
		{
			var ldn = GetLDeviceNode (iedname, apname, ldname);
			if (ldn == null)
				return null;
			foreach (TreeNode n in ldn.Nodes) {
				if (n.Name.Equals ("LN0")) {
					return n;
				}
			}
			return null;
		}
		
		public TreeNode GetIEDNode ()
		{
			if (scl == null || tree == null)
				return null;
			var s = GetSCLNode ();
			if (s == null)
				return null;
			foreach (TreeNode n in s.Nodes) {
				if (n.Name.Equals ("tIED[]")) {
					return n;
				}
			}
			return null;
		}
		
		public TreeNode GetAccessPointNode (string iedname, string apname)
		{
			if (scl == null || tree == null)
				return null;
			var iedn = GetIEDNode (iedname);
			if (iedn == null)
				return null;
			foreach (TreeNode apsn in iedn.Nodes) {
				if (apsn.Name.Equals ("tAccessPoint[]")) {
					foreach (TreeNode apn in apsn.Nodes) {
						tAccessPoint ap = (tAccessPoint) apn.Tag;
						if (ap.name.Equals (apname)) {
							return apn;
						}
					}
				}
			}
			return null;
		}
		
		public TreeNode GetServerNode (string iedname, string apname)
		{
			if (scl == null || tree == null)
				return null;
			var apn = GetAccessPointNode (iedname, apname);
			if (apn == null)
				return null;
			foreach (TreeNode n in apn.Nodes) {
				if (n.Name.Equals ("tServer")) {
					return n;
				}
			}
			return null;
		}
		
		public TreeNode GetLDeviceNode (string iedname, string apname, string ldinst)
		{
			if (scl == null || tree == null)
				return null;
			var sn = GetServerNode (iedname, apname);
			if (sn == null)
				return null;
			foreach (TreeNode n in sn.Nodes) {
				if (n.Name.Equals ("tLDevice[]")) {
					foreach (TreeNode ldn in n.Nodes) {
						if (ldn.Name.Contains ("tLDevice")) {
							tLDevice ld = (tLDevice) ldn.Tag;
							if (ld.inst.Equals (ldinst)) {
								return ldn;
							}
						}
					}
				}
			}
			return null;
		}
		
		public TreeNode GetIEDNode (string iedname)
		{
			if (scl == null || tree == null)
				return null;
			var ieds = GetIEDNode ();
			if (ieds == null)
				return null;
			foreach (TreeNode n in ieds.Nodes) {
				tIED ied = (tIED) n.Tag;
				if (ied.name.Equals (iedname)) {
					return n;
				}
			}
			return null;
		}
		
		public TreeNode GetGSEControlNode (string iedname, string apname, string ldinst, string cgse)
		{
			if (scl == null || tree == null)
				return null;
			var ldn = GetLDeviceNode (iedname, apname, ldinst);
			if (ldn == null)
				return null;
			foreach (TreeNode n in ldn.Nodes) {
				if (n.Name.Equals ("tLN0")) {
					foreach (TreeNode ln in n.Nodes) {
						if (n.Name.Equals ("tGSEControl[]")) {
							foreach (TreeNode ngse in n.Nodes) {
								if (ngse.Name.Contains ("tGSEControl")) {
									tGSE gse = (tGSE) ngse.Tag;
									if (gse.cbName.Equals (cgse))
										return ngse;
								}
							}
						}
					}
				}
			}
			return null;
		}
		
		public TreeNode GetGSENode (string iedname, string apname, string ldinst, string cgse)
		{
			if (scl == null || tree == null)
				return null;
			var ncap = GetConnectedAPNode (iedname, apname);
			if (ncap == null)
				return null;
			foreach (TreeNode n in ncap.Nodes) {
				if (n.Name.Equals ("tGSE[]")) {
					foreach (TreeNode ngse in n.Nodes) {
						if (ngse.Name.Contains ("tGSE")) {
							tGSE gse = (tGSE) ngse.Tag;
							if (gse.cbName.Equals (cgse))
								return ngse;
						}
					}
				}
			}
			return null;
		}
		
		public TreeNode GetConnectedAPNode (string iedname, string apname)
		{
			if (scl == null || tree == null)
				return null;
			var snn = GetSubNetworkNode ();
			if (snn == null)
				return null;
			foreach (TreeNode n in snn.Nodes) {
				System.Console.WriteLine ("Nodes in SNs = " + n.Name + "/" + n.Text);
				// Fixme: Must be used Name not Text attribute, is a Bug in CommunicationDialog
				if (n.Name.Contains ("tSubNetwork")
				    || n.Text.Contains ("tSubNetwork")) {
					foreach (TreeNode sn in n.Nodes) {
						System.Console.WriteLine ("Nodes in SubN = " + sn.Name + "/" + sn.Text);
						if (sn.Name.Equals ("tConnectedAP[]")) {
							foreach (TreeNode capn in sn.Nodes) {
								System.Console.WriteLine ("Nodes in CAP = " + capn.Name);
								if (capn.Name.Contains ("tConnectedAP")) {
									tConnectedAP cap = (tConnectedAP) capn.Tag;
									if (cap.iedName.Equals(iedname)
									    && cap.apName.Equals (apname)) {
										System.Console.WriteLine ("Found cap ied = " + cap.iedName 
										                          + " - ap = " + cap.apName);
										return capn;
									}
								}
							}
						}
					}
				}
			}
			return null;
		}
		
		public TreeNode GetSubnetworkNode (string name)
		{
			if (scl == null || tree == null)
				return null;
			var cn = GetCommunicationNode ();
			if (cn == null)
				return null;
			foreach (TreeNode n in cn.Nodes) {
				if (n.Name.Equals("tSubNetwork[]")) {
					foreach (TreeNode sn in n.Nodes) {
						if (sn.Name.Equals ("tSubNetwork")) {
							tSubNetwork tsn = (tSubNetwork) sn.Tag;
							if (tsn.name.Contains (name))
								return sn;
						}
					}
				}
			}
			return null;
		}
		
		public TreeNode GetCommunicationNode ()
		{
			if (scl == null || tree == null)
				return null;
			
			var s = GetSCLNode ();
			if (s == null)
				return null;
			foreach (TreeNode n in s.Nodes) {
				if (n.Name.Equals("tCommunication"))
					return n;
			}
			return null;
		}
					
		public TreeNode GetSCLNode ()
		{
			if (scl == null || tree == null)
				return null;
			
			foreach (TreeNode r in tree.Nodes) {
				if (r.Name.Equals ("root")) {
					foreach (TreeNode n in r.Nodes) {
						if (n.Name.Equals("SCL"))
							return n;
					}
				}
			}
			return null;
		}
		
		public TreeNode AddCommunicationNode () 
		{
			if (scl == null || tree == null)
				return null;
			if (scl.Configuration == null)
				return null;
			if (scl.Configuration.Communication == null)
				return null;
			var r = GetSCLNode ();
			var node = new TreeNode ();
			if (r == null)
				return null;
			node.Name = "tCommunication";
			node.Text = "Communication";
			node.Tag = scl.Configuration.Communication;
			r.Nodes.Add (node);
			return node;
		}
		
		public TreeNode AddIEDsNode () 
		{
			if (scl == null || tree == null)
				return null;
			if (scl.Configuration == null)
				return null;
			if (scl.Configuration.IED == null)
				return null;
			var r = GetSCLNode ();
			var node = new TreeNode ();
			node.Name = "tIED[]";
			node.Text = "IEDs";
			node.Tag = scl.Configuration.IED;
			r.Nodes.Add (node);
			return node;
		}
		
		public TreeNode AddSubstationNode () 
		{
			if (scl == null || tree == null)
				return null;
			if (scl.Configuration == null)
				return null;
			if (scl.Configuration.Substation == null)
				return null;
			var r = GetSCLNode ();
			var node = new TreeNode ();
			node.Name = "tSubstation";
			node.Text = "Substation Model";
			node.Tag = scl.Configuration.Substation;
			r.Nodes.Add (node);
			return node;
		}
		
		public TreeNode GetSubNetworkNode ()
		{
			if (scl == null || tree == null)
				return null;
			if (scl.Configuration == null)
				return null;
			if (scl.Configuration.Communication == null)
				return null;
			if (scl.Configuration.Communication.SubNetwork == null)
				return null;
			var c = GetCommunicationNode ();
			if (c == null)
				return null;
			foreach (TreeNode n in c.Nodes) {
				System.Console.WriteLine ("Nodes in Communication = "  + n.Name);
				if (n.Name.Equals ("tSubNetwork[]")) {
					return n;
				}
			}
			return null;
		}
		
		public TreeNode GetSubNetworkNode (string subnet)
		{
			if (scl == null || tree == null)
				return null;
			if (scl.Configuration == null)
				return null;
			if (scl.Configuration.Communication == null)
				return null;
			if (scl.Configuration.Communication.SubNetwork == null)
				return null;
			var snn = GetSubNetworkNode ();
			if (snn == null)
				return null;
			foreach (TreeNode n in snn.Nodes) {
				// Fixme: tSubNetwork Node's Name must use the class' name not the object's name
				if (n.Name.Equals (subnet)) {
					var sn = (tSubNetwork) snn.Tag;
					if (sn.name.Equals (subnet)) {
						return n;
					}
				}
			}
			return null;
		}
		
		public bool AddSubNetworkNode ()
		{
			if (scl == null || tree == null)
				return false;
			if (scl.Configuration == null)
				return false;
			if (scl.Configuration.Communication == null)
				return false;
			if (scl.Configuration.Communication.SubNetwork == null)
				return false;
			var fsn = GetSubNetworkNode ();
			if (fsn == null) {
				var c = GetCommunicationNode ();
				if (c == null)
					return false;
				TreeNode nn = new TreeNode ();
				nn.Name = "tSubNetwork[]";
				nn.Text = "Station SubNetworks";
				nn.Tag = scl.Configuration.Communication.SubNetwork;
				c.Nodes.Add (nn);
			}
			return false;
		}
		
		public bool AddSubNetworkNode (tSubNetwork sn)
		{
			if (scl == null || tree == null)
				return false;
			if (scl.Configuration == null)
				return false;
			if (scl.Configuration.Communication == null)
				return false;
			if (scl.Configuration.Communication.SubNetwork == null)
				return false;
			var snn = GetSubNetworkNode ();
			if (snn == null)
				return false;
			TreeNode nn = new TreeNode ();
			nn.Name = "tSubNetwork";
			nn.Text = sn.name;
			nn.Tag = sn;
			snn.Nodes.Add (nn);
			return true;
		}
		
		public bool AddConnectedAP (string subnet, tConnectedAP cap)
		{
			if (scl == null || tree == null)
				return false;
			
			var sn = GetSubNetworkNode (subnet);
			if (sn == null)
				return false;
			foreach (TreeNode n in sn.Nodes) {
				if (n.Name.Equals ("tConnectedAP[]")) {
					TreeNode nn = new TreeNode ();
					nn.Name = "tConnectedAP";
					nn.Text = cap.iedName + "." + cap.apName;
					nn.Tag = cap;
					n.Nodes.Add (nn);
					return true;
				}
			}
			return false;
		}
	}
}


        
		
