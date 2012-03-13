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
		private string oldGSEName;
		private bool editWindow = false;
		private TreeNode node;
		
		/// <summary>
		/// This method shows a dialog box that allows to create a GOOSE or GSE configuration
		/// </summary>
		/// <param name="ldInst">
		/// LDevice instance
		/// </param>
		/// <param name="treeSCL">
		/// TreeNode reference
		/// </param>
		/// <param name="apParentName">
		/// Name of Access point where configuration will be added according to the LN0 selected.
		/// </param>
		/// <param name="iedParentName">
		/// Name of IED where configuration will be added according to the LN0 selected.
		/// </param>
		public GSEDialog(TreeNode node, OpenSCL.Object scl, tIED ied, tAccessPoint ap, tLDevice ld)
		{
			this.scl = scl;
			this.ied = ied;
			this.ap = ap;
			this.ld = ld;
			this.node = node;
			
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
		public GSEDialog (TreeNode node, OpenSCL.Object scl, tIED ied, tAccessPoint ap,   
		                 tLDevice ld, tGSEControl gc)
		{
			this.editWindow = true;
			this.scl = scl;
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
				tGSE gse = (tGSE) hgse["gse"];
				this.cbName.Text = gse.cbName;
			    this.desc2.Text = gse.desc;
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
			gsc[6] = this.desc2.Text;				
			if(this.editWindow == true)
			{				
				//GSEHandler(node, this.oldGSEName, gsc, this.gseProperty.SelectedObject);
				this.editWindow = false;
			}
			else
			{
				//GSEHandler(node, gsc, gseProperty.SelectedObject);
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
		public  void GSEHandler(TreeNode treeSCL, string gseName, string[] gsc, object objectgse)		
		{		
			this.gsec.datSet = this.datSet.SelectedItem.ToString();
			node.TreeView.SelectedNode.Tag = this.gsec;
			node.TreeView.SelectedNode.Text = this.gsec.name;	
//			
//			String[] names = new String[4];
//			names[0] = "MAC_Address";
//			names[1] = "APPID";
//			names[2] = "VLAN_PRIORITY";
//			names[3] = "VLAN_ID";
//			if(this.scl.Communication!=null)
//			{
//				TreeNode Conn = this.treeViewSCL.SeekAssociation(treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes, 
//			                this.objectManagement.FindVariable(
//				            this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(treeSCL.TreeView.SelectedNode, typeof(tAccessPoint)).Tag, "name").ToString(),
//			                this.objectManagement.FindVariable(
//							this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(treeSCL.TreeView.SelectedNode, typeof(tIED)).Tag, "name").ToString());
//				if(this.scl.Communication.SubNetwork!=null && Conn != null)
//				{
//					for(int i=0; i<sCL.Communication.SubNetwork.Length; i++)
//					{
//						treeViewSCL = new TreeViewSCL();
//						TreeNode gseN = treeViewSCL.SeekAssociation(treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[i].Nodes, gseName ,"cbName", "tGSE");				
//						TreeNode newGSE = gseN;
//						if(gseN!=null)
//						{
//							TreeNode parentGSE = gseN.Parent;
//							tGSE tgse = (tGSE) gseN.Tag;
//							tgse.ldInst = gsc[0];
//							tgse.cbName = tgseC.name;
//							tgse.desc = gsc[6];			
//							if(this.objectManagement.ModifyObjectOfArrayObjectOfParentObject(tgse, gseN.Index, gseN.Parent.Parent.Tag))
//							{
//								if(gseN.FirstNode!=null)
//								{
//									object arrayOf = gseN.FirstNode.Tag;
//									tP[] arr = (tP[]) this.objectManagement.FindVariable(arrayOf, "P");
//									tAddress tad = new tAddress();
//									tgse.Address = tad;
//									if(arr!=null)
//									{
//										for(int x=0; x<arr.Length; x++)
//										{
//											for(int y=0; y<names.Length;y++)
//											{
//												if(arr[x].type.ToString() == names[y])
//												{
//													arr[x].Value = gsc[x+2].ToString();	
//												}
//											}
//										}
//										tgse.Address.P = (tP[]) arr;
//										gseN.Tag = tgse;
//										gseN.Text = tgse.cbName;	
//										if(this.objectManagement.ModifyObjectOfArrayObjectOfParentObject((tP[]) arr, 0, tgse.Address.P))
//										{									
//										}
//									}
//								}
//							}																													
//						}
//					}
//				}
//				else
//				{
//					GSEHandler(treeSCL, gsc, objectgse);
//				}
//			} 
//			else
//				{
//					GSEHandler(treeSCL, gsc, objectgse);
//				}
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
		public void GSEHandler(TreeNode treeSCL, string[] gsc, object objectgse)
		{
//			tGSEControl gs = (tGSEControl) objectgse;
//			gs.datSet = this.datSet.SelectedItem.ToString();
//			SCL sCL = (SCL) treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Tag;
//			TreeNode nodetGSECtrl = new TreeNode();
//			nodetGSECtrl.Name = gs.name; 
//			nodetGSECtrl.Text = gs.name;
//			nodetGSECtrl.Tag = gs;
//			tGSE tGse = new tGSE();
//			tGse.cbName = gs.name;		
//			if(this.objectManagement.AddObjectToArrayObjectOfParentObject(gs, treeSCL.Tag))
//			{
//				if(treeSCL.TreeView.SelectedNode.Tag is tLN0)
//				{
//					tLN0 ln0 = (tLN0) treeSCL.Tag;
//					TreeNode parentGSE = new TreeNode();
//					parentGSE.Name = "tGSEControl[]"; 
//					parentGSE.Text = "GSEControl";
//					parentGSE.Tag = ln0.GSEControl;
//					treeSCL.Nodes.Add(parentGSE);
//					treeSCL = parentGSE;
//				}
//				else
//				{
//					treeSCL = treeSCL.TreeView.SelectedNode;
//				}				
//				treeSCL.Nodes.Add(nodetGSECtrl);
//			}			
//			treeViewSCL.CreateCommNode(sCL, treeSCL);	
//			TreeNode connAPRef = new TreeNode();			
//			for(int i=0; i<sCL.Communication.SubNetwork.Length; i++)
//			{
//				this.treeViewSCL = new TreeViewSCL();
//				connAPRef = treeViewSCL.SeekAssociation(treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[i].Nodes, apName, iedName, "apName", "iedName");			
//				if(connAPRef == null && sCL.Communication.SubNetwork[i].ConnectedAP==null)
//				{
//					treeViewSCL.CreateConnectedNode(sCL, treeSCL, apName, iedName, i);											
//					connAPRef = treeViewSCL.SeekAssociation(treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[i].Nodes, apName, iedName, "apName", "iedName");																
//				}	
//				if(connAPRef != null)
//				{
//					tGse.cbName = gs.name;
//					tGse.ldInst = gsc[0];
//					tGse.desc = gsc[6];								
//					TreeNode nodeGSE = new TreeNode();	
//					this.objectManagement.AddObjectToArrayObjectOfParentObject(tGse, connAPRef.Tag);					
//					if(connAPRef.Nodes["tGSE[]"]==null)
//					{								
//						tConnectedAP tConnectAP = (tConnectedAP) connAPRef.Tag;
//						nodeGSE.Text = "GSE";
//						nodeGSE.Name = "tGSE[]";
//						nodeGSE.Tag = tConnectAP.GSE;
//						connAPRef.Nodes.Add(nodeGSE);
//					}
//					else
//					{
//						nodeGSE = connAPRef.Nodes["tGSE[]"];
//					}		
//					TreeNode nodetGSE = new TreeNode();
//					nodetGSE.Text = gs.name;
//					nodetGSE.Name = gsc[0]+"."+gs.name;
//					nodetGSE.Tag  = tGse;
//					nodeGSE.Nodes.Add(nodetGSE);					
//					AttributeReferences aReferences = new AttributeReferences();
//					aReferences.Insert(tGse, nodetGSECtrl);
//					tAddress taddr = new tAddress();
//					this.objectManagement.AddObjectToSCLObject(taddr, tGse);
//					TreeNode nodeAddress = new TreeNode();
//					nodeAddress.Text = "Address";
//					nodeAddress.Name = "Address";
//					nodeAddress.Tag  = taddr;
//					nodetGSE.Nodes.Add(nodeAddress);										
//					Utils utilsOM = new Utils();
//					TreeNode nodeP = new TreeNode();
//					nodeP.Name = "tP[]";
//					nodeP.Text = "P";
//					nodeAddress.Nodes.Add(nodeP);
//										
//					tP t_mac = new tP();
//					tP_MACAddress t_mac_ = new tP_MACAddress();
//					this.objectManagement.EmptySourcetoDestinyObject(t_mac_,t_mac);
//					t_mac.Value = this.mac.Text;
//					utilsOM.AddTPTreeNode(t_mac, "tP_mac", "tP", taddr, nodeP);
//					
//					tP t_app = new tP();
//					tP_APPID  t_app_ = new tP_APPID();
//					this.objectManagement.EmptySourcetoDestinyObject(t_app_, t_app);
//					t_app.Value = this.appId.Text;
//					utilsOM.AddTPTreeNode(t_app, "tP_app", "tP", taddr, nodeP);
//		
//					tP t_vlap = new tP();
//					tP_VLANPRIORITY t_vlap_ = new tP_VLANPRIORITY();
//					this.objectManagement.EmptySourcetoDestinyObject(t_vlap_,t_vlap);
//					t_vlap.Value = this.vLANP.Text;
//					utilsOM.AddTPTreeNode(t_vlap, "tP_vlanp", "tP", taddr, nodeP);
//						
//					tP t_vlani = new tP();
//					tP_VLANID t_vlani_ = new tP_VLANID();
//					this.objectManagement.EmptySourcetoDestinyObject(t_vlani_,t_vlani);
//					t_vlani.Value = this.vLANI.Text;
//					utilsOM.AddTPTreeNode(t_vlani, "tP_vlani", "tP", taddr, nodeP);
//				}
//			}
		}		
	}
}
