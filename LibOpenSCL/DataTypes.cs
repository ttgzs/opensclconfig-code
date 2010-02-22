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
using System.ComponentModel;
using OpenSCL;

namespace IEC61850.SCL
{		
	/// <summary>
	/// This data type structure is could be used by a personalized or composed DAData class. 
	/// </summary>
	public class DADataType : tDA
	{
		public bool CheckSelection = false;
		public bool Visible = true;
		public string id;
		public string iedType;
		public tEnumVal[] EnumVal;		 
		private tVal val;
		
		public DADataType()
		{
			this.Val = new tVal[1];			
		}
		
		[Category("DA"), Description("Value of attribute.")]
		public string Value
		{
			get
			{
				if(this.Val[0]==null)
				{
					return null;
				}
				else
				{
					return this.Val[0].Value;
				}				
			}
			set
			{
				val = new tVal();
				this.Val[0] = val;
				this.Val[0].Value = value;
			}
		}
	}
	
	/// <summary>
	/// This data type structure is could be used by a personalized or composed SDI class. 
	/// </summary>
	public class SDIDADataTypeBDA : tDA
	{
		public bool CheckSelection = false;
		public bool Visible = true;
		public string id;
		public string iedType;
		public tEnumVal[] EnumVal;
		private tVal val;
		
		public SDIDADataTypeBDA()
		{
			this.Val = new tVal[1];	
		}
		
		[Category("DA"), Description("Value of attribute.")]
		public string Value
		{
			get
			{
				if(this.Val[0]==null)
				{
					return null;
				}
				else
				{
					return this.Val[0].Value;
				}				
			}
			set
			{
				val = new tVal();
				this.Val[0] = val;
				this.Val[0].Value = value;
			}
		}
	}
	
	/// <summary>
	/// This data type structure is could be used by a personalized or composed SDO class. 
	/// </summary>
	public class SDOSDIDOTypeDA : tDA
	{
		public bool CheckSelection = false;	
		public bool Visible = true;
		public string id;
		public string iedType;
		public string cdc;
	}	
				
	/// <summary>
	/// The parameter T (Transient_Data) shall be the time when the client sends the control request.
	/// </summary>
	public class Transient_Data : SDIDADataTypeBDA
	{
		private BOOLEAN testField;
		
		public Transient_Data(string iedType, string lnType)
		{
			this.name = "Transient_Data";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"Transient_Data";
			this.iedType = iedType;			
			this.testField = new BOOLEAN("test");
			(this.testField as DADataType).CheckSelection = true;			
		}	
		
		public BOOLEAN test
		{
			get
			{
				return this.testField;
			}
			set
			{
				this.testField = value;
			}
		}	
	}
			
	/// <summary>
	/// The parameter Check shall specify the kind of checks a control object shall perform 
	/// before issuing the control operation if common DATA class is DPC.
	/// </summary>
	public class Check : SDIDADataTypeBDA
	{
		private BOOLEAN synchrocheckField;
		private BOOLEAN interlockcheckField;	
		
		public Check(string iedType, string lnType)
		{
			this.name = "Check";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"Check";
			this.iedType = iedType;			
			this.synchrocheckField = new BOOLEAN("synchrocheck");
			this.interlockcheckField = new BOOLEAN("interlockcheck");
		}
		
		public BOOLEAN synchrocheck
		{
			get
			{
				return this.synchrocheckField;
			}
			set
			{
				this.synchrocheckField = value;
			}
		}
		
		public BOOLEAN interlockcheck
		{
			get
			{
				return this.interlockcheckField;
			}
			set
			{
				this.interlockcheckField = value;
			}
		}
	}
			
	/// <summary>
	/// Source shall give information related to the origin of a value. The value may be acquired 
	/// from the process or be a substituted value.
	/// </summary>
	public enum sourceEnum
	{
		process,
		substituted
	}
		
	/// <summary>
	/// Analogue values may be represented as a basic data type INTEGER (attribute i) or as FLOATING
	/// POINT (attribute f)
	/// </summary>
	public class AnalogueValue : SDIDADataTypeBDA
	{
		private INT32 iField;
		private FLOAT32 fField;		
		
		public AnalogueValue(string iedType, string lnType)
		{
			this.name = "AnalogueValue";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"AnalogueValue";
			this.iedType = iedType;			
			this.iField = new INT32("i");
			this.fField = new FLOAT32("f");
		}
		
