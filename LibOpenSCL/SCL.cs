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
 * standard IEC 61850-6 Ed.1.0
*/ 

using System.Xml.Serialization;

namespace IEC61850.SCL
{

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute("Substation", Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	public partial class tSubstation : tEquipmentContainer {
		
		private tVoltageLevel[] voltageLevelField;
		
		private tFunction[] functionField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("VoltageLevel")]
		public tVoltageLevel[] VoltageLevel {
			get {
				return this.voltageLevelField;
			}
			set {
				this.voltageLevelField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Function")]
		public tFunction[] Function {
			get {
				return this.functionField;
			}
			set {
				this.functionField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tVoltageLevel : tEquipmentContainer {
		
		private tVoltage voltageField;
		
		private tBay[] bayField;
		
		/// <remarks/>
		public tVoltage Voltage {
			get {
				return this.voltageField;
			}
			set {
				this.voltageField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Bay")]
		public tBay[] Bay {
			get {
				return this.bayField;
			}
			set {
				this.bayField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed.1.0:
	 * unit -> unitField
	 * multiplier -> multiplierField
	*/
	public partial class tVoltage : tValueWithUnit {
		
		private tSIUnitEnum unitField;
		
		private tUnitMultiplierEnum multiplierField;
		
		public tVoltage(){
			this.unitField = tSIUnitEnum.V;
			this.multiplierField = tUnitMultiplierEnum.Item;
		}
		/// <remarks/>
		/// 
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tSIUnitEnum.V)]
		public tSIUnitEnum unit {
			get {
				return this.unitField;
			}
			set {
				this.unitField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tUnitMultiplierEnum.Item)]
		public tUnitMultiplierEnum multiplier {
			get {
				return this.multiplierField;
			}
			set {
				this.multiplierField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDurationInMilliSec))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDurationInSec))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBitRateInMbPerSec))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tVoltage))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/
	public partial class tValueWithUnit {
		
		private tSIUnitEnum unitField;
		
		private tUnitMultiplierEnum multiplierField;
		
		private decimal valueField;
		
		public tValueWithUnit() {
			this.multiplierField = tUnitMultiplierEnum.Item;
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public tSIUnitEnum unit {
			get {
				return this.unitField;
			}
			set {
				this.unitField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tUnitMultiplierEnum.Item)]
		public tUnitMultiplierEnum multiplier {
			get {
				return this.multiplierField;
			}
			set {
				this.multiplierField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public decimal Value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tSIUnitEnum {
		
		/// <remarks/>
		none,
		
		/// <remarks/>
		m,
		
		/// <remarks/>
		kg,
		
		/// <remarks/>
		s,
		
		/// <remarks/>
		A,
		
		/// <remarks/>
		K,
		
		/// <remarks/>
		mol,
		
		/// <remarks/>
		cd,
		
		/// <remarks/>
		deg,
		
		/// <remarks/>
		rad,
		
		/// <remarks/>
		sr,
		
		/// <remarks/>
		Gy,
		
		/// <remarks/>
		q,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("°C")]
		C,
		
		/// <remarks/>
		Sv,
		
		/// <remarks/>
		F,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("C")]
		C1,
		
		/// <remarks/>
		S,
		
		/// <remarks/>
		H,
		
		/// <remarks/>
		V,
		
		/// <remarks/>
		ohm,
		
		/// <remarks/>
		J,
		
		/// <remarks/>
		N,
		
		/// <remarks/>
		Hz,
		
		/// <remarks/>
		lx,
		
		/// <remarks/>
		Lm,
		
		/// <remarks/>
		Wb,
		
		/// <remarks/>
		T,
		
		/// <remarks/>
		W,
		
		/// <remarks/>
		Pa,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("m^2")]
		m2,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("m^3")]
		m3,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("m/s")]
		ms,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("m/s^2")]
		ms2,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("m^3/s")]
		m3s,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("m/m^3")]
		mm3,
		
