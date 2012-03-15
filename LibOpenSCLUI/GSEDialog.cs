// LibOpenSCLUI
//
// Copyright (C) 2009 Comisión Federal de Electricidad
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 3 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 
using System;
using System.Windows.Forms;
using IEC61850.SCL;

namespace OpenSCL.UI
{
	/// <summary>
	/// Description of GSEDialog .
	/// </summary>
	public partial class GSEDialog : Form
	{
		private OpenSCL.Object scl;
		private tIED ied;
		private tAccessPoint ap;
		private tLDevice ld;
		private tGSEControl gsec;
		private tGSE gse;
		private string oldGSEName;
		private bool editWindow = false;
		private TreeNode node;
		private TreeViewSCL tvscl;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="OpenSCL.UI.GSEDialog"/> class.
		/// </summary>
		/// <param name='tvscl'>
		/// Tvscl.
		/// </param>
		/// <param name='node'>
		/// Node.
		/// </param>
		/// <param name='scl'>
		/// Scl.
		/// </param>
		/// <param name='ied'>
		/// Ied.
		/// </param>
		/// <param name='ap'>
		/// Ap.
		/// </param>
		/// <param name='ld'>
		/// Ld.
		/// </param>
		public GSEDialog(TreeViewSCL tvscl, TreeNode node,
		                 tIED ied, tAccessPoint ap, tLDevice ld)
		{
			this.scl = tvscl.scl;
			this.ied = ied;
			this.ap = ap;
			this.ld = ld;
			this.node = node;
			this.tvscl = tvscl;
			
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();
			this.IdInst.Text = ld.inst;
			this.Text = "New GOOSE";	
		}
		
		/// <summary>
		/// This method shows a dialog box that allows to edit a GOOSE or GSE configuration
		/// </summary>
		/// <param name="gseSelected">
		/// GOOSE or GSE that was selected for Edit his configuration.
		/// </param>
		/// <param name="treeSCL">
		/// TreeNode reference
		/// </param>
		/// <param name="apParentName">
		/// Name of Access point where configuration will be edited according to the LN0 selected.
		/// </param>
		/// <param name="iedParentName">
		/// Name of IED where configuration will be edited according to the LN0 selected.
		/// </param>
		public GSEDialog (TreeViewSCL tvscl, TreeNode node, tIED ied, tAccessPoint ap,   
		                 tLDevice ld, tGSEControl gc)
		{
			this.editWindow = true;
			this.tvscl = tvscl;
			this.scl = tvscl.scl;
			this.ld = ld;
			this.ied = ied;
			this.ap = ap;
			this.node = node;
			this.gsec = gc;
			InitializeComponent();
			this.datSet.SelectedItem = gc.datSet;
			this.oldGSEName = gc.name;
			this.IdInst.Text = this.ld.inst;
			
			var hgse = this.scl.Configuration.GetGSE (ied.name, ap.name, ld.inst, gc.name);
			if (hgse["gse"] is tGSE) {
				this.gse = (tGSE) hgse["gse"];
				this.cbName.Text = gse.cbName;
			    this.desc.Text = gse.desc;
				if (gse.Address != null && gse.Address.P != null) {
					for (int i = 0; i < gse.Address.P.Length; i++) {
						if (gse.Address.P[i].typeEnum == tPTypeEnum.MAC_Address)
							this.mac.Text    = gse.Address.P[i].Value;
						if (gse.Address.P[i].typeEnum == tPTypeEnum.APPID)
							this.appId.Text    = gse.Address.P[i].Value;
						if (gse.Address.P[i].typeEnum == tPTypeEnum.VLAN_PRIORITY)
							this.vLANP.Text    = gse.Address.P[i].Value;
						if (gse.Address.P[i].typeEnum == tPTypeEnum.VLAN_ID)
							this.vLANI.Text    = gse.Address.P[i].Value;
					}
				}
			}
			this.Text = "Edit GOOSE";			
		}
		
		/// <summary>
		/// This event saves the configuration of the GOOSE or GSE made.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		public void OkButtonClick(object sender, EventArgs e)
		{		
			String[] gsc = new String[7];
			gsc[0] = this.IdInst.Text;
			gsc[1] = this.cbName.Text;
			gsc[2] = this.mac.Text;
			gsc[3] = this.appId.Text;
			gsc[4] = this.vLANP.Text;
			gsc[5] = this.vLANI.Text;
			gsc[6] = this.desc.Text;				
			if(this.editWindow == true)
			{				
				//GSEHandler(node, this.oldGSEName, gsc, this.gseProperty.SelectedObject);
				this.UpdateGSE ();
				this.editWindow = false;
			}
			else
			{
				//GSEHandler(node, gsc, gseProperty.SelectedObject);
				this.AddGSE ();
			}			
			this.Close();
		}	
	
