// 
//  tSampledValueControl.cs
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
	public partial class tSampledValueControl : tControlWithIEDName 
	{		
		private tSampledValueControlSmvOpts smvOptsField;		
		private string smvIDField;		
		private bool multicastField;		
		private uint smpRateField;		
		private uint nofASDUField;
		
		public tSampledValueControl()
		{
			this.multicastField = true;
		}
			
		[Category("SampledValueControl"), Description("Sampled Values Options")]
		public tSampledValueControlSmvOpts SmvOpts 
		{
			get 
			{
				return this.smvOptsField;
			}
			set
			{
				this.smvOptsField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("SampledValueControl"), Description("Idenitifier of the SMV, (Multicast CB or Unicast CB)")]
		public string smvID
		{
			get 
			{
				return this.smvIDField;
			}
			set 
			{
				this.smvIDField = value;
			}
		}
			
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SampledValueControl"), Description("If it's false indicates Unicast SMV services")]
		public bool multicast 
		{
			get
			{
				return this.multicastField;
			}
			set
			{
				this.multicastField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SampledValueControl"), Description("Sample rate")]
		public uint smpRate
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
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SampledValueControl"), Description("Number of ASDU (Application service data unit)")]
		public uint nofASDU 
		{
			get
			{
				return this.nofASDUField;
			}
			set
			{
				this.nofASDUField = value;
			}
		}
	}


}

