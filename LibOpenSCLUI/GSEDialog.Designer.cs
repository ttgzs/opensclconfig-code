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

using IEC61850.SCL;

namespace OpenSCL.UI
{
	partial class GSEDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">
		/// true if managed resources should be disposed; otherwise, false.
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
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
//			this.groupBox1 = new System.Windows.Forms.GroupBox();
			//this.gseProperty = new System.Windows.Forms.PropertyGrid();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.datSet = new System.Windows.Forms.ComboBox();
			this.datSetLabel = new System.Windows.Forms.Label();
			this.vLANI = new System.Windows.Forms.MaskedTextBox();
			this.appId = new System.Windows.Forms.MaskedTextBox();
			this.desc2 = new System.Windows.Forms.TextBox();
			this.vLANP = new System.Windows.Forms.MaskedTextBox();
			this.mac = new System.Windows.Forms.MaskedTextBox();
			this.cbName = new System.Windows.Forms.TextBox();
			this.IdInst = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
//			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			//this.groupBox1.Controls.Add(this.gseProperty);
//			this.groupBox1.Location = new System.Drawing.Point(12, 12);
//			this.groupBox1.Name = "groupBox1";
//			this.groupBox1.Size = new System.Drawing.Size(295, 267);
//			this.groupBox1.TabIndex = 0;
//			this.groupBox1.TabStop = false;
//			this.groupBox1.Text = "GOOSE Controls";
			// 
			// gseProperty
			// 
//			this.gseProperty.Dock = System.Windows.Forms.DockStyle.Fill;
//			this.gseProperty.Location = new System.Drawing.Point(3, 16);
//			this.gseProperty.Name = "gseProperty";
//			this.gseProperty.Size = new System.Drawing.Size(289, 248);
//			this.gseProperty.TabIndex = 5;
//			this.gseProperty.ToolbarVisible = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.datSet);
			this.groupBox2.Controls.Add(this.datSetLabel);
			this.groupBox2.Controls.Add(this.vLANI);
			this.groupBox2.Controls.Add(this.appId);
			this.groupBox2.Controls.Add(this.desc2);
			this.groupBox2.Controls.Add(this.vLANP);
			this.groupBox2.Controls.Add(this.mac);
			this.groupBox2.Controls.Add(this.cbName);
			this.groupBox2.Controls.Add(this.IdInst);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Location = new System.Drawing.Point(12, 285);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(295, 234);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "GOOSE Network";
			// 
			// datSet
			// 
			this.datSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.datSet.FormattingEnabled = true;
			this.datSet.Location = new System.Drawing.Point(137, 56);
			this.datSet.Name = "datSet";
			this.datSet.Size = new System.Drawing.Size(121, 21);
			this.datSet.TabIndex = 14;
			var l = new System.Collections.ArrayList ();
			if (ld.LN0.DataSet != null)
				foreach (tDataSet dt in ld.LN0.DataSet) {
					l.Add (dt.name);
				}
			this.datSet.DataSource = l;
			// 
			// datSetLabel
			// 
			this.datSetLabel.Location = new System.Drawing.Point(85, 60);
			this.datSetLabel.Name = "datSetLabel";
			this.datSetLabel.Size = new System.Drawing.Size(100, 23);
			this.datSetLabel.TabIndex = 15;
			this.datSetLabel.Text = "Dataset:";
			// 
			// vLANI
			// 
			this.vLANI.Location = new System.Drawing.Point(136, 164);
			this.vLANI.Name = "vLANI";
			this.vLANI.Size = new System.Drawing.Size(122, 20);
			this.vLANI.TabIndex = 12;
			this.vLANI.Text = "0";
			// 
			// appId
			// 
			this.appId.Location = new System.Drawing.Point(136, 110);
			this.appId.Name = "appId";
			this.appId.Size = new System.Drawing.Size(122, 20);
			this.appId.TabIndex = 10;
			this.appId.Text = "0x0000";
			// 
			// desc2
			// 
			this.desc2.Location = new System.Drawing.Point(136, 190);
			this.desc2.Name = "desc2";
			this.desc2.Size = new System.Drawing.Size(122, 20);
			this.desc2.TabIndex = 13;
			// 
			// vLANP
			// 
			this.vLANP.Location = new System.Drawing.Point(136, 136);
			this.vLANP.Name = "vLANP";
			this.vLANP.Size = new System.Drawing.Size(122, 20);
			this.vLANP.TabIndex = 11;
			this.vLANP.Text = "4";
			// 
			// mac
			// 
			this.mac.Location = new System.Drawing.Point(136, 83);
			this.mac.Name = "mac";
			this.mac.Size = new System.Drawing.Size(122, 20);
			this.mac.TabIndex = 9;
			this.mac.Mask = "AA-AA-AA-AA-AA-AA";
			this.mac.Text = "01:0c:cd:01:00:00";
			// 
			// cbName
			// 
			this.cbName.Enabled = false;
			this.cbName.Location = new System.Drawing.Point(136, 57);
			this.cbName.Name = "cbName";
			this.cbName.Size = new System.Drawing.Size(122, 20);
			this.cbName.TabIndex = 8;
			this.cbName.Visible = false;
			// 
			// IdInst
			// 
			this.IdInst.Enabled = false;
			this.IdInst.Location = new System.Drawing.Point(136, 31);
			this.IdInst.Name = "IdInst";
			this.IdInst.Size = new System.Drawing.Size(122, 20);
			this.IdInst.TabIndex = 7;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(69, 192);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(100, 23);
			this.label13.TabIndex = 6;
			this.label13.Text = "Description:";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(80, 167);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 23);
			this.label12.TabIndex = 5;
			this.label12.Text = "VLAN ID:";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(60, 138);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 23);
			this.label11.TabIndex = 4;
			this.label11.Text = "VLAN Priority:";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(56, 112);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 3;
			this.label10.Text = "Application ID:";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(58, 85);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 2;
			this.label9.Text = "MAC Address:";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(3, 61);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(132, 23);
			this.label8.TabIndex = 1;
			this.label8.Text = "GSE Control Block Name:";
			this.label8.Visible = false;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(31, 34);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(109, 23);
			this.label7.TabIndex = 0;
			this.label7.Text = "Logical Device Inst:";
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(48, 525);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 25);
			this.okButton.TabIndex = 2;
			this.okButton.Text = "Ok";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OkButtonClick);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Location = new System.Drawing.Point(193, 525);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 25);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			this.CancelBtn.Click += new System.EventHandler(this.CancelBtnClick);
			// 
			// GSEDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(319, 558);
			this.ControlBox = false;
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.groupBox2);
//			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GSEDialog";
			this.Opacity = 0.9;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
//			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.AcceptButton = okButton;
			this.AcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CancelButton = CancelBtn;
			this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}
		private System.Windows.Forms.Label datSetLabel;
		private System.Windows.Forms.ComboBox datSet;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.TextBox cbName;
		private System.Windows.Forms.TextBox IdInst;
		private System.Windows.Forms.MaskedTextBox vLANI;
		private System.Windows.Forms.MaskedTextBox vLANP;
		private System.Windows.Forms.TextBox desc2;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.MaskedTextBox mac;
		private System.Windows.Forms.MaskedTextBox appId;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox2;
//		private System.Windows.Forms.GroupBox groupBox1;
	}
}
