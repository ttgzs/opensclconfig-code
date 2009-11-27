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
	partial class DataSetDialog
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
			this.LNLabel = new System.Windows.Forms.Label();
			this.DataSetGroupBox = new System.Windows.Forms.GroupBox();
			this.SourceDataSetListBox = new System.Windows.Forms.ListBox();
			this.DescTextBox = new System.Windows.Forms.TextBox();
			this.NameTextBox = new System.Windows.Forms.TextBox();
			this.DescriptionLabel = new System.Windows.Forms.Label();
			this.NameLabel = new System.Windows.Forms.Label();
			this.FCDAGroupBox = new System.Windows.Forms.GroupBox();
			this.DestinyDataSetListBox = new System.Windows.Forms.ListBox();
			this.OKButton = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.chooseAllFCDAButton = new System.Windows.Forms.Button();
			this.comeBackOneFCDAButton = new System.Windows.Forms.Button();
			this.chooseOneFCDAButton = new System.Windows.Forms.Button();
			this.comeBackAllFCDAButton = new System.Windows.Forms.Button();
			this.LNtypeLabel = new System.Windows.Forms.Label();
			this.DataSetGroupBox.SuspendLayout();
			this.FCDAGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// LNLabel
			// 
			this.LNLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LNLabel.Location = new System.Drawing.Point(142, 26);
			this.LNLabel.Name = "LNLabel";
			this.LNLabel.Size = new System.Drawing.Size(146, 21);
			this.LNLabel.TabIndex = 0;
			this.LNLabel.Text = "Logical Node Type";
			// 
			// DataSetGroupBox
			// 
			this.DataSetGroupBox.Controls.Add(this.SourceDataSetListBox);
			this.DataSetGroupBox.Controls.Add(this.DescTextBox);
			this.DataSetGroupBox.Controls.Add(this.NameTextBox);
			this.DataSetGroupBox.Controls.Add(this.DescriptionLabel);
			this.DataSetGroupBox.Controls.Add(this.NameLabel);
			this.DataSetGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DataSetGroupBox.Location = new System.Drawing.Point(16, 95);
			this.DataSetGroupBox.Name = "DataSetGroupBox";
			this.DataSetGroupBox.Size = new System.Drawing.Size(324, 413);
			this.DataSetGroupBox.TabIndex = 2;
			this.DataSetGroupBox.TabStop = false;
			this.DataSetGroupBox.Text = "DataSet";
			// 
			// SourceDataSetListBox
			// 
			this.SourceDataSetListBox.FormattingEnabled = true;
			this.SourceDataSetListBox.HorizontalScrollbar = true;
			this.SourceDataSetListBox.ItemHeight = 16;
			this.SourceDataSetListBox.Location = new System.Drawing.Point(15, 153);
			this.SourceDataSetListBox.Name = "SourceDataSetListBox";
			this.SourceDataSetListBox.Size = new System.Drawing.Size(294, 228);
			this.SourceDataSetListBox.TabIndex = 2;
			// 
			// DescTextBox
			// 
			this.DescTextBox.Location = new System.Drawing.Point(126, 63);
			this.DescTextBox.Name = "DescTextBox";
			this.DescTextBox.Size = new System.Drawing.Size(148, 23);
			this.DescTextBox.TabIndex = 1;
			// 
			// NameTextBox
			// 
			this.NameTextBox.Location = new System.Drawing.Point(126, 28);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.Size = new System.Drawing.Size(148, 23);
			this.NameTextBox.TabIndex = 1;
			// 
			// DescriptionLabel
			// 
			this.DescriptionLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DescriptionLabel.Location = new System.Drawing.Point(15, 66);
			this.DescriptionLabel.Name = "DescriptionLabel";
			this.DescriptionLabel.Size = new System.Drawing.Size(102, 21);
			this.DescriptionLabel.TabIndex = 0;
			this.DescriptionLabel.Text = "Description";
			// 
			// NameLabel
			// 
			this.NameLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameLabel.Location = new System.Drawing.Point(15, 31);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(58, 21);
			this.NameLabel.TabIndex = 0;
			this.NameLabel.Text = "Name";
			// 
			// FCDAGroupBox
			// 
			this.FCDAGroupBox.Controls.Add(this.DestinyDataSetListBox);
			this.FCDAGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FCDAGroupBox.Location = new System.Drawing.Point(414, 95);
			this.FCDAGroupBox.Name = "FCDAGroupBox";
			this.FCDAGroupBox.Size = new System.Drawing.Size(324, 413);
			this.FCDAGroupBox.TabIndex = 2;
			this.FCDAGroupBox.TabStop = false;
			this.FCDAGroupBox.Text = "FCDA";
			// 
			// DestinyDataSetListBox
			// 
			this.DestinyDataSetListBox.FormattingEnabled = true;
			this.DestinyDataSetListBox.ItemHeight = 16;
			this.DestinyDataSetListBox.Location = new System.Drawing.Point(18, 37);
			this.DestinyDataSetListBox.Name = "DestinyDataSetListBox";
			this.DestinyDataSetListBox.Size = new System.Drawing.Size(300, 340);
			this.DestinyDataSetListBox.TabIndex = 0;
			// 
			// OKButton
			// 
			this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OKButton.Location = new System.Drawing.Point(238, 537);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(87, 23);
			this.OKButton.TabIndex = 3;
			this.OKButton.Text = "OK";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButtonClick);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CancelBtn.Location = new System.Drawing.Point(442, 537);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(84, 23);
			this.CancelBtn.TabIndex = 3;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			this.CancelBtn.Click += new System.EventHandler(this.CancelBtnClick);
			// 
			// chooseAllFCDAButton
			// 
			this.chooseAllFCDAButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chooseAllFCDAButton.Location = new System.Drawing.Point(358, 271);
			this.chooseAllFCDAButton.Name = "chooseAllFCDAButton";
			this.chooseAllFCDAButton.Size = new System.Drawing.Size(39, 33);
			this.chooseAllFCDAButton.TabIndex = 4;
			this.chooseAllFCDAButton.Text = ">>";
			this.chooseAllFCDAButton.UseVisualStyleBackColor = true;
			this.chooseAllFCDAButton.Click += new System.EventHandler(this.ChooseAllFCDAButtonClick);
			// 
			// comeBackOneFCDAButton
			// 
			this.comeBackOneFCDAButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comeBackOneFCDAButton.Location = new System.Drawing.Point(358, 349);
			this.comeBackOneFCDAButton.Name = "comeBackOneFCDAButton";
			this.comeBackOneFCDAButton.Size = new System.Drawing.Size(39, 33);
			this.comeBackOneFCDAButton.TabIndex = 4;
			this.comeBackOneFCDAButton.Text = "<";
			this.comeBackOneFCDAButton.UseVisualStyleBackColor = true;
			this.comeBackOneFCDAButton.Click += new System.EventHandler(this.ComeBackOneFCDAButtonClick);
			// 
			// chooseOneFCDAButton
			// 
			this.chooseOneFCDAButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chooseOneFCDAButton.Location = new System.Drawing.Point(358, 310);
			this.chooseOneFCDAButton.Name = "chooseOneFCDAButton";
			this.chooseOneFCDAButton.Size = new System.Drawing.Size(39, 33);
			this.chooseOneFCDAButton.TabIndex = 4;
			this.chooseOneFCDAButton.Text = ">";
			this.chooseOneFCDAButton.UseVisualStyleBackColor = true;
			this.chooseOneFCDAButton.Click += new System.EventHandler(this.ChooseOneFCDAButtonClick);
			// 
			// comeBackAllFCDAButton
			// 
			this.comeBackAllFCDAButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comeBackAllFCDAButton.Location = new System.Drawing.Point(358, 388);
			this.comeBackAllFCDAButton.Name = "comeBackAllFCDAButton";
			this.comeBackAllFCDAButton.Size = new System.Drawing.Size(39, 33);
			this.comeBackAllFCDAButton.TabIndex = 4;
			this.comeBackAllFCDAButton.Text = "<<";
			this.comeBackAllFCDAButton.UseVisualStyleBackColor = true;
			this.comeBackAllFCDAButton.Click += new System.EventHandler(this.ComeBackAllFCDAButtonClick);
			// 
			// LNtypeLabel
			// 
			this.LNtypeLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
			this.LNtypeLabel.Location = new System.Drawing.Point(305, 26);
			this.LNtypeLabel.Name = "LNtypeLabel";
			this.LNtypeLabel.Size = new System.Drawing.Size(209, 23);
			this.LNtypeLabel.TabIndex = 5;
			this.LNtypeLabel.Text = "label1";
			// 
			// DataSetDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(757, 580);
			this.Controls.Add(this.LNtypeLabel);
			this.Controls.Add(this.comeBackAllFCDAButton);
			this.Controls.Add(this.chooseOneFCDAButton);
			this.Controls.Add(this.comeBackOneFCDAButton);
			this.Controls.Add(this.chooseAllFCDAButton);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.FCDAGroupBox);
			this.Controls.Add(this.DataSetGroupBox);
			this.Controls.Add(this.LNLabel);
			this.Name = "DataSetDialog";
			this.Opacity = 0.9;
			this.Text = "WindowDataSet";
			this.DataSetGroupBox.ResumeLayout(false);
			this.DataSetGroupBox.PerformLayout();
			this.FCDAGroupBox.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label LNtypeLabel;
		private System.Windows.Forms.TextBox DescTextBox;
		private System.Windows.Forms.TextBox NameTextBox;
		private System.Windows.Forms.ListBox DestinyDataSetListBox;
		private System.Windows.Forms.ListBox SourceDataSetListBox;
		private System.Windows.Forms.Button comeBackAllFCDAButton;
		private System.Windows.Forms.Button chooseOneFCDAButton;
		private System.Windows.Forms.Button comeBackOneFCDAButton;
		private System.Windows.Forms.Button chooseAllFCDAButton;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.Label DescriptionLabel;
		private System.Windows.Forms.GroupBox FCDAGroupBox;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.GroupBox DataSetGroupBox;
		private System.Windows.Forms.Label LNLabel;			
	}
}
