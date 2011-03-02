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

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using IEC61850.SCL;

namespace OpenSCL
{	
	public struct IEDConnectedAP {
		int i;
		int a;
		int s;
		int c;
		public IEDConnectedAP (int i, int a, int s, int c)
		{
			this.i = i;
			this.a = a;
			this.s = s;
			this.c = c;
		}
		public int ied {
			set { i = value; }
			get { return i;}
		}
		public int ap {
			set { a = value; }
			get { return a; }
		}
		public int subnetwork {
			set { s = value; }
			get { return s; }
		}
		public int connectedap {
			set { c = value;}
			get { return c; }
		}
	}
	
	/// <summary>
	/// This class uses functions that involve an XML File.
	/// </summary>
	public class Object
	{
		// An Errors List that occurs when a serialization or deserialization is 
		// executed.
		List<ErrorsManagement> ListErrors;
		private ObjectManagement objectManagement;
		private SCL configuration;
		private string filename;
		
		// FIXME: It returns a TRUE value if the configuration is generic, 
		// if it's loaded from CID or ICD this must be set to FALSE.
		protected bool genericConfiguration;
		
		public string id 
		{
			get 
			{
				return this.configuration.Header.id;
			}
			set 
			{
				this.configuration.Header.id = value;
			}
		}
		
		public bool HaveRevisionInformation()
		{
			if (this.configuration.Header != null)
				return true;
			else
				return false;
		}
		
		public IEC61850.SCL.tHitem[] RevisionHistory 
		{
			get 
			{
				if (this.configuration.Header.History != null)
					return this.configuration.Header.History;
				else
					return null;
			}
			set 
			{
				this.configuration.Header.History = value;
			}
		}
		
		public bool AppendHistoryItem (string version, string revision, 
		                           string when, string who, 
		                           string what, string why)
		{
			if (this.RevisionHistory != null)
			{
				System.Collections.ArrayList history = 
						(System.Collections.ArrayList) this.RevisionHistory.GetEnumerator();
				tHitem item = new tHitem();
				
				item.version = version;
				item.revision = revision;
				item.when = when;
				item.what = what;
				item.who = who;
				item.why = why;
				
				history.Add(item);
				
				return true;
			}
			
			return false;
		}
		
			
		public string FileName 
		{
			get 
			{
				return this.filename;
			}
			set 
			{
				this.Deserialize (value);
				this.filename = value;
			}
		}
		
		public string Description 
		{
			get 
			{
				if(this.configuration.Header.Text != null)
					return this.configuration.Header.Text.source;
				else
					return null;
			}
			set 
			{
				if(this.configuration.Header.Text != null)
					this.configuration.Header.Text.source = value;
			}
		}

		/// <summary>
   		/// FIXME: It returns a configuration of an IED according to an XML file.
   		/// </summary>
		public tIED[] Devices 
		{
			get 
			{
				return this.configuration.IED;
			}
			set 
			{
				this.configuration.IED = value;
			}
		}
		
   		/// <summary>
   		/// It returns an SCL object.
   		/// </summary>
		public SCL Configuration 
		{
			get 
			{
				return this.configuration;
			}
			set 
			{
				this.configuration = value;
			}
		}
		
   		/// <summary>
   		/// It returns the value of the attribute "ConfigurationVersion" 
   		/// that belongs to the SCL file's Header.
   		/// </summary>
		public string Version 
		{
			get 
			{
				if (this.configuration.Header != null)
					return this.configuration.Header.version;
				else 
					return null;
			}
			set 
			{
				if (this.configuration.Header != null)
					this.configuration.Header.version = value;
				else
				{
					this.configuration.Header = new tHeader();
					this.configuration.Header.version = value;
				}
			}
		}
		
   		/// <summary>
   		/// It returns the value of the attribute "ConfigurationRevision" 
   		/// that belongs to the Header of an XML file.
   		/// </summary>
		public string Revision 
		{
			get 
			{
				if(this.configuration.Header != null)
					return this.configuration.Header.revision;
				else
					return null;
			}
			set 
			{
				if (this.configuration.Header != null)
					this.configuration.Header.revision = value;
				else
				{
					this.configuration.Header = new tHeader();
					this.configuration.Header.revision = value;
				}
			}
		}
		
		public Object()
		{
			this.ListErrors = new List<ErrorsManagement>();
			this.objectManagement = new ObjectManagement();
		}
		
		public Object(string filepath)
		{
			this.ListErrors = new List<ErrorsManagement>();
			this.objectManagement = new ObjectManagement();
			this.filename = filepath;
			this.Deserialize (filepath);
		}
		
		public bool IsSCD ()
		{
			if (this.Devices.GetLength(0) > 1)
				return true;
			else
				return false;
		}
		
		public bool Serialize()
		{
			return this.Serialize(this.filename);
		}
		
   		/// <summary>
   		/// This method creates an XML file using a serialize function.
   		/// </summary>
   		/// <param name="nameFileXML">
   		/// Name of the XML File, including directory where is located the file.
   		/// </param>
   		/// <remarks>
   		/// The directory shall exist, and the name file shouldn't exist. 		
   		///  </remarks>
		public bool Serialize(string nameFileXML)
		{         	        	
        	XmlSerializer serializer = new XmlSerializer(typeof(SCL));
        	TextWriter writer = new StreamWriter(nameFileXML);       	        	       	
        	serializer.Serialize(writer, this.configuration);
        	writer.Dispose();
			this.filename = nameFileXML;
			return true;
   		}
		