		/// <remarks/>
		M,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("kg/m^3")]
		kgm3,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("m^2/s")]
		m2s,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("W/m K")]
		WmK,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("J/K")]
		JK,
		
		/// <remarks/>
		ppm,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("s^-1")]
		s1,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("rad/s")]
		rads,
		
		/// <remarks/>
		VA,
		
		/// <remarks/>
		Watts,
		
		/// <remarks/>
		VAr,
		
		/// <remarks/>
		phi,
		
		/// <remarks/>
		cos_phi,
		
		/// <remarks/>
		Vs,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("V^2")]
		V2,
		
		/// <remarks/>
		As,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("A^2")]
		A2,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("A^2 s")]
		A2s,
		
		/// <remarks/>
		VAh,
		
		/// <remarks/>
		Wh,
		
		/// <remarks/>
		VArh,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("V/Hz")]
		VHz,
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("b/s")]
		bs,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tUnitMultiplierEnum {
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("")]
		Item,
		
		/// <remarks/>
		m,
		
		/// <remarks/>
		k,
		
		/// <remarks/>
		M,
		
		/// <remarks/>
		mu,
		
		/// <remarks/>
		y,
		
		/// <remarks/>
		z,
		
		/// <remarks/>
		a,
		
		/// <remarks/>
		f,
		
		/// <remarks/>
		p,
		
		/// <remarks/>
		n,
		
		/// <remarks/>
		c,
		
		/// <remarks/>
		d,
		
		/// <remarks/>
		da,
		
		/// <remarks/>
		h,
		
		/// <remarks/>
		G,
		
		/// <remarks/>
		T,
		
		/// <remarks/>
		P,
		
		/// <remarks/>
		E,
		
		/// <remarks/>
		Z,
		
		/// <remarks/>
		Y,
	}

	/// <remarks/>
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]

	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/
	public partial class tHeader {
		
		private tText textField;
		
		private tHitem[] historyField;
		
		private string idField;
		
		private string versionField;
		
		private string revisionField;
		
		private string toolIDField;
		
		private tHeaderNameStructure nameStructureField;
		
		public tHeader() {
			this.revisionField = "";
			this.nameStructureField = tHeaderNameStructure.IEDName;
		}
		
		/// <remarks/>
		public tText Text {
			get {
				return this.textField;
			}
			set {
				this.textField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("Hitem", IsNullable=false)]
		public tHitem[] History {
			get {
				return this.historyField;
			}
			set {
				this.historyField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string id {
			get {
				return this.idField;
			}
			set {
				this.idField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string version {
			get {
				return this.versionField;
			}
			set {
				this.versionField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[System.ComponentModel.DefaultValueAttribute("")]
		public string revision {
			get {
				return this.revisionField;
			}
			set {
				this.revisionField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string toolID {
			get {
				return this.toolIDField;
			}
			set {
				this.toolIDField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tHeaderNameStructure.IEDName)]
		public tHeaderNameStructure nameStructure {
			get {
				return this.nameStructureField;
			}
			set {
				this.nameStructureField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tText : tAnyContentFromOtherNamespace {
		
		private string sourceField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
		public string source {
			get {
				return this.sourceField;
			}
			set {
				this.sourceField = value;
			}
		}
	}

	/// <remarks/>
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
	public partial class tAnyContentFromOtherNamespace {
		
		private System.Xml.XmlNode[] anyField;
		
		private System.Xml.XmlAttribute[] anyAttrField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		[System.Xml.Serialization.XmlAnyElementAttribute()]
		public System.Xml.XmlNode[] Any {
			get {
				return this.anyField;
			}
			set {
				this.anyField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr {
			get {
				return this.anyAttrField;
			}
			set {
				this.anyAttrField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tLog : tAnyContentFromOtherNamespace {
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tAccessControl : tAnyContentFromOtherNamespace {
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/
	public partial class tHitem : tAnyContentFromOtherNamespace {
		
		private string versionField;
		
		private string revisionField;
		
		private string whenField;
		
		private string whoField;
		
		private string whatField;
		
		private string whyField;
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string version {
			get {
				return this.versionField;
			}
			set {
				this.versionField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string revision {
			get {
				return this.revisionField;
			}
			set {
				this.revisionField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string when {
			get {
				return this.whenField;
			}
			set {
				this.whenField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string who {
			get {
				return this.whoField;
			}
			set {
				this.whoField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string what {
			get {
				return this.whatField;
			}
			set {
				this.whatField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string why {
			get {
				return this.whyField;
			}
			set {
				this.whyField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tPrivate : tAnyContentFromOtherNamespace {
		
		private string typeField;
		
		private string sourceField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
		public string source {
			get {
				return this.sourceField;
			}
			set {
				this.sourceField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tHeaderNameStructure {
		
		/// <remarks/>
		IEDName,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/
	public partial class tEnumVal {
		
		private string ordField;
		
		private string valueField;
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
		public string ord {
			get {
				return this.ordField;
			}
			set {
				this.ordField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute(DataType="normalizedString")]
		public string Value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed.1.0:
	 * iedName -> iedNameField
	 * ldInst -> ldInstField
	*/
	public partial class tAssociation {
		
		private tAssociationKindEnum kindField;
		
		private string associationIDField;
		
		private string iedNameField;
		
		private string ldInstField;
		
		private string prefixField;
		
		private string lnClassField;
		
		private string lnInstField;
		
		public tAssociation() {
			this.prefixField = "";
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public tAssociationKindEnum kind {
			get {
				return this.kindField;
			}
			set {
				this.kindField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string associationID {
			get {
				return this.associationIDField;
			}
			set {
				this.associationIDField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string iedName {
			get {
				return this.iedNameField;
			}
			set {
				this.iedNameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string ldInst {
			get {
				return this.ldInstField;
			}
			set {
				this.ldInstField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[System.ComponentModel.DefaultValueAttribute("")]
		public string prefix {
			get {
				return this.prefixField;
			}
			set {
				this.prefixField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string lnClass {
			get {
				return this.lnClassField;
			}
			set {
				this.lnClassField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string lnInst {
			get {
				return this.lnInstField;
			}
			set {
				this.lnInstField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tAssociationKindEnum {
		
		/// <remarks/>
		[System.Xml.Serialization.XmlEnumAttribute("pre-established")]
		preestablished,
		
		/// <remarks/>
		predefined,
	}
	
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed.1.0:
	 * iedName -> iedNameField
	 * ldInst -> ldInstField
	 * prefix -> prefixField
	 * lnClass -> lnClassField
	 * lnInst -> lnInstField
	*/	
	public partial class tExtRef {
		
		private string iedNameField;
		
		private string ldInstField;
		
		private string prefixField;
		
		private string lnClassField;
		
		private string lnInstField;
		
		private string doNameField;
		
		private string daNameField;
		
		private string intAddrField;
		
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string iedName {
			get {
				return this.iedNameField;
			}
			set {
				this.iedNameField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string ldInst {
			get {
				return this.ldInstField;
			}
			set {
				this.ldInstField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string prefix {
			get {
				return this.prefixField;
			}
			set {
				this.prefixField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string lnClass {
			get {
				return this.lnClassField;
			}
			set {
				this.lnClassField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string lnInst {
			get {
				return this.lnInstField;
			}
			set {
				this.lnInstField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string doName {
			get {
				return this.doNameField;
			}
			set {
				this.doNameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string daName {
			get {
				return this.daNameField;
			}
			set {
				this.daNameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string intAddr {
			get {
				return this.intAddrField;
			}
			set {
				this.intAddrField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tVal {
		
		private uint sGroupField;
		
		private bool sGroupFieldSpecified;
		
		private string valueField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint sGroup {
			get {
				return this.sGroupField;
			}
			set {
				this.sGroupField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool sGroupSpecified {
			get {
				return this.sGroupFieldSpecified;
			}
			set {
				this.sGroupFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute(DataType="normalizedString")]
		public string Value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/
	public partial class tPhysConn {
		
		private tP[] pField;
		
		private string typeField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("P")]
		public tP[] P {
			get {
				return this.pField;
			}
			set {
				this.pField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
	}

	/// <remarks/>
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
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The data type "tPTypeEnum was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public partial class tP {
		
		private tPTypeEnum typeField;
		
		private string valueField;
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public tPTypeEnum type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute(DataType="normalizedString")]
		public string Value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}	
	}
	
    /// <remarks/>
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "TPTypeEnum" was added to fullfill standar IEC 61850 Ed.1.0
	*/
	public enum tPTypeEnum{
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
	}
	
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_VLAN-ID", Namespace="http://www.iec.ch/61850/2003/SCL")]
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed.1.0:
	*/	
	public partial class tP_VLANID : tP {
		//private tPTypeEnum typeField;
		
		public tP_VLANID() {
			this.type = tPTypeEnum.VLAN_ID;
		}
		
//		[Required]
//		[System.Xml.Serialization.XmlAttributeAttribute()]
//		[System.ComponentModel.DefaultValueAttribute(tPTypeEnum.VLAN_ID)]
//		public tPTypeEnum type {
//			get {
//				return this.typeField;
//			}
//			set {
//				this.typeField = value;
//			}
//		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_VLAN-PRIORITY", Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public partial class tP_VLANPRIORITY : tP {
		//private tPTypeEnum typeField;
		
		public tP_VLANPRIORITY() {
			this.type = tPTypeEnum.VLAN_PRIORITY;
		}
		
//		[Required]
//		[System.Xml.Serialization.XmlAttributeAttribute()]
//		[System.ComponentModel.DefaultValueAttribute(tPTypeEnum.VLAN_PRIORITY)]
//		public tPTypeEnum type {
//			get {
//				return this.typeField;
//			}
//			set {
//				this.typeField = value;
//			}
//		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public partial class tP_APPID : tP {
		//private tPTypeEnum typeField;
		
		public tP_APPID() {
			this.type = tPTypeEnum.APPID;
		}
		
//		[Required]
//		[System.Xml.Serialization.XmlAttributeAttribute()]
//		[System.ComponentModel.DefaultValueAttribute(tPTypeEnum.APPID)]
//		public tPTypeEnum type {
//			get {
//				return this.typeField;
//			}
//			set {
//				this.typeField = value;
//			}
//		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_MAC-Address", Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed.1.0
	*/	
	public partial class tP_MACAddress : tP {
		//private tPTypeEnum typeField;
		
		public tP_MACAddress() {
			this.type = tPTypeEnum.MAC_Address;
		}
		
//		[Required]
//		[System.Xml.Serialization.XmlAttributeAttribute()]
//		[System.ComponentModel.DefaultValueAttribute(tPTypeEnum.MAC_Address)]
//		public tPTypeEnum type {
//			get {
//				return this.typeField;
//			}
//			set {
//				this.typeField = value;
//			}
//		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-AE-Invoke", Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public partial class tP_OSIAEInvoke : tP {
		//private tPTypeEnum typeField;
		
		public tP_OSIAEInvoke() {
			this.type = tPTypeEnum.OSI_AE_Invoke;
		}
//		
//		[Required]
//		[System.Xml.Serialization.XmlAttributeAttribute()]
//		[System.ComponentModel.DefaultValueAttribute(tPTypeEnum.OSI_AE_Invoke)]
//		public tPTypeEnum type {
//			get {
//				return this.typeField;
//			}
//			set {
//				this.typeField = value;
//			}
//		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-AE-Qualifier", Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public partial class tP_OSIAEQualifier : tP {
		//private tPTypeEnum typeField;
		
		public tP_OSIAEQualifier() {
			this.type = tPTypeEnum.OSI_AE_Qualifier;
		}
		
//		[Required]
//		[System.Xml.Serialization.XmlAttributeAttribute()]
//		[System.ComponentModel.DefaultValueAttribute(tPTypeEnum.OSI_AE_Qualifier)]
//		public tPTypeEnum type {
//			get {
//				return this.typeField;
//			}
//			set {
//				this.typeField = value;
//			}
//		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-AP-Invoke", Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed.1.0
	*/	
	public partial class tP_OSIAPInvoke : tP {
		//private tPTypeEnum typeField;
		
		public tP_OSIAPInvoke() {
			this.type = tPTypeEnum.OSI_AP_Invoke;
		}
		
//		[Required]
//		[System.Xml.Serialization.XmlAttributeAttribute()]
//		[System.ComponentModel.DefaultValueAttribute(tPTypeEnum.OSI_AP_Invoke)]
//		public tPTypeEnum type {
//			get {
//				return this.typeField;
//			}
//			set {
//				this.typeField = value;
//			}
//		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-AP-Title", Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed.1.0
	*/	
	public partial class tP_OSIAPTitle : tP {
		//private tPTypeEnum typeField;
		
		public tP_OSIAPTitle() {
			this.type = tPTypeEnum.OSI_AP_Title;
		}
		
//		[Required]
//		[System.Xml.Serialization.XmlAttributeAttribute()]
//		[System.ComponentModel.DefaultValueAttribute(tPTypeEnum.OSI_AP_Title)]
//		public tPTypeEnum type {
//			get {
//				return this.typeField;
//			}
//			set {
//				this.typeField = value;
//			}
//		}
	}
	
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-PSEL", Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed.1.0
	*/	
	public partial class tP_OSIPSEL : tP {
		//private tPTypeEnum typeField;
		
		public tP_OSIPSEL() {
			this.type = tPTypeEnum.OSI_PSEL;
		}
		
//		[Required]
//		[System.Xml.Serialization.XmlAttributeAttribute()]
//		[System.ComponentModel.DefaultValueAttribute(tPTypeEnum.OSI_PSEL)]
//		public tPTypeEnum type {
//			get {
//				return this.typeField;
//			}
//			set {
//				this.typeField = value;
//			}
//		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-SSEL", Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed.1.0
	*/	
	public partial class tP_OSISSEL : tP {
		//private tPTypeEnum typeField;
		
		public tP_OSISSEL() {
			this.type = tPTypeEnum.OSI_SSEL;
		}
		
//		[Required]
//		[System.Xml.Serialization.XmlAttributeAttribute()]
//		[System.ComponentModel.DefaultValueAttribute(tPTypeEnum.OSI_SSEL)]
//		public tPTypeEnum type {
//			get {
//				return this.typeField;
//			}
//			set {
//				this.typeField = value;
//			}
//		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-TSEL", Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public partial class tP_OSITSEL : tP {
		//private tPTypeEnum typeField;
		
		public tP_OSITSEL() {
			this.type = tPTypeEnum.OSI_TSEL;
		}
		
//		[Required]
//		[System.Xml.Serialization.XmlAttributeAttribute()]
//		[System.ComponentModel.DefaultValueAttribute(tPTypeEnum.OSI_TSEL)]
//		public tPTypeEnum type {
//			get {
//				return this.typeField;
//			}
//			set {
//				this.typeField = value;
//			}
//		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_OSI-NSAP", Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public partial class tP_OSINSAP : tP {
		//private tPTypeEnum typeField;
		
		public tP_OSINSAP() {
			this.type = tPTypeEnum.OSI_NSAP;
		}
		
//		[Required]
//		[System.Xml.Serialization.XmlAttributeAttribute()]
//		[System.ComponentModel.DefaultValueAttribute(tPTypeEnum.OSI_NSAP)]
//		public tPTypeEnum type {
//			get {
//				return this.typeField;
//			}
//			set {
//				this.typeField = value;
//			}
//		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_IP-GATEWAY", Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed.1.0
	*/	
	public partial class tP_IPGATEWAY : tP {
		//private tPTypeEnum typeField;
		
		public tP_IPGATEWAY() {
			this.type = tPTypeEnum.IP_GATEWAY;
		}
		
//		[Required]
//		[System.Xml.Serialization.XmlAttributeAttribute()]
//		[System.ComponentModel.DefaultValueAttribute(tPTypeEnum.IP_GATEWAY)]
//		public tPTypeEnum type {
//			get {
//				return this.typeField;
//			}
//			set {
//				this.typeField = value;
//			}
//		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(TypeName="tP_IP-SUBNET", Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed.1.0
	*/	
	public partial class tP_IPSUBNET : tP {
		//private tPTypeEnum typeField;
		
		public tP_IPSUBNET() {
			this.type = tPTypeEnum.IP_SUBNET;
		}
		
//		[Required]
//		[System.Xml.Serialization.XmlAttributeAttribute()]
//		[System.ComponentModel.DefaultValueAttribute(tPTypeEnum.IP_SUBNET)]
//		public tPTypeEnum type {
//			get {
//				return this.typeField;
//			}
//			set {
//				this.typeField = value;
//			}
//		}
	}

	/// <remarks/>
	//$
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The attribute "type" was added to fulfill standard IEC 61850 Ed.1.0
	*/	
	public partial class tP_IP : tP {
		//private tPTypeEnum typeField;
		
		public tP_IP() {
			this.type = tPTypeEnum.IP;
		}
		
		
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed.1.0:
	 * iedName -> iedNameField
	 * ldInst -> ldInstField
	*/	
	public partial class tClientLN {
		
		private string iedNameField;
		
		private string ldInstField;
		
		private string prefixField;
		
		private string lnClassField;
		
		private string lnInstField;
		
		public tClientLN() {
			this.prefixField = "";
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string iedName {
			get {
				return this.iedNameField;
			}
			set {
				this.iedNameField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string ldInst {
			get {
				return this.ldInstField;
			}
			set {
				this.ldInstField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[System.ComponentModel.DefaultValueAttribute("")]
		public string prefix {
			get {
				return this.prefixField;
			}
			set {
				this.prefixField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string lnClass {
			get {
				return this.lnClassField;
			}
			set {
				this.lnClassField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string lnInst {
			get {
				return this.lnInstField;
			}
			set {
				this.lnInstField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tTrgOps {
		
		private bool dchgField;
		
		private bool qchgField;
		
		private bool dupdField;
		
		private bool periodField;
		
		public tTrgOps() {
			this.dchgField = false;
			this.qchgField = false;
			this.dupdField = false;
			this.periodField = false;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool dchg {
			get {
				return this.dchgField;
			}
			set {
				this.dchgField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool qchg {
			get {
				return this.qchgField;
			}
			set {
				this.qchgField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool dupd {
			get {
				return this.dupdField;
			}
			set {
				this.dupdField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool period {
			get {
				return this.periodField;
			}
			set {
				this.periodField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tFCDA {
		
		private string ldInstField;
		
		private string prefixField;
		
		private string lnClassField;
		
		private string lnInstField;
		
		private string doNameField;
		
		private string daNameField;
		
		private tFCEnum fcField;
		
		public tFCDA() {
			this.prefixField = "";
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string ldInst {
			get {
				return this.ldInstField;
			}
			set {
				this.ldInstField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[System.ComponentModel.DefaultValueAttribute("")]
		public string prefix {
			get {
				return this.prefixField;
			}
			set {
				this.prefixField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string lnClass {
			get {
				return this.lnClassField;
			}
			set {
				this.lnClassField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string lnInst {
			get {
				return this.lnInstField;
			}
			set {
				this.lnInstField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string doName {
			get {
				return this.doNameField;
			}
			set {
				this.doNameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string daName {
			get {
				return this.daNameField;
			}
			set {
				this.daNameField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public tFCEnum fc {
			get {
				return this.fcField;
			}
			set {
				this.fcField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tFCEnum {
		
		/// <remarks/>
		ST,
		
		/// <remarks/>
		MX,
		
		/// <remarks/>
		CO,
		
		/// <remarks/>
		SP,
		
		/// <remarks/>
		SG,
		
		/// <remarks/>
		SE,
		
		/// <remarks/>
		SV,
		
		/// <remarks/>
		CF,
		
		/// <remarks/>
		DC,
		
		/// <remarks/>
		EX,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tConfLNs {
		
		private bool fixPrefixField;
		
		private bool fixLnInstField;
		
		public tConfLNs() {
			this.fixPrefixField = false;
			this.fixLnInstField = false;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool fixPrefix {
			get {
				return this.fixPrefixField;
			}
			set {
				this.fixPrefixField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool fixLnInst {
			get {
				return this.fixLnInstField;
			}
			set {
				this.fixLnInstField = value;
			}
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSMVSettings))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSESettings))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLogSettings))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tReportSettings))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServiceSettings {
		
		private tServiceSettingsEnum cbNameField;
		
		private tServiceSettingsEnum datSetField;
		
		public tServiceSettings() {
			this.cbNameField = tServiceSettingsEnum.Fix;
			this.datSetField = tServiceSettingsEnum.Fix;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tServiceSettingsEnum.Fix)]
		public tServiceSettingsEnum cbName {
			get {
				return this.cbNameField;
			}
			set {
				this.cbNameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tServiceSettingsEnum.Fix)]
		public tServiceSettingsEnum datSet {
			get {
				return this.datSetField;
			}
			set {
				this.datSetField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tServiceSettingsEnum {
		
		/// <remarks/>
		Dyn,
		
		/// <remarks/>
		Conf,
		
		/// <remarks/>
		Fix,
	}

	/// <remarks/>	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSMVSettings : tServiceSettings {
		
		private decimal[] smpRateField;
		
		private tServiceSettingsEnum svIDField;
		
		private tServiceSettingsEnum optFieldsField;
		
		private tServiceSettingsEnum smpRateField1;
		
		public tSMVSettings() {
			this.svIDField = tServiceSettingsEnum.Fix;
			this.optFieldsField = tServiceSettingsEnum.Fix;
			this.smpRateField1 = tServiceSettingsEnum.Fix;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("SmpRate")]
		public decimal[] SmpRate {
			get {
				return this.smpRateField;
			}
			set {
				this.smpRateField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tServiceSettingsEnum.Fix)]
		public tServiceSettingsEnum svID {
			get {
				return this.svIDField;
			}
			set {
				this.svIDField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tServiceSettingsEnum.Fix)]
		public tServiceSettingsEnum optFields {
			get {
				return this.optFieldsField;
			}
			set {
				this.optFieldsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tServiceSettingsEnum.Fix)]
		public tServiceSettingsEnum smpRate {
			get {
				return this.smpRateField1;
			}
			set {
				this.smpRateField1 = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tGSESettings : tServiceSettings {
		
		private tServiceSettingsEnum appIDField;
		
		private tServiceSettingsEnum dataLabelField;
		
		public tGSESettings() {
			this.appIDField = tServiceSettingsEnum.Fix;
			this.dataLabelField = tServiceSettingsEnum.Fix;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tServiceSettingsEnum.Fix)]
		public tServiceSettingsEnum appID {
			get {
				return this.appIDField;
			}
			set {
				this.appIDField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tServiceSettingsEnum.Fix)]
		public tServiceSettingsEnum dataLabel {
			get {
				return this.dataLabelField;
			}
			set {
				this.dataLabelField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tLogSettings : tServiceSettings {
		
		private tServiceSettingsEnum logEnaField;
		
		private tServiceSettingsEnum trgOpsField;
		
		private tServiceSettingsEnum intgPdField;
		
		public tLogSettings() {
			this.logEnaField = tServiceSettingsEnum.Fix;
			this.trgOpsField = tServiceSettingsEnum.Fix;
			this.intgPdField = tServiceSettingsEnum.Fix;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tServiceSettingsEnum.Fix)]
		public tServiceSettingsEnum logEna {
			get {
				return this.logEnaField;
			}
			set {
				this.logEnaField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tServiceSettingsEnum.Fix)]
		public tServiceSettingsEnum trgOps {
			get {
				return this.trgOpsField;
			}
			set {
				this.trgOpsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tServiceSettingsEnum.Fix)]
		public tServiceSettingsEnum intgPd {
			get {
				return this.intgPdField;
			}
			set {
				this.intgPdField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tReportSettings : tServiceSettings {
		
		private tServiceSettingsEnum rptIDField;
		
		private tServiceSettingsEnum optFieldsField;
		
		private tServiceSettingsEnum bufTimeField;
		
		private tServiceSettingsEnum trgOpsField;
		
		private tServiceSettingsEnum intgPdField;
		
		public tReportSettings() {
			this.rptIDField = tServiceSettingsEnum.Fix;
			this.optFieldsField = tServiceSettingsEnum.Fix;
			this.bufTimeField = tServiceSettingsEnum.Fix;
			this.trgOpsField = tServiceSettingsEnum.Fix;
			this.intgPdField = tServiceSettingsEnum.Fix;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tServiceSettingsEnum.Fix)]
		public tServiceSettingsEnum rptID {
			get {
				return this.rptIDField;
			}
			set {
				this.rptIDField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tServiceSettingsEnum.Fix)]
		public tServiceSettingsEnum optFields {
			get {
				return this.optFieldsField;
			}
			set {
				this.optFieldsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tServiceSettingsEnum.Fix)]
		public tServiceSettingsEnum bufTime {
			get {
				return this.bufTimeField;
			}
			set {
				this.bufTimeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tServiceSettingsEnum.Fix)]
		public tServiceSettingsEnum trgOps {
			get {
				return this.trgOpsField;
			}
			set {
				this.trgOpsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tServiceSettingsEnum.Fix)]
		public tServiceSettingsEnum intgPd {
			get {
				return this.intgPdField;
			}
			set {
				this.intgPdField = value;
			}
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tServiceWithMaxAndClient))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tServiceWithMaxAndModify))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tServiceWithMaxAndMaxAttributes))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tServiceWithMaxAndMaxAttributesAndModify))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tServiceWithMax {
		
		private uint maxField;
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint max {
			get {
				return this.maxField;
			}
			set {
				this.maxField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServiceWithMaxAndClient : tServiceWithMax {
		
		private bool clientField;
		
		public tServiceWithMaxAndClient() {
			this.clientField = true;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(true)]
		public bool client {
			get {
				return this.clientField;
			}
			set {
				this.clientField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServiceWithMaxAndModify : tServiceWithMax {
		
		private bool modifyField;
		
		public tServiceWithMaxAndModify() {
			this.modifyField = true;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(true)]
		public bool modify {
			get {
				return this.modifyField;
			}
			set {
				this.modifyField = value;
			}
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tServiceWithMaxAndMaxAttributesAndModify))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServiceWithMaxAndMaxAttributes : tServiceWithMax {
		
		private uint maxAttributesField;
		
		private bool maxAttributesFieldSpecified;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint maxAttributes {
			get {
				return this.maxAttributesField;
			}
			set {
				this.maxAttributesField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool maxAttributesSpecified {
			get {
				return this.maxAttributesFieldSpecified;
			}
			set {
				this.maxAttributesFieldSpecified = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServiceWithMaxAndMaxAttributesAndModify : tServiceWithMaxAndMaxAttributes {
		
		private bool modifyField;
		
		public tServiceWithMaxAndMaxAttributesAndModify() {
			this.modifyField = true;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(true)]
		public bool modify {
			get {
				return this.modifyField;
			}
			set {
				this.modifyField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServiceYesNo {
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServices {
		
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
		
		/// <remarks/>
		public tServiceYesNo DynAssociation {
			get {
				return this.dynAssociationField;
			}
			set {
				this.dynAssociationField = value;
			}
		}
		
		/// <remarks/>
		public tServicesSettingGroups SettingGroups {
			get {
				return this.settingGroupsField;
			}
			set {
				this.settingGroupsField = value;
			}
		}
		
		/// <remarks/>
		public tServiceYesNo GetDirectory {
			get {
				return this.getDirectoryField;
			}
			set {
				this.getDirectoryField = value;
			}
		}
		
		/// <remarks/>
		public tServiceYesNo GetDataObjectDefinition {
			get {
				return this.getDataObjectDefinitionField;
			}
			set {
				this.getDataObjectDefinitionField = value;
			}
		}
		
		/// <remarks/>
		public tServiceYesNo DataObjectDirectory {
			get {
				return this.dataObjectDirectoryField;
			}
			set {
				this.dataObjectDirectoryField = value;
			}
		}
		
		/// <remarks/>
		public tServiceYesNo GetDataSetValue {
			get {
				return this.getDataSetValueField;
			}
			set {
				this.getDataSetValueField = value;
			}
		}
		
		/// <remarks/>
		public tServiceYesNo SetDataSetValue {
			get {
				return this.setDataSetValueField;
			}
			set {
				this.setDataSetValueField = value;
			}
		}
		
		/// <remarks/>
		public tServiceYesNo DataSetDirectory {
			get {
				return this.dataSetDirectoryField;
			}
			set {
				this.dataSetDirectoryField = value;
			}
		}
		
		/// <remarks/>
		public tServiceWithMaxAndMaxAttributesAndModify ConfDataSet {
			get {
				return this.confDataSetField;
			}
			set {
				this.confDataSetField = value;
			}
		}
		
		/// <remarks/>
		public tServiceWithMaxAndMaxAttributes DynDataSet {
			get {
				return this.dynDataSetField;
			}
			set {
				this.dynDataSetField = value;
			}
		}
		
		/// <remarks/>
		public tServiceYesNo ReadWrite {
			get {
				return this.readWriteField;
			}
			set {
				this.readWriteField = value;
			}
		}
		
		/// <remarks/>
		public tServiceYesNo TimerActivatedControl {
			get {
				return this.timerActivatedControlField;
			}
			set {
				this.timerActivatedControlField = value;
			}
		}
		
		/// <remarks/>
		public tServiceWithMax ConfReportControl {
			get {
				return this.confReportControlField;
			}
			set {
				this.confReportControlField = value;
			}
		}
		
		/// <remarks/>
		public tServiceYesNo GetCBValues {
			get {
				return this.getCBValuesField;
			}
			set {
				this.getCBValuesField = value;
			}
		}
		
		/// <remarks/>
		public tServiceWithMax ConfLogControl {
			get {
				return this.confLogControlField;
			}
			set {
				this.confLogControlField = value;
			}
		}
		
		/// <remarks/>
		public tReportSettings ReportSettings {
			get {
				return this.reportSettingsField;
			}
			set {
				this.reportSettingsField = value;
			}
		}
		
		/// <remarks/>
		public tLogSettings LogSettings {
			get {
				return this.logSettingsField;
			}
			set {
				this.logSettingsField = value;
			}
		}
		
		/// <remarks/>
		public tGSESettings GSESettings {
			get {
				return this.gSESettingsField;
			}
			set {
				this.gSESettingsField = value;
			}
		}
		
		/// <remarks/>
		public tSMVSettings SMVSettings {
			get {
				return this.sMVSettingsField;
			}
			set {
				this.sMVSettingsField = value;
			}
		}
		
		/// <remarks/>
		public tServiceYesNo GSEDir {
			get {
				return this.gSEDirField;
			}
			set {
				this.gSEDirField = value;
			}
		}
		
		/// <remarks/>
		public tServiceWithMaxAndClient GOOSE {
			get {
				return this.gOOSEField;
			}
			set {
				this.gOOSEField = value;
			}
		}
		
		/// <remarks/>
		public tServiceWithMaxAndClient GSSE {
			get {
				return this.gSSEField;
			}
			set {
				this.gSSEField = value;
			}
		}
		
		/// <remarks/>
		public tServiceYesNo FileHandling {
			get {
				return this.fileHandlingField;
			}
			set {
				this.fileHandlingField = value;
			}
		}
		
		/// <remarks/>
		public tConfLNs ConfLNs {
			get {
				return this.confLNsField;
			}
			set {
				this.confLNsField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServicesSettingGroups {
		
		private tServiceYesNo sGEditField;
		
		private tServiceYesNo confSGField;
		
		/// <remarks/>
		public tServiceYesNo SGEdit {
			get {
				return this.sGEditField;
			}
			set {
				this.sGEditField = value;
			}
		}
		
		/// <remarks/>
		public tServiceYesNo ConfSG {
			get {
				return this.confSGField;
			}
			set {
				this.confSGField = value;
			}
		}
	}

	/// <remarks/>
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
	public partial class tBaseElement {
		
		private System.Xml.XmlElement[] anyField;
		
		private tText textField;
		
		private tPrivate[] privateField;
		
		private System.Xml.XmlAttribute[] anyAttrField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAnyElementAttribute()]
		public System.Xml.XmlElement[] Any {
			get {
				return this.anyField;
			}
			set {
				this.anyField = value;
			}
		}
		
		/// <remarks/>
		public tText Text {
			get {
				return this.textField;
			}
			set {
				this.textField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Private")]
		public tPrivate[] Private {
			get {
				return this.privateField;
			}
			set {
				this.privateField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr {
			get {
				return this.anyAttrField;
			}
			set {
				this.anyAttrField = value;
			}
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEnumType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDAType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDOType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLNodeType))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tIDNaming : tBaseElement {
		
		private string idField;
		
		private string descField;
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string id {
			get {
				return this.idField;
			}
			set {
				this.idField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string desc {
			get {
				return this.descField;
			}
			set {
				this.descField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tEnumType : tIDNaming {
		
		private tEnumVal[] enumValField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("EnumVal")]
		public tEnumVal[] EnumVal {
			get {
				return this.enumValField;
			}
			set {
				this.enumValField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tDAType : tIDNaming {
		
		private tBDA[] bDAField;
		
		private string iedTypeField;
		
		public tDAType() {
			this.iedTypeField = "";
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("BDA")]
		public tBDA[] BDA {
			get {
				return this.bDAField;
			}
			set {
				this.bDAField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[System.ComponentModel.DefaultValueAttribute("")]
		public string iedType {
			get {
				return this.iedTypeField;
			}
			set {
				this.iedTypeField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tBDA : tAbstractDataAttribute {
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBDA))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDA))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tAbstractDataAttribute : tUnNaming {
		
		private tVal[] valField;
		
		private string nameField;
		
		private string sAddrField;
		
		private string bTypeField;
		
		private tValKindEnum valKindField;
		
		private string typeField;
		
		private uint countField;
		
		public tAbstractDataAttribute() {
			this.valKindField = tValKindEnum.Set;
			this.countField = ((uint)(0));
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Val")]
		public tVal[] Val {
			get {
				return this.valField;
			}
			set {
				this.valField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string sAddr {
			get {
				return this.sAddrField;
			}
			set {
				this.sAddrField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string bType {
			get {
				return this.bTypeField;
			}
			set {
				this.bTypeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tValKindEnum.Set)]
		public tValKindEnum valKind {
			get {
				return this.valKindField;
			}
			set {
				this.valKindField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(typeof(uint), "0")]
		public uint count {
			get {
				return this.countField;
			}
			set {
				this.countField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tValKindEnum {
		
		/// <remarks/>
		Spec,
		
		/// <remarks/>
		Conf,
		
		/// <remarks/>
		RO,
		
		/// <remarks/>
		Set,
	}

	/// <remarks/>
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
	public partial class tUnNaming : tBaseElement {
		
		private string descField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string desc {
			get {
				return this.descField;
			}
			set {
				this.descField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tDO : tUnNaming {
		
		private string nameField;
		
		private string typeField;
		
		private string accessControlField;
		
		private bool transientField;
		
		public tDO() {
			this.transientField = false;
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="Name")]
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string accessControl {
			get {
				return this.accessControlField;
			}
			set {
				this.accessControlField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool transient {
			get {
				return this.transientField;
			}
			set {
				this.transientField = value;
			}
		}
	}

	/// <remarks/>	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSCLControl : tUnNaming {
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tSettingControl : tUnNaming {
		
		private uint numOfSGsField;
		
		private uint actSGField;
		
		public tSettingControl() {
			this.actSGField = ((uint)(1));
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint numOfSGs {
			get {
				return this.numOfSGsField;
			}
			set {
				this.numOfSGsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(typeof(uint), "1")]
		public uint actSG {
			get {
				return this.actSGField;
			}
			set {
				this.actSGField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tInputs : tUnNaming {
		
		private tExtRef[] extRefField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ExtRef")]
		public tExtRef[] ExtRef {
			get {
				return this.extRefField;
			}
			set {
				this.extRefField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tDAI : tUnNaming {
		
		private tVal[] valField;
		
		private string nameField;
		
		private string sAddrField;
		
		private tValKindEnum valKindField;
		
		private uint ixField;
		
		private bool ixFieldSpecified;
		
		public tDAI() {
			this.valKindField = tValKindEnum.Set;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Val")]
		public tVal[] Val {
			get {
				return this.valField;
			}
			set {
				this.valField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string sAddr {
			get {
				return this.sAddrField;
			}
			set {
				this.sAddrField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tValKindEnum.Set)]
		public tValKindEnum valKind {
			get {
				return this.valKindField;
			}
			set {
				this.valKindField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint ix {
			get {
				return this.ixField;
			}
			set {
				this.ixField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ixSpecified {
			get {
				return this.ixFieldSpecified;
			}
			set {
				this.ixFieldSpecified = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tSDI : tUnNaming {
		
		private tUnNaming[] itemsField;
		
		private string nameField;
		
		private uint ixField;
		
		private bool ixFieldSpecified;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("DAI", typeof(tDAI))]
		[System.Xml.Serialization.XmlElementAttribute("SDI", typeof(tSDI))]
		public tUnNaming[] Items {
			get {
				return this.itemsField;
			}
			set {
				this.itemsField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint ix {
			get {
				return this.ixField;
			}
			set {
				this.ixField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ixSpecified {
			get {
				return this.ixFieldSpecified;
			}
			set {
				this.ixFieldSpecified = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]

	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tDOI : tUnNaming {
		
		private tUnNaming[] itemsField;
		
		private string nameField;
		
		private uint ixField;
		
		private bool ixFieldSpecified;
		
		private string accessControlField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("DAI", typeof(tDAI))]
		[System.Xml.Serialization.XmlElementAttribute("SDI", typeof(tSDI))]
		public tUnNaming[] Items {
			get {
				return this.itemsField;
			}
			set {
				this.itemsField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="Name")]
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint ix {
			get {
				return this.ixField;
			}
			set {
				this.ixField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ixSpecified {
			get {
				return this.ixFieldSpecified;
			}
			set {
				this.ixFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string accessControl {
			get {
				return this.accessControlField;
			}
			set {
				this.accessControlField = value;
			}
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSMV))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSE))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tControlBlock : tUnNaming {
		
		private tP[] addressField;
		
		private string ldInstField;
		
		private string cbNameField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("P", IsNullable=false)]
		public tP[] Address {
			get {
				return this.addressField;
			}
			set {
				this.addressField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string ldInst {
			get {
				return this.ldInstField;
			}
			set {
				this.ldInstField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string cbName {
			get {
				return this.cbNameField;
			}
			set {
				this.cbNameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSMV : tControlBlock {
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tGSE : tControlBlock {
		
		private tDurationInMilliSec minTimeField;
		
		private tDurationInMilliSec maxTimeField;
		
		/// <remarks/>
		public tDurationInMilliSec MinTime {
			get {
				return this.minTimeField;
			}
			set {
				this.minTimeField = value;
			}
		}
		
		/// <remarks/>
		public tDurationInMilliSec MaxTime {
			get {
				return this.maxTimeField;
			}
			set {
				this.maxTimeField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
		
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed.1.0:
	 * unit -> unitField
	 * multiplier -> multiplierField
	*/		
	public partial class tDurationInMilliSec : tValueWithUnit {
			private tSIUnitEnum unitField;
		
		private tUnitMultiplierEnum multiplierField;
		
		public tDurationInMilliSec(){
			this.unitField = tSIUnitEnum.s;
			this.multiplierField = tUnitMultiplierEnum.m;
		}
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tSIUnitEnum.s)]
		public tSIUnitEnum unit {
			get {
				return this.unitField;
			}
			set {
				this.unitField = value;
			}
		}
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tUnitMultiplierEnum.m)]
		public tUnitMultiplierEnum multiplier {
			get {
				return this.multiplierField;
			}
			set {
				this.multiplierField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tConnectedAP : tUnNaming {
		
		private tP[] addressField;
		
		private tGSE[] gSEField;
		
		private tSMV[] sMVField;
		
		private tPhysConn[] physConnField;
		
		private string iedNameField;
		
		private string apNameField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("P", IsNullable=false)]
		public tP[] Address {
			get {
				return this.addressField;
			}
			set {
				this.addressField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("GSE")]
		public tGSE[] GSE {
			get {
				return this.gSEField;
			}
			set {
				this.gSEField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("SMV")]
		public tSMV[] SMV {
			get {
				return this.sMVField;
			}
			set {
				this.sMVField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("PhysConn")]
		public tPhysConn[] PhysConn {
			get {
				return this.physConnField;
			}
			set {
				this.physConnField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string iedName {
			get {
				return this.iedNameField;
			}
			set {
				this.iedNameField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string apName {
			get {
				return this.apNameField;
			}
			set {
				this.apNameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tRptEnabled : tUnNaming {
		
		private tClientLN[] clientLNField;
		
		private uint maxField;
		
		public tRptEnabled() {
			this.maxField = ((uint)(1));
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ClientLN")]
		public tClientLN[] ClientLN {
			get {
				return this.clientLNField;
			}
			set {
				this.clientLNField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(typeof(uint), "1")]
		public uint max {
			get {
				return this.maxField;
			}
			set {
				this.maxField = value;
			}
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLN0))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLN))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tAnyLN : tUnNaming {
		
		private tDataSet[] dataSetField;
		
		private tReportControl[] reportControlField;
		
		private tLogControl[] logControlField;
		
		private tDOI[] dOIField;
		
		private tInputs inputsField;
		
		private string lnTypeField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("DataSet")]
		public tDataSet[] DataSet {
			get {
				return this.dataSetField;
			}
			set {
				this.dataSetField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ReportControl")]
		public tReportControl[] ReportControl {
			get {
				return this.reportControlField;
			}
			set {
				this.reportControlField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("LogControl")]
		public tLogControl[] LogControl {
			get {
				return this.logControlField;
			}
			set {
				this.logControlField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("DOI")]
		public tDOI[] DOI {
			get {
				return this.dOIField;
			}
			set {
				this.dOIField = value;
			}
		}
		
		/// <remarks/>
		public tInputs Inputs {
			get {
				return this.inputsField;
			}
			set {
				this.inputsField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string lnType {
			get {
				return this.lnTypeField;
			}
			set {
				this.lnTypeField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tDataSet : tNaming {
		
		private tFCDA[] fCDAField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("FCDA")]
		public tFCDA[] FCDA {
			get {
				return this.fCDAField;
			}
			set {
				this.fCDAField = value;
			}
		}
	}

	/// <remarks/>
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
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/
	public partial class tNaming : tBaseElement {
		
		private string nameField;
		
		private string descField;
		
		/// <remarks/>
		//[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string desc {
			get {
				return this.descField;
			}
			set {
				this.descField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]

	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tSDO : tNaming {
		
		private string typeField;
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
	}

	/// <summary>
	/// FIXME: The typeField must be  
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSubNetwork : tNaming {
		
		private tBitRateInMbPerSec bitRateField;
		
		private tConnectedAP[] connectedAPField;
		
		private string typeField;
		
		/// <remarks/>
		public tBitRateInMbPerSec BitRate {
			get {
				return this.bitRateField;
			}
			set {
				this.bitRateField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ConnectedAP")]
		public tConnectedAP[] ConnectedAP {
			get {
				return this.connectedAPField;
			}
			set {
				this.connectedAPField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]

	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed.1.0:
	 * unit -> unitField
	 * multiplier -> multiplierField
	*/		
	public partial class tBitRateInMbPerSec : tValueWithUnit {
		private tSIUnitEnum unitField;
		
		private tUnitMultiplierEnum multiplierField;
		
		public tBitRateInMbPerSec(){
			this.unitField = tSIUnitEnum.bs;
			this.multiplierField = tUnitMultiplierEnum.M;
		}
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tSIUnitEnum.bs)]
		public tSIUnitEnum unit {
			get {
				return this.unitField;
			}
			set {
				this.unitField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tUnitMultiplierEnum.M)]
		public tUnitMultiplierEnum multiplier {
			get {
				return this.multiplierField;
			}
			set {
				this.multiplierField = value;
			}
		}
	}

	/// <remarks/>
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
	public partial class tControl : tNaming {
		
		private string datSetField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string datSet {
			get {
				return this.datSetField;
			}
			set {
				this.datSetField = value;
			}
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSampledValueControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSEControl))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tControlWithIEDName : tControl {
		
		private string[] iEDNameField;
		
		private uint confRevField;
		
		private bool confRevFieldSpecified;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("IEDName", DataType="normalizedString")]
		public string[] IEDName {
			get {
				return this.iEDNameField;
			}
			set {
				this.iEDNameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint confRev {
			get {
				return this.confRevField;
			}
			set {
				this.confRevField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool confRevSpecified {
			get {
				return this.confRevFieldSpecified;
			}
			set {
				this.confRevFieldSpecified = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tSampledValueControl : tControlWithIEDName {
		
		private tSampledValueControlSmvOpts smvOptsField;
		
		private string smvIDField;
		
		private bool multicastField;
		
		private uint smpRateField;
		
		private uint nofASDUField;
		
		public tSampledValueControl() {
			this.multicastField = true;
		}
		
		/// <remarks/>		
		public tSampledValueControlSmvOpts SmvOpts {
			get {
				return this.smvOptsField;
			}
			set {
				this.smvOptsField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string smvID {
			get {
				return this.smvIDField;
			}
			set {
				this.smvIDField = value;
			}
		}
		
		/// <remarks/>		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(true)]
		public bool multicast {
			get {
				return this.multicastField;
			}
			set {
				this.multicastField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint smpRate {
			get {
				return this.smpRateField;
			}
			set {
				this.smpRateField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint nofASDU {
			get {
				return this.nofASDUField;
			}
			set {
				this.nofASDUField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSampledValueControlSmvOpts {
		
		private bool refreshTimeField;
		
		private bool sampleSynchronizedField;
		
		private bool sampleRateField;
		
		private bool securityField;
		
		private bool dataRefField;
		
		public tSampledValueControlSmvOpts() {
			this.refreshTimeField = false;
			this.sampleSynchronizedField = false;
			this.sampleRateField = false;
			this.securityField = false;
			this.dataRefField = false;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool refreshTime {
			get {
				return this.refreshTimeField;
			}
			set {
				this.refreshTimeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool sampleSynchronized {
			get {
				return this.sampleSynchronizedField;
			}
			set {
				this.sampleSynchronizedField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool sampleRate {
			get {
				return this.sampleRateField;
			}
			set {
				this.sampleRateField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool security {
			get {
				return this.securityField;
			}
			set {
				this.securityField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool dataRef {
			get {
				return this.dataRefField;
			}
			set {
				this.dataRefField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tGSEControl : tControlWithIEDName {
		
		private tGSEControlTypeEnum typeField;
		
		private string appIDField;
		
		public tGSEControl() {
			this.typeField = tGSEControlTypeEnum.GOOSE;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tGSEControlTypeEnum.GOOSE)]
		public tGSEControlTypeEnum type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string appID {
			get {
				return this.appIDField;
			}
			set {
				this.appIDField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tGSEControlTypeEnum {
		
		/// <remarks/>
		GSSE,
		
		/// <remarks/>
		GOOSE,
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLogControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tReportControl))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tControlWithTriggerOpt : tControl {
		
		private tTrgOps trgOpsField;
		
		private uint intgPdField;
		
		public tControlWithTriggerOpt() {
			this.intgPdField = ((uint)(0));
		}
		
		/// <remarks/>
		public tTrgOps TrgOps {
			get {
				return this.trgOpsField;
			}
			set {
				this.trgOpsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(typeof(uint), "0")]
		public uint intgPd {
			get {
				return this.intgPdField;
			}
			set {
				this.intgPdField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tLogControl : tControlWithTriggerOpt {
		
		private string logNameField;
		
		private bool logEnaField;
		
		private bool reasonCodeField;
		
		public tLogControl() {
			this.logEnaField = true;
			this.reasonCodeField = true;
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string logName {
			get {
				return this.logNameField;
			}
			set {
				this.logNameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(true)]
		public bool logEna {
			get {
				return this.logEnaField;
			}
			set {
				this.logEnaField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(true)]
		public bool reasonCode {
			get {
				return this.reasonCodeField;
			}
			set {
				this.reasonCodeField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tReportControl : tControlWithTriggerOpt {
		
		private tReportControlOptFields optFieldsField;
		
		private tRptEnabled rptEnabledField;
		
		private string rptIDField;
		
		private uint confRevField;
		
		private bool bufferedField;
		
		private uint bufTimeField;
		
		public tReportControl() {
			this.bufferedField = false;
			this.bufTimeField = ((uint)(0));
		}
		
		/// <remarks/>
		public tReportControlOptFields OptFields {
			get {
				return this.optFieldsField;
			}
			set {
				this.optFieldsField = value;
			}
		}
		
		/// <remarks/>		
		public tRptEnabled RptEnabled {
			get {
				return this.rptEnabledField;
			}
			set {
				this.rptEnabledField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string rptID {
			get {
				return this.rptIDField;
			}
			set {
				this.rptIDField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint confRev {
			get {
				return this.confRevField;
			}
			set {
				this.confRevField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool buffered {
			get {
				return this.bufferedField;
			}
			set {
				this.bufferedField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(typeof(uint), "0")]
		public uint bufTime {
			get {
				return this.bufTimeField;
			}
			set {
				this.bufTimeField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tReportControlOptFields {
		
		private bool seqNumField;
		
		private bool timeStampField;
		
		private bool dataSetField;
		
		private bool reasonCodeField;
		
		private bool dataRefField;
		
		private bool entryIDField;
		
		private bool configRefField;
		
		public tReportControlOptFields() {
			this.seqNumField = false;
			this.timeStampField = false;
			this.dataSetField = false;
			this.reasonCodeField = false;
			this.dataRefField = false;
			this.entryIDField = false;
			this.configRefField = false;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool seqNum {
			get {
				return this.seqNumField;
			}
			set {
				this.seqNumField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool timeStamp {
			get {
				return this.timeStampField;
			}
			set {
				this.timeStampField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool dataSet {
			get {
				return this.dataSetField;
			}
			set {
				this.dataSetField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool reasonCode {
			get {
				return this.reasonCodeField;
			}
			set {
				this.reasonCodeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool dataRef {
			get {
				return this.dataRefField;
			}
			set {
				this.dataRefField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool entryID {
			get {
				return this.entryIDField;
			}
			set {
				this.entryIDField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool configRef {
			get {
				return this.configRefField;
			}
			set {
				this.configRefField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tAccessPoint : tNaming {
		
		private tUnNaming[] itemsField;
		
		private bool routerField;
		
		private bool clockField;
		
		public tAccessPoint() {
			this.routerField = false;
			this.clockField = false;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("LN", typeof(tLN))]
		[System.Xml.Serialization.XmlElementAttribute("Server", typeof(tServer))]
		public tUnNaming[] Items {
			get {
				return this.itemsField;
			}
			set {
				this.itemsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool router {
			get {
				return this.routerField;
			}
			set {
				this.routerField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool clock {
			get {
				return this.clockField;
			}
			set {
				this.clockField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute("LN", Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tLN : tAnyLN {
		
		private string lnClassField;
		
		private uint instField;
		
		private string prefixField;
		
		public tLN() {
			this.prefixField = "";
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string lnClass {
			get {
				return this.lnClassField;
			}
			set {
				this.lnClassField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public uint inst {
			get {
				return this.instField;
			}
			set {
				this.instField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[System.ComponentModel.DefaultValueAttribute("")]
		public string prefix {
			get {
				return this.prefixField;
			}
			set {
				this.prefixField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServer : tUnNaming {
		
		private tServerAuthentication authenticationField;
		
		private tLDevice[] lDeviceField;
		
		private tAssociation[] associationField;
		
		private uint timeoutField;
		
		public tServer() {
			this.timeoutField = ((uint)(30));
		}
		
		/// <remarks/>
		public tServerAuthentication Authentication {
			get {
				return this.authenticationField;
			}
			set {
				this.authenticationField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("LDevice")]
		public tLDevice[] LDevice {
			get {
				return this.lDeviceField;
			}
			set {
				this.lDeviceField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Association")]
		public tAssociation[] Association {
			get {
				return this.associationField;
			}
			set {
				this.associationField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(typeof(uint), "30")]
		public uint timeout {
			get {
				return this.timeoutField;
			}
			set {
				this.timeoutField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tServerAuthentication {
		
		private bool noneField;
		
		private bool passwordField;
		
		private bool weakField;
		
		private bool strongField;
		
		private bool certificateField;
		
		public tServerAuthentication() {
			this.noneField = true;
			this.passwordField = false;
			this.weakField = false;
			this.strongField = false;
			this.certificateField = false;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(true)]
		public bool none {
			get {
				return this.noneField;
			}
			set {
				this.noneField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool password {
			get {
				return this.passwordField;
			}
			set {
				this.passwordField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool weak {
			get {
				return this.weakField;
			}
			set {
				this.weakField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool strong {
			get {
				return this.strongField;
			}
			set {
				this.strongField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool certificate {
			get {
				return this.certificateField;
			}
			set {
				this.certificateField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tLDevice : tUnNaming {
		
		private LN0 lN0Field;
		
		private tLN[] lnField;
		
		private tAccessControl accessControlField;
		
		private string instField;
		
		private string ldNameField;
		
		/// <remarks/>
		public LN0 LN0 {
			get {
				return this.lN0Field;
			}
			set {
				this.lN0Field = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("LN")]
		public tLN[] LN {
			get {
				return this.lnField;
			}
			set {
				this.lnField = value;
			}
		}
		
		/// <remarks/>
		public tAccessControl AccessControl {
			get {
				return this.accessControlField;
			}
			set {
				this.accessControlField = value;
			}
		}
		
		/// <remarks/>		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string inst {
			get {
				return this.instField;
			}
			set {
				this.instField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="Name")]
		public string ldName {
			get {
				return this.ldNameField;
			}
			set {
				this.ldNameField = value;
			}
		}
	}

	/// <remarks/>	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	public partial class LN0 : tLN0 {
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	public partial class tLN0 : tAnyLN {
		
		private tGSEControl[] gSEControlField;
		
		private tSampledValueControl[] sampledValueControlField;
		
		private tSettingControl settingControlField;
		
		private tSCLControl sCLControlField;
		
		private tLog logField;
		
		private string lnClassField;
		
		private string instField;
		
		public tLN0() {
			this.lnClassField = "LLN0";
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("GSEControl")]
		public tGSEControl[] GSEControl {
			get {
				return this.gSEControlField;
			}
			set {
				this.gSEControlField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("SampledValueControl")]
		public tSampledValueControl[] SampledValueControl {
			get {
				return this.sampledValueControlField;
			}
			set {
				this.sampledValueControlField = value;
			}
		}
		
		/// <remarks/>
		public tSettingControl SettingControl {
			get {
				return this.settingControlField;
			}
			set {
				this.settingControlField = value;
			}
		}
		
		/// <remarks/>
		public tSCLControl SCLControl {
			get {
				return this.sCLControlField;
			}
			set {
				this.sCLControlField = value;
			}
		}
		
		/// <remarks/>
		public tLog Log {
			get {
				return this.logField;
			}
			set {
				this.logField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string lnClass {
			get {
				return this.lnClassField;
			}
			set {
				this.lnClassField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string inst {
			get {
				return this.instField;
			}
			set {
				this.instField = value;
			}
		}
	}

	/// <remarks/>
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
	public partial class tLNodeContainer : tNaming {
		
		private tLNode[] lNodeField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("LNode")]
		public tLNode[] LNode {
			get {
				return this.lNodeField;
			}
			set {
				this.lNodeField = value;
			}
		}
	}
	
	///<remarks/>	
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tLPHDEnum" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public enum tLPHDEnum{
		LPHD,		
	}
	
	///<remarks/>	
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tLLN0Enum" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public enum tLLN0Enum{
		LLN0,		
	}
			
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tDomainLNGroup AEnum" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public enum tDomainLNGroupAEnum{
		ANCR,		
		ARCO,
		ATCC,
		AVCO,
	}
		
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tDomainLNGroupCEnum" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public enum tDomainLNGroupCEnum {
		CILO,
		CSWI,
		CALH,
		CCGR,
		CPOW,
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tDomainLNGroupGEnum" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public enum tDomainLNGroupGEnum {
		GAPC,
		GGIO,
		GSAL,
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tDomainLNGroupIEnum" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public enum tDomainLNGroupIEnum {
		IHMI,
		IARC,
		ITCI,
		ITMI,
	}
	
	///<remarks/>
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tDomainLNGroupMEnum" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public enum tDomainLNGroupMEnum {
		MMXU,
		MDIF,
		MHAI,
		MHAN,
		MMTR,
		MMXN,
		MSQI,
		MSTA,
	}
	
	
	///<remarks/>	
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tDomainLNGroupPEnum" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public enum tDomainLNGroupPEnum {
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
		PZSU,
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tDomainLNGroupREnum" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public enum tDomainLNGroupREnum {
		RSYN,
		RDRE,
		RADR,
		RBDR,
		RDRS,
		RBRF,
		RDIR,
		RFLO,
		RPSB,
		RREC,
	}
	
		
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tDomainLNGroupSEnum" was added to fulfill standard IEC 61850 Ed.1.0
	 */
	public enum tDomainLNGroupSEnum {
		SARC,
		SIMG,
		SIML,
		SPDC,
	}
	
		
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tDomainLNGroupTEnum" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public enum tDomainLNGroupTEnum {
		TCTR,
		TVTR,
	}
	
		
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tDomainLNGroupXEnum" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public enum tDomainLNGroupXEnum {
		XCBR,
		XSWI,
	}
	
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tDomainLNGroupYEnum" was added to fulfill standard IEC 61850 Ed.1.0
	*/	
	public enum tDomainLNGroupYEnum {
	YPTR,
		YEFN,
		YLTC,
		YPSH,	
	}
	
	///<remarks/>	
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tDomainLNGroupZEnum" was added to fulfill standard IEC 61850 Ed.1.0
	*/
	public enum tDomainLNGroupZEnum {
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
		ZTCR,
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tDomainLNEnum" was added to fulfill standard IEC 61850 Ed.1.0.
	 * This is composed by following Enums: tDomainLNGroupAEnum, tDomainLNGroupCEnum, 
	 * tDomainLNGroupGEnum, tDomainLNGroupIEnum, tDomainLNGroupMEnum, tDomainLNGroupPEnum, 
	 * tDomainLNGroupREnum, tDomainLNGroupSEnum, tDomainLNGroupTEnum, tDomainLNGroupXEnum,
	 * tDomainLNGroupYEnum, tDomainLNGroupZEnum
	*/	
	public enum tDomainLNEnum {
		//A
		ANCR,ARCO,ATCC,AVCO,
		//C
		CILO, CSWI,CALH,CCGR,CPOW,
		//G
		GAPC,GGIO,GSAL,
		//I
		IHMI,IARC,ITCI,ITMI,
		//M
		MMXU,MDIF,MHAI,MHAN,MMTR,MMXN,MSQI,MSTA,		
		//P
		PDIF,PDIS,PDIR,PDOP,PDUP,PFRC,PHAR,PHIZ,PIOC,PMRI,PMSS,POPF,PPAM,PSCH,PSDE,PTEF,PTOC,PTOF,PTOV,PTRC,PTTR,PTUC,PTUV,PUPF,PTUF,PVOC,PVPH,PZSU,
		//R
		RSYN,RDRE,RADR,RBDR,RDRS,RBRF,RDIR,RFLO,RPSB,RREC,
		//S
		SARC,SIMG,SIML,SPDC,
		//T
		TCTR,TVTR,
		//X
		XCBR,XSWI,
		//Y
		YPTR,YEFN,YLTC,YPSH,
		//Z
		ZAXN,ZBAT,ZBSH,ZCAB,ZCAP,ZCON,ZGEN,ZGIL,ZLIN,ZMOT,ZREA,ZRRC,ZSAR,ZTCF,ZTCR,
	}
	
	
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/*
	 * The enumeration "tPredefinedLNClassEnum" was added to fulfill standard IEC 61850 Ed.1.0.
	 * This is composed by following Enums: tLPHDEnum, tLLN0Enum y tDomainLNEnum
	 * (que incluyen a tDomainLNGroupAEnum, tDomainLNGroupCEnum, tDomainLNGroupGEnum, 
	 * tDomainLNGroupIEnum, tDomainLNGroupMEnum, tDomainLNGroupPEnum, 
	 * tDomainLNGroupREnum, tDomainLNGroupSEnum, tDomainLNGroupTEnum, 
	 * tDomainLNGroupXEnum, tDomainLNGroupYEnum, tDomainLNGroupZEnum)
	*/
	public enum tPredefinedLNClassEnum {
		//tLPHDEnum
		LPHD,		
		//tLLN0Enum
		LLN0,
		//A
		ANCR,ARCO,ATCC,AVCO,
		//C
		CILO, CSWI,CALH,CCGR,CPOW,
		//G
		GAPC,GGIO,GSAL,
		//I
		IHMI,IARC,ITCI,ITMI,
		//M
		MMXU,MDIF,MHAI,MHAN,MMTR,MMXN,MSQI,MSTA,		
		//P
		PDIF,PDIS,PDIR,PDOP,PDUP,PFRC,PHAR,PHIZ,PIOC,PMRI,PMSS,POPF,PPAM,PSCH,PSDE,PTEF,PTOC,PTOF,PTOV,PTRC,PTTR,PTUC,PTUV,PUPF,PTUF,PVOC,PVPH,PZSU,
		//R
		RSYN,RDRE,RADR,RBDR,RDRS,RBRF,RDIR,RFLO,RPSB,RREC,
		//S
		SARC,SIMG,SIML,SPDC,
		//T
		TCTR,TVTR,
		//X
		XCBR,XSWI,
		//Y
		YPTR,YEFN,YLTC,YPSH,
		//Z
		ZAXN,ZBAT,ZBSH,ZCAB,ZCAP,ZCON,ZGEN,ZGIL,ZLIN,ZMOT,ZREA,ZRRC,ZSAR,ZTCF,ZTCR,
	}
	
	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The value's atttribute "string lnClassField to tPredefinedLNClassEnum lnClassField"
	 * was added to fulfill standard IEC 61850 Ed.1.0
	*/	
	public partial class tLNode : tUnNaming {
		
		private string lnInstField;
		
		private tPredefinedLNClassEnum lnClassField;
		
		private string iedNameField;
		
		private string ldInstField;
		
		private string prefixField;
		
		private string lnTypeField;
		
		public tLNode() {
			this.lnInstField = "";
			this.iedNameField = "None";
			this.ldInstField = "";
			this.prefixField = "";			
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[System.ComponentModel.DefaultValueAttribute("")]
		public string lnInst {
			get {
				return this.lnInstField;
			}
			set {
				this.lnInstField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public tPredefinedLNClassEnum lnClass {
			get {
				return this.lnClassField;
			}
			set {
				this.lnClassField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[System.ComponentModel.DefaultValueAttribute("None")]
		public string iedName {
			get {
				return this.iedNameField;
			}
			set {
				this.iedNameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[System.ComponentModel.DefaultValueAttribute("")]
		public string ldInst {
			get {
				return this.ldInstField;
			}
			set {
				this.ldInstField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[System.ComponentModel.DefaultValueAttribute("")]
		public string prefix {
			get {
				return this.prefixField;
			}
			set {
				this.prefixField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string lnType {
			get {
				return this.lnTypeField;
			}
			set {
				this.lnTypeField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	public partial class tConnectivityNode : tLNodeContainer {
		
		private string pathNameField;
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string pathName {
			get {
				return this.pathNameField;
			}
			set {
				this.pathNameField = value;
			}
		}
	}

	/// <remarks/>
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
	public partial class tPowerSystemResource : tLNodeContainer {
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSubFunction : tPowerSystemResource {
		
		private tGeneralEquipment[] generalEquipmentField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("GeneralEquipment")]
		public tGeneralEquipment[] GeneralEquipment {
			get {
				return this.generalEquipmentField;
			}
			set {
				this.generalEquipmentField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	public partial class tGeneralEquipment : tEquipment {
		
		private string typeField;
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
	}

	/// <remarks/>
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
	public partial class tEquipment : tPowerSystemResource {
		
		private bool virtualField;
		
		public tEquipment() {
			this.virtualField = false;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool @virtual {
			get {
				return this.virtualField;
			}
			set {
				this.virtualField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	public partial class tPowerTransformer : tEquipment {
		
		private tTransformerWinding[] transformerWindingField;
		
		private tPowerTransformerEnum typeField;
		
		public tPowerTransformer() {
			this.typeField = tPowerTransformerEnum.PTR;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("TransformerWinding")]
		public tTransformerWinding[] TransformerWinding {
			get {
				return this.transformerWindingField;
			}
			set {
				this.transformerWindingField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public tPowerTransformerEnum type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	public partial class tTransformerWinding : tAbstractConductingEquipment {
		
		private tTapChanger tapChangerField;
		
		private tTransformerWindingEnum typeField;
		
		public tTransformerWinding() {
			this.typeField = tTransformerWindingEnum.PTW;
		}
		
		/// <remarks/>
		public tTapChanger TapChanger {
			get {
				return this.tapChangerField;
			}
			set {
				this.tapChangerField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public tTransformerWindingEnum type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	public partial class tTapChanger : tPowerSystemResource {
		
		private string typeField;
		
		private bool virtualField;
		
		public tTapChanger() {
			this.typeField = "LTC";
			this.virtualField = false;
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="Name")]
		public string type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool @virtual {
			get {
				return this.virtualField;
			}
			set {
				this.virtualField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tTransformerWindingEnum {
		
		/// <remarks/>
		PTW,
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTransformerWinding))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConductingEquipment))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tAbstractConductingEquipment : tEquipment {
		
		private tTerminal[] terminalField;
		
		private tSubEquipment[] subEquipmentField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Terminal")]
		public tTerminal[] Terminal {
			get {
				return this.terminalField;
			}
			set {
				this.terminalField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("SubEquipment")]
		public tSubEquipment[] SubEquipment {
			get {
				return this.subEquipmentField;
			}
			set {
				this.subEquipmentField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	public partial class tTerminal : tUnNaming {
		
		private string nameField;
		
		private string connectivityNodeField;
		
		private string substationNameField;
		
		private string voltageLevelNameField;
		
		private string bayNameField;
		
		private string cNodeNameField;
		
		public tTerminal() {
			this.nameField = "";
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[System.ComponentModel.DefaultValueAttribute("")]
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string connectivityNode {
			get {
				return this.connectivityNodeField;
			}
			set {
				this.connectivityNodeField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string substationName {
			get {
				return this.substationNameField;
			}
			set {
				this.substationNameField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string voltageLevelName {
			get {
				return this.voltageLevelNameField;
			}
			set {
				this.voltageLevelNameField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string bayName {
			get {
				return this.bayNameField;
			}
			set {
				this.bayNameField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string cNodeName {
			get {
				return this.cNodeNameField;
			}
			set {
				this.cNodeNameField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tSubEquipment : tPowerSystemResource {
		
		private tPhaseEnum phaseField;
		
		private bool virtualField;
		
		public tSubEquipment() {
			this.phaseField = tPhaseEnum.none;
			this.virtualField = false;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tPhaseEnum.none)]
		public tPhaseEnum phase {
			get {
				return this.phaseField;
			}
			set {
				this.phaseField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool @virtual {
			get {
				return this.virtualField;
			}
			set {
				this.virtualField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tPhaseEnum {
		
		/// <remarks/>
		A,
		
		/// <remarks/>
		B,
		
		/// <remarks/>
		C,
		
		/// <remarks/>
		N,
		
		/// <remarks/>
		all,
		
		/// <remarks/>
		none,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	public partial class tConductingEquipment : tAbstractConductingEquipment {
		
		private string typeField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Required]
		public string type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tPowerTransformerEnum {
		
		/// <remarks/>
		PTR,
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tFunction : tPowerSystemResource {
		
		private tSubFunction[] subFunctionField;
		
		private tGeneralEquipment[] generalEquipmentField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("SubFunction")]
		public tSubFunction[] SubFunction {
			get {
				return this.subFunctionField;
			}
			set {
				this.subFunctionField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("GeneralEquipment")]
		public tGeneralEquipment[] GeneralEquipment {
			get {
				return this.generalEquipmentField;
			}
			set {
				this.generalEquipmentField = value;
			}
		}
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBay))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tVoltageLevel))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubstation))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tEquipmentContainer : tPowerSystemResource {
		
		private tPowerTransformer[] powerTransformerField;
		
		private tGeneralEquipment[] generalEquipmentField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("PowerTransformer")]
		public tPowerTransformer[] PowerTransformer {
			get {
				return this.powerTransformerField;
			}
			set {
				this.powerTransformerField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("GeneralEquipment")]
		public tGeneralEquipment[] GeneralEquipment {
			get {
				return this.generalEquipmentField;
			}
			set {
				this.generalEquipmentField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tBay : tEquipmentContainer {
		
		private tConductingEquipment[] conductingEquipmentField;
		
		private tConnectivityNode[] connectivityNodeField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ConductingEquipment")]
		public tConductingEquipment[] ConductingEquipment {
			get {
				return this.conductingEquipmentField;
			}
			set {
				this.conductingEquipmentField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ConnectivityNode")]
		public tConnectivityNode[] ConnectivityNode {
			get {
				return this.connectivityNodeField;
			}
			set {
				this.connectivityNodeField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	public partial class tDA : tAbstractDataAttribute {
		
		private bool dchgField;
		
		private bool qchgField;
		
		private bool dupdField;
		
		private tFCEnum fcField;
		
		public tDA() {
			this.dchgField = false;
			this.qchgField = false;
			this.dupdField = false;
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool dchg {
			get {
				return this.dchgField;
			}
			set {
				this.dchgField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool qchg {
			get {
				return this.qchgField;
			}
			set {
				this.qchgField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(false)]
		public bool dupd {
			get {
				return this.dupdField;
			}
			set {
				this.dupdField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public tFCEnum fc {
			get {
				return this.fcField;
			}
			set {
				this.fcField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	public partial class tDOType : tIDNaming {
		
		private tBaseElement[] itemsField;
		
		private string iedTypeField;
		
		private string cdcField;
		
		public tDOType() {
			this.iedTypeField = "";
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("DA", typeof(tDA))]
		[System.Xml.Serialization.XmlElementAttribute("SDO", typeof(tSDO))]
		public tBaseElement[] Items {
			get {
				return this.itemsField;
			}
			set {
				this.itemsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[System.ComponentModel.DefaultValueAttribute("")]
		public string iedType {
			get {
				return this.iedTypeField;
			}
			set {
				this.iedTypeField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string cdc {
			get {
				return this.cdcField;
			}
			set {
				this.cdcField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/		
	public partial class tLNodeType : tIDNaming {
		
		private tDO[] doField;
		
		private string iedTypeField;
		
		private string lnClassField;
		
		public tLNodeType() {
			this.iedTypeField = "";
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("DO")]
		public tDO[] DO {
			get {
				return this.doField;
			}
			set {
				this.doField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[System.ComponentModel.DefaultValueAttribute("")]
		public string iedType {
			get {
				return this.iedTypeField;
			}
			set {
				this.iedTypeField = value;
			}
		}
		
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string lnClass {
			get {
				return this.lnClassField;
			}
			set {
				this.lnClassField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
		
	/* 
	 * According to IEC 61850 Ed.1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	 * 
	 * The following attributes were added to fulfill standard IEC 61850 Ed.1.0:
	 * unit -> unitField
	 * multiplier -> multiplierField
	*/		
	public partial class tDurationInSec : tValueWithUnit {
			private tSIUnitEnum unitField;
		
			private tUnitMultiplierEnum multiplierField;
		
		public tDurationInSec(){
			this.unitField = tSIUnitEnum.s;
			this.multiplierField = tUnitMultiplierEnum.Item;
		}
		/// <remarks/>
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tSIUnitEnum.s)]
		public tSIUnitEnum unit {
			get {
				return this.unitField;
			}
			set {
				this.unitField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[System.ComponentModel.DefaultValueAttribute(tUnitMultiplierEnum.Item)]
		public tUnitMultiplierEnum multiplier {
			get {
				return this.multiplierField;
			}
			set {
				this.multiplierField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute("IED", Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	public partial class tIED : tNaming {
		
		private tServices servicesField;
		
		private tAccessPoint[] accessPointField;
		
		private string typeField;
		
		private string manufacturerField;
		
		private string configVersionField;
		
		/// <remarks/>
		public tServices Services {
			get {
				return this.servicesField;
			}
			set {
				this.servicesField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("AccessPoint")]
		public tAccessPoint[] AccessPoint {
			get {
				return this.accessPointField;
			}
			set {
				this.accessPointField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string manufacturer {
			get {
				return this.manufacturerField;
			}
			set {
				this.manufacturerField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		public string configVersion {
			get {
				return this.configVersionField;
			}
			set {
				this.configVersionField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute("Communication", Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	public partial class tCommunication : tUnNaming {
		
		private tSubNetwork[] subNetworkField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("SubNetwork")]
		public tSubNetwork[] SubNetwork {
			get {
				return this.subNetworkField;
			}
			set {
				this.subNetworkField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute("DataTypeTemplates", Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	public partial class tDataTypeTemplates {
		
		private tLNodeType[] lNodeTypeField;
		
		private tDOType[] dOTypeField;
		
		private tDAType[] dATypeField;
		
		private tEnumType[] enumTypeField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("LNodeType")]
		public tLNodeType[] LNodeType {
			get {
				return this.lNodeTypeField;
			}
			set {
				this.lNodeTypeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("DOType")]
		public tDOType[] DOType {
			get {
				return this.dOTypeField;
			}
			set {
				this.dOTypeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("DAType")]
		public tDAType[] DAType {
			get {
				return this.dATypeField;
			}
			set {
				this.dATypeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("EnumType")]
		public tEnumType[] EnumType {
			get {
				return this.enumTypeField;
			}
			set {
				this.enumTypeField = value;
			}
		}
	}

	/// <remarks/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	public partial class SCL : tBaseElement {
		
		private tHeader headerField;
		
		private tSubstation[] substationField;
		
		private tCommunication communicationField;
		
		private tIED[] iEDField;
		
		private tDataTypeTemplates dataTypeTemplatesField;
		
		/// <remarks/>
		public tHeader Header {
			get {
				return this.headerField;
			}
			set {
				this.headerField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Substation")]
		public tSubstation[] Substation {
			get {
				return this.substationField;
			}
			set {
				this.substationField = value;
			}
		}
		
		/// <remarks/>
		public tCommunication Communication {
			get {
				return this.communicationField;
			}
			set {
				this.communicationField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("IED")]
		public tIED[] IED {
			get {
				return this.iEDField;
			}
			set {
				this.iEDField = value;
			}
		}
		
		/// <remarks/>
		public tDataTypeTemplates DataTypeTemplates {
			get {
				return this.dataTypeTemplatesField;
			}
			set {
				this.dataTypeTemplatesField = value;
			}
		}
	}
}
