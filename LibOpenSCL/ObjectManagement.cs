// LibOpenSCL
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
using System.Collections;
using System.Reflection;
using IEC61850.SCL;

namespace OpenSCL
{	
	/// <summary>
	/// 
	/// </summary>
	public class ObjectManagement
	{		
		/// <summary>
		/// 
		/// </summary>
		public ObjectManagement()
		{
			
		}	
		
		/// <summary>
		/// This method adds a valid object to an array, both of them has to be of the same type. The array 
		/// should be a variable of a parent object.		
		/// </summary>
		/// <param name="itemObject">
		/// Valid object that will be added to an array.
		/// </param>		
		/// <param name="parentObject">
		/// Variable of array where a valid object will be added.
		/// </param>
		/// <returns>
		/// If the valid object was added correctly, it returns a "True" value, otherwise a "False" value 
		/// is returned.
		/// </returns>
		/// <remarks>
		/// To know if the object is valid, the object should be validated previously to verify if it 
		/// is according to the IEC 61850 Ed.1.0. 
		/// </remarks>
   		public bool AddObjectToArrayObjectOfParentObject(object itemObject, object parentObject)
		{   			
   			if(itemObject!=null)
   			{
   				string attributeName = this.GetNameAttributeArray(itemObject.GetType(), parentObject.GetType());
   				if(!attributeName.Equals(""))
   				{
	   			   	return this.AddItemToArray(itemObject, attributeName, parentObject);   			
   				}
   			}   			
   			return false;
   		}
   		
		/// <summary>
		/// This method gets the variable's name of the parent object, wich is the parent object under wich you 
		/// want to add a valid object.  
		/// </summary>
		/// <param name="typeAttributeRequired">
		/// Type of object that will be added to an array. It will be compared to the variables of the parent object
		/// to get the variable's name that contents the array under the valid object will be added.
		/// </param>				
		/// <param name="typeParentObject">
		/// Type of the parent object, that will be used to find the variable's name.
		/// </param>
		/// <returns>
		/// String that contains the variable's name of the parent object.
		/// </returns>
		/// <remarks>
		/// This method should be used when the typeAttributeRequired is not an array type.
		/// </remarks>
   		public string GetNameAttributeArray(Type typeAttributeRequired, Type typeParentObject)
   		{   			
   			PropertyInfo[] attributesInformation = typeParentObject.GetProperties();      			
			foreach (PropertyInfo attributeInformation in attributesInformation) 
			{
   				if(attributeInformation.PropertyType.ToString().Equals(typeAttributeRequired.ToString()+"[]"))
				{					
   					return attributeInformation.Name.ToString();
   				}   				
   			}
			return "";
   		}  		
   		   		   		
		/// <summary>
		/// This method adds an object to an object's array.
		/// </summary>
		/// <param name="itemObject">
		/// Object that will be added to the object's array. 
		/// </param>				
		/// <param name="nameArrayObject">
		/// Variable's name of the parent object that will contains the object's array.
		/// </param>
		/// <param name="parentObject">
		/// Parent Object that will contains the object's array updated.
		/// </param>
		/// <returns>
		/// If the valid object was added correctly, it returns a "True" value, otherwise a "False" value 
		/// is returned.
		/// </returns>		
   		public bool AddItemToArray(object itemObject, string nameArrayObject, object parentObject)
   		{
   			Array array  = parentObject.GetType().InvokeMember(nameArrayObject, BindingFlags.Instance | BindingFlags.Public |
              BindingFlags.GetProperty | BindingFlags.GetField, null, parentObject, null) as Array;//   			
   			if (array == null)
   			{ 
   				array = Array.CreateInstance(itemObject.GetType(),1);
   				if (array == null)
   				{
   					return false;
   				}
   				array.SetValue(itemObject, 0);  
   				parentObject.GetType().InvokeMember(nameArrayObject,BindingFlags.Instance | 
   			 	  BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.SetField,
              		null, parentObject, new object[1] { array } );
   				return true;  			
   			}
   			int arraySize = array.GetLength(0);
   			Array tempArray = Array.CreateInstance(itemObject.GetType(), arraySize + 1);
   			array.CopyTo(tempArray, 0);
   			array = tempArray;
   			array.SetValue(itemObject, arraySize);
   			parentObject.GetType().InvokeMember(nameArrayObject,BindingFlags.Instance | 
   			 BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.SetField,
              null, parentObject, new object[1] { array } );
   			return true;  			
   		}  		
		
