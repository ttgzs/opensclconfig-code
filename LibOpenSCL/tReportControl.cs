// 
//  tReportControl.cs
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
	
	/* 
	 * According to IEC 61850 Ed. 1.0 standard, there are some mandatory attributes, the 
	 * indication of this was developed using a validation's attribute "[Required]"
	*/	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tReportControl : tControlWithTriggerOpt 
	{		
		private tReportControlOptFields optFieldsField;		
		private tRptEnabled rptEnabledField;		
		private string rptIDField;		
		private uint confRevField;		
		private bool bufferedField;		
		private uint bufTimeField;
		
		public tReportControl() 
		{
			this.confRevField = ((uint)(0));
			this.bufferedField = false;
			this.bufTimeField = ((uint)(0));			
		}
		
		[Category("ReportControl"), Description("optional fields to include in report."),
		 Browsable(false)]
		public tReportControlOptFields OptFields
		{
			get 
			{
				return this.optFieldsField;
			}
			set 
			{
				this.optFieldsField = value;
			}
		}
		
		[Category("ReportControl"), Description("Contains the list of client LNs for which this report shall be enabled."),
		 Browsable(false)]
		public tRptEnabled RptEnabled 
		{
			get
			{
				return this.rptEnabledField;
			}
			set 
			{
				this.rptEnabledField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("ReportControl"), Description("Identifier for the report control block.")]
		public string rptID
		{
			get 
			{
				return this.rptIDField;
			}
			set 
			{
				this.rptIDField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControl"), Description("The configuration revision number of this report control block.")]
		public uint confRev 
		{
			get
			{
				return this.confRevField;
			}
			set 
			{
				this.confRevField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControl"), Description("Specifies if reports are buffered or no."), DefaultValue(false) ]
		public bool buffered 
		{
			get
			{
				return this.bufferedField;
			}
			set
			{
				this.bufferedField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControl"), Description("Buffer time.")]
		public uint bufTime 
		{
			get 
			{
				return this.bufTimeField;
			}
			set
			{
				this.bufTimeField = value;
			}
		}
	}


}

