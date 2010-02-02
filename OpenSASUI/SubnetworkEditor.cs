
using System;
using OpenSCL;

namespace OpenSASUI
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class SubnetworkEditor : Gtk.Bin
	{
		private OpenSCL.Object sclfile;
		private int subnet;
		
		private void Init ()
		{
			this.Build();
			this.entry1.Text = "SubnetworkName";
			this.expander1.Expanded = false;
			this.expander1.Sensitive = false;
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
			this.entry1.Text = "";
			this.entry1.Text += this.sclfile.Subnetworks[this.subnet].name;
			
			return true;
		}
	}
}
