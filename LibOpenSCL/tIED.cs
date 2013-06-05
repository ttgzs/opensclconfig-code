// 
//  tIED.cs
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
	[System.Xml.Serialization.XmlRootAttribute("IED", Namespace="http://www.iec.ch/61850/2003/SCL", IsNullable=false)]
	public partial class tIED : tNaming 
	{		
		private static int index = 0;
		private static int nld = 0;
		private tServices servicesField;		
		private tAccessPoint[] accessPointField;		
		private string typeField;		
		private string manufacturerField;		
		private string configVersionField;
		
		public tIED()
		{
			if(this.name == null)
			{
				this.name = "IED" + ( ++index ).ToString();
			}
		}
		
		[Category("IED"), Description("All services for dynamic building of associations."), Browsable(false)]
		public tServices Services 
		{
			get 
			{
				return this.servicesField;
			}
			set 
			{
				this.servicesField = value;
			}
		}
		
		[System.Xml.Serialization.XmlElementAttribute("AccessPoint")]
		[Category("IED"), Browsable(false)]
		public tAccessPoint[] AccessPoint 
		{
			get 
			{
				return this.accessPointField;
			}
			set 
			{
				this.accessPointField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("IED"), Description("The (manufacturer specific) IED product type.")]
		public string type
		{
			get 
			{
				return this.typeField;
			}
			set 
			{
				this.typeField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("IED"), Description("The manufacturer’s name.")]
		public string manufacturer 
		{
			get 
			{
				return this.manufacturerField;
			}
			set
			{
				this.manufacturerField = value;
			}
		}
		
		[System.Xml.Serialization.XmlAttributeAttribute(DataType="normalizedString")]
		[Category("IED"), Description("The basic configuration version of this IED configuration.")]
		public string configVersion 
		{
			get 
			{
				return this.configVersionField;
			}
			set 
			{
				this.configVersionField = value;
			}
		}
		
		/// <summary>
		/// Add a new Access Point to the IED. 
		/// </summary>
		/// <param name="name">
		/// A <see cref="System.String"/> with the name of the new Access Point to be added.
		/// </param>
		/// <returns>
		/// A <see cref="System.Int32"/> with the index of the new Access Point added.
		/// </returns>
		public int AddAP (string name)
		{
			if (name == null)
				return -1;
			tAccessPoint ap = new tAccessPoint ();
			ap.name = name;
			ap.Server = new tServer ();
			ap.Server.Authentication = new tServerAuthentication ();
			int index = -1;
			if (this.accessPointField == null) {
				this.accessPointField = new tAccessPoint[1];
				this.accessPointField [0] = ap;
				index = 0;
			} else {
				// Search for AP name if duplicated return -1				
				for (int i = 0; i < this.accessPointField.GetLength(0); i++) {
					if (this.accessPointField [i].name.Equals (name)) {
						System.Console.WriteLine ("Found a Duplicated AP with name " + name);
						return -1;
					}
				}
				// No duplicated, add to the array
				System.Array.Resize<tAccessPoint> (ref this.accessPointField,
				                                  this.accessPointField.GetLength (0) + 1);
				index = this.accessPointField.GetLength (0) - 1;
				this.accessPointField [index] = ap;
			}
			return index;
		}
		
		/// <summary>
		/// Search the Access Point's index with the given name. 
		/// </summary>
		/// <param name="apname">
		/// A <see cref="System.String"/> with the access point to search.
		/// </param>
		/// <returns>
		/// A <see cref="System.Int32"/> with the index of the found access point or -1 if no one was found.
		/// </returns>
		public int GetAP (string apname) {
			for (int i = 0; i < this.accessPointField.GetLength(0); i++) {
				if (this.accessPointField[i].name.Equals(apname))
				{
					return i;
				}
			}
			return -1;
		}
		
		public int AddLDevice (string inst, string ap, tDataTypeTemplates tpl) 
		{
			if (tpl == null) return -1;
			if (accessPointField == null)
				AddAP (ap);

			var ld = new tLDevice ();
			if (inst == null)
				ld.inst = "TEMPLATE_LD" + (++tIED.nld).ToString ();
			else
				ld.inst = inst;

			tLNodeType tln;
			int lnt = tpl.GetLNType ("TEMPLATE.LPHD");
			if (lnt != -1) {
				tln = tpl.LNodeType [lnt];
			}
			else {
				tln = new tLNodeType (name, "LPHD", name + ".LPHD");
				var arrtln = new tLNodeType [1];
				arrtln [0] = tln;
				tpl.AddLNodeType (arrtln);
			}

			var ln = new tLN ();
			ln.inst = 1;
			ln.lnType = tln.id;
			ln.lnClass = tln.lnClass;
			ld.AddLN (ln);

			int api = this.GetAP(ap);
			if (api == -1) {
				api = this.AddAP (ap);
			}
			return this.AccessPoint[api].Server.AddLDevice (ld);
		}
	}

}

