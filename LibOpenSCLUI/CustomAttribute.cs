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
		private SCL scl;
		private tBaseElement element;
		private System.Xml.XmlDocument xmldoc;
		
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
			this.xmldoc = new System.Xml.XmlDocument (); // FIXME: May adding a representation of the 
														 // xml file in memory could add new attributes
			this.scl = scl;
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
			FillAttr ();
			
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
			if (this.scl.xmlns != null) {
				for (int i = 0; i < this.scl.xmlns.ToArray().GetLength(0); i++) {
					this.nameSpaceList.Items.Add(this.scl.xmlns.ToArray()[i].Namespace);
				}
			}
			
//			this.addNameSpace = new Button();
//			this.addNameSpace.Text = "Add";
//			this.addNameSpace.Size = new System.Drawing.Size((this.nameSpaceList.Width - right * 2) / 3,
//			                                                 this.okButton.Height);
//			this.addNameSpace.Top = this.nameSpaceList.Bottom + bottom;
//			this.addNameSpace.Left = this.nameSpaceList.Left;
//			
//			this.removeNameSpace = new Button();
//			this.removeNameSpace.Text = "Remove";
//			this.removeNameSpace.Size = new System.Drawing.Size((this.nameSpaceList.Width - right * 2) / 3,
//			                                                 this.okButton.Height);
//			this.removeNameSpace.Top = this.addNameSpace.Top;
//			this.removeNameSpace.Left = this.addNameSpace.Right + right;
//			
//			this.editNameSpace = new Button();
//			this.editNameSpace.Text = "Edit";
//			this.editNameSpace.Size = new System.Drawing.Size((this.nameSpaceList.Width - right * 2) / 3,
//			                                                 this.okButton.Height);
//			this.editNameSpace.Top = this.removeNameSpace.Top;
//			this.editNameSpace.Left = this.removeNameSpace.Right + right;
//			
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
			// TODO: Add this buttoms when Add Attribute is possible
			//this.Controls.Add(this.addAttribute);
			//this.Controls.Add(this.deleteAttribute);
			this.Controls.Add(this.attrNameLabel);
			this.Controls.Add(this.attrName);
			this.Controls.Add(this.attrValueLabel);
			this.Controls.Add(this.attrValue);
			this.Controls.Add(this.nameSpaceLabel);
			this.Controls.Add(this.nameSpaceList);
			// TODO: Add this buttoms when Add Attribute is possible
			//this.Controls.Add(this.addNameSpace);
			//this.Controls.Add(this.removeNameSpace);
			//this.Controls.Add(this.editNameSpace);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			
			this.AcceptButton = this.okButton;
			this.AcceptButton.DialogResult =  DialogResult.OK;
			this.CancelButton = this.cancelButton;
			this.CancelButton.DialogResult = DialogResult.Cancel;
			// TODO: Add this methods when Add Attribute is possible
			//this.addAttribute.Click += HandleAddAttributehandleClick;
			//this.addNameSpace.Click += HandleAddNameSpacehandleClick;
			//this.attrName.KeyPress += HandleAttrNamehandleKeyPress;
			//this.attrValue.KeyPress += HandleAttrValuehandleKeyPress;
		}
		
		void FillAttr ()
		{
			this.attrList.Items.Clear ();
			if(this.element.AnyAttr != null) {
				for (int i = 0; i < this.element.AnyAttr.Length; i++) {
					this.attrList.Items.Add(this.element.AnyAttr[i].Name);
				}
			}
		}
		
//		private void ChangeAttrName() {
//			if (this.element.AnyAttr != null) {
//				this.element.AnyAttr[this.attrList.SelectedIndex].Name = this.attrName.Text;
//				this.attrList.Items[this.attrList.SelectedIndex] = this.element.AnyAttr[this.attrList.SelectedIndex].Name;
//			}
//		}
		
		private void ChangeAttrValue() {
			if (this.element.AnyAttr != null) {
				this.element.AnyAttr[this.attrList.SelectedIndex].Value = this.attrName.Text;
				this.attrList.Items[this.attrList.SelectedIndex] = this.element.AnyAttr[this.attrList.SelectedIndex].Name;
			}
		}
		
//		void HandleAttrNamehandleKeyPress (object sender, System.EventArgs e)
//		{
//			if (e.KeyCode == Keys.Enter) {
//				this.ChangeAttrName();
//			}
//		}
		
