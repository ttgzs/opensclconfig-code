﻿// LibOpenSCL
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

namespace LibOpenSCL{
	
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
   		private bool AddItemToArray(object itemObject, string nameArrayObject, object parentObject)
   		{
   			Array array  = parentObject.GetType().InvokeMember(nameArrayObject, BindingFlags.Instance | BindingFlags.Public |
              BindingFlags.GetProperty | BindingFlags.GetField, null, parentObject, null) as Array;//   			
   			if (array == null)
   			{ 
   				array = Array.CreateInstance(itemObject.GetType(),1);
   				if (array == null)
   					return false;
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
   				return false;
   			int arraySize = array.GetLength(0);
   			if (arraySize < 1)
   				return false;
   			Type arrayType = array.GetValue(0).GetType();
   			Array newArray = Array.CreateInstance(arrayType, arraySize - 1);
   			int count = 0;
   			for (int i = 0; i < arraySize ; i++)
   			{
   				if (i != indexObject)
   				{
   					newArray.SetValue(array.GetValue(i), count);
   					count++;
   				}
   			}
   			parentObject.GetType().InvokeMember(nameArrayObject,
   			  BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.SetField,
   			     null, parentObject, new object[1] { newArray });
   			return true;
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
   				return false;
   			int arraySize = array.GetLength(0);
   			if (arraySize < 1)
   				return false;   			
   			array.SetValue(itemObject,indexObject);  			   			
   			parentObject.GetType().InvokeMember(nameArrayObject,
   			  BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.SetField,
   			     null, parentObject, new object[1] { array });
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
   			if(!attributeName.Equals(""))
   			{   				
   			   	parentObject.GetType().InvokeMember(attributeName, BindingFlags.Instance | BindingFlags.Public | 
   				                                    BindingFlags.SetProperty | BindingFlags.SetField, null, parentObject, new object [] {objectToAdd});
   				return true;
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
		/// This method sets the values from the GUI to an SCL object of base type.
		/// </summary>
		/// <param name="sourceObject">
		/// Graphical Object that contains the values of the GUI.
		/// </param>
		/// <param name="assignObject">
		/// SCL Object of base type that will get the values of the graphical object. 
		/// </param>
		/// <param name="assignObjectBaseType">
		/// Base type of the SCL class. This parameter verify that the values are part of a SCL class. 		
		/// </param>
		/// <remarks>
		/// The name of the graphical objects, like TextBox, ComboBox, etc. where the user will introduce values
		/// shall be the same name that has the variables of the SCL Class that are contained in SCL.cs file and
		/// also this graphical object should be public.
		/// 
		/// Example:
		/// The user want to work with the variable "password" that it's part of the SCL class "tAuthentication", 
		/// so a graphical object like a Combobox should be created and named "password". 
		/// 
		/// public System.Windows.Forms.ComboBox password;
		/// public bool password 
		/// { 	
		///    get 
		///    {
		///       return this.passwordField;	
		///    }	
		///    set 
		///    { 
		///       this.passwordField = value;
		///    }		
		/// }
		/// </remarks>
		public void SetGUIToSCLObjectBaseType(object sourceObject, object assignObject, Type assignObjectBaseType)
		{			
			PropertyInfo[] attributesInformation = assignObject.GetType().GetProperties();        	        	        	        	
						
        	foreach (PropertyInfo attributeInformation in attributesInformation) 
        	{
				this.CompareForSetVariablesSCLObject(sourceObject, assignObject, assignObjectBaseType, attributeInformation);
        	}						
		}	

		/// <summary>
		/// This method sets the values from the GUI to an SCL object that is not a base type.		
		/// </summary>
		/// <param name="sourceObject">
		/// Graphical Object that contains the values of the GUI.
		/// </param>
		/// <param name="assignObject">
		/// SCL Object that will get the values of the graphical object.
		/// </param>
		/// <remarks>
		/// The name of the graphical objects, like TextBox, ComboBox, etc. where the user will introduce values
		/// shall be the same name that has the variables of the SCL Class that are contained in SCL.cs file and
		/// also this graphical object should be public.
		/// 
		/// Example:
		/// The user want to work with the variable "password" that it's part of the SCL class "tAuthentication", 
		/// so a graphical object like a Combobox should be created and named "password". 
		/// 
		/// public System.Windows.Forms.ComboBox password;
		/// public bool password 
		/// { 	
		///    get 
		///    {
		///       return this.passwordField;	
		///    }	
		///    set 
		///    { 
		///       this.passwordField = value;
		///    }		
		/// }
		/// </remarks>
		public void SetGUIToSCLObject(object sourceObject, object assignObject)
		{			
			try
			{
				PropertyInfo[] attributesInformation = assignObject.GetType().GetProperties();        	        	        	        	
							
        		foreach (PropertyInfo attributeInformation in attributesInformation) 
        		{
					this.CompareForSetVariablesSCLObject(sourceObject, assignObject, assignObject.GetType(), attributeInformation);
        		}						
			}
			catch(NullReferenceException e)
			{
				System.Diagnostics.Trace.Write("Error: "+ e);
			}
			
		}	
										
		/// <summary>
		/// This method sets the values of the graphical object to the variables of tText type from SCL object.
		/// </summary>
		/// <param name="assignObject">
		/// SCL Object that will get the values of the graphical object.
		/// </param>
		/// <param name="sourceObject">
		/// Graphical Object that contains the values of the GUI.
		/// </param>
		/// <param name="attributeInformation">
		/// Variable's object that will gets the value from the graphical object of GUI.		
		/// </param>
		private void EmptyAttributeOfGUITotText(Object assignObject, Object sourceObject, PropertyInfo attributeInformation)
		{
			object[] objects = new object[1];        	       				
			ConversionObject conversionObject = new ConversionObject();
			object valueObjectAttribute = sourceObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField, null, sourceObject, new object [] {});
			switch(valueObjectAttribute.GetType().ToString())
			{			
				case "System.Windows.Forms.TextBox":
					objects[0] = conversionObject.SetStringTotTextObject( this.GetValueAttributeTextBox(valueObjectAttribute));
        			assignObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.SetField | BindingFlags.SetProperty, null, assignObject, objects);
					break;
			}        			 	
		}
											
		/// <summary>
		/// This method gets a value from a graphical object "TextBox".
		/// </summary>
		/// <param name="valueObjectAttribute">
		/// Value of the graphical object.
		/// </param>
		/// <returns>
		/// String that contains the value of the gaphical object.
		/// </returns>
		private string GetValueAttributeTextBox(object valueObjectAttribute)
		{
			TextBox valueAttribute = new TextBox();			
			valueAttribute = (TextBox) valueObjectAttribute;
			return valueAttribute.Text;
		}
			
		/// <summary>
		/// This method gets the value from a graphical object "Combobox", only if the values are not 
		/// from an Enum type
		/// </summary>
		/// <param name="valueObjectAttribute">
		/// Value of graphical object.		
		/// </param>
		/// <returns>
		/// If the graphical object ComboBox has a value it's returned, otherwise an empty string is returned. 
		/// </returns>		
		private string GetValueAttributeComboBox(object valueObjectAttribute)
		{					
			ComboBox valueAttribute = (ComboBox) valueObjectAttribute;
			object selectedItem = valueAttribute.SelectedItem;			
			if(selectedItem!=null)
				return selectedItem.ToString();
			else
				return "";
		}
		
		/// <summary>
		/// This method sets the values of a SCL object to a graphical object of GUI.
		/// </summary>
		/// <param name="sourceObject">
		/// Graphical Object that will contain the values of the SCL object.
		/// </param>
		/// <param name="assignObject">
		/// SCL object.
		/// </param>
		/// <returns>
		/// If the values of the SCL Object were setting to a graphical object correctly, then this method 
		/// will return a true value otherwise a False value will be returned.
		/// </returns>
		/// <remarks>
		/// The name of the graphical objects, like TextBox, ComboBox, etc. where the user will introduce values
		/// shall be the same name that has the variables of the SCL Class that are contained in SCL.cs file and
		/// also this graphical object should be public.
		/// 
		/// Example:
		/// The user want to work with the variable "password" that it's part of the SCL class "tAuthentication", 
		/// so a graphical object like a Combobox should be created and named "password". 
		/// 
		/// public System.Windows.Forms.ComboBox password;
		/// public bool password 
		/// { 	
		///    get 
		///    {
		///       return this.passwordField;	
		///    }	
		///    set 
		///    { 
		///       this.passwordField = value;
		///    }		
		/// }
		///</remarks>
		public bool SetSCLObjectToGUI(Object sourceObject, Object assignObject)
		{			
			if(sourceObject==null)
				return false;
			PropertyInfo[] attributesInformation = sourceObject.GetType().GetProperties();        	        	        	        	
						
        	foreach (PropertyInfo attributeInformation in attributesInformation) 
        	{
        		this.ComparateForSetVariablesGUI(sourceObject, assignObject, sourceObject.GetType(), attributeInformation);
        	}
        	return true;
		}	
		
		/// <summary>
		/// This method sets the values of a SCL object of base type to a graphical object of GUI.		
		/// </summary>
		/// <param name="sourceObject">
		/// Graphical object that will get the values from SCL object of base type.		
		/// </param>
		/// <param name="assignObject">
		/// SCL object of base type.
		/// </param>
		/// <param name="sourceObjectBaseType">
		/// Base type of the SCL class. This parameter verify that the values are part of a SCL class. 		
		/// </param>
		/// <returns>
		/// The name of the graphical objects, like TextBox, ComboBox, etc. where the user will introduce values
		/// shall be the same name that has the variables of the SCL Class that are contained in SCL.cs file and
		/// also this graphical object should be public.
		/// 
		/// Example:
		/// The user want to work with the variable "password" that it's part of the SCL class "tAuthentication", 
		/// so a graphical object like a Combobox should be created and named "password". 
		/// 
		/// public System.Windows.Forms.ComboBox password;
		/// public bool password 
		/// { 	
		///    get 
		///    {
		///       return this.passwordField;	
		///    }	
		///    set 
		///    { 
		///       this.passwordField = value;
		///    }		
		/// }
		///	</returns>
		public bool SetSCLObjectBaseTypeToGUI(Object sourceObject, Object assignObject, Type sourceObjectBaseType)
		{			
			if(sourceObject==null)
				return false;
			PropertyInfo[] attributesInformation = sourceObject.GetType().GetProperties();        	        	        	        	
						
        	foreach (PropertyInfo attributeInformation in attributesInformation) 
        	{
        		this.ComparateForSetVariablesGUI(sourceObject, assignObject, sourceObjectBaseType,attributeInformation);
        	}
        	return true;
		}	
						
		/// <summary>
		/// This method sets the variable's values of a SCL object of primitive type to the variables of 
		/// the graphical objects.		
		/// </summary>
		/// <param name="sourceObject">
		/// Graphical object that wil contains the SCL object of base type.
		/// </param>
		/// <param name="assignObject">
		/// SCL object of base type.
		/// </param>
		/// <param name="attributeInformation">
		/// Variable's object that will get the value from a graphical object of GUI.
		/// </param>
		private void EmptyPrimitiveTypetoAttributeOfGUI(Object assignObject, Object sourceObject, PropertyInfo attributeInformation)
		{
			object[] objects = new object[1];  			
			object valueAttribute = sourceObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.GetField, null, sourceObject, null);						
			if(valueAttribute != null && !valueAttribute.Equals(""))
			{				
				object attributeObjectGUI = assignObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField, null, assignObject, null);
				switch(attributeObjectGUI.GetType().ToString())
				{			
					case "System.Windows.Forms.TextBox":
						objects[0] = SetValueAttributeTextBox(valueAttribute.ToString(), attributeObjectGUI);					
        				assignObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.SetField | BindingFlags.SetProperty, null, assignObject, objects);
						break;								
					case "System.Windows.Forms.ComboBox":							
						objects[0] = this.SetValueAttributeComboBox(valueAttribute.ToString(), attributeObjectGUI);
        				assignObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.SetField | BindingFlags.SetProperty, null, assignObject, objects);
						break;
					case "System.Windows.Forms.RadioButton":
						objects[0] = this.SetValueAttributeRadioButton(valueAttribute, attributeObjectGUI);
        				assignObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.SetField | BindingFlags.SetProperty, null, assignObject, objects);
						break;							
				}			
			}			
		}	
		
		/// <summary>
		/// This method sets the tText variable's value of SCL object to graphical object of GUI. 		
		/// </summary>
		/// <param name="sourceObject">
		/// Graphical object that will get the values from SCL object of base type.
		/// </param>
		/// <param name="assignObject">
		/// SCL object of base type.
		/// </param>
		/// <param name="attributeInformation">
		/// Variable's object that will contain the value of a graphical object of GUI.
		/// </param>		
		private void EmptytTexttoAttributeOfGUI(Object assignObject, Object sourceObject, PropertyInfo attributeInformation)
		{
			ConversionObject conversionObject = new ConversionObject();
			object[] objects = new object[1];        	       				
			tText valueAttribute = (tText) sourceObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.GetField, null, sourceObject, null);			
			if(valueAttribute!=null&&!conversionObject.SettTextObjectToString(valueAttribute).Equals(""))
			{
				object attributeObjectGUI = assignObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField, null, assignObject, new object [] {});
				switch(attributeObjectGUI.GetType().ToString())
				{			
					case "System.Windows.Forms.TextBox":
						objects[0] = this.SetValueAttributeTextBox(conversionObject.SettTextObjectToString(valueAttribute), attributeObjectGUI);
        				assignObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.SetField | BindingFlags.SetProperty, null, assignObject, objects);
						break;
				}        			
			}			 	
		}		
		
		/// <summary>
		/// This method sets the value of SCL object to a graphical object "Textbox".
		/// </summary>
		/// <param name="valueAttribute">
		/// Value of the SCL object.
		/// </param>
		/// <param name="TextBoxGUI">
		/// Graphical object "TextBox" that will get the variable's value of SCL object.
		/// </param>
		/// <returns>
		/// Graphical obejct TextBox that has the value of SCL object.
		/// </returns>
		private object SetValueAttributeTextBox( string valueAttribute, object TextBoxGUI)
		{			 
			TextBox textBoxObject = (TextBox) TextBoxGUI;
			textBoxObject.Text = valueAttribute;
			return textBoxObject;
		}		
		
		/// <summary>
		/// This method sets the value of SCL object to a graphical object "ComboBox", only if the values are not 
		/// an Enum type	
		/// </summary>
		/// <param name="valueAttribute">
		/// Value of the SCL object.
		/// </param>
		/// <param name="ComboBoxGUI">
		/// Graphical object "ComboBox" that will get the variable's value of SCL object.
		/// </param>
		/// <returns>
		/// Graphical object ComboBox that has the value of SCL object.
		/// </returns>
		private object SetValueAttributeComboBox(string valueAttribute, object ComboBoxGUI)
		{					
			ComboBox ComboBoxObject = (ComboBox) ComboBoxGUI;
			ComboBoxObject.SelectedItem = valueAttribute;			
			return ComboBoxObject;
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
   		/// This method gets the type of some variables that belong to a specific class with the purpose of 
   		/// determining the method to be used to assign the values of GUI to SCL object.
		/// </summary>
		/// <param name="sourceObject">
		/// Values of graphical object of GUI.
		/// </param>
		/// <param name="assignObject">
		/// Object that will get the value's from the graphical object of GUI.
		/// </param>
		/// <param name="assignObjectType">
		/// Object's type that will determine the method to be used for the variables that belongs at this type.
		/// </param>
		/// <param name="attributeInformation">
		/// Object's variable that will get the value from a graphical object of GUI.
		/// </param>
		private void CompareForSetVariablesSCLObject(Object sourceObject, Object assignObject, Type assignObjectType, PropertyInfo attributeInformation)
		{
		  if(attributeInformation.DeclaringType == assignObjectType)		  	
		  {		  			  	
        	switch(attributeInformation.PropertyType.Name)
        	{
        		case "UInt32":
        		case "String":
        		case "Boolean":        		
        			 EmptyAttributeOfGUIToPrimitiveType(assignObject, sourceObject, attributeInformation);			
        			 break;     		
        		case "tText":
        			 EmptyAttributeOfGUITotText(assignObject, sourceObject, attributeInformation);	
        			 break;        		
        		default:
        			 switch(attributeInformation.PropertyType.BaseType.ToString())
        			 {        			 	
        			 	case "System.Enum":
        			 		EmptyAttributeOfGUIToEnumObject(assignObject, sourceObject, attributeInformation);
        			    break;
        			 }
        			 	
        			 break;
        	}       
		  }
		}
				
		/// <summary>
		/// This method sets the values of graphical object to the variables of SCL object, only if the 
		/// variables' type are primitive.
		/// </summary>
		/// <param name="assignObject">
		/// Object that will contain the values of the graphical object.
		/// </param>
		/// <param name="sourceObject">
		/// Values of graphical object.
		/// </param>
		/// <param name="attributeInformation">
		/// Object's variable that will contain the value of the graphical object.
		/// </param>
		private void EmptyAttributeOfGUIToPrimitiveType(Object assignObject, Object sourceObject, PropertyInfo attributeInformation)
		{
			object[] objects = new object[1];        	       						
			object valueObjectAttribute = sourceObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField, null, sourceObject, new object [] {});
			ConversionObject conversionObject;	
			
			switch(valueObjectAttribute.GetType().ToString())
			{						
				case "System.Windows.Forms.TextBox":
					conversionObject = new ConversionObject();
					objects[0] = conversionObject.SetStringToPrimitiveType(this.GetValueAttributeTextBox(valueObjectAttribute), attributeInformation.PropertyType.Name);					
					
        			assignObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.SetField | BindingFlags.SetProperty, null, assignObject, objects);
					break;	
				case "System.Windows.Forms.ComboBox":				
					conversionObject = new ConversionObject();										
					objects[0] = conversionObject.SetStringToPrimitiveType(this.GetValueAttributeComboBox(valueObjectAttribute), attributeInformation.PropertyType.Name);
        			assignObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.SetField | BindingFlags.SetProperty, null, assignObject, objects);
					break;
				case "System.Windows.Forms.RadioButton":
					objects[0] = GetValueAttributeRadioButton(valueObjectAttribute);
					assignObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.SetField | BindingFlags.SetProperty, null, assignObject, objects);
					break;					
			}     
		}
				
		/// <summary>
		/// Since the variables of a given class will get the operation to determine 
		/// the type to be used for set data from the graphical object to a SCL object 
		/// of base type.
		/// </summary>
		/// <param name="sourceObject">
		/// Graphical object that will contain the values of SCL object of base type.
		/// </param>
		/// <param name="assignObject">
		/// SCL object of base type.
		/// </param>
		/// <param name="sourceObjectType">
		/// Object's type that will be used to define the operations for the variables
		/// that belong to this type.
		/// </param>
		/// <param name="attributeInformation">
		/// Object's variable that will contains the values from graphical object of a GUI.
		/// </param>
		private void ComparateForSetVariablesGUI(Object sourceObject, Object assignObject, Type sourceObjectType, PropertyInfo attributeInformation)
		{							
			if(attributeInformation.DeclaringType == sourceObjectType)
        		switch(attributeInformation.PropertyType.Name)
        		{
					 case "UInt32":
					 case "String":
					 case "Boolean":
						EmptyPrimitiveTypetoAttributeOfGUI(assignObject, sourceObject, attributeInformation);			
        			 	break;     					        			
        			 case "tText":
        			 	EmptytTexttoAttributeOfGUI(assignObject, sourceObject, attributeInformation);        			 	
        			 	break;
        			 default:
        			 	switch(attributeInformation.PropertyType.BaseType.ToString())
        			 	{        			 	
	        			 	case "System.Enum":
        			 			EmptyEnumObjectToAttributeOfGUI(assignObject, sourceObject, attributeInformation);
        			    		break;
        			 	}     
        			 	break;
        		}       	
		}
		
		/// <summary>
		/// This method sets the values of the Enum variables from the SCL object to the graphical object 
		/// of a GUI.
		/// </summary>
		/// <param name="sourceObject">
		/// Graphical object that will contain the values of variables from SCL object.
		/// </param>
		/// <param name="assignObject">
		/// SCL object of base type.
		/// </param>
		/// <param name="attributeInformation">
		/// Object's variable that will set the values to a graphical object of GUI.
		/// </param>
		private void EmptyEnumObjectToAttributeOfGUI(Object assignObject, Object sourceObject, PropertyInfo attributeInformation)
		{
			ConversionObject conversionObject = new ConversionObject();
			object[] objects = new object[1];        	       				
			object valueAttribute = (object)sourceObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.GetField, null, sourceObject, null);
			
			if(valueAttribute!=null&&!conversionObject.SetEnumObjectToString(valueAttribute).Equals(""))
			{
				object attributeObjectGUI = assignObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField, null, assignObject, new object [] {});
				switch(attributeObjectGUI.GetType().ToString())
				{			
					case "System.Windows.Forms.ComboBox":				
						
						ComboBox ComboBoxObject = (ComboBox) attributeObjectGUI;						
						ComboBoxObject.SelectedItem = conversionObject.SetStringToEnumObject(conversionObject.SetEnumObjectToString(valueAttribute),attributeInformation.PropertyType);
						objects[0] = ComboBoxObject;
        				assignObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.SetField | BindingFlags.SetProperty, null, assignObject, objects);
						break;
				}        	
			}							 	
		}
		
		/// <summary>
		/// This method sets the values of the Enum variables from the graphical object to the 
		/// SCL object.
		/// </summary>
		/// <param name="assignObject">
		/// SCL object that will contain the values of variables from graphical object.
		/// </param>
		/// <param name="sourceObject">
		/// Values of the graphical object.
		/// </param>
		/// <param name="attributeInformation">
		/// Object's variable that will get the values from the graphical object of GUI.
		/// </param>
		private void EmptyAttributeOfGUIToEnumObject(Object assignObject, Object sourceObject, PropertyInfo attributeInformation)
		{
			object[] objects = new object[1];        	       				
			ConversionObject conversionObject = new ConversionObject();
			
			object valueObjectAttribute = sourceObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.GetField, null, sourceObject, new object [] {});
			switch(valueObjectAttribute.GetType().ToString())
			{			
				case "System.Windows.Forms.ComboBox":				
					objects[0] = conversionObject.SetStringToEnumObject(this.GetValueAttributeComboBox(valueObjectAttribute), attributeInformation.PropertyType);					
        			assignObject.GetType().InvokeMember(attributeInformation.Name, BindingFlags.SetField | BindingFlags.SetProperty, null, assignObject, objects);
					break;
			}        			 	
		}			
		
		/// <summary>
		/// This method gets a boolean value since a graphical object of the "RadioButton" type.
		/// </summary>
		/// <param name="valueObjectAttribute">
		/// Value of the graphical object.
		/// </param>
		/// <returns>
		/// If the RadioButton was selected then it returns a True value, otherwise, a false value is returned.
		/// </returns>
		private object GetValueAttributeRadioButton(object valueObjectAttribute)
		{					
			RadioButton valueAttribute = (RadioButton) valueObjectAttribute;		
			return valueAttribute.Checked;
		}	
			
		/// <summary>
		/// This method sets the value of a boolean variable of the SCL Object to a "RadioButton" 
		/// </summary>
		/// <param name="valueObjectAttribute">
		/// Value of a boolean variable of the SCL Object.
		/// </param>
		/// <param name="radioButtonGUI">
		/// A RadioButton updated according to the value of the variable.
		/// </param>
		/// <returns>
		/// If the value of the variable is true, then it returns a RadioButton object 
		/// selected, otherwise the RadioButton object is not selected.
		/// </returns>
		private object SetValueAttributeRadioButton(object valueObjectAttribute, object radioButtonGUI)
		{
			RadioButton radioButton = (RadioButton) radioButtonGUI;
			radioButton.Checked = (bool) valueObjectAttribute;
			return radioButton;
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
	}	
}