   		/// <summary>
   		/// This method deletes an object of an array of the same type. This array is a variable of a parent 
   		/// object.
		/// </summary>
		/// <param name="itemObject">
		/// Valid object that will be deleted.
		/// </param>	
		/// <param name="indexObject">
		/// Position of the object that will be deleted, in the array.
		/// </param>	
		/// <param name="parentObject">
		/// Parent object that contains the variable array where the object will be deleted. 
		/// </param>
		/// <returns>
		/// If the valid object was deleted correctly, it returns a "True" value, otherwise a "False" value 
		/// is returned.
		/// </returns>		
   		public bool RemoveObjectOfArrayObjectOfParentObject(object itemObject, int indexObject, object parentObject)
		{ 					
   			if(itemObject==null)   				
   			{
   				return false;
   			}
   			string attributeArrayName = this.GetNameAttributeArray(itemObject.GetType(), parentObject.GetType());   			
   			if(!attributeArrayName.Equals(""))
   			{
   				return this.RemoveItemOfArray(indexObject, attributeArrayName, parentObject);
   			}
   			return false;		
   		}
   		   		   		
   		/// <summary>
   		/// This method assigns a NULL value to an object to delete it. This object has to be a variable of a 
   		/// parent object.
   		/// </summary>
   		/// <param name="objectToDelete">
   		/// Object that will be deleted.
   		/// </param>
   		/// <param name="parentObject">
   		/// Parent object that is the variable object to be deleted.
   		/// </param>
   		/// <returns>
   		/// If the valid object was deleted correctly, it returns a "True" value, otherwise 
		/// a "False" value is returned.
		/// </returns>		
   		public bool DeleteSCLObject(object objectToDelete, object parentObject)
   		{
   			string attributeName = this.GetNameAttribute(objectToDelete, parentObject);
   			if(!attributeName.Equals(""))
   			{   				
   			   	parentObject.GetType().InvokeMember(attributeName, BindingFlags.Instance | BindingFlags.Public | 
   				                                    BindingFlags.SetProperty | BindingFlags.SetField, null, parentObject, new object [] {null});
   				return true;
   			}
   			return false;
   		}
   																	
		/// <summary>
		/// This method gets the variable's name of a parent object.
		/// </summary>
		/// <param name="attributeRequired">
		/// Type of object that is used to get the variable's name of the parent object.
		/// </param>
		/// <param name="parentObject">
		/// Type of parent object that will be used to get the variable's name.
		/// </param>
		/// <returns>
		/// If there is a variable's name in the parent object, it's returned otherwise an empty string is 
		/// returned.
		/// </returns>
		/// <remarks>
		/// This method is used when a type "attributeRequired" is the same of the variable's parent object. 
		/// </remarks>
   		private string GetNameAttribute(object attributeRequired, object parentObject)
   		{   			
   			PropertyInfo[] attributesInformation = parentObject.GetType().GetProperties();   			
			foreach (PropertyInfo attributeInformation in attributesInformation) 
			{
				if(attributeInformation.PropertyType.Equals(attributeRequired.GetType()))
				{	
					return attributeInformation.Name.ToString();
   				}   				
   			}
			return "";
   		}
		   									   		
