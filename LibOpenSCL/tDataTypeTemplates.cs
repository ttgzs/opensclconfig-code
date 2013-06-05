// 
//  tDataTypeTemplates.cs
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
	[System.Xml.Serialization.XmlRootAttribute("DataTypeTemplates", Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	public partial class tDataTypeTemplates 
	{		
		private tLNodeType[] lNodeTypeField;		
		private tDOType[] dOTypeField;		
		private tDAType[] dATypeField;		
		private tEnumType[] enumTypeField;
		private static int nlnt = 0;
		private static int ndat = 0;
		private static int ndot = 0;

		public tDataTypeTemplates ()
		{
		}

		[System.Xml.Serialization.XmlElementAttribute("LNodeType")]
		[Category("DataTypeTemplates"), Browsable(false)]
		public tLNodeType[] LNodeType
		{
			get
			{
				return this.lNodeTypeField;
			}
			set 
			{
				this.lNodeTypeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("DOType")]
		[Category("DataTypeTemplates"), Browsable(false)]
		public tDOType[] DOType 
		{
			get 
			{
				return this.dOTypeField;
			}
			set 
			{
				this.dOTypeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("DAType")]
		[Category("DataTypeTemplates"), Browsable(false)]
		public tDAType[] DAType 
		{
			get 
			{
				return this.dATypeField;
			}
			set 
			{
				this.dATypeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("EnumType")]
		[Category("DataTypeTemplates"), Browsable(false)]
		public tEnumType[] EnumType 
		{
			get 
			{
				return this.enumTypeField;
			}
			set 
			{
				this.enumTypeField = value;
			}
		}
		
		public int GetLNType (string id) {
			if (this.lNodeTypeField==null)
				return -1;
			for (int i = 0; i < this.lNodeTypeField.Length; i++) {
				tLNodeType lnt = this.lNodeTypeField[i];
				if (lnt.id.Equals(id))
					return i;
			}
			return -1;
		}
		
		/// <summary>
		/// Add an array of tLNodeTypes, if one of them already exists is not added.
		/// </summary>
		/// <param name="array">
		/// A <see cref="tLNodeType[]"/> with the tLNodeType objects to add.
		/// </param>
		/// <returns>
		/// A <see cref="System.Collections.Generic.List<tLNodeType>"/>, a list of ignored tLNTypes.
		/// </returns>
		public System.Collections.Generic.List<tLNodeType> 
			AddLNodeType (tLNodeType[] tmpl)
		{
			if (dATypeField == null)
				AddDAType (null);
			if (dOTypeField == null)
				AddDOType (null);

			var ignored = new System.Collections.Generic.List<tLNodeType> ();
			var toadd = new System.Collections.ArrayList ();

			tLNodeType dt = new tLNodeType ();;
			if (tmpl == null) {
				dt.iedType = "TEMPLATE";
				dt.id = "TEMPLATE.LNTYPE" + tDataTypeTemplates.nlnt++;
				dt.lnClass = "TMPL";
			}

			if (lNodeTypeField == null && tmpl != null) {
				lNodeTypeField = new tLNodeType[tmpl.Length];
				tmpl.CopyTo (lNodeTypeField, 0);
				return ignored;
			}

			if (lNodeTypeField == null && tmpl == null) {
				lNodeTypeField = new tLNodeType[1];
				lNodeTypeField [0] = dt;
				return ignored;
			}

			if (lNodeTypeField != null && tmpl != null) {
				for (int i = 0; i < tmpl.Length; i++) {
					int j = this.GetDOType (tmpl [i].id);
					if (j >= 0) {
						ignored.Add (tmpl [i]);
						continue;
					} else
						toadd.Add (tmpl [i]);
				}
			}

			if (lNodeTypeField != null && tmpl == null) {
				toadd.Add (dt);
			}

			int index = this.lNodeTypeField.Length;
			System.Array.Resize<tLNodeType>(ref this.lNodeTypeField,
			                                 this.lNodeTypeField.Length + toadd.Count);

			for (int i = 0; i <  toadd.Count; i++) {
				this.lNodeTypeField[i+index] = (tLNodeType) toadd[i];
			}
			return ignored;
		}
		
		public int GetDOType (string id) {
			if (this.dOTypeField==null)
				return -1;
			for (int i = 0; i < this.dOTypeField.Length; i++) {
				tDOType dot = this.dOTypeField[i];
				if (dot.id.Equals(id))
					return i;
			}
			return -1;
		}
		
		public System.Collections.Generic.List<tDOType> 
			AddDOType (tDOType[] tmpl)
		{
			var ignored = new System.Collections.Generic.List<tDOType> ();
			var toadd = new System.Collections.ArrayList ();

			tDOType dt = new tDOType ();;
			if (tmpl == null) {
				dt.iedType = "TEMPLATE";
				dt.id = "TEMPLATE.DOType" + tDataTypeTemplates.ndot++;
				dt.cdc = "SPS";
			}

			if (dOTypeField == null && tmpl != null) {
				dOTypeField = new tDOType[tmpl.Length];
				tmpl.CopyTo (dOTypeField, 0);
				return ignored;
			}

			if (dOTypeField == null && tmpl == null) {
				dOTypeField = new tDOType[1];
				dOTypeField [0] = dt;
				return ignored;
			}

			if (this.dOTypeField != null && tmpl != null) {
				for (int i = 0; i < tmpl.Length; i++) {
					int j = this.GetDOType (tmpl [i].id);
					if (j >= 0) {
						ignored.Add (tmpl [i]);
						continue;
					} else
						toadd.Add (tmpl [i]);
				}
			}

			if (dOTypeField != null && tmpl == null) {
				toadd.Add (dt);
			}

			int index = this.dOTypeField.Length;
			System.Array.Resize<tDOType>(ref this.dOTypeField,
			                                 this.dOTypeField.Length + toadd.Count);

			for (int i = 0; i <  toadd.Count; i++) {
				this.dOTypeField[i+index] = (tDOType) toadd[i];
			}
			return ignored;
		}
		
		public int GetDAType (string id) {
			if (this.dATypeField==null)
				return -1;
			for (int i = 0; i < this.dATypeField.Length; i++) {
				tDAType dat = this.dATypeField[i];
				if (dat.id.Equals(id))
					return i;
			}
			return -1;
		}

		public System.Collections.Generic.List<tDAType> 
			AddDAType (tDAType[] tmpl)
		{
			var ignored = new System.Collections.Generic.List<tDAType> ();
			var toadd = new System.Collections.ArrayList ();

			tDAType dt = new tDAType ();;
			if (tmpl == null) {
				dt.iedType = "TEMPLATE";
				dt.id = "TEMPLATE.DAType" + tDataTypeTemplates.ndat++;
			}

			if (dATypeField == null && tmpl != null) {
				dATypeField = new tDAType[tmpl.Length];
				tmpl.CopyTo (dATypeField, 0);
				return ignored;
			}

			if (dATypeField == null && tmpl == null) {
				dATypeField = new tDAType[1];
				dATypeField [0] = dt;
				return ignored;
			}

			if (dATypeField != null && tmpl != null) {
				for (int i = 0; i < tmpl.Length; i++) {
					int j = this.GetDOType (tmpl [i].id);
					if (j >= 0) {
						ignored.Add (tmpl [i]);
						continue;
					} else
						toadd.Add (tmpl [i]);
				}
			}

			if (dATypeField != null && tmpl == null) {
				toadd.Add (dt);
			}

			int index = this.dATypeField.Length;
			System.Array.Resize<tDAType>(ref this.dATypeField,
			                                 this.dATypeField.Length + toadd.Count);

			for (int i = 0; i <  toadd.Count; i++) {
				this.dATypeField[i+index] = (tDAType) toadd[i];
			}
			return ignored;
		}		
		
		public int GetEnumType (string id) {
			if (this.enumTypeField==null)
				return -1;
			for (int i = 0; i < this.enumTypeField.Length; i++) {
				tEnumType ent = this.enumTypeField[i];
				if (ent.id.Equals(id))
					return i;
			}
			return -1;
		}
		
		public System.Collections.Generic.List<tEnumType> AddEnumType(tEnumType[] ent) {
			if(ent==null)
				return null;
			
			System.Collections.Generic.List<tEnumType> ignored;
			System.Collections.ArrayList toadd;
			
			ignored = new System.Collections.Generic.List<tEnumType>();
			toadd = new System.Collections.ArrayList();
			if (this.enumTypeField != null) {
				for (int i = 0; i < ent.Length; i++) {
					int j = this.GetEnumType(ent[i].id);
					if(j >= 0) {
						ignored.Add(ent[i]);
						continue;
					}
					else
						toadd.Add(ent[i]);
				}
				
				
				int index = this.enumTypeField.Length;
				System.Array.Resize<tEnumType>(ref this.enumTypeField,
				                                 this.enumTypeField.Length + toadd.Count);
				for (int i = 0; i <  toadd.Count; i++) {
					this.enumTypeField[i+index] = (tEnumType) toadd[i];
				}
			}
			else {
				this.enumTypeField =  new tEnumType[ent.Length];
				ent.CopyTo (enumTypeField, 0);
			}
			return ignored;
		}
		
		
	}
}

