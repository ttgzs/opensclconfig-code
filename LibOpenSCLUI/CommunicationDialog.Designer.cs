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
	partial class CommunicationDialog
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
			this.nameSubNet = new System.Windows.Forms.TextBox();
			this.nameSubNetCB = new System.Windows.Forms.ComboBox();
			this.descSubNet = new System.Windows.Forms.TextBox();
			this.APnam = new System.Windows.Forms.TextBox();
			this.iedNam = new System.Windows.Forms.TextBox();
			this.appdesc = new System.Windows.Forms.Label();
			this.license = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.descLabel = new System.Windows.Forms.Label();
			this.newSubNet = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ssel = new System.Windows.Forms.MaskedTextBox();
			this.psel = new System.Windows.Forms.MaskedTextBox();
			this.tsel = new System.Windows.Forms.MaskedTextBox();
			this.gateway = new System.Windows.Forms.MaskedTextBox();
			this.mask = new System.Windows.Forms.MaskedTextBox();
			this.ip = new System.Windows.Forms.MaskedTextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.appcopyright = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.nameSubNet);
			this.groupBox1.Controls.Add(this.nameSubNetCB);
			this.groupBox1.Controls.Add(this.descSubNet);
			this.groupBox1.Controls.Add(this.APnam);
			this.groupBox1.Controls.Add(this.iedNam);
			this.groupBox1.Controls.Add(this.appdesc);
			this.groupBox1.Controls.Add(this.license);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.descLabel);
			this.groupBox1.Controls.Add(this.newSubNet);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(336, 156);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "ConnectedAP";
			// 
			// nameSubNet
			// 
			this.nameSubNet.Location = new System.Drawing.Point(142, 38);
			this.nameSubNet.Name = "nameSubNet";
			this.nameSubNet.Size = new System.Drawing.Size(173, 20);
			this.nameSubNet.TabIndex = 1;
			this.nameSubNet.Visible = false;
			// 
			// nameSubNetCB
			// 
			this.nameSubNetCB.AllowDrop = true;
			this.nameSubNetCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.nameSubNetCB.FormattingEnabled = true;
			this.nameSubNetCB.Location = new System.Drawing.Point(142, 38);
			this.nameSubNetCB.Name = "nameSubNetCB";
			this.nameSubNetCB.Size = new System.Drawing.Size(174, 21);
			this.nameSubNetCB.TabIndex = 1;
			this.nameSubNetCB.SelectedIndexChanged += new System.EventHandler(this.nameSubNetCBChange);
			// 
			// descSubNet
			// 
			this.descSubNet.Location = new System.Drawing.Point(143, 65);
			this.descSubNet.Name = "descSubNet";
			this.descSubNet.Size = new System.Drawing.Size(173, 20);
			this.descSubNet.TabIndex = 7;
			// 
			// APnam
			// 
			this.APnam.Location = new System.Drawing.Point(142, 118);
			this.APnam.Name = "APnam";
			this.APnam.Size = new System.Drawing.Size(174, 20);
			this.APnam.TabIndex = 5;
			// 
			// iedNam
			// 
			this.iedNam.Location = new System.Drawing.Point(143, 90);
			this.iedNam.Name = "iedNam";
			this.iedNam.Size = new System.Drawing.Size(173, 20);
			this.iedNam.TabIndex = 4;
			// 
			// label3
			// 
			this.appdesc.Location = new System.Drawing.Point(10, 121);
			this.appdesc.Name = "label3";
			this.appdesc.Size = new System.Drawing.Size(132, 23);
			this.appdesc.TabIndex = 2;
			this.appdesc.Text = "Access Point Name:";
			// 
			// label2
			// 
			this.license.Location = new System.Drawing.Point(10, 93);
			this.license.Name = "label2";
			this.license.Size = new System.Drawing.Size(132, 23);
			this.license.TabIndex = 1;
			this.license.Text = "IED Name:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(132, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "SubNetwork Name:";
			// 
			// descLabel
			// 
			this.descLabel.Location = new System.Drawing.Point(10, 69);
			this.descLabel.Name = "descLabel";
			this.descLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.descLabel.Size = new System.Drawing.Size(132, 23);
			this.descLabel.TabIndex = 6;
			this.descLabel.Text = "Description:";
			// 
			// newSubNet
			// 
			this.newSubNet.Location = new System.Drawing.Point(142, 16);
			this.newSubNet.Name = "newSubNet";
			this.newSubNet.Size = new System.Drawing.Size(143, 24);
			this.newSubNet.TabIndex = 11;
			this.newSubNet.Text = "New SubNetwork";
			this.newSubNet.UseVisualStyleBackColor = true;
			this.newSubNet.CheckedChanged += new System.EventHandler(this.NewSubNetCheckedChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ssel);
			this.groupBox2.Controls.Add(this.psel);
			this.groupBox2.Controls.Add(this.tsel);
			this.groupBox2.Controls.Add(this.gateway);
			this.groupBox2.Controls.Add(this.mask);
			this.groupBox2.Controls.Add(this.ip);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.appcopyright);
			this.groupBox2.Location = new System.Drawing.Point(13, 174);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(335, 196);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Address";
			// 
			// ssel
			// 
			this.ssel.Location = new System.Drawing.Point(141, 160);
			this.ssel.Name = "ssel";
			this.ssel.Size = new System.Drawing.Size(174, 20);
			this.ssel.TabIndex = 11;
			// 
			// psel
			// 
			this.psel.Location = new System.Drawing.Point(142, 133);
			this.psel.Name = "psel";
			this.psel.Size = new System.Drawing.Size(173, 20);
			this.psel.TabIndex = 10;
			// 
			// tsel
			// 
			this.tsel.Location = new System.Drawing.Point(142, 105);
			this.tsel.Name = "tsel";
			this.tsel.Size = new System.Drawing.Size(173, 20);
			this.tsel.TabIndex = 9;
			// 
			// gateway
			// 
			this.gateway.Location = new System.Drawing.Point(142, 78);
			this.gateway.Name = "gateway";
			this.gateway.Size = new System.Drawing.Size(173, 20);
			this.gateway.TabIndex = 8;
			// 
			// mask
			// 
			this.mask.Location = new System.Drawing.Point(141, 51);
			this.mask.Name = "mask";
			this.mask.Size = new System.Drawing.Size(174, 20);
			this.mask.TabIndex = 7;
			this.mask.Text = "255.255.255.0";
			// 
			// ip
			// 
			this.ip.Location = new System.Drawing.Point(141, 23);
			this.ip.Name = "ip";
			this.ip.Size = new System.Drawing.Size(174, 20);
			this.ip.TabIndex = 6;
			this.ip.Text = "192.168.1.1";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(9, 162);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(132, 23);
			this.label9.TabIndex = 5;
			this.label9.Text = "OSI - SSEL:";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(9, 135);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(132, 23);
			this.label8.TabIndex = 4;
			this.label8.Text = "OSI - PSEL:";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(9, 108);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(132, 23);
			this.label7.TabIndex = 3;
			this.label7.Text = "OSI - TSEL:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(9, 81);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(132, 23);
			this.label6.TabIndex = 2;
			this.label6.Text = "Gateway:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(9, 53);
			this.label5.Name = "label5";
			this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label5.Size = new System.Drawing.Size(132, 23);
			this.label5.TabIndex = 1;
			this.label5.Text = "Subnetwork mask:";
			// 
			// label4
			// 
			this.appcopyright.Location = new System.Drawing.Point(9, 27);
			this.appcopyright.Name = "label4";
			this.appcopyright.Size = new System.Drawing.Size(132, 23);
			this.appcopyright.TabIndex = 0;
			this.appcopyright.Text = "IP Address:";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(66, 394);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 12;
			this.btnOK.Text = "Ok";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOKClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(225, 393);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancelClick);
			// 
			// CommunicationDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(362, 439);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "CommunicationDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Connection to a SubNetwork";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.AcceptButton = btnOK;
			this.AcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CancelButton = btnCancel;
			this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}
		private System.Windows.Forms.CheckBox newSubNet;
		private System.Windows.Forms.ComboBox nameSubNetCB;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox descSubNet;
		private System.Windows.Forms.TextBox nameSubNet;
		private System.Windows.Forms.TextBox iedNam;
		private System.Windows.Forms.TextBox APnam;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.MaskedTextBox ip;
		private System.Windows.Forms.MaskedTextBox mask;
		private System.Windows.Forms.MaskedTextBox gateway;
		private System.Windows.Forms.MaskedTextBox tsel;
		private System.Windows.Forms.MaskedTextBox psel;
		private System.Windows.Forms.MaskedTextBox ssel;
	
		private System.Windows.Forms.Label descLabel;
		private System.Windows.Forms.Label appcopyright;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label license;
		private System.Windows.Forms.Label appdesc;				
		private System.Windows.Forms.GroupBox groupBox1;
	}
		

}
