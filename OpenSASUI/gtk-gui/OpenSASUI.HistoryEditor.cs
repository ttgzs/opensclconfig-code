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
    
    
    public partial class HistoryEditor {
        
        private Gtk.VBox vbox1;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Button add;
        
        private Gtk.Button remove;
        
        private Gtk.Button edit;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TreeView history;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget OpenSASUI.HistoryEditor
            Stetic.BinContainer.Attach(this);
            this.Name = "OpenSASUI.HistoryEditor";
            // Container child OpenSASUI.HistoryEditor.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.add = new Gtk.Button();
            this.add.CanFocus = true;
            this.add.Name = "add";
            this.add.UseStock = true;
            this.add.UseUnderline = true;
            this.add.Label = "gtk-add";
            this.hbox1.Add(this.add);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.hbox1[this.add]));
            w1.Position = 0;
            w1.Expand = false;
            w1.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.remove = new Gtk.Button();
            this.remove.CanFocus = true;
            this.remove.Name = "remove";
            this.remove.UseStock = true;
            this.remove.UseUnderline = true;
            this.remove.Label = "gtk-remove";
            this.hbox1.Add(this.remove);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox1[this.remove]));
            w2.Position = 1;
            w2.Expand = false;
            w2.Fill = false;
            // Container child hbox1.Gtk.Box+BoxChild
            this.edit = new Gtk.Button();
            this.edit.CanFocus = true;
            this.edit.Name = "edit";
            this.edit.UseStock = true;
            this.edit.UseUnderline = true;
            this.edit.Label = "gtk-edit";
            this.hbox1.Add(this.edit);
            Gtk.Box.BoxChild w3 = ((Gtk.Box.BoxChild)(this.hbox1[this.edit]));
            w3.Position = 2;
            w3.Expand = false;
            w3.Fill = false;
            this.vbox1.Add(this.hbox1);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
            w4.Position = 0;
            w4.Expand = false;
            w4.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.history = new Gtk.TreeView();
            this.history.CanFocus = true;
            this.history.Name = "history";
            this.GtkScrolledWindow.Add(this.history);
            this.vbox1.Add(this.GtkScrolledWindow);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox1[this.GtkScrolledWindow]));
            w6.Position = 1;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Hide();
        }
    }
}