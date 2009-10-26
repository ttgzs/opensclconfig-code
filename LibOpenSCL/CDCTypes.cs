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
	/// This class defines the common data attribute types that are defined for his use in the ACD
	/// common data class. 
	/// </summary>
	public class  ACD : DOData
	{
		private cdcName cdcNameField;
		private cdcNs cdcNsField;
		private d dField;
		private DataName DataNameField;
		private dataNs dataNsField;
		private dirGeneral dirGeneralField;
		private dirNeut dirNeutField;
		private dirPhsA dirPhsAField;
		private dirPhsB dirPhsBField;
		private dirPhsC dirPhsCField;
		private dU dUField;
		private general generalField;
		private neut neutField;
		private phsA phsAField;
		private phsB phsBField;
		private phsC phsCField;
		private q  qField;
		private t tField;
		
		/// <summary>
		/// Directional protection activation information (ACD)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN. 
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public ACD(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "ACD";
			this.id = this.type;
			this.iedType = iedType;				
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);
			this.dirGeneralField = new dirGeneral(tBasicTypeEnum.Enum);
			this.dirNeutField = new dirNeut(tBasicTypeEnum.Enum);
			this.dirPhsAField = new dirPhsA(tBasicTypeEnum.Enum);
			this.dirPhsBField = new dirPhsB(tBasicTypeEnum.Enum);
			this.dirPhsCField = new dirPhsC(tBasicTypeEnum.Enum);
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.generalField = new general(tBasicTypeEnum.BOOLEAN);
			this.neutField = new neut(tBasicTypeEnum.BOOLEAN);
			this.phsAField = new phsA(tBasicTypeEnum.BOOLEAN);
			this.phsBField = new phsB(tBasicTypeEnum.BOOLEAN);
			this.phsCField = new phsC(tBasicTypeEnum.BOOLEAN);
			this.qField = new q(tBasicTypeEnum.Quality);
			this.tField = new t(tBasicTypeEnum.Timestamp);
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Required]		
		[Browsable(false)]
		public dirGeneral dirGeneral
		{
			get
			{
				return this.dirGeneralField;
			}
			set
			{
				this.dirGeneralField = value;
			}
		}		
		
		[Browsable(false)]
		public dirNeut dirNeut
		{
			get
			{
				return this.dirNeutField;
			}
			set
			{
				this.dirNeutField = value;
			}
		}
				
		[Browsable(false)]
		public dirPhsA dirPhsA 
		{
			get
			{
				return this.dirPhsAField;
			}
			set
			{
				this.dirPhsAField = value;
			}
		}	
		
		[Browsable(false)]
		public dirPhsB dirPhsB
		{
			get
			{
				return this.dirPhsBField;
			}
			set
			{
				this.dirPhsBField = value;
			}
		}
				
		[Browsable(false)]
		public dirPhsC dirPhsC
		{
			get
			{
				return this.dirPhsCField;
			}
			set
			{
				this.dirPhsCField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU 
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public general general
		{
			get
			{
				return this.generalField;
			}
			set
			{
				this.generalField = value;
			}
		}
		
		[Browsable(false)]
		public neut neut
		{
			get
			{
				return this.neutField;
			}
			set
			{
				this.neutField = value;
			}
		}
		
		[Browsable(false)]
		public phsA phsA
		{
			get
			{
				return this.phsAField;
			}
			set
			{
				this.phsAField = value;
			}
		}
		
		[Browsable(false)]
		public phsB phsB 
		{
			get
			{
				return this.phsBField;
			}
			set
			{
				this.phsBField  = value;
			}
		}
		
		[Browsable(false)]
		public phsC phsC
		{
			get
			{
				return this.phsCField;
			}
			set
			{
				this.phsCField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public q q
		{
			get
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public t t
		{
			get
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the ACT
	/// common data class. 
	/// </summary>
	public class  ACT : DOData
	{		
		private cdcName cdcNameField;
		private cdcNs cdcNsField;
		private d dField;
		private DataName DataNameField;
		private dataNs dataNsField;
		private dU dUField;
		private general generalField;
		private neut neutField;
		private operTm operTmField;
		private phsA phsAField;
		private phsB phsBField;
		private phsC phsCField;
		private q  qField;
		private t tField;	
		
		/// <summary>
		/// Protection activation information (ACT)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN.
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public ACT(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "ACT";
			this.id = this.type;
			this.iedType = iedType;				
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.generalField = new general(tBasicTypeEnum.BOOLEAN);
			this.neutField = new neut(tBasicTypeEnum.BOOLEAN);
			this.operTmField = new operTm(tBasicTypeEnum.Timestamp);
			this.phsAField = new phsA(tBasicTypeEnum.BOOLEAN);
			this.phsBField = new phsB(tBasicTypeEnum.BOOLEAN);
			this.phsCField = new phsC(tBasicTypeEnum.BOOLEAN);
			this.qField = new q(tBasicTypeEnum.Quality);
			this.tField = new t(tBasicTypeEnum.Timestamp);
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU 
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public general general
		{
			get
			{
				return this.generalField;
			}
			set
			{
				this.generalField = value;
			}
		}
		
		[Browsable(false)]
		public neut neut
		{
			get
			{
				return this.neutField;
			}
			set
			{
				this.neutField = value;
			}
		}
		
		[Browsable(false)]
		public operTm operTm
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
		public phsA phsA
		{
			get
			{
				return this.phsAField;
			}
			set
			{
				this.phsAField = value;
			}
		}
		
		[Browsable(false)]
		public phsB phsB 
		{
			get
			{
				return this.phsBField;
			}
			set
			{
				this.phsBField  = value;
			}
		}
		
		[Browsable(false)]
		public phsC phsC
		{
			get
			{
				return this.phsCField;
			}
			set
			{
				this.phsCField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public q q
		{
			get
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public t t
		{
			get
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		}		
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the APC
	/// common data class.
	/// </summary>
	public class  APC : DOData
	{	
		private cdcName cdcNameField;
		private cdcNs cdcNsField;
		private ctlModel ctlModelField;
		private d dField;
		private DataName DataNameField;
		private dataNs dataNsField;			
		private dU dUField;
		private maxVal maxValField;
		private minVal minValField;
		private operTm operTmField;
		private origin originField;
		private q qField;
		private setMag2 setMag2Field;
		private stepSize stepSizeField;
		private sVC sVCField;
		private t tField;
		private units unitsField;
		
		/// <summary>
		/// Controllable analogue set point information (APC)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN.
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public APC(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "APC";
			this.id = this.type;
			this.iedType = iedType;				
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);
			this.ctlModelField = new ctlModel(iedType, this.id);
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);			
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);			
			this.maxValField = new maxVal(iedType, this.id);
			AnalogueValue AnalogueValueField = new AnalogueValue(iedType, this.maxValField.id);
			this.maxValField.SetLinkSDIDADataTypeBDA(AnalogueValueField);			
			this.minValField = new minVal(iedType, this.id);
			AnalogueValueField = new AnalogueValue(iedType, this.minValField.id);	
			this.minValField.SetLinkSDIDADataTypeBDA(AnalogueValueField);
			this.operTmField = new operTm(tBasicTypeEnum.Timestamp);
			this.originField = new origin(iedType, this.id);		
			this.qField = new q(tBasicTypeEnum.Quality);	
			this.setMag2Field = new setMag2(iedType, this.id);
			this.stepSizeField = new stepSize(iedType, this.id);
			this.sVCField = new sVC(iedType, this.id);
			this.tField = new t(tBasicTypeEnum.Timestamp);
			this.unitsField = new units(iedType, this.id);
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public ctlModel ctlModel
		{
			get
			{
				return this.ctlModelField;
			}
			set
			{
				this.ctlModelField = value;
			}
		}
		
		[Browsable(false)]
		public d d
		{		
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU 
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Browsable(false)]
		public maxVal maxVal
		{
			get 
			{
				return this.maxValField;
			}
			set
			{
				this.maxValField = value;
			}
		}
		
		[Browsable(false)]
		public minVal minVal
		{
			get 
			{
				return this.minValField;
			}
			set
			{
				this.minValField = value;
			}
		}
		
		[Browsable(false)]
		public operTm operTm
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
		public q q
		{
			get 
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public setMag2 setMag2		
		{
			get 
			{
				return this.setMag2Field;
			}
			set
			{
				this.setMag2Field = value;
			}
		}
		
		[Browsable(false)]
		public stepSize stepSize
		{
			get 
			{
				return this.stepSizeField;
			}
			set
			{
				this.stepSizeField = value;
			}
		}
		
		[Browsable(false)]
		public sVC sVC
		{
			get 
			{
				return this.sVCField;
			}
			set
			{
				this.sVCField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public t t
		{
			get 
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		}
		
		[Browsable(false)]
		public units units
		{
			get 
			{
				return this.unitsField;
			}
			set
			{
				this.unitsField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the ASG
	/// common data class.
	/// </summary>
	public class  ASG : DOData
	{	
		private cdcName cdcNameField;
		private cdcNs cdcNsField;
		private d dField;
		private DataName DataNameField;
		private dataNs dataNsField;
		private dU dUField;
		private maxVal maxValField;
		private minVal minValField;		
		private setMag setMagField;
		private setMag2 setMag2Field;
		private stepSize stepSizeField;
		private sVC sVCField;		
		private units unitsField;
		
		/// <summary>
		/// Analogue setting (ASG)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN. 
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public ASG(string name, string lnType, string iedType) : base (name, lnType+name)
		{			
			this.cdc = "ASG";
			this.id = this.type;
			this.iedType = iedType;					
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);
			this.dUField = new dU(tBasicTypeEnum.Unicode255);			
			this.maxValField = new maxVal(iedType, this.id);
			AnalogueValue AnalogueValueField = new AnalogueValue(iedType, this.maxValField.id);
			this.maxValField.SetLinkSDIDADataTypeBDA(AnalogueValueField);			
			this.minValField = new minVal(iedType, this.id);
			AnalogueValueField = new AnalogueValue(iedType, this.minValField.id);	
			this.minValField.SetLinkSDIDADataTypeBDA(AnalogueValueField);			
			this.setMagField = new setMag(iedType, this.id);
			this.setMag2Field = new setMag2(iedType, this.id);
			this.stepSizeField = new stepSize(iedType, this.id);
			this.sVCField = new sVC(iedType, this.id);			
			this.unitsField = new units(iedType, this.id);
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU 
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Browsable(false)]
		public maxVal maxVal
		{
			get 
			{
				return this.maxValField;
			}
			set
			{
				this.maxValField = value;
			}
		}
		
		[Browsable(false)]
		public minVal minVal
		{
			get 
			{
				return this.minValField;
			}
			set
			{
				this.minValField = value;
			}
		}
		
		[Browsable(false)]
		public setMag setMag		
		{
			get 
			{
				return this.setMagField;
			}
			set
			{
				this.setMagField = value;
			}
		}
		
		[Browsable(false)]
		public setMag2 setMag2
		{
			get 
			{
				return this.setMag2Field;
			}
			set
			{
				this.setMag2Field = value;
			}
		}
		
		[Browsable(false)]
		public stepSize stepSize
		{
			get 
			{
				return this.stepSizeField;
			}
			set
			{
				this.stepSizeField = value;
			}
		}
		
		[Browsable(false)]
		public sVC sVC
		{
			get 
			{
				return this.sVCField;
			}
			set
			{
				this.sVCField = value;
			}
		}	
		
		[Browsable(false)]
		public units units
		{
			get 
			{
				return this.unitsField;
			}
			set
			{
				this.unitsField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the BCR
	/// common data class.
	/// </summary>
	public class  BCR : DOData
	{
		private actVal actValField;
		private cdcName cdcNameField;
		private cdcNs cdcNsField;
		private d dField;
		private DataName DataNameField;
		private dataNs dataNsField;
		private dU dUField;
		private frEna frEnaField;
		private frPd frPdField;
		private frRs frRsField;
		private frTm frTmField;
		private frVal frValField;
		private pulsQty pulsQtyField;
		private q qField;
		private strTm strTmField;
		private t tField;
		private units unitsField;
		
		/// <summary>
		/// Binary counter reading (BCR).
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN.
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public BCR(string name, string lnType, string iedType) : base (name, lnType+name)
		{			
			this.cdc = "BCR";
			this.id = this.type;
			this.iedType = iedType;				
			this.actValField = new actVal(tBasicTypeEnum.INT128);
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.frEnaField = new frEna(tBasicTypeEnum.BOOLEAN);
			this.frPdField = new frPd(tBasicTypeEnum.INT32);
			this.frRsField = new frRs(tBasicTypeEnum.BOOLEAN);
			this.frTmField = new frTm(tBasicTypeEnum.Timestamp);
			this.frValField = new frVal(tBasicTypeEnum.INT128);
			this.pulsQtyField = new pulsQty(tBasicTypeEnum.FLOAT32);
			this.qField = new q(tBasicTypeEnum.Quality);	
			this.strTmField = new strTm(tBasicTypeEnum.Timestamp);
			this.tField = new t(tBasicTypeEnum.Timestamp);
			this.unitsField = new units(iedType, this.id);
		}
		
		[Required]
		[Browsable(false)]
		public actVal actVal
		{
			get 
			{
				return this.actValField;
			}
			set
			{
				this.actValField = value;
			}
		}	
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU 
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Browsable(false)]
		public frEna frEna
		{
			get
			{
				return this.frEnaField;
			}
			set
			{
				this.frEnaField = value;
			}
		}
		
		[Browsable(false)]
		public frPd frPd
		{
			get
			{
				return this.frPdField;
			}
			set
			{
				this.frPdField = value;
			}
		}
		
		[Browsable(false)]
		public frRs frRs
		{
			get
			{
				return this.frRsField;
			}
			set
			{
				this.frRsField = value;
			}
		}
		
		[Browsable(false)]
		public frTm frTm
		{
			get
			{
				return this.frTmField;
			}
			set
			{
				this.frTmField = value;
			}
		}
		
		[Browsable(false)]
		public frVal frVal
		{
			get
			{
				return this.frValField;
			}
			set
			{
				this.frValField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public pulsQty pulsQty
		{
			get
			{
				return this.pulsQtyField;
			}
			set
			{
				this.pulsQtyField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public q q
		{
			get 
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
		[Browsable(false)]
		public strTm strTm
		{
			get
			{
				return this.strTmField;
			}
			set
			{
				this.strTmField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public t t
		{
			get 
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		}
		
		[Browsable(false)]
		public units units
		{
			get 
			{
				return this.unitsField;
			}
			set
			{
				this.unitsField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the BSC
	/// common data class.
	/// </summary>
	public class  BSC : DOData
	{
		private cdcName cdcNameField;
		private cdcNs cdcNsField;
		private ctlModel ctlModelField;
		private ctlNum ctlNumField;
		private ctlVal ctlValField;
		private d dField;
		private DataName DataNameField;
		private dataNs dataNsField;			
		private dU dUField;
		private maxVal maxValField;
		private minVal minValField;
		private operTm operTmField;
		private origin originField;
		private persistent persistentField;
		private q qField;
		private sboClass sboClassField;
		private sboTimeout sboTimeoutField;
		private stepSize stepSizeField;
		private stSeld stSeldField;
		private subEna subEnaField;
		private subID subIDField;
		private subQ subQField;
		private subVal subValField;
		private t tField;
		private valWTr valWTrField;
		
		/// <summary>
		/// Binary controlled step position information (BSC).
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN.
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public BSC(string name, string lnType, string iedType) : base (name, lnType+name)
		{			
			this.cdc = "BSC";
			this.id = this.type;
			this.iedType = iedType;				
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);
			this.ctlModelField = new ctlModel(iedType, this.id);
			this.ctlNumField = new ctlNum(tBasicTypeEnum.INT8U);
			this.ctlValField = new ctlVal(tBasicTypeEnum.Enum);			
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);			
			this.dUField = new dU(tBasicTypeEnum.Unicode255);						
			this.maxValField = new maxVal(tBasicTypeEnum.INT8);									
			this.minValField = new minVal(tBasicTypeEnum.INT8);			
			this.operTmField = new operTm(tBasicTypeEnum.Timestamp);
			this.originField = new origin(iedType, this.id);
			this.persistentField = new persistent(tBasicTypeEnum.BOOLEAN);
			this.qField = new q(tBasicTypeEnum.Quality);	
			this.sboClassField = new sboClass(iedType, this.id);
			this.sboTimeoutField = new sboTimeout(tBasicTypeEnum.INT32U);
			this.stepSizeField = new stepSize(tBasicTypeEnum.INT8U);
			this.stSeldField = new stSeld(tBasicTypeEnum.BOOLEAN);
			this.subEnaField = new subEna(tBasicTypeEnum.BOOLEAN);
			this.subIDField = new subID(tBasicTypeEnum.VisString64);
			this.subQField = new subQ(tBasicTypeEnum.Quality);
			this.subValField = new subVal(iedType, this.id);
			ValWithTrans ValWithTransField = new ValWithTrans(iedType, this.subValField.id);
			this.subValField.SetLinkSDIDADataTypeBDA(ValWithTransField);
			this.tField = new t(tBasicTypeEnum.Timestamp);			
			this.valWTrField = new valWTr(iedType, this.id);
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public ctlModel ctlModel
		{
			get
			{
				return this.ctlModelField;
			}
			set
			{
				this.ctlModelField = value;
			}
		}
		
		[Browsable(false)]
		public ctlNum ctlNum
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
		
		[Browsable(false)]
		public ctlVal ctlVal
		{
			get
			{
				return this.ctlValField;
			}
			set
			{
				this.ctlValField = value;
			}
		}
		
		[Browsable(false)]
		public d d
		{		
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU 
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Browsable(false)]
		public maxVal maxVal
		{
			get 
			{
				return this.maxValField;
			}
			set
			{
				this.maxValField = value;
			}
		}
		
		[Browsable(false)]
		public minVal minVal
		{
			get 
			{
				return this.minValField;
			}
			set
			{
				this.minValField = value;
			}
		}
		
		[Browsable(false)]
		public operTm operTm
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
		public persistent persistent
		{
			get 
			{
				return this.persistentField;
			}
			set
			{
				this.persistentField = value;
			}
		}
		
		[Browsable(false)]
		public q q
		{
			get 
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
		[Browsable(false)]
		public sboClass sboClass 
		{
			get 
			{
				return this.sboClassField;
			}
			set
			{
				this.sboClassField = value;
			}
		}
		
		[Browsable(false)]
		public sboTimeout sboTimeout
		{
			get 
			{
				return this.sboTimeoutField;
			}
			set
			{
				this.sboTimeoutField = value;
			}
		}
		
		[Browsable(false)]
		public stepSize stepSize
		{
			get 
			{
				return this.stepSizeField;
			}
			set
			{
				this.stepSizeField = value;
			}
		}
		
		[Browsable(false)]
		public subEna subEna
		{
			get 
			{
				return this.subEnaField;
			}
			set
			{
				this.subEnaField = value;
			}
		}
		
		[Browsable(false)]
		public subID subID
		{
			get 
			{
				return this.subIDField;
			}
			set
			{
				this.subIDField = value;
			}
		}
		
		[Browsable(false)]
		public subQ subQ
		{
			get 
			{
				return this.subQField;
			}
			set
			{
				this.subQField = value;
			}
		}
		
		[Browsable(false)]
		public subVal subVal
		{
			get 
			{
				return this.subValField;
			}
			set
			{
				this.subValField = value;
			}
		}
		
		[Browsable(false)]
		public t t
		{
			get 
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		}
		
		[Browsable(false)]
		public valWTr valWTr
		{
			get 
			{
				return this.valWTrField;
			}
			set
			{
				this.valWTrField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the CMV
	/// common data class.
	/// </summary>
	public class  CMV : DOData
	{
		private angRef angRefField;
		private angSVC angSVCField;
		private cdcName cdcNameField;
		private cdcNs cdcNsField;
		private cVal cValField;
		private d dField;
		private DataName DataNameField;
		private dataNs dataNsField;
		private db dbField;
		private dU dUField;
		private instCVal instCValField;
		private magSVC magSVCField;
		private q qField;
		private range rangeField;
		private rangeC rangeCField;
		private smpRate smpRateField;
		private subCVal subCValField;
		private subEna subEnaField;
		private subID subIDField;
		private subQ subQField;
		private t tField;
		private units unitsField;
		private zeroDb zeroDbField;
		
		/// <summary>
		/// Complex measured value (CMV)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN.
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public CMV(string name, string lnType, string iedType) : base (name, lnType+name)
		{			
			this.cdc = "CMV";
			this.id = this.type;
			this.iedType = iedType;			
			this.angRefField = new angRef(tBasicTypeEnum.Enum);
			this.angSVCField = new angSVC(iedType, this.id);
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);
			this.cValField = new cVal(iedType, this.id);
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);
			this.dbField = new db(tBasicTypeEnum.INT32U);
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.instCValField = new instCVal(iedType, this.id);
			this.magSVCField = new magSVC(iedType, this.id);
			this.qField = new q(tBasicTypeEnum.Quality);					
			this.rangeField = new range(tBasicTypeEnum.Enum);
			this.rangeCField = new rangeC(iedType, this.id);
			this.smpRateField = new smpRate(tBasicTypeEnum.INT32U);
			this.subCValField = new subCVal(iedType, this.id);
			this.subEnaField = new subEna(tBasicTypeEnum.BOOLEAN);
			this.subIDField = new subID(tBasicTypeEnum.VisString64);
			this.subQField = new subQ(tBasicTypeEnum.Quality);
			this.tField = new t(tBasicTypeEnum.Timestamp);
			this.unitsField = new units(iedType, this.id);
			this.zeroDbField = new zeroDb(tBasicTypeEnum.INT32U);
		}
		
		[Browsable(false)]
		public angRef angRef 
		{
			get
			{
				return this.angRefField;
			}
			set
			{
				this.angRefField = value;
			}
		}
		
		[Browsable(false)]
		public angSVC angSVC
		{
			get
			{
				return this.angSVCField;
			}
			set
			{
				this.angSVCField = value;
			}
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public cVal cVal
		{
			get
			{
				return this.cValField;
			}
			set
			{
				this.cValField = value;
			}
		}
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public db db
		{
			get
			{
				return this.dbField;
			}
			set
			{
				this.dbField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU 
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Browsable(false)]
		public instCVal instCVal
		{
			get
			{
				return this.instCValField;
			}
			set
			{
				this.instCValField = value;
			}
		}
		
		[Browsable(false)]
		public magSVC magSVC
		{
			get
			{
				return this.magSVCField;
			}
			set
			{
				this.magSVCField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public q q
		{
			get 
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
		[Browsable(false)]
		public range range
		{
			get 
			{
				return this.rangeField;
			}
			set
			{
				this.rangeField = value;
			}
		}
		
		[Browsable(false)]
		public rangeC rangeC 
		{
			get 
			{
				return this.rangeCField;
			}
			set
			{
				this.rangeCField = value;
			}
		}
		
		[Browsable(false)]
		public smpRate smpRate
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
		
		[Browsable(false)]
		public subCVal subCVal
		{
			get 
			{
				return this.subCValField;
			}
			set
			{
				this.subCValField = value;
			}
		}
		
		[Browsable(false)]
		public subEna subEna
		{
			get 
			{
				return this.subEnaField;
			}
			set
			{
				this.subEnaField = value;
			}
		}
		
		[Browsable(false)]
		public subID subID 
		{
			get 
			{
				return this.subIDField;
			}
			set
			{
				this.subIDField = value;
			}
		}
		
		[Browsable(false)]
		public subQ subQ
		{
			get 
			{
				return this.subQField;
			}
			set
			{
				this.subQField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public t t
		{
			get 
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		}
		
		[Browsable(false)]
		public units units
		{
			get 
			{
				return this.unitsField;
			}
			set
			{
				this.unitsField = value;
			}
		}
		
		[Browsable(false)]
		public zeroDb zeroDb
		{
			get 
			{
				return this.zeroDbField;
			}
			set
			{
				this.zeroDbField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the CSD
	/// common data class.
	/// </summary>
	public class  CSD : DOData
	{
		private cdcName cdcNameField;
		private cdcNs cdcNsField;
		private crvPts crvPtsField;
		private d dField;
		private DataName DataNameField;
		private dataNs dataNsField;
		private dU dUField;
		private numPts numPtsField;
		private xD xDField;
		private xUnit xUnitField;
		private yD yDField;
		private yUnit yUnitField;
		
		/// <summary>
		/// Curve shape description (CSD)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN.  
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public CSD(string name, string lnType, string iedType) : base (name, lnType+name)
		{			
			this.cdc = "CSD";
			this.id = this.type;
			this.iedType = iedType;				
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);
			this.crvPtsField = new crvPts(iedType, this.id);
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.numPtsField = new numPts(tBasicTypeEnum.INT16U);			
			this.xDField = new xD(tBasicTypeEnum.VisString255);
			this.xUnitField = new xUnit(iedType, this.id);
			this.yDField = new yD(tBasicTypeEnum.VisString255);
			this.yUnitField = new yUnit(iedType, this.id);
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public crvPts crvPts 
		{
			get
			{
				return this.crvPtsField;
			}
			set
			{
				this.crvPtsField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}	
		
		[Browsable(false)]
		public dU dU 
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public numPts numPts
		{
			get
			{
				return this.numPtsField;
			}
			set
			{
				this.numPtsField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public xD xD
		{
			get
			{
				return this.xDField;
			}
			set
			{
				this.xDField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public xUnit xUnit 
		{
			get
			{
				return this.xUnitField;
			}
			set
			{
				this.xUnitField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public yD yD 
		{
			get
			{
				return this.yDField;
			}
			set
			{
				this.yDField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public yUnit yUnit
		{
			get
			{
				return this.yUnitField;
			}
			set
			{
				this.yUnitField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the CURVE
	/// common data class.
	/// </summary>
	public class  CURVE : DOData
	{
		private cdcName cdcNameField;
		private cdcNs cdcNsField;
		private d dField;
		private DataName DataNameField;
		private dataNs dataNsField;
		private dU dUField;
		private setCharact setCharactField;
		private setCharact2 setCharact2Field;
		private setParA setParAField;
		private setParA2 setParA2Field;
		private setParB setParBField;
		private setParB2 setParB2Field;
		private setParC setParCField;
		private setParC2 setParC2Field;
		private setParD setParDField;
		private setParD2 setParD2Field;
		private setParE setParEField;
		private setParE2 setParE2Field;
		private setParF setParFField;
		private setParF2 setParF2Field;
		
		/// <summary>
		/// Setting curve (CURVE)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN. 
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public CURVE(string name, string lnType, string iedType) : base (name, lnType+name)
		{			
			this.cdc = "CURVE";
			this.id = this.type;
			this.iedType = iedType;				
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.setCharactField = new setCharact(tBasicTypeEnum.VisString255);
			this.setCharact2Field = new setCharact2(tBasicTypeEnum.VisString255);
			this.setParAField = new setParA(tBasicTypeEnum.FLOAT32);
			this.setParA2Field = new setParA2(tBasicTypeEnum.FLOAT32);
			this.setParBField = new setParB(tBasicTypeEnum.FLOAT32);
			this.setParB2Field = new setParB2(tBasicTypeEnum.FLOAT32);
			this.setParCField = new setParC(tBasicTypeEnum.FLOAT32);
			this.setParC2Field = new setParC2(tBasicTypeEnum.FLOAT32);
			this.setParDField = new setParD(tBasicTypeEnum.FLOAT32);
			this.setParD2Field = new setParD2(tBasicTypeEnum.FLOAT32);
			this.setParEField = new setParE(tBasicTypeEnum.FLOAT32);
			this.setParE2Field = new setParE2(tBasicTypeEnum.FLOAT32);
			this.setParFField = new setParF(tBasicTypeEnum.FLOAT32);
			this.setParF2Field = new setParF2(tBasicTypeEnum.FLOAT32);
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU 
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Browsable(false)]
		public setCharact setCharact
		{
			get
			{
				return this.setCharactField;
			}
			set
			{
				this.setCharactField = value;
			}
		}
		
		[Browsable(false)]
		public setCharact2 setCharact2
		{
			get
			{
				return this.setCharact2Field;
			}
			set
			{
				this.setCharact2Field = value;
			}
		}
		
		[Browsable(false)]
		public setParA setParA
		{
			get
			{
				return this.setParAField;
			}
			set
			{
				this.setParAField = value;
			}
		}
		
		[Browsable(false)]
		public setParA2 setParA2
		{
			get
			{
				return this.setParA2Field;
			}
			set
			{
				this.setParA2Field = value;
			}
		}
		
		[Browsable(false)]
		public setParB setParB
		{
			get
			{
				return this.setParBField;
			}
			set
			{
				this.setParBField = value;
			}
		}
		
		[Browsable(false)]
		public setParB2 setParB2
		{
			get
			{
				return this.setParB2Field;
			}
			set
			{
				this.setParB2Field = value;
			}
		}
		
		[Browsable(false)]
		public setParC setParC
		{
			get
			{
				return this.setParCField;
			}
			set
			{
				this.setParCField = value;
			}
		}
		
		[Browsable(false)]
		public setParC2 setParC2
		{
			get
			{
				return this.setParC2Field;
			}
			set
			{
				this.setParC2Field = value;
			}
		}
		
		[Browsable(false)]
		public setParD setParD
		{
			get
			{
				return this.setParDField;
			}
			set
			{
				this.setParDField = value;
			}
		}
		
		[Browsable(false)]
		public setParD2 setParD2
		{
			get
			{
				return this.setParD2Field;
			}
			set
			{
				this.setParD2Field = value;
			}
		}
		
		[Browsable(false)]
		public setParE setParE
		{
			get
			{
				return this.setParEField;
			}
			set
			{
				this.setParEField = value;
			}
		}
		
		[Browsable(false)]
		public setParE2 setParE2
		{
			get
			{
				return this.setParE2Field;
			}
			set
			{
				this.setParE2Field = value;
			}
		}
		
		[Browsable(false)]
		public setParF setParF
		{
			get
			{
				return this.setParFField;
			}
			set
			{
				this.setParFField = value;
			}
		}
		
		[Browsable(false)]
		public setParF2 setParF2
		{
			get
			{
				return this.setParF2Field;
			}
			set
			{
				this.setParF2Field = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the DEL
	/// common data class.
	/// </summary>
	public class  DEL : DOData
	{
		private angRef angRefField;		
		private cdcName cdcNameField;
		private cdcNs cdcNsField;		
		private d dField;
		private DataName DataNameField;
		private dataNs dataNsField;		
		private dU dUField;
		private phsAB phsABField;
		private phsBC phsBCField;
		private phsCA phsCAField;
		
		/// <summary>
		/// Phase to phase related measured values of a three phase system (DEL)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN.
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public DEL(string name, string lnType, string iedType) : base (name, lnType+name)
		{			
			this.cdc = "DEL";
			this.id = this.type;
			this.iedType = iedType;				
			this.angRefField = new angRef(tBasicTypeEnum.Enum);			
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);			
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);			
			this.dUField = new dU(tBasicTypeEnum.Unicode255);			
			this.phsABField = new phsAB(iedType, this.id);
			CMV CMVField = new CMV("", this.phsABField.id, iedType);
			this.phsABField.SetLinkDOData(CMVField);			
			this.phsBCField = new phsBC(iedType, this.id);
			CMVField = new CMV("", this.phsBCField.id, iedType);
			this.phsBCField.SetLinkDOData(CMVField);			
			this.phsCAField = new phsCA(iedType, this.id);
			CMVField = new CMV("", this.phsCAField.id, iedType);
			this.phsCAField.SetLinkDOData(CMVField);
		}
		
		[Browsable(false)]
		public angRef angRef 
		{
			get
			{
				return this.angRefField;
			}
			set
			{
				this.angRefField = value;
			}
		}		
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}	
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU 
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Browsable(false)]
		public phsAB phsAB 
		{
			get 
			{
				return this.phsABField;
			}
			set
			{
				this.phsABField = value;
			}
		}
		
		[Browsable(false)]
		public phsBC phsBC 
		{
			get 
			{
				return this.phsBCField;
			}
			set
			{
				this.phsBCField = value;
			}
		}
		
		[Browsable(false)]
		public phsCA phsCA
		{
			get 
			{
				return this.phsCAField;
			}
			set
			{
				this.phsCAField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the DPC
	/// common data class.
	/// </summary>
	public class  DPC : DOData
	{
		private cdcName cdcNameField;
		private cdcNs cdcNsField;
		private ctlModel ctlModelField;
		private ctlNum ctlNumField;
		private ctlVal ctlValField;
		private d dField;
		private DataName DataNameField;
		private dataNs dataNsField;			
		private dU dUField;		
		private operTm operTmField;
		private origin originField;
		private PulseConfig PulseConfigField;
		private q qField;
		private sboClass sboClassField;
		private sboTimeout sboTimeoutField;		
		private stSeld stSeldField;
		private stVal stValField;
		private subEna subEnaField;
		private subID subIDField;
		private subQ subQField;
		private subVal subValField;		
		private t tField;	
		
		/// <summary>
		/// Controllable double point (DPC)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN.
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public DPC(string name, string lnType, string iedType) : base (name, lnType+name)
		{			
			this.cdc = "DPC";
			this.id = this.type;
			this.iedType = iedType;				
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);
			this.ctlModelField = new ctlModel(iedType, this.id);
			this.ctlNumField = new ctlNum(tBasicTypeEnum.INT8U);
			this.ctlValField = new ctlVal(tBasicTypeEnum.BOOLEAN);
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);			
			this.dUField = new dU(tBasicTypeEnum.Unicode255);			
			this.operTmField = new operTm(tBasicTypeEnum.Timestamp);
			this.originField = new origin(iedType, this.id);		
			this.PulseConfigField = new PulseConfig(iedType, this.id);
			this.qField = new q(tBasicTypeEnum.Quality);
			this.sboClassField = new sboClass(iedType, this.id);
			this.sboTimeoutField = new sboTimeout(tBasicTypeEnum.INT32U);			
			this.stSeldField = new stSeld(tBasicTypeEnum.BOOLEAN);
			this.stValField = new stVal(tBasicTypeEnum.Enum);
			this.subEnaField = new subEna(tBasicTypeEnum.BOOLEAN);
			this.subIDField = new subID(tBasicTypeEnum.VisString64);
			this.subQField = new subQ(tBasicTypeEnum.Quality);
			this.subValField = new subVal(tBasicTypeEnum.Enum);
			this.tField = new t(tBasicTypeEnum.Timestamp);
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public ctlModel ctlModel
		{
			get
			{
				return this.ctlModelField;
			}
			set
			{
				this.ctlModelField = value;
			}
		}
		
		[Browsable(false)]
		public ctlNum ctlNum
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
		
		[Browsable(false)]
		public ctlVal ctlVal
		{
			get
			{
				return this.ctlValField;
			}
			set
			{
				this.ctlValField = value;
			}
		}
		
		[Browsable(false)]
		public d d
		{		
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU 
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}	
		
		[Browsable(false)]
		public operTm operTm
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
		
		[Browsable(false)]
		public PulseConfig PulseConfig
		{
			get
			{
				return this.PulseConfigField;
			}
			set
			{
				this.PulseConfigField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public q q
		{
			get 
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
		[Browsable(false)]
		public sboClass sboClass 
		{
			get 
			{
				return this.sboClassField;
			}
			set
			{
				this.sboClassField = value;
			}
		}
		
		[Browsable(false)]
		public sboTimeout sboTimeout
		{
			get 
			{
				return this.sboTimeoutField;
			}
			set
			{
				this.sboTimeoutField = value;
			}
		}
		
		[Browsable(false)]
		public stSeld stSeld
		{
			get 
			{
				return this.stSeldField;
			}
			set
			{
				this.stSeldField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public stVal stVal
		{
			get 
			{
				return this.stValField;
			}
			set
			{
				this.stValField = value;
			}
		}
		
		[Browsable(false)]
		public subEna subEna
		{
			get 
			{
				return this.subEnaField;
			}
			set
			{
				this.subEnaField = value;
			}
		}
		
		[Browsable(false)]
		public subID subID
		{
			get 
			{
				return this.subIDField;
			}
			set
			{
				this.subIDField = value;
			}
		}
		
		[Browsable(false)]
		public subQ subQ
		{
			get 
			{
				return this.subQField;
			}
			set
			{
				this.subQField = value;
			}
		}
		
		[Browsable(false)]
		public subVal subVal
		{
			get 
			{
				return this.subValField;
			}
			set
			{
				this.subValField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public t t
		{
			get 
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the DPL
	/// common data class.
	/// </summary>
	public class  DPL : DOData
	{
		private cdcName cdcNameField;
		private cdcNs cdcNsField;		
		private DataName DataNameField;
		private dataNs dataNsField;
		private hwRev hwRevField;
		private location locationField;
		private model modelField;
		private serNum serNumField;
		private swRev swRevField;
		private vendor vendorField;
		
		/// <summary>
		/// Device name plate (DPL)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN.
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public DPL(string name, string lnType, string iedType) : base (name, lnType+name)
		{			
			this.cdc = "DPL";
			this.id = this.type;
			this.iedType = iedType;				
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);			
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);
			this.hwRevField = new hwRev(tBasicTypeEnum.VisString255);
			this.locationField = new location(tBasicTypeEnum.VisString255);
			this.modelField = new model(tBasicTypeEnum.VisString255);
			this.serNumField = new serNum(tBasicTypeEnum.VisString255);
			this.swRevField = new swRev(tBasicTypeEnum.VisString255);
			this.vendorField = new vendor(tBasicTypeEnum.VisString255);
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}		
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public hwRev hwRev
		{
			get
			{
				return this.hwRevField;
			}
			set
			{
				this.hwRevField = value;
			}
		}
		
		[Browsable(false)]
		public location location
		{
			get
			{
				return this.locationField;
			}
			set
			{
				this.locationField = value;
			}
		}
		
		[Browsable(false)]
		public model model
		{
			get
			{
				return this.modelField;
			}
			set
			{
				this.modelField = value;
			}
		}
		
		[Browsable(false)]
		public serNum serNum
		{
			get
			{
				return this.serNumField;
			}
			set
			{
				this.serNumField = value;
			}
		}
		
		[Browsable(false)]
		public swRev swRev
		{
			get
			{
				return this.swRevField;
			}
			set
			{
				this.swRevField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public vendor vendor 
		{
			get
			{
				return this.vendorField;
			}
			set
			{
				this.vendorField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the DPS
	/// common data class.
	/// </summary>
	public class  DPS : DOData
	{
		private cdcName cdcNameField;
		private cdcNs cdcNsField;		
		private d dField;
		private DataName DataNameField;
		private dataNs dataNsField;			
		private dU dUField;		
		private q qField;
		private stVal stValField;
		private subEna subEnaField;
		private subID subIDField;
		private subQ subQField;
		private subVal subValField;
		private t tField;
		
		/// <summary>
		/// Double point status (DPS)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN.
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public DPS(string name, string lnType, string iedType) : base (name, lnType+name)
		{			
			this.cdc = "DPS";
			this.id = this.type;
			this.iedType = iedType;				
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);			
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);			
			this.dUField = new dU(tBasicTypeEnum.Unicode255);									
			this.qField = new q(tBasicTypeEnum.Quality);	
			this.stValField = new stVal(tBasicTypeEnum.Enum);
			this.subEnaField = new subEna(tBasicTypeEnum.BOOLEAN);
			this.subIDField = new subID(tBasicTypeEnum.VisString64);
			this.subQField = new subQ(tBasicTypeEnum.Quality);
			this.subValField = new subVal(tBasicTypeEnum.Enum);
			this.tField = new t(tBasicTypeEnum.Timestamp);
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}	
		
		[Browsable(false)]
		public d d
		{		
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU 
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public q q
		{
			get 
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public stVal stVal
		{
			get 
			{
				return this.stValField;
			}
			set
			{
				this.stValField = value;
			}
		}	
		
		[Browsable(false)]
		public subEna subEna
		{
			get 
			{
				return this.subEnaField;
			}
			set
			{
				this.subEnaField = value;
			}
		}
		
		[Browsable(false)]
		public subID subID
		{
			get 
			{
				return this.subIDField;
			}
			set
			{
				this.subIDField = value;
			}
		}
		
		[Browsable(false)]
		public subQ subQ
		{
			get 
			{
				return this.subQField;
			}
			set
			{
				this.subQField = value;
			}
		}
		
		[Browsable(false)]
		public subVal subVal
		{
			get 
			{
				return this.subValField;
			}
			set
			{
				this.subValField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public t t
		{
			get 
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the HDEL
	/// common data class.
	/// </summary>
	public class  HDEL : DOData
	{
		private angRef angRefField;		
		private cdcName cdcNameField;
		private cdcNs cdcNsField;		
		private d dField;
		private DataName DataNameField;
		private dataNs dataNsField;		
		private dU dUField;
		private evalTm evalTmField;
		private frequency frequencyField;
		private hvRef hvRefField;
		private numCyc numCycField;
		private numHar numHarField;
//		FIXME : These attributes have a data type ARRAY[0..numHar] OF Vector and we have to verify how it works
//		      according to the IEC 61850 standard.
//		private phsABHar phsABHarField;
//		private phsBCHar phsBCHarField;
//		private phsCAHar phsCAHarField;
		private q qField;
		private rmsCyc rmsCycField;
		private smpRate smpRateField;
		private t tField;
		private units unitsField;
		
		/// <summary>
		/// Harmonic value for DEL (HDEL)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN. 
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public HDEL(string name, string lnType, string iedType) : base (name, lnType+name)
		{			
			this.cdc = "HDEL";
			this.id = this.type;
			this.iedType = iedType;				
			this.angRefField = new angRef(tBasicTypeEnum.Enum);			
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);			
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);			
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.evalTmField = new evalTm(tBasicTypeEnum.INT16U);
			this.frequencyField = new frequency(tBasicTypeEnum.FLOAT32);
			this.hvRefField = new hvRef(tBasicTypeEnum.Enum);
			this.numCycField = new numCyc(tBasicTypeEnum.INT16U);
			this.numHarField = new numHar(tBasicTypeEnum.INT16U);
//			this.phsABHarField = new phsABHar(iedType, this.id);
//			this.phsBCHarField = new phsBCHar(iedType, this.id);
//			this.phsCAHarField = new phsCAHar(iedType, this.id);
			this.qField = new q(tBasicTypeEnum.Quality);
			this.rmsCycField = new rmsCyc(tBasicTypeEnum.INT16U);
			this.smpRateField = new smpRate(tBasicTypeEnum.INT32U);
			this.tField = new t(tBasicTypeEnum.Timestamp);
			this.unitsField = new units(iedType, this.id);
		}
		
		[Browsable(false)]
		public angRef angRef 
		{
			get
			{
				return this.angRefField;
			}
			set
			{
				this.angRefField = value;
			}
		}	
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}	
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}	
		
		[Browsable(false)]
		public dU dU 
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public evalTm evalTm
		{
			get
			{
				return this.evalTmField;
			}
			set
			{
				this.evalTmField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public frequency frequency
		{
			get
			{
				return this.frequencyField;
			}
			set
			{
				this.frequencyField = value;
			}
		}
		
		[Browsable(false)]
		public hvRef hvRef
		{
			get
			{
				return this.hvRefField;
			}
			set
			{
				this.hvRefField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public numCyc numCyc
		{
			get
			{
				return this.numCycField;
			}
			set
			{
				this.numCycField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public numHar numHar
		{
			get
			{
				return this.numHarField;
			}
			set
			{
				this.numHarField = value;
			}
		}
		
//		[Required]
//		[Browsable(false)]
//		public phsABHar phsABHar
//		{
//			get	
//			{
//				return this.phsABHarField;
//			}
//			set
//			{
//				this.phsABHarField = value;
//			}
//		}
//		
//		[Browsable(false)]
//		public phsBCHar phsBCHar
//		{
//			get
//			{
//				return this.phsBCHarField;
//			}
//			set
//			{
//				this.phsBCHarField = value;
//			}
//		}
//		
//		[Browsable(false)]
//		public phsCAHar phsCAHar
//		{
//			get
//			{
//				return this.phsCAHarField;
//			}
//			set
//			{
//				this.phsCAHarField = value;
//			}
//		}
		
		[Required]
		[Browsable(false)]
		public q q
		{
			get
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
		[Browsable(false)]
		public rmsCyc rmsCyc
		{
			get
			{
				return this.rmsCycField;
			}
			set
			{
				this.rmsCycField = value;
			}
		}
		
		[Browsable(false)]
		public smpRate smpRate
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
		
		[Browsable(false)]
		public t t
		{
			get 
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		}
		
		[Browsable(false)]
		public units units
		{
			get 
			{
				return this.unitsField;
			}
			set
			{
				this.unitsField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the HMV
	/// common data class.
	/// </summary>
	public class  HMV : DOData
	{
		private cdcName cdcNameField;
		private cdcNs cdcNsField;
		private d dField;
		private DataName DataNameField;
		private dataNs dataNsField;
		private dU dUField;
		private evalTm evalTmField;
		private frequency frequencyField;
//		FIXME : This attribute has a data type ARRAY[0..numHar] OF Vector and we have to verify how it works
//		      according to the IEC 61850 standard.		
//		private har harField;
		private hvRef hvRefField;
		private numCyc numCycField;
		private numHar numHarField;
		private q qField;
		private rmsCyc rmsCycField;
		private smpRate smpRateField;
		private t tField;
		private units unitsField;
		
		/// <summary>
		/// Harmonic Value (HMV)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN. 
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public HMV(string name, string lnType, string iedType) : base (name, lnType+name)
		{			
			this.cdc = "HMV";
			this.id = this.type;
			this.iedType = iedType;				
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.evalTmField = new evalTm(tBasicTypeEnum.INT16U);
			this.frequencyField = new frequency(tBasicTypeEnum.FLOAT32);
//			this.harField = new har(iedType, this.id);
			this.hvRefField = new hvRef(tBasicTypeEnum.Enum);
			this.numCycField = new numCyc(tBasicTypeEnum.INT16U);
			this.numHarField = new numHar(tBasicTypeEnum.INT16U);
			this.qField = new q(tBasicTypeEnum.Quality);
			this.rmsCycField = new rmsCyc(tBasicTypeEnum.INT16U);
			this.smpRateField = new smpRate(tBasicTypeEnum.INT32U);
			this.tField = new t(tBasicTypeEnum.Timestamp);
			this.unitsField = new units(iedType, this.id);
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU 
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public evalTm evalTm
		{
			get
			{
				return this.evalTmField;
			}
			set
			{
				this.evalTmField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public frequency frequency
		{
			get
			{
				return this.frequencyField;
			}
			set
			{
				this.frequencyField = value;
			}
		}
		
//		[Required]
//		[Browsable(false)]
//		public har har
//		{
//			get
//			{
//				return this.harField;
//			}
//			set
//			{
//				this.harField = value;
//			}
//		}	
		
		[Browsable(false)]
		public hvRef hvRef
		{
			get
			{
				return this.hvRefField;
			}
			set
			{
				this.hvRefField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public numCyc numCyc
		{
			get
			{
				return this.numCycField;
			}
			set
			{
				this.numCycField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public numHar numHar
		{
			get
			{
				return this.numHarField;
			}
			set
			{
				this.numHarField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public q q
		{
			get
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
		[Browsable(false)]
		public rmsCyc rmsCyc
		{
			get
			{
				return this.rmsCycField;
			}
			set
			{
				this.rmsCycField = value;
			}
		}
		
		[Browsable(false)]
		public smpRate smpRate
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
		[Browsable(false)]
		public t t
		{
			get 
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		}
		
		[Browsable(false)]
		public units units
		{
			get 
			{
				return this.unitsField;
			}
			set
			{
				this.unitsField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the HWYE
	/// common data class.
	/// </summary>
	public class  HWYE : DOData
	{
		private angRef angRefField;		
		private cdcName cdcNameField;
		private cdcNs cdcNsField;		
		private d dField;
		private DataName DataNameField;
		private dataNs dataNsField;		
		private dU dUField;
		private evalTm evalTmField;
		private frequency frequencyField;
		private hvRef hvRefField;
//		FIXME : The attributes commented have a data type ARRAY[0..numHar] OF Vector and we have to verify how it works
//		      according to the IEC 61850 standard.		
//		private netHar netHarField;
//		private neutHar neutHarField;
		private numCyc numCycField;
		private numHar numHarField;
//		private phsAHar phsAHarField;
//		private phsBHar phsBHarField;
//		private phsCHar phsCHarField;
		private q qField;
//		private resHar resHarField;
		private rmsCyc rmsCycField;
		private smpRate smpRateField;
		private t tField;
		private units unitsField;
		
		/// <summary>
		/// Harmonic value for WYE (HWYE)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN. 
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public HWYE(string name, string lnType, string iedType) : base (name, lnType+name)
		{			
			this.cdc = "HWYE";
			this.id = this.type;
			this.iedType = iedType;				
			this.angRefField = new angRef(tBasicTypeEnum.Enum);			
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);			
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.DataNameField = new DataName(iedType, this.id);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);			
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.evalTmField = new evalTm(tBasicTypeEnum.INT16U);
			this.frequencyField = new frequency(tBasicTypeEnum.FLOAT32);
			this.hvRefField = new hvRef(tBasicTypeEnum.Enum);
//			this.netHarField = new netHar(iedType, this.id);
//			this.neutHarField = new neutHar(iedType, this.id);
			this.numCycField = new numCyc(tBasicTypeEnum.INT16U);
			this.numHarField = new numHar(tBasicTypeEnum.INT16U);
//			this.phsAHarField = new phsAHar(iedType, this.id);
//			this.phsBHarField = new phsBHar(iedType, this.id);
//			this.phsCHarField = new phsCHar(iedType, this.id);
			this.qField = new q(tBasicTypeEnum.Quality);	
//			this.resHarField = new resHar(iedType, this.id);
			this.rmsCycField = new rmsCyc(tBasicTypeEnum.INT16U);
			this.smpRateField = new smpRate(tBasicTypeEnum.INT32U);
			this.tField = new t(tBasicTypeEnum.Timestamp);
			this.unitsField = new units(iedType, this.id);
		}
		
		[Browsable(false)]
		public angRef angRef 
		{
			get
			{
				return this.angRefField;
			}
			set
			{
				this.angRefField = value;
			}
		}		
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}	
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}	
		
		[Browsable(false)]
		public dU dU 
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public evalTm evalTm
		{
			get
			{
				return this.evalTmField;
			}
			set
			{
				this.evalTmField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public frequency frequency
		{
			get
			{
				return this.frequencyField;
			}
			set
			{
				this.frequencyField = value;
			}
		}
		
		[Browsable(false)]
		public hvRef hvRef
		{
			get
			{
				return this.hvRefField;
			}
			set
			{
				this.hvRefField = value;
			}
		}	
		
//		[Browsable(false)]
//		public netHar netHar
//		{
//			get
//			{
//				return this.netHarField;
//			}
//			set
//			{
//				this.netHarField = value;
//			}
//		}
//		
//		[Browsable(false)]
//		public neutHar neutHar
//		{
//			get
//			{
//				return this.neutHarField;
//			}
//			set
//			{
//				this.neutHarField = value;
//			}
//		}
		
		[Required]
		[Browsable(false)]
		public numCyc numCyc
		{
			get
			{
				return this.numCycField;
			}
			set
			{
				this.numCycField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public numHar numHar
		{
			get
			{
				return this.numHarField;
			}
			set
			{
				this.numHarField = value;
			}
		}
		
//		[Required]
//		[Browsable(false)]
//		public phsAHar phsAHar
//		{
//			get
//			{
//				return this.phsAHarField;
//			}
//			set
//			{
//				this.phsAHarField = value;
//			}
//		}
//		
//		[Browsable(false)]
//		public phsBHar phsBHar
//		{
//			get
//			{
//				return this.phsBHarField;
//			}
//			set
//			{
//				this.phsBHarField = value;
//			}
//		}
//		
//		[Browsable(false)]
//		public phsCHar phsCHar	
//		{
//			get
//			{
//				return this.phsCHarField;
//			}
//			set
//			{
//				this.phsCHarField = value;
//			}
//		}
		
		[Required]
		[Browsable(false)]
		public q q
		{
			get 
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
//		[Browsable(false)]
//		public resHar resHar
//		{
//			get 
//			{
//				return this.resHarField;
//			}
//			set
//			{
//				this.resHarField = value;
//			}
//		}
		
		[Browsable(false)]
		public rmsCyc rmsCyc
		{
			get
			{
				return this.rmsCycField;
			}
			set
			{
				this.rmsCycField = value;
			}
		}
		
		[Browsable(false)]
		public smpRate smpRate
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
		[Browsable(false)]
		public t t
		{
			get 
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		}
		
		[Browsable(false)]
		public units units
		{
			get 
			{
				return this.unitsField;
			}
			set
			{
				this.unitsField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the INC
	/// common data class.
	/// </summary>
	public class  INC : DOData
	{		
		private DataName DataNameField;
		private ctlVal ctlValField;
		private operTm operTmField;
		private origin originField;
		private ctlNum ctlNumField;
		private stVal stValField;
		private q  qField;
		private t tField;
		private stSeld stSeldField;	
		private subEna subEnaField;	
		private subVal subValField;
		private subQ subQField;	
		private subID subIDField; 	
		private ctlModel ctlModelField;
		private sboTimeout sboTimeoutField;
		private sboClass sboClassField; 
		private minVal minValField;
		private maxVal maxValField; 
		private stepSize stepSizeField; 
		private d dField;
		private dU dUField;
		private cdcNs cdcNsField;
		private cdcName cdcNameField;
		private dataNs dataNsField;
		
		/// <summary>
		/// Controllable integer status (INC)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN. 
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public INC(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "INC";
			this.id = this.type;
			this.iedType = iedType;				
			this.DataNameField = new DataName(iedType, this.id); 
			this.ctlValField = new ctlVal(tBasicTypeEnum.INT32U);
			this.operTmField = new operTm(tBasicTypeEnum.Timestamp);
			this.originField = new origin(iedType, this.id);
			this.ctlNumField = new ctlNum(tBasicTypeEnum.INT8U);
			this.stValField = new stVal(tBasicTypeEnum.INT32U);
			this.qField = new q(tBasicTypeEnum.Quality);
			this.tField = new t(tBasicTypeEnum.Timestamp);
			this.stSeldField = new stSeld(tBasicTypeEnum.BOOLEAN);
			this.subEnaField = new subEna(tBasicTypeEnum.BOOLEAN);	
			this.subValField = new subVal(tBasicTypeEnum.INT32);
			this.subQField = new subQ(tBasicTypeEnum.Quality);
			this.subIDField = new subID(tBasicTypeEnum.VisString64);
			this.ctlModelField = new ctlModel(iedType, this.id);
			this.sboTimeoutField = new sboTimeout(tBasicTypeEnum.INT32U);
			this.sboClassField = new sboClass(iedType, this.id);
			this.minValField = new minVal(tBasicTypeEnum.INT32);
			this.maxValField = new maxVal(tBasicTypeEnum.INT32);
			this.stepSizeField = new stepSize(tBasicTypeEnum.INT32U); 	
			this.dField = new d(tBasicTypeEnum.VisString255); 	
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);  	
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255); 
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);	
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		} 
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public ctlModel ctlModel
		{
			get
			{
				return this.ctlModelField;
			}
			set
			{
				this.ctlModelField = value;
			}
		}
		
		[Browsable(false)]
		public ctlNum ctlNum
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
		
		[Browsable(false)]
		public ctlVal ctlVal
		{
			get
			{
				return this.ctlValField;
			}
			set
			{ 
				this.ctlValField = value;
			}
		}	
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		} 	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Browsable(false)]
		public maxVal maxVal
		{
			get
			{
				return this.maxValField;
			}
			set
			{
				this.maxValField = value;
			}
		}	
		
		[Browsable(false)]
		public minVal minVal
		{
			get
			{
				return this.minValField;
			}
			set
			{
				this.minValField = value;
			}
		}
		
		[Browsable(false)]
		public operTm operTm
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
		public q q
		{
			get
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
		[Browsable(false)]
		public sboClass sboClass
		{
			get
			{
				return this.sboClassField;
			}
			set
			{
				this.sboClassField = value;
			}
		}	
		
		[Browsable(false)]
		public sboTimeout sboTimeout
		{
			get
			{
				return this.sboTimeoutField;
			}
			set
			{
				this.sboTimeoutField = value;
			}
		}	
		
		[Browsable(false)]
		public stepSize stepSize
		{
			get
			{
				return this.stepSizeField;
			}
			set
			{
				this.stepSizeField = value;
			}
		}
		
		[Browsable(false)]
		public stSeld stSeld
		{
			get
			{
				return this.stSeldField;
			}
			set
			{
				this.stSeldField = value;
			}
		} 
		
		[Required]
		[Browsable(false)]
		public stVal stVal
		{
			get
			{
				return this.stValField;
			}
			set
			{
				this.stValField = value;
			}
		}	
		
		[Browsable(false)]
		public subEna subEna
		{
			get
			{
				return this.subEnaField;
			}
			set
			{
				this.subEnaField = value;
			}
		}	
		
		[Browsable(false)]
		public subID subID
		{
			get
			{
				return this.subIDField;
			}
			set
			{
				this.subIDField = value;
			}
		} 
		
		[Browsable(false)]
		public subQ subQ
		{
			get
			{
				return this.subQField;
			}
			set
			{
				this.subQField = value;
			}
		} 
		
		[Browsable(false)]
		public subVal subVal
		{
			get
			{
				return this.subValField;
			}
			set
			{
				this.subValField = value;
			}
		}	
		
		[Required]
		[Browsable(false)]
		public t t
		{
			get
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		} 
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the ING
	/// common data class.
	/// </summary>
	public class  ING : DOData
	{		
		private DataName DataNameField;
		private setVal setValField;
		private setVal2 setVal2Field;
		private minVal minValField;
		private maxVal maxValField;
		private stepSize stepSizeField; 
		private d dField; 
		private dU dUField;
		private cdcNs cdcNsField;
		private cdcName cdcNameField;
		private dataNs dataNsField;
		
		/// <summary>
		/// Integer status setting (ING)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN.
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public ING(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "ING";
			this.id = this.type;
			this.iedType = iedType;				
			this.DataNameField = new DataName(iedType, this.id); 
			this.setValField = new setVal(tBasicTypeEnum.INT32); 
			this.setVal2Field = new setVal2(tBasicTypeEnum.INT32); 
			this.minValField = new minVal(tBasicTypeEnum.INT32);
			this.maxValField = new maxVal(tBasicTypeEnum.INT32); 	
			this.stepSizeField = new stepSize(tBasicTypeEnum.INT32U);	
			this.dField = new d(tBasicTypeEnum.VisString255);
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);	
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);		
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255); 		
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}	
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs	
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		} 
		
		[Browsable(false)]
		public maxVal maxVal
		{
			get
			{
				return this.maxValField;
			}
			set
			{
				this.maxValField = value;
			}
		} 
		
		[Browsable(false)]
		public minVal minVal
		{
			get
			{
				return this.minValField;
			}
			set
			{
				this.minValField = value;
			}
		} 	
		
		[Browsable(false)]
		public setVal setVal
		{
			get
			{
				return this.setValField;
			}
			set
			{
				this.setValField = value;
			}
		} 	
		
		[Browsable(false)]
		public setVal2 setVal2
		{
			get
			{
				return this.setVal2Field;
			}
			set
			{
				this.setVal2Field = value;
			}
		} 	
		
		[Browsable(false)]
		public stepSize stepSize
		{
			get
			{
				return this.stepSizeField;
			}
			set
			{
				this.stepSizeField = value;
			}
		} 		
	}	
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the INS
	/// common data class.
	/// </summary>
	public class  INS : DOData
	{		
		private DataName DataNameField;
		private stVal stValField;
		private q  qField;
		private t tField;
		private subEna subEnaField;
		private subVal subValField;
		private subQ subQField;
		private subID subIDField;
		private d dField;
		private dU dUField;
		private cdcNs cdcNsField;
		private cdcName cdcNameField;
		private dataNs dataNsField;
				
		/// <summary>
		/// Integer status (INS)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN.
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public INS(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "INS";
			this.id = this.type;
			this.iedType = iedType;				
			this.DataNameField = new DataName(iedType, this.id); 
			this.stValField = new stVal(tBasicTypeEnum.INT32U);
			this.qField = new q(tBasicTypeEnum.Quality);
			this.tField = new t(tBasicTypeEnum.Timestamp);
			this.subEnaField = new subEna(tBasicTypeEnum.BOOLEAN);
			this.subValField = new subVal(tBasicTypeEnum.Enum);
			this.subQField = new subQ(tBasicTypeEnum.Quality);
			this.subIDField = new subID(tBasicTypeEnum.VisString64);
			this.dField = new d(tBasicTypeEnum.VisString255); 	
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255); 
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);	
		}	
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}	
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}	
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}	
		
		[Browsable(false)]
		public dU dU
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}	
		
		[Required]
		[Browsable(false)]
		public q q
		{
			get
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public stVal stVal
		{
			get
			{
				return this.stValField;
			}
			set
			{
				this.stValField = value;
			}
		}
		
		[Browsable(false)]
		public subEna subEna
		{
			get
			{
				return this.subEnaField;
			}
			set
			{
				this.subEnaField = value;
			}
		}
		
		[Browsable(false)]
		public subID subID
		{
			get
			{
				return this.subIDField;
			}
			set
			{
				this.subIDField = value;
			}
		}
		
		[Browsable(false)]
		public subQ subQ
		{
			get
			{
				return this.subQField;
			}
			set
			{
				this.subQField = value;
			}
		}
		
		[Browsable(false)]
		public subVal subVal
		{
			get
			{
				return this.subValField;
			}
			set
			{
				this.subValField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public t t
		{
			get
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		}	
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the ISC
	/// common data class.
	/// </summary>
	public class  ISC : DOData
	{		
		private DataName DataNameField;
		private ctlVal ctlValField;
		private operTm operTmField;
		private origin originField;
		private ctlNum ctlNumField;
		private valWTr valWTrField;
		private q  qField;
		private t tField;
		private stSeld stSeldField;
		private subEna subEnaField;	
		private subVal subValField;
		private subQ subQField;	
		private subID subIDField; 	
		private ctlModel ctlModelField;
		private sboTimeout sboTimeoutField;
		private sboClass sboClassField;
		private minVal minValField;
		private maxVal maxValField; 
		private stepSize stepSizeField;
		private d dField;
		private dU dUField;		
		private cdcNs cdcNsField;
		private cdcName cdcNameField;
		private dataNs dataNsField;
		
		/// <summary>
		/// Integer controlled step position information (ISC)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN. 
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public ISC(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "ISC";
			this.id = this.type;
			this.iedType = iedType;				
			this.DataNameField = new DataName(iedType, this.id); 
			this.ctlValField = new ctlVal(tBasicTypeEnum.INT8);
			this.operTmField = new operTm(tBasicTypeEnum.Timestamp);
			this.originField = new origin(iedType, this.id);
			this.ctlNumField = new ctlNum(tBasicTypeEnum.INT8U); 
			this.valWTrField = new valWTr(iedType, this.id);
			this.qField = new q(tBasicTypeEnum.Quality);
			this.tField = new t(tBasicTypeEnum.Timestamp);
			this.stSeldField = new stSeld(tBasicTypeEnum.BOOLEAN);
			this.subEnaField = new subEna(tBasicTypeEnum.BOOLEAN);			
			this.subValField = new subVal(iedType, this.id);
			ValWithTrans ValWithTransField = new ValWithTrans(iedType, this.subValField.id);
			this.subValField.SetLinkSDIDADataTypeBDA(ValWithTransField);			
			this.subQField = new subQ(tBasicTypeEnum.Quality);
			this.subIDField = new subID(tBasicTypeEnum.VisString64);
			this.ctlModelField = new ctlModel(iedType, this.id);
			this.sboTimeoutField = new sboTimeout(tBasicTypeEnum.INT32U);
			this.sboClassField = new sboClass(iedType, this.id);
			this.minValField = new minVal(tBasicTypeEnum.INT8);
			this.maxValField = new maxVal(tBasicTypeEnum.INT8);
			this.stepSizeField = new stepSize(tBasicTypeEnum.INT8U);
			this.dField = new d(tBasicTypeEnum.VisString255); 	
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255); 
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);	
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}	
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}	
		
		[Required]
		[Browsable(false)]
		public ctlModel ctlModel
		{
			get
			{
				return this.ctlModelField;
			}
			set
			{
				this.ctlModelField = value;
			}
		} 
		
		[Browsable(false)]
		public ctlNum ctlNum
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
		
		[Browsable(false)]
		public ctlVal ctlVal
		{
			get
			{
				return this.ctlValField;
			}
			set
			{
				this.ctlValField = value;
			}
		} 
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}	
		
		[Browsable(false)]
		public dU dU
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}	
		
		[Browsable(false)]
		public maxVal maxVal
		{
			get
			{
				return this.maxValField;
			}
			set
			{
				this.maxValField = value;
			}
		} 	
		
		[Browsable(false)]
		public minVal minVal
		{
			get
			{
				return this.minValField;
			}
			set
			{
				this.minValField = value;
			}
		} 
		
		[Browsable(false)]
		public operTm operTm
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
		
		[Browsable(false)]
		public q q
		{
			get
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
		[Browsable(false)]
		public sboClass sboClass
		{
			get
			{
				return this.sboClassField;
			}
			set
			{
				this.sboClassField = value;
			}
		} 
		
		[Browsable(false)]
		public sboTimeout sboTimeout
		{
			get
			{
				return this.sboTimeoutField;
			}
			set
			{
				this.sboTimeoutField = value;
			}
		} 
		
		[Browsable(false)]
		public stepSize stepSize
		{
			get
			{
				return this.stepSizeField;
			}
			set
			{
				this.stepSizeField = value;
			}
		}
		
		[Browsable(false)]
		public stSeld stSeld
		{
			get
			{
				return this.stSeldField;
			}
			set
			{
				this.stSeldField = value;
			}
		} 	
		
		[Browsable(false)]
		public subEna subEna
		{
			get
			{
				return this.subEnaField;
			}
			set
			{
				this.subEnaField = value;
			}
		} 
		
		[Browsable(false)]
		public subID subID
		{
			get
			{
				return this.subIDField;
			}
			set
			{
				this.subIDField = value;
			}
		} 
		
		[Browsable(false)]
		public subQ subQ
		{
			get
			{
				return this.subQField;
			}
			set
			{
				this.subQField = value;
			}
		}  
		
		[Browsable(false)]
		public subVal subVal
		{
			get
			{
				return this.subValField;
			}
			set
			{
				this.subValField = value;
			}
		} 	
		
		[Browsable(false)]
		public t t
		{
			get
			{
				return this.tField;
			}
			set
			{				
				this.tField = value;
			}
		} 	
		
		[Browsable(false)]
		public valWTr valWTr
		{
			get
			{
				return this.valWTrField;
			}
			set
			{				
				this.valWTrField = value;
			}
		}	
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the LPL
	/// common data class.
	/// </summary>
	public class  LPL : DOData
	{		
		private DataName DataNameField;
		private vendor vendorField; 
		private swRev swRevField;
		private d dField;
		private dU dUField; 
		private configRev configRevField; 
		private ldNs ldNsField; 
		private lnNs lnNsField;
		private cdcNs cdcNsField;
		private cdcName cdcNameField;
		private dataNs dataNsField;
		
		/// <summary>
		/// Logical node name plate (LPL)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN.
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public LPL(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "LPL";
			this.id = this.type;
			this.iedType = iedType;				
			this.DataNameField = new DataName(iedType, this.id); 
			this.vendorField = new vendor(tBasicTypeEnum.VisString255);
			this.swRevField = new swRev(tBasicTypeEnum.VisString255); 
			this.dField = new d(tBasicTypeEnum.VisString255); 	
			this.dUField = new dU(tBasicTypeEnum.Unicode255); 
			this.configRevField = new configRev(tBasicTypeEnum.VisString255); 
			this.ldNsField = new ldNs(tBasicTypeEnum.VisString255); 
			this.lnNsField = new lnNs(tBasicTypeEnum.VisString255); 
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255); 
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);	
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}	
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}	
		
		[Browsable(false)]
		public configRev configRev
		{
			get
			{
				return this.configRevField;
			}
			set
			{
				this.configRevField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Browsable(false)]
		public ldNs ldNs
		{
			get
			{
				return this.ldNsField;
			}
			set
			{
				this.ldNsField = value;
			}
		}	
		
		[Browsable(false)]
		public lnNs lnNs
		{
			get
			{
				return this.lnNsField;
			}
			set
			{
				this.lnNsField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public swRev swRev
		{
			get
			{
				return this.swRevField;
			}
			set
			{
				this.swRevField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public vendor vendor
		{
			get
			{
				return this.vendorField;
			}
			set
			{
				this.vendorField = value;
			}
		} 
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the MV
	/// common data class.
	/// </summary>
	public class  MV : DOData
	{		
		private DataName DataNameField; 
		private instMag instMagField; 
		private mag magField; 
		private range rangeField;
		private q qField;
		private t tField;
		private subEna subEnaField;
		private subVal subValField;
		private subQ subQField;
		private subID subIDField; 
		private units unitsField; 
		private db dbField; 
		private zeroDb zeroDbField; 
		private sVC sVCField; 
		private rangeC rangeCField; 
		private smpRate smpRateField;
		private d dField;
		private dU dUField;
		private cdcNs cdcNsField;
		private cdcName cdcNameField;
		private dataNs dataNsField;
		
		/// <summary>
		/// Measured value (MV)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN.
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public MV(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "MV";
			this.id = this.type;
			this.iedType = iedType;				
			this.DataNameField = new DataName(iedType, this.id); 
			this.instMagField = new instMag(iedType, this.id);
			this.magField = new mag(iedType, this.id);			
			this.rangeField = new range(iedType, this.id);
			AnalogueValue AnalogueValueField = new AnalogueValue(iedType, this.rangeField.id);
			this.rangeField.SetLinkSDIDADataTypeBDA(AnalogueValueField);			
			this.qField = new q(tBasicTypeEnum.Quality);
			this.tField = new t(tBasicTypeEnum.Timestamp);
			this.subEnaField = new subEna(tBasicTypeEnum.BOOLEAN);			
			this.subValField = new subVal(tBasicTypeEnum.INT32);
			AnalogueValueField = new AnalogueValue(iedType, this.subValField.id);
			this.subValField.SetLinkSDIDADataTypeBDA(AnalogueValueField);			
			this.subQField = new subQ(tBasicTypeEnum.Quality);
			this.subIDField = new subID(tBasicTypeEnum.VisString64); 
			this.unitsField = new units(iedType, this.id); 	
			this.dbField = new db(tBasicTypeEnum.INT32U);
			this.zeroDbField = new zeroDb(tBasicTypeEnum.INT32U); 
			this.sVCField = new sVC(iedType, this.id);
			this.rangeCField = new rangeC(iedType, this.id);
			this.smpRateField = new smpRate(tBasicTypeEnum.INT32U);
			this.dField = new d(tBasicTypeEnum.VisString255); 	
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255); 
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255);
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);	
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}	
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}	
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public db db
		{
			get
			{
				return this.dbField;
			}
			set
			{
				this.dbField = value;
			}
		} 	
		
		[Browsable(false)]
		public dU dU
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Browsable(false)]
		public instMag instMag
		{
			get
			{
				return this.instMagField;
			}
			set
			{
				this.instMagField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
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
		
		[Required]
		[Browsable(false)]
		public q q
		{
			get
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}	
		
		[Browsable(false)]
		public range range
		{
			get
			{
				return this.rangeField;
			}
			set
			{
				this.rangeField = value;
			}
		}
		
		[Browsable(false)]
		public rangeC rangeC
		{
			get
			{
				return this.rangeCField;
			}
			set
			{
				this.rangeCField = value;
			}
		}
		
		[Browsable(false)]
		public smpRate smpRate
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
		
		[Browsable(false)]
		public subEna subEna
		{
			get
			{
				return this.subEnaField;
			}
			set
			{
				this.subEnaField = value;
			}
		}  	
		
		[Browsable(false)]
		public subID subID
		{
			get
			{
				return this.subIDField;
			}
			set
			{
				this.subIDField = value;
			}
		}
		
		[Browsable(false)]
		public subQ subQ
		{
			get
			{
				return this.subQField;
			}
			set
			{
				this.subQField = value;
			}
		} 
		
		[Browsable(false)]
		public subVal subVal
		{
			get
			{
				return this.subValField;
			}
			set
			{
				this.subValField = value;
			}
		} 
		
		[Browsable(false)]
		public sVC sVC
		{
			get
			{
				return this.sVCField;
			}
			set
			{
				this.sVCField = value;
			}
		} 	
		
		[Required]
		[Browsable(false)]
		public t t
		{
			get
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		} 
		
		[Browsable(false)]
		public units units
		{
			get
			{
				return this.unitsField;
			}
			set
			{
				this.unitsField = value;
			}
		} 
		
		[Browsable(false)]
		public zeroDb zeroDb
		{
			get
			{
				return this.zeroDbField;
			}
			set
			{
				this.zeroDbField = value;
			}
		} 		
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the SAV
	/// common data class.
	/// </summary>
	public class  SAV : DOData
	{		
		private DataName DataNameField; 
		private instMag instMagField; 
		private q  qField;
		private t tField; 
		private units unitsField;
		private sVC sVCField; 
		private max maxField;
		private min minField;		
		private d dField;
		private dU dUField;
		private cdcNs cdcNsField;
		private cdcName cdcNameField;
		private dataNs dataNsField;
		
		/// <summary>
		/// Sampled value (SAV)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN. 
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public SAV(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "SAV";
			this.id = this.type;
			this.iedType = iedType;				
			this.DataNameField = new DataName(iedType, this.id); 
			this.instMagField = new instMag(iedType, this.id); 
			this.qField = new q(tBasicTypeEnum.Quality);
			this.tField = new t(tBasicTypeEnum.Timestamp);
			this.unitsField = new units(iedType, this.id); 
			this.sVCField = new sVC(iedType, this.id);		 	
			this.maxField = new max(iedType, this.id);
			this.minField = new min(iedType, this.id);			
			this.dField = new d(tBasicTypeEnum.VisString255); 	
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);  	
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255); 
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);	
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}	
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}		
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public instMag instMag
		{
			get
			{
				return this.instMagField;
			}
			set
			{
				this.instMagField = value;
			}
		}
		
		[Browsable(false)]
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
		
		[Browsable(false)]
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
		[Browsable(false)]
		public q q
		{
			get
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}	
		
		[Browsable(false)]
		public sVC sVC
		{
			get
			{
				return this.sVCField;
			}
			set
			{
				this.sVCField = value;
			}
		} 
		
		[Browsable(false)]
		public t t
		{
			get
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		}
		
		[Browsable(false)]
		public units units
		{
			get
			{
				return this.unitsField;
			}
			set
			{
				this.unitsField = value;
			}
		}		
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the SEC
	/// common data class.
	/// </summary>
	public class  SEC : DOData
	{		
		private DataName DataNameField; 
		private cnt  cntField;
		private sev sevField;
		private t tField;
		private addr addrField; 	
		private addInfo addInfoField;	
		private d dField;
		private dU dUField;
		private cdcNs cdcNsField;
		private cdcName cdcNameField;
		private dataNs dataNsField;
		
		/// <summary>
		/// Security violation counting (SEC)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN.
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public SEC(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "SEC";
			this.id = this.type;
			this.iedType = iedType;				
			this.DataNameField = new DataName(iedType, this.id); 
			this.cntField = new cnt(tBasicTypeEnum.INT32U); 
			this.sevField = new sev(tBasicTypeEnum.Enum);
			this.tField = new t(tBasicTypeEnum.Timestamp); 
			this.addrField = new addr(tBasicTypeEnum.Octet64);
			this.addInfoField = new addInfo(tBasicTypeEnum.VisString64);
			this.dField = new d(tBasicTypeEnum.VisString255); 	
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);  	
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255); 
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);							
		}
		
		[Browsable(false)]
		public addInfo addInfo
		{
			get
			{
				return this.addInfoField;
			}
			set
			{
				this.addInfoField = value;
			}
		}
		
		[Browsable(false)]
		public addr addr
		{
			get
			{
				return this.addrField;
			}
			set
			{
				this.addrField = value;
			}
		} 
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}	
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}		
		
		[Required]
		[Browsable(false)]
		public cnt cnt
		{
			get
			{
				return this.cntField;
			}
			set
			{
				this.cntField = value;
			}
		} 
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}	
		
		[Required]
		[Browsable(false)]
		public sev sev
		{
			get
			{
				return this.sevField;
			}
			set
			{
				this.sevField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public t t
		{
			get
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		} 
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the SEQ
	/// common data class.
	/// </summary>
	public class  SEQ : DOData
	{		
		private DataName DataNameField;
		private c1 c1Field;
		private c2 c2Field;
		private c3 c3Field; 
		private seqT seqTField;	
		private phsRef phsRefField;
		private d dField;
		private dU dUField;
		private cdcNs cdcNsField;
		private cdcName cdcNameField;
		private dataNs dataNsField;
		
		/// <summary>
		/// Sequence (SEQ)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN. 
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public SEQ(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "SEQ";
			this.id = this.type;
			this.iedType = iedType;				
			this.DataNameField = new DataName(iedType, this.id); 			
			this.c1Field = new c1(iedType, this.id);
			CMV CMVField = new CMV("", this.c1Field.id, iedType);
			this.c1Field.SetLinkDOData(CMVField);								
			this.c2Field = new c2(iedType, this.id);
			CMVField = new CMV("", this.c2Field.id, iedType);
			this.c2Field.SetLinkDOData(CMVField);					
			this.c3Field = new c3(iedType, this.id); 
			CMVField = new CMV("", this.c3Field.id, iedType);
			this.c3Field.SetLinkDOData(CMVField);					
			this.seqTField = new seqT(tBasicTypeEnum.Enum);
			this.phsRefField = new phsRef(tBasicTypeEnum.Enum);
			this.dField = new d(tBasicTypeEnum.VisString255); 	
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);  	
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255); 
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);	
		}
		
		[Required]
		[Browsable(false)]
		public c1 c1
		{
			get
			{
				return this.c1Field;
			}
			set
			{
				this.c1Field = value;
			}
		}	
		
		[Required]
		[Browsable(false)]
		public c2 c2
		{
			get
			{
				return this.c2Field;
			}
			set
			{
				this.c2Field = value;
			}
		}	
		
		[Required]
		[Browsable(false)]
		public c3 c3
		{
			get
			{
				return this.c3Field;
			}
			set
			{
				this.c3Field = value;
			}
		} 
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		}	
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}	
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Browsable(false)]
		public phsRef phsRef
		{
			get
			{
				return this.phsRefField;
			}
			set
			{
				this.phsRefField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public seqT seqT
		{
			get
			{
				return this.seqTField;
			}
			set
			{
				this.seqTField = value;
			}
		} 	
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the SPC
	/// common data class.
	/// </summary>
	public class  SPC : DOData
	{		
		private DataName DataNameField;
		private ctlVal ctlValField;
		private operTm operTmField;
		private origin originField;
		private ctlNum ctlNumField;
		private stVal stValField;
		private q  qField;
		private t tField;
		private stSeld stSeldField;	
		private subEna subEnaField;	
		private subVal subValField;
		private subQ subQField;	
		private subID subIDField; 
		private PulseConfig PulseConfigField; 
		private ctlModel ctlModelField;
		private sboTimeout sboTimeoutField;
		private sboClass sboClassField;
		private d dField;
		private dU dUField;
		private cdcNs cdcNsField;
		private cdcName cdcNameField;
		private dataNs dataNsField;
		
		/// <summary>
		/// Controllable single point (SPC)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN. 
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public SPC(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "SPC";
			this.id = this.type;
			this.iedType = iedType;				
			this.DataNameField = new DataName(iedType, this.id); 
			this.ctlValField = new ctlVal(tBasicTypeEnum.BOOLEAN);
			this.operTmField = new operTm(tBasicTypeEnum.Timestamp);
			this.originField = new origin(iedType, this.id);
			this.ctlNumField = new ctlNum(tBasicTypeEnum.INT8U);
			this.stValField = new stVal(tBasicTypeEnum.BOOLEAN);
			this.qField = new q(tBasicTypeEnum.Quality);
			this.tField = new t(tBasicTypeEnum.Timestamp);
			this.stSeldField = new stSeld(tBasicTypeEnum.BOOLEAN);
			this.subEnaField = new subEna(tBasicTypeEnum.BOOLEAN);	
			this.subValField = new subVal(tBasicTypeEnum.BOOLEAN);
			this.subQField = new subQ(tBasicTypeEnum.Quality);
			this.subIDField = new subID(tBasicTypeEnum.VisString64); 
			this.PulseConfigField = new PulseConfig(iedType, this.id);
			this.ctlModelField = new ctlModel(iedType, this.id);
			this.sboTimeoutField = new sboTimeout(tBasicTypeEnum.INT32U);
			this.sboClassField = new sboClass(iedType, this.id);
			this.dField = new d(tBasicTypeEnum.VisString255); 	
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);  	
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255); 
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);	
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		} 
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public ctlModel ctlModel
		{
			get
			{
				return this.ctlModelField;
			}
			set
			{
				this.ctlModelField = value;
			}
		}	
		
		[Browsable(false)]
		public ctlNum ctlNum
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
		
		[Browsable(false)]
		public ctlVal ctlVal
		{
			get
			{
				return this.ctlValField;
			}
			set
			{ 
				this.ctlValField = value;
			}
		}
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		} 	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}	
		
		[Browsable(false)]
		public operTm operTm
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
		
		[Browsable(false)]
		public PulseConfig PulseConfig
		{
			get
			{
				return this.PulseConfigField;
			}
			set
			{
				this.PulseConfigField = value;
			}
		}
		
		[Browsable(false)]
		public q q
		{
			get
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
		[Browsable(false)]
		public sboClass sboClass
		{
			get
			{
				return this.sboClassField;
			}
			set
			{
				this.sboClassField = value;
			}
		}
		
		[Browsable(false)]
		public sboTimeout sboTimeout
		{
			get
			{
				return this.sboTimeoutField;
			}
			set
			{
				this.sboTimeoutField = value;
			}
		}	
		
		[Browsable(false)]
		public stSeld stSeld
		{
			get
			{
				return this.stSeldField;
			}
			set
			{
				this.stSeldField = value;
			}
		}  
		
		[Browsable(false)]
		public stVal stVal
		{
			get
			{
				return this.stValField;
			}
			set
			{
				this.stValField = value;
			}
		}
		
		[Browsable(false)]
		public subEna subEna
		{
			get
			{
				return this.subEnaField;
			}
			set
			{
				this.subEnaField = value;
			}
		}	
		
		[Browsable(false)]
		public subID subID
		{
			get
			{
				return this.subIDField;
			}
			set
			{
				this.subIDField = value;
			}
		} 	
		
		[Browsable(false)]
		public subQ subQ
		{
			get
			{
				return this.subQField;
			}
			set
			{
				this.subQField = value;
			}
		} 	
		
		[Browsable(false)]
		public subVal subVal
		{
			get
			{
				return this.subValField;
			}
			set
			{
				this.subValField = value;
			}
		}	
		
		[Browsable(false)]
		public t t
		{
			get
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		} 
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the SPG
	/// common data class.
	/// </summary>
	public class  SPG : DOData
	{		
		private DataName DataNameField;
		private setVal setValField;
		private setVal2 setVal2Field;
		private d dField;
		private dU dUField;
		private cdcNs cdcNsField;
		private cdcName cdcNameField;
		private dataNs dataNsField;
		
		/// <summary>
		/// Single point setting (SPG)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN. 
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public SPG(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "SPG";
			this.id = this.type;
			this.iedType = iedType;				
			this.DataNameField = new DataName(iedType, this.id); 
			this.setValField = new setVal(tBasicTypeEnum.BOOLEAN);
			this.setVal2Field = new setVal2(tBasicTypeEnum.BOOLEAN);
			this.dField = new d(tBasicTypeEnum.VisString255); 	
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);  	
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255); 
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);	
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		} 
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		} 
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}	
		
		[Browsable(false)]
		public setVal setVal
		{
			get
			{
				return this.setValField;
			}
			set
			{
				this.setValField = value;
			}
		}
		
		[Browsable(false)]
		public setVal2 setVal2
		{
			get
			{
				return this.setVal2Field;
			}
			set
			{
				this.setVal2Field = value;
			}
		}		
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the SPS
	/// common data class.
	/// </summary>
	public class  SPS : DOData
	{		
		private DataName DataNameField;
		private stVal stValField;
		private q  qField;
		private t tField;
		private subEna subEnaField;	
		private subVal subValField;
		private subQ subQField;	
		private subID subIDField; 
		private d dField;
		private dU dUField;
		private cdcNs cdcNsField;
		private cdcName cdcNameField;
		private dataNs dataNsField;
		
		/// <summary>
		/// Single point status (SPS)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN. 
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public SPS(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "SPS";
			this.id = this.type;
			this.iedType = iedType;				
			this.DataNameField = new DataName(iedType, this.id); 
			this.stValField = new stVal(tBasicTypeEnum.BOOLEAN);
			this.qField = new q(tBasicTypeEnum.Quality);
			this.tField = new t(tBasicTypeEnum.Timestamp);
			this.subEnaField = new subEna(tBasicTypeEnum.BOOLEAN);	
			this.subValField = new subVal(tBasicTypeEnum.BOOLEAN);
			this.subQField = new subQ(tBasicTypeEnum.Quality);
			this.subIDField = new subID(tBasicTypeEnum.VisString64); 
			this.dField = new d(tBasicTypeEnum.VisString255); 	
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);  	
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255); 
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);				
		}
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		} 
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		}
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public q q
		{
			get
			{
				return this.qField;
			}
			set
			{
				this.qField = value;
			}
		}
		
		[Required]
		[Browsable(false)]
		public stVal stVal
		{
			get
			{
				return this.stValField;
			}
			set
			{
				this.stValField = value;
			}
		}	
		
		[Browsable(false)]
		public subEna subEna
		{
			get
			{
				return this.subEnaField;
			}
			set
			{
				this.subEnaField = value;
			}
		} 
		
		[Browsable(false)]
		public subID subID
		{
			get
			{
				return this.subIDField;
			}
			set
			{
				this.subIDField = value;
			}
		}
		
		[Browsable(false)]
		public subQ subQ
		{
			get
			{
				return this.subQField;
			}
			set
			{
				this.subQField = value;
			}
		} 	
		
		[Browsable(false)]
		public subVal subVal
		{
			get
			{
				return this.subValField;
			}
			set
			{
				this.subValField = value;
			}
		} 
		
		[Required]
		[Browsable(false)]
		public t t
		{
			get
			{
				return this.tField;
			}
			set
			{
				this.tField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the WYE
	/// common data class.
	/// </summary>
	public class  WYE : DOData
	{		
		private DataName DataNameField; 
		private phsA phsAField;
		private phsB phsBField;
		private phsC phsCField; 
		private neut neutField;
		private net netField; 
		private res resField;	
		private angRef angRefField;
		private d dField;
		private dU dUField;
		private cdcNs cdcNsField;
		private cdcName cdcNameField;
		private dataNs dataNsField;
	
		/// <summary>
		/// Phase to ground related measured values of a three phase system (WYE)
		/// </summary>
		/// <param name="name">
		/// A name identifying the DO.
		/// </param>
		/// <param name="lnType">
		/// Containing more detailed functional specification about LN. 
		/// </param>
		/// <param name="iedType">
		/// The manufacturer IED type of the IED to which this LN type belongs.
		/// </param>
		public WYE(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "WYE";
			this.id = this.type;
			this.iedType = iedType;				
			this.DataNameField = new DataName(iedType, this.id); 			
			this.phsAField = new phsA(iedType, this.id);
			CMV CMVField = new CMV("", this.phsAField.id, iedType);
			this.phsAField.SetLinkDOData(CMVField);			
			this.phsBField = new phsB(iedType, this.id);
			CMVField = new CMV("", this.phsBField.id, iedType);
			this.phsBField.SetLinkDOData(CMVField);			
			this.phsCField = new phsC(iedType, this.id); 
			CMVField = new CMV("", this.phsCField.id, iedType);
			this.phsCField.SetLinkDOData(CMVField);			
			this.neutField = new neut(iedType, this.id); 
			CMVField = new CMV("", this.neutField.id, iedType);
			this.neutField.SetLinkDOData(CMVField);			
			this.netField = new net(iedType, this.id); 
			CMVField = new CMV("", this.netField.id, iedType);
			this.netField.SetLinkDOData(CMVField);			
			this.resField = new res(iedType, this.id);
			CMVField = new CMV("", this.resField.id, iedType);
			this.resField.SetLinkDOData(CMVField);			
			this.angRefField = new angRef(tBasicTypeEnum.Enum);
			this.dField = new d(tBasicTypeEnum.VisString255); 	
			this.dUField = new dU(tBasicTypeEnum.Unicode255);
			this.cdcNsField = new cdcNs(tBasicTypeEnum.VisString255);  	
			this.cdcNameField = new cdcName(tBasicTypeEnum.VisString255); 
			this.dataNsField = new dataNs(tBasicTypeEnum.VisString255);				
		}
		
		[Browsable(false)]
		public angRef angRef
		{
			get
			{
				return this.angRefField;
			}
			set
			{
				this.angRefField = value;
			}
		}	
		
		[Browsable(false)]
		public cdcName cdcName
		{
			get
			{
				return this.cdcNameField;
			}
			set
			{
				this.cdcNameField = value;
			}
		} 
		
		[Browsable(false)]
		public cdcNs cdcNs
		{
			get
			{
				return this.cdcNsField;
			}
			set
			{
				this.cdcNsField = value;
			}
		}
		
		[Browsable(false)]
		public d d
		{
			get
			{
				return this.dField;
			}
			set
			{
				this.dField = value;
			}
		} 	
		
		[Browsable(false)]
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
		
		[Browsable(false)]
		public dataNs dataNs
		{
			get
			{
				return this.dataNsField;
			}
			set
			{
				this.dataNsField = value;
			}
		}
		
		[Browsable(false)]
		public dU dU
		{
			get
			{
				return this.dUField;
			}
			set
			{
				this.dUField = value;
			}
		}	
		
		[Browsable(false)]
		public net net
		{
			get
			{
				return this.netField;
			}
			set
			{
				this.netField = value;
			}
		}	
		
		[Browsable(false)]
		public neut neut
		{
			get
			{
				return this.neutField;
			}
			set
			{
				this.neutField = value;
			}
		} 
		
		[Browsable(false)]
		public phsA phsA
		{
			get
			{
				return this.phsAField;
			}
			set
			{
				this.phsAField = value;
			}
		} 		
		
		[Browsable(false)]
		public phsB phsB
		{
			get
			{
				return this.phsBField;
			}
			set
			{
				this.phsBField = value;
			}
		}		
		
		[Browsable(false)]
		public phsC phsC
		{
			get
			{
				return this.phsCField;
			}
			set
			{
				this.phsCField = value;
			}
		}
		
		[Browsable(false)]
		public res res
		{
			get
			{
				return this.resField;
			}
			set
			{
				this.resField = value;
			}
		} 
	}	
		
	/**********************************************************************************************/
	
	/// <summary>
	/// Binary counter status represented as an integer value.
	/// tBasicTypeEnum.INT128
	/// </summary>	
	public class actVal :DADataType
	{
		public actVal(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "actVal";
			this.bType = basicTypeEnum;
			this.iedType = iedType;
		}
	}
	
	/// <summary>
	/// Additional information that may give further clarification as to the last detected violation.
	/// tBasicTypeEnum.VisString64
	/// </summary>
	public class addInfo :DADataType
	{
		public addInfo(tBasicTypeEnum basicTypeEnum)
		{									
			this.name = "addInfo";
			this.bType = basicTypeEnum;
		}
	}
		
	/// <summary>
	/// Address of the remote source that last caused the count to be incremented.
	/// tBasicTypeEnum.Octet64
	/// </summary>
	public class addr :DADataType
	{
		public addr(tBasicTypeEnum basicTypeEnum)
		{											
			this.name = "addr";
			this.bType = basicTypeEnum;
		}
	}
	
/// <summary>
	/// Angle reference.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class angRef  :DADataType
	{
		ConversionObject conversionObject;
		public angRef(tBasicTypeEnum basicTypeEnum)
		{					
			this.name = "angRef";
			this.bType = basicTypeEnum;
			this.iedType = iedType;			
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(angRefEnum.Va);
			}				
			this.id = this.type = "angRefEnum";						
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(angRefEnum));			
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
		public angRefEnum tValue
		{			
			get
			{
				return (angRefEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(angRefEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}	
	}
	
	/// <summary>
	///  Scaled value configuration for angles.
	/// </summary>
	public class angSVC : SDIDADataTypeBDA
	{
		private ScaledValueConfig scaledValueConfigField;
		
		public angSVC(string iedType, string lnType)
		{				
			this.name = "angSVC";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"angSVC";
			this.iedType = iedType;
			this.scaledValueConfigField = new ScaledValueConfig(iedType, this.id);
		}
		
		public ScaledValueConfig ScaledValueConfig
		{
			get
			{
				return this.scaledValueConfigField;
			}
			set
			{
				this.scaledValueConfigField = value;
			}
		}		
	}
	
	/// <summary>
	/// Sequence component 1.
	/// </summary>
	public class c1 : SDOSDIDOTypeDA
	{
		private DOData c1DOData;
		
		public c1(string iedType, string lnType)
		{
			this.name = "c1";						
			this.id = this.type = lnType+"c1";
			this.iedType = iedType;		
			this.bType = tBasicTypeEnum.Struct;
		}	
		
		public void SetLinkDOData(DOData c1DOData)
		{
			this.c1DOData = c1DOData;
			this.cdc = c1DOData.cdc;
			this.c1DOData.id = this.type;
		}
		
		public DOData DOData
		{
			get
			{
				return this.c1DOData;
			}
			set
			{
				this.c1DOData = value;
			}
		}
	}
	
	/// <summary>
	/// Sequence component 2.
	/// </summary>
	public class c2 : SDOSDIDOTypeDA
	{
		private DOData c2DOData;
		
		public c2(string iedType, string lnType)
		{
			this.name = "c2";						
			this.id = this.type = lnType+"c2";
			this.iedType = iedType;	
			this.bType = tBasicTypeEnum.Struct;
		}		
		
		public void SetLinkDOData(DOData c2DOData)
		{
			this.c2DOData = c2DOData;
			this.cdc = c2DOData.cdc;
			this.c2DOData.id = this.type;
		}
		
		public DOData DOData
		{
			get
			{
				return this.c2DOData;
			}
			set
			{
				this.c2DOData = value;
			}
		}
	}
	
	/// <summary>
	/// Sequence component 3.
	/// </summary>
	public class c3 : SDOSDIDOTypeDA
	{
		private DOData c3DOData;
		
		public c3(string iedType, string lnType)
		{
			this.name = "c3";						
			this.id = this.type = lnType+"c3";
			this.iedType = iedType;			
			this.bType = tBasicTypeEnum.Struct;
		}			
		
		public void SetLinkDOData(DOData c3DOData)
		{
			this.c3DOData = c3DOData;
			this.cdc = c3DOData.cdc;
			this.c3DOData.id = this.type;
		}
		
		public DOData DOData
		{
			get
			{
				return this.c3DOData;
			}
			set
			{
				this.c3DOData = value;
			}
		}
	}
	
	/// <summary>
	/// Name of the common data class.
	/// tBasicTypeEnum.VisString255
	/// </summary>
	public class cdcName : DADataType
	{
		public cdcName(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "cdcName";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Common data class name space.
	/// tBasicTypeEnum.VisString255
	/// </summary>
	public class cdcNs : DADataType
	{
		public cdcNs(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "cdcNs";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Counter value of security violations.
	/// tBasicTypeEnum.INT32U
	/// </summary>
	public class cnt : DADataType
	{		
		public cnt(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "cnt";
			this.bType = basicTypeEnum;				
		}
	}
	
	/// <summary>
	/// Uniquely identifies the configuration of a logical device instance.
	/// tBasicTypeEnum.VisString255
	/// </summary>
	public class configRev :DADataType
	{		
		public configRev (tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "configRev ";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// The array with the points specifying a curve shape.
	/// </summary>	
	public class crvPts :SDIDADataTypeBDA
	{		
		private Point PointField;
		
		public crvPts(string iedType, string lnType)
		{		
			this.iedType = iedType;
			this.name = "crvPts";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"crvPts";
			this.bType = tBasicTypeEnum.Struct;
			this.PointField = new Point(iedType, this.id);				
		}
		
		public Point Point
		{
			get
			{
				return this.PointField;
			}
			set
			{
				this.PointField = value;
			}
		}	
	}
	
	/// <summary>
	/// Specifies the control model that corresponds to the behaviour of the data. 
	/// </summary>
	public class ctlModel : SDIDADataTypeBDA
	{
		private ctlModels ctlModelsField;
		
		public ctlModel(string iedType, string lnType)
		{
			this.name = "ctlModel";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"ctlModel";
			this.iedType = iedType;
			this.bType = tBasicTypeEnum.Struct;
			this.ctlModelsField = new ctlModels(tBasicTypeEnum.Enum);
		}
		
		public ctlModels ctlModels
		{
			get
			{
				return this.ctlModelsField;
			}
			set
			{
				this.ctlModelsField = value;
			}
		}
	}
	
	/// <summary>
	/// It shows the control sequence number of the control service.
	/// tBasicTypeEnum.INT8U
	/// </summary>
	public class ctlNum :DADataType
	{
		public ctlNum(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "ctlNum";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary> 
	///  Determines the control activity.
	/// </summary>
	public class ctlVal : DADataType
	{
		ConversionObject conversionObject;	
		public ctlVal(tBasicTypeEnum basicTypeEnum)
		{			
			conversionObject = new ConversionObject();
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(ctlValEnum.stop);
			}	
			this.name = "ctlVal";
			this.bType = basicTypeEnum;
			this.iedType = iedType;					
			this.id = this.type = "ctlValEnum";			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(ctlValEnum));			
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
		public ctlValEnum tValue
		{			
			get
			{
				return (ctlValEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(ctlValEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}
	}
	
	/// <summary>
	/// Deadbanded complex value.
	/// tBasicTypeEnum.struct
	/// </summary>
	public class cVal : SDIDADataTypeBDA
	{		
		private Vector VectorField;
		
		public cVal(string iedType, string lnType)
		{	this.name = "cVal";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"cVal";
			this.iedType = iedType;			
			this.VectorField = new Vector(iedType, this.id);			
		}	
		
		public Vector Vector	
		{
			get
			{
				return this.VectorField;
			}
			set
			{
				this.VectorField = value;
			}
		}	
	}
	
	/// <summary>
	/// Textual description of the data.
	/// tBasicTypeEnum.VisString255
	/// </summary>
	public class d : DADataType
	{
		public d(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "d";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Data name space. 
	/// tBasicTypeEnum.VisString255
	/// </summary>
	public class dataNs : DADataType
	{
		public dataNs(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "dataNs";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Deadband.
	/// tBasicTypeEnum.INT32U
	/// </summary>
	public class db :DADataType
	{		
		public db(tBasicTypeEnum basicTypeEnum)
		{					
			this.name = "db";
			this.bType = basicTypeEnum;			
		}
	}	
	
	/// <summary>
	/// General direction of the fault.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class dirGeneral :DADataType
	{		
		ConversionObject conversionObject;	
		public dirGeneral(tBasicTypeEnum basicTypeEnum)
		{			
			conversionObject = new ConversionObject();
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(dirGeneralEnum.unknown);
			}	
			this.name = "dirGeneral";
			this.bType = basicTypeEnum;
			this.iedType = iedType;					
			this.id = this.type = "dirGeneralEnum";			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(dirGeneralEnum));			
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
		public dirGeneralEnum tValue
		{			
			get
			{
				return (dirGeneralEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(dirGeneralEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}
	}	
	
	/// <summary>
	/// Direction of the fault for neut.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class dirNeut :DADataType
	{		
		ConversionObject conversionObject;		
		public dirNeut(tBasicTypeEnum basicTypeEnum)
		{		
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(dirEnum.unknown);
			}	
			this.name = "dirNeut";
			this.bType = basicTypeEnum;
			this.iedType = iedType;					
			this.id = this.type = "dirNeutEnum";			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(dirEnum));			
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
		public dirEnum tValue
		{			
			get
			{
				return (dirEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(dirEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}
	}
	
	/// <summary>
	/// Direction of the fault for phase A.
	/// </summary>
	public class dirPhsA :DADataType
	{		
		ConversionObject conversionObject;		
		public dirPhsA(tBasicTypeEnum basicTypeEnum)
		{		
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(dirEnum.unknown);
			}	
			this.name = "dirPhsA";
			this.bType = basicTypeEnum;
			this.iedType = iedType;					
			this.id = this.type = "dirPhsAEnum";			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(dirEnum));			
			this.EnumVal = new tEnumVal[valuesEnumArray.Length];
			for(int x = 0; x < valuesEnumArray.Length; x++)
			{
				tEnumVal enumVal = new tEnumVal();
				enumVal.ord = ((int) valuesEnumArray.GetValue(x)).ToString();
				enumVal.Value = valuesEnumArray.GetValue(x).ToString();
				this.EnumVal[x] = enumVal;
			}
		}
		
		[Category("DA"), DisplayName("Value"), Description("It´s the value of attribute.")]
		public dirEnum tValue
		{			
			get
			{
				return (dirEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(dirEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}				
	}
	
	/// <summary>
	/// Direction of the fault for phase B.
	/// </summary>	
	public class dirPhsB :DADataType
	{		
		ConversionObject conversionObject;		
		public dirPhsB(tBasicTypeEnum basicTypeEnum)
		{				
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(dirEnum.unknown);
			}
			this.name = "dirPhsB";
			this.bType = basicTypeEnum;
			this.iedType = iedType;					
			this.id = this.type = "dirPhsBEnum";			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(dirEnum));			
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
		public dirEnum tValue
		{			
			get
			{
				return (dirEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(dirEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}			
	}

	/// <summary>
	/// Direction of the fault for phase C.
	/// </summary>	
	public class dirPhsC :DADataType
	{		
		ConversionObject conversionObject;		
		public dirPhsC(tBasicTypeEnum basicTypeEnum)
		{		
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(dirEnum.unknown);
			}	
			this.name = "dirPhsC";
			this.bType = basicTypeEnum;
			this.iedType = iedType;					
			this.id = this.type = "dirPhsCEnum";			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(dirEnum));			
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
		public dirEnum tValue
		{			
			get
			{
				return (dirEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(dirEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}			
	}

	/// <summary>
	/// Textual description of the data using unicode characters.
	/// tBasicTypeEnum.Unicode255
	/// </summary>
	public class dU : DADataType
	{
		public dU(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "dU";
			this.bType = basicTypeEnum;			
		}
	}

	/// <summary>
	/// Number of points used to define a curve.
	/// tBasicTypeEnum.INT16U
	/// </summary>
	public class numPts : DADataType
	{
		public numPts(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "numPts";
			this.bType = basicTypeEnum;			
		}
	}

	/// <summary>
	/// Time window applied to interharmonic calculations.
	/// tBasicTypeEnum.INT16U
	/// </summary>
	public class evalTm :DADataType
	{		
		public evalTm(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "evalTm";
			this.bType = basicTypeEnum;			
		}
	}
		
	/// <summary>
	/// Controls the freeze, process.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class frEna :DADataType
	{		
		public frEna(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "frEna";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// Nominal frequency of the power system or some other fundamental frequency in Hz.
	/// tBasicTypeEnum.FLOAT32
	/// </summary>
	public class frequency :DADataType
	{		
		public frequency(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "frequency";
			this.bType = basicTypeEnum;					
		}
	}
	
	/// <summary>
	/// Time interval in ms between freeze operations.
	/// tBasicTypeEnum.INT32
	/// </summary>
	public class frPd :DADataType
	{		
		public frPd(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "frPd";
			this.bType = basicTypeEnum;			
		}
	}	
	
	/// <summary>
	/// Indicates that counter is to be automatically reset to zero after each freezing process.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class frRs :DADataType
	{		
		public frRs(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "frRs";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// Time of the last counter freeze.
	/// tBasicTypeEnum.Timestamp
	/// </summary>
	public class frTm :DADataType
	{		
		public frTm(tBasicTypeEnum basicTypeEnum)
		{					
			this.name = "frTm";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// Frozen binary counter status represented as an integer value.
	/// tBasicTypeEnum.INT128
	/// </summary>
	public class frVal : DADataType
	{		
		public frVal(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "frVal";
			this.bType = basicTypeEnum;
		}
	}
		
	/// <summary>
	/// Logical "or" of the phase values.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class general :DADataType
	{		
		public general(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "general";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// This array shall contain the harmonic and subharmonic or the interharmonic values.
	/// tBasicTypeEnum 
	/// </summary>
	public class har :DADataType
	{		
		public har(tBasicTypeEnum basicTypeEnum)
		{					
			this.name = "har";
			this.bType = basicTypeEnum;
		}
	}	
	
	/// <summary>
	/// Specifies the reference type which the data attribute mag of the data attribute type Vector 
	/// contain.
	/// </summary>
	public class hvRef :DADataType
	{		
		ConversionObject conversionObject;		
		public hvRef(tBasicTypeEnum basicTypeEnum)
		{		
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(hvRefEnum.fundamental);
			}	
			this.name = "hvRef";
			this.bType = basicTypeEnum;
			this.iedType = iedType;			
			this.id = this.type = "hvRefEnum";			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(hvRefEnum));			
			this.EnumVal = new tEnumVal[valuesEnumArray.Length];
			for(int x = 0; x < valuesEnumArray.Length; x++)
			{
				tEnumVal enumVal = new tEnumVal();
				enumVal.ord = ((int) valuesEnumArray.GetValue(x)).ToString();
				enumVal.Value = valuesEnumArray.GetValue(x).ToString();
				this.EnumVal[x] = enumVal;
			}
		}
		
		[Category("DA"), DisplayName("Value"), Description("It´s the value of attribute.")]
		public hvRefEnum tValue
		{			
			get
			{
				return (hvRefEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(hvRefEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}						
	}	
	
	/// <summary>
	/// HW-revision.
	/// tBasicTypeEnum.VisString255
	/// </summary>
	public class hwRev :DADataType
	{
		public hwRev(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "hwRev";
			this.bType = basicTypeEnum;
		}
	}
		
	/// <summary>
	/// Instant value of a vector type value.
	/// </summary>
	public class instCVal : SDIDADataTypeBDA
	{
		private Vector VectorField;		
		public instCVal(string iedType, string lnType)
		{
			this.name = "instCVal";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"instCVal";
			this.iedType = iedType;		
			this.VectorField = new Vector(iedType, this.id);			
		}
				
		public Vector Vector	
		{
			get
			{
				return this.VectorField;
			}
			set
			{
				this.VectorField = value;
			}
		}	
	}
	
	/// <summary>
	/// Magnitude of a the instantaneous value of a measured value.
	/// </summary>
	public class instMag :SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
		
		public instMag(string iedType, string lnType)
		{	
			this.name = "instMag";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"instMag";
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
	/// Logical device name space.
	/// tBasicTypeEnum.VisString255
	/// </summary>
	public class ldNs :DADataType
	{
		public ldNs(tBasicTypeEnum basicTypeEnum)
		{						
			this.name = "ldNs";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// Logical node name space. 
	/// tBasicTypeEnum.VisString255
	/// </summary>
	public class lnNs :DADataType
	{
		public lnNs(tBasicTypeEnum basicTypeEnum)
		{	
			this.name = "lnNs";
			this.bType = basicTypeEnum;
		}
	}
	
	//tBasicTypeEnum.VisString255
	/// <summary>
	/// Location, where the equipment is installed.
	/// </summary>
	public class location :DADataType
	{
		public location(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "location";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// Deadbanded value.
	/// </summary>
	public class mag : SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;		
		
		public mag(string iedType, string lnType)
		{
			this.name = "mag";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"mag";
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
	/// Scaled value configuration for magnitude.
	/// </summary>
	public class magSVC : SDIDADataTypeBDA
	{
		private ScaledValueConfig scaledValueConfigField;
		
		public magSVC(string iedType, string lnType)
		{				
			this.name = "magSVC";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"magSVC";
			this.iedType = iedType;
			this.scaledValueConfigField = new ScaledValueConfig(iedType, this.id);
		}
		
		public ScaledValueConfig ScaledValueConfig
		{
			get
			{
				return this.scaledValueConfigField;
			}
			set
			{
				this.scaledValueConfigField = value;
			}
		}		
	}
	
	/// <summary>
	/// Maximum process measurement for which values of i or f are considered within process limits.
	/// </summary>
	public class max : SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
		
		public max(string iedType, string lnType)
		{
			this.name = "max";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"max";
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
	/// Defines together with minVal the setting range.
	/// INC -> ING -> tBasicTypeEnum.INT32 
	/// BSC -> ISC -> tBasicTypeEnum.INT8
	/// APC -> ASG -> estructura compleja AnalogueValue tBasicTypeEnum.Struct
	/// </summary>
	public class maxVal : SDIDADataTypeBDA
	{
		private SDIDADataTypeBDA maxValStructure;
		
		public maxVal(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "maxVal";
			this.bType = basicTypeEnum;
		}
		
		public maxVal(string iedType, string lnType)
		{				
			this.name = "maxVal";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"maxVal";
			this.iedType = iedType;			
		}
		
		public void SetLinkSDIDADataTypeBDA(SDIDADataTypeBDA maxValStructure)
		{
			this.maxValStructure = maxValStructure;
		}
		
		public SDIDADataTypeBDA SDIDADataTypeBDA
		{
			get
			{
				return this.maxValStructure;
			}
			set
			{
				this.maxValStructure = value;
			}
		}
	}
	
	/// <summary>
	/// Minimum process measurement for which values of i or f are considered within process limits.
	/// </summary>
	public class min : SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
		
		public min(string iedType, string lnType)
		{
			this.name = "min";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"min";
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
	/// Defines together with maxVal the setting range.
	/// INC -> ING -> tBasicTypeEnum.INT32
	/// BSC -> ISC -> tBasicTypeEnum.INT8
	/// APC -> ASG -> estructura compleja AnalogueValue tBasicTypeEnum.Struct
	/// </summary>
	public class minVal : SDIDADataTypeBDA
	{
		private SDIDADataTypeBDA minValStructure;
		
		public minVal(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "minVal";
			this.bType = basicTypeEnum;
		}
		
		public minVal(string iedType, string lnType)
		{				
			this.name = "minVal";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"minVal";
			this.iedType = iedType;			
		}
		
		public void SetLinkSDIDADataTypeBDA(SDIDADataTypeBDA minValStructure)
		{
			this.minValStructure = minValStructure;
		}
		
		public SDIDADataTypeBDA SDIDADataTypeBDA
		{
			get
			{
				return this.minValStructure;
			}
			set
			{
				this.minValStructure = value;
			}
		}
	}	
	
	/// <summary>
	/// Vendor specific product name.
	/// tBasicTypeEnum.VisString255 
	/// </summary>
	public class model: DADataType
	{
		public model(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "model";
			this.bType = basicTypeEnum;
		}
	}	
	
	/// <summary>
	/// Net current.
	/// </summary>
	public class net : SDOSDIDOTypeDA
	{
		private DOData netDOData;
		
		public net(string iedType, string lnType)
		{						
			this.name = "net";
			this.id = this.type = lnType+"net";
			this.iedType = iedType;
			this.bType = tBasicTypeEnum.Struct;
		}
		
		public void SetLinkDOData(DOData netDOData)
		{
			this.netDOData = netDOData;
			this.cdc = netDOData.cdc;
			this.netDOData.id = this.type;
		}
		
		public DOData DOData
		{
			get
			{
				return this.netDOData;
			}
			set
			{
				this.netDOData = value;
			}
		}
	}
	
	/// <summary>
	/// Start event with earth current.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class neut :SDOSDIDOTypeDA
	{
		private DOData neutDOData;
		
		public neut(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "neut";
			this.bType = basicTypeEnum;			
		}
		
		public neut(string iedType, string lnType)
		{
			this.name = "neut";						
			this.id = this.type = lnType+"neut";
			this.iedType = iedType;			
		}			
		
		public void SetLinkDOData(DOData neutDOData)
		{
			this.neutDOData = neutDOData;
			this.cdc = neutDOData.cdc;
			this.neutDOData.id = this.type;
		}
		
		public DOData DOData
		{
			get
			{
				return this.neutDOData;
			}
			set
			{
				this.neutDOData = value;
			}
		}
	}
			
	/// <summary>
	/// Number of cycles of power frequency, which are used for harmonic, subharmonic and 
	/// interharmonic calculation. 
	/// tBasicTypeEnum.INT16U
	/// </summary>
	public class numCyc :DADataType
	{
		public numCyc(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "numCyc";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// Number of harmonic and subharmonics or interharmonic values that are to be returned as 
	/// the value attribute. 
	/// tBasicTypeEnum.INT16U
	/// </summary>
	public class numHar :DADataType
	{
		public numHar(tBasicTypeEnum basicTypeEnum)
		{	
			this.name = "numHar";
			this.bType = basicTypeEnum;
		}
	}
	
	/// <summary>
	/// Operation Time.
	/// tBasicTypeEnum.Timestamp
	/// </summary>
	public class operTm :DADataType
	{		
		public operTm(tBasicTypeEnum basicTypeEnum)
		{
			this.name = "operTm";
			this.bType = basicTypeEnum;
		}
	}	
	
	/// <summary>
	/// Contains information related to the originator of the last change of the controllable value 
	/// of the data.
	/// </summary>
	public class origin : SDIDADataTypeBDA
	{
		private orCat orCatField;
		private orIdent orIdentField;
		
		public origin(string iedType, string lnType)
		{
			this.name = "origin";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"Originator";
			this.iedType = iedType;			
			this.orCatField = new orCat(tBasicTypeEnum.Enum);
			this.orIdentField = new orIdent(tBasicTypeEnum.Octet64);			
		}
		
		[Required]
		public orCat orCat
		{
			get
			{
				return this.orCatField;
			}
			set
			{
				this.orCatField = value;
			}
		}
		
		[Required]
		public orIdent orIdent
		{
			get
			{
				return this.orIdentField;
			}
			set
			{
				this.orIdentField = value;
			}
		}
	}

	/// <summary>
	/// Configures the control output.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class persistent :DADataType
	{
		public persistent(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "persistent";
			this.bType = basicTypeEnum;
			this.iedType = iedType;
		}
	}
		
	/// <summary>
	/// Trip or start event of phase A.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class phsA :SDOSDIDOTypeDA
	{
		private DOData phsADOData;
		
		public phsA(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "phsA";
			this.bType = basicTypeEnum;			
		}	
		
		public phsA(string iedType, string lnType)
		{
			this.name = "phsA";						
			this.id = this.type = lnType+"phsA";
			this.iedType = iedType;			
			this.bType = tBasicTypeEnum.Struct;
		}	
		
		public void SetLinkDOData(DOData phsADOData)
		{
			this.phsADOData = phsADOData;
			this.cdc = phsADOData.cdc;
			this.phsADOData.id = this.type;
		}
		
		public DOData DOData
		{
			get
			{
				return this.phsADOData;
			}
			set
			{
				this.phsADOData = value;
			}
		}
	}
		
	/// <summary>
	/// Value of phase A to phase B measurement. 
	/// </summary>
	public class phsAB : SDOSDIDOTypeDA
	{
		private DOData phsABDOData;
		
		public phsAB(string iedType, string lnType)
		{
			this.name = "phsAB";						
			this.id = this.type = lnType+"phsAB";
			this.iedType = iedType;			
			this.bType = tBasicTypeEnum.Struct;
		}	
		
		public void SetLinkDOData(DOData phsABDOData)
		{
			this.phsABDOData = phsABDOData;
			this.cdc = phsABDOData.cdc;
			this.phsABDOData.id = this.type;
		}
		
		public DOData DOData
		{
			get
			{
				return this.phsABDOData;
			}
			set
			{
				this.phsABDOData = value;
			}
		}
	}
	
	/// <summary>
	/// Trip or start event of phase B.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class phsB : SDOSDIDOTypeDA
	{
		private DOData phsBDOData;
		
		public phsB(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "phsB";
			this.bType = basicTypeEnum;			
		}	
		
		public phsB(string iedType, string lnType)
		{
			this.name = "phsB";						
			this.id = this.type = lnType+"phsB";
			this.iedType = iedType;			
			this.bType = tBasicTypeEnum.Struct;
		}	
		
		public void SetLinkDOData(DOData phsBDOData)
		{
			this.phsBDOData = phsBDOData;
			this.cdc = phsBDOData.cdc;
			this.phsBDOData.id = this.type;
		}
		
		public DOData DOData
		{
			get
			{
				return this.phsBDOData;
			}
			set
			{
				this.phsBDOData = value;
			}
		}
	}

	/// <summary>
	/// Value of phase B to phase C measurement.
	/// </summary>
	public class phsBC : SDOSDIDOTypeDA
	{
		private DOData phsBCDOData;
		
		public phsBC(string iedType, string lnType)
		{
			this.name = "phsBC";
			this.id = this.type = lnType+"phsBC";
			this.iedType = iedType;
			this.bType = tBasicTypeEnum.Struct;
		}
		
		public void SetLinkDOData(DOData phsBCDOData)
		{
			this.phsBCDOData = phsBCDOData;
			this.cdc = phsBCDOData.cdc;
			this.phsBCDOData.id = this.type;
		}
	
		public DOData DOData
		{
			get
			{
				return this.phsBCDOData;
			}
			set
			{
				this.phsBCDOData = value;
			}
		}
	}

	/// <summary>
	/// Value of phase C to phase A measurement.
	/// </summary>
	public class phsCA : SDOSDIDOTypeDA
	{
		private DOData phsCADOData;
		
		public phsCA(string iedType, string lnType)
		{
			this.name = "phsCA";
			this.id = this.type = lnType+"phsCA";
			this.iedType = iedType;
			this.bType = tBasicTypeEnum.Struct;
		}
		
		public void SetLinkDOData(DOData phsCADOData)
		{
			this.phsCADOData = phsCADOData;
			this.cdc = phsCADOData.cdc;
			this.phsCADOData.id = this.type;
		}
		
		public DOData DOData
		{
			get
			{
				return this.phsCADOData;
			}
			set
			{
				this.phsCADOData = value;
			}
		}
	}

	/// <summary>
	/// Trip or start event of phase A.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class phsC :SDOSDIDOTypeDA
	{
		private DOData phsCDOData;
		
		public phsC(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "phsC";
			this.bType = basicTypeEnum;			
		}	
		
		public phsC(string iedType, string lnType)
		{
			this.name = "phsC";						
			this.id = this.type = lnType+"phsC";
			this.iedType = iedType;			
			this.bType = tBasicTypeEnum.Struct;
		}	
		
		public void SetLinkDOData(DOData phsCDOData)
		{
			this.phsCDOData = phsCDOData;
			this.cdc = phsCDOData.cdc;
			this.phsCDOData.id = this.type;
		}
		
		public DOData DOData
		{
			get
			{
				return this.phsCDOData;
			}
			set
			{
				this.phsCDOData = value;
			}
		}
	}	

	/// <summary>
	/// Indicates which phase has been used as reference for the transformation of phase values to 
	/// sequence values.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class phsRef :DADataType
	{
		ConversionObject conversionObject;	
		
		public phsRef(tBasicTypeEnum basicTypeEnum)
		{	
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(phsRefEnum.A);
			}	
			this.name = "phsRef";
			this.bType = basicTypeEnum;
			this.id = this.type = "phsRefEnum";
			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(phsRefEnum));			
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
		public phsRefEnum tValue
		{			
			get
			{
				return (phsRefEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(phsRefEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}			
	}	

	/// <summary>
	/// Magnitude of the counted value per count.
	/// tBasicTypeEnum.FLOAT32
	/// </summary>
	public class pulsQty :SDIDADataTypeBDA
	{
		private PulseConfig PulseConfigField;
		
		public pulsQty(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "pulsQty";
			this.bType = basicTypeEnum;			
		}
		
		public pulsQty(string iedType, string lnType)
		{			
			this.name = "pulsQty";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"pulsQty";
			this.iedType = iedType;
			this.PulseConfigField = new PulseConfig(iedType, this.id);
		}
		
		public PulseConfig PulseConfig
		{
			get
			{
				return this.PulseConfigField;
			}
			set
			{
				this.PulseConfigField = value;
			}			
		}
	}
	
	/// <summary>
	/// Quality of the attribute(s) representing the value of the data.
	/// tBasicTypeEnum.Quality
	/// </summary>
	public class q :DADataType
	{
		public q(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "q";
			this.bType = basicTypeEnum;			
		}
	}	
	
	/// <summary>
	/// Range in which the current value of instMag or instCVal.mag is.
	/// </summary>
	public class range : SDIDADataTypeBDA
	{
		private SDIDADataTypeBDA rangeStructure;
		ConversionObject conversionObject;
		
		public range(tBasicTypeEnum basicTypeEnum)
		{
			this.name = "range";
			this.bType = basicTypeEnum;			
			this.id = this.type = "rangeEnum";
		}
		
		public range(string iedType, string lnType)
		{
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(rangeEnum.normal);
			}				
			this.name = "range";			
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"range";
			this.iedType = iedType;
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(rangeEnum));
			this.EnumVal = new tEnumVal[valuesEnumArray.Length];
			for(int x = 0; x < valuesEnumArray.Length; x++)
			{
				tEnumVal enumVal = new tEnumVal();
				enumVal.ord = ((int) valuesEnumArray.GetValue(x)).ToString();
				enumVal.Value = valuesEnumArray.GetValue(x).ToString();
				this.EnumVal[x] = enumVal;
			}
		}
		
		[Category("DA"), DisplayName("Value"), Description("It´s the value of attribute.")]
		public rangeEnum tValue
		{			
			get
			{
				return (rangeEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(rangeEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}
			
		public void SetLinkSDIDADataTypeBDA(SDIDADataTypeBDA rangeStructure)
		{
			this.rangeStructure = rangeStructure;
		}
		
		public SDIDADataTypeBDA SDIDADataTypeBDA
		{
			get
			{
				return this.rangeStructure;
			}
			set
			{
				this.rangeStructure = value;
			}
		}
	}

	/// <summary>
	/// Configuration parameters as used in the context with the range attribute.
	/// </summary>
	public class rangeC : SDIDADataTypeBDA
	{
		private RangeConfig RangeConfigField;
		
		public rangeC(string iedType, string lnType)
		{
			this.name = "rangeC";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"rangeC";
			this.iedType = iedType;
			
			this.RangeConfigField = new RangeConfig(iedType, this.id);
		}
		
		public RangeConfig RangeConfig
		{
			get
			{
				return this.RangeConfigField;
			}
			set
			{
				this.RangeConfigField = value;
			}
		}
	}

	/// <summary>
	/// Residual current.
	/// </summary>
	public class res : SDOSDIDOTypeDA
	{
		private DOData resDOData;
		
		public res(string iedType, string lnType)
		{
			this.name = "res";						
			this.id = this.type = lnType+"res";
			this.iedType = iedType;			
			this.bType = tBasicTypeEnum.Struct;
		}				
		
		public void SetLinkDOData(DOData resDOData)
		{
			this.resDOData = resDOData;
			this.cdc = resDOData.cdc;
			this.resDOData.id = this.type;
		}
		
		public DOData DOData
		{
			get
			{
				return this.resDOData;
			}
			set
			{
				this.resDOData = value;
			}
		}
	}
	
	//tBasicTypeEnum.INT16U
	/// <summary>
	/// Number of cycles of power frequency, which are used for the calculation of rms values.
	/// </summary>
	public class rmsCyc :DADataType
	{
		public rmsCyc(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "rmsCyc";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Specifies the SBO-class according to the control model that corresponds to the behaviour 
	/// of the data. 
	/// </summary>
	public class sboClass : SDIDADataTypeBDA
	{
		private SboClasses SboClassesField;
		
		public sboClass(string iedType, string lnType)
		{
			this.name = "sboClass";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"sboClass";
			this.iedType = iedType;			
			this.SboClassesField = new SboClasses(tBasicTypeEnum.Enum);
		}
		
		public SboClasses SboClasses
		{
			get
			{
				return this.SboClassesField;
			}
			set
			{
				this.SboClassesField = value;
			}
		}		
	}
	
	/// <summary>
	/// Specifies the timeout according to the control model that corresponds to the behaviour 
	/// of the data. 
	/// tBasicTypeEnum.INT32U
	/// </summary>
	public class sboTimeout : DADataType
	{
		public sboTimeout(tBasicTypeEnum basicTypeEnum)
		{		
			this.name = "sboTimeout";
			this.bType = basicTypeEnum;
			this.iedType = iedType;
		}
	}	
	
	/// <summary>
	/// This attribute shall specify the type of the sequence.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class seqT  :DADataType
	{
		ConversionObject conversionObject;		
		public seqT(tBasicTypeEnum basicTypeEnum)
		{				
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(seqTEnum.pos_neg_zero);
			}	
			this.name = "seqT";
			this.bType = basicTypeEnum;
			this.id = this.type = "seqTEnum";			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(seqTEnum));			
			this.EnumVal = new tEnumVal[valuesEnumArray.Length];
			for(int x = 0; x < valuesEnumArray.Length; x++)
			{
				tEnumVal enumVal = new tEnumVal();
				enumVal.ord = x.ToString();
				enumVal.Value = valuesEnumArray.GetValue(x).ToString();
				this.EnumVal[x] = enumVal;
			}		
		}
		
		[Category("DA"), DisplayName("Value"), Description("Value of attribute.")]
		public seqTEnum tValue
		{			
			get
			{
				return (seqTEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(seqTEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}		
	}
	
	/// <summary>
	/// Serial number.
	/// </summary>
	public class serNum : DADataType
	{
		public serNum(tBasicTypeEnum basicTypeEnum)
		{	
			this.name = "serNum";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// This attribute shall describe the curve characteristic. 
	/// tBasicTypeEnum.VisString255
	/// </summary>
	/// <remarks>
	/// FC = SP
 	/// </remarks>
	public class setCharact : DADataType
	{
		public setCharact(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "setCharact";
			this.bType = basicTypeEnum;			
		}
	}

	/// <summary>
	/// This attribute shall describe the curve characteristic. 
	/// tBasicTypeEnum.VisString255
	/// </summary>
	/// <remarks>
	/// FC = SG, SE
 	/// </remarks>
	public class setCharact2 : DADataType
	{
		public setCharact2(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "setCharact2";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// The value of an analogue setting or set point.
	/// </summary>
	/// <remarks>
	/// FC = SP
 	/// </remarks>
	public class setMag :SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
		
		public setMag(string iedType, string lnType)
		{				
			this.name = "setMag";		
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"setMag";
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
	/// The value of an analogue setting or set point.
	/// </summary>
	/// <remarks>
	/// FC = SG, SE
 	/// </remarks>
	public class setMag2 :SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
		
		public setMag2(string iedType, string lnType)
		{				
			this.name = "setMag2";	
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"setMag2";
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
	/// Attribute used to set the parameter A of the setting curve.
	/// tBasicTypeEnum.FLOAT32 
	/// </summary>
	/// <remarks>
	/// FC = SP
 	/// </remarks>	
	public class setParA :DADataType
	{
		public setParA(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "setParA";
			this.bType = basicTypeEnum;			
		}
	}
	 
	/// <summary>
	/// Attribute used to set the parameter A of the setting curve.
	/// tBasicTypeEnum.FLOAT32 
	/// </summary>
	/// <remarks>
	/// FC = SG, SE 
 	/// </remarks>	
	public class setParA2 :DADataType
	{
		public setParA2(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "setParA2";
			this.bType = basicTypeEnum;			
		}
	}
	
	//tBasicTypeEnum.FLOAT32  y su FCs son: SP 
	/// <summary>
	/// Attribute used to set the parameter B of the setting curve.
	/// tBasicTypeEnum.FLOAT32 
	/// </summary>
	/// <remarks>
	/// FC = SP
 	/// </remarks>		
	public class setParB : DADataType
	{
		public setParB(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "setParB";
			this.bType = basicTypeEnum;		
		}
	}
	
	/// <summary>
	/// Attribute used to set the parameter B of the setting curve.
	/// tBasicTypeEnum.FLOAT32 
	/// </summary>
	/// <remarks>
	/// FC = SG, SE 
 	/// </remarks>	
	public class setParB2 : DADataType
	{
		public setParB2(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "setParB2";
			this.bType = basicTypeEnum;		
		}
	}
	
	/// <summary>
	/// Attribute used to set the parameter C of the setting curve.
	/// tBasicTypeEnum.FLOAT32 
	/// </summary>
	/// <remarks>
	/// FC = SP
 	/// </remarks>	
	public class setParC :DADataType
	{
		public setParC(tBasicTypeEnum basicTypeEnum)
		{					
			this.name = "setParC";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Attribute used to set the parameter C of the setting curve.
	/// tBasicTypeEnum.FLOAT32 
	/// </summary>
	/// <remarks>
	/// FC = SG, SE 
 	/// </remarks>	
	public class setParC2 :DADataType
	{
		public setParC2(tBasicTypeEnum basicTypeEnum)
		{					
			this.name = "setParC2";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Attribute used to set the parameter D of the setting curve.
	/// tBasicTypeEnum.FLOAT32 
	/// </summary>
	/// <remarks>
	/// FC = SP
 	/// </remarks>	
	public class setParD :DADataType
	{
		public setParD(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "setParD";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Attribute used to set the parameter D of the setting curve.
	/// tBasicTypeEnum.FLOAT32 
	/// </summary>
	/// <remarks>
	/// FC = SG, SE 
 	/// </remarks>	
	public class setParD2 :DADataType
	{
		public setParD2(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "setParD2";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Attribute used to set the parameter E of the setting curve.
	/// tBasicTypeEnum.FLOAT32 
	/// </summary>
	/// <remarks>
	/// FC = SP
 	/// </remarks>	
	public class setParE :DADataType
	{
		public setParE(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "setParE";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Attribute used to set the parameter E of the setting curve.
	/// tBasicTypeEnum.FLOAT32 
	/// </summary>
	/// <remarks>
	/// FC = SG, SE 
 	/// </remarks>	
	public class setParE2 :DADataType
	{
		public setParE2(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "setParE2";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Attribute used to set the parameter F of the setting curve.
	/// tBasicTypeEnum.FLOAT32 
	/// </summary>
	/// <remarks>
	/// FC = SP
 	/// </remarks>	
	public class setParF :DADataType
	{
		public setParF(tBasicTypeEnum basicTypeEnum)
		{					
			this.name = "setParF";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Attribute used to set the parameter F of the setting curve.
	/// tBasicTypeEnum.FLOAT32 
	/// </summary>
	/// <remarks>
	/// FC = SG, SE 
 	/// </remarks>	
	public class setParF2 :DADataType
	{
		public setParF2(tBasicTypeEnum basicTypeEnum)
		{					
			this.name = "setParF2";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// The value of a status setting.
	/// SPG -> tBasicTypeEnum.BOOLEAN
	/// ING -> tBasicTypeEnum.INT32
	/// </summary>
	/// <remarks>
	/// FC = SP
	/// </remarks>
	public class setVal : DADataType
	{
		public setVal(tBasicTypeEnum basicTypeEnum)
		{		
			this.name = "setVal";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// The value of a status setting.
	/// SPG -> tBasicTypeEnum.BOOLEAN
	/// ING -> tBasicTypeEnum.INT32
	/// </summary>
	/// <remarks>
	/// FC = SG, SE 
	/// </remarks>
	public class setVal2 : DADataType
	{
		public setVal2(tBasicTypeEnum basicTypeEnum)
		{		
			this.name = "setVal2";
			this.bType = basicTypeEnum;			
		}
	}	
	
	/// <summary>
	/// Severity of the last violation detected. 
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class sev :DADataType
	{
		ConversionObject conversionObject;			
		
		public sev(tBasicTypeEnum basicTypeEnum)
		{		
			conversionObject = new ConversionObject();	
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(sevEnum.unknown);
			}	
			this.name = "sev";
			this.bType = basicTypeEnum;
			this.id = this.type = "sevEnum";			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(sevEnum));			
			this.EnumVal = new tEnumVal[valuesEnumArray.Length];
			for(int x = 0; x < valuesEnumArray.Length; x++)
			{
				tEnumVal enumVal = new tEnumVal();
				enumVal.ord = ((int) valuesEnumArray.GetValue(x)).ToString();
				enumVal.Value = valuesEnumArray.GetValue(x).ToString();
				this.EnumVal[x] = enumVal;
			}
		}
		
		[Category("DA"), DisplayName("Value"), Description("It´s the value of attribute.")]
		public sevEnum tValue
		{			
			get
			{
				return (sevEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(sevEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}			
	}
	
	//tBasicTypeEnum.INT32U
	/// <summary>
	/// Sample Rate
	/// </summary>
	public class smpRate :DADataType
	{
		public smpRate(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "smpRate";
			this.bType = basicTypeEnum;
		}
	}
		
	/// <summary>
	/// Defines the step between individual values that ctlVal, setVal or setMag will accept.
	/// INC -> ING -> tBasicTypeEnum.INT32U
	/// BSC -> ISC -> tBasicTypeEnum.INT8U
	/// APC -> ASG -> AnalogueValue
	/// </summary>
	public class stepSize : SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
		
		public stepSize(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "stepSize";
			this.bType = basicTypeEnum;			
		}
		
		public stepSize(string iedType, string lnType)
		{				
			this.name = "stepSize";			
			this.iedType = iedType;
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"stepSize";
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
	/// Starting time of the freeze process.
	/// tBasicTypeEnum.Timestamp
	/// </summary>
	public class strTm :DADataType
	{
		public strTm(tBasicTypeEnum basicTypeEnum)
		{
			this.name = "strTm";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// The controllable data is in the status "selected".
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class stSeld : DADataType
	{
		public stSeld(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "stSeld";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Status value of the data.
	/// INS -> INC -> tBasicTypeEnum.INT32 
	/// SPS -> SPC -> tBasicTypeEnum.BOOLEAN
	/// DPC -> 	tBasicTypeEnum.Enum
	/// INC -> tBasicTypeEnum.INT32 
	/// </summary>
	public class stVal :DADataType
	{
		ConversionObject conversionObject;
		
		public stVal(tBasicTypeEnum basicTypeEnum)
		{				
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(valEnum.intermediate_state);
			}	
			this.name = "stVal";
			this.bType = basicTypeEnum;
			this.iedType = iedType;							
			this.id = this.type = " stValEnum";			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(valEnum));
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
		public valEnum tValue
		{			
			get
			{
				return (valEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(valEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}
	}
		
	/// <summary>
	/// Value used to substitute the data attribute instCVal.
	/// </summary>
	public class subCVal : SDIDADataTypeBDA
	{
		private Vector VectorField;
		ConversionObject conversionObject;
		
		public subCVal(string iedType, string lnType)
		{			
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(valEnum.intermediate_state);
			}	
			this.name = "subCVal";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"subCVal";
			this.iedType = iedType;			
			this.VectorField = new Vector(iedType, this.id);			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(valEnum));
			this.EnumVal = new tEnumVal[valuesEnumArray.Length];
			for(int x = 0; x < valuesEnumArray.Length; x++)
			{
				tEnumVal enumVal = new tEnumVal();
				enumVal.ord = ((int) valuesEnumArray.GetValue(x)).ToString();
				enumVal.Value = valuesEnumArray.GetValue(x).ToString();
				this.EnumVal[x] = enumVal;
			}
		}
		
		[Category("DA"), DisplayName("Value"), Description("It´s the value of attribute.")]
		public valEnum tValue
		{			
			get
			{
				return (valEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(valEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}
				
		public Vector Vector	
		{
			get
			{
				return this.VectorField;
			}
			set
			{
				this.VectorField = value;
			}
		}	
	}
	
	/// <summary>
	/// Used to enable substitution.
	/// tBasicTypeEnum.BOOLEAN
	/// </summary>
	public class subEna :DADataType
	{
		public subEna(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "subEna";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Shows the address of the device that made the substitution.
	/// tBasicTypeEnum.VisString64
	/// </summary>
	public class subID :DADataType
	{
		public subID(tBasicTypeEnum basicTypeEnum)
		{					
			this.name = "subID";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Value used to substitute the data attribute q.
	/// tBasicTypeEnum.Quality
	/// </summary>
	public class subQ :DADataType
	{
		public subQ(tBasicTypeEnum basicTypeEnum)
		{						
			this.name = "subQ";
			this.bType = basicTypeEnum;			
		}
	}	
			
	/// <summary>
	/// Value used to substitute the attribute representing the value of the data instance.
	/// INS -> DPS -> DPC -> tBasicTypeEnum.Enum
	/// MV -> tBasicTypeEnum.Struct -> AnalogueValue
	/// SPS -> SPC -> tBasicTypeEnum.BOOLEAN
	/// INC -> tBasicTypeEnum.INT32
	/// BSC -> ISC -> ValWithTrans
	/// </summary>
	public class subVal : SDIDADataTypeBDA
	{
		private SDIDADataTypeBDA subValStructure;
		
		public subVal(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "subVal";
			this.bType = basicTypeEnum;					
			this.id = this.type = " subValEnum";			
			this.EnumVal = new tEnumVal[4];
			tEnumVal enumVal0 = new tEnumVal();
			enumVal0.ord = "0";
			enumVal0.Value = "intermediate-state";
			this.EnumVal[0] = enumVal0;			
			tEnumVal enumVal1 = new tEnumVal();
			enumVal1.ord = "1";
			enumVal1.Value = "off";
			this.EnumVal[1] = enumVal1;			
			tEnumVal enumVal2 = new tEnumVal();
			enumVal2.ord = "2";
			enumVal2.Value = "on";
			this.EnumVal[2] = enumVal2;			
			tEnumVal enumVal3 = new tEnumVal();
			enumVal3.ord = "3";
			enumVal3.Value = "bad-state";
			this.EnumVal[3] = enumVal3;						
		}
			
		public subVal(string iedType, string lnType)
		{
			this.name = "subVal";			
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"subVal";
			this.iedType = iedType;
		}
		
		public void SetLinkSDIDADataTypeBDA(SDIDADataTypeBDA subValStructure)
		{
			this.subValStructure = subValStructure;
		}
		
		public SDIDADataTypeBDA SDIDADataTypeBDA
		{
			get
			{
				return this.subValStructure;
			}
			set
			{
				this.subValStructure = value;
			}
		}
	}
	
	/// <summary>
	/// Scaled value configuration.
	/// </summary>
	public class sVC : SDIDADataTypeBDA
	{
		private ScaledValueConfig scaledValueConfigField;
		
		public sVC(string iedType, string lnType)
		{				
			this.name = "sVC";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"sVC";
			this.iedType = iedType;
			this.scaledValueConfigField = new ScaledValueConfig(iedType, this.id);
		}
		
		public ScaledValueConfig ScaledValueConfig
		{
			get
			{
				return this.scaledValueConfigField;
			}
			set
			{
				this.scaledValueConfigField = value;
			}
		}	
	}

	/// <summary>
	/// SW-revision.
	/// tBasicTypeEnum.VisString255
	/// </summary>
	public class swRev :DADataType
	{
		public swRev(tBasicTypeEnum basicTypeEnum)
		{				
			this.name = "swRev";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Timestamp of the last change in one of the attribute(s) representing the value of the data 
	/// or in the q attribute.
	/// tBasicTypeEnum.Timestamp
	/// </summary>
	public class t :DADataType
	{
		public t(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "t";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Units of the attribute(s) representing the value of the data.
	/// </summary>
	public class units : SDIDADataTypeBDA
	{
		private Unit UnitField;
		
		public units(string iedType, string lnType)
		{
			this.name = "units";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"units";
			this.iedType = iedType;			
			this.UnitField = new Unit(iedType, this.id);
		}
		
		public Unit Unit
		{
			get
			{
				return this.UnitField;
			}
			set
			{
				this.UnitField = value;
			}
		}		
	}
	
	/// <summary>
	/// Value with transient indication.
	/// </summary>
	public class valWTr : SDIDADataTypeBDA
	{
		private ValWithTrans ValWithTransField;		
		
		public valWTr(string iedType, string lnType)
		{
			this.name = "valWTr";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"valWTr";
			this.iedType = iedType;			
			this.ValWithTransField = new ValWithTrans(iedType, this.id);
		}
		
		public ValWithTrans ValWithTrans
		{
			get
			{
				return this.ValWithTransField;
			}
			set
			{
				this.ValWithTransField = value;
			}
		}	
	}
	
	/// <summary>
	/// Name of the vendor.
	/// tBasicTypeEnum.VisString255
	/// </summary>
	public class vendor : DADataType
	{
		public vendor(tBasicTypeEnum basicTypeEnum)
		{						
			this.name = "vendor";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Description of the value of the x-axis of a curve.
	/// tBasicTypeEnum.VisString255
	/// </summary>
	public class xD : DADataType
	{
		public xD(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "xD";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Unit of the x-axis of a curve.
	/// </summary>
	public class xUnit : SDIDADataTypeBDA
	{
		private Unit UnitField;		
		
		public xUnit(string iedType, string lnType)
		{
			this.name = "xUnit";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"xUnit";
			this.iedType = iedType;			
			this.UnitField = new Unit(iedType, this.id);
		}
		
		public Unit Unit
		{
			get
			{
				return this.UnitField;
			}
			set
			{
				this.UnitField = value;
			}
		}	
	}
	
	/// <summary>
	/// Description of the value of the y-axis of a curve.
	/// tBasicTypeEnum.VisString255
	/// </summary>
	public class yD : DADataType
	{
		public yD(tBasicTypeEnum basicTypeEnum)
		{						
			this.name = "yD";
			this.bType = basicTypeEnum;			
		}
	}
	
	/// <summary>
	/// Unit of the y-axis of a curve.
	/// </summary>
	public class yUnit : SDIDADataTypeBDA
	{
		private Unit UnitField;		
		
		public yUnit(string iedType, string lnType)
		{
			this.name = "yUnit";
			this.bType = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"yUnit";
			this.iedType = iedType;			
			this.UnitField = new Unit(iedType, this.id);
		}
		
		public Unit Unit
		{
			get
			{
				return this.UnitField;
			}
			set
			{
				this.UnitField = value;
			}
		}	
	}
	
	/// <summary>
	/// Configuration parameter used to calculate the range around zero, where the analogue value 
	/// will be forced to zero.
	/// tBasicTypeEnum.INT32U
	/// </summary>
	public class zeroDb :DADataType
	{
		public zeroDb(tBasicTypeEnum basicTypeEnum)
		{			
			this.name = "zeroDb";
			this.bType = basicTypeEnum;			
		}
	}	
	
	
	
	
	
	
}
