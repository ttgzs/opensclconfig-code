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
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;
		private VisString255 dField;
		private VisString255 dataNsField;
		private dirGeneral dirGeneralField;
		private dirNeut dirNeutField;
		private dirPhsA dirPhsAField;
		private dirPhsB dirPhsBField;
		private dirPhsC dirPhsCField;
		private Unicode255 dUField;
		private BOOLEAN generalField;
		private BOOLEAN neutField;
		private BOOLEAN phsAField;
		private BOOLEAN phsBField;
		private BOOLEAN phsCField;
		private Quality  qField;
		private Timestamp tField;
		
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
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);
			this.dirGeneralField = new dirGeneral(tFCEnum.ST);
			this.dirNeutField = new dirNeut(tFCEnum.ST); 
			this.dirPhsAField = new dirPhsA(tFCEnum.ST);
			this.dirPhsBField = new dirPhsB(tFCEnum.ST);
			this.dirPhsCField = new dirPhsC(tFCEnum.ST);
			this.dUField = new Unicode255("dU", tFCEnum.DC);			
			this.generalField = new BOOLEAN("general", tFCEnum.ST);
			this.neutField = new BOOLEAN("neut", tFCEnum.ST);
			this.phsAField = new BOOLEAN("phsA", tFCEnum.ST);
			this.phsBField = new BOOLEAN("phsB", tFCEnum.ST);
			this.phsCField = new BOOLEAN("phsC", tFCEnum.ST);
			this.qField = new Quality("q", tFCEnum.ST);
			this.tField = new Timestamp("t", tFCEnum.ST);
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public BOOLEAN general
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
		public BOOLEAN neut
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
		public BOOLEAN phsA
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
		public BOOLEAN phsB 
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
		public BOOLEAN phsC
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
		public Quality q
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
		public Timestamp t
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
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;
		private VisString255 dField;
		private VisString255 dataNsField;
		private Unicode255 dUField;
		private BOOLEAN generalField;
		private BOOLEAN neutField;
		private Timestamp operTmField;
		private BOOLEAN phsAField;
		private BOOLEAN phsBField;
		private BOOLEAN phsCField;
		private Quality  qField;
		private Timestamp tField;	
		
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
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.generalField = new BOOLEAN("general", tFCEnum.ST);
			this.neutField = new BOOLEAN("neut", tFCEnum.ST);
			this.operTmField = new Timestamp("operTm", tFCEnum.CF);
			this.phsAField = new BOOLEAN("phsA", tFCEnum.ST);
			this.phsBField = new BOOLEAN("phsB", tFCEnum.ST);
			this.phsCField = new BOOLEAN("phsC", tFCEnum.ST);
			this.qField = new Quality("q", tFCEnum.ST);
			this.tField = new Timestamp("t", tFCEnum.ST);
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public BOOLEAN general
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
		public BOOLEAN neut
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
		public BOOLEAN phsA
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
		public BOOLEAN phsB 
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
		public BOOLEAN phsC
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
		public Quality q
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
		public Timestamp t
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
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;
		private ctlModel ctlModelField;
		private VisString255 dField;
		private VisString255 dataNsField;			
		private Unicode255 dUField;
		private maxVal maxValField;
		private minVal minValField;
		private Timestamp operTmField;
		private origin originField;
		private Quality qField;
		private setMag2 setMag2Field;
		private stepSize stepSizeField;
		private sVC sVCField;
		private Timestamp tField;
		private units unitsField;
		private VisString65 SBOField;
		private SBOw SBOwField;
		private Oper OperField;
		private Cancel CancelField;
		
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
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);
			this.ctlModelField = new ctlModel(iedType, this.id, tFCEnum.CF);
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);			
			this.dUField = new Unicode255("dU",tFCEnum.DC);			
			this.maxValField = new maxVal(iedType, this.id, tFCEnum.CF);		
			this.minValField = new minVal(iedType, this.id, tFCEnum.CF);						
			this.operTmField = new Timestamp("operTm", tFCEnum.SP);
			this.originField = new origin(iedType, this.id, tFCEnum.SP);		
			this.qField = new Quality("q", tFCEnum.MX);	
			this.setMag2Field = new setMag2(iedType, this.id, tFCEnum.SP);
			this.stepSizeField = new stepSize(iedType, this.id, tFCEnum.CF);
			this.sVCField = new sVC(iedType, this.id, tFCEnum.CF);
			this.tField = new Timestamp("t", tFCEnum.MX);
			this.unitsField = new units(iedType, this.id, tFCEnum.CF);
			this.SBOField = new VisString65("SBO", tFCEnum.SP);			
			this.SBOwField = new SBOw(iedType, this.id, tFCEnum.SP);				
			this.OperField = new Oper(iedType, this.id, tFCEnum.SP);						
			this.CancelField = new Cancel(iedType, this.id, tFCEnum.SP);						
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public Quality q
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
		public Timestamp t
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
		public VisString65 SBO
		{
			get
			{
				return this.SBOField;
			}
			set
			{
				this.SBOField = value;
			}
		}
		
		[Browsable(false)]
		public SBOw SBOw
		{
			get
			{
				return this.SBOwField;
			}
			set
			{
				this.SBOwField = value;
			}
		}
		
		[Browsable(false)]
		public Oper Oper
		{
			get
			{
				return this.OperField;
			}
			set
			{
				this.OperField = value;
			}
		}
		
		[Browsable(false)]
		public Cancel Cancel
		{
			get
			{
				return this.CancelField;
			}
			set
			{
				this.CancelField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the ASG
	/// common data class.
	/// </summary>
	public class  ASG : DOData
	{	
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;
		private VisString255 dField;
		private VisString255 dataNsField;
		private Unicode255 dUField;
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
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);
			this.dUField = new Unicode255("dU",tFCEnum.DC);			
			this.maxValField = new maxVal(iedType, this.id, tFCEnum.CF);						
			this.minValField = new minVal(iedType, this.id, tFCEnum.CF);			
			this.setMagField = new setMag(iedType, this.id, tFCEnum.SP);
			this.setMag2Field = new setMag2(iedType, this.id, tFCEnum.SG);
			this.stepSizeField = new stepSize(iedType, this.id, tFCEnum.CF);
			this.sVCField = new sVC(iedType, this.id, tFCEnum.CF);			
			this.unitsField = new units(iedType, this.id, tFCEnum.CF);
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		private INT128 actValField;
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;
		private VisString255 dField;
		private VisString255 dataNsField;
		private Unicode255 dUField;
		private BOOLEAN frEnaField;
		private INT32 frPdField;
		private BOOLEAN frRsField;
		private Timestamp frTmField;
		private INT128 frValField;
		private FLOAT32 pulsQtyField;
		private Quality qField;
		private Timestamp strTmField;
		private Timestamp tField;
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
			this.actValField = new INT128("actVal", tFCEnum.ST);
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.frEnaField = new BOOLEAN("frEna", tFCEnum.CF);
			this.frPdField = new INT32("frPd", tFCEnum.CF);
			this.frRsField = new BOOLEAN("frRs", tFCEnum.CF);
			this.frTmField = new Timestamp("frTm", tFCEnum.ST);
			this.frValField = new INT128("frVal", tFCEnum.ST);
			this.pulsQtyField = new FLOAT32("pulsQty", tFCEnum.CF);
			this.qField = new Quality("q", tFCEnum.ST);	
			this.strTmField = new Timestamp("strTm", tFCEnum.CF);
			this.tField = new Timestamp("t", tFCEnum.ST);
			this.unitsField = new units(iedType, this.id, tFCEnum.CF);
		}
		
		[Required]
		[Browsable(false)]
		public INT128 actVal
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
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public BOOLEAN frEna
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
		public INT32 frPd
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
		public BOOLEAN frRs
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
		public Timestamp frTm
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
		public INT128 frVal
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
		public FLOAT32 pulsQty
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
		public Quality q
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
		public Timestamp strTm
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
		public Timestamp t
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
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;
		private ctlModel ctlModelField;
		private INT8U ctlNumField;
		private ctlVal ctlValField;
		private VisString255 dField;
		private VisString255 dataNsField;			
		private Unicode255 dUField;
		private INT8 maxValField;
		private INT8 minValField;
		private Timestamp operTmField;
		private origin originField;
		private BOOLEAN persistentField;
		private Quality qField;
		private sboClass sboClassField;
		private INT32U sboTimeoutField;
		private INT8U stepSizeField;
		private BOOLEAN stSeldField;
		private BOOLEAN subEnaField;
		private VisString64 subIDField;
		private Quality subQField;
		private subVal subValField;
		private Timestamp tField;
		private valWTr valWTrField;
		private VisString65 SBOField;
		private SBOw SBOwField;
		private Oper OperField;
		private Cancel CancelField;
		
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
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);
			this.ctlModelField = new ctlModel(iedType, this.id, tFCEnum.CF);
			this.ctlNumField = new INT8U("ctlNum", tFCEnum.CO);
			this.ctlValField = new ctlVal(tFCEnum.CO);			
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);			
			this.dUField = new Unicode255("dU",tFCEnum.DC);						
			this.maxValField = new INT8("maxVal", tFCEnum.CF);
			this.minValField = new INT8("minVal", tFCEnum.CF);
			this.operTmField = new Timestamp("operTm", tFCEnum.CO);
			this.originField = new origin(iedType, this.id, tFCEnum.CO);
			this.persistentField = new BOOLEAN("persistent", tFCEnum.CF);
			this.qField = new Quality("q", tFCEnum.ST);	
			this.sboClassField = new sboClass(iedType, this.id, tFCEnum.CF);
			this.sboTimeoutField = new INT32U("sboTimeout", tFCEnum.CF);
			this.stepSizeField = new INT8U("stepSize", tFCEnum.CF);
			this.stSeldField = new BOOLEAN("stSeld", tFCEnum.ST);
			this.subEnaField = new BOOLEAN("subEna", tFCEnum.SV);
			this.subIDField = new VisString64("subID", tFCEnum.SV);
			this.subQField = new Quality("subQ", tFCEnum.SV);
			this.subValField = new subVal(iedType, this.id, tFCEnum.SV);
			ValWithTrans ValWithTransField = new ValWithTrans(iedType, this.subValField.id);
			this.subValField.SetLinkSDIDADataTypeBDA(ValWithTransField);
			this.tField = new Timestamp("t", tFCEnum.ST);			
			this.valWTrField = new valWTr(iedType, this.id, tFCEnum.ST);
			this.SBOField = new VisString65("SBO", tFCEnum.CO);
			this.SBOField.Visible = false;
			this.SBOwField = new SBOw(iedType, this.id, tFCEnum.CO);			
			this.OperField = new Oper(iedType, this.id, tFCEnum.CO);			
			this.CancelField = new Cancel(iedType, this.id, tFCEnum.CO);			
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public INT8 maxVal
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
		public INT8 minVal
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
		public BOOLEAN persistent
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
		public Quality q
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
		public INT32U sboTimeout
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
		public INT8U stepSize
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
		public BOOLEAN subEna
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
		public VisString64 subID
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
		public Quality subQ
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
		public Timestamp t
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
		
		[Browsable(false)]
		public VisString65 SBO
		{
			get
			{
				return this.SBOField;
			}
			set
			{
				this.SBOField = value;
			}
		}
		
		[Browsable(false)]
		public SBOw SBOw
		{
			get
			{
				return this.SBOwField;
			}
			set
			{
				this.SBOwField = value;
			}
		}
		
		[Browsable(false)]
		public Oper Oper
		{
			get
			{
				return this.OperField;
			}
			set
			{
				this.OperField = value;
			}
		}
		
		[Browsable(false)]
		public Cancel Cancel
		{
			get
			{
				return this.CancelField;
			}
			set
			{
				this.CancelField = value;
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
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;
		private cVal cValField;
		private VisString255 dField;
		private VisString255 dataNsField;
		private INT32U dbField;
		private Unicode255 dUField;
		private instCVal instCValField;
		private magSVC magSVCField;
		private Quality qField;
		private range rangeField;
		private rangeC rangeCField;
		private INT32U smpRateField;
		private subCVal subCValField;
		private BOOLEAN subEnaField;
		private VisString64 subIDField;
		private Quality subQField;
		private Timestamp tField;
		private units unitsField;
		private INT32U zeroDbField;
		
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
			this.angRefField = new angRef(tFCEnum.CF);
			this.angSVCField = new angSVC(iedType, this.id, tFCEnum.CF);
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);
			this.cValField = new cVal(iedType, this.id, tFCEnum.MX);
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);
			this.dbField = new INT32U("db", tFCEnum.CF);
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.instCValField = new instCVal(iedType, this.id, tFCEnum.MX);
			this.magSVCField = new magSVC(iedType, this.id, tFCEnum.CF);
			this.qField = new Quality("q", tFCEnum.MX);
			this.rangeField = new range(tFCEnum.MX);
			this.rangeCField = new rangeC(iedType, this.id, tFCEnum.CF);
			this.smpRateField = new INT32U("smpRate", tFCEnum.CF);
			this.subCValField = new subCVal(iedType, this.id, tFCEnum.SV);
			this.subEnaField = new BOOLEAN("subEna", tFCEnum.SV);
			this.subIDField = new VisString64("subID", tFCEnum.SV);
			this.subQField = new Quality("subQ", tFCEnum.SV);
			this.tField = new Timestamp("t", tFCEnum.MX);
			this.unitsField = new units(iedType, this.id, tFCEnum.CF);
			this.zeroDbField = new INT32U("zeroDb", tFCEnum.CF);
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
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public INT32U db
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
		public Unicode255 dU
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
		public Quality q
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
		public INT32U smpRate
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
		public BOOLEAN subEna
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
		public VisString64 subID 
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
		public Quality subQ
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
		public Timestamp t
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
		public INT32U zeroDb
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
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;
		private crvPts crvPtsField;
		private VisString255 dField;
		private VisString255 dataNsField;
		private Unicode255 dUField;
		private INT16U numPtsField;
		private VisString255 xDField;
		private xUnit xUnitField;
		private VisString255 yDField;
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
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);
			this.crvPtsField = new crvPts(iedType, this.id, tFCEnum.DC);
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.numPtsField = new INT16U("numPts", tFCEnum.DC);			
			this.xDField = new VisString255("xD", tFCEnum.DC);
			this.xUnitField = new xUnit(iedType, this.id, tFCEnum.DC);
			this.yDField = new VisString255("yD", tFCEnum.DC);
			this.yUnitField = new yUnit(iedType, this.id, tFCEnum.DC);
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public INT16U numPts
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
		public VisString255 xD
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
		public VisString255 yD 
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
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;
		private VisString255 dField;
		private VisString255 dataNsField;
		private Unicode255 dUField;
		private VisString255 setCharactField;
		private VisString255 setCharact2Field;
		private FLOAT32 setParAField;
		private FLOAT32 setParA2Field;
		private FLOAT32 setParBField;
		private FLOAT32 setParB2Field;
		private FLOAT32 setParCField;
		private FLOAT32 setParC2Field;
		private FLOAT32 setParDField;
		private FLOAT32 setParD2Field;
		private FLOAT32 setParEField;
		private FLOAT32 setParE2Field;
		private FLOAT32 setParFField;
		private FLOAT32 setParF2Field;
		
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
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.setCharactField = new VisString255("setCharact", tFCEnum.SP);
			this.setCharact2Field = new VisString255("setCharact2", tFCEnum.SG);
			this.setParAField = new FLOAT32("setParA", tFCEnum.SP);
			this.setParA2Field = new FLOAT32("setParA2", tFCEnum.SG);
			this.setParBField = new FLOAT32("setParB", tFCEnum.SP);
			this.setParB2Field = new FLOAT32("setParB2", tFCEnum.SG);
			this.setParCField = new FLOAT32("setParC", tFCEnum.SP);
			this.setParC2Field = new FLOAT32("setParC2", tFCEnum.SG);
			this.setParDField = new FLOAT32("setParD", tFCEnum.SP);
			this.setParD2Field = new FLOAT32("setParD2", tFCEnum.SG);
			this.setParEField = new FLOAT32("setParE", tFCEnum.SP);
			this.setParE2Field = new FLOAT32("setParE2", tFCEnum.SG);
			this.setParFField = new FLOAT32("setParF", tFCEnum.SP);
			this.setParF2Field = new FLOAT32("setParF2", tFCEnum.SG);
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public VisString255 setCharact
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
		public VisString255 setCharact2
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
		public FLOAT32 setParA
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
		public FLOAT32 setParA2
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
		public FLOAT32 setParB
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
		public FLOAT32 setParB2
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
		public FLOAT32 setParC
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
		public FLOAT32 setParC2
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
		public FLOAT32 setParD
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
		public FLOAT32 setParD2
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
		public FLOAT32 setParE
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
		public FLOAT32 setParE2
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
		public FLOAT32 setParF
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
		public FLOAT32 setParF2
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
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;		
		private VisString255 dField;
		private VisString255 dataNsField;		
		private Unicode255 dUField;
		private CMV phsABField;
		private CMV phsBCField;
		private CMV phsCAField;
		
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
			this.angRefField = new angRef(tFCEnum.CF);			
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);			
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);			
			this.dUField = new Unicode255("dU",tFCEnum.DC);			
			this.phsABField = new CMV("phsAB",this.id, iedType);			
			this.phsBCField = new CMV("phsBC",this.id, iedType);			
			this.phsCAField = new CMV("phsCA",this.id, iedType);			
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
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public CMV phsAB 
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
		public CMV phsBC 
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
		public CMV phsCA
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
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;
		private ctlModel ctlModelField;
		private INT8U ctlNumField;
		private BOOLEAN ctlValField;
		private VisString255 dField;
		private VisString255 dataNsField;			
		private Unicode255 dUField;		
		private Timestamp operTmField;
		private origin originField;
		private PulseConfig PulseConfigField;
		private Quality qField;
		private sboClass sboClassField;
		private INT32U sboTimeoutField;		
		private BOOLEAN stSeldField;
		private stVal stValField;
		private BOOLEAN subEnaField;
		private VisString64 subIDField;
		private Quality subQField;
		private subVal subValField;		
		private Timestamp tField;	
		private VisString65 SBOField;
		private SBOw SBOwField;
		private Oper OperField;
		private Cancel CancelField;
		
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
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);
			this.ctlModelField = new ctlModel(iedType, this.id, tFCEnum.CF);
			this.ctlNumField = new INT8U("ctlNum", tFCEnum.CO);
			this.ctlValField = new BOOLEAN("ctlVal", tFCEnum.CO);
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);			
			this.dUField = new Unicode255("dU",tFCEnum.DC);			
			this.operTmField = new Timestamp("operTm", tFCEnum.CO);
			this.originField = new origin(iedType, this.id, tFCEnum.CO);		
			this.PulseConfigField = new PulseConfig(iedType, this.id, tFCEnum.CF);
			this.qField = new Quality("q", tFCEnum.ST);
			this.sboClassField = new sboClass(iedType, this.id, tFCEnum.CF);
			this.sboTimeoutField = new INT32U("sboTimeout", tFCEnum.CF);			
			this.stSeldField = new BOOLEAN("stSeld", tFCEnum.ST);
			this.stValField = new stVal(tFCEnum.ST);
			this.subEnaField = new BOOLEAN("subEna", tFCEnum.SV);
			this.subIDField = new VisString64("subID", tFCEnum.SV);
			this.subQField = new Quality("subQ", tFCEnum.SV);
			this.subValField = new subVal(tFCEnum.SV);
			this.tField = new Timestamp("t", tFCEnum.ST);
			this.SBOField = new VisString65("SBO", tFCEnum.CO);
			this.SBOField.Visible = false;
			this.SBOwField = new SBOw(iedType, this.id, tFCEnum.CO);
			this.OperField = new Oper(iedType, this.id, tFCEnum.CO);
			this.CancelField = new Cancel(iedType, this.id, tFCEnum.CO);		
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		
		[Browsable(false)]
		public BOOLEAN ctlVal
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public Quality q
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
		public INT32U sboTimeout
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
		public BOOLEAN stSeld
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
		public BOOLEAN subEna
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
		public VisString64 subID
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
		public Quality subQ
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
		public Timestamp t
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
		public VisString65 SBO
		{
			get
			{
				return this.SBOField;
			}
			set
			{
				this.SBOField = value;
			}
		}
		
		[Browsable(false)]
		public SBOw SBOw
		{
			get
			{
				return this.SBOwField;
			}
			set
			{
				this.SBOwField = value;
			}
		}
		
		[Browsable(false)]
		public Oper Oper
		{
			get
			{
				return this.OperField;
			}
			set
			{
				this.OperField = value;
			}
		}
		
		[Browsable(false)]
		public Cancel Cancel
		{
			get
			{
				return this.CancelField;
			}
			set
			{
				this.CancelField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the DPL
	/// common data class.
	/// </summary>
	public class  DPL : DOData
	{
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;		
		private VisString255 dataNsField;
		private VisString255 hwRevField;
		private VisString255 locationField;
		private VisString255 modelField;
		private VisString255 serNumField;
		private VisString255 swRevField;
		private VisString255 vendorField;
		
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
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);			
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);
			this.hwRevField = new VisString255("hwRev", tFCEnum.DC);
			this.locationField = new VisString255("location", tFCEnum.DC);
			this.modelField = new VisString255("model", tFCEnum.DC);
			this.serNumField = new VisString255("serNum", tFCEnum.DC);
			this.swRevField = new VisString255("swRev", tFCEnum.DC);
			this.vendorField = new VisString255("vendor", tFCEnum.DC);
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 dataNs
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
		public VisString255 hwRev
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
		public VisString255 location
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
		public VisString255 model
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
		public VisString255 serNum
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
		public VisString255 swRev
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
		public VisString255 vendor 
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
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;		
		private VisString255 dField;
		private VisString255 dataNsField;			
		private Unicode255 dUField;		
		private Quality qField;
		private stVal stValField;
		private BOOLEAN subEnaField;
		private VisString64 subIDField;
		private Quality subQField;
		private subVal subValField;
		private Timestamp tField;
		
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
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);			
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);			
			this.dUField = new Unicode255("dU",tFCEnum.DC);									
			this.qField = new Quality("q", tFCEnum.ST);	
			this.stValField = new stVal(tFCEnum.ST);
			this.subEnaField = new BOOLEAN("subEna", tFCEnum.SV);
			this.subIDField = new VisString64("subID", tFCEnum.SV);
			this.subQField = new Quality("subQ", tFCEnum.SV);
			this.subValField = new subVal(tFCEnum.SV);
			this.tField = new Timestamp("t", tFCEnum.ST);
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public Quality q
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
		public BOOLEAN subEna
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
		public VisString64 subID
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
		public Quality subQ
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
		public Timestamp t
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
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;		
		private VisString255 dField;
		private VisString255 dataNsField;		
		private Unicode255 dUField;
		private INT16U evalTmField;
		private FLOAT32 frequencyField;
		private hvRef hvRefField;
		private INT16U numCycField;
		private INT16U numHarField;
