using System;
using System.Threading;
using Gtk;
using OpenSCL;

namespace OpenSASConfigurator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
