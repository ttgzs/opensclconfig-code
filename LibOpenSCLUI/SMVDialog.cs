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
	/// Description of SMVWindow.
	/// </summary>
	public partial class SMVDialog : Form
	{
		private TreeNode treeSCL;		
		private string apParentName;
		private string iedParentName;
		private string oldSMVName;		
		private bool edit = false;		 
		private TreeViewSCL treeViewSCL = new TreeViewSCL();
		private ObjectManagement objectManagement = new ObjectManagement();
		
		/// <summary>
		/// This method shows a dialog box that allows to create a Sampled Value (SMV) configuration
		/// </summary>
		/// <param name="ldInst">
		/// LDevice instance
		/// </param>
		/// <param name="apNameParent">
		/// Name of Access point where configuration will be added according to the LN0 selected.
		/// </param>
		/// <param name="iedNameParent">
		/// Name of IED where configuration will be added according to the LN0 selected.
		/// </param>
		/// <param name="treeSCL">
		/// TreeNode reference
		/// </param>
		public SMVDialog(string ldInst, string apParentName, string iedParentName, TreeNode treeSCL)
		{
			this.treeSCL = treeSCL;
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();
			this.datSet.DataSource = this.treeViewSCL.getDataset(this.treeSCL);//victor
			tSampledValueControl tSMCCtrl = new tSampledValueControl();
			this.propertySMV.SelectedObject = tSMCCtrl;
			tSampledValueControlSmvOpts tSmVOpts = new tSampledValueControlSmvOpts();
			this.propertyOptions.SelectedObject = tSmVOpts;
			this.ldInst.Text = ldInst;
			this.ldInst.Enabled = false;
			this.apParentName = apParentName;
			this.iedParentName = iedParentName;
			this.Text = "New Sampled Value";
		}
		
		/// <summary>
		/// This method shows a dialog box that allows to edit a SMV configuration
		/// </summary>
		/// <param name="treeSCL">
		/// TreeNode reference
		/// </param>
		/// <param name="apParentName">
		/// Name of Access point where configuration will be added according to the LN0 selected.
		/// </param>
		/// <param name="iedParentName">
		/// Name of IED where configuration will be added according to the LN0 selected.
		/// </param>
		/// <param name="smvObject">
		/// Object that contains the information of SMV class
		/// </param>
		/// <param name="optObject">
		/// Object that contains the information of SMV options class
		/// </param>
		public SMVDialog(TreeNode treeSCL, string apParentName, string iedParentName, object smvObject, object optObject, string ldInst)
		{			
			SCL sCL = (SCL)treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Tag;
			this.edit = true;
			this.treeSCL = treeSCL;
			this.apParentName = apParentName;
			this.iedParentName = iedParentName;
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();
			this.datSet.DataSource = this.treeViewSCL.getDataset(this.treeSCL);//victor
			this.datSet.SelectedIndex = this.treeViewSCL.getDataSetSelected(treeSCL, smvObject);//victor
			this.oldSMVName = this.objectManagement.FindVariable(this.treeSCL.TreeView.SelectedNode.Tag, "name").ToString();			
			this.propertySMV.SelectedObject = smvObject;
			this.propertyOptions.SelectedObject = optObject;
			TreeNode smvNode = null;
			if(sCL.Communication != null)
			{
				this.treeViewSCL = new TreeViewSCL();
				smvNode = this.treeViewSCL.SeekAssociation(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes, this.objectManagement.FindVariable(smvObject, "name").ToString(), "cbName", "tSMV" );
			}
			tSMV tsmv = new tSMV();			
			this.ldInst.Enabled = false;			
			this.ldInst.Text = ldInst;
			if(smvNode!= null)
			{
				this.desc.Text  = this.objectManagement.FindVariable(smvNode.Tag, "desc").ToString();						
				if(smvNode.FirstNode!=null)
				{	
					object arrayOf = smvNode.FirstNode.Tag;
					tP[] arr = (tP[]) this.objectManagement.FindVariable(arrayOf, "P");
					if(arr!=null)
					{
						if(arr.Length>0)
						{
							this.mac.Text    = this.objectManagement.GetTpValue(arr, "MAC_Address");
							this.appID.Text  = this.objectManagement.GetTpValue(arr, "APPID");
							this.vLANP.Text  = this.objectManagement.GetTpValue(arr, "VLAN_PRIORITY");
							this.vLANI.Text  = this.objectManagement.GetTpValue(arr, "VLAN_ID");
						}	
					}
				}
			}
			this.Text = "Edit Sampled Value";				
		}
		
		/// <summary>
		///  This event saves the configuration of the SMV made.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		private void BtnOKSMVClick(object sender, System.EventArgs e)
		{
			string[] smv = new string[6];
			smv[0] = this.ldInst.Text ;
			smv[1] = this.mac.Text;
			smv[2] = this.appID.Text;
			smv[3] = this.vLANP.Text;
			smv[4] = this.vLANI.Text;
			smv[5] = this.desc.Text;				
			if(this.edit == true)
			{ 
				SMVHandler(this.treeSCL, this.propertySMV.SelectedObject, this.propertyOptions.SelectedObject, smv, this.oldSMVName);						
				this.edit = false;
			}
			else
			{
				SMVHandler(this.propertySMV.SelectedObject, this.propertyOptions.SelectedObject, smv, this.treeSCL);
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
		/// This method shows the information to edit all values pre-configured for SMV, 
		/// SMVControl and SMVoptions classes.
		/// </summary>
		/// <param name="treeSCL">
		/// TreeNode reference
		/// </param>
		/// <param name="smvc">
		/// Sampled Value Controls class.
		/// </param>
		/// <param name="smvopt">
		/// Sampled Value Options class.
		/// </param>
		/// <param name="smv">
		/// Sampled Value class.
		/// </param>
		/// <param name="oldSMVName">
		/// Control block Name of the SMV.
		/// </param>		
		public void SMVHandler(TreeNode treeSCL, object smvc, object smvopt, string[] smv, string oldSMVName)
		{	
			SCL sCL = (SCL) treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Tag;							
			tSampledValueControl tsmvc = (tSampledValueControl) smvc;
			tsmvc = (tSampledValueControl) smvc;				
			tSampledValueControlSmvOpts tsmvco = (tSampledValueControlSmvOpts) smvopt;			
			tsmvco = (tSampledValueControlSmvOpts) smvopt;				
			this.objectManagement.ModifyObjectOfArrayObjectOfParentObject(tsmvc, treeSCL.TreeView.SelectedNode.Index, treeSCL.TreeView.SelectedNode.Parent.Parent.Tag);			
			treeSCL.TreeView.SelectedNode.Tag = tsmvc;
			treeSCL.TreeView.SelectedNode.Text = tsmvc.name;						
			String[] names = new String[4];
			names[0] = "MAC_Address";
			names[1] = "APPID";
			names[2] = "VLAN_PRIORITY";
			names[3] = "VLAN_ID";
			if(sCL.Communication!=null)
			{
				TreeNode Conn = this.treeViewSCL.SeekAssociation(treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes, 
			                this.objectManagement.FindVariable(
				            this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(treeSCL.TreeView.SelectedNode, typeof(tAccessPoint)).Tag, "name").ToString(),
			                this.objectManagement.FindVariable(
							this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(treeSCL.TreeView.SelectedNode, typeof(tIED)).Tag, "name").ToString());
				if(sCL.Communication.SubNetwork!=null && Conn != null)
				{
					for(int i=0; i<sCL.Communication.SubNetwork.Length; i++)
					{
						TreeNode smvN = treeViewSCL.SeekAssociation(treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[i].Nodes, oldSMVName ,"cbName", "tSMV");				
						TreeNode newSMV = smvN;
						if(smvN!=null)
						{
							tSMV tsmv = (tSMV) smvN.Tag;
							tsmv.ldInst = smv[0];
							tsmv.cbName = tsmvc.name;			
							tsmv.desc = smv[5];	
							tsmvc.datSet = this.datSet.SelectedItem.ToString();//victor
							if(this.objectManagement.ModifyObjectOfArrayObjectOfParentObject(tsmv, smvN.Index, smvN.Parent.Parent.Tag))
							{
								if(smvN.FirstNode!=null)
								{
									object arrayOf = smvN.FirstNode.Tag;
									tP[] arr = (tP[]) this.objectManagement.FindVariable(arrayOf, "P");
									tAddress tad = new tAddress();
									tsmv.Address = tad;		
									if(arr!=null)
									{
										for(int x=0; x<arr.Length; x++)
										{
											for(int y=0; y<names.Length;y++)
											{
												if(arr[x].type.ToString() == names[y])
												{
													arr[x].Value = smv[y+1].ToString();	
												}
											}
										}
									}
									tsmv.Address.P = (tP[]) arr;
									smvN.Tag = tsmv;
									smvN.Text = tsmv.cbName;	
									if(this.objectManagement.ModifyObjectOfArrayObjectOfParentObject((tP[]) arr, 0, tsmv.Address.P))
									{									
									}	
				}
			}									
						}
					}
				}
				else
				{
					SMVHandler(tsmvc, tsmvco, smv, treeSCL);
				}
			}
			else
			{
				SMVHandler(tsmvc, tsmvco, smv, treeSCL);
			}
		}
		
		/// <summary>
		/// This method shows the information to edit all values pre-configured for SMV, 
		/// SMVControl and SMVoptions classes.
		/// </summary>
		/// <param name="sMVControl">
		/// Sampled Value Controls class.
		/// </param>
		/// <param name="sMVOptions">
		/// Sampled Value Options class.
		/// </param>
		/// <param name="smv">
		/// Sampled Value class.
		/// </param>
		/// <param name="treeSCL">
		/// TreeNode reference
		/// </param>
		public void SMVHandler(object sMVControl, object sMVOptions, string[] smv, TreeNode treeSCL)
		{
			tSampledValueControl sMVCtrl = (tSampledValueControl) sMVControl; 
			sMVCtrl.datSet = this.datSet.SelectedItem.ToString();
			SCL sCL = (SCL) treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Tag;
			tSampledValueControlSmvOpts sMVOpts = (tSampledValueControlSmvOpts) sMVOptions;
			TreeNode nodeSMVControl = new TreeNode();
			TreeNode nodeSMV;
			nodeSMVControl.Name = sMVCtrl.name;
			nodeSMVControl.Text = sMVCtrl.name;
			nodeSMVControl.Tag = sMVCtrl;
			TreeNode nodetSMV;		
			tSMV tsmv = new tSMV();			
			if(this.objectManagement.AddObjectToArrayObjectOfParentObject(sMVCtrl, treeSCL.Tag))
			{
				if(treeSCL.TreeView.SelectedNode.Tag is tLN0)
				{
					tLN0 ln0 = (tLN0) treeSCL.Tag;
					TreeNode parentSMV = new TreeNode();
					parentSMV .Name = "tSampledValueControl[]"; 
					parentSMV .Text = "SampledValueControl";
					parentSMV .Tag = ln0.SampledValueControl;
					treeSCL.Nodes.Add(parentSMV);
					treeSCL = parentSMV;
				}
				else
				{
					treeSCL = treeSCL.TreeView.SelectedNode;
				}				
				treeSCL.Nodes.Add(nodeSMVControl);				
				this.objectManagement.AddObjectToSCLObject(sMVOpts, sMVCtrl);							  	
				TreeNode nodeOP = new TreeNode();
				nodeOP.Name = "SMVOpts";
				nodeOP.Text = "SMVOpts";
				nodeOP.Tag  = sMVOpts;
				nodeSMVControl.Nodes.Add(nodeOP);
			}		
			treeViewSCL.CreateCommNode(sCL, treeSCL);			
			TreeNode connAPRef = new TreeNode();
			for(int i=0; i<sCL.Communication.SubNetwork.Length; i++)
			{
				connAPRef = treeViewSCL.SeekAssociation(treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[i].Nodes, apParentName, iedParentName, "apName", "iedName");			
				if(connAPRef == null && sCL.Communication.SubNetwork[i].ConnectedAP==null)
				{
					treeViewSCL.CreateConnectedNode(sCL, treeSCL, apParentName, iedParentName, i);										
					connAPRef = treeViewSCL.SeekAssociation(treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[i].Nodes, apParentName, iedParentName, "apName", "iedName");
				}			
				if(connAPRef != null)
				{
					tsmv.cbName = sMVCtrl.name;
					tsmv.ldInst = smv[0];
					tsmv.desc = smv[5];		
					nodeSMV = new TreeNode();				
					this.objectManagement.AddObjectToArrayObjectOfParentObject(tsmv, connAPRef.Tag);					
					if(connAPRef.Nodes["tSMV[]"]==null)
					{								
						tConnectedAP tconn = (tConnectedAP) connAPRef.Tag;
						nodeSMV.Text = "SMV";
						nodeSMV.Name = "tSMV[]";
						nodeSMV.Tag = tconn.SMV;
						connAPRef.Nodes.Add(nodeSMV);
					}
					else
					{
						nodeSMV = connAPRef.Nodes["tSMV[]"];
					}					
					nodetSMV = new TreeNode();
					nodetSMV.Text = sMVCtrl.name;
					nodetSMV.Name = smv[0]+"."+sMVCtrl.name;
					nodetSMV.Tag  = tsmv;
					nodeSMV.Nodes.Add(nodetSMV);	
					AttributeReferences aReferences = new AttributeReferences();
					aReferences.Insert(tsmv, nodeSMVControl);
					tAddress taddr = new tAddress();
					this.objectManagement.AddObjectToSCLObject(taddr, tsmv);
					TreeNode nodeAddress = new TreeNode();
					nodeAddress.Text = "Address";
					nodeAddress.Name = "Address";
					nodeAddress.Tag  = taddr;
					nodetSMV.Nodes.Add(nodeAddress);																				
					TreeNode nodetP = new TreeNode();
					nodetP.Name = "tP[]";
					nodetP.Text = "P";
					nodeAddress.Nodes.Add(nodetP);	
					Utils utilsOM = new Utils();
					
					tP t_mac = new tP();
					tP_MACAddress t_mac_ = new tP_MACAddress();
					this.objectManagement.EmptySourcetoDestinyObject(t_mac_,t_mac);
					t_mac.Value = this.mac.Text;
					utilsOM.AddTPTreeNode(t_mac, "tP_mac", "tP", taddr, nodetP);
					
					tP t_app = new tP();
					tP_APPID  t_app_ = new tP_APPID();
					this.objectManagement.EmptySourcetoDestinyObject(t_app_, t_app);
					t_app.Value = this.appID.Text;
					utilsOM.AddTPTreeNode(t_app, "tP_app", "tP", taddr, nodetP);
		
					tP t_vlap = new tP();
					tP_VLANPRIORITY t_vlap_ = new tP_VLANPRIORITY();
					this.objectManagement.EmptySourcetoDestinyObject(t_vlap_,t_vlap);
					t_vlap.Value = this.vLANP.Text;
					utilsOM.AddTPTreeNode(t_vlap, "tP_vlanp", "tP", taddr, nodetP);
						
					tP t_vlani = new tP();
					tP_VLANID t_vlani_ = new tP_VLANID();
					this.objectManagement.EmptySourcetoDestinyObject(t_vlani_,t_vlani);
					t_vlani.Value = this.vLANI.Text;
					utilsOM.AddTPTreeNode(t_vlani, "tP_vlani", "tP", taddr, nodetP);
				}
			}
		}		
	}
}
