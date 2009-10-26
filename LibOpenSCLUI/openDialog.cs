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
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using OpenSCL;

namespace OpenSCL.UI
{
	/// <summary>
	/// Description of openDialog component.
	/// </summary>
	public partial class openDialog
	{		
		TreeViewSCL treeViewSCLOpen;
		OpenSCL.Object Object = new OpenSCL.Object(); 		
		OpenFileDialog dlg = new OpenFileDialog();
  		
		/// <summary>
		/// This method sets default values to an OpenDialog object that allows to open an SCL file.
		/// </summary>
		public void InicializeOpenDialog()
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
		/// This method shows a dialog box to allow select an XML file and show it on a tree.
		/// </summary>
		/// <param name="treeViewOpen">
		/// Graphical component "TreeView" where some nodes of XML file will be added.
		/// </param>
		/// <returns>
		/// If the file that will be open has errors of XML sintax or an incorrect data according to the 
		/// XSD files then a list of errors is returned, otherwise an empty list is returned.
		/// </returns>
		public List<ErrorsManagement> OpenSCLFile(TreeView treeViewOpen, string xSDFile)
		{	
			List<ErrorsManagement> list = null;			
			InicializeOpenDialog();	
			if(dlg.ShowDialog() == DialogResult.OK)
			{			
				ValidatingSCL validate = new ValidatingSCL();
				list = validate.ValidateFile(dlg.FileName, xSDFile);
				if (list.Count == 0)
				{										
					treeViewSCLOpen = new TreeViewSCL();
					Object.Deserialize(dlg.FileName);				
					treeViewOpen.Nodes.Add(treeViewSCLOpen.GetTreeNodeSCL(Path.GetFileName(dlg.FileName), Object.Configuration));
				}
			}		
			return list;		
		}							
	}
}
	

	


