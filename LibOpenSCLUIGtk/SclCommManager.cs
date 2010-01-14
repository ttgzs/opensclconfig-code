// 
//  SclCommManager.cs
//  
//  Author:
//       Nombre completo <Dirección de correo electrónico>
//  
//  Copyright (c) 2010 Nombre completo
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
using OpenSCL;

namespace LibOpenSCLUIGtk
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class SclCommManager : Gtk.Bin
	{
		private OpenSCL.Object sclfile;
		private int subnetwork;
		
		private void Init ()
		{
			this.Build ();
			Gtk.TreeStore ipmodel = new Gtk.TreeStore(typeof(string), // IP 0
			                                          typeof(int), // IP index 1
			                                          typeof(string), // IP MASK 2
			                                          typeof(int), // IP MASK index 3
			                                          typeof(string), // IP GATEWAY 4
			                                          typeof(int), // IP GATEWAY index 5
			                                          typeof(int), // ConnectedAP num 6
			                                          typeof(string), // IED Name 7
			                                          typeof(string)); // IED description 8
			this.iptreeview.Model = ipmodel;
			this.iptreeview.AppendColumn ("IP Address", new Gtk.CellRendererText (), "text", 0);
			this.iptreeview.AppendColumn ("SubNetwork Mask", new Gtk.CellRendererText (), "text", 2);
			this.iptreeview.AppendColumn ("IED Name", new Gtk.CellRendererText (), "text", 7);
			this.iptreeview.AppendColumn ("Description", new Gtk.CellRendererText (), "text", 8);
			ipmodel.SetSortColumnId (0, Gtk.SortType.Ascending);
			ipmodel.SetSortFunc (0, (Gtk.TreeIterCompareFunc) compare_ip);
			ipmodel.SetSortFunc (7, (Gtk.TreeIterCompareFunc) comparestring);
			this.iptreeview.GetColumn(0).Clickable = true;
			this.iptreeview.GetColumn(0).SortColumnId = 0;
			this.iptreeview.GetColumn(0).SortIndicator = true;
			this.iptreeview.GetColumn(0).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.iptreeview.GetColumn(2).Clickable = true;
			this.iptreeview.GetColumn(2).SortColumnId = 7;
			this.iptreeview.GetColumn(2).SortIndicator = true;
			this.iptreeview.GetColumn(2).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			
			this.ipupdate.Clicked += HandleIpupdatehandleClicked;
		}

		int comparestring (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			string s1 = (string) this.iptreeview.Model.GetValue (a, 0);
			string s2 = (string) this.iptreeview.Model.GetValue (b, 0);
			return s1.CompareTo(s2);
		}
		
		int compare_ip (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			string s1 = (string) this.iptreeview.Model.GetValue (a, 0);
			string s2 = (string) this.iptreeview.Model.GetValue (b, 0);
			string[] ts1;
			string[] ts2;
			
			if (s1.Contains (":")) {
				// Is a IPv6 address
				ts1 = s1.Split (':');
				ts2 = s2.Split (':');
			}
			else {
				// Is a IPv4 address
				ts1 = s1.Split ('.');
				ts2 = s2.Split ('.');
			}
			// If a has more members than b, then not compare and return 0 as being equal
			if (ts1.GetLength(0) > ts2.GetLength(0))
				return 0;
			
			// This will compare member by member
			int res = 0;
			for (int i = 0; i < ts1.GetLength(0); i++) {
				int va = int.Parse(ts1[i]);
				int vb = int.Parse (ts2[i]);
				res = va - vb;
				if (res != 0)
					break;
			}
			
			return res;
		}
		
		void HandleIpupdatehandleClicked (object sender, EventArgs e)
		{
			Gtk.TreeStore ipmodel = (Gtk.TreeStore) this.iptreeview.Model;
			Gtk.TreeIter iter;
			// Clear IP table
			while (ipmodel.GetIterFirst(out iter))
				ipmodel.Remove(ref iter);
			// Fill IP table
			for (int i = 0; i < sclfile.Subnetworks[this.subnetwork].ConnectedAP.GetLength(0); i++) {
				string ip = "";
				string ipmask = "";
				string ipgatew = "";
				string iedname = "";
				string ieddesc = "";
				// Search for IP tPType
				int ipindex = -1;
				int maskindex = -1;
				int gatewindex = -1;
				if (sclfile.Subnetworks[this.subnetwork].ConnectedAP[i].Address != null) {
					for (int j = 0; j < sclfile.Subnetworks[this.subnetwork].ConnectedAP[i].Address.P.GetLength(0); j++) {
						if (sclfile.Subnetworks[this.subnetwork]
						    .ConnectedAP[i].Address.P[j].type == IEC61850.SCL.tPTypeEnum.IP)
							ipindex = j;
						if (sclfile.Subnetworks[this.subnetwork]
						    .ConnectedAP[i].Address.P[j].type == IEC61850.SCL.tPTypeEnum.IP_SUBNET)
							maskindex = j;
						if (sclfile.Subnetworks[this.subnetwork]
						    .ConnectedAP[i].Address.P[j].type == IEC61850.SCL.tPTypeEnum.IP_GATEWAY)
							gatewindex = j;
						
					}
					if (ipindex >= 0)
						ip += sclfile.Subnetworks[this.subnetwork]
						    .ConnectedAP[i].Address.P[ipindex].Value;
					if (maskindex >= 0)
						ipmask += sclfile.Subnetworks[this.subnetwork]
						    .ConnectedAP[i].Address.P[maskindex].Value;
					if (gatewindex >= 0)
						ipgatew += sclfile.Subnetworks[this.subnetwork]
						    .ConnectedAP[i].Address.P[gatewindex].Value;
					if (sclfile.Subnetworks[this.subnetwork].ConnectedAP[i].iedName != null)
						iedname += sclfile.Subnetworks[this.subnetwork].ConnectedAP[i].iedName;
					
					if (sclfile.Subnetworks[this.subnetwork].ConnectedAP[i].apName != null) {
						iedname += " (";
						iedname += sclfile.Subnetworks[this.subnetwork].ConnectedAP[i].apName;
						iedname += ")";
					}
					
					ipmodel.AppendValues(ip, ipindex, ipmask, maskindex,
					                     ipgatew, gatewindex, i,
					                     iedname, "");
				}
			}
		}

		public SclCommManager ()
		{
			this.subnetwork = -1;
			this.Init();
		}
		public SclCommManager (OpenSCL.Object sclfile, int subnet)
		{
			this.Init();
			this.SetSubnetwork(sclfile, subnet);
		}
		
		public bool SelectSubnetwork (OpenSCL.Object sclfile, 
		                           int subnet)
		{
			if (sclfile == null)
				return false;
			if (sclfile.Subnetworks == null)
				return false;
			if (subnet < 0 && subnet > sclfile.Subnetworks.GetLength(0))
				return false;
			if (sclfile.Subnetworks[subnet].ConnectedAP == null)
				return false;
			
			this.Clear();
			
			return true;
		}
		
		public bool SetSubnetwork (OpenSCL.Object sclfile, int subnet)
		{
			this.sclfile = sclfile;
			this.subnetwork = subnet;
			if (SelectSubnetwork(sclfile, subnet)) 
				return true;
			else {
				this.sclfile = null;
				this.subnetwork = -1;
				this.Clear();
				return false;
			}
		}
		
		public bool ChangeSubnetwork (int subnet)
		{
			this.subnetwork = subnet;
			int s = subnet;
			if (SelectSubnetwork(this.sclfile, subnet))
				return true;
			else {
				this.subnetwork = s;
				return SelectSubnetwork (this.sclfile, s);
			}
		}
		
		public void Clear ()
		{
			Gtk.TreeIter iter;
			// IP viewer
			Gtk.TreeStore ipmodel = (Gtk.TreeStore) this.iptreeview.Model;
			while (ipmodel.GetIterFirst(out iter))
				ipmodel.Remove(ref iter);
		}
	}
}