		/// <summary>
		/// This event cancel the changes made on the configuration.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void CancelBtnClick(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		/// <summary>
		/// This method Edit a GSEControl shows the information to edit all values pre-configured for GSE and GSEControl classes.
		/// </summary>
		/// <param name="treeSCL">
		/// TreeNode reference
		/// </param>
		/// <param name="gseName">
		/// Name of GSE to modify
		/// </param>
		/// <param name="gsc">
		/// Array of GSEControl values.
		/// </param>
		public  void UpdateGSE ()		
		{		
			this.gsec.datSet = this.datSet.SelectedItem.ToString();
			node.TreeView.SelectedNode.Tag = this.gsec;
			node.TreeView.SelectedNode.Text = this.gsec.name;
			tGSE gse = (tGSE) tvscl.GetGSENode (ied.name, ap.name, ld.inst, gsec.name).Tag;
			
			gse.desc = this.desc.Text;
			if (gse.Address == null)
				gse.InitAddess ();
			if (gse.Address != null && gse.Address.P != null) {
				for (int i = 0; i < gse.Address.P.Length; i++) {
					if (gse.Address.P[i].typeEnum == tPTypeEnum.MAC_Address)
						gse.Address.P[i].Value = this.mac.Text;
					if (gse.Address.P[i].typeEnum == tPTypeEnum.APPID)
						gse.Address.P[i].Value = this.appId.Text;
					if (gse.Address.P[i].typeEnum == tPTypeEnum.VLAN_PRIORITY)
						gse.Address.P[i].Value = this.vLANP.Text ;
					if (gse.Address.P[i].typeEnum == tPTypeEnum.VLAN_ID)
						gse.Address.P[i].Value = this.vLANI.Text;
				}
			}
			gse.cbName = this.cbName.Text;
		    this.gsec.name = this.cbName.Text;
		}				
		
		/// <summary>
		/// This method Adds a new Node. shows the information to edit all values pre-configured for GSE and GSEControl classes.
		/// </summary>
		/// <param name="treeSCL">
		/// TreeNode reference.
		/// </param>
		/// <param name="gsc">
		/// Array of GSEControl values
		/// </param>		
		public void AddGSE ()
		{
			// Add a GSEControl to IED
			tGSEControl cgse = new tGSEControl ();
			cgse.name = this.cbName.Text;
			cgse.appID = this.appId.Text;
			cgse.desc = this.desc.Text;
			cgse.type = tGSEControlTypeEnum.GOOSE;
			cgse.datSet = this.datSet.SelectedItem.ToString ();
			ld.LN0.AddGSEControl (cgse);
			if (!this.tvscl.AddGSEControlNode (ied.name, ap.name, ld.inst, cgse))
			{
				MessageBox.Show("Can't update Tree for new GSEControl", 
						                "Adding a New GOOSE",
						                MessageBoxButtons.OK,
						                MessageBoxIcon.Error);
			}
			// Add a GSE to Network
			tGSE gse = new tGSE ();
			gse.cbName = cgse.name;
			gse.desc = cgse.desc;
			gse.ldInst = ld.inst;
			gse.InitAddess ();
			if (gse.Address != null && gse.Address.P != null) {
				for (int i = 0; i < gse.Address.P.Length; i++) {
					if (gse.Address.P[i].typeEnum == tPTypeEnum.MAC_Address)
						gse.Address.P[i].Value = this.mac.Text;
					if (gse.Address.P[i].typeEnum == tPTypeEnum.APPID)
						gse.Address.P[i].Value = this.appId.Text;
					if (gse.Address.P[i].typeEnum == tPTypeEnum.VLAN_PRIORITY)
						gse.Address.P[i].Value = this.vLANP.Text ;
					if (gse.Address.P[i].typeEnum == tPTypeEnum.VLAN_ID)
						gse.Address.P[i].Value = this.vLANI.Text;
				}
			}
			int iedindex = this.scl.GetIED (ied.name);
			var lcap = this.scl.GetIEDConnectedAP (iedindex);
			for (int i = 0; i < lcap.Count; i++) {
				IEDConnectedAP iap = (IEDConnectedAP) lcap[i];
				tConnectedAP cap = this.scl.GetConnectedAP (iap.subnetwork, iap.connectedap);
				if (cap.apName.Equals (ap.name)
				    && cap.iedName.Equals (ied.name)) {
					cap.AddGSE (gse);
					System.Console.WriteLine ("Adding a new GSE Node...");
					if (!this.tvscl.AddGSENode (ied.name, ap.name, ld.inst, gse))
					{
						MessageBox.Show("Can't update Tree new GSE", 
								                "Adding a New GOOSE",
								                MessageBoxButtons.OK,
								                MessageBoxIcon.Error);
					}
				}
			}
		}		
	}
}
