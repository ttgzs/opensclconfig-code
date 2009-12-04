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

using System.Windows.Forms;

namespace OpenSCL.UI
{
	partial class WindowTreeViewLNType
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// This method disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">
		/// If managed resources should be disposed it has a True value; otherwise, a false is assigned.
		/// </param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might not be able to load 
		/// this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			//this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.splitContainer1 = new SplitContainer();
			this.panel1 = new Panel();
			this.panel2 = new Panel();
			this.treeLN = new System.Windows.Forms.TreeView();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.propertyGridLNType = new System.Windows.Forms.PropertyGrid();
			//this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			
			this.panel1.Controls.Add (this.treeLN);
			this.panel1.Dock = DockStyle.Fill;
			this.panel1.Name = "TreePanel";
			this.panel1.AutoSize = true;
			
			this.panel2.Controls.Add (this.propertyGridLNType);
			this.panel2.Dock = DockStyle.Fill;
			this.panel2.Name = "PropertiesPanel";
			this.panel2.AutoSize = true;
			
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Location = new System.Drawing.Point(0, 52);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Dock = DockStyle.Fill;
			this.splitContainer1.Panel1.Controls.Add (this.panel1);
			this.splitContainer1.Panel2.Controls.Add (this.panel2);
			this.splitContainer1.Panel1.AutoScroll = true;
			this.splitContainer1.Panel2.AutoScroll = true;
			// 
			// label1
			// 
			// Point(478, 521);
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(478, 621);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "Attributes in Blue are required";
			// 
			// label2
			// 
//			this.label2.Location = new System.Drawing.Point(this.label1.Left, 
//			                                                this.label1.Height + this.label1.Top + 57);
//			this.label2.Name = "label2";
//			this.label2.Size = new System.Drawing.Size(545, 421);
//			this.label2.TabIndex = 7;
//			this.label2.Text = "is Required";
			// 
			// groupBox1
			// 
//			this.groupBox1.Controls.Add(this.label2);
//			this.groupBox1.Controls.Add(this.label1);
//			this.groupBox1.Controls.Add(this.treeLN);
//			this.groupBox1.Location = new System.Drawing.Point(this.label1.Left, 
//			                                                   this.label1.Height + this.label1.Top+ 24);
//			this.groupBox1.Name = "groupBox1";
//			this.groupBox1.Size = new System.Drawing.Size(300, 461);
//			this.groupBox1.Dock = DockStyle.Fill;
//			this.groupBox1.TabIndex = 0;
//			this.groupBox1.TabStop = false;
//			
			// 
			// treeLN
			// 
			this.treeLN.CheckBoxes = true;
			this.treeLN.Location = new System.Drawing.Point(6, 35);
			this.treeLN.Name = "treeLN";
			this.treeLN.Dock = DockStyle.Fill;
			this.treeLN.Scrollable = true;
			this.treeLN.Size = new System.Drawing.Size(468, 461);
			//this.treeLN.AutoSize = true;
			this.treeLN.TabIndex = 5;
			this.treeLN.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeLNAfterCheck);
			this.treeLN.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeLNAfterSelect);
			this.treeLN.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeLNBeforeCheck);
			
			// 
			// propertyGridLNType
			// 
			//this.propertyGridLNType.Location = new System.Drawing.Point(366, 12);
			this.propertyGridLNType.Name = "propertyGridLNType";
			this.propertyGridLNType.Size = new System.Drawing.Size(468, 461);
			this.propertyGridLNType.TabIndex = 1;
			this.propertyGridLNType.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropertyLNTypeValueChanged);
			
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(528, 521);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.DialogResult = DialogResult.Cancel;
			this.CancelButton = this.buttonCancel;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(620, 521);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 3;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.DialogResult = DialogResult.OK;
			this.AcceptButton = this.buttonOk;
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			
			// 
			// WindowTreeViewLNType
			// 
			//this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			//this.ClientSize = new System.Drawing.Size(892, 566);
			//this.ControlBox = false;
			//this.Controls.Add(this.propertyGridLNType);
			this.Size = new System.Drawing.Size (800, 580);
			//this.Controls.Add(this.label1);
			//this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.splitContainer1);
			this.MaximizeBox = false;
			//this.MaximumSize = new System.Drawing.Size(900, 600);
			this.MinimizeBox = false;
			//this.MinimumSize = new System.Drawing.Size(900, 600);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.Name = "WindowTreeViewLNType";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Editing Logical Node Data Objects";
			this.TopMost = true;
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			
			//this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}		
		private System.Windows.Forms.TreeView treeLN;	
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PropertyGrid propertyGridLNType;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.GroupBox groupBox1;	
		private	System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
	}
}

