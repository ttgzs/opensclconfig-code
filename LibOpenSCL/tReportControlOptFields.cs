// 
//  tReportControlOptFields.cs
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
	 * The attributes bufOvfl and segmentation were added to fullfill the standard IEC61850-6 Ed.1.0. 
	 * This attributes were also added on the SCL_IED.xsd file because these attributes doesn't exist 
	 * on this file although they are indicated on the standard.
	 */ 
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tReportControlOptFields 
	{		
		private bool seqNumField;		
		private bool timeStampField;		
		private bool dataSetField;		
		private bool reasonCodeField;		
		private bool dataRefField;		
		private bool entryIDField;		
		private bool configRefField;
		private bool bufOvflField;
		private bool segmentationField;
		
		public tReportControlOptFields() 
		{
			this.seqNumField = false;
			this.timeStampField = false;
			this.dataSetField = false;
			this.reasonCodeField = false;
			this.dataRefField = false;
			this.entryIDField = false;
			this.configRefField = false;
			this.bufOvflField = false;
			this.segmentationField = false;
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Current sequence number of the reports.")]
		public bool seqNum 
		{
			get 
			{
				return this.seqNumField;
			}
			set 
			{
				this.seqNumField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Represent a UTC time with the epoch of midnight (00:00:00) of "+
			"1970-01-01.")]
		public bool timeStamp 
		{
			get 
			{
				return this.timeStampField;
			}
			set
			{
				this.timeStampField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Identifies a DATA-SET that is contained in the LN.")]
		public bool dataSet 
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
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Reason for inclusion in the report")]
		public bool reasonCode
		{
			get
			{
				return this.reasonCodeField;
			}
			set
			{
				this.reasonCodeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Data Object Reference")]
		public bool dataRef 
		{
			get 
			{
				return this.dataRefField;
			}
			set
			{
				this.dataRefField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Used to identify an entry in a sequence of events such as a log or a buffered report.")]
		public bool entryID 
		{
			get
			{
				return this.entryIDField;
			}
			set 
			{
				this.entryIDField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Configuration reference.")]
		public bool configRef 
		{
			get
			{
				return this.configRefField;
			}
			set 
			{
				this.configRefField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Configuration reference.")]
		public bool bufOvfl 
		{
			get
			{
				return this.bufOvflField;
			}
			set 
			{
				this.bufOvflField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]
		[Category("ReportControlOptFields"), Description("Configuration reference.")]
		public bool segmentation 
		{
			get
			{
				return this.segmentationField;
			}
			set 
			{			
				this.segmentationField = value;
			}
		}
	}

	
}

