// 
//  tAccessPoint.cs
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
	 * The following attributes were added to fulfill standard IEC 61850 Ed. 1.0:
	 * Server -> serverField
	 * LN -> lNField
	 * 
	 * The attribute "itemsField" was deleted to fulfill standar IEC 61850 Ed. 1.0.
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tAccessPoint : tNaming
	{		
		private static int index = 0;
		private bool routerField;		
		private bool clockField;		
		private tServer serverField;		
		private tLN[] lNField;
		
		public tAccessPoint() 
		{
			this.routerField = false;
			this.clockField = false;
			if(this.name == null)
			{
				this.name = "AccessPoint" + ( ++ index ).ToString();
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("AccessPoint"), Description("This is a function of the communication network on the IED.")]
		public bool router
		{
			get 
			{
				return this.routerField;
			}
			set 
			{
				this.routerField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("AccessPoint"), Description("The presence and setting to true defines this IED to be a master clock at this bus.")]
		public bool clock 
		{
			get
			{
				return this.clockField;
			}
			set 
			{
				this.clockField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("Server")]
		[Category("AccessPoint"), Description("A communication entity within an IED."), Browsable(false)]
		public tServer Server
		{
			get
			{
				return this.serverField;
			}
			set
			{
				this.serverField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("LN")]
		[Category("AccessPoint"), Browsable(false)]
		public tLN[] LN
		{
			get
			{
				return this.lNField;
			}
			set
			{
				this.lNField = value;
			}
		}
	}
}

