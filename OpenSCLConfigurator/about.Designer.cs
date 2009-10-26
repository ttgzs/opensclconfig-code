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

namespace OpenSCLConfigurator
{
	partial class about
	{	
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// This method disposes the resources used by the form.
		/// </summary>
		/// <param name="disposing">
		/// It returns a TRUE value if managed resources should be disposed; 
		/// otherwise, a FALSE value is returned.
		/// </param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method inicializes the components of the form.
		/// </summary>
		/// <remarks>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. 
		/// The Forms designer might not be able to load this method if it 
		/// was changed manually.
		/// </remarks>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(about));
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabAbout = new System.Windows.Forms.TabPage();
			this.richTextBox2 = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tabVersion = new System.Windows.Forms.TabPage();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.tabDevelop = new System.Windows.Forms.TabPage();
			this.richTextBox3 = new System.Windows.Forms.RichTextBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabAbout.SuspendLayout();
			this.tabVersion.SuspendLayout();
			this.tabDevelop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(428, 378);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(87, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Ok";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.OKAboutClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(288, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(138, 27);
			this.label1.TabIndex = 1;
			this.label1.Text = "Open SCL Configurator";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.pictureBox1.Location = new System.Drawing.Point(1, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(1111, 76);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("DejaVu Sans", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.label3.Location = new System.Drawing.Point(220, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(528, 41);
			this.label3.TabIndex = 4;
			this.label3.Text = "“Creating configurations files for Intelligent Electronic Devices (IED\'s) accordi" +
			"ng to the IEC 61850 Ed.1.0 standard”";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("DejaVu Sans", 8.25F, System.Drawing.FontStyle.Bold);
			this.label4.Location = new System.Drawing.Point(222, 344);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(528, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "Copyright © 2009 Comisión Federal de Electricidad";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabAbout);
			this.tabControl1.Controls.Add(this.tabVersion);
			this.tabControl1.Controls.Add(this.tabDevelop);
			this.tabControl1.Location = new System.Drawing.Point(220, 143);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(587, 202);
			this.tabControl1.TabIndex = 6;
			// 
			// tabAbout
			// 
			this.tabAbout.Controls.Add(this.richTextBox2);
			this.tabAbout.Controls.Add(this.label2);
			this.tabAbout.Controls.Add(this.textBox1);
			this.tabAbout.Controls.Add(this.label8);
			this.tabAbout.Location = new System.Drawing.Point(4, 22);
			this.tabAbout.Name = "tabAbout";
			this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
			this.tabAbout.Size = new System.Drawing.Size(579, 176);
			this.tabAbout.TabIndex = 1;
			this.tabAbout.Text = "About OpenSCLConfigurator";
			this.tabAbout.UseVisualStyleBackColor = true;
			// 
			// richTextBox2
			// 
			this.richTextBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.richTextBox2.Location = new System.Drawing.Point(34, 75);
			this.richTextBox2.Name = "richTextBox2";
			this.richTextBox2.ReadOnly = true;
			this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.richTextBox2.Size = new System.Drawing.Size(522, 84);
			this.richTextBox2.TabIndex = 4;
			this.richTextBox2.Text = resources.GetString("richTextBox2.Text");
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(34, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(369, 21);
			this.label2.TabIndex = 3;
			this.label2.Text = "Released under the terms of the GNU General Public License";
			// 
			// OpenSCLConfigurator Version Number
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.textBox1.Font = new System.Drawing.Font("DejaVu Sans", 8.25F);
			this.textBox1.Location = new System.Drawing.Point(99, 19);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(46, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "0.2.1";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(34, 21);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(61, 16);
			this.label8.TabIndex = 1;
			this.label8.Text = "Versión:";
			// 
			// tabVersion
			// 
			this.tabVersion.Controls.Add(this.richTextBox1);
			this.tabVersion.Location = new System.Drawing.Point(4, 22);
			this.tabVersion.Name = "tabVersion";
			this.tabVersion.Padding = new System.Windows.Forms.Padding(3);
			this.tabVersion.Size = new System.Drawing.Size(579, 176);
			this.tabVersion.TabIndex = 2;
			this.tabVersion.Text = "Version Info";
			this.tabVersion.UseVisualStyleBackColor = true;
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.richTextBox1.Font = new System.Drawing.Font("DejaVu Sans", 8.25F);
			this.richTextBox1.Location = new System.Drawing.Point(61, 48);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(462, 79);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
			// 
			// tabDevelop
			// 
			this.tabDevelop.Controls.Add(this.richTextBox3);
			this.tabDevelop.Location = new System.Drawing.Point(4, 22);
			this.tabDevelop.Name = "tabDevelop";
			this.tabDevelop.Padding = new System.Windows.Forms.Padding(3);
			this.tabDevelop.Size = new System.Drawing.Size(579, 176);
			this.tabDevelop.TabIndex = 0;
			this.tabDevelop.Text = "Ported and Developed by";
			this.tabDevelop.UseVisualStyleBackColor = true;
			// 
			// richTextBox3
			// 
			this.richTextBox3.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.richTextBox3.Font = new System.Drawing.Font("DejaVu Sans", 9F, System.Drawing.FontStyle.Bold);
			this.richTextBox3.Location = new System.Drawing.Point(0, 0);
			this.richTextBox3.Name = "richTextBox3";
			this.richTextBox3.ReadOnly = true;
			this.richTextBox3.Size = new System.Drawing.Size(577, 173);
			this.richTextBox3.TabIndex = 1;
			this.richTextBox3.Text = resources.GetString("richTextBox3.Text");
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.pictureBox2.Location = new System.Drawing.Point(175, 157);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(43, 185);
			this.pictureBox2.TabIndex = 7;
			this.pictureBox2.TabStop = false;
			// 
			// about
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(927, 409);
			this.ControlBox = false;
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Font = new System.Drawing.Font("DejaVu Sans", 8.25F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "about";
			this.Opacity = 0.9;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "- OpenSCLConfigurator -";
			this.TopMost = true;
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabAbout.ResumeLayout(false);
			this.tabAbout.PerformLayout();
			this.tabVersion.ResumeLayout(false);
			this.tabDevelop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
		}
		
		private System.Windows.Forms.RichTextBox richTextBox3;		
		private System.Windows.Forms.TabPage tabDevelop;
		private System.Windows.Forms.TabPage tabAbout;
		private System.Windows.Forms.TabPage tabVersion;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RichTextBox richTextBox2;
		private System.Windows.Forms.PictureBox pictureBox2;		
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;						
		private System.Windows.Forms.Button button1;
	}
}