		public INT32 i
		{
			get
			{
				return this.iField;
			}
			set
			{
				this.iField = value;
			}
		}
		
		public FLOAT32 f
		{
			get
			{
				return this.fField;
			}
			set
			{
				this.fField = value;
			}
		}		
	}
		
	/// <summary>
	/// Configuration of analogue value type.
	/// </summary>
	public class ScaledValueConfig : SDIDADataTypeBDA
	{
		private FLOAT32 scaleFactorField;
		private FLOAT32 offsetField;
		
		public ScaledValueConfig(string iedType, string lnType)
		{
			this.name = "ScaledValueConfig";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"ScaledValueConfig";
			this.iedType = iedType;
			this.scaleFactorField = new FLOAT32("scaleFactor");
			this.offsetField = new FLOAT32("offset");
		}
		
		[Required]
		public FLOAT32 scaleFactor
		{
			get
			{
				return this.scaleFactorField;
			}
			set
			{
				this.scaleFactorField = value;
			}
		}
		
		[Required]
		public FLOAT32 offset
		{
			get
			{
				return this.offsetField;
			}
			set
			{
				this.offsetField = value;
			}
		}
	}
	
	/// <summary>
	/// These attributes shall be the configuration parameters used in the context with the range 
	/// attribute.
	/// </summary>
	public class hhLim : SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
		
		public hhLim(string iedType, string lnType)
		{
			this.name = "hhLim";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"hhLim";
			this.iedType = iedType;
			this.AnalogueValueField = new AnalogueValue(iedType, this.id);
			this.AnalogueValueField.CheckSelection = true;			
		}
		
