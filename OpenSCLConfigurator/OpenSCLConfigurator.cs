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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OpenSCL;
using OpenSCL.UI;
using IEC61850.SCL;

namespace OpenSCLConfigurator
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class App : Form
	{		
		
		// Private variables
		private System.Boolean modified;
		private System.Boolean validate;
		private ImageList tb_il	= new ImageList();	
		private string xSDFiles = Application.StartupPath+"/XSD//SCL.xsd";
		private string AppName = "OpenSCLConfigurator";
		private string file = "";
		private OpenSCL.Object scl;
		
		// Form objects
		private System.Windows.Forms.ToolStripMenuItem importIEDConfigToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem validateSCLFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
				
		public System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem fileMenu;
		public System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem openItem;	
		private System.Windows.Forms.MenuItem helpMenu;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem editMenu;
		private System.Windows.Forms.MenuItem preferencesItem;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton New;
		private System.Windows.Forms.ToolBarButton Open;
		private System.Windows.Forms.ToolBarButton Salvar;
		private System.Windows.Forms.ToolBarButton Exit;			
		public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;		
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;		
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;		
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
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
		private System.Windows.Forms.ToolBarButton Separator2;
		private System.Windows.Forms.ToolBarButton Separator1;
		
		private string File {
			get { return file; }
			set { 
				file = value;
				this.Text = this.Text + " - " + file;
			}
		}
		
		/// <summary>
		/// This method initialize the components of the form. 
		/// </summary>
		public App()
		{
			modified = false;
			// On open files validation is desable by default
			validate = false;
			
			//System.Windows.Forms.MessageBox.Show ( os.Platform.ToString() );
			InitializeComponent();
			string[] args = Environment.GetCommandLineArgs();
			if (args.Length > 1) {
				string arg = args [1];
				try {
					System.Console.WriteLine ("arg = " + arg);
					OpenSCLFile (arg, false);
//						if (Path.GetFileName (arg) != "") {
//							var f = new System.IO.FileStream (arg, FileMode.Open);
//							if (f.CanRead) {
//								f.Close ();
//								OpenSCLFile (arg, false);
//							}
//						}
				}
				catch (System.IO.FileNotFoundException) {
					System.Console.WriteLine ("File: " + arg + " does not exist");
				}
			}
		}
		
		/// <summary>
		/// This method disposes the components of the form.
		/// </summary>
		/// <param name="disposing">
		/// 
		/// </param>
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
			this.PropertyGridAttributes = new System.Windows.Forms.PropertyGrid();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			
			this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
			this.fileMenu = new System.Windows.Forms.MenuItem();
			this.openItem = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.editMenu = new System.Windows.Forms.MenuItem();
			this.preferencesItem = new System.Windows.Forms.MenuItem();
			this.helpMenu = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			
			this.validateSCLFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			
			this.importIEDConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			
			this.Exit = new System.Windows.Forms.ToolBarButton();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.Separator1 = new System.Windows.Forms.ToolBarButton();
			
			this.New = new System.Windows.Forms.ToolBarButton();
			this.Open = new System.Windows.Forms.ToolBarButton();
			this.Salvar = new System.Windows.Forms.ToolBarButton();
			
			this.Separator2 = new System.Windows.Forms.ToolBarButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			
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
			//this.Panel1.Size = new System.Drawing.Size(347, 670);
			this.Panel1.TabIndex = 0;
			this.Panel1.AutoSize = true;
			// 
			// treeViewFile
			// 
			this.treeViewFile.Anchor = ((System.Windows.Forms.AnchorStyles)
			                            ((((System.Windows.Forms.AnchorStyles.Top 
			                                | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewFile.Location = new System.Drawing.Point(0, 0);
			this.treeViewFile.Name = "treeViewFile";
			this.treeViewFile.Dock = DockStyle.Fill;
			//this.treeViewFile.AutoSize = true;
			//this.treeViewFile.Size = new System.Drawing.Size(347, 671);
			//this.treeViewFile.MinimumSize = new System.Drawing.Size(200, 300);
			this.treeViewFile.TabIndex = 0;
			this.treeViewFile.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TreeViewFileMouseUp);
			this.treeViewFile.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFileAfterSelect);
			
			// 
			// Panel2
			// 
			this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel2.Controls.Add(this.PropertyGridAttributes);
						
			this.Panel2.Location = new System.Drawing.Point(0, 0);
			this.Panel2.Name = "Panel2";
			//this.Panel2.Size = new System.Drawing.Size(583, 670);
			this.Panel2.TabIndex = 2;
			//this.Panel2.AutoScroll = true;
			this.Panel2.AutoSize = true;
			
			// 
			// PropertyGridAttributes
			// 
			this.PropertyGridAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.PropertyGridAttributes.Location = new System.Drawing.Point(1, 1);
			this.PropertyGridAttributes.Name = "PropertyGridAttributes";
			this.PropertyGridAttributes.Dock = DockStyle.Fill;
			//this.PropertyGridAttributes.Size = new System.Drawing.Size(580, 465);
			//this.PropertyGridAttributes.AutoScroll = true;
			//this.PropertyGridAttributes.AutoSize = true;
			this.PropertyGridAttributes.TabIndex = 3;
			this.PropertyGridAttributes.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropertyGridAttributesPropertyValueChanged);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Location = new System.Drawing.Point(0, 52);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Dock = DockStyle.Fill;
			//this.splitContainer1.Size = new System.Drawing.Size(943, 672);
			//this.splitContainer1.MinimumSize = new System.Drawing.Size(300, 200);
			//this.splitContainer1.AutoSize = true;
			//this.splitContainer1.AutoScroll = true;
			//this.splitContainer1.SplitterDistance = 349;
			
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.AutoScroll = true;
			
			this.splitContainer1.Panel1.Controls.Add(this.Panel1);
			//this.splitContainer1.AutoScrollMinSize = new System.Drawing.Size(943, 672);
			
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.Panel2);
			this.splitContainer1.Panel2.AutoScroll = true;
			this.splitContainer1.TabIndex = 5;
			
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
									this.fileMenu,
									this.helpMenu});
			// 
			// File Menu
			// 
			this.fileMenu.Index = 0;
			this.fileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
									this.openItem,
									this.menuItem2});
			this.fileMenu.OwnerDraw = true;
			this.fileMenu.Text = "File";
			// 
			// Open SCL File
			// 
			this.openItem.Index = 0;
			this.openItem.OwnerDraw = true;
			this.openItem.Text = "Open";
			// 
			// Exit Application
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.OwnerDraw = true;
			this.menuItem2.Text = "Exit";
			this.menuItem2.Click += new System.EventHandler(this.exitApp);
			
			// 
			// Preferences
			// 
			this.preferencesItem.Index = 1;
			this.preferencesItem.OwnerDraw = true;
			this.preferencesItem.Text = "Preferences";
			this.preferencesItem.Click += new System.EventHandler(this.OpenPreferencesDialog);
			
			// 
			// Edit
			// 
			this.editMenu.Index = 1;
			this.editMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
									this.menuItem5});
			this.helpMenu.OwnerDraw = true;
			this.helpMenu.Text = "Help";
			
			// 
			// Help
			// 
			this.helpMenu.Index = 1;
			this.helpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
									this.menuItem5});
			this.helpMenu.OwnerDraw = true;
			this.helpMenu.Text = "Help";
			// 
			// About
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.OwnerDraw = true;
			this.menuItem5.Text = "About";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.toolsToolStripMenuItem,
									this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			//this.menuStrip1.Size = new System.Drawing.Size(943, 24);
			//this.menuStrip1.AutoSize = true;
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
			//this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			//this.fileToolStripMenuItem.AutoSize = true;
			this.fileToolStripMenuItem.Text = "Project";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			//this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			//this.newToolStripMenuItem.AutoSize = true;
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.NewFile);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			//this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			//this.openToolStripMenuItem.AutoSize = true;
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFile);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			//this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			//this.saveToolStripMenuItem.AutoSize = true;
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveFile);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			//this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			//this.exitToolStripMenuItem.AutoSize = true;
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitApp);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			//this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			//this.helpToolStripMenuItem.AutoSize = true;
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			//this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			//this.aboutToolStripMenuItem.AutoSize = true;
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutClick);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.validateSCLFileToolStripMenuItem,
									this.importIEDConfigToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			//this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			//this.toolsToolStripMenuItem.AutoSize = true;
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// validateSCLFileToolStripMenuItem
			// 
			this.validateSCLFileToolStripMenuItem.Name = "validateSCLFileToolStripMenuItem";
			//this.validateSCLFileToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			//this.validateSCLFileToolStripMenuItem.AutoSize = true;
			this.validateSCLFileToolStripMenuItem.Text = "Validate SCL file";
			this.validateSCLFileToolStripMenuItem.Click += new System.EventHandler(this.ValidateFileClick);
			// 
			// importIEDConfigToolStripMenuItem
			// 
			this.importIEDConfigToolStripMenuItem.Name = "importIEDConfigToolStripMenuItem";
			//this.importIEDConfigToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			//this.importIEDConfigToolStripMenuItem.AutoSize = true;
			this.importIEDConfigToolStripMenuItem.Text = "Import IED file";
			this.importIEDConfigToolStripMenuItem.Click += new System.EventHandler(this.ImportIEDClick);
			// 
			// Exit
			// 
			this.Exit.ImageIndex = 3;
			this.Exit.Name = "Exit";
			this.Exit.ToolTipText = "Exit Application";
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
									this.Separator1,
									this.New,
									this.Open,
									this.Salvar,
									this.Separator2,
									this.Exit});
			this.toolBar1.ButtonSize = new System.Drawing.Size(16, 16);
			
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.Location = new System.Drawing.Point(0, 24);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			//this.toolBar1.Size = new System.Drawing.Size(943, 28);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBarEvent);
			// 
			// Separator1
			// 
			this.Separator1.Name = "Separator1";
			this.Separator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
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
			// Separator2
			// 
			this.Separator2.Name = "Separator2";
			this.Separator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
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
			// FormSCL
			// 
			//this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			//this.ClientSize = new System.Drawing.Size(943, 746);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolBar1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Name = "FormSCL";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = this.AppName;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			//this.AutoScroll = true;
			this.AutoSize = true;
			
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
			
			//Set app icon
			System.Drawing.Icon ico = new Icon(Application.StartupPath+"/imgs//OpenSCL_logo.ico");
			this.Icon = ico;
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
			this.treeViewFile.Nodes.Clear();			
			Utils utils = new Utils();
			var scln = new OpenSCL.Object ();
			this.scl = scln;
			scl.Configuration.Header.version = "1";
			scl.Configuration.Header.revision = "1";
			tHitem item = new tHitem();
			item.version = "1";
			item.revision = "1";
			item.why = "New SCL";
			scl.Configuration.Header.AddHistoryItem(item);
			string t = "New SCL - Ver. " + scl.Configuration.Header.version
						+ " - Rev. " + scl.Configuration.Header.revision;
			this.treeViewFile.Nodes.Add(utils.treeViewSCL.GetTreeNodeSCL(t, scl.Configuration));
			utils.CreateIED (scl.Configuration, this.treeViewFile.Nodes[0]);
		}
		
		/// <summary>
		/// Open Prefences Dialog
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// </param>
		void OpenPreferencesDialog(object sender, EventArgs e)
		{							
			
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
			SaveFile(sender, e);
			this.treeViewFile.Nodes.Clear();
			openDialog dlg = new openDialog();
			if(dlg.ShowDialog() == DialogResult.OK)
			{			
				listError = OpenSCLFile(dlg.FileName, validate);
			}
			if (listError.Capacity > 0 )
				EnablePanels (listError);
		}
		
		public List<ErrorsManagement> OpenSCLFile (string filename, bool validate)
		{
			List<ErrorsManagement> list = new List<ErrorsManagement> ();
						
			if (validate) {
				//System.Windows.Forms.MessageBox.Show ("OpenDialog: Validating");
				ValidatingSCL val = new ValidatingSCL ();
				list = val.ValidateFile (filename, xSDFiles);
			}
			
			if (list.Count == 0)
			{										
				var treeViewSCLOpen = new TreeViewSCL();
				// Creating a SCL object
				System.Console.WriteLine("Deserializating file to SCLObject:...");
				System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
				sw.Start();
				this.scl = new OpenSCL.Object ();
				this.scl.Deserialize(filename);
				sw.Stop();
				System.Console.WriteLine("Enlapsed Time:"+sw.ElapsedMilliseconds+" ms");
				// Creating TreeView
				System.Console.WriteLine("Creating TreeView:...");
				System.Diagnostics.Stopwatch swt = new System.Diagnostics.Stopwatch();
				swt.Start();
				this.File = Path.GetFileName(filename);
				string t = "SCL Configuration";
				if (this.scl.Configuration.Header != null)
					t = this.file + " Ver. " + 
						this.scl.Configuration.Header.version +
						"Rev. " + this.scl.Configuration.Header.revision;
				treeViewFile.Nodes.Add(treeViewSCLOpen.GetTreeNodeSCL(t, this.scl.Configuration));
				swt.Stop();
				System.Console.WriteLine("Enlapsed Time:"+swt.ElapsedMilliseconds+" ms");
			}	
			return list;
		}
		
		
		/// <summary>
		/// This method shows a dialog box to allow select an IED file (*.icd, *.cid) and show it 
		/// on a tree.
		/// </summary>
		/// <param name="treeViewOpen">
		/// Graphical component "TreeView" where some nodes of IED file will be added.
		/// </param>
		/// <returns>
		/// If the file that will be open has errors of XML sintax or an incorrect data according to the 
		/// XSD files then a list of errors is returned, otherwise an empty list is returned.
		/// </returns>
		public List<ErrorsManagement> ImportIED (string filename, bool validate)
		{	
			var list = new List<ErrorsManagement> ();
			
			if (validate) {
					var val = new ValidatingSCL ();
					list = val.ValidateFile(filename, xSDFiles);
			}
			
			if (list.Count == 0) {										
				
				var treeViewSCLOpen = new TreeViewSCL();
				// Creating a SCL object
				System.Console.WriteLine ("Deserializating file to SCLObject:...");
				System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
				sw.Start();
				var ied = new OpenSCL.Object ();
				ied.Deserialize (filename);					
				sw.Stop ();
				System.Console.WriteLine ("Enlapsed Time:" + sw.ElapsedMilliseconds + " ms");
				
				System.Console.WriteLine ("Importing IED TreeView:...");
				System.Diagnostics.Stopwatch swt = new System.Diagnostics.Stopwatch();
				swt.Start ();
				
				// TODO: Add a dialog to show rejected IEDs
				if (this.scl != null)
					this.scl.Configuration.AddIED (ied.Configuration);
				else
					this.scl = ied;
				
				swt.Stop();
				System.Console.WriteLine ("Enlapsed Time:"+swt.ElapsedMilliseconds+" ms");
				
				System.Console.WriteLine ("Cleaning TreeView:...");
				System.Diagnostics.Stopwatch swc = new System.Diagnostics.Stopwatch ();
				swc.Start ();
				
				treeViewFile.Nodes.Clear ();
				
				swc.Stop ();
				System.Console.WriteLine ("Enlapsed Time:"+swc.ElapsedMilliseconds+" ms");
				
				System.Console.WriteLine ("Creating TreeView:...");
				System.Diagnostics.Stopwatch swu = new System.Diagnostics.Stopwatch ();
				swu.Start ();
				
				string t = "SCL Configuration";
				if (this.scl.Configuration.Header != null)
					t = this.file + " Ver. " + 
						this.scl.Configuration.Header.version +
						"Rev. " + this.scl.Configuration.Header.revision;
				treeViewFile.Nodes.Clear ();
				treeViewFile.Nodes.Add(treeViewSCLOpen.GetTreeNodeSCL (t, scl.Configuration));
				
				swu.Stop ();
				System.Console.WriteLine ("Enlapsed Time:"+swu.ElapsedMilliseconds+" ms");
			}
			return list;
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
			}			
		}
		
		/// <summary>
		/// This event calls some methods to validate an SCL file
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
			List<ErrorsManagement> listError = null;
					
			SaveFile(sender, e);
			this.treeViewFile.Nodes.Clear();				
			openDialog dlg = new openDialog();
			if (dlg.ShowDialog () == DialogResult.OK)
			{
				listError = OpenSCLFile (dlg.FileName, true);
			}
			if (listError.Capacity > 0)
				EnablePanels(listError);
		}

		/// <summary>
		/// This event calls some methods to import an IED to an SCL File.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void ImportIEDClick (object sender, EventArgs e)
		{
			if (this.treeViewFile.Nodes != null && this.treeViewFile.Nodes.Count > 0)
			{			
				var listError = new List<ErrorsManagement> ();
				openDialog dlg = new openDialog ();
				dlg.ImportIED = true;
				if (dlg.ShowDialog () == DialogResult.OK)
					listError = ImportIED (dlg.FileName, validate);
				if (listError.Capacity > 0)
					EnablePanels (listError);
			}			
			else
			{			
				MessageBox.Show ("Can't import IED over un empty SCL");								
			}
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
			a.ShowDialog();
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
    	            System.Drawing.Point nodePosition = new System.Drawing.Point(e.X, e.Y);
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
					Panel2.AutoScroll = false;
				}
				else
				{
					UIErrorsManagement uiError = new UIErrorsManagement();
					Panel2.Controls.Add(uiError.ShowError(listError));
					
					Panel2.AutoScroll = true;
				}								
			}
			Panel1.Controls.Add(this.treeViewFile);
		}

		/// <summary>
		/// This event shows a message to ask for saving the file.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void FormSCLFormClosed(object sender, FormClosedEventArgs e)
		{
			SaveFile(sender, e);
		}		
   		
		/// <summary>
		/// Realiza la validación del lnclass
		/// </summary>
		/// <param name="s">Name of the object.</param>
		/// <param name="e">El evento se produce cuando el usuario cambia el valor de una propiedad, que se especifica como GridItem, en PropertyGrid.</param>
		void PropertyGridAttributesPropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			WindowTreeViewLNType windowTreeViewLNType;
			OpenSCL.Object sCL = new OpenSCL.Object();
			ConversionObject conversionObject = new ConversionObject();
			if(e.ChangedItem.Label.ToString() == "lnClass")
			{
				if( e.ChangedItem.Value.ToString() != "LPHD" )
				{
					sCL.Configuration = (SCL) treeViewFile.Nodes["root"].Nodes["SCL"].Tag;
					string lnType = (treeViewFile.SelectedNode.Tag as tAnyLN).lnType;
					(treeViewFile.SelectedNode.Tag as tAnyLN).lnType = (treeViewFile.SelectedNode.Tag as tLN).prefix.ToString()+conversionObject.SetEnumObjectToString((treeViewFile.SelectedNode.Tag as tLN).lnClass)+(treeViewFile.SelectedNode.Tag as tLN).inst.ToString();
					windowTreeViewLNType = new WindowTreeViewLNType(treeViewFile.SelectedNode, sCL.Configuration, treeViewFile.SelectedNode.Tag, "New");
					windowTreeViewLNType.ShowDialog();					
					if(windowTreeViewLNType.DialogResult == DialogResult.Cancel)
					{
						(treeViewFile.SelectedNode.Tag as tLN).lnClassEnum = (tLNClassEnum)conversionObject.SetStringToEnumObject((treeViewFile.SelectedNode.Tag as tLN).lnClassFieldTemp.ToString(), typeof( tLNClassEnum));
						(treeViewFile.SelectedNode.Tag as tAnyLN).lnType = lnType;						
					}
					if(windowTreeViewLNType.DialogResult == DialogResult.OK)
					{
						(treeViewFile.SelectedNode.Tag as tAnyLN).lnType = (treeViewFile.SelectedNode.Tag as tLN).prefix.ToString()+conversionObject.SetEnumObjectToString((treeViewFile.SelectedNode.Tag as tLN).lnClass)+(treeViewFile.SelectedNode.Tag as tLN).inst.ToString();
						(treeViewFile.SelectedNode.Tag as tAnyLN).DataSet = null;
						treeViewFile.SelectedNode.Nodes.RemoveByKey("tDataSet[]");
					}
					treeViewFile.SelectedNode.Text = conversionObject.SetEnumObjectToString((treeViewFile.SelectedNode.Tag as tLN).lnClass)+(treeViewFile.SelectedNode.Tag as tLN).inst.ToString();																		
				}				
			}			
		}
	} 	
}
