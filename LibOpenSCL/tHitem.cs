// 
//  tHitem.cs
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
	public partial class tHitem : tAnyContentFromOtherNamespace 
	{		
		private static int index = 0;
		private string versionField;		
		private string revisionField;		
		private string whenField;		
		private string whoField;		
		private string whatField;		
		private string whyField;
		
		public tHitem()
		{
			this.versionField = "0";
			if(this.revision == null)
			{
				this.revision = (++index).ToString();
			}
			this.whenField = "";	
			this.what = "New SCL File";
		}
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Hitem"), Description("The version of this history entry")]
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
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Hitem"), Description("The revision of this history entry")]
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
		
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Hitem"), Description("Date when the version/revision was released")]
		public string when 
		{
			get 
			{
				return this.whenField;
			}
			set 
			{
				this.whenField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Hitem"), Description("Who made/approved this version/revision")]
		public string who 
		{
			get
			{
				return this.whoField;
			}
			set 
			{
				this.whoField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Hitem"), Description("What has been changed since the last approval")]
		public string what 
		{
			get 
			{
				return this.whatField;
			}
			set 
			{
				this.whatField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("Hitem"), Description("Why the change has happened")]
		public string why 
		{
			get 
			{
				return this.whyField;
			}
			set 
			{
				this.whyField = value;
			}
		}
	}

}

