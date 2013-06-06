// 
//  tDAType.cs
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
	public partial class tDAType : tIDNaming 
	{
		private static int nattr = 0;
		private tBDA[] bDAField;		
		private string iedTypeField;
		
		public tDAType()
		{
			this.iedTypeField = "";
		}
		
		[System.Xml.Serialization.XmlElementAttribute("BDA")]
		[Category("DAType"), Browsable(false)]
		public tBDA[] BDA 
		{
			get
			{
				return this.bDAField;
			}
			set 
			{
				this.bDAField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]	
		[Category("DAType"), Description("it is used to define the relation of a specific LN type to an IED type.")]
		public string iedType
		{
			get 
			{
				return this.iedTypeField;
			}
			set 
			{
				this.iedTypeField = value;
				OnPropertyChanged ("iedType");
			}
		}

		public int AddBasicAttribute (tBDA ba)
		{
			tBDA bda = new tBDA ();
			if (ba == null) {
				bda.name = "TEMPLATE_ATTRIBUTE" + tDAType.nattr++;
				bda.bTypeEnum = tBasicTypeEnum.VisString255;
			} else
				bda = ba;

			if (bDAField == null) {
				bDAField = new tBDA[1];
				bDAField [0] = bda;
				return 0;
			} else {
				int index = this.bDAField.Length;
				System.Array.Resize<tBDA> (ref this.bDAField,
					                                 this.bDAField.Length + 1);
				this.bDAField [index] = bda;
				return index;
			}
		}

		// All attributes with a name already used by other attribute in DBA will be ignored.
		public int AddBasicAttributeArray (tBDA[] ba)
		{
			if (bDAField == null) {
				bDAField = new tBDA[ba.Length];
				ba.CopyTo (bDAField, 0);
				return 0;
			} else {
				int index = -1;
				for (int i = 0; i < ba.Length; i++) {
					int p = GetAttribute (ba[i].name);
					if (p < 0) {
						index = AddBasicAttribute (ba[i]);
					}
				}
				return index;
			}
		}

		public int GetAttribute (string name)
		{
			if (name == null) return -1;

			for (int j=0; j < bDAField.Length; j++) {
				if (bDAField[j].name.Equals (name))
					return j;
			}
			return -1;
		}
	}

}

