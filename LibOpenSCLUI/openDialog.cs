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
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using IEC61850.SCL;

namespace OpenSCL.UI
{
	/// <summary>
	/// Description of openDialog component.
	/// </summary>
	public partial class openDialog
	{		
		private bool open_ied = false;
		string filename;
		
		public bool ImportIED {
			get { return open_ied; }
			set { open_ied = value;}
		}
		
		public string FileName {
			get { return filename; }
		}
		
		
		
		private void  OpenSclDialogInit (System.Windows.Forms.OpenFileDialog dlg)
		{
			dlg.Title = "Open an SCL File";
			dlg.Filter = "SCL Files (*.icd,*.cid,*.ssd,*.scd)|*.icd;*.cid;*.ssd;*.scd|" +
				"IED Capability Description Files (*.icd)|*.icd|" +
				"Configured IED Description Files (*.cid)|*.cid|" +
				"Substation Configuration Description Files (*.scd)|*.scd|" +
				"System Specification Description Files (*.ssd)|*.ssd|" +
				"All Files (*.*)|*.*";
			dlg.FilterIndex =1;
			dlg.CheckPathExists = true;
			dlg.CheckFileExists = true;
		}
		
		/// <summary>
		/// This method sets default values to an OpenDialog object that allows to open an IED file 
		/// (*.ICD, *.CID).
		/// </summary>
		private void OpenIEDDialogInit (System.Windows.Forms.OpenFileDialog dlg)
		{
			dlg.Title = "Open an IED File";
			dlg.Filter = "SCL Files (*.icd,*.cid,*.ssd,*.scd)|*.icd;*.cid;*.ssd;*.scd|" +
				"IED Capability Description Files (*.icd)|*.icd|" +
				"Configured IED Description Files (*.cid)|*.cid|" +
				"Substation Configuration Description Files (*.scd)|*.scd|" +
				"System Specification Description Files (*.ssd)|*.ssd|" +
				"All Files (*.*)|*.*";
			dlg.FilterIndex =1;
			dlg.CheckPathExists = true;
			dlg.CheckFileExists = true;			
		}
		
		public DialogResult ShowDialog () 
		{ 
			var dlg = new System.Windows.Forms.OpenFileDialog ();
			if (open_ied)
				OpenIEDDialogInit (dlg);
			else
				OpenSclDialogInit (dlg);
			
			var r = dlg.ShowDialog ();
			filename = dlg.FileName;
			return r;
		}
	}
}
	

	


