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
	partial class SMVDialog
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.desc = new System.Windows.Forms.TextBox();
			this.vLANI = new System.Windows.Forms.MaskedTextBox();
			this.vLANP = new System.Windows.Forms.MaskedTextBox();
			this.appID = new System.Windows.Forms.MaskedTextBox();
			this.mac = new System.Windows.Forms.MaskedTextBox();
			this.ldInst = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.propertySMV = new System.Windows.Forms.PropertyGrid();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.propertyOptions = new System.Windows.Forms.PropertyGrid();
			this.BtnOKSMV = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.datSet = new System.Windows.Forms.ComboBox();
			this.datasetLabel = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.desc);
			this.groupBox1.Controls.Add(this.vLANI);
			this.groupBox1.Controls.Add(this.vLANP);
			this.groupBox1.Controls.Add(this.appID);
			this.groupBox1.Controls.Add(this.mac);
			this.groupBox1.Controls.Add(this.ldInst);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(342, 239);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(233, 245);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "SMV Network";
			// 
			// desc
			// 
			this.desc.Location = new System.Drawing.Point(94, 209);
			this.desc.Name = "desc";
			this.desc.Size = new System.Drawing.Size(122, 20);
			this.desc.TabIndex = 12;
			// 
			// vLANI
			// 
			this.vLANI.Location = new System.Drawing.Point(94, 175);
			this.vLANI.Name = "vLANI";
			this.vLANI.Size = new System.Drawing.Size(122, 20);
			this.vLANI.TabIndex = 11;
			// 
			// vLANP
			// 
			this.vLANP.Location = new System.Drawing.Point(94, 141);
			this.vLANP.Name = "vLANP";
			this.vLANP.Size = new System.Drawing.Size(122, 20);
			this.vLANP.TabIndex = 10;
			// 
			// appID
			// 
			this.appID.Location = new System.Drawing.Point(94, 107);
			this.appID.Name = "appID";
			this.appID.Size = new System.Drawing.Size(122, 20);
			this.appID.TabIndex = 9;
			// 
			// mac
			// 
			this.mac.Location = new System.Drawing.Point(94, 71);
			this.mac.Name = "mac";
			this.mac.Size = new System.Drawing.Size(122, 20);
			this.mac.TabIndex = 8;
			// 
			// ldInst
			// 
			this.ldInst.Location = new System.Drawing.Point(94, 35);
			this.ldInst.Name = "ldInst";
			this.ldInst.Size = new System.Drawing.Size(122, 20);
			this.ldInst.TabIndex = 7;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(21, 212);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 6;
			this.label7.Text = "Description:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(33, 178);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 5;
			this.label6.Text = "VLAN ID:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(13, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "VLAN Priority:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(10, 111);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 3;
			this.label4.Text = "Application ID:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(14, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "MAC Address:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(43, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "LD Inst:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.propertySMV);
			this.groupBox2.Location = new System.Drawing.Point(12, 20);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(311, 380);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Sampled Value Control Options";
			// 
			// propertySMV
			// 
			this.propertySMV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertySMV.Location = new System.Drawing.Point(3, 16);
			this.propertySMV.Name = "propertySMV";
			this.propertySMV.Size = new System.Drawing.Size(305, 361);
			this.propertySMV.TabIndex = 0;
			this.propertySMV.ToolbarVisible = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.propertyOptions);
			this.groupBox3.Location = new System.Drawing.Point(342, 20);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(233, 213);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "SMV Options";
			// 
			// propertyOptions
			// 
			this.propertyOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyOptions.Location = new System.Drawing.Point(3, 16);
			this.propertyOptions.Name = "propertyOptions";
			this.propertyOptions.Size = new System.Drawing.Size(227, 194);
			this.propertyOptions.TabIndex = 0;
			this.propertyOptions.ToolbarVisible = false;
			// 
			// BtnOKSMV
			// 
			this.BtnOKSMV.Location = new System.Drawing.Point(68, 472);
			this.BtnOKSMV.Name = "BtnOKSMV";
			this.BtnOKSMV.Size = new System.Drawing.Size(75, 23);
			this.BtnOKSMV.TabIndex = 2;
			this.BtnOKSMV.Text = "Ok";
			this.BtnOKSMV.UseVisualStyleBackColor = true;
			this.BtnOKSMV.Click += new System.EventHandler(this.BtnOKSMVClick);
			// 
			// CancelBtn
			// 
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(200, 472);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 3;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			this.CancelBtn.Click += new System.EventHandler(this.CancelBtnClick);
			// 
			// datSet
			// 
			this.datSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.datSet.FormattingEnabled = true;
			this.datSet.Location = new System.Drawing.Point(128, 416);
			this.datSet.Name = "datSet";
			this.datSet.Size = new System.Drawing.Size(121, 21);
			this.datSet.TabIndex = 4;
			// 
			// datasetLabel
			// 
			this.datasetLabel.Location = new System.Drawing.Point(78, 419);
			this.datasetLabel.Name = "datasetLabel";
			this.datasetLabel.Size = new System.Drawing.Size(100, 23);
			this.datasetLabel.TabIndex = 5;
			this.datasetLabel.Text = "Dataset:";
			// 
			// SMVDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(597, 534);
			this.ControlBox = false;
			this.Controls.Add(this.datSet);
			this.Controls.Add(this.datasetLabel);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.BtnOKSMV);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SMVDialog";
			this.Opacity = 0.9;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TransparencyKey = System.Drawing.Color.Red;
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label datasetLabel;
		private System.Windows.Forms.ComboBox datSet;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button BtnOKSMV;
		private System.Windows.Forms.PropertyGrid propertySMV;
		private System.Windows.Forms.PropertyGrid propertyOptions;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox desc;
		private System.Windows.Forms.MaskedTextBox vLANI;
		private System.Windows.Forms.MaskedTextBox vLANP;
		private System.Windows.Forms.MaskedTextBox appID;
		private System.Windows.Forms.MaskedTextBox mac;
		private System.Windows.Forms.TextBox ldInst;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
