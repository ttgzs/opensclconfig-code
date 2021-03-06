// OpenSCLConfigurator 
//
// Copyright (C) 2009 Comisión Federal de Electricidad
// Copyright (C) 2013 Daniel Espinosa <esodan@gmail.com>
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
		private OpenSCL.Object scl;
		private SclViewerTree sclviewertree;

		private string filter = "SCL Files (*.icd,*.iid,*.cid,*.ssd,*.scd,*.sed)|*.icd;*.cid;*.ssd;*.scd|" +
				"IED Capability Description Files (*.icd)|*.icd|" +
				"Instantiated IED Description Files (*.iid)|*.iid|" +
				"Configured IED Description Files (*.cid)|*.cid|" +
				"Substation Configuration Description Files (*.scd)|*.scd|" +
				"System Exchange Description Files (*.sed)|*.sed|" +
				"System Specification Description Files (*.ssd)|*.ssd|" +
				"All Files (*.*)|*.*";

		// Form objects
		private System.Windows.Forms.ToolStripMenuItem importIEDConfigToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem validateSCLFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
				
		public System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem fileMenu;
		public System.Windows.Forms.MenuItem exitItem;
		private System.Windows.Forms.MenuItem openItem;	
		private System.Windows.Forms.MenuItem helpMenu;
		private System.Windows.Forms.MenuItem aboutItem;
		private System.Windows.Forms.MenuItem editMenu;
		private System.Windows.Forms.MenuItem preferencesItem;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton New;
		private System.Windows.Forms.ToolBarButton Open;
		private System.Windows.Forms.ToolBarButton save;
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
		private System.Windows.Forms.ToolStripMenuItem saveasToolStripMenuItem;
		private System.Windows.Forms.PropertyGrid PropertyGridAttributes;
		private System.Windows.Forms.ToolBarButton Separator2;
		private System.Windows.Forms.ToolBarButton Separator1;
		
		private string File {
			get { 
				string f = "No Name";
				if (scl != null)
					if (scl.FileName != null)
						f = Path.GetFileName (scl.FileName);
				return f;
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
			this.sclviewertree = new SclViewerTree ();
			// Legacy Tree initialization
			this.Panel2 = new System.Windows.Forms.Panel();
			this.PropertyGridAttributes = new System.Windows.Forms.PropertyGrid();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			
			this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
			this.fileMenu = new System.Windows.Forms.MenuItem();
			this.openItem = new System.Windows.Forms.MenuItem();
			this.exitItem = new System.Windows.Forms.MenuItem();
			this.editMenu = new System.Windows.Forms.MenuItem();
			this.preferencesItem = new System.Windows.Forms.MenuItem();
			this.helpMenu = new System.Windows.Forms.MenuItem();
			this.aboutItem = new System.Windows.Forms.MenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveasToolStripMenuItem = new ToolStripMenuItem ();
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
			this.save = new System.Windows.Forms.ToolBarButton();
			
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
			this.Panel1.Controls.Add(this.sclviewertree);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Panel1.Location = new System.Drawing.Point(0, 0);
			this.Panel1.Name = "Panel1";
			//this.Panel1.Size = new System.Drawing.Size(347, 670);
			this.Panel1.TabIndex = 0;
			this.Panel1.AutoSize = true;
			this.sclviewertree.Anchor = ((System.Windows.Forms.AnchorStyles)
			                            ((((System.Windows.Forms.AnchorStyles.Top 
			                                | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.sclviewertree.Location = new System.Drawing.Point(0, 0);
			this.sclviewertree.Name = "SclTreeViewer";
			this.sclviewertree.Dock = DockStyle.Fill;
			this.sclviewertree.TabIndex = 0;
			this.sclviewertree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.sclviewertreeAfterSelect);
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
									this.exitItem});
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
			this.exitItem.Index = 1;
			this.exitItem.OwnerDraw = true;
			this.exitItem.Text = "Exit";
			this.exitItem.Click += new System.EventHandler(this.exitApp);
			
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
									this.aboutItem});
			this.helpMenu.OwnerDraw = true;
			this.helpMenu.Text = "Help";
			
			// 
			// Help
			// 
			this.helpMenu.Index = 1;
			this.helpMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
									this.aboutItem});
			this.helpMenu.OwnerDraw = true;
			this.helpMenu.Text = "Help";
			// 
			// About
			// 
			this.aboutItem.Index = 0;
			this.aboutItem.OwnerDraw = true;
			this.aboutItem.Text = "About";
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
									this.saveasToolStripMenuItem,
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
			// saveasToolStripMenuItem
			//
			this.saveasToolStripMenuItem.Name = "saveasToolStripMenuItem";
			this.saveasToolStripMenuItem.Text = "Save as...";
			this.saveasToolStripMenuItem.Click += new System.EventHandler(this.SaveAsFile);
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
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
									this.Separator1,
									this.New,
									this.Open,
									this.save,
									this.Separator2});
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
			this.save.ImageIndex = 2;
			this.save.Name = "Salvar";
			this.save.ToolTipText = "Save configuration file";
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
		void NewFile (object sender, EventArgs e)
		{							
			if (modified && scl != null) {
				var res = MessageBox.Show("Do you want to save your work?",
					                	"Creating a new SCL...",
				               			MessageBoxButtons.YesNoCancel,
				                        MessageBoxIcon.Exclamation);
				if (res == DialogResult.Yes) {
					SaveSCLFile (true);
				}
				if (res == DialogResult.Cancel)
					return;
			}
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			
			var scln = new OpenSCL.Object ();
			this.scl = scln;
			
			this.Text = this.AppName + " - " + this.File;
			this.scl.Configuration.AddIED("TEMPLATE");
			this.sclviewertree.scl = this.scl.Configuration;
			this.sclviewertree.title = GetSclTitle ();
			modified = true;
			this.Cursor = System.Windows.Forms.Cursors.Default;
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
		private void OpenFile (object sender, EventArgs e)
		{	
			OpenSCLFile (null, false);
		}

		private string GetSclTitle ()
		{
			string t = "SCL File: ";
			if (this.scl.Configuration.Header == null) {
				this.scl.Configuration.Header = new tHeader ();
			}
			t += this.File + " Ver. " + 
				this.scl.Configuration.Header.version +
				" Rev. " + this.scl.Configuration.Header.revision;
			return t;
		}

		public void OpenSCLFile (string filename, bool validate)
		{
			List<ErrorsManagement> list = new List<ErrorsManagement> ();
			
			if (modified && scl != null)
			{
				var res = MessageBox.Show("Do you want to save your work?",
					            "Openning a new SCL",
				                MessageBoxButtons.YesNoCancel,
				                MessageBoxIcon.Exclamation);
				if (res == DialogResult.Yes) {
					SaveSCLFile (true);
				}
				if (res == DialogResult.Cancel)
					return;
			}
			
			string f = "";
			
			if (filename == null) {
				openDialog dlg = new openDialog ();
				var res = dlg.ShowDialog ();
				if(res == DialogResult.OK)
					f = dlg.FileName;
				else
					return;
			}
			else
				f = filename;
			
			if (validate) {
				//System.Windows.Forms.MessageBox.Show ("OpenDialog: Validating");
				ValidatingSCL val = new ValidatingSCL ();
				list = val.ValidateFile (f, xSDFiles);
			}
			this.PropertyGridAttributes.SelectedObject = null;
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			this.scl = null;
			// Creating an SCL object
			System.Console.WriteLine ("Deserializating file to SCLObject:...");
			System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch ();
			sw.Start ();
			this.scl = new OpenSCL.Object ();
			this.scl.Deserialize (f);
			sw.Stop();
			System.Console.WriteLine ("Enlapsed Time:" + sw.ElapsedMilliseconds + " ms");
			// Creating TreeView
			System.Console.WriteLine ("Creating TreeView:...");
			System.Diagnostics.Stopwatch swt = new System.Diagnostics.Stopwatch();
			swt.Start();
			string t = GetSclTitle ();
			this.sclviewertree.scl = this.scl.Configuration;
			this.sclviewertree.title = t;
			swt.Stop();
			System.Console.WriteLine ("Enlapsed Time:" + swt.ElapsedMilliseconds + " ms");
			modified = false;
			this.Text = this.AppName + " - " + this.File;
			Console.WriteLine ("File: " + scl.FileName + "Openend Modif = " + modified.ToString ());
			this.Cursor = System.Windows.Forms.Cursors.Default;
			
			if (list.Count == 0)
				EnablePanels (null);
			else
				EnablePanels (list);
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
				// Creating a SCL object
				System.Console.WriteLine ("Deserializating file to Import...");
				System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
				sw.Start();
				var ied = new OpenSCL.Object ();
				ied.Deserialize (filename);
				sw.Stop ();
				System.Console.WriteLine ("Enlapsed Time:" + sw.ElapsedMilliseconds + " ms");

				System.Console.WriteLine ("Importing IED:...");
				System.Diagnostics.Stopwatch swt = new System.Diagnostics.Stopwatch();
				swt.Start ();
				// TODO: Add a dialog to show rejected IEDs
				if (this.scl != null)
					this.scl.Configuration.ImportIED (ied.Configuration);
				else
					this.scl = ied;

				swt.Stop();
				System.Console.WriteLine ("Enlapsed Time:"+swt.ElapsedMilliseconds+" ms");

				System.Console.WriteLine ("Creating TreeView:...");
				System.Diagnostics.Stopwatch swc = new System.Diagnostics.Stopwatch ();
				swc.Start ();

				sclviewertree.scl = this.scl.Configuration;
				sclviewertree.title = GetSclTitle ();
				swc.Stop ();
				System.Console.WriteLine ("Enlapsed Time:"+swc.ElapsedMilliseconds+" ms");

				modified = true;
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
		private void SaveFile (object sender, EventArgs e)
		{
			SaveSCLFile (true);
		}
		
		private void SaveAsFile (object sender, EventArgs e)
		{
			SaveSCLFile (false);
		}
		
		private void SaveSCLFile (bool save)
		{
			if (this.scl == null) {
				MessageBox.Show ("You must create or open an SCL file",
					            "Warnning",
				                MessageBoxButtons.OK,
				                MessageBoxIcon.Information);
				return;
			}
			
			if (save && scl.FileName != null) {
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.scl.Serialize ();
				modified = false;
				this.Cursor = System.Windows.Forms.Cursors.Default;
				System.Console.WriteLine ("Saved...");
				return;
			}
			else {
				SaveFileDialog saveDlg = new SaveFileDialog ();
				saveDlg.Title = "Save As ...";
				saveDlg.Filter = filter;
				saveDlg.CheckPathExists = true;
				saveDlg.DefaultExt = "scd";
				saveDlg.OverwritePrompt = true;
				saveDlg.ValidateNames = true;
				if(saveDlg.ShowDialog () == DialogResult.OK)
				{
	                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					this.scl.Serialize (saveDlg.FileName);
					this.Text = this.AppName + " - " + this.File;
					modified = false;
					this.Cursor = System.Windows.Forms.Cursors.Default;
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
		private void ValidateFileClick (object sender, EventArgs e)
		{
			List<ErrorsManagement> list = new List<ErrorsManagement> ();
			string f = "";
			openDialog dlg = new openDialog ();
			var res = dlg.ShowDialog ();
			if(res == DialogResult.OK)
				f = dlg.FileName;
			else
				return;
			try {
				ValidatingSCL val = new ValidatingSCL ();
				list = val.ValidateFile (f, xSDFiles);
				if (list.Count > 0) {
					string msg = "";
					for (int i = 0; i < list.Count; i++) {
						msg += list[i].ErrorMessage + "\n";
					}
					MessageBox.Show ("Validation has found issues in SCL file:\n\n"
				                 + msg,
				                 "Validation finished",
				                 MessageBoxButtons.OK,
				                 MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex) {
				MessageBox.Show ("Validation has thrown an Error:\n\n"
				                 + ex.Message,
				                 "Validation Stoped",
				                 MessageBoxButtons.OK,
				                 MessageBoxIcon.Error);
			}
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
			if (this.sclviewertree.Nodes != null && this.sclviewertree.Nodes.Count > 0)
			{			
				var listError = new List<ErrorsManagement> ();
				openDialog dlg = new openDialog ();
				dlg.ImportIED = true;
				if (dlg.ShowDialog () == DialogResult.OK) {
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					listError = ImportIED (dlg.FileName, validate);
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
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
			CheckSaved ();
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
		void sclviewertreeAfterSelect (object sender, TreeViewEventArgs e)
		{
			if (e.Node is GenericNode) {
				GenericNode node = (GenericNode) e.Node;
				if (node.Tag == null)
					System.Console.WriteLine ("NO OBJECT");
				else
					System.Console.WriteLine ("Selected Object is: " + node.Tag.GetType ().ToString ());
				if (!(node.Tag is Array))
					this.PropertyGridAttributes.SelectedObject = node.Tag;
			}
		}
		
		void OnContextChanged (System.Object o, EventArgs args)
		{
			modified = true;
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
			Panel1.Controls.Add(this.sclviewertree);
		}

		void CheckSaved ()
		{
			if (modified == true) {
				if (MessageBox.Show("Do you want to save the changes on this file \n", "Save File",
				                    MessageBoxButtons.YesNo,
				                    MessageBoxIcon.Exclamation) == DialogResult.Yes)
				{
					SaveFile (null, null);
				}
			}
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
			CheckSaved ();
		}

		void PropertyGridAttributesPropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			modified = true;
		}
	} 	
}
