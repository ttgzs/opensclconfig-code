// 
//  tTrgOps.cs
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
	public partial class tTrgOps
	{		
		private bool dchgField;		
		private bool qchgField;		
		private bool dupdField;		
		private bool periodField;
		
		public tTrgOps() 
		{
			this.dchgField = false;
			this.qchgField = false;
			this.dupdField = false;
			this.periodField = false;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("TrgOps"), Description("dchg enabled means that a change in the value of that attribute should cause a report")]
		public bool dchg 
		{
			get 
			{
				return this.dchgField;
			}
			set 
			{
				this.dchgField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("TrgOps"), Description("dchg enabled means that a change in the value of the quality for that attribute should cause a report")]
		public bool qchg
		{
			get
			{
				return this.qchgField;
			}
			set 
			{
				this.qchgField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("TrgOps"), Description("dupd enabled A report or a log entry shall be generated due to freezing the value of "+
		                                 "a freezable attribute or updating the value of any other attribute.")]
		public bool dupd 
		{
			get 
			{
				return this.dupdField;
			}
			set 
			{
				this.dupdField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("TrgOps"), Description("if it es enabled integrity period is relevant.")]		
		public bool period 
		{
			get 
			{
				return this.periodField;
			}
			set 
			{
				this.periodField = value;
			}
		}
	}

}

