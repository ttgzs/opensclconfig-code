// 
//  tUnNaming.cs
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
	
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDO))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAbstractDataAttribute))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBDA))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDA))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tCommunication))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSCLControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSettingControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tInputs))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDAI))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSDI))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDOI))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControlBlock))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSMV))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSE))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConnectedAP))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tRptEnabled))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAnyLN))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLN0))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLN))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLDevice))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tServer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTerminal))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLNode))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tUnNaming : tBaseElement
	{		
		private string descField;
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Description"), Description("Some descriptive text for the attribute.")]
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

