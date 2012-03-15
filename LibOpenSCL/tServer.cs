// 
//  tServer.cs
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
	public partial class tServer : tUnNaming 
	{		
		private tServerAuthentication authenticationField;		
		private tLDevice[] lDeviceField;		
		private tAssociation[] associationField;		
		private uint timeoutField;
		
		public tServer() 
		{
			this.timeoutField = ((uint)(30));
		}
		
		[Category("Server"), Description("Defines the authentication possibilities or method(s) to be used."), Browsable(false)]
		public tServerAuthentication Authentication 
		{
			get 
			{
				return this.authenticationField;
			}
			set 
			{
				this.authenticationField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("LDevice")]
		[Category("Server"), Browsable(false)]
		public tLDevice[] LDevice 
		{
			get 
			{
				return this.lDeviceField;
			}
			set 
			{
				this.lDeviceField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("Association")]
		[Category("Server"), Browsable(false)]
		public tAssociation[] Association
		{
			get 
			{
				return this.associationField;
			}
			set 
			{
				this.associationField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("Server"), Description("Time out in seconds.")]
		public uint timeout 
		{
			get
			{
				return this.timeoutField;
			}
			set 
			{
				this.timeoutField = value;
			}
		}
		
		public int GetLDevice (string inst)
		{
			if (this.LDevice == null)
				return -1;
			for (int i = 0; i < this.LDevice.Length; i++) {
				if (this.LDevice[i].inst.Equals (inst))
					return i;
			}
			return -1;
		}
		
		public int AddLDevice (tLDevice ld)
		{
			System.Array.Resize<tLDevice>(ref this.lDeviceField,
			                                  this.lDeviceField.Length + 1);
			int index = this.lDeviceField.Length - 1;
			this.lDeviceField[index] = ld;
			return index;
		}		
	}

}

