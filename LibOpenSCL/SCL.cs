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
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute("Substation", Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]	
	public partial class tSubstation : tEquipmentContainer 
	{		
		private tVoltageLevel[] voltageLevelField;		
		private tFunction[] functionField;

		[System.Xml.Serialization.XmlElementAttribute("VoltageLevel")]
		[Category("Substation"), Browsable(false)]		
		public tVoltageLevel[] VoltageLevel 
		{
			get 
			{
				return this.voltageLevelField;
			}
			set 
			{
				this.voltageLevelField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("Function")]
		[Category("Substation"), Browsable(false)]		
		public tFunction[] Function 
		{
			get 
			{
				return this.functionField;
			}
			set 
			{
				this.functionField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tVoltageLevel : tEquipmentContainer 
	{		
		private tVoltage voltageField;		
		private tBay[] bayField;
		
		[Category("VoltageLevel"), Description("It can be used to state the voltage."), Browsable(false)]
		public tVoltage Voltage 
		{
			get 
			{
				return this.voltageField;
			}
			set 
			{
				this.voltageField = value;
			}
		}

		[Category("VoltageLevel"), Browsable(false)]		
		[System.Xml.Serialization.XmlElementAttribute("Bay")]
		public tBay[] Bay 
		{
			get 
			{
				return this.bayField;
			}
			set 
			{
				this.bayField = value;
			}
		}
	}
	
	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed. 1.0:
	 * unit -> unitField
	 * multiplier -> multiplierField
	*/
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tVoltage : tValueWithUnit {
		
		private tSIUnitEnum unitField;		
		private tUnitMultiplierEnum multiplierField;
				
		public tVoltage()
		{
			this.unitField = tSIUnitEnum.V;
			this.multiplierField = tUnitMultiplierEnum.Item;
		}

		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("Voltage"), Description("Units derived from ISO 1000 to represent a measurement."), DefaultValue(tSIUnitEnum.V)]
		public tSIUnitEnum unit 
		{
			get 
			{
				return this.unitField;
			}
			set 
			{
				this.unitField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("Voltage"), Description("It shall define the multiplier value"), DefaultValue(tUnitMultiplierEnum.Item)]
		public tUnitMultiplierEnum multiplier 
		{
			get 
			{
				return this.multiplierField;
			}
			set 
			{
				this.multiplierField = value;
			}
		}
	}
	
	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDurationInMilliSec))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDurationInSec))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBitRateInMbPerSec))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tVoltage))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tValueWithUnit 
	{		
		private tSIUnitEnum unitField;		
		private tUnitMultiplierEnum multiplierField;		
		private decimal valueField;
		
		public tValueWithUnit() 
		{
			this.multiplierField = tUnitMultiplierEnum.Item;
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ValueWithUnit"), Description("Units derived from ISO 1000 to represent a measurement.")]
		public tSIUnitEnum unit 
		{
			get 
			{
				return this.unitField;
			}
			set 
			{
				this.unitField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("ValueWithUnit"), Description("It shall define the multiplier value"), DefaultValue(tUnitMultiplierEnum.Item)]
		public tUnitMultiplierEnum multiplier 
		{
			get 
			{
				return this.multiplierField;
			}
			set 
			{
				this.multiplierField = value;
			}
		}
		
		[System.Xml.Serialization.XmlTextAttribute()]
		[Category("ValueWithUnit"), Description("Value assigned")]
		public decimal Value 
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

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tSIUnitEnum : int
	{		
		none = 1,
		m = 2,
		kg = 3,
		s = 4,
		A = 5,
		K = 6,
		mol = 7,
		cd = 8,
		deg = 9,
		rad = 10,
		sr = 11,
		Gy = 21,
		q = 22,
		
		[System.Xml.Serialization.XmlEnumAttribute("°C")]
		C = 23,
		
		Sv = 24,
		F = 25,
		
		[System.Xml.Serialization.XmlEnumAttribute("C")]
		C1 = 26,
		
		S = 27,
		H = 28,
		V = 29,
		ohm = 30,
		J = 31,
		N = 32,
		Hz = 33,
		lx = 34,
		Lm = 35,
		Wb = 36,
		T = 37,
		W = 38,
		Pa = 39,
		
		[System.Xml.Serialization.XmlEnumAttribute("m^2")]
		m2 = 41,
		
		[System.Xml.Serialization.XmlEnumAttribute("m^3")]
		m3 = 42,
		
		[System.Xml.Serialization.XmlEnumAttribute("m/s")]
		ms = 43,
		
		[System.Xml.Serialization.XmlEnumAttribute("m/s^2")]
		ms2 = 44,
		
		[System.Xml.Serialization.XmlEnumAttribute("m^3/s")]
		m3s = 45,
		
		[System.Xml.Serialization.XmlEnumAttribute("m/m^3")]
		mm3 = 46,
		
		M = 47,
		
		[System.Xml.Serialization.XmlEnumAttribute("kg/m^3")]
		kgm3 = 48,
		
		[System.Xml.Serialization.XmlEnumAttribute("m^2/s")]
		m2s = 49,

		[System.Xml.Serialization.XmlEnumAttribute("W/m K")]
		WmK = 50,

		[System.Xml.Serialization.XmlEnumAttribute("J/K")]
		JK = 51,

		ppm = 52,

		[System.Xml.Serialization.XmlEnumAttribute("s^-1")]
		s1 = 53,

		[System.Xml.Serialization.XmlEnumAttribute("rad/s")]
		rads = 54,

		VA = 61,
		Watts = 62,
		VAr = 63,
		phi = 64,
		cos_phi = 65,
		Vs = 66,
		
		[System.Xml.Serialization.XmlEnumAttribute("V^2")]
		V2 = 67,

		As = 68,

		[System.Xml.Serialization.XmlEnumAttribute("A^2")]
		A2 = 69,

		[System.Xml.Serialization.XmlEnumAttribute("A^2 s")]
		A2s = 70,

		VAh = 71,
		Wh = 72,
		VArh = 73,

		[System.Xml.Serialization.XmlEnumAttribute("V/Hz")]
		VHz = 74,

		[System.Xml.Serialization.XmlEnumAttribute("b/s")]
		bs = 75,
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tUnitMultiplierEnum : int 
	{		
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item = 0,
		m = -3,
		k = 3,
		M = 6,
		mu = -6,
		y = -24,
		z = -21,
		a = -18,
		f = -15,
		p = -12,
		n = -9,
		c = -2,
		d = -1,
		da = 1,
		h = 2,
		G = 9,
		T = 12,
		P = 15,
		E = 18,
		Z = 21,
		Y = 24,
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tHeader 
	{		
		private static int index = 0;
		private tText textField;		
		private tHitem[] historyField;		
		private string idField;		
		private string versionField;
		private string revisionField;		
		private string toolIDField;		
		private tHeaderNameStructure nameStructureField;
				
		public tHeader() 
		{
			this.versionField = "0";
			if(this.revision == null )
			{
				this.revision = ( ++index ).ToString();
			}
			this.idField = "SCL File";
			this.toolIDField = "OpenSCLConfigurator";
			this.nameStructureField = tHeaderNameStructure.IEDName;				
		}
		
		[Category("Header"), Browsable(false)]
		public tText Text 
		{
			get 
			{
				return this.textField;
			}
			set 
			{
				this.textField = value;
			}
		}
		
		[System.Xml.Serialization.XmlArrayItemAttribute("Hitem", IsNullable=false)]
		[Category("Header"), Browsable(false)]
		public tHitem[] History 
		{
			get 
			{
				return this.historyField;
			}
			set 
			{
				this.historyField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Header"), Description("A string identifying this SCL file.")]
		public string id 
		{
			get 
			{
				return this.idField;
			}
			set 
			{
				this.idField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Header"), Description("The version of this SCL configuration file.")]
		public string version 
		{
			get 
			{
				return this.versionField;
			}
			set 
			{
				this.versionField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Header"), Description("The revision of this SCL configuration file, by default the empty string meaning the original before any revision")]
		public string revision 
		{
			get 
			{
				return this.revisionField;
			}
			set 
			{
				this.revisionField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Header"), Description("The manufacturer specific identification of the tool that was used to create the SCL file")]
		[ReadOnly(true)]
		public string toolID 
		{
			get 
			{
				return this.toolIDField;
			}
			set 
			{
				this.toolIDField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("Header"), Description("Element indicating if communication system signal names are built"+
		    "from the substation function structure or from the IED product structure")]
		public tHeaderNameStructure nameStructure 
		{
			get 
			{
				return this.nameStructureField;
			}
			set 
			{
				this.nameStructureField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tText : tAnyContentFromOtherNamespace 
	{		
		private string sourceField;
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
		[Browsable(false)]
		public string source 
		{
			get 
			{
				return this.sourceField;
			}
			set 
			{
				this.sourceField = value;
			}
		}
	}

	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLog))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAccessControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tHitem))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPrivate))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tText))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tAnyContentFromOtherNamespace 
	{		
		private System.Xml.XmlNode[] anyField;		
		private System.Xml.XmlAttribute[] anyAttrField;
		
		[System.Xml.Serialization.XmlTextAttribute()]
		[System.Xml.Serialization.XmlAnyElementAttribute()]
		[Browsable(false)]
		public System.Xml.XmlNode[] Any 
		{
			get 
			{
				return this.anyField;
			}
			set 
			{
				this.anyField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		[Browsable(false)]
		public System.Xml.XmlAttribute[] AnyAttr 
		{
			get 
			{
				return this.anyAttrField;
			}
			set 
			{
				this.anyAttrField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tLog : tAnyContentFromOtherNamespace 
	{	
		
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tAccessControl : tAnyContentFromOtherNamespace 
	{
		
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tHitem : tAnyContentFromOtherNamespace 
	{		
		private static int index = 0;
		private string versionField;		
		private string revisionField;		
		private string whenField;		
		private string whoField;		
		private string whatField;		
		private string whyField;
		
		public tHitem()
		{
			this.versionField = "0";
			if(this.revision == null)
			{
				this.revision = (++index).ToString();
			}
			this.whenField = "";	
			this.what = "New SCL File";
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Hitem"), Description("The version of this history entry")]
		public string version 
		{
			get 
			{
				return this.versionField;
			}
			set 
			{
				this.versionField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Hitem"), Description("The revision of this history entry")]
		public string revision 
		{
			get 
			{
				return this.revisionField;
			}
			set 
			{
				this.revisionField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Hitem"), Description("Date when the version/revision was released")]
		public string when 
		{
			get 
			{
				return this.whenField;
			}
			set 
			{
				this.whenField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Hitem"), Description("Who made/approved this version/revision")]
		public string who 
		{
			get
			{
				return this.whoField;
			}
			set 
			{
				this.whoField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Hitem"), Description("What has been changed since the last approval")]
		public string what 
		{
			get 
			{
				return this.whatField;
			}
			set 
			{
				this.whatField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Hitem"), Description("Why the change has happened")]
		public string why 
		{
			get 
			{
				return this.whyField;
			}
			set 
			{
				this.whyField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tPrivate : tAnyContentFromOtherNamespace
	{		
		private string typeField;		
		private string sourceField;
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Private"), Description("Distinguishes different (private) purposes of the element contents"), ReadOnly(false)]
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
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
		[Category("Private"), Description("URL to some file, which contains the private information"), ReadOnly(false)]
		public string source
		{
			get 
			{
				return this.sourceField;
			}
			set 
			{
				this.sourceField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tHeaderNameStructure 
	{		
		IEDName,
		FuncName
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tEnumVal 
	{		
		private string ordField;		
		private string valueField;
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
		[Category("EnumVal"), Description("It contains the order of the values")]
		public string ord
		{
			get 
			{
				return this.ordField;
			}
			set 
			{
				this.ordField = value;
			}
		}
		
		[System.Xml.Serialization.XmlTextAttribute(DataType="normalizedString")]
		[Category("EnumVal"), Description("The value is the character string")]
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
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed. 1.0:
	 * iedName -> iedNameField
	 * ldInst -> ldInstField
	 * 
	 * The data type "lnClassField" was added to fulfill standard IEC 61850 Ed. 1.0	 
	 * 
	 * To accept any Logical Node without shows an error, the type of lnClass attribute has to be changed from Enum to String.
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tAssociation 
	{		
		private tAssociationKindEnum kindField;		
		private string associationIDField;		
		private string iedNameField;		
		private string ldInstField;		
		private string prefixField;		
		private string lnClassField;		
		private string lnInstField;
		
		public tAssociation() 
		{
			this.prefixField = "";
			this.kindField = tAssociationKindEnum.preestablished;
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("Association"), Description("The kind of pre-configured association, pre-established or predefined")]		
		public tAssociationKindEnum kind 
		{
			get 
			{
				return this.kindField;
			}
			set 
			{
				this.kindField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Association"), Description("The identification of a pre-configured association")]
		public string associationID 
		{
			get 
			{
				return this.associationIDField;
			}
			set
			{
				this.associationIDField = value;
			}
		}
		
		[Required]		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Association"), Description("The reference identifying the IED on which the client resides")]
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
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Association"), Description("The reference to the client logical device")]
		public string ldInst 
		{
			get
			{
				return this.ldInstField;
			}
			set 
			{
				this.ldInstField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Association"), Description("The LN prefix")]
		public string prefix 
		{
			get 
			{
				return this.prefixField;
			}
			set 
			{
				this.prefixField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("Association"), Description("The class of the client LN")]
		public string lnClass 
		{
			get 
			{
				return this.lnClassField;
			}
			set 
			{
				this.lnClassField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Association"), Description("The instance number of the client LN")]
		public string lnInst 
		{
			get 
			{
				return this.lnInstField;
			}
			set 
			{
				this.lnInstField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tAssociationKindEnum 
	{		
		[System.Xml.Serialization.XmlEnumAttribute("pre-established")]
		preestablished,
		
		predefined,
	}
	
	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed. 1.0:
	 * iedName -> iedNameField
	 * ldInst -> ldInstField
	 * prefix -> prefixField
	 * lnClass -> lnClassField
	 * lnInst -> lnInstField
	 * 
	 * The data type "lnClassField" was added to fulfill standard IEC 61850 Ed. 1.0	 
	 * 
	 * To accept any Logical Node without shows an error, the type of lnClass attribute has to be changed from Enum to String.
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tExtRef 
	{		
		private string iedNameField;		
		private string ldInstField;		
		private string prefixField;		
		private string lnClassField;		
		private string lnInstField;		
		private string doNameField;		
		private string daNameField;		
		private string intAddrField;
				
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ExtRef"), Description("The name of the IED from where the input comes.")]
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
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ExtRef"), Description("The LD instance name from where the input comes.")]
		public string ldInst
		{
			get 
			{
				return this.ldInstField;
			}
			set 
			{
				this.ldInstField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ExtRef"), Description("The LN prefix")]
		public string prefix 
		{
			get
			{
				return this.prefixField;
			}
			set 
			{
				this.prefixField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ExtRef"), Description("The LN class")]
		public string lnClass
		{
			get 
			{
				return this.lnClassField;
			}
			set 
			{
				this.lnClassField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ExtRef"), Description("The instance id of this LN instance of below LN class in the IED")]
		public string lnInst
		{
			get 
			{
				return this.lnInstField;
			}
			set
			{
				this.lnInstField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ExtRef"), Description("A name identifying the DO (within the LN)")]
		public string doName
		{
			get 
			{
				return this.doNameField;
			}
			set 
			{
				this.doNameField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ExtRef"), Description("The attribute designating the input.")]
		public string daName
		{
			get
			{
				return this.daNameField;
			}
			set 
			{
				this.daNameField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ExtRef"), Description("The internal address to which the input is bound."), ReadOnly(true)]
		public string intAddr 
		{
			get 
			{
				return this.intAddrField;
			}
			set 
			{
				this.intAddrField = value;
			}
		}
	}
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tVal 
	{		
		private uint sGroupField;		
		private bool sGroupFieldSpecified;		
		private string valueField;
				
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("Val"), Description("The number of the setting group to which this value belongs.")]
		public uint sGroup 
		{
			get 
			{
				return this.sGroupField;
			}
			set 
			{
				this.sGroupField = value;
			}
		}
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		[Category("Val"), Description("It specifies to which setting group the value belongs.")]
		public bool sGroupSpecified 
		{
			get 
			{
				return this.sGroupFieldSpecified;
			}
			set 
			{
				this.sGroupFieldSpecified = value;
			}
		}
		
		[System.Xml.Serialization.XmlTextAttribute(DataType="normalizedString")]
		[Category("Val"), Description("A value for each defined setting group.")]
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
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tPhysConn 
	{		
		private tP[] pField;		
		private string typeField;
		
		[System.Xml.Serialization.XmlElementAttribute("P")]
		
		[Category("PhysConn"), Browsable(false)]
		public tP[] P 
		{
			get 
			{
				return this.pField;
			}
			set 
			{
				this.pField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("PhysConn"), Description("This attribute identifies the meaning of the value")]
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
	}

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

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed. 1.0:
	 * iedName -> iedNameField
	 * ldInst -> ldInstField
	 *
	 * The data type "lnClassField was added to fulfill the standard IEC 61850 Ed. 1.0
	 * 
	 * To accept any Logical Node without shows an error, the type of lnClass attribute has to be changed from Enum to String.
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tClientLN 
	{		
		private string iedNameField;		
		private string ldInstField;		
		private string prefixField;		
		private string lnClassField;		
		private string lnInstField;
		
		public tClientLN() 
		{
			this.prefixField = "";
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ClientLN"), Description("The name of the IED where the LN resides")]
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
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ClientLN"), Description("The instance identification of the LD where the LN resides")]
		public string ldInst 
		{
			get 
			{
				return this.ldInstField;
			}
			set 
			{
				this.ldInstField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ClientLN"), Description("The LN prefix")]
		public string prefix 
		{
			get 
			{
				return this.prefixField;
			}
			set 
			{
				this.prefixField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ClientLN"), Description("The LN class")]
		public string lnClass 
		{
			get 
			{
				return this.lnClassField;
			}
			set
			{
				this.lnClassField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ClientLN"), Description("The instance id of this LN instance of below LN class in the IED")]
		public string lnInst 
		{
			get 
			{
				return this.lnInstField;
			}
			set 
			{
				this.lnInstField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tTrgOps
	{		
		private bool dchgField;		
		private bool qchgField;		
		private bool dupdField;		
		private bool periodField;
		
		public tTrgOps() 
		{
			this.dchgField = false;
			this.qchgField = false;
			this.dupdField = false;
			this.periodField = false;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("TrgOps"), Description("dchg enabled means that a change in the value of that attribute should cause a report")]
		public bool dchg 
		{
			get 
			{
				return this.dchgField;
			}
			set 
			{
				this.dchgField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("TrgOps"), Description("dchg enabled means that a change in the value of the quality for that attribute should cause a report")]
		public bool qchg
		{
			get
			{
				return this.qchgField;
			}
			set 
			{
				this.qchgField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("TrgOps"), Description("dupd enabled A report or a log entry shall be generated due to freezing the value of "+
		                                 "a freezable attribute or updating the value of any other attribute.")]
		public bool dupd 
		{
			get 
			{
				return this.dupdField;
			}
			set 
			{
				this.dupdField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("TrgOps"), Description("if it es enabled integrity period is relevant.")]		
		public bool period 
		{
			get 
			{
				return this.periodField;
			}
			set 
			{
				this.periodField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The data type "lnClassField" was added to fulfill standard IEC 61850 Ed. 1.0	 
	 * 
	 * To accept any Logical Node without shows an error, the type of lnClass attribute has to be changed from Enum to String.
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tFCDA
	{		
		private string ldInstField;		
		private string prefixField;		
		private string lnClassField;		
		private string lnInstField;		
		private string doNameField;		
		private string daNameField;		
		private tFCEnum fcField;
		private tLDevice ldField;
		
		public tFCDA() 
		{
			this.prefixField = "";
		}
				
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("FCDA"), Description("The LD where the DO resides"), ReadOnly(true)]
		public string ldInst 
		{
			get 
			{
				if (this.ldInstField == null)
					return "";
				else
					return this.ldInstField;
			}
			set 
			{
				this.ldInstField = value;
			}
		}
		
		[System.Xml.Serialization.XmlIgnore]
		public tLDevice LDevice {
			
			get { return this.ldField; }
			
			set { this.ldField = value; }
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("FCDA"), Description("Prefix identifying together with lnInst and lnClass the LN where the DO resides")]		
		public string prefix 
		{
			get
			{
				return this.prefixField;
			}
			set
			{
				this.prefixField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("FCDA"), Description("LN class of the LN where the DO resides")]		
		public string lnClass 
		{
			get 
			{
				return this.lnClassField;
			}
			set 
			{
				this.lnClassField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("FCDA"), Description("Instance number of the LN where the DO resides")]		
		public string lnInst
		{
			get
			{
				return this.lnInstField;
			}
			set 
			{
				this.lnInstField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("FCDA"), Description("A name identifying the DO (within the LN).")]		
		public string doName 
		{
			get 
			{
				return this.doNameField;
			}
			set 
			{
				this.doNameField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("FCDA"), Description("The attribute name.")]		
		public string daName 
		{
			get
			{
				return this.daNameField;
			}
			set 
			{
				this.daNameField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("FCDA"), Description("All attributes of this functional constraint are selected")]		
		public tFCEnum fc
		{
			get
			{
				return this.fcField;
			}
			set 
			{
				this.fcField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tFCEnum
	{		
		ST,
		MX,
		CO,
		SP,
		SG,
		SE,
		SV,
		CF,
		DC,
		EX									
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tConfLNs 
	{		
		private bool fixPrefixField;		
		private bool fixLnInstField;
		
		public tConfLNs() 
		{
			/*this.fixPrefixField = false;
			this.fixLnInstField = false;*/
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ConfLNs"), Description("if false, prefixes can be set/changed")]
		public bool fixPrefix 
		{
			get 
			{
				return this.fixPrefixField;
			}
			set 
			{
				this.fixPrefixField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ConfLNs"), Description("if false. LN instance numbers can be changed")]	
		public bool fixLnInst 
		{
			get 
			{
				return this.fixLnInstField;
			}
			set 
			{
				this.fixLnInstField = value;
			}
		}
	}

	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSMVSettings))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSESettings))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLogSettings))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tReportSettings))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServiceSettings 
	{		
		private tServiceSettingsEnum cbNameField;		
		private tServiceSettingsEnum datSetField;
		
		public tServiceSettings() 
		{
			this.cbNameField = tServiceSettingsEnum.Fix;
			this.datSetField = tServiceSettingsEnum.Fix;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServiceSettings"), Description("Control block name")]	
		public tServiceSettingsEnum cbName 
		{
			get 
			{
				return this.cbNameField;
			}
			set 
			{
				this.cbNameField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServiceSettings"), Description("Data set reference")]	
		public tServiceSettingsEnum datSet 
		{
			get 
			{
				return this.datSetField;
			}
			set 
			{
				this.datSetField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tServiceSettingsEnum 
	{		
		Dyn,
		Conf,
		Fix,
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSMVSettings : tServiceSettings 
	{		
		private decimal[] smpRateField;		
		private tServiceSettingsEnum svIDField;		
		private tServiceSettingsEnum optFieldsField;		
		private tServiceSettingsEnum smpRateField1;
		
		public tSMVSettings()
		{
			this.svIDField = tServiceSettingsEnum.Fix;
			this.optFieldsField = tServiceSettingsEnum.Fix;
			this.smpRateField1 = tServiceSettingsEnum.Fix;
		}
		
		[System.Xml.Serialization.XmlElementAttribute("SmpRate")]
		[Category("SMVSettings"), Description("Specifies the samples per unit.")]			
		public decimal[] SmpRate 
		{
			get 
			{
				return this.smpRateField;
			}
			set 
			{
				this.smpRateField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("SMVSettings"), Description("Sample value identifier.")]					
		public tServiceSettingsEnum svID 
		{
			get 
			{
				return this.svIDField;
			}
			set
			{
				this.svIDField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("SMVSettings"), Description("Optional fields to include in report")]			
		public tServiceSettingsEnum optFields 
		{
			get 
			{
				return this.optFieldsField;
			}
			set
			{
				this.optFieldsField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SMVSettings"), Description("Specifies the samples per unit.")]					
		public tServiceSettingsEnum smpRate 
		{
			get
			{
				return this.smpRateField1;
			}
			set 
			{
				this.smpRateField1 = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tGSESettings : tServiceSettings 
	{		
		private tServiceSettingsEnum appIDField;		
		private tServiceSettingsEnum dataLabelField;
		
		public tGSESettings() 
		{
			this.appIDField = tServiceSettingsEnum.Fix;
			this.dataLabelField = tServiceSettingsEnum.Fix;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("GSESettings"), Description("A system wide unique identification of the application to which the GOOSE message"+
			"belongs.")]							
		public tServiceSettingsEnum appID 
		{
			get
			{
				return this.appIDField;
			}
			set
			{
				this.appIDField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("GSESettings"), Description("A value for the object reference if the corresponding element ist being sent")]
		public tServiceSettingsEnum dataLabel 
		{
			get 
			{
				return this.dataLabelField;
			}
			set 
			{
				this.dataLabelField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tLogSettings : tServiceSettings
	{		
		private tServiceSettingsEnum logEnaField;		
		private tServiceSettingsEnum trgOpsField;		
		private tServiceSettingsEnum intgPdField;
		
		public tLogSettings() 
		{
			this.logEnaField = tServiceSettingsEnum.Fix;
			this.trgOpsField = tServiceSettingsEnum.Fix;
			this.intgPdField = tServiceSettingsEnum.Fix;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LogSettings"), Description("Log Enable. TRUE enables immediate logging; FALSE prohibits logging until enabled online")]		
		public tServiceSettingsEnum logEna 
		{
			get 
			{
				return this.logEnaField;
			}
			set 
			{
				this.logEnaField = value;
			}
		}

		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LogSettings"), Description("TrgOps contains the reasons which cause the control block to store an entry into the log.")]		
		public tServiceSettingsEnum trgOps 
		{
			get 
			{
				return this.trgOpsField;
			}
			set 
			{
				this.trgOpsField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("LogSettings"), Description("Integrity period: logging all values initiated by the server based on a given period")]
		public tServiceSettingsEnum intgPd 
		{
			get 
			{
				return this.intgPdField;
			}
			set 
			{
				this.intgPdField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tReportSettings : tServiceSettings 
	{		
		private tServiceSettingsEnum rptIDField;		
		private tServiceSettingsEnum optFieldsField;		
		private tServiceSettingsEnum bufTimeField;	
		private tServiceSettingsEnum trgOpsField;		
		private tServiceSettingsEnum intgPdField;
		
		public tReportSettings()
		{
			// FIXME: Check/Delete default values
			this.rptIDField = tServiceSettingsEnum.Fix;
			this.optFieldsField = tServiceSettingsEnum.Fix;
			this.bufTimeField = tServiceSettingsEnum.Fix;
			this.trgOpsField = tServiceSettingsEnum.Fix;
			this.intgPdField = tServiceSettingsEnum.Fix;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportSettings"), Description("Identifier for the report control block")]
		public tServiceSettingsEnum rptID 
		{
			get 
			{
				return this.rptIDField;
			}
			set 
			{
				this.rptIDField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportSettings"), Description("Optional fields to include in report")]
		public tServiceSettingsEnum optFields
		{
			get
			{
				return this.optFieldsField;
			}
			set 
			{
				this.optFieldsField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportSettings"), Description("Buffer Time")]
		public tServiceSettingsEnum bufTime
		{
			get
			{
				return this.bufTimeField;
			}
			set 
			{
				this.bufTimeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportSettings"), Description("TrgOps contains the reasons which causes the control block to report a"+
			"value into the report.")]
		public tServiceSettingsEnum trgOps 
		{
			get 
			{
				return this.trgOpsField;
			}
			set
			{
				this.trgOpsField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportSettings"), Description("Integrity period: reporting all values initiated by the server based on this period")]
		public tServiceSettingsEnum intgPd 
		{
			get
			{
				return this.intgPdField;
			}
			set 
			{
				this.intgPdField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tServiceWithMaxAndClient))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tServiceWithMaxAndModify))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tServiceWithMaxAndMaxAttributes))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tServiceWithMaxAndMaxAttributesAndModify))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tServiceWithMax 
	{		
		private uint maxField;
		
		public tServiceWithMax()
		{
			this.maxField = 0;
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServiceWithMax"), Description("The maximum number of data sets")]
		public uint max 
		{
			get 
			{
				return this.maxField;
			}
			set 
			{
				this.maxField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServiceWithMaxAndClient : tServiceWithMax
	{		
		private bool clientField;
		
		public tServiceWithMaxAndClient() 
		{
			this.clientField = true;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServiceWithMaxAndClient"), Description("Client"), DefaultValue(true)]
		public bool client 
		{
			get 
			{
				return this.clientField;
			}
			set 
			{
				this.clientField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServiceWithMaxAndModify : tServiceWithMax
	{		
		private bool modifyField;
		
		public tServiceWithMaxAndModify()
		{
			this.modifyField = true;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServiceWithMaxAndModify"), Description("TRUE means that preconfigured data sets may be modified")]
		public bool modify 
		{
			get 
			{
				return this.modifyField;
			}
			set
			{
				this.modifyField = value;
			}
		}
	}

	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tServiceWithMaxAndMaxAttributesAndModify))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServiceWithMaxAndMaxAttributes : tServiceWithMax 
	{		
		private uint maxAttributesField;		
		private bool maxAttributesFieldSpecified;
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServiceWithMaxAndMaxAttributes"), Description("The maximum number of attributes allowed in a data set "+
        	" (an FCDA can contain several attributes)")]
		public uint maxAttributes 
		{
			get
			{
				return this.maxAttributesField;
			}
			set 
			{
				this.maxAttributesField = value;
			}
		}
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		[Category("ServiceWithMaxAndMaxAttributes"), Description("The maximum number of attributes specified in a data set "+
        	" (an FCDA can contain several attributes)")]		
		public bool maxAttributesSpecified
		{
			get 
			{
				return this.maxAttributesFieldSpecified;
			}
			set
			{
				this.maxAttributesFieldSpecified = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServiceWithMaxAndMaxAttributesAndModify : tServiceWithMaxAndMaxAttributes
	{		
		private bool modifyField;
		
		public tServiceWithMaxAndMaxAttributesAndModify() 
		{
			this.modifyField = true;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServiceWithMaxAndMaxAttributesAndModify"), Description("TRUE means that preconfigured data sets may be modified")]
		public bool modify 
		{
			get 
			{
				return this.modifyField;
			}
			set 
			{
				this.modifyField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServiceYesNo 
	{
		
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServices 
	{		
		private tServiceYesNo dynAssociationField;		
		private tServicesSettingGroups settingGroupsField;		
		private tServiceYesNo getDirectoryField;	
		private tServiceYesNo getDataObjectDefinitionField;
		private tServiceYesNo dataObjectDirectoryField;		
		private tServiceYesNo getDataSetValueField;		
		private tServiceYesNo setDataSetValueField;		
		private tServiceYesNo dataSetDirectoryField;		
		private tServiceWithMaxAndMaxAttributesAndModify confDataSetField;		
		private tServiceWithMaxAndMaxAttributes dynDataSetField;		
		private tServiceYesNo readWriteField;		
		private tServiceYesNo timerActivatedControlField;		
		private tServiceWithMax confReportControlField;		
		private tServiceYesNo getCBValuesField;		
		private tServiceWithMax confLogControlField;		
		private tReportSettings reportSettingsField;		
		private tLogSettings logSettingsField;		
		private tGSESettings gSESettingsField;		
		private tSMVSettings sMVSettingsField;		
		private tServiceYesNo gSEDirField;		
		private tServiceWithMaxAndClient gOOSEField;		
		private tServiceWithMaxAndClient gSSEField;		
		private tServiceYesNo fileHandlingField;		
		private tConfLNs confLNsField;		
		
		[Category("Services"), Description("All services for dynamic building of associations.")]
		public tServiceYesNo DynAssociation 
		{
			get 
			{
				return this.dynAssociationField;
			}
			set 
			{
				this.dynAssociationField = value;
			}
		}
		
		[Category("Services"), Description("Setting group services belong to the setting group control block.")]
		public tServicesSettingGroups SettingGroups
		{
			get 
			{
				return this.settingGroupsField;
			}
			set 
			{
				this.settingGroupsField = value;
			}
		}
		
		[Category("Services"), Description("Service for reading the contents of a server, that is the LD and LN directories.")]
		public tServiceYesNo GetDirectory 
		{
			get 
			{
				return this.getDirectoryField;
			}
			set 
			{
				this.getDirectoryField = value;
			}
		}
		
		[Category("Services"), Description("Service to retrieve the complete list of all DA definitions of the referenced data that are"+
			" visible and thus accessible to the requesting client by the referenced LN.")]
		public tServiceYesNo GetDataObjectDefinition 
		{
			get 
			{
				return this.getDataObjectDefinitionField;
			}
			set 
			{
				this.getDataObjectDefinitionField = value;
			}
		}
		
		[Category("Services"), Description("Service to get the DATA defined in a LN.")]
		public tServiceYesNo DataObjectDirectory 
		{
			get 
			{
				return this.dataObjectDirectoryField;
			}
			set 
			{
				this.dataObjectDirectoryField = value;
			}
		}
		
		[Category("Services"), Description("Service to retrieve all values of data referenced by the members of the data set.")]
		public tServiceYesNo GetDataSetValue 
		{
			get 
			{
				return this.getDataSetValueField;
			}
			set 
			{
				this.getDataSetValueField = value;
			}
		}
		
		[Category("Services"), Description("Service to write all values of data referenced by the members of the data set.")]
		public tServiceYesNo SetDataSetValue 
		{
			get 
			{
				return this.setDataSetValueField;
			}
			set
			{
				this.setDataSetValueField = value;
			}
		}
		
		[Category("Services"), Description("Service to retrieve FCD/FCDA of all members referenced in the data set.")]
		public tServiceYesNo DataSetDirectory 
		{
			get 
			{
				return this.dataSetDirectoryField;
			}
			set 
			{
				this.dataSetDirectoryField = value;
			}
		}
		
		[Category("Services"), Description("service to configure new data sets up to the defined max.")]
		public tServiceWithMaxAndMaxAttributesAndModify ConfDataSet
		{
			get 
			{
				return this.confDataSetField;
			}
			set 
			{
				this.confDataSetField = value;
			}
		}
		
		[Category("Services"), Description("Services to dynamically create and delete data sets.")]
		public tServiceWithMaxAndMaxAttributes DynDataSet 
		{
			get 
			{
				return this.dynDataSetField;
			}
			set 
			{
				this.dynDataSetField = value;
			}
		}
		
		[Category("Services"), Description("Basic data read and write facility.")]
		public tServiceYesNo ReadWrite 
		{
			get 
			{
				return this.readWriteField;
			}
			set
			{
				this.readWriteField = value;
			}
		}
		
		[Category("Services"), Description("This element specifies that timer activated control services are supported.")]
		public tServiceYesNo TimerActivatedControl 
		{
			get
			{
				return this.timerActivatedControlField;
			}
			set 
			{
				this.timerActivatedControlField = value;
			}
		}
		
		[Category("Services"), Description("Capability of static creation of report control blocks.")]
		public tServiceWithMax ConfReportControl 
		{
			get 
			{
				return this.confReportControlField;
			}
			set 
			{
				this.confReportControlField = value;
			}
		}
		
		[Category("Services"), Description("Read values of control blocks.")]
		public tServiceYesNo GetCBValues 
		{
			get 
			{
				return this.getCBValuesField;
			}
			set
			{
				this.getCBValuesField = value;
			}
		}
		
		[Category("Services"), Description("Capability of static creation of log control blocks.")]
		public tServiceWithMax ConfLogControl 
		{
			get 
			{
				return this.confLogControlField;
			}
			set 
			{
				this.confLogControlField = value;
			}
		}
		
		[Category("Services"), Description("The report control block attributes for which online setting is possible.")]
		public tReportSettings ReportSettings
		{
			get 
			{
				return this.reportSettingsField;
			}
			set 
			{
				this.reportSettingsField = value;
			}
		}
		
		[Category("Services"), Description("The log control block attributes for which online setting is possible.")]
		public tLogSettings LogSettings 
		{
			get 
			{
				return this.logSettingsField;
			}
			set
			{
				this.logSettingsField = value;
			}
		}
		
		[Category("Services"), Description("The GSE control block attributes for which online setting is possible.")]
		public tGSESettings GSESettings 
		{
			get 
			{
				return this.gSESettingsField;
			}
			set 
			{
				this.gSESettingsField = value;
			}
		}
		
		[Category("Services"), Description("The SMV control block attributes for which online setting is possible.")]
		public tSMVSettings SMVSettings
		{
			get 
			{
				return this.sMVSettingsField;
			}
			set 
			{
				this.sMVSettingsField = value;
			}
		}
		
		[Category("Services"), Description("GSE directory services.")]
		public tServiceYesNo GSEDir
		{
			get
			{
				return this.gSEDirField;
			}
			set 
			{
				this.gSEDirField = value;
			}
		}
		
		[Category("Services"), Description("This element shows that the IED can be a GOOSE server and/or client.")]
		public tServiceWithMaxAndClient GOOSE 
		{
			get 
			{
				return this.gOOSEField;
			}
			set 
			{
				this.gOOSEField = value;
			}
		}
		
		[Category("Services"), Description("This element shows that the IED can be a binary data GSSE server and/or client.")]
		public tServiceWithMaxAndClient GSSE 
		{
			get 
			{
				return this.gSSEField;
			}
			set 
			{
				this.gSSEField = value;
			}
		}
		
		[Category("Services"), Description("All file handling services.")]
		public tServiceYesNo FileHandling 
		{
			get 
			{
				return this.fileHandlingField;
			}
			set
			{
				this.fileHandlingField = value;
			}
		}
		
		[Category("Services"), Description("Describes what can be configured for LNs defined in an ICD file.")]
		public tConfLNs ConfLNs
		{
			get
			{
				return this.confLNsField;
			}
			set 
			{
				this.confLNsField = value;
			}
		}
	}
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServicesSettingGroups
	{		
		private tServiceYesNo sGEditField;		
		private tServiceYesNo confSGField;
		
		[Category("ServicesSettingGroups"), Description("The capability of online editing is decided with the SGEdit element.")]
		public tServiceYesNo SGEdit 
		{
			get
			{
				return this.sGEditField;
			}
			set 
			{
				this.sGEditField = value;
			}
		}
		
		[Category("ServicesSettingGroups"), Description("The capability to configure the (number of) setting groups by SCL can be also "+
 			"available.")]
		public tServiceYesNo ConfSG 
		{
			get
			{
				return this.confSGField;
			}
			set
			{
				this.confSGField = value;
			}
		}
	}

	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tIDNaming))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEnumType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDAType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDOType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLNodeType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tNaming))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSDO))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubNetwork))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControlWithIEDName))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSampledValueControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSEControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControlWithTriggerOpt))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLogControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tReportControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDataSet))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAccessPoint))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tIED))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLNodeContainer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConnectivityNode))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPowerSystemResource))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubFunction))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tFunction))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTapChanger))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGeneralEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPowerTransformer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAbstractConductingEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTransformerWinding))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConductingEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEquipmentContainer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBay))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tVoltageLevel))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubstation))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tUnNaming))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDO))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAbstractDataAttribute))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBDA))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDA))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tCommunication))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSCLControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSettingControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tInputs))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDAI))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSDI))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDOI))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControlBlock))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSMV))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSE))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConnectedAP))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tRptEnabled))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAnyLN))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLN0))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLN))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLDevice))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tServer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTerminal))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLNode))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tBaseElement 
	{		
		private System.Xml.XmlElement[] anyField;		
		private tText textField;		
		private tPrivate[] privateField;		
		private System.Xml.XmlAttribute[] anyAttrField;
		
		
		/*
		 * TODO: This implementation fails to add new XmlAttributes because no XmlDocument exists
		 * 
		private System.Collections.Generic.List<System.Xml.XmlAttribute> anyAttrField;
		
		[Category("BaseElement"), Browsable(false)]
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get 
			{
				return this.anyAttrField.ToArray();
			}
			set 
			{
				if (value == null) 
					this.anyAttrField.Clear();
				else {
					for(int i = 0; i < value.Length; i++) {
						this.anyAttrField.Add(value[i]);
					}
				}
					
			}
		}
		
		public bool AddCustomAttribute (string name, string val, string prefix, string ns) {
			if(this.anyAttrField.Count > 0) {
				
			}
			return false;
		}
		
		public tBaseElement() {
			anyAttrField = new System.Collections.Generic.List<System.Xml.XmlAttribute>();
		}
		
		
		*/
		
		[Category("BaseElement"), Browsable(false)]
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get 
			{
				return this.anyAttrField;
			}
			set 
			{
				this.anyAttrField = value;
			}
		}
		
		
		//Name spaces
		[System.Xml.Serialization.XmlNamespaceDeclarations]
    	public System.Xml.Serialization.XmlSerializerNamespaces xmlns;
		
		
		[System.Xml.Serialization.XmlAnyElementAttribute()]
		[Category("BaseElement"), Browsable(false)]
		public System.Xml.XmlElement[] Any 
		{
			get 
			{
				return this.anyField;
			}
			set
			{
				this.anyField = value;
			}
		}
		
		[Category("BaseElement"), Browsable(false)]
		public tText Text 
		{
			get 
			{
				return this.textField;
			}
			set
			{
				this.textField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("Private")]
		[Category("BaseElement"), Browsable(false)]
		public tPrivate[] Private 
		{
			get
			{
				return this.privateField;
			}
			set
			{
				this.privateField = value;
			}
		}
		
		
	}
	
	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEnumType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDAType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDOType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLNodeType))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tIDNaming : tBaseElement 
	{		
		private string idField;		
		private string descField;
		
		public tIDNaming() {}
		
		public tIDNaming(string id)
		{
			this.id = id;
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Identifier"), Description("Mandatory identifier attribute."), ReadOnly(true)]
		public string id 
		{
			get 
			{
				return this.idField;
			}
			set 
			{
				this.idField = value;
			}
		}
				
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Identifier"), Description("Description attribute.")]		
		public string desc
		{
			get 
			{
				return this.descField;
			}
			set
			{
				this.descField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tEnumType : tIDNaming 
	{		
		private tEnumVal[] enumValField;
		
		[System.Xml.Serialization.XmlElementAttribute("EnumVal")]
		[Category("EnumType"), Browsable(false)]
		public tEnumVal[] EnumVal 
		{
			get 
			{
				return this.enumValField;
			}
			set 
			{
				this.enumValField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tDAType : tIDNaming 
	{		
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
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tBDA : tAbstractDataAttribute 
	{
		
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 *
	 * The type of the attribute "bTypeField" was changed from string to "tBasciTypeEnum".
	*/		
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBDA))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDA))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tAbstractDataAttribute : tUnNaming
	{		
		private tVal[] valField;		
		private string nameField;		
		private string sAddrField;		
		private tBasicType bTypeField;		
		private tValKindEnum valKindField;		
		private string typeField;		
		private uint countField;
		
		public tAbstractDataAttribute() 
		{
			//this.valKindField = tValKindEnum.Set;
			//this.countField = ((uint)(0));
			this.bTypeField = new tBasicType();
		}
		
		[System.Xml.Serialization.XmlElementAttribute("Val")]
		[Category("AbstractDataAttribute"), Browsable(false)]
		public tVal[] Val
		{
			get 
			{
				return this.valField;
			}
			set 
			{
				this.valField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("AbstractDataAttribute"), Description("The attribute name."), ReadOnly(true)]
		public string name 
		{
			get
			{
				return this.nameField;
			}
			set 
			{
				this.nameField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("AbstractDataAttribute"), Description("A short address of this BDA attribute.")]
		public string sAddr
		{
			get
			{
				return this.sAddrField;
			}
			set 
			{
				this.sAddrField = value;
			}
		}
		
		[System.Xml.Serialization.XmlIgnore]
		public tBasicTypeEnum bTypeEnum 
		{
			get { return this.bTypeField.bTypeEnum; }
			set { this.bTypeField.bTypeEnum = value; }
		}
		
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("AbstractDataAttribute"), Description("The basic type of the attribute."), ReadOnly(true)]
		public string bType 
		{
			get 
			{
				return this.bTypeField.bType;
			}
			set 
			{
				this.bTypeField.bType = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("AbstractDataAttribute"), Description("Determines how the value shall be interpreted if any is given."), ReadOnly(true)]
		public tValKindEnum valKind 
		{
			get 
			{
				return this.valKindField;
			}
			set 
			{
				this.valKindField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("AbstractDataAttribute"), Description("It's used to refer to the appropriate enumeration type or DAType definition."), ReadOnly(true)]
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
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("AbstractDataAttribute"), Description("Shall state the number of array elements in the case where the attribute is an "+
			"array."), ReadOnly(true)]
		public uint count 
		{
			get 
			{
				return this.countField;
			}
			set 
			{
				this.countField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tValKindEnum 
	{
		Spec,
		Conf,
		RO,
		Set
	}

	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDO))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAbstractDataAttribute))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBDA))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDA))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tCommunication))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSCLControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSettingControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tInputs))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDAI))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSDI))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDOI))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControlBlock))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSMV))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSE))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConnectedAP))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tRptEnabled))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAnyLN))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLN0))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLN))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLDevice))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tServer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTerminal))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLNode))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tUnNaming : tBaseElement
	{		
		private string descField;
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Description"), Description("Some descriptive text for the attribute.")]
		public string desc 
		{
			get
			{
				return this.descField;
			}
			set 
			{
				this.descField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tDO : tUnNaming
	{		
		private string nameField;		
		private string typeField;		
		private string accessControlField;		
		private bool transientField;
		
		public tDO()
		{
			this.transientField = false;
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="Name")]
		[Category("DO"), Description("The DATA name."), ReadOnly(true)]
		public string name
		{
			get 
			{
				return this.nameField;
			}
			set 
			{
				this.nameField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("DO"), Description("The type references the id of a DOType definition."), 
		 ReadOnly(true)]
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
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("DO"), Description("Access control definition for this DO.")]
		public string accessControl 
		{
			get 
			{
				return this.accessControlField;
			}
			set 
			{
				this.accessControlField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DO"), Description("If set to true, it indicates that the Transient definition applies.")]
		public bool transient 
		{
			get
			{
				return this.transientField;
			}
			set 
			{
				this.transientField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSCLControl : tUnNaming 
	{
		
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tSettingControl : tUnNaming
	{		
		private uint numOfSGsField;		
		private uint actSGField;
		
		public tSettingControl()
		{
			this.numOfSGsField = ((uint) (1));
			this.actSGField = ((uint)(1));
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SettingControl"), Description("The number of setting groups available.")]
		public uint numOfSGs 
		{
			get 
			{
				return this.numOfSGsField;
			}
			set 
			{
				this.numOfSGsField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SettingControl"), Description("TThe number of the setting group to be activated when loading the configuration.")]
		public uint actSG 
		{
			get
			{
				return this.actSGField;
			}
			set 
			{
				this.actSGField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tInputs : tUnNaming 
	{		
		private tExtRef[] extRefField;
		
		[System.Xml.Serialization.XmlElementAttribute("ExtRef")]
		
		[Category("Inputs"), Browsable(false)]
		public tExtRef[] ExtRef
		{
			get
			{
				return this.extRefField;
			}
			set 
			{
				this.extRefField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tDAI : tUnNaming 
	{		
		private tVal[] valField;		
		private string nameField;		
		private string sAddrField;		
		private tValKindEnum valKindField;		
		private uint ixField;		
		private bool ixFieldSpecified;
		
		public tDAI()
		{
			this.valKindField = tValKindEnum.Set;
		}
		
		[System.Xml.Serialization.XmlElementAttribute("Val")]
		[Category("DAI"), Browsable(false)]
		public tVal[] Val 
		{
			get 
			{
				return this.valField;
			}
			set 
			{
				this.valField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DAI"), Description("The name of the Data attribute whose value is given."), ReadOnly(true)]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("DAI"), Description("Short address of this Data attribute.")]
		public string sAddr 
		{
			get 
			{
				return this.sAddrField;
			}
			set 
			{
				this.sAddrField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DAI"), Description("The meaning of the value from the engineering phases, if any name is given.")]		
		public tValKindEnum valKind 
		{
			get 
			{
				return this.valKindField;
			}
			set 
			{
				this.valKindField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DAI"), Description("Index of the DAI element in case of an array type.")]		
		public uint ix 
		{
			get 
			{
				return this.ixField;
			}
			set 
			{
				this.ixField = value;
			}
		}
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		[Category("DAI"), Description("Index of the DAI element in case of an array type.")]		
		public bool ixSpecified
		{
			get
			{
				return this.ixFieldSpecified;
			}
			set 
			{
				this.ixFieldSpecified = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed. 1.0:
	 * tSDI -> SDIField
	 * tDAI -> DAIField
	 * 
	 * The attribute "itemsField" was deleted to fulfill standar IEC 61850 Ed. 1.0.
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tSDI : tUnNaming 
	{		
		private string nameField;		
		private uint ixField;		
		private bool ixFieldSpecified;		
		private tSDI[] SDIField;
		private tDAI[] DAIField;
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SDI"), Description("Name of the SDI (structure part)"), ReadOnly(true)]
		public string name 
		{
			get 
			{
				return this.nameField;
			}
			set 
			{
				this.nameField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SDI"), Description("Index of the SDI element in case of an array type.")]	
		public uint ix 
		{
			get 
			{
				return this.ixField;
			}
			set
			{
				this.ixField = value;
			}
		}
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		[Category("SDI"), Description("Index of the SDI element in case of an array type.")]	
		public bool ixSpecified 
		{
			get 
			{
				return this.ixFieldSpecified;
			}
			set 
			{
				this.ixFieldSpecified = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("SDI", typeof(tSDI))]
		[Category("SDI"), Browsable(false)]
		public tSDI[] SDI	
		{
			get 
			{
			 	return this.SDIField;
			}
			set
			{
				this.SDIField = value;
			}		
		}
		
		[System.Xml.Serialization.XmlElementAttribute("DAI", typeof(tDAI))]
		[Category("SDI"), Browsable(false)]		
		public tDAI[] DAI
		{
			get
			{
				return this.DAIField;
			}
			set
			{
				this.DAIField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed. 1.0:
	 * tSDI -> SDIField
	 * tDAI -> DAIField
	 * 
	 * The attribute "itemsField" was deleted to fulfill standar IEC 61850 Ed. 1.0.
	 *
	 * Only one array of TSDI or TDAI elements should be choose. 
	 * When an element is selected, the "ADD" option must be hidden, so elements of another type could not be added. 
	 * This point is defined on the XSD files contained on the IEC 61850 standard, as follows:
	 * <xs:choice minOccurs="0" maxOccurs="unbounded">
	 *	<xs:element name="SDI" type="tSDI"/>
	 *	<xs:element name="DAI" type="tDAI"/>
	 * </xs:choice>
	 * 
	 * According to the Reference Manual of XML, "The <choiCe> option describes a selection between 
	 * some elements or an elements group that can show up on the instance of the XML document"
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tDOI : tUnNaming 
	{		
		private string nameField;		
		private uint ixField;		
		private bool ixFieldSpecified;		
		private string accessControlField;		
		private tSDI[] SDIField;
		private tDAI[] DAIField;
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="Name")]	
		[Category("DOI"), Description("A standardised DO name"), ReadOnly(true)]
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("DOI"), Description("Index of a data element in case of an array type")]
		public uint ix
		{
			get 
			{
				return this.ixField;
			}
			set
			{
				this.ixField = value;
			}
		}
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		[Category("DOI"), Description("Index of a data element in case of an array type")]
		public bool ixSpecified 
		{
			get
			{
				return this.ixFieldSpecified;
			}
			set 
			{
				this.ixFieldSpecified = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]	
		[Category("DOI"), Description("Access control definition for this data.")]
		public string accessControl 
		{
			get
			{
				return this.accessControlField;
			}
			set
			{
				this.accessControlField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("SDI", typeof(tSDI))]
		[Category("DOI"), Browsable(false)]
		public tSDI[] SDI
		{
			get 
			{
			 	return this.SDIField;
			}
			set
			{
				this.SDIField = value;
			}		
		}
		
		[System.Xml.Serialization.XmlElementAttribute("DAI", typeof(tDAI))]
		[Category("DOI"), Browsable(false)]
		public tDAI[] DAI
		{
			get
			{
				return this.DAIField;
			}
			set
			{
				this.DAIField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The value of the attribute "addressField" of tP[] was changed to tAddress, to fulfill the IEC 61850 Ed.1.0 standard.
	*/		
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSMV))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSE))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tControlBlock : tUnNaming 
	{		
		private tAddress addressField;		
		private string ldInstField;		
		private string cbNameField;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		private tLDevice tLDevice;
		
		[Category("ControlBlock"), Description("This contains the address parameters of this access point at this bus, at least "+
			"one parameter"), Browsable(false)]
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
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ControlBlock"), Description("The instance identification of the LD within this IED, on which the control block is located."), ReadOnlyAttribute(true)]
		public string ldInst 
		{
			get 
			{
				if(this.tLDevice != null)
				{
					return this.tLDevice.inst;
				}
				return this.ldInstField;
			}
			set 
			{
				if(this.tLDevice != null)
				{
					this.tLDevice.inst = this.ldInstField = value;
				}
				this.ldInstField = value;
			}
		}

		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ControlBlock"), Description("The name of the control block within the LLN0 of the LD ldInst."), ReadOnlyAttribute(true)]
		public string cbName 
		{
			get 
			{
				return this.cbNameField;
			}
			set
			{
				this.cbNameField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSMV : tControlBlock 
	{
		//se agregan estas propiedades por q no se pueden acceder a ellas debido a la herencia
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		private string ldInstField;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		private tLDevice tLDevice;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		private string cbNameField;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		private tSampledValueControl tSampledValueControl;
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ControlBlock"), Description("The name of the control block within the LLN0 of the LD ldInst."), ReadOnlyAttribute(true)]		
		public string cbName
		{
			get 
			{
				if(this.tSampledValueControl != null)
				{
					return this.tSampledValueControl.name;
				}
				return this.cbNameField;
			}
			set
			{
				if(this.tSampledValueControl != null)
				{
					this.tSampledValueControl.name = this.cbNameField = value;
				}
					this.cbNameField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ControlBlock"), Description("The instance identification of the LD within this IED, on which the control block is located."), ReadOnlyAttribute(true)]
		public string ldInst 
		{
			get 
			{
				if(this.tLDevice != null)
				{
					return this.tLDevice.inst;
				}
				return this.ldInstField;
			}
			set 
			{
				if(this.tLDevice != null)
				{
					this.tLDevice.inst = this.ldInstField = value;
				}
				this.ldInstField=value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tGSE : tControlBlock 
	{		
		private tDurationInMilliSec minTimeField;		
		private tDurationInMilliSec maxTimeField;
		
		//victor, se agregan por el acceso a las propiedades heredades
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		private string ldInstField;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		private tLDevice tLDevice;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		private string cbNameField;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		private tGSEControl tGSEControl;
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ControlBlock"), Description("The name of the control block within the LLN0 of the LD ldInst."), ReadOnlyAttribute(true)]
		public string cbName 
		{
			get 
			{
				if(this.tGSEControl != null)
				{
					return this.tGSEControl.name;
				}
				return this.cbNameField;
			}
			set
			{
				if(this.tGSEControl != null)
				{
					this.tGSEControl.name = this.cbNameField = value;
				}
					this.cbNameField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ControlBlock"), Description("The instance identification of the LD within this IED, on which the control block is located."), ReadOnlyAttribute(true)]
		public string ldInst 
		{
			get 
			{
				if(this.tLDevice != null)
				{
					return this.tLDevice.inst;
				}
				return this.ldInstField;
			}
			set 
			{
				if(this.tLDevice != null)
				{
					this.tLDevice.inst = this.ldInstField = value;
				}
				this.ldInstField=value;
			}
		}
		
		[Category("GSE"), Description("The maximal allowed sending delay on a data change in ms."), 
		 Browsable(false)]
		public tDurationInMilliSec MinTime
		{
			get 
			{
				return this.minTimeField;
			}
			set 
			{
				this.minTimeField = value;
			}
		}
				
		[Category("GSE"), Description("The source supervision time in ms (supervision heartbeat cycle time)."), 
		 Browsable(false)]
		public tDurationInMilliSec MaxTime 
		{
			get 
			{
				return this.maxTimeField;
			}
			set 
			{
				this.maxTimeField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed. 1.0:
	 * unit -> unitField
	 * multiplier -> multiplierField
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]			
	public partial class tDurationInMilliSec : tValueWithUnit 
	{
		private tSIUnitEnum unitField;		
		private tUnitMultiplierEnum multiplierField;
		
		public tDurationInMilliSec()
		{
			this.unitField = tSIUnitEnum.s;
			this.multiplierField = tUnitMultiplierEnum.m;
		}

		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DurationInMilliSec"), Description("It shall define the SI unit")]
		public tSIUnitEnum unit 
		{
			get 
			{
				return this.unitField;
			}
			set
			{
				this.unitField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DurationInMilliSec"), Description("It shall define the multiplier value")]
		public tUnitMultiplierEnum multiplier 
		{
			get 
			{
				return this.multiplierField;
			}
			set
			{
				this.multiplierField = value;
			}
		}
	}

	/* 
	 * The class "tAddress" was added to fulfill standard IEC 61850 Ed. 1.0.	 
	*/		
	public partial class tAddress 
	{		
		private tP[] pField;
		
		[System.Xml.Serialization.XmlElementAttribute("P", IsNullable=false)]
		[Category("Address"), Description("The different parameters are defined within the contained P elements."),
		  Browsable(false)]
		public tP[] P 
		{
			get
			{
				return this.pField;
			}
			set 
			{
				this.pField = value;
			}
		}		
	}
	
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
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tRptEnabled : tUnNaming
	{		
		private tClientLN[] clientLNField;		
		private uint maxField;
		
		public tRptEnabled() 
		{
			this.maxField = ((uint)(1));
		}

		[Category("RptEnabled"), Browsable(false)]
		[System.Xml.Serialization.XmlElementAttribute("ClientLN")]		
		public tClientLN[] ClientLN 
		{
			get 
			{
				return this.clientLNField;
			}
			set 
			{
				this.clientLNField = value;
			}
		}
		
		[Category("RptEnabled"), Description("Defines the maximum number of report control blocks of this type.")]
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		public uint max 
		{
			get
			{
				return this.maxField;
			}
			set 
			{
				this.maxField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLN0))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLN))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tAnyLN : tUnNaming 
	{		
		private tDataSet[] dataSetField;		
		private tReportControl[] reportControlField;		
		private tLogControl[] logControlField;		
		private tDOI[] dOIField;		
		private tInputs inputsField;		
		private string lnTypeField;
		
		[System.Xml.Serialization.XmlElementAttribute("DataSet")]
		[Category("LN"), Browsable(false)]
		public tDataSet[] DataSet 
		{
			get 
			{
				return this.dataSetField;
			}
			set
			{
				this.dataSetField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("ReportControl")]
		[Category("LN"), Browsable(false)]
		public tReportControl[] ReportControl 
		{
			get 
			{
				return this.reportControlField;
			}
			set 
			{
				this.reportControlField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("LogControl")]
		[Category("LN"), Browsable(false)]
		public tLogControl[] LogControl 
		{
			get 
			{
				return this.logControlField;
			}
			set 
			{
				this.logControlField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("DOI")]
		[Category("LN"), Browsable(false)]
		public tDOI[] DOI 
		{
			get 
			{
				return this.dOIField;
			}
			set 
			{
				this.dOIField = value;
			}
		}
		
		[Category("LN"), Description("Input"), Browsable(false)]
		public tInputs Inputs
		{
			get
			{
				return this.inputsField;
			}
			set 
			{
				this.inputsField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LN"), Description("The instantiable type definition of this logical node.")]
		public string lnType
		{
			get 
			{
				return this.lnTypeField;
			}
			set 
			{
				this.lnTypeField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tDataSet : tNaming 
	{		
		private static int index = 0;
		private tFCDA[] fCDAField;
		
		public tDataSet()
		{
			if(this.name == null)
			{
				this.name = "DataSet" + ( ++ index ).ToString();
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("FCDA")]
		[Category("DataSet"), Browsable(false)]
		public tFCDA[] FCDA 
		{
			get 
			{
				return this.fCDAField;
			}
			set 
			{
				this.fCDAField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSDO))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubNetwork))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControlWithIEDName))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSampledValueControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSEControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControlWithTriggerOpt))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLogControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tReportControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDataSet))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAccessPoint))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tIED))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLNodeContainer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConnectivityNode))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPowerSystemResource))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubFunction))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tFunction))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTapChanger))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGeneralEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPowerTransformer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAbstractConductingEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTransformerWinding))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConductingEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEquipmentContainer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBay))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tVoltageLevel))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubstation))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tNaming : tBaseElement 
	{		
		private string nameField;		
		private string descField;
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("General Information"), Description("A name used as a technical key to designate the object.")]
		public string name 
		{
			get
			{
				return this.nameField;
			}
			set
			{
				if ( value != "")
				{
					this.nameField = value;
				}
				else
				{
					this.name = nameField;
				}
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("General Information"), Description("It is used as an operator- or user-related object identification.")]		
		public string desc 
		{
			get
			{
				return this.descField;
			}
			set
			{
				this.descField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSDO : tNaming
	{		
		private string typeField;
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("SDO"), Description("References the DOType defining the contents of the SDO.")]	
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
	}

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
			
			System.Array.Resize<tConnectedAP>(ref this.connectedAPField, 
				                              this.connectedAPField.GetLength(0) + 1);
			int index = this.connectedAPField.GetLength(0) - 1;
			this.connectedAPField[index] = ap;
			return index;
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed. 1.0:
	 * unit -> unitField
	 * multiplier -> multiplierField
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tBitRateInMbPerSec : tValueWithUnit 
	{
		private tSIUnitEnum unitField;		
		private tUnitMultiplierEnum multiplierField;
		
		public tBitRateInMbPerSec()
		{
			this.unitField = tSIUnitEnum.bs;
			this.multiplierField = tUnitMultiplierEnum.M;
		}

		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("BitRateInMbPerSec"), Description("It defines the unit of the bit rate")]
		public tSIUnitEnum unit 
		{
			get 
			{
				return this.unitField;
			}
			set 
			{
				this.unitField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("BitRateInMbPerSec"), Description("It shall define the multiplier value")]
		public tUnitMultiplierEnum multiplier
		{
			get
			{
				return this.multiplierField;
			}
			set 
			{
				this.multiplierField = value;
			}
		}
	}

	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControlWithIEDName))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSampledValueControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSEControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControlWithTriggerOpt))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLogControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tReportControl))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tControl : tNaming
	{		
		private static int index = 0;
		private string datSetField;
		
		public tControl()
		{
			if(this.name == null)
			{
				this.name = "Control" + ( ++ index ).ToString();
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Control"), Description("Data set reference"), BrowsableAttribute(false)]
		public string datSet 
		{
			get 
			{
				return this.datSetField;
			}
			set 
			{
				this.datSetField = value;
			}
		}
	}

	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSampledValueControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSEControl))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tControlWithIEDName : tControl 
	{		
		private string[] iEDNameField;		
		private uint confRevField;		
		private bool confRevFieldSpecified;
		
		[System.Xml.Serialization.XmlElementAttribute("IEDName", DataType="normalizedString")]
		[Category("ControlWithIEDName"), Description("The name of the IED."), Browsable(false)]
		public string[] IEDName
		{
			get
			{
				return this.iEDNameField;
			}
			set 
			{
				this.iEDNameField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ControlWithIEDName"), Description("The configuration revision number of a control block")]
		public uint confRev 
		{
			get 
			{
				return this.confRevField;
			}
			set 
			{
				this.confRevField = value;
			}
		}
		
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		[Category("ControlWithIEDName"), Description("The configuration revision number of a control block")]
		public bool confRevSpecified 
		{
			get 
			{
				return this.confRevFieldSpecified;
			}
			set 
			{
				this.confRevFieldSpecified = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSampledValueControl : tControlWithIEDName 
	{		
		private tSampledValueControlSmvOpts smvOptsField;		
		private string smvIDField;		
		private bool multicastField;		
		private uint smpRateField;		
		private uint nofASDUField;
		
		public tSampledValueControl()
		{
			this.multicastField = true;
		}
			
		[Category("SampledValueControl"), Description("Sampled Values Options")]
		public tSampledValueControlSmvOpts SmvOpts 
		{
			get 
			{
				return this.smvOptsField;
			}
			set
			{
				this.smvOptsField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("SampledValueControl"), Description("Idenitifier of the SMV, (Multicast CB or Unicast CB)")]
		public string smvID
		{
			get 
			{
				return this.smvIDField;
			}
			set 
			{
				this.smvIDField = value;
			}
		}
			
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SampledValueControl"), Description("If it's false indicates Unicast SMV services")]
		public bool multicast 
		{
			get
			{
				return this.multicastField;
			}
			set
			{
				this.multicastField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SampledValueControl"), Description("Sample rate")]
		public uint smpRate
		{
			get
			{
				return this.smpRateField;
			}
			set 
			{
				this.smpRateField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SampledValueControl"), Description("Number of ASDU (Application service data unit)")]
		public uint nofASDU 
		{
			get
			{
				return this.nofASDUField;
			}
			set
			{
				this.nofASDUField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSampledValueControlSmvOpts
	{		
		private bool refreshTimeField;		
		private bool sampleSynchronizedField;		
		private bool sampleRateField;		
		private bool securityField;		
		private bool dataRefField;
		
		public tSampledValueControlSmvOpts() 
		{
			this.refreshTimeField = false;
			this.sampleSynchronizedField = false;
			this.sampleRateField = false;
			this.securityField = false;
			this.dataRefField = false;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("SampledValueControlSmvOpts"), Description("Time of refresh activity")]
		public bool refreshTime 
		{
			get 
			{
				return this.refreshTimeField;
			}
			set 
			{
				this.refreshTimeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SampledValueControlSmvOpts"), Description("Samples are synchronized by clock signals")]
		public bool sampleSynchronized 
		{
			get 
			{
				return this.sampleSynchronizedField;
			}
			set 
			{
				this.sampleSynchronizedField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SampledValueControlSmvOpts"), Description("Sample rate from the instance")]
		public bool sampleRate 
		{
			get 
			{
				return this.sampleRateField;
			}
			set
			{
				this.sampleRateField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SampledValueControlSmvOpts"), Description(" ")]
		public bool security
		{
			get
			{
				return this.securityField;
			}
			set 
			{
				this.securityField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SampledValueControlSmvOpts"), Description("If true, then the data set reference is included in the SV message")]
		public bool dataRef 
		{
			get 
			{
				return this.dataRefField;
			}
			set 
			{
				this.dataRefField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tGSEControl : tControlWithIEDName 
	{		
		private tGSEControlTypeEnum typeField;		
		private string appIDField;
		
		public tGSEControl() 
		{
			this.typeField = tGSEControlTypeEnum.GOOSE;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("GSEControl"), Description("GSE Type")]
		public tGSEControlTypeEnum type 
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
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("GSEControl"), Description("A system wide unique identification of the application to which the GOOSE message "+
			"belongs.")]
		public string appID
		{
			get 
			{
				return this.appIDField;
			}
			set 
			{
				this.appIDField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	[Category("GSEControl"), Description("GSE Type")]
	public enum tGSEControlTypeEnum 
	{		
		GSSE,
		GOOSE,
	}

	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLogControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tReportControl))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tControlWithTriggerOpt : tControl 
	{		
		private tTrgOps trgOpsField;		
		private uint intgPdField;
		
		public tControlWithTriggerOpt()
		{
			this.intgPdField = ((uint)(0));
		}
		
		[Category("ControlWithTriggerOpt"), Description("Reasons which causes the control block to report a "+
		 "value into the report."), Browsable(false)]
		public tTrgOps TrgOps 
		{
			get 
			{
				return this.trgOpsField;
			}
			set
			{
				this.trgOpsField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ControlWithTriggerOpt"), Description("reporting all values initiated by the server based on this period.")]
		public uint intgPd
		{
			get 
			{
				return this.intgPdField;
			}
			set 
			{
				this.intgPdField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tLogControl : tControlWithTriggerOpt 
	{		
		private string logNameField;		
		private bool logEnaField;		
		private bool reasonCodeField;
		
		public tLogControl() 
		{
			this.logEnaField = true;
			this.reasonCodeField = true;
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LogControl"), Description("Reference to the LD, which is the owner of the log.")]
		public string logName 
		{
			get
			{
				return this.logNameField;
			}
			set
			{
				this.logNameField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LogControl"), Description("TRUE enables immediate logging; FALSE prohibits logging until enabled online.")]
		public bool logEna 
		{
			get 
			{
				return this.logEnaField;
			}
			set 
			{
				this.logEnaField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LogControl"), Description("Reason for inclusion in the report")]
		public bool reasonCode
		{
			get 
			{
				return this.reasonCodeField;
			}
			set
			{
				this.reasonCodeField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tReportControl : tControlWithTriggerOpt 
	{		
		private tReportControlOptFields optFieldsField;		
		private tRptEnabled rptEnabledField;		
		private string rptIDField;		
		private uint confRevField;		
		private bool bufferedField;		
		private uint bufTimeField;
		
		public tReportControl() 
		{
			this.confRevField = ((uint)(0));
			this.bufferedField = false;
			this.bufTimeField = ((uint)(0));			
		}
		
		[Category("ReportControl"), Description("optional fields to include in report."),
		 Browsable(false)]
		public tReportControlOptFields OptFields
		{
			get 
			{
				return this.optFieldsField;
			}
			set 
			{
				this.optFieldsField = value;
			}
		}
		
		[Category("ReportControl"), Description("Contains the list of client LNs for which this report shall be enabled."),
		 Browsable(false)]
		public tRptEnabled RptEnabled 
		{
			get
			{
				return this.rptEnabledField;
			}
			set 
			{
				this.rptEnabledField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ReportControl"), Description("Identifier for the report control block.")]
		public string rptID
		{
			get 
			{
				return this.rptIDField;
			}
			set 
			{
				this.rptIDField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControl"), Description("The configuration revision number of this report control block.")]
		public uint confRev 
		{
			get
			{
				return this.confRevField;
			}
			set 
			{
				this.confRevField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControl"), Description("Specifies if reports are buffered or no."), DefaultValue(false) ]
		public bool buffered 
		{
			get
			{
				return this.bufferedField;
			}
			set
			{
				this.bufferedField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControl"), Description("Buffer time.")]
		public uint bufTime 
		{
			get 
			{
				return this.bufTimeField;
			}
			set
			{
				this.bufTimeField = value;
			}
		}
	}

	 /* 
	 * The attributes bufOvfl and segmentation were added to fullfill the standard IEC61850-6 Ed.1.0. 
	 * This attributes were also added on the SCL_IED.xsd file because these attributes doesn't exist 
	 * on this file although they are indicated on the standard.
	 */ 
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tReportControlOptFields 
	{		
		private bool seqNumField;		
		private bool timeStampField;		
		private bool dataSetField;		
		private bool reasonCodeField;		
		private bool dataRefField;		
		private bool entryIDField;		
		private bool configRefField;
		private bool bufOvflField;
		private bool segmentationField;
		
		public tReportControlOptFields() 
		{
			this.seqNumField = false;
			this.timeStampField = false;
			this.dataSetField = false;
			this.reasonCodeField = false;
			this.dataRefField = false;
			this.entryIDField = false;
			this.configRefField = false;
			this.bufOvflField = false;
			this.segmentationField = false;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Current sequence number of the reports.")]
		public bool seqNum 
		{
			get 
			{
				return this.seqNumField;
			}
			set 
			{
				this.seqNumField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Represent a UTC time with the epoch of midnight (00:00:00) of "+
			"1970-01-01.")]
		public bool timeStamp 
		{
			get 
			{
				return this.timeStampField;
			}
			set
			{
				this.timeStampField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Identifies a DATA-SET that is contained in the LN.")]
		public bool dataSet 
		{
			get
			{
				return this.dataSetField;
			}
			set 
			{
				this.dataSetField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Reason for inclusion in the report")]
		public bool reasonCode
		{
			get
			{
				return this.reasonCodeField;
			}
			set
			{
				this.reasonCodeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Data Object Reference")]
		public bool dataRef 
		{
			get 
			{
				return this.dataRefField;
			}
			set
			{
				this.dataRefField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Used to identify an entry in a sequence of events such as a log or a buffered report.")]
		public bool entryID 
		{
			get
			{
				return this.entryIDField;
			}
			set 
			{
				this.entryIDField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Configuration reference.")]
		public bool configRef 
		{
			get
			{
				return this.configRefField;
			}
			set 
			{
				this.configRefField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Configuration reference.")]
		public bool bufOvfl 
		{
			get
			{
				return this.bufOvflField;
			}
			set 
			{
				this.bufOvflField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Configuration reference.")]
		public bool segmentation 
		{
			get
			{
				return this.segmentationField;
			}
			set 
			{			
				this.segmentationField = value;
			}
		}
	}

	/* 
	 * The following attributes were added to fulfill standard IEC 61850 Ed. 1.0:
	 * Server -> serverField
	 * LN -> lNField
	 * 
	 * The attribute "itemsField" was deleted to fulfill standar IEC 61850 Ed. 1.0.
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tAccessPoint : tNaming
	{		
		private static int index = 0;
		private bool routerField;		
		private bool clockField;		
		private tServer serverField;		
		private tLN[] lNField;
		
		public tAccessPoint() 
		{
			this.routerField = false;
			this.clockField = false;
			if(this.name == null)
			{
				this.name = "AccessPoint" + ( ++ index ).ToString();
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("AccessPoint"), Description("This is a function of the communication network on the IED.")]
		public bool router
		{
			get 
			{
				return this.routerField;
			}
			set 
			{
				this.routerField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("AccessPoint"), Description("The presence and setting to true defines this IED to be a master clock at this bus.")]
		public bool clock 
		{
			get
			{
				return this.clockField;
			}
			set 
			{
				this.clockField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("Server")]
		[Category("AccessPoint"), Description("A communication entity within an IED."), Browsable(false)]
		public tServer Server
		{
			get
			{
				return this.serverField;
			}
			set
			{
				this.serverField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("LN")]
		[Category("AccessPoint"), Browsable(false)]
		public tLN[] LN
		{
			get
			{
				return this.lNField;
			}
			set
			{
				this.lNField = value;
			}
		}
	}
	
	public enum tStatusEnum {
		Valid,
		Invalid,
		Unknown
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 *
	 * The data type "lnClassField" was added to fulfill standard IEC 61850 Ed. 1.0	 
	 *
	 * To accept any Logical Node without shows an error, the type of lnClass attribute has to be changed from Enum to String.
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute("LN", Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]	
	public partial class tLN : tAnyLN 
	{		
		private static uint index = 0;
		private tLNClassEnum lnClassField;		
		private uint instField;		
		private string prefixField;
		private string lnClassString;
		private tStatusEnum status;
		
		[System.Xml.Serialization.XmlIgnore()]
		public tLNClassEnum lnClassFieldTemp;
		
		public tLN() 
		{
			this.prefix = "";
			this.lnClass = tLNClassEnum.LPHD.ToString();
			this.lnClassEnum = tLNClassEnum.LPHD;
			this.inst = ++index;
			this.status = tStatusEnum.Unknown;
		}
		
		/// <summary>
		/// Use this constructor to create a new LN and verify if it is Valid, if there's no other
		/// LN in the LD with the same prefix, class and instance. Check Status property in order 
		/// to know its status. 
		/// </summary>
		/// <param name="ld">
		/// A <see cref="tLDevice"/> to be used to check for duplicated instances.
		/// </param>
		/// <param name="lnClass">
		/// A <see cref="System.String"/> with the name of the LN Class as on IEC 61850-7-x
		/// </param>
		/// <param name="prefix">
		/// A <see cref="System.String"/> with the prefix on LN Class.
		/// </param>
		/// <param name="inst">
		/// A <see cref="System.UInt32"/> with the instance number of the LN Class.
		/// </param>
		/// <param name="lnType">
		/// A <see cref="tLNodeType"/> reference to instantied.
		/// </param>
		public tLN (tLDevice ld, string lnClass, string prefix, uint inst, tLNodeType lnType) {
			if (ld == null) return;
			if (lnType == null) return;
			
			if (inst == 0)
				this.inst = ++index;
			else
				this.inst = inst;
			
			this.lnClass = lnClass;
			
			this.lnType = lnType.id;
			
			// Search for duplicated LN
			if(ld.LN != null) {
				for (int i = 0; i < ld.LN.GetLength(0); i++) {
					tLN ln = ld.LN[i];
					if ( ln.prefix == this.prefix && ln.inst == this.inst && ln.lnClass == this.lnClass) {
						this.status = tStatusEnum.Invalid;
						break;
					}
				}
				this.status = tStatusEnum.Valid;
			}
		}
		
		
		/// <summary>
		/// Check this property in order to know if this LN has been verified for duplicated nodes, if so
		/// this returns tLNValidEnum.Valid, other wise it returns tLNValidEnum.Invalid. If not checked, 
		/// when is created by using the default constructor, it return tLNValidEnum.Unknown.
		/// </summary>
		[System.Xml.Serialization.XmlIgnore]
		public tStatusEnum Status {
			get { return this.status; }
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LN"), Browsable(false), Description("The LN class")]
		public string lnClass 
		{
			get 
			{
				return this.lnClassString;
			}
			set
			{				
				this.lnClassString = value;
				if(System.Enum.IsDefined(typeof(tLNClassEnum), lnClass))
				{
					this.lnClassEnum = (tLNClassEnum) System.Enum.Parse(typeof(tLNClassEnum), lnClass);
				}
				else
				{
					this.lnClassEnum = tLNClassEnum.Custom;
				}		
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlIgnore()]
		[Category("LN"), DisplayName("lnClass"), Description("The LN class")]
		public tLNClassEnum lnClassEnum 
		{
			get 
			{
				return this.lnClassField;
			}
			set
			{	
				if(lnClassField != value)
				{
					this.lnClassFieldTemp = lnClassField;
				}
				this.lnClassField = value;				
				if(this.lnClassField!=tLNClassEnum.Custom)
				{
					this.lnClassString = this.lnClassField.ToString();
				}
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LN"), Description("The LN instance number identifying this LN.")]
		public uint inst 
		{
			get 
			{
				return this.instField;
			}
			set 
			{
				this.instField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LN"), Description("The LN prefix part.")]
		public string prefix
		{
			get 
			{
				return this.prefixField;
			}
			set 
			{
				this.prefixField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServer : tUnNaming 
	{		
		private tServerAuthentication authenticationField;		
		private tLDevice[] lDeviceField;		
		private tAssociation[] associationField;		
		private uint timeoutField;
		
		public tServer() 
		{
			this.timeoutField = ((uint)(30));
		}
		
		[Category("Server"), Description("Defines the authentication possibilities or method(s) to be used."), Browsable(false)]
		public tServerAuthentication Authentication 
		{
			get 
			{
				return this.authenticationField;
			}
			set 
			{
				this.authenticationField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("LDevice")]
		[Category("Server"), Browsable(false)]
		public tLDevice[] LDevice 
		{
			get 
			{
				return this.lDeviceField;
			}
			set 
			{
				this.lDeviceField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("Association")]
		[Category("Server"), Browsable(false)]
		public tAssociation[] Association
		{
			get 
			{
				return this.associationField;
			}
			set 
			{
				this.associationField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("Server"), Description("Time out in seconds.")]
		public uint timeout 
		{
			get
			{
				return this.timeoutField;
			}
			set 
			{
				this.timeoutField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServerAuthentication 
	{		
		private bool noneField;		
		private bool passwordField;		
		private bool weakField;		
		private bool strongField;		
		private bool certificateField;
		
		public tServerAuthentication()
		{
			this.noneField = true;
			this.passwordField = false;
			this.weakField = false;
			this.strongField = false;
			this.certificateField = false;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServerAuthentication"), Description("No authentication.")]
		public bool none 
		{
			get 
			{
				return this.noneField;
			}
			set
			{
				this.noneField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServerAuthentication"), Description("Key for authentication.")]
		public bool password 
		{
			get
			{
				return this.passwordField;
			}
			set 
			{
				this.passwordField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServerAuthentication"), Description("A weak password for authentication.")]
		public bool weak 
		{
			get 
			{
				return this.weakField;
			}
			set 
			{
				this.weakField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServerAuthentication"), Description("A strong password for authentication.")]
		public bool strong 
		{
			get
			{
				return this.strongField;
			}
			set 
			{
				this.strongField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ServerAuthentication"), Description("A certificate for authentication.")]
		public bool certificate 
		{
			get 
			{
				return this.certificateField;
			}
			set 
			{
				this.certificateField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"	 	
	 * 
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tLDevice : tUnNaming
	{		
		private static int index = 0;
		private LN0 lN0Field;		
		private tLN[] lnField;		
		private tAccessControl accessControlField;		
		private string instField;		
		
		public tLDevice()
		{
			if(this.inst == null)
			{
				this.inst = "LDevice" + ( ++index ).ToString();
			}
		}
		
		[Category("LDevice"), Description("The LN class is always LLN0"), Browsable(false)]
		public LN0 LN0 
		{
			get
			{
				return this.lN0Field;
			}
			set
			{
				this.lN0Field = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("LN")]
		[Category("LDevice"), Browsable(false)]
		public tLN[] LN 
		{
			get 
			{
				return this.lnField;
			}
			set 
			{
				this.lnField = value;
			}
		}
		
		[Category("LDevice"), Description("Access control definition for this LD."), Browsable(false)]
		public tAccessControl AccessControl 
		{
			get 
			{
				return this.accessControlField;
			}
			set
			{
				this.accessControlField = value;
			}
		}
			
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LDevice"), Description("Identification of the LDevice within the IED.")]
		public string inst 
		{
			get
			{
				return this.instField;
			}
			set 
			{
				if( value != "")
				{
					this.instField = value;
				}
				else
				{
					this.inst = this.instField;
				}
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	public partial class LN0 : tLN0 
	{
		
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The data type "lnClassField" was added to fulfill standard IEC 61850 Ed. 1.0	
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tLN0 : tAnyLN 
	{
		private tGSEControl[] gSEControlField;		
		private tSampledValueControl[] sampledValueControlField;		
		private tSettingControl settingControlField;		
		private tSCLControl sCLControlField;		
		private tLog logField;		
		private tLNClassEnum lnClassField;		
		private string instField;
		
		public tLN0()
		{
			this.lnClassField = tLNClassEnum.LLN0;
			inst = "1";
			lnType = lnClass + inst;
		}
		
		[System.Xml.Serialization.XmlElementAttribute("GSEControl")]
		[Category("LN"), Browsable(false)]
		public tGSEControl[] GSEControl 
		{
			get 
			{
				return this.gSEControlField;
			}
			set 
			{
				this.gSEControlField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("SampledValueControl")]
		[Category("LN"), Browsable(false)]
		public tSampledValueControl[] SampledValueControl
		{
			get 
			{
				return this.sampledValueControlField;
			}
			set
			{
				this.sampledValueControlField = value;
			}
		}
		
		[Category("LN"), Description(" "), Browsable(false)]
		public tSettingControl SettingControl
		{
			get 
			{
				return this.settingControlField;
			}
			set
			{
				this.settingControlField = value;
			}
		}
		
		[Category("LN"), Description(" "), Browsable(false)]
		public tSCLControl SCLControl 
		{
			get 
			{
				return this.sCLControlField;
			}
			set 
			{
				this.sCLControlField = value;
			}
		}
		
		[Category("LN"), Description(" ")]
		public tLog Log 
		{
			get 
			{
				return this.logField;
			}
			set 
			{
				this.logField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LN"), Description("The LN class."), ReadOnly(true)]
		public tLNClassEnum lnClass 
		{
			get
			{
				return this.lnClassField;
			}
			set 
			{
				this.lnClassField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LN"), Description("The LN instance number identifying this LN.")]
		public string inst 
		{
			get 
			{
				return this.instField;
			}
			set 
			{
				this.instField = value;
			}
		}
	}

	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConnectivityNode))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPowerSystemResource))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubFunction))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tFunction))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTapChanger))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGeneralEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPowerTransformer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAbstractConductingEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTransformerWinding))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConductingEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEquipmentContainer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBay))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tVoltageLevel))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubstation))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tLNodeContainer : tNaming 
	{		
		private static int index = 0;
		private tLNode[] lNodeField;
		public tLNodeContainer()
		{
			if(this.name == null )
			{
				this.name = "LNodeContainer" + ( ++index ).ToString();
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("LNode")]
		[Category("LNodeContainer"), Browsable(false)]
		public tLNode[] LNode 
		{
			get
			{
				return this.lNodeField;
			}
			set
			{
				this.lNodeField = value;
			}
		}
	}
	
	/*
	 * The enumeration "tLPHDEnum" was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tLPHDEnum
	{
		LPHD		
	}
	
	/*
	 * The enumeration "tLLN0Enum" was added to fulfill standard IEC 61850 Ed. 1.0
	*/	
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tLLN0Enum
	{
		LLN0		
	}
			
	/*
	 * The enumeration "tDomainLNGroup AEnum" was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tDomainLNGroupAEnum
	{
		ANCR,		
		ARCO,
		ATCC,
		AVCO
	}
		
	/*
	 * The enumeration "tDomainLNGroupCEnum" was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tDomainLNGroupCEnum 
	{
		CILO,
		CSWI,
		CALH,
		CCGR,
		CPOW
	}
	
	/*
	 * The enumeration "tDomainLNGroupGEnum" was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tDomainLNGroupGEnum 
	{
		GAPC,
		GGIO,
		GSAL
	}
	
	/*
	 * The enumeration "tDomainLNGroupIEnum" was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tDomainLNGroupIEnum
	{
		IHMI,
		IARC,
		ITCI,
		ITMI
	}
	
	/*
	 * The enumeration "tDomainLNGroupMEnum" was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tDomainLNGroupMEnum 
	{
		MMXU,
		MDIF,
		MHAI,
		MHAN,
		MMTR,
		MMXN,
		MSQI,
		MSTA
	}
	
	/*
	 * The enumeration "tDomainLNGroupPEnum" was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tDomainLNGroupPEnum 
	{
		PDIF,
		PDIS,
		PDIR,
		PDOP,
		PDUP,
		PFRC,
		PHAR,
		PHIZ,
		PIOC,
		PMRI,
		PMSS,
		POPF,
		PPAM,
		PSCH,
		PSDE,
		PTEF,
		PTOC,
		PTOF,
		PTOV,
		PTRC,
		PTTR,
		PTUC,
		PTUV,
		PUPF,
		PTUF,
		PVOC,
		PVPH,
		PZSU
	}
	
	/*
	 * The enumeration "tDomainLNGroupREnum" was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tDomainLNGroupREnum 
	{
		RSYN,
		RDRE,
		RADR,
		RBDR,
		RDRS,
		RBRF,
		RDIR,
		RFLO,
		RPSB,
		RREC
	}
	
	/*
	 * The enumeration "tDomainLNGroupSEnum" was added to fulfill standard IEC 61850 Ed. 1.0
	 */	
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tDomainLNGroupSEnum
	{
		SARC,
		SIMG,
		SIML,
		SPDC
	}
	
	/*
	 * The enumeration "tDomainLNGroupTEnum" was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tDomainLNGroupTEnum 
	{
		TCTR,
		TVTR
	}
	
		
	/*
	 * The enumeration "tDomainLNGroupXEnum" was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tDomainLNGroupXEnum
	{
		XCBR,
		XSWI
	}
	
	/*
	 * The enumeration "tDomainLNGroupYEnum" was added to fulfill standard IEC 61850 Ed. 1.0
	*/	
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tDomainLNGroupYEnum
	{
		YPTR,
		YEFN,
		YLTC,
		YPSH	
	}
	
	/*
	 * The enumeration "tDomainLNGroupZEnum" was added to fulfill standard IEC 61850 Ed. 1.0
	*/
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tDomainLNGroupZEnum 
	{
		ZAXN,
		ZBAT,
		ZBSH,
		ZCAB,
		ZCAP,
		ZCON,
		ZGEN,
		ZGIL,
		ZLIN,
		ZMOT,
		ZREA,
		ZRRC,
		ZSAR,
		ZTCF,
		ZTCR
	}
	
	/*
	 * The enumeration "tDomainLNEnum" was added to fulfill standard IEC 61850 Ed. 1.0.
	 * This is composed by following Enums: tDomainLNGroupAEnum, tDomainLNGroupCEnum, 
	 * tDomainLNGroupGEnum, tDomainLNGroupIEnum, tDomainLNGroupMEnum, tDomainLNGroupPEnum, 
	 * tDomainLNGroupREnum, tDomainLNGroupSEnum, tDomainLNGroupTEnum, tDomainLNGroupXEnum,
	 * tDomainLNGroupYEnum, tDomainLNGroupZEnum
	*/	
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tDomainLNEnum
	{
		ANCR,ARCO,ATCC,AVCO,
		CILO, CSWI,CALH,CCGR,CPOW,
		GAPC,GGIO,GSAL,
		IHMI,IARC,ITCI,ITMI,
		MMXU,MDIF,MHAI,MHAN,MMTR,MMXN,MSQI,MSTA,		
		PDIF,PDIS,PDIR,PDOP,PDUP,PFRC,PHAR,PHIZ,PIOC,PMRI,PMSS,POPF,PPAM,PSCH,PSDE,PTEF,PTOC,PTOF,PTOV,PTRC,PTTR,PTUC,PTUV,PUPF,PTUF,PVOC,PVPH,PZSU,
		RSYN,RDRE,RADR,RBDR,RDRS,RBRF,RDIR,RFLO,RPSB,RREC,
		SARC,SIMG,SIML,SPDC,
		TCTR,TVTR,
		XCBR,XSWI,
		YPTR,YEFN,YLTC,YPSH,
		ZAXN,ZBAT,ZBSH,ZCAB,ZCAP,ZCON,ZGEN,ZGIL,ZLIN,ZMOT,ZREA,ZRRC,ZSAR,ZTCF,ZTCR
	}
	
	/*
	 * The enumeration "tPredefinedLNClassEnum" was added to fulfill standard IEC 61850 Ed. 1.0.
	 * This is composed by following Enums: tLPHDEnum, tLLN0Enum y tDomainLNEnum
	 * (que incluyen a tDomainLNGroupAEnum, tDomainLNGroupCEnum, tDomainLNGroupGEnum, 
	 * tDomainLNGroupIEnum, tDomainLNGroupMEnum, tDomainLNGroupPEnum, 
	 * tDomainLNGroupREnum, tDomainLNGroupSEnum, tDomainLNGroupTEnum, 
	 * tDomainLNGroupXEnum, tDomainLNGroupYEnum, tDomainLNGroupZEnum)
	*/	
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public enum tPredefinedLNClassEnum 
	{
		LPHD,		
		LLN0,
		ANCR,ARCO,ATCC,AVCO,
		CILO, CSWI,CALH,CCGR,CPOW,
		GAPC,GGIO,GSAL,
		IHMI,IARC,ITCI,ITMI,
		MMXU,MDIF,MHAI,MHAN,MMTR,MMXN,MSQI,MSTA,
		PDIF,PDIS,PDIR,PDOP,PDUP,PFRC,PHAR,PHIZ,PIOC,PMRI,PMSS,POPF,PPAM,PSCH,PSDE,PTEF,PTOC,PTOF,PTOV,PTRC,PTTR,PTUC,PTUV,PUPF,PTUF,PVOC,PVPH,PZSU,
		RSYN,RDRE,RADR,RBDR,RDRS,RBRF,RDIR,RFLO,RPSB,RREC,
		SARC,SIMG,SIML,SPDC,
		TCTR,TVTR,
		XCBR,XSWI,
		YPTR,YEFN,YLTC,YPSH,
		ZAXN,ZBAT,ZBSH,ZCAB,ZCAP,ZCON,ZGEN,ZGIL,ZLIN,ZMOT,ZREA,ZRRC,ZSAR,ZTCF,ZTCR
	}
	
	/* 
	 * The enumeration "tLNClassEnum" was added to fulfill standard IEC 61850 Ed. 1.0.
	 * This is composed by following Enums: tPredefinedLNClassEnum y tExtensionLNClassEnum	 	 
	 *
	 * To add a Logical Node personalized and defined by the enum "Custom" was added.
	*/	
	public enum tLNClassEnum
	{
		LPHD,		
		LLN0,
		ANCR,ARCO,ATCC,AVCO,
		CILO, CSWI,CALH,CCGR,CPOW,
		GAPC,GGIO,GSAL,
		IHMI,IARC,ITCI,ITMI,
		MMXU,MDIF,MHAI,MHAN,MMTR,MMXN,MSQI,MSTA,
		PDIF,PDIS,PDIR,PDOP,PDUP,PFRC,PHAR,PHIZ,PIOC,PMRI,PMSS,POPF,PPAM,PSCH,PSDE,PTEF,PTOC,PTOF,PTOV,PTRC,PTTR,PTUC,PTUV,PUPF,PTUF,PVOC,PVPH,PZSU,
		RSYN,RDRE,RADR,RBDR,RDRS,RBRF,RDIR,RFLO,RPSB,RREC,
		SARC,SIMG,SIML,SPDC,
		TCTR,TVTR,
		XCBR,XSWI,
		YPTR,YEFN,YLTC,YPSH,
		ZAXN,ZBAT,ZBSH,ZCAB,ZCAP,ZCON,ZGEN,ZGIL,ZLIN,ZMOT,ZREA,ZRRC,ZSAR,ZTCF,ZTCR,
		// Missing:
		// tExtensionLNClassEnum	
		Custom,
	}	
	
	/* 
	 * The enumeration "tPredefinedAttributeNameEnum" was added to fulfill standard IEC 61850 Ed. 1.0	
	 * 
	 * The value "Check" was deleted because it was redundant.
	*/
	public enum tPredefinedAttributeNameEnum
	{
		T,		
		Test,		
		Check,
		SIUnit,
		Oper,
		SBO,
		SBOw,
		Cancel
	}
	
	/* 
	 * The enumeration "tAttributeNameEnum" was added to fulfill standard IEC 61850 Ed. 1.0.
	 * This is composed by following Enums: tPredefinedAttributeNameEnum tExtensionAttributeNameEnum
	 *
	 * The value "Check" was deleted because it was redundant.
	*/	
	public enum tAttributeNameEnum
	{
		//tPredefinedAttributeNameEnum
		T,		
		Test,		
		Check,
		SIUnit,
		Oper,
		SBO,
		SBOw,
		Cancel,			
		// Missing:
		// tExtensionAttributeNameEnum		
		ctlVal,
		operTm,
		origin,
		ctlNum,
		stVal,
		q,
		t,
		stSeld,
		subEna,
		subVal,
		subQ,
		subID,
		ctlModel,
		sboTimeout,
		sboClass,
		minVal,
		maxVal,
		stepSize,
		d,
		dU,
		cdcNs,
		cdcName,
		dataNs
	}
	
	/*
	 * The enumeration "tPredefinedGeneralEquipmentEnum" was added to fulfill standard IEC 61850 Ed. 1.0.	 
	*/		
	public enum tPredefinedGeneralEquipmentEnum
	{
		AXN,		
		BAT,		
		MOT	
	}
	
	/* 
	 * The enumeration "tGeneralEquipmentEnum" was added to fulfill standard IEC 61850 Ed. 1.0.
	 * This is composed by following Enums: tPredefinedGeneralEquipmentEnum tExtensionGeneralEquipmentEnum
	*/	
	public enum tGeneralEquipmentEnum
	{
		//tPredefinedGeneralEquipmentEnum
		AXN,		
		BAT,		
		MOT			
		// Missing:
		// tExtensionGeneralEquipmentEnum
	}
	
	/*
	 * The enumeration "tPredefinedCommonConductingEquipmentEnum" was added to fulfill standard IEC 61850 Ed. 1.0.	 
	*/		
	public enum tPredefinedCommonConductingEquipmentEnum
	{
		CBR,		
		DIS,		
		VTR,	
		CTR,
		GEN,
		CAP,
		REA,
		CON,
		MOT,
		EFN,
		PSH,
		BAT,
		BSH,
		CAB,
		GIL,
		LIN,
		RRC,
		SAR,
		TCF,
		TCR,
		IFL
	}
	
	/* 
	 * The enumeration "tCommonConductingEquipmentEnum" was added to fulfill standard IEC 61850 Ed. 1.0.
	 * This is composed by following Enums: tPredefinedCommonConductingEquipmentEnum tExtensionEquipmentEnum
	*/	
	public enum tCommonConductingEquipmentEnum
	{
		//tPredefinedCommonConductingEquipmentEnum
		CBR,		
		DIS,		
		VTR,	
		CTR,
		GEN,
		CAP,
		REA,
		CON,
		MOT,
		EFN,
		PSH,
		BAT,
		BSH,
		CAB,
		GIL,
		LIN,
		RRC,
		SAR,
		TCF,
		TCR,
		IFL		
		 
		// FIXME : tExtensionEquipmentEnum is missing
	}
	
	/*
	 * The enumeration "tPredefinedCDCEnum" was added to fulfill standard IEC 61850 Ed. 1.0.	 
	*/		
	public enum tPredefinedCDCEnum
	{
		SPS,
		DPS,
		INS,
		ACT,
		ACD,
		SEC,
		BCR,
		MV,
		CMV,
		SAV,
		WYE,
		DEL,
		SEQ,
		HMV,
		HWYE,
		HDEL,
		SPC,
		DPC,
		INC,
		BSC,
		ISC,
		APC,
		SPG,
		ING,
		ASG,
		CURVE,
		DPL,
		LPL,
		CSD			
	}
	
	/* 
	 * The enumeration "tCDCEnum" was added to fulfill standard IEC 61850 Ed. 1.0.
	 * This is composed by the following Enums: tPredefinedCDCEnum and tExtensionCDCEnum
	*/	
	public enum tCDCEnum
	{
		//tPredefinedCDCEnum
		SPS,
		DPS,
		INS,
		ACT,
		ACD,
		SEC,
		BCR,
		MV,
		CMV,
		SAV,
		WYE,
		DEL,
		SEQ,
		HMV,
		HWYE,
		HDEL,
		SPC,
		DPC,
		INC,
		BSC,
		ISC,
		APC,
		SPG,
		ING,
		ASG,
		CURVE,
		DPL,
		LPL,
		CSD				
		//FIXME : tExtensionCDCEnum is missing

	}
	
	/*
	 * The enumeration "tPredefinedBasicTypeEnum" was added to fulfill standard IEC 61850 Ed. 1.0.	 
	*/		
	public enum  tPredefinedBasicTypeEnum 
	{
		BOOLEAN,		
		INT8,
		INT16,
		INT24,
		INT32,
		INT128,
		INT8U,
		INT16U,
		INT24U,
		INT32U,
		FLOAT32,
		FLOAT64,
		Enum,
		Dbpos,
		Tcmd,
		Quality,
		Timestamp,
		VisString32,
		VisString64,
		VisString129,
		VisString255,
		Octet64,
		Struct,
		EntryTime,
		Unicode255,
		Check
	}
	
	public class tBasicType
	{
		private string typeField;
		
		public tBasicType()
		{
			this.typeField = "BOOLEAN";
		}
		
		public tBasicTypeEnum bTypeEnum {
			get { return this.StringToEnum(this.typeField); }
			set { this.typeField = this.EnumToString(value); }
		}
		
		public string bType {
			get { return this.typeField; }
			set { this.typeField = value; }
		}
        
		public string EnumToString (tBasicTypeEnum t)
		{
			string text = "";
			switch (t) {
			
			case tBasicTypeEnum.BOOLEAN:
				text = "BOOLEAN";
				break;
			case tBasicTypeEnum.INT8:
				text = "INT8";
				break;				
			case tBasicTypeEnum.INT16:
				text = "INT16";
				break;				
			case tBasicTypeEnum.INT24:
				text = "INT24";
				break;			
			case tBasicTypeEnum.INT32:
				text = "INT32";
				break;			
			case tBasicTypeEnum.INT128:
				text = "INT128";
				break;			
			case tBasicTypeEnum.INT8U:
				text = "INT8U";
				break;				
			case tBasicTypeEnum.INT16U:
				text = "INT16U";
				break;				
			case tBasicTypeEnum.INT24U:
				text = "INT24U";
				break;				
			case tBasicTypeEnum.INT32U:
				text = "INT32U";
				break;				
			case tBasicTypeEnum.FLOAT32:
				text = "FLOAT32";
				break;				
			case tBasicTypeEnum.FLOAT64:
				text = "FLOAT64";
				break;				
			case tBasicTypeEnum.Enum:
				text = "Enum";
				break;				
			case tBasicTypeEnum.Dbpos:
				text = "Dbpos";
				break;				
			case tBasicTypeEnum.Tcmd:
				text = "Tcmd";
				break;				
			case tBasicTypeEnum.Quality:
				text = "Quality";
				break;				
			case tBasicTypeEnum.Timestamp:
				text = "Timestamp";
				break;				
			case tBasicTypeEnum.VisString32:
				text = "VisString32";
				break;				
			case tBasicTypeEnum.VisString64:
				text = "VisString64";
				break;
			case tBasicTypeEnum.VisString255:
				text = "VisString255";
				break;
			case tBasicTypeEnum.Octet64:
				text = "Octet64";
				break;
			case tBasicTypeEnum.Struct:
				text = "Struct";
				break;
			case tBasicTypeEnum.EntryTime:
				text = "EntryTime";
				break;
			case tBasicTypeEnum.Unicode255:
				text = "Unicode255";
				break;
			default:
				text = "Extension";
				break;
			}
			
			return text;
		}
		
		public tBasicTypeEnum StringToEnum (string t)
		{
			tBasicTypeEnum type;
			switch (t) {
			
			case "BOOLEAN":
				type = tBasicTypeEnum.BOOLEAN;
				break;
			
			case "INT8":
				type = tBasicTypeEnum.INT8;
				break;
				
			case "INT16":
				type = tBasicTypeEnum.INT16;
				break;
				
			case "INT24":
				type = tBasicTypeEnum.INT24;
				break;
			
			case "INT32":
				type = tBasicTypeEnum.INT32;
				break;
			
			case "INT128":
				type = tBasicTypeEnum.INT128;
				break;
			
			case "INT8U":
				type = tBasicTypeEnum.INT8U;
				break;
				
			case "INT16U":
				type = tBasicTypeEnum.INT16U;
				break;
				
			case "INT24U":
				type = tBasicTypeEnum.INT24U;
				break;
				
			case "INT32U":
				type = tBasicTypeEnum.INT32U;
				break;
				
			case "FLOAT32":
				type = tBasicTypeEnum.FLOAT32;
				break;
				
			case "FLOAT64":
				type = tBasicTypeEnum.FLOAT64;
				break;
				
			case "Enum":
				type = tBasicTypeEnum.Enum;
				break;
				
			case "Dbpos":
				type = tBasicTypeEnum.Dbpos;
				break;
				
			case "Tcmd":
				type = tBasicTypeEnum.Tcmd;
				break;
				
			case "Quality":
				type = tBasicTypeEnum.Quality;
				break;
				
			case "Timestamp":
				type = tBasicTypeEnum.Timestamp;
				break;
			case "VisString32":
				type = tBasicTypeEnum.VisString32;
				break;
				
			case "VisString64":
				type = tBasicTypeEnum.VisString64;
				break;
			case "VisString255":
				type = tBasicTypeEnum.VisString255;
				break;
			case "Octet64":
				type = tBasicTypeEnum.Octet64;
				break;
			case "Struct":
				type = tBasicTypeEnum.Struct;
				break;
			case "EntryTime":
				type = tBasicTypeEnum.EntryTime;
				break;
			case "Unicode255":
				type = tBasicTypeEnum.Unicode255;
				break;
			default:
				type = tBasicTypeEnum.Extension;
				break;
			}
			
			return type;
		}
	}
	
	/*
	 * The enumeration "tBasicTypeEnum" was added to fulfill standard IEC 61850 Ed. 1.0.
	 * This is composed by the following Enums: tPredefinedBasicTypeEnum and tExtensionBasicTypeEnum
	*/	
	public enum  tBasicTypeEnum 
	{
		//tPredefinedBasicTypeEnum
		BOOLEAN,		
		INT8,
		INT16,
		INT24,
		INT32,
		INT128,
		INT8U,
		INT16U,
		INT24U,
		INT32U,
		FLOAT32,
		FLOAT64,
		Enum,
		Dbpos,
		Tcmd,
		Quality,
		Timestamp,
		VisString32,
		VisString64,
		VisString129,
		VisString255,
		Octet64,
		Struct,
		EntryTime,
		Unicode255,
		//tExtensionBasicTypeEnum is missing	
		Check,
		VisString65,
		Extension // Used for custom types
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The value's atttribute "string lnClassField to tLNClassEnum lnClassField"
	 * was added to fulfill standard IEC 61850 Ed. 1.0
	 *
	 * To accept any Logical Node without shows an error, the type of lnClass attribute has to be changed from Enum to String.
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tLNode : tUnNaming 
	{		
		private string lnInstField;		
		private string lnClassField;		
		private string iedNameField;		
		private string ldInstField;		
		private string prefixField;		
		private string lnTypeField;
		private tLN tLN;
		private tLDevice tLDevice;
		private tIED tIED;
		
		/// <summary>
		/// This constructor set lnClass to XSWI as default logical node class type. 
		/// </summary>
		public tLNode () {
			
		}
		
		/// <summary>
		/// Use this constructor to create a new tLNode to be used on SCL's Substation section.
		/// </summary>
		/// <param name="ied">
		/// A <see cref="tIED"/> witch contains the referer LD and LN in a configured system. Use null if no IED is
		/// referer because you are creating a Specification.
		/// </param>
		/// <param name="ld">
		/// A <see cref="tLDevice"/> reference witch contains a LN to be referer in a configured system. Use null if no IED is
		/// referer because you are creating a Specification.
		/// </param>
		/// <param name="ln">
		/// A <see cref="tLN"/> reference in configured system. Use null if no IED is
		/// referer because you are creating a Specification.
		/// </param>
		public tLNode(tIED ied, tLDevice ld, tLN ln)
		{
			if (ied != null) {
				this.iedNameField = ied.name;
				
				if(ld != null)
					this.ldInstField = ld.inst;
				else
					this.ldInstField = "";
			}
			else
				this.iedNameField = "None";
			
			if(ln != null) {
				this.lnInstField = (string) System.Convert.ChangeType(this.tLN.inst, typeof(string));
				this.lnClassField = this.tLN.lnClass;
				this.lnTypeField = this.tLN.lnType;
			}
			else {
				this.ldInstField = "";
				this.prefixField = "";
				this.lnClass = "XSWI";
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LNode"), Description("The LN instance identification.")]
		public string lnInst 
		{
			get
			{
				return this.lnInstField;
			}
			set 
			{
				this.lnInstField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LNode"), Description("The LN class.")]
		public string lnClass 
		{
			get 
			{
				return this.lnClassField;
			}
			set
			{
				this.lnClassField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LNode"), Description("The name of the IED which contains the LN.")]
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
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]	
		[Category("LNode"), Description("The LD instance on the IED which contains the LN.")]
		public string ldInst 
		{
			get 
			{
				return this.ldInstField;
			}
			set 
			{
				this.ldInstField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LNode"), Description("The LN prefix used in the IED.")]
		public string prefix 
		{
			get 
			{
				return this.prefixField;
			}
			set 
			{
				this.prefixField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LNode"), Description("The LN type definition containing more detailed functional specification.")]
		public string lnType 
		{
			get 
			{
				return this.lnTypeField;
			}
			set 
			{
				this.lnTypeField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]		
	public partial class tConnectivityNode : tLNodeContainer
	{		
		private string pathNameField;

		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ConnectivityNode"), Description("This acts as a key")]
		public string pathName 
		{
			get 
			{
				return this.pathNameField;
			}
			set 
			{
				this.pathNameField = value;
			}
		}
	}

	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubFunction))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tFunction))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTapChanger))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGeneralEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPowerTransformer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAbstractConductingEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTransformerWinding))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConductingEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEquipmentContainer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBay))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tVoltageLevel))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubstation))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tPowerSystemResource : tLNodeContainer 
	{
		
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSubFunction : tPowerSystemResource 
	{		
		private tGeneralEquipment[] generalEquipmentField;
		
		[System.Xml.Serialization.XmlElementAttribute("GeneralEquipment")]
		[Category("PowerSystemResource"), Browsable(false)]
		public tGeneralEquipment[] GeneralEquipment
		{
			get
			{
				return this.generalEquipmentField;
			}
			set 
			{
				this.generalEquipmentField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 *  
	 * The value's atttribute "string typeField" was replaced by 
	 * "tGeneralEquipmentEnum typeField"
	*/
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tGeneralEquipment : tEquipment 
	{		
		private tGeneralEquipmentEnum typeField;
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("GeneralEquipment"), Description("Type of General Equipment")]
		public tGeneralEquipmentEnum type
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
	}

	/*
	 * The symbol @ was added to the name of virtual variable to avoid problems 
	 * with the compiler.
	*/
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGeneralEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPowerTransformer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAbstractConductingEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTransformerWinding))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConductingEquipment))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tEquipment : tPowerSystemResource
	{		
		private bool virtualField;
		
		public tEquipment()
		{
			this.virtualField = false;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("Equipment"), Description("Virtual equipment configured")]
		public bool @virtual
		{
			get 
			{
				return this.virtualField;
			}
			set 
			{
				this.virtualField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]		
	public partial class tPowerTransformer : tEquipment 
	{		
		private tTransformerWinding[] transformerWindingField;		
		private tPowerTransformerEnum typeField;
		
		public tPowerTransformer() 
		{
			this.typeField = tPowerTransformerEnum.PTR;
		}
		
		[System.Xml.Serialization.XmlElementAttribute("TransformerWinding")]
		[Category("PowerTransformer"), Browsable(false)]
		public tTransformerWinding[] TransformerWinding 
		{
			get 
			{
				return this.transformerWindingField;
			}
			set 
			{
				this.transformerWindingField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("PowerTransformer"), Description("Type of Power Transformer")]
		public tPowerTransformerEnum type 
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
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tTransformerWinding : tAbstractConductingEquipment 
	{		
		private tTapChanger tapChangerField;		
		private tTransformerWindingEnum typeField;
		
		public tTransformerWinding() 
		{
			this.typeField = tTransformerWindingEnum.PTW;
		}
		
		[Category("TransformerWinding"), Description(" ")]
		public tTapChanger TapChanger 
		{
			get 
			{
				return this.tapChangerField;
			}
			set
			{
				this.tapChangerField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("TransformerWinding"), Description("Type of Transformer Winding")]
		public tTransformerWindingEnum type
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
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The symbol @ was added to the name of virtual variable to avoid problems 
	 * with the compiler.
	*/
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tTapChanger : tPowerSystemResource 
	{		
		private string typeField;		
		private bool virtualField;
		
		public tTapChanger() 
		{
			this.typeField = "LTC";
			this.virtualField = false;
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="Name")]
		[Category("TapChanger"), Description("Type of Tap Changer")]
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
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("TapChanger"), Description("Virtual equipment")]
		public bool @virtual 
		{
			get
			{
				return this.virtualField;
			}
			set 
			{
				this.virtualField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tTransformerWindingEnum 
	{		
		PTW
	}

	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTransformerWinding))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConductingEquipment))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tAbstractConductingEquipment : tEquipment
	{		
		private tTerminal[] terminalField;		
		private tSubEquipment[] subEquipmentField;
		
		[System.Xml.Serialization.XmlElementAttribute("Terminal")]
		[Category("AbstractConductingEquipment"), Browsable(false)]
		public tTerminal[] Terminal 
		{
			get 
			{
				return this.terminalField;
			}
			set 
			{
				this.terminalField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("SubEquipment")]
		[Category("AbstractConductingEquipment"), Browsable(false)]
		public tSubEquipment[] SubEquipment 
		{
			get 
			{
				return this.subEquipmentField;
			}
			set 
			{
				this.subEquipmentField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]		
	public partial class tTerminal : tUnNaming 
	{		
		private string nameField;		
		private string connectivityNodeField;		
		private string substationNameField;		
		private string voltageLevelNameField;		
		private string bayNameField;		
		private string cNodeNameField;
		
		public tTerminal() 
		{
			this.nameField = "";
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Terminal"), Description("The optional relative name of the terminal at this Equipment.")]
		public string name 
		{
			get
			{
				return this.nameField;
			}
			set 
			{
				this.nameField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Terminal"), Description("The pathname of the connectivity node to which this terminal connects.")]
		public string connectivityNode
		{
			get 
			{
				return this.connectivityNodeField;
			}
			set
			{
				this.connectivityNodeField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Terminal"), Description("The name of the substation containing the connectivityNode.")]
		public string substationName 
		{
			get
			{
				return this.substationNameField;
			}
			set 
			{
				this.substationNameField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Terminal"), Description("The name of the voltage level containing the connectivityNode.")]
		public string voltageLevelName 
		{
			get 
			{
				return this.voltageLevelNameField;
			}
			set
			{
				this.voltageLevelNameField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Terminal"), Description("The name of the bay containing the connectivityNode.")]
		public string bayName
		{
			get
			{
				return this.bayNameField;
			}
			set 
			{
				this.bayNameField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Terminal"), Description("The (relative) name of the connectivityNode within its bay.")]
		public string cNodeName 
		{
			get
			{
				return this.cNodeNameField;
			}
			set
			{
				this.cNodeNameField = value;
			}
		}
	}

	/*
	 * The symbol @ was added to the name of virtual variable to avoid problems 
	 * with the compiler.
	*/
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSubEquipment : tPowerSystemResource 
	{		
		private tPhaseEnum phaseField;		
		private bool virtualField;
		
		public tSubEquipment() 
		{
			this.phaseField = tPhaseEnum.none;
			this.virtualField = false;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SubEquipment"), Description("The phase to which the subdevice belongs.")]
		public tPhaseEnum phase 
		{
			get 
			{
				return this.phaseField;
			}
			set 
			{
				this.phaseField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("SubEquipment"), Description("A virtual equipment")]
		public bool @virtual 
		{
			get 
			{
				return this.virtualField;
			}
			set
			{
				this.virtualField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tPhaseEnum 
	{		
		A,
		B,
		C,
		N,
		all,
		none,
	}

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
		private string typeField;
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Required]
		[Category("ConductingEquipment"), Description("Type of Conducting Equipment.")]
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
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tPowerTransformerEnum 
	{
		PTR
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tFunction : tPowerSystemResource 
	{		
		private tSubFunction[] subFunctionField;		
		private tGeneralEquipment[] generalEquipmentField;
		
		[System.Xml.Serialization.XmlElementAttribute("SubFunction")]
		[Category("Function"), Browsable(false)]
		public tSubFunction[] SubFunction 
		{
			get 
			{
				return this.subFunctionField;
			}
			set
			{
				this.subFunctionField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("GeneralEquipment")]
		[Category("Function"), Browsable(false)]
		public tGeneralEquipment[] GeneralEquipment 
		{
			get 
			{
				return this.generalEquipmentField;
			}
			set 
			{
				this.generalEquipmentField = value;
			}
		}
	}

	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBay))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tVoltageLevel))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubstation))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tEquipmentContainer : tPowerSystemResource 
	{		
		private tPowerTransformer[] powerTransformerField;		
		private tGeneralEquipment[] generalEquipmentField;
		
		[System.Xml.Serialization.XmlElementAttribute("PowerTransformer")]
		[Category("EquipmentContainer"), Browsable(false)]
		public tPowerTransformer[] PowerTransformer 
		{
			get 
			{
				return this.powerTransformerField;
			}
			set 
			{
				this.powerTransformerField = value;
			}
		}

		[System.Xml.Serialization.XmlElementAttribute("GeneralEquipment")]
		[Category("EquipmentContainer"), Browsable(false)]
		public tGeneralEquipment[] GeneralEquipment 
		{
			get 
			{
				return this.generalEquipmentField;
			}
			set
			{
				this.generalEquipmentField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tBay : tEquipmentContainer
	{		
		private tConductingEquipment[] conductingEquipmentField;		
		private tConnectivityNode[] connectivityNodeField;
		
		[System.Xml.Serialization.XmlElementAttribute("ConductingEquipment")]
		[Category("Bay"), Browsable(false)]
		public tConductingEquipment[] ConductingEquipment 
		{
			get 
			{
				return this.conductingEquipmentField;
			}
			set 
			{
				this.conductingEquipmentField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("ConnectivityNode")]
		[Category("Bay"), Browsable(false)]
		public tConnectivityNode[] ConnectivityNode 
		{
			get
			{
				return this.connectivityNodeField;
			}
			set 
			{
				this.connectivityNodeField = value;
			}
		}
	}
		
	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tDA : tAbstractDataAttribute
	{		
		private bool dchgField;		
		private bool qchgField;		
		private bool dupdField;		
		private tFCEnum fcField;
		
		public tDA() 
		{
			//this.dchgField = false;
			//this.qchgField = false;
			//this.dupdField = false;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DA"), Description("Data change trigger option")]
		public bool dchg 
		{
			get
			{
				return this.dchgField;
			}
			set 
			{
				this.dchgField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("DA"), Description("Quality change trigger option")]		
		public bool qchg
		{
			get
			{
				return this.qchgField;
			}
			set 
			{
				this.qchgField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DA"), Description("Data value update trigger option")]
		public bool dupd 
		{
			get 
			{
				return this.dupdField;
			}
			set 
			{
				this.dupdField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DA"), Description("Functional constraint"), ReadOnly(true)]
		public tFCEnum fc 
		{
			get
			{
				return this.fcField;
			}
			set
			{
				this.fcField = value;
			}
		}
	}

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
		[Category("DOType"), Description("The type of the IED to which this DOType belongs."), ReadOnly(true)]
		public string iedType 
		{
			get 
			{
				return this.iedTypeField;
			}
			set 
			{
				this.iedTypeField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DOType"), Description("The basic Common Data Class."), ReadOnly(true)]
		public string cdc
		{
			get 
			{
				return this.cdcField;
			}
			set
			{
				this.cdcField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 	 
	 * The data type "lnClassField" was added to fulfill standard IEC 61850 Ed. 1.0	 
	 *
	 * To accept any Logical Node without shows an error, the type of lnClass attribute has to be changed from Enum to String.
	*/		
	public partial class tLNodeType : tIDNaming
	{		
		private tDO[] doField;		
		private string iedTypeField;		
		private string lnClassField;
		
		public tLNodeType() 
		{
			this.iedTypeField = "";
		}
		
		public tLNodeType(string iedType, string lnClass, string id) : base (id)
		{
			this.lnClass = lnClass;
			this.iedType = iedType;
		}
		
		[System.Xml.Serialization.XmlElementAttribute("DO")]
		[Category("LNodeType"), Browsable(false)]
		public tDO[] DO 
		{
			get 
			{
				return this.doField;
			}
			set 
			{
				this.doField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LNodeType"), Description("The manufacturer IED type of the IED to which this LN type belongs.")]
		public string iedType
		{
			get
			{
				return this.iedTypeField;
			}
			set
			{
				this.iedTypeField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("LNodeType"), Description("The LN base class of this type.")]
		public string lnClass 
		{
			get 
			{
				return this.lnClassField;
			}
			set 
			{
				this.lnClassField = value;
			}
		}
	}

	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed. 1.0:
	 * unit -> unitField
	 * multiplier -> multiplierField
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]			
	public partial class tDurationInSec : tValueWithUnit 
	{
		private tSIUnitEnum unitField;		
		private tUnitMultiplierEnum multiplierField;
		
		public tDurationInSec()
		{
			this.unitField = tSIUnitEnum.s;
			this.multiplierField = tUnitMultiplierEnum.Item;
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DurationInSec"), Description("Shall define the SI unit.")]
		public tSIUnitEnum unit 
		{
			get 
			{
				return this.unitField;
			}
			set 
			{
				this.unitField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("DurationInSec"), Description("Shall define the multiplier value.")]
		public tUnitMultiplierEnum multiplier 
		{
			get 
			{
				return this.multiplierField;
			}
			set
			{
				this.multiplierField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute("IED", Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	public partial class tIED : tNaming 
	{		
		private static int index = 0;
		private tServices servicesField;		
		private tAccessPoint[] accessPointField;		
		private string typeField;		
		private string manufacturerField;		
		private string configVersionField;
		
		public tIED()
		{
			if(this.name == null)
			{
				this.name = "IED" + ( ++index ).ToString();
			}
		}
		
		[Category("IED"), Description("All services for dynamic building of associations."), Browsable(false)]
		public tServices Services 
		{
			get 
			{
				return this.servicesField;
			}
			set 
			{
				this.servicesField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("AccessPoint")]
		[Category("IED"), Browsable(false)]
		public tAccessPoint[] AccessPoint 
		{
			get 
			{
				return this.accessPointField;
			}
			set 
			{
				this.accessPointField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("IED"), Description("The (manufacturer specific) IED product type.")]
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
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("IED"), Description("The manufacturer’s name.")]
		public string manufacturer 
		{
			get 
			{
				return this.manufacturerField;
			}
			set
			{
				this.manufacturerField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("IED"), Description("The basic configuration version of this IED configuration.")]
		public string configVersion 
		{
			get 
			{
				return this.configVersionField;
			}
			set 
			{
				this.configVersionField = value;
			}
		}
		
		/// <summary>
		/// Add a new Access Point to the IED. 
		/// </summary>
		/// <param name="name">
		/// A <see cref="System.String"/> with the name of the new Access Point to be added.
		/// </param>
		/// <returns>
		/// A <see cref="System.Int32"/> with the index of the new Access Point added.
		/// </returns>
		public int AddAP (string name) {
			if (name == null) return -1;
			tAccessPoint ap = new tAccessPoint();
			ap.name = name;
			int index = -1;
			if (this.accessPointField == null) {
				this.accessPointField = new tAccessPoint[1];
				this.accessPointField[0] = ap;
				index = 0;
			}
			
			// Search for AP name if duplicated return -1				
			for (int i = 0; i < this.accessPointField.GetLength(0); i++) {
				if (this.accessPointField[i].name.Equals(name)) {
					System.Console.WriteLine("Found a Duplicated AP with name " + name);
					return -1;
				}
			}
			// No duplicated, add to the array
			System.Array.Resize<tAccessPoint>(ref this.accessPointField,
			                                  this.accessPointField.GetLength(0) + 1);
			index = this.accessPointField.GetLength(0) - 1;
			this.accessPointField[index] = ap;
			return index;
		}
		
		/// <summary>
		/// Search the Access Point's index with the given name. 
		/// </summary>
		/// <param name="apname">
		/// A <see cref="System.String"/> with the access point to search.
		/// </param>
		/// <returns>
		/// A <see cref="System.Int32"/> with the index of the found access point or -1 if no one was found.
		/// </returns>
		public int GetAP (string apname) {
			for (int i = 0; i < this.accessPointField.GetLength(0); i++) {
				if (this.accessPointField[i].name.Equals(apname))
				{
					return i;
				}
			}
			return -1;
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute("Communication", Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	public partial class tCommunication : tUnNaming
	{		
		private tSubNetwork[] subNetworkField;
		
		private int isn;
		
		public tCommunication() {
			this.isn = 0; // Points to the unused index
		}
		
		[System.Xml.Serialization.XmlElementAttribute("SubNetwork")]
		[Category("Communication"), Browsable(false)]
		public tSubNetwork[] SubNetwork 
		{
			get 
			{
				return this.subNetworkField;
			}
			set 
			{
				this.subNetworkField = value;
			}
		}
		
		/// <summary>
		/// Adds a new Subnetwork with the given name. 
		/// </summary>
		/// <param name="name">
		/// A <see cref="System.String"/> with the name of the new subnetwork to add.
		/// </param>
		/// <returns>
		/// A <see cref="System.Int32"/> with the index of the new subnetwork.
		/// </returns>
		public int AddSubNetwork(string name, string desc) {
			if (name == null) return -1;
			
			tSubNetwork sn = new tSubNetwork();
			sn.name = name;
			sn.desc = desc;
			
			if(this.subNetworkField == null) { // Init array
				this.subNetworkField = new tSubNetwork[1];
				this.subNetworkField[0] = sn;
				return 0;
			}
			// Search for existing subnetwork
			for (int i = 0; i < this.subNetworkField.GetLength(0); i++) {
				if (name.Equals(this.subNetworkField[i].name)) {
					return -1;
				}
			}
			// Add to Array
			int index = -1;
			System.Array.Resize<tSubNetwork>(ref this.subNetworkField,
			                                 this.subNetworkField.GetLength(0) + 1);
			
			index = this.subNetworkField.GetLength(0);
			this.subNetworkField[index] = sn;
			return index;
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute("DataTypeTemplates", Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	public partial class tDataTypeTemplates 
	{		
		private tLNodeType[] lNodeTypeField;		
		private tDOType[] dOTypeField;		
		private tDAType[] dATypeField;		
		private tEnumType[] enumTypeField;
		
		[System.Xml.Serialization.XmlElementAttribute("LNodeType")]
		[Category("DataTypeTemplates"), Browsable(false)]
		public tLNodeType[] LNodeType
		{
			get
			{
				return this.lNodeTypeField;
			}
			set 
			{
				this.lNodeTypeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("DOType")]
		[Category("DataTypeTemplates"), Browsable(false)]
		public tDOType[] DOType 
		{
			get 
			{
				return this.dOTypeField;
			}
			set 
			{
				this.dOTypeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("DAType")]
		[Category("DataTypeTemplates"), Browsable(false)]
		public tDAType[] DAType 
		{
			get 
			{
				return this.dATypeField;
			}
			set 
			{
				this.dATypeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("EnumType")]
		[Category("DataTypeTemplates"), Browsable(false)]
		public tEnumType[] EnumType 
		{
			get 
			{
				return this.enumTypeField;
			}
			set 
			{
				this.enumTypeField = value;
			}
		}
	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	public partial class SCL : tBaseElement 
	{		
		private tHeader headerField;		
		private tSubstation[] substationField;		
		private tCommunication communicationField;		
		private tIED[] iEDField;		
		private tDataTypeTemplates dataTypeTemplatesField;
		
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
		
	}
}
