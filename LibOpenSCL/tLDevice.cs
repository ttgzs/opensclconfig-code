// 
//  tLDevice.cs
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
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tLDevice : tUnNaming
	{		
		private static int index = 0;
		private LN0 lN0Field;		
		private tLN[] lnField;		
		private tAccessControl accessControlField;		
		private string instField;		
		
		public tLDevice()
		{
			if(this.inst == null)
			{
				this.inst = "LDevice" + ( ++index ).ToString();
			}
		}
		
		[Category("LDevice"), Description("The LN class is always LLN0"), Browsable(false)]
		public LN0 LN0 
		{
			get
			{
				return this.lN0Field;
			}
			set
			{
				this.lN0Field = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("LN")]
		[Category("LDevice"), Browsable(false)]
		public tLN[] LN 
		{
			get 
			{
				return this.lnField;
			}
			set 
			{
				this.lnField = value;
			}
		}
		
		[Category("LDevice"), Description("Access control definition for this LD."), Browsable(false)]
		public tAccessControl AccessControl 
		{
			get 
			{
				return this.accessControlField;
			}
			set
			{
				this.accessControlField = value;
			}
		}
			
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LDevice"), Description("Identification of the LDevice within the IED.")]
		public string inst 
		{
			get
			{
				return this.instField;
			}
			set 
			{
				if( value != "")
				{
					this.instField = value;
				}
				else
				{
					this.inst = this.instField;
				}
			}
		}
	}

}

