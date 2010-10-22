// 
//  tDOI.cs
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
	 * The following attributes were added to fulfill standard IEC 61850 Ed. 1.0:
	 * tSDI -> SDIField
	 * tDAI -> DAIField
	 * 
	 * The attribute "itemsField" was deleted to fulfill standar IEC 61850 Ed. 1.0.
	 *
	 * Only one array of TSDI or TDAI elements should be choose. 
	 * When an element is selected, the "ADD" option must be hidden, so elements of another type could not be added. 
	 * This point is defined on the XSD files contained on the IEC 61850 standard, as follows:
	 * <xs:choice minOccurs="0" maxOccurs="unbounded">
	 *	<xs:element name="SDI" type="tSDI"/>
	 *	<xs:element name="DAI" type="tDAI"/>
	 * </xs:choice>
	 * 
	 * According to the Reference Manual of XML, "The <choiCe> option describes a selection between 
	 * some elements or an elements group that can show up on the instance of the XML document"
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tDOI : tUnNaming 
	{		
		private string nameField;		
		private uint ixField;		
		private bool ixFieldSpecified;		
		private string accessControlField;		
		private tSDI[] SDIField;
		private tDAI[] DAIField;
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="Name")]	
		[Category("DOI"), Description("A standardised DO name"), ReadOnly(true)]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("DOI"), Description("Index of a data element in case of an array type")]
		public uint ix
		{
			get 
			{
				return this.ixField;
			}
			set
			{
				this.ixField = value;
			}
		}
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		[Category("DOI"), Description("Index of a data element in case of an array type")]
		public bool ixSpecified 
		{
			get
			{
				return this.ixFieldSpecified;
			}
			set 
			{
				this.ixFieldSpecified = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]	
		[Category("DOI"), Description("Access control definition for this data.")]
		public string accessControl 
		{
			get
			{
				return this.accessControlField;
			}
			set
			{
				this.accessControlField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("SDI", typeof(tSDI))]
		[Category("DOI"), Browsable(false)]
		public tSDI[] SDI
		{
			get 
			{
			 	return this.SDIField;
			}
			set
			{
				this.SDIField = value;
			}		
		}
		
		[System.Xml.Serialization.XmlElementAttribute("DAI", typeof(tDAI))]
		[Category("DOI"), Browsable(false)]
		public tDAI[] DAI
		{
			get
			{
				return this.DAIField;
			}
			set
			{
				this.DAIField = value;
			}
		}
	}

}

