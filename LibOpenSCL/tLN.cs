// 
//  tLN.cs
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
	 * The data type "lnClassField" was added to fulfill standard IEC 61850 Ed. 1.0	 
	 *
	 * To accept any Logical Node without shows an error, the type of lnClass attribute has to be changed from Enum to String.
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute("LN", Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]	
	public partial class tLN : tAnyLN 
	{		
		private static uint index = 0;
		private tLNClassEnum lnClassField;		
		private uint instField;		
		private string prefixField;
		private string lnClassString;
		private tStatusEnum status;
		
		[System.Xml.Serialization.XmlIgnore()]
		public tLNClassEnum lnClassFieldTemp;
		
		public tLN() 
		{
			this.prefix = "";
			this.lnClass = tLNClassEnum.LPHD.ToString();
			this.lnClassEnum = tLNClassEnum.LPHD;
			this.inst = ++index;
			this.status = tStatusEnum.Unknown;
		}
		
		/// <summary>
		/// Use this constructor to create a new LN and verify if it is Valid, if there's no other
		/// LN in the LD with the same prefix, class and instance. Check Status property in order 
		/// to know its status. 
		/// </summary>
		/// <param name="ld">
		/// A <see cref="tLDevice"/> to be used to check for duplicated instances.
		/// </param>
		/// <param name="lnClass">
		/// A <see cref="System.String"/> with the name of the LN Class as on IEC 61850-7-x
		/// </param>
		/// <param name="prefix">
		/// A <see cref="System.String"/> with the prefix on LN Class.
		/// </param>
		/// <param name="inst">
		/// A <see cref="System.UInt32"/> with the instance number of the LN Class.
		/// </param>
		/// <param name="lnType">
		/// A <see cref="tLNodeType"/> reference to instantied.
		/// </param>
		public tLN (tLDevice ld, string lnClass, string prefix, uint inst, tLNodeType lnType) {
			if (ld == null) return;
			if (lnType == null) return;
			
			if (inst == 0)
				this.inst = ++index;
			else
				this.inst = inst;
			
			this.lnClass = lnClass;
			
			this.lnType = lnType.id;
			
			// Search for duplicated LN
			if(ld.LN != null) {
				for (int i = 0; i < ld.LN.GetLength(0); i++) {
					tLN ln = ld.LN[i];
					if ( ln.prefix == this.prefix && ln.inst == this.inst && ln.lnClass == this.lnClass) {
						this.status = tStatusEnum.Invalid;
						break;
					}
				}
				this.status = tStatusEnum.Valid;
			}
		}
		
		
		/// <summary>
		/// Check this property in order to know if this LN has been verified for duplicated nodes, if so
		/// this returns tLNValidEnum.Valid, other wise it returns tLNValidEnum.Invalid. If not checked, 
		/// when is created by using the default constructor, it return tLNValidEnum.Unknown.
		/// </summary>
		[System.Xml.Serialization.XmlIgnore]
		public tStatusEnum Status {
			get { return this.status; }
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LN"), Description("The LN class")]
		public string lnClass 
		{
			get 
			{
				return this.lnClassString;
			}
			set
			{				
				this.lnClassString = value;
				if(System.Enum.IsDefined(typeof(tLNClassEnum), lnClass))
				{
					this.lnClassEnum = (tLNClassEnum) System.Enum.Parse(typeof(tLNClassEnum), lnClass);
				}
				else
				{
					this.lnClassEnum = tLNClassEnum.Custom;
				}
				OnPropertyChanged ("lnClass");
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlIgnore()]
		[Category("LN"), DisplayName("lnClassEnum"), Description("Pre-defined LN class")]
		public tLNClassEnum lnClassEnum 
		{
			get 
			{
				return this.lnClassField;
			}
			set
			{	
				if(lnClassField != value)
				{
					this.lnClassFieldTemp = lnClassField;
				}
				this.lnClassField = value;				
				if(this.lnClassField!=tLNClassEnum.Custom)
				{
					this.lnClassString = this.lnClassField.ToString();
				}
				OnPropertyChanged ("lnClass");
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LN"), Description("The LN instance number identifying this LN.")]
		public uint inst 
		{
			get 
			{
				return this.instField;
			}
			set 
			{
				this.instField = value;
				OnPropertyChanged ("inst");
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LN"), Description("The LN prefix part.")]
		public string prefix
		{
			get 
			{
				return this.prefixField;
			}
			set 
			{
				this.prefixField = value;
				OnPropertyChanged ("prefix");
			}
		}
	}

}

