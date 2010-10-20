// 
//  tLNode.cs
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
	 * The value's atttribute "string lnClassField to tLNClassEnum lnClassField"
	 * was added to fulfill standard IEC 61850 Ed. 1.0
	 *
	 * To accept any Logical Node without shows an error, the type of lnClass attribute has to be changed from Enum to String.
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tLNode : tUnNaming 
	{		
		private string lnInstField;		
		private string lnClassField;		
		private string iedNameField;		
		private string ldInstField;		
		private string prefixField;		
		private string lnTypeField;
		private tLN tLN;
		private tLDevice tLDevice;
		private tIED tIED;
		
		/// <summary>
		/// This constructor set lnClass to XSWI as default logical node class type. 
		/// </summary>
		public tLNode () {
			
		}
		
		/// <summary>
		/// Use this constructor to create a new tLNode to be used on SCL's Substation section.
		/// </summary>
		/// <param name="ied">
		/// A <see cref="tIED"/> witch contains the referer LD and LN in a configured system. Use null if no IED is
		/// referer because you are creating a Specification.
		/// </param>
		/// <param name="ld">
		/// A <see cref="tLDevice"/> reference witch contains a LN to be referer in a configured system. Use null if no IED is
		/// referer because you are creating a Specification.
		/// </param>
		/// <param name="ln">
		/// A <see cref="tLN"/> reference in configured system. Use null if no IED is
		/// referer because you are creating a Specification.
		/// </param>
		public tLNode(tIED ied, tLDevice ld, tLN ln)
		{
			if (ied != null) {
				this.iedNameField = ied.name;
				
				if(ld != null)
					this.ldInstField = ld.inst;
				else
					this.ldInstField = "";
			}
			else
				this.iedNameField = "None";
			
			if(ln != null) {
				this.lnInstField = (string) System.Convert.ChangeType(this.tLN.inst, typeof(string));
				this.lnClassField = this.tLN.lnClass;
				this.lnTypeField = this.tLN.lnType;
			}
			else {
				this.ldInstField = "";
				this.prefixField = "";
				this.lnClass = "XSWI";
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LNode"), Description("The LN instance identification.")]
		public string lnInst 
		{
			get
			{
				return this.lnInstField;
			}
			set 
			{
				this.lnInstField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LNode"), Description("The LN class.")]
		public string lnClass 
		{
			get 
			{
				return this.lnClassField;
			}
			set
			{
				this.lnClassField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LNode"), Description("The name of the IED which contains the LN.")]
		public string iedName 
		{
			get 
			{
				return this.iedNameField;
			}
			set 
			{
				this.iedNameField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]	
		[Category("LNode"), Description("The LD instance on the IED which contains the LN.")]
		public string ldInst 
		{
			get 
			{
				return this.ldInstField;
			}
			set 
			{
				this.ldInstField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LNode"), Description("The LN prefix used in the IED.")]
		public string prefix 
		{
			get 
			{
				return this.prefixField;
			}
			set 
			{
				this.prefixField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LNode"), Description("The LN type definition containing more detailed functional specification.")]
		public string lnType 
		{
			get 
			{
				return this.lnTypeField;
			}
			set 
			{
				this.lnTypeField = value;
			}
		}
	}

	
}

