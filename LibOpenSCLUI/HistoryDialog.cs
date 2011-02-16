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
using IEC61850.SCL;

namespace OpenSCL.UI
{
	/// <summary>
	/// Description of HistoryDialog. 
	/// Dialog box that allows to capture information about an history.
	/// </summary>
	public partial class HistoryDialog : Form
	{			
		private tHitem objectHitem;
		private tHeader objectHeader;		
	
		public HistoryDialog(tHeader objectHeader)
		{			
			this.objectHeader = objectHeader;
			this.objectHitem = new tHitem();			
			InitializeComponent();
			this.OkButton.DialogResult = DialogResult.OK;			
			this.AcceptButton = this.OkButton;				
			this.tHitemPropertyGrid.SelectedObject = objectHitem;
		}
				
		/// <summary>		
		/// This event adds an item to the history class for the header used to show this window.		
		/// </summary>
		/// <param name="sender">
		/// Name of the object.
		/// </param>
		/// <param name="e">
		/// This class contains no event data; it is used by events that do not pass state information to an event 
		/// handler when an event is raised. If the event handler requires state information, the application must 
		/// derive a class from this class to hold the data.
		/// </param>
		void OkButtonClick(object sender, EventArgs e)
		{	
			this.objectHitem = (tHitem)this.tHitemPropertyGrid.SelectedObject;		
			ObjectManagement.AddObjectToArrayObjectOfParentObject(this.objectHitem, this.objectHeader);
		}
	}
}