//		FIXME : These attributes have a data type ARRAY[0..numHar] OF Vector and we have to verify how it works
//		      according to the IEC 61850 standard.
//		private phsABHar phsABHarField;
//		private phsBCHar phsBCHarField;
//		private phsCAHar phsCAHarField;
		private Quality qField;
		private INT16U rmsCycField;
		private INT32U smpRateField;
		private Timestamp tField;
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
			this.angRefField = new angRef(tFCEnum.CF);
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);			
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);			
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.evalTmField = new INT16U("evalTm", tFCEnum.CF);
			this.frequencyField = new FLOAT32("frequency", tFCEnum.CF);
			this.hvRefField = new hvRef(tFCEnum.CF);
			this.numCycField = new INT16U("numCyc", tFCEnum.CF);
			this.numHarField = new INT16U("numHar", tFCEnum.CF);
//			this.phsABHarField = new phsABHar(iedType, this.id, tFCEnum.MX);
//			this.phsBCHarField = new phsBCHar(iedType, this.id, tFCEnum.MX);
//			this.phsCAHarField = new phsCAHar(iedType, this.id, tFCEnum.MX);
			this.qField = new Quality("q", tFCEnum.MX);
			this.rmsCycField = new INT16U("rmsCyc", tFCEnum.CF);
			this.smpRateField = new INT32U("smpRate", tFCEnum.CF);
			this.tField = new Timestamp("t", tFCEnum.MX);
			this.unitsField = new units(iedType, this.id, tFCEnum.CF);
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
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public INT16U evalTm
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
		public FLOAT32 frequency
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
		public INT16U numCyc
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
		public INT16U numHar
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
		public Quality q
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
		public INT16U rmsCyc
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
		public INT32U smpRate
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
		public Timestamp t
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
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;
		private VisString255 dField;
		private VisString255 dataNsField;
		private Unicode255 dUField;
		private INT16U evalTmField;
		private FLOAT32 frequencyField;
