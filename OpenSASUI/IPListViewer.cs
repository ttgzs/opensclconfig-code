// 
//  IPListViewer.cs
//  
//  Author:
//       Daniel Espinosa <esodan@gmail.com>
//  
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

namespace OpenSASUI
{

	[System.ComponentModel.ToolboxItem(true)]
	public class IPListViewer : OpenSASUI.CommViewer
	{

		public IPListViewer ()
		{
			// Setup TCP/IP table information
			Gtk.TreeStore ipmodel = new Gtk.TreeStore(typeof(string), // IP 0
			                                          typeof(int), // IP index 1
			                                          typeof(string), // IP MASK 2
			                                          typeof(int), // IP MASK index 3
			                                          typeof(string), // IP GATEWAY 4
			                                          typeof(int), // IP GATEWAY index 5
			                                          typeof(int), // ConnectedAP num 6
			                                          typeof(string), // IED Name 7
			                                          typeof(string)); // IED description 8
			
			ipmodel.SetSortFunc (0, (Gtk.TreeIterCompareFunc) compare_ip);
			ipmodel.SetSortFunc (7, (Gtk.TreeIterCompareFunc) comparestring_c7);
			this.InfoTreeView.Model = ipmodel;
			this.InfoTreeView.AppendColumn (Mono.Unix.Catalog.GetString("IP Address"),
			                              new Gtk.CellRendererText (), "text", 0);
			this.InfoTreeView.AppendColumn (Mono.Unix.Catalog.GetString("SubNetwork Mask"),
			                              new Gtk.CellRendererText (), "text", 2);
			this.InfoTreeView.AppendColumn (Mono.Unix.Catalog.GetString("IED Name"),
			                              new Gtk.CellRendererText (), "text", 7);
			this.InfoTreeView.AppendColumn (Mono.Unix.Catalog.GetString("Description"), new Gtk.CellRendererText (), "text", 8);
			
			this.InfoTreeView.GetColumn(0).Clickable = true;
			this.InfoTreeView.GetColumn(0).SortColumnId = 0;
			this.InfoTreeView.GetColumn(0).SortIndicator = true;
			this.InfoTreeView.GetColumn(0).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			this.InfoTreeView.GetColumn(2).Clickable = true;
			this.InfoTreeView.GetColumn(2).SortColumnId = 7;
			this.InfoTreeView.GetColumn(2).SortIndicator = true;
			this.InfoTreeView.GetColumn(2).Sizing = Gtk.TreeViewColumnSizing.Autosize;
			
			this.UpdateListButton.Clicked += HandleUpdatehandleClicked;
			
			this.HideDetails = true;
		}
		
		void HandleUpdatehandleClicked (object sender, EventArgs e)
		{
			this.UpdateList();
		}
		
		protected override void UpdateList()
		{
			Gtk.TreeStore ipmodel = (Gtk.TreeStore) this.InfoTreeView.Model;
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
						    .ConnectedAP[i].Address.P[j].typeEnum == IEC61850.SCL.tPTypeEnum.IP)
							ipindex = j;
						if (sclfile.Subnetworks[this.subnetwork]
						    .ConnectedAP[i].Address.P[j].typeEnum == IEC61850.SCL.tPTypeEnum.IP_SUBNET)
							maskindex = j;
						if (sclfile.Subnetworks[this.subnetwork]
						    .ConnectedAP[i].Address.P[j].typeEnum == IEC61850.SCL.tPTypeEnum.IP_GATEWAY)
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
		
		protected int compare_ip (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			string s1 = (string) this.InfoTreeView.Model.GetValue (a, 0);
			string s2 = (string) this.InfoTreeView.Model.GetValue (b, 0);
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
		
	}
}
