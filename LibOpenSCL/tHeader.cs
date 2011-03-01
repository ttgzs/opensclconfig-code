// 
//  tHeader.cs
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
	public partial class tHeader 
	{		
		private static int index = 0;
		private tText textField;		
		private tHitem[] historyField;		
		private string idField;		
		private string versionField;
		private string revisionField;		
		private string toolIDField;		
		private tHeaderNameStructure nameStructureField;
				
		public tHeader() 
		{
			this.versionField = "0";
			if(this.revision == null )
			{
				this.revision = ( ++index ).ToString();
			}
			this.idField = "SCL File";
			this.toolIDField = "OpenSCLConfigurator";
			this.nameStructureField = tHeaderNameStructure.IEDName;				
		}
		
		[Category("Header"), Browsable(false)]
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
		
		[System.Xml.Serialization.XmlArrayItemAttribute("Hitem", IsNullable=false)]
		[Category("Header"), Browsable(false)]
		public tHitem[] History 
		{
			get 
			{
				return this.historyField;
			}
			set 
			{
				this.historyField = value;
			}
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Header"), Description("A string identifying this SCL file.")]
		public string id 
		{
			get 
			{
				return this.idField;
			}
			set 
			{
				this.idField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Header"), Description("The version of this SCL configuration file.")]
		public string version 
		{
			get 
			{
				return this.versionField;
			}
			set 
			{
				this.versionField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Header"), Description("The revision of this SCL configuration file, by default the empty string meaning the original before any revision")]
		public string revision 
		{
			get 
			{
				return this.revisionField;
			}
			set 
			{
				this.revisionField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Header"), Description("The manufacturer specific identification of the tool that was used to create the SCL file")]
		[ReadOnly(true)]
		public string toolID 
		{
			get 
			{
				return this.toolIDField;
			}
			set 
			{
				this.toolIDField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute()]		
		[Category("Header"), Description("Element indicating if communication system signal names are built"+
		    "from the substation function structure or from the IED product structure")]
		public tHeaderNameStructure nameStructure 
		{
			get 
			{
				return this.nameStructureField;
			}
			set 
			{
				this.nameStructureField = value;
			}
		}
		
		public int AddHistoryItem(tHitem item) {
			int index = -1;
			if (this.historyField != null) {
				System.Array.Resize<tHitem>(ref this.historyField,
				                                 this.historyField.Length + 1);
				
				index = this.historyField.Length - 1;
			}
			else {
				this.historyField = new tHitem[1];
				index = 0;
			}
			this.historyField[index] = item;
			return index;
		}
		
		/// <summary>
		/// Add Items to History.
		/// </summary>
		/// <param name="its">
		/// A <see cref="tHitem[]"/>
		/// </param>
		/// <param name="prefix">
		/// A <see cref="System.String"/>, it is added at the bigining of the tHitem.what field.
		/// </param>
		/// <returns>
		/// A <see cref="System.Int32"/>
		/// </returns>
		public bool AddHistoryItem(tHitem[] its, string prefix) {
			if(its == null)
				return false;
			
			if (this.historyField != null) {
				try {
					int index = this.historyField.Length;
					System.Array.Resize<tHitem>(ref this.historyField,
					                                 this.historyField.Length + its.Length);
					for (int i = 0; i <  its.Length; i++) {
						this.historyField[i+index] = its[i];
						if(prefix!=null)
								this.historyField[i+index].what = prefix + this.historyField[i+index].what;
					}
				}
				catch {
					return false;
				}
			}
			else {
				its.CopyTo(this.historyField, 0);
			}
			return true;
		}
	}

	

	
	
}