   		/// <summary>
   		/// This method gets the information of an XML file and sets to SCL objects 
   		/// using the deserialize function.
   		/// </summary>
   		/// <param name="nameFileXML">
   		/// Name of the XML File, including directory where is located the file.
   		/// </param>
   		/// <returns>
   		/// If an attribute or a node is unknown then a list of error is returned.
   		/// </returns>
   		/// <remarks>
   		/// The directory and the XML File shall exist.
   		/// </remarks>
   		//public List<ErrorsManagement> Deserialize(string nameFileXML)
   		public bool Deserialize()
		{
			this.Deserialize(this.filename);
			return true; // API Change required
		}
			
		public void Deserialize(string nameFileXML)
		{
			XmlSerializer XS = new XmlSerializer(typeof(SCL));
    	   	XS.UnknownNode+= new XmlNodeEventHandler(UnknownNode);
           	XS.UnknownAttribute+= new XmlAttributeEventHandler(UnknownAttribute);        
           	FileStream fs = File.OpenRead(nameFileXML);         	
            this.configuration =(SCL) XS.Deserialize(fs);
			this.filename = nameFileXML;
            fs.Dispose();           
		}   		 		   		
   		
		
		
		
		// IED Related functions
		
		// DEPRECATED not use on new code
		/// <summary>
		/// This method imports an ICD or CID file to the project file.
		/// </summary>
		/// <param name="objectSCLProject">
		/// SCL object of the project file.
		/// </param>
		/// <param name="objectSCLToImport">
		/// SCL object created using the deserializer method on the ICD or CID file of the IED to import.
		/// </param>
		/// <returns>
		/// The SCL object of the IED imported.
		/// </returns>
		public SCL ImportIED(SCL project, SCL import)
		{
			project.AddIED(import);
			// FIXME: Review why to return the import and not the new modified configuration
			return import;
		}
		
		public int GetIED (string iedName)
		{
			if (this.Devices == null)
				return -1;
			if (iedName.Equals(null))
				return -1;
			
			int pos = -1;
			for (int i = 0; i < this.Devices.GetLength(0); i++) {
				if (this.Devices[i].name.Equals(iedName)) {
					pos = i;
					break;
				}
			}			
			return pos;
		}
		
		public IEC61850.SCL.tIED GetIED (int iedIndex)
		{
			if (this.Devices == null)
				return null;
			if (iedIndex < 0 || iedIndex > this.Devices.GetLength(0))
				return null;
			
			return Devices[iedIndex];
		}
		
		// Access Point related functions
		
		public int GetAP (int iedIndex, string name)
		{
			int pos = -1;
			for (int i = 0; i < Devices[iedIndex].AccessPoint.GetLength(0); i++) {
				if (Devices[iedIndex].AccessPoint[i].name.Equals(name))
				{
					pos = i;
					break;
				}
			}			
			return pos;
		}
		
		public IEC61850.SCL.tAccessPoint[] GetAP (string iedName)
		{
			if (this.Devices == null)
				return null;
			int ied = GetIED(iedName);
			if (ied < 0)
				return null;
			else
				return Devices[ied].AccessPoint;
		}
		
		public IEC61850.SCL.tAccessPoint[] GetAP (int iedIndex)
		{
			if (this.GetIED(iedIndex) == null)
				return null;
			return Devices[iedIndex].AccessPoint;
		}
		
		public IEC61850.SCL.tAccessPoint GetAP (string iedName, string apName)
		{
			int ied = GetIED(iedName);
			int ap = GetAP(ied, apName);
			return Devices[ied].AccessPoint[ap];
		}
		
		public IEC61850.SCL.tAccessPoint GetAP (int iedIndex, int apIndex)
		{
			if (iedIndex < 0)
				return null;
			if (apIndex < 0)
				return null;
			
			if (this.Devices == null)
				return null;
			if (iedIndex > this.Devices.GetLength(0))
				return null;
			if (apIndex > this.Devices[iedIndex].AccessPoint.GetLength(0))
				return null;
			
			return this.Devices[iedIndex].AccessPoint[apIndex];
		}
		
		// LogicalDevices Related methods
		
		public IEC61850.SCL.tLDevice[] GetLD (string iedName, string apName)
		{
			int ied = this.GetIED(iedName);
			int ap = this.GetAP(ied, apName);
			
			if (ied < 0 || ied > Devices.GetLength(0) 
			    || ap < 0 || ap > Devices.GetLength(0))
				return null;
			
			return Devices[ied].AccessPoint[ap].Server.LDevice;
		}
		
		public IEC61850.SCL.tLDevice[] GetLD (int iedIndex, int apIndex)
		{
			if (iedIndex < 0 || iedIndex > Devices.GetLength(0) 
			    || apIndex < 0 || apIndex > Devices.GetLength(0))
				return null;
			
			return Devices[iedIndex].AccessPoint[apIndex].Server.LDevice;
		}
		
		public IEC61850.SCL.tLDevice[] GetLD (int iedIndex)
		{
			if (this.Devices == null)
				return null;
			if (iedIndex < 0 || iedIndex > Devices.GetLength(0))
				return null;
			if (Devices[iedIndex].AccessPoint == null)
				return null;
			
			if (Devices[iedIndex].AccessPoint.GetLength(0) == 1)
				return Devices[iedIndex].AccessPoint[0].Server.LDevice;
			else
				return null;
		}
		
