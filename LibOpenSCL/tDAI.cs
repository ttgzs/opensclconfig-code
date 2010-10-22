// 
//  tDAI.cs
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
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tDAI : tUnNaming 
	{		
		private tVal[] valField;		
		private string nameField;		
		private string sAddrField;		
		private tValKindEnum valKindField;		
		private uint ixField;		
		private bool ixFieldSpecified;
		
		public tDAI()
		{
			this.valKindField = tValKindEnum.Set;
		}
		
		[System.Xml.Serialization.XmlElementAttribute("Val")]
		[Category("DAI"), Browsable(false)]
		public tVal[] Val 
		{
			get 
			{
				return this.valField;
			}
			set 
			{
				this.valField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DAI"), Description("The name of the Data attribute whose value is given."), ReadOnly(true)]
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
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("DAI"), Description("Short address of this Data attribute.")]
		public string sAddr 
		{
			get 
			{
				return this.sAddrField;
			}
			set 
			{
				this.sAddrField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DAI"), Description("The meaning of the value from the engineering phases, if any name is given.")]		
		public tValKindEnum valKind 
		{
			get 
			{
				return this.valKindField;
			}
			set 
			{
				this.valKindField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DAI"), Description("Index of the DAI element in case of an array type.")]		
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
		[Category("DAI"), Description("Index of the DAI element in case of an array type.")]		
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
	}


}

