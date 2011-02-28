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
	/// Description of DataSetDialog.
	/// This part is used to manipulate a DataSet that belongs a logical node.
	/// </summary>
	public partial class DataSetDialog : Form
	{
		private TreeNode treeSCL;
		private SCL scl;
		private tDataSet dataSetSCL;
		private ObjectManagement objectManagement;
		private TreeViewSCL treeViewSCL;
		private TreeNode node;
		private object anyLN;
		private bool bandModify;
		
		public DataSetDialog()
		{			
			this.treeViewSCL = new TreeViewSCL();
			this.objectManagement = new ObjectManagement();			
			this.bandModify = false;
			InitializeComponent();	
		}		
		
		/// <summary>
		/// This method creates a DataSet. 
		/// </summary>
		/// <param name="treeSCL">
		/// TreeNode that contains the DataSet object.
		/// </param>
		/// <param name="sCLObject">
		/// sCL object of the project.
		/// </param>
		public void CreateDataSet(TreeNode treeSCL, SCL sCLObject)
		{
			this.treeSCL = treeSCL;
			this.scl = sCLObject;
			this.anyLN = this.treeViewSCL.SearchUPForBaseTypeAndGetSCLTreeNode(treeSCL, typeof(tAnyLN)).Tag;
			this.node = this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(treeSCL, typeof(tLDevice));
			DataSet dataSet = new DataSet();					
			if(this.node!=null)
			{
				this.Name ="ldInst"+ (node.Tag as tLDevice).inst;						
				if(this.anyLN is tLN)
				{
					this.LNtypeLabel.Text = ((anyLN as tLN).prefix+(anyLN as tLN).lnClass+(anyLN as tLN).inst);
					this.dataSetSCL = dataSet.GetLNFCDAs(node.Tag as tLDevice, this.anyLN as tLN, this.scl.DataTypeTemplates);
				}
				else
				{
					this.LNtypeLabel.Text = ((anyLN as LN0).lnClass+(anyLN as LN0).inst);
					this.dataSetSCL = dataSet.GetLN0FCDAs(node.Tag as tLDevice, this.anyLN as LN0, this.scl.DataTypeTemplates);
				}	
				for(int x = 0; this.dataSetSCL != null && this.dataSetSCL.FCDA != null && x < this.dataSetSCL.FCDA.Length; x++)
				{
					this.SourceDataSetListBox.Items.Add(new FCDAListBox(this.dataSetSCL.FCDA[x], (this.anyLN as tAnyLN).lnType));
				}
			}
			else
			{				
				this.LNtypeLabel.Text = ((anyLN as tLN).prefix+(anyLN as tLN).lnClass+(anyLN as tLN).inst);				
				this.dataSetSCL = dataSet.GetLNFCDAs(null, this.anyLN as tLN, this.scl.DataTypeTemplates);
				for(int x = 0; this.dataSetSCL != null && this.dataSetSCL.FCDA != null && x < this.dataSetSCL.FCDA.Length; x++)
				{
					this.SourceDataSetListBox.Items.Add(new FCDAListBox(this.dataSetSCL.FCDA[x], (this.anyLN as tLN).lnType));
				}
			}			
			this.SourceDataSetListBox.SelectionMode = SelectionMode.None;
			this.DestinyDataSetListBox.SelectionMode = SelectionMode.None;
			this.SourceDataSetListBox.SelectionMode = SelectionMode.MultiSimple;
			this.DestinyDataSetListBox.SelectionMode = SelectionMode.MultiSimple;
			this.SourceDataSetListBox.DisplayMember = "DisplayFCDA";
			this.DestinyDataSetListBox.DisplayMember = "DisplayFCDA";	
		}
				
		/// <summary>
		/// This method removes the selected nodes from the SourceDataSetListBox object and adds them
		/// to the DestinyDataSetListBox object.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		private void ChooseOneFCDAButtonClick(object sender, EventArgs e)
		{
			if(this.SourceDataSetListBox.SelectedIndex != -1)
			{
				while( 0 < SourceDataSetListBox.SelectedIndices.Count)
				{
					this.DestinyDataSetListBox.Items.Add(this.SourceDataSetListBox.Items[this.SourceDataSetListBox.SelectedIndices[0]]);
					this.SourceDataSetListBox.Items.Remove(this.SourceDataSetListBox.Items[this.SourceDataSetListBox.SelectedIndices[0]]);
					
				}
			}
		}
		
		/// <summary>
		/// This event removes the selected nodes from the DestinyDataSetListBox object and adds them
		/// to the SourceDataSetListBox object.		
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		private void ComeBackOneFCDAButtonClick(object sender, EventArgs e)
		{
			if(DestinyDataSetListBox.SelectedIndex != -1)
			{
				while( 0 < DestinyDataSetListBox.SelectedIndices.Count)
				{
					this.SourceDataSetListBox.Items.Add(this.DestinyDataSetListBox.SelectedItem);
					this.DestinyDataSetListBox.Items.Remove(this.DestinyDataSetListBox.SelectedItem);
				}
			}
		
		}
		
		/// <summary>
		/// This event removes the contents of the SourceDataSetListBox object and adds it to the 
		/// DestinyDataSetListBox object.		
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		private void ChooseAllFCDAButtonClick(object sender, EventArgs e)
		{
			for(int i =0; i < this.SourceDataSetListBox.Items.Count; i++)
			{
				this.DestinyDataSetListBox.Items.Add(this.SourceDataSetListBox.Items[i]);
			}
			this.SourceDataSetListBox.Items.Clear();
		}
		
		/// <summary>
		/// This method reload the values of a DataSet that was previously created.
		/// </summary>
		/// <param name="treeDataSet">
		/// TreeNode of the selected DataSet.
		/// </param>
		/// <param name="sCL">
		/// sCL object that contains the data assigned to the selected DataSet.
		/// </param>
		public void ReloadDataSet(TreeNode treeDataSet, SCL sCL)
		{
			this.bandModify = true;
			this.scl = sCL;
			this.treeSCL = treeDataSet;
			tDataSet dataSetSCLDestiny = (tDataSet) treeDataSet.Tag;			
			tDataSet dataSetSCLSource;
			this.NameTextBox.Text = dataSetSCLDestiny.name;
			this.DescTextBox.Text = dataSetSCLDestiny.desc;
			this.anyLN = this.treeViewSCL.SearchUPForBaseTypeAndGetSCLTreeNode(treeDataSet, typeof(tAnyLN)).Tag;								
			DataSet dataSet = new DataSet();
			this.node = this.treeViewSCL.SearchUPForTypeAndGetSCLTreeNode(treeDataSet, typeof(tLDevice));					
			if(this.node!=null)
			{
				this.Name ="ldInst"+ (node.Tag as tLDevice).inst;									
				if(this.anyLN is tLN)
				{
					this.LNtypeLabel.Text = ((anyLN as tLN).prefix+(anyLN as tLN).lnClass+(anyLN as tLN).inst);
					dataSetSCLSource = dataSet.GetLNFCDAs(node.Tag as tLDevice, this.anyLN as tLN, this.scl.DataTypeTemplates);
				}
				else
				{
					this.LNtypeLabel.Text = ((anyLN as LN0).lnClass+(anyLN as LN0).inst);
					dataSetSCLSource = dataSet.GetLN0FCDAs(node.Tag as tLDevice, this.anyLN as LN0, this.scl.DataTypeTemplates);
				}
				for(int x = 0, y = 0; dataSetSCLSource != null && dataSetSCLSource.FCDA != null && x < dataSetSCLSource.FCDA.Length; x++)
				{				
					if(dataSetSCLDestiny != null&& dataSetSCLDestiny.FCDA != null && y < dataSetSCLDestiny.FCDA.Length && this.objectManagement.Compare(dataSetSCLSource.FCDA[x],dataSetSCLDestiny.FCDA[y]))
					{
						this.DestinyDataSetListBox.Items.Add(new FCDAListBox(dataSetSCLDestiny.FCDA[y], (this.anyLN as tAnyLN).lnType));						
						y++;
					}
					else
					{
						this.SourceDataSetListBox.Items.Add(new FCDAListBox(dataSetSCLSource.FCDA[x], (this.anyLN as tAnyLN).lnType));
					}					
				}
			}
			else
			{
				this.LNtypeLabel.Text = ((anyLN as tLN).prefix+(anyLN as tLN).lnClass+(anyLN as tLN).inst);				
				dataSetSCLSource = dataSet.GetLNFCDAs(null, this.anyLN as tLN, this.scl.DataTypeTemplates);
				for(int x = 0, y = 0; dataSetSCLSource != null && dataSetSCLSource.FCDA != null && x < dataSetSCLSource.FCDA.Length; x++)
				{				
					if(dataSetSCLDestiny != null&& dataSetSCLDestiny.FCDA != null && y < dataSetSCLDestiny.FCDA.Length && this.objectManagement.Compare(dataSetSCLSource.FCDA[x],dataSetSCLDestiny.FCDA[y]))
					{
						this.DestinyDataSetListBox.Items.Add(new FCDAListBox(dataSetSCLDestiny.FCDA[y], (this.anyLN as tAnyLN).lnType));						
						y++;
					}
					else
					{
						this.SourceDataSetListBox.Items.Add(new FCDAListBox(dataSetSCLSource.FCDA[x], (this.anyLN as tAnyLN).lnType));
					}					
				}
			}			
			this.SourceDataSetListBox.DisplayMember = "DisplayFCDA";
			this.DestinyDataSetListBox.DisplayMember = "DisplayFCDA";				
		}
		
		/// <summary>
		/// This event removes the contents of the DestinyDataSetListBox object and adds it to the
		/// SourceDataSetListBox object.		
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		private void ComeBackAllFCDAButtonClick(object sender, EventArgs e)
		{
			for( int i = 0; i < this.DestinyDataSetListBox.Items.Count; i ++)
			{
				this.SourceDataSetListBox.Items.Add(this.DestinyDataSetListBox.Items[i]);
			}
			this.DestinyDataSetListBox.Items.Clear();
		}
		
		/// <summary>
		/// This event cancels the changes made on the dialog box.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void CancelBtnClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		/// <summary>
		/// This event saves the information of the DataSet.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		private void OKButtonClick(object sender, EventArgs e)
		{			
			if(this.DestinyDataSetListBox.Items.Count>0)
			{
				this.treeSCL.TreeView.SelectedNode = this.treeViewSCL.SearchUPForBaseTypeAndGetSCLTreeNode(treeSCL, typeof(tAnyLN));
				object lN = this.treeSCL.TreeView.SelectedNode.Tag;
				if(this.dataSetSCL!=null)
				{
					this.dataSetSCL.FCDA = null;
				}
				else
				{
					this.dataSetSCL = new tDataSet();
				}				
				tFCDA[] fCDAs = new tFCDA[this.DestinyDataSetListBox.Items.Count];
				for(int x = 0; x < this.DestinyDataSetListBox.Items.Count; x++)
				{
					fCDAs[x] = (this.DestinyDataSetListBox.Items[x] as FCDAListBox).fCDA;					
				}
				this.dataSetSCL.FCDA = fCDAs;
				this.dataSetSCL.name = this.NameTextBox.Text;
				this.dataSetSCL.desc = this.DescTextBox.Text;
				this.objectManagement.AddObjectToArrayObjectOfParentObject(this.dataSetSCL, lN);
				treeViewSCL.GetNodesItemOfArray((lN as tAnyLN).DataSet, lN.GetType(), this.treeSCL.TreeView.SelectedNode);				
				if(this.bandModify)
				{
					RegularExpressionTree regularExpressionTree = new  RegularExpressionTree();
					AutomataForValidateToTreeNode automataForValidateToTreeNode = new AutomataForValidateToTreeNode(this.treeSCL,
						regularExpressionTree.GetRegExpToDelete(this.treeSCL));	
					automataForValidateToTreeNode.InterpretString();
				}				
				this.Close();
			}	
			else
			{
				MessageBox.Show("No data has been added to the DataSet");
			}
		}
	}
	
	/// <summary>
	/// This class is used to manipulate the FCDA class that will be showed on the ListBox.
	/// </summary>
	class FCDAListBox
	{
		public tFCDA fCDA;
		private string lNType;
		
		public FCDAListBox(tFCDA fCDA, string lNType)
		{
			this.fCDA = fCDA;
			this.lNType = lNType;
		}		
		
		public string DisplayFCDA
		{
			get
			{				
				return this.lNType+"."+this.fCDA.doName+"."+this.fCDA.daName;
			}
		}
	}
}
