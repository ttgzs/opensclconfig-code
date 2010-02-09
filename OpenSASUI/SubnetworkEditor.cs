
using System;
using OpenSCL;

namespace OpenSASUI
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class SubnetworkEditor : Gtk.Bin
	{
		private OpenSCL.Object sclfile;
		private int subnet;
		private string defaultdesc;
		
		private void Init ()
		{
			this.Build();
			this.name.Text = Mono.Unix.Catalog.GetString("Subnetwork Name");
			this.expander.Expanded = false;
			this.expander.Sensitive = false;
			this.defaultdesc = this.descsubnet.Text;
		}
		
		public SubnetworkEditor ()
		{
			this.Init ();
			
		}
		
		public bool SetSubnetwork (OpenSCL.Object sclfile, int subnetIndex)
		{
			if (sclfile == null)
				return false;
			if (sclfile.Subnetworks == null)
				return false;
			if (subnetIndex < 0 || 
			    subnetIndex > sclfile.Subnetworks.GetLength(0))
				return false;
			
			this.sclfile = sclfile;
			this.subnet = subnetIndex;
			this.name.Text = "";
			this.name.Text += this.sclfile.Subnetworks[this.subnet].name;
			this.bitrate.Text = "";
			this.bitrate.Text += this.sclfile.Subnetworks[this.subnet].BitRate;
			this.type.Text = "";
			this.type.Text += this.sclfile.Subnetworks[this.subnet].type;
			
			string desc = "";
			desc += Mono.Unix.Catalog.GetString("Subnetwork: ");
			desc += this.sclfile.Subnetworks[this.subnet].name;
			desc += "\nDescription:";
			desc += this.sclfile.Subnetworks[this.subnet].desc;
			desc += Mono.Unix.Catalog.GetString("\nConnected Access Points: ");
			if (this.sclfile.Subnetworks[this.subnet].ConnectedAP != null)
				if (this.sclfile.Subnetworks[this.subnet].ConnectedAP.GetLength(0) > 0)
					desc += this.sclfile.Subnetworks[this.subnet].ConnectedAP.GetLength(0);
			
			this.descsubnet.Text = desc;
			this.expander.Sensitive = true;
			return true;
		}
		
		public void Clear ()
		{
			this.name.Text = "";
			this.bitrate.Text = "";
			this.type.Text = "";
			this.descsubnet.Text = this.defaultdesc;
			this.expander.Sensitive = false;
		}
	}
}
