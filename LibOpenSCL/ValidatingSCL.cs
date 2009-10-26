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
 * This file contains methods to validate SCL and XSD files to verify if they are
 * according to the XML standard. Also it compares the SCL files against XSD files 
 * to verify if the SCL file is according to the IEC 61850 Ed.1.0 standard.
*/ 

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace OpenSCL
{
	public class ValidatingSCL
    {
        private XmlDocument doc;
        private XmlSchema xSchema;
        private ValidationEventHandler validationEventHandler;
		List<ErrorsManagement> ListErrors;

		/// <summary>
		/// Constructior: donde se realiza la inicialización de las variables.
		/// </summary>
        public ValidatingSCL()
        {
        	ListErrors = new List<ErrorsManagement>();
           	validationEventHandler = new ValidationEventHandler(Schema_ValidationHandler);
        }

		/// <summary>
		/// This method makes the validation of an SCL file.
		/// </summary>
		/// <param name="sCLFile">
		/// SCL File to be validated.
		/// </param>
		/// <returns>
		/// If some errors occurs during the validation process then a list with those errors is returned 
		/// otherwise this list is empty.
		/// </returns>
		public List<ErrorsManagement> ValidateFile(string sCLFile, string xSDFile)
		{		
			List<ErrorsManagement> errorList = null;			
			try
			{		
				errorList = ValidateSCLFile(sCLFile);
				//If the SCL file has some error, then the process ends without validate the XSD files.
				if (errorList.Count  == 0)
				{
					//If some of the XSD files has some error, then the process ends without validate the XSD against SCL files.				
					errorList = ValidateXSDFile(xSDFile);				
					if(errorList.Count == 0)
					{
						//If the SCL and XSD files are valid, then the validation of SCL against XSD files is made.					
						errorList = ValidateSCLagainstXSD(sCLFile, xSDFile);
					}
				}	
				
			}
            catch(Exception error)
            {
				//if (error.ToString() != null)
					
				//MessageBox.Show(error.Message);					
				//if ((error.GetType().ToString() == "System.Xml.Schema.XmlSchemaException") ||
				  //  (error.GetType().ToString() == "System.NullReferenceException"))				
            	//if (error.Data == "System.Collections.Hashtable")				
			//	{		
					//errorList = null;                	
			//	}
           	}			
			return errorList;			
		}	
 
   		/// <summary>
   		/// This method validates the SCL file.
   		/// </summary>
   		/// <param name="sclDoc">
   		/// SCL file including his path where it is.
   		/// </param>
   		/// <returns>
   		/// If some errors occurs during the validation process then a list with those errors is returned 
		/// otherwise this list is empty.
   		/// </returns>
        public virtual List<ErrorsManagement> ValidateSCLFile(string sclDoc)
        {			
        	doc = new XmlDocument();
            try
            {
                doc.Load(sclDoc);
            }
            catch(Exception e)
            {
				ListErrors.Add( new ErrorsManagement(string.Format(e.Message)));
           	}
	    	return ListErrors;
        }
        
   		/// <summary>
   		/// This method validates the XSD file. 
   		/// </summary>
   		/// <param name="xsdDoc">
   		/// XSD files including his path where there are.
   		/// </param>
   		/// <returns>
   		/// If some errors occurs during the validation process then a list with those errors is returned 
		/// otherwise this list is empty.
   		/// </returns>
   		/// <remarks>
   		/// These XSD files are contained and referenced on the IEC 61850 Ed.1.0 standard.
   		/// </remarks>
        public virtual List<ErrorsManagement> ValidateXSDFile(string xsdDoc)
       	{
        	xSchema = new XmlSchema();
           	try
        	{
              	xSchema = XmlSchema.Read(XmlReader.Create(xsdDoc), Schema_ValidationHandler);
            }
           	catch (Exception e)
            {
               	ListErrors.Add(new ErrorsManagement(string.Format(e.Message)));							
            }
            return ListErrors;
	   	}
             
        /// <summary>
   		/// This method validates the SCL file against XSD files.   		
   		/// </summary>
   		/// <param name="sclDoc">
   		/// SCL file including his path where it is.
   		/// </param>
   		/// <param name="xsdDoc">
   		/// XSD files including his path where there are.
   		/// </param>
   		/// <returns>
   		/// If some errors occurs during the validation process then a list with those errors is returned 
		/// otherwise this list is empty.
   		/// </returns>
		public virtual List<ErrorsManagement> ValidateSCLagainstXSD(string sclDoc, string xsdDoc)
        {
        	XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(XmlSchema.Read(XmlReader.Create(xsdDoc), Schema_ValidationHandler));
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(settings_ValidationHandler);
            XmlReader rdr = XmlReader.Create(sclDoc,settings);
            try
			{
            	// Validating the SCL file.
				while (rdr.Read())
				{
				}
            }
           	catch (Exception e)
            {
                ListErrors.Add(new ErrorsManagement(string.Format(e.Message)));								
                rdr.Close();
            }
           	return ListErrors;
        }

		/// <summary>
		/// This event handle the errors founded during the validation process.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
        public void settings_ValidationHandler(object sender, ValidationEventArgs e)
        {
        	if ( e.Severity==XmlSeverityType.Warning )
        	{
        		ListErrors.Add( new ErrorsManagement( string.Format( "WARNING! - Line " + sender.GetType().InvokeMember("LineNumber", BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.GetField, null, sender, null) 
        			+ ", Position " +sender.GetType().InvokeMember("LinePosition", BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.GetField, null, sender, null)
        			+ " : " + e.Message)));
        	}        		
        	else if( e.Severity==XmlSeverityType.Error )
        	{
				ListErrors.Add( new ErrorsManagement (string.Format("ERROR! - Line " + sender.GetType().InvokeMember("LineNumber", BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.GetField, null, sender, null) 
        			+ ", Position " +sender.GetType().InvokeMember("LinePosition", BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.GetField, null, sender, null)
        			+ " : " + e.Message)));
        	}							
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">
        /// Name of the object.
        /// </param>
        /// <param name="e">
        /// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
        /// </param>
        void Schema_ValidationHandler(object sender, ValidationEventArgs e)
        {			
			ListErrors.Add( new ErrorsManagement(string.Format(e.Message)));									
		}        
    }
}
