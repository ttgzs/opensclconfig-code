// 
//  tConnectedAP.cs
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
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tConnectedAP : tUnNaming 
	{		
		private tAddress addressField;		
		private tGSE[] gSEField;		
		private tSMV[] sMVField;		
		private tPhysConn[] physConnField;		
		private string iedNameField;		
		private string apNameField;
		
		public tConnectedAP () {}
		
		public tConnectedAP (tIED ied, int ap, tAddress addr) {
			this.iedNameField = ied.name;
			this.apName = ied.AccessPoint[ap].name;
			this.addressField = addr;
		}
		
		[Category("ConnectedAP"), Description("The Address element contains the address parameters of this access point at this bus."), Browsable(false)]
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
						
		[System.Xml.Serialization.XmlElementAttribute("GSE")]
		[Category("ConnectedAP"), Browsable(false)]
		public tGSE[] GSE
		{
			get
			{
				return this.gSEField;
			}
			set
			{
				this.gSEField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("SMV")]
		[Category("ConnectedAP"), Browsable(false)]
		public tSMV[] SMV 
		{
			get
			{
				return this.sMVField;
			}
			set
			{
				this.sMVField = value;
			}
		}
				
		[System.Xml.Serialization.XmlElementAttribute("PhysConn")]		
		[Category("ConnectedAP"), Browsable(false)]
		public tPhysConn[] PhysConn 
		{
			get 
			{
				return this.physConnField;
			}
			set
			{
				this.physConnField = value;
			}
		}

		[Required]
		[Category("ConnectedAP"), Description("A name identifying the IED."), ReadOnly(true)]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]		
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
		
		[Required]
		[Category("ConnectedAP"), Description("A name identifying this access point within the IED")]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString"), ReadOnly(true)]		
		public string apName 
		{
			get 
			{
				return this.apNameField;
			}
			set
			{
				// FIXME: Must search for this object before to set its value to verify it exists
				this.apNameField = value;
			}
		}
		
		public int AddGSE (tGSE gse) {
			int index = -1;
			if (this.gSEField != null) {
				System.Array.Resize<tGSE>(ref this.gSEField,
				                                 this.gSEField.Length + 1);
				
				index = this.gSEField.Length - 1;
			}
			else {
				this.gSEField = new tGSE[1];
				index = 0;
			}
			this.gSEField[index] = gse;
			return index;
		}
	}

}

