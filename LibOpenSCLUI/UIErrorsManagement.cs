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
using System.Collections.Generic;

namespace OpenSCL.UI
{
	/// <summary>
	/// Description of UIErrorsManagement.
	/// </summary>
	public class UIErrorsManagement
	{
		private ListBox listBox = new ListBox();
		
		public UIErrorsManagement()
		{
			
		}
		
		public ListBox ShowError(List<ErrorsManagement> listErrors)
		{			
			if(listErrors!=null)
			{					
				foreach(ErrorsManagement ls in listErrors) 
				{
					listBox.Items.Add(ls.ErrorMessage);
				}
			}
			if(listBox.Items.Count>0)
			{
				listBox.Dock = System.Windows.Forms.DockStyle.Fill;		
				listBox.ScrollAlwaysVisible = true;
				listBox.Show();
			}				
			return listBox;					
		}
		
	}
}
