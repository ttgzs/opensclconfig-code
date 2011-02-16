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

using System;
using System.Windows.Forms;
using System.Xml;
using IEC61850.SCL;

namespace OpenSCL.UI
{
	/// <summary>
	/// Description of ManipulationText.
	/// </summary>
	public partial class PrivateDialog : Form
	{
		private tPrivate sCLPrivate;		
		private Private privateObject;
		private bool bandModifyElement = false;
		private bool bandModifyAttribute = false;		
		int indexElementTemp;
		
		public PrivateDialog(tPrivate sCLPrivate)
		{
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();			
			if(sCLPrivate.Any != null && sCLPrivate.Any.Length > 0)
			{
				this.elementsListBox.DataSource = sCLPrivate.Any;
				this.elementsListBox.DisplayMember = "Name";			
			}					
			this.sCLPrivate = sCLPrivate;
			this.privateObject = new Private();
		}
		
		/// <summary>
		/// This method cleans the value's of the graphical objects of this dialog box.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void ManipulationTextLoad(object sender, EventArgs e)
		{
			if(this.sCLPrivate.type != null)
			{
				this.TextType.Text = this.sCLPrivate.type.ToString();
			}
			else
			{
				this.TextType.Text = "";
			}
			if((this.sCLPrivate as tPrivate).source != null)
			{
				this.TextSource.Text = this.sCLPrivate.source.ToString();
			}
			else
			{
				this.TextSource.Text = "";
			}						
		}	

		/// <summary>
		/// This event close the dialog box.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void CancelBtnClick(object sender, EventArgs e)
		{						
			this.Close();
		}
				
		/// <summary>
		/// This event saves the information of the tPrivate object, like type and source properties.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void ButtonOkClick(object sender, EventArgs e)
		{
			if(this.TextType.Text != "")
			{
				this.sCLPrivate.type  = this.TextType.Text;
			}
			else
			{
				this.sCLPrivate.type= null;
			}
			if(this.TextSource.Text != "")
			{
				this.sCLPrivate.source = this.TextSource.Text;
			}
			else
			{
				this.sCLPrivate.source = null;
			}		
			this.Close();
		}
		
		/// <summary>
		/// This event shows the graphical objects used to add element data. 
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void AddElementButtonClick(object sender, EventArgs e)
		{				
			this.bandModifyElement = false;				
			this.LoadElement(null);
		}
		
		/// <summary>
		/// This event cancel the changes made on the dialog box.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void AttributeButtonCancelClick(object sender, EventArgs e)
		{			
			this.attributeLocalNameTextBox.Text = this.AttributeValueTextBox.Text = "";
		}
		
		/// <summary>
		/// This event creates or modififes an element using the data provided on the specific dialog box.		
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void ElementOKButtonClick(object sender, EventArgs e)
		{						
			if(!(this.namespaceTextBox.Text.Equals("") || this.localNameTextBox.Text.Equals("") || this.prefixTextBox.Text.Equals("")))
			{
				if(this.bandModifyElement)
				{
					this.privateObject.ModifyElement(this.elementsListBox.SelectedIndex, this.sCLPrivate, this.prefixTextBox.Text, this.localNameTextBox.Text, this.namespaceTextBox.Text, this.valueTextBox.Text);
					this.elementsListBox.UpdateItems(sCLPrivate.Any, "Name");
				}				
				else
				{
					this.privateObject.AddElement(this.sCLPrivate, this.prefixTextBox.Text, this.localNameTextBox.Text, this.namespaceTextBox.Text, this.valueTextBox.Text);
					this.elementsListBox.UpdateItems(sCLPrivate.Any, "Name");
				}
				this.valueTextBox.Text = this.namespaceTextBox.Text = this.localNameTextBox.Text = this.prefixTextBox.Text = "";
			}
			else
			{
				MessageBox.Show("The fields are empty");
			}
		}
					
