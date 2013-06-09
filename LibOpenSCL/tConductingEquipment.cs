// 
//  tConductingEquipment.cs
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
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]		
	public partial class tConductingEquipment : tAbstractConductingEquipment 
	{		
		private string _type;
		private tCommonConductingEquipmentEnum _type_enum;
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Required]
		[Category("ConductingEquipment"), Description("Type of Conducting Equipment.")]
		public string type 
		{
			get
			{
				return this._type;
			}
			set 
			{
				this._type = value;
				if(System.Enum.IsDefined(typeof(tCommonConductingEquipmentEnum), _type))
				{
					this.typeEnum = (tCommonConductingEquipmentEnum) 
								System.Enum.Parse(typeof(tCommonConductingEquipmentEnum), _type);
				}
				else
				{
					this.typeEnum = tCommonConductingEquipmentEnum.EXT;
				}
			}
		}

		[System.Xml.Serialization.XmlIgnore]
		public tCommonConductingEquipmentEnum typeEnum {
			get {
				return _type_enum;
			}
			set {
				_type_enum = value;
				if(this._type_enum!=tCommonConductingEquipmentEnum.EXT)
				{
					this._type = this._type_enum.ToString();
				}
			}

		}
	}
}

