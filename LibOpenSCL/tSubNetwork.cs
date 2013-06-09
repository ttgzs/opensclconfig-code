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
using System.Net;

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
		private static int nip = 1;
		private System.Collections.Hashtable _connected_ied;
		private tBitRateInMbPerSec bitRateField;		
		private tConnectedAP[] connectedAPField;		
		private string typeField;
		private IPAddress ip;
		
		public tSubNetwork()
		{
			this.name = "SubNetwork" + ( ++ index ).ToString();
		}

		[System.Xml.Serialization.XmlIgnore]
		public SCL scl { get; set; }

		private System.Collections.Hashtable parse_private_ip ()
		{
			System.Collections.Hashtable h = new System.Collections.Hashtable ();
			if (Private != null) {
				// Parse from Private
				for (int i = 0; i < Private.Length; i++) {
					if (Private[i].type == "OpenSCL") {
						if (Private[i].source.Contains ("default.subnetwork.ipaddress/")) {
							string[] s = new string[1];
							s[0] = "/";
							var t = Private[i].source.Split (s, StringSplitOptions.None);
							System.Console.WriteLine ("IP element: "+ Private[i].source);
							h.Add (int.Parse(t[2]), int.Parse (t[3]));
						}
					}
				}
			} 
			return h;
		}

		[System.Xml.Serialization.XmlIgnore]
		public IPAddress ipaddress { 
			get {
				if (ip == null) {
					byte[] b = new byte[4];
					var h = parse_private_ip ();
					if (h.Count > 0) {
						b[0] = (byte) h[0];
						b[1] = (byte) h[1];
						b[2] = (byte) h[2];
						b[3] = (byte) h[3];
					} else {
						b[0] = 192;
						b[1] = 168;
						b[2] = 0;
						b[3] = 0;
					}
					ip = new IPAddress (b);
				}
				return ip;
			}
			set {
				ip = value;
				int index = AddPrivate (null);
				byte[] b = ip.GetAddressBytes ();
				for (int i = 0; i < b.Length; i++) {
					Private[index].source += "default.subnetwork.ipaddress/" + i + "/" + b[i].ToString ();
				}
			}
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
			if(aps == null)
				return false;
			
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

		[System.Xml.Serialization.XmlIgnore]
		public System.Collections.Hashtable connected_ied {
			get {
				if (_connected_ied == null)
					_connected_ied = new System.Collections.Hashtable ();
				if (scl != null) {
					if (ConnectedAP != null) {
						for (int i = 0; i < ConnectedAP.Length; i++) {
							int iedindex = scl.GetIED (ConnectedAP[i].iedName);
							if (iedindex >= 0) {
								int iap = scl.IED[iedindex].GetAP (ConnectedAP[i].apName);
								if (iap >= 0) {
									var cap = new ConnectedAPRef (scl,
									                              scl.Communication.GetSubNetwork (this.name),
									                              i, iedindex, iap);
									_connected_ied.Add (i, cap);
								}
							}
						}
					}
				}
				return _connected_ied;
			}
		}

		public string NextIP ()
		{
			var b = ip.GetAddressBytes ();
			b[b.Length-1] += (byte) nip;
			return ip.ToString ();
		}

		public string NetworkIP ()
		{
			return ip.ToString ();
		}

		public string LastIP ()
		{
			if (!(ip.IsIPv6LinkLocal || ip.IsIPv6Multicast || ip.IsIPv6SiteLocal)) {
				var b = ip.GetAddressBytes ();
				b[b.Length-1] = 254;
				var i = new IPAddress (b);
				return i.ToString ();
			}
			return "";
		}

	}

	public class ConnectedAPRef
	{
		private int cap_index;
		private int ied_index;
		private int ap_index;
		private int sn_index;

		public ConnectedAPRef (SCL scl, int subnetwork, int cap_index, int ied_index, int ap_index)
		{
			this.scl = scl;
			this.sn_index = subnetwork;
			this.cap_index = cap_index;
			this.ied_index = ied_index;
			this.ap_index = ap_index;
		}
		public SCL scl { get; set; }

		public bool valid {
			get {
				if (scl == null)
					return false;
				if (scl.Communication == null)
					return false;
				if (scl.Communication.SubNetwork == null)
					return false;
				if (sn_index < 0 ||
					scl.Communication.SubNetwork.Length < sn_index)
					return false;
				if (scl.Communication.SubNetwork [sn_index].ConnectedAP == null)
					return false;
				if (cap_index < 0 || 
					cap_index > scl.Communication.SubNetwork [sn_index].ConnectedAP.Length)
					return false;
				if (scl.IED == null)
					return false;
				if (ied_index < 0 || ied_index > scl.IED.Length)
					return false;
				if (scl.IED [ied_index].AccessPoint == null)
					return false;
				if (ap_index < 0 || ap_index > scl.IED [ied_index].AccessPoint.Length)
					return false;
				return true;
			}
		}

		public tConnectedAP connected_ap { 
			get {
				if (valid)
					return scl.Communication.SubNetwork [sn_index].ConnectedAP[cap_index];
				return null;
			}
		}
		public tIED ied { 
			get {
				if (valid)
					return scl.IED[ied_index];
				return null;
			}
		}
		public tAccessPoint ap { 
			get {
				if (valid)
					return ied.AccessPoint[ap_index];
				return null;
			}
		}
	}

}

