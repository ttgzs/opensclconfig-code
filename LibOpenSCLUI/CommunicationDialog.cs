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
		private SCL sCL;
		private string iedName;
		private string apName;	
		private ObjectManagement objectManagement = new ObjectManagement();
		private Utils utilsOM = new Utils();
		private	TreeNode nodeComm = new TreeNode();
		private	TreeNode nodeSubNetwork = new TreeNode();
		private	TreeNode nodetSubNetwork = new TreeNode();
		private	TreeNode nodeConnected = new TreeNode();
		private	TreeNode nodetConnected = new TreeNode();	
		private tConnectedAP tConnected = new tConnectedAP();		
		private tAddress address = new tAddress();			
		private TreeNode nodeP = new TreeNode();
		private TreeViewSCL treeViewSCL = new TreeViewSCL();
		
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
		public CommunicationDialog(TreeNode treeSCL, SCL sCL, string iedName, string apName, TreeNode objFound)
		{		
			InitializeComponent();		
			this.treeSCL = treeSCL;
			this.sCL = sCL;
			this.iedName = iedName;
			this.apName = apName;	
			if(this.sCL.Communication!= null && this.sCL.Communication.SubNetwork!= null)
			{
				for(int i=0; i< this.sCL.Communication.SubNetwork.Length; i++)
				{
					this.nameSubNetCB.Items.AddRange(new object[] {this.sCL.Communication.SubNetwork[i].name});						
					if (objFound != null) 
					{
						if(this.objectManagement.FindVariable(objFound.Parent.Parent.Tag, "name").ToString() == this.sCL.Communication.SubNetwork[i].name)
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
		void NewSubNetCheckedChanged(object sender, System.EventArgs e)
		{
			this.nameSubNetCB.Visible =! (this.newSubNet.Checked);
			this.newSubNet.Visible =! (this.newSubNet.Checked);
			this.nameSubNet.Visible = (this.newSubNet.Checked);
			if (newSubNet.Checked)
			{
				this.descSubNet.Text = "";
				this.ip.Text = "";
				this.mask.Text = "";
				this.gateway.Text = "";
				this.tsel.Text = "";
				this.psel.Text = "";
				this.ssel.Text = "";
			}
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
				ExcludeNodes();						
				nameSubNet.Text = nameSubNetCB.Text;				
			}
			if(checkSubNames())
			{
				DrawCommunication();
				this.Close();
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
			if (objFound != null)
			{								
				object arrayOf = objFound.FirstNode.Tag;
				tP[] arr = (tP[]) this.objectManagement.FindVariable(arrayOf, "P");			
				this.ip.Text = this.objectManagement.FindVariable(arr[0], "Value").ToString();
				this.mask.Text = this.objectManagement.FindVariable(arr[1], "Value").ToString();
				this.gateway.Text = this.objectManagement.FindVariable(arr[2], "Value").ToString();
				this.tsel.Text = this.objectManagement.FindVariable(arr[3], "Value").ToString();
				this.psel.Text = this.objectManagement.FindVariable(arr[4], "Value").ToString();
				this.ssel.Text = this.objectManagement.FindVariable(arr[5], "Value").ToString();	
			}			
		}
		
		/// <summary>
		/// This method verifies if the subnetwork's name exists.		
		/// </summary>
		/// <returns>
		/// If there is a match of the name, it returns a true value otherwise a false value is returned.
		/// </returns>
		public bool checkSubNames()
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
		public void DrawCommunication()
		{				
			tConnected.apName = this.apName;
			tConnected.iedName = this.iedName;				
			if(this.sCL.Communication == null)
			{				
				tCommunication communication = new tCommunication();
				this.objectManagement.AddObjectToSCLObject(communication , this.sCL);
				nodeComm = new TreeNode();				
				nodeComm.Name = "tCommunication";
				nodeComm.Tag = this.sCL.Communication;
				nodeComm.Text = "tCommunication";				
				treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes.Add(nodeComm);
			}
			else
			{
				nodeComm = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"];
			}							
			tSubNetwork subnetwork = new tSubNetwork();	
			subnetwork.name = nameSubNet.Text;			
			subnetwork.desc = descSubNet.Text;			
			if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"]==null)	
			{					
					nodeSubNetwork = new TreeNode();
					nodeSubNetwork.Name = "tSubNetwork[]";
					nodeSubNetwork.Tag = this.sCL.Communication.SubNetwork;
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
				this.objectManagement.AddObjectToArrayObjectOfParentObject(subnetwork, this.sCL.Communication);
				this.objectManagement.AddObjectToSCLObject(this.sCL.Communication.SubNetwork, this.sCL);					
				nodetSubNetwork = new TreeNode();			
				nodetSubNetwork.Name = subnetwork.name; 
				nodetSubNetwork.Text = "tSubNetwork";
				treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes.Add(nodetSubNetwork);
			}
			else
			{										
				nodetSubNetwork = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[this.GetNodeName(nodeSubNetwork.Nodes, nameSubNet.Text, "name")];
			}	
			this.nodetSubNetwork.Tag = subnetwork;			
			this.objectManagement.AddObjectToArrayObjectOfParentObject(tConnected,this.sCL.Communication.SubNetwork[nodetSubNetwork.Index]);
			if(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[nodetSubNetwork.Name].Nodes["tConnectedAP[]"]==null)
			{
				nodeComm = new TreeNode();			
				nodeComm.Name = "tConnectedAP[]";
				nodeComm.Tag = this.sCL.Communication.SubNetwork[nodetSubNetwork.Index].ConnectedAP;
				nodeComm.Text = "ConnectedAP";
				treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[nodetSubNetwork.Name].Nodes.Add(nodeComm);
			}
			else
			{
				nodeComm = this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[nodetSubNetwork.Name].Nodes["tConnectedAP[]"];
			}									
			nodetConnected = new TreeNode();			
			nodetConnected.Name = "tConnectedAP"+this.iedName+this.apName;
			nodetConnected.Tag = tConnected;
			nodetConnected.Text = "tConnectedAP";
			treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[nodetSubNetwork.Name].Nodes["tConnectedAP[]"].Nodes.Add(nodetConnected);				
			objectManagement.AddObjectToSCLObject(address, tConnected);

			TreeNode nodeAddress = new TreeNode();
			nodeAddress.Name = "Adress";
			nodeAddress.Tag = address;
			nodeAddress.Text = "Address";
			treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[nodetSubNetwork.Name].Nodes["tConnectedAP[]"].Nodes[nodetConnected.Name].Nodes.Add(nodeAddress);											
		
			nodeP.Name = "tP[]";
			nodeP.Text = "P";
			treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[nodetSubNetwork.Name].Nodes["tConnectedAP[]"].Nodes[nodetConnected.Name].Nodes["Adress"].Nodes.Add(nodeP);				

			tP t_ip = new tP();
			tP_IP t_ip_ = new tP_IP();
			this.utilsOM.EmptyGUIObjectoSCLObject(t_ip_,t_ip);
			t_ip.Value = ip.Text;
			DrawTPNodes(t_ip, "tP_ip", "tP");
			
			tP t_subnet = new tP();
			tP_IPSUBNET t_subnet_ = new tP_IPSUBNET();
			this.utilsOM.EmptyGUIObjectoSCLObject(t_subnet_,t_subnet);
			t_subnet.Value = mask.Text;
			DrawTPNodes(t_subnet, "tP_subnet", "tP");
			
			tP t_gate = new tP();
			tP_IPGATEWAY  t_gate_ = new tP_IPGATEWAY();
			this.utilsOM.EmptyGUIObjectoSCLObject(t_gate_, t_gate);
			t_gate.Value = gateway.Text;
			DrawTPNodes(t_gate, "tP_gate", "tP");

			tP t_tsel = new tP();
			tP_OSITSEL t_tsel_ = new tP_OSITSEL();
			this.utilsOM.EmptyGUIObjectoSCLObject(t_tsel_,t_tsel);
			t_tsel.Value = tsel.Text;
			DrawTPNodes(t_tsel, "tP_tsel", "tP");
				
			tP t_psel = new tP();
			tP_OSIPSEL t_psel_ = new tP_OSIPSEL();
			this.utilsOM.EmptyGUIObjectoSCLObject(t_psel_,t_psel);
			t_psel.Value = psel.Text;
			DrawTPNodes(t_psel, "tP_psel", "tP");

			tP t_ssel = new tP();
			tP_OSISSEL t_ssel_ = new tP_OSISSEL();
			this.utilsOM.EmptyGUIObjectoSCLObject(t_ssel_,t_ssel);
			t_ssel.Value = ssel.Text;
			DrawTPNodes(t_ssel, "tP_ssel", "tP");					
			
//			utilsOM.DrawTPNodes(nodeP, this.address, tPTypeEnum.IP, ip.Text);
//			utilsOM.DrawTPNodes(nodeP, this.address, tPTypeEnum.IP_SUBNET, mask.Text);
//			utilsOM.DrawTPNodes(nodeP, this.address, tPTypeEnum.IP_GATEWAY, gateway.Text);
//			utilsOM.DrawTPNodes(nodeP, this.address, tPTypeEnum.OSI_TSEL, tsel.Text);
//			utilsOM.DrawTPNodes(nodeP, this.address, tPTypeEnum.OSI_PSEL, psel.Text);
//			utilsOM.DrawTPNodes(nodeP, this.address, tPTypeEnum.OSI_SSEL, ssel.Text);					
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
		public string GetNodeName(TreeNodeCollection nodes, string nameOfSub, string var)
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
		/// This method excludes the reference of accessPoint into the treeview 
		/// </summary>
		public void ExcludeNodes()
		{			
			TreeNode treeN = treeViewSCL.SeekAssociation(this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes, this.apName, this.iedName);		    
			if (treeN != null)
			{
				treeViewSCL.Remove(treeN);	
			}						
		}							

		/// <summary>
		/// This method draws the nodes for the tP class
		/// </summary>
		/// <param name="nodeParent">
		/// Tree node where the nodes will be added.
		/// </param>
		/// <param name="parent">
		/// Object that will be added on the treeNode.
		/// </param>
		/// <param name="typeEnum">
		/// Enum type of the tP node to add.
		/// </param>
		//public void DrawTPNodes(TreeNode nodeParent, object parent, tPTypeEnum typeEnum, string ValueTp)
		public void DrawTPNodes(object tagNode, string name, string text)		
		{
//			ObjectManagement objectManagement = new ObjectManagement();
//			tP tp = new tP();
//			tp.Value = nodeParent.v;
//			tp.type  = typeEnum;			
//			TreeNode treenode1 = new TreeNode();	
//			objectManagement.AddObjectToArrayObjectOfParentObject(tp, parent);			
//			treenode1 = new TreeNode();				
//			treenode1.Name = typeEnum.ToString();
//			treenode1.Tag = tp;
//			treenode1.Text = tp.type.ToString();
//			nodeParent.Nodes.Add(treenode1);
			
			TreeNode treenode1 = new TreeNode();
			objectManagement.AddObjectToArrayObjectOfParentObject(tagNode, address);		
			treenode1 = new TreeNode();				
			treenode1.Name = name;
			treenode1.Tag = tagNode;
			treenode1.Text = text;				
			this.treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[nodetSubNetwork.Name].Nodes["tConnectedAP[]"].Nodes[nodetConnected.Name].Nodes["Adress"].Nodes["tP[]"].Nodes.Add(treenode1);				
		}	
		
//		void NameSubNetCBSelectedIndexChanged(object sender, EventArgs e)
//		{
//			TreeNode objectFound = null;
//			objectFound = treeSCL.TreeView.Nodes["root"].Nodes["SCL"].Nodes["tCommunication"].Nodes["tSubNetwork[]"].Nodes[this.GetNodeName(nodeSubNetwork.Nodes, nameSubNet.Text, "name")];
//			loadValues(objectFound);
//		}
	}
}
