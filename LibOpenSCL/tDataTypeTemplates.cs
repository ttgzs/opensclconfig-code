// 
//  tDataTypeTemplates.cs
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
namespace IEC61850.SCL
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute("DataTypeTemplates", Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	public partial class tDataTypeTemplates 
	{		
		private tLNodeType[] lNodeTypeField;		
		private tDOType[] dOTypeField;		
		private tDAType[] dATypeField;		
		private tEnumType[] enumTypeField;
		
		[System.Xml.Serialization.XmlElementAttribute("LNodeType")]
		[Category("DataTypeTemplates"), Browsable(false)]
		public tLNodeType[] LNodeType
		{
			get
			{
				return this.lNodeTypeField;
			}
			set 
			{
				this.lNodeTypeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("DOType")]
		[Category("DataTypeTemplates"), Browsable(false)]
		public tDOType[] DOType 
		{
			get 
			{
				return this.dOTypeField;
			}
			set 
			{
				this.dOTypeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("DAType")]
		[Category("DataTypeTemplates"), Browsable(false)]
		public tDAType[] DAType 
		{
			get 
			{
				return this.dATypeField;
			}
			set 
			{
				this.dATypeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("EnumType")]
		[Category("DataTypeTemplates"), Browsable(false)]
		public tEnumType[] EnumType 
		{
			get 
			{
				return this.enumTypeField;
			}
			set 
			{
				this.enumTypeField = value;
			}
		}
	}
}

