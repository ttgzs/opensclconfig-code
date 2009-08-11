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

namespace OpenSCL
{	
	public class ObjectManagement
	{		
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
   			if(arrayObject!=null&&arrayObject[0]!=null)
   			{
   				string nameArrayObject = this.GetNameAttributeArray(arrayObject[0].GetType(), parentObject.GetType());
   				if(!nameArrayObject.Equals(""))
   				{
	   				parentObject.GetType().InvokeMember(nameArrayObject,BindingFlags.Instance | 
   					 BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.SetField,
	              	   	null, parentObject, new object[1] { arrayObject } );
   			   		return true;   			
   				}
   			}  			
   			return false;
   		}
   		
		/// <summary>
		/// This method adds a valid object to an array of the same type. This array has to be a variable of
		/// a parent object.
		/// </summary>
		/// <param name="itemObject">
		/// Valid Object that will be added to the array.
		/// </param>	
		/// <param name="nameArrayObject">
		/// Variable's name that contains the array that will include the valid object.
		/// </param>	
		/// <param name="parentObject">
		/// Parent Object that contains the variable of array where the valid object will be added.
		/// </param>
		/// <returns>
		/// If the valid object was added correctly, it returns a "True" value, otherwise a "False" value 
		/// is returned.
		/// </returns>
		/// <remarks>
		/// The object should be validated previously to verify if it is according to the IEC 61850 Ed.1.0. 
		/// This method can be used when the variable's name that contains the array is known. 
		/// </remarks>
   		public bool AddObjectToArrayObjectOfParentObject(object itemObject, string nameArrayObject, object parentObject)
		{ 						
   			return this.AddItemToArray(itemObject, nameArrayObject, parentObject);		
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
   		private bool ModifyItemOfArray(object itemObject, int indexObject, string nameArrayObject, object parentObject)
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
		/// This method adds a valid object to an Array of the same type. 
		/// The array shall be a variable of a parent object.
		/// </summary>
		/// <param name="itemObject">
		/// Valid object.
		/// </param>
		/// <param name="parentObject">
		/// Parent object that contains an array as a variable.
		/// </param>
		/// <param name="typeParentObject">
		/// Type of the parent object. It's used to add an object in classes that 
		/// are considered base classes. 
		/// </param>
		/// <returns>
		/// If the valid object was added correctly then it returns a True value, otherwise
		/// a false value is returned.
		/// </returns>
		public bool AddObjectToArrayObjectOfParentObject(object itemObject, object parentObject, Type typeParentObject)
		{   			
   			if(itemObject!=null)
   			{
   				string attributeName = this.GetNameAttributeArray(itemObject.GetType(), typeParentObject);
   				if(!attributeName.Equals(""))
   				{
	   			   	return this.AddItemToArray(itemObject, attributeName, parentObject);   			
   				}
   			}   			
   			return false;
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
   			if (array == null)
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
	}	
}
