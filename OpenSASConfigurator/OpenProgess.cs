
using System;

namespace OpenSASConfigurator
{


	public partial class OpenProgess : Gtk.Window
	{

		public OpenProgess (Gtk.Window parent, string filename) : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			this.progressbar.Fraction = 0.01;
			this.progressbar.PulseStep = 0.003;
			this.progressbar.Text = "Loading file...";
			this.label.Text = "Opening SCL File: ";
			this.label.Text += filename;
			this.Modal = true;
			this.TransientFor = parent;
			this.SetPosition(Gtk.WindowPosition.CenterOnParent);
			this.Decorated = false;
		}
		
		public void Pulse()
		{
			this.progressbar.Pulse();
		}
	}
}
