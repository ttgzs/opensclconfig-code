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
using System.Windows.Forms;

namespace OpenSCL.UI
{
	public class CustomAttributeDialog : Form
	{
		private TreeNode treeSCL;
		private SCL sCL;
		private tBaseElement element;
		
		private Button okButton;
		private Button cancelButton;
		private Label attrListLabel;
		private ListBox attrList;
		private Button addAttribute;
		private Button deleteAttribute;
		private Button addNameSpace;
		private Button editNameSpace;
		private Button removeNameSpace;
		private Label nameSpaceLabel;
		private ComboBox nameSpaceList;
		private Label attrNameLabel;
		private TextBox attrName;
		private Label attrValueLabel;
		private TextBox attrValue;
		
		public CustomAttributeDialog(SCL scl, tBaseElement element) {
			this.sCL = scl;
			this.element = element;
			this.InitializeComponent();
		}
		
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
		private void InitializeComponent() {
			// Temporary variables used to modify dialog's controls distribution
			int right = this.Margin.Right * 2;
			int bottom = this.Margin.Bottom * 2;
			int top = this.Margin.Top;
			int left = this.Margin.Left;
			int text_size = 200;
			
			this.attrListLabel = new Label();
			this.attrListLabel.Text = "C&ustom Attributes";
			this.attrListLabel.AutoSize = true;
			this.attrListLabel.Location = new System.Drawing.Point(20,20);
			
			this.attrList = new ListBox();
			this.attrList.Size = new System.Drawing.Size(150, 300);
			this.attrList.Top = this.attrListLabel.Bottom + bottom;
			this.attrList.Left = this.attrListLabel.Left;
			if(this.element.AnyAttr != null) {
				for (int i = 0; i < this.element.AnyAttr.GetLength(0); i++) {
					this.attrList.Items.Add(this.element.AnyAttr[i].Name);
				}
			}
			
			this.okButton = new Button();
			this.okButton.Text = "&Accept";
			this.okButton.AutoSize = true;
			
			this.addAttribute = new Button();
			this.addAttribute.Text = "A&dd";
			this.addAttribute.Size = new System.Drawing.Size(this.attrList.Width/2 - right/2, 
			                                                 this.okButton.Height);
			this.addAttribute.Top = this.attrList.Bottom + bottom;
			this.addAttribute.Left = this.attrList.Left;
			
			this.deleteAttribute = new Button();
			this.deleteAttribute.Text = "&Remove";
			this.deleteAttribute.Size = new System.Drawing.Size(this.attrList.Width/2 - right/2, 
			                                                    this.okButton.Height);
			this.deleteAttribute.Top = this.addAttribute.Top;
			this.deleteAttribute.Left = this.addAttribute.Right + right;
			
			// Initial for longest label text
			this.nameSpaceLabel = new Label();
			this.nameSpaceLabel.Text = "Name &Space";
			this.nameSpaceLabel.AutoSize = true;
			
			// Attribute name and value
			this.attrNameLabel = new Label();
			this.attrNameLabel.Text = "&Name";
			this.attrNameLabel.Size = this.nameSpaceLabel.Size;
			this.attrNameLabel.Top = this.attrList.Top + top * 4;
			this.attrNameLabel.Left = this.attrList.Right + right;
			
			this.attrName = new TextBox();
			this.attrName.Size = new System.Drawing.Size(text_size, this.attrNameLabel.Height);
			this.attrName.Top = this.attrNameLabel.Top;
			this.attrName.Left = this.attrNameLabel.Right + right;
			
			this.attrValueLabel = new Label();
			this.attrValueLabel.Text = "&Value";
			this.attrValueLabel.Size = this.nameSpaceLabel.Size;
			this.attrValueLabel.Top = this.attrNameLabel.Bottom + bottom;
			this.attrValueLabel.Left = this.attrNameLabel.Left;
			
			this.attrValue = new TextBox();
			this.attrValue.Size = new System.Drawing.Size(this.attrName.Width, this.attrValueLabel.Height);
			this.attrValue.Top = this.attrValueLabel.Top;
			this.attrValue.Left = this.attrValueLabel.Right + right;
			
			// Name Space
			this.nameSpaceLabel.Top = this.attrValueLabel.Bottom + bottom;
			this.nameSpaceLabel.Left = this.attrValueLabel.Left;
			
			this.nameSpaceList = new ComboBox();
			this.nameSpaceList.AutoSize = true;
			this.nameSpaceList.Top = this.nameSpaceLabel.Top;
			this.nameSpaceList.Left = this.nameSpaceLabel.Right + right;
			this.nameSpaceList.Height = this.nameSpaceLabel.Height * 2;
			this.nameSpaceList.Width = this.attrName.Width;
			if (this.sCL.xmlns != null) {
				for (int i = 0; i < this.sCL.xmlns.ToArray().GetLength(0); i++) {
					this.nameSpaceList.Items.Add(this.sCL.xmlns.ToArray()[i].Namespace);
				}
			}
			
			this.addNameSpace = new Button();
			this.addNameSpace.Text = "Add";
			this.addNameSpace.Size = new System.Drawing.Size((this.nameSpaceList.Width - right * 2) / 3,
			                                                 this.okButton.Height);
			this.addNameSpace.Top = this.nameSpaceList.Bottom + bottom;
			this.addNameSpace.Left = this.nameSpaceList.Left;
			
			this.removeNameSpace = new Button();
			this.removeNameSpace.Text = "Remove";
			this.removeNameSpace.Size = new System.Drawing.Size((this.nameSpaceList.Width - right * 2) / 3,
			                                                 this.okButton.Height);
			this.removeNameSpace.Top = this.addNameSpace.Top;
			this.removeNameSpace.Left = this.addNameSpace.Right + right;
			
			this.editNameSpace = new Button();
			this.editNameSpace.Text = "Edit";
			this.editNameSpace.Size = new System.Drawing.Size((this.nameSpaceList.Width - right * 2) / 3,
			                                                 this.okButton.Height);
			this.editNameSpace.Top = this.removeNameSpace.Top;
			this.editNameSpace.Left = this.removeNameSpace.Right + right;
			
			// final setup of Ok button
			this.okButton.Top = this.addAttribute.Bottom + 20;
			this.okButton.Left = this.nameSpaceList.Right - this.okButton.Width;
			
			// Cancel button
			this.cancelButton = new Button();
			this.cancelButton.Text = "&Cancel";
			this.cancelButton.AutoSize = true;
			this.cancelButton.Top = this.okButton.Top;
			this.cancelButton.Left = this.okButton.Left - left - this.cancelButton.Width;
			
			// Main Dialog
			this.AutoSize = true;
			this.Text = "Edit Custom Attribute";
			this.Controls.Add(this.attrListLabel);
			this.Controls.Add(this.attrList);
			this.Controls.Add(this.addAttribute);
			this.Controls.Add(this.deleteAttribute);
			this.Controls.Add(this.attrNameLabel);
			this.Controls.Add(this.attrName);
			this.Controls.Add(this.attrValueLabel);
			this.Controls.Add(this.attrValue);
			this.Controls.Add(this.nameSpaceLabel);
			this.Controls.Add(this.nameSpaceList);
			this.Controls.Add(this.addNameSpace);
			this.Controls.Add(this.removeNameSpace);
			this.Controls.Add(this.editNameSpace);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			
			this.AcceptButton = this.okButton;
			this.AcceptButton.DialogResult =  DialogResult.OK;
			this.CancelButton = this.cancelButton;
			this.CancelButton.DialogResult = DialogResult.Cancel;
			this.addAttribute.Click += HandleAddAttributehandleClick;
		}