		public IEC61850.SCL.tLDevice[] GetLD (string iedName)
		{
			int ied = GetIED(iedName);
			
			return this.GetLD(ied);
		}
		
		/// <summary>
		/// Get an  
		/// </summary>
		/// <param name="iedName">
		/// A <see cref="System.String"/>
		/// </param>
		/// <param name="ldname">
		/// A <see cref="System.String"/>
		/// </param>
		/// <returns>
		/// A <see cref="IEC61850.SCL.tLDevice[]"/>
		/// </returns>
		public IEC61850.SCL.tLDevice GetLD (IEC61850.SCL.tIED ied, string ldinst)
		{
			if (ldinst == null)
				return null;
			
			if (ied == null)
				return null;
			
			if (ied.AccessPoint == null)
				return null;
			
			IEC61850.SCL.tLDevice ldevice = null;
			int found = 0;
			for (int i = 0; i < ied.AccessPoint.GetLength(0); i++) {
				for (int j = 0; j < ied.AccessPoint[i].Server.LDevice.GetLength(0);
				     j++) {
					if (ied.AccessPoint[i].Server.LDevice[j].inst.Equals (ldinst)) {
						ldevice = ied.AccessPoint[i].Server.LDevice[j];
						found++;
					}
				}
			}
			if (found == 1)
				return ldevice;
			else
				return null;
		}
		
		public IEC61850.SCL.tLDevice GetLD (int iedIndex, int apIndex, int ldIndex)
		{
			if (Devices == null)
				return null;
			if (iedIndex < 0 || iedIndex > Devices.GetLength(0))
				return null;
			
			if (Devices[iedIndex].AccessPoint == null)
				return null;
			if (apIndex < 0 || apIndex > Devices[iedIndex].AccessPoint.GetLength(0))
				return null;
			
			if (Devices[iedIndex].AccessPoint[apIndex].Server == null)
				return null;
			if (Devices[iedIndex].AccessPoint[apIndex].Server.LDevice == null)
				return null;
			if (ldIndex < 0 
			    || ldIndex > Devices[iedIndex].AccessPoint[apIndex].Server.LDevice.GetLength(0))
				return null;
			
			return Devices[iedIndex].AccessPoint[apIndex].Server.LDevice[ldIndex];
		}
		
		/// <summary>
		/// Gets the Index of Logical Device named "name". LD's name must have an "InstanceLDName",
		/// structure first the LD instance and then  LD name.
		/// </summary>
		/// <param name="iedIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="apIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="ldInst">
		/// A <see cref="System.String"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Int32"/>
		/// </returns>
		private int GetLD (int iedIndex, int apIndex, string ldInst)
		{
			if (ldInst == null)
				return -1;
			if (Devices == null)
				return -1;
			if (iedIndex < 0 || iedIndex > Devices.GetLength(0))
				return -1;
			
			if (Devices[iedIndex].AccessPoint == null)
				return -1;
			if (apIndex < 0 || apIndex > Devices[iedIndex].AccessPoint.GetLength(0))
				return -1;
			
			if (Devices[iedIndex].AccessPoint[apIndex].Server == null)
				return -1;
			if (Devices[iedIndex].AccessPoint[apIndex].Server.LDevice == null)
				return -1;
			
			int pos = -1;
			for (int i = 0; i < Devices[iedIndex].AccessPoint[apIndex].Server.LDevice.GetLength(0); i++) {
				string ldinst = Devices[iedIndex].AccessPoint[apIndex].Server.LDevice[i].inst;
				if (ldinst.Equals(ldInst))
				{
					pos = i;
					break;
				}
			}			
			return pos;
		}
		
		
			
		// Communications
		
		public tSubNetwork[] Subnetworks
		{
			get {
				return this.configuration.Communication.SubNetwork;
			}
			
			set {
				this.configuration.Communication.SubNetwork = value;
			}
		}
		
		public int GetSubnetwork (string name)
		{
			if (this.configuration.Communication == null)
				return -1;
			if (this.configuration.Communication.SubNetwork == null)
				return -1;
			int pos = -1;
			for (int i = 0; i < this.configuration.Communication.SubNetwork.GetLength(0); i++)
			{
				if ( this.configuration.Communication.SubNetwork[i].name.Equals(name))
				{
					pos = i;
					break;
				}
			}
			
			return pos;
		}
		
		public tConnectedAP GetConnectedAP (int subnetIndex, int connectedapIndex)
		{
			if(subnetIndex < 0)
				return null;
			if (connectedapIndex < 0)
				return null;		
			if(this.Subnetworks == null)
				return null;
			if(subnetIndex > this.Subnetworks.GetLength(0))
				return null;
			if(this.Subnetworks[subnetIndex].ConnectedAP == null)
				return null;
			if(connectedapIndex > this.Subnetworks[subnetIndex].ConnectedAP.GetLength(0))
				return null;
			
			return this.Subnetworks[subnetIndex].ConnectedAP[connectedapIndex];
			
		}
		
		
		// DEPRECATED use tConnectedAP GetConnectedAP (int subnetIndex, int connectedapIndex)
		public tConnectedAP GetIEDConnectedAP (int subnetIndex, int connectedapIndex)
		{
			return this.GetConnectedAP(subnetIndex, connectedapIndex);			
		}
			