//		FIXME : This attribute has a data type ARRAY[0..numHar] OF Vector and we have to verify how it works
//		      according to the IEC 61850 standard.		
//		private har harField;
		private hvRef hvRefField;
		private INT16U numCycField;
		private INT16U numHarField;
		private Quality qField;
		private INT16U rmsCycField;
		private INT32U smpRateField;
		private Timestamp tField;
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
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.evalTmField = new INT16U("evalTm", tFCEnum.CF);
			this.frequencyField = new FLOAT32("frequency", tFCEnum.CF);
//			this.harField = new har(iedType, this.id, tFCEnum.MX);
			this.hvRefField = new hvRef(tFCEnum.CF);
			this.numCycField = new INT16U("numCyc", tFCEnum.CF);
			this.numHarField = new INT16U("numHar", tFCEnum.CF);
			this.qField = new Quality("q", tFCEnum.MX);
			this.rmsCycField = new INT16U("rmsCyc", tFCEnum.CF);
			this.smpRateField = new INT32U("smpRate", tFCEnum.CF);
			this.tField = new Timestamp("t", tFCEnum.MX);
			this.unitsField = new units(iedType, this.id, tFCEnum.CF);
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public INT16U evalTm
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
		public FLOAT32 frequency
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
		public INT16U numCyc
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
		public INT16U numHar
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
		public Quality q
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
		public INT16U rmsCyc
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
		public INT32U smpRate
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
		public Timestamp t
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
		private VisString255 cdcNameField;
		private VisString255 cdcNsField;		
		private VisString255 dField;
		private VisString255 dataNsField;		
		private Unicode255 dUField;
		private INT16U evalTmField;
		private FLOAT32 frequencyField;
		private hvRef hvRefField;
