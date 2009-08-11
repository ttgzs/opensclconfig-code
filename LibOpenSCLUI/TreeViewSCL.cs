// LibOpenSCLUI
//
// Copyright (C) 2009 Comisión Federal de Electricidad
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
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
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace OpenSCL.UI
{	
	/// <summary>
	/// This class creates a graphical component called "treeNode" using a SCL object.
	/// </summary>
	public class TreeViewSCL
	{				
		TreeNode node;
		public TreeViewSCL()
		{
			
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
		private void GetNodes(object sCLObject, TreeNode treeSCL)
		{			
			node = new TreeNode();
            node.Name = sCLObject.GetType().Name.ToString();
            node.Text = sCLObject.GetType().Name.ToString();            
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
			object valueAttributeObject;
			Array valuesAttributeObject;
			PropertyInfo[] attributesInformation = sCLObject.GetType().GetProperties();        	        	        	        										                 							
        	foreach (PropertyInfo attributeInformation in attributesInformation) 
        	{        		
	        	if(!this.ValidateObjectPrimitive(attributeInformation))
    	    	{
        			// If the variable is an Array type then a pooling of every item is made, and it 
        			// will be sent to a method that adds it in some node of the tree.    
        			if(attributeInformation.PropertyType.BaseType.Name.Equals("Array"))
        			{
		       			valuesAttributeObject = sCLObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, sCLObject, null ) as  Array;        				
        				if(valuesAttributeObject!=null)
        				{
        					this.GetNodesItemOfArray(attributeInformation, valuesAttributeObject,  treeSCL.Nodes[sCLObject.GetType().Name.ToString()]);
        				}     				
        			}
        			// If the variable is an Object type then a method will be called for 
        			// add it to a node of the tree.        			
	        		else
    	    		{        				
        				valueAttributeObject = sCLObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, sCLObject, null );				        			        						
        				if(valueAttributeObject!=null)
        				{        					
        					this.GetNodes(valueAttributeObject,  treeSCL.Nodes[sCLObject.GetType().Name.ToString()]);
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
            node.Text = attributeInformation.Name;            
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
            node.Text = itemSCLObject.GetType().Name.ToString();           
            node.Tag = itemSCLObject;
            treeSCL.Nodes.Add(node);			
        	foreach (PropertyInfo attributeInformation in attributesInformation) 
        	{        		
        		if(!this.ValidateObjectPrimitive(attributeInformation))
        		{
        			//If the variable is an Array type then it has to pool every item that belongs to the Array and it will be 
        			//sent to a method where will be associated to a node of a tree.        		        			        			
        			if(attributeInformation.PropertyType.BaseType.Name.Equals("Array"))
        			{
        				valuesAttributeObject = itemSCLObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, itemSCLObject, null ) as  Array;        				
        				if(valuesAttributeObject!=null)
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
				     case "tPrivate[]":
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
	}

	/// <summary>
	/// 
	/// </summary>
	class NextNodeDisplayName
    {
        private string _name;
        private string _finishNode;
        [CategoryAttribute("Next Node"), DescriptionAttribute("Next Node to display"), ReadOnly(true)]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        
        [CategoryAttribute("Finish Node"), DescriptionAttribute("Finish Node"), ReadOnly(true)]
        public string FinishNode
        {
            get
            {
                return _finishNode;
            }
            set
            {
                _finishNode = value;
            }
        }
    }
}
