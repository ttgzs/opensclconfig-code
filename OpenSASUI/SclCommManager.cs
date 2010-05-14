
using System;

namespace OpenSASUI
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class SclCommManager : Gtk.Bin
	{
		private OpenSCL.Object sclfile;
		private int subnetwork;
				
		private void Init ()
		{
			this.Build ();
			
			this.gselistviewer.Sensitive = false;
			this.iplistviewer.Sensitive = false;
			this.reportlistviewer.Sensitive = false;
			
			this.notebook1.Page = 0;
		}

		public SclCommManager ()
		{
			this.subnetwork = -1;
			this.Init();
		}
		public SclCommManager (OpenSCL.Object sclfile, int subnet)
		{
			this.subnetwork = -1;
			this.Init();
			this.SetSubnetwork(sclfile, subnet);
		}
		
		public bool SelectSubnetwork (OpenSCL.Object sclfile, int subnet)
		{
			if (sclfile == null)
				return false;
			if (sclfile.Subnetworks == null)
				return false;
			if (subnet < 0 && subnet > sclfile.Subnetworks.GetLength(0))
				return false;
			if (sclfile.Subnetworks[subnet].ConnectedAP == null)
				return false;
			if (!this.subnetworkeditor1.SetSubnetwork(this.sclfile, this.subnetwork))
				return false;
			
			this.Clear();
			
			if (this.gselistviewer.SetSubnetwork(this.sclfile,this.subnetwork, true))
				this.gselistviewer.Sensitive = true;
			
			if (this.iplistviewer.SetSubnetwork(this.sclfile,this.subnetwork, true))
				this.iplistviewer.Sensitive = true;
			
			if (this.reportlistviewer.SetSubnetwork(this.sclfile,this.subnetwork, true))
				this.reportlistviewer.Sensitive = true;
			
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
			this.gselistviewer.Clear();
			this.iplistviewer.Clear();
			this.reportlistviewer.Clear();
		}
	}
}
