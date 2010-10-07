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
	partial class PrivateDialog
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">
		/// if resources should be disposed ti returns a true value, otherwise a false value
		/// is returned.
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
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrivateDialog));
			this.prefixTextBox = new System.Windows.Forms.TextBox();
			this.valueTextBox = new System.Windows.Forms.TextBox();
			this.localNameTextBox = new System.Windows.Forms.TextBox();
			this.namespaceTextBox = new System.Windows.Forms.TextBox();
			this.prefixLabel = new System.Windows.Forms.Label();
			this.t2Label = new System.Windows.Forms.Label();
			this.localNameLabel = new System.Windows.Forms.Label();
			this.namespaceLabel = new System.Windows.Forms.Label();
			this.elementGroupBox1 = new System.Windows.Forms.GroupBox();
			this.DeleteElementButton = new System.Windows.Forms.Button();
			this.elementsListBox = new OpenSCL.UI.ListBoxHierachy();
			this.AddElementButton = new System.Windows.Forms.Button();
			this.elementOKButton = new System.Windows.Forms.Button();
			this.AttributeGroupBox = new System.Windows.Forms.GroupBox();
			this.DeleteAttributeButton = new System.Windows.Forms.Button();
			this.AddAttributeButton = new System.Windows.Forms.Button();
			this.attributesListBox = new OpenSCL.UI.ListBoxHierachy();
			this.attributeOKButton = new System.Windows.Forms.Button();
			this.AttributeValueTextBox = new System.Windows.Forms.TextBox();
			this.attributeLocalNameTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.license = new System.Windows.Forms.Label();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.TextSource = new System.Windows.Forms.TextBox();
			this.labelSoucer = new System.Windows.Forms.Label();
			this.labelType = new System.Windows.Forms.Label();
			this.TextType = new System.Windows.Forms.TextBox();
			this.elementGroupBox1.SuspendLayout();
			this.AttributeGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// prefixTextBox
			// 
			this.prefixTextBox.Location = new System.Drawing.Point(145, 211);
			this.prefixTextBox.Name = "prefixTextBox";
			this.prefixTextBox.Size = new System.Drawing.Size(100, 20);
			this.prefixTextBox.TabIndex = 3;
			// 
			// valueTextBox
			// 
			this.valueTextBox.Location = new System.Drawing.Point(145, 294);
			this.valueTextBox.Name = "valueTextBox";
			this.valueTextBox.Size = new System.Drawing.Size(100, 20);
			this.valueTextBox.TabIndex = 5;
			// 
			// localNameTextBox
			// 
			this.localNameTextBox.Location = new System.Drawing.Point(145, 251);
			this.localNameTextBox.Name = "localNameTextBox";
			this.localNameTextBox.Size = new System.Drawing.Size(100, 20);
			this.localNameTextBox.TabIndex = 4;
			// 
			// namespaceTextBox
			// 
			this.namespaceTextBox.Location = new System.Drawing.Point(145, 172);
			this.namespaceTextBox.Name = "namespaceTextBox";
			this.namespaceTextBox.Size = new System.Drawing.Size(205, 20);
			this.namespaceTextBox.TabIndex = 2;
			// 
			// prefixLabel
			// 
			this.prefixLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.prefixLabel.Location = new System.Drawing.Point(53, 211);
			this.prefixLabel.Name = "prefixLabel";
			this.prefixLabel.Size = new System.Drawing.Size(86, 22);
			this.prefixLabel.TabIndex = 4;
			this.prefixLabel.Text = "Prefix";
			// 
			// valueLabel
			// 
			this.t2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.t2Label.Location = new System.Drawing.Point(52, 295);
			this.t2Label.Name = "valueLabel";
			this.t2Label.Size = new System.Drawing.Size(86, 22);
			this.t2Label.TabIndex = 4;
			this.t2Label.Text = "Value";
			// 
			// localNameLabel
			// 
			this.localNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.localNameLabel.Location = new System.Drawing.Point(52, 252);
			this.localNameLabel.Name = "localNameLabel";
			this.localNameLabel.Size = new System.Drawing.Size(86, 22);
			this.localNameLabel.TabIndex = 4;
			this.localNameLabel.Text = "Name";
			// 
			// namespaceLabel
			// 
			this.namespaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.namespaceLabel.Location = new System.Drawing.Point(53, 170);
			this.namespaceLabel.Name = "namespaceLabel";
			this.namespaceLabel.Size = new System.Drawing.Size(86, 22);
			this.namespaceLabel.TabIndex = 4;
			this.namespaceLabel.Text = "Namespace";
			// 
			// elementGroupBox1
			// 
			this.elementGroupBox1.Controls.Add(this.DeleteElementButton);
			this.elementGroupBox1.Controls.Add(this.elementsListBox);
			this.elementGroupBox1.Controls.Add(this.AddElementButton);
			this.elementGroupBox1.Controls.Add(this.elementOKButton);
			this.elementGroupBox1.Controls.Add(this.namespaceLabel);
			this.elementGroupBox1.Controls.Add(this.localNameLabel);
			this.elementGroupBox1.Controls.Add(this.prefixTextBox);
			this.elementGroupBox1.Controls.Add(this.t2Label);
			this.elementGroupBox1.Controls.Add(this.valueTextBox);
			this.elementGroupBox1.Controls.Add(this.prefixLabel);
			this.elementGroupBox1.Controls.Add(this.localNameTextBox);
			this.elementGroupBox1.Controls.Add(this.namespaceTextBox);
			this.elementGroupBox1.Location = new System.Drawing.Point(23, 98);
			this.elementGroupBox1.Name = "elementGroupBox1";
			this.elementGroupBox1.Size = new System.Drawing.Size(397, 380);
			this.elementGroupBox1.TabIndex = 3;
			this.elementGroupBox1.TabStop = false;
			this.elementGroupBox1.Text = "Element";
			// 
			// DeleteElementButton
			// 
			this.DeleteElementButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteElementButton.Image")));
			this.DeleteElementButton.Location = new System.Drawing.Point(99, 112);
			this.DeleteElementButton.Name = "DeleteElementButton";
			this.DeleteElementButton.Size = new System.Drawing.Size(28, 28);
			this.DeleteElementButton.TabIndex = 9;
			this.DeleteElementButton.UseVisualStyleBackColor = true;
			this.DeleteElementButton.Click += new System.EventHandler(this.DeleteElementButtonClick);
			// 
			// elementsListBox
			// 
			this.elementsListBox.FormattingEnabled = true;
			this.elementsListBox.HorizontalScrollbar = true;
			this.elementsListBox.Location = new System.Drawing.Point(66, 29);
			this.elementsListBox.Name = "elementsListBox";
			this.elementsListBox.Size = new System.Drawing.Size(258, 82);
			this.elementsListBox.TabIndex = 1;
			this.elementsListBox.Click += new System.EventHandler(this.EditElementEvent);
			// 
			// AddElementButton
			// 
			this.AddElementButton.Image = ((System.Drawing.Image)(resources.GetObject("AddElementButton.Image")));
			this.AddElementButton.Location = new System.Drawing.Point(65, 112);
			this.AddElementButton.Name = "AddElementButton";
			this.AddElementButton.Size = new System.Drawing.Size(28, 28);
			this.AddElementButton.TabIndex = 8;
			this.AddElementButton.UseVisualStyleBackColor = true;
			this.AddElementButton.Click += new System.EventHandler(this.AddElementButtonClick);
			// 
			// elementOKButton
			// 
			this.elementOKButton.Location = new System.Drawing.Point(145, 340);
			this.elementOKButton.Name = "elementOKButton";
			this.elementOKButton.Size = new System.Drawing.Size(63, 23);
			this.elementOKButton.TabIndex = 6;
			this.elementOKButton.Text = "Save";
			this.elementOKButton.UseVisualStyleBackColor = true;
			this.elementOKButton.Click += new System.EventHandler(this.ElementOKButtonClick);
			// 
			// AttributeGroupBox
			// 
			this.AttributeGroupBox.Controls.Add(this.DeleteAttributeButton);
			this.AttributeGroupBox.Controls.Add(this.AddAttributeButton);
			this.AttributeGroupBox.Controls.Add(this.attributesListBox);
			this.AttributeGroupBox.Controls.Add(this.attributeOKButton);
			this.AttributeGroupBox.Controls.Add(this.AttributeValueTextBox);
			this.AttributeGroupBox.Controls.Add(this.attributeLocalNameTextBox);
			this.AttributeGroupBox.Controls.Add(this.label1);
			this.AttributeGroupBox.Controls.Add(this.license);
			this.AttributeGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AttributeGroupBox.Location = new System.Drawing.Point(470, 98);
			this.AttributeGroupBox.Name = "AttributeGroupBox";
			this.AttributeGroupBox.Size = new System.Drawing.Size(364, 385);
			this.AttributeGroupBox.TabIndex = 4;
			this.AttributeGroupBox.TabStop = false;
			this.AttributeGroupBox.Text = "Attribute";
			// 
			// DeleteAttributeButton
			// 
			this.DeleteAttributeButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteAttributeButton.Image")));
			this.DeleteAttributeButton.Location = new System.Drawing.Point(90, 112);
			this.DeleteAttributeButton.Name = "DeleteAttributeButton";
			this.DeleteAttributeButton.Size = new System.Drawing.Size(28, 28);
			this.DeleteAttributeButton.TabIndex = 7;
			this.DeleteAttributeButton.UseVisualStyleBackColor = true;
			this.DeleteAttributeButton.Click += new System.EventHandler(this.DeleteAttributeButtonClick);
			// 
			// AddAttributeButton
			// 
			this.AddAttributeButton.Image = ((System.Drawing.Image)(resources.GetObject("AddAttributeButton.Image")));
			this.AddAttributeButton.Location = new System.Drawing.Point(57, 112);
			this.AddAttributeButton.Name = "AddAttributeButton";
			this.AddAttributeButton.Size = new System.Drawing.Size(28, 28);
			this.AddAttributeButton.TabIndex = 6;
			this.AddAttributeButton.UseVisualStyleBackColor = true;
			this.AddAttributeButton.Click += new System.EventHandler(this.AddAttributeButtonClick);
			// 
			// attributesListBox
			// 
			this.attributesListBox.FormattingEnabled = true;
			this.attributesListBox.HorizontalScrollbar = true;
			this.attributesListBox.Location = new System.Drawing.Point(57, 29);
			this.attributesListBox.Name = "attributesListBox";
			this.attributesListBox.Size = new System.Drawing.Size(258, 82);
			this.attributesListBox.TabIndex = 1;
			this.attributesListBox.Click += new System.EventHandler(this.EditAttributeEvent);
			// 
			// attributeOKButton
			// 
			this.attributeOKButton.Location = new System.Drawing.Point(165, 340);
			this.attributeOKButton.Name = "attributeOKButton";
			this.attributeOKButton.Size = new System.Drawing.Size(63, 23);
			this.attributeOKButton.TabIndex = 4;
			this.attributeOKButton.Text = "Save";
			this.attributeOKButton.UseVisualStyleBackColor = true;
			this.attributeOKButton.Click += new System.EventHandler(this.AttributeOKButtonClick);
			// 
			// AttributeValueTextBox
			// 
			this.AttributeValueTextBox.Location = new System.Drawing.Point(175, 250);
			this.AttributeValueTextBox.Name = "AttributeValueTextBox";
			this.AttributeValueTextBox.Size = new System.Drawing.Size(123, 20);
			this.AttributeValueTextBox.TabIndex = 3;
			// 
			// attributeLocalNameTextBox
			// 
			this.attributeLocalNameTextBox.Location = new System.Drawing.Point(176, 190);
			this.attributeLocalNameTextBox.Name = "attributeLocalNameTextBox";
			this.attributeLocalNameTextBox.Size = new System.Drawing.Size(122, 20);
			this.attributeLocalNameTextBox.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(83, 251);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 22);
			this.label1.TabIndex = 4;
			this.label1.Text = "Value";
			// 
			// label2
			// 
			this.license.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.license.Location = new System.Drawing.Point(83, 191);
			this.license.Name = "label2";
			this.license.Size = new System.Drawing.Size(86, 22);
			this.license.TabIndex = 4;
			this.license.Text = "Name";
			// 
			// CancelBtn
			// 
			this.CancelBtn.Location = new System.Drawing.Point(470, 527);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 6;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			this.CancelBtn.Click += new System.EventHandler(this.CancelBtnClick);
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(345, 527);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 5;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.ButtonOkClick);
			// 
			// TextSource
			// 
			this.TextSource.Location = new System.Drawing.Point(474, 46);
			this.TextSource.Multiline = true;
			this.TextSource.Name = "TextSource";
			this.TextSource.Size = new System.Drawing.Size(360, 23);
			this.TextSource.TabIndex = 2;
			// 
			// labelSoucer
			// 
			this.labelSoucer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSoucer.Location = new System.Drawing.Point(474, 21);
			this.labelSoucer.Name = "labelSoucer";
			this.labelSoucer.Size = new System.Drawing.Size(60, 23);
			this.labelSoucer.TabIndex = 9;
			this.labelSoucer.Text = "Source";
			// 
			// labelType
			// 
			this.labelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelType.Location = new System.Drawing.Point(29, 20);
			this.labelType.Name = "labelType";
			this.labelType.Size = new System.Drawing.Size(42, 23);
			this.labelType.TabIndex = 8;
			this.labelType.Text = "Type";
			// 
			// TextType
			// 
			this.TextType.Location = new System.Drawing.Point(30, 46);
			this.TextType.Multiline = true;
			this.TextType.Name = "TextType";
			this.TextType.Size = new System.Drawing.Size(377, 23);
			this.TextType.TabIndex = 1;
			// 
			// PrivateDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CausesValidation = false;
			this.ClientSize = new System.Drawing.Size(854, 572);
			this.ControlBox = false;
			this.Controls.Add(this.TextSource);
			this.Controls.Add(this.labelSoucer);
			this.Controls.Add(this.labelType);
			this.Controls.Add(this.TextType);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.AttributeGroupBox);
			this.Controls.Add(this.elementGroupBox1);
			this.MaximizeBox = false;
			this.Name = "PrivateDialog";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Manipulation of Private section";
			this.Load += new System.EventHandler(this.ManipulationTextLoad);
			this.elementGroupBox1.ResumeLayout(false);
			this.elementGroupBox1.PerformLayout();
			this.AttributeGroupBox.ResumeLayout(false);
			this.AttributeGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}		
		private System.Windows.Forms.Button CancelBtn;		
		private System.Windows.Forms.Button DeleteAttributeButton;
		private System.Windows.Forms.Button DeleteElementButton;
		private OpenSCL.UI.ListBoxHierachy attributesListBox;
		private OpenSCL.UI.ListBoxHierachy elementsListBox;
		private System.Windows.Forms.Button elementOKButton;
		private System.Windows.Forms.Button attributeOKButton;
		private System.Windows.Forms.TextBox attributeLocalNameTextBox;
		private System.Windows.Forms.TextBox AttributeValueTextBox;
		private System.Windows.Forms.Label license;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox AttributeGroupBox;
		private System.Windows.Forms.Button AddAttributeButton;
		private System.Windows.Forms.Button AddElementButton;
		private System.Windows.Forms.GroupBox elementGroupBox1;
		private System.Windows.Forms.Label t2Label;
		private System.Windows.Forms.TextBox valueTextBox;
		private System.Windows.Forms.Label localNameLabel;
		private System.Windows.Forms.Label prefixLabel;
		private System.Windows.Forms.TextBox localNameTextBox;
		private System.Windows.Forms.TextBox prefixTextBox;
		private System.Windows.Forms.TextBox namespaceTextBox;
		private System.Windows.Forms.Label namespaceLabel;
		private System.Windows.Forms.TextBox TextType;
		private System.Windows.Forms.Label labelType;
		private System.Windows.Forms.Label labelSoucer;
		private System.Windows.Forms.TextBox TextSource;
		private System.Windows.Forms.Button buttonOk;	
	}
}
