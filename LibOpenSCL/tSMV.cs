// 
//  tSMV.cs
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
	public partial class tSMV : tControlBlock 
	{
		//se agregan estas propiedades por q no se pueden acceder a ellas debido a la herencia
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		private string ldInstField;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		private tLDevice tLDevice;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		private string cbNameField;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		private tSampledValueControl tSampledValueControl;
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ControlBlock"), Description("The name of the control block within the LLN0 of the LD ldInst."), ReadOnlyAttribute(true)]		
		public string cbName
		{
			get 
			{
				if(this.tSampledValueControl != null)
				{
					return this.tSampledValueControl.name;
				}
				return this.cbNameField;
			}
			set
			{
				if(this.tSampledValueControl != null)
				{
					this.tSampledValueControl.name = this.cbNameField = value;
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
	}


}

