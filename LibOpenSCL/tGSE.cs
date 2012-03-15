// 
//  tGSE.cs
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
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tGSE : tControlBlock 
	{		
		private tDurationInMilliSec minTimeField;		
		private tDurationInMilliSec maxTimeField;
		
		[Category("GSE"), 
		 Description("The maximal allowed sending delay on a data change in ms."),  
		 ReadOnlyAttribute(true)]
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
		 ReadOnlyAttribute(true)]
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
		
		public void InitAddess ()
		{
			if (Address == null)
				this.Address = new tAddress ();
			
			this.Address.P = new tP[4];
			var appid = new tP_APPID ();
			appid.Value = "0x0000";
			this.Address.P[0] = appid;
			var mac = new tP_MACAddress ();
			mac.Value = "01:0c:cd:01:00:00";
			this.Address.P[1] = mac;
			var vlanid = new tP_VLANID ();
			vlanid.Value = "0";
			this.Address.P[2] = vlanid;
			var vlanp = new tP_VLANPRIORITY ();
			vlanp.Value = "4";
			this.Address.P[3] = vlanp;
		}
	}

}

