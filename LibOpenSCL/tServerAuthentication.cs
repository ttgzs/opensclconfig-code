// 
//  tServerAuthentication.cs
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
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServerAuthentication 
	{		
		private bool noneField;		
		private bool passwordField;		
		private bool weakField;		
		private bool strongField;		
		private bool certificateField;
		
		public tServerAuthentication()
		{
			this.noneField = true;
			this.passwordField = false;
			this.weakField = false;
			this.strongField = false;
			this.certificateField = false;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServerAuthentication"), Description("No authentication.")]
		public bool none 
		{
			get 
			{
				return this.noneField;
			}
			set
			{
				this.noneField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServerAuthentication"), Description("Key for authentication.")]
		public bool password 
		{
			get
			{
				return this.passwordField;
			}
			set 
			{
				this.passwordField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServerAuthentication"), Description("A weak password for authentication.")]
		public bool weak 
		{
			get 
			{
				return this.weakField;
			}
			set 
			{
				this.weakField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServerAuthentication"), Description("A strong password for authentication.")]
		public bool strong 
		{
			get
			{
				return this.strongField;
			}
			set 
			{
				this.strongField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServerAuthentication"), Description("A certificate for authentication.")]
		public bool certificate 
		{
			get 
			{
				return this.certificateField;
			}
			set 
			{
				this.certificateField = value;
			}
		}
	}

}

