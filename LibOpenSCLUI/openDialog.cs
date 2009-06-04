// LibOpenSCLUI
//
// Copyright (C) 2009 Comisión Federal de Electricidad
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
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

namespace OpenSCL.UI
{
	/// <summary>
	/// Description of openDialog.
	/// </summary>
	public partial class openDialog
	{
		//opens file dialog, if is ok and the file has errors fills the listbox from listerrors else sends the listbox empty
		public string openDialogs()
		{
			OpenFileDialog dlg = new OpenFileDialog();
			string NameFileXML;
			dlg.Title = "Open XML Document";
			dlg.Filter = "XML Files (.xml)|*.xml|CID Files (*.icd)|*.icd|SCD Files (.scd)|*.scd|SSD Files (*.ssd)|*.ssd";
			dlg.FilterIndex =1;
			if(dlg.ShowDialog() == DialogResult.OK)
			{				
				NameFileXML=dlg.FileName;				
			}
			else
			{
				NameFileXML="";
			}
			return NameFileXML;				
		}				
	}
}
	

	