   		/// <summary>
   		/// This method deletes an object of object's array.		
		/// </summary>
		/// <param name="indexObject">
		/// Position of the object that will be deleted, in the array.
		/// </param>				
		/// <param name="nameArrayObject">
		/// Variable's name of the parent object, that will contains the object's array updated.
		/// </param>
		/// <param name="parentObject">
		/// Parent object that will contains the object's array. 
		/// </param>
		/// <returns>
		/// If the valid object was deleted correctly from the object's array, it returns a "True" value, otherwise 
		/// a "False" value is returned.
		/// </returns>		
   		private bool RemoveItemOfArray(int indexObject, string nameArrayObject, object parentObject)
   		{
   			Array array = parentObject.GetType().InvokeMember(nameArrayObject,
   			 BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.GetField,
   			   null, parentObject, null) as Array;
   			if (array == null && indexObject >= 0)
   			{
   				return false;
   			}
   			int arraySize = array.GetLength(0);
   			if (arraySize < 1)
   			{
   				return false;	
   			}
   			ArrayList arrayList = new ArrayList(array);
			arrayList.RemoveAt(indexObject);			
			if (arraySize < 1)
			{
   				return false;   			
			}
			Array newArray = Array.CreateInstance(array.GetValue(0).GetType(), arrayList.Count);			
			arrayList.CopyTo(newArray);			
			if(newArray.Length==0)
			{
				newArray = null;		
			}
			parentObject.GetType().InvokeMember(nameArrayObject,
   			  BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.SetField,
   			     null, parentObject, new object[1] { newArray });			
   			return true;
   		}
   		
		// FIXME: Deprecate the use of AddObjectToSCLObject function
		
		/// <summary>
   		/// This method adds an object to a parent object.   		
   		/// </summary>
   		/// <param name="objectToAdd">
   		/// Object that will be added.
   		/// </param>
   		/// <param name="parentObject">
   		/// Parent object that will contain the object as a variable.
   		/// </param>
   		/// <returns>
   		/// If the valid object was added correctly, it returns a "True" value, otherwise 
		/// a "False" value is returned.
		/// </returns>		
   		public bool AddObjectToSCLObject(object objectToAdd, object parentObject)
   		{
   			string attributeName = this.GetNameAttribute(objectToAdd, parentObject);
   			return this.AddObjectToSCLObject(objectToAdd, attributeName, parentObject);
   		}
		
		/// <summary>
   		/// This method adds an object to a parent object.   		
   		/// </summary>
   		/// <param name="objectToAdd">
   		/// Object that will be added.
   		/// </param>
   		/// <param name="attributeName">
		/// Variable's name of the parent object that will contains the object's array.
		/// </param>
   		/// <param name="parentObject">
   		/// Parent object that will contain the object as a variable.
   		/// </param>
   		/// <returns>
   		/// If the valid object was added correctly, it returns a "True" value, otherwise 
		/// a "False" value is returned.
		/// </returns>		
   		public bool AddObjectToSCLObject(object objectToAdd, string attributeName, object parentObject)
   		{   			
   			if(!attributeName.Equals(""))
   			{   				
   			   	parentObject.GetType().InvokeMember(attributeName, BindingFlags.Instance | BindingFlags.Public | 
   				                                    BindingFlags.SetProperty | BindingFlags.SetField, null, parentObject, new object [] {objectToAdd});
   				return true;
   			}
   			return false;
   		}
   		   		  		  		  		
