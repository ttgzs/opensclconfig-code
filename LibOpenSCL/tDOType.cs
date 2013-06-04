// 
//  tDOType.cs
//  
//  Authors:
//       Comision Federal de Electricidad
//       Daniel Espinosa <esodan@gmail.com>
//  
//  Copyright (c) 2009 Comision Federal de Electricidad
//  Copyright (c) 2010 Daniel Espinosa
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.ComponentModel;

namespace IEC61850.SCL
{
	
	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "itemsField" was deleted to fulfill standar IEC 61850 Ed. 1.0:
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed. 1.0:
	 * SDO -> sDOField
	 * DA -> dAField
	 *
	 * Only one array of TSDI or TDAI elements should be choose. 
	 * When an element is selected, the "ADD" option must be hidden, so elements of another type could not be added. 
	 * This point is defined on the XSD files contained on the IEC 61850 standard, as follows:
	 * <xs:choice minOccurs="0" maxOccurs="unbounded">
	 *	<xs:element name="SDO" type="tSDO"/>
	 *	<xs:element name="DA" type="tDA"/>
	 * </xs:choice>
	 * 
	 * According to the Reference Manual of XML, "The <choice> option describes a selection between 
	 * some elements or an elements group that can show up on the instance of the XML document"
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tDOType : tIDNaming
	{
		private string iedTypeField;		
		private string cdcField;		
		private tSDO[] sDOField;		
		private tDA[] dAField;
		
		public tDOType()
		{
			this.iedTypeField = "";
		}
				
		[System.Xml.Serialization.XmlElementAttribute("SDO")]
		[Category("DOType"), Browsable(false)]
		public tSDO[] SDO
		{
			get
			{
				return this.sDOField; 
			}
			set
			{
				this.sDOField = value;
			}					
		}
	    
		[System.Xml.Serialization.XmlElementAttribute("DA")]
		[Category("DOType"), Browsable(false)]
	    public tDA[] DA
	    {
	        get
	        {
	      		return this.dAField;
	      	}
	        set
	        {
	        	this.dAField = value;
	        }
	    }
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("DOType"), Description("The type of the IED to which this DOType belongs.")]
		public string iedType 
		{
			get 
			{
				return this.iedTypeField;
			}
			set 
			{
				this.iedTypeField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DOType"), Description("The basic Common Data Class.")]
		public string cdc
		{
			get 
			{
				return this.cdcField;
			}
			set
			{
				this.cdcField = value;
			}
		}
	}

}

