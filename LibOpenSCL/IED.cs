// OpenSCLConfigurator
//
// Copyright (C) 2009 Comisión Federal de Electricidad
// 
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 3
// of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

using System;
using IEC61850.SCL;

namespace OpenSCL
{
	
	/// <summary>
	/// This object represent a single IED in a SCD or CID files. 
	/// </summary>
	public class Device : Object
	{
		
		private tIED deviceConfigField;
		
		public string name {
			get {
				return this.ConfiguredDevices[0].name;
			}
			set {
				this.ConfiguredDevices[0].name = value;
			}
		}
		
		public string manufacturer {
			get {
				tIED ied =  this.ConfiguredDevices[0];
				return ied.manufacturer;
			}
			
			set {
				if (this.genericConfiguration) {
					this.ConfiguredDevices[0].manufacturer = value;
				}
				else {
					// FIXME: Rise an Exception
				}
			}
		}
		
		/// <value>
		/// 
		/// An IED's configuration (CID) just have one tIED object then allways access
		/// to the first element of the IEDs array
		/// </value>
		public string configVersion {
			get {
				return this.ConfiguredDevices[0].configVersion;
			}
			set {
				this.ConfiguredDevices[0].configVersion = value;
			}
		}
		
		public tP_IP ip {
			get {
				//FIXME: Search in SubNetwork this data
				tP_IP val = new tP_IP();
				return val;
			}
			set {
				
			}
		}
		
		public tP_VLANID vlan {
			get {
				//FIXME: Search in SubNetwork this data
				tP_VLANID val = new tP_VLANID();
				return val;
			}
			set {
				
			}
		}
		
		/// <summary>
		/// Creates a new IED with default values to get a generic configuration.
		/// </summary>
		public Device()
		{
			// FIXME: Set Values to Generic configuration
			//this.genericConfiguration = true;
						
			// FIXME: Add one Generic Logical Device
			// Setup a generic LN
			/*tLN ln = new tLN ();
			ln.lnClass = "XCBR";
			ln.inst = 1;
			ln.prefix = "Q0";
			*/
			// Setup a generic LD
			/*tLDevice ld = new tLDevice ();
			ld.ldName = "GENERIC";*/
			
			// Setup LN0 and LPHD
			/*ld.LN0 = new LN0();
			tLN lphd = new tLN();
			lphd.lnClass = "LPHD";*/
			
			// Add LNs to LD
			//ld.LN = new tLN[] { lphd, ln };
			
			// Create Access Points
			/*tAccessPoint acc = new tAccessPoint ();
			acc.Items = new tUnNaming[] { ld };
			acc.name = "1";
			tIED ied = new tIED ();
			ied.name = "XCBR";
			ied.type = "GENERIC";
			ied.AccessPoint = new tAccessPoint[] { acc };
			this.ConfiguredDevices = new tIED[] { ied };
			this.manufacturer = "GENERIC MANUFACTURER";
			this.configVersion = "0.1";
			this.ConfigurationVersion = "0.1";*/
		}
		
		/// <summary>
		/// Loads an CID or ICD XML file. Is invalid to load SCD files.
		/// </summary>
		/// <param name="filepath">
		/// A <see cref="System.String"/> with the path to the file to open.
		/// </param>
		public Device(string filepath)
		{
			this.Deserialize (filepath);
		}
		
		/// <summary>
		/// Loads an CID or ICD XML file.
		/// </summary>
		/// <param name="filePath">
		/// A <see cref="System.String"/> with the path to the file to open.
		/// </param>
		public void Open(string filePath)
		{
			this.Deserialize (filePath);
		}
		
		/// <summary>
		/// Saves this IED configuration to filePath.
		/// </summary>
		/// <param name="filePath">
		/// A <see cref="System.String"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Boolean"/>
		/// </returns>
		public bool Write(string filePath)
		{
			return this.Serialize (filePath);
		}
		
	}
}