   		/// <summary>
   		/// This method creates an specified object (where his contructor requires only one parameter) on the 
   		/// nameClassType variable.
   		/// </summary>
   		/// <param name="nameClassType">
   		/// Name of the class type that will be used to create his object.
   		/// </param>
   		/// <param name="parameter">
   		/// Parameter used in the constructor method.
   		/// </param>
   		/// <returns>
   		/// If the class type is defined on the library then it returns the object, otherwise it a NULL value is returned.
   		/// </returns>
   		public object CreateObject(string nameClassType, object parameter)
   		{     			   			
   			object[] parameters = new object[1];
            parameters[0] = parameter;
            if(!string.IsNullOrEmpty(nameClassType))
            {
            	Type TypeClass = Type.GetType("IEC61850.SCL."+nameClassType);
            	if(TypeClass != null)
            	{            	
	            	return this.CreateInstanceObject(TypeClass, parameters);
    	        }
        	    else
            	{
            		TypeClass = Type.GetType("IEC61850.SCL."+nameClassType);
            		if(TypeClass != null)
	            	{            	
    	        		return this.CreateInstanceObject(TypeClass, parameters);
        	    	}		
            		else
            		{
            			return null;
            		}        	
            	}
            }            
   			return null;
   		} 
   		
   		/// <summary>
   		/// This method creates an specified object (where his contructor requires only one parameter) on the 
   		/// nameClassType variable.
   		/// </summary>
   		/// <param name="nameClassType">
   		/// Name of the class type that will be used to create his object.
   		/// </param>
   		/// <param name="parameters">
   		/// Parameters used in the constructor method.
   		/// </param>
   		/// <returns>
   		/// If the class type is defined on the library then it returns the object, otherwise it a NULL value is returned.
   		/// </returns>
   		public object CreateObject(string nameClassType, params object[] parameters)
   		{     			   			   			
            if(!string.IsNullOrEmpty(nameClassType))
            {
            	Type TypeClass = Type.GetType("IEC61850.SCL."+nameClassType);
            	if(TypeClass != null)
            	{            	
	            	return this.CreateInstanceObject(TypeClass, parameters);
    	        }
        	    else
            	{
            		TypeClass = Type.GetType("OpenSCL."+nameClassType);
            		if(TypeClass != null)
	            	{            	
    	        		return this.CreateInstanceObject(TypeClass, parameters);
        	    	}		
            		else
            		{
            			return null;
            		}        	
            	}
            }            
   			return null;
   		} 
   		
   		/// <summary>
   		/// This method creates an specified object (where his contructor requires only one parameter) on the 
   		/// nameClassType variable.
   		/// </summary>
   		/// <param name="nameClassType">
   		/// Name of the class type that will be used to create his object.
   		/// </param>
   		/// <returns>
   		/// If the class type is defined on the library then it returns the object, otherwise it a NULL value is returned.
   		/// </returns>
   		public object CreateObject(string nameClassType)
   		{     			   			   			
            if(!string.IsNullOrEmpty(nameClassType))
            {
            	Type TypeClass = Type.GetType("IEC61850.SCL."+nameClassType);            	            
            	if(TypeClass != null)
            	{            	
            		return Activator.CreateInstance(TypeClass);
    	        }
        	    else
            	{
            		TypeClass = Type.GetType("IEC61850.SCL."+nameClassType);            		
            		if(TypeClass != null)
	            	{            	
            			return Activator.CreateInstance(TypeClass);
        	    	}		
            		else
            		{
            			return null;
            		}        	
            	}
            }            
   			return null;
   		} 
   		
   		/// <summary>
   		/// This method creates an instance of the specified object (where his contructor requires only one parameter) on the 
   		/// nameClassType variable.
   		/// </summary>
   		/// <param name="TypeClass">
   		/// Class type that will be used to create his object.
   		/// </param>
   		/// <param name="parameters">
   		/// Parameters used in the constructor method.
   		/// </param>
   		/// <returns>
   		/// If the class type is defined on the library then it returns the object, otherwise it a NULL value is returned.
   		/// </returns>
   		private object CreateInstanceObject(Type TypeClass, object[] parameters)
   		{        
            object newClass = Activator.CreateInstance(TypeClass, parameters);
            if (newClass != null)
            {
            	return newClass;
            }                    
            else
            {
				return null;
			}
   		}
   		