		void HandleAddAttributehandleClick (object sender, System.EventArgs e)
		{
			System.Xml.XmlAttribute[] attr;
			if (this.element.AnyAttr == null) {
				attr = new System.Xml.XmlAttribute[1];
			}
			else {
				attr = new System.Xml.XmlAttribute[this.element.AnyAttr.GetLength(0) + 1];
				this.element.AnyAttr.CopyTo(attr, 0);
			}
			string name;
			string prefix;
			string nameSpace;
			
			EditDialog dlg = new EditDialog(ref name, ref prefix, ref nameSpace);
			
			this.sCL.xmlns.Add(prefix, nameSpace);			
			attr[attr.GetLength(0) - 1] = new System.Xml.XmlAttribute (name, prefix, nameSpace);
		}
	}
	
	public class EditDialog : Form
	{
		private Label nameLabel;
		private TextBox name;
		private Label valueLabel;
		private TextBox valueText;
		private Button okButton;
		private Button cancelButton;
		
		private ComboBox nameSpaceList;
		
		private string[] nameSpace;
		
		public string Name {
			get { return name.Text; }
		}
		
		public string Value {
			get { return valueText.Text; }
		}
		
		public EditDialog() {
			this.InitializeComponent();
		}
		
		public EditDialog(string[] ns) {
			this.nameSpace = ns.Clone();
			this.InitializeComponent();
		}
		                  
		
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
		private void InitializeComponent() {
			
		}
	}
	
	
}
