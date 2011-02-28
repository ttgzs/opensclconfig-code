// 
//  tAnyLN.cs
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
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLN0))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLN))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tAnyLN : tUnNaming 
	{		
		private tDataSet[] dataSetField;		
		private tReportControl[] reportControlField;		
		private tLogControl[] logControlField;		
		private tDOI[] dOIField;		
		private tInputs inputsField;		
		private string lnTypeField;
		
		[System.Xml.Serialization.XmlElementAttribute("DataSet")]
		[Category("LN"), Browsable(false)]
		public tDataSet[] DataSet 
		{
			get 
			{
				return this.dataSetField;
			}
			set
			{
				this.dataSetField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("ReportControl")]
		[Category("LN"), Browsable(false)]
		public tReportControl[] ReportControl 
		{
			get 
			{
				return this.reportControlField;
			}
			set 
			{
				this.reportControlField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("LogControl")]
		[Category("LN"), Browsable(false)]
		public tLogControl[] LogControl 
		{
			get 
			{
				return this.logControlField;
			}
			set 
			{
				this.logControlField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("DOI")]
		[Category("LN"), Browsable(false)]
		public tDOI[] DOI 
		{
			get 
			{
				return this.dOIField;
			}
			set 
			{
				this.dOIField = value;
			}
		}
		
		[Category("LN"), Description("Input"), Browsable(false)]
		public tInputs Inputs
		{
			get
			{
				return this.inputsField;
			}
			set 
			{
				this.inputsField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LN"), Description("The instantiable type definition of this logical node.")]
		public string lnType
		{
			get 
			{
				return this.lnTypeField;
			}
			set 
			{
				this.lnTypeField = value;
			}
		}
		
		public int AddDataSet (tDataSet ds) {
			int index = -1;
			if (this.dataSetField != null) {
				System.Array.Resize<tDataSet>(ref this.dataSetField,
				                                 this.dataSetField.Length + 1);
				
				index = this.dataSetField.Length - 1;
			}
			else {
				this.dataSetField = new tDataSet[1];
				index = 0;
			}
			this.dataSetField[index] = ds;
			return index;
		}
	}

}