		public AnalogueValue AnalogueValue
		{
			get
			{
				return this.AnalogueValueField;
			}
			set
			{
				this.AnalogueValueField = value;
			}
		}
	}

	/// <summary>
	/// These attributes shall be the configuration parameters used in the context with the range 
	/// attribute.
	/// </summary>
	public class hLim : SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
	
		public hLim(string iedType, string lnType)
		{
			this.name = "hLim";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"hLim";
			this.iedType = iedType;
			this.AnalogueValueField = new AnalogueValue(iedType, this.id);
			this.AnalogueValueField.CheckSelection = true;			
		}
		
		public AnalogueValue AnalogueValue
		{
			get
			{
				return this.AnalogueValueField;
			}
			set
			{
				this.AnalogueValueField = value;
			}
		}
	}
	
	/// <summary>
	/// These attributes shall be the configuration parameters used in the context with the range 
	/// attribute.
	/// </summary>
	public class lLim : SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
	
		public lLim(string iedType, string lnType)
		{
			this.name = "lLim";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"lLim";
			this.iedType = iedType;
			this.AnalogueValueField = new AnalogueValue(iedType, this.id);
			this.AnalogueValueField.CheckSelection = true;			
		}
		
		public AnalogueValue AnalogueValue
		{
			get
			{
				return this.AnalogueValueField;
			}
			set
			{
				this.AnalogueValueField = value;
			}
		}
	}
	
	/// <summary>
	/// These attributes shall be the configuration parameters used in the context with the range 
	/// attribute.
	/// </summary>
	public class llLim : SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
	
		public llLim(string iedType, string lnType)
		{
			this.name = "llLim";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"llLim";
			this.iedType = iedType;
			this.AnalogueValueField = new AnalogueValue(iedType, this.id);
			this.AnalogueValueField.CheckSelection = true;			
		}
		
		public AnalogueValue AnalogueValue
		{
			get
			{
				return this.AnalogueValueField;
			}
			set
			{
				this.AnalogueValueField = value;
			}
		}
	}

	/// <summary>
	/// Range configuration type is used to configure the limits that define the range of a 
	/// measured value.
	/// </summary>
	public class RangeConfig : SDIDADataTypeBDA
	{
		private hhLim hhLimField;
		private hLim hLimField;
		private lLim lLimField;
		private min minField;
		private max maxField;
		private llLim llLimField;
		
		public RangeConfig(string iedType, string lnType)
		{
			this.name = "RangeConfig";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"RangeConfig";
			this.iedType = iedType;			
			this.hhLimField = new hhLim(iedType, this.id);
			this.hLimField = new hLim(iedType, this.id);
			this.lLimField = new lLim(iedType, this.id);
			this.minField = new min(iedType, this.id);
			this.maxField = new max(iedType, this.id);
			this.llLimField = new llLim(iedType, this.id);				 
		}
		
		[Required]
		public hhLim hhLim
		{
			get
			{
				return this.hhLimField;
			}
			set
			{
				this.hhLimField = value;
			}
		}
		
		[Required]
		public hLim hLim 
		{
			get
			{
				return this.hLimField;
			}
			set
			{
				this.hLimField = value;
			}
		}
		
		[Required]
		public lLim lLim 
		{
			get
			{
				return this.lLimField;
			}
			set
			{
				this.lLimField = value;
			}
		}
		
		[Required]
		public llLim llLim
		{
			get
			{
				return this.llLimField;
			}
			set
			{
				this.llLimField = value;
			}
		}
	
		[Required]
		public min min
		{
			get
			{
				return this.minField;
			}
			set
			{
				this.minField = value;
			}
		}
		
		[Required]
		public max max
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
	
	/// <summary>
	/// Step position with transient indication type is for example used to indicate the position 
	/// of tap changers.
	/// </summary>
	public class ValWithTrans : SDIDADataTypeBDA
	{
		private INT8 posValField;
		private BOOLEAN transIndField;
		
		public ValWithTrans(string iedType, string lnType)
		{
			this.name = "ValWithTrans";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"ValWithTrans";
			this.iedType = iedType;			
			this.posValField = new INT8("posVal");
			this.transIndField = new BOOLEAN("transInd");
		}

		[Required]
		public INT8 posVal
		{
			get
			{
				return this.posValField;
			}
			set
			{
				this.posValField = value;
			}
		}
	
		public BOOLEAN transInd
		{
			get
			{
				return this.transIndField;
			}
			set
			{
				this.transIndField = value;
			}
		}
	}	
			
	/// <summary>
	/// This identifier shall define if the control output is a pulse output or if it is a 
	/// persistent output.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class cmdQual : DADataType
	{
		public cmdQual()
		{						
			this.name = "cmdQual";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.id = this.type = "cmdQualEnum";			
			this.EnumVal = new tEnumVal[2];
			tEnumVal enumVal0 = new tEnumVal();
			enumVal0.ord = "0";
			enumVal0.Value = "pulse";
			this.EnumVal[0] = enumVal0;			
			tEnumVal enumVal1 = new tEnumVal();
			enumVal1.ord = "1";
			enumVal1.Value = "persistent";
			this.EnumVal[1] = enumVal1;
		}
	}
				
	/// <summary>
	/// Pulse configuration type is used to configure the output pulse generated with a command.
	/// </summary>
	public class PulseConfig : SDIDADataTypeBDA
	{
		private cmdQual cmdQualField;
		private INT32U onDurField;
		private INT32U offDurField;
		private INT32U numPlsField;
		
		public PulseConfig(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.name = "PulseConfig";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fc = fCEnum;
			this.id = this.type = lnType+"PulseConfig";
			this.iedType = iedType;			
			this.cmdQualField = new cmdQual();
			this.onDurField = new INT32U("onDur");
			this.offDurField = new INT32U("offDur");
			this.numPlsField = new INT32U("numPls");
		}
		
		public PulseConfig(string iedType, string lnType)
		{
			this.name = "PulseConfig";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"PulseConfig";
			this.iedType = iedType;			
			this.cmdQualField = new cmdQual();
			this.onDurField = new INT32U("onDur");
			this.offDurField = new INT32U("offDur");
			this.numPlsField = new INT32U("numPls");
		}
		
		[Required]
		public cmdQual cmdQual
		{
			get
			{
				return this.cmdQualField;
			}
			set
			{
				this.cmdQualField = value;
			}
		}	
	
		[Required]
		public INT32U onDur
		{
			get
			{
				return this.onDurField;
			}
			set
			{
				this.onDurField = value;
			}
		}
	
		[Required]
		public INT32U offDur
		{
			get
			{
				return this.offDurField;
			}
			set
			{
				this.offDurField = value;
			}
		}
	
		[Required]
		public INT32U numPls
		{
			get
			{
				return this.numPlsField;
			}
			set
			{
				this.numPlsField = value;
			}
		}
	}

	/// <summary>
	/// It shall define the SI unit.
	/// </summary>
	public class Unit  : SDIDADataTypeBDA
	{
		private SIUnit SIUnitField;
		private multiplier multiplierField;
		
		public Unit (string iedType, string lnType)
		{
			this.name = "Unit";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"Unit";
			this.iedType = iedType;
			this.SIUnitField = new SIUnit();
			this.multiplierField = new multiplier();
		}
		
		[Required]
		public SIUnit SIUnit 
		{
			get
			{
				return this.SIUnitField;
			}
			set
			{
				this.SIUnitField = value;
			}
		}
		
		public multiplier multiplier
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
	
	/// <summary>
	/// It shall define the SI unit.
	/// </summary>
	public class SIUnit : DADataType
	{
		ConversionObject conversionObject;		
		public SIUnit()
		{
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(tSIUnitEnum.A);
			}				
			this.name = "SIUnit";		
			this.bTypeEnum = tBasicTypeEnum.Enum;		
			this.id = this.type = "SIUnitEnum";				
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(tSIUnitEnum));			
			this.EnumVal = new tEnumVal[valuesEnumArray.Length];
			for(int x = 0; x < valuesEnumArray.Length; x++)
			{
				tEnumVal enumVal = new tEnumVal();
				enumVal.ord = ((int) valuesEnumArray.GetValue(x)).ToString();
				enumVal.Value = valuesEnumArray.GetValue(x).ToString();
				this.EnumVal[x] = enumVal;
			}			
		}
		
		[DisplayName("Value"), Description("It´s the value of attribute.")]
		public tSIUnitEnum tValue
		{			
			get
			{
				return (tSIUnitEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(tSIUnitEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}
	}
	
	/// <summary>
	/// It shall define the multiplier value.
	/// </summary>
	public class multiplier : DADataType
	{
		ConversionObject conversionObject;		
	
		public multiplier()
		{
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(tUnitMultiplierEnum.a);
			}				
			this.name = "multiplier";		
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.id = this.type = "multiplierEnum";				
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(tUnitMultiplierEnum));			
			this.EnumVal = new tEnumVal[valuesEnumArray.Length];
			for(int x = 0; x < valuesEnumArray.Length; x++)
			{
				tEnumVal enumVal = new tEnumVal();
				enumVal.ord = ((int) valuesEnumArray.GetValue(x)).ToString();
				enumVal.Value = valuesEnumArray.GetValue(x).ToString();
				this.EnumVal[x] = enumVal;
			}			
		}
		
		[CategoryAttribute("DA"), DisplayName("Value"), Description("Value of attribute.")]
		public tUnitMultiplierEnum tValue
		{			
			get
			{
				return (tUnitMultiplierEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(tUnitMultiplierEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}
	}
	
	/// <summary>
	/// The angle reference is defined in the context where the Vector type is used.
	/// </summary>
	public class ang : SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;		
		
		public ang(string iedType, string lnType)
		{
			this.name = "ang";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"ang";
			this.iedType = iedType;			
			this.AnalogueValueField = new AnalogueValue(iedType, this.id);
			this.AnalogueValueField.CheckSelection = true;			
		}
		
		public AnalogueValue AnalogueValue
		{
			get
			{
				return this.AnalogueValueField;
			}
			set
			{
				this.AnalogueValueField = value;
			}
		}	
	}
	
	/// <summary>
	/// Vector type.
	/// </summary>
	public class Vector  : SDIDADataTypeBDA
	{
		private mag magField;
		private ang angField;
		public Vector (string iedType, string lnType)
		{
			this.name = "Vector";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"Vector";
			this.iedType = iedType;			
			this.magField = new mag(iedType, this.id);
			this.angField = new ang(iedType, this.id);
		}
		
		[Required]
		public mag mag				
		{
			get
			{
				return this.magField;
			}
			set
			{
				this.magField = value;
			}
		}	
		
		public ang ang
		{
			get
			{
				return this.angField;
			}
			set
			{
				this.angField = value;
			}
		}	
	}
		
	/// <summary>
	/// Point type.
	/// </summary>
	public class Point  : SDIDADataTypeBDA
	{
		private FLOAT32 xValField;
		private FLOAT32 yValField; 
		public Point (string iedType, string lnType)
		{
			this.name = "Point";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"Point";
			this.iedType = iedType;			
			this.xValField = new FLOAT32("xVal");
			this.yValField = new FLOAT32("yVal");
		}
		
		[Required]
		public FLOAT32 xVal
		{
			get
			{
				return this.xValField;
			}
			set
			{
				this.xValField = value;
			}
		}		
		
		[Required]
		public FLOAT32 yVal
		{
			get
			{
				return this.yValField;
			}
			set
			{
				this.yValField = value;
			}
		}
	}
	
	/// <summary>
	/// CtlModels type.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class ctlModels : DADataType
	{
		ConversionObject conversionObject;	
	
		public ctlModels ()
		{		
			conversionObject = new ConversionObject();
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(ctlModelsEnum.status_only);
			}	
			this.name = "ctlModels";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.id = this.type = "ctlModelsEnum";	
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(ctlModelsEnum));			
			this.EnumVal = new tEnumVal[valuesEnumArray.Length];
			for(int x = 0; x < valuesEnumArray.Length; x++)
			{
				tEnumVal enumVal = new tEnumVal();
				enumVal.ord = ((int) valuesEnumArray.GetValue(x)).ToString();
				enumVal.Value = valuesEnumArray.GetValue(x).ToString();
				this.EnumVal[x] = enumVal;
			}								
		}
			
		[Category("DA"), DisplayName("Value"), Description("Value of attribute.")]
		public ctlModelsEnum tValue
		{			
			get
			{
				return (ctlModelsEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(ctlModelsEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}
	}
		
	/// <summary>
	/// SboClasses type.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class SboClasses : DADataType
	{
		public SboClasses()
		{		
			this.name = "SboClasses";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.id = this.type = "SboClassesEnum";						
			this.EnumVal = new tEnumVal[2];			
			tEnumVal enumVal0 = new tEnumVal();
			enumVal0.ord = "0";
			enumVal0.Value = "operate-once";
			this.EnumVal[0] = enumVal0;			
			tEnumVal enumVal1 = new tEnumVal();
			enumVal1.ord = "1";
			enumVal1.Value = "operate-many";
			this.EnumVal[1] = enumVal1;
		}
	}		
			
	/// <summary>
	/// Enums of angRef
	/// </summary>
	public enum angRefEnum
	{
		Va, Vb, Vc, Aa, Ab, Ac, Vab, Vbc, Vca, Vother, Aother,
	}
				
	/// <summary>
	/// Enums of dirGeneral
	/// </summary>
	public enum dirGeneralEnum
	{
		unknown, forward, backward, both,
	}		
		
	/// <summary>
	/// Enums of dir
	/// </summary>
	public enum dirEnum
	{
		unknown, forward, backward,
	}		
	
	/// <summary>
	/// Enum of hvRef
	/// </summary>
	public enum hvRefEnum
	{
		fundamental, rms, absolute,
	}	
	
	/// <summary>
	/// The originator category shall specify the category of the originator that caused a change 
	/// of a value.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class orCat : DADataType
	{
		public orCat()
		{			
			this.name = "orCat";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.id = this.type = "orCatEnum";			
			this.EnumVal = new tEnumVal[9];
			tEnumVal enumVal0 = new tEnumVal();
			enumVal0.ord = "0";
			enumVal0.Value = "not-supported";
			this.EnumVal[0] = enumVal0;			
			tEnumVal enumVal1 = new tEnumVal();
			enumVal1.ord = "1";
			enumVal1.Value = "bay-control";
			this.EnumVal[1] = enumVal1;			
			tEnumVal enumVal2 = new tEnumVal();
			enumVal2.ord = "2";
			enumVal2.Value = "station-control";
			this.EnumVal[2] = enumVal2;			
			tEnumVal enumVal3 = new tEnumVal();
			enumVal3.ord = "3";
			enumVal3.Value = "remote-control";
			this.EnumVal[3] = enumVal3;			
			tEnumVal enumVal4 = new tEnumVal();
			enumVal4.ord = "4";
			enumVal4.Value = "automatic-bay";
			this.EnumVal[4] = enumVal4;			
			tEnumVal enumVal5 = new tEnumVal();
			enumVal5.ord = "5";
			enumVal5.Value = "automatic-station";
			this.EnumVal[5] = enumVal5;			
			tEnumVal enumVal6 = new tEnumVal();
			enumVal6.ord = "6";
			enumVal6.Value = "automatic-remote";
			this.EnumVal[6] = enumVal6;			
			tEnumVal enumVal7 = new tEnumVal();
			enumVal7.ord = "7";
			enumVal7.Value = "maintenance";
			this.EnumVal[7] = enumVal7;			
			tEnumVal enumVal8 = new tEnumVal();
			enumVal8.ord = "8";
			enumVal8.Value = "process";
			this.EnumVal[8] = enumVal8;
		}
	}
	
	/// <summary>
	/// Enum of phsRef
	/// </summary>
	public enum phsRefEnum
	{
		A, B, C,
	}

	/// <summary>
	/// Enum of range
	/// </summary>
	public enum rangeEnum
	{
		normal, high, low, high_high, low_low,
	}
	
	/// <summary>
	/// Enum of seqT
	/// </summary>
	public enum seqTEnum
	{
		pos_neg_zero,
		dir_quad_zero,
	}
	
	/// <summary>
	/// Enum of sev
	/// </summary>	
	public enum sevEnum
	{
		unknown, critical, major, minor, warning,
	}
	
	/// <summary>
	/// Enum of ctlVal
	/// </summary>
	public enum ctlValEnum
	{
		stop, lower, higher, reserved,
	}	
	
	/// <summary>
	/// Enum of val
	/// </summary>
	public enum valEnum
	{
		intermediate_state, off, on, bad_state,
	}
	
	/// <summary>
	/// Enum of ctlModels
	/// </summary>
	public enum ctlModelsEnum
	{
		status_only, direct_with_normal_security, sbo_with_normal_security, sbo_with_enhanced_security, direct_with_enhanced_security,
	}											  
	
	/// <summary>
	/// Class to define a boolean data type.
	/// </summary>
	public class BOOLEAN : DADataType
	{
		public BOOLEAN(string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.BOOLEAN;
			this.fc = fCEnum;
		}
		
		public BOOLEAN(string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.BOOLEAN;			
		}
	}
	
	/// <summary>
	/// Class to define an INT8 data type.
	/// </summary>
	public class INT8 : DADataType
	{
		public INT8(string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT8;	
			this.fc = fCEnum;
		}
		
		public INT8(string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT8;			
		}
	}
	
	/// <summary>
	/// Class to define an INT16 data type.
	/// </summary>	
	public class INT16 : DADataType
	{
		public INT16(string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT16;
			this.fc = fCEnum;			
		}
		
		public INT16(string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT16;
		}
	}

	/// <summary>
	/// Class to define an INT24 data type.
	/// </summary>	
	public class INT24 : DADataType
	{
		public INT24(string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT24;
			this.fc = fCEnum;			
		}
		
		public INT24(string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT24;
		}
	}

	/// <summary>
	/// Class to define an INT32 data type.
	/// </summary>	
	public class INT32 : DADataType
	{
		public INT32(string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT32;
			this.fc = fCEnum;			
		}
		
		public INT32(string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT32;
		}
	}	

	/// <summary>
	/// Class to define an INT128 data type.
	/// </summary>	
	public class INT128 : DADataType
	{
		public INT128(string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT128;
			this.fc = fCEnum;		
		}
		
		public INT128(string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT128;
		}
	}	

	/// <summary>
	/// Class to define an INT8U data type.
	/// </summary>	
	public class INT8U : DADataType
	{
		public INT8U(string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT8U;
			this.fc = fCEnum;
		}
		
		public INT8U(string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT8U;
		}
	}

	/// <summary>
	/// Class to define an INT16U data type.
	/// </summary>	
	public class INT16U : DADataType
	{
		public INT16U(string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT16U;
			this.fc = fCEnum;		
		}
		
		public INT16U(string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT16U;
		}
	}	

	/// <summary>
	/// Class to define an INT24U data type.
	/// </summary>	
	public class INT24U : DADataType
	{
		public INT24U (string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT24U;
			this.fc = fCEnum;
		}
		
		public INT24U (string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT24U;
		}
	}

	/// <summary>
	/// Class to define an INT32U data type.
	/// </summary>	
	public class INT32U : DADataType
	{
		public INT32U(string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT32U;
			this.fc = fCEnum;			
		}
		
		public INT32U(string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.INT32U;
		}
	}	

	/// <summary>
	/// Class to define an FLOAT32 data type.
	/// </summary>	
	public class FLOAT32 : DADataType
	{
		public FLOAT32 (string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.FLOAT32;
			this.fc = fCEnum;
		}
		
		public FLOAT32 (string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.FLOAT32;
		}
	}
	
	/// <summary>
	/// Class to define an FLOAT64 data type.
	/// </summary>	
	public class FLOAT64 : DADataType
	{
		public FLOAT64(string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.FLOAT64;
			this.fc = fCEnum;
		}
		
		public FLOAT64(string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.FLOAT64;
		}
	}		
	

	/// <summary>
	/// Class to define an VisString255 data type.
	/// </summary>	
	public class VisString255 : DADataType
	{
		public VisString255(string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.VisString255;			
			this.fc = fCEnum;
		}
		
		public VisString255(string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.VisString255;			
		}
	}
	
	/// <summary>
	/// Class to define an Octet64 data type.
	/// </summary>	
	public class Octet64 : DADataType
	{
		public Octet64(string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.Octet64;
			this.fc = fCEnum;
		}
		
		public Octet64(string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.Octet64;
		}
	}
	
	/// <summary>
	/// Class to define an VisString32 data type.
	/// </summary>	
	public class VisString32 : DADataType
	{
		public VisString32(string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.VisString32;
			this.fc = fCEnum;
		}
		
		public VisString32(string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.VisString32;
		}
	}
	
	/// <summary>
	/// Class to define an Timestamp data type.
	/// </summary>	
	public class Timestamp  : DADataType
	{
		public Timestamp(string name, tFCEnum fCEnum)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.Timestamp;
			this.fc = fCEnum;
		}
		
		public Timestamp(string name)
		{
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.Timestamp;
		}
	}
	
	/// <summary>
	/// Class to define an Unicode255 data type.
	/// </summary>	
	public class Unicode255 : DADataType
	{
		public Unicode255(string name, tFCEnum fCEnum)
		{						
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.Unicode255;	
			this.fc = fCEnum;
		}
		
		public Unicode255(string name)
		{						
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.Unicode255;					
		}
	}
	
	/// <summary>
	/// The quality identifier shall reflect the quality of the information in the server, as it 
	/// is supplied to the client.
	/// </summary>
	public class Quality  : DADataType
	{
		public Quality(string name, tFCEnum fCEnum)
		{						
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.Quality;	
			this.fc = fCEnum;
		}
		
		public Quality(string name)
		{						
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.Quality;					
		}
	}
	
	/// <summary>
	/// Class to define a VisString64 data type.
	/// </summary>	
	public class VisString64  : DADataType
	{
		public VisString64(string name, tFCEnum fCEnum)
		{						
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.VisString64;
			this.fc = fCEnum;
		}
		
		public VisString64(string name)
		{						
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.VisString64;					
		}
	}
	
	/// <summary>
	/// Class to define a VisString65 data type.
	/// </summary>	
	public class VisString65  : DADataType
	{
		public VisString65(string name, tFCEnum fCEnum)
		{						
			this.name = name;
			this.bTypeEnum = tBasicTypeEnum.VisString65;					
			this.fc = fCEnum;
		}
	}	
	
	/// <summary>
	/// The select with value service shall be performed through the use of an MMS write to the 
	/// SBOw attribute.
	/// </summary>	
	public class SBOw : SDIDADataTypeBDA
	{
		private Timestamp operTmField;
		private origin originField;
		private INT8U ctlNumField;
		private Transient_Data Transient_DataField;
		private BOOLEAN testField;
		private Check CheckField;
	
		public SBOw(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.Visible = false;
			this.name = "SBOw";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fc = fCEnum;
			this.id = this.type = lnType+"SBOw";
			this.iedType = iedType;	
			this.operTmField = new Timestamp("operTm");
			this.ctlNumField = new INT8U("ctlNum");
			this.testField = new BOOLEAN("test");
			this.originField = new origin(iedType, this.id);			
			this.Transient_DataField = new Transient_Data(iedType, this.id);
			this.CheckField = new Check(iedType, this.id);
		}
		
		[Browsable(false)]
		public INT8U ctlNum
		{
			get
			{
				return this.ctlNumField;
			}
			set
			{
				this.ctlNumField = value;
			}
		}	
	
		[Required]
		[Browsable(false)]
		public BOOLEAN test
		{
			get
			{
				return this.testField;
			}
			set
			{
				this.testField = value;
			}
		}		
		
		[Browsable(false)]
		public Timestamp operTm
		{
			get
			{
				return this.operTmField;
			}
			set
			{
				this.operTmField = value;
			}
		}
	
		[Required]
		[Browsable(false)]
		public origin origin
		{
			get 
			{
				return this.originField;
			}
			set
			{
				this.originField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public Transient_Data Transient_Data
		{
			get
			{
				return this.Transient_DataField;
			}
			set
			{
				this.Transient_DataField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public Check Check
		{
			get
			{
				return this.CheckField;
			}
			set
			{
				this.CheckField = value;
			}
		}
	}
	
	/// <summary>
	/// The receives service parameters and control values shall be performed through 
	/// the use of an MMS write to the Oper attribute.
	/// </summary>
	public class Oper : SDIDADataTypeBDA
	{
		private Timestamp operTmField;
		private origin originField;
		private INT8U ctlNumField;
		private Transient_Data Transient_DataField;
		private BOOLEAN testField;
		private Check CheckField;
	
		public Oper(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.Visible = false;
			this.name = "Oper";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fc = fCEnum;
			this.id = this.type = lnType+"Oper";
			this.iedType = iedType;	
			this.operTmField = new Timestamp("operTm");			
			this.ctlNumField = new INT8U("ctlNum");
			this.testField = new BOOLEAN("test");
			this.originField = new origin(iedType, this.id);			
			this.Transient_DataField = new Transient_Data(iedType, this.id);
			this.CheckField = new Check(iedType, this.id);
		}
		
		[Browsable(false)]
		public Timestamp operTm
		{
			get
			{
				return this.operTmField;
			}
			set
			{
				this.operTmField = value;
			}
		}
	
		[Browsable(false)]
		public INT8U ctlNum
		{
			get
			{
				return this.ctlNumField;
			}
			set
			{
				this.ctlNumField = value;
			}
		}		
	
		[Required]
		[Browsable(false)]
		public BOOLEAN test
		{
			get
			{
				return this.testField;
			}
			set
			{
				this.testField = value;
			}
		}		
	
		[Required]
		[Browsable(false)]
		public origin origin
		{
			get 
			{
				return this.originField;
			}
			set
			{
				this.originField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public Transient_Data Transient_Data
		{
			get
			{
				return this.Transient_DataField;
			}
			set
			{
				this.Transient_DataField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public Check Check
		{
			get
			{
				return this.CheckField;
			}
			set
			{
				this.CheckField = value;
			}
		}
	}
	
	/// <summary>
	/// The receives service parameters and control values shall be performed through 
	/// the use of an MMS write to the Cancel attribute.
	/// </summary>	
	public class Cancel : SDIDADataTypeBDA
	{
		private Timestamp operTmField;
		private origin originField;
		private INT8U ctlNumField;
		private Transient_Data Transient_DataField;
		private BOOLEAN testField;		
	
		public Cancel(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.Visible = false;
			this.name = "Cancel";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fc = fCEnum;
			this.id = this.type = lnType+"Cancel";
			this.iedType = iedType;	
			this.operTmField = new Timestamp("operTm");
			this.originField = new origin(iedType, this.id);
			this.ctlNumField = new INT8U("ctlNum");
			this.Transient_DataField = new Transient_Data(iedType, this.id);
			this.testField = new BOOLEAN("test");
		}
		
		[Browsable(false)]
		public Timestamp operTm
		{
			get
			{
				return this.operTmField;
			}
			set
			{
				this.operTmField = value;
			}
		}
	
		[Required]
		[Browsable(false)]
		public BOOLEAN test
		{
			get
			{
				return this.testField;
			}
			set
			{
				this.testField = value;
			}
		}
	
		[Browsable(false)]
		public INT8U ctlNum
		{
			get
			{
				return this.ctlNumField;
			}
			set
			{
				this.ctlNumField = value;
			}
		}		
	
		[Required]
		[Browsable(false)]
		public origin origin
		{
			get 
			{
				return this.originField;
			}
			set
			{
				this.originField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public Transient_Data Transient_Data
		{
			get
			{
				return this.Transient_DataField;
			}
			set
			{
				this.Transient_DataField = value;
			}
		}
	}
			
	/// <summary>
	/// Enum of valMod
	/// </summary>
	/// <remarks>
	/// This enum was created to be used by stVal attribute.
	/// </remarks>
	public enum valModEnum
	{
		on, blocked, test, test_blocked,off,
	}
}		
