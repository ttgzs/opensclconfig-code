// OpenSCLConfigurator 
//
// Copyright (C) 2009 Comisión Federal de Electricidad
// 
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 3
// of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

using System;
using System.Windows.Forms;

namespace OpenSCLConfigurator
{
	/// <summary>
	/// Description of about class.
	/// </summary>
	public partial class about : Form
	{		            
        /// <summary>
        /// Inicialization of components of the form.
        /// </summary>
        public about()
        {
            InitializeComponent();                                                
        }		        	
		
        /// <summary>
        /// This method hides the about form.
        /// </summary>
        /// <param name="sender">
        /// Graphical component selected.
        /// </param>
        /// <param name="e">
        /// Initializes a new instance of the EventArgs class. 
        /// </param>
		void OKAboutClick(object sender, EventArgs e)
		{
			this.Hide();			
		}						
	}
 }
