// 
//  tSampledValueControlSmvOpts.cs
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
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSampledValueControlSmvOpts
	{		
		private bool refreshTimeField;		
		private bool sampleSynchronizedField;		
		private bool sampleRateField;		
		private bool securityField;		
		private bool dataRefField;
		
		public tSampledValueControlSmvOpts() 
		{
			this.refreshTimeField = false;
			this.sampleSynchronizedField = false;
			this.sampleRateField = false;
			this.securityField = false;
			this.dataRefField = false;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("SampledValueControlSmvOpts"), Description("Time of refresh activity")]
		public bool refreshTime 
		{
			get 
			{
				return this.refreshTimeField;
			}
			set 
			{
				this.refreshTimeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SampledValueControlSmvOpts"), Description("Samples are synchronized by clock signals")]
		public bool sampleSynchronized 
		{
			get 
			{
				return this.sampleSynchronizedField;
			}
			set 
			{
				this.sampleSynchronizedField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SampledValueControlSmvOpts"), Description("Sample rate from the instance")]
		public bool sampleRate 
		{
			get 
			{
				return this.sampleRateField;
			}
			set
			{
				this.sampleRateField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SampledValueControlSmvOpts"), Description(" ")]
		public bool security
		{
			get
			{
				return this.securityField;
			}
			set 
			{
				this.securityField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SampledValueControlSmvOpts"), Description("If true, then the data set reference is included in the SV message")]
		public bool dataRef 
		{
			get 
			{
				return this.dataRefField;
			}
			set 
			{
				this.dataRefField = value;
			}
		}
	}

}

