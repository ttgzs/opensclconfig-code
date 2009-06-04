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
using System.Reflection;
using System.Windows.Forms;

namespace OpenSCL.UI
{
	/// <summary>
	/// Esta clase genera un árbol de nodos (TreeNode) aparatir de un objeto SCL.
	/// </summary>
	public class TreeViewSCL
	{				
		public TreeViewSCL()
		{
			
		}
		/// <summary>
		/// This method creates a graphical component called "tree" 
		/// using a SCL object where every class represent a node.		
		/// </summary>
		/// <param name="sCLObject">
		/// SCL object to create a tree.
		/// </param>
		/// <param name="treeSCL">
		/// Graphical componente called "tree" that will be created.
		/// </param>
		/// <remarks>
		/// This method uses another methods and himself to create the "tree".
		/// The "tree" gets the SCL object and associate it with a node using
		/// the name of the SCL object.	
		/// </remarks>
		public void GetNodes(object sCLObject, TreeNode treeSCL)
		{		
			object valueAttributeObject;
			Array valuesAttributeObject;
			PropertyInfo[] attributesInformation = sCLObject.GetType().GetProperties();        	        	        	        										

			treeSCL.Nodes.Add(sCLObject.GetType().Name.ToString(), sCLObject.GetType().Name.ToString());
        	foreach (PropertyInfo attributeInformation in attributesInformation) 
        	{        		
        		if(!this.ValidateObjectPrimitive(attributeInformation))
        		{        			
        			//If the variable is an Array type then it has to pool every item that belongs to the Array and it will be 
        			//sent to a method where will be associated to a node of a tree.        		
        			if(attributeInformation.PropertyType.BaseType.Name.Equals("Array"))
        			{
        				valuesAttributeObject = sCLObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, sCLObject, null ) as  Array;        				
        				for(int x = 0;  valuesAttributeObject!=null && x <valuesAttributeObject.GetLength(0); x++)
        				{
        					this.GetNodesArray(valuesAttributeObject.GetValue(x), treeSCL.Nodes[sCLObject.GetType().Name.ToString()],x);
        				}        				
        			}
        			//If the variable is an object type, then it will use this method to associate it with a node of the tree.
        			else
        			{        				
        				valueAttributeObject = sCLObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, sCLObject, null );				        			        						
        				if(valueAttributeObject!=null)
        				{        					
        					this.GetNodes(valueAttributeObject, treeSCL.Nodes[sCLObject.GetType().Name.ToString()]);
        				}
        					
        			}        			
        		}
        		//A method to associate the attributes with the corresponding node is called here.        		
        		else
        		{           		
        			valueAttributeObject = sCLObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, sCLObject, null );        				
        			if(valueAttributeObject!=null)
        				this.GetNodesAttribute(attributeInformation.Name.ToString(), treeSCL.Nodes[sCLObject.GetType().Name.ToString()],valueAttributeObject);        				
    	    	}	
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
			object valueAttributeObject;
			Array valuesAttributeObject;
			PropertyInfo[] attributesInformation = itemSCLObject.GetType().GetProperties();        	        	        	        										

			treeSCL.Nodes.Add(itemSCLObject.GetType().Name.ToString()+index, itemSCLObject.GetType().Name.ToString());
        	foreach (PropertyInfo attributeInformation in attributesInformation) 
        	{        		
        		if(!this.ValidateObjectPrimitive(attributeInformation))
        		{
        			//If the variable is an Array type then it has to pool every item that belongs to the Array and it will be 
        			//sent to a method where will be associated to a node of a tree.        		        			        			
        			if(attributeInformation.PropertyType.BaseType.Name.Equals("Array"))
        			{
        				valuesAttributeObject = itemSCLObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, itemSCLObject, null ) as  Array;        				
        				for(int x = 0;  valuesAttributeObject!=null && x <valuesAttributeObject.GetLength(0); x++)
        				{
        					this.GetNodesArray(valuesAttributeObject.GetValue(x), treeSCL.Nodes[itemSCLObject.GetType().Name.ToString()+index],x);
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
        		//A method to associate the attributes with the corresponding node is called here.        		
        		else
        		{  
        			
        			valueAttributeObject = itemSCLObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, itemSCLObject, null );        				
        			if(valueAttributeObject!=null)
        				this.GetNodesAttribute(attributeInformation.Name.ToString(), treeSCL.Nodes[itemSCLObject.GetType().Name.ToString()+index],valueAttributeObject);        				
    	    	}	
        	}	        	
		}		
		/// <summary>
		/// This method associates the attributes to a node and add them to the corresponding node.		
		/// </summary>
		/// <param name="variableName">
		/// Variable's name that will be associtaed to the corresponding node.
		/// </param>
		/// <param name="treeSCL">
		/// Graphical component "tree"
		/// </param>
		/// <param name="valueAttributeObject">
		/// Value of the variable that will be showed in the corresponding node.
		/// </param>
		private void GetNodesAttribute(string variableName, TreeNode treeSCL, object valueAttributeObject)
		{
			treeSCL.Nodes.Add(variableName, "    "+variableName+" = "+valueAttributeObject);
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
		private bool ValidateObjectPrimitive(PropertyInfo attributeInformation)
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
}