		/// <summary>
		/// This event creates or modifies an attribute using the information provided on the specific dialog box.		
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void AttributeOKButtonClick(object sender, EventArgs e)
		{
			if(!(this.attributeLocalNameTextBox.Text.Equals("")))
			{
				if(this.bandModifyAttribute)
				{
					if(this.bandModifyElement)
					{
						this.privateObject.ModifyAttribute(this.indexElementTemp, this.attributesListBox.SelectedIndex, this.sCLPrivate, attributeLocalNameTextBox.Text, AttributeValueTextBox.Text);
					}
					else
					{
						this.privateObject.ModifyAttribute(sCLPrivate.Any.Length-1, this.attributesListBox.SelectedIndex, this.sCLPrivate, attributeLocalNameTextBox.Text, AttributeValueTextBox.Text);
					}
					this.attributesListBox.Items[this.attributesListBox.SelectedIndex] = attributeLocalNameTextBox.Text;
				}
				else
				{
					if(this.bandModifyElement)
					{
						this.privateObject.AddAttribute(this.indexElementTemp, sCLPrivate, attributeLocalNameTextBox.Text, AttributeValueTextBox.Text);
					}
					else
					{
						this.privateObject.AddAttribute(this.sCLPrivate.Any.Length-1, sCLPrivate, attributeLocalNameTextBox.Text, AttributeValueTextBox.Text);
					}
					this.attributesListBox.Items.Add(attributeLocalNameTextBox.Text);
				}
				this.attributeLocalNameTextBox.Text = this.AttributeValueTextBox.Text = "";	
				EditElementEvent(sender, e);
			}
			else
			{
				MessageBox.Show("The fields are empty");
			}
		}
						
		/// <summary>
		/// This event cancel the changes made for the element on the dialgo box.		
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void ElementButtonCancelClick(object sender, EventArgs e)
		{			
			this.valueTextBox.Text = this.namespaceTextBox.Text = this.localNameTextBox.Text = this.prefixTextBox.Text = "";
		}

		/// <summary>
		/// This event shows a dialog box for the attribute information.		
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void AddAttributeButtonClick(object sender, EventArgs e)
		{
			this.bandModifyAttribute = false;
			this.LoadAtttribute(null);						
		}			
		
		/// <summary>		
		/// This event allows to modify or delete information about the selected element.		
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void EditElementEvent(object sender, EventArgs e)
		{	
			this.attributesListBox.Items.Clear();
			if(this.elementsListBox.SelectedIndex!=-1)
			{
				this.bandModifyElement = true;
				this.indexElementTemp = this.elementsListBox.SelectedIndex;
				this.LoadElement(this.sCLPrivate.Any[this.elementsListBox.SelectedIndex]);								
			}						
		}
		
		/// <summary>
		/// This method cleans or shows the element information on the dialog box.		
		/// </summary>
		/// <param name="Element">
		/// If an element will be edited, the element information is send to the dialog box, in the case of 
		/// insert an element then the element's value should be null.		
		/// </param>
		private void LoadElement(XmlNode Element)
		{			
			if(Element != null && Element.Attributes != null && Element.Attributes.Count > 0)
			{			
				for(int x = 0; x < Element.Attributes.Count; x++)
				{
					this.attributesListBox.Items.Add(Element.Attributes[x].Name);
				}
				if(this.attributesListBox.Items.Count > 0)
				{					
					this.attributesListBox.SelectedIndex = 0;
				}				
			}
			if(this.bandModifyElement)
			{				
				this.prefixTextBox.Text = Element.Prefix;
				this.localNameTextBox.Text = Element.LocalName;
				this.namespaceTextBox.Text = Element.NamespaceURI;
				this.valueTextBox.Text = Element.InnerText;
			}
			else
			{
				this.valueTextBox.Text = this.namespaceTextBox.Text = this.localNameTextBox.Text = this.prefixTextBox.Text = "";			 
			}		
			this.DeleteElementButton.Enabled = this.elementsListBox.Items.Count > 0;
		}	
		
