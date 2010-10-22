// 
//  tLogSettings.cs
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
	public partial class tLogSettings : tServiceSettings
	{		
		private tServiceSettingsEnum logEnaField;		
		private tServiceSettingsEnum trgOpsField;		
		private tServiceSettingsEnum intgPdField;
		
		public tLogSettings() 
		{
			this.logEnaField = tServiceSettingsEnum.Fix;
			this.trgOpsField = tServiceSettingsEnum.Fix;
			this.intgPdField = tServiceSettingsEnum.Fix;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LogSettings"), Description("Log Enable. TRUE enables immediate logging; FALSE prohibits logging until enabled online")]		
		public tServiceSettingsEnum logEna 
		{
			get 
			{
				return this.logEnaField;
			}
			set 
			{
				this.logEnaField = value;
			}
		}

		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LogSettings"), Description("TrgOps contains the reasons which cause the control block to store an entry into the log.")]		
		public tServiceSettingsEnum trgOps 
		{
			get 
			{
				return this.trgOpsField;
			}
			set 
			{
				this.trgOpsField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("LogSettings"), Description("Integrity period: logging all values initiated by the server based on a given period")]
		public tServiceSettingsEnum intgPd 
		{
			get 
			{
				return this.intgPdField;
			}
			set 
			{
				this.intgPdField = value;
			}
		}
	}

}

