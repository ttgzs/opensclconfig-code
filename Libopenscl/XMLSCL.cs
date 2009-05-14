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
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace LibOpenSCL
{	
	/// <summary>
	/// Esta clase realiza operaciones que involucra al archivo XML.
	/// </summary>
	public partial class XMLSCL 
	{
		List<ErrorsManagement> ListErrors;    
		public XMLSCL()
		{
			
		}
		
   		/// <summary>
   		/// This method creates an XML file using a serialize function.
   		/// </summary>
   		/// <param name="xMLObject">
   		/// SCL object that contains the information to generate the XML file.
   		/// </param>
   		/// <param name="nameFileXML">
   		/// Name of the XML File, including directory where is located the file.
   		/// </param>
   		/// <remarks>
   		/// The directory shall exist, and the name file shouldn't exist. 		
   		///  </remarks>
		public void Serialize(SCL xMLObject, string nameFileXML)
		 {         	        	
        	XmlSerializer serializer = 
        	new XmlSerializer(typeof(SCL));
        	TextWriter writer = new StreamWriter(nameFileXML);       	        	       	
        	serializer.Serialize(writer, xMLObject);
        	writer.Close();        	
   		}
		
   		/// <summary>
   		/// This methods gets the information of an XML file and sets to SCL objects 
   		/// using the deserialize function.
   		/// </summary>
   		/// <param name="xMLObject">
   		/// SCL Object that will contain the information of XML File.
   		/// </param>
   		/// <param name="nameFileXML">
   		/// Name of the XML File, including directory where is located the file.
   		/// </param>
   		/// <returns>
   		/// If an attribute or a node is unknown then a list of error is returned.
   		/// </returns>
   		/// <remarks>
   		/// The directory and the XML File shall exist.
   		/// </remarks>
   		public List<ErrorsManagement> Deserialize(out SCL xMLObject,string nameFileXML)
		{
   			ListErrors = new List<ErrorsManagement>();			 
			XmlSerializer XS = new XmlSerializer(typeof(SCL));
    	   XS.UnknownNode+= new 
        		XmlNodeEventHandler(Serializer_UnknownNode);
           XS.UnknownAttribute+= new XmlAttributeEventHandler(Serializer_UnknownAttribute);        
        	FileStream fs = new FileStream(nameFileXML, FileMode.Open);
            xMLObject =(SCL) XS.Deserialize(fs);                    
            fs.Close();           
            return ListErrors;
		}   		 		   		
   		
		/// <summary>
		/// This method is executed when XmlSerializer finds an unknown XML node during the 
		/// deserialize method.
		/// </summary>
		/// <param name="sender">
		/// Event's source.</param>
		/// <param name="e">
		/// An XmlNodeEventArgs that contains the event's data.
		/// </param>
		/// <remarks>
		/// This method occurs only when the Deserialize method is used.
		/// </remarks>
		private void Serializer_UnknownNode(object sender, XmlNodeEventArgs e)
    	{	        
			ListErrors.Add(new ErrorsManagement("Unknown node:"+ e.Name + "\t" + e.Text));
	    }

		/// <summary>
		/// This method is executed when XmlSerializer finds an unknown XML attribute 
		/// during the deserialize method.
		/// </summary>
		/// <param name="sender">
		/// Event's source.</param>
		/// <param name="e">
		/// An XmlAttributeEventArgs that contains the event data.
		/// </param>
		/// <remarks>
		/// This method occurs only when the Deserialize method is used.
		/// </remarks>
   		private void Serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
    	{
        	System.Xml.XmlAttribute attr = e.Attr;        	
        	ListErrors.Add(new ErrorsManagement("Unknown attribute:"+ attr.Name + "='" + attr.Value + "'"));
    	}	  		
	}
}