		public  System.Collections.ArrayList
			GetIEDConnectedAP (string iedName)
		{
			if (iedName.Equals(null))
				return null;
			
			return this.GetIEDConnectedAP (iedName);
		}
		
		public System.Collections.ArrayList 
			GetIEDConnectedAP (int iedIndex)
		{
			if (this.configuration.Communication == null)
			    return null;
			if (this.configuration.Communication.SubNetwork == null)
				return null;
			
			tIED ied = this.GetIED (iedIndex);
			if (ied == null)
				return null;
			
			if (ied.AccessPoint == null)
				return null;
			
			System.Collections.ArrayList
					res = new System.Collections.ArrayList ();
			
			for (int nap = 0; nap < ied.AccessPoint.GetLength(0); nap++) {
				tAccessPoint ap = this.GetAP(iedIndex, nap);			                                      
				
				
				for (int i = 0; i < this.configuration.Communication.SubNetwork.GetLength(0); i++)
				{
					for (int j=0; 
					     j < this.configuration.Communication.SubNetwork[i].ConnectedAP.GetLength(0); 
					     j++)
					{
						
						if (this.configuration.Communication
						    .SubNetwork[i].ConnectedAP[j].iedName.Equals(ied.name) 
						    &&
						    this.configuration.Communication
						    .SubNetwork[i].ConnectedAP[j].apName.Equals(ap.name))
						{
							IEDConnectedAP c = new IEDConnectedAP();
							c.subnetwork = i;
							c.connectedap = j;
							c.ied = iedIndex;
							c.ap = nap;
							res.Add (c);
						}
					}
				}	
			}
			
			return res;
		}
		
		public tAddress GetIEDAddress (int subnetIndex, int connapIndex)
		{
			if (subnetIndex < 0)
				return null;
			if (connapIndex < 0)
				return null;
			if (this.Subnetworks == null)
				return null;
			if (subnetIndex > this.Subnetworks.GetLength(0))
				return null;
			if (this.Subnetworks[subnetIndex].ConnectedAP == null)
				return null;
			if (connapIndex > this.Subnetworks[subnetIndex].ConnectedAP.GetLength(0))
				return null;
			return this.Subnetworks[subnetIndex]
						.ConnectedAP[connapIndex].Address;
		}
		
		
		/// <summary>
		/// Find all tAddress on the specified subnetwork. Takes the list
		/// of IED's connected Access Point from connap. connap must include 
		/// a list of objects type OpenSCL.IEDConnectedAP.
		/// </summary>
		/// <param name="connap">
		/// A <see cref="System.Collections.ArrayList"/>
		/// </param>
		/// <param name="subnetIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Collections.ArrayList"/>
		/// </returns>
		public System.Collections.ArrayList 
			GetIEDAddress (System.Collections.ArrayList connap, 
		                               int subnetIndex)
		{
			if (connap == null)
				return null;
			if (subnetIndex < 0)
				return null;
			if (this.Subnetworks == null)
				return null;
			if (subnetIndex > this.Subnetworks.GetLength(0))
				return null;
			if (this.Subnetworks[subnetIndex].ConnectedAP == null)
				return null;
			if ((connap.Count > 0))
				return null;
				
			OpenSCL.IEDConnectedAP cap = new OpenSCL.IEDConnectedAP(-1, -1, -1, -1);
			if (!connap[0].GetType().Equals(cap.GetType()))
				return null;
			
			System.Collections.ArrayList address = new System.Collections.ArrayList();
			for (int s = 0; s < this.Subnetworks.GetLength(0); s++) {
				for (int i = 0; i < connap.Count; i++) {
					cap = (OpenSCL.IEDConnectedAP) connap[i];
					if (cap.subnetwork == subnetIndex) {
					    address.Add(this.Subnetworks[subnetIndex]
									.ConnectedAP[cap.connectedap].Address);
						}
				}
			}
			
			if(address.Count > 0)
				return address;	
			else
				return null;
		}
		
		// GSE Related functions
		
