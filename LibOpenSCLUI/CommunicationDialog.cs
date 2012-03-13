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
	/// Description of CommunicationDialog.
	/// </summary>
	public partial class CommunicationDialog : Form
	{
		private TreeNode treeSCL;
		private SCL scl;
		private string iedName;
		private string apName;	
		private ObjectManagement objectManagement = new ObjectManagement();
		private	TreeNode nodeComm = new TreeNode();
		private	TreeNode nodeSubNetwork = new TreeNode();
		private	TreeNode nodetSubNetwork = new TreeNode();
		private	TreeNode nodeConnected = new TreeNode();
		private	TreeNode nodetConnected = new TreeNode();	
		private tConnectedAP connap = new tConnectedAP();		
		private tAddress address = new tAddress();			
		private TreeNode nodeP = new TreeNode();
		private TreeViewSCL treeViewSCL = new TreeViewSCL();
		private TreeNode obj = new TreeNode();
		
		private void nameSubNetCBChange(object sender, System.EventArgs e)
		{	
			SCL sc = (SCL) this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Tag;
			if(sc.Communication!= null && sc.Communication.SubNetwork!=null)
			{
				this.obj = this.treeViewSCL.SeekAssociation(this.treeSCL
				                                            .TreeView.Nodes["root"].Nodes["SCL"]
				                                            .Nodes["tCommunication"].Nodes["tSubNetwork[]"]
				                                            .Nodes[this.nameSubNetCB.SelectedIndex].Nodes,
				                                            this.apName, this.iedName);
				loadValues(obj);
				this.descSubNet.Text = sc.Communication.SubNetwork[this.nameSubNetCB.SelectedIndex].desc;
			}
		}
		/// <summary>
		/// This is a constructor method that displays a dialog box to provide 
		/// communication configuration.		
		/// </summary>
		/// <param name="treeSCL">
		/// Reference of a treeNode to the selected node in the treeview.
		/// </param>
		/// <param name="sCL"></param>
		/// <param name="iedName">
		/// IED's name that will configure his communication parameters.
		/// </param>
		/// <param name="apName">
		/// Access point name that will contain the subnetwork configured.
		/// </param>
		/// <param name="objFound">
		/// Contains a previous subnetwork's configuration of the IED selected.	
		/// </param>		
		public CommunicationDialog (TreeNode treeSCL, SCL sCL, string iedName, string apName, TreeNode objFound)
		{		
			InitializeComponent();		
			this.treeSCL = treeSCL;
			this.scl = sCL;
			this.iedName = iedName;
			this.apName = apName;	
			if(this.scl.Communication!= null && this.scl.Communication.SubNetwork!= null)
			{
				for(int i=0; i< this.scl.Communication.SubNetwork.Length; i++)
				{
					this.nameSubNetCB.Items.AddRange(new object[] {this.scl.Communication.SubNetwork[i].name});						
					if (objFound != null) 
					{
						if(this.objectManagement.FindVariable(objFound.Parent.Parent.Tag, "name").ToString() == this.scl.Communication.SubNetwork[i].name)
						{
							this.nameSubNetCB.SelectedIndex = i;
							this.descSubNet.Text = this.objectManagement.FindVariable(objFound.Parent.Parent.Tag, "desc").ToString();				
						}
					}	
					else
					{
						this.nameSubNetCB.SelectedIndex = 0;
					}
				}				
		    }					
			loadValues(objFound);
		}			
		
	   	/// <summary>
	   	/// This method allows configure a new subnetwork for the IED and accesspoint selected.
	   	/// </summary>
	   	/// <param name="sender">
   		/// Name of the object.
	   	/// </param>
	   	/// <param name="e">
	   	/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
	   	/// </param>
		void NewSubNetCheckedChanged (object sender, System.EventArgs e)
		{
			this.nameSubNetCB.Visible =! (this.newSubNet.Checked);
			this.newSubNet.Visible =! (this.newSubNet.Checked);
			this.nameSubNet.Visible = (this.newSubNet.Checked);
		}

		/// <summary>
		/// This event saves the configuration provided.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void btnOKClick(object sender, EventArgs e)
		{					
			if (newSubNet.Checked == false)
		 	{						
				CommunicationHandler(this.treeSCL, this.APnam.Text, this.iedNam.Text);
				nameSubNet.Text = nameSubNetCB.Text;				
				this.Close();
			}
			else
			{
				if(checkSubNames())
				{
					DrawCommunication();
					this.Close();
				}
			}
		 }		
		
		/// <summary>
		/// This event cancel the changes or a new information of communication.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void btnCancelClick(object sender, System.EventArgs e)
		{
			this.Close();
		}	

		/// <summary>
		/// This method load values to show them on the graphical objects in the dialog box.		
		/// </summary>
		/// <param name="objFound">
		/// Contains a previous subnetwork's configuration of the IED selected.	
		/// </param>			
		private void loadValues(TreeNode objFound)
		{						
			this.iedNam.Text = this.iedName;
			this.iedNam.Enabled = false;
			this.APnam.Text = this.apName;
			this.APnam.Enabled = false;		
			this.newSubNet.Checked = (this.nameSubNetCB.Text=="");		
			if (objFound != null && objFound.FirstNode != null)
			{								
				object arrayOf = objFound.FirstNode.Tag;
				tP[] arr = (tP[]) this.objectManagement.FindVariable(arrayOf, "P");					
				if(arr!=null && arr.Length>0)
				{
					this.ip.Text = this.objectManagement.GetTpValue(arr, "IP");
					this.mask.Text = this.objectManagement.GetTpValue(arr, "IP_SUBNET");//this.objectManagement.FindVariable(arr[1], "Value").ToString();
					this.gateway.Text = this.objectManagement.GetTpValue(arr, "IP_GATEWAY");//this.objectManagement.FindVariable(arr[2], "Value").ToString();
					this.tsel.Text = this.objectManagement.GetTpValue(arr, "OSI_TSEL");//this.objectManagement.FindVariable(arr[3], "Value").ToString();
					this.psel.Text = this.objectManagement.GetTpValue(arr, "OSI_PSEL");//this.objectManagement.FindVariable(arr[4], "Value").ToString();
					this.ssel.Text = this.objectManagement.GetTpValue(arr, "OSI_SSEL");//this.objectManagement.FindVariable(arr[5], "Value").ToString();
				}
			}			
		}
		
		/// <summary>
		/// This method verifies if the subnetwork's name exists.		
		/// </summary>
		/// <returns>
		/// If there is a match of the name, it returns a true value otherwise a false value is returned.
		/// </returns>
		private bool checkSubNames()
		{
			if (this.newSubNet.Checked) 
			{
				if(this.nameSubNet.Text=="")
				{
					MessageBox.Show("The name can't be empty!");
					return false;
				}
				else
				{
					for(int i=0; i<this.nameSubNetCB.Items.Count;i++)
					{
						if(this.nameSubNetCB.Items[i].ToString() == this.nameSubNet.Text)
						{
							MessageBox.Show("There is a SubNetwork with this name!!");							
							return false;							
						}
					}
				}			
			}
			return true;			
		}
		
		/// <summary>
		/// This method draws the Communication nodes on the main tree.
		/// </summary>
		private void DrawCommunication()
		{				
			// Add a tCommunication object to SCL
			if(this.scl.Communication == null)
			{				
				tCommunication communication = new tCommunication();
				this.scl.Communication = communication;
				nodeComm = new TreeNode();
				nodeComm.Name = "tCommunication";
				nodeComm.Tag = this.scl.Communication;
				nodeComm.Text = "tCommunication";				
				treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes.Add(nodeComm);
			}
			else
			{
				nodeComm = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"];
			}							
			// Add a Subnetwork
			if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"]==null)	
			{					
					nodeSubNetwork = new TreeNode();
					nodeSubNetwork.Name = "tSubNetwork[]";
					nodeSubNetwork.Tag = this.scl.Communication.SubNetwork;
					nodeSubNetwork.Text = "SubNetwork";
					treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes.Add(nodeSubNetwork);
			}
			else
			{
				nodeSubNetwork = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"];
			}												
			if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[this.nameSubNet.Text]==null && 
			   this.GetNodeName(nodeSubNetwork.Nodes, nameSubNet.Text, "name")==null)
			{						
				int sni = this.scl.Communication.AddSubNetwork(this.nameSubNet.Text, this.descSubNet.Text);
				if (sni >= 0) {
					nodetSubNetwork = new TreeNode();
					nodetSubNetwork.Name = this.scl.Communication.SubNetwork[sni].name; 
					nodetSubNetwork.Text = "tSubNetwork";
					nodetSubNetwork.Tag = this.scl.Communication.SubNetwork[sni];
					treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes.Add(nodetSubNetwork);
				}
				else {
					System.Windows.Forms.MessageBox.Show("Subnetwork couldn't be added. Verify if it already exist and try again",
					                                            "Subnetwork wasn't added",
					                                            System.Windows.Forms.MessageBoxButtons.OK,
					                                            System.Windows.Forms.MessageBoxIcon.Error);
				}
			}
			else
			{										
				nodetSubNetwork = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[this.GetNodeName(nodeSubNetwork.Nodes, nameSubNet.Text, "name")];
			}	
			if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[nodetSubNetwork.Name].Nodes["tConnectedAP[]"]==null)
			{
				nodeComm = new TreeNode();			
				nodeComm.Name = "tConnectedAP[]";
				nodeComm.Tag = this.scl.Communication.SubNetwork[nodetSubNetwork.Index].ConnectedAP;
				nodeComm.Text = "ConnectedAP";
				treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"]
						.Nodes["tSubNetwork[]"].Nodes[nodetSubNetwork.Name].Nodes.Add(nodeComm);
			}
			else
			{
				nodeComm = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[nodetSubNetwork.Name].Nodes["tConnectedAP[]"];
			}
											
			this.treeViewSCL = new TreeViewSCL();
			connap.apName = this.apName;
			connap.iedName = this.iedName;				
			if(this.treeViewSCL.SeekAssociation(this.treeSCL.TreeView.Nodes["root"]
			                                    .Nodes["SCL"].Nodes["tCommunication"]
			                                    .Nodes["tSubNetwork[]"].Nodes[nodetSubNetwork.Name]
			                                    .Nodes,this.apName, this.iedName)==null)
			{
				// Create tAddress				
				tP[] tp = new tP[6];
				tP_IP _ip = new tP_IP();
				_ip.Value = this.ip.Text;
				tp[0] = _ip;
				
				tP_IPSUBNET _subnet = new tP_IPSUBNET();
				_subnet.Value = this.mask.Text;
				tp[1] = _subnet;
				
				tP_IPGATEWAY _gate = new tP_IPGATEWAY();
				_gate.Value = this.gateway.Text;
				tp[2] = _gate;
				
				tP_OSITSEL _tsel = new tP_OSITSEL();
				_tsel.Value = this.tsel.Text;
				tp[3] = _tsel;
				
				tP_OSISSEL _ssel = new tP_OSISSEL();
				_ssel.Value = this.ssel.Text;
				tp[4] = _ssel;
				
				tP_OSIPSEL _psel = new tP_OSIPSEL();
				_psel.Value = this.psel.Text;
				tp[5] = _psel;
				
				tAddress addr = new tAddress();
				addr.P = tp;
				
				tIED ied = this.scl.IED[this.scl.GetIED(this.iedName)];
				int api = ied.GetAP(this.apName);
				int capi = this.scl.Communication
							.SubNetwork[nodetSubNetwork.Index].AddConnectedAP(ied, api, addr, null);
				if (capi >= 0) {
					AttributeReferences refe = new AttributeReferences();
					nodetConnected = new TreeNode();			
					nodetConnected.Name = "tConnectedAP"+this.iedName+this.apName;
					nodetConnected.Tag = this.scl.Communication.SubNetwork[nodetSubNetwork.Index].ConnectedAP[capi];
					nodetConnected.Text = "tConnectedAP";
					treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"]
								.Nodes["tSubNetwork[]"].Nodes[nodetSubNetwork.Name]
								.Nodes["tConnectedAP[]"].Nodes.Add(nodetConnected);
					refe.Insert(this.scl.Communication.SubNetwork[nodetSubNetwork.Index].ConnectedAP[capi],
					            this.treeSCL.TreeView.SelectedNode);
					
					// Add Nodes for tAddress and tP
					TreeNode nodeAddress = new TreeNode();
					nodeAddress.Name = "Adress";
					nodeAddress.Tag = address;
					nodeAddress.Text = "Address";
					treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"]
								.Nodes["tSubNetwork[]"].Nodes[nodetSubNetwork.Name]
								.Nodes["tConnectedAP[]"].Nodes[nodetConnected.Name].Nodes.Add(nodeAddress);											
					nodeP.Name = "tP[]";
					nodeP.Text = "P";
					treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"]
								.Nodes["tSubNetwork[]"].Nodes[nodetSubNetwork.Name]
								.Nodes["tConnectedAP[]"].Nodes[nodetConnected.Name]
								.Nodes["Adress"].Nodes.Add(nodeP);				
					
					Utils.AddTPTreeNode(_ip, nodeP);
					Utils.AddTPTreeNode(_subnet, nodeP);
					Utils.AddTPTreeNode(_gate, nodeP);
					Utils.AddTPTreeNode(_tsel, nodeP);
					Utils.AddTPTreeNode(_psel, nodeP);
					Utils.AddTPTreeNode(_ssel, nodeP);
				}
				else
					System.Windows.Forms.MessageBox.Show("ConnectedAP couldn't be added. Verify if it already exist and try again",
					                                            "ConnectedAP wasn't added",
					                                            System.Windows.Forms.MessageBoxButtons.OK,
					                                            System.Windows.Forms.MessageBoxIcon.Error);
			}
			else
			{
				nodetConnected = this.treeViewSCL.SeekAssociation(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[nodetSubNetwork.Name].Nodes["tConnectedAP[]"].Nodes, this.apName, this.iedName, "apName", "iedName");
			}
		}						
		
		/// <summary>
		/// This method look for an specific value in the treeNode.
		/// </summary>
		/// <param name="nodes">
		/// TreenodeCollection for specific seek.
		/// </param>
		/// <param name="nameOfSub">
		/// Subnetwork name that will be the value to seek
		/// </param>
		/// <param name="var">
		/// Variable's name to look for.
		/// </param>
		/// <returns>
		/// If there is a match then it returns the founded value otherwise it reurns a null value.
		/// </returns>
		private string GetNodeName(TreeNodeCollection nodes, string nameOfSub, string var)
		{
			string nameOf;
			foreach (TreeNode n in nodes)
            {         
				nameOf  = (string)this.objectManagement.FindVariable(n.Tag, var);
				if(nameOfSub == nameOf)
				{
					return n.Name;
				}
            }
			return nameOf = null;
		}

		/// <summary>
		/// This method shows the information to edit all values pre-configured for 
		/// subnetwork, connectedAP and tps
		/// </summary>
		/// <param name="treeSCL">
		/// TreeNode reference
		/// </param>
		/// <param name="apParentName">
		/// Name of Access Point where belongs the communication configurations.
		/// </param>
		/// <param name="iedParentName">
		/// Name of IED where belongs the communication configurations.
		/// </param>
		private void CommunicationHandler(TreeNode treeSCL, string apParentName, string iedParentName)
		{	
			tConnectedAP tconn = new tConnectedAP();
			tSubNetwork tsub = new tSubNetwork();
			tsub.desc = this.descSubNet.Text;
			String[] comm = new String[6];
			String[] names = new String[6];
			this.nameSubNet.Text = this.nameSubNetCB.SelectedItem.ToString();
			tsub.name = this.nameSubNet.Text;
			comm[0] = this.ip.Text;
			comm[1] = this.mask.Text;
			comm[2] = this.gateway.Text;
			comm[3]= this.tsel.Text;
			comm[4] = this.psel.Text;
			comm[5] = this.ssel.Text;
			names[0] = "IP";
			names[1] = "IP_SUBNET";
			names[2] = "IP_GATEWAY";
			names[3] = "OSI_TSEL";
			names[4] = "OSI_PSEL";
			names[5] = "OSI_SSEL";
			for(int i=0; i<this.scl.Communication.SubNetwork.Length; i++)
			{
				   if(this.scl.Communication.SubNetwork[i].name == this.nameSubNetCB.SelectedItem.ToString())
				{ 
					this.scl.Communication.SubNetwork[i].name = this.nameSubNet.Text;
					this.scl.Communication.SubNetwork[i].desc = this.descSubNet.Text;	
					TreeNode connected = this.treeViewSCL.SeekAssociation(treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[i].Nodes, apParentName, iedParentName, "apName", "iedName");
					if(connected!=null)
					{
						tconn = (tConnectedAP) connected.Tag;
						tconn.iedName = iedParentName;
						tconn.apName = apParentName;
						if(this.objectManagement.ModifyObjectOfArrayObjectOfParentObject(tconn, connected.Index, connected.Parent.Parent.Tag))
						{
							if(connected.FirstNode!=null)
							{
								object arrayOf = connected.FirstNode.Tag;
								tP[] arr = (tP[]) this.objectManagement.FindVariable(arrayOf, "P");
								tAddress tad = new tAddress();
								tconn.Address = tad;
								tconn.Address.P = arr;
								connected.Tag = tconn;
								if(arr!=null)
								{
									for(int j=0; j<arr.Length;j++)
									{
										for(int k =0; k<names.Length; k++)
										{
											if(arr[j].type.ToString() == names[k])
											{
												arr[j].Value = comm[k].ToString();	
											}	
										}
									}	
									this.objectManagement.ModifyObjectOfArrayObjectOfParentObject((tP[]) arr, 0, tconn.Address.P);
								}
								else
								{
									DrawCommunication();
								}
							}
							else
							{
								DrawCommunication();
							}
						}
					}
					else
					{
						DrawCommunication();
					}
				}
			}									
		}									
	}
}
