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

namespace OpenSCL
{    
	/// <summary>
	/// This class contains the methods to define a structure of error messages 
	/// that are used in error management.
	/// </summary>
    public class ErrorsManagement
    {      	 
    	private object errorSCLObject;
        private string attributeName;
        private string errorMessage;
    	
        /// <summary>
        /// Constructor: This method associates an error message to the object 
        /// and the variable that are not in accordance with standard IEC 61850 
        /// Ed.1.0.
        /// </summary>
        /// <param name="errorSCLObject">
        /// Object that is not according to the standard IEC 61850 Ed.1.0.
        /// </param>
        /// <param name="attributeName">
        /// Variable that is not according to the standard IEC 61850 Ed.1.0.
        /// </param>
        /// <param name="errorMessage">
        /// Error message that will be associated to the object and the variable.
        /// </param>
        public ErrorsManagement(object errorSCLObject, string attributeName, string errorMessage)
        {
            this.errorSCLObject = errorSCLObject; 
            this.attributeName = attributeName;
            this.errorMessage = errorMessage;
        }        
        
        /// <summary>
        /// Constructor: This method generates a general error. This method can 
        /// be used when an object should be diferent to NULL or when there are 
        /// unknown attributes on an XML file.
        /// </summary>
        /// <param name="errorMessage">
        /// Error message.
        /// </param>
        public ErrorsManagement(string errorMessage)
        {                        
            this.errorMessage = errorMessage;
        }        
       
        public object ErrorSCLObject
        {
        	get
        	{
        		return this.errorSCLObject;
        	}        	
        	set
        	{
        	   this.errorSCLObject = value;
        	}
        }
        
        public string AttributeName
        {
        	get
        	{
        		return this.attributeName;
        	}
        	set
        	{
        		this.attributeName = value;
        	}
        }
        
        public string ErrorMessage
        {
        	get
        	{
        		return this.errorMessage;
        	}        	
        	set
        	{
        		this.errorMessage = value;
        	}
        	
        }
    }
}
