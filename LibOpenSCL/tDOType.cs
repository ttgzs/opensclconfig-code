// 
//  tDOType.cs
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
	 * The attribute "itemsField" was deleted to fulfill standar IEC 61850 Ed. 1.0:
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed. 1.0:
	 * SDO -> sDOField
	 * DA -> dAField
	 *
	 * Only one array of TSDI or TDAI elements should be choose. 
	 * When an element is selected, the "ADD" option must be hidden, so elements of another type could not be added. 
	 * This point is defined on the XSD files contained on the IEC 61850 standard, as follows:
	 * <xs:choice minOccurs="0" maxOccurs="unbounded">
	 *	<xs:element name="SDO" type="tSDO"/>
	 *	<xs:element name="DA" type="tDA"/>
	 * </xs:choice>
	 * 
	 * According to the Reference Manual of XML, "The <choice> option describes a selection between 
	 * some elements or an elements group that can show up on the instance of the XML document"
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tDOType : tIDNaming
	{
		private string iedTypeField;		
		private string cdcField;		
		private tSDO[] sDOField;		
		private tDA[] dAField;
		
		public tDOType()
		{
			this.iedTypeField = "";
		}
				
		[System.Xml.Serialization.XmlElementAttribute("SDO")]
		[Category("DOType"), Browsable(false)]
		public tSDO[] SDO
		{
			get
			{
				return this.sDOField; 
			}
			set
			{
				this.sDOField = value;
			}					
		}
	    
		[System.Xml.Serialization.XmlElementAttribute("DA")]
		[Category("DOType"), Browsable(false)]
	    public tDA[] DA
	    {
	        get
	        {
	      		return this.dAField;
	      	}
	        set
	        {
	        	this.dAField = value;
	        }
	    }
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("DOType"), Description("The type of the IED to which this DOType belongs.")]
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
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DOType"), Description("The basic Common Data Class.")]
		public string cdc
		{
			get 
			{
				return this.cdcField;
			}
			set
			{
				string t = value;
				if (t.Length != 3)
					return;
				this.cdcField = t.ToUpper ();
				OnPropertyChanged ("cdc");
			}
		}

		public int AddDA (tDA[] das)
		{
			int index = -1;
			if (DA == null && das != null) {
				for (int i = 0; i < das.Length; i++) {
					for (int j = 0; j < DA.Length; j++) {
						if (DA [j].name.Equals (das [i].name))
							return -1;
					}
				}
				index = this.dAField.Length;
				System.Array.Resize<tDA> (ref this.dAField,
				                                 this.dAField.Length + das.Length);
				for (int k = 0; k <  das.Length; k++) {
					this.dAField [k + index] = das [k];
				}
			} else {
				if (das != null) {
					dAField = new tDA[das.Length];
					das.CopyTo (dAField, 0);
				}
				else {
					var da = new tDA ();
					da.bTypeEnum = tBasicTypeEnum.VisString255;
					da.name = "TEMPLATE_ATTRIBUTE";
					da.fcEnum = tFCEnum.ST;
					da.dchg = true;
					dAField = new tDA[1];
					dAField[0] = da;
					index = 0;
				}
			}
			return index;
		}

		public int AddSDO (tSDO[] sdo)
		{
			int index = -1;
			if (DA == null && sdo != null) {
				for (int i = 0; i < sdo.Length; i++) {
					for (int j = 0; j < DA.Length; j++) {
						if (SDO[j].name.Equals (sdo[i].name))
							return -1;
					}
				}
				index = this.sDOField.Length;
				System.Array.Resize<tSDO> (ref this.sDOField,
				                                 this.sDOField.Length + sdo.Length);
				for (int k = 0; k <  sdo.Length; k++) {
					this.sDOField [k + index] = sdo [k];
				}
			} else {
				if (sdo != null) {
					sDOField = new tSDO[sdo.Length];
					sdo.CopyTo (dAField, 0);
				}
				else {
					var sd = new tSDO ();
					sd.type = "TEMPLATE.DOType";
					sd.name = "TEMPLATE_ATTRIBUTE_OBJECT";
					sDOField = new tSDO[1];
					sDOField[0] = sd;
					index = 0;
				}
			}
			return index;
		}
	}

}

