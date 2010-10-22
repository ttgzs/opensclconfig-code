// 
//  tValueWithUnit.cs
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
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDurationInMilliSec))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDurationInSec))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBitRateInMbPerSec))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tVoltage))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tValueWithUnit 
	{		
		private tSIUnitEnum unitField;		
		private tUnitMultiplierEnum multiplierField;		
		private decimal valueField;
		
		public tValueWithUnit() 
		{
			this.multiplierField = tUnitMultiplierEnum.Item;
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ValueWithUnit"), Description("Units derived from ISO 1000 to represent a measurement.")]
		public tSIUnitEnum unit 
		{
			get 
			{
				return this.unitField;
			}
			set 
			{
				this.unitField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("ValueWithUnit"), Description("It shall define the multiplier value"), DefaultValue(tUnitMultiplierEnum.Item)]
		public tUnitMultiplierEnum multiplier 
		{
			get 
			{
				return this.multiplierField;
			}
			set 
			{
				this.multiplierField = value;
			}
		}
		
		[System.Xml.Serialization.XmlTextAttribute()]
		[Category("ValueWithUnit"), Description("Value assigned")]
		public decimal Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}

}

