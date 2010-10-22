// 
//  tAnyContentFromOtherNamespace.cs
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
	
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLog))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAccessControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tHitem))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPrivate))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tText))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tAnyContentFromOtherNamespace 
	{		
		private System.Xml.XmlNode[] anyField;		
		private System.Xml.XmlAttribute[] anyAttrField;
		
		[System.Xml.Serialization.XmlTextAttribute()]
		[System.Xml.Serialization.XmlAnyElementAttribute()]
		[Browsable(false)]
		public System.Xml.XmlNode[] Any 
		{
			get 
			{
				return this.anyField;
			}
			set 
			{
				this.anyField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		[Browsable(false)]
		public System.Xml.XmlAttribute[] AnyAttr 
		{
			get 
			{
				return this.anyAttrField;
			}
			set 
			{
				this.anyAttrField = value;
			}
		}
	}

}

