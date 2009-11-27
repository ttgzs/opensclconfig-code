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

namespace OpenSCL.UI
{
	partial class LNodeDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.textBoxlnType = new System.Windows.Forms.TextBox();
			this.labellnType = new System.Windows.Forms.Label();
			this.textBoxlnClass = new System.Windows.Forms.TextBox();
			this.textBoxlnInst = new System.Windows.Forms.TextBox();
			this.textBoxldInst = new System.Windows.Forms.TextBox();
			this.labellnClass = new System.Windows.Forms.Label();
			this.labellnInst = new System.Windows.Forms.Label();
			this.labelldInst = new System.Windows.Forms.Label();
			this.textBoxiedName = new System.Windows.Forms.TextBox();
			this.labeliedName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonCANCEL = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.comboBoxtLNode = new System.Windows.Forms.ComboBox();
			this.groupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.textBoxlnType);
			this.groupBox.Controls.Add(this.labellnType);
			this.groupBox.Controls.Add(this.textBoxlnClass);
			this.groupBox.Controls.Add(this.textBoxlnInst);
			this.groupBox.Controls.Add(this.textBoxldInst);
			this.groupBox.Controls.Add(this.labellnClass);
			this.groupBox.Controls.Add(this.labellnInst);
			this.groupBox.Controls.Add(this.labelldInst);
			this.groupBox.Controls.Add(this.textBoxiedName);
			this.groupBox.Controls.Add(this.labeliedName);
			this.groupBox.Controls.Add(this.label1);
			this.groupBox.Controls.Add(this.buttonCANCEL);
			this.groupBox.Controls.Add(this.buttonOK);
			this.groupBox.Controls.Add(this.comboBoxtLNode);
			this.groupBox.Location = new System.Drawing.Point(12, 12);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(565, 390);
			this.groupBox.TabIndex = 0;
			this.groupBox.TabStop = false;
			// 
			// textBoxlnType
			// 
			this.textBoxlnType.Location = new System.Drawing.Point(93, 261);
			this.textBoxlnType.Name = "textBoxlnType";
			this.textBoxlnType.ReadOnly = true;
			this.textBoxlnType.Size = new System.Drawing.Size(149, 20);
			this.textBoxlnType.TabIndex = 13;
			// 
			// labellnType
			// 
			this.labellnType.Location = new System.Drawing.Point(26, 261);
			this.labellnType.Name = "labellnType";
			this.labellnType.Size = new System.Drawing.Size(100, 23);
			this.labellnType.TabIndex = 12;
			this.labellnType.Text = "lnType";
			// 
			// textBoxlnClass
			// 
			this.textBoxlnClass.Location = new System.Drawing.Point(93, 221);
			this.textBoxlnClass.Name = "textBoxlnClass";
			this.textBoxlnClass.ReadOnly = true;
			this.textBoxlnClass.Size = new System.Drawing.Size(149, 20);
			this.textBoxlnClass.TabIndex = 11;
			// 
			// textBoxlnInst
			// 
			this.textBoxlnInst.Location = new System.Drawing.Point(93, 179);
			this.textBoxlnInst.Name = "textBoxlnInst";
			this.textBoxlnInst.ReadOnly = true;
			this.textBoxlnInst.Size = new System.Drawing.Size(149, 20);
			this.textBoxlnInst.TabIndex = 10;
			// 
			// textBoxldInst
			// 
			this.textBoxldInst.Location = new System.Drawing.Point(93, 131);
			this.textBoxldInst.Name = "textBoxldInst";
			this.textBoxldInst.ReadOnly = true;
			this.textBoxldInst.Size = new System.Drawing.Size(149, 20);
			this.textBoxldInst.TabIndex = 9;
			// 
			// labellnClass
			// 
			this.labellnClass.Location = new System.Drawing.Point(26, 224);
			this.labellnClass.Name = "labellnClass";
			this.labellnClass.Size = new System.Drawing.Size(100, 23);
			this.labellnClass.TabIndex = 8;
			this.labellnClass.Text = "lnClass";
			// 
			// labellnInst
			// 
			this.labellnInst.Location = new System.Drawing.Point(26, 179);
			this.labellnInst.Name = "labellnInst";
			this.labellnInst.Size = new System.Drawing.Size(100, 23);
			this.labellnInst.TabIndex = 7;
			this.labellnInst.Text = "lnInst";
			// 
			// labelldInst
			// 
			this.labelldInst.Location = new System.Drawing.Point(26, 134);
			this.labelldInst.Name = "labelldInst";
			this.labelldInst.Size = new System.Drawing.Size(100, 23);
			this.labelldInst.TabIndex = 6;
			this.labelldInst.Text = "ldInst";
			// 
			// textBoxiedName
			// 
			this.textBoxiedName.Location = new System.Drawing.Point(93, 89);
			this.textBoxiedName.Name = "textBoxiedName";
			this.textBoxiedName.ReadOnly = true;
			this.textBoxiedName.Size = new System.Drawing.Size(149, 20);
			this.textBoxiedName.TabIndex = 5;
			// 
			// labeliedName
			// 
			this.labeliedName.Location = new System.Drawing.Point(26, 89);
			this.labeliedName.Name = "labeliedName";
			this.labeliedName.Size = new System.Drawing.Size(100, 23);
			this.labeliedName.TabIndex = 4;
			this.labeliedName.Text = "iedName";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(26, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "LNode";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// buttonCANCEL
			// 
			this.buttonCANCEL.Location = new System.Drawing.Point(409, 341);
			this.buttonCANCEL.Name = "buttonCANCEL";
			this.buttonCANCEL.Size = new System.Drawing.Size(75, 23);
			this.buttonCANCEL.TabIndex = 2;
			this.buttonCANCEL.Text = "Cancel";
			this.buttonCANCEL.UseVisualStyleBackColor = true;
			this.buttonCANCEL.Click += new System.EventHandler(this.ButtonCANCELClick);
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(60, 341);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "Ok";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
			// 
			// comboBoxtLNode
			// 
			this.comboBoxtLNode.FormattingEnabled = true;
			this.comboBoxtLNode.Location = new System.Drawing.Point(93, 33);
			this.comboBoxtLNode.MaxDropDownItems = 15;
			this.comboBoxtLNode.Name = "comboBoxtLNode";
			this.comboBoxtLNode.Size = new System.Drawing.Size(391, 21);
			this.comboBoxtLNode.TabIndex = 0;
			this.comboBoxtLNode.SelectedValueChanged += new System.EventHandler(this.ComboBoxtLNodeSelectedValueChanged);
			// 
			// WindowLNode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(589, 414);
			this.Controls.Add(this.groupBox);
			this.Name = "WindowLNode";
			this.Text = "tSubstation";
			this.Load += new System.EventHandler(this.TSubstationLoad);
			this.groupBox.ResumeLayout(false);
			this.groupBox.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox textBoxlnInst;
		private System.Windows.Forms.Label labeliedName;
		private System.Windows.Forms.TextBox textBoxiedName;
		private System.Windows.Forms.Label labelldInst;
		private System.Windows.Forms.Label labellnInst;
		private System.Windows.Forms.Label labellnClass;
		private System.Windows.Forms.TextBox textBoxldInst;
		private System.Windows.Forms.TextBox textBoxlnClass;
		private System.Windows.Forms.Label labellnType;
		private System.Windows.Forms.TextBox textBoxlnType;
		private System.Windows.Forms.GroupBox groupBox;
		private System.Windows.Forms.ComboBox comboBoxtLNode;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCANCEL;		
		private System.Windows.Forms.Label label1;
	}
}
