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

namespace OpenSCL
{
	/// <summary>
	/// This class contains the methods to make some validations according to standard IEC 61850 Ed.1.0
	/// </summary>
	public class ConversionObject
	{												
		/// <summary>
		/// This method changes a string's value to primitive type specified.		
		/// </summary>
		/// <param name="valueAttribute">
		/// String that will be changed to primitive type.
		/// </param>
		/// <param name="typeAttribute">
		/// Primitive type specified
		/// </param>
		/// <returns>
		/// A value of primitive type specified.
		/// </returns>
		public object SetStringToPrimitiveType(object valueAttribute, string typeAttribute)
		{			
			if(valueAttribute == null)
			{
				return "";
			}
			object valuePrimitiveType="";		
			switch(typeAttribute)
        	{
        		case "String":
					    valuePrimitiveType = valueAttribute;
						break;
        		case "Boolean":
						valuePrimitiveType = (bool) System.Convert.ChangeType(valueAttribute, typeof(bool));
						break;			
			}
			return valuePrimitiveType;
		}
		
		/// <summary>
		/// This method sets the valueof an object that will be an Enum to a string.
		/// </summary>
		/// <param name="enumObject">
		/// Object that will be an Enum.
		/// </param>
		/// <returns>
		/// String that contains the value of an object that will be an Enum.
		/// </returns>
		public string SetEnumObjectToString(object enumObject)
		{
			return enumObject.ToString();
		}
		
		/// <summary>
		/// This method converts a string value to a valid value of an Enum.
		/// </summary>
		/// <param name="enumString">
		/// String value according to an Enum.
		/// </param>
		/// <param name="enumType">
		/// Enum type of the string. 
		/// </param>
		/// <returns>
		/// Value of the enum requeried.
		/// </returns>
		public object SetStringToEnumObject(string enumString, Type enumType)
		{
			return Enum.Parse(enumType,enumString);
		}			
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="enumType">
		/// 
		/// </param>
		/// <returns>
		/// 
		/// </returns>
		public Array GetValuesEnumToArray(Type enumType)
		{
			return System.Enum.GetValues(enumType);
		}	
	}
}
