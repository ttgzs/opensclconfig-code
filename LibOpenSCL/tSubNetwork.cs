// 
//  tSubNetwork.cs
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
	public partial class tSubNetwork : tNaming 
	{		
		private static int index = 0;
		private tBitRateInMbPerSec bitRateField;		
		private tConnectedAP[] connectedAPField;		
		private string typeField;
		
		public tSubNetwork()
		{
			this.name = "SubNetwork" + ( ++ index ).ToString();
		}
		
		[Category("SubNetwork"), Description("Defining the bit rate in Mbit/s."), Browsable(false)]	
		public tBitRateInMbPerSec BitRate 
		{
			get
			{
				return this.bitRateField;
			}
			set 
			{
				this.bitRateField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("ConnectedAP")]
		[Category("SubNetwork"), Browsable(false)]
		public tConnectedAP[] ConnectedAP 
		{
			get 
			{
				return this.connectedAPField;
			}
			set
			{
				this.connectedAPField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("SubNetwork"), Description("The SubNetwork protocol type.")]
		public string type 
		{
			get
			{
				return this.typeField;
			}
			set
			{
				this.typeField = value;
			}
		}
		
		/// <summary>
		/// Add a new Connected Access Point to a Subnetwork. 
		/// </summary>
		/// <param name="ied">
		/// A <see cref="tIED"/> object with the IED to connect to this subnetwork.
		/// </param>
		/// <param name="ap">
		/// A <see cref="System.Int32"/> with the index of the Access Point in the IED to connect to
		/// this subnetwork.
		/// </param>
		/// <param name="addr">
		/// A <see cref="tAddress"/> object to set Connected Access Point's address of the IED to
		/// connect to this network.
		/// </param>
		/// <param name="desc">
		/// A <see cref="System.String"/> with the description of the new Connected Access Point.
		/// </param>
		/// <returns>
		/// A <see cref="System.Int32"/>, with the index of Connected Access Point added, -1 on error.
		/// </returns>
		public int AddConnectedAP(tIED ied, int apIndex, tAddress addr, string desc) {
			if(ied == null || addr == null || apIndex < 0 || apIndex > ied.AccessPoint.GetLength(0)) 
				return -1;
			
			tConnectedAP ap = new tConnectedAP();
			ap.Address = addr;
			ap.desc = desc;
			ap.iedName = ied.name;
			ap.apName = ied.AccessPoint[apIndex].name;
			
			if (this.connectedAPField == null) {
				this.connectedAPField = new tConnectedAP[1];
				this.connectedAPField[0] = ap;
				return 0;
			}
			return this.AddConnectedAP(ap);
		}
		
		public int AddConnectedAP(tConnectedAP ap) {
			int index = -1;
			if (this.connectedAPField != null) {
				try {
					System.Array.Resize<tConnectedAP>(ref this.connectedAPField, 
					                              this.connectedAPField.Length + 1);
					index = this.connectedAPField.Length - 1;
				}
				catch {
					return -1;
				}
			}
			else {
				this.connectedAPField = new tConnectedAP[1];
				index = 0;
			}			
			this.connectedAPField[index] = ap;
			return index;
		}
		
		public bool AddConnectedAP(tConnectedAP[] aps) {
			if (this.connectedAPField != null) {
				try {
					int index = this.connectedAPField.Length;
					System.Array.Resize<tConnectedAP>(ref this.connectedAPField,
					                                 this.connectedAPField.Length + aps.Length);
					for (int i = 0; i <  aps.Length; i++) {
						this.connectedAPField[i+index] = aps[i];
					}
				}
				catch {
					return false;
				}
			}
			else {
				aps.CopyTo(this.connectedAPField, 0);
			}
			return true;
		}
	}

}

