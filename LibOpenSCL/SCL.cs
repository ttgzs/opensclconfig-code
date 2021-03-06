// LibOpenSCL
//
// Copyright (C) 2009 Comisión Federal de Electricidad
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 3 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 
/*
 * It contains all the classes and methods that were generated from XSD file of the 
 * standard IEC 61850 Ed. 1.0-6 Edition 1.0
*/ 

using System.ComponentModel;

namespace IEC61850.SCL
{
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	public partial class SCL : tBaseElement 
	{		
		private static int nied = 0;
		private static int nsub = 0;
		private tHeader headerField;		
		private tSubstation[] substationField;		
		private tCommunication communicationField;		
		private tIED[] iEDField;		
		private tDataTypeTemplates dataTypeTemplatesField;
		
		public SCL()
		{
			this.Header = new tHeader();
		}
		
		[Category("SCL"), Description("The header serves to identify an SCL configuration file and its version, and to specify options "+
			"for the mapping of names to signals."), Browsable(false)]
		public tHeader Header 
		{
			get 
			{
				return this.headerField;
			}
			set
			{
				this.headerField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("Substation")]
		[Category("SCL"), Browsable(false)]
		public tSubstation[] Substation 
		{
			get 
			{
				return this.substationField;
			}
			set 
			{
				this.substationField = value;
			}
		}
		
		[Category("SCL"), Description("It models the logically possible connections between IEDs at and across subnetworks "+ 
			"by means of access points"), Browsable(false)]	
		public tCommunication Communication 
		{
			get
			{
				return this.communicationField;
			}
			set 
			{
				this.communicationField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("IED")]
		[Category("SCL"), Browsable(false)]		
		public tIED[] IED
		{
			get
			{
				return this.iEDField;
			}
			set 
			{
				this.iEDField = value;
			}
		}
		
		[Category("SCL"), Description("Defines instantiable logical node types."), Browsable(false)]
		public tDataTypeTemplates DataTypeTemplates
		{
			get 
			{
				return this.dataTypeTemplatesField;
			}
			set 
			{
				this.dataTypeTemplatesField = value;
			}
		}
		
		/// <summary>
		/// Get the IED index with the given name. 
		/// </summary>
		/// <param name="iedName">
		/// A <see cref="System.String"/> with the IED to search.
		/// </param>
		/// <returns>
		/// A <see cref="System.Int32"/> with the index of the found IED or -1 on not found.
		/// </returns>
		public int GetIED (string iedName) {
			if (this.iEDField == null)
				return -1;
			if (iedName.Equals(null))
				return -1;
			
			int pos = -1;
			for (int i = 0; i < this.iEDField.GetLength(0); i++) {
				if (this.iEDField[i].name.Equals(iedName)) {
					pos = i;
					break;
				}
			}			
			return pos;
		}
		
		
		/// <summary>
		/// Adds all IEDs configured on conf parameter, including its templates, communications
		/// and history. Ignores any IED and templates already configured.
		/// </summary>
		/// <param name="conf">
		/// A <see cref="SCL"/> a configuration with IEDs, templates, communications and history.
		/// </param>
		/// <returns>
		/// A <see cref="System.Collections.Generic.List<tIED>"/>, with all ignored IEDs.
		/// </returns>
		public System.Collections.Generic.List<tIED> 
			ImportIED (SCL conf)
		{
			if(conf==null)
				return null;
			if(conf.IED == null)
				return null;
			string now = System.DateTime.Now.ToString();
			
			// Add Types, if one template already exist it is ignored
			if (conf.DataTypeTemplates != null) {
				this.DataTypeTemplates.AddLNodeTypeArray (conf.DataTypeTemplates.LNodeType);
				this.DataTypeTemplates.AddDOType (conf.DataTypeTemplates.DOType);
				this.DataTypeTemplates.AddDAType (conf.DataTypeTemplates.DAType);
				this.DataTypeTemplates.AddEnumType (conf.DataTypeTemplates.EnumType);
			}
			
			// Subnetworks
			
			if(this.Communication != null) {
				if(this.Communication.SubNetwork != null) {
					if(conf.Communication != null)
						this.Communication.AddSubNetworkArray (conf.Communication.SubNetwork);
				}
				else
					this.Communication.SubNetwork = conf.Communication.SubNetwork;
			}
			else
				this.Communication = conf.Communication;
			
			
			// Add IEDs, only new IED are added, if not, they are ignored
			System.Collections.Generic.List<tIED> ignored = this.AddIED(conf.IED, conf.Header.version, conf.Header.revision);
			
			// Update Revision number due to IEDs added
			this.Header.UpdateRevision();
			// History items
			if(this.Header != null) {
				if(this.Header.History != null){
					if(conf.Header != null) {
						if(conf.Header.History != null) {
							if (conf.Header.History.Length > 0) {
								if (conf.Header.History[0] != null) {							
									string why = "[ImpSC;Strc:" + conf.Header.nameStructure +
						 				";id:" + conf.Header.id 
										+ ";V:" + conf.Header.version 
										+ ";R:" + conf.Header.revision + "]";
									this.Header.AddHistoryItem(conf.Header.History, why);
								}
							}
						}
					}
				}
			}
			else
				this.Header = conf.Header;
			
			return ignored;
		}
		
		
		private System.Collections.Generic.List<tIED> AddIED(tIED[] array, string iedVersion, string iedRevision) {
			if(array==null)
				return null;
			
			System.Collections.Generic.List<tIED> ignored;
			System.Collections.ArrayList toadd;
			
			ignored = new System.Collections.Generic.List<tIED>();
			toadd = new System.Collections.ArrayList();
			if (this.iEDField != null) {
				for (int i = 0; i < array.Length; i++) {
					int j = this.GetIED(array[i].name);
					if(j >= 0) {
						ignored.Add(array[i]);
						continue;
					}
					else
						toadd.Add(array[i]);
				}
				int index = this.iEDField.Length;
				System.Array.Resize<tIED>(ref this.iEDField,
				                                 this.iEDField.Length + toadd.Count);
				// Setup History items to add
				this.Header.UpdateRevision();
				tHitem item = new tHitem();
				item.version = this.Header.version;
				item.revision = this.Header.revision;
				item.what = "Configured IEDs";
				string why = " [ConfVer:"+ iedVersion
							+ " ConfRev:" + iedRevision;
				for (int i = 0; i <  toadd.Count; i++) {
					// Set value and item to add
					this.iEDField[i+index] = (tIED) toadd[i];
					item.why = "Added IED: " + this.iEDField[i+index].name + why;
					this.Header.AddHistoryItem(item);
				}
			}
			else {
				this.iEDField = (tIED[]) toadd.ToArray();
			}
			return ignored;
		}

		public int AddIED (string name)
		{
			int index = -1;
			if (dataTypeTemplatesField == null)
				dataTypeTemplatesField = new tDataTypeTemplates ();
			int i;

			tIED ied = new tIED ();
			if (name == null) {
				i = GetIED ("TEMPLATE");
				if (i >= 0)
					SCL.nied++;
				string n = "";
				if (SCL.nied == 0)
					SCL.nied++;
				else
					n += (SCL.nied++).ToString ();
				ied.name = "TEMPLATE" + n;
			} else {
				i = GetIED (name);
				if (i >= 0)
					return -1;
				ied.name = name;
			}

			ied.configVersion = "0";
			int iap = ied.AddAP (null);
			ied.AddLDevice (null, ied.AccessPoint[iap].name, this.DataTypeTemplates);
			
			if (iEDField == null) {
				iEDField = new tIED[1];
				iEDField [0] = ied;
				index = 0;
			} else {
				System.Array.Resize<tIED> (ref this.iEDField,
				                                  this.iEDField.GetLength (0) + 1);
				index = this.iEDField.GetLength (0) - 1;
				this.iEDField [index] = ied;
			}
			return index;
		}

		public System.Collections.Hashtable GetGSE (string iedname, string apname, string ldinst, string gsecname)
		{
			var h = new System.Collections.Hashtable();
			if (this.Communication == null)
				return h;
			if (this.Communication.SubNetwork == null)
				return h;
			
			for (int i = 0; i < this.Communication.SubNetwork.Length; i++)
			{
				tSubNetwork s = this.Communication.SubNetwork[i];
				if (s.ConnectedAP == null)
					return h;
				for (int c = 0; c < s.ConnectedAP.Length; c++) {
					tConnectedAP cap = s.ConnectedAP[c];
					if (cap.iedName.Equals (iedname)
					    && cap.apName.Equals (apname)) 
					{
						if (cap.GSE == null)
							return h;
						for (int g = 0; g < cap.GSE.Length; g++) 
						{
							tGSE gse = cap.GSE[g];
							if (gse.cbName.Equals (gsecname) 
							    && gse.ldInst.Equals (ldinst)) 
							{
								h.Add ("gse", gse);
								h.Add ("subnetwork", s);
								h.Add ("connectedap", cap);
								return h;
							}
						}
					}
				}
			}
			return h;
		}

		public int AddSubnetwork (string name)
		{
			if (Communication == null) {
				Communication = new tCommunication ();
			}
			return Communication.AddSubNetwork (null);
		}

		public int AddSubstation (string name)
		{
			tSubstation s = new tSubstation ();

			if (name == null) {
				s.name = "TEMPLATE_SUBSTATION" + nsub++;
			} else
				s.name = name;
			// Voltage 23 kV
			s.VoltageLevel = new tVoltageLevel[1];
			s.VoltageLevel[0].name = "TEMPLATE_VOLTAGE_LEVEL";
			s.VoltageLevel[0].Voltage = new tVoltage ();
			s.VoltageLevel[0].Voltage.unit = tSIUnitEnum.V;
			s.VoltageLevel[0].Voltage.multiplier = tUnitMultiplierEnum.k;
			s.VoltageLevel[0].Voltage.Value = 23;
			var lowbays = s.VoltageLevel[0].Bay = new tBay[1];
			lowbays[0].name = "4000";
			var cb = s.VoltageLevel[0].Bay[0].ConductingEquipment = new tConductingEquipment[1];
			var cn = s.VoltageLevel[0].Bay[0].ConnectivityNode = new tConnectivityNode [2];
			cb[0].typeEnum = tCommonConductingEquipmentEnum.CBR;
			cb[0].Terminal = new tTerminal[2];
			// Defined 2 terminals with no connection
			cb[0].Terminal[0].substationName = s.name;
			cb[0].Terminal[0].voltageLevelName = s.VoltageLevel[0].name;
			cb[0].Terminal[0].bayName = lowbays[0].name;
			cb[0].Terminal[0].name = "C1";
			cb[0].Terminal[1].substationName = s.name;
			cb[0].Terminal[1].voltageLevelName = s.VoltageLevel[0].name;
			cb[0].Terminal[1].bayName = lowbays[0].name;
			cb[0].Terminal[1].name = "C2";

			if (Substation == null) {
				Substation = new tSubstation[1];
				Substation [0] = s;
				return 0;
			}
			int i = substationField.Length;
			System.Array.Resize<tSubstation>(ref this.substationField,
				                                 this.substationField.Length + 1);
			substationField[i] = s;
			return i;
		}
	}
}
