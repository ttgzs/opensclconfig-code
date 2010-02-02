
using System;
using OpenSCL;
using IEC61850.SCL;

namespace OpenSASUI
{


	[System.ComponentModel.ToolboxItem(true)]
	public partial class LDEditor : Gtk.Bin
	{
		private int ldindex;
		private int iedindex;
		private int apindex;
		private OpenSCL.Object sclfile;
		
		private void Init()
		{
			this.Build ();
			this.ldindex = -1;
			this.iedindex = -1;
			this.apindex = -1;
			// LN tree View
			Gtk.TreeStore model = new Gtk.TreeStore (GLib.GType.String , GLib.GType.Int, GLib.GType.String);
			Gtk.TreeIter root = model.AppendNode();
			model.SetValues(root,
			                "No Logical Nodes",
			                0,
			                "Add new Logical Nodes");
			this.lntreeview.Model = model;
			
			this.lntreeview.AppendColumn ("LN Class", new Gtk.CellRendererText (), "text", 0);
			this.lntreeview.AppendColumn ("Description", new Gtk.CellRendererText (), "text", 2);
			
			this.lntreeview.Selection.Changed += HandleLntreeviewSelectionhandleChanged;
			
			// DO tree View
			Gtk.TreeStore domodel = new Gtk.TreeStore (GLib.GType.String , GLib.GType.Int, GLib.GType.String);
			this.dotreeview.Model = domodel;
			
			this.dotreeview.AppendColumn ("Data Object", new Gtk.CellRendererText (), "text", 0);
			this.dotreeview.AppendColumn ("Description", new Gtk.CellRendererText (), "text", 2);
			this.dotreeview.Selection.Changed += HandleDotreeviewSelectionChanged;
		}

		void HandleDotreeviewSelectionChanged (object sender, EventArgs e)
		{
			Gtk.TreeIter lniter;
			
			if (this.lntreeview.Selection.GetSelected(out lniter))
			{
				Gtk.TreeIter doiter;
				Gtk.TreeSelection sel;
								
				int lnnum = (int) this.lntreeview.Model.GetValue(lniter, 1);
				
				sel = (Gtk.TreeSelection) sender;
				if (sel.GetSelected(out doiter)) {
					Gtk.TreeStore model = (Gtk.TreeStore) this.dotreeview.Model;
					if (model.GetPath(doiter).Indices.GetLength(0) == 1) {
						int donum = (int) model.GetValue(doiter, 1);
						tLDevice ld = this.sclfile.GetLD (this.iedindex, this.apindex, this.ldindex);
						if (ld.LN[lnnum].DOI[donum].DAI != null) {
							if (!model.IterHasChild (doiter)) {
								for (int i = 0; i < ld.LN[lnnum].DOI[donum].DAI.GetLength(0); i++) {
									model.AppendValues(doiter,
									                   ld.LN[lnnum].DOI[donum].DAI[i].name,
									                   i,
									                   ld.LN[lnnum].DOI[donum].DAI[i].desc);
								}
							}
						}
					}
				}
			}
		}

		void HandleLntreeviewSelectionhandleChanged (object sender, EventArgs e)
		{
			Gtk.TreeIter seliter;
			Gtk.TreeSelection sel = (Gtk.TreeSelection) sender;
			if (sel.GetSelected(out seliter))
			{
				Gtk.TreeStore model = (Gtk.TreeStore) this.lntreeview.Model;
				Gtk.TreeStore domodel = (Gtk.TreeStore) this.dotreeview.Model;
				int i = (int) model.GetValue (seliter, 1);
				// Remove Nodes on DOI view
				
				Gtk.TreeIter iter;
				while(domodel.GetIterFirst(out iter))
					domodel.Remove(ref iter);
				// Fill DOI information
				tLDevice ld = this.sclfile.GetLD(this.iedindex, this.apindex, this.ldindex);
				if (ld.LN[i].DOI != null)
				{
					for (int j = 0; j < ld.LN[i].DOI.GetLength(0); j++)
						domodel.AppendValues (ld.LN[i].DOI[j].name,
						                    j, ld.LN[i].DOI[j].desc);
				}
				else
					model.AppendValues("No DOI Information", 0,
					                   "Sugestion: See at Data Type Templates");
			}
		}
		
		public LDEditor ()
		{
			this.Init ();
		}
		
		public LDEditor (OpenSCL.Object sclfile, int numied, int numap, int numld)
		{
			this.Init();
			this.SetLD(sclfile, numied, numap, numld);
		}
				
		private bool SelectLD (OpenSCL.Object sclfile, int numied, int numap, int numld)
		{
			if(sclfile == null)
				return false;
			tLDevice ld = sclfile.GetLD(numied, numap, numld);
			
			if (ld == null)
				return false;
			
			if (ld.LN == null)
				return false;
			
			this.ldinstance.Text = ld.inst;
			// Delete All LN
			Gtk.TreeIter lniter;
			Gtk.TreeStore lnmodel = (Gtk.TreeStore) this.lntreeview.Model;
			
			while (this.lntreeview.Model.GetIterFirst(out lniter))
			{
				lnmodel.Remove(ref lniter);
			}
			//Populate Logical Nodes
		    for (int i = 0; i < ld.LN.GetLength(0); i++)
			{
				string ln = "";
				ln += ld.LN[i].prefix;
				ln += ld.LN[i].lnClass;
				ln += ld.LN[i].inst;
				lnmodel.AppendValues(ln, i, 
				                     ld.LN[i].desc);
			}
			
			return true;
		}
		
		public bool SetLD (OpenSCL.Object sclfile, int numied, int numap, int numld)
		{
			this.sclfile = sclfile;
			this.iedindex = numied;
			this.apindex = numap;
			this.ldindex = numld;
				
			if(this.SelectLD(sclfile, numied, numap, numld)) {
				return true;
			}
			else {
				this.sclfile = null;
				this.iedindex = -1;
				this.apindex = -1;
				this.ldindex = -1;
				
				return false;
			}
		}
		
		public bool ChangeLD (int apIndex, int ldIndex)
		{
			this.apindex = apIndex;
			this.ldindex = ldIndex;
			
			if (this.SelectLD (this.sclfile, this.iedindex, apIndex, ldIndex)) {
				return true;
			}
			else {
				Gtk.MessageDialog msg = new Gtk.MessageDialog(null, Gtk.DialogFlags.DestroyWithParent,
				                                              Gtk.MessageType.Error, Gtk.ButtonsType.Close,
				                                              false, "Error on Set LD %i from AP %i IED %I", 
				                                              ldIndex, apindex, iedindex);
				msg.Run();
				this.apindex = -1;
				this.ldindex = -1;
				return false;
			}
		}
	}
}
