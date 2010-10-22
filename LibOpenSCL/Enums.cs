// 
//  Enums.cs
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
	
	
	// Helper enum
	public enum tStatusEnum {
		Valid,
		Invalid,
		Unknown
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
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tAssociationKindEnum 
	{		
		[System.Xml.Serialization.XmlEnumAttribute("pre-established")]
		preestablished,
		
		predefined,
	}
	
	
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tHeaderNameStructure 
	{		
		IEDName,
		FuncName
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

	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	[Category("GSEControl"), Description("GSE Type")]
	public enum tGSEControlTypeEnum 
	{		
		GSSE,
		GOOSE,
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


	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tTransformerWindingEnum 
	{		
		PTW
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
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public enum tPowerTransformerEnum 
	{
		PTR
	}
}