		public IEC61850.SCL.tGSEControl GetGSEControl (int iedIndex, int apIndex, int ldinst, 
		                                               int gsecontrolIndex)
		{
			if (this.configuration.IED == null)
				return null;
			if (iedIndex < 0 || iedIndex > this.configuration.IED.GetLength(0))
				return null;
			if (apIndex < 0)
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint == null)
				return null;
			if (apIndex < 0 || apIndex > this.configuration.IED[iedIndex].AccessPoint.GetLength(0))
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex].Server == null)
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex].Server.LDevice == null)
				return null;
			if (ldinst < 0 
			    || ldinst > this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice.GetLength(0))
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN0 == null)
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN0.GSEControl == null)
				return null;
			if (gsecontrolIndex < 0 || gsecontrolIndex > this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN0.GSEControl.GetLength(0))
				return null;
			
			return this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN0.GSEControl[gsecontrolIndex];
		}
		
		public int GetGSEControlIndex (int iedIndex, int apIndex, int ldinst, string gsecName)
		{
			if (this.configuration.IED == null)
				return -1;
			if (iedIndex < 0 || iedIndex > this.configuration.IED.GetLength(0))
				return -1;
			if (apIndex < 0)
				return -1;
			if (this.configuration.IED[iedIndex].AccessPoint == null)
				return -1;
			if (apIndex < 0 || apIndex > this.configuration.IED[iedIndex].AccessPoint.GetLength(0))
				return -1;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex].Server == null)
				return -1;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex].Server.LDevice == null)
				return -1;
			if (ldinst < 0 
			    || ldinst > this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice.GetLength(0))
				return -1;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN0 == null)
				return -1;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN0.GSEControl == null)
				return -1;
			
			IEC61850.SCL.tGSEControl[] gsec = this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    									.Server.LDevice[ldinst].LN0.GSEControl;
			
			for (int i = 0; i < gsec.GetLength(0); i++) {
				if (gsec[i].name.Equals (gsecName))
					return i;
			}
			
			return -1;
		}
		
		public IEC61850.SCL.tGSEControl GetGSEControl (int iedIndex, int apIndex, int ldinst, string gsecName)
		{
			return this.GetGSEControl(iedIndex, apIndex, ldinst,
			                               this.GetGSEControlIndex(iedIndex,
			                                                       apIndex,
			                                                       ldinst,
			                                                       gsecName));
		}
		
		public IEC61850.SCL.tGSEControl GetGSEControl (int iedIndex, string ldinst, string gsecName)
		{
			//
			
			if (iedIndex < 0 || ldinst == null || gsecName == null)
				return null;
			
			IEC61850.SCL.tLDevice ld = this.GetLD (this.GetIED (iedIndex), ldinst);
			if (ld == null)
				return null;
			
			if (ld.LN0 == null)
				return null;
			if (ld.LN0.GSEControl == null)
				return null;
			for (int i = 0; i < ld.LN0.GSEControl.GetLength(0); i++) {
				if (ld.LN0.GSEControl[i].name.Equals(gsecName))
					return ld.LN0.GSEControl[i];
			}
			
			return null;
		}
		
		
		public int GetGSEControlDataSetIndex (int iedIndex, string ldinst, string gsecName)
		{
			IEC61850.SCL.tGSEControl gc = this.GetGSEControl(iedIndex, ldinst, gsecName);
			if (gc == null)
				return -1;
			if (gc.datSet == null)
				return -1;
			
			IEC61850.SCL.tLDevice ld = this.GetLD (this.GetIED (iedIndex), ldinst);
			if (ld == null)
				return -1;
			if (ld.LN0 == null)
				return -1;
			if (ld.LN0.DataSet == null)
				return -1;
			
			for (int i = 0; i < ld.LN0.DataSet.GetLength(0); i++) {
				if (ld.LN0.DataSet[i].name.Equals(gc.datSet))
					return i;
			}
			
			return -1;
		}
		
		public IEC61850.SCL.tDataSet GetGSEControlDataSet (int iedIndex, string ldinst, string gsecName)
		{
			int gc = this.GetGSEControlDataSetIndex(iedIndex, ldinst, gsecName);
			if (gc < 0)
				return null;
			
			IEC61850.SCL.tLDevice ld = this.GetLD (this.GetIED (iedIndex), ldinst);
			if (ld == null)
				return null;
			if (ld.LN0 == null)
				return null;
			if (ld.LN0.DataSet == null)
				return null;
			
			return ld.LN0.DataSet[gc];
		}
		
		public string[] GetGSEControlSuscriptions (int iedIndex, int apIndex, int ldinst, int gsecIndex)
		{
			IEC61850.SCL.tGSEControl gc = this.GetGSEControl(iedIndex, apIndex, ldinst, gsecIndex);
			if (gc == null)
				return null;
			if (gc.IEDName == null)
				return null;
			return gc.IEDName;
		}
		
		// Reports Related functions
		
		/// <summary>
		/// Returns a tReportControl at reportIndex in the LN0 of the Logical Device at ldinst index,
		/// exposed at access point at apIndex from the IED at iedIndex. 
		/// </summary>
		/// <param name="iedIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="apIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="ldinst">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// /// <param name="reportIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="IEC61850.SCL.tReportControl"/>
		/// </returns>
		public IEC61850.SCL.tReportControl GetLN0ReportControl (int iedIndex, int apIndex, int ldinst, int reportIndex)
		{
			if (this.configuration.IED == null)
				return null;
			if (iedIndex < 0 || iedIndex > this.configuration.IED.GetLength(0))
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint == null)
				return null;
			if (apIndex < 0 || apIndex > this.configuration.IED[iedIndex].AccessPoint.GetLength(0))
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex].Server == null)
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex].Server.LDevice == null)
				return null;
			if (ldinst < 0 
			    || ldinst > this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice.GetLength(0))
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN0 == null)
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN0.ReportControl == null)
				return null;
			if (reportIndex < 0 || 
			    reportIndex > this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN0.ReportControl.GetLength(0))
				return null;
			
			return this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN0.ReportControl[reportIndex];
		}
		
		/// <summary>
		/// Returns a tReportControl at reportIndex in the LN at lnIndex of the Logical Device at ldinst index,
		/// exposed at access point at apIndex from the IED at iedIndex. 
		/// </summary>
		/// <param name="iedIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="apIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="ldinst">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="lnIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="reportIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="IEC61850.SCL.tReportControl"/>
		/// </returns>
		public IEC61850.SCL.tReportControl GetLNReportControl (int iedIndex, int apIndex, int ldinst, 
		                                                     int lnIndex, int reportIndex)
		{
			if (this.configuration.IED == null)
				return null;
			if (iedIndex < 0 || iedIndex > this.configuration.IED.GetLength(0))
				return null;
			if (apIndex < 0)
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint == null)
				return null;
			if (apIndex < 0 || apIndex > this.configuration.IED[iedIndex].AccessPoint.GetLength(0))
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex].Server == null)
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex].Server.LDevice == null)
				return null;
			if (ldinst < 0 
			    || ldinst > this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice.GetLength(0))
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN == null)
				return null;
			if (lnIndex < 0
			    || lnIndex > this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN.GetLength(0))
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN[lnIndex].ReportControl == null)
				return null;
			if (reportIndex < 0 
			    || reportIndex > this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN[lnIndex].ReportControl.GetLength(0))
				return null;
			
			return this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN[lnIndex].ReportControl[reportIndex];
		}
		
		public int GetLN0ReportControlDataSetIndex (int iedIndex, int apIndex, int ldinst, int reportIndex)
		{
			IEC61850.SCL.tReportControl rep = this.GetLN0ReportControl(iedIndex, apIndex, ldinst,
			                                                        reportIndex);
			if (rep == null)
				return -1;
			if (rep.datSet == null)
				return -1;
			
			IEC61850.SCL.tLN0 ln = this.GetLN0(iedIndex, apIndex, ldinst);
			if (ln == null)
				return -1;
			if (ln.DataSet == null)
				return -1;
			for (int i = 0; i < ln.DataSet.GetLength(0); i++) {
				if (ln.DataSet[i].name.Equals(rep.datSet))
					return i;
			}
			return -1;
		}
		
		public IEC61850.SCL.tDataSet GetLN0ReportControlDataSet (int iedIndex, int apIndex, int ldinst, 
		                                                     int reportIndex)
		{
			int rep = this.GetLN0ReportControlDataSetIndex(iedIndex, apIndex, ldinst, reportIndex);
			if (rep < 0)
				return null;
			
			IEC61850.SCL.tLN0 ln = this.GetLN0(iedIndex, apIndex, ldinst);
			if (ln == null)
				return null;
			if (ln.DataSet == null)
				return null;
			
			return ln.DataSet[rep];
		}
		
		public int GetLNReportControlDataSetIndex (int iedIndex, int apIndex, int ldinst, 
		                                         int lnIndex, int reportIndex)
		{
			IEC61850.SCL.tReportControl rep = this.GetLNReportControl(iedIndex, apIndex, ldinst,
			                                                        lnIndex, reportIndex);
			if (rep == null)
				return -1;
			if (rep.datSet == null)
				return -1;
			
			IEC61850.SCL.tLN ln = this.GetLN(iedIndex, apIndex, ldinst, lnIndex);
			if (ln == null)
				return -1;
			if (ln.DataSet == null)
				return -1;
			for (int i = 0; i < ln.DataSet.GetLength(0); i++) {
				if (ln.DataSet[i].name.Equals(rep.datSet))
					return i;
			}
			
			return -1;
		}
		
		public IEC61850.SCL.tDataSet GetLNReportControlDataSet (int iedIndex, int apIndex, int ldinst, 
		                                                     int lnIndex, int reportIndex)
		{
			int rep = this.GetLNReportControlDataSetIndex(iedIndex, apIndex, ldinst, lnIndex, reportIndex);
			if (rep < 0)
				return null;
			
			IEC61850.SCL.tLN ln = this.GetLN(iedIndex, apIndex, ldinst, lnIndex);
			if (ln == null)
				return null;
			if (ln.DataSet == null)
				return null;
			
			return ln.DataSet[rep];
		}
		
		
		// LN Related
		
		public IEC61850.SCL.tLN0 GetLN0 (int iedIndex, int apIndex, int ldinst)
		{
			if (this.configuration.IED == null)
				return null;
			if (iedIndex < 0 || iedIndex > this.configuration.IED.GetLength(0))
				return null;
			if (apIndex < 0)
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint == null)
				return null;
			if (apIndex < 0 || apIndex > this.configuration.IED[iedIndex].AccessPoint.GetLength(0))
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex].Server == null)
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex].Server.LDevice == null)
				return null;
			if (ldinst < 0 
			    || ldinst > this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice.GetLength(0))
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN0 == null)
				return null;
			
			return this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN0;
		}
		
		public IEC61850.SCL.tLN GetLN (int iedIndex, int apIndex, int ldinst, int lnIndex)
		{
			if (this.configuration.IED == null)
				return null;
			if (iedIndex < 0 || iedIndex > this.configuration.IED.GetLength(0))
				return null;
			if (apIndex < 0)
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint == null)
				return null;
			if (apIndex < 0 || apIndex > this.configuration.IED[iedIndex].AccessPoint.GetLength(0))
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex].Server == null)
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex].Server.LDevice == null)
				return null;
			if (ldinst < 0 
			    || ldinst > this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice.GetLength(0))
				return null;
			if (this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN == null)
				return null;
			if (lnIndex < 0
			    || lnIndex > this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN.GetLength(0))
				return null;
			
			return this.configuration.IED[iedIndex].AccessPoint[apIndex]
			    					.Server.LDevice[ldinst].LN[lnIndex];
		}
		
		// tP related
		
		/// <summary>
		/// Get a tP object from a tAddress. 
		/// </summary>
		/// <param name="subnet">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="numap">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="nump">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="IEC61850.SCL.tP"/>
		/// </returns>
		public IEC61850.SCL.tP GetPAddress (int subnet, int numap, int nump)
		{
			if (this.Subnetworks == null)
				return null;
			if (subnet < 0 || subnet > this.Subnetworks.GetLength(0))
				return null;
			if (this.Subnetworks[subnet].ConnectedAP == null)
				return null;
			if (numap < 0 || numap > this.Subnetworks[subnet].ConnectedAP.GetLength(0))
				return null;
			if (this.Subnetworks[subnet].ConnectedAP[numap].Address == null)
				return null;
			if (this.Subnetworks[subnet].ConnectedAP[numap].Address.P == null)
				return null;
			if (nump < 0 || nump > this.Subnetworks[subnet].ConnectedAP[numap].Address.P.GetLength(0))
				return null;
			
			return this.Subnetworks[subnet].ConnectedAP[numap].Address.P[nump];
		}
		
		/// <summary>
		/// Returns an array with all tP on the given subnetwork and connected accesspoint's address.
		/// </summary>
		/// <param name="subnet">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="numap">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="IEC61850.SCL.tP[]"/>
		/// </returns>
		public IEC61850.SCL.tP[] GetPAddress (int subnet, int numap)
		{
			if (this.Subnetworks == null)
				return null;
			if (subnet < 0 || subnet > this.Subnetworks.GetLength(0))
				return null;
			if (this.Subnetworks[subnet].ConnectedAP == null)
				return null;
			if (numap < 0 || numap > this.Subnetworks[subnet].ConnectedAP.GetLength(0))
				return null;
			if (this.Subnetworks[subnet].ConnectedAP[numap].Address == null)
				return null;
			if (this.Subnetworks[subnet].ConnectedAP[numap].Address.P == null)
				return null;
			
			return this.Subnetworks[subnet].ConnectedAP[numap].Address.P;
		}
		
		/// <summary>
		/// Returns an array with all tP on the given subnetwork and connected accesspoint's phycal connection. 
		/// </summary>
		/// <param name="subnet">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="numap">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="pcIndex">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="IEC61850.SCL.tP[]"/>
		/// </returns>
		public IEC61850.SCL.tP[] GetPPhysConn (int subnet, int numap, int pcIndex)
		{
			if (this.Subnetworks == null)
				return null;
			if (subnet < 0 || subnet > this.Subnetworks.GetLength(0))
				return null;
			if (this.Subnetworks[subnet].ConnectedAP == null)
				return null;
			if (numap < 0 || numap > this.Subnetworks[subnet].ConnectedAP.GetLength(0))
				return null;
			if (this.Subnetworks[subnet].ConnectedAP[numap].PhysConn == null)
				return null;
			if (pcIndex < 0 || pcIndex > this.Subnetworks[subnet].ConnectedAP[numap].PhysConn.GetLength(0))
				return null;
			if (this.Subnetworks[subnet].ConnectedAP[numap].PhysConn[pcIndex].P == null)
				return null;
			
			return this.Subnetworks[subnet].ConnectedAP[numap].PhysConn[pcIndex].P;
		}

		/// <summary>
		/// Get a tP from a tPhysConn. 
		/// </summary>
		/// <param name="subnet">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="numap">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <param name="nump">
		/// A <see cref="System.Int32"/>
		/// </param>
		/// <returns>
		/// A <see cref="IEC61850.SCL.tP"/>
		/// </returns>
		public IEC61850.SCL.tP GetPPhysConn (int subnet, int numap, int pcIndex, int nump)
		{
			if (this.Subnetworks == null)
				return null;
			if (subnet < 0 || subnet > this.Subnetworks.GetLength(0))
				return null;
			if (this.Subnetworks[subnet].ConnectedAP == null)
				return null;
			if (numap < 0 || numap > this.Subnetworks[subnet].ConnectedAP.GetLength(0))
				return null;
			if (this.Subnetworks[subnet].ConnectedAP[numap].PhysConn == null)
				return null;
			if (pcIndex < 0 || pcIndex > this.Subnetworks[subnet].ConnectedAP[numap].PhysConn.GetLength(0))
				return null;
			if (this.Subnetworks[subnet].ConnectedAP[numap].PhysConn[pcIndex].P == null)
				return null;
			if (nump < 0 || nump > this.Subnetworks[subnet].ConnectedAP[numap].PhysConn[pcIndex].P.GetLength(0))
				return null;
			
			return this.Subnetworks[subnet].ConnectedAP[numap].PhysConn[pcIndex].P[nump];
		}
		
		// Substation
		
		public tSubstation[] Substation
		{
			get {
				return this.configuration.Substation;
			}
			
			set {
				this.configuration.Substation = value;
			}
		}
		
		/// <summary>
		/// This method is executed when XmlSerializer finds an unknown XML node during the 
		/// deserialize method.
		/// </summary>
		/// <param name="sender">
		/// Event's source.</param>
		/// <param name="e">
		/// An XmlNodeEventArgs that contains the event's data.
		/// </param>
		/// <remarks>
		/// This method occurs only when the Deserialize method is used.
		/// </remarks>
		private void UnknownNode(object sender, XmlNodeEventArgs e)
    	{	        
			ListErrors.Add(new ErrorsManagement("Unknown node:"+ e.Name + "\t" + e.Text));
	    }
		
		/// <summary>
		/// This method is executed when XmlSerializer finds an unknown XML attribute 
		/// during the deserialize method.
		/// </summary>
		/// <param name="sender">
		/// Event's source.</param>
		/// <param name="e">
		/// An XmlAttributeEventArgs that contains the event data.
		/// </param>
		/// <remarks>
		/// This method occurs only when the Deserialize method is used.
		/// </remarks>
   		private void UnknownAttribute(object sender, XmlAttributeEventArgs e)
    	{
        	System.Xml.XmlAttribute attr = e.Attr;        	
        	ListErrors.Add(new ErrorsManagement("Unknown attribute:"+ attr.Name + "='" + attr.Value + "'"));
    	}	  		
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="arrayToImport">
		/// 
		/// </param>
		/// <param name="arraySCLProject">
		/// 
		/// </param>
		/// <param name="ParentToImport">
		/// 
		/// </param>
		/// <param name="ParenSCLProyect">
		/// 
		/// </param>
		private void ValidateIDName(object[] arrayToImport, object[] arraySCLProject, object ParentToImport, object ParenSCLProyect)
		{			
			bool bandAddObject=true;
			for(int x = 0, i=0; arrayToImport != null && x < arrayToImport.Length;x++)
			{
				for(int y = 0; arraySCLProject!=null && y < arraySCLProject.Length; y++)
				{
					if((arrayToImport[x] as tIDNaming).id.Equals((arraySCLProject[y] as tIDNaming).id))
					{						
						this.objectManagement.RemoveObjectOfArrayObjectOfParentObject(arrayToImport[x], i, ParentToImport);
						bandAddObject=false;						
						break;
					}
				}
				if(bandAddObject)
				{
					this.objectManagement.AddObjectToArrayObjectOfParentObject(arrayToImport[x], ParenSCLProyect);
					i++;					
				}
				bandAddObject=true;
			}
		}
		
		// DEPRECATED: Not use in new code
		public string GetPDescription (tPTypeEnum type)
		{
			string text = "";
			switch (type)
			{
			case tPTypeEnum.IP:
				text = "TCP/IP Address";
				break;
			case tPTypeEnum.IP_SUBNET:
				text = "Subnetwork Mask for TCP/IP profiles";
				break;
			case tPTypeEnum.IP_GATEWAY:
				text = "First Hop IP gateway address for TCP/IP profiles";
				break;
			case tPTypeEnum.OSI_NSAP:
				text = "OSI Network Address";
				break;
			case tPTypeEnum.OSI_TSEL:
				text = "OSI Transport Selector";
				break;
			case tPTypeEnum.OSI_SSEL:
				text = "OSI Session Selector";
				break;
			case tPTypeEnum.OSI_PSEL:
				text = "OSI Presentation Selector";
				break;
			case tPTypeEnum.OSI_AP_Title:
				text = "OSI ACSE AP Title value";
				break;
			case tPTypeEnum.OSI_AP_Invoke:
				text = "OSI ACSE AP Invoke ID";
				break;
			case tPTypeEnum.OSI_AE_Qualifier:
				text = "OSI ACSE AE Qualifier";
				break;
			case tPTypeEnum.OSI_AE_Invoke:
				text = "OSI ACSE AE Invoke ID";
				break;
			case tPTypeEnum.MAC_Address:
				text = "Media Access Address value";
				break;
			case tPTypeEnum.APPID:
				text = "Application Identifier";
				break;
			case tPTypeEnum.VLAN_PRIORITY:
				text = "VLAN User Priority";
				break;
			case tPTypeEnum.VLAN_ID:
				text = "VLAN ID";
				break;
			default:
				text = "No description or type not sopported";
				break;
			}
			return text;
		}
		
		// DEPRECATED: Not use in new code
		public string GetPName (tPTypeEnum type)
		{
			string text = "";
			switch (type)
			{
			case tPTypeEnum.IP:
				text = "IP";
				break;
			case tPTypeEnum.IP_SUBNET:
				text = "IP-SUBNET";
				break;
			case tPTypeEnum.IP_GATEWAY:
				text = "IP-GATEWAY";
				break;
			case tPTypeEnum.OSI_NSAP:
				text = "OSI-NSAP";
				break;
			case tPTypeEnum.OSI_TSEL:
				text = "OSI-TSEL";
				break;
			case tPTypeEnum.OSI_SSEL:
				text = "OSI-SSEL";
				break;
			case tPTypeEnum.OSI_PSEL:
				text = "OSI-PSEL";
				break;
			case tPTypeEnum.OSI_AP_Title:
				text = "OSI-AP-Title";
				break;
			case tPTypeEnum.OSI_AP_Invoke:
				text = "OSI-AP-Invoke";
				break;
			case tPTypeEnum.OSI_AE_Qualifier:
				text = "OSI-AE-Qualifier";
				break;
			case tPTypeEnum.OSI_AE_Invoke:
				text = "OSI-SE-Invoke";
				break;
			case tPTypeEnum.MAC_Address:
				text = "MAC-Address";
				break;
			case tPTypeEnum.APPID:
				text = "APPID";
				break;
			case tPTypeEnum.VLAN_PRIORITY:
				text = "VLAN-PRIORITY";
				break;
			case tPTypeEnum.VLAN_ID:
				text = "VLAN ID";
				break;
			default:
				text = "No name or type not sopported";
				break;
			}
			return text;
		}

	}
}
