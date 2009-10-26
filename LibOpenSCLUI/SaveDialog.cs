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
	/// Description of SaveDialog.
	/// </summary>
	public class SaveDialog
	{
		OpenSCL.Object sclObject = new OpenSCL.Object(); 		
		SaveFileDialog saveDlg = new SaveFileDialog();

		/// <summary>
		/// This method sets default values to a Save Dialog object
		/// </summary>
		public void InicializeSaveDialog()
		{
			saveDlg.Title = "Save an SCL File";
			saveDlg.Filter = "SCL Files (*.icd,*.cid,*.ssd,*.scd)|*.icd;*.cid;*.ssd;*.scd|" +
				"IED Capability Description Files (*.icd)|*.icd|" +
				"Configured IED Description Files (*.cid)|*.cid|" +
				"Substation Configuration Description Files (*.scd)|*.scd|" +
				"System Specification Description Files (*.ssd)|*.ssd|" +
				"All Files (*.*)|*.*";			
			saveDlg.CheckPathExists = true;
			saveDlg.DefaultExt = "scd";
			saveDlg.OverwritePrompt = true;
			saveDlg.ValidateNames = true;
		}

		/// <summary>
		/// This method shows a dialog box to allow select a name for the SCL file to save it.
		/// </summary>
		/// <param name="treeViewOpen">
		/// Graphical component "TreeView" where some nodes of XML file will be added.
		/// </param>
		public void SaveSCLFile(TreeView treeViewOpen)
		{			
			InicializeSaveDialog();	
            if (treeViewOpen.Nodes.Count != 0)
            {            		                
                sclObject.Configuration = (SCL) treeViewOpen.Nodes["root"].Nodes["SCL"].Tag;;
				if(saveDlg.ShowDialog() == DialogResult.OK)
                {
                    sclObject.Serialize(saveDlg.FileName);	
                    MessageBox.Show("The file was saved correctly");
                }
            }
            else
            {
            	MessageBox.Show("Warning!!, You have to open a file first");
			}			
		}					
	}
}
