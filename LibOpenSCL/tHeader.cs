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
		private bool logsetversion;
				
		public tHeader() 
		{
			// By default not log any set version updated
			this.logsetversion = false;
			
			this.version = "0";
			this.revision = "0";
			this.id = "Created by LibOpenSCL (c) Comision Federal de Electricidad, 2009";
		}
		
		/// <summary>
		/// Set to true if you want to log any update of version number not using UpdateVersion().
		/// </summary>
		[System.Xml.Serialization.XmlIgnore]
		public bool LogSetVersion {
			get { return this.logsetversion; }
			set { this.logsetversion = value; }
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
				if(this.logsetversion) 
				{
					tHitem item = new tHitem();
					item.version = this.version;
					item.revision = this.revision;
					item.what = "Version updated: new value = " + value.ToString();
					item.who = "No one. Automatic";
					item.why = "Log forsed version updated";
					this.AddHistoryItem(item);
				}				
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
				if(this.logsetversion) 
				{
					tHitem item = new tHitem();
					item.version = this.version;
					item.revision = this.revision;
					item.what = "Revision updated: new value = " + value.ToString();
					item.who = "No one. Automatic";
					item.why = "Log forsed revision updated";
					this.AddHistoryItem(item);
				}
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
		
		
		/// <summary>
		/// Add a tHitem object to History.
		/// </summary>
		/// <param name="item">
		/// A <see cref="tHitem"/> object to add.
		/// </param>
		/// <returns>
		/// A <see cref="System.Int32"/> index of the added item.
		/// </returns>
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
		/// Add Items to History. Item's version and revision, are set to Header's ones.
		/// </summary>
		/// <param name="its">
		/// A <see cref="tHitem[]"/>
		/// </param>
		/// <param name="whyPrefix">
		/// A <see cref="System.String"/>, if not null, it is added at the bigining of the tHitem.why field.
		/// </param>
		/// <returns>
		/// A <see cref="System.Int32"/>
		/// </returns>
		public bool AddHistoryItem(tHitem[] its, string whyPrefix) {
			if(its == null)
				return false;
			
			if (this.historyField != null) {
				try {
					int index = this.historyField.Length;
					System.Array.Resize<tHitem>(ref this.historyField,
					                                 this.historyField.Length + its.Length);
					for (int i = 0; i <  its.Length; i++) {
						this.historyField[i+index] = its[i];
						this.historyField[i+index].revision = this.revision;
						this.historyField[i+index].version = this.version;
						if(whyPrefix!=null)
								this.historyField[i+index].what = whyPrefix + this.historyField[i+index].what;
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
		
		/// <summary>
		/// Increase version number in one. If the version is not a number, it is not updated.
		/// If updated, set revision to 0.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> updated version or the original if it is not a number.
		/// </returns>
		public string UpdateVersion() {
			try {
				int v = int.Parse(this.version);
				v+=1;
				this.version = v.ToString();
				this.revision = "0";
			}
			catch {
				System.Console.WriteLine("Configuration's version is not an integer; version not updated...");
			}
			return this.version;
		}
		
		
		/// <summary>
		/// Increase revision number in one. If the version is not a number, it is not updated.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> updated revision or the original if it is not a number.
		/// </returns>
		public string UpdateRevision() {
			try {
				int v = int.Parse(this.revision);
				v+=1;
				this.revision = v.ToString();
			}
			catch {
				System.Console.WriteLine("Configuration's revision is not an integer; revision not updated...");
			}
			return this.revision;
		}
	}
}

