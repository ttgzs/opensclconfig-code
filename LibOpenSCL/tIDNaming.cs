// 
//  tIDNaming.cs
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
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEnumType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDAType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDOType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLNodeType))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tIDNaming : tBaseElement 
	{		
		private string idField;		
		private string descField;
		
		public tIDNaming() {}
		
		public tIDNaming(string id)
		{
			this.id = id;
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Identifier"), Description("Mandatory identifier attribute."), ReadOnly(true)]
		public string id 
		{
			get 
			{
				return this.idField;
			}
			set 
			{
				this.idField = value;
			}
		}
				
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Identifier"), Description("Description attribute.")]		
		public string desc
		{
			get 
			{
				return this.descField;
			}
			set
			{
				this.descField = value;
			}
		}
	}

}

