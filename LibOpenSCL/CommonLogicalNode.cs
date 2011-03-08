// 
//  CommonLogicalNode.cs
//  
//  Authors:
//       Comision Federal de Electricidad
//       Daniel Espinosa <esodan@gmail.com>
//  
//  Copyright (c) 2009 Comision Federal de Electricidad
//  Copyright (c) 2011 Daniel Espinosa
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
namespace IEC61850.SCL
{
	
	/// <summary>
	/// This class defines the logical node attributes that are defined for his use in the 
	/// Common Logical Node.
	/// </summary>
	public class CommonLogicalNode : tLN
	{				
		// FIXME: CommonLogicalNode must inherit from tLN
		// FIXME: These properties are for GUI not for OpenSCL library
		public bool CheckSelection = false;
		public bool Visible = true;
		
		// FIXME: Must not be used or reimplemented
		public string iedType;
		
		//public string lnType;
		
		private INC ModField;	
		private INS BehField;		
		private INS HealthField;
		private LPL NamPltField;
		
		private void Init() {
			this.ModField = new INC("Mod", lnType, iedType);
		  	this.BehField = new INS("Beh", lnType, iedType);
			this.HealthField = new INS("Health",  lnType, iedType);
			this.NamPltField = new LPL("NamPlt",  lnType, iedType);
		}
				
		public CommonLogicalNode(string lnType, string iedType)
		{	
			this.Init();
			this.lnType = lnType;			
		}
		
		public CommonLogicalNode(string lnType, string iedType, string lnClass) 
			: base (iedType, lnClass, lnType)
		{	
			this.Init();
			this.lnType = lnType;
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
	}
	
}

