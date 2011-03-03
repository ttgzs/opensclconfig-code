// 
//  SclFileChooser.cs
//  
//  Author:
//       Daniel Espinosa <esodan@gmail.com>
//  
//  Copyright (c) 2011 Daniel Espinosa
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using Gtk;

namespace OpenSASUI
{
	public class SclFileChooser
	{
		public SclFileChooser ()
		{
		}
		
		public static void SetSCLFilters(Gtk.FileChooserDialog dlg)
		{
			FileFilter filter = new FileFilter();
			filter.Name = "Substation Configuration Language Files";
			filter.AddMimeType("scl/cid");
			filter.AddPattern("*.cid");
			filter.AddMimeType("scl/icd");
			filter.AddPattern("*.icd");
			filter.AddMimeType("scl/scd");
			filter.AddPattern("*.scd");
			filter.AddMimeType("scl/ssd");
			filter.AddPattern("*.ssd");			
			dlg.AddFilter(filter);
			
			filter = new FileFilter();
			filter.Name = "Configured IED Description";
			filter.AddMimeType("scl/cid");
			filter.AddPattern("*.cid");
			dlg.AddFilter(filter);
			
			filter = new FileFilter();
			filter.Name = "IED Configuration Description";
			filter.AddMimeType("scl/icd");
			filter.AddPattern("*.icd");
			dlg.AddFilter(filter);
			
			filter = new FileFilter();
			filter.Name = "Substation Configuration Description";
			filter.AddMimeType("scl/scd");
			filter.AddPattern("*.scd");
			dlg.AddFilter(filter);
			
			filter = new FileFilter();
			filter.Name = "Substation Specification Description";
			filter.AddMimeType("scl/ssd");
			filter.AddPattern("*.ssd");
			dlg.AddFilter(filter);
		}
	}
}

