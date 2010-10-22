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

}

