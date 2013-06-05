// 
//  tBaseElement.cs
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
	
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tIDNaming))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEnumType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDAType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDOType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLNodeType))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tNaming))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSDO))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubNetwork))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControlWithIEDName))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSampledValueControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSEControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControlWithTriggerOpt))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLogControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tReportControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDataSet))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAccessPoint))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tIED))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLNodeContainer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConnectivityNode))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPowerSystemResource))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubFunction))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tFunction))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTapChanger))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGeneralEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tPowerTransformer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAbstractConductingEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTransformerWinding))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConductingEquipment))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tEquipmentContainer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBay))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tVoltageLevel))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSubstation))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tUnNaming))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDO))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAbstractDataAttribute))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tBDA))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDA))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tCommunication))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSCLControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSettingControl))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tInputs))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDAI))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSDI))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tDOI))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tControlBlock))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tSMV))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tGSE))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tConnectedAP))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tRptEnabled))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tAnyLN))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLN0))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLN))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLDevice))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tServer))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tTerminal))]
	[System.Xml.Serialization.XmlIncludeAttribute(typeof(tLNode))]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]
	public partial class tBaseElement : INotifyPropertyChanged
	{		
		private System.Xml.XmlElement[] anyField;		
		private tText textField;		
		private tPrivate[] privateField;		
		private System.Xml.XmlAttribute[] anyAttrField;
		
		
		/*
		 * TODO: This implementation fails to add new XmlAttributes because no XmlDocument exists
		 * 
		private System.Collections.Generic.List<System.Xml.XmlAttribute> anyAttrField;
		
		[Category("BaseElement"), Browsable(false)]
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get 
			{
				return this.anyAttrField.ToArray();
			}
			set 
			{
				if (value == null) 
					this.anyAttrField.Clear();
				else {
					for(int i = 0; i < value.Length; i++) {
						this.anyAttrField.Add(value[i]);
					}
				}
					
			}
		}
		
		public bool AddCustomAttribute (string name, string val, string prefix, string ns) {
			if(this.anyAttrField.Count > 0) {
				
			}
			return false;
		}
		
		public tBaseElement() {
			anyAttrField = new System.Collections.Generic.List<System.Xml.XmlAttribute>();
		}
		
		
		*/
		
		[Category("BaseElement"), Browsable(false)]
		[System.Xml.Serialization.XmlAnyAttributeAttribute()]
		public System.Xml.XmlAttribute[] AnyAttr
		{
			get 
			{
				return this.anyAttrField;
			}
			set 
			{
				this.anyAttrField = value;
			}
		}
		
		
		//Name spaces
		[System.Xml.Serialization.XmlNamespaceDeclarations]
    	public System.Xml.Serialization.XmlSerializerNamespaces xmlns;
		
		
		[System.Xml.Serialization.XmlAnyElementAttribute()]
		[Category("BaseElement"), Browsable(false)]
		public System.Xml.XmlElement[] Any 
		{
			get 
			{
				return this.anyField;
			}
			set
			{
				this.anyField = value;
			}
		}
		
		[Category("BaseElement"), Browsable(false)]
		public tText Text 
		{
			get 
			{
				return this.textField;
			}
			set
			{
				this.textField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("Private")]
		[Category("BaseElement"), Browsable(false)]
		public tPrivate[] Private 
		{
			get
			{
				return this.privateField;
			}
			set
			{
				this.privateField = value;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged (string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(name));
		}
	}
	
}

