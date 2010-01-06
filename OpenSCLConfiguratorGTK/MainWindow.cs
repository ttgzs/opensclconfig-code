// 
//  MainWindow.cs
//  
//  Author:
//       Daniel Espinosa <esodan@gmail.com>
//  
//  Copyright (c) 2009 Daniel Espinosa Ortiz
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
using System.Reflection;
using Gtk;
using OpenSCL;


public partial class MainWindow : Gtk.Window
{
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		this.notebook1.CurrentPage = 0;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected virtual void OnExitEvent (object sender, System.EventArgs e)
	{
		Application.Quit ();
	}
	
	protected virtual void OnOpenEvent (object sender, System.EventArgs e)
	{
		Gtk.FileChooserDialog dlg = new FileChooserDialog("Open SCL File",
		                                            this,
		                                            FileChooserAction.Open,
		                                            "Cancel", ResponseType.Cancel,
		                                            "Open", ResponseType.Accept);
		
		if (dlg.Run() == (int) Gtk.ResponseType.Accept)
		{
			this.scleditor.SclFile = new OpenSCL.Object(dlg.Filename);
		}
		dlg.Destroy();
	}
	
	protected virtual void OnNewEvent (object sender, System.EventArgs e)
	{
	}
	
	protected virtual void OnSave (object sender, System.EventArgs e)
	{
		if (this.scleditor.SclFile != null)
			this.scleditor.SclFile.Serialize ();
	}
	
	protected virtual void OnSaveAs (object sender, System.EventArgs e)
	{
		if (this.scleditor.SclFile != null)
		{
			Gtk.FileChooserDialog dlg = new Gtk.FileChooserDialog ("Save As",
			                                                       this,
			                                                       Gtk.FileChooserAction.Save,
			                                                       "Accept", Gtk.ResponseType.Accept,
			                                                       "Cancel", Gtk.ResponseType.Cancel);
			if (dlg.Run() == (int) ResponseType.Accept)
			{
				this.scleditor.SclFile.Serialize(dlg.Filename);
			}
			
			dlg.Destroy();
		}
	}
	
	protected virtual void OnAbout (object sender, System.EventArgs e)
	{
		Gtk.AboutDialog dialog = new Gtk.AboutDialog();
		System.Reflection.Assembly asm = Assembly.GetExecutingAssembly();
		dialog.ProgramName = (asm.GetCustomAttributes (
			typeof (AssemblyTitleAttribute), false) [0]
			as AssemblyTitleAttribute).Title;
		
		dialog.Version = asm.GetName ().Version.ToString ();
		
		dialog.Comments = (asm.GetCustomAttributes (
			typeof (AssemblyDescriptionAttribute), false) [0]
			as AssemblyDescriptionAttribute).Description;
		
		dialog.Copyright = (asm.GetCustomAttributes (
			typeof (AssemblyCopyrightAttribute), false) [0]
			as AssemblyCopyrightAttribute).Copyright;
		
		dialog.License = license;
		
		dialog.Authors = authors;
		
		dialog.Run();
		dialog.Destroy();
	}
		
	private static string license = 
  @"This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU Lesser General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.
 
  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU Lesser General Public License for more details.
 
  You should have received a copy of the GNU Lesser General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.";
	
	private static string [] authors = new string [] { 
									"Daniel Espinosa <esodan@gmail.com>" 
	};

}
