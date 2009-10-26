﻿// OpenSCLConfigurator 
//
// Copyright (C) 2009 Comisión Federal de Electricidad
// 
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 3
// of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OpenSCL;
using OpenSCL.UI;

namespace OpenSCLConfigurator
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormSCL : Form
	{		
		public System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		public System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;	
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;		
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton SEPARATOR1;
		private System.Windows.Forms.ToolBarButton New;
		private System.Windows.Forms.ToolBarButton Open;
		private System.Windows.Forms.ToolBarButton Salvar;
		private System.Windows.Forms.ToolBarButton SEPARATOR2;			
		private System.Windows.Forms.ToolBarButton Exit;			
		public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;		
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;		
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;		
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem validateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem iEDToolStripMenuItem;					
		private System.Windows.Forms.MenuStrip menuStrip1;		
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private	System.Windows.Forms.Panel Panel1;		
		private	System.Windows.Forms.Panel Panel2;
		private	System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.PropertyGrid PropertyGridAttributes;
		private System.Windows.Forms.TreeView treeViewFile;
						
		ImageList tb_il					= new ImageList();	
		string xSDFiles = Application.StartupPath+"/../../XSD//SCL.xsd";
		string newFile = Application.StartupPath+"/../..//NewSCLFile.icd";		

		/// <summary>
		/// This method initialize the components of the form. 
		/// </summary>
		public FormSCL()
		{
			InitializeComponent();	
		}
		
		/// <summary>
		/// This method disposes the components of the form.
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		
		/// <summary>
		/// This method initialize the components contained on the form.
		/// </summary>
		public void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Panel1 = new System.Windows.Forms.Panel();
			this.treeViewFile = new System.Windows.Forms.TreeView();
			this.Panel2 = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iEDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.validateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SEPARATOR1 = new System.Windows.Forms.ToolBarButton();
			this.Exit = new System.Windows.Forms.ToolBarButton();
			this.SEPARATOR2 = new System.Windows.Forms.ToolBarButton();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.New = new System.Windows.Forms.ToolBarButton();
			this.Open = new System.Windows.Forms.ToolBarButton();
			this.Salvar = new System.Windows.Forms.ToolBarButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.PropertyGridAttributes = new System.Windows.Forms.PropertyGrid();
			this.Panel1.SuspendLayout();
			this.Panel2.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Panel1
			// 
			this.Panel1.Controls.Add(this.treeViewFile);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel1.Location = new System.Drawing.Point(0, 0);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(347, 670);
			this.Panel1.TabIndex = 0;
			// 
			// treeViewFile
			// 
			this.treeViewFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewFile.Location = new System.Drawing.Point(0, 0);
			this.treeViewFile.Name = "treeViewFile";
			this.treeViewFile.Size = new System.Drawing.Size(347, 671);
			this.treeViewFile.TabIndex = 0;
			this.treeViewFile.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TreeViewFileMouseUp);
			this.treeViewFile.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFileAfterSelect);
			// 
			// Panel2
			// 
			this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Panel2.Controls.Add(this.PropertyGridAttributes);
			this.Panel2.Location = new System.Drawing.Point(0, 0);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(583, 670);
			this.Panel2.TabIndex = 0;
			// 
			// PropertyGridAttributes
			// 
			this.PropertyGridAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.PropertyGridAttributes.Location = new System.Drawing.Point(1, 1);
			this.PropertyGridAttributes.Name = "PropertyGridAttributes";
			this.PropertyGridAttributes.Size = new System.Drawing.Size(580, 465);
			this.PropertyGridAttributes.TabIndex = 3;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Location = new System.Drawing.Point(0, 52);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.AutoScroll = true;
			this.splitContainer1.Panel1.Controls.Add(this.Panel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.Panel2);
			this.splitContainer1.Size = new System.Drawing.Size(943, 672);
			this.splitContainer1.SplitterDistance = 349;
			this.splitContainer1.TabIndex = 5;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
									this.menuItem1,
									this.menuItem4});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
									this.menuItem3,
									this.menuItem2});
			this.menuItem1.OwnerDraw = true;
			this.menuItem1.Text = "File";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.OwnerDraw = true;
			this.menuItem3.Text = "Open";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.OwnerDraw = true;
			this.menuItem2.Text = "Exit";
			this.menuItem2.Click += new System.EventHandler(this.exitApp);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
									this.menuItem5});
			this.menuItem4.OwnerDraw = true;
			this.menuItem4.Text = "Help";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.OwnerDraw = true;
			this.menuItem5.Text = "About";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.iEDToolStripMenuItem,
									this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(943, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.newToolStripMenuItem,
									this.openToolStripMenuItem,
									this.saveToolStripMenuItem,
									this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.fileToolStripMenuItem.Text = "Project";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.NewFile);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFile);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveFile);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitApp);
			// 
			// iEDToolStripMenuItem
			// 
			this.iEDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.validateToolStripMenuItem});
			this.iEDToolStripMenuItem.Name = "iEDToolStripMenuItem";
			this.iEDToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
			this.iEDToolStripMenuItem.Text = "IED";
			// 
			// validateToolStripMenuItem
			// 
			this.validateToolStripMenuItem.Name = "validateToolStripMenuItem";
			this.validateToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.validateToolStripMenuItem.Text = "File validator";
			this.validateToolStripMenuItem.Click += new System.EventHandler(this.ValidateFileClick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutClick);
			// 
			// SEPARATOR1
			// 
			this.SEPARATOR1.Name = "SEPARATOR1";
			this.SEPARATOR1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// Exit
			// 
			this.Exit.ImageIndex = 3;
			this.Exit.Name = "Exit";
			this.Exit.ToolTipText = "Exit Application";
			// 
			// SEPARATOR2
			// 
			this.SEPARATOR2.Name = "SEPARATOR2";
			this.SEPARATOR2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
									this.SEPARATOR1,
									this.New,
									this.Open,
									this.Salvar,
									this.SEPARATOR2,
									this.Exit});
			this.toolBar1.ButtonSize = new System.Drawing.Size(16, 16);
			this.toolBar1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.Location = new System.Drawing.Point(0, 24);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(943, 28);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBarEvent);
			// 
			// New
			// 
			this.New.ImageIndex = 0;
			this.New.Name = "New";
			this.New.ToolTipText = "New configuration file";
			// 
			// Open
			// 
			this.Open.ImageIndex = 1;
			this.Open.Name = "Open";
			this.Open.ToolTipText = "Open a configuration file";
			// 
			// Salvar
			// 
			this.Salvar.ImageIndex = 2;
			this.Salvar.Name = "Salvar";
			this.Salvar.ToolTipText = "Save configuration file";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 724);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(943, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "Status Bar";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
			// 
			// PropertyGridAttributes
			// 
			this.PropertyGridAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom))));
			this.PropertyGridAttributes.Location = new System.Drawing.Point(1, 1);
			this.PropertyGridAttributes.Name = "PropertyGridAttributes";
			this.PropertyGridAttributes.Size = new System.Drawing.Size(580, 580);
			this.PropertyGridAttributes.TabIndex = 3;
			// 
			// FormSCL
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(943, 746);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolBar1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Name = "FormSCL";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = ":..OpenSCLConfigurator..:";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSCLFormClosed);
			this.Panel1.ResumeLayout(false);
			this.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}				
				
		/// <summary>
		/// Adding icons into the application
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		private void Form1_Load(object sender, System.EventArgs e) 
		{			
			tb_il.Images.Add(new Icon(Application.StartupPath+"/imgs//new_file.ico"));															
			tb_il.Images.Add(new Icon(Application.StartupPath+"/imgs//open_file.ico"));																		
			tb_il.Images.Add(new Icon(Application.StartupPath+"/imgs//save_file.ico"));			
			tb_il.Images.Add(new Icon(Application.StartupPath+"/imgs//exit.ico"));
			toolBar1.ImageList = tb_il;  											
		}												

		/// <summary>
		/// This method comes from the principal menu. It's the option to create a project.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void NewFile(object sender, EventArgs e)
		{	
			SaveFile(sender, e);
			List<ErrorsManagement> list = null;					
			ValidatingSCL validate = new ValidatingSCL();			
			list = validate.ValidateFile(newFile, xSDFiles);
			if (list.Count == 0)
			{														
				TreeViewSCL treeViewSCLOpen = new TreeViewSCL();
				OpenSCL.Object Object = new OpenSCL.Object(); 					
				Object.Deserialize(this.newFile);				
				this.treeViewFile.Nodes.Add(treeViewSCLOpen.GetTreeNodeSCL(Path.GetFileName(newFile), Object.Configuration));
			}		
			EnablePanels(list);			
		}
		
		/// <summary>
		/// This method comes from the principal menu. It's the option to open a project
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		private void OpenFile(object sender, EventArgs e)
		{	
			List<ErrorsManagement> listError = null;
			try
			{
				SaveFile(sender, e);
				openDialog o = new openDialog();					
				listError = o.OpenSCLFile(this.treeViewFile, xSDFiles);												
				EnablePanels(listError);
			}
			catch 
			{
				MessageBox.Show("SCL File Not Valid/Corrupted", "Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}		
		
		/// <summary>
		/// This method comes from the principal menu. It's the option to save a project.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		private void SaveFile(object sender, EventArgs e)
		{
			if (this.treeViewFile.Nodes.Count > 0)
            {   
				if (MessageBox.Show("Do you want to save the changes on this file \n", "Save File", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{				
					SaveDialog saveD = new SaveDialog();
					saveD.SaveSCLFile(this.treeViewFile);
				}
				this.treeViewFile.Nodes.Clear();				
			}			
		}
		
		/// <summary>
		/// This event calls some methods to validate an XML file
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		private void ValidateFileClick(object sender, EventArgs e)
		{
			OpenFile(sender, e);
		}
		
		/// <summary>
		/// This method comes from the principal menu. It's the option to exit of the application program.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		private void exitApp(object sender, System.EventArgs e)
		{
			Application.Exit();			
		}
		
		/// <summary>
		/// This method comes from the principal menu. It's the option to show a information about this application program.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void AboutClick(object sender, EventArgs e)
		{
			about a = new about();
			a.Show();
		}	
		
		/// <summary>
		/// This method calls the method for new, open, save and exit from the toolbar icons
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>	
		private void toolBarEvent(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)		
		{					
			switch(toolBar1.Buttons.IndexOf(e.Button))
			{				
				//New configuration file
				case 1:
				{
					NewFile(sender, e);
					break;
				}
				//Open configuration file
				case 2:
				{
					OpenFile(sender, e);						
					break;
				}
				//Save configuration file
				case 3: 
				{
					SaveFile(sender, e);
					break;
				}			
				//Exit application
				case 5: 
				{
					Application.Exit();
					break;
				}
			}
		}

		/// <summary>
		/// This method updates the information on the propertygrid when a node of the tree is selected.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void treeViewFileAfterSelect(object sender, TreeViewEventArgs e)
		{
			Utils guiObjectManagement = new Utils();			
			this.PropertyGridAttributes.SelectedObject = guiObjectManagement.UpdatePropertyGrid(e.Node.Tag);						
		}

		/// <summary>
		/// This method displays a menu when a click on the rigt button of the mouse is given.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>		
		void TreeViewFileMouseUp(object sender, MouseEventArgs e)
		{
			if (this.treeViewFile.Nodes.Count > 0)
			{
            	if (e.Button == MouseButtons.Right && (treeViewFile.SelectedNode.IsSelected))
            	{
	                ContextMenuSCL contextMenuSCL = new ContextMenuSCL();
    	            Point nodePosition = new Point(e.X, e.Y);
        	        ContextMenuStrip menuStrip = contextMenuSCL.GetContextMenuSCL(this.treeViewFile.SelectedNode);
            	    menuStrip.Show(treeViewFile, nodePosition);
            	}	
			}
		}

		/// <summary>
		/// This method allows to enable a listbox with the errors found during the validation process
		/// or a propertygrid with the attributes for the selected node.
		/// </summary>
		/// <param name="listError">
		/// List of Errors founded during the validationprocess, if it is null, it means that the properties
		/// has to be displayed
		/// </param>
		void EnablePanels(List<ErrorsManagement> listError)
		{
			if (listError != null)					
			{
				Panel2.Controls.Clear();
				PropertyGridAttributes.SelectedObject = null;						
				Panel2.Dock = System.Windows.Forms.DockStyle.Fill;						
				if (listError.Count == 0 )
				{					
					Panel2.Controls.Add(PropertyGridAttributes);	
				}
				else
				{			
					UIErrorsManagement uiError = new UIErrorsManagement();
					Panel2.Controls.Add(uiError.ShowError(listError));						
				}								
			}
			Panel1.Controls.Add(this.treeViewFile);
		}

		void FormSCLFormClosed(object sender, FormClosedEventArgs e)
		{
			SaveFile(sender, e);
		}		
	} 	
}
