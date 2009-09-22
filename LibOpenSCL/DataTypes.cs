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
		public string id;
		public string iedType;
		public string cdc;
	}	
	
	/// <summary>
	/// Name of an instance of a class of a single hierarchy level. 
	/// tBasicTypeEnum.VisString32
	/// </summary>
	public class ObjectName : DADataType
	{
		public ObjectName(tBasicTypeEnum basicTypeEnum)
		{
			this.name = "ObjectName";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// ObjectReference comprises the whole path-name of an instance of a class that identifies the 
	/// instance uniquely.
	/// tBasicTypeEnum.VisString255
	/// </summary>
	public class ObjectReference : DADataType
	{
		public ObjectReference(tBasicTypeEnum basicTypeEnum)
		{
			this.name = "ObjectReference";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// The ServiceError may be extended by an SCSM and the application layer referenced by an SCSM.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class ServiceError : DADataType
	{
		public ServiceError(tBasicTypeEnum basicTypeEnum)
		{
			this.name = "ServiceError";
			this.bType = basicTypeEnum;
			this.id = this.type = "ServiceErrorEnum";
			this.EnumVal = new tEnumVal[12];			
			tEnumVal enumVal0 = new tEnumVal();
			enumVal0.ord = "0";
			enumVal0.Value = "instance-not-available";
			this.EnumVal[0] = enumVal0;			
			tEnumVal enumVal1 = new tEnumVal();
			enumVal1.ord = "1";
			enumVal1.Value = "instance-in-use";
			this.EnumVal[1] = enumVal1;			
			tEnumVal enumVal2 = new tEnumVal();
			enumVal2.ord = "2";
			enumVal2.Value = "access-violation";
			this.EnumVal[2] = enumVal2;			
			tEnumVal enumVal3 = new tEnumVal();
			enumVal3.ord = "3";
			enumVal3.Value = "access-not-allowed-in-current-state";
			this.EnumVal[3] = enumVal3;			
			tEnumVal enumVal4 = new tEnumVal();
			enumVal4.ord = "4";
			enumVal4.Value = "parameter-value-inappropriate";
			this.EnumVal[4] = enumVal4;			
			tEnumVal enumVal5 = new tEnumVal();
			enumVal5.ord = "5";
			enumVal5.Value = "parameter-value-inconsistent";
			this.EnumVal[5] = enumVal5;			
			tEnumVal enumVal6 = new tEnumVal();
			enumVal6.ord = "6";
			enumVal6.Value = "class-not-supported";
			this.EnumVal[6] = enumVal6;			
			tEnumVal enumVal7 = new tEnumVal();
			enumVal7.ord = "7";
			enumVal7.Value = "instance-locked-by-other-client";
			this.EnumVal[7] = enumVal7;			
			tEnumVal enumVal8 = new tEnumVal();
			enumVal8.ord = "8";
			enumVal8.Value = "control-must-be-selected";
			this.EnumVal[8] = enumVal8;			
			tEnumVal enumVal9 = new tEnumVal();
			enumVal9.ord = "9";
			enumVal9.Value = "type-conflict";
			this.EnumVal[9] = enumVal9;			
			tEnumVal enumVal10 = new tEnumVal();
			enumVal10.ord = "10";
			enumVal10.Value = "failed-due-to-communications-constraint";
			this.EnumVal[10] = enumVal10;			
			tEnumVal enumVal11 = new tEnumVal();
			enumVal11.ord = "11";
			enumVal11.Value = "failed-due-to-server-constraint";
			this.EnumVal[11] = enumVal11;
		}
	}
	
	/// <summary>
	/// Used to identify an entry in a sequence of events such as a log or a buffered report as 
	/// specified by an SCSM.
	/// tBasicTypeEnum.Octet64
	/// </summary>
	public class EntryID : DADataType
	{
		public EntryID(tBasicTypeEnum basicTypeEnum)
		{
			this.name = "EntryID";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// Represent the time and date as applied internally for the communication, reporting, logging, 
	/// and subsystem as specified by a SCSM. 
	/// tBasicTypeEnum.Timestamp
	/// </summary>
	public class EntryTime : DADataType
	{
		public EntryTime(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "EntryTime";
			this.bType = basicTypeEnum;
		}
	}
		
	/// <summary>
	/// The attribute TrgOp shall specify the trigger conditions which shall be monitored by this BRCB.
	/// </summary>
	public class TrgOp : SDIDADataTypeBDA
	{		
		private bool dchgField;
		private bool qchgField;
		private bool dupdField;
		private bool integrityField; 
		private bool GIField;
		
		public TrgOp(string iedType, string lnType)
		{
			this.name = "TrgOp";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"TrgOp";
			this.iedType = iedType;
		}
		
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
		
		public bool integrity
		{
			get
			{
				return this.integrityField;
			}
			set
			{
				this.integrityField = value;
			}
		}
		
		public bool GI
		{
			get
			{
				return this.GIField;
			}
			set
			{
				this.GIField = value;
			}
		}
	}
	
	/// <summary>
	/// Data attribute type name.
	/// </summary>
	public class DAType : SDIDADataTypeBDA
	{
		private DATName DATNameField;
		private DATRef DATRefField;
		private Presence PresenceField;
		
		public DAType(string iedType, string lnType)
		{
			this.name = "DAType";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"DAType";
			this.iedType = iedType;			
			this.PresenceField = new Presence(tBasicTypeEnum.BOOLEAN);
			this.DATNameField = new DATName(iedType, this.id);
			this.DATRefField = new DATRef(iedType, this.id);			
		}
		
		public Presence Presence
		{
			get
			{
				return this.PresenceField;
			}
			set
			{
				this.PresenceField = value;
			}
		}
		
		public DATName DATName
		{
			get
			{
				return this.DATNameField;
			}
			set
			{
				this.DATNameField = value;
			}
		}
		
		public DATRef DATRef
		{
			get
			{
				return this.DATRefField;
			}
			set
			{
				this.DATRefField = value;
			}
		}		
	}
	
	/// <summary>
	/// Instance name of an instance of DAType.
	/// </summary>
	public class DATName : SDIDADataTypeBDA
	{
		private ObjectName ObjectNameField;
		
		public DATName(string iedType, string lnType)
		{
			this.name = "DATName";			
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"DATName";
			this.iedType = iedType;			
			this.ObjectNameField = new ObjectName(tBasicTypeEnum.VisString32);
		}
		
		public ObjectName ObjectName
		{
			get
			{
				return this.ObjectNameField;
			}
			set
			{
				this.ObjectNameField = value;
			}
		}
	}
	
	/// <summary>
	/// Path-name of an instance of DAType.
	/// </summary>
	public class DATRef : SDIDADataTypeBDA
	{
		private ObjectReference ObjectReferenceField;
		
		public DATRef(string iedType, string lnType)
		{
			this.name = "DATRef";			
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"DATRef";
			this.iedType = iedType;			
			this.ObjectReferenceField = new ObjectReference(tBasicTypeEnum.VisString255);
		}
		
		public ObjectReference ObjectReference
		{
			get
			{
				return this.ObjectReferenceField;
			}
			set
			{
				this.ObjectReferenceField = value;
			}
		}
	}
	
	/// <summary>
	/// Indicates mandatory/optional.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class Presence : DADataType
	{
		public Presence(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "Presence";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// Instance name of an instance of DATA.
	/// </summary>
	public class DataName : SDIDADataTypeBDA
	{
		private ObjectName ObjectNameField;
		
		public DataName(string iedType, string lnType)
		{
			this.name = "DataName";			
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"DataName";
			this.iedType = iedType;			
			this.ObjectNameField = new ObjectName(tBasicTypeEnum.VisString32);
		}
		
		public ObjectName ObjectName
		{
			get
			{
				return this.ObjectNameField;
			}
			set
			{
				this.ObjectNameField = value;
			}
		}
	}
	
	/// <summary>
	/// Path-name of an instance of DATA
	/// </summary>
	public class DataRef : SDIDADataTypeBDA
	{
		private ObjectReference ObjectReferenceField;
		
		public DataRef(string iedType, string lnType)
		{
			this.name = "DataRef";			
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"DataRef";
			this.iedType = iedType;			
			this.ObjectReferenceField = new ObjectReference(tBasicTypeEnum.VisString255);
		}
		
		public ObjectReference ObjectReference
		{
			get
			{
				return this.ObjectReferenceField;
			}
			set
			{
				this.ObjectReferenceField = value;
			}
		}
	}
			
	/// <summary>
	/// Identifies a type of an attribute data, p.e. Vector class.
	/// </summary>
	public class DataAttributeType : SDIDADataTypeBDA
	{
		private DAType DATypeField;	
		
		public DataAttributeType(string iedType, string lnType)
		{
			this.name = "DataAttributeType";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"DataAttributeType";
			this.iedType = iedType;			
			this.DATypeField = new DAType(iedType, this.id);
		}
		
		public DAType DAType
		{
			get
			{
				return this.DATypeField;
			}
			set
			{
				this.DATypeField = value;
			}
		}
	}
	
	/// <summary>
	/// Common Data class.
	/// </summary>
	public class COMMON_DATA : SDIDADataTypeBDA
	{
		private DataName DataNameField;
		private DataRef DataRefField;
		private Presence PresenceField;
		private DataAttributeType DataAttributeTypeField;
		private TrgOp TrgOpField;
		
		public COMMON_DATA(string iedType, string lnType)
		{
			this.name = "COMMON_DATA";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"COMMON_DATA";
			this.iedType = iedType;			
			this.PresenceField = new Presence(tBasicTypeEnum.BOOLEAN);
			this.DataNameField = new DataName(iedType, this.id);
			this.DataRefField = new DataRef(iedType, this.id);			
			this.DataAttributeType = new DataAttributeType(iedType, this.id);
			this.TrgOpField = new TrgOp(iedType, this.id);			
		}
		
		public Presence Presence
		{
			get
			{
				return this.PresenceField;
			}
			set
			{
				this.PresenceField = value;
			}
		}	
		
		public TrgOp TrgOp
		{
			get
			{
				return this.TrgOpField;
			}
			set
			{
				this.TrgOpField = value;
			}
		}	
		
		public DataName DataName
		{
			get
			{
				return this.DataNameField;
			}
			set
			{
				this.DataNameField = value;
			}
		}
		
		public DataRef DataRef
		{
			get
			{
				return this.DataRefField;
			}
			set
			{
				this.DataRefField = value;
			}
		}	
		
		public DataAttributeType DataAttributeType
		{
			get
			{
				return this.DataAttributeTypeField;
			}
			set
			{
				this.DataAttributeTypeField = value;
			}
		}				
	}
	
	/// <summary>
	/// The attribute TimeOfEntry shall be the time, when the entry is added to the buffer.
	/// </summary>
	public class TimeOfEntry : SDIDADataTypeBDA
	{
		private EntryTime EntryTimeField;		

		public TimeOfEntry(string iedType, string lnType)
		{
			this.name = "TimeOfEntry";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"TimeOfEntry";
			this.iedType = iedType;			
			this.EntryTimeField = new EntryTime(tBasicTypeEnum.Timestamp);
		}
		
		public EntryTime EntryTime
		{
			get
			{
				return this.EntryTimeField;
			}
			set
			{
				this.EntryTimeField = value;
			}
		}
	}
	
	/// <summary>
	/// Used to identify an entry in a sequence of events such as a log or a buffered report as 
	/// specified by an SCSM.
	/// </summary>
	public class Entry : SDIDADataTypeBDA
	{
		private TimeOfEntry TimeOfEntryField;
		private EntryID EntryIDField;
		
		public Entry(string iedType, string lnType)
		{
			this.name = "Entry";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"Entry";
			this.iedType = iedType;
			this.EntryIDField = new EntryID(tBasicTypeEnum.Octet64);
			this.TimeOfEntryField = new TimeOfEntry(iedType, this.id);			
		}
		
		public EntryID EntryID
		{
			get
			{
				return this.EntryIDField;
			}
			set
			{
				this.EntryIDField = value;
			}
		}	
		
		public TimeOfEntry TimeOfEntry
		{
			get
			{
				return this.TimeOfEntryField;
			}
			set
			{
				this.TimeOfEntryField = value;
			}
		}			
	}
			
	/// <summary>
	/// The reason for inclusion shall be set according the TrgOp that caused the creation of the EntryData. 
	/// </summary>
	public class ReasonCode : SDIDADataTypeBDA
	{
		private TrgOp TrgOpField;		
		
		public ReasonCode(string iedType, string lnType)
		{
			this.name = "ReasonCode";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"ReasonCode";
			this.iedType = iedType;			
			this.TrgOpField = new TrgOp(iedType, this.id);
		}		
		
		public TrgOp TrgOp
		{
			get
			{
				return this.TrgOpField;
			}
			set
			{
				this.TrgOpField = value;
			}			
		}		
	}
	
	/// <summary>
	/// The parameter EntryData shall contain the data reference, value, and reasonCode of each member 
	/// of the DATA-SET to be included in the report.
	/// </summary>
	public class EntryData : SDIDADataTypeBDA
	{
		private DataRef DataRefField;
		private ReasonCode ReasonCodeField;
			
		public EntryData(string iedType, string lnType)
		{
			this.name = "EntryData";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"EntryData";
			this.iedType = iedType;			
			this.DataRefField = new DataRef(iedType, this.id);
			this.ReasonCodeField = new ReasonCode(iedType, this.id);
		}
		
		public DataRef DataRef
		{
			get
			{
				return this.DataRefField;
			}
			set
			{
				this.DataRefField = value;
			}
		}
	}
		
	/// <summary>
	/// This identifier shall indicate a quality issue that the value of the attribute to which the 
	/// quality has been associated is beyond the capability of being represented properly. 
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class overflow : DADataType
	{
		public overflow(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "overflow";
			this.bType = basicTypeEnum;
		}
	}	
	
	/// <summary>
	/// This identifier shall indicate a quality issue that the attribute to which the quality has 
	/// been associated is beyond a predefined range of values. 
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class outOfRange : DADataType
	{
		public outOfRange(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "outOfRange";
			this.bType = basicTypeEnum;
		}
	}	
	
	/// <summary>
	/// This identifier shall indicate that the value may not be a correct value due to a reference 
	/// being out of calibration. 
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class badReference : DADataType
	{
		public badReference(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "badReference";
			this.bType = basicTypeEnum;
		}
	}	
	
	/// <summary>
	/// To prevent overloading of event driven communication channels, it is desirable to detect and 
	/// suppress oscillating (fast changing) binary inputs.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class oscillatory : DADataType
	{
		public oscillatory(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "oscillatory";
			this.bType = basicTypeEnum;
		}
	}	
	
	/// <summary>
	/// This identifier shall indicate that a supervision function has detected an internal or external 
	/// failure.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class failure : DADataType
	{
		public failure(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "failure";
			this.bType = basicTypeEnum;
		}
	}	
	
	/// <summary>
	/// A value shall be oldData if an update is not made during a specific time interval. 
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class oldData : DADataType
	{
		public oldData(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "oldData";
			this.bType = basicTypeEnum;
		}
	}	
	
	/// <summary>
	/// This identifier shall indicate that an evaluation function has detected an inconsistency.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class inconsistent : DADataType
	{
		public inconsistent(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "inconsistent";
			this.bType = basicTypeEnum;
		}
	}	
	
	/// <summary>
	/// This identifier shall indicate that the value does not meet the stated accuracy of the source.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class inaccurate : DADataType
	{
		public inaccurate(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "inaccurate";
			this.bType = basicTypeEnum;
		}
	}	
	
	/// <summary>
	/// The parameter T (Transient_Data) shall be the time when the client sends the control request.
	/// </summary>
	public class Transient_Data : SDIDADataTypeBDA
	{
		private test testField;
		
		public Transient_Data(string iedType, string lnType)
		{
			this.name = "Transient_Data";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"Transient_Data";
			this.iedType = iedType;			
			this.testField = new test(tBasicTypeEnum.BOOLEAN);
		}	
		
		public test test
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
	/// This parameter TimOperRsp shall specify the details of the positive response on the service 
	/// TimeActivatedOperate.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class TimOperRsp : DADataType
	{
		public TimOperRsp(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "TimOperRsp";
			this.bType = basicTypeEnum;
			this.id = this.type = "TimOperRspEnum";			
			this.EnumVal = new tEnumVal[3];
			tEnumVal enumVal0 = new tEnumVal();
			enumVal0.ord = "0";
			enumVal0.Value = "Temporal 0";
			this.EnumVal[0] = enumVal0;			
			tEnumVal enumVal1 = new tEnumVal();
			enumVal1.ord = "1";
			enumVal1.Value = "Temporal 1";
			this.EnumVal[1] = enumVal1;			
			tEnumVal enumVal2 = new tEnumVal();
			enumVal2.ord = "2";
			enumVal2.Value = "Temporal 2";
			this.EnumVal[2] = enumVal2;
		}
	}
	
	/// <summary>
	/// The synchrocheck will verify some electrotechnical conditions and enable or not the control, 
	/// depending on its type.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class synchrocheck : DADataType
	{
		public synchrocheck(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "synchrocheck";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// Verify if there is an interlock condition.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class interlockcheck : DADataType
	{
		public interlockcheck(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "interlockcheck";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// The parameter Check shall specify the kind of checks a control object shall perform 
	/// before issuing the control operation if common DATA class is DPC.
	/// </summary>
	public class Check : SDIDADataTypeBDA
	{
		private synchrocheck synchrocheckField;
		private interlockcheck interlockcheckField;	
		
		public Check(string iedType, string lnType)
		{
			this.name = "Check";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"Check";
			this.iedType = iedType;			
			this.synchrocheckField = new synchrocheck(tBasicTypeEnum.BOOLEAN);
			this.interlockcheckField = new interlockcheck(tBasicTypeEnum.BOOLEAN);
		}
		
		public synchrocheck synchrocheck
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
		
		public interlockcheck interlockcheck
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
	/// The reason for an invalid or questionable value of an attribute may be specified in more 
	/// detail with further quality identifiers. 
	/// </summary>
	public class detailQual : SDIDADataTypeBDA
	{
		private overflow overflowField;
		private outOfRange outOfRangeField;
		private badReference badReferenceField;
		private oscillatory oscillatoryField;
		private failure failureField;
		private oldData oldDataField;
		private inconsistent inconsistentField;
		private inaccurate inaccurateField;		
		
		public detailQual(string iedType, string lnType)
		{
			this.name = "detailQual";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"detailQual";
			this.iedType = iedType;			
			this.overflowField = new overflow(tBasicTypeEnum.BOOLEAN);
			this.outOfRangeField = new outOfRange(tBasicTypeEnum.BOOLEAN);
			this.badReferenceField = new badReference(tBasicTypeEnum.BOOLEAN);
			this.oscillatoryField = new oscillatory(tBasicTypeEnum.BOOLEAN);
			this.failureField = new failure(tBasicTypeEnum.BOOLEAN);
			this.oldDataField = new oldData(tBasicTypeEnum.BOOLEAN);
			this.inconsistentField = new inconsistent(tBasicTypeEnum.BOOLEAN);
			this.inaccurateField = new inaccurate(tBasicTypeEnum.BOOLEAN);
		}
		
		[Required]
		public overflow overflow 
		{
			get
			{
				return this.overflowField;
			}
			set
			{
				this.overflowField = value;
			}
		}
		
		[Required]
		public outOfRange outOfRange
		{
			get
			{
				return this.outOfRangeField;
			}
			set
			{
				this.outOfRangeField = value;
			}		
		}
		
		[Required]
		public badReference  badReference
		{
			get
			{
				return this.badReferenceField ;
			}
			set
			{
				this.badReferenceField = value;
			}
		}	
		
		[Required]
		public oscillatory oscillatory
		{
			get
			{
				return this.oscillatoryField;
			}
			set
			{
				this.oscillatoryField = value;
			}
		}	
		
		[Required]
		public oldData oldData
		{
			get
			{
				return this.oldDataField;
			}
			set
			{
				this.oldDataField = value;
			}
		}	
		
		[Required]
		public inconsistent inconsistent
		{
			get
			{
				return this.inconsistentField;
			}
			set
			{
				this.inconsistentField = value;
			}
		}	
		
		[Required]
		public inaccurate inaccurate	
		{
			get
			{
				return this.inaccurateField;
			}
			set
			{
				this.inaccurateField = value;
			}
		}
	}
	
	/// <summary>
	/// Marking a value if no abnormal or abnormal condition of the acquisition function or the 
	/// information source is detected.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class validity : DADataType
	{
		public validity(tBasicTypeEnum basicTypeEnum)
		{
			this.name = "validity";		
			this.bType = basicTypeEnum;
			this.id = this.type = "validityEnum";						 			
			this.EnumVal = new tEnumVal[4];
			tEnumVal enumVal0 = new tEnumVal();
			enumVal0.ord = "0";
			enumVal0.Value = "good";
			this.EnumVal[0] = enumVal0;			
			tEnumVal enumVal1 = new tEnumVal();
			enumVal1.ord = "1";
			enumVal1.Value = "invalid";
			this.EnumVal[1] = enumVal1;			
			tEnumVal enumVal2 = new tEnumVal();
			enumVal2.ord = "2";
			enumVal2.Value = "reserved";
			this.EnumVal[2] = enumVal2;			
			tEnumVal enumVal3 = new tEnumVal();
			enumVal3.ord = "3";
			enumVal3.Value = "questionable";
			this.EnumVal[3] = enumVal3; 
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
	/// Source shall give information related to the origin of a value. The value may be acquired 
	/// from the process or be a substituted value.
	/// </summary>
	[DefaultValue(sourceEnum.process)]
	public class source : DADataType
	{
		ConversionObject conversionObject;		
		public source(tBasicTypeEnum basicTypeEnum)
		{
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(sourceEnum.process);
			}			
			this.name = "source";		
			this.bType = basicTypeEnum;
			this.id = this.type = "sourceEnum";				
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(sourceEnum));			
			this.EnumVal = new tEnumVal[valuesEnumArray.Length];
			for(int x = 0; x < valuesEnumArray.Length; x++)
			{
				tEnumVal enumVal = new tEnumVal();
				enumVal.ord = x.ToString();
				enumVal.Value = valuesEnumArray.GetValue(x).ToString();
				this.EnumVal[x] = enumVal;
			}				
		}
		
		[DisplayName("Value"), Description("It´s the value of attribute.")]
		public sourceEnum tValue
		{			
			get
			{
				return (sourceEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(sourceEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}		
	}
	
	/// <summary>
	/// Contains values that can be assigned to a boolean type data.
	/// </summary>
	public enum booleanEnum
	{		
		False,
		True,
	}
	
	/// <summary>
	/// The parameter Test shall define whether the information is caused by normal operation or by test.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class test : DADataType
	{
		ConversionObject conversionObject;		
		bool valueBoolean;
		public test(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "test";
			this.bType = basicTypeEnum;		
			conversionObject = new ConversionObject();
			if(this.Value==null)
			{
				valueBoolean = (bool) this.conversionObject.SetStringToPrimitiveType(this.conversionObject.SetEnumObjectToString(booleanEnum.False),"Boolean");
				this.Value = valueBoolean.ToString();
			}				
		}
		
		[DisplayName("Value"), Description("It´s the value of attribute.")]
		public booleanEnum tValue
		{			
			get				
			{
				valueBoolean = (bool) this.conversionObject.SetStringToPrimitiveType(this.Value,"Boolean");
				return (booleanEnum) this.conversionObject.SetStringToEnumObject(valueBoolean.ToString(), typeof(booleanEnum));
			}
			set				
			{
				valueBoolean = (bool)this.conversionObject.SetStringToPrimitiveType(this.conversionObject.SetEnumObjectToString(value),"Boolean");
				this.Value = valueBoolean.ToString();
			}
		}
	}
	
	/// <summary>
	/// This identifier shall be set if further update of the value has been blocked by an operator.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class operatorBlocked : DADataType
	{
		ConversionObject conversionObject;		
		bool valueBoolean;
		public operatorBlocked(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "operatorBlocked";
			this.bType = basicTypeEnum;			
			conversionObject = new ConversionObject();
			if(this.Value==null)
			{
				valueBoolean = (bool) this.conversionObject.SetStringToPrimitiveType(this.conversionObject.SetEnumObjectToString(booleanEnum.False),"Boolean");
				this.Value = valueBoolean.ToString();
			}	
		}
		
		[Category("DA"), DisplayName("Value"), Description("It´s the value of attribute.")]
		public booleanEnum tValue
		{			
			get
			{
				valueBoolean = (bool) this.conversionObject.SetStringToPrimitiveType(this.Value,"Boolean");
				return (booleanEnum) this.conversionObject.SetStringToEnumObject(valueBoolean.ToString(), typeof(booleanEnum));
			}
			set				
			{
				valueBoolean = (bool)this.conversionObject.SetStringToPrimitiveType(this.conversionObject.SetEnumObjectToString(value),"Boolean");
				this.Value = valueBoolean.ToString();			
			}
		}
	}
	
	/// <summary>
	/// The quality identifier shall reflect the quality of the information in the server, as it 
	/// is supplied to the client.
	/// </summary>
	public class Quality : SDIDADataTypeBDA
	{
		private validity validityField;			
		private detailQual detailQualField;	
		private source sourceField;
		private test testField;	
		private operatorBlocked operatorBlockedField;
		
		public Quality(string iedType, string lnType)
		{
			this.name = "Quality";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"Quality";
			this.iedType = iedType;			
			this.validityField = new validity(tBasicTypeEnum.Enum);			
			this.sourceField = new source(tBasicTypeEnum.Enum);
			this.test = new test(tBasicTypeEnum.BOOLEAN);
			this.operatorBlockedField = new operatorBlocked(tBasicTypeEnum.BOOLEAN);
			this.detailQualField = new detailQual(iedType, this.id);					
		}
		
		[Required]
		public validity validity	
		{
			get
			{
				return this.validityField;
			}
			set
			{
				this.validityField = value;
			}
		}
		
		[Required]
		public source source	
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
		
		[Required]
		public test test
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
		public operatorBlocked operatorBlocked
		{
			get
			{
				return this.operatorBlockedField;
			}
			set
			{	
				this.operatorBlockedField = value;
			}
		}
		
		[Required]
		public detailQual detailQual	
		{
			get
			{
				return this.detailQualField;
			}
			set
			{	
				this.detailQualField = value;
			}
		}
	}
		 
	/// <summary>
	/// The value of i shall be an integer representation of the measured value.
	/// tBasicTypeEnum.INT32
	/// </summary>
	public class i : DADataType
	{
		public i(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "i";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// The value of f shall be the floating point representation of the measured value.
	/// tBasicTypeEnum.FLOAT32
	/// </summary>
	public class f : DADataType
	{
		public f(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "f";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// Analogue values may be represented as a basic data type INTEGER (attribute i) or as FLOATING
	/// POINT (attribute f)
	/// </summary>
	public class AnalogueValue : SDIDADataTypeBDA
	{
		private i iField;
		private f fField;		
		
		public AnalogueValue(string iedType, string lnType)
		{
			this.name = "AnalogueValue";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"AnalogueValue";
			this.iedType = iedType;			
			this.iField = new i(tBasicTypeEnum.INT32);
			this.fField = new f(tBasicTypeEnum.FLOAT32);
		}
		
		public i i
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
		
		public f f
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
	/// This data attribute type shall be used to configure the INTEGER (i) value representation of
	/// the AnalogueValue.
	/// tBasicTypeEnum.FLOAT32
	/// </summary>
	public class scaleFactor : DADataType
	{
		public scaleFactor(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "scaleFactor";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// This data attribute type shall be used to configure the INTEGER (i) value representation of 
	/// the AnalogueValue.
	/// tBasicTypeEnum.FLOAT32
	/// </summary>
	public class offset : DADataType
	{
		public offset(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "offset";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// Configuration of analogue value type.
	/// </summary>
	public class ScaledValueConfig : SDIDADataTypeBDA
	{
		private scaleFactor scaleFactorField;
		private offset offsetField;
		
		public ScaledValueConfig(string iedType, string lnType)
		{
			this.name = "ScaledValueConfig";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"ScaledValueConfig";
			this.iedType = iedType;
			this.scaleFactorField = new scaleFactor(tBasicTypeEnum.FLOAT32);
			this.offsetField = new offset(tBasicTypeEnum.FLOAT32);
		}
		
		[Required]
		public scaleFactor scaleFactor
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
		public offset offset
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
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"hhLim";
			this.iedType = iedType;
			this.AnalogueValueField = new AnalogueValue(iedType, this.id);
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
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"hLim";
			this.iedType = iedType;
			this.AnalogueValueField = new AnalogueValue(iedType, this.id);
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
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"lLim";
			this.iedType = iedType;
			this.AnalogueValueField = new AnalogueValue(iedType, this.id);
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
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"llLim";
			this.iedType = iedType;
			this.AnalogueValueField = new AnalogueValue(iedType, this.id);
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
			this.bType = tBasicTypeEnum.Struct;
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
	/// The posVal shall contain the step position.
	/// tBasicTypeEnum.INT8
	/// </summary>
	public class posVal : DADataType
	{
		public posVal(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "posVal";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// The transInd shall indicate that the equipment is in a transient state.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class transInd : DADataType
	{
		public transInd(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "transInd";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// Step position with transient indication type is for example used to indicate the position 
	/// of tap changers.
	/// </summary>
	public class ValWithTrans : SDIDADataTypeBDA
	{
		private posVal posValField;
		private transInd transIndField;
		
		public ValWithTrans(string iedType, string lnType)
		{
			this.name = "ValWithTrans";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"ValWithTrans";
			this.iedType = iedType;			
			this.posValField = new posVal(tBasicTypeEnum.INT8);
			this.transIndField = new transInd(tBasicTypeEnum.BOOLEAN);
		}

		[Required]
		public posVal posVal
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
	
		public transInd transInd
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
		public cmdQual(tBasicTypeEnum basicTypeEnum)
		{						
			this.name = "cmdQual";
			this.bType = basicTypeEnum;
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
	/// onDur shall specify the on duration of the pulse.
	/// tBasicTypeEnum.INT32U
	/// </summary>
	public class onDur : DADataType
	{
		public onDur(tBasicTypeEnum basicTypeEnum)
		{						
			this.name = "onDur";
			this.bType = basicTypeEnum;
		}
	}		
	
	/// <summary>
	/// offDur specifies the duration between two pulses.
	/// tBasicTypeEnum.INT32U
	/// </summary>
	public class offDur : DADataType
	{
		public offDur(tBasicTypeEnum basicTypeEnum)
		{						
			this.name = "offDur";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// NumPls shall specify the number of pulses that are generated.
	/// tBasicTypeEnum.INT32U
	/// </summary>
	public class numPls : DADataType
	{
		public numPls(tBasicTypeEnum basicTypeEnum)
		{						
			this.name = "numPls";
			this.bType = basicTypeEnum;
		}
	}	
	
	/// <summary>
	/// Pulse configuration type is used to configure the output pulse generated with a command.
	/// </summary>
	public class PulseConfig : SDIDADataTypeBDA
	{
		private cmdQual cmdQualField;
		private onDur onDurField;
		private offDur offDurField;
		private numPls numPlsField;
		
		public PulseConfig(string iedType, string lnType)
		{
			this.name = "PulseConfig";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"PulseConfig";
			this.iedType = iedType;			
			this.cmdQualField = new cmdQual(tBasicTypeEnum.Enum);
			this.onDurField = new onDur(tBasicTypeEnum.INT32U);
			this.offDurField = new offDur(tBasicTypeEnum.INT32U);
			this.numPlsField = new numPls(tBasicTypeEnum.INT32U);
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
		public onDur onDur
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
		public offDur offDur
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
		public numPls numPls
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
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"Unit";
			this.iedType = iedType;
			this.SIUnitField = new SIUnit(tBasicTypeEnum.Enum);
			this.multiplierField = new multiplier(tBasicTypeEnum.Enum);
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
		public SIUnit(tBasicTypeEnum basicTypeEnum)
		{
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(tSIUnitEnum.A);
			}				
			this.name = "SIUnit";		
			this.bType = basicTypeEnum;		
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
	
		public multiplier(tBasicTypeEnum basicTypeEnum)
		{
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(tUnitMultiplierEnum.a);
			}				
			this.name = "multiplier";		
			this.bType = basicTypeEnum;		
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
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"ang";
			this.iedType = iedType;			
			this.AnalogueValueField = new AnalogueValue(iedType, this.id);
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
			this.bType = tBasicTypeEnum.Struct;
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
	/// The x value of a curve point.
	///tBasicTypeEnum.FLOAT32	
	/// </summary>
	public class xVal : DADataType
	{
		public xVal(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "xVal";
			this.bType = basicTypeEnum;
		}
	}	
		
	/// <summary>
	/// The y value of a curve point.
	/// tBasicTypeEnum.FLOAT32
	/// </summary>
	public class yVal : DADataType
	{
		public yVal(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "yVal";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// Point type.
	/// </summary>
	public class Point  : SDIDADataTypeBDA
	{
		private xVal xValField;
		private yVal yValField; 
		public Point (string iedType, string lnType)
		{
			this.name = "Point";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"Point";
			this.iedType = iedType;			
			this.xValField = new xVal(tBasicTypeEnum.FLOAT32);
			this.yValField = new yVal(tBasicTypeEnum.FLOAT32);
		}
		
		[Required]
		public xVal xVal
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
		public yVal yVal
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
	public class Ctlmodels : DADataType
	{
		public Ctlmodels(tBasicTypeEnum basicTypeEnum)
		{		
			this.name = "Ctlmodels";
			this.bType = basicTypeEnum;
			this.id = this.type = "CtlmodelsEnum";					
			this.EnumVal = new tEnumVal[5];
			tEnumVal enumVal0 = new tEnumVal();
			enumVal0.ord = "0";
			enumVal0.Value = "status-only";
			this.EnumVal[0] = enumVal0;			
			tEnumVal enumVal1 = new tEnumVal();
			enumVal1.ord = "1";
			enumVal1.Value = "direct-with-normal-security";
			this.EnumVal[1] = enumVal1;			
			tEnumVal enumVal2 = new tEnumVal();
			enumVal2.ord = "2";
			enumVal2.Value = "sbo-with-normal-security";
			this.EnumVal[2] = enumVal2;			
			tEnumVal enumVal3 = new tEnumVal();
			enumVal3.ord = "3";
			enumVal3.Value = "directwith-enhanced-security";
			this.EnumVal[3] = enumVal3;			
			tEnumVal enumVal4 = new tEnumVal();
			enumVal4.ord = "4";
			enumVal4.Value = "sbo-with-enhanced-security";
			this.EnumVal[4] = enumVal4;
		}
	}
		
	/// <summary>
	/// SboClasses type.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class SboClasses : DADataType
	{
		public SboClasses(tBasicTypeEnum basicTypeEnum)
		{		
			this.name = "SboClasses";
			this.bType = basicTypeEnum;
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
	/// It shall be the interval in seconds continuously counted from the epoch 1970-01-01 00:00:00 UTC.
	/// tBasicTypeEnum.FLOAT32
	/// </summary>
	public class SecondSinceEpoch : DADataType
	{
		public SecondSinceEpoch(tBasicTypeEnum basicTypeEnum)
		{						
			this.name = "SecondSinceEpoch";
			this.bType = basicTypeEnum;
		}
	}
		
	/// <summary>
	/// It shall be the fraction of the current second when the value of the TimeStamp has been 
	/// determined. 
	/// tBasicTypeEnum.INT24U
	/// </summary>
	public class FractionOfSecond : DADataType
	{
		public FractionOfSecond(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "FractionOfSecond";
			this.bType = basicTypeEnum;
		}
	}
			
	/// <summary>
	/// It shall indicate that the value for SecondSinceEpoch could be taken into account all 
	/// leap seconds occurred.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class LeapSecondsKnown : DADataType
	{
		public LeapSecondsKnown(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "LeapSecondsKnown";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// It shall indicate that the time source of the sending device is unreliable.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class ClockFailure : DADataType
	{
		public ClockFailure(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "ClockFailure";
			this.bType = basicTypeEnum;
		}
	}
		
	/// <summary>
	/// It shall indicate that the time source of the sending device is not synchronized with 
	/// the external UTC time.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class ClockNotSynchronized : DADataType
	{
		public ClockNotSynchronized(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "ClockNotSynchronized";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// It shall represent the time accuracy class of the time source of the sending device relative 
	/// to the external UTC time. 
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class TimeAccuracy : DADataType
	{
		public TimeAccuracy(tBasicTypeEnum basicTypeEnum)
		{							
			this.name = "TimeAccuracy";
			this.bType = basicTypeEnum;
			this.id = this.type = "TimeAccuracyEnum";			
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
	/// The TimeQuality shall provide information about the time source of the sending IED.
	/// </summary>
	public class TimeQuality : SDIDADataTypeBDA
	{
		private LeapSecondsKnown LeapSecondsKnownField;
		private ClockFailure ClockFailureField;
		private ClockNotSynchronized ClockNotSynchronizedField;
		private TimeAccuracy TimeAccuracyField;
		public TimeQuality(string iedType, string lnType)
		{
			this.name = "TimeQuality";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"TimeQuality";
			this.iedType = iedType;			
			this.LeapSecondsKnownField = new LeapSecondsKnown(tBasicTypeEnum.BOOLEAN);
			this.ClockFailureField = new ClockFailure(tBasicTypeEnum.BOOLEAN);
			this.ClockNotSynchronizedField = new ClockNotSynchronized(tBasicTypeEnum.BOOLEAN);
			this.TimeAccuracyField = new TimeAccuracy(tBasicTypeEnum.Enum);
		}
		
		[Required]
		public LeapSecondsKnown LeapSecondsKnown
		{
			get
			{
				return this.LeapSecondsKnownField;
			}
			set
			{
				this.LeapSecondsKnownField = value;
			}
		}
		
		[Required]
		public ClockFailure ClockFailure
		{
			get
			{
				return this.ClockFailureField;
			}
			set
			{
				this.ClockFailureField = value;
			}
		}
		
		public ClockNotSynchronized ClockNotSynchronized
		{
			get
			{
				return this.ClockNotSynchronizedField;
			}
			set
			{
				this.ClockNotSynchronizedField = value;
			}
		}
		
		[Required]
		public TimeAccuracy TimeAccuracy
		{
			get
			{
				return this.TimeAccuracyField;
			}
			set
			{
				this.TimeAccuracyField = value;
			}
		}
	}
	
	/// <summary>
	/// The TimeStamp type shall represent a UTC time with the epoch of midnight (00:00:00) of 1970-01-01
	/// </summary>
	public class TimeStamp : SDIDADataTypeBDA
	{
		private SecondSinceEpoch SecondSinceEpochField;
		private FractionOfSecond FractionOfSecondField;
		private TimeQuality TimeQualityField;
		public TimeStamp (string iedType, string lnType)
		{
			this.name = "TimeStamp";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"TimeStamp";
			this.iedType = iedType;		
			this.SecondSinceEpochField = new SecondSinceEpoch(tBasicTypeEnum.FLOAT32);
			this.FractionOfSecondField = new FractionOfSecond(tBasicTypeEnum.INT24U);
			this.TimeQualityField = new TimeQuality(iedType, this.id);
		}
		
		[Required]
		public SecondSinceEpoch SecondSinceEpoch
		{
			get
			{
				return this.SecondSinceEpochField;
			}
			set
			{
				this.SecondSinceEpochField = value;
			}
		}
		
		[Required]
		public FractionOfSecond FractionOfSecond			
		{
			get
			{
				return this.FractionOfSecondField;
			}
			set
			{
				this.FractionOfSecondField = value;
			}
		}
		
		[Required]
		public TimeQuality TimeQuality	
		{
			get
			{
				return this.TimeQualityField;
			}
			set
			{
				this.TimeQualityField = value;
			}
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
		public orCat(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "orCat";
			this.bType = basicTypeEnum;
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
	/// The originator identification shall show the address of the originator who caused the change
	/// of the value. 
	/// </summary>
	public class orIdent : DADataType
	{
		public orIdent(tBasicTypeEnum basicTypeEnum)
		{
			this.name = "orIdent";
			this.bType = basicTypeEnum;
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
}		
