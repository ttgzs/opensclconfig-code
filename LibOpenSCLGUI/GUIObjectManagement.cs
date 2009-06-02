
using System;
using System.Windows.Forms;
using OpenSCL;
using IEC61850.SCL;
using System.Reflection;

namespace OpenSCL.UI
{
	
	
	public class Utils
	{
			
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
		
		
	}
}
