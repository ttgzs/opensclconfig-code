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

namespace OpenSCL.UI
{
	/// <summary>
	/// Description of GUIObjectManagement.
	/// </summary>
	public class Utils
	{
		public object ObjectReturnedinAfterSelect;
																																																		
		/// <summary>
		/// This method sets the values of a SCL object to a graphical object of GUI.
		/// </summary>
		/// <param name="sourceObject">
		/// Graphical Object that will contain the values of the SCL object.
		/// </param>
		/// <param name="assignObject">
		/// SCL object.
		/// </param>		
   		public void EmptySCLObjectoGUIObject(object sourceObject, object assignObject)			
		{
			PropertyInfo[] attributesInformation = sourceObject.GetType().GetProperties();        	        	        	        							
			object[] valueObjectAttribute = new object[1];
			MemberInfo[] nameOfVariablesToFind;
        	foreach (PropertyInfo attributeInformation in attributesInformation) 
        	{        		
        		valueObjectAttribute[0] = sourceObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, sourceObject, null );				
        		if(valueObjectAttribute[0]!=null)
        		{
        			nameOfVariablesToFind = assignObject.GetType().FindMembers(
        						MemberTypes.Field |
    							MemberTypes.Property, 
    							BindingFlags.Public | 
    							BindingFlags.Instance,
    							Type.FilterName, attributeInformation.Name);
        			if(nameOfVariablesToFind.Length>0)
        			{
        				assignObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.SetField | BindingFlags.SetProperty, null, assignObject, valueObjectAttribute);        		        			
        			}
        		}
        	}				
		}		
		
   		/// <summary>
		/// This method sets the values of  a graphical object of GUI to an SCL object.
		/// </summary>
		/// <param name="sourceObject">
		/// SCL object.
		/// </param>
		/// <param name="assignObject">
		/// Graphical Object that will contain the values of the SCL object.
		/// </param>
   		public void EmptyGUIObjectoSCLObject(object sourceObject, object assignObject)
		{
			PropertyInfo[] attributesInformation = assignObject.GetType().GetProperties();        	        	        	        							
			object[] valueObjectAttribute = new object[1];
			MemberInfo[] nameOfVariablesToFind;
        	foreach (PropertyInfo attributeInformation in attributesInformation) 
        	{        
        	     nameOfVariablesToFind = sourceObject.GetType().FindMembers(
        						MemberTypes.Field |
    							MemberTypes.Property, 
    							BindingFlags.Public | 
    							BindingFlags.Instance,
    							Type.FilterName, attributeInformation.Name);
        		if(nameOfVariablesToFind.Length>0)
        		{
					valueObjectAttribute[0] = sourceObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, sourceObject, null );				
					assignObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.SetField | BindingFlags.SetProperty, null, assignObject, valueObjectAttribute);        		        	        		
        		}        		
        	}			
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
                        Utils GUIOM = new Utils();
                        GUIOM.EmptySCLObjectoGUIObject(NodetreeViewFile, HierachyClass);
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
	}	   			
}
