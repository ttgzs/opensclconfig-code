// 
//  tP.cs
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
	 * The data type "tPTypeEnum was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tP_VLANID))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tP_VLANPRIORITY))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tP_APPID))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tP_MACAddress))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tP_OSIAEInvoke))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tP_OSIAEQualifier))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tP_OSIAPInvoke))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tP_OSIAPTitle))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tP_OSIPSEL))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tP_OSISSEL))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tP_OSITSEL))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tP_OSINSAP))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tP_IPGATEWAY))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tP_IPSUBNET))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tP_IP))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tP 
	{		
		private tPType typeField;		
		private string valueField;
		
		public tP ()
		{
			this.typeField = new tPType();
		}
		
		[System.Xml.Serialization.XmlIgnore]
		public tPType PType
		{
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlIgnore]
		public string Description
		{
			get {
				return this.typeField.Description();
			}
		}
		
		[System.Xml.Serialization.XmlIgnore]
		public tPTypeEnum typeEnum
		{
			get {
				return this.typeField.typeEnum;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("P"), Description("This attribute identifies the meaning of the value"), ReadOnlyAttribute(true)]
		public string type 
		{
			get 
			{
				return this.typeField.type;
			}
			set
			{
				this.typeField.type = value;
			}
		}
		
		[System.Xml.Serialization.XmlTextAttribute(DataType="normalizedString")]
		[Category("P"), Description("An address value")]
		public string Value 
		{
			get
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}	
	}
	    
	/*
	 * The enumeration "TPTypeEnum" was added to fullfill standar IEC 61850 Ed. 1.0
	*/
	public class tPType
	{
		private string typeField;
		
		public tPType() 
		{
			this.typeField = this.EnumToString(tPTypeEnum.IP);
		}
		
		public tPType (tPTypeEnum t)
		{
			this.typeField = this.EnumToString(t);
		}
		
		public string type 
		{
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
		
		public tPTypeEnum typeEnum 
		{
			get {
				return this.StringToEnum(this.typeField);
			}
			set {
				this.typeField = this.EnumToString(value);
			}
		}
		
		public string EnumToString (tPTypeEnum type)
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
				text = "OSI-AE-Invoke";
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
				text = "VLAN-ID";
				break;
			default:
				text = "EXTENSION";
				break;
			}
			return text;
		}
		
		public tPTypeEnum StringToEnum (string t)
		{
			tPTypeEnum type;
			switch (t)
			{
			case "IP":
				type = tPTypeEnum.IP;
				break;
			case "IP-SUBNET":
				type = tPTypeEnum.IP_SUBNET;
				break;
			case "IP-GATEWAY":
				type = tPTypeEnum.IP_GATEWAY;
				break;
			case "OSI-NSAP":
				type = tPTypeEnum.OSI_NSAP;
				break;
			case "OSI-TSEL":
				type = tPTypeEnum.OSI_TSEL;
				break;
			case "OSI-SSEL":
				type = tPTypeEnum.OSI_SSEL;
				break;
			case "OSI-PSEL":
				type = tPTypeEnum.OSI_PSEL;
				break;
			case "OSI-AP-Title":
				type = tPTypeEnum.OSI_AP_Title;
				break;
			case "OSI-AP-Invoke":
				type = tPTypeEnum.OSI_AP_Invoke;
				break;
			case "OSI-AE-Qualifier":
				type = tPTypeEnum.OSI_AE_Qualifier;
				break;
			case "OSI-AE-Invoke":
				type = tPTypeEnum.OSI_AE_Invoke;
				break;
			case "MAC-Address":
				type = tPTypeEnum.MAC_Address;
				break;
			case "APPID":
				type = tPTypeEnum.APPID;
				break;
			case "VLAN-PRIORITY":
				type = tPTypeEnum.VLAN_PRIORITY;
				break;
			case "VLAN-ID":
				type = tPTypeEnum.VLAN_ID;
				break;
			default:
				type = tPTypeEnum.EXTENSION;
				break;
			}
			return type;
		}
		
		public string Description ()
		{
			string text = "";
			switch (this.StringToEnum(this.typeField))
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
				text = "EXTENSION: Custom type";
				break;
			}
			return text;
		}
		
	}
	
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tPTypeEnum
	{
		IP,
		[System.Xml.Serialization.XmlEnumAttribute("IP-SUBNET")]
		IP_SUBNET,		
		[System.Xml.Serialization.XmlEnumAttribute("IP-GATEWAY")]
		IP_GATEWAY,	
		[System.Xml.Serialization.XmlEnumAttribute("OSI-NSAP")]
		OSI_NSAP,		
		[System.Xml.Serialization.XmlEnumAttribute("OSI-TSEL")]
		OSI_TSEL,		
		[System.Xml.Serialization.XmlEnumAttribute("OSI-SSEL")]
		OSI_SSEL,		
		[System.Xml.Serialization.XmlEnumAttribute("OSI-PSEL")]
		OSI_PSEL,		
		[System.Xml.Serialization.XmlEnumAttribute("OSI-AP-Title")]
		OSI_AP_Title,		
		[System.Xml.Serialization.XmlEnumAttribute("OSI-AP-Invoke")]
		OSI_AP_Invoke,		
		[System.Xml.Serialization.XmlEnumAttribute("OSI-AE-Qualifier")]
		OSI_AE_Qualifier,		
		[System.Xml.Serialization.XmlEnumAttribute("OSI-AE-Invoke")]
		OSI_AE_Invoke,		
		[System.Xml.Serialization.XmlEnumAttribute("MAC-Address")]
		MAC_Address,		
		[System.Xml.Serialization.XmlEnumAttribute("APPID")]
		APPID,		
		[System.Xml.Serialization.XmlEnumAttribute("VLAN-PRIORITY")]
		VLAN_PRIORITY,		
		[System.Xml.Serialization.XmlEnumAttribute("VLAN-ID")]
		VLAN_ID,
		EXTENSION // For custom types
	}
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_VLAN-ID", Namespace="http://www.iec.ch/61850/2003/SCL")]
	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed. 1.0:
	*/	
	public partial class tP_VLANID : tP 
	{
		public tP_VLANID() 
		{
			this.PType = new tPType(tPTypeEnum.VLAN_ID);
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed. 1.0
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_VLAN-PRIORITY", Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tP_VLANPRIORITY : tP 
	{
		public tP_VLANPRIORITY() 
		{
			this.PType = new tPType (tPTypeEnum.VLAN_PRIORITY);
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	public partial class tP_APPID : tP 
	{
		public tP_APPID()
		{
			this.PType = new tPType(tPTypeEnum.APPID);
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed. 1.0
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_MAC-Address", Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tP_MACAddress : tP
	{
		public tP_MACAddress() 
		{
			this.PType = new tPType(tPTypeEnum.MAC_Address);
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-AE-Invoke", Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tP_OSIAEInvoke : tP
	{
		public tP_OSIAEInvoke()
		{
			this.PType = new tPType(tPTypeEnum.OSI_AE_Invoke);
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-AE-Qualifier", Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tP_OSIAEQualifier : tP 
	{
		public tP_OSIAEQualifier() 
		{
			this.PType = new tPType(tPTypeEnum.OSI_AE_Qualifier);
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed. 1.0
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-AP-Invoke", Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tP_OSIAPInvoke : tP 
	{
		public tP_OSIAPInvoke() 
		{
			this.PType = new tPType(tPTypeEnum.OSI_AP_Invoke);
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed. 1.0
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-AP-Title", Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tP_OSIAPTitle : tP 
	{
		public tP_OSIAPTitle()
		{
			this.PType = new tPType(tPTypeEnum.OSI_AP_Title);
		}
	}
	
	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed. 1.0
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-PSEL", Namespace="http://www.iec.ch/61850/2003/SCL")]			
	public partial class tP_OSIPSEL : tP 
	{
		public tP_OSIPSEL()
		{
			this.PType = new tPType(tPTypeEnum.OSI_PSEL);
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed. 1.0
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-SSEL", Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tP_OSISSEL : tP
	{
		public tP_OSISSEL()
		{
			this.PType = new tPType(tPTypeEnum.OSI_SSEL);
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed. 1.0
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-TSEL", Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tP_OSITSEL : tP 
	{
		public tP_OSITSEL() 
		{
			this.PType = new tPType(tPTypeEnum.OSI_TSEL);
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-NSAP", Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tP_OSINSAP : tP
	{
		public tP_OSINSAP()
		{
			this.PType = new tPType(tPTypeEnum.OSI_NSAP);
		}
	}
 
	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed. 1.0
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_IP-GATEWAY", Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tP_IPGATEWAY : tP 
	{
		public tP_IPGATEWAY()
		{
			this.PType = new tPType(tPTypeEnum.IP_GATEWAY);
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed. 1.0
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_IP-SUBNET", Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tP_IPSUBNET : tP 
	{
		public tP_IPSUBNET()
		{
			this.PType = new tPType(tPTypeEnum.IP_SUBNET);
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed. 1.0
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tP_IP : tP
	{
		public tP_IP()
		{
			this.PType = new tPType(tPTypeEnum.IP);
		}
	}

}

