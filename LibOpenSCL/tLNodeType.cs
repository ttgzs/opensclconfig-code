// 
//  tLNodeType.cs
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
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 	 
	 * The data type "lnClassField" was added to fulfill standard IEC 61850 Ed. 1.0	 
	 *
	 * To accept any Logical Node without shows an error, the type of lnClass attribute has to be changed from Enum to String.
	*/		
	public partial class tLNodeType : tIDNaming
	{		
		private tDO[] doField;		
		private string iedTypeField;		
		private string lnClassField;
		
		public tLNodeType() 
		{
			this.iedTypeField = "";
		}
		
		public tLNodeType(string iedType, string lnClass, string id) : base (id)
		{
			this.lnClass = lnClass;
			this.iedType = iedType;
		}
		
		[System.Xml.Serialization.XmlElementAttribute("DO")]
		[Category("LNodeType"), Browsable(false)]
		public tDO[] DO 
		{
			get 
			{
				return this.doField;
			}
			set 
			{
				this.doField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LNodeType"), Description("The manufacturer IED type of the IED to which this LN type belongs.")]
		public string iedType
		{
			get
			{
				return this.iedTypeField;
			}
			set
			{
				this.iedTypeField = value;
				OnPropertyChanged ("iedType");
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LNodeType"), Description("The LN base class of this type.")]
		public string lnClass 
		{
			get 
			{
				return this.lnClassField;
			}
			set 
			{
				this.lnClassField = value;
				OnPropertyChanged ("lnClass");
			}
		}
	}

	
}

