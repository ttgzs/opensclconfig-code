// 
//  tLN0.cs
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
	
	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The data type "lnClassField" was added to fulfill standard IEC 61850 Ed. 1.0	
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tLN0 : tAnyLN 
	{
		private tGSEControl[] gSEControlField;		
		private tSampledValueControl[] sampledValueControlField;		
		private tSettingControl settingControlField;		
		private tSCLControl sCLControlField;		
		private tLog logField;		
		private tLNClassEnum lnClassField;		
		private string instField;
		
		public tLN0()
		{
			this.lnClassField = tLNClassEnum.LLN0;
			inst = "1";
			lnType = lnClass + inst;
		}
		
		[System.Xml.Serialization.XmlElementAttribute("GSEControl")]
		[Category("LN"), Browsable(false)]
		public tGSEControl[] GSEControl 
		{
			get 
			{
				return this.gSEControlField;
			}
			set 
			{
				this.gSEControlField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("SampledValueControl")]
		[Category("LN"), Browsable(false)]
		public tSampledValueControl[] SampledValueControl
		{
			get 
			{
				return this.sampledValueControlField;
			}
			set
			{
				this.sampledValueControlField = value;
			}
		}
		
		[Category("LN"), Description(" "), Browsable(false)]
		public tSettingControl SettingControl
		{
			get 
			{
				return this.settingControlField;
			}
			set
			{
				this.settingControlField = value;
			}
		}
		
		[Category("LN"), Description(" "), Browsable(false)]
		public tSCLControl SCLControl 
		{
			get 
			{
				return this.sCLControlField;
			}
			set 
			{
				this.sCLControlField = value;
			}
		}
		
		[Category("LN"), Description(" ")]
		public tLog Log 
		{
			get 
			{
				return this.logField;
			}
			set 
			{
				this.logField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LN"), Description("The LN class."), ReadOnly(true)]
		public tLNClassEnum lnClass 
		{
			get
			{
				return this.lnClassField;
			}
			set 
			{
				this.lnClassField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LN"), Description("The LN instance number identifying this LN.")]
		public string inst 
		{
			get 
			{
				return this.instField;
			}
			set 
			{
				this.instField = value;
			}
		}
	}
}