		/// <summary>
		/// This method cleans or shows the attribute information on the dialog box.			
		/// </summary>
		/// <param name="attribute">
		/// If an attribute will be edited, the element information is send to the dialog box, in the case of 
		/// insert an attribute then the attribute's value should be null.	
		/// </param>
		private void LoadAtttribute(XmlAttribute attribute)
		{
			if(this.bandModifyAttribute)
			{
				this.attributeLocalNameTextBox.Text = attribute.Name;
				this.AttributeValueTextBox.Text = attribute.Value;
			}
			else
			{
				this.attributeLocalNameTextBox.Text = this.AttributeValueTextBox.Text = "";
			}
			this.DeleteAttributeButton.Enabled = this.attributesListBox.Items.Count > 0;
		}
		
		/// <summary>
		/// This event shows the dialog box to modify or delete the information of the selected attribute. 		
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		private void EditAttributeEvent(object sender, EventArgs e)
		{
			if(this.attributesListBox.SelectedIndex!=-1)
			{
				this.bandModifyAttribute = true;				
				if(this.bandModifyElement)
				{					
					this.LoadAtttribute(this.sCLPrivate.Any[this.indexElementTemp].Attributes[this.attributesListBox.SelectedIndex]);
				}
				else
				{					
					this.LoadAtttribute(this.sCLPrivate.Any[this.sCLPrivate.Any.Length-1].Attributes[this.attributesListBox.SelectedIndex]);
				}				
			}
		}
		
		/// <summary>
		/// This event deletes the selected element.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void DeleteElementButtonClick(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to delete the selected element? If you remove, you will lose the element's data", "Delete element", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				if(this.bandModifyElement)
				{
					this.privateObject.DeleteElement(this.indexElementTemp, this.sCLPrivate);
					this.elementsListBox.UpdateItems(sCLPrivate.Any, "Name");
					this.valueTextBox.Text = this.namespaceTextBox.Text = this.localNameTextBox.Text = this.prefixTextBox.Text = "";
				}		
				this.DeleteElementButton.Enabled = this.elementsListBox.Items.Count > 0;							
				EditElementEvent(sender, e);				
			}
		}
		
		/// <summary>
		/// This event deletes the selected attribute.
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void DeleteAttributeButtonClick(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you want to delete the selected attribute? If you remove, you will lose the attribute's data", "Delete attribute", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				if(this.bandModifyElement)
				{
					if(this.bandModifyAttribute)
					{
						this.sCLPrivate.Any[this.indexElementTemp].Attributes.RemoveAt(this.attributesListBox.SelectedIndex);
						this.attributeLocalNameTextBox.Text = this.AttributeValueTextBox.Text = "";
					}					
				}
				else
				{
					if(this.bandModifyAttribute)
					{
						this.sCLPrivate.Any[this.sCLPrivate.Any.Length-1].Attributes.RemoveAt(this.attributesListBox.SelectedIndex);						
						this.attributeLocalNameTextBox.Text = this.AttributeValueTextBox.Text = "";
					}
				}				
				this.attributesListBox.Items.RemoveAt(this.attributesListBox.SelectedIndex);				
				this.DeleteAttributeButton.Enabled = this.attributesListBox.Items.Count > 0;									
			}			
		}
	}
	
	/// <summary>
	/// Custom class that inherits from Listbox class. 
	/// </summary>
	/// <remarks>
	/// This class was created to access at his constructor and other methods that are defined as protected.
	/// </remarks>
	public class ListBoxHierachy : ListBox
	{		
		public void UpdateItems(object newDataSorce, string displayMember)
		{
			this.DataSource = null;
			this.Items.Clear();			
			this.DataSource = newDataSorce;
			this.DisplayMember = displayMember;
		}
	}
}