   		/// <summary>
   		/// This method finds a property included in the object provided.    		
   		/// </summary>
   		/// <param name="objectToEval">
   		/// Object used to get the property provided and his value. 
   		/// </param>
   		/// <param name="nameVariable">
   		/// Property that will be searching on the object. 
   		/// </param>
   		/// <returns>
   		/// If the property exists on the object provided, then the property's value will be returned, otherwise a NULL value 
   		/// will be returned. If the property exist but his value is NULL, a value of -1 will be returned.
   		/// </returns>
   		public object FindVariable(object objectToEval, string nameVariable)
   		{
   			MemberInfo[] nameOfVariablesToFind;			
			nameOfVariablesToFind = objectToEval.GetType().FindMembers(
   								MemberTypes.Field |
    							MemberTypes.Property, 
    							BindingFlags.Public | 
    							BindingFlags.Instance,
    							Type.FilterName, nameVariable);
   			object valueVariable = null;
			if(nameOfVariablesToFind.Length>0)
			{							
				valueVariable = objectToEval.GetType().InvokeMember(nameVariable, BindingFlags.GetField | BindingFlags.GetProperty , null, objectToEval, null );
				if(valueVariable==null)
				{
					valueVariable = "null";
				}
			}
			return valueVariable;
   		}
   		
   		/// <summary>
   		/// This method asigns a value to a property included in the object provided.
   		/// </summary>
   		/// <param name="objectToEval">
   		/// Object used to get the property provided and his value.
   		/// </param>
   		/// <param name="nameVariable">
   		/// Property that will be searching on the object. 
   		/// </param>
   		/// <param name="valueVariable">
   		/// Value of the property.
   		/// </param>
   		/// <remarks>
   		/// The instruccion try.. catch was added to allows the manipulation of the attributes of the
   		/// Common Data Classes (CDC) that are an int type but on the DataTypeTemplates are an Enum 
   		/// Type.
   		/// </remarks>		
   		public void FindVariableAndSetValue(object objectToEval, string nameVariable, object valueVariable)
   		{
   			MemberInfo[] nameOfVariablesToFind;			
			nameOfVariablesToFind = objectToEval.GetType().FindMembers(
   								MemberTypes.Field |
    							MemberTypes.Property, 
    							BindingFlags.Public | 
								BindingFlags.NonPublic |
    							BindingFlags.Instance,
    							Type.FilterName, nameVariable);   			
			if(nameOfVariablesToFind.Length>0)
			{				
				try
				{
					objectToEval.GetType().InvokeMember(nameVariable, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic |
                 	BindingFlags.SetProperty | BindingFlags.SetField, null, objectToEval, new object [] {valueVariable});
				}
				catch(Exception)
				{
					object newObject = Activator.CreateInstance(Type.GetType("IEC61850.SCL."+nameVariable));
					this.EmptySourcetoDestinyObject(valueVariable, newObject);							
					objectToEval.GetType().InvokeMember(nameVariable, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic |
                 	BindingFlags.SetProperty | BindingFlags.SetField, null, objectToEval, new object [] {newObject});
				}				
			}
		}
   		
   		/// <summary>
   		/// This method invoques a method to ejecute it.
   		/// </summary>
   		/// <param name="objectToEval">
   		/// Object that contains the method.
   		/// </param>
   		/// <param name="nameMethod">
   		/// Method's name that will be used.
   		/// </param>
   		/// <param name="value">
   		/// Value used on the parameter step.
   		/// </param>
   		public void SetValueMethod(object objectToEval, string nameMethod, object value)
   		{
   			MemberInfo[] nameOfVariablesToFind;			
			nameOfVariablesToFind = objectToEval.GetType().FindMembers(
   								MemberTypes.Method |     							
    							MemberTypes.Field |
    							MemberTypes.Property, 
    							BindingFlags.Public | 
    							BindingFlags.Instance,
    							Type.FilterName, nameMethod);   			
			if(nameOfVariablesToFind.Length>0)
			{				
				objectToEval.GetType().InvokeMember(nameMethod, BindingFlags.InvokeMethod,
				 null, objectToEval, new object [] {value});
			}			
   		}		 
		/// <summary>
		/// This method gets the information of a property.
		/// </summary>
		/// <param name="typeAttributeRequired">
		/// Properties type to get his information.
		/// </param>
		/// <param name="typeSCLObject">
		/// Getting the information of the property using the type of the SCL object .
		/// </param>
		/// <returns>
		/// The information of the property choosen.
		/// </returns>
   		public PropertyInfo GetProperty(Type typeAttributeRequired, Type typeSCLObject)
   		{
   			string propertyName = this.GetNameAttributeArray(typeAttributeRequired, typeSCLObject);
   			if(!propertyName.Equals(""))
   			{
   			   	return typeSCLObject.GetProperty(propertyName);
   			}
   			else
   			{
   				return null;
   			}
   		}   
   		
