// 
//  tServices.cs
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
	public partial class tServices 
	{		
		private tServiceYesNo dynAssociationField;		
		private tServicesSettingGroups settingGroupsField;		
		private tServiceYesNo getDirectoryField;	
		private tServiceYesNo getDataObjectDefinitionField;
		private tServiceYesNo dataObjectDirectoryField;		
		private tServiceYesNo getDataSetValueField;		
		private tServiceYesNo setDataSetValueField;		
		private tServiceYesNo dataSetDirectoryField;		
		private tServiceWithMaxAndMaxAttributesAndModify confDataSetField;		
		private tServiceWithMaxAndMaxAttributes dynDataSetField;		
		private tServiceYesNo readWriteField;		
		private tServiceYesNo timerActivatedControlField;		
		private tServiceWithMax confReportControlField;		
		private tServiceYesNo getCBValuesField;		
		private tServiceWithMax confLogControlField;		
		private tReportSettings reportSettingsField;		
		private tLogSettings logSettingsField;		
		private tGSESettings gSESettingsField;		
		private tSMVSettings sMVSettingsField;		
		private tServiceYesNo gSEDirField;		
		private tServiceWithMaxAndClient gOOSEField;		
		private tServiceWithMaxAndClient gSSEField;		
		private tServiceYesNo fileHandlingField;		
		private tConfLNs confLNsField;		
		
		[Category("Services"), Description("All services for dynamic building of associations.")]
		public tServiceYesNo DynAssociation 
		{
			get 
			{
				return this.dynAssociationField;
			}
			set 
			{
				this.dynAssociationField = value;
			}
		}
		
		[Category("Services"), Description("Setting group services belong to the setting group control block.")]
		public tServicesSettingGroups SettingGroups
		{
			get 
			{
				return this.settingGroupsField;
			}
			set 
			{
				this.settingGroupsField = value;
			}
		}
		
		[Category("Services"), Description("Service for reading the contents of a server, that is the LD and LN directories.")]
		public tServiceYesNo GetDirectory 
		{
			get 
			{
				return this.getDirectoryField;
			}
			set 
			{
				this.getDirectoryField = value;
			}
		}
		
		[Category("Services"), Description("Service to retrieve the complete list of all DA definitions of the referenced data that are"+
			" visible and thus accessible to the requesting client by the referenced LN.")]
		public tServiceYesNo GetDataObjectDefinition 
		{
			get 
			{
				return this.getDataObjectDefinitionField;
			}
			set 
			{
				this.getDataObjectDefinitionField = value;
			}
		}
		
		[Category("Services"), Description("Service to get the DATA defined in a LN.")]
		public tServiceYesNo DataObjectDirectory 
		{
			get 
			{
				return this.dataObjectDirectoryField;
			}
			set 
			{
				this.dataObjectDirectoryField = value;
			}
		}
		
		[Category("Services"), Description("Service to retrieve all values of data referenced by the members of the data set.")]
		public tServiceYesNo GetDataSetValue 
		{
			get 
			{
				return this.getDataSetValueField;
			}
			set 
			{
				this.getDataSetValueField = value;
			}
		}
		
		[Category("Services"), Description("Service to write all values of data referenced by the members of the data set.")]
		public tServiceYesNo SetDataSetValue 
		{
			get 
			{
				return this.setDataSetValueField;
			}
			set
			{
				this.setDataSetValueField = value;
			}
		}
		
		[Category("Services"), Description("Service to retrieve FCD/FCDA of all members referenced in the data set.")]
		public tServiceYesNo DataSetDirectory 
		{
			get 
			{
				return this.dataSetDirectoryField;
			}
			set 
			{
				this.dataSetDirectoryField = value;
			}
		}
		
		[Category("Services"), Description("service to configure new data sets up to the defined max.")]
		public tServiceWithMaxAndMaxAttributesAndModify ConfDataSet
		{
			get 
			{
				return this.confDataSetField;
			}
			set 
			{
				this.confDataSetField = value;
			}
		}
		
		[Category("Services"), Description("Services to dynamically create and delete data sets.")]
		public tServiceWithMaxAndMaxAttributes DynDataSet 
		{
			get 
			{
				return this.dynDataSetField;
			}
			set 
			{
				this.dynDataSetField = value;
			}
		}
		
		[Category("Services"), Description("Basic data read and write facility.")]
		public tServiceYesNo ReadWrite 
		{
			get 
			{
				return this.readWriteField;
			}
			set
			{
				this.readWriteField = value;
			}
		}
		
		[Category("Services"), Description("This element specifies that timer activated control services are supported.")]
		public tServiceYesNo TimerActivatedControl 
		{
			get
			{
				return this.timerActivatedControlField;
			}
			set 
			{
				this.timerActivatedControlField = value;
			}
		}
		
		[Category("Services"), Description("Capability of static creation of report control blocks.")]
		public tServiceWithMax ConfReportControl 
		{
			get 
			{
				return this.confReportControlField;
			}
			set 
			{
				this.confReportControlField = value;
			}
		}
		
		[Category("Services"), Description("Read values of control blocks.")]
		public tServiceYesNo GetCBValues 
		{
			get 
			{
				return this.getCBValuesField;
			}
			set
			{
				this.getCBValuesField = value;
			}
		}
		
		[Category("Services"), Description("Capability of static creation of log control blocks.")]
		public tServiceWithMax ConfLogControl 
		{
			get 
			{
				return this.confLogControlField;
			}
			set 
			{
				this.confLogControlField = value;
			}
		}
		
		[Category("Services"), Description("The report control block attributes for which online setting is possible.")]
		public tReportSettings ReportSettings
		{
			get 
			{
				return this.reportSettingsField;
			}
			set 
			{
				this.reportSettingsField = value;
			}
		}
		
		[Category("Services"), Description("The log control block attributes for which online setting is possible.")]
		public tLogSettings LogSettings 
		{
			get 
			{
				return this.logSettingsField;
			}
			set
			{
				this.logSettingsField = value;
			}
		}
		
		[Category("Services"), Description("The GSE control block attributes for which online setting is possible.")]
		public tGSESettings GSESettings 
		{
			get 
			{
				return this.gSESettingsField;
			}
			set 
			{
				this.gSESettingsField = value;
			}
		}
		
		[Category("Services"), Description("The SMV control block attributes for which online setting is possible.")]
		public tSMVSettings SMVSettings
		{
			get 
			{
				return this.sMVSettingsField;
			}
			set 
			{
				this.sMVSettingsField = value;
			}
		}
		
		[Category("Services"), Description("GSE directory services.")]
		public tServiceYesNo GSEDir
		{
			get
			{
				return this.gSEDirField;
			}
			set 
			{
				this.gSEDirField = value;
			}
		}
		
		[Category("Services"), Description("This element shows that the IED can be a GOOSE server and/or client.")]
		public tServiceWithMaxAndClient GOOSE 
		{
			get 
			{
				return this.gOOSEField;
			}
			set 
			{
				this.gOOSEField = value;
			}
		}
		
		[Category("Services"), Description("This element shows that the IED can be a binary data GSSE server and/or client.")]
		public tServiceWithMaxAndClient GSSE 
		{
			get 
			{
				return this.gSSEField;
			}
			set 
			{
				this.gSSEField = value;
			}
		}
		
		[Category("Services"), Description("All file handling services.")]
		public tServiceYesNo FileHandling 
		{
			get 
			{
				return this.fileHandlingField;
			}
			set
			{
				this.fileHandlingField = value;
			}
		}
		
		[Category("Services"), Description("Describes what can be configured for LNs defined in an ICD file.")]
		public tConfLNs ConfLNs
		{
			get
			{
				return this.confLNsField;
			}
			set 
			{
				this.confLNsField = value;
			}
		}
	}
	

}

