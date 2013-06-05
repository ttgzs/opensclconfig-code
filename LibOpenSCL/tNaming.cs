// 
//  tNaming.cs
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
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSDO))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubNetwork))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControlWithIEDName))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSampledValueControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSEControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControlWithTriggerOpt))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLogControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tReportControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDataSet))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAccessPoint))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tIED))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLNodeContainer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConnectivityNode))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPowerSystemResource))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubFunction))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tFunction))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTapChanger))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGeneralEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPowerTransformer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAbstractConductingEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTransformerWinding))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConductingEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEquipmentContainer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBay))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tVoltageLevel))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubstation))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tNaming : tBaseElement 
	{		
		private string nameField;		
		private string descField;
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("General Information"), Description("A name used as a technical key to designate the object.")]
		public string name 
		{
			get
			{
				return this.nameField;
			}
			set
			{
				if ( value != "")
				{
					this.nameField = value;
				}
				else
				{
					this.name = nameField;
				}
				OnPropertyChanged ("name");
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("General Information"), Description("It is used as an operator- or user-related object identification.")]		
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

