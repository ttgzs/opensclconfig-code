// 
//  tControlBlock.cs
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
	 * 
	 * The value of the attribute "addressField" of tP[] was changed to tAddress, to fulfill the IEC 61850 Ed.1.0 standard.
	*/		
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSMV))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSE))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tControlBlock : tUnNaming 
	{		
		private tAddress addressField;		
		private string ldInstField;		
		private string cbNameField;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		private tLDevice tLDevice;
		
		[Category("ControlBlock"), Description("This contains the address parameters of this access point at this bus, at least "+
			"one parameter"), Browsable(false)]
		public tAddress Address 
		{
			get 
			{
				return this.addressField;
			}
			set 
			{
				this.addressField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ControlBlock"), 
		 Description("The instance identification of the LD within this IED, on which the control block is located."), 
		 ReadOnlyAttribute(true)]
		public string ldInst 
		{
			get 
			{
				if(this.tLDevice != null)
				{
					return this.tLDevice.inst;
				}
				return this.ldInstField;
			}
			set 
			{
				if(this.tLDevice != null)
				{
					this.tLDevice.inst = this.ldInstField = value;
				}
				this.ldInstField = value;
			}
		}

		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ControlBlock"), 
		 Description("The name of the control block within the LLN0 of the LD ldInst."), 
		 ReadOnlyAttribute(true)]
		public string cbName 
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
	}
}