//		void HandleAttrValuehandleKeyPress (object sender, System.EventArgs e)
//		{
//			if (e.KeyCode == Keys.Enter) {
//				this.ChangeAttrValue();
//			}
//		}
		
		public static void AddNameSpace(SCL scl, ComboBox nameSpaceList) {
			EditDialog dlg = new EditDialog(scl);
			dlg.Text = "Add new Name Space";
			dlg.L1 = "Name:";
			dlg.L2 = "URI:";
			DialogResult res = dlg.ShowDialog();
			if (res == DialogResult.OK) {
				if (scl.xmlns == null) {
					scl.xmlns = new System.Xml.Serialization.XmlSerializerNamespaces();
				}
				scl.xmlns.Add(dlg.T1, dlg.T2);
				nameSpaceList.Items.Clear();
				for (int i = 0; i < scl.xmlns.ToArray().GetLength(0); i++) {
					nameSpaceList.Items.Add("xmlns:" 
					                             + scl.xmlns.ToArray()[i].Name + "="
					                             + scl.xmlns.ToArray()[i].Namespace);
				}
			}
		}
		
		void HandleAddNameSpacehandleClick (object sender, System.EventArgs e)
		{
			CustomAttributeDialog.AddNameSpace(this.scl, this.nameSpaceList);
		}

		// TODO: We can't add new Custom Attributes due to you need an XML document object reference
		void HandleAddAttributehandleClick (object sender, System.EventArgs e)
		{
			// Add a custom Name Space before to add a new one
			if(this.scl.xmlns == null)
				CustomAttributeDialog.AddNameSpace(this.scl, this.nameSpaceList);
			
			// If no custom name space then abort
			if(this.scl.xmlns != null) {
				System.Xml.XmlAttribute[] attrArray;
				if (this.element.AnyAttr == null) {
					attrArray = new System.Xml.XmlAttribute[1];
				}
				else {
					attrArray = new System.Xml.XmlAttribute[this.element.AnyAttr.GetLength(0) + 1];
					this.element.AnyAttr.CopyTo(attrArray, 0);
				}
				
				string[] ns = new string[this.scl.xmlns.ToArray().Length];
				for(int i = 0; i < ns.Length; i++) {
					ns[i] = "xmlns:"+this.scl.xmlns.ToArray()[i].Name
						+ "=" + this.scl.xmlns.ToArray()[i].Namespace;
				}
				
				EditDialog dlg = new EditDialog(this.scl, ns);
				dlg.L1 = "Name:";
				dlg.L2 = "Value:";
				dlg.Text = "Add Custom Attribute";
				DialogResult res = dlg.ShowDialog();
				
				if (res == DialogResult.OK) {
					if (this.xmldoc != null) {
						System.Console.WriteLine("NameSpace = "
					                         	+ this.scl.xmlns.ToArray()[dlg.NameSpaceIndex]);
						
						System.Console.WriteLine("Att name = " + dlg.T1);
						System.Console.WriteLine("Att value = "
						                         + dlg.T2);
						
					
						System.Xml.XmlAttribute a = this.xmldoc.CreateAttribute (dlg.T1,
						                                                         this.scl.xmlns.ToArray()[dlg.NameSpaceIndex]
						                                                         .ToString ());
						a.Value = dlg.T2;
						
						if(this.element.AnyAttr == null) {
							this.element.AnyAttr = new System.Xml.XmlAttribute [1];
							this.element.AnyAttr[1] = a;
						}
//						else
//							this.element.AddXmlAttribute (a);
						
						FillAttr ();
					}
				}
			}
		}
	}
	
	public class EditDialog : Form
	{
		private Label t1Label;
		private TextBox t1;
		private Label t2Label;
		private TextBox t2;
		private Button okButton;
		private Button cancelButton;
		
		private Label nameSpaceLabel;
		private ComboBox nameSpaceList;
		private Button addNameSpace;
				
		private string[] ns;
		private SCL scl;
		
		/// <summary>
		/// Set the value to show in the first label of the first textbox. 
		/// </summary>
		public string L1 {
			set { this.t1Label.Text = value; }
		}
		
		/// <summary>
		/// Get the value on in the first textbox. 
		/// </summary>
		public string T1 {
			get { return t1.Text; }
		}
		
		/// <summary>
		/// Set the value to show in the second label of the second textbox. 
		/// </summary>
		public string L2 {
			set { this.t2Label.Text = value; }
		}
		
		/// <summary>
		/// Get the value on in the second textbox. 
		/// </summary>
		public string T2 {
			get { return t2.Text; }
		}
		
		public int NameSpaceIndex {
			get {
				return this.nameSpaceList.SelectedIndex;
			}
		}
			
		public EditDialog(SCL scl) {
			this.scl = scl;
			this.InitializeComponent();
		}
		
		public EditDialog(SCL scl, string[] namespaces) {
			if(namespaces != null) {
				this.ns = new System.String[namespaces.Length];
				namespaces.CopyTo(this.ns, 0);
			}
			this.scl = scl;
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
			int righ = this.Margin.Right * 2;
			int bottom = this.Margin.Bottom * 4;
			int left = this.Margin.Left * 2;
			int text_size = 200;
			
			// Setup longest Label
			this.nameSpaceLabel = new Label();
			this.nameSpaceLabel.Text = "Select a NameSpace";
			this.nameSpaceLabel.AutoSize = true;
						
			this.t1Label = new Label();
			this.t1Label.Text = "Name:";
			this.t1Label.Size = this.nameSpaceLabel.Size;
			this.t1Label.Location = new System.Drawing.Point(20,20);
			
			this.t1 = new TextBox();
			this.t1.Size = new System.Drawing.Size(text_size, this.t1Label.Height);
			this.t1.Top = this.t1Label.Top;
			this.t1.Left = this.t1Label.Right + righ;
			
			this.t2Label = new Label();
			this.t2Label.Text = "Value:";
			this.t2Label.Size = this.nameSpaceLabel.Size;
			this.t2Label.Top = this.t1Label.Bottom + bottom;
			this.t2Label.Left = this.t1Label.Left;
			
			this.t2 = new TextBox();
			this.t2.Size = t1.Size;
			this.t2.Top = this.t2Label.Top;
			this.t2.Left = this.t1.Left;
			
			// Finish nameSpaceLabel setup
			this.nameSpaceLabel.Top = this.t2Label.Bottom + bottom;
			this.nameSpaceLabel.Left = this.t2Label.Left;
						
			this.nameSpaceList = new ComboBox();
			this.nameSpaceList.Size = this.t1.Size;
			this.nameSpaceList.Top = this.nameSpaceLabel.Top;
			this.nameSpaceList.Left = this.t1.Left;
			if(this.ns != null) {
				this.nameSpaceList.Items.AddRange(this.ns);
			}
			
			this.addNameSpace = new Button();
			this.addNameSpace.AutoSize = true;
			this.addNameSpace.Text = "Add";
			this.addNameSpace.Top = this.nameSpaceList.Bottom + bottom;
			this.addNameSpace.Left = this.nameSpaceList.Right - this.addNameSpace.Width;
			
			this.okButton = new Button();
			this.okButton.AutoSize = true;
			this.okButton.Text = "&Accept";
			this.okButton.Top = this.t2Label.Bottom + bottom * 2;;
			this.okButton.Left = this.t2.Right - this.okButton.Width;
			
			this.cancelButton = new Button();
			this.cancelButton.Text = "&Cancel";
			this.cancelButton.AutoSize = true;
			this.cancelButton.Top = this.okButton.Top;
			this.cancelButton.Left = this.okButton.Left - left - this.cancelButton.Width;
			
			this.Text = "Edit";
			this.Size = new System.Drawing.Size(this.okButton.Right + righ * 2, this.okButton.Bottom + bottom * 3);
			this.AcceptButton = this.okButton;
			this.AcceptButton.DialogResult = DialogResult.OK;
			this.CancelButton = this.cancelButton;
			this.CancelButton.DialogResult = DialogResult.Cancel;
			
			this.Controls.Add(t1Label);
			this.Controls.Add(t1);
			this.Controls.Add(t2Label);
			this.Controls.Add(t2);
			this.Controls.Add(okButton);
			this.Controls.Add(cancelButton);
			if(this.ns != null) {
				this.Controls.Add(nameSpaceLabel);
				this.Controls.Add(nameSpaceList);
				// Move ok and cancel buttons
				this.okButton.Top = this.nameSpaceLabel.Bottom + bottom * 2;
				this.cancelButton.Top = this.okButton.Top;
				this.AutoSize = true;
				
			}
			this.addNameSpace.Click += HandleAddNameSpacehandleClick;
		}

		void HandleAddNameSpacehandleClick (object sender, System.EventArgs e)
		{
			CustomAttributeDialog.AddNameSpace(this.scl, this.nameSpaceList);
		}
	}
	
	
}