//		FIXME : The attributes commented have a data type ARRAY[0..numHar] OF Vector and we have to verify how it works
//		      according to the IEC 61850 standard.		
//		private netHar netHarField;
//		private neutHar neutHarField;
		private INT16U numCycField;
		private INT16U numHarField;
//		private phsAHar phsAHarField;
//		private phsBHar phsBHarField;
//		private phsCHar phsCHarField;
		private Quality qField;
//		private resHar resHarField;
		private INT16U rmsCycField;
		private INT32U smpRateField;
		private Timestamp tField;
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
			this.angRefField = new angRef(tFCEnum.CF);			
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);			
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);			
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.evalTmField = new INT16U("evalTm", tFCEnum.CF);
			this.frequencyField = new FLOAT32("frequency", tFCEnum.CF);
			this.hvRefField = new hvRef(tFCEnum.CF);
//			this.netHarField = new netHar(iedType, this.id, tFCEnum.MX);
//			this.neutHarField = new neutHar(iedType, this.id, tFCEnum.MX);
			this.numCycField = new INT16U("numCyc", tFCEnum.CF);
			this.numHarField = new INT16U("numHar", tFCEnum.CF);
//			this.phsAHarField = new phsAHar(iedType, this.id, tFCEnum.MX);
//			this.phsBHarField = new phsBHar(iedType, this.id, tFCEnum.MX);
//			this.phsCHarField = new phsCHar(iedType, this.id, tFCEnum.MX);
			this.qField = new Quality("q", tFCEnum.MX);	