   		/// <summary>
   		/// This method adds an array to a variable of the parent object. Both of them has to be of the 
   		/// same type.
   		/// </summary>
   		/// <param name="arrayObject">
   		/// Array that will be added to the variable of the parent object.
   		/// </param>
   		/// <param name="parentObject">
   		/// Parent object.
   		/// </param>
   		/// <returns>
   		/// If the array was added correctly, it returns a "True" value, otherwise a "False" value 
		/// is returned.
		/// </returns>
   		public bool AddArrayObjectToParentObject(object[] arrayObject, object parentObject)
		{   
   			if(arrayObject!=null && arrayObject[0]!=null)
   			{
   				string nameArrayObject = this.GetNameAttributeArray(arrayObject[0].GetType(), parentObject.GetType());
   				if(!nameArrayObject.Equals(""))
   				{
   					Array array  = parentObject.GetType().InvokeMember(nameArrayObject, BindingFlags.Instance | BindingFlags.Public |   					                                                   
						BindingFlags.GetProperty | BindingFlags.GetField, null, parentObject, null) as Array;//   			
   					if (array == null)
   					{
   						array = Array.CreateInstance(arrayObject[0].GetType(),1);
   						if (array == null)
   						{
   							return false;
   						}
   						parentObject.GetType().InvokeMember(nameArrayObject,BindingFlags.Instance | 
   					 	  BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.SetField,
	              	   	    null, parentObject, new object[1] { arrayObject } );
   						return true;   			
   					}
	   				else
	   				{
	   					Array tempArray = Array.CreateInstance(arrayObject[0].GetType(), array.GetLength(0) + arrayObject.GetLength(0));
	   					array.CopyTo(tempArray, 0);
	   					arrayObject.CopyTo(tempArray, array.GetLength(0));
	   					array = tempArray;	   					
	   					parentObject.GetType().InvokeMember(nameArrayObject,BindingFlags.Instance |
	   					  BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.SetField,
	   					    null, parentObject, new object[1] { array } );
	   					return true;
	   				}   			   		
   				}
   			}  			
   			return false;
   		}
		
