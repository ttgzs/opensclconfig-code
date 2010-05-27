// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace OpenSASUI {
    
    
    public partial class CommViewer {
        
        private Gtk.VBox vbox4;
        
        private Gtk.HBox hbox2;
        
        private Gtk.Button updatelist;
        
        private Gtk.Button updategsetype;
        
        private Gtk.Button addobject;
        
        private Gtk.Button deleteobject;
        
        private Gtk.Button editobject;
        
        private Gtk.HPaned hpaned2;
        
        private Gtk.VBox vbox10;
        
        private Gtk.Label information_label;
        
        private Gtk.ScrolledWindow GtkScrolledWindow1;
        
        private Gtk.TreeView informationtreeview;
        
        private Gtk.VBox vbox11;
        
        private Gtk.Label label12;
        
        private Gtk.ScrolledWindow GtkScrolledWindow6;
        
        private Gtk.TreeView detailstreeview;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget OpenSASUI.CommViewer
            Stetic.BinContainer.Attach(this);
            this.Name = "OpenSASUI.CommViewer";
            // Container child OpenSASUI.CommViewer.Gtk.Container+ContainerChild
            this.vbox4 = new Gtk.VBox();
            this.vbox4.Name = "vbox4";
            this.vbox4.Spacing = 6;
            // Container child vbox4.Gtk.Box+BoxChild
            this.hbox2 = new Gtk.HBox();
            this.hbox2.Name = "hbox2";
            this.hbox2.Spacing = 6;
            // Container child hbox2.Gtk.Box+BoxChild
            this.updatelist = new Gtk.Button();
            this.updatelist.CanFocus = true;
            this.updatelist.Name = "updatelist";
            this.updatelist.UseStock = true;
            this.updatelist.UseUnderline = true;
            this.updatelist.Label = "gtk-refresh";
            this.hbox2.Add(this.updatelist);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.hbox2[this.updatelist]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.updategsetype = new Gtk.Button();
            this.updategsetype.TooltipMarkup = "Show GSE's types from IED's information";
            this.updategsetype.CanFocus = true;
            this.updategsetype.Name = "updategsetype";
            this.updategsetype.UseUnderline = true;
            // Container child updategsetype.Gtk.Container+ContainerChild
            Gtk.Alignment w2 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w3 = new Gtk.HBox();
            w3.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w4 = new Gtk.Image();
            w4.Pixbuf = Stetic.IconLoader.LoadIcon(this, "gtk-refresh", Gtk.IconSize.Menu, 16);
            w3.Add(w4);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w6 = new Gtk.Label();
            w6.LabelProp = Mono.Unix.Catalog.GetString("GSE Types");
            w6.UseUnderline = true;
            w3.Add(w6);
            w2.Add(w3);
            this.updategsetype.Add(w2);
            this.hbox2.Add(this.updategsetype);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.hbox2[this.updategsetype]));
            w10.Position = 1;
            w10.Expand = false;
            w10.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.addobject = new Gtk.Button();
            this.addobject.CanFocus = true;
            this.addobject.Name = "addobject";
            this.addobject.UseStock = true;
            this.addobject.UseUnderline = true;
            this.addobject.Label = "gtk-add";
            this.hbox2.Add(this.addobject);
            Gtk.Box.BoxChild w11 = ((Gtk.Box.BoxChild)(this.hbox2[this.addobject]));
            w11.Position = 2;
            w11.Expand = false;
            w11.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.deleteobject = new Gtk.Button();
            this.deleteobject.CanFocus = true;
            this.deleteobject.Name = "deleteobject";
            this.deleteobject.UseStock = true;
            this.deleteobject.UseUnderline = true;
            this.deleteobject.Label = "gtk-remove";
            this.hbox2.Add(this.deleteobject);
            Gtk.Box.BoxChild w12 = ((Gtk.Box.BoxChild)(this.hbox2[this.deleteobject]));
            w12.Position = 3;
            w12.Expand = false;
            w12.Fill = false;
            // Container child hbox2.Gtk.Box+BoxChild
            this.editobject = new Gtk.Button();
            this.editobject.CanFocus = true;
            this.editobject.Name = "editobject";
            this.editobject.UseStock = true;
            this.editobject.UseUnderline = true;
            this.editobject.Label = "gtk-edit";
            this.hbox2.Add(this.editobject);
            Gtk.Box.BoxChild w13 = ((Gtk.Box.BoxChild)(this.hbox2[this.editobject]));
            w13.Position = 4;
            w13.Expand = false;
            w13.Fill = false;
            this.vbox4.Add(this.hbox2);
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.vbox4[this.hbox2]));
            w14.Position = 0;
            w14.Expand = false;
            w14.Fill = false;
            // Container child vbox4.Gtk.Box+BoxChild
            this.hpaned2 = new Gtk.HPaned();
            this.hpaned2.CanFocus = true;
            this.hpaned2.Name = "hpaned2";
            this.hpaned2.Position = 488;
            // Container child hpaned2.Gtk.Paned+PanedChild
            this.vbox10 = new Gtk.VBox();
            this.vbox10.Name = "vbox10";
            this.vbox10.Spacing = 6;
            // Container child vbox10.Gtk.Box+BoxChild
            this.information_label = new Gtk.Label();
            this.information_label.Name = "information_label";
            this.information_label.LabelProp = Mono.Unix.Catalog.GetString("GSE Information");
            this.vbox10.Add(this.information_label);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.vbox10[this.information_label]));
            w15.Position = 0;
            w15.Expand = false;
            w15.Fill = false;
            // Container child vbox10.Gtk.Box+BoxChild
            this.GtkScrolledWindow1 = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
            this.GtkScrolledWindow1.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
            this.informationtreeview = new Gtk.TreeView();
            this.informationtreeview.CanFocus = true;
            this.informationtreeview.Name = "informationtreeview";
            this.GtkScrolledWindow1.Add(this.informationtreeview);
            this.vbox10.Add(this.GtkScrolledWindow1);
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.vbox10[this.GtkScrolledWindow1]));
            w17.Position = 1;
            this.hpaned2.Add(this.vbox10);
            Gtk.Paned.PanedChild w18 = ((Gtk.Paned.PanedChild)(this.hpaned2[this.vbox10]));
            w18.Resize = false;
            // Container child hpaned2.Gtk.Paned+PanedChild
            this.vbox11 = new Gtk.VBox();
            this.vbox11.Name = "vbox11";
            this.vbox11.Spacing = 6;
            // Container child vbox11.Gtk.Box+BoxChild
            this.label12 = new Gtk.Label();
            this.label12.Name = "label12";
            this.label12.LabelProp = Mono.Unix.Catalog.GetString("Details");
            this.vbox11.Add(this.label12);
            Gtk.Box.BoxChild w19 = ((Gtk.Box.BoxChild)(this.vbox11[this.label12]));
            w19.Position = 0;
            w19.Expand = false;
            w19.Fill = false;
            // Container child vbox11.Gtk.Box+BoxChild
            this.GtkScrolledWindow6 = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow6.Name = "GtkScrolledWindow6";
            this.GtkScrolledWindow6.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow6.Gtk.Container+ContainerChild
            this.detailstreeview = new Gtk.TreeView();
            this.detailstreeview.TooltipMarkup = "GSE Details. List DataSet information and IED recommended to be suscribed to this GSE.";
            this.detailstreeview.CanFocus = true;
            this.detailstreeview.Name = "detailstreeview";
            this.GtkScrolledWindow6.Add(this.detailstreeview);
            this.vbox11.Add(this.GtkScrolledWindow6);
            Gtk.Box.BoxChild w21 = ((Gtk.Box.BoxChild)(this.vbox11[this.GtkScrolledWindow6]));
            w21.Position = 1;
            this.hpaned2.Add(this.vbox11);
            this.vbox4.Add(this.hpaned2);
            Gtk.Box.BoxChild w23 = ((Gtk.Box.BoxChild)(this.vbox4[this.hpaned2]));
            w23.Position = 1;
            this.Add(this.vbox4);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Hide();
        }
    }
}
