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


/*
 * This file contains functions to validate the values of some variables of SCL Classes.
 * Functions uses personalized attributes, like "Required" to do that SCL classes fulfill
 * with the established in the standard IEC 61850 Ed.1.0.
 */ 
 
using System;

namespace LibOpenSCL
{

	///<summary>
	/// This class defines a [Required] attribute, which one identify at SCL class if it 
	/// contains a required variable.
	/// </summary>		
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredAttribute : System.Attribute
    {
        private bool required;
        private string errorMessage;
        
        public bool Required
        {
            get
            {
                return required;
            }
            set
            {
                required = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
            }
        }
		
        /// <summary>
        /// Constructor: This method is to indicate if the attribute is required
        /// </summary>
        public RequiredAttribute()
        {
            required = true;
        }
      
        /// <summary>
        /// Constructor: This method identify if the attribute is required
        /// </summary>
        /// <param name="required">
        /// His value is true if the attribute is required and False in other case.
        /// </param>
        public RequiredAttribute(bool required)
        {
            this.required = required;
        }

        /// <summary>
        /// Constructor: This method sends an error message when the attribute is empty
        /// </summary>
        /// <param name="errorMessage">
        /// Text to identify the error
        /// </param>
        public RequiredAttribute(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }
    }

	/// <summary>
	/// This class defines an attribute to assign a default value to required variable of 
	/// SCL Class 
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DefaultValueAttribute : Attribute
    {    	
    	public object Default {
			get {
				return this.Default;
			}
			set {
				this.Default = value;
			}
		}
     
        /// <summary>
        /// This method assigns a default value to variable of SCL Class
        /// </summary>
        /// <param name="Default">
        /// Default value assigned to the attribute
        /// </param>
        public DefaultValueAttribute(object Default)
        {
            this.Default = Default;
        }

    }

	/// <summary>
	/// This class defines a range of values for some variables of SCL Class  
	/// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class InRangeAttribute : System.Attribute
    {
        private string errorMessage;
        private object min;
        private object max;

        /// <summary>
        /// Constructor : Defines a range of values that can be used for the variable 
        /// </summary>
        /// <param name="min">
        /// Low limit of value's range
        /// </param>
        /// <param name="max">
        /// High limit of value's range
        /// </param>
        public InRangeAttribute(object min, object max)
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Constructor: Defines a range of values that variables can used and also generates 
        /// an error message according to value's limit violation
        /// </summary>
        /// <param name="min">
        /// Low limit of value's range
        /// </param>
        /// <param name="max">
        /// High limit of value's range
        /// </param>
        /// <param name="errorMessage">
        /// Text to identify the error
        /// </param>
        public InRangeAttribute(object min, object max, string errorMessage)
        {
            this.min = min;
            this.max = max;
            this.errorMessage = errorMessage;
        }

        public object Min
        {
            get
            {
                return min;
            }
            set
            {
                min = value;
            }
        }

        public object Max
        {
            get
            {
                return max;
            }
            set
            {
                max = value;
            }
        }


        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
            }
        }

 
    }


}