   		/// <summary>
   		/// 
   		/// </summary>
   		/// <param name="A">
   		/// 
   		/// </param>
   		/// <param name="B">
   		/// 
   		/// </param>
   		/// <returns>
   		/// 
   		/// </returns>
   		public bool Compare(object A, object B)
		{
			if(A.GetType()==B.GetType())
			{
				PropertyInfo[] attributesInformation = A.GetType().GetProperties();
				foreach (PropertyInfo attributeInformation in attributesInformation)
				{
					object[] valueObjectAttributeA = new object[1];
					object[] valueObjectAttributeB = new object[1];
					valueObjectAttributeA[0] = A.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, A, null );
					valueObjectAttributeB[0] = B.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField | BindingFlags.GetProperty , null, B, null );
        			
					if(valueObjectAttributeA[0]!=null && valueObjectAttributeB[0]!=null &&!valueObjectAttributeA[0].ToString().Equals(valueObjectAttributeB[0].ToString()))
        			{
        				return false;
        			}					
				}
				return true;				
			}
			else
			{
				return false;
			}
		}
   		
   		//New
   		/// <summary>
   		/// This method modifies an object contained on an array of the same type. The array has to be a parent object.		
		/// </summary>
		/// <param name="itemObject">
		/// Valid object that will be modified.
		/// </param>	
		/// <param name="indexObject">
		/// Position of the object that will be modified, in the array. 
		/// </param>	
		/// <param name="parentObject">
		/// Parent object that contains the variable array where the object will be modified. 
		/// </param>
		/// <returns>
		/// If the valid object was modified correctly, it returns a "True" value, otherwise 
		/// a "False" value is returned.
		/// </returns>		
		/// <remarks>
		/// The object should be validated previously to verify if it is according to the IEC 61850 Ed.1.0.
		/// </remarks>
   		public bool ModifyObjectOfArrayObjectOfParentObject(object itemObject, int indexObject, object parentObject)
   		{
   			string attributeArrayName = this.GetNameAttributeArray(itemObject.GetType(), parentObject.GetType());
   			if(!attributeArrayName.Equals(""))
   			{
   				return this.ModifyItemOfArray(itemObject, indexObject, attributeArrayName, parentObject);
   			}
   			return false;
   		}   		
   		
   		/// <summary>
		/// This method modifies an object included on an object's array.
		/// </summary>
		/// <param name="itemObject">
		/// Object that contains the new values.
		/// </param>
		/// <param name="indexObject">
		/// Position of the object that will be modified, in the array. 
		/// </param>				
		/// <param name="nameArrayObject">
		/// Variable's name of the parent object that will contains the object's array updated.
		/// </param>
		/// <param name="parentObject">
		/// Parent object that will contains an object's array. 
		/// </param>
		/// <returns>
		/// If the valid object was modified correctly, it returns a "True" value, otherwise 
		/// a "False" value is returned.
		/// </returns>		
   		public bool ModifyItemOfArray(object itemObject, int indexObject, string nameArrayObject, object parentObject)
   		{
   			Array array = parentObject.GetType().InvokeMember(nameArrayObject,
   			 BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.GetField,
   			   null, parentObject, null) as Array;
   			if (array == null)
   			{
   				return false;
   			}
   			int arraySize = array.GetLength(0);
   			if (arraySize < 1)
   			{
   				return false;   			
   			}
   			array.SetValue(itemObject,indexObject);  			   			
   			parentObject.GetType().InvokeMember(nameArrayObject,
   			  BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.SetField,
   			     null, parentObject, new object[1] { array });
   			return true;
   		}   		   		   		
   		
		/// <summary>
		/// This method sets the values of a SCL object to a graphical object.
		/// </summary>
		/// <param name="sourceObject">
		/// Graphical Object that will contain the values of the SCL object.
		/// </param>
		/// <param name="assignObject">
		/// SCL object.
		/// </param>
		public void EmptySourcetoDestinyObject(object sourceObject, object assignObject)			
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
		/// This method sets the values of a graphical object to an SCL object.
		/// </summary>
		/// <param name="sourceObject">
		/// SCL object.
		/// </param>
		/// <param name="assignObject">
		/// Graphical Object that will contain the values of the SCL object.
		/// </param>
   		public void EmptyDestinytoSourceObject(object sourceObject, object assignObject)
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
		/// gets the value of tP
		/// </summary>
		/// <param name="tpArray">tp array</param>
		/// <param name="type">the type of tP</param>
		/// <returns>the value of current tP otherwise return ""</returns>
		public string GetTpValue(tP[] tpArray, string type)
		{
			for(int i=0; i<tpArray.Length; i++)
			{
				if(FindVariable(tpArray[i], "type").ToString() == type)
				{
					return FindVariable(tpArray[i], "Value").ToString();
				}
			}
			return "";
		}		
	}
}
