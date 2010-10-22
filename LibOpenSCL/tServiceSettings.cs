// 
//  tServiceSettings.cs
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
	
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSMVSettings))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSESettings))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLogSettings))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tReportSettings))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServiceSettings 
	{		
		private tServiceSettingsEnum cbNameField;		
		private tServiceSettingsEnum datSetField;
		
		public tServiceSettings() 
		{
			this.cbNameField = tServiceSettingsEnum.Fix;
			this.datSetField = tServiceSettingsEnum.Fix;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServiceSettings"), Description("Control block name")]	
		public tServiceSettingsEnum cbName 
		{
			get 
			{
				return this.cbNameField;
			}
			set 
			{
				this.cbNameField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServiceSettings"), Description("Data set reference")]	
		public tServiceSettingsEnum datSet 
		{
			get 
			{
				return this.datSetField;
			}
			set 
			{
				this.datSetField = value;
			}
		}
	}

}

