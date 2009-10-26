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

namespace IEC61850.SCL
{
	/// <summary>
	/// Description of LNTypes.
	/// </summary>			
	public class DOData : tDOType
	{
		public bool CheckSelection = false;
		public string nameField;
		public string typeField;
		
		public DOData(string name, string type)
		{
			this.nameField = name;
			this.typeField = type;
		}
		
		[ReadOnly(true)]
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
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ANCR" (Neutral current regulator).
	/// </summary>
	public class ANCR : CommonLogicalNode
	{
		private BSC TapChgField;
		private INC OpCntRsField;
		private SPS AutoField;		
		private SPS LocField;
		private SPC LColField;
		private SPC RColField;	
		private ING HaRstField;
		
		public ANCR(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.ANCR;
			this.iedType = iedType;
			this.TapChgField = new BSC("TapChg", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.AutoField = new SPS("Auto", lnType, iedType);
			this.LocField = new SPS("Loc", lnType, iedType);
			this.LColField = new SPC("LCol", lnType, iedType);
			this.RColField = new SPC("RCol", lnType, iedType); 			
			this.HaRstField = new ING("HaRst", lnType, iedType); 				
		}	
		
		[Required]
		public BSC TapChg
		{			
			get 
			{
				return this.TapChgField;
			}			
			set
			{				
				this.TapChgField = value;
			}
		}
	
		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}
	
		public SPC LCol
		{			
			get 
			{
				return this.LColField;
			}			
			set
			{				
				this.LColField = value;
			}
		}		
	
		public SPC RCol
		{			
			get 
			{
				return this.RColField;
			}			
			set
			{				
				this.RColField = value;
			}
		}
	
		public SPS Auto
		{			
			get 
			{
				return this.AutoField;
			}			
			set
			{				
				this.AutoField = value;
			}
		}	
	
