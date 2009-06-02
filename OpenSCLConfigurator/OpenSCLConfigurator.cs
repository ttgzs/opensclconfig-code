// OpenSCLConfigurator 
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
		private System.Windows.Forms.ToolBarButton Exit;
		private System.Windows.Forms.ToolBarButton SEPARATOR2;		
		public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;		
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;		
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;		
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;		
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private	System.Windows.Forms.Panel Panel1;		
		private	System.Windows.Forms.Panel Panel2;
		private	System.Windows.Forms.SplitContainer splitContainer1;
		
		ImageList tb_il					= new ImageList();		

		public FormSCL()
		{
			InitializeComponent();
		}
					
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
		
		public void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Panel1 = new System.Windows.Forms.Panel();
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
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iEDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.validateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SEPARATOR1 = new System.Windows.Forms.ToolBarButton();
			this.Exit = new System.Windows.Forms.ToolBarButton();
			this.SEPARATOR2 = new System.Windows.Forms.ToolBarButton();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Panel1
			// 
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel1.Location = new System.Drawing.Point(0, 0);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(300, 383);
			this.Panel1.TabIndex = 0;
			// 
			// Panel2
			// 
			this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Panel2.AutoSize = true;
			this.Panel2.Location = new System.Drawing.Point(0, 0);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(916, 666);
			this.Panel2.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 52);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.Panel1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.Panel2);
			this.splitContainer1.Size = new System.Drawing.Size(814, 385);
			this.splitContainer1.SplitterDistance = 302;
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
			this.menuStrip1.Size = new System.Drawing.Size(814, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.openToolStripMenuItem,
									this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.fileToolStripMenuItem.Text = "Project";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFile);
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
			this.validateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
			// 
			// SEPARATOR1
			// 
			this.SEPARATOR1.Name = "SEPARATOR1";
			this.SEPARATOR1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// Exit
			// 
			this.Exit.ImageIndex = 0;
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
									this.Exit,
									this.SEPARATOR2});
			this.toolBar1.ButtonSize = new System.Drawing.Size(16, 16);
			this.toolBar1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.Location = new System.Drawing.Point(0, 24);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(814, 28);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBarEvent);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 437);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(814, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "Status Bar";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
			// 
			// FormSCL
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(814, 459);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolBar1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Name = "FormSCL";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = ":..OpenSCLConfigurator..:";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem validateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem iEDToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
	
		//adding the icons into the app
		private void Form1_Load(object sender, System.EventArgs e) 
		{			
			tb_il.Images.Add(new Icon(Application.StartupPath+"/../../imgs//exit.ico"));															
			toolBar1.ImageList = tb_il;  											
		}												
		
		/// <summary>
		/// This method comes from the principal menu. It's the option to open a project
		/// </summary>
		/// <param name="sender">
		/// 
		/// </param>
		/// <param name="e">
		/// 
		/// </param>
		void OpenFile(object sender, EventArgs e)
		{			
			OpenSCL.Object Object = new OpenSCL.Object();
			openDialog o = new openDialog();			
			string nameFileXML = o.openDialogs();
			Object.Deserialize(nameFileXML);	
			TreeView tv = new TreeView();	
			TreeViewSCL treeViewSCL = new TreeViewSCL();
			TreeNode arbol = new TreeNode();	
			arbol.Text ="IEC61850"; 
			treeViewSCL.GetNodes(Object.Configuration,arbol);
			tv.Nodes.Add(arbol);	
			Panel1.Controls.Add(tv);
			tv.Dock = System.Windows.Forms.DockStyle.Fill;
			tv.Scrollable = true;  			
		}		
		
		void ValidateFileClick(object sender, EventArgs e)
		{
			//Code to validate XML files
		}
		
		//Menu : opción exit
		private void exitApp(object sender, System.EventArgs e)
		{
				Application.Exit();			
		}
				
		//events for toolBar
		private void toolBarEvent(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)		
		{					
			switch(toolBar1.Buttons.IndexOf(e.Button))
			{				
				case 1: //Exit
				{
					Application.Exit();
					break;
				}
			}
		
		}												
	} 	
}
