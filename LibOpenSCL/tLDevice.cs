// 
//  tLDevice.cs
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
	 * 
	*/		
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.iec.ch/61850/2003/SCL")]	
	public partial class tLDevice : tUnNaming
	{		
		private static int index = 0;
		private static int nln = 0;
		private LN0 lN0Field;
		private tLN[] lnField;
		private tAccessControl accessControlField;
		private string instField;
		private System.Collections.Hashtable _lnhash = new System.Collections.Hashtable ();
		
		public tLDevice()
		{
		}

		[System.Xml.Serialization.XmlIgnore()]
		public tDataTypeTemplates templates { get; set; }
		
		[Category("LDevice"), Description("The LN class is always LLN0"), Browsable(false)]
		public LN0 LN0 
		{
			get
			{
				return this.lN0Field;
			}
			set
			{
				this.lN0Field = value;
			}
		}

		[System.Xml.Serialization.XmlIgnore]
		public System.Collections.Hashtable LNHash
		{ get; set; }

		[System.Xml.Serialization.XmlElementAttribute("LN")]
		[Category("LDevice"), Browsable(false)]
		public tLN[] LN 
		{
			get 
			{
				return this.lnField;
			}
			set 
			{
				this.lnField = value;
			}
		}
		
		[Category("LDevice"), Description("Access control definition for this LD."), Browsable(false)]
		public tAccessControl AccessControl 
		{
			get 
			{
				return this.accessControlField;
			}
			set
			{
				this.accessControlField = value;
			}
		}
			
		[Required]
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("LDevice"), Description("Identification of the LDevice within the IED.")]
		public string inst 
		{
			get
			{
				return this.instField;
			}
			set 
			{
				if( value != "")
				{
					this.instField = value;
				}
				else
				{
					this.inst = this.instField;
				}
				OnPropertyChanged ("inst");
			}
		}
		
		public int AddLN (tLN lnode)
		{
			var ln = new tLN ();
			if (lnode == null) {
				ln.inst = (uint) (++tLDevice.nln);
				if (templates != null) {
					int i = templates.GetLNType ("TEMPLATE.LNTYPE0");
					System.Console.WriteLine ("Index of lntmpl = " + i);
					if (i>=0) {
						ln.lnClass = templates.LNodeType[i].lnClass;
						ln.lnType = templates.LNodeType[i].id;
					} else {
						tLNodeType lnt = new tLNodeType ();
						lnt.iedType = this.inst;
						lnt.lnClass = "TMPL";
						lnt.id = "TEMPLATE.LNTYPE0";
						var ig = templates.AddLNodeType (lnt);
						if (ig == -1)
							return -1;
						ln.lnClass = lnt.lnClass;
						ln.lnType = lnt.id;
					}
				} else {
					ln.lnClass = "TMPL";
					ln.lnType = "TEMPLATE.LNTYPE0";
				}
			} else {
				ln = lnode;
			}

			int index = -1;
			if (this.LN == null) {
				this.LN = new tLN[1];
				this.LN[0] = ln;
				index = 0;
			}
			else {
				System.Array.Resize<tLN>(ref this.lnField,
				                         this.lnField.Length + 1);
				index = this.lnField.Length -1;
				lnField[index] = ln;
			}
			return index;
		}

		public int GetLN (string prefix, string lnclass, uint inst)
		{
			if (LN != null) {
				for (int i = 0; i < LN.Length; i++) {
					if (LN[i].prefix.Equals (prefix) &&
					    LN[i].lnClass.Equals (lnclass) &&
					    LN[i].inst == inst)
						return i;
				}
			}
			return -1;
		}

		public System.Collections.Hashtable find_duplicated_ln ()
		{
			System.Collections.Hashtable hln = new System.Collections.Hashtable ();
			System.Collections.Hashtable dln = new System.Collections.Hashtable ();
			if (LN != null) {
				for (int i = 0; i < LN.Length; i++) {
					string k = LN[i].prefix +
						LN[i].lnClass +
							LN[i].inst;
					if (!hln.ContainsKey (k))
						hln.Add (k,i);
					else
						dln.Add (k,i);
				}
			}
			return dln;
		}

		public System.Collections.Hashtable find_invalid_lntypes ()
		{
			System.Collections.Hashtable tln = templates.logical_nodes_types;;
			System.Collections.Hashtable ilnt = new System.Collections.Hashtable ();
			if (LN != null) {
				for (int i = 0; i < LN.Length; i++) {
					if (!tln.ContainsKey (LN[i].lnType)) {
						string k = LN[i].prefix +
						LN[i].lnClass +
							LN[i].inst;
						ilnt.Add (k,i);
					}
				}
			}
			return ilnt;
		}
	}
}