		[Required]
		public SPS Loc 
		{			
			get 
			{
				return this.LocField;
			}			
			set
			{				
				this.LocField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ARCO" (Reactive power control).
	/// </summary>
	public class ARCO : CommonLogicalNode
	{
		private BSC TapChgField;
		private INC OpCntRsField;
		private SPS AutoField;
		private SPS DschBlkField;
		private SPS LocField;
		private SPS NeutAlmField;
		private SPS VOvStField;
			
		public ARCO(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.ARCO;
			this.iedType = iedType;			
			this.TapChgField = new BSC("TapChg", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.AutoField = new SPS("Auto", lnType, iedType);
			this.DschBlkField = new SPS("DschBlk", lnType, iedType);
			this.LocField = new SPS("Loc", lnType, iedType);
			this.NeutAlmField = new SPS("NeutAlm", lnType, iedType);
			this.VOvStField = new SPS("VOvSt", lnType, iedType);
		}	
		
		[Required]
		public BSC TapChg
		{			
			get 
			{
				return this.TapChgField;
			}			
			set
			{				
				this.TapChgField = value;
			}
		}
	
		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}
	
		public SPS Auto
		{			
			get 
			{
				return this.AutoField;
			}			
			set
			{				
				this.AutoField = value;
			}
		}	
	
		public SPS DschBlk
		{			
			get 
			{
				return this.DschBlkField;
			}			
			set
			{				
				this.DschBlkField = value;
			}
		}
	
		[Required]
		public SPS Loc 
		{			
			get 
			{
				return this.LocField;
			}			
			set
			{				
				this.LocField = value;
			}
		}
	
		public SPS NeutAlm
		{			
			get 
			{
				return this.NeutAlmField;
			}			
			set
			{				
				this.NeutAlmField = value;
			}
		}
	
		public SPS VOvSt
		{			
			get 
			{
				return this.VOvStField;
			}			
			set
			{				
				this.VOvStField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ATCC" (Automatic tap changer controller).
	/// </summary>	
	public class ATCC : CommonLogicalNode
	{		
		private ASG BlkLVField;
		private ASG BlkRVField;
		private ASG BndCtrField;
		private ASG BndWidField;
		private ASG LDCRField;
		private ASG LDCXField;
		private ASG LDCZField;
		private ASG LimLodAField;
		private ASG RnbkRVField;
		private ASG VRedValField;		
		private BSC TapChgField;
		private DPC ParOpField;		
		private INC OpCntRsField;
		private ING CtlDlTmmsField;		
		private ING TapBlkLField;
		private ING TapBlkRField;
		private INS HiTapPosField;
		private INS LoTapPosField;
		private INC TapPosField;
		private MV CircAField;
		private MV CtlVField;	
		private MV HiCtlVField;
		private MV HiDmdAField;
		private MV LoCtlVField;
		private MV LodAField;
		private MV PhAngField;
		private SPC LTCBlkField;
		private SPC LTCDragRsField;
		private SPC VRed1Field;
		private SPC VRed2Field;
		private SPG LDCField;
		private SPG TmDlChrField;		
		private SPS AutoField;		
		private SPS LocField;
					
		public ATCC(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.ATCC;
			this.iedType = iedType;
			this.BlkLVField = new ASG("BlkLV", lnType, iedType);
			this.BlkRVField = new ASG("BlkRV", lnType, iedType);
			this.BndCtrField = new ASG("BndCtr", lnType, iedType);
			this.BndWidField = new ASG("BndWid", lnType, iedType);
			this.LDCRField = new ASG("LDCR", lnType, iedType);
			this.LDCXField = new ASG("LDCX", lnType, iedType);
			this.LDCZField = new ASG("LDCZ", lnType, iedType);
			this.LimLodAField = new ASG("LimLodA", lnType, iedType);
			this.RnbkRVField = new ASG("RnbkRV", lnType, iedType);
			this.VRedValField = new ASG("VRedVal", lnType, iedType);
			this.TapChgField = new BSC("TapChg", lnType, iedType);			
			this.ParOpField = new DPC("ParOp", lnType, iedType);						
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.CtlDlTmmsField = new ING("CtlDlTmms", lnType, iedType);
			this.TapBlkLField = new ING("TapBlkL", lnType, iedType);
			this.TapBlkRField = new ING("TapBlkR", lnType, iedType);
			this.HiTapPosField = new INS("HiTapPos", lnType, iedType);
			this.LoTapPosField = new INS("LoTapPos", lnType, iedType);
			this.TapPosField = new INC("TapPos", lnType, iedType);
			this.CircAField = new MV("CircA", lnType, iedType);
			this.CtlVField = new MV("CtlV", lnType, iedType);
			this.HiCtlVField = new MV("HiCtlV", lnType, iedType);
			this.HiDmdAField = new MV("HiDmdA", lnType, iedType);
			this.LoCtlVField = new MV("LoCtlV", lnType, iedType);
			this.PhAngField = new MV("PhAng", lnType, iedType);
			this.LTCBlkField = new SPC("LTCBlk", lnType, iedType);
			this.LTCDragRsField = new SPC("LTCDragRs", lnType, iedType);
			this.VRed1Field = new SPC("VRed1", lnType, iedType);
			this.VRed2Field = new SPC("VRed2", lnType, iedType);
			this.LDCField = new SPG("LDC", lnType, iedType);
			this.TmDlChrField = new SPG("TmDlChr", lnType, iedType);
			this.AutoField = new SPS("Auto", lnType, iedType);
			this.LocField = new SPS("Loc", lnType, iedType);			
		}	
		
		public ASG BlkLV
		{			
			get 
			{
				return this.BlkLVField;
			}			
			set
			{				
				this.BlkLVField = value;
			}
		}
		
		public ASG BlkRV
		{			
			get 
			{
				return this.BlkRVField;
			}			
			set
			{				
				this.BlkRVField = value;
			}
		}
	
		public ASG BndCtr
		{			
			get 
			{
				return this.BndCtrField;
			}			
			set
			{				
				this.BndCtrField = value;
			}
		}
	
		public ASG BndWid
		{			
			get 
			{
				return this.BndWidField;
			}			
			set
			{				
				this.BndWidField = value;
			}
		}
	
		public ASG LDCR
		{			
			get 
			{
				return this.LDCRField;
			}			
			set
			{				
				this.LDCRField = value;
			}
		}
		
		public ASG LDCX
		{			
			get 
			{
				return this.LDCXField;
			}			
			set
			{				
				this.LDCXField = value;
			}
		}
	
		public ASG LDCZ
		{			
			get 
			{
				return this.LDCZField;
			}			
			set
			{				
				this.LDCZField = value;
			}
		}
	
		public ASG LimLodA
		{			
			get 
			{
				return this.LimLodAField;
			}			
			set
			{				
				this.LimLodAField = value;
			}
		}
	
		public ASG RnbkRV
		{			
			get 
			{
				return this.RnbkRVField;
			}			
			set
			{				
				this.RnbkRVField = value;
			}
		}
	
		public ASG VRedVal
		{			
			get 
			{
				return this.VRedValField;
			}			
			set
			{				
				this.VRedValField = value;
			}
		}
	
		public BSC TapChg
		{			
			get 
			{
				return this.TapChgField;
			}			
			set
			{				
				this.TapChgField = value;
			}
		}
	
		[Required]
		public DPC ParOp
		{			
			get 
			{
				return this.ParOpField;
			}			
			set
			{				
				this.ParOpField = value;
			}
		}
	
		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}
	
		public ING CtlDlTmms
		{			
			get 
			{
				return this.CtlDlTmmsField;
			}			
			set
			{				
				this.CtlDlTmmsField = value;
			}
		}	
	
		public ING TapBlkL
		{			
			get 
			{
				return this.TapBlkLField;
			}			
			set
			{				
				this.TapBlkLField = value;
			}
		}
	
		public ING TapBlkR
		{			
			get 
			{
				return this.TapBlkRField;
			}			
			set
			{				
				this.TapBlkRField = value;
			}
		}
	
		public INS HiTapPos
		{			
			get 
			{
				return this.HiTapPosField;
			}			
			set
			{				
				this.HiTapPosField = value;
			}
		}

		public INS LoTapPos
		{			
			get 
			{
				return this.LoTapPosField;
			}			
			set
			{				
				this.LoTapPosField = value;
			}
		}
		
		public INC TapPos
		{			
			get 
			{
				return this.TapPosField;
			}			
			set
			{				
				this.TapPosField = value;
			}
		}
	
		public MV CircA
		{			
			get 
			{
				return this.CircAField;
			}			
			set
			{				
				this.CircAField = value;
			}
		}
		
		[Required]
		public MV CtlV
		{			
			get 
			{
				return this.CtlVField;
			}			
			set
			{				
				this.CtlVField = value;
			}
		}
	
		public MV HiCtlV
		{			
			get 
			{
				return this.HiCtlVField;
			}			
			set
			{				
				this.HiCtlVField= value;
			}
		}
	
		public MV HiDmdA
		{			
			get 
			{
				return this.HiCtlVField;
			}			
			set
			{				
				this.HiCtlVField= value;
			}
		}
		
		public MV LoCtlV
		{			
			get 
			{
				return this.LoCtlVField;
			}			
			set
			{				
				this.LoCtlVField= value;
			}
		}
		
		public MV PhAng
		{			
			get 
			{
				return this.PhAngField;
			}			
			set
			{				
				this.PhAngField= value;
			}
		}
	
		public SPC LTCBlk
		{			
			get 
			{
				return this.LTCBlkField;
			}			
			set
			{				
				this.LTCBlkField= value;
			}
		}
	
		public SPC LTCDragRs
		{			
			get 
			{
				return this.LTCDragRsField;
			}			
			set
			{				
				this.LTCDragRsField = value;
			}
		}
	
		public SPC VRed1
		{			
			get 
			{
				return this.VRed1Field;
			}			
			set
			{				
				this.VRed1Field = value;
			}
		}
	
		public SPC VRed2
		{			
			get 
			{
				return this.VRed2Field;
			}			
			set
			{				
				this.VRed2Field = value;
			}
		}
	
		public SPG LDC
		{			
			get 
			{
				return this.LDCField;
			}			
			set
			{				
				this.LDCField = value;
			}
		}
	
		public SPG TmDlChr
		{			
			get 
			{
				return this.TmDlChrField;
			}			
			set
			{				
				this.TmDlChrField = value;
			}
		}
		
		public SPS Auto
		{			
			get 
			{
				return this.AutoField;
			}			
			set
			{				
				this.AutoField = value;
			}
		}	
		
		[Required]
		public SPS Loc 
		{			
			get 
			{
				return this.LocField;
			}			
			set
			{				
				this.LocField = value;
			}
		}		
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "AVCO" (Voltage control).
	/// </summary>		
	public class AVCO : CommonLogicalNode
	{	
		private ASG LimAOvField;
		private ASG LimVOvField;
		private BSC TapChgField;
		private INC OpCntRsField;
		private SPS AutoField;		
		private SPS BlkAOvField;
		private SPS BlkEFField;
		private SPS BlkVOvField;		
		private SPS LocField;		
		
		public AVCO(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.AVCO;
			this.iedType = iedType;			
			this.LimAOvField = new ASG("LimAOv",lnType, iedType);
			this.LimVOvField = new ASG("LimVOv",lnType, iedType);
			this.TapChgField = new BSC("TapChg", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.AutoField = new SPS("Auto", lnType, iedType);
			this.BlkAOvField = new SPS("BlkAOv",lnType, iedType);
			this.BlkEFField = new SPS("BlkEF",lnType, iedType);
			this.BlkVOvField = new SPS("BlkVOv",lnType, iedType);
			this.LocField = new SPS("Loc", lnType, iedType);
		}
		
		public ASG LimAOv
		{			
			get 
			{
				return this.LimAOvField;
			}			
			set
			{				
				this.LimAOvField = value;
			}
		}

		public ASG LimVOv
		{			
			get 
			{
				return this.LimVOvField;
			}			
			set
			{				
				this.LimVOvField = value;
			}
		}

		[Required]
		public BSC TapChg
		{			
			get 
			{
				return this.TapChgField;
			}			
			set
			{				
				this.TapChgField = value;
			}
		}

		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}
			
		public SPS Auto
		{			
			get 
			{
				return this.AutoField;
			}			
			set
			{				
				this.AutoField = value;
			}
		}	
	
		public SPS BlkAOv
		{			
			get 
			{
				return this.BlkAOvField;
			}			
			set
			{				
				this.BlkAOvField = value;
			}
		}
	
		public SPS BlkEF
		{			
			get 
			{
				return this.BlkEFField;
			}			
			set
			{				
				this.BlkEFField = value;
			}
		}

		[Required]
		public SPS Loc 
		{			
			get 
			{
				return this.LocField;
			}			
			set
			{				
				this.LocField = value;
			}
		}	
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "CALH" (Alarm handling).
	/// </summary>		
	public class CALH : CommonLogicalNode
	{	
		private SPS AlmLstOvField;
		private SPS GrAlmField;
		private SPS GrWrnField;
	
		public CALH(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.CALH;
			this.iedType = iedType;			
			this.AlmLstOvField = new SPS("AlmLstOv", lnType, iedType); 				 
			this.GrAlmField = new SPS("GrAlm", lnType, iedType); 				 
			this.GrWrnField = new SPS("GrWrn", lnType, iedType); 				 			                                                      			                                                      
		}

		public SPS AlmLstOv
		{			
			get 
			{
				return this.AlmLstOvField;
			}			
			set
			{				
				this.AlmLstOvField = value;
			}
		}	
	
		[Required]
		public SPS GrAlm
		{			
			get 
			{
				return this.GrAlmField;
			}			
			set
			{				
				this.GrAlmField = value;
			}
		}
	
		public SPS GrWrn
		{			
			get 
			{
				return this.GrWrnField;
			}			
			set
			{				
				this.GrWrnField = value;
			}
		}		
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "CCGR" (Cooling group control).
	/// </summary>		
	public class CCGR : CommonLogicalNode
	{	
		private ASG OilTmpSetField;
		private DPL EENameField;
		private INC FanCtlField;
		private INC FanCtlGenField;
		private INC PmpCtlField;
		private INC PmpCtlGenField;
		private INS EEHealthField;
		private INS OpTmhField;
		private MV EnvTmpField;
		private MV FanAField;
		private MV FanFlwField;
		private MV OilMotAField;
		private MV OilTmplnField;
		private MV OilTmpOutField;
		private SPC CECtlField;
		private SPS AutoField;		
		private SPS FanOvCurField;
		private SPS PmpAlmField;
		private SPS PmpOvCurField;
	
		public CCGR(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.CCGR;
			this.iedType = iedType;			
			this.OilTmpSetField = new ASG("OilTmpSet", lnType, iedType); 				 
			this.EENameField = new DPL("EEName",  lnType, iedType);
			this.FanCtlField = new INC("FanCtl", lnType, iedType);
			this.FanCtlGenField = new INC("FanCtlGen", lnType, iedType);
			this.PmpCtlField = new INC("PmpCtl", lnType, iedType);
			this.PmpCtlGenField = new INC("PmpCtlGen", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
			this.EnvTmpField = new MV("EnvTmp",  lnType, iedType);
			this.FanAField = new MV("FanA", lnType, iedType);
			this.FanFlwField = new MV("FanFlw", lnType, iedType);
			this.OilMotAField = new MV("OilMotA", lnType, iedType);
			this.OilTmplnField = new MV("OilTmpln", lnType, iedType);
			this.OilTmpOutField = new MV("OilTmpOut", lnType, iedType);
			this.CECtlField = new SPC("CECtl", lnType, iedType);
			this.AutoField = new SPS("Auto", lnType, iedType);
			this.FanOvCurField = new SPS("FanOvCur", lnType, iedType);
			this.PmpAlmField = new SPS("PmpAlm", lnType, iedType);
			this.PmpOvCurField = new SPS("PmpOvCur", lnType, iedType); 
		}

		public ASG OilTmpSet
		{			
			get 
			{
				return this.OilTmpSetField;
			}			
			set
			{				
				this.OilTmpSetField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{				
				this.EENameField = value;
			}
		}
	
		public INC FanCtl
		{			
			get 
			{
				return this.FanCtlField;
			}		
			set
			{				
				this.FanCtlField = value;
			}
		}

		public INC FanCtlGen
		{			
			get 
			{
				return this.FanCtlGenField;
			}			
			set
			{				
				this.FanCtlGenField = value;
			}
		}

		public INC PmpCtl
		{			
			get 
			{
				return this.PmpCtlField;
			}			
			set
			{				
				this.PmpCtlField = value;
			}
		}

		public INC PmpCtlGen
		{			
			get 
			{
				return this.PmpCtlGenField;
			}			
			set
			{				
				this.PmpCtlGenField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}		
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}
	
		public MV EnvTmp
		{			
			get 
			{
				return this.EnvTmpField;
			}			
			set
			{				
				this.EnvTmpField = value;
			}
		}

		public MV FanA
		{			
			get 
			{
				return this.FanAField;
			}			
			set
			{				
				this.FanAField = value;
			}
		}

		public MV FanFlw
		{			
			get 
			{
				return this.FanFlwField;
			}			
			set
			{				
				this.FanFlwField = value;
			}
		}
	
		public MV OilMotA
		{			
			get 
			{
				return this.OilMotAField;
			}			
			set
			{				
				this.OilMotAField = value;
			}
		}

		public MV OilTmpln
		{			
			get 
			{
				return this.OilTmplnField;
			}			
			set
			{				
				this.OilTmplnField= value;
			}
		}

		public MV OilTmpOut
		{			
			get 
			{
				return this.OilTmpOutField;
			}			
			set
			{				
				this.OilTmpOutField = value;
			}
		}

		public SPC CECtl
		{			
			get 
			{
				return this.CECtlField;
			}			
			set
			{				
				this.CECtlField = value;
			}
		}

		public SPS Auto
		{			
			get 
			{
				return this.AutoField;
			}			
			set
			{				
				this.AutoField = value;
			}
		}	
	
		public SPS FanOvCur
		{			
			get 
			{
				return this.FanOvCurField;
			}			
			set
			{				
				this.FanOvCurField  = value;
			}
		}
	
		public SPS PmpAlm
		{			
			get 
			{
				return this.PmpAlmField;
			}			
			set
			{				
				this.PmpAlmField = value;
			}
		}

		public SPS PmpOvCur
		{			
			get 
			{
				return this.PmpOvCurField;
			}			
			set
			{				
				this.PmpOvCurField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "CILO" (Interlocking).
	/// </summary>
	public class CILO : CommonLogicalNode	
	{	
		private SPS EnaClsField;
		private SPS EnaOpnField;
		
		public CILO(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.CILO;
			this.iedType = iedType;			
			this.EnaClsField = new SPS("EnaCls",  lnType, iedType);
			this.EnaOpnField = new SPS("EnaOpn",  lnType, iedType);
		}
	
		[Required]
		public SPS EnaCls
		{			
			get 
			{
				return this.EnaClsField;
			}			
			set
			{				
				this.EnaClsField  = value;
			}
		}

		[Required]
		public SPS EnaOpn
		{			
			get 
			{
				return this.EnaOpnField;
			}			
			set
			{				
				this.EnaOpnField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the 
	/// Common Logical Node.
	/// </summary>
	public class CommonLogicalNode : tLNodeType
	{				
		public bool CheckSelection = false;
		public string lnType;
		private INC ModField;	
		private INC OpCntRsField;
		private INS BehField;		
		private INS EEHealthField;
		private INS HealthField;
		private INS OpCntField;
		private INS OpTmhField;	
		private LPL NamPltField;
		private SPS LocField;		
	
		public CommonLogicalNode(string lnType, string iedType)
		{						
			this.lnType = lnType;
			this.ModField = new INC("Mod", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs",  lnType, iedType);
		  	this.BehField = new INS("Beh", lnType, iedType);
		 	this.EEHealthField = new INS("EEHealth",  lnType, iedType);
			this.HealthField = new INS("Health",  lnType, iedType);
			this.OpCntField = new INS("OpCnt",  lnType, iedType);
			this.OpTmhField = new INS("OpTmh",  lnType, iedType);
			this.NamPltField = new LPL("NamPlt",  lnType, iedType);
			this.LocField = new SPS("Loc",  lnType, iedType);	  	
		}
		
		[Required]
		public INC Mod
		{			
			get 
			{
				return this.ModField;
			}			
			set
			{				
				this.ModField = value;
			}
		}	

		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}
	
		[Required]
		public INS Beh
		{
			get
			{				
				return this.BehField;
			}
			set
			{
				this.BehField = value;
			}
		}
	
		public INS EEHealth
		{
			get
			{				
				return this.EEHealthField;
			}
			set
			{
				this.EEHealthField = value;
			}
		}

		[Required]
		public INS Health
		{
			get
			{				
				return this.HealthField;
			}
			set
			{
				this.HealthField = value;
			}
		}

		public INS OpCnt
		{
			get
			{				
				return this.OpCntField;
			}
			set
			{
				this.OpCntField = value;
			}
		}

		public INS OpTmh
		{
			get
			{				
				return this.OpTmhField;
			}
			set
			{
				this.OpTmhField = value;
			}
		}
	
		[Required]
		public LPL NamPlt
		{
			get
			{				
				return this.NamPltField;
			}
			set
			{
				this.NamPltField = value;
			}
		}

		public SPS Loc
		{
			get
			{				
				return this.LocField;
			}
			set
			{
				this.LocField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "CPOW" (Point-on-wave switching).
	/// </summary>		
	public class CPOW : CommonLogicalNode	
	{	
		private ACT OpClsField;
		private ACT OpOpnField;
		private ING MaxDlTmmsField;
		private SPS StrPOWField;
		private SPS TmExcField;
	
		public CPOW(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.CPOW;
			this.iedType = iedType;
			this.OpClsField = new ACT("OpCls",  lnType, iedType);
			this.OpOpnField = new ACT("OpOpn",  lnType, iedType);
			this.MaxDlTmmsField = new ING("MaxDlTmms",  lnType, iedType);
			this.StrPOWField = new SPS("StrPOW",  lnType, iedType);
			this.TmExcField = new SPS("TmExc",  lnType, iedType);
		}
	
		public ACT OpCls
		{
			get
			{				
				return this.OpClsField;
			}
			set
			{
				this.OpClsField = value;
			}
		}

		public ACT OpOpn
		{
			get
			{				
				return this.OpOpnField;
			}
			set
			{
				this.OpOpnField = value;
			}
		}

		public ING MaxDlTmms
		{
			get
			{				
				return this.MaxDlTmmsField;
			}
			set
			{
				this.MaxDlTmmsField = value;
			}
		}
	
		public SPS StrPOW
		{
			get
			{				
				return this.StrPOWField;
			}
			set
			{
				this.StrPOWField = value;
			}
		}

		[Required]
		public SPS TmExc
		{
			get
			{				
				return this.TmExcField;
			}
			set
			{
				this.TmExcField = value;
			}
		}
	}	
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "CSWI" (Switch controller).
	/// </summary>		
	public class CSWI : CommonLogicalNode
	{	
		private ACT OpClsField;
		private ACT OpOpnField;
		private DPC PosField;
		private DPC PosAField;
		private DPC PosBField;
		private DPC PosCField;
		private INC OpCntRsField;
		private SPS LocField;

		public CSWI(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.CSWI;
			this.iedType = iedType;			
			this.OpClsField = new ACT("OpCls", lnType, iedType);
			this.OpOpnField = new ACT("OpOpn", lnType, iedType);
			this.PosField = new DPC("Pos", lnType, iedType);
			this.PosAField = new DPC("PosA", lnType, iedType);
			this.PosBField = new DPC("PosB", lnType, iedType);
			this.PosCField = new DPC("PosC", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.LocField = new SPS("Loc", lnType, iedType);
		}

		public ACT OpCls
		{
			get
			{				
				return this.OpClsField;
			}
			set
			{
				this.OpClsField = value;
			}
		}
	
		public ACT OpOpn
		{
			get
			{				
				return this.OpOpnField;
			}
			set
			{
				this.OpOpnField = value;
			}
		}

		[Required]
		public DPC Pos
		{
			get
			{				
				return this.PosField;
			}
			set
			{
				this.PosField  = value;
			}
		}

		public DPC PosA
		{
			get
			{				
				return this.PosAField;
			}
			set
			{
				this.PosAField = value;
			}
		}

		public DPC PosB
		{
			get
			{				
				return this.PosBField;
			}
			set
			{
				this.PosBField = value;
			}
		}

		public DPC PosC
		{
			get
			{				
				return this.PosCField;
			}
			set
			{
				this.PosCField = value;
			}
		}
	
		private INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public SPS Loc
		{			
			get 
			{
				return this.LocField;
			}			
			set
			{				
				this.LocField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "GAPC" (Generic automatic process control).
	/// </summary>		
	public class GAPC : CommonLogicalNode
	{
		private ACD StrField;
		private ACT OpField;
		private ASG StrValField;
		private DPC DPCSOField;
		private INC ISCSOField;
		private INC OpCntRsField;
		private SPC SPCSOField;
		private SPS AutoField;		
		private SPS LocField;

		public GAPC(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.GAPC;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField =new ACT("Op", lnType, iedType);
		 	this.StrValField = new ASG("StrVal", lnType, iedType);
			this.DPCSOField = new DPC("DPCSO", lnType, iedType);
			this.ISCSOField = new INC("ISCSO", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.SPCSOField = new SPC("SPCSO", lnType, iedType);
			this.AutoField = new SPS("Auto", lnType, iedType);
			this.LocField = new SPS("Loc", lnType, iedType);
		}
	
		[Required]
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public ASG StrVal
		{			
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		}
	
		public DPC DPCSO
		{			
			get 
			{
				return this.DPCSOField;
			}			
			set
			{				
				this.DPCSOField = value;
			}
		}
	
		public INC ISCSO
		{			
			get 
			{
				return this.ISCSOField;
			}			
			set
			{				
				this.ISCSOField = value;
			}
		}
	
		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public SPC SPCSO
		{			
			get 
			{
				return this.SPCSOField;
			}			
			set
			{				
				this.SPCSOField = value;
			}
		}		
	
		public SPS Auto
		{			
			get 
			{
				return this.AutoField;
			}			
			set
			{				
				this.AutoField = value;
			}
		}		
	
		public SPS Loc
		{			
			get 
			{
				return this.LocField;
			}			
			set
			{				
				this.LocField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "GGIO" (Generic process I/O).
	/// </summary>		
	public class GGIO : CommonLogicalNode
	{
		private DPC DPCSOField;
		private DPL EENameField;
		private INC ISCSOField;
		private INC OpCntRsField;
		private INS EEHealthField;
		private INS IntInField;
		private MV AnInField;
		private SPC SPCSOField;
		private SPS AlmField;
		private SPS IndField;
		private SPS LocField;
	
		public GGIO(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.GGIO;
			this.iedType = iedType;			
			this.DPCSOField = new DPC("DPCSO", lnType, iedType);
			this.EENameField = new DPL("EEName",  lnType, iedType);
			this.ISCSOField = new INC("ISCSO", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.IntInField = new INS("IntIn", lnType, iedType);
			this.AnInField = new MV("AnIn", lnType, iedType);
			this.SPCSOField = new SPC("SPCSO", lnType, iedType);
			this.AlmField = new SPS("Alm", lnType, iedType);
			this.IndField = new SPS("Ind", lnType, iedType);
			this.LocField = new SPS("Loc", lnType, iedType);
		}		
		
		public DPC DPCSO
		{			
			get 
			{
				return this.DPCSOField;
			}			
			set
			{				
				this.DPCSOField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{				
				this.EENameField = value;
			}
		}

		public INC ISCSO
		{			
			get 
			{
				return this.ISCSOField;
			}			
			set
			{				
				this.ISCSOField = value;
			}
		}

		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}
	
		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS IntIn
		{			
			get 
			{
				return this.IntInField;
			}			
			set
			{				
				this.IntInField = value;
			}
		}	

		public MV AnIn
		{			
			get 
			{
				return this.AnInField;
			}			
			set
			{				
				this.AnInField = value;
			}
		}

		public SPC SPCSO
		{			
			get 
			{
				return this.SPCSOField;
			}			
			set
			{				
				this.SPCSOField = value;
			}
		}	

		public SPS Alm
		{			
			get 
			{
				return this.AlmField;
			}			
			set
			{				
				this.AlmField = value;
			}
		}	

		public SPS Ind
		{			
			get 
			{
				return this.IndField;
			}			
			set
			{				
				this.IndField = value;
			}
		}			

		public SPS Loc
		{			
			get 
			{
				return this.LocField;
			}			
			set
			{				
				this.LocField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "GSAL" (Generic security application).
	/// </summary>
	public class GSAL : CommonLogicalNode
	{		
		private INC NumCntRsField;
		private INC OpCntRsField;		
		private SEC AcsCtlFailField;
		private SEC AuthFailField;
		private SEC InaField;
		private SEC SvcViolField;
		
		public GSAL(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.GSAL;
			this.iedType = iedType;			
			this.NumCntRsField = new INC("NumCntRs", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs",  lnType, iedType);
			this.AcsCtlFailField = new SEC("AcsCtlFail", lnType, iedType);
			this.AuthFailField = new SEC("AuthFail", lnType, iedType);
			this.InaField = new SEC("Ina", lnType, iedType);
			this.SvcViolField = new SEC("SvcViol", lnType, iedType);
		}

		[Required]
		public INC NumCntRs
		{			
			get 
			{
				return this.NumCntRsField;
			}			
			set
			{				
				this.NumCntRsField = value;
			}
		}	

		[Required]
		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		[Required]
		public SEC AcsCtlFail
		{			
			get 
			{
				return this.AcsCtlFailField;
			}			
			set
			{				
				this.AcsCtlFailField = value;
			}
		}

		[Required]
		public SEC AuthFail
		{			
			get 
			{
				return this.AuthFailField;
			}			
			set
			{				
				this.AuthFailField = value;
			}
		}

		[Required]
		public SEC Ina
		{			
			get 
			{
				return this.InaField;
			}			
			set
			{				
				this.InaField = value;
			}
		}

		[Required]
		public SEC SvcViol
		{			
			get 
			{
				return this.SvcViolField;
			}			
			set
			{				
				this.SvcViolField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "IARC" (Archiving).
	/// </summary>	
	public class IARC : CommonLogicalNode
	{		
		private INC NumCntRsField;
		private INC OpCntRsField;			
		private ING MaxNumRcdField;
		private ING MemFullField;
		private ING OpModField;
		private INS MemUsedField;
		private INS NumRcdField;
		private SPS MemOvField;
	
		public IARC(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.IARC;
			this.iedType = iedType;			
			this.NumCntRsField = new INC("NumCntRs", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs",  lnType, iedType);
			this.MaxNumRcdField = new ING("MaxNumRcd",  lnType, iedType);
			this.MemFullField = new ING("MemFull",  lnType, iedType);
			this.OpModField = new ING("OpMod",  lnType, iedType);
			this.MemUsedField = new INS("MemUsed", lnType, iedType);
			this.NumRcdField = new INS("NumRcd", lnType, iedType);
			this.MemOvField = new SPS("MemOv", lnType, iedType);
		}

		[Required]
		public INC NumCntRs
		{			
			get 
			{
				return this.NumCntRsField;
			}			
			set
			{				
				this.NumCntRsField = value;
			}
		}	

		[Required]
		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING MaxNumRcd
		{			
			get 
			{
				return this.MaxNumRcdField;
			}			
			set
			{				
				this.MaxNumRcdField = value;
			}
		}

		public ING MemFull
		{			
			get 
			{
				return this.MemFullField;
			}			
			set
			{				
				this.MemFullField = value;
			}
		}

		public ING OpMod
		{			
			get 
			{
				return this.OpModField;
			}			
			set
			{				
				this.OpModField = value;
			}
		}

		public INS MemUsed
		{			
			get 
			{
				return this.MemUsedField;
			}			
			set
			{				
				this.MemUsedField = value;
			}
		}

		public INS NumRcd
		{			
			get 
			{
				return this.NumRcdField;
			}			
			set
			{				
				this.NumRcdField = value;
			}
		}
	
		[Required]
		public SPS MemOv
		{			
			get 
			{
				return this.MemOvField;
			}			
			set
			{				
				this.MemOvField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "IHMI" (Human machine interface).
	/// </summary>		
	public class IHMI : CommonLogicalNode
	{
		public IHMI(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.IHMI;
			this.iedType = iedType;
		}
	}	

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ITCI" (Telecontrol interface).
	/// </summary>		
	public class ITCI : CommonLogicalNode
	{
		public ITCI(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.ITCI;
			this.iedType = iedType;
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ITMI" (Telemonitoring interface).
	/// </summary>		
	public class ITMI : CommonLogicalNode
	{
		public ITMI(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.ITMI;
			this.iedType = iedType;
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "LLN0" (Logical node zero).
	/// </summary>		
	public class LLN0 : CommonLogicalNode
	{
		private INS OpTmhField;
		private SPC DiagField;
		private SPC LEDRsField;
		private SPS LocField;
	
		public LLN0(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.LLN0;
			this.iedType = iedType;
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
			this.DiagField = new SPC("Diag", lnType, iedType);
			this.LEDRsField = new SPC("LEDRs", lnType, iedType);
			this.LocField = new SPS("Loc", lnType, iedType);
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}

		public SPC Diag
		{			
			get 
			{
				return this.DiagField;
			}			
			set
			{				
				this.DiagField = value;
			}
		}

		public SPC LEDRs
		{			
			get 
			{
				return this.LEDRsField;
			}			
			set
			{				
				this.LEDRsField = value;
			}
		}
	
		public SPS Loc
		{			
			get 
			{
				return this.LocField;
			}			
			set
			{				
				this.LocField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "LPHD" (Physical device information).
	/// </summary>
	public class LPHD : CommonLogicalNode
	{
		private DPL PhyNamField;
		private INS PhyHealthField;
		private INS NumPwrUpField;
		private INS WrmStrField;
		private INS WacTrgField;
		private SPC RsStatField;
		private SPS OutOvField;
		private SPS ProxyField;
		private SPS InOvField;
		private SPS PwrUpField;
		private SPS PwrDnField;
		private SPS PwrSupAlmField;
	
		public LPHD(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.LPHD;
			this.iedType = iedType;			
			this.PhyNamField = new DPL("PhyNam", lnType, iedType);				 
			this.PhyHealthField = new INS("PhyHealth", lnType, iedType);
			this.NumPwrUpField = new INS("NumPwrUp", lnType, iedType);
			this.WrmStrField = new INS("WrmStr", lnType, iedType);
			this.WacTrgField = new INS("WacTrg", lnType, iedType);
			this.RsStatField = new SPC("RsStat", lnType, iedType);
			this.OutOvField = new SPS("OutOv", lnType, iedType);
			this.ProxyField = new SPS("Proxy", lnType, iedType);
			this.InOvField = new SPS("InOv", lnType, iedType);
			this.PwrUpField = new SPS("PwrUp", lnType, iedType);
			this.PwrDnField = new SPS("PwrDn", lnType, iedType);
			this.PwrSupAlmField = new SPS("PwrSupAlm", lnType, iedType);
		}
		
		[Required]
		public DPL PhyNam
		{					
			get 
			{
				return this.PhyNamField;
			}			
			set
			{				
				this.PhyNamField = value;
			}
		}

		[Required]
		public INS PhyHealth
		{					
			get 
			{
				return this.PhyHealthField;
			}			
			set
			{				
				this.PhyHealthField = value;
			}
		}
	
		public INS NumPwrUp
		{					
			get 
			{
				return this.NumPwrUpField;
			}			
			set
			{				
				this.NumPwrUpField = value;
			}
		}

		public INS WrmStr
		{					
			get 
			{
				return this.WrmStrField;
			}			
			set
			{				
				this.WrmStrField = value;
			}
		}

		public INS WacTrg
		{					
			get 
			{
				return this.WacTrgField;
			}			
			set
			{				
				this.WacTrgField = value;
			}
		}

		public SPC RsStat
		{					
			get 
			{
				return this.RsStatField;
			}			
			set
			{				
				this.RsStatField = value;
			}
		}
	
		public SPS OutOv
		{					
			get 
			{
				return this.OutOvField;
			}			
			set
			{				
				this.OutOvField = value;
			}
		}
	
		[Required]
		public SPS Proxy
		{					
			get 
			{
				return this.ProxyField;
			}		
			set
			{				
				this.ProxyField = value;
			}
		}

		public SPS InOv
		{					
			get 
			{
				return this.InOvField;
			}			
			set
			{				
				this.InOvField = value;
			}
		}

		public SPS PwrUp
		{					
			get 
			{
				return this.PwrUpField;
			}			
			set
			{				
				this.PwrUpField = value;
			}
		}
	
		public SPS PwrDn
		{					
			get 
			{
				return this.PwrDnField;
			}			
			set
			{				
				this.PwrDnField = value;
			}
		}

		public SPS PwrSupAlm
		{					
			get 
			{
				return this.PwrSupAlmField;
			}			
			set
			{				
				this.PwrSupAlmField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "MDIF" (Differential measurements).
	/// </summary>	
	public class MDIF : CommonLogicalNode
	{
		private SAV Amp1Field;
		private SAV Amp2Field;
		private SAV Amp3Field;
		private WYE OpARemField;
		
		public MDIF(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.MDIF;
			this.iedType = iedType;			
			this.Amp1Field = new SAV("Amp1", lnType, iedType);				 
			this.Amp2Field = new SAV("Amp2", lnType, iedType);				 
			this.Amp3Field = new SAV("Amp3", lnType, iedType);				 
			this.OpARemField = new WYE("OpARem", lnType, iedType);				 			
		}
		
		public SAV Amp1
		{					
			get 
			{
				return this.Amp1Field;
			}			
			set
			{				
				this.Amp1Field = value;
			}
		}

		public SAV Amp2
		{					
			get 
			{
				return this.Amp2Field;
			}			
			set
			{				
				this.Amp2Field = value;
			}
		}

		public SAV Amp3
		{					
			get 
			{
				return this.Amp3Field;
			}			
			set
			{				
				this.Amp3Field = value;
			}
		}

		public WYE OpARem
		{					
			get 
			{
				return this.OpARemField;
			}			
			set
			{				
				this.OpARemField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "MHAI" (Harmonics or interharmonics).
	/// </summary>		
	public class MHAI : CommonLogicalNode
	{
		private ASG HzSetField;
		private ASG EvTmmsField;
		private ASG ThdAValField;
		private ASG ThdVValField;
		private ASG NomAField;
		private DEL HRmsPPVField;
		private DEL ThdPPVField;
		private DEL ThdOddPPVField;
		private DEL ThdEvnPPVField;
		private DEL HCfPPVField;
		private DPL EENameField;
		private HDEL HPPVField;
		private HWYE HAField;
		private HWYE HPhVField;
		private HWYE HWField;
		private HWYE HVArField;
		private HWYE HVAField;
		private ING NumCycField;
		private ING ThdATmmsField;
		private ING ThdVTmmsField;
		private INS EEHealthField;
		private MV HzField;
		private WYE HRmsAField;
		private WYE HRmsPhVField;
		private WYE HTuWField;
		private WYE HTsWField;
		private WYE HATmField;
		private WYE HKfField;
		private WYE HTdfField;
		private WYE ThdAField;
		private WYE ThdOddAField;
		private WYE ThdEvnAField;
		private WYE TddAField;
		private WYE TddOddAField;
		private WYE TddEvnAField;
		private WYE ThdPhVField;
		private WYE ThdOddPhVField;
		private WYE ThdEvnPhVField;
		private WYE HCfPhVField;
		private WYE HCfAField;
		private WYE HTifField;
	
		public MHAI(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.MHAI;
			this.iedType = iedType;			
			this.HzSetField = new ASG("HzSet", lnType, iedType);
			this.EvTmmsField = new ASG("EvTmms", lnType, iedType);
			this.ThdAValField = new ASG("ThdAVal", lnType, iedType);
			this.ThdVValField = new ASG("ThdVVal", lnType, iedType);
			this.NomAField = new ASG("NomA", lnType, iedType);
			this.HRmsPPVField = new DEL("HRmsPPV", lnType, iedType);
			this.ThdPPVField = new DEL("ThdPPV", lnType, iedType);
			this.ThdOddPPVField = new DEL("ThdOddPPV", lnType, iedType);
			this.ThdEvnPPVField = new DEL("ThdEvnPPV", lnType, iedType);
			this.HCfPPVField = new DEL("HCfPPV", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.HPPVField =new HDEL("HPPV", lnType, iedType);
			this.HAField = new HWYE("HA", lnType, iedType);
			this.HPhVField = new HWYE("HPhV", lnType, iedType);
			this.HWField = new HWYE("HW", lnType, iedType);
			this.HVArField = new HWYE("HVAr", lnType, iedType);
			this.HVAField = new HWYE("HVA", lnType, iedType);
			this.NumCycField = new ING("NumCyc", lnType, iedType);
			this.ThdATmmsField = new ING("ThdATmms", lnType, iedType);
			this.ThdVTmmsField = new ING("ThdVTmms", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
			this.HzField = new MV("Hz", lnType, iedType);
			this.HRmsAField = new WYE("HRmsA", lnType, iedType);
			this.HRmsPhVField = new WYE("HRmsPhV", lnType, iedType);
			this.HTuWField = new WYE("HTuW", lnType, iedType);
			this.HTsWField = new WYE("HTsW", lnType, iedType);
			this.HATmField = new WYE("HATm", lnType, iedType);
			this.HKfField = new WYE("HKf", lnType, iedType);
			this.HTdfField = new WYE("HTdf", lnType, iedType);
			this.ThdAField = new WYE("ThdA", lnType, iedType);
			this.ThdOddAField = new WYE("ThdOddA", lnType, iedType);
			this.ThdEvnAField = new WYE("ThdEvnA", lnType, iedType);
			this.TddAField = new WYE("TddA", lnType, iedType);
			this.TddOddAField = new WYE("TddOddA", lnType, iedType);
			this.TddEvnAField = new WYE("TddEvnA", lnType, iedType);
			this.ThdPhVField = new WYE("ThdPhV", lnType, iedType);
			this.ThdOddPhVField = new WYE("ThdOddPhV", lnType, iedType);
			this.ThdEvnPhVField = new WYE("ThdEvnPhV", lnType, iedType);
			this.HCfPhVField = new WYE("HCfPhV", lnType, iedType);
			this.HCfAField = new WYE("HCfA", lnType, iedType);
			this.HTifField = new WYE("HTif", lnType, iedType);
		}
	
		public ASG HzSet
		{					
			get 
			{
				return this.HzSetField;
			}			
			set
			{				
				this.HzSetField = value;
			}
		}

		public ASG EvTmms
		{					
			get 
			{
				return this.EvTmmsField;
			}			
			set
			{				
				this.EvTmmsField = value;
			}
		}

		public ASG ThdAVal
		{					
			get 
			{
				return this.ThdAValField;
			}			
			set
			{				
				this.ThdAValField = value;
			}
		}
	
		public ASG NomA
		{					
			get 
			{
				return this.NomAField;
			}			
			set
			{				
				this.NomAField = value;
			}
		}

		public DEL HRmsPPV
		{					
			get 
			{
				return this.HRmsPPVField;
			}			
			set
			{				
				this.HRmsPPVField = value;
			}
		}

		public DEL ThdPPV
		{					
			get 
			{
				return this.ThdPPVField;
			}			
			set
			{				
				this.ThdPPVField = value;
			}
		}	
	
		public DEL ThdOddPPV
		{					
			get 
			{
				return this.ThdOddPPVField;
			}		
			set
			{				
				this.ThdOddPPVField = value;
			}
		}	

		public DEL ThdEvnPPV
		{					
			get 
			{
				return this.ThdEvnPPVField;
			}			
			set
			{				
				this.ThdEvnPPVField = value;
			}
		}
	
		public DEL HCfPPV
		{					
			get 
			{
				return this.HCfPPVField;
			}			
			set
			{				
				this.HCfPPVField = value;
			}
		}

		public DPL EEName
		{					
			get 
			{
				return this.EENameField;
			}			
			set
			{				
				this.EENameField = value;
			}
		}

		public HDEL HPPV
		{					
			get 
			{
				return this.HPPVField;
			}			
			set
			{				
				this.HPPVField = value;
			}
		}

		public HWYE HA
		{					
			get 
			{
				return this.HAField;
			}			
			set
			{				
				this.HAField = value;
			}
		}

		public HWYE HPhV
		{					
			get 
			{
				return this.HPhVField;
			}			
			set
			{				
				this.HPhVField = value;
			}
		}

		public HWYE HW
		{					
			get 
			{
				return this.HWField;
			}			
			set
			{				
				this.HWField = value;
			}
		}

		public HWYE HVAr
		{					
			get 
			{
				return this.HVArField;
			}			
			set
			{				
				this.HVArField = value;
			}
		}		
	
		public ING NumCyc
		{					
			get 
			{
				return this.NumCycField;
			}			
			set
			{				
				this.NumCycField = value;
			}
		}

		public ING ThdATmms
		{					
			get 
			{
				return this.ThdATmmsField;
			}			
			set
			{				
				this.ThdATmmsField = value;
			}
		}

		public ING ThdVTmms
		{					
			get 
			{
				return this.ThdVTmmsField;
			}			
			set
			{				
				this.ThdVTmmsField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public MV Hz
		{			
			get 
			{
				return this.HzField;
			}			
			set
			{				
				this.HzField = value;
			}
		}

		public WYE HRmsA
		{			
			get 
			{
				return this.HRmsAField;
			}			
			set
			{				
				this.HRmsAField = value;
			}
		}
		
		public WYE HRmsPhV
		{			
			get 
			{
				return this.HRmsPhVField;
			}			
			set
			{				
				this.HRmsPhVField = value;
			}
		}
	
		public WYE HTuW
		{			
			get 
			{
				return this.HTuWField;
			}			
			set
			{				
				this.HTuWField = value;
			}
		}

		public WYE HTsW
		{			
			get 
			{
				return this.HTsWField;
			}			
			set
			{				
				this.HTsWField = value;
			}
		}

		public WYE HATm
		{			
			get 
			{
				return this.HATmField;
			}			
			set
			{				
				this.HATmField = value;
			}
		}

		public WYE HKf
		{			
			get 
			{
				return this.HKfField;
			}			
			set
			{				
				this.HKfField = value;
			}
		}
	
		public WYE HTdf
		{			
			get 
			{
				return this.HTdfField;
			}			
			set
			{				
				this.HTdfField = value;
			}
		}

		public WYE ThdA
		{			
			get 
			{
				return this.ThdAField;
			}			
			set
			{				
				this.ThdAField = value;
			}
		}

		public WYE ThdOddA
		{			
			get 
			{
				return this.ThdOddAField;
			}			
			set
			{				
				this.ThdOddAField = value;
			}
		}

		public WYE ThdEvnA
		{			
			get 
			{
				return this.ThdEvnAField;
			}			
			set
			{				
				this.ThdEvnAField = value;
			}
		}

		public WYE TddA
		{			
			get 
			{
				return this.TddAField;
			}			
			set
			{				
				this.TddAField = value;
			}
		}

		public WYE TddOddA
		{			
			get 
			{
				return this.TddOddAField;
			}			
			set
			{				
				this.TddOddAField= value;
			}
		}

		public WYE TddEvnA
		{			
			get 
			{
				return this.TddEvnAField;
			}			
			set
			{				
				this.TddEvnAField = value;
			}
		}
	
		public WYE ThdPhV
		{			
			get 
			{
				return this.ThdPhVField;
			}			
			set
			{				
				this.ThdPhVField = value;
			}
		}
	
		public WYE ThdOddPhV
		{			
			get 
			{
				return this.ThdOddPhVField;
			}			
			set
			{				
				this.ThdOddPhVField = value;
			}
		}

		public WYE ThdEvnPhV
		{			
			get 
			{
				return this.ThdEvnPhVField;
			}			
			set
			{				
				this.ThdEvnPhVField = value;
			}
		}

		public WYE HCfPhV
		{			
			get 
			{
				return this.HCfPhVField;
			}			
			set
			{				
				this.HCfPhVField = value;
			}
		}

		public WYE HCfA
		{			
			get 
			{
				return this.HCfAField;
			}			
			set
			{				
				this.HCfAField = value;
			}
		}
	
		public WYE HTif
		{			
			get 
			{
				return this.HTifField;
			}			
			set
			{				
				this.HTifField = value;
			}
		}
	}	
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "MHAN" (Non phase related harmonics or interharmonics).
	/// </summary>		
	public class MHAN : CommonLogicalNode
	{
		private ASG HzSetField;
		private ASG EvTmmsField;
		private ASG ThdAValField;
		private ASG ThdVValField;
		private ASG NomAField;
		private DPL EENameField;
		private HMV HaAmpField;
		private HMV HaVolField;
		private HMV HaWattField;
		private HMV HaVolAmprField;
		private HMV HaVolAmpField;
		private ING NumCycField;
		private ING ThdATmmsField;
		private ING ThdVTmmsField;
		private INS EEHealthField;
		private MV HzField;
		private MV HaRmsAmpField;
		private MV HaRmsVolField;
		private MV HaTuWattField;
		private MV HaTsWattField;
		private MV HaAmpTmField;
		private MV HaKFactField;
		private MV HaTdFactField;
		private MV ThdAmpField;
		private MV ThdOddAmpField;
		private MV ThdEvnAmpField;
		private MV TddAmpField;
		private MV TddOddAmpField;
		private MV TddEvnAmpField;
		private MV ThdVolField;
		private MV ThdOddVolField;
		private MV ThdEvnVolField;
		private MV HaCfAmpField;
		private MV HaCfVolField;
		private MV HaTiFactField;
	
		public MHAN(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.MHAN;
			this.iedType = iedType;			
			this.HzSetField = new ASG("HzSet", lnType, iedType);
			this.EvTmmsField = new ASG("EvTmms", lnType, iedType);
			this.ThdAValField = new ASG("ThdAVal", lnType, iedType);
			this.ThdVValField = new ASG("ThdVVal", lnType, iedType);
			this.NomAField = new ASG("NomA", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.HaAmpField = new HMV("HaAmp", lnType, iedType);
			this.HaVolField = new HMV("HaVol", lnType, iedType);
			this.HaWattField = new HMV("HaWatt", lnType, iedType);
			this.HaVolAmprField = new HMV("HaVolAmpr", lnType, iedType);
			this.HaVolAmpField = new HMV("HaVolAmp", lnType, iedType);
			this.NumCycField = new ING("NumCyc", lnType, iedType);
			this.ThdATmmsField = new ING("ThdATmms", lnType, iedType);
			this.ThdVTmmsField = new ING("ThdVTmms", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
			this.HzField = new MV("Hz", lnType, iedType);
			this.HaRmsAmpField = new MV("HaRmsAmp", lnType, iedType);
			this.HaRmsVolField =new MV("HaRmsVol", lnType, iedType);
			this.HaTuWattField = new MV("HaTuWatt", lnType, iedType);
			this.HaTsWattField = new MV("HaTsWatt", lnType, iedType);
			this.HaAmpTmField = new MV("HaAmpTm", lnType, iedType);
			this.HaKFactField = new MV("HaKFact", lnType, iedType);
			this.HaTdFactField = new MV("HaTdFact", lnType, iedType);    
			this.ThdAmpField = new MV("ThdAmp", lnType, iedType);
			this.ThdOddAmpField = new MV("ThdOddAmp", lnType, iedType);
			this.ThdEvnAmpField = new MV("ThdEvnAmp", lnType, iedType);
			this.TddAmpField = new MV("TddAmp", lnType, iedType);
			this.TddOddAmpField = new MV("TddOddAmp", lnType, iedType);
			this.TddEvnAmpField = new MV("TddEvnAmp", lnType, iedType);
			this.ThdVolField = new MV("ThdVol", lnType, iedType);
			this.ThdOddVolField = new MV("ThdOddVol", lnType, iedType);
			this.ThdEvnVolField = new MV("ThdEvnVol", lnType, iedType);
			this.HaCfAmpField = new MV("HaCfAmp", lnType, iedType);		
			this.HaCfVolField = new MV("HaCfVol", lnType, iedType);
			this.HaTiFactField = new MV("HaTiFact", lnType, iedType);
		}
	
		public ASG HzSet
		{					
			get 
			{
				return this.HzSetField;
			}			
			set
			{				
				this.HzSetField = value;
			}
		}

		public ASG EvTmms
		{					
			get 
			{
				return this.EvTmmsField;
			}			
			set
			{				
				this.EvTmmsField = value;
			}
		}

		public ASG ThdAVal
		{					
			get 
			{
				return this.ThdAValField;
			}			
			set
			{				
				this.ThdAValField = value;
			}
		}
	
		public ASG NomA
		{					
			get 
			{
				return this.NomAField;
			}			
			set
			{				
				this.NomAField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{				
				this.EENameField = value;
			}
		}

		public HMV HaAmp
		{			
			get 
			{
				return this.HaAmpField;
			}			
			set
			{				
				this.HaAmpField = value;
			}
		}

		public HMV HaVol
		{			
			get 
			{
				return this.HaVolField;
			}			
			set
			{				
				this.HaVolField = value;
			}
		}

		public HMV HaWatt
		{			
			get 
			{
				return this.HaWattField;
			}			
			set
			{				
				this.HaWattField = value;
			}
		}

		public HMV HaVolAmpr
		{			
			get 
			{
				return this.HaVolAmprField;
			}			
			set
			{				
				this.HaVolAmprField = value;
			}
		}

		public HMV HaVolAmp
		{			
			get 
			{
				return this.HaVolAmpField;
			}			
			set
			{				
				this.HaVolAmpField = value;
			}
		}

		public ING NumCyc
		{					
			get 
			{
				return this.NumCycField;
			}			
			set
			{				
				this.NumCycField = value;
			}
		}

		public ING ThdATmms
		{					
			get 
			{
				return this.ThdATmmsField;
			}			
			set
			{				
				this.ThdATmmsField = value;
			}
		}

		public ING ThdVTmms
		{					
			get 
			{
				return this.ThdVTmmsField;
			}			
			set
			{				
				this.ThdVTmmsField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public MV Hz
		{			
			get 
			{
				return this.HzField;
			}			
			set
			{				
				this.HzField = value;
			}
		}

		public MV HaRmsAmp
		{			
			get 
			{
				return this.HaRmsAmpField;
			}			
			set
			{				
				this.HaRmsAmpField = value;
			}
		}
	
		public MV HaRmsVol
		{			
			get 
			{
				return this.HaRmsVolField;
			}			
			set
			{				
				this.HaRmsVolField = value;
			}
		}

		public MV HaTuWatt
		{			
			get 
			{
				return this.HaTuWattField;
			}			
			set
			{				
				this.HaTuWattField = value;
			}
		}

		public MV HaTsWatt
		{			
			get 
			{
				return this.HaTsWattField;
			}			
			set
			{				
				this.HaTsWattField = value;
			}
		}
	
		public MV HaAmpTm
		{			
			get 
			{
				return this.HaAmpTmField;
			}			
			set
			{				
				this.HaAmpTmField = value;
			}
		}

		public MV HaKFact
		{			
			get 
			{
				return this.HaKFactField;
			}			
			set
			{				
				this.HaKFactField = value;
			}
		}

		public MV HaTdFact
		{			
			get 
			{
				return this.HaTdFactField;
			}			
			set
			{				
				this.HaTdFactField = value;
			}
		}

		public MV ThdAmp
		{			
			get 
			{
				return this.ThdAmpField;
			}			
			set
			{				
				this.ThdAmpField = value;
			}
		}
	
		public MV ThdOddAmp
		{			
			get 
			{
				return this.ThdOddAmpField;
			}			
			set
			{				
				this.ThdOddAmpField = value;
			}
		}
	
		public MV ThdEvnAmp
		{			
			get 
			{
				return this.ThdEvnAmpField;
			}			
			set
			{				
				this.ThdEvnAmpField = value;
			}
		}

		public MV TddAmp
		{			
			get 
			{
				return this.TddAmpField;
			}			
			set
			{				
				this.TddAmpField = value;
			}
		}

		public MV TddOddAmp
		{			
			get 
			{
				return this.TddOddAmpField;
			}			
			set
			{				
				this.TddOddAmpField = value;
			}
		}
	
		public MV TddEvnAmp
		{			
			get 
			{
				return this.TddEvnAmpField;
			}			
			set
			{				
				this.TddEvnAmpField = value;
			}
		}

		public MV ThdVol
		{			
			get 
			{
				return this.ThdVolField;
			}			
			set
			{				
				this.ThdVolField = value;
			}
		}

		public MV ThdOddVol
		{			
			get 
			{
				return this.ThdOddVolField;
			}			
			set
			{				
				this.ThdOddVolField = value;
			}
		}

		public MV ThdEvnVol
		{			
			get 
			{
				return this.ThdEvnVolField;
			}			
			set
			{				
				this.ThdEvnVolField = value;
			}
		}

		public MV HaCfAmp
		{			
			get 
			{
				return this.HaCfAmpField;
			}			
			set
			{				
				this.HaCfAmpField  = value;
			}
		}

		public MV HaCfVol
		{			
			get 
			{
				return this.HaCfVolField;
			}			
			set
			{				
				this.HaCfVolField = value;
			}
		}

		public MV HaTiFact
		{			
			get 
			{
				return this.HaTiFactField;
			}			
			set
			{				
				this.HaTiFactField = value;
			}
		}
	}		

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "MMTR" (Non phase related Measurement).
	/// </summary>		
	public class MMTR : CommonLogicalNode
	{
		private BCR TotVAhField;
		private BCR TotWhFiedl;
		private BCR TotVArhField;
		private BCR SupWhField;
		private BCR SupVArhField;
		private BCR DmdWhField;
		private BCR DmdVArhField;
		private DPL EENameField;
		private INS EEHealthField;
	
		public MMTR(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.MMTR;
			this.iedType = iedType;			
			this.TotVAhField = new BCR("TotVAh", lnType, iedType);
			this.TotWhFiedl = new BCR("TotWh", lnType, iedType);
			this.TotVArhField = new BCR("TotVArh", lnType, iedType);
			this.SupWhField = new BCR("SupWh", lnType, iedType);
			this.SupVArhField = new BCR("SupVArh", lnType, iedType);
			this.DmdWhField = new BCR("DmdWh", lnType, iedType);
			this.DmdVArhField = new BCR("DmdVArh", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
		}

		public BCR TotVAh
		{			
			get 
			{
				return this.TotVAhField;
			}			
			set
			{				
				this.TotVAhField = value;
			}
		}

		public BCR TotWh
		{			
			get 
			{
				return this.TotWhFiedl;
			}			
			set
			{				
				this.TotWhFiedl = value;
			}
		}

		public BCR TotVArh
		{			
			get 
			{
				return this.TotVArhField;
			}			
			set
			{				
				this.TotVArhField = value;
			}
		}

		public BCR SupWh
		{			
			get 
			{
				return this.SupWhField;
			}			
			set
			{				
				this.SupWhField = value;
			}
		}

		public BCR SupVArh
		{			
			get 
			{
				return this.SupVArhField;
			}			
			set
			{				
				this.SupVArhField = value;
			}
		}

		public BCR DmdWh
		{			
			get 
			{
				return this.DmdWhField;
			}			
			set
			{				
				this.DmdWhField = value;
			}
		}

		public BCR DmdVArh
		{			
			get 
			{
				return this.DmdVArhField;
			}			
			set
			{				
				this.DmdVArhField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{				
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "MMXN" (Metering).
	/// </summary>		
	public class MMXN : CommonLogicalNode
	{
		private CMV ImpField;
		private DPL EENameField;
		private INS EEHealthField;
		private MV AmpField;
		private MV VolField;
		private MV WattField;
		private MV VolAmprField;
		private MV VolAmpField;
		private MV PwrFactField;
		private MV HzField;

		public MMXN(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.MMXN;
			this.iedType = iedType;			
			this.ImpField = new CMV("Imp", lnType, iedType);
            this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.AmpField = new MV("Amp", lnType, iedType);
			this.VolField = new MV("Vol", lnType, iedType);
			this.WattField = new MV("Watt", lnType, iedType);
			this.VolAmprField = new MV("VolAmpr", lnType, iedType);
			this.VolAmpField = new MV("VolAmp", lnType, iedType);
			this.PwrFactField = new MV("PwrFact", lnType, iedType);
			this.HzField = new MV("Hz", lnType, iedType);
		}

		public CMV Imp
		{			
			get 
			{
				return this.ImpField;
			}			
			set
			{				
				this.ImpField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{				
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public MV Amp
		{			
			get 
			{
				return this.AmpField;
			}			
			set
			{				
				this.AmpField = value;
			}
		}

		public MV Vol
		{			
			get 
			{
				return this.VolField;
			}			
			set
			{				
				this.VolField = value;
			}
		}

		public MV Watt
		{			
			get 
			{
				return this.WattField;
			}			
			set
			{				
				this.WattField = value;
			}
		}

		public MV VolAmpr
		{			
			get 
			{
				return this.VolAmprField;
			}			
			set
			{				
				this.VolAmprField = value;
			}
		}
	
		public MV VolAmp
		{			
			get 
			{
				return this.VolAmpField;
			}			
			set
			{				
				this.VolAmpField = value;
			}
		}

		public MV PwrFact
		{			
			get 
			{
				return this.PwrFactField;
			}			
			set
			{				
				this.PwrFactField = value;
			}
		}

		public MV Hz
		{			
			get 
			{
				return this.HzField;
			}			
			set
			{				
				this.HzField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "MMXU" (Measurement).
	/// </summary>		
	public class MMXU : CommonLogicalNode
	{
		private DEL PPVField;
		private INS EEHealthField;
		private MV TotWField;
		private MV TotVArField;
		private MV TotVAField;
		private MV TotPFField;
		private MV HzField;
		private WYE PhVField;
		private WYE AField;
		private WYE WField;
		private WYE VArField;
		private WYE VAField;
		private WYE PFField;
		private WYE ZField;
		
		public MMXU(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.MMXU;
			this.iedType = iedType;		
			this.PPVField = new DEL("PPV", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.TotWField = new MV("TotW", lnType, iedType);
			this.TotVArField = new MV("TotVAr", lnType, iedType);
			this.TotVAField = new MV("TotVA", lnType, iedType);
			this.TotPFField = new MV("TotPF", lnType, iedType);
			this.HzField = new MV("Hz", lnType, iedType);
			this.PhVField = new WYE("PhV", lnType, iedType);
			this.AField = new WYE("A", lnType, iedType);
			this.WField = new WYE("W", lnType, iedType);
			this.VArField = new WYE("VAr", lnType, iedType);
			this.VAField = new WYE("VA", lnType, iedType);
			this.PFField = new WYE("PF", lnType, iedType);
			this.ZField = new WYE("Z", lnType, iedType);
		}

		public DEL PPV
		{			
			get 
			{
				return this.PPVField;
			}			
			set
			{				
				this.PPVField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public MV TotW
		{			
			get 
			{
				return this.TotWField;
			}			
			set
			{				
				this.TotWField = value;
			}
		}
	
		public MV TotVAr
		{			
			get 
			{
				return this.TotVArField;
			}			
			set
			{				
				this.TotVArField = value;
			}
		}
	
		public MV TotVA
		{			
			get 
			{
				return this.TotVAField;
			}			
			set
			{				
				this.TotVAField = value;
			}
		}

		public MV TotPF
		{			
			get 
			{
				return this.TotPFField;
			}			
			set
			{				
				this.TotPFField = value;
			}
		}
	
		public MV Hz
		{			
			get 
			{
				return this.HzField;
			}			
			set
			{				
				this.HzField = value;
			}
		}
	
		public WYE PhV
		{			
			get 
			{
				return this.PhVField;
			}			
			set
			{				
				this.PhVField = value;
			}
		}

		public WYE A
		{			
			get 
			{
				return this.AField;
			}			
			set
			{				
				this.AField = value;
			}
		}

		public WYE W
		{			
			get 
			{
				return this.WField;
			}			
			set
			{				
				this.WField = value;
			}
		}
	
		public WYE VAr
		{			
			get 
			{
				return this.VArField;
			}			
			set
			{				
				this.VArField = value;
			}
		}
	
		public WYE VA
		{			
			get 
			{
				return this.VAField;
			}			
			set
			{				
				this.VAField = value;
			}
		}

		public WYE PF
		{			
			get 
			{
				return this.PFField;
			}			
			set
			{				
				this.PFField = value;
			}
		}

		public WYE Z
		{			
			get 
			{
				return this.ZField;
			}			
			set
			{				
				this.ZField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "MSQI" (Sequence and imbalance).
	/// </summary>		
	public class MSQI : CommonLogicalNode
	{
		private DEL ImbPPVField;
		private DPL EENameField;
		private INS EEHealthField;
		private MV ImbNgAField;
		private MV ImbNgVField;
		private MV ImbZroAField;
		private MV ImbZroVField;
		private MV MaxImbAField;
		private MV MaxImbPPVField;
		private MV MaxImbVField;
		private SEQ SeqAField;
		private SEQ SeqVField;
		private SEQ DQ0SeqField;
		private WYE ImbAField;
		private WYE ImbVField;
		
		public MSQI(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.MSQI;
			this.iedType = iedType;			
			this.ImbPPVField = new DEL("ImbPPV", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.ImbNgAField = new MV("ImbNgA",lnType, iedType);
			this.ImbNgVField = new MV("ImbNgV",lnType, iedType);
			this.ImbZroAField = new MV("ImbZroA",lnType, iedType);
			this.ImbZroVField = new MV("ImbZroV",lnType, iedType);
			this.MaxImbAField = new MV("MaxImbA",lnType, iedType);
			this.MaxImbPPVField = new MV("MaxImbPPV",lnType, iedType);
			this.MaxImbVField = new MV("MaxImbV",lnType, iedType);
			this.SeqAField = new SEQ("SeqA",lnType, iedType);
			this.SeqVField = new SEQ("SeqV",lnType, iedType);
			this.DQ0SeqField = new SEQ("DQ0Seq",lnType, iedType);
			this.ImbAField = new WYE("ImbA",lnType, iedType);
			this.ImbVField = new WYE("ImbV",lnType, iedType);
 		}

		public DEL ImbPPV
		{			
			get 
			{
				return this.ImbPPVField;
			}			
			set
			{				
				this.ImbPPVField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{				
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}
	
		public MV ImbNgA
		{			
			get 
			{
				return this.ImbNgAField;
			}			
			set
			{				
				this.ImbNgAField = value;
			}
		}

		public MV ImbNgV
		{			
			get 
			{
				return this.ImbNgVField;
			}			
			set
			{				
				this.ImbNgVField = value;
			}
		}

		public MV ImbZroA
		{			
			get 
			{
				return this.ImbZroAField;
			}			
			set
			{				
				this.ImbZroAField = value;
			}
		}

		public MV ImbZroV
		{			
			get 
			{
				return this.ImbZroVField;
			}			
			set
			{				
				this.ImbZroVField = value;
			}
		}
	
		public MV MaxImbA
		{			
			get 
			{
				return this.MaxImbAField;
			}			
			set
			{				
				this.MaxImbAField = value;
			}
		}
	
		public MV MaxImbPPV
		{			
			get 
			{
				return this.MaxImbPPVField;
			}			
			set
			{				
				this.MaxImbPPVField = value;
			}
		}

		public MV MaxImbV
		{			
			get 
			{
				return this.MaxImbVField;
			}			
			set
			{				
				this.MaxImbVField = value;
			}
		}
	
		public SEQ SeqA
		{			
			get 
			{
				return this.SeqAField;
			}			
			set
			{				
				this.SeqAField = value;
			}
		}

		public SEQ SeqV
		{			
			get 
			{
				return this.SeqVField;
			}			
			set
			{				
				this.SeqVField = value;
			}
		}

		public SEQ DQ0Seq
		{			
			get 
			{
				return this.DQ0SeqField;
			}			
			set
			{				
				this.DQ0SeqField = value;
			}
		}

		public WYE ImbA
		{			
			get 
			{
				return this.ImbAField;
			}			
			set
			{				
				this.ImbAField = value;
			}
		}

		public WYE ImbV
		{			
			get 
			{
				return this.ImbVField;
			}			
			set
			{				
				this.ImbVField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "MSTA" (Metering Statistics).
	/// </summary>			
	public class MSTA : CommonLogicalNode
	{
		private ASG EvTmmsField;
		private DPL EENameField;
		private INS EEHealthField;
		private MV AvAmpsField;
		private MV MaxAmpsField;
		private MV MinAmpsField;
		private MV AvVoltsField;
		private MV MaxVoltsField;
		private MV MinVoltsField;
		private MV AvVAField;
		private MV MaxVAField;
		private MV MinVAField;
		private MV AvWField;
		private MV MaxWField;
		private MV MinWField;
		private MV AvVArField;
		private MV MaxVArField;
		private MV MinVArField;
		private SPC EvStrField;
	
		public MSTA(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.MSTA;
			this.iedType = iedType;			
			this.EvTmmsField = new ASG("EvTmms", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.AvAmpsField = new MV("AvAmps", lnType, iedType);
			this.MaxAmpsField = new MV("MaxAmps", lnType, iedType);
			this.MinAmpsField = new MV("MinAmps", lnType, iedType);
			this.AvVoltsField = new MV("AvVolts", lnType, iedType);
			this.MaxVoltsField = new MV("MaxVolts", lnType, iedType);
			this.MinVoltsField = new MV("MinVolts", lnType, iedType);
			this.AvVAField = new MV("AvVA", lnType, iedType);			                                                                                                                                                                   
			this.MaxVAField = new MV("MaxVA", lnType, iedType);
			this.MinVAField = new MV("MinVA", lnType, iedType);
			this.AvWField = new MV("AvW", lnType, iedType);
			this.MaxWField = new MV("MaxW", lnType, iedType);
			this.MinWField = new MV("MinW", lnType, iedType);
			this.AvVArField = new MV("AvVAr", lnType, iedType);
			this.MaxVArField = new MV("MaxVAr", lnType, iedType);                                                                                                                                                                                                                                                                                                                                       
			this.MinVArField = new MV("MinVAr", lnType, iedType);                                                                                                                                                                                                                                                                                                                                             
			this.EvStrField = new SPC("EvStr", lnType, iedType);                                                                                                                                                                                                                                                                                                 
		}

		public ASG EvTmms
		{					
			get 
			{
				return this.EvTmmsField;
			}			
			set
			{				
				this.EvTmmsField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{				
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}
	
		public MV AvAmps
		{			
			get 
			{
				return this.AvAmpsField;
			}			
			set
			{				
				this.AvAmpsField = value;
			}
		}

		public MV MaxAmps
		{			
			get 
			{
				return this.MaxAmpsField;
			}			
			set
			{				
				this.MaxAmpsField = value;
			}
		}
	
		public MV MinAmps
		{			
			get 
			{
				return this.MinAmpsField;
			}			
			set
			{				
				this.MinAmpsField = value;
			}
		}
	
		public MV AvVolts
		{			
			get 
			{
				return this.AvVoltsField;
			}			
			set
			{				
				this.AvVoltsField = value;
			}
		}
	
		public MV MaxVolts
		{			
			get 
			{
				return this.MaxVoltsField;
			}			
			set
			{				
				this.MaxVoltsField = value;
			}
		}
	
		public MV MinVolts
		{			
			get 
			{
				return this.MinVoltsField;
			}			
			set
			{				
				this.MinVoltsField = value;
			}
		}
	
		public MV AvVA
		{			
			get 
			{
				return this.AvVAField;
			}			
			set
			{				
				this.AvVAField = value;
			}
		}

		public MV MaxVA
		{			
			get 
			{
				return this.MaxVAField;
			}			
			set
			{				
				this.MaxVAField = value;
			}
		}

		public MV MinVA
		{			
			get 
			{
				return this.MinVAField;
			}			
			set
			{				
				this.MinVAField = value;
			}
		}

		public MV AvW
		{			
			get 
			{
				return this.AvWField;
			}			
			set
			{				
				this.AvWField = value;
			}
		}

		public MV MaxW
		{			
			get 
			{
				return this.MaxWField;
			}			
			set
			{				
				this.MaxWField = value;
			}
		}
	
		public MV MinW
		{			
			get 
			{
				return this.MinWField;
			}			
			set
			{				
				this.MinWField = value;
			}
		}
	
		public MV AvVAr
		{			
			get 
			{
				return this.AvVArField;
			}			
			set
			{				
				this.AvVArField = value;
			}
		}

		public MV MaxVAr
		{			
			get 
			{
				return this.MaxVArField;
			}			
			set
			{				
				this.MaxVArField = value;
			}
		}
	
		public MV MinVAr
		{			
			get 
			{
				return this.MinVArField;
			}			
			set
			{				
				this.MinVArField = value;
			}
		}

		public SPC EvStr
		{			
			get 
			{
				return this.EvStrField;
			}			
			set
			{				
				this.EvStrField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PDIF" (Differential).
	/// </summary>		
	public class PDIF : CommonLogicalNode
	{
		private ACD StrField;
		private ACT OpField;
		private ASG LinCapacField;
		private CSD TmAStField;
		private CURVE TmACrvField;
		private INC OpCntRsField;
		private ING LoSetField;
		private ING HiSetField;
		private ING MinOpTmmsField;
		private ING MaxOpTmmsField;
		private ING RstModField;
		private ING RsDlTmmsField;
		private WYE DifAClcField;
		private WYE RstAField;
	
		public PDIF(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.PDIF;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField = new ACT("Op", lnType, iedType);
			this.LinCapacField = new ASG("LinCapac", lnType, iedType);
			this.TmAStField = new CSD("TmASt", lnType, iedType);
			this.TmACrvField = new CURVE("TmACrv", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.LoSetField = new ING("LoSet", lnType, iedType);
			this.HiSetField = new ING("HiSet", lnType, iedType);
			this.MinOpTmmsField = new ING("MinOpTmms", lnType, iedType);
			this.MaxOpTmmsField = new ING("MaxOpTmms", lnType, iedType);                                                                    
			this.RstModField = new ING("RstMod", lnType, iedType);
			this.RsDlTmmsField = new ING("RsDlTmms", lnType, iedType);
			this.DifAClcField = new WYE("DifAClc", lnType, iedType);
			this.RstAField = new WYE("RstA", lnType, iedType);
		}

		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}
	
		public ASG LinCapac
		{			
			get 
			{
				return this.LinCapacField;
			}			
			set
			{				
				this.LinCapacField = value;
			}
		}
	
		public CSD TmASt
		{			
			get 
			{
				return this.TmAStField;
			}			
			set
			{				
				this.TmAStField = value;
			}
		}

		private CURVE TmACrv
		{			
			get 
			{
				return this.TmACrvField;
			}			
			set
			{				
				this.TmACrvField = value;
			}
		}

		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING LoSet
		{			
			get 
			{
				return this.LoSetField;
			}			
			set
			{				
				this.LoSetField = value;
			}
		}

		public ING HiSet
		{			
			get 
			{
				return this.HiSetField;
			}			
			set
			{				
				this.HiSetField = value;
			}
		}

		public ING MinOpTmms
		{			
			get 
			{
				return this.MinOpTmmsField;
			}			
			set
			{				
				this.MinOpTmmsField = value;
			}
		}

		public ING MaxOpTmms
		{			
			get 
			{
				return this.MaxOpTmmsField;
			}			
			set
			{				
				this.MaxOpTmmsField = value;
			}
		}

		public ING RstMod
		{			
			get 
			{
				return this.RstModField;
			}			
			set
			{				
				this.RstModField = value;
			}
		}

		public ING RsDlTmms
		{			
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}

		public WYE DifAClc
		{			
			get 
			{
				return this.DifAClcField;
			}			
			set
			{				
				this.DifAClcField = value;
			}
		}
	
		public WYE RstA
		{			
			get 
			{
				return this.RstAField;
			}			
			set
			{				
				this.RstAField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PDIR" (Direction comparison).
	/// </summary>		
	public class PDIR : CommonLogicalNode
	{
		private ACD StrField;
		private ACT OpField;
		private INC OpCntRsField;
		private ING RsDlTmmsField;
	
		public PDIR(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.PDIR;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField = new ACT("Op", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.RsDlTmmsField = new ING("RsDlTmms", lnType, iedType);
		}

		[Required]
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}
	
		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING RsDlTmms
		{			
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PDIS" (Distance).
	/// </summary>		
	public class PDIS : CommonLogicalNode
	{
		private ACD StrField;
		private ACT OpField;
		private ASG PoRchField;
		private ASG PhStrField;
		private ASG GndStrField;
		private ASG PctRchField;
		private ASG OfsField;
		private ASG PctOfsField;
		private ASG RisLodField;
		private ASG AngLodField;
		private ASG X1Field;
		private ASG LinAngField;
		private ASG RisGndRchField;
		private ASG RisPhRchField;
		private ASG K0FactField;
		private ASG K0FactAngField;
		private INC OpCntRsField;
		private ING DirModField;
		private ING OpDlTmmsField;
		private ING PhDlTmmsField;
		private ING GndDlTmmsField;
		private ING RsDlTmmsField;
		private SPG TmDlModField;
		private SPG PhDlModField;
		private SPG GndDlModField;
		
		public PDIS(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.PDIS;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField = new ACT("Op", lnType, iedType);
			this.PoRchField = new ASG("PoRch", lnType, iedType);
			this.PhStrField = new ASG("PhStr", lnType, iedType);
			this.GndStrField = new ASG("GndStr", lnType, iedType);
			this.PctRchField = new ASG("PctRch", lnType, iedType);
			this.OfsField = new ASG("Ofs", lnType, iedType);
			this.PctOfsField = new ASG("PctOfs", lnType, iedType);
			this.RisLodField = new ASG("RisLod", lnType, iedType);
			this.AngLodField = new ASG("AngLod", lnType, iedType);
			this.X1Field = new ASG("X1", lnType, iedType);
			this.LinAngField = new ASG("LinAng", lnType, iedType);                                                                                                                                                                                                                              
			this.RisGndRchField = new ASG("RisGndRch", lnType, iedType);                                                                                                                                                                                                                                          
			this.RisPhRchField = new ASG("RisPhRch", lnType, iedType);                                                                                                                                                                                                                                        
			this.K0FactField = new ASG("K0Fact", lnType, iedType);                                                                                                                                                                                                                                    
			this.K0FactAngField = new ASG("K0FactAng", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.DirModField = new ING("DirMod", lnType, iedType);
			this.OpDlTmmsField = new ING("OpDlTmms", lnType, iedType);
			this.PhDlTmmsField = new ING("PhDlTmms", lnType, iedType);
			this.GndDlTmmsField = new ING("GndDlTmms", lnType, iedType);
			this.RsDlTmmsField = new ING("RsDlTmms", lnType, iedType);
			this.TmDlModField = new SPG("TmDlMod", lnType, iedType);
			this.PhDlModField = new SPG("PhDlMod", lnType, iedType);
			this.GndDlModField = new SPG("GndDlMod", lnType, iedType);
		}

		[Required]
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}	
	
		public ASG PoRch
		{			
			get 
			{
				return this.PoRchField;
			}			
			set
			{				
				this.PoRchField = value;
			}
		}

		public ASG PhStr
		{			
			get 
			{
				return this.PhStrField;
			}			
			set
			{				
				this.PhStrField = value;
			}
		}

		public ASG GndStr
		{			
			get 
			{
				return this.GndStrField;
			}			
			set
			{				
				this.GndStrField = value;
			}
		}

		public ASG PctRch
		{			
			get 
			{
				return this.PctRchField;
			}			
			set
			{				
				this.PctRchField = value;
			}
		}

		public ASG Ofs
		{			
			get 
			{
				return this.OfsField;
			}			
			set
			{				
				this.OfsField = value;
			}
		}

		public ASG PctOfs
		{			
			get 
			{
				return this.PctOfsField;
			}			
			set
			{				
				this.PctOfsField = value;
			}
		}

		public ASG RisLod
		{			
			get 
			{
				return this.RisLodField;
			}			
			set
			{				
				this.RisLodField = value;
			}
		}

		public ASG AngLod
		{			
			get 
			{
				return this.AngLodField;
			}			
			set
			{				
				this.AngLodField = value;
			}
		}
		
		public ASG X1
		{			
			get 
			{
				return this.X1Field;
			}			
			set
			{				
				this.X1Field = value;
			}
		}

		public ASG LinAng
		{			
			get 
			{
				return this.LinAngField;
			}			
			set
			{				
				this.LinAngField = value;
			}
		}

		public ASG RisGndRch
		{			
			get 
			{
				return this.RisGndRchField;
			}			
			set
			{				
				this.RisGndRchField = value;
			}
		}

		public ASG RisPhRch
		{			
			get 
			{
				return this.RisPhRchField;
			}			
			set
			{				
				this.RisPhRchField = value;
			}
		}

		public ASG K0Fact
		{			
			get 
			{
				return this.K0FactField;
			}			
			set
			{				
				this.K0FactField = value;
			}
		}
	
		public ASG K0FactAng
		{			
			get 
			{
				return this.K0FactAngField;
			}			
			set
			{				
				this.K0FactAngField = value;
			}
		}

		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING DirMod
		{			
			get 
			{
				return this.DirModField;
			}			
			set
			{				
				this.DirModField = value;
			}
		}

		public ING OpDlTmms
		{			
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}

		public ING PhDlTmms
		{			
			get 
			{
				return this.PhDlTmmsField;
			}			
			set
			{				
				this.PhDlTmmsField = value;
			}
		}

		public ING GndDlTmms
		{			
			get 
			{
				return this.GndDlTmmsField;
			}			
			set
			{				
				this.GndDlTmmsField = value;
			}
		}

		public ING RsDlTmms
		{			
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}

		public SPG TmDlMod
		{			
			get 
			{
				return this.TmDlModField;
			}			
			set
			{				
				this.TmDlModField = value;
			}
		}

		public SPG PhDlMod
		{			
			get 
			{
				return this.PhDlModField;
			}			
			set
			{				
				this.PhDlModField = value;
			}
		}

		public SPG GndDlMod
		{			
			get 
			{
				return this.GndDlModField;
			}			
			set
			{				
				this.GndDlModField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PDOP" (Directional overpower).
	/// </summary>		
	public class PDOP : CommonLogicalNode
	{
		private ACD StrField;
		private ACT OpField;
		private ASG StrValField;
		private INC OpCntRsField;
		private ING DirModField;
		private ING OpDlTmmsField;
		private ING RsDlTmmsField;
		
		public PDOP(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.PDOP;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField =new ACT("Op", lnType, iedType);
			this.StrValField = new ASG("StrVal", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.DirModField = new ING("DirMod", lnType, iedType);
			this.OpDlTmmsField = new ING("OpDlTmms", lnType, iedType);
			this.RsDlTmmsField = new ING("RsDlTmms", lnType, iedType);
		}

		[Required]
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public ASG StrVal
		{			
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		}

		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING DirMod
		{			
			get 
			{
				return this.DirModField;
			}			
			set
			{				
				this.DirModField = value;
			}
		}
		
		public ING OpDlTmms
		{			
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}

		public ING RsDlTmms
		{			
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PDUP" (Directional underpower).
	/// </summary>	
	public class PDUP : CommonLogicalNode
	{
		private ACD StrField;
		private ACT OpField;
		private ASG StrValField;
		private INC OpCntRsField;
		private ING OpDlTmmsField;
		private ING RsDlTmmsField;
		private ING DirModField;
	
		public PDUP(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.PDUP;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField =new ACT("Op", lnType, iedType);
			this.StrValField = new ASG("StrVal", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.OpDlTmmsField = new ING("OpDlTmms", lnType, iedType);
			this.RsDlTmmsField = new ING("RsDlTmms", lnType, iedType);
			this.DirModField = new ING("DirMod", lnType, iedType);
		}

		[Required]
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}
	
		public ASG StrVal
		{			
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		}
	
		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING OpDlTmms
		{			
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}
	
		public ING RsDlTmms
		{			
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}
	
		public ING DirMod
		{			
			get 
			{
				return this.DirModField;
			}			
			set
			{				
				this.DirModField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PFRC" (Rate of change of frequency).
	/// </summary>	
	public class PFRC : CommonLogicalNode
	{
		private ACD StrField;
		private ACT OpField;
		private ASG StrValField;
		private ASG BlkValField;
		private INC OpCntRsField;
		private ING OpDlTmmsField;
		private ING RsDlTmmsField;
		private SPS BlkVField;
	
		public PFRC(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.PFRC;
			this.iedType = iedType;		
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField =new ACT("Op", lnType, iedType);
			this.StrValField = new ASG("StrVal", lnType, iedType);
			this.BlkValField = new ASG("BlkVal", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);			                           
			this.OpDlTmmsField = new ING("OpDlTmms", lnType, iedType);
			this.RsDlTmmsField = new ING("RsDlTmms", lnType, iedType);
			this.BlkVField = new SPS("BlkV", lnType, iedType);
		}

		[Required]
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public ASG StrVal
		{			
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		}

		public ASG BlkVal
		{			
			get 
			{
				return this.BlkValField;
			}			
			set
			{				
				this.BlkValField = value;
			}
		}

		private INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING OpDlTmms
		{			
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}
	
		public ING RsDlTmms
		{			
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}

		public SPS BlkV
		{			
			get 
			{
				return this.BlkVField;
			}			
			set
			{				
				this.BlkVField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PHAR" (Harmonic restraint).
	/// </summary>		
	public class PHAR : CommonLogicalNode
	{
		private ACD StrField;
		private ASG PhStrField;
		private ASG PhStopField;
		private INC OpCntRsField;
		private ING HaRstField;
		private ING OpDlTmmsField;
		private ING RsDlTmmsField;
	
		public PHAR(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.PHAR;
			this.iedType = iedType;	
			this.StrField = new ACD("Str", lnType, iedType);
			this.PhStrField = new ASG("PhStr", lnType, iedType);
			this.PhStopField = new ASG("PhStop", lnType, iedType);                           
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);                           
			this.HaRstField = new ING("HaRst", lnType, iedType);                                                      
			this.OpDlTmmsField = new ING("OpDlTmms", lnType, iedType);                                                      
			this.RsDlTmmsField = new ING("RsDlTmms", lnType, iedType);			                           
		}

		[Required]
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		public ASG PhStr
		{			
			get 
			{
				return this.PhStrField;
			}			
			set
			{				
				this.PhStrField = value;
			}
		}

		public ASG PhStop
		{			
			get 
			{
				return this.PhStopField;
			}			
			set
			{				
				this.PhStopField = value;
			}
		}
	
		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING HaRst
		{			
			get 
			{
				return this.HaRstField;
			}			
			set
			{				
				this.HaRstField = value;
			}
		}

		public ING OpDlTmms
		{			
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}
	
		public ING RsDlTmms
		{			
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PHIZ" (Ground detector).
	/// </summary>	
	public class PHIZ : CommonLogicalNode
	{
		private ACD StrField;
		private ACT OpField;
		private ASG AStrField;
		private ASG VStrField;
		private ASG HVStrField;
		private INC OpCntRsField;
		private ING OpDlTmmsField;
		private ING RsDlTmmsField;
	
		public PHIZ(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.PHIZ;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField = new ACT("Op", lnType, iedType);
			this.AStrField = new ASG("AStr", lnType, iedType);
			this.VStrField = new ASG("VStr", lnType, iedType);
			this.HVStrField = new ASG("HVStr", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.OpDlTmmsField = new ING("OpDlTmms", lnType, iedType);
			this.RsDlTmmsField = new ING("RsDlTmms", lnType, iedType);
		}

		[Required]
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public ASG AStr
		{			
			get 
			{
				return this.AStrField;
			}			
			set
			{				
				this.AStrField = value;
			}
		}

		public ASG VStr
		{			
			get 
			{
				return this.VStrField;
			}			
			set
			{				
				this.VStrField = value;
			}
		}

		public ASG HVStr
		{			
			get 
			{
				return this.HVStrField;
			}			
			set
			{				
				this.HVStrField = value;
			}
		}

		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING OpDlTmms
		{			
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}
	
		public ING RsDlTmms
		{			
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}		
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PIOC" (Instantaneous overcurrent).
	/// </summary>		
	public class PIOC : CommonLogicalNode
	{
		private ACD StrField;
		private ACT OpField;
		private ASG StrValField;		
		private INC OpCntRsField;

		public PIOC(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.PIOC;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField =new ACT("Op", lnType, iedType);
		 	this.StrValField = new ASG("StrVal", lnType, iedType);			
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
		}
	
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public ASG StrVal
		{			
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		}	

		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}
	}	
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PMRI" (Motor restart inhibition).
	/// </summary>	
	public class PMRI : CommonLogicalNode
	{
		private ACT OpField;
		private ASG SetAField;
		private INC OpCntRsField;
		private ING SetTmsField;
		private ING MaxNumStrField;
		private ING MaxWrmStrField;
		private ING MaxStrTmmField;
		private ING EqTmmField;
		private ING InhTmmField;
		private INS StrInhTmmField;
		private SPS StrInhField;

		public PMRI(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.PMRI;
			this.iedType = iedType;			
			this.OpField =new ACT("Op", lnType, iedType);
			this.SetAField = new ASG("SetA", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.SetTmsField = new ING("SetTms", lnType, iedType);
			this.MaxNumStrField = new ING("MaxNumStr", lnType, iedType);
			this.MaxWrmStrField = new ING("MaxWrmStr", lnType, iedType);	
			this.MaxStrTmmField = new ING("MaxStrTmm", lnType, iedType);
			this.EqTmmField = new ING("EqTmm", lnType, iedType);
			this.InhTmmField = new ING("InhTmm", lnType, iedType);
			this.StrInhTmmField = new INS("StrInhTmm", lnType, iedType);
			this.StrInhField = new SPS("StrInh", lnType, iedType);
		}

		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public ASG SetA
		{			
			get 
			{
				return this.SetAField;
			}			
			set
			{				
				this.SetAField = value;
			}
		}

		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING SetTms
		{			
			get 
			{
				return this.SetTmsField;
			}			
			set
			{				
				this.SetTmsField = value;
			}
		}
	
		public ING MaxNumStr
		{			
			get 
			{
				return this.MaxNumStrField;
			}			
			set
			{				
				this.MaxNumStrField = value;
			}
		}
	
		public ING MaxWrmStr
		{			
			get 
			{
				return this.MaxWrmStrField;
			}			
			set
			{				
				this.MaxWrmStrField = value;
			}
		}
	
		public ING MaxStrTmm
		{			
			get 
			{
				return this.MaxStrTmmField;
			}			
			set
			{				
				this.MaxStrTmmField = value;
			}
		}
	
		public ING EqTmm
		{			
			get 
			{
				return this.EqTmmField;
			}			
			set
			{				
				this.EqTmmField = value;
			}
		}

		public ING InhTmm
		{			
			get 
			{
				return this.InhTmmField;
			}			
			set
			{				
				this.InhTmmField = value;
			}
		}

		public INS StrInhTmm
		{			
			get 
			{
				return this.StrInhTmmField;
			}			
			set
			{				
				this.StrInhTmmField = value;
			}
		}

		public SPS StrInh
		{			
			get 
			{
				return this.StrInhField;
			}			
			set
			{				
				this.StrInhField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PMSS" (Motor starting time supervision).
	/// </summary>		
	public class PMSS : CommonLogicalNode
	{
		private ACD StrField;
		private ACT OpField;
		private ASG SetAField;
		private ASG MotStrField;
		private INC OpCntRsField;
		private ING SetTmsField;
		private ING LokRotTmsField;

		public PMSS(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.PMSS;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField =new ACT("Op", lnType, iedType);
			this.SetAField = new ASG("SetA", lnType, iedType);
			this.MotStrField = new ASG("MotStr", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.SetTmsField = new ING("SetTms", lnType, iedType);
			this.LokRotTmsField = new ING("LokRotTms", lnType, iedType);
		}

		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}
	
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public ASG SetA
		{			
			get 
			{
				return this.SetAField;
			}			
			set
			{				
				this.SetAField = value;
			}
		}

		public ASG MotStr
		{			
			get 
			{
				return this.MotStrField;
			}			
			set
			{				
				this.MotStrField = value;
			}
		}
	
		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}
	
		public ING SetTms
		{			
			get 
			{
				return this.SetTmsField;
			}			
			set
			{				
				this.SetTmsField = value;
			}
		}

		public ING LokRotTms
		{			
			get 
			{
				return this.LokRotTmsField;
			}			
			set
			{				
				this.LokRotTmsField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "POPF" (Over power factor).
	/// </summary>		
	public class POPF : CommonLogicalNode
	{
		private ACD StrField;
		private ACT OpField;
		private ASG StrValField;
		private ASG BlkValAField;
		private ASG BlkValVField;
		private INC OpCntRsField;
		private ING OpDlTmmsField;
		private ING RsDlTmmsField;
		private SPS BlkAField;
		private SPS BlkVField;

		public POPF(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.POPF;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField =new ACT("Op", lnType, iedType);
		 	this.StrValField = new ASG("StrVal", lnType, iedType);
		 	this.BlkValAField = new ASG("BlkValA", lnType, iedType);                                                        
			this.BlkValVField = new ASG("BlkValV", lnType, iedType);                                                        
		 	this.OpCntRsField = new INC("OpCntRs", lnType, iedType);                                                        
		 	this.OpDlTmmsField = new ING("OpDlTmms", lnType, iedType);
		 	this.RsDlTmmsField = new ING("RsDlTmms", lnType, iedType);
		 	this.BlkAField = new SPS("BlkA", lnType, iedType);                                                        
			this.BlkVField = new SPS("BlkV", lnType, iedType);                                                        
		}

		[Required]
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public ASG StrVal
		{			
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		}

		public ASG BlkValA
		{			
			get 
			{
				return this.BlkValAField;
			}			
			set
			{				
				this.BlkValAField = value;
			}
		}

		public ASG BlkValV
		{			
			get 
			{
				return this.BlkValVField;
			}			
			set
			{				
				this.BlkValAField = value;
			}
		}

		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING OpDlTmms
		{			
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}

		public ING RsDlTmms
		{			
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}
	
		public SPS BlkA
		{			
			get 
			{
				return this.BlkAField;
			}			
			set
			{				
				this.BlkAField = value;
			}
		}

		public SPS BlkV
		{			
			get 
			{
				return this.BlkVField;
			}			
			set
			{				
				this.BlkVField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PPAM" (Phase angle measuring).
	/// </summary>		
	public class PPAM : CommonLogicalNode
	{
		private ACD StrField;
		private ACT OpField;
		private ASG StrValField;
		private INC OpCntRsField;
	
		public PPAM(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.PPAM;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField =new ACT("Op", lnType, iedType);
		 	this.StrValField = new ASG("StrVal", lnType, iedType);
		 	this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
		}

		[Required]
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}
	
		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public ASG StrVal
		{			
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		}
	
		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PSCH" (Protection scheme).
	/// </summary>		
	public class PSCH : CommonLogicalNode
	{		
		private INC OpCntRsField;
		private SPS ProRxField;
		private SPS ProTxField; 
		private ACD StrField;
		private ACT OpField; 
		private ACT CarRxField; 
		private SPS LosOfGrdField; 
		private ACT EchoField;
		private ACT WeiOpField; 
		private SPS GrdRxField; 
		private ING SchTypField; 
		private ING OpDlTmmsField; 
		private ING CrdTmmsField;
		private ING DurTmmsField; 
		private ING UnBlkModField; 
		private ING SecTmmsField; 
		private ING WeiModField; 
		private ING WeiTmmsField;
		private ASG PPVValField; 
		private ASG PhGndValField; 
		private ING RvAModField; 
		private ING RvRsTmmsField;
		private ACT RvABlkField;
		private ING RvATmmsField;	
		
		public PSCH(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.CCGR;
			this.iedType = iedType;				
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType); 
			this.ProTxField = new SPS("ProTx", lnType, iedType); 
			this.ProRxField = new SPS("ProRx", lnType, iedType); 
			this.StrField = new ACD("Str", lnType, iedType); 
			this.OpField = new ACT("Op", lnType, iedType); 
			this.CarRxField = new ACT("CarRx", lnType, iedType); 
			this.LosOfGrdField = new SPS("LosOfGrd", lnType, iedType); 
			this.EchoField = new ACT("Echo", lnType, iedType);
			this.WeiOpField = new ACT("WeiOp", lnType, iedType);
			this.GrdRxField = new SPS("GrdRx", lnType, iedType); 	
			this.SchTypField = new ING("SchTyp", lnType, iedType); 
			this.OpDlTmmsField = new ING("OpDlTmms", lnType, iedType); 
			this.CrdTmmsField = new ING("CrdTmms", lnType, iedType); 
			this.DurTmmsField = new ING("DurTmms", lnType, iedType); 	
			this.UnBlkModField = new ING("UnBlkMod", lnType, iedType); 
			this.SecTmmsField = new ING("SecTmms", lnType, iedType); 
			this.WeiModField = new ING("WeiMod", lnType, iedType);	 
			this.WeiTmmsField = new ING("WeiTmms", lnType, iedType); 	
			this.PPVValField = new ASG("PPVVal", lnType, iedType); 
			this.PhGndValField = new ASG("PhGndVal", lnType, iedType);
			this.RvAModField = new ING("RvAMod", lnType, iedType); 
			this.RvRsTmmsField = new ING("RvRsTmms", lnType, iedType);	
		}

		[Required]
		public ACD Str
		{
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}			
		} 

		public ACT CarRx
		{
			get 
			{
				return this.CarRxField;
			}			
			set
			{				
				this.CarRxField = value;
			}
			
		} 

		public ACT Echo
		{
			get 
			{
				return this.EchoField;
			}			
			set
			{				
				this.EchoField = value;
			}
			
		} 			

		[Required]
		public ACT Op
		{
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
			
		}

		public ACT RvABlk
		{
			get 
			{
				return this.RvABlkField;
			}			
			set
			{				
				this.RvABlkField = value;
			}
			
		}	

		public ACT WeiOp
		{
			get 
			{
				return this.WeiOpField;
			}			
			set
			{				
				this.WeiOpField = value;
			}			
		} 	

		public ASG PhGndVal
		{
			get 
			{
				return this.PhGndValField;
			}			
			set
			{				
				this.PhGndValField = value;
			}			
		} 	

		public ASG PPVVal
		{
			get 
			{
				return this.PPVValField;
			}			
			set
			{				
				this.PPVValField = value;
			}
			
		}

		public INC OpCntRs
		{
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}			
		}	

		public ING CrdTmms
		{
			get 
			{
				return this.CrdTmmsField;
			}			
			set
			{				
				this.CrdTmmsField = value;
			}			
		} 	

		public ING DurTmms
		{
			get 
			{
				return this.DurTmmsField;
			}			
			set
			{				
				this.DurTmmsField = value;
			}			
		} 	

		public ING OpDlTmms
		{
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}			
		} 

		public ING RvAMod
		{
			get 
			{
				return this.RvAModField;
			}			
			set
			{				
				this.RvAModField = value;
			}			
		} 	

		public ING RvATmms
		{
			get 
			{
				return this.RvATmmsField;
			}			
			set
			{				
				this.RvATmmsField = value;
			}			
		} 				

		public ING RvRsTmms
		{
			get 
			{
				return this.RvRsTmmsField;
			}			
			set
			{				
				this.RvRsTmmsField = value;
			}			
		}	
	
		public ING SchTyp
		{
			get 
			{
				return this.SchTypField;
			}			
			set
			{				
				this.SchTypField = value;
			}			
		}	

		public ING SecTmms
		{
			get 
			{
				return this.SecTmmsField;
			}			
			set
			{				
				this.SecTmmsField = value;
			}			
		} 	
	
		public ING UnBlkMod
		{
			get 
			{
				return this.UnBlkModField;
			}			
			set
			{				
				this.UnBlkModField = value;
			}			
		}  	

		public ING WeiMod
		{
			get 
			{
				return this.WeiModField;
			}			
			set
			{				
				this.WeiModField = value;
			}			
		} 	
			
		public ING WeiTmms
		{
			get 
			{
				return this.WeiTmmsField;
			}			
			set
			{				
				this.WeiTmmsField = value;
			}			
		} 	

		public SPS GrdRx
		{
			get 
			{
				return this.GrdRxField;
			}			
			set
			{				
				this.GrdRxField = value;
			}			
		} 				

		public SPS LosOfGrd
		{
			get 
			{
				return this.LosOfGrdField;
			}			
			set
			{				
				this.LosOfGrdField = value;
			}			
		}	

		[Required]
		public SPS ProRx
		{
			get 
			{
				return this.ProRxField;
			}			
			set
			{				
				this.ProRxField = value;
			}			
		}

		[Required]
		public SPS ProTx
		{
			get 
			{
				return this.ProTxField;
			}			
			set
			{				
				this.ProTxField = value;
			}			
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PSDE" (Sensitive directional earthfault).
	/// </summary>			
	public class PSDE : CommonLogicalNode	
	{	
		private ACD StrField;
		private ACT OpField;
		private ASG AngField;
		private ASG GndStrField; 
		private ASG GndOpField;
		private INC OpCntRsField; 
		private ING StrDlTmmsField; 
		private ING OpDlTmmsField; 
		private ING DirModField;		
	
		public PSDE(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.CCGR;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField =new ACT("Op", lnType, iedType); 
			this.AngField =new ASG("Ang", lnType, iedType); 
			this.GndStrField = new ASG("GndStr", lnType, iedType); 
			this.GndOpField = new ASG("GndOp", lnType, iedType); 
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType); 	
			this.StrDlTmmsField = new ING("StrDlTmms", lnType, iedType); 
			this.OpDlTmmsField = new ING("OpDlTmms", lnType, iedType); 
			this.DirModField = new ING("DirMod", lnType, iedType);			
		}

		[Required]
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}
		
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}		
			set
			{				
				this.OpField = value;
			}
		}		

		public ASG Ang
		{			
			get 
			{
				return this.AngField;
			}			
			set
			{				
				this.AngField = value;
			}
		} 
	
		public ASG GndOp
		{			
			get 
			{
				return this.GndOpField;
			}			
			set
			{				
				this.GndOpField = value;
			}
		} 		

		public ASG GndStr
		{			
			get 
			{
				return this.GndStrField;
			}			
			set
			{				
				this.GndStrField = value;
			}
		} 	

		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING DirMod
		{			
			get 
			{
				return this.DirModField;
			}			
			set
			{				
				this.DirModField = value;
			}
		}			

		public ING OpDlTmms
		{			
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		} 

		public ING StrDlTmms
		{			
			get 
			{
				return this.StrDlTmmsField;
			}			
			set
			{				
				this.StrDlTmmsField = value;
			}
		} 	
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PTEF" (Transient earth fault).
	/// </summary>		
	public class PTEF : CommonLogicalNode	
	{	
		private ACD StrField;
		private ACT OpField;
		private ASG GndStrField; 
		private ASG GndOpField;
		private INC OpCntRsField; 
		private ING DirModField; 
		
		public PTEF(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.CCGR;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField =new ACT("Op", lnType, iedType); 
			this.GndStrField = new ASG("GndStr", lnType, iedType); 
			this.GndOpField = new ASG("GndOp", lnType, iedType); 			
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.DirModField = new ING("DirMod", lnType, iedType);			
		}

		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}		

		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}		
	
		public ASG GndStr
		{			
			get 
			{
				return this.GndStrField;
			}			
			set
			{				
				this.GndStrField = value;
			}
		}		

		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		} 	

		public ING DirMod
		{			
			get 
			{
				return this.DirModField;
			}			
			set
			{				
				this.DirModField = value;
			}
		}	
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PTOC" (Time overcurrent).
	/// </summary>		
	public class PTOC : CommonLogicalNode	
	{	
		private ACD StrField;
		private ACT OpField; 
		private ASG StrValField; 
		private ASG TmMultField; 
		private CSD TmAStField; 
		private CURVE TmACrvField; 	 
		private INC OpCntRsField; 
		private ING MinOpTmmsField; 
		private ING MaxOpTmmsField; 
		private ING OpDlTmmsField; 
		private ING TypRsCrvField;	
		private ING RsDlTmmsField;	
		private ING DirModField;
		 		
		public PTOC(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.CCGR;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField =new ACT("Op", lnType, iedType); 
			this.StrValField =new ASG("StrVal", lnType, iedType); 
			this.TmMultField =new ASG("TmMult", lnType, iedType); 
			this.TmAStField =new CSD("TmASt", lnType, iedType); 
			this.TmACrvField =new CURVE("TmACrv", lnType, iedType); 
			this.OpCntRsField =new INC("OpCntRs", lnType, iedType); 
			this.MinOpTmmsField =new ING("MinOpTmms", lnType, iedType); 
			this.MaxOpTmmsField =new ING("MaxOpTmms", lnType, iedType); 
			this.OpDlTmmsField =new ING("OpDlTmms", lnType, iedType); 
			this.TypRsCrvField =new ING("TypRsCrv", lnType, iedType); 
			this.RsDlTmmsField =new ING("RsDlTmms", lnType, iedType); 
			this.DirModField =new ING("DirMod", lnType, iedType);			
		}

		[Required]
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}	

		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		} 			

		public ASG StrVal
		{			
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		}		

		public ASG TmMult
		{			
			get 
			{
				return this.TmMultField;
			}			
			set
			{				
				this.TmMultField = value;
			}
		} 			

		public CSD TmASt
		{			
			get 
			{
				return this.TmAStField;
			}			
			set
			{				
				this.TmAStField = value;
			}
		}		

		public CURVE TmACrv
		{			
			get 
			{
				return this.TmACrvField;
			}			
			set
			{				
				this.TmACrvField = value;
			}
		} 			

		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}	

		public ING DirMod
		{			
			get 
			{
				return this.DirModField;
			}			
			set
			{				
				this.DirModField = value;
			}
		}	

		public ING MaxOpTmms
		{			
			get 
			{
				return this.MaxOpTmmsField;
			}			
			set
			{				
				this.MaxOpTmmsField = value;
			}
		} 	

		public ING MinOpTmms
		{			
			get 
			{
				return this.MinOpTmmsField;
			}			
			set
			{				
				this.MinOpTmmsField = value;
			}
		} 				
					
		public ING OpDlTmms
		{			
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		} 	

		public ING RsDlTmms
		{			
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		} 		

		public ING TypRsCrv
		{			
			get 
			{
				return this.TypRsCrvField;
			}			
			set
			{				
				this.TypRsCrvField = value;
			}
		} 											
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PTOF" (Overfrequency).
	/// </summary>		
	public class PTOF : CommonLogicalNode	
	{	
		private ACD StrField;
		private ACT OpField; 
		private ASG StrValField; 
		private ASG BlkValField;
		private INC OpCntRsField; 	
		private ING OpDlTmmsField;	
		private ING RsDlTmmsField;	
		private SPS BlkVField;	
			
		public PTOF(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.CCGR;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField =new ACT("Op", lnType, iedType); 
			this.StrValField =new ASG("StrVal", lnType, iedType); 
			this.BlkValField =new ASG("BlkVal", lnType, iedType); 
			this.OpCntRsField =new INC("OpCntRs", lnType, iedType); 
			this.OpDlTmmsField =new ING("OpDlTmms", lnType, iedType); 	
			this.RsDlTmmsField =new ING("RsDlTmms", lnType, iedType); 
			this.BlkVField =new SPS("BlkV", lnType, iedType);						
		}

		[Required]
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}	

		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		} 

		public ASG BlkVal
		{			
			get 
			{
				return this.BlkValField;
			}			
			set
			{				
				this.BlkValField = value;
			}
		} 		

		public ASG StrVal
		{			
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		} 	
	
		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}	
		
		public ING OpDlTmms
		{			
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		} 
			
		public ING RsDlTmms
		{			
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}
		
		public SPS BlkV
		{			
			get 
			{
				return this.BlkVField;
			}			
			set
			{				
				this.BlkVField = value;
			}
		}	
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PTOV" (Overvoltage).
	/// </summary>		
	public class PTOV : CommonLogicalNode	
	{	
		private ACD StrField;
		private ACT OpField; 
		private ASG StrValField; 
		private ASG TmMultField; 	
		private CSD TmVStField; 
		private CURVE TmVCrvField;	
		private INC OpCntRsField; 
		private ING MinOpTmmsField; 
		private ING MaxOpTmmsField; 
		private ING OpDlTmmsField;	
		private ING RsDlTmmsField;

		public PTOV(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.CCGR;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField =new ACT("Op", lnType, iedType); 
			this.StrValField =new ASG("StrVal", lnType, iedType); 
			this.TmMultField =new ASG("TmMult", lnType, iedType); 
			this.TmVStField =new CSD("TmVSt", lnType, iedType); 
			this.TmVCrvField =new CURVE("TmVCrv", lnType, iedType); 
			this.OpCntRsField =new INC("OpCntRs", lnType, iedType);	
			this.MinOpTmmsField =new ING("MinOpTmms", lnType, iedType); 
			this.MaxOpTmmsField =new ING("MaxOpTmms", lnType, iedType); 
			this.OpDlTmmsField =new ING("OpDlTmms", lnType, iedType); 	
			this.RsDlTmmsField =new ING("RsDlTmms", lnType, iedType);			
		}

		[Required]
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		} 
			
		public ASG StrVal
		{			
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		}  
			
		public ASG TmMult
		{			
			get 
			{
				return this.TmMultField;
			}			
			set
			{				
				this.TmMultField = value;
			}
		} 	
			
		public CSD TmVSt
		{			
			get 
			{
				return this.TmVStField;
			}			
			set
			{				
				this.TmVStField = value;
			}
		} 	
			
		public CURVE TmVCrv
		{			
			get 
			{
				return this.TmVCrvField;
			}			
			set
			{				
				this.TmVCrvField = value;
			}
		} 
			
		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		} 

		public ING MaxOpTmms
		{			
			get 
			{
				return this.MaxOpTmmsField;
			}			
			set
			{				
				this.MaxOpTmmsField = value;
			}
		} 	

		public ING MinOpTmms
		{			
			get 
			{
				return this.MinOpTmmsField;
			}			
			set
			{				
				this.MinOpTmmsField = value;
			}
		} 	

		public ING OpDlTmms
		{			
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}  
			
		public ING RsDlTmms
		{			
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}			
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PTRC" (Protection trip conditioning).
	/// </summary>		
	public class PTRC : CommonLogicalNode	
	{	
		private ACD StrField;
		private ACT TrField;
		private ACT OpField;  
		private INC OpCntRsField;
		private ING TrModField; 
		private ING TrPlsTmmsField;
		
		public PTRC(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.CCGR;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType); 
			this.TrField = new ACT("Tr", lnType, iedType); 
			this.OpField = new ACT("Op", lnType, iedType); 
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType); 	
			this.TrModField = new ING("TrMod", lnType, iedType); 	
			this.TrPlsTmmsField = new ING("TrPlsTmms", lnType, iedType);			
		}
		
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		} 

		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}  		

		public ACT Tr
		{			
			get 
			{
				return this.TrField;
			}			
			set
			{				
				this.TrField = value;
			}
		}
						
		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}  
			
		public ING TrMod
		{			
			get 
			{
				return this.TrModField;
			}			
			set
			{				
				this.TrModField = value;
			}
		} 
			
		public ING TrPlsTmms
		{			
			get 
			{
				return this.TrPlsTmmsField;
			}			
			set
			{				
				this.TrPlsTmmsField = value;
			}
		}				
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PTTR" (Thermal overload).
	/// </summary>		
	public class PTTR : CommonLogicalNode	
	{	
		private ACD StrField;
		private ACT OpField;   
		private ACT AlmThmField; 
		private ASG TmpMaxField;
		private ASG StrValField; 
		private ASG AlmValField; 
		private CSD TmTmpStField; 
		private CSD TmAStField; 
		private CURVE TmTmpCrvField; 
		private CURVE TmACrvField; 	
		private INC OpCntRsField;	
		private ING OpDlTmmsField;	
		private ING MinOpTmmsField;	 
		private ING MaxOpTmmsField;	
		private ING RsDlTmmsField;	
		private ING ConsTmsField;	
		private MV AmpField; 
		private MV TmpField; 	
		private MV TmpRlField;	
		private MV LodRsvAlmField;
		private MV LodRsvTrField;	
		private MV AgeRatField;
		
		public PTTR(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.CCGR;
			this.iedType = iedType;			
			this.StrField = new ACD("Str", lnType, iedType); 
			this.OpField = new ACT("Op", lnType, iedType); 
			this.AlmThmField = new ACT("AlmThm", lnType, iedType); 
			this.TmpMaxField = new ASG("TmpMax", lnType, iedType); 
			this.StrValField = new ASG("StrVal", lnType, iedType); 
			this.AlmValField = new ASG("AlmVal", lnType, iedType); 
			this.TmTmpStField = new CSD("TmTmpSt", lnType, iedType); 
			this.TmAStField = new CSD("TmASt", lnType, iedType); 
			this.TmTmpCrvField = new CURVE("TmTmpCrv", lnType, iedType); 
			this.TmACrvField = new CURVE("TmACrv", lnType, iedType); 
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType); 	
			this.OpDlTmmsField = new ING("OpDlTmms", lnType, iedType); 
			this.MinOpTmmsField = new ING("MinOpTmms", lnType, iedType); 
			this.MaxOpTmmsField = new ING("MaxOpTmms", lnType, iedType); 
			this.RsDlTmmsField = new ING("RsDlTmms", lnType, iedType);
			this.ConsTmsField = new ING("ConsTms", lnType, iedType);	
			this.AmpField = new MV("Amp", lnType, iedType);	
			this.TmpField = new MV("Tmp", lnType, iedType);	
			this.TmpRlField = new MV("TmpRl", lnType, iedType); 
			this.LodRsvAlmField = new MV("LodRsvAlm", lnType, iedType); 
			this.LodRsvTrField = new MV("LodRsvTr", lnType, iedType);
			this.AgeRatField = new MV("AgeRat", lnType, iedType);			
		}
		
		public ACD Str
		{			
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		public ACT AlmThm
		{			
			get 
			{
				return this.AlmThmField;
			}			
			set
			{				
				this.AlmThmField = value;
			}
		} 

		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}	

		public ASG AlmVal
		{			
			get 
			{
				return this.AlmValField;
			}			
			set
			{				
				this.AlmValField = value;
			}
		} 

		public ASG StrVal
		{			
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		} 

		public ASG TmpMax
		{			
			get 
			{
				return this.TmpMaxField;
			}			
			set
			{				
				this.TmpMaxField = value;
			}
		} 
	
		public CSD TmASt
		{			
			get 
			{
				return this.TmAStField;
			}			
			set
			{				
				this.TmAStField = value;
			}
		} 
	
		public CSD TmTmpSt
		{			
			get 
			{
				return this.TmTmpStField;
			}			
			set
			{				
				this.TmTmpStField = value;
			}
		} 	
	
		public CURVE TmACrv
		{			
			get 
			{
				return this.TmACrvField;
			}			
			set
			{				
				this.TmACrvField = value;
			}
		} 	
	
		public CURVE TmTmpCrv
		{			
			get 
			{
				return this.TmTmpCrvField;
			}			
			set
			{				
				this.TmTmpCrvField = value;
			}
		}  	

		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		} 		

		public ING ConsTms
		{			
			get 
			{
				return this.ConsTmsField;
			}			
			set
			{				
				this.ConsTmsField = value;
			}
		} 	

		public ING MaxOpTmms
		{			
			get 
			{
				return this.MaxOpTmmsField;
			}			
			set
			{				
				this.MaxOpTmmsField = value;
			}
		} 	

		public ING MinOpTmms
		{			
			get 
			{
				return this.MinOpTmmsField;
			}			
			set
			{				
				this.MinOpTmmsField = value;
			}
		}	

		public ING OpDlTmms
		{			
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}	

		public ING RsDlTmms
		{			
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		} 

		public MV AgeRat
		{			
			get 
			{
				return this.AgeRatField;
			}			
			set
			{				
				this.AgeRatField = value;
			}
		}	

		public MV Amp
		{			
			get 
			{
				return this.AmpField;
			}			
			set
			{				
				this.AmpField = value;
			}
		}
	
		public MV LodRsvAlm
		{			
			get 
			{
				return this.LodRsvAlmField;
			}			
			set
			{				
				this.LodRsvAlmField = value;
			}
		}
	
		public MV LodRsvTr
		{			
			get 
			{
				return this.LodRsvTrField;
			}			
			set
			{				
				this.LodRsvTrField = value;
			}
		}			

		public MV Tmp
		{			
			get 
			{
				return this.TmpField;
			}			
			set
			{				
				this.TmpField = value;
			}
		} 			
	
		public MV TmpRl
		{			
			get 
			{
				return this.TmpRlField;
			}			
			set
			{				
				this.TmpRlField = value;
			}
		} 		
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PTUC" (Undercurrent).
	/// </summary>		
	public class PTUC : CommonLogicalNode
	{
		private ACD StrField; 
		private ACT OpField;
		private ASG StrValField;
		private ASG TmMultField;
		private CSD TmAStField;
		private CURVE TmACrvField;
		private INC OpCntRsField;
		private ING OpDlTmmsField;
		private ING MinOpTmmsField;	
		private ING MaxOpTmmsField;
		private ING TypRsCrvField;
		private ING RsDlTmmsField;
		private ING DirModField;
		
		public PTUC(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.PTUC;
			this.iedType = iedType;
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField = new ACT("Op", lnType, iedType);
			this.StrValField = new ASG("StrVal", lnType, iedType);
			this.TmMultField = new ASG("TmMult", lnType, iedType);
			this.TmAStField = new CSD("TmASt", lnType, iedType);
			this.TmACrvField = new CURVE("TmACrv", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.OpDlTmmsField = new ING ("OpDlTmms", lnType, iedType);
			this.MinOpTmmsField = new ING ("MinOpTmms", lnType, iedType);
			this.MaxOpTmmsField = new ING ("MaxOpTmms", lnType, iedType);
			this.TypRsCrvField = new ING ("TypRsCrv", lnType, iedType);
			this.RsDlTmmsField = new ING ("RsDlTmms", lnType, iedType);
			this.DirModField = new ING ("DirMod", lnType, iedType);
		}

		[Required]
		public ACD Str
		{
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public ASG StrVal
		{
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		}

		public ASG TmMult
		{
			get 
			{
				return this.TmMultField;
			}			
			set
			{				
				this.TmMultField = value;
			}
		}

		public CSD TmASt
		{
			get 
			{
				return this.TmAStField;
			}			
			set
			{				
				this.TmAStField = value;
			}
		}

		public CURVE TmACrv
		{
			get 
			{
				return this.TmACrvField;
			}			
			set
			{				
				this.TmACrvField = value;
			}
		}
	
		public INC OpCntRs
		{
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING OpDlTmms
		{
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}

		public ING MinOpTmms
		{
			get 
			{
				return this.MinOpTmmsField;
			}			
			set
			{				
				this.MinOpTmmsField = value;
			}
		}

		public ING MaxOpTmms
		{
			get 
			{
				return this.MaxOpTmmsField;
			}			
			set
			{				
				this.MaxOpTmmsField = value;
			}
		}
	
		public ING TypRsCrv
		{
			get 
			{
				return this.TypRsCrvField;
			}			
			set
			{				
				this.TypRsCrvField = value;
			}
		}

		public ING RsDlTmms
		{
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}
		
		public ING DirMod
		{
			get 
			{
				return this.DirModField;
			}			
			set
			{				
				this.DirModField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PTUF" (Underfrequency).
	/// </summary>		
	public class PTUF : CommonLogicalNode
	{
		private ACD StrField; 
		private ACT OpField;
		private ASG StrValField;
		private ASG BlkValField;
		private INC OpCntRsField;
		private ING OpDlTmmsField;
		private ING RsDlTmmsField;
		private SPS BlkVField;
		
		public PTUF(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.PTUF;
			this.iedType = iedType;
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField = new ACT("Op", lnType, iedType);
			this.StrValField = new ASG("StrVal", lnType, iedType);
			this.BlkValField = new ASG("BlkVal", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.OpDlTmmsField = new ING ("OpDlTmms", lnType, iedType);
			this.RsDlTmmsField = new ING ("RsDlTmms", lnType, iedType);
			this.BlkVField = new SPS("BlkV",lnType, iedType);
		}

		[Required]
		public ACD Str
		{
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public ASG StrVal
		{
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		}

		public ASG BlkVal
		{
			get 
			{
				return this.BlkValField;
			}			
			set
			{				
				this.BlkValField = value;
			}
		}

		public INC OpCntRs
		{
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING OpDlTmms
		{
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}

		public ING RsDlTmms
		{
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}

		public SPS BlkV
		{
			get 
			{
				return this.BlkVField;
			}			
			set
			{				
				this.BlkVField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PTUV" (Undervoltage).
	/// </summary>		
	public class PTUV : CommonLogicalNode
	{
		private ACD StrField; 
		private ACT OpField;
		private ASG StrValField;
		private ASG TmMultField;
		private CSD TmVStField;
		private CURVE TmVCrvField;
		private INC OpCntRsField;
		private ING MinOpTmmsField;	
		private ING MaxOpTmmsField;
		private ING OpDlTmmsField;
		private ING RsDlTmmsField;
		
		public PTUV(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.PTUV;
			this.iedType = iedType;
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField = new ACT("Op", lnType, iedType);
			this.StrValField = new ASG("StrVal", lnType, iedType);
			this.TmMultField = new ASG("TmMult", lnType, iedType);
			this.TmVStField = new CSD("TmVSt", lnType, iedType);
			this.TmVCrvField =new CURVE("TmVCrv", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.MinOpTmmsField = new ING ("MinOpTmms", lnType, iedType);
			this.MaxOpTmmsField = new ING ("MaxOpTmms", lnType, iedType);
			this.OpDlTmmsField = new ING ("OpDlTmms", lnType, iedType);
			this.RsDlTmmsField = new ING ("RsDlTmms", lnType, iedType);
		}

		[Required]
		public ACD Str
		{
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}
	
		[Required]
		public ACT Op
		{
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public ASG StrVal
		{
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		}

		public ASG TmMult
		{
			get 
			{
				return this.TmMultField;
			}			
			set
			{				
				this.TmMultField = value;
			}
		}
	
		public CSD TmVSt
		{
			get 
			{
				return this.TmVStField;
			}			
			set
			{				
				this.TmVStField = value;
			}
		}
	
		public CURVE TmVCrv
		{
			get 
			{
				return this.TmVCrvField;
			}			
			set
			{				
				this.TmVCrvField = value;
			}
		}
	
		public INC OpCntRs
		{
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}
	
		public ING MinOpTmms
		{
			get 
			{
				return this.MinOpTmmsField;
			}			
			set
			{				
				this.MinOpTmmsField = value;
			}
		}

		public ING MaxOpTmms
		{
			get 
			{
				return this.MaxOpTmmsField;
			}			
			set
			{				
				this.MaxOpTmmsField = value;
			}
		}
	
		public ING OpDlTmms
		{
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}

		public ING RsDlTmms
		{
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PUPF" (Underpower factor).
	/// </summary>		
	public class PUPF : CommonLogicalNode
	{
		private ACD StrField; 
		private ACT OpField;
		private ASG StrValField;
		private ASG BlkValAField;
		private ASG BlkValVField;
		private INC OpCntRsField;
		private ING OpDlTmmsField;
		private ING RsDlTmmsField;
		private SPS BlkAField;
		private SPS BlkVField;
		
		public PUPF(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.PUPF;
			this.iedType = iedType;
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField = new ACT("Op", lnType, iedType);
			this.StrValField = new ASG("StrVal", lnType, iedType);
			this.BlkValAField = new ASG("BlkValA", lnType, iedType);
			this.BlkValVField = new ASG("BlkValV", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.OpDlTmmsField = new ING ("OpDlTmms", lnType, iedType);
			this.RsDlTmmsField = new ING ("RsDlTmms", lnType, iedType);
			this.BlkAField = new SPS("BlkA", lnType, iedType);
			this.BlkVField = new SPS("BlkV",lnType, iedType);
		}
	
		[Required]
		public ACD Str
		{
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public ASG StrVal
		{
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		}

		public ASG BlkValA
		{
			get 
			{
				return this.BlkValAField;
			}			
			set
			{				
				this.BlkValAField = value;
			}
		}

		public ASG BlkValV
		{
			get 
			{
				return this.BlkValVField;
			}			
			set
			{				
				this.BlkValVField = value;
			}
		}
		
		public INC OpCntRs
		{
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING OpDlTmms
		{
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}

		public ING RsDlTmms
		{
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}

		public SPS BlkA
		{
			get 
			{
				return this.BlkAField;
			}			
			set
			{				
				this.BlkAField = value;
			}
		}

		public SPS BlkV
		{
			get 
			{
				return this.BlkVField;
			}			
			set
			{				
				this.BlkVField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PVOC" (Voltage controlled time overcurrent).
	/// </summary>		
	public class PVOC : CommonLogicalNode
	{
		private ACD StrField;
		private ACT OpField;
		private ASG TmMultField;
		private CSD AVStField;
		private CSD TmAStField;
		private CURVE AVCrvField;
		private CURVE TmACrvField;
		private INC OpCntRsField;
		private ING MinOpTmmsField;	
		private ING MaxOpTmmsField;
		private ING OpDlTmmsField;
		private ING TypRsCrvField;
		private ING RsDlTmmsField;
		
		public PVOC(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.PVOC;
			this.iedType = iedType;
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField = new ACT("Op", lnType, iedType);
			this.TmMultField = new ASG("TmMult", lnType, iedType);
			this.AVStField = new CSD ("AVSt", lnType, iedType);
			this.TmAStField = new CSD("TmASt", lnType, iedType);
			this.AVCrvField = new CURVE ("AVCrv", lnType, iedType);
			this.TmACrvField = new CURVE("TmACrv", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.MinOpTmmsField = new ING ("MinOpTmms", lnType, iedType);
			this.MaxOpTmmsField = new ING ("MaxOpTmms", lnType, iedType);
			this.OpDlTmmsField = new ING ("OpDlTmms", lnType, iedType);
			this.TypRsCrvField = new ING ("TypRsCrv", lnType, iedType);
			this.RsDlTmmsField = new ING ("RsDlTmms", lnType, iedType);			
		}

		[Required]
		public ACD Str
		{
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public ASG TmMult
		{
			get 
			{
				return this.TmMultField;
			}			
			set
			{				
				this.TmMultField = value;
			}
		}
	
		public CSD AVSt
		{
			get 
			{
				return this.AVStField;
			}			
			set
			{				
				this.AVStField = value;
			}
		}
	
		public CSD TmASt
		{
			get 
			{
				return this.TmAStField;
			}			
			set
			{				
				this.TmAStField = value;
			}
		}

		public CURVE AVCrv
		{
			get 
			{
				return this.AVCrvField;
			}			
			set
			{				
				this.AVCrvField = value;
			}
		}

		public CURVE TmACrv
		{
			get 
			{
				return this.TmACrvField;
			}			
			set
			{				
				this.TmACrvField = value;
			}
		}

		public INC OpCntRs
		{
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING MinOpTmms
		{
			get 
			{
				return this.MinOpTmmsField;
			}			
			set
			{				
				this.MinOpTmmsField = value;
			}
		}

		public ING MaxOpTmms
		{
			get 
			{
				return this.MaxOpTmmsField;
			}			
			set
			{				
				this.MaxOpTmmsField = value;
			}
		}

		public ING OpDlTmms
		{
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}
	
		public ING TypRsCrv
		{
			get 
			{
				return this.TypRsCrvField;
			}			
			set
			{				
				this.TypRsCrvField = value;
			}
		}
	
		public ING RsDlTmms
		{
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PVPH" (Volts per Hz).
	/// </summary>		
	public class PVPH : CommonLogicalNode
	{
		private ACD StrField; 
		private ACT OpField;
		private ASG StrValField;
		private ASG TmMultField;
		private CSD VHzStField;
		private CURVE VHzCrvField;
		private INC OpCntRsField;
		private ING OpDlTmmsField;
		private ING TypRsCrvField;
		private ING RsDlTmmsField;
		private ING MinOpTmmsField;	
		private ING MaxOpTmmsField;
		
		public PVPH(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.PVPH;
			this.iedType = iedType;
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField = new ACT("Op", lnType, iedType);
			this.StrValField = new ASG("StrVal", lnType, iedType);
			this.TmMultField = new ASG("TmMult", lnType, iedType);
			this.VHzStField = new CSD("VHzSt", lnType, iedType);
			this.VHzCrvField = new CURVE("VHzCrv", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.OpDlTmmsField = new ING ("OpDlTmms", lnType, iedType);
			this.TypRsCrvField = new ING ("TypRsCrv", lnType, iedType);
			this.RsDlTmmsField = new ING ("RsDlTmms", lnType, iedType);
			this.MinOpTmmsField = new ING ("MinOpTmms", lnType, iedType);
			this.MaxOpTmmsField = new ING ("MaxOpTmms", lnType, iedType);
		}
	
		[Required]
		public ACD Str
		{
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}
	
		public ASG StrVal
		{
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		}

		public ASG TmMult
		{
			get 
			{
				return this.TmMultField;
			}			
			set
			{				
				this.TmMultField = value;
			}
		}
	
		public CSD VHzSt
		{
			get 
			{
				return this.VHzStField;
			}			
			set
			{				
				this.VHzStField = value;
			}
		}

		public CURVE VHzCrv
		{
			get 
			{
				return this.VHzCrvField;
			}			
			set
			{				
				this.VHzCrvField = value;
			}
		}

		public INC OpCntRs
		{
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING OpDlTmms
		{
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}
	
		public ING TypRsCrv
		{
			get 
			{
				return this.TypRsCrvField;
			}			
			set
			{				
				this.TypRsCrvField = value;
			}
		}

		public ING RsDlTmms
		{
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}
	
		public ING MinOpTmms
		{
			get 
			{
				return this.MinOpTmmsField;
			}			
			set
			{				
				this.MinOpTmmsField = value;
			}
		}

		public ING MaxOpTmms
		{
			get 
			{
				return this.MaxOpTmmsField;
			}			
			set
			{				
				this.MaxOpTmmsField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "PZSU" (Zero speed or underspeed).
	/// </summary>	
	public class PZSU : CommonLogicalNode
	{
		private ACD StrField; 
		private ACT OpField;
		private ASG StrValField;
		private INC OpCntRsField;
		private ING OpDlTmmsField;
		private ING RsDlTmmsField;
		
		public PZSU(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.PZSU;
			this.iedType = iedType;
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField = new ACT("Op", lnType, iedType);
			this.StrValField = new ASG("StrVal", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.OpDlTmmsField = new ING ("OpDlTmms", lnType, iedType);
			this.RsDlTmmsField = new ING ("RsDlTmms", lnType, iedType);
		}

		[Required]
		public ACD Str
		{
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		[Required]
		public ACT Op
		{
			get 
			{
				return this.OpField;
			}		
			set
			{				
				this.OpField = value;
			}
		}
	
		public ASG StrVal
		{
			get 
			{
				return this.StrValField;
			}			
			set
			{				
				this.StrValField = value;
			}
		}
	
		public INC OpCntRs
		{
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING OpDlTmms
		{
			get 
			{
				return this.OpDlTmmsField;
			}			
			set
			{				
				this.OpDlTmmsField = value;
			}
		}
	
		public ING RsDlTmms
		{
			get 
			{
				return this.RsDlTmmsField;
			}			
			set
			{				
				this.RsDlTmmsField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "RADR" (Disturbance recorder channel analogue).
	/// </summary>		
	public class RADR : CommonLogicalNode
	{
		private ASG HiTrgLevField;
		private ASG LoTrgLevField;
		private INC OpCntRsField;
		private ING ChNumField;
		private ING TrgModField;
		private ING LevModField;
		private ING PreTmmsField;
		private ING PstTmmsField;
		private SPS ChTrgField;
		
		public RADR(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.RADR;
			this.iedType = iedType;
			this.HiTrgLevField = new ASG("HiTrgLev", lnType, iedType);
			this.LoTrgLevField = new ASG("LoTrgLev", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.ChNumField = new ING("ChNum", lnType, iedType);
			this.TrgModField = new ING("TrgMod", lnType, iedType);
			this.LevModField = new ING("LevMod", lnType, iedType);
			this.PreTmmsField = new ING("PreTmms", lnType, iedType);
			this.PstTmmsField = new ING("PstTmms", lnType, iedType);
			this.ChTrgField = new SPS("ChTrg", lnType, iedType);
		}

		public ASG HiTrgLev
		{
			get 
			{
				return this.HiTrgLevField;
			}			
			set
			{				
				this.HiTrgLevField = value;
			}
		}

		public ASG LoTrgLev
		{
			get 
			{
				return this.LoTrgLevField;
			}			
			set
			{				
				this.LoTrgLevField = value;
			}
		}
	
		public INC OpCntRs
		{
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING ChNum
		{
			get 
			{
				return this.ChNumField;
			}			
			set
			{				
				this.ChNumField = value;
			}
		}

		public ING TrgMod
		{
			get 
			{
				return this.TrgModField;
			}			
			set
			{				
				this.TrgModField = value;
			}
		}
	
		public ING LevMod
		{
			get 
			{
				return this.LevModField;
			}			
			set
			{				
				this.LevModField = value;
			}
		}

		public ING PreTmms
		{
			get 
			{
				return this.PreTmmsField;
			}			
			set
			{				
				this.PreTmmsField = value;
			}
		}

		public ING PstTmms
		{
			get 
			{
				return this.PstTmmsField;
			}			
			set
			{				
				this.PstTmmsField = value;
			}
		}
	
		[Required]
		public SPS ChTrg
		{
			get 
			{
				return this.ChTrgField;
			}			
			set
			{				
				this.ChTrgField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "RBDR" (Disturbance recorder channel binary).
	/// </summary>		
	public class RBDR : CommonLogicalNode
	{
		private INC OpCntRsField;
		private ING ChNumField;
		private ING TrgModField;
		private ING LevModField;
		private ING PreTmmsField;
		private ING PstTmmsField;
		private SPS ChTrgField;
		
		public RBDR(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.RBDR;
			this.iedType = iedType;
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.ChNumField = new ING("ChNum", lnType, iedType);
			this.TrgModField = new ING("TrgMod", lnType, iedType);
			this.LevModField = new ING("LevMod", lnType, iedType);
			this.PreTmmsField = new ING("PreTmms", lnType, iedType);
			this.PstTmmsField = new ING("PstTmms", lnType, iedType);
			this.ChTrgField = new SPS("ChTrg", lnType, iedType);
		}

		public INC OpCntRs
		{
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING ChNum
		{
			get 
			{
				return this.ChNumField;
			}			
			set
			{				
				this.ChNumField = value;
			}
		}
	
		public ING TrgMod
		{
			get 
			{
				return this.TrgModField;
			}			
			set
			{				
				this.TrgModField = value;
			}
		}
	
		public ING LevMod
		{
			get 
			{
				return this.LevModField;
			}			
			set
			{				
				this.LevModField = value;
			}
		}
	
		public ING PreTmms
		{
			get 
			{
				return this.PreTmmsField;
			}			
			set
			{				
				this.PreTmmsField = value;
			}
		}
	
		public ING PstTmms
		{
			get 
			{
				return this.PstTmmsField;
			}			
			set
			{				
				this.PstTmmsField = value;
			}
		}

		[Required]
		public SPS ChTrg
		{
			get 
			{
				return this.ChTrgField;
			}			
			set
			{				
				this.ChTrgField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "RBRF" (Breaker failure).
	/// </summary>		
	public class RBRF : CommonLogicalNode
	{
		private ACD StrField;
		private ACT OpExField;
		private ACT OpInField;
		private ASG DetValAField;
		private INC OpCntRsField;
		private ING FailModField;
		private ING FailTmmsField;
		private ING SPlTrTmmsField;
		private ING TPTrTmmsField;
		private ING ReTrModField;
		
		public RBRF(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.RBRF;
			this.iedType = iedType;
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpExField = new ACT("OpEx", lnType, iedType);
			this.OpInField = new ACT("OpIn", lnType, iedType);
			this.DetValAField = new ASG("DetValA", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.FailModField = new ING("FailMod", lnType, iedType);
			this.FailTmmsField = new ING("FailTmms", lnType, iedType);
			this.SPlTrTmmsField = new ING("SPlTrTmms", lnType, iedType);
			this.TPTrTmmsField = new ING("TPTrTmms", lnType, iedType);
			this.ReTrModField = new ING("ReTrMod", lnType, iedType);
		}
	
		public ACD Str
		{
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		public ACT OpEx
		{
			get 
			{
				return this.OpExField;
			}			
			set
			{				
				this.OpExField = value;
			}
		}

		public ACT OpIn
		{
			get 
			{
				return this.OpInField;
			}			
			set
			{				
				this.OpInField = value;
			}
		}

		public ASG DetValA
		{
			get 
			{
				return this.DetValAField;
			}			
			set
			{				
				this.DetValAField = value;
			}
		}
	
		public INC OpCntRs
		{
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING FailMod
		{
			get 
			{
				return this.FailModField;
			}			
			set
			{				
				this.FailModField = value;
			}
		}

		public ING FailTmms
		{
			get 
			{
				return this.FailTmmsField;
			}			
			set
			{				
				this.FailTmmsField = value;
			}
		}

		public ING SPlTrTmms
		{
			get 
			{
				return this.SPlTrTmmsField;
			}			
			set
			{				
				this.SPlTrTmmsField = value;
			}
		}
	
		public ING TPTrTmms
		{
			get 
			{
				return this.TPTrTmmsField;
			}		
			set
			{				
				this.TPTrTmmsField = value;
			}
		}

		public ING ReTrMod
		{
			get 
			{
				return this.ReTrModField;
			}			
			set
			{				
				this.ReTrModField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "RDIR" (Directional element).
	/// </summary>		
	public class RDIR : CommonLogicalNode
	{
		private ACD DirField;
		private ASG ChrAngField;
		private ASG MinFwdAngField;
		private ASG MinRvAngField;
		private ASG MaxFwdAngField;
		private ASG MaxRvAngField;
		private ASG BlkValAField;
		private ASG BlkValVField;
		private ASG MinPPVField;
		private ING PolQtyField;
		
		public RDIR(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.RDIR;
			this.iedType = iedType;
			this.DirField = new ACD("Dir", lnType, iedType);
			this.ChrAngField = new ASG("ChrAng", lnType, iedType);
			this.MinFwdAngField = new ASG("MinFwdAng", lnType, iedType);
			this.MinRvAngField = new ASG("MinRvAng", lnType, iedType);
			this.MaxFwdAngField = new ASG("MaxFwdAng", lnType, iedType);
			this.MaxRvAngField = new ASG("MaxRvAng", lnType, iedType);
			this.BlkValAField = new ASG("BlkValA", lnType, iedType);
			this.BlkValVField = new ASG("BlkValV", lnType, iedType);
			this.MinPPVField = new ASG("MinPPV", lnType, iedType);
			this.PolQtyField = new ING("PolQty", lnType, iedType);
		}

		[Required]
		public ACD Dir
		{
			get 
			{
				return this.DirField;
			}			
			set
			{				
				this.DirField = value;
			}
		}

		public ASG ChrAng
		{
			get 
			{
				return this.ChrAngField;
			}			
			set
			{				
				this.ChrAngField = value;
			}
		}

		public ASG MinFwdAng
		{
			get 
			{
				return this.MinFwdAngField;
			}			
			set
			{				
				this.MinFwdAngField = value;
			}
		}

		public ASG MinRvAng
		{
			get 
			{
				return this.MinRvAngField;
			}			
			set
			{				
				this.MinRvAngField = value;
			}
		}

		public ASG MaxFwdAng
		{
			get 
			{
				return this.MaxFwdAngField;
			}			
			set
			{				
				this.MaxFwdAngField = value;
			}
		}
	
		public ASG MaxRvAng
		{
			get 
			{
				return this.MaxRvAngField;
			}			
			set
			{				
				this.MaxRvAngField = value;
			}
		}

		public ASG BlkValA
		{
			get 
			{
				return this.BlkValAField;
			}			
			set
			{				
				this.BlkValAField = value;
			}
		}

		public ASG BlkValV
		{
			get 
			{
				return this.BlkValVField;
			}			
			set
			{				
				this.BlkValVField = value;
			}
		}

		public ASG MinPPV
		{
			get 
			{
				return this.MinPPVField;
			}			
			set
			{				
				this.MinPPVField = value;
			}
		}

		public ING PolQty
		{
			get 
			{
				return this.PolQtyField;
			}		
			set
			{				
				this.PolQtyField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "RDRE" (Disturbance recorder function).
	/// </summary>		
	public class RDRE : CommonLogicalNode
	{
		private INC OpCntRsField;
		private ING TrgModField;
		private ING LevModField;
		private ING PreTmmsField;
		private ING PstTmmsField;
		private ING MemFullField;
		private ING MaxNumRcdField;
		private ING ReTrgModField;
		private ING PerTrgTmsField;
		private ING ExclTmmsField;
		private ING OpModField;
		private INS FltNumField;
		private INS GriFltNumField;
		private INS MemUsedField;
		private SPC RcdTrgField;
		private SPC MemRsField;
		private SPC MemClrField;
		private SPC RcdMadeField;
		private SPC RcdStrField;
		
		public RDRE(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.RDRE;
			this.iedType = iedType;
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.TrgModField = new ING("TrgMod", lnType, iedType);
			this.LevModField = new ING("LevMod", lnType, iedType);
			this.PreTmmsField = new ING("PreTmms", lnType, iedType);
			this.PstTmmsField = new ING("PstTmms", lnType, iedType);
			this.MemFullField = new ING("MemFull", lnType, iedType);
			this.MaxNumRcdField = new ING("MaxNumRcd",  lnType, iedType);
			this.ReTrgModField = new ING("ReTrgMod", lnType, iedType);
			this.PerTrgTmsField = new ING("PerTrgTms", lnType, iedType);
			this.ExclTmmsField = new ING("ExclTmms", lnType, iedType);
			this.OpModField = new ING("OpMod",  lnType, iedType);
			this.FltNumField = new INS("FltNum", lnType, iedType);
			this.GriFltNumField = new INS("GriFltNum", lnType, iedType);
			this.MemUsedField = new INS("MemUsed", lnType, iedType);
			this.RcdTrgField = new SPC("RcdTrg", lnType, iedType);
			this.MemRsField = new SPC("MemRs", lnType, iedType);
			this.MemClrField = new SPC("MemClr", lnType, iedType);
			this.RcdMadeField = new SPC("RcdMade", lnType, iedType);
			this.RcdStrField = new SPC("RcdStr", lnType, iedType);
		}

		public INC OpCntRs
		{
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}
	
		public ING TrgMod
		{
			get 
			{
				return this.TrgModField;
			}			
			set
			{				
				this.TrgModField = value;
			}
		}

		public ING LevMod
		{
			get 
			{
				return this.LevModField;
			}			
			set
			{				
				this.LevModField = value;
			}
		}
	
		public ING PreTmms
		{
			get 
			{
				return this.PreTmmsField;
			}			
			set
			{				
				this.PreTmmsField = value;
			}
		}

		public ING PstTmms
		{
			get 
			{
				return this.PstTmmsField;
			}			
			set
			{				
				this.PstTmmsField = value;
			}
		}

		public ING MemFull
		{
			get 
			{
				return this.MemFullField;
			}			
			set
			{				
				this.MemFullField = value;
			}
		}
	
		public ING MaxNumRcd
		{			
			get 
			{
				return this.MaxNumRcdField;
			}			
			set
			{				
				this.MaxNumRcdField = value;
			}
		}

		public ING ReTrgMod
		{			
			get 
			{
				return this.ReTrgModField;
			}			
			set
			{				
				this.ReTrgModField = value;
			}
		}

		public ING PerTrgTms
		{			
			get 
			{
				return this.PerTrgTmsField;
			}			
			set
			{				
				this.PerTrgTmsField = value;
			}
		}

		public ING ExclTmms
		{			
			get 
			{
				return this.ExclTmmsField;
			}			
			set
			{				
				this.ExclTmmsField = value;
			}
		}
	
		public ING OpMod
		{			
			get 
			{
				return this.OpModField;
			}			
			set
			{				
				this.OpModField = value;
			}
		}

		[Required]
		public INS FltNum
		{			
			get 
			{
				return this.FltNumField;
			}		
			set
			{				
				this.FltNumField = value;
			}
		}
	
		public INS GriFltNum
		{			
			get 
			{
				return this.GriFltNumField;
			}			
			set
			{				
				this.GriFltNumField = value;
			}
		}
	
		public INS MemUsed
		{			
			get 
			{
				return this.MemUsedField;
			}			
			set
			{				
				this.MemUsedField = value;
			}
		}

		public SPC RcdTrg
		{			
			get 
			{
				return this.RcdTrgField;
			}			
			set
			{				
				this.RcdTrgField = value;
			}
		}

		public SPC MemRs
		{			
			get 
			{
				return this.MemRsField;
			}			
			set
			{				
				this.MemRsField = value;
			}
		}
	
		public SPC MemClr
		{			
			get 
			{
				return this.MemClrField;
			}			
			set
			{				
				this.MemClrField = value;
			}
		}

		[Required]
		public SPC RcdMade
		{			
			get 
			{
				return this.RcdMadeField;
			}			
			set
			{				
				this.RcdMadeField = value;
			}
		}

		public SPC RcdStr
		{			
			get 
			{
				return this.RcdStrField;
			}		
			set
			{				
				this.RcdStrField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "RDRS" (Disturbance record handling).
	/// </summary>		
	public class RDRS : CommonLogicalNode
	{
		private SPC AutoUpLodField;
		private SPC DltRcdField;
		
		public RDRS(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.RDRS;
			this.iedType = iedType;
			this.AutoUpLodField = new SPC("AutoUpLod", lnType, iedType);
			this.DltRcdField = new SPC("DltRcd", lnType, iedType);
		}

		public SPC AutoUpLod
		{
			get 
			{
				return this.AutoUpLodField;
			}			
			set
			{				
				this.AutoUpLodField = value;
			}
		}

		public SPC DltRcd
		{
			get 
			{
				return this.DltRcdField;
			}			
			set
			{				
				this.DltRcdField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "RFLO" (Fault locator).
	/// </summary>		
	public class RFLO : CommonLogicalNode
	{
		private ASG LinLenKmField;
		private ASG R1Field;
		private ASG X1Field;
		private ASG R0Field;
		private ASG X0Field;
		private ASG Z1ModField;
		private ASG Z1AngField;
		private ASG Z0ModField;
		private ASG Z0AngField;
		private ASG Rm0Field;
		private ASG Xm0Field;
		private ASG Zm0ModField;
		private ASG Zm0AngField;
		private CMV FltZField;
		private INC OpCntRsField;
		private INS FltLoopFiels;
		private MV FltDiskmField;
		
		public RFLO(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.RFLO;
			this.iedType = iedType;
			this.LinLenKmField = new ASG("LinLenKm", lnType, iedType);
			this.R1Field = new ASG("R1", lnType, iedType);
			this.X1Field = new ASG("X1", lnType, iedType);
			this.R0Field = new ASG("R0", lnType, iedType);
			this.X0Field = new ASG("X0", lnType, iedType);
			this.Z1ModField = new ASG("Z1Mod", lnType, iedType);
			this.Z1AngField = new ASG("Z1Ang", lnType, iedType);
			this.Z0ModField = new ASG("Z0Mod", lnType, iedType);
			this.Z0AngField = new ASG("Z0Ang", lnType, iedType);
			this.Rm0Field = new ASG("Rm0", lnType, iedType);
			this.Xm0Field = new ASG("Xm0", lnType, iedType);
			this.Zm0ModField = new ASG("Zm0Mod", lnType, iedType);
			this.Zm0AngField = new ASG("Zm0Ang", lnType, iedType);
			this.FltZField = new CMV("FltZ", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.FltLoopFiels = new INS("FltLoop", lnType, iedType);
			this.FltDiskmField = new MV("FltDiskm", lnType, iedType);
		}

		public ASG LinLenKm
		{
			get 
			{
				return this.LinLenKmField;
			}			
			set
			{				
				this.LinLenKmField = value;
			}
		}

		public ASG R1
		{
			get 
			{
				return this.R1Field;
			}			
			set
			{				
				this.R1Field = value;
			}
		}

		public ASG X1
		{
			get 
			{
				return this.X1Field;
			}			
			set
			{				
				this.X1Field = value;
			}
		}

		public ASG R0
		{
			get 
			{
				return this.R0Field;
			}			
			set
			{				
				this.R0Field = value;
			}
		}
	
		public ASG X0
		{
			get 
			{
				return this.X0Field;
			}			
			set
			{				
				this.X0Field = value;
			}
		}

		public ASG Z1Mod
		{
			get 
			{
				return this.Z1ModField;
			}			
			set
			{				
				this.Z1ModField = value;
			}
		}

		public ASG Z1Ang
		{
			get 
			{
				return this.Z1AngField;
			}			
			set
			{				
				this.Z1AngField = value;
			}
		}

		public ASG Z0Mod
		{
			get 
			{
				return this.Z0ModField;
			}			
			set
			{				
				this.Z0ModField = value;
			}
		}
	
		public ASG Z0Ang
		{
			get 
			{
				return this.Z0AngField;
			}			
			set
			{
				this.Z0AngField = value;
			}
		}

		public ASG Rm0
		{
			get 
			{
				return this.Rm0Field;
			}			
			set
			{
				this.Rm0Field = value;
			}
		}

		public ASG Xm0
		{
			get 
			{
				return this.Xm0Field;
			}			
			set
			{
				this.Xm0Field = value;
			}
		}

		public ASG Zm0Mod
		{
			get 
			{
				return this.Zm0ModField;
			}			
			set
			{
				this.Zm0ModField = value;
			}
		}

		public ASG Zm0Ang
		{
			get 
			{
				return this.Zm0AngField;
			}			
			set
			{
				this.Zm0AngField = value;
			}
		}

		[Required]
		public CMV FltZ
		{
			get 
			{
				return this.FltZField;
			}			
			set
			{
				this.FltZField = value;
			}
		}

		public INC OpCntRs
		{
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public INS FltLoop
		{
			get 
			{
				return this.FltLoopFiels;
			}			
			set
			{				
				this.FltLoopFiels = value;
			}
		}

		public MV FltDiskm
		{
			get 
			{
				return this.FltDiskmField;
			}			
			set
			{				
				this.FltDiskmField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "RPSB" (Power swing detection/blocking).
	/// </summary>		
	public class RPSB : CommonLogicalNode
	{
		private ACD StrField; 
		private ACT OpField;
		private ASG SwgValField;
		private ASG SwgRisField;
		private ASG SwgReactField;
		private INC OpCntRsField;
		private ING SwgTmmsField;
		private ING UnBlkTmmsField;
		private ING MaxNumSlpField;
		private ING EvTmmsField;
		private SPG ZeroEnaField;
		private SPG NgEnaField;
		private SPG MaxEnaField;
		private SPS BlkZnField;
		
		public RPSB(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.RPSB;
			this.iedType = iedType;
			this.StrField = new ACD("Str", lnType, iedType);
			this.OpField = new ACT("Op", lnType, iedType);
			this.SwgValField = new ASG("SwgVal", lnType, iedType);
			this.SwgRisField = new ASG("SwgRis", lnType, iedType);
			this.SwgReactField = new ASG("SwgReact", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.SwgTmmsField = new ING("SwgTmms", lnType, iedType);
			this.UnBlkTmmsField = new ING("UnBlkTmms", lnType, iedType);
			this.MaxNumSlpField = new ING("MaxNumSlp", lnType, iedType);
			this.EvTmmsField = new ING("EvTmms", lnType, iedType);
			this.ZeroEnaField = new SPG("ZeroEna", lnType, iedType);
			this.NgEnaField = new SPG("NgEna", lnType, iedType);
			this.MaxEnaField = new SPG("MaxEna", lnType, iedType);
			this.BlkZnField = new SPS("BlkZn", lnType, iedType);
		}

		public ACD Str
		{
			get 
			{
				return this.StrField;
			}			
			set
			{				
				this.StrField = value;
			}
		}

		public ACT Op
		{
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public ASG SwgVal
		{
			get 
			{
				return this.SwgValField;
			}			
			set
			{				
				this.SwgValField = value;
			}
		}

		public ASG SwgRis
		{
			get 
			{
				return this.SwgRisField;
			}			
			set
			{				
				this.SwgRisField = value;
			}
		}

		public ASG SwgReact
		{
			get 
			{
				return this.SwgReactField;
			}			
			set
			{				
				this.SwgReactField = value;
			}
		}

		public INC OpCntRs
		{
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING SwgTmms
		{
			get 
			{
				return this.SwgTmmsField;
			}			
			set
			{				
				this.SwgTmmsField = value;
			}
		}
	
		public ING UnBlkTmms
		{
			get 
			{
				return this.UnBlkTmmsField;
			}			
			set
			{				
				this.UnBlkTmmsField = value;
			}
		}
	
		public ING MaxNumSlp
		{
			get 
			{
				return this.MaxNumSlpField;
			}			
			set
			{				
				this.MaxNumSlpField = value;
			}
		}
	
		public ING EvTmms
		{
			get 
			{
				return this.EvTmmsField;
			}			
			set
			{				
				this.EvTmmsField = value;
			}
		}
	
		public SPG ZeroEna
		{
			get 
			{
				return this.ZeroEnaField;
			}		
			set
			{				
				this.ZeroEnaField = value;
			}
		}

		public SPG NgEna
		{
			get 
			{
				return this.NgEnaField;
			}			
			set
			{				
				this.NgEnaField = value;
			}
		}

		public SPG MaxEna
		{
			get 
			{
				return this.MaxEnaField;
			}			
			set
			{				
				this.MaxEnaField = value;
			}
		}

		public SPS BlkZn
		{
			get 
			{
				return this.BlkZnField;
			}			
			set
			{				
				this.BlkZnField = value;
			}
		}		
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "RREC" (Autoreclosing).
	/// </summary>		
	public class RREC : CommonLogicalNode
	{
		private ACT OpField;
		private INC OpCntRsField;
		private ING Rec1TmmsField;
		private ING Rec2TmmsField;
		private ING Rec3TmmsField;
		private ING PlsTmmsField;
		private ING RclTmmsField;
		private INS AutoRecStField;
		private SPC BlkRecField;
		private SPC ChkRecField;
		private SPS AutoField;
		
		public RREC(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.RREC;
			this.iedType = iedType;
			this.OpField =new ACT("Op", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.Rec1TmmsField = new ING("Rec1Tmms", lnType, iedType);
			this.Rec2TmmsField = new ING ("Rec2Tmms", lnType, iedType);
			this.Rec3TmmsField = new ING("Rec3Tmms", lnType, iedType);
			this.PlsTmmsField = new ING("PlsTmms", lnType, iedType);
			this.RclTmmsField = new ING("RclTmms", lnType, iedType);
			this.AutoRecStField = new INS("AutoRecSt", lnType, iedType);
			this.BlkRecField = new SPC("BlkRec", lnType, iedType);
			this.ChkRecField = new SPC("ChkRec", lnType, iedType);
			this.AutoField = new SPS("Auto", lnType, iedType);
		}

		[Required]
		public ACT Op
		{			
			get 
			{
				return this.OpField;
			}			
			set
			{				
				this.OpField = value;
			}
		}

		public INC OpCntRs
		{			
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		public ING Rec1Tmms
		{			
			get 
			{
				return this.Rec1TmmsField;
			}			
			set
			{				
				this.Rec1TmmsField = value;
			}
		}

		public ING Rec2Tmms
		{			
			get 
			{
				return this.Rec2TmmsField;
			}			
			set
			{				
				this.Rec2TmmsField = value;
			}
		}

		public ING Rec3Tmms
		{			
			get 
			{
				return this.Rec3TmmsField;
			}			
			set
			{				
				this.Rec3TmmsField = value;
			}
		}
	
		public ING PlsTmms
		{			
			get 
			{
				return this.PlsTmmsField;
			}			
			set
			{				
				this.PlsTmmsField = value;
			}
		}

		public ING RclTmms
		{			
			get 
			{
				return this.RclTmmsField;
			}			
			set
			{				
				this.RclTmmsField = value;
			}
		}

		[Required]
		public INS AutoRecSt
		{			
			get 
			{
				return this.AutoRecStField;
			}			
			set
			{				
				this.AutoRecStField = value;
			}
		}

		public SPC BlkRec
		{			
			get 
			{
				return this.BlkRecField;
			}			
			set
			{				
				this.BlkRecField = value;
			}
		}

		public SPC ChkRec
		{			
			get 
			{
				return this.ChkRecField;
			}			
			set
			{				
				this.ChkRecField = value;
			}
		}

		public SPS Auto
		{			
			get 
			{
				return this.AutoField;
			}			
			set
			{				
				this.AutoField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "RSYN" (Synchronism-check or synchronising).
	/// </summary>		
	public class RSYN : CommonLogicalNode
	{
		private ASG DifVField;
		private ASG DifHzField;
		private ASG DifAngField;
		private ASG DeaLinValField;
		private ASG LivLinValField;
		private ASG DeaBusValField;
		private ASG LivBusValField;
		private ING LivDeaModField;
		private ING PlsTmmsField;
		private ING BkrTmmsField;
		private MV DifVClcField;
		private MV DifHzClcField;
		private MV DifAngClcField;
		private SPC RHzField;
		private SPC LHzField;
		private SPC RVField;
		private SPC LVField;
		private SPS RelField;
		private SPS VIndField;
		private SPS AngIndField;
		private SPS HzIndField;
		private SPS SynPrgField;
		
		public RSYN(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.RSYN;
			this.iedType = iedType;
			this.DifVField = new ASG("DifV", lnType, iedType);
			this.DifHzField = new ASG("DifHz", lnType, iedType);
			this.DifAngField = new ASG("DifAng", lnType, iedType);
			this.DeaLinValField = new ASG("DeaLinVal", lnType, iedType);
			this.LivLinValField = new ASG("LivLinVal", lnType, iedType);
			this.DeaBusValField = new ASG("DeaBusVal", lnType, iedType);
			this.LivBusValField = new ASG("LivBusVal", lnType, iedType);
			this.LivDeaModField = new ING("LivDeaMod", lnType, iedType);
			this.PlsTmmsField = new ING("PlsTmms", lnType, iedType);
			this.BkrTmmsField = new ING("BkrTmms", lnType, iedType); 
			this.DifVClcField = new MV("DifVClc", lnType, iedType);
			this.DifHzClcField = new MV("DifHzClc", lnType, iedType);
			this.DifAngClcField = new MV("DifAngClc", lnType, iedType);
			this.RHzField = new SPC("RHz", lnType, iedType);
			this.LHzField = new SPC("LHz", lnType, iedType);
			this.RVField = new SPC("RV", lnType, iedType);
			this.LVField = new SPC("LV", lnType, iedType);
			this.RelField = new SPS("Rel", lnType, iedType);
			this.VIndField = new SPS("VInd", lnType, iedType);
			this.AngIndField = new SPS("AngInd", lnType, iedType);
			this.HzIndField = new SPS("HzInd", lnType, iedType);
			this.SynPrgField = new SPS("SynPrg", lnType, iedType);
		}

		public ASG DifV
		{			
			get 
			{
				return this.DifVField;
			}			
			set
			{				
				this.DifVField = value;
			}
		}

		public ASG DifHz
		{			
			get 
			{
				return this.DifHzField;
			}			
			set
			{				
				this.DifHzField = value;
			}
		}

		public ASG DifAng
		{			
			get 
			{
				return this.DifAngField;
			}			
			set
			{				
				this.DifAngField = value;
			}
		}

		public ASG DeaLinVal
		{			
			get 
			{
				return this.DeaLinValField;
			}			
			set
			{				
				this.DeaLinValField = value;
			}
		}

		public ASG LivLinVal
		{			
			get 
			{
				return this.LivLinValField;
			}			
			set
			{				
				this.LivLinValField = value;
			}
		}

		public ASG DeaBusVal
		{			
			get 
			{
				return this.DeaBusValField;
			}			
			set
			{				
				this.DeaBusValField = value;
			}
		}

		public ASG LivBusVal
		{			
			get 
			{
				return this.LivBusValField;
			}			
			set
			{				
				this.LivBusValField = value;
			}
		}

		public ING LivDeaMod
		{			
			get 
			{
				return this.LivDeaModField;
			}			
			set
			{				
				this.LivDeaModField = value;
			}
		}

		public ING PlsTmms
		{			
			get 
			{
				return this.PlsTmmsField;
			}			
			set
			{				
				this.PlsTmmsField = value;
			}
		}

		public ING BkrTmms
		{			
			get 
			{
				return this.BkrTmmsField;
			}			
			set
			{				
				this.BkrTmmsField = value;
			}
		}

		public MV DifVClc
		{			
			get 
			{
				return this.DifVClcField;
			}			
			set
			{				
				this.DifVClcField = value;
			}
		}
	
		public MV DifHzClc
		{			
			get 
			{
				return this.DifHzClcField;
			}			
			set
			{				
				this.DifHzClcField = value;
			}
		}

		public MV DifAngClc
		{			
			get 
			{
				return this.DifAngClcField;
			}			
			set
			{				
				this.DifAngClcField = value;
			}
		}

		public SPC RHz
		{			
			get 
			{
				return this.RHzField;
			}			
			set
			{				
				this.RHzField = value;
			}
		}

		public SPC LHz
		{			
			get 
			{
				return this.LHzField;
			}			
			set
			{				
				this.LHzField = value;
			}
		}

		public SPC RV
		{			
			get 
			{
				return this.RVField;
			}			
			set
			{				
				this.RVField = value;
			}
		}

		public SPC LV
		{			
			get 
			{
				return this.LVField;
			}			
			set
			{				
				this.LVField = value;
			}
		}

		[Required]
		public SPS Rel
		{			
			get 
			{
				return this.RelField;
			}			
			set
			{	
				this.RelField = value;
			}
		}

		public SPS VInd
		{			
			get 
			{
				return this.VIndField;
			}			
			set
			{	
				this.VIndField = value;
			}
		}

		public SPS AngInd
		{			
			get 
			{
				return this.AngIndField;
			}			
			set
			{	
				this.AngIndField = value;
			}
		}

		public SPS HzInd
		{			
			get 
			{
				return this.HzIndField;
			}			
			set
			{	
				this.HzIndField = value;
			}
		}

		public SPS SynPrg
		{			
			get 
			{
				return this.SynPrgField;
			}			
			set
			{	
				this.SynPrgField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "SARC" (Monitoring and diagnostics for arcs).
	/// </summary>		
	public class SARC : CommonLogicalNode
	{
		private DPL EENameField;
		private INC OpCntRsField;
		private INC FACntRsField;
		private INC ArcCntRsField;
		private INS EEHealthField;
		private SPS FADetField;
		private SPS SwArcDetField;
		
		public SARC(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.SARC;
			this.iedType = iedType;
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.OpCntRsField = new INC("OpCntRs", lnType, iedType);
			this.FACntRsField = new INC("FACntRs", lnType, iedType);
			this.ArcCntRsField = new INC("ArcCntRs", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.FADetField = new SPS("FADet", lnType, iedType);
			this.SwArcDetField = new SPS("SwArcDet", lnType, iedType);
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INC OpCntRs
		{
			get 
			{
				return this.OpCntRsField;
			}			
			set
			{				
				this.OpCntRsField = value;
			}
		}

		[Required]
		public INC FACntRs
		{
			get 
			{
				return this.FACntRsField;
			}			
			set
			{				
				this.FACntRsField = value;
			}
		}

		public INC ArcCntRs
		{
			get 
			{
				return this.ArcCntRsField;
			}			
			set
			{				
				this.ArcCntRsField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		[Required]
		public SPS FADet
		{			
			get 
			{
				return this.FADetField;
			}			
			set
			{				
				this.FADetField = value;
			}
		}

		public SPS SwArcDet
		{			
			get 
			{
				return this.SwArcDetField;
			}			
			set
			{				
				this.SwArcDetField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "SIMG" (Insulation medium supervision (gas)).
	/// </summary>			
	public class SIMG : CommonLogicalNode
	{
		private DPL EENameField;
		private INS EEHealthField;
		private MV PresField;
		private MV DenField;
		private MV TmpField;
		private SPS InsAlmField;
		private SPS InsBlkField;
		private SPS InsTrField;
		private SPS PresAlmField;
		private SPS DenAlmField;
		private SPS TmpAlmField;
		private SPS InsLevMaxField;
		private SPS InsLevMinField;
		
		public SIMG(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.SIMG;
			this.iedType = iedType;
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.PresField = new MV("Pres", lnType, iedType);
			this.DenField = new MV("Den", lnType, iedType);
			this.TmpField = new MV("Tmp", lnType, iedType); 
			this.InsAlmField = new SPS("InsAlm", lnType, iedType); 
			this.InsBlkField = new SPS("InsBlk", lnType, iedType); 
			this.InsTrField = new SPS("InsTr", lnType, iedType);
			this.PresAlmField = new SPS("PresAlm", lnType, iedType);
			this.DenAlmField = new SPS("DenAlm", lnType, iedType);
			this.TmpAlmField = new SPS("TmpAlm", lnType, iedType);
			this.InsLevMaxField = new SPS("InsLevMax", lnType, iedType);
			this.InsLevMinField = new SPS("InsLevMin", lnType, iedType);
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public MV Pres
		{			
			get 
			{
				return this.PresField;
			}			
			set
			{				
				this.PresField = value;
			}
		}

		public MV Den
		{			
			get 
			{
				return this.DenField;
			}			
			set
			{				
				this.DenField = value;
			}
		}

		public MV Tmp
		{			
			get 
			{
				return this.TmpField;
			}			
			set
			{				
				this.TmpField = value;
			}
		}

		[Required]
		public SPS InsAlm
		{			
			get 
			{
				return this.InsAlmField;
			}			
			set
			{				
				this.InsAlmField = value;
			}
		}

		public SPS InsBlk
		{			
			get 
			{
				return this.InsBlkField;
			}			
			set
			{				
				this.InsBlkField = value;
			}
		}
		
		public SPS InsTr
		{			
			get 
			{
				return this.InsTrField;
			}			
			set
			{				
				this.InsTrField = value;
			}
		}

		public SPS PresAlm
		{			
			get 
			{
				return this.PresAlmField;
			}			
			set
			{				
				this.PresAlmField = value;
			}
		}
	
		public SPS DenAlm
		{			
			get 
			{
				return this.DenAlmField;
			}			
			set
			{				
				this.DenAlmField = value;
			}
		}

		public SPS TmpAlm
		{			
			get 
			{
				return this.TmpAlmField;
			}			
			set
			{				
				this.TmpAlmField = value;
			}
		}

		public SPS InsLevMax
		{			
			get 
			{
				return this.InsLevMaxField;
			}			
			set
			{				
				this.InsLevMaxField = value;
			}
		}

		public SPS InsLevMin
		{			
			get 
			{
				return this.InsLevMinField;
			}			
			set
			{				
				this.InsLevMinField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "SIML" (Insulation medium supervision (liquid)).
	/// </summary>		
	public class SIML : CommonLogicalNode
	{
		private DPL EENameField;
		private INS EEHealthField;
		private MV TmpField;
		private MV LevField;
		private MV PresField;
		private MV H2OField;
		private MV H2OTmpField;
		private MV H2Field;
		private SPS InsAlmField;
		private SPS InsBlkField;
		private SPS InsTrField;
		private SPS TmpAlmField;
		private SPS PresTrField;
		private SPS PresAlmField;
		private SPS GasInsAlmField;
		private SPS GasInsTrField;
		private SPS GasFlwTrField;
		private SPS InsLevMaxField;
		private SPS InsLevMinField;
		private SPS H2AlmField;
		private SPS MstAlmField;
		
		public SIML(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.SIML;
			this.iedType = iedType;
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.TmpField = new MV("Tmp", lnType, iedType); 
			this.LevField = new MV("Lev", lnType, iedType); 
			this.PresField = new MV("Pres", lnType, iedType);
			this.H2OField = new MV("H2O", lnType, iedType);
			this.H2OTmpField = new MV("H2OTmp", lnType, iedType);
			this.H2Field = new MV("H2", lnType, iedType);
			this.InsAlmField = new SPS("InsAlm", lnType, iedType); 
			this.InsBlkField = new SPS("InsBlk", lnType, iedType); 
			this.InsTrField = new SPS("InsTr", lnType, iedType);
			this.InsAlmField = new SPS("InsAlm", lnType, iedType); 
			this.PresTrField = new SPS("PresTr", lnType, iedType); 
			this.PresAlmField = new SPS("PresAlm", lnType, iedType);
			this.GasInsAlmField = new SPS("GasInsAlm", lnType, iedType); 
			this.GasInsTrField = new SPS("GasInsTr", lnType, iedType); 
			this.GasFlwTrField = new SPS ("GasFlwTr", lnType, iedType); 
			this.InsLevMaxField = new SPS("InsLevMax", lnType, iedType);
			this.InsLevMinField = new SPS("InsLevMin", lnType, iedType);
			this.H2AlmField = new SPS("H2Alm", lnType, iedType);
			this.MstAlmField = new SPS("MstAlm", lnType, iedType);
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public MV Tmp
		{			
			get 
			{
				return this.TmpField;
			}			
			set
			{				
				this.TmpField = value;
			}
		}

		public MV Lev
		{			
			get 
			{
				return this.LevField;
			}			
			set
			{				
				this.LevField = value;
			}
		}

		public MV Pres
		{			
			get 
			{
				return this.PresField;
			}			
			set
			{				
				this.PresField = value;
			}
		}

		public MV H2O
		{			
			get 
			{
				return this.H2OField;
			}			
			set
			{				
				this.H2OField = value;
			}
		}

		public MV H2OTmp
		{			
			get 
			{
				return this.H2OTmpField;
			}			
			set
			{				
				this.H2OTmpField = value;
			}
		}

		public MV H2
		{			
			get 
			{
				return this.H2Field;
			}			
			set
			{				
				this.H2Field = value;
			}
		}

		[Required]
		public SPS InsAlm
		{			
			get 
			{
				return this.InsAlmField;
			}			
			set
			{				
				this.InsAlmField = value;
			}
		}

		public SPS InsBlk
		{			
			get 
			{
				return this.InsBlkField;
			}			
			set
			{				
				this.InsBlkField = value;
			}
		}

		public SPS InsTr
		{			
			get 
			{
				return this.InsTrField;
			}			
			set
			{				
				this.InsTrField = value;
			}
		}
	
		public SPS TmpAlm
		{			
			get 
			{
				return this.TmpAlmField;
			}			
			set
			{				
				this.TmpAlmField = value;
			}
		}

		public SPS PresTr
		{			
			get 
			{
				return this.PresTrField;
			}			
			set
			{				
				this.PresTrField = value;
			}
		}

		public SPS PresAlm
		{			
			get 
			{
				return this.PresAlmField;
			}			
			set
			{				
				this.PresAlmField = value;
			}
		}
	
		public SPS GasInsAlm
		{			
			get 
			{
				return this.GasInsAlmField;
			}			
			set
			{				
				this.GasInsAlmField = value;
			}
		}

		public SPS GasInsTr
		{			
			get 
			{
				return this.GasInsTrField;
			}			
			set
			{				
				this.GasInsTrField = value;
			}
		}

		public SPS GasFlwTr
		{			
			get 
			{
				return this.GasFlwTrField;
			}			
			set
			{				
				this.GasFlwTrField = value;
			}
		}

		public SPS InsLevMax
		{			
			get 
			{
				return this.InsLevMaxField;
			}			
			set
			{				
				this.InsLevMaxField = value;
			}
		}

		public SPS InsLevMin
		{			
			get 
			{
				return this.InsLevMinField;
			}			
			set
			{				
				this.InsLevMinField = value;
			}
		}

		public SPS H2Alm
		{			
			get 
			{
				return this.H2AlmField;
			}			
			set
			{				
				this.H2AlmField = value;
			}
		}

		public SPS MstAlm
		{			
			get 
			{
				return this.MstAlmField;
			}			
			set
			{				
				this.MstAlmField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "SPDC" (Monitoring and diagnostics for partial discharges).
	/// </summary>		
	public class SPDC : CommonLogicalNode
	{
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpCntField;
		private MV AcuPaDschField;
		private SPS PaDschAlmField;
		
		public SPDC(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.SPDC;
			this.iedType = iedType;
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpCntField = new INS("OpCnt", lnType, iedType);
			this.AcuPaDschField = new MV("AcuPaDsch", lnType, iedType);
			this.PaDschAlmField = new SPS("PaDschAlm", lnType, iedType);			
		}
	
		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		[Required]
		public INS OpCnt
		{
			get
			{				
				return this.OpCntField;
			}
			set
			{
				this.OpCntField = value;
			}
		}
	
		public MV AcuPaDsch
		{
			get
			{				
				return this.AcuPaDschField;
			}
			set
			{
				this.AcuPaDschField = value;
			}
		}

		public SPS PaDschAlm
		{
			get
			{				
				return this.PaDschAlmField;
			}
			set
			{
				this.PaDschAlmField = value;
			}
		}		
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "TCTR" (Current transformer).
	/// </summary>		
	public class TCTR : CommonLogicalNode
	{
		private ASG ARtgField;
		private ASG HzRtgField;
		private ASG RatField;
		private ASG CorField;
		private ASG AngCorField;
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
		private SAV AmpField;
		
		public TCTR(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.TCTR;
			this.iedType = iedType;
			this.ARtgField = new ASG("ARtg", lnType, iedType);
			this.HzRtgField = new ASG("HzRtg", lnType, iedType);
			this.RatField = new ASG("Rat", lnType, iedType);
			this.CorField = new ASG ("Cor", lnType, iedType);
			this.AngCorField = new ASG("AngCor", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
			this.AmpField = new SAV("Amp", lnType, iedType);
		}

		public ASG ARtg
		{
			get 
			{
				return this.ARtgField;
			}			
			set
			{				
				this.ARtgField = value;
			}
		}

		public ASG HzRtg
		{
			get 
			{
				return this.HzRtgField;
			}			
			set
			{				
				this.HzRtgField = value;
			}
		}

		public ASG Rat
		{
			get 
			{
				return this.RatField;
			}			
			set
			{
				this.RatField = value;
			}
		}

		public ASG Cor
		{
			get 
			{
				return this.CorField;
			}			
			set
			{
				this.CorField = value;
			}
		}

		public ASG AngCor
		{
			get 
			{
				return this.AngCorField;
			}			
			set
			{
				this.AngCorField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}
	
		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}

		[Required]
		public SAV Amp
		{			
			get 
			{
				return this.AmpField;
			}			
			set
			{				
				this.AmpField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "TVTR" (Voltage transformer).
	/// </summary>		
	public class TVTR : CommonLogicalNode
	{
		private ASG VRtgField;
		private ASG HzRtgField;
		private ASG RatField;
		private ASG CorField;
		private ASG AngCorField;
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
		private SAV VolField;
		private SPS FuFailField;
		
		public TVTR(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.TVTR;
			this.iedType = iedType;
			this.VRtgField = new ASG("VRtg", lnType, iedType);
			this.HzRtgField = new ASG("HzRtg", lnType, iedType);
			this.RatField = new ASG("Rat", lnType, iedType);
			this.CorField = new ASG ("Cor", lnType, iedType);
			this.AngCorField = new ASG("AngCor", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
			this.VolField = new SAV("Vol", lnType, iedType);
			this.FuFailField = new SPS("FuFail", lnType, iedType);
		}

		public ASG VRtg
		{
			get 
			{
				return this.VRtgField;
			}			
			set
			{				
				this.VRtgField = value;
			}
		}

		public ASG HzRtg
		{
			get 
			{
				return this.HzRtgField;
			}			
			set
			{				
				this.HzRtgField = value;
			}
		}

		public ASG Rat
		{
			get 
			{
				return this.RatField;
			}			
			set
			{
				this.RatField = value;
			}
		}

		public ASG Cor
		{
			get 
			{
				return this.CorField;
			}			
			set
			{
				this.CorField = value;
			}
		}

		public ASG AngCor
		{
			get 
			{
				return this.AngCorField;
			}			
			set
			{
				this.AngCorField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}
	
		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}

		[Required]
		public SAV Vol
		{			
			get 
			{
				return this.VolField;
			}			
			set
			{				
				this.VolField = value;
			}
		}

		public SPS FuFail
		{			
			get 
			{
				return this.FuFailField;
			}			
			set
			{				
				this.FuFailField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "XCBR" (Circuit breaker).
	/// </summary>	
	public class XCBR : CommonLogicalNode
	{
		private BCR SumSwARsField;
		private DPC PosField;
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpCntField;
		private INS CBOpCapField;
		private INS POWCapField;
		private INS MaxOpCapField;
		private SPC BlkOpnField;
		private SPC BlkClsField;
		private SPC ChaMotEnaField;
		private SPS LocField;
		
		public XCBR(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.XCBR;
			this.iedType = iedType;
			this.SumSwARsField = new BCR("SumSwARs", lnType, iedType);
			this.PosField = new DPC("Pos", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpCntField = new INS("OpCnt", lnType, iedType);
			this.CBOpCapField = new INS("CBOpCap", lnType, iedType);
			this.POWCapField = new INS("POWCap", lnType, iedType);
			this.MaxOpCapField = new INS("MaxOpCap", lnType, iedType);
			this.BlkOpnField = new SPC("BlkOpn", lnType, iedType);
			this.BlkClsField = new SPC("BlkCls", lnType, iedType);
			this.ChaMotEnaField = new SPC("ChaMotEna", lnType, iedType);
			this.LocField = new SPS("Loc", lnType, iedType);
		}
	
		public BCR SumSwARs
		{
			get 
			{
				return this.SumSwARsField;
			}			
			set
			{				
				this.SumSwARsField = value;
			}
		}

		[Required]
		public DPC Pos
		{
			get 
			{
				return this.PosField;
			}			
			set
			{				
				this.PosField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		[Required]
		public INS OpCnt
		{
			get
			{				
				return this.OpCntField;
			}
			set
			{
				this.OpCntField = value;
			}
		}

		[Required]
		public INS CBOpCap
		{
			get
			{
				return this.CBOpCapField;
			}
			set
			{
				this.CBOpCapField = value;
			}
		}

		public INS POWCap
		{
			get
			{
				return this.POWCapField;
			}
			set
			{
				this.POWCapField = value;
			}
		}

		public INS MaxOpCap
		{
			get
			{
				return this.MaxOpCapField;
			}
			set
			{
				this.MaxOpCapField = value;
			}
		}

		[Required]
		public SPC BlkOpn
		{
			get
			{
				return this.BlkOpnField;
			}
			set
			{
				this.BlkOpnField = value;
			}
		}

		[Required]
		public SPC BlkCls
		{
			get
			{
				return this.BlkClsField;
			}
			set
			{
				this.BlkClsField = value;
			}
		}
	
		public SPC ChaMotEna
		{
			get
			{
				return this.ChaMotEnaField;
			}
			set
			{
				this.ChaMotEnaField = value;
			}
		}

		[Required]
		public SPS Loc
		{			
			get 
			{
				return this.LocField;
			}			
			set
			{				
				this.LocField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "XSWI" (Circuit switch).
	/// </summary>		
	public class XSWI : CommonLogicalNode
	{
		private DPC PosField;
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpCntField;
		private INS SwTypField;
		private INS SwOpCapField;
		private INS MaxOpCapField;
		private SPC BlkOpnField;
		private SPC BlkClsField;
		private SPC ChaMotEnaField;
		private SPS LocField;
		
		public XSWI(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.XSWI;
			this.iedType = iedType;
			this.PosField = new DPC("Pos", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpCntField = new INS("OpCnt", lnType, iedType);
			this.SwTypField = new INS("SwTyp", lnType, iedType);
			this.SwOpCapField = new INS("SwOpCap", lnType, iedType);
			this.MaxOpCapField = new INS("MaxOpCap", lnType, iedType);
			this.BlkOpnField = new SPC("BlkOpn", lnType, iedType);
			this.BlkClsField = new SPC("BlkCls", lnType, iedType);
			this.ChaMotEnaField = new SPC("ChaMotEna", lnType, iedType);
			this.LocField = new SPS("Loc", lnType, iedType);
		}

		[Required]
		public DPC Pos
		{
			get 
			{
				return this.PosField;
			}			
			set
			{				
				this.PosField = value;
			}
		}
	
		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		[Required]
		public INS OpCnt
		{
			get
			{				
				return this.OpCntField;
			}
			set
			{
				this.OpCntField = value;
			}
		}

		[Required]
		public INS SwTyp
		{
			get
			{				
				return this.SwTypField;
			}
			set
			{
				this.SwTypField = value;
			}
		}
	
		[Required]
		public INS SwOpCap
		{
			get
			{				
				return this.SwOpCapField;
			}
			set
			{
				this.SwOpCapField = value;
			}
		}

		public INS MaxOpCap
		{
			get
			{
				return this.MaxOpCapField;
			}
			set
			{
				this.MaxOpCapField = value;
			}
		}

		[Required]
		public SPC BlkOpn
		{
			get
			{
				return this.BlkOpnField;
			}
			set
			{
				this.BlkOpnField = value;
			}
		}

		[Required]
		public SPC BlkCls
		{
			get
			{
				return this.BlkClsField;
			}
			set
			{
				this.BlkClsField = value;
			}
		}

		public SPC ChaMotEna
		{
			get
			{
				return this.ChaMotEnaField;
			}
			set
			{
				this.ChaMotEnaField = value;
			}
		}

		[Required]
		public SPS Loc
		{			
			get 
			{
				return this.LocField;
			}			
			set
			{				
				this.LocField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "YEFN" (Earth fault neutralizer (Petersen coil)).
	/// </summary>		
	public class YEFN : CommonLogicalNode
	{
		private APC ColPosField;
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
		private ISC ColTapPosField;
		private MV ECAField;
		private SPS LocField;
		
		public YEFN(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.YEFN;
			this.iedType = iedType;
			this.ColPosField = new APC("ColPos", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
			this.ColTapPosField = new ISC("ColTapPos", lnType, iedType);
			this.ECAField = new MV("ECA", lnType, iedType);
			this.LocField = new SPS("Loc", lnType, iedType);
		}

		public APC ColPos
		{
			get 
			{
				return this.ColPosField;
			}			
			set
			{				
				this.ColPosField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}

		[Required]
		public ISC ColTapPos
		{			
			get 
			{
				return this.ColTapPosField;
			}			
			set
			{				
				this.ColTapPosField = value;
			}
		}

		[Required]
		public MV ECA
		{			
			get 
			{
				return this.ECAField;
			}			
			set
			{				
				this.ECAField = value;
			}
		}
	
		[Required]
		public SPS Loc
		{			
			get 
			{
				return this.LocField;
			}		
			set
			{				
				this.LocField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "YLTC" (Tap changer).
	/// </summary>		
	public class YLTC : CommonLogicalNode
	{
		private BSC TapChgField;
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpCntField;
		private ISC TapPosField;
		private MV TorqField;
		private MV MotDrvAField;
		private SPS EndPosRField;
		private SPS EndPosLField;
		private SPS OilFilField;
		
		public YLTC(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.YLTC;
			this.iedType = iedType;
			this.TapChgField = new BSC("TapChg", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpCntField = new INS("OpCnt", lnType, iedType);
			this.TapPosField = new ISC("TapPos", lnType, iedType);
			this.TorqField = new MV("Torq", lnType, iedType);
			this.MotDrvAField = new MV("MotDrvA", lnType, iedType);
			this.EndPosRField = new SPS("EndPosR", lnType, iedType);
			this.EndPosLField = new SPS("EndPosL", lnType, iedType);
			this.OilFilField = new SPS("OilFil", lnType, iedType);
		}
	
		public BSC TapChg
		{			
			get 
			{
				return this.TapChgField;
			}			
			set
			{				
				this.TapChgField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}
	
		public INS OpCnt
		{
			get
			{				
				return this.OpCntField;
			}
			set
			{
				this.OpCntField = value;
			}
		}

		public ISC TapPos
		{			
			get 
			{
				return this.TapPosField;
			}			
			set
			{				
				this.TapPosField = value;
			}
		}

		public MV Torq
		{			
			get 
			{
				return this.TorqField;
			}			
			set
			{				
				this.TorqField = value;
			}
		}
	
		public MV MotDrvA
		{			
			get 
			{
				return this.MotDrvAField;
			}			
			set
			{				
				this.MotDrvAField = value;
			}
		}

		[Required]
		public SPS EndPosR
		{			
			get 
			{
				return this.EndPosRField;
			}			
			set
			{				
				this.EndPosRField = value;
			}
		}
	
		[Required]
		public SPS EndPosL
		{			
			get 
			{
				return this.EndPosLField;
			}			
			set
			{				
				this.EndPosLField = value;
			}
		}
	
		public SPS OilFil
		{			
			get 
			{
				return this.OilFilField;
			}			
			set
			{				
				this.OilFilField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "YPSH" (Power shunt).
	/// </summary>		
	public class YPSH : CommonLogicalNode
	{
		private DPC PosField;
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
		private INS ShOpCapField;
		private INS MaxOpCapField;
		private SPC BlkOpnField;
		private SPC BlkClsField;
		private SPC ChaMotEnaField;
		
		public YPSH(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.YPSH;
			this.iedType = iedType;
			this.PosField = new DPC("Pos", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
			this.ShOpCapField = new INS("ShOpCap", lnType, iedType);
			this.MaxOpCapField = new INS("MaxOpCap", lnType, iedType);
			this.BlkOpnField = new SPC("BlkOpn", lnType, iedType);
			this.BlkClsField = new SPC("BlkCls", lnType, iedType);
			this.ChaMotEnaField = new SPC("ChaMotEna", lnType, iedType);			
		}

		[Required]
		public DPC Pos
		{
			get 
			{
				return this.PosField;
			}			
			set
			{				
				this.PosField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}

		[Required]
		public INS ShOpCap
		{			
			get 
			{
				return this.ShOpCapField;
			}			
			set
			{				
				this.ShOpCapField = value;
			}
		}

		public INS MaxOpCap
		{
			get
			{
				return this.MaxOpCapField;
			}
			set
			{
				this.MaxOpCapField = value;
			}
		}

		[Required]
		public SPC BlkOpn
		{
			get
			{
				return this.BlkOpnField;
			}
			set
			{
				this.BlkOpnField = value;
			}
		}

		[Required]
		public SPC BlkCls
		{
			get
			{
				return this.BlkClsField;
			}
			set
			{
				this.BlkClsField = value;
			}
		}

		public SPC ChaMotEna
		{
			get
			{
				return this.ChaMotEnaField;
			}
			set
			{
				this.ChaMotEnaField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "YPTR" (Power transformer).
	/// </summary>		
	public class YPTR : CommonLogicalNode
	{
		private ASG HiVRtgField;
		private ASG LoVRtgField;
		private ASG PwrRtgField;
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
		private MV HPTmpField;
		private SPS HPTmpAlmField;
		private SPS HPTmpTrField;
		private SPS OANLField;
		private SPS OpOvAField;
		private SPS OpOvVField;
		private SPS OpUnVField;
		private SPS CGAlmField;	
	
		public YPTR(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.YPTR;
			this.iedType = iedType;
			this.HiVRtgField = new ASG("HiVRtg", lnType, iedType);
			this.LoVRtgField = new ASG("LoVRtg", lnType, iedType); 
			this.PwrRtgField = new ASG("PwrRtg", lnType, iedType); 
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
			this.HPTmpField = new MV("HPTmp", lnType, iedType); 
			this.HPTmpAlmField = new SPS("HPTmpAlm", lnType, iedType);
			this.HPTmpTrField = new SPS("HPTmpTr", lnType, iedType);
			this.OANLField = new SPS("OANL", lnType, iedType);
			this.OpOvAField = new SPS("OpOvA", lnType, iedType);
			this.OpOvVField = new SPS("OpOvV", lnType, iedType);
			this.OpUnVField = new SPS("OpUnV", lnType, iedType);
			this.CGAlmField = new SPS("CGAlm", lnType, iedType);
		}

		public ASG HiVRtg
		{
			get
			{
				return this.HiVRtgField;
			}
			set
			{
				this.HiVRtgField = value;
			}
		}

		public ASG LoVRtg
		{
			get
			{
				return this.LoVRtgField;
			}
			set
			{
				this.LoVRtgField = value;
			}
		}

		public ASG PwrRtg
		{
			get
			{
				return this.PwrRtgField;
			}
			set
			{
				this.PwrRtgField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}

		public MV HPTmp
		{			
			get 
			{
				return this.HPTmpField;
			}			
			set
			{				
				this.HPTmpField = value;
			}
		}
	
		public SPS HPTmpAlm
		{			
			get 
			{
				return this.HPTmpAlmField;
			}			
			set
			{				
				this.HPTmpAlmField = value;
			}
		}
	
		public SPS HPTmpTr
		{			
			get 
			{
				return this.HPTmpTrField;
			}			
			set
			{				
				this.HPTmpTrField = value;
			}
		}

		public SPS OANL
		{			
			get 
			{
				return this.OANLField;
			}			
			set
			{				
				this.OANLField = value;
			}
		}

		public SPS OpOvA
		{			
			get 
			{
				return this.OpOvAField;
			}			
			set
			{				
				this.OpOvAField = value;
			}
		}

		public SPS OpOvV
		{			
			get 
			{
				return this.OpOvVField;
			}			
			set
			{				
				this.OpOvVField = value;
			}
		}

		public SPS OpUnV
		{			
			get 
			{
				return this.OpUnVField;
			}			
			set
			{				
				this.OpUnVField = value;
			}
		}

		public SPS CGAlm
		{			
			get 
			{
				return this.CGAlmField;
			}			
			set
			{				
				this.CGAlmField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ZAXN" (Auxiliary network).
	/// </summary>		
	public class ZAXN : CommonLogicalNode
	{
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
		private MV VolField;
		private MV AmpField;
		
		public ZAXN(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.ZAXN;
			this.iedType = iedType;
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
			this.VolField = new MV("Vol", lnType, iedType);
			this.AmpField = new MV("Amp", lnType, iedType);
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}

		public MV Vol
		{			
			get 
			{
				return this.VolField;
			}			
			set
			{				
				this.VolField = value;
			}
		}

		public MV Amp
		{			
			get 
			{
				return this.AmpField;
			}			
			set
			{				
				this.AmpField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ZBAT" (Battery).
	/// </summary>	
	public class ZBAT : CommonLogicalNode
	{
		private ASG LoBatValField;
		private ASG HiBatValField;
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
		private MV VolField;
		private MV VolChgRteField;
		private MV AmpField;
		private SPC BatTestField;
		private SPS TestRslField;
		private SPS BatHiField;
		private SPS BatLoField;
	
		public ZBAT(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;			
			this.lnClass = tLNClassEnum.ZBAT;
			this.iedType = iedType;			
			this.LoBatValField = new ASG("LoBatVal", lnType, iedType);
			this.HiBatValField = new ASG("HiBatVal", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
			this.VolField = new MV("Vol", lnType, iedType);
			this.VolChgRteField = new MV("VolChgRte", lnType, iedType);
			this.AmpField = new MV("Amp", lnType, iedType);
			this.BatTestField = new SPC("BatTest", lnType, iedType);
			this.TestRslField = new SPS("TestRsl", lnType, iedType);
			this.BatHiField = new SPS("BatHi", lnType, iedType);
			this.BatLoField = new SPS("BatLo", lnType, iedType);			                          
		}

		public ASG LoBatVal
		{			
			get 
			{
				return this.LoBatValField;
			}			
			set
			{				
				this.LoBatValField = value;
			}
		}

		public ASG HiBatVal
		{			
			get 
			{
				return this.HiBatValField;
			}			
			set
			{				
				this.HiBatValField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}

		[Required]
		public MV Vol
		{			
			get 
			{
				return this.VolField;
			}			
			set
			{				
				this.VolField = value;
			}
		}

		public MV VolChgRte
		{			
			get 
			{
				return this.VolChgRteField;
			}			
			set
			{				
				this.VolChgRteField  = value;
			}
		}
	
		public MV Amp
		{			
			get 
			{
				return this.AmpField;
			}			
			set
			{				
				this.AmpField = value;
			}
		}
	
		public SPC BatTest
		{			
			get 
			{
				return this.BatTestField;
			}			
			set
			{				
				this.BatTestField = value;
			}
		}
	
		public SPS TestRsl
		{			
			get 
			{
				return this.TestRslField;
			}			
			set
			{				
				this.TestRslField = value;
			}
		}

		public SPS BatHi
		{			
			get 
			{
				return this.BatHiField;
			}			
			set
			{				
				this.BatHiField = value;
			}
		}

		public SPS BatLo
		{			
			get 
			{
				return this.BatLoField;
			}			
			set
			{				
				this.BatLoField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ZBSH" (Bushing).
	/// </summary>		
	public class ZBSH : CommonLogicalNode
	{
		private ASG RefReactField;
		private ASG RefPFField;
		private ASG RefVField;
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
		private MV ReactField;
		private MV LosFactField;
		private MV VolField;

		public ZBSH(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.ZBSH;
			this.iedType = iedType;			
			this.RefReactField = new ASG("RefReact", lnType, iedType);
			this.RefPFField = new ASG("RefPF", lnType, iedType);
			this.RefVField = new ASG("RefV", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
			this.ReactField = new MV("React", lnType, iedType);
			this.LosFactField = new MV("LosFact", lnType, iedType);
			this.VolField = new MV("Vol", lnType, iedType);
		}

		public ASG RefReact
		{			
			get 
			{
				return this.RefReactField;
			}			
			set
			{				
				this.RefReactField = value;
			}
		}

		public ASG RefPF
		{			
			get 
			{
				return this.RefPFField;
			}			
			set
			{				
				this.RefPFField = value;
			}
		}

		public ASG RefV
		{			
			get 
			{
				return this.RefVField;
			}			
			set
			{				
				this.RefVField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}
	
		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}
	
		[Required]
		public MV React
		{			
			get 
			{
				return this.ReactField;
			}			
			set
			{				
				this.ReactField = value;
			}
		}

		public MV LosFact
		{			
			get 
			{
				return this.LosFactField;
			}			
			set
			{				
				this.LosFactField = value;
			}
		}

		public MV Vol
		{			
			get 
			{
				return this.VolField;
			}			
			set
			{				
				this.VolField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ZCAB" (Power cable).
	/// </summary>		
	public class ZCAB : CommonLogicalNode
	{
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
	
		public ZCAB(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.ZCAB;
			this.iedType = iedType;			
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ZCAP" (Capacitor bank).
	/// </summary>		
	public class ZCAP : CommonLogicalNode
	{
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
		private SPC CapDSField;
		private SPS DschBlkField;
	
		public ZCAP(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.ZCAP;
			this.iedType = iedType;			
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
			this.CapDSField = new SPC("CapDS", lnType, iedType);
			this.DschBlkField = new SPS("DschBlk", lnType, iedType);
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}

		[Required]
		public SPC CapDS
		{			
			get 
			{
				return this.CapDSField;
			}			
			set
			{				
				this.CapDSField = value;
			}
		}

		[Required]
		public SPS DschBlk
		{			
			get 
			{
				return this.DschBlkField;
			}			
			set
			{				
				this.DschBlkField = value;
			}
		}
	}	

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ZCON" (Converter).
	/// </summary>		
	public class ZCON : CommonLogicalNode
	{
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
	
		public ZCON(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.ZCON;
			this.iedType = iedType;			
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
		}
	
		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ZGEN" (Generator).
	/// </summary>		
	public class ZGEN : CommonLogicalNode
	{
		private ASG DmdPwrField;
		private ASG PwrRtgField;
		private ASG VRtgField;
		private DPC GnCtlField;
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
		private INS GnStField;
		private MV GnSpdField;
		private SPC DExtField;
		private SPC AuxSCOField;
		private SPC StopVlvField;
		private SPC ReactPwrRField;
		private SPC ReactPwrLField;
		private SPS OANLField;
		private SPS ClkRotField;
		private SPS CntClkRotField;
		private SPS OpUnExtField;
		private SPS OpOvExtField;
		private SPS LosOilField;
		private SPS LosVacField;	
		private SPS PresAlmField;
	
		public ZGEN(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.ZGEN;
			this.iedType = iedType;			
			this.DmdPwrField = new ASG("DmdPwr", lnType, iedType);
			this.PwrRtgField = new ASG("PwrRtg", lnType, iedType);
			this.VRtgField = new ASG("VRtg", lnType, iedType);
			this.GnCtlField = new DPC("GnCtl", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
			this.GnStField = new INS("GnSt", lnType, iedType);
			this.GnSpdField = new MV("GnSpd", lnType, iedType);
			this.DExtField = new SPC("DExt", lnType, iedType);
			this.AuxSCOField = new SPC("AuxSCO", lnType, iedType);
			this.StopVlvField = new SPC("StopVlv", lnType, iedType);
			this.ReactPwrRField = new SPC("ReactPwrR", lnType, iedType);
			this.ReactPwrLField = new SPC("ReactPwrL", lnType, iedType);
			this.OANLField = new SPS("OANL", lnType, iedType);
			this.ClkRotField = new SPS("ClkRot", lnType, iedType);
			this.CntClkRotField = new SPS("CntClkRot", lnType, iedType);
			this.OpUnExtField = new SPS("OpUnExt", lnType, iedType);
			this.OpOvExtField = new SPS("OpOvExt", lnType, iedType);
			this.LosOilField = new SPS("LosOil", lnType, iedType);
			this.LosVacField = new SPS("LosVac", lnType, iedType);
			this.PresAlmField = new SPS("PresAlm", lnType, iedType);
		}
	
		public ASG DmdPwr
		{			
			get 
			{
				return this.DmdPwrField;
			}			
			set
			{				
				this.DmdPwrField = value;
			}
		}

		public ASG PwrRtg
		{			
			get 
			{
				return this.PwrRtgField;
			}			
			set
			{				
				this.PwrRtgField = value;
			}
		}
	
		public ASG VRtg
		{			
			get 
			{
				return this.VRtgField;
			}			
			set
			{				
				this.VRtgField = value;
			}
		}

		[Required]
		public DPC GnCtl
		{			
			get 
			{
				return this.GnCtlField;
			}			
			set
			{				
				this.GnCtlField = value;
			}
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}

		[Required]
		public INS GnSt
		{			
			get 
			{
				return this.GnStField;
			}			
			set
			{				
				this.GnStField = value;
			}
		}

		public MV GnSpd
		{			
			get 
			{
				return this.GnSpdField;
			}			
			set
			{				
				this.GnSpdField = value;
			}
		}

		[Required]
		public SPC DExt
		{			
			get 
			{
				return this.DExtField;
			}			
			set
			{				
				this.DExtField = value;
			}
		}

		public SPC AuxSCO
		{			
			get 
			{
				return this.AuxSCOField;
			}			
			set
			{										
				this.AuxSCOField = value;
			}
		}

		public SPC StopVlv
		{			
			get 
			{
				return this.StopVlvField;
			}			
			set
			{										
				this.StopVlvField = value;
			}
		}

		public SPC ReactPwrR
		{			
			get 
			{
				return this.ReactPwrRField;
			}			
			set
			{										
				this.ReactPwrRField = value;
			}
		}

		public SPC ReactPwrL
		{			
			get 
			{
				return this.ReactPwrLField;
			}			
			set
			{										
				this.ReactPwrLField = value;
			}
		}

		[Required]
		public SPS OANL
		{			
			get 
			{
				return this.OANLField;
			}			
			set
			{										
				this.OANLField = value;
			}
		}

		[Required]
		public SPS ClkRot
		{			
			get 
			{
				return this.ClkRotField;
			}			
			set
			{										
				this.ClkRotField = value;
			}
		}

		[Required]
		public SPS CntClkRot
		{			
			get 
			{
				return this.CntClkRotField;
			}			
			set
			{										
				this.CntClkRotField = value;
			}
		}

		[Required]
		public SPS OpUnExt
		{			
			get 
			{
				return this.OpUnExtField;
			}			
			set
			{										
				this.OpUnExtField = value;
			}
		}

		[Required]
		public SPS OpOvExt
		{			
			get 
			{
				return this.OpOvExtField;
			}			
			set
			{										
				this.OpOvExtField = value;
			}
		}

		public SPS LosOil
		{			
			get 
			{
				return this.LosOilField;
			}			
			set
			{										
				this.LosOilField = value;
			}
		}

		public SPS LosVac
		{			
			get 
			{
				return this.LosVacField;
			}			
			set
			{										
				this.LosVacField = value;
			}
		}
	
		public SPS PresAlm
		{			
			get 
			{
				return this.PresAlmField;
			}			
			set
			{										
				this.PresAlmField = value;
			}
		}
	}	

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ZGIL" (Gas insulated line).
	/// </summary>		
	public class ZGIL : CommonLogicalNode
	{
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
	
		public ZGIL(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.ZGIL;
			this.iedType = iedType;		
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}
	
		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ZLIN" (Power overhead line).
	/// </summary>		
	public class ZLIN : CommonLogicalNode
	{
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;

		public ZLIN(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.ZLIN;
			this.iedType = iedType;			
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
		}
		
		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}
	
		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ZMOT" (Motor).
	/// </summary>	
	public class ZMOT : CommonLogicalNode
	{
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
		private SPC DExtField;
		private SPS LosOilField;
		private SPS LosVacField;	
		private SPS PresAlmField;

		public ZMOT(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.ZMOT;
			this.iedType = iedType;			
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);			
			this.DExtField = new SPC("DExt", lnType, iedType);
			this.LosOilField = new SPS("LosOil", lnType, iedType);
			this.LosVacField = new SPS("LosVac", lnType, iedType);
			this.PresAlmField = new SPS("PresAlm", lnType, iedType);
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}
	
		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}

		[Required]
		public SPC DExt
		{			
			get 
			{
				return this.DExtField;
			}			
			set
			{				
				this.DExtField = value;
			}
		}

		public SPS LosOil
		{			
			get 
			{
				return this.LosOilField;
			}			
			set
			{										
				this.LosOilField = value;
			}
		}

		public SPS LosVac
		{			
			get 
			{
				return this.LosVacField;
			}			
			set
			{										
				this.LosVacField = value;
			}
		}

		public SPS PresAlm
		{			
			get 
			{
				return this.PresAlmField;
			}			
			set
			{										
				this.PresAlmField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ZREA" (Reactor).
	/// </summary>		
	public class ZREA : CommonLogicalNode
	{
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
	
		public ZREA(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.ZREA;
			this.iedType = iedType;			
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
		}
	
		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}
	
		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ZRRC" (Rotating reactive component).
	/// </summary>		
	public class ZRRC : CommonLogicalNode
	{
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;

		public ZRRC(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.ZRRC;
			this.iedType = iedType;			
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ZSAR" (Surge arrestor).
	/// </summary>		
	public class ZSAR : CommonLogicalNode
	{
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
		private SPS OPSAField;
	
		public ZSAR(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.ZSAR;
			this.iedType = iedType;			
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
			this.OPSAField = new SPS("OPSA", lnType, iedType);
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}
	
		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}

		[Required]
		public SPS OPSA
		{			
			get 
			{
				return this.OPSAField;
			}			
			set
			{				
				this.OPSAField = value;
			}
		}
	}

	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ZTCF" (Thyristor controlled frequency converter).
	/// </summary>		
	public class ZTCF : CommonLogicalNode
	{
		private ASG PwrFrqField;
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;

		public ZTCF(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.ZTCF;
			this.iedType = iedType;			
			this.PwrFrqField = new ASG("PwrFrq", lnType, iedType);
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
		}

		public ASG PwrFrq
		{			
			get 
			{
				return this.PwrFrqField;
			}			
			set
			{	
				this.PwrFrqField = value;
			}
		}
	
		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}
	}
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the LN 
	/// class "ZTCR" (Thyristor controlled reactive component).
	/// </summary>	
	public class ZTCR : CommonLogicalNode
	{
		private DPL EENameField;
		private INS EEHealthField;
		private INS OpTmhField;
	
		public ZTCR(string lnType, string iedType) : base(lnType, iedType)
		{
			this.id = lnType;
			this.lnClass = tLNClassEnum.ZTCR;
			this.iedType = iedType;
			this.EENameField = new DPL("EEName", lnType, iedType);
			this.EEHealthField = new INS("EEHealth", lnType, iedType);
			this.OpTmhField = new INS("OpTmh", lnType, iedType);
		}

		public DPL EEName
		{			
			get 
			{
				return this.EENameField;
			}			
			set
			{	
				this.EENameField = value;
			}
		}

		public INS EEHealth
		{			
			get 
			{
				return this.EEHealthField;
			}			
			set
			{				
				this.EEHealthField = value;
			}
		}

		public INS OpTmh
		{			
			get 
			{
				return this.OpTmhField;
			}			
			set
			{				
				this.OpTmhField = value;
			}
		}
	}
}