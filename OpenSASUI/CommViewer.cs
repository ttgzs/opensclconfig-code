// 
//  CommViewer.cs
//  
//  Author:
//       Daniel Espinosa <esodan@gmail.com>
//  
//  Copyright (c) 2010 Daniel Espinosa
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

namespace OpenSASUI
{


	//[System.ComponentModel.ToolboxItem(true)]
	public abstract partial class CommViewer : Gtk.Bin
	{
		protected OpenSCL.Object sclfile;
		protected int ied;
		protected int subnetwork;
		protected bool update;
		private bool hidedetails;
		
		protected int comparestring (object tree, Gtk.TreeIter a, Gtk.TreeIter b, int column)
		{
			string s1 = (string) this.informationtreeview.Model.GetValue (a, column);
			string s2 = (string) this.informationtreeview.Model.GetValue (b, column);
			if (s1 != null || s2 != null)
				return s1.CompareTo(s2);
			else
				return 0;
		}
		
		protected int comparestring_c0 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			return comparestring (tree, a, b, 0);
		}
		
		protected int comparestring_c1 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			return comparestring (tree, a, b, 1);
		}
		
		protected int comparestring_c2 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			return comparestring (tree, a, b, 2);
		}
		
		protected int comparestring_c3 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			return comparestring (tree, a, b, 3);
		}
		
		protected int comparestring_c4 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			return comparestring (tree, a, b, 4);
		}
		
		protected int comparestring_c5 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			return comparestring (tree, a, b, 5);
		}
		
		protected int comparestring_c6 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			return comparestring (tree, a, b, 6);
		}
				
		protected int comparestring_c7 (object tree, Gtk.TreeIter a, Gtk.TreeIter b)
		{
			
			return comparestring (tree, a, b, 7);
		}
				
		protected void FillModelDataSetInfo(IEC61850.SCL.tDataSet ds, int dsIndex, Gtk.TreeStore dsmodel)
		{
			if (!(ds == null || dsIndex < 0)) {
				string name = "" + ds.name;
				string desc = "" + ds.desc;
				Gtk.TreeIter dsIter;
				
				dsIter = dsmodel.AppendValues(name, "", desc, -1, dsIndex);
				if (ds.FCDA != null) {
					for (int j = 0; j < ds.FCDA.GetLength(0); j++) {
						string t = "";
						if (ds.FCDA[j].ldInst != null)
							if(ds.FCDA[j].ldInst.Length > 0) {
								t += ds.FCDA[j].ldInst + ".";
						}
						else
							t += "[NO LD DEFINED].";
						
						if (ds.FCDA[j].lnClass != null)
							if (ds.FCDA[j].lnClass.Length > 0) {
								t += ds.FCDA[j].prefix;
								t += ds.FCDA[j].lnClass;
								t += ds.FCDA[j].lnInst + ".";
							}
						else
							t += "[NO LN INFO].";
						if (ds.FCDA[j].doName != null)
							if (ds.FCDA[j].doName.Length > 0)
								t += ds.FCDA[j].doName;
						else
							t += "[NO DATA OBJECT INFO]";
						if (ds.FCDA[j].daName != null)
							if (ds.FCDA[j].daName.Length > 0)
								t += "." + ds.FCDA[j].daName;
						
						dsmodel.AppendValues(dsIter, t, ds.FCDA[j].fc.ToString(), "", j, dsIndex);
					}
				}
			}
			else
				dsmodel.AppendValues("NO DataSet REFERENCE IS SET");
		}
		
		public CommViewer ()
		{
			this.ied = -1;
			this.subnetwork = -1;
			this.update = false;
			this.hidedetails = false;
			this.Build ();
			this.updatelist.Clicked += HandleUpdatehandleClicked;
			this.updategsetype.Clicked += OnActivatedGSETypes;
			// Setup Object's DataSet table information
			Gtk.TreeStore dsetmodel = new Gtk.TreeStore(typeof(string), // FCDA / DataSet name 0
			                                            typeof(string), // FC 1
			                                            typeof(string), // Desc 2
			                                            typeof(int), // FCDA Index 3
			                                            typeof(int)); // DataSet Index 4
			this.detailstreeview.AppendColumn (Mono.Unix.Catalog.GetString("DataSet/IED"),
			                               new Gtk.CellRendererText (), "text", 0);
			this.detailstreeview.AppendColumn (Mono.Unix.Catalog.GetString("FC"),
			                               new Gtk.CellRendererText (), "text", 1);
			
			this.detailstreeview.AppendColumn (Mono.Unix.Catalog.GetString("Desc"),
			                               new Gtk.CellRendererText (), "text", 2);
			this.detailstreeview.Model = dsetmodel;
			this.detailstreeview.GetColumn(0).Resizable = true;
			this.detailstreeview.GetColumn(1).Resizable = true;
			this.detailstreeview.GetColumn(2).Resizable = true;
			
			this.Sensitive = false;
		}
		
		public OpenSCL.Object SclFile {
			get {
				return this.sclfile;
			}
		}

		public bool Update {
			get {
				return this.update;
			}
			set {
				this.update = value;
			}
		}
		
		protected Gtk.TreeView InfoTreeView {
			get {
				return this.informationtreeview;
			}
		}
		
		protected Gtk.TreeView DetailsTreeView {
			get {
				return this.detailstreeview;
			}
		}
		
		protected Gtk.Button UpdateListButton {
			get {
				return this.updatelist;
			}
		}
		
		protected string InfoLabel {
			get {
				return this.information_label.Text;
			}
			set {
				this.information_label.Text = value;
			}
		}
		
		protected bool HideDetails {
			get {
				return this.hidedetails;
			}
			set {
				this.hidedetails = value;
				if(this.hidedetails) {
					this.hpaned2.Remove(this.hpaned2.Child2);
				}
				else
					this.hpaned2.Pack2(this.vbox11, true,  false);
			}
		}
		
		public bool SetSubnetwork (OpenSCL.Object sclfile, int subnet, bool update)
		{
			return this.InitData(sclfile, subnet, -1, update);
		}
		
		public bool SetIED (OpenSCL.Object sclfile, int subnet, int ied, bool update)
		{
			return this.InitData(sclfile, subnet, ied, update);
		}
		
		private bool InitData (OpenSCL.Object sclfile, int subnet, int ied, bool update)
		{
			if (sclfile == null)
				return false;
			if (sclfile.Subnetworks == null)
				return false;
			if (subnet < 0 || subnet > sclfile.Subnetworks.GetLength(0))
				return false;
			
			this.ied = ied;
			this.subnetwork = subnet;
			this.sclfile = sclfile;
			this.update = update;
			if(update) {
				this.UpdateList();
				this.UpdateGSETypes();
				this.updategsetype.Visible = false;
			}

			this.Sensitive = true;
			
			return true;
		}
		
		protected abstract void UpdateList ();
		
		protected virtual void UpdateGSETypes ()
		{
			// To be overided by derived classes
		}
		
		protected virtual void OnActivatedGSETypes (object sender, System.EventArgs e)
		{
			this.UpdateGSETypes();
		}
		
		void HandleUpdatehandleClicked (object sender, EventArgs e)
		{
			this.UpdateList();
		}
		
		protected void Clear(bool sensitive)
		{
			Gtk.TreeIter iter;
			// Object List Viewer
			Gtk.TreeStore model = (Gtk.TreeStore) this.informationtreeview.Model;
			while (model.GetIterFirst(out iter))
				model.Remove(ref iter);
			// Object's DataSet Viewer
			Gtk.TreeStore dsmodel = (Gtk.TreeStore) this.informationtreeview.Model;
			while (dsmodel.GetIterFirst(out iter))
				dsmodel.Remove(ref iter);
			
			this.Sensitive = sensitive;
		}
		
		public void Clear()
		{
			this.Clear(false);
		}
		
	}
}
