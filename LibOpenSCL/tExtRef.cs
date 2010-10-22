// 
//  tExtRef.cs
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
	 * iedName -> iedNameField
	 * ldInst -> ldInstField
	 * prefix -> prefixField
	 * lnClass -> lnClassField
	 * lnInst -> lnInstField
	 * 
	 * The data type "lnClassField" was added to fulfill standard IEC 61850 Ed. 1.0	 
	 * 
	 * To accept any Logical Node without shows an error, the type of lnClass attribute has to be changed from Enum to String.
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tExtRef 
	{		
		private string iedNameField;		
		private string ldInstField;		
		private string prefixField;		
		private string lnClassField;		
		private string lnInstField;		
		private string doNameField;		
		private string daNameField;		
		private string intAddrField;
				
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ExtRef"), Description("The name of the IED from where the input comes.")]
		public string iedName 
		{
			get 
			{
				return this.iedNameField;
			}
			set 
			{
				this.iedNameField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ExtRef"), Description("The LD instance name from where the input comes.")]
		public string ldInst
		{
			get 
			{
				return this.ldInstField;
			}
			set 
			{
				this.ldInstField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ExtRef"), Description("The LN prefix")]
		public string prefix 
		{
			get
			{
				return this.prefixField;
			}
			set 
			{
				this.prefixField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ExtRef"), Description("The LN class")]
		public string lnClass
		{
			get 
			{
				return this.lnClassField;
			}
			set 
			{
				this.lnClassField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ExtRef"), Description("The instance id of this LN instance of below LN class in the IED")]
		public string lnInst
		{
			get 
			{
				return this.lnInstField;
			}
			set
			{
				this.lnInstField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ExtRef"), Description("A name identifying the DO (within the LN)")]
		public string doName
		{
			get 
			{
				return this.doNameField;
			}
			set 
			{
				this.doNameField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ExtRef"), Description("The attribute designating the input.")]
		public string daName
		{
			get
			{
				return this.daNameField;
			}
			set 
			{
				this.daNameField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ExtRef"), Description("The internal address to which the input is bound."), ReadOnly(true)]
		public string intAddr 
		{
			get 
			{
				return this.intAddrField;
			}
			set 
			{
				this.intAddrField = value;
			}
		}
	}
	
}

