// 
//  tAbstractDataAttribute.cs
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
	 * The type of the attribute "bTypeField" was changed from string to "tBasciTypeEnum".
	*/		
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBDA))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDA))]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tAbstractDataAttribute : tUnNaming
	{		
		private tVal[] valField;
		private string nameField;
		private string sAddrField;
		private tBasicType _btypeenum;
		private tValKindEnum valKindField;
		private string typeField;
		private uint countField;
		
		public tAbstractDataAttribute() 
		{
			//this.valKindField = tValKindEnum.Set;
			//this.countField = ((uint)(0));
			this._btypeenum = new tBasicType();
		}
		
		[System.Xml.Serialization.XmlElementAttribute("Val")]
		[Category("AbstractDataAttribute"), Browsable(false)]
		public tVal[] Val
		{
			get 
			{
				return this.valField;
			}
			set 
			{
				this.valField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("AbstractDataAttribute"), Description("The attribute name.")]
		public string name 
		{
			get
			{
				return this.nameField;
			}
			set 
			{
				this.nameField = value;
				OnPropertyChanged ("name");
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("AbstractDataAttribute"), Description("A short address of this BDA attribute.")]
		public string sAddr
		{
			get
			{
				return this.sAddrField;
			}
			set 
			{
				this.sAddrField = value;
			}
		}
		
		[System.Xml.Serialization.XmlIgnore]
		[Category("AbstractDataAttribute"), Description("The basic type of the attribute.")]
		public tBasicTypeEnum bTypeEnum 
		{
			get { return this._btypeenum.bTypeEnum; }
			set {
				this._btypeenum.bTypeEnum = value;
				OnPropertyChanged ("bType");
			}
		}
		
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("AbstractDataAttribute"), Description("The basic type of the attribute.")]
		public string bType 
		{
			get 
			{
				return this._btypeenum.bType;
			}
			set 
			{
				this._btypeenum.bType = value;
				OnPropertyChanged ("bType");
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("AbstractDataAttribute"), Description("Determines how the value shall be interpreted if any is given.")]
		public tValKindEnum valKind 
		{
			get 
			{
				return this.valKindField;
			}
			set 
			{
				this.valKindField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("AbstractDataAttribute"), Description("It's used to refer to the appropriate enumeration type or DAType definition.")]
		public string type 
		{
			get
			{
				return this.typeField;
			}
			set 
			{
				this.typeField = value;
				OnPropertyChanged ("type");
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("AbstractDataAttribute"), Description("Shall state the number of array elements in the case where the attribute is an "+
			"array.")]
		public uint count 
		{
			get 
			{
				return this.countField;
			}
			set 
			{
				this.countField = value;
			}
		}
	}

}

