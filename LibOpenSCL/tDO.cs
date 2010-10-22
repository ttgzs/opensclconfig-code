// 
//  tDO.cs
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
	public partial class tDO : tUnNaming
	{		
		private string nameField;		
		private string typeField;		
		private string accessControlField;		
		private bool transientField;
		
		public tDO()
		{
			this.transientField = false;
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="Name")]
		[Category("DO"), Description("The DATA name."), ReadOnly(true)]
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
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("DO"), Description("The type references the id of a DOType definition."), 
		 ReadOnly(true)]
		public string type 
		{
			get 
			{
				return this.typeField;
			}
			set
			{
				this.typeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("DO"), Description("Access control definition for this DO.")]
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
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DO"), Description("If set to true, it indicates that the Transient definition applies.")]
		public bool transient 
		{
			get
			{
				return this.transientField;
			}
			set 
			{
				this.transientField = value;
			}
		}
	}
}

