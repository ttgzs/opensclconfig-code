// 
//  tSMVSettings.cs
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
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSMVSettings : tServiceSettings 
	{		
		private decimal[] smpRateField;		
		private tServiceSettingsEnum svIDField;		
		private tServiceSettingsEnum optFieldsField;		
		private tServiceSettingsEnum smpRateField1;
		
		public tSMVSettings()
		{
			this.svIDField = tServiceSettingsEnum.Fix;
			this.optFieldsField = tServiceSettingsEnum.Fix;
			this.smpRateField1 = tServiceSettingsEnum.Fix;
		}
		
		[System.Xml.Serialization.XmlElementAttribute("SmpRate")]
		[Category("SMVSettings"), Description("Specifies the samples per unit.")]			
		public decimal[] SmpRate 
		{
			get 
			{
				return this.smpRateField;
			}
			set 
			{
				this.smpRateField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("SMVSettings"), Description("Sample value identifier.")]					
		public tServiceSettingsEnum svID 
		{
			get 
			{
				return this.svIDField;
			}
			set
			{
				this.svIDField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("SMVSettings"), Description("Optional fields to include in report")]			
		public tServiceSettingsEnum optFields 
		{
			get 
			{
				return this.optFieldsField;
			}
			set
			{
				this.optFieldsField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SMVSettings"), Description("Specifies the samples per unit.")]					
		public tServiceSettingsEnum smpRate 
		{
			get
			{
				return this.smpRateField1;
			}
			set 
			{
				this.smpRateField1 = value;
			}
		}
	}


}

