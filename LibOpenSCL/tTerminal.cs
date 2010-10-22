// 
//  tTerminal.cs
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
	public partial class tTerminal : tUnNaming 
	{		
		private string nameField;		
		private string connectivityNodeField;		
		private string substationNameField;		
		private string voltageLevelNameField;		
		private string bayNameField;		
		private string cNodeNameField;
		
		public tTerminal() 
		{
			this.nameField = "";
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Terminal"), Description("The optional relative name of the terminal at this Equipment.")]
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
		[Category("Terminal"), Description("The pathname of the connectivity node to which this terminal connects.")]
		public string connectivityNode
		{
			get 
			{
				return this.connectivityNodeField;
			}
			set
			{
				this.connectivityNodeField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Terminal"), Description("The name of the substation containing the connectivityNode.")]
		public string substationName 
		{
			get
			{
				return this.substationNameField;
			}
			set 
			{
				this.substationNameField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Terminal"), Description("The name of the voltage level containing the connectivityNode.")]
		public string voltageLevelName 
		{
			get 
			{
				return this.voltageLevelNameField;
			}
			set
			{
				this.voltageLevelNameField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Terminal"), Description("The name of the bay containing the connectivityNode.")]
		public string bayName
		{
			get
			{
				return this.bayNameField;
			}
			set 
			{
				this.bayNameField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Terminal"), Description("The (relative) name of the connectivityNode within its bay.")]
		public string cNodeName 
		{
			get
			{
				return this.cNodeNameField;
			}
			set
			{
				this.cNodeNameField = value;
			}
		}
	}

}