//			this.resHarField = new resHar(iedType, this.id, tFCEnum.MX);
			this.rmsCycField = new INT16U("rmsCyc", tFCEnum.CF);
			this.smpRateField = new INT32U("smpRate", tFCEnum.CF);
			this.tField = new Timestamp("t", tFCEnum.MX);
			this.unitsField = new units(iedType, this.id, tFCEnum.CF);
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
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public INT16U evalTm
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
		public FLOAT32 frequency
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
		public INT16U numCyc
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
		public INT16U numHar
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
		public Quality q
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
		public INT16U rmsCyc
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
		public INT32U smpRate
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
		public Timestamp t
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
	/// <remarks>
	/// The original type of the fields "ctlVal" and "stVal" was INT32U, it was changed because they are used as an EnumType on the DataTypeTemplates.
	/// </remarks>	
	public class  INC : DOData
	{		
		private ctlVal ctlValField;
		private Timestamp operTmField;
		private origin originField;
		private INT8U ctlNumField;
		private stVal stValField;
		private Quality  qField;
		private Timestamp tField;
		private BOOLEAN stSeldField;	
		private BOOLEAN subEnaField;	
		private INT32 subValField;
		private Quality subQField;	
		private VisString64 subIDField; 	
		private ctlModel ctlModelField;
		private INT32U sboTimeoutField;
		private sboClass sboClassField; 
		private INT32 minValField;
		private INT32 maxValField; 
		private INT32U stepSizeField; 
		private VisString255 dField;
		private Unicode255 dUField;
		private VisString255 cdcNsField;
		private VisString255 cdcNameField;
		private VisString255 dataNsField;
		private VisString65 SBOField;
		private SBOw SBOwField;
		private Oper OperField;
		private Cancel CancelField;
		
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
		/// <remarks>
		/// The original type of the fields "ctlVal" and "stVal" was INT32U, it was changed because they are used as an EnumType on the DataTypeTemplates.
		/// </remarks>			
		public INC(string name, string lnType, string iedType) : base (name, lnType+name)
		{
			this.cdc = "INC";
			this.id = this.type;
			this.iedType = iedType;				
			this.ctlValField = new ctlVal(tFCEnum.CO);
			this.operTmField = new Timestamp("operTm", tFCEnum.CO);
			this.originField = new origin(iedType, this.id, tFCEnum.CO);
			this.ctlNumField = new INT8U("ctlNum", tFCEnum.CO);
			this.stValField = new stVal(tFCEnum.ST);
			this.qField = new Quality("q", tFCEnum.ST);
			this.tField = new Timestamp("t", tFCEnum.ST);
			this.stSeldField = new BOOLEAN("stSeld", tFCEnum.ST);
			this.subEnaField = new BOOLEAN("subEna", tFCEnum.SV);	
			this.subValField = new INT32("subVal", tFCEnum.SV);
			this.subQField = new Quality("subQ", tFCEnum.SV);
			this.subIDField = new VisString64("subID", tFCEnum.SV);
			this.ctlModelField = new ctlModel(iedType, this.id, tFCEnum.CF);
			this.sboTimeoutField = new INT32U("sboTimeout", tFCEnum.CF);
			this.sboClassField = new sboClass(iedType, this.id, tFCEnum.CF);
			this.minValField = new INT32("minVal", tFCEnum.CF);
			this.maxValField = new INT32("maxVal", tFCEnum.CF);
			this.stepSizeField = new INT32U("stepSize", tFCEnum.CF); 	
			this.dField = new VisString255("d", tFCEnum.DC); 	
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);  	
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX); 
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);	
			this.SBOField = new VisString65("SBO", tFCEnum.CO);
			this.SBOField.Visible = false;
			this.SBOwField = new SBOw(iedType, this.id, tFCEnum.CO);			
			this.OperField = new Oper(iedType, this.id, tFCEnum.CO);			
			this.CancelField = new Cancel(iedType, this.id, tFCEnum.CO);			
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public INT32 maxVal
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
		public INT32 minVal
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
		public Quality q
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
		public INT32U sboTimeout
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
		public INT32U stepSize
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
		public BOOLEAN stSeld
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
		public BOOLEAN subEna
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
		public VisString64 subID
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
		public Quality subQ
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
		public INT32 subVal
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
		public Timestamp t
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
		public VisString65 SBO
		{
			get
			{
				return this.SBOField;
			}
			set
			{
				this.SBOField = value;
			}
		}
		
		[Browsable(false)]
		public SBOw SBOw
		{
			get
			{
				return this.SBOwField;
			}
			set
			{
				this.SBOwField = value;
			}
		}
		
		[Browsable(false)]
		public Oper Oper
		{
			get
			{
				return this.OperField;
			}
			set
			{
				this.OperField = value;
			}
		}
		
		[Browsable(false)]
		public Cancel Cancel
		{
			get
			{
				return this.CancelField;
			}
			set
			{
				this.CancelField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the ING
	/// common data class.
	/// </summary>
	public class  ING : DOData
	{		
		private INT32 setValField;
		private INT32 setVal2Field;
		private INT32 minValField;
		private INT32 maxValField;
		private INT32U stepSizeField; 
		private VisString255 dField; 
		private Unicode255 dUField;
		private VisString255 cdcNsField;
		private VisString255 cdcNameField;
		private VisString255 dataNsField;
		
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
			this.setValField = new INT32("setVal", tFCEnum.SP); 
			this.setVal2Field = new INT32("setVal2", tFCEnum.SG); 
			this.minValField = new INT32("minVal", tFCEnum.CF);
			this.maxValField = new INT32("maxVal", tFCEnum.CF); 	
			this.stepSizeField = new INT32U("stepSize", tFCEnum.CF);	
			this.dField = new VisString255("d", tFCEnum.DC);
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);	
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);		
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX); 		
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs	
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
		public Unicode255 dU
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
		public INT32 maxVal
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
		public INT32 minVal
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
		public INT32 setVal
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
		public INT32 setVal2
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
		public INT32U stepSize
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
	/// <remarks>
	/// The original type of the fields "stVal" was INT32U, it was changed because they are used as an EnumType on the DataTypeTemplates.
	/// </remarks>		
	public class  INS : DOData
	{		
		private stVal stValField;
		private Quality  qField;
		private Timestamp tField;
		private BOOLEAN subEnaField;
		private subVal subValField;
		private Quality subQField;
		private VisString64 subIDField;
		private VisString255 dField;
		private Unicode255 dUField;
		private VisString255 cdcNsField;
		private VisString255 cdcNameField;
		private VisString255 dataNsField;
				
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
			this.stValField = new stVal(tFCEnum.ST);
			this.qField = new Quality("q", tFCEnum.ST);
			this.tField = new Timestamp("t", tFCEnum.ST);
			this.subEnaField = new BOOLEAN("subEna", tFCEnum.SV);
			this.subValField = new subVal(tFCEnum.SV);
			this.subQField = new Quality("subQ", tFCEnum.SV);
			this.subIDField = new VisString64("subID", tFCEnum.SV);
			this.dField = new VisString255("d", tFCEnum.DC); 	
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX); 
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);	
		}	
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public Quality q
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
		public BOOLEAN subEna
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
		public VisString64 subID
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
		public Quality subQ
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
		public Timestamp t
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
		private INT8 ctlValField;
		private Timestamp operTmField;
		private origin originField;
		private INT8U ctlNumField;
		private valWTr valWTrField;
		private Quality  qField;
		private Timestamp tField;
		private BOOLEAN stSeldField;
		private BOOLEAN subEnaField;	
		private subVal subValField;
		private Quality subQField;	
		private VisString64 subIDField; 	
		private ctlModel ctlModelField;
		private INT32U sboTimeoutField;
		private sboClass sboClassField;
		private INT8 minValField;
		private INT8 maxValField; 
		private INT8U stepSizeField;
		private VisString255 dField;
		private Unicode255 dUField;		
		private VisString255 cdcNsField;
		private VisString255 cdcNameField;
		private VisString255 dataNsField;
		private VisString65 SBOField;
		private SBOw SBOwField;
		private Oper OperField;
		private Cancel CancelField;
		
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
			this.ctlValField = new INT8("ctlVal", tFCEnum.CO);
			this.operTmField = new Timestamp("operTm", tFCEnum.CO);
			this.originField = new origin(iedType, this.id, tFCEnum.CO);
			this.ctlNumField = new INT8U("ctlNum", tFCEnum.CO); 
			this.valWTrField = new valWTr(iedType, this.id, tFCEnum.ST);
			this.qField = new Quality("q", tFCEnum.ST);
			this.tField = new Timestamp("t", tFCEnum.ST);
			this.stSeldField = new BOOLEAN("stSeld", tFCEnum.ST);
			this.subEnaField = new BOOLEAN("subEna", tFCEnum.SV);			
			this.subValField = new subVal(iedType, this.id, tFCEnum.SV);
			ValWithTrans ValWithTransField = new ValWithTrans(iedType, this.subValField.id);
			this.subValField.SetLinkSDIDADataTypeBDA(ValWithTransField);			
			this.subQField = new Quality("subQ", tFCEnum.SV);
			this.subIDField = new VisString64("subID", tFCEnum.SV);
			this.ctlModelField = new ctlModel(iedType, this.id, tFCEnum.CF);
			this.sboTimeoutField = new INT32U("sboTimeout", tFCEnum.CF);
			this.sboClassField = new sboClass(iedType, this.id, tFCEnum.CF);
			this.minValField = new INT8("minVal", tFCEnum.CF);
			this.maxValField = new INT8("maxVal", tFCEnum.CF);
			this.stepSizeField = new INT8U("stepSize", tFCEnum.CF);
			this.dField = new VisString255("d", tFCEnum.DC); 	
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX); 
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);	
			this.SBOField = new VisString65("SBO", tFCEnum.CO);
			this.SBOField.Visible = false;
			this.SBOwField = new SBOw(iedType, this.id, tFCEnum.CO);			
			this.OperField = new Oper(iedType, this.id, tFCEnum.CO);			
			this.CancelField = new Cancel(iedType, this.id, tFCEnum.CO);			
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		
		[Browsable(false)]
		public INT8 ctlVal
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public INT8 maxVal
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
		public INT8 minVal
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
		public Quality q
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
		public INT32U sboTimeout
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
		public INT8U stepSize
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
		public BOOLEAN stSeld
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
		public BOOLEAN subEna
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
		public VisString64 subID
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
		public Quality subQ
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
		public Timestamp t
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
		
		[Browsable(false)]
		public VisString65 SBO
		{
			get
			{
				return this.SBOField;
			}
			set
			{
				this.SBOField = value;
			}
		}
		
		[Browsable(false)]
		public SBOw SBOw
		{
			get
			{
				return this.SBOwField;
			}
			set
			{
				this.SBOwField = value;
			}
		}
		
		[Browsable(false)]
		public Oper Oper
		{
			get
			{
				return this.OperField;
			}
			set
			{
				this.OperField = value;
			}
		}
		
		[Browsable(false)]
		public Cancel Cancel
		{
			get
			{
				return this.CancelField;
			}
			set
			{
				this.CancelField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the LPL
	/// common data class.
	/// </summary>
	public class  LPL : DOData
	{		
		private VisString255 vendorField; 
		private VisString255 swRevField;
		private VisString255 dField;
		private Unicode255 dUField; 
		private VisString255 configRevField; 
		private VisString255 ldNsField; 
		private VisString255 lnNsField;
		private VisString255 cdcNsField;
		private VisString255 cdcNameField;
		private VisString255 dataNsField;
		
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
			this.vendorField = new VisString255("vendor", tFCEnum.DC);
			this.swRevField = new VisString255("swRev", tFCEnum.DC); 
			this.dField = new VisString255("d", tFCEnum.DC); 	
			this.dUField = new Unicode255("dU",tFCEnum.DC); 
			this.configRevField = new VisString255("configRev", tFCEnum.DC); 
			this.ldNsField = new VisString255("ldNs", tFCEnum.EX); 
			this.lnNsField = new VisString255("lnNs", tFCEnum.EX); 
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX); 
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);	
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 configRev
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public VisString255 ldNs
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
		public VisString255 lnNs
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
		public VisString255 swRev
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
		public VisString255 vendor
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
		private instMag instMagField; 
		private mag magField; 
		private range rangeField;
		private Quality qField;
		private Timestamp tField;
		private BOOLEAN subEnaField;
		private subVal subValField;
		private Quality subQField;
		private VisString64 subIDField; 
		private units unitsField; 
		private INT32U dbField; 
		private INT32U zeroDbField; 
		private sVC sVCField; 
		private rangeC rangeCField; 
		private INT32U smpRateField;
		private VisString255 dField;
		private Unicode255 dUField;
		private VisString255 cdcNsField;
		private VisString255 cdcNameField;
		private VisString255 dataNsField;
		
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
			this.instMagField = new instMag(iedType, this.id, tFCEnum.MX);
			this.magField = new mag(iedType, this.id, tFCEnum.MX);			
			this.rangeField = new range(iedType, this.id, tFCEnum.MX);		
			this.qField = new Quality("q", tFCEnum.MX);
			this.tField = new Timestamp("t", tFCEnum.MX);
			this.subEnaField = new BOOLEAN("subEna", tFCEnum.SV);			
			this.subValField = new subVal(iedType, this.id, tFCEnum.SV);		
			AnalogueValue AnalogueValueField = new AnalogueValue(iedType, this.subValField.id);
			this.subValField.SetLinkSDIDADataTypeBDA(AnalogueValueField);			
			this.subQField = new Quality("subQ", tFCEnum.SV);
			this.subIDField = new VisString64("subID", tFCEnum.SV); 
			this.unitsField = new units(iedType, this.id, tFCEnum.CF); 	
			this.dbField = new INT32U("db", tFCEnum.CF);
			this.zeroDbField = new INT32U("zeroDb", tFCEnum.CF); 
			this.sVCField = new sVC(iedType, this.id, tFCEnum.CF);
			this.rangeCField = new rangeC(iedType, this.id, tFCEnum.CF);
			this.smpRateField = new INT32U("smpRate", tFCEnum.CF);
			this.dField = new VisString255("d", tFCEnum.DC); 	
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX); 
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX);
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);	
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public INT32U db
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
		public Unicode255 dU
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
		public Quality q
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
		public INT32U smpRate
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
		public BOOLEAN subEna
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
		public VisString64 subID
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
		public Quality subQ
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
		public Timestamp t
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
		public INT32U zeroDb
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
		private instMag instMagField; 
		private Quality  qField;
		private Timestamp tField; 
		private units unitsField;
		private sVC sVCField; 
		private max maxField;
		private min minField;		
		private VisString255 dField;
		private Unicode255 dUField;
		private VisString255 cdcNsField;
		private VisString255 cdcNameField;
		private VisString255 dataNsField;
		
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
			this.instMagField = new instMag(iedType, this.id, tFCEnum.MX); 
			this.qField = new Quality("q", tFCEnum.MX);
			this.tField = new Timestamp("t", tFCEnum.MX);
			this.unitsField = new units(iedType, this.id, tFCEnum.CF); 
			this.sVCField = new sVC(iedType, this.id, tFCEnum.CF);		 	
			this.maxField = new max(iedType, this.id, tFCEnum.CF);
			this.minField = new min(iedType, this.id, tFCEnum.CF);			
			this.dField = new VisString255("d", tFCEnum.DC); 	
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);  	
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX); 
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);	
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public Quality q
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
		public Timestamp t
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
		private INT32U  cntField;
		private sev sevField;
		private Timestamp tField;
		private Octet64 addrField; 	
		private VisString64 addInfoField;	
		private VisString255 dField;
		private Unicode255 dUField;
		private VisString255 cdcNsField;
		private VisString255 cdcNameField;
		private VisString255 dataNsField;
		
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
			this.cntField = new INT32U("cnt", tFCEnum.ST); 
			this.sevField = new sev(tFCEnum.ST);
			this.tField = new Timestamp("t", tFCEnum.ST); 
			this.addrField = new Octet64("addr", tFCEnum.ST);
			this.addInfoField = new VisString64("addInfo", tFCEnum.ST);
			this.dField = new VisString255("d", tFCEnum.DC); 	
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);  	
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX); 
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);							
		}
		
		[Browsable(false)]
		public VisString64 addInfo
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
		public Octet64 addr
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
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public INT32U cnt
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public Timestamp t
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
		private CMV c1Field;
		private CMV c2Field;
		private CMV c3Field; 
		private seqT seqTField;	
		private phsRef phsRefField;
		private VisString255 dField;
		private Unicode255 dUField;
		private VisString255 cdcNsField;
		private VisString255 cdcNameField;
		private VisString255 dataNsField;
		
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
			this.c1Field = new CMV("c1", this.id, iedType);			
			this.c2Field = new CMV("c2", this.id, iedType);			
			this.c3Field = new CMV("c3", this.id, iedType);			
			this.seqTField = new seqT(tFCEnum.MX);
			this.phsRefField = new phsRef(tFCEnum.CF);
			this.dField = new VisString255("d", tFCEnum.DC); 	
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);  	
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX); 
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);	
		}
		
		[Required]
		[Browsable(false)]
		public CMV c1
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
		public CMV c2
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
		public CMV c3
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
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		private BOOLEAN ctlValField;
		private Timestamp operTmField;
		private origin originField;
		private INT8U ctlNumField;
		private BOOLEAN stValField;
		private Quality  qField;
		private Timestamp tField;
		private BOOLEAN stSeldField;	
		private BOOLEAN subEnaField;	
		private BOOLEAN subValField;
		private Quality subQField;	
		private VisString64 subIDField; 
		private PulseConfig PulseConfigField; 
		private ctlModel ctlModelField;
		private INT32U sboTimeoutField;
		private sboClass sboClassField;
		private VisString255 dField;
		private Unicode255 dUField;
		private VisString255 cdcNsField;
		private VisString255 cdcNameField;
		private VisString255 dataNsField;
		private VisString65 SBOField;
		private SBOw SBOwField;
		private Oper OperField;
		private Cancel CancelField;
		
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
			this.ctlValField = new BOOLEAN("ctlVal", tFCEnum.CO);
			this.operTmField = new Timestamp("operTm", tFCEnum.CO);			
			this.ctlNumField = new INT8U("ctlNum", tFCEnum.CO);
			this.stValField = new BOOLEAN("stVal", tFCEnum.ST);
			this.qField = new Quality("q", tFCEnum.ST);
			this.tField = new Timestamp("t", tFCEnum.ST);
			this.stSeldField = new BOOLEAN("stSeld", tFCEnum.ST);
			this.subEnaField = new BOOLEAN("subEna", tFCEnum.SV);	
			this.subValField = new BOOLEAN("subVal", tFCEnum.SV);
			this.subQField = new Quality("subQ", tFCEnum.SV);
			this.subIDField = new VisString64("subID", tFCEnum.SV); 				
			this.sboTimeoutField = new INT32U("sboTimeout", tFCEnum.CF);			
			this.dField = new VisString255("d", tFCEnum.DC); 	
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);  	
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX); 
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);	
			this.originField = new origin(iedType, this.id, tFCEnum.CO);
			this.PulseConfigField = new PulseConfig(iedType, this.id, tFCEnum.CF);
			this.ctlModelField = new ctlModel(iedType, this.id, tFCEnum.CF);
			this.sboClassField = new sboClass(iedType, this.id, tFCEnum.CF);
			this.SBOField = new VisString65("SBO", tFCEnum.CO);
			this.SBOField.Visible = false;
			//Nota hay propiedades que se repiten hay q buscarlos y crear sus temporales para no generar basura
			this.SBOwField = new SBOw(iedType, this.id, tFCEnum.CO);		
			this.OperField = new Oper(iedType, this.id, tFCEnum.CO);			
			this.CancelField = new Cancel(iedType, this.id, tFCEnum.CO);
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		
		[Browsable(false)]
		public BOOLEAN ctlVal
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public Quality q
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
		public INT32U sboTimeout
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
		public BOOLEAN stSeld
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
		public BOOLEAN stVal
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
		public BOOLEAN subEna
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
		public VisString64 subID
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
		public Quality subQ
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
		public BOOLEAN subVal
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
		public Timestamp t
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
		public VisString65 SBO
		{
			get
			{
				return this.SBOField;
			}
			set
			{
				this.SBOField = value;
			}
		}
		
		[Browsable(false)]
		public SBOw SBOw
		{
			get
			{
				return this.SBOwField;
			}
			set
			{
				this.SBOwField = value;
			}
		}
		
		[Browsable(false)]
		public Oper Oper
		{
			get
			{
				return this.OperField;
			}
			set
			{
				this.OperField = value;
			}
		}
		
		[Browsable(false)]
		public Cancel Cancel
		{
			get
			{
				return this.CancelField;
			}
			set
			{
				this.CancelField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the common data attribute types that are defined for his use in the SPG
	/// common data class.
	/// </summary>
	public class  SPG : DOData
	{		
		private BOOLEAN setValField;
		private BOOLEAN setVal2Field;
		private VisString255 dField;
		private Unicode255 dUField;
		private VisString255 cdcNsField;
		private VisString255 cdcNameField;
		private VisString255 dataNsField;
		
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
			this.setValField = new BOOLEAN("setVal", tFCEnum.SP);
			this.setVal2Field = new BOOLEAN("setVal2", tFCEnum.SG);
			this.dField = new VisString255("d", tFCEnum.DC); 	
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);  	
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX); 
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);	
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public BOOLEAN setVal
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
		public BOOLEAN setVal2
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
		private BOOLEAN stValField;
		private Quality  qField;
		private Timestamp tField;
		private BOOLEAN subEnaField;	
		private BOOLEAN subValField;
		private Quality subQField;	
		private VisString64 subIDField; 
		private VisString255 dField;
		private Unicode255 dUField;
		private VisString255 cdcNsField;
		private VisString255 cdcNameField;
		private VisString255 dataNsField;
		
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
			this.stValField = new BOOLEAN("stVal", tFCEnum.ST);
			this.qField = new Quality("q", tFCEnum.ST);
			this.tField = new Timestamp("t", tFCEnum.ST);
			this.subEnaField = new BOOLEAN("subEna", tFCEnum.SV);	
			this.subValField = new BOOLEAN("subVal", tFCEnum.SV);
			this.subQField = new Quality("subQ", tFCEnum.SV);
			this.subIDField = new VisString64("subID", tFCEnum.SV); 
			this.dField = new VisString255("d", tFCEnum.DC); 	
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);  	
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX); 
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);				
		}
		
		[Browsable(false)]
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public Quality q
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
		public BOOLEAN stVal
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
		public BOOLEAN subEna
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
		public VisString64 subID
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
		public Quality subQ
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
		public BOOLEAN subVal
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
		public Timestamp t
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
		private CMV phsAField;
		private CMV phsBField;
		private CMV phsCField; 
		private CMV neutField;
		private CMV netField; 
		private CMV resField;	
		private angRef angRefField;
		private VisString255 dField;
		private Unicode255 dUField;
		private VisString255 cdcNsField;
		private VisString255 cdcNameField;
		private VisString255 dataNsField;
	
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
			this.phsAField = new CMV("phsA", this.id, iedType);							
			this.phsBField = new CMV("phsB", this.id, iedType);									
			this.phsCField = new CMV("phsC", this.id, iedType);	
			this.neutField = new CMV("neut", this.id, iedType);
			this.netField = new CMV("net", this.id, iedType); 						
			this.resField = new CMV("res", this.id, iedType);			
			this.angRefField = new angRef(tFCEnum.CF);
			this.dField = new VisString255("d", tFCEnum.DC); 	
			this.dUField = new Unicode255("dU",tFCEnum.DC);
			this.cdcNsField = new VisString255("cdcNs", tFCEnum.EX);  	
			this.cdcNameField = new VisString255("cdcName", tFCEnum.EX); 
			this.dataNsField = new VisString255("dataNs", tFCEnum.EX);				
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
		public VisString255 cdcName
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
		public VisString255 cdcNs
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
		public VisString255 d
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
		public VisString255 dataNs
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
		public Unicode255 dU
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
		public CMV net
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
		public CMV neut
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
		public CMV phsA
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
		public CMV phsB
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
		public CMV phsC
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
		public CMV res
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
		
	/// <summary>
	/// Angle reference.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class angRef : DADataType
	{
		ConversionObject conversionObject;
		public angRef(tFCEnum fCEnum)
		{					
			this.name = "angRef";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.fcEnum = fCEnum;
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
		
		public angSVC(string iedType, string lnType, tFCEnum fCEnum)
		{				
			this.name = "angSVC";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"angSVC";
			this.iedType = iedType;
			this.scaledValueConfigField = new ScaledValueConfig(iedType, this.id);
			this.scaledValueConfigField.CheckSelection = true;			
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
	/// The array with the points specifying a curve shape.
	/// </summary>	
	public class crvPts :SDIDADataTypeBDA
	{		
		private Point PointField;
		
		public crvPts(string iedType, string lnType, tFCEnum fCEnum)
		{		
			this.iedType = iedType;
			this.name = "crvPts";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"crvPts";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.PointField = new Point(iedType, this.id);				
			this.PointField.CheckSelection = true;
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
		ConversionObject conversionObject;
		
		public ctlModel(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.name = "ctlModel";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"ctlModel";
			this.iedType = iedType;
			this.ctlModelsField = new ctlModels();
			this.ctlModelsField.CheckSelection = true;
		}	
		public ctlModel (tFCEnum fCEnum)
		{		
			conversionObject = new ConversionObject();
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(ctlModelsEnum.status_only);
			}	
			this.name = "ctlModel";
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
	///  Determines the control activity.
	/// </summary>
	/// <remarks>	
	/// The set of values for ctlValEnum and valModEnum was modified and a constructor method was created 
	/// to fullfill the standard IEC61850 Ed.1.0.
	/// </remarks>
	public class ctlVal : DADataType
	{
		ConversionObject conversionObject;	
	
		public ctlVal()
		{			
			conversionObject = new ConversionObject();
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(valModEnum.on);
			}	
			this.name = "ctlVal";
			this.bTypeEnum = tBasicTypeEnum.Enum;			
			this.iedType = iedType;					
			this.id = this.type = "ctlValEnum";			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(valModEnum));			
			this.EnumVal = new tEnumVal[valuesEnumArray.Length];
			for(int x = 0; x < valuesEnumArray.Length; x++)
			{
				tEnumVal enumVal = new tEnumVal();
				enumVal.ord = ((int) valuesEnumArray.GetValue(x)).ToString();
				enumVal.Value = valuesEnumArray.GetValue(x).ToString();
				this.EnumVal[x] = enumVal;
			}								
		}
	
		public ctlVal(tFCEnum fCEnum)
		{			
			conversionObject = new ConversionObject();
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(valModEnum.on);
			}	
			this.name = "ctlVal";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.fcEnum = fCEnum;
			this.iedType = iedType;					
			this.id = this.type = "ctlValEnum";			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(valModEnum));			
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
		public valModEnum tValue
		{			
			get
			{
				return (valModEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(valModEnum));			
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
		
		public cVal(string iedType, string lnType, tFCEnum fCEnum)
		{	this.name = "cVal";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"cVal";
			this.iedType = iedType;			
			this.VectorField = new Vector(iedType, this.id);			
			this.VectorField.CheckSelection = true;
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
	/// General direction of the fault.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class dirGeneral :DADataType
	{		
		ConversionObject conversionObject;	
		public dirGeneral(tFCEnum fCEnum)
		{			
			conversionObject = new ConversionObject();
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(dirGeneralEnum.unknown);
			}	
			this.name = "dirGeneral";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.fcEnum = fCEnum;
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
		
		public dirNeut(tFCEnum fCEnum)
		{		
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(dirEnum.unknown);
			}	
			this.name = "dirNeut";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.fcEnum = fCEnum;
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
		
		public dirPhsA(tFCEnum fCEnum)
		{		
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(dirEnum.unknown);
			}	
			this.name = "dirPhsA";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.fcEnum = fCEnum;
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
		
		public dirPhsB(tFCEnum fCEnum)
		{				
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(dirEnum.unknown);
			}
			this.name = "dirPhsB";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.fcEnum = fCEnum;
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
		
		public dirPhsC(tFCEnum fCEnum)
		{		
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(dirEnum.unknown);
			}	
			this.name = "dirPhsC";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.fcEnum = fCEnum;
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
	/// Specifies the reference type which the data attribute mag of the data attribute type Vector 
	/// contain.
	/// </summary>
	public class hvRef :DADataType
	{		
		ConversionObject conversionObject;		
		
		public hvRef(tFCEnum fCEnum)
		{		
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(hvRefEnum.fundamental);
			}	
			this.name = "hvRef";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.fcEnum = fCEnum;
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
	/// Instant value of a vector type value.
	/// </summary>
	public class instCVal : SDIDADataTypeBDA
	{
		private Vector VectorField;		
		
		public instCVal(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.name = "instCVal";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"instCVal";
			this.iedType = iedType;		
			this.VectorField = new Vector(iedType, this.id);			
			this.VectorField.CheckSelection = true;
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
		
		public instMag(string iedType, string lnType, tFCEnum fCEnum)
		{	
			this.name = "instMag";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"instMag";
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
	/// Deadbanded value.
	/// </summary>
	public class mag : SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;		
		
		public mag(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.name = "mag";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"mag";
			this.iedType = iedType;			
			this.AnalogueValueField = new AnalogueValue(iedType, this.id);
			this.AnalogueValueField.CheckSelection = true;
		}
		
		public mag(string iedType, string lnType)
		{
			this.name = "mag";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"mag";
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
	/// Scaled value configuration for magnitude.
	/// </summary>
	public class magSVC : SDIDADataTypeBDA
	{
		private ScaledValueConfig scaledValueConfigField;
		
		public magSVC(string iedType, string lnType, tFCEnum fCEnum)
		{				
			this.name = "magSVC";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"magSVC";
			this.iedType = iedType;
			this.scaledValueConfigField = new ScaledValueConfig(iedType, this.id);
			this.scaledValueConfigField.CheckSelection = true;
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
		
		public max(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.name = "max";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"max";
			this.iedType = iedType;
			this.AnalogueValueField = new AnalogueValue(iedType, this.id);
			this.AnalogueValueField.CheckSelection = true;
		}
		
		public max(string iedType, string lnType)
		{
			this.name = "max";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"max";
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
	/// Defines together with minVal the setting range.
	/// INC -> ING -> tBasicTypeEnum.INT32 
	/// BSC -> ISC -> tBasicTypeEnum.INT8
	/// APC -> ASG -> estructura compleja AnalogueValue tBasicTypeEnum.Struct
	/// </summary>
	public class maxVal : SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;				
		
		public maxVal(string iedType, string lnType, tFCEnum fCEnum)
		{				
			this.name = "maxVal";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"maxVal";
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
	/// Minimum process measurement for which values of i or f are considered within process limits.
	/// </summary>
	public class min : SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
		
		public min(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.name = "min";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;			
			this.id = this.type = lnType+"min";
			this.iedType = iedType;
			this.AnalogueValueField = new AnalogueValue(iedType, this.id);
			this.AnalogueValueField.CheckSelection = true;
		}
		
		public min(string iedType, string lnType)
		{
			this.name = "min";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"min";
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
	/// Defines together with maxVal the setting range.
	/// INC -> ING -> tBasicTypeEnum.INT32
	/// BSC -> ISC -> tBasicTypeEnum.INT8
	/// APC -> ASG -> estructura compleja AnalogueValue tBasicTypeEnum.Struct
	/// </summary>
	public class minVal : SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
		
		public minVal(string iedType, string lnType, tFCEnum fCEnum)
		{				
			this.name = "minVal";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"minVal";
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
	/// Contains information related to the originator of the last change of the controllable value 
	/// of the data.
	/// </summary>
	public class origin : SDIDADataTypeBDA
	{
		private orCat orCatField;
		private Octet64 orIdentField;
		
		public origin(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.name = "origin";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"Originator";
			this.iedType = iedType;			
			this.orCatField = new orCat();
			this.orIdentField = new Octet64("orIdent");			
		}
		
		public origin(string iedType, string lnType)
		{
			this.name = "origin";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.id = this.type = lnType+"Originator";
			this.iedType = iedType;			
			this.orCatField = new orCat();
			this.orIdentField = new Octet64("orIdent");			
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
		public Octet64 orIdent
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
	/// Indicates which phase has been used as reference for the transformation of phase values to 
	/// sequence values.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class phsRef :DADataType
	{
		ConversionObject conversionObject;	
		
		public phsRef(tFCEnum fCEnum)
		{	
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(phsRefEnum.A);
			}	
			this.name = "phsRef";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.fcEnum = fCEnum;
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
		
		public pulsQty(string iedType, string lnType, tFCEnum fCEnum)
		{			
			this.name = "pulsQty";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"pulsQty";
			this.iedType = iedType;
			this.PulseConfigField = new PulseConfig(iedType, this.id);
			this.PulseConfigField.CheckSelection = true;
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
	/// Range in which the current value of instMag or instCVal.mag is.
	/// </summary>
	public class range : SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
		ConversionObject conversionObject;
		
		public range(tFCEnum fCEnum)
		{
			this.name = "range";
			this.bTypeEnum = tBasicTypeEnum.Enum;			
			this.fcEnum = fCEnum;
			this.id = this.type = "rangeEnum";
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(rangeEnum.normal);
			}				
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
		
		public range(string iedType, string lnType, tFCEnum fCEnum)
		{					
			this.name = "range";			
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"range";
			this.iedType = iedType;
			this.AnalogueValueField = new AnalogueValue(iedType, this.id);
			this.AnalogueValueField.CheckSelection = true;
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
	/// Configuration parameters as used in the context with the range attribute.
	/// </summary>
	public class rangeC : SDIDADataTypeBDA
	{
		private RangeConfig RangeConfigField;
		
		public rangeC(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.name = "rangeC";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"rangeC";
			this.iedType = iedType;
			
			this.RangeConfigField = new RangeConfig(iedType, this.id);
			this.RangeConfigField.CheckSelection = true;
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
	/// Specifies the SBO-class according to the control model that corresponds to the behaviour 
	/// of the data. 
	/// </summary>
	public class sboClass : SDIDADataTypeBDA
	{
		private SboClasses SboClassesField;
		
		public sboClass(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.name = "sboClass";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"sboClass";
			this.iedType = iedType;			
			this.SboClassesField = new SboClasses();
			this.SboClassesField.CheckSelection = true;
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
	/// This attribute shall specify the type of the sequence.
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class seqT  :DADataType
	{
		ConversionObject conversionObject;		
		
		public seqT(tFCEnum fCEnum)
		{				
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(seqTEnum.pos_neg_zero);
			}	
			this.name = "seqT";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.fcEnum = fCEnum;
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
	/// The value of an analogue setting or set point.
	/// </summary>
	/// <remarks>
	/// FC = SP
 	/// </remarks>
	public class setMag :SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
		
		public setMag(string iedType, string lnType, tFCEnum fCEnum)
		{				
			this.name = "setMag";		
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"setMag";
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
	/// The value of an analogue setting or set point.
	/// </summary>
	/// <remarks>
	/// FC = SG, SE
 	/// </remarks>
	public class setMag2 :SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
		
		public setMag2(string iedType, string lnType, tFCEnum fCEnum)
		{				
			this.name = "setMag2";	
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"setMag2";
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
	/// Severity of the last violation detected. 
	/// tBasicTypeEnum.Enum
	/// </summary>
	public class sev :DADataType
	{
		ConversionObject conversionObject;			
		
		public sev(tFCEnum fCEnum)
		{		
			conversionObject = new ConversionObject();	
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(sevEnum.unknown);
			}	
			this.name = "sev";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.fcEnum = fCEnum;
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
	
	/// <summary>
	/// Defines the step between individual values that ctlVal, setVal or setMag will accept.
	/// INC -> ING -> tBasicTypeEnum.INT32U
	/// BSC -> ISC -> tBasicTypeEnum.INT8U
	/// APC -> ASG -> AnalogueValue
	/// </summary>
	public class stepSize : SDIDADataTypeBDA
	{
		private AnalogueValue AnalogueValueField;
		
		public stepSize(string iedType, string lnType, tFCEnum fCEnum)
		{				
			this.name = "stepSize";			
			this.iedType = iedType;
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"stepSize";
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
	/// Status value of the data.
	/// INS -> INC -> tBasicTypeEnum.INT32 
	/// SPS -> SPC -> tBasicTypeEnum.BOOLEAN
	/// DPC -> 	tBasicTypeEnum.Enum
	/// INC -> tBasicTypeEnum.INT32 
	/// </summary>
	public class stVal :DADataType
	{
		ConversionObject conversionObject;		
		/// <summary>
		/// This constructor was created empty and the data will be set the values when 
		/// the type changes from enum to int32
		/// </summary>
		public stVal()
		{	
			this.Value="";
		}
		
		public stVal(tFCEnum fCEnum)
		{				
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(valModEnum.on);
			}	
			this.name = "stVal";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.fcEnum = fCEnum;
			this.iedType = iedType;							
			this.id = this.type = " stValEnum";			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(valModEnum));
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
		public valModEnum tValue
		{			
			get
			{
				return (valModEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(valModEnum));											
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
		
		public subCVal(string iedType, string lnType, tFCEnum fCEnum)
		{			
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(valEnum.intermediate_state);
			}	
			this.name = "subCVal";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
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
		
		public subVal(tFCEnum fCEnum)
		{				
			this.name = "subVal";
			this.bTypeEnum = tBasicTypeEnum.Enum;					
			this.fcEnum = fCEnum;
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
			
		public subVal(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.name = "subVal";			
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
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
		
		public sVC(string iedType, string lnType, tFCEnum fCEnum)
		{				
			this.name = "sVC";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"sVC";
			this.iedType = iedType;
			this.scaledValueConfigField = new ScaledValueConfig(iedType, this.id);
			this.scaledValueConfigField.CheckSelection = true;
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
	/// Units of the attribute(s) representing the value of the data.
	/// </summary>
	public class units : SDIDADataTypeBDA
	{
		private Unit UnitField;
		
		public units(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.name = "units";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"units";
			this.iedType = iedType;			
			this.UnitField = new Unit(iedType, this.id);
			this.UnitField.CheckSelection = true;
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
		
		public valWTr(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.name = "valWTr";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"valWTr";
			this.iedType = iedType;			
			this.ValWithTransField = new ValWithTrans(iedType, this.id);
			this.ValWithTransField.CheckSelection = true;
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
	/// Unit of the x-axis of a curve.
	/// </summary>
	public class xUnit : SDIDADataTypeBDA
	{
		private Unit UnitField;		
		
		public xUnit(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.name = "xUnit";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"xUnit";
			this.iedType = iedType;			
			this.UnitField = new Unit(iedType, this.id);
			this.UnitField.CheckSelection = true;
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
	/// Unit of the y-axis of a curve.
	/// </summary>
	public class yUnit : SDIDADataTypeBDA
	{
		private Unit UnitField;		
		
		public yUnit(string iedType, string lnType, tFCEnum fCEnum)
		{
			this.name = "yUnit";
			this.bTypeEnum = tBasicTypeEnum.Struct;
			this.fcEnum = fCEnum;
			this.id = this.type = lnType+"yUnit";
			this.iedType = iedType;			
			this.UnitField = new Unit(iedType, this.id);
			this.UnitField.CheckSelection = true;
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
	
	public class valMod :DADataType
	{
		ConversionObject conversionObject;
		
		public valMod(tFCEnum fCEnum)
		{				
			conversionObject = new ConversionObject();			
			if(this.Value==null)
			{
				this.Value = this.conversionObject.SetEnumObjectToString(valModEnum.on);
			}	
			this.name = "stVal";
			this.bTypeEnum = tBasicTypeEnum.Enum;
			this.fcEnum = fCEnum;
			this.iedType = iedType;							
			this.id = this.type = " stValEnum";			
			Array valuesEnumArray = conversionObject.GetValuesEnumToArray(typeof(valModEnum));
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
		public valModEnum tValue
		{			
			get
			{
				return (valModEnum) this.conversionObject.SetStringToEnumObject(this.Value, typeof(valModEnum));			
			}
			set
			{
				this.Value = this.conversionObject.SetEnumObjectToString(value);				
			}
		}
	}
}
