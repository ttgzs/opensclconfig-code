// 
//  tEquipmentContainer.cs
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
	
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBay))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tVoltageLevel))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubstation))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tEquipmentContainer : tPowerSystemResource 
	{		
		private tPowerTransformer[] powerTransformerField;		
		private tGeneralEquipment[] generalEquipmentField;
		
		[System.Xml.Serialization.XmlElementAttribute("PowerTransformer")]
		[Category("EquipmentContainer"), Browsable(false)]
		public tPowerTransformer[] PowerTransformer 
		{
			get 
			{
				return this.powerTransformerField;
			}
			set 
			{
				this.powerTransformerField = value;
			}
		}

		[System.Xml.Serialization.XmlElementAttribute("GeneralEquipment")]
		[Category("EquipmentContainer"), Browsable(false)]
		public tGeneralEquipment[] GeneralEquipment 
		{
			get 
			{
				return this.generalEquipmentField;
			}
			set
			{
				this.generalEquipmentField = value;
			}
		}
	}
}

