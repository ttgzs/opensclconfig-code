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
    
    
    public partial class APEditor {
        
        private Gtk.VBox vbox1;
        
        private Gtk.Expander accesspointdetails;
        
        private Gtk.Table table2;
        
        private Gtk.Entry accesspointdesc;
        
        private Gtk.CheckButton accesspointisclock;
        
        private Gtk.CheckButton accesspointisrouter;
        
        private Gtk.Entry accesspointname;
        
        private Gtk.Expander aplndetails;
        
        private Gtk.HBox hbox3;
        
        private Gtk.ScrolledWindow GtkScrolledWindow1;
        
        private Gtk.TreeView aplntreeview;
        
        private Gtk.VBox vbox2;
        
        private Gtk.Button addapln;
        
        private Gtk.Button removeapln;
        
        private Gtk.Button propertiesapln;
        
        private Gtk.Label GtkLabel3;
        
        private Gtk.Label label8;
        
        private Gtk.Label label9;
        
        private Gtk.Label GtkLabel6;
        
        private Gtk.HBox hbox4;
        
        private Gtk.Label label10;
        
        private Gtk.ComboBox subnetworklist;
        
        private Gtk.Button propertiessubnet;
        
        private Gtk.Button connectsubnet;
        
        private Gtk.Button desconnectsubnet;
        
        private Gtk.Expander connectiondetails;
        
        private Gtk.Notebook notebook;
        
        private Gtk.HPaned hpaned1;
        
        private Gtk.ScrolledWindow GtkScrolledWindow;
        
        private Gtk.TreeView addresstreeview;
        
        private Gtk.Table table1;
        
        private Gtk.Entry addressvalue;
        
        private Gtk.Label label6;
        
        private Gtk.Label label7;
        
        private Gtk.Button manageaddress;
        
        private Gtk.ComboBox tplist;
        
        private Gtk.Label label2;
        
        private Gtk.HPaned hpaned2;
        
        private Gtk.ScrolledWindow GtkScrolledWindow2;
        
        private Gtk.TreeView physicaltreeview;
        
        private Gtk.Table table3;
        
        private Gtk.Label label11;
        
        private Gtk.Label label12;
        
        private Gtk.Button managephysicalconnections;
        
        private Gtk.Entry physicaltype;
        
        private Gtk.Entry physicalvalue;
        
        private Gtk.Label label5;
        
        private Gtk.Label label3;
        
        private Gtk.Label label4;
        
        private Gtk.Label GtkLabel12;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget OpenSASUI.APEditor
            Stetic.BinContainer.Attach(this);
            this.Name = "OpenSASUI.APEditor";
            // Container child OpenSASUI.APEditor.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.accesspointdetails = new Gtk.Expander(null);
            this.accesspointdetails.CanFocus = true;
            this.accesspointdetails.Name = "accesspointdetails";
            this.accesspointdetails.Expanded = true;
            // Container child accesspointdetails.Gtk.Container+ContainerChild
            this.table2 = new Gtk.Table(((uint)(4)), ((uint)(2)), false);
            this.table2.Name = "table2";
            this.table2.RowSpacing = ((uint)(6));
            this.table2.ColumnSpacing = ((uint)(6));
            // Container child table2.Gtk.Table+TableChild
            this.accesspointdesc = new Gtk.Entry();
            this.accesspointdesc.CanFocus = true;
            this.accesspointdesc.Name = "accesspointdesc";
            this.accesspointdesc.IsEditable = true;
            this.accesspointdesc.InvisibleChar = '●';
            this.table2.Add(this.accesspointdesc);
            Gtk.Table.TableChild w1 = ((Gtk.Table.TableChild)(this.table2[this.accesspointdesc]));
            w1.TopAttach = ((uint)(1));
            w1.BottomAttach = ((uint)(2));
            w1.LeftAttach = ((uint)(1));
            w1.RightAttach = ((uint)(2));
            w1.XOptions = ((Gtk.AttachOptions)(4));
            w1.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.accesspointisclock = new Gtk.CheckButton();
            this.accesspointisclock.TooltipMarkup = "Is a Clock? <FIXME>";
            this.accesspointisclock.CanFocus = true;
            this.accesspointisclock.Name = "accesspointisclock";
            this.accesspointisclock.Label = Mono.Unix.Catalog.GetString("Is Clock");
            this.accesspointisclock.DrawIndicator = true;
            this.accesspointisclock.UseUnderline = true;
            this.table2.Add(this.accesspointisclock);
            Gtk.Table.TableChild w2 = ((Gtk.Table.TableChild)(this.table2[this.accesspointisclock]));
            w2.TopAttach = ((uint)(2));
            w2.BottomAttach = ((uint)(3));
            w2.LeftAttach = ((uint)(1));
            w2.RightAttach = ((uint)(2));
            w2.XOptions = ((Gtk.AttachOptions)(4));
            w2.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.accesspointisrouter = new Gtk.CheckButton();
            this.accesspointisrouter.CanFocus = true;
            this.accesspointisrouter.Name = "accesspointisrouter";
            this.accesspointisrouter.Label = Mono.Unix.Catalog.GetString("Is Router");
            this.accesspointisrouter.DrawIndicator = true;
            this.accesspointisrouter.UseUnderline = true;
            this.table2.Add(this.accesspointisrouter);
            Gtk.Table.TableChild w3 = ((Gtk.Table.TableChild)(this.table2[this.accesspointisrouter]));
            w3.TopAttach = ((uint)(2));
            w3.BottomAttach = ((uint)(3));
            w3.XOptions = ((Gtk.AttachOptions)(4));
            w3.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.accesspointname = new Gtk.Entry();
            this.accesspointname.CanFocus = true;
            this.accesspointname.Name = "accesspointname";
            this.accesspointname.IsEditable = true;
            this.accesspointname.InvisibleChar = '●';
            this.table2.Add(this.accesspointname);
            Gtk.Table.TableChild w4 = ((Gtk.Table.TableChild)(this.table2[this.accesspointname]));
            w4.LeftAttach = ((uint)(1));
            w4.RightAttach = ((uint)(2));
            w4.XOptions = ((Gtk.AttachOptions)(4));
            w4.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.aplndetails = new Gtk.Expander(null);
            this.aplndetails.CanFocus = true;
            this.aplndetails.Name = "aplndetails";
            this.aplndetails.Expanded = true;
            // Container child aplndetails.Gtk.Container+ContainerChild
            this.hbox3 = new Gtk.HBox();
            this.hbox3.Name = "hbox3";
            this.hbox3.Spacing = 6;
            // Container child hbox3.Gtk.Box+BoxChild
            this.GtkScrolledWindow1 = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
            this.GtkScrolledWindow1.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
            this.aplntreeview = new Gtk.TreeView();
            this.aplntreeview.CanFocus = true;
            this.aplntreeview.Name = "aplntreeview";
            this.GtkScrolledWindow1.Add(this.aplntreeview);
            this.hbox3.Add(this.GtkScrolledWindow1);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.hbox3[this.GtkScrolledWindow1]));
            w6.Position = 0;
            // Container child hbox3.Gtk.Box+BoxChild
            this.vbox2 = new Gtk.VBox();
            this.vbox2.Name = "vbox2";
            this.vbox2.Spacing = 6;
            // Container child vbox2.Gtk.Box+BoxChild
            this.addapln = new Gtk.Button();
            this.addapln.CanFocus = true;
            this.addapln.Name = "addapln";
            this.addapln.UseStock = true;
            this.addapln.UseUnderline = true;
            this.addapln.Label = "gtk-add";
            this.vbox2.Add(this.addapln);
            Gtk.Box.BoxChild w7 = ((Gtk.Box.BoxChild)(this.vbox2[this.addapln]));
            w7.Position = 0;
            w7.Expand = false;
            w7.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.removeapln = new Gtk.Button();
            this.removeapln.CanFocus = true;
            this.removeapln.Name = "removeapln";
            this.removeapln.UseStock = true;
            this.removeapln.UseUnderline = true;
            this.removeapln.Label = "gtk-remove";
            this.vbox2.Add(this.removeapln);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox2[this.removeapln]));
            w8.Position = 1;
            w8.Expand = false;
            w8.Fill = false;
            // Container child vbox2.Gtk.Box+BoxChild
            this.propertiesapln = new Gtk.Button();
            this.propertiesapln.CanFocus = true;
            this.propertiesapln.Name = "propertiesapln";
            this.propertiesapln.UseStock = true;
            this.propertiesapln.UseUnderline = true;
            this.propertiesapln.Label = "gtk-properties";
            this.vbox2.Add(this.propertiesapln);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.vbox2[this.propertiesapln]));
            w9.Position = 2;
            w9.Expand = false;
            w9.Fill = false;
            this.hbox3.Add(this.vbox2);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.hbox3[this.vbox2]));
            w10.Position = 1;
            w10.Expand = false;
            w10.Fill = false;
            this.aplndetails.Add(this.hbox3);
            this.GtkLabel3 = new Gtk.Label();
            this.GtkLabel3.Name = "GtkLabel3";
            this.GtkLabel3.LabelProp = Mono.Unix.Catalog.GetString("Logical Nodes in AP");
            this.GtkLabel3.UseUnderline = true;
            this.aplndetails.LabelWidget = this.GtkLabel3;
            this.table2.Add(this.aplndetails);
            Gtk.Table.TableChild w12 = ((Gtk.Table.TableChild)(this.table2[this.aplndetails]));
            w12.TopAttach = ((uint)(3));
            w12.BottomAttach = ((uint)(4));
            w12.RightAttach = ((uint)(2));
            // Container child table2.Gtk.Table+TableChild
            this.label8 = new Gtk.Label();
            this.label8.Name = "label8";
            this.label8.LabelProp = Mono.Unix.Catalog.GetString("Name:");
            this.table2.Add(this.label8);
            Gtk.Table.TableChild w13 = ((Gtk.Table.TableChild)(this.table2[this.label8]));
            w13.XOptions = ((Gtk.AttachOptions)(4));
            w13.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table2.Gtk.Table+TableChild
            this.label9 = new Gtk.Label();
            this.label9.Name = "label9";
            this.label9.LabelProp = Mono.Unix.Catalog.GetString("Description:");
            this.table2.Add(this.label9);
            Gtk.Table.TableChild w14 = ((Gtk.Table.TableChild)(this.table2[this.label9]));
            w14.TopAttach = ((uint)(1));
            w14.BottomAttach = ((uint)(2));
            w14.XOptions = ((Gtk.AttachOptions)(4));
            w14.YOptions = ((Gtk.AttachOptions)(4));
            this.accesspointdetails.Add(this.table2);
            this.GtkLabel6 = new Gtk.Label();
            this.GtkLabel6.Name = "GtkLabel6";
            this.GtkLabel6.LabelProp = Mono.Unix.Catalog.GetString("Access Point Details");
            this.GtkLabel6.UseUnderline = true;
            this.accesspointdetails.LabelWidget = this.GtkLabel6;
            this.vbox1.Add(this.accesspointdetails);
            Gtk.Box.BoxChild w16 = ((Gtk.Box.BoxChild)(this.vbox1[this.accesspointdetails]));
            w16.Position = 0;
            w16.Expand = false;
            w16.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hbox4 = new Gtk.HBox();
            this.hbox4.Name = "hbox4";
            this.hbox4.Spacing = 6;
            // Container child hbox4.Gtk.Box+BoxChild
            this.label10 = new Gtk.Label();
            this.label10.TooltipMarkup = "The Subnetwork name this Access Point is Connected to";
            this.label10.Name = "label10";
            this.label10.LabelProp = Mono.Unix.Catalog.GetString("Subnetwork:");
            this.hbox4.Add(this.label10);
            Gtk.Box.BoxChild w17 = ((Gtk.Box.BoxChild)(this.hbox4[this.label10]));
            w17.Position = 0;
            w17.Expand = false;
            w17.Fill = false;
            // Container child hbox4.Gtk.Box+BoxChild
            this.subnetworklist = Gtk.ComboBox.NewText();
            this.subnetworklist.Name = "subnetworklist";
            this.hbox4.Add(this.subnetworklist);
            Gtk.Box.BoxChild w18 = ((Gtk.Box.BoxChild)(this.hbox4[this.subnetworklist]));
            w18.Position = 1;
            w18.Expand = false;
            w18.Fill = false;
            // Container child hbox4.Gtk.Box+BoxChild
            this.propertiessubnet = new Gtk.Button();
            this.propertiessubnet.CanFocus = true;
            this.propertiessubnet.Name = "propertiessubnet";
            this.propertiessubnet.UseStock = true;
            this.propertiessubnet.UseUnderline = true;
            this.propertiessubnet.Label = "gtk-properties";
            this.hbox4.Add(this.propertiessubnet);
            Gtk.Box.BoxChild w19 = ((Gtk.Box.BoxChild)(this.hbox4[this.propertiessubnet]));
            w19.PackType = ((Gtk.PackType)(1));
            w19.Position = 2;
            w19.Expand = false;
            w19.Fill = false;
            // Container child hbox4.Gtk.Box+BoxChild
            this.connectsubnet = new Gtk.Button();
            this.connectsubnet.CanFocus = true;
            this.connectsubnet.Name = "connectsubnet";
            this.connectsubnet.UseStock = true;
            this.connectsubnet.UseUnderline = true;
            this.connectsubnet.Label = "gtk-connect";
            this.hbox4.Add(this.connectsubnet);
            Gtk.Box.BoxChild w20 = ((Gtk.Box.BoxChild)(this.hbox4[this.connectsubnet]));
            w20.PackType = ((Gtk.PackType)(1));
            w20.Position = 3;
            w20.Expand = false;
            w20.Fill = false;
            // Container child hbox4.Gtk.Box+BoxChild
            this.desconnectsubnet = new Gtk.Button();
            this.desconnectsubnet.CanFocus = true;
            this.desconnectsubnet.Name = "desconnectsubnet";
            this.desconnectsubnet.UseStock = true;
            this.desconnectsubnet.UseUnderline = true;
            this.desconnectsubnet.Label = "gtk-disconnect";
            this.hbox4.Add(this.desconnectsubnet);
            Gtk.Box.BoxChild w21 = ((Gtk.Box.BoxChild)(this.hbox4[this.desconnectsubnet]));
            w21.PackType = ((Gtk.PackType)(1));
            w21.Position = 4;
            w21.Expand = false;
            w21.Fill = false;
            this.vbox1.Add(this.hbox4);
            Gtk.Box.BoxChild w22 = ((Gtk.Box.BoxChild)(this.vbox1[this.hbox4]));
            w22.Position = 1;
            w22.Expand = false;
            w22.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.connectiondetails = new Gtk.Expander(null);
            this.connectiondetails.CanFocus = true;
            this.connectiondetails.Name = "connectiondetails";
            this.connectiondetails.Expanded = true;
            // Container child connectiondetails.Gtk.Container+ContainerChild
            this.notebook = new Gtk.Notebook();
            this.notebook.CanFocus = true;
            this.notebook.Name = "notebook";
            this.notebook.CurrentPage = 0;
            // Container child notebook.Gtk.Notebook+NotebookChild
            this.hpaned1 = new Gtk.HPaned();
            this.hpaned1.CanFocus = true;
            this.hpaned1.Name = "hpaned1";
            this.hpaned1.Position = 209;
            // Container child hpaned1.Gtk.Paned+PanedChild
            this.GtkScrolledWindow = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow.Name = "GtkScrolledWindow";
            this.GtkScrolledWindow.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow.Gtk.Container+ContainerChild
            this.addresstreeview = new Gtk.TreeView();
            this.addresstreeview.CanFocus = true;
            this.addresstreeview.Name = "addresstreeview";
            this.GtkScrolledWindow.Add(this.addresstreeview);
            this.hpaned1.Add(this.GtkScrolledWindow);
            Gtk.Paned.PanedChild w24 = ((Gtk.Paned.PanedChild)(this.hpaned1[this.GtkScrolledWindow]));
            w24.Resize = false;
            // Container child hpaned1.Gtk.Paned+PanedChild
            this.table1 = new Gtk.Table(((uint)(3)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            // Container child table1.Gtk.Table+TableChild
            this.addressvalue = new Gtk.Entry();
            this.addressvalue.CanFocus = true;
            this.addressvalue.Name = "addressvalue";
            this.addressvalue.IsEditable = true;
            this.addressvalue.InvisibleChar = '●';
            this.table1.Add(this.addressvalue);
            Gtk.Table.TableChild w25 = ((Gtk.Table.TableChild)(this.table1[this.addressvalue]));
            w25.TopAttach = ((uint)(1));
            w25.BottomAttach = ((uint)(2));
            w25.LeftAttach = ((uint)(1));
            w25.RightAttach = ((uint)(2));
            w25.XOptions = ((Gtk.AttachOptions)(0));
            w25.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label6 = new Gtk.Label();
            this.label6.Name = "label6";
            this.label6.LabelProp = Mono.Unix.Catalog.GetString("Type:");
            this.table1.Add(this.label6);
            Gtk.Table.TableChild w26 = ((Gtk.Table.TableChild)(this.table1[this.label6]));
            w26.XOptions = ((Gtk.AttachOptions)(4));
            w26.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label7 = new Gtk.Label();
            this.label7.Name = "label7";
            this.label7.LabelProp = Mono.Unix.Catalog.GetString("Value:");
            this.table1.Add(this.label7);
            Gtk.Table.TableChild w27 = ((Gtk.Table.TableChild)(this.table1[this.label7]));
            w27.TopAttach = ((uint)(1));
            w27.BottomAttach = ((uint)(2));
            w27.XOptions = ((Gtk.AttachOptions)(4));
            w27.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.manageaddress = new Gtk.Button();
            this.manageaddress.CanFocus = true;
            this.manageaddress.Name = "manageaddress";
            this.manageaddress.UseUnderline = true;
            // Container child manageaddress.Gtk.Container+ContainerChild
            Gtk.Alignment w28 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w29 = new Gtk.HBox();
            w29.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w30 = new Gtk.Image();
            w30.Pixbuf = Stetic.IconLoader.LoadIcon(this, "stock_navigator-references", Gtk.IconSize.Button, 16);
            w29.Add(w30);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w32 = new Gtk.Label();
            w32.LabelProp = Mono.Unix.Catalog.GetString("Manage System Addresses");
            w32.UseUnderline = true;
            w29.Add(w32);
            w28.Add(w29);
            this.manageaddress.Add(w28);
            this.table1.Add(this.manageaddress);
            Gtk.Table.TableChild w36 = ((Gtk.Table.TableChild)(this.table1[this.manageaddress]));
            w36.TopAttach = ((uint)(2));
            w36.BottomAttach = ((uint)(3));
            w36.RightAttach = ((uint)(2));
            w36.XOptions = ((Gtk.AttachOptions)(4));
            w36.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.tplist = Gtk.ComboBox.NewText();
            this.tplist.Name = "tplist";
            this.table1.Add(this.tplist);
            Gtk.Table.TableChild w37 = ((Gtk.Table.TableChild)(this.table1[this.tplist]));
            w37.LeftAttach = ((uint)(1));
            w37.RightAttach = ((uint)(2));
            w37.XOptions = ((Gtk.AttachOptions)(0));
            w37.YOptions = ((Gtk.AttachOptions)(4));
            this.hpaned1.Add(this.table1);
            this.notebook.Add(this.hpaned1);
            // Notebook tab
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Address");
            this.notebook.SetTabLabel(this.hpaned1, this.label2);
            this.label2.ShowAll();
            // Container child notebook.Gtk.Notebook+NotebookChild
            this.hpaned2 = new Gtk.HPaned();
            this.hpaned2.CanFocus = true;
            this.hpaned2.Name = "hpaned2";
            this.hpaned2.Position = 209;
            // Container child hpaned2.Gtk.Paned+PanedChild
            this.GtkScrolledWindow2 = new Gtk.ScrolledWindow();
            this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
            this.GtkScrolledWindow2.ShadowType = ((Gtk.ShadowType)(1));
            // Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
            this.physicaltreeview = new Gtk.TreeView();
            this.physicaltreeview.CanFocus = true;
            this.physicaltreeview.Name = "physicaltreeview";
            this.GtkScrolledWindow2.Add(this.physicaltreeview);
            this.hpaned2.Add(this.GtkScrolledWindow2);
            Gtk.Paned.PanedChild w41 = ((Gtk.Paned.PanedChild)(this.hpaned2[this.GtkScrolledWindow2]));
            w41.Resize = false;
            // Container child hpaned2.Gtk.Paned+PanedChild
            this.table3 = new Gtk.Table(((uint)(3)), ((uint)(2)), false);
            this.table3.Name = "table3";
            this.table3.RowSpacing = ((uint)(6));
            this.table3.ColumnSpacing = ((uint)(6));
            // Container child table3.Gtk.Table+TableChild
            this.label11 = new Gtk.Label();
            this.label11.Name = "label11";
            this.label11.LabelProp = Mono.Unix.Catalog.GetString("Value:");
            this.table3.Add(this.label11);
            Gtk.Table.TableChild w42 = ((Gtk.Table.TableChild)(this.table3[this.label11]));
            w42.TopAttach = ((uint)(1));
            w42.BottomAttach = ((uint)(2));
            w42.XOptions = ((Gtk.AttachOptions)(4));
            w42.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table3.Gtk.Table+TableChild
            this.label12 = new Gtk.Label();
            this.label12.Name = "label12";
            this.label12.LabelProp = Mono.Unix.Catalog.GetString("Type:");
            this.table3.Add(this.label12);
            Gtk.Table.TableChild w43 = ((Gtk.Table.TableChild)(this.table3[this.label12]));
            w43.XOptions = ((Gtk.AttachOptions)(4));
            w43.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table3.Gtk.Table+TableChild
            this.managephysicalconnections = new Gtk.Button();
            this.managephysicalconnections.CanFocus = true;
            this.managephysicalconnections.Name = "managephysicalconnections";
            this.managephysicalconnections.UseUnderline = true;
            // Container child managephysicalconnections.Gtk.Container+ContainerChild
            Gtk.Alignment w44 = new Gtk.Alignment(0.5F, 0.5F, 0F, 0F);
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            Gtk.HBox w45 = new Gtk.HBox();
            w45.Spacing = 2;
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Image w46 = new Gtk.Image();
            w46.Pixbuf = Stetic.IconLoader.LoadIcon(this, "stock_navigator-references", Gtk.IconSize.Button, 16);
            w45.Add(w46);
            // Container child GtkHBox.Gtk.Container+ContainerChild
            Gtk.Label w48 = new Gtk.Label();
            w48.LabelProp = Mono.Unix.Catalog.GetString("Manage System Physical Connections");
            w48.UseUnderline = true;
            w45.Add(w48);
            w44.Add(w45);
            this.managephysicalconnections.Add(w44);
            this.table3.Add(this.managephysicalconnections);
            Gtk.Table.TableChild w52 = ((Gtk.Table.TableChild)(this.table3[this.managephysicalconnections]));
            w52.TopAttach = ((uint)(2));
            w52.BottomAttach = ((uint)(3));
            w52.RightAttach = ((uint)(2));
            w52.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table3.Gtk.Table+TableChild
            this.physicaltype = new Gtk.Entry();
            this.physicaltype.CanFocus = true;
            this.physicaltype.Name = "physicaltype";
            this.physicaltype.IsEditable = true;
            this.physicaltype.InvisibleChar = '●';
            this.table3.Add(this.physicaltype);
            Gtk.Table.TableChild w53 = ((Gtk.Table.TableChild)(this.table3[this.physicaltype]));
            w53.LeftAttach = ((uint)(1));
            w53.RightAttach = ((uint)(2));
            w53.XOptions = ((Gtk.AttachOptions)(4));
            w53.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table3.Gtk.Table+TableChild
            this.physicalvalue = new Gtk.Entry();
            this.physicalvalue.CanFocus = true;
            this.physicalvalue.Name = "physicalvalue";
            this.physicalvalue.IsEditable = true;
            this.physicalvalue.InvisibleChar = '●';
            this.table3.Add(this.physicalvalue);
            Gtk.Table.TableChild w54 = ((Gtk.Table.TableChild)(this.table3[this.physicalvalue]));
            w54.TopAttach = ((uint)(1));
            w54.BottomAttach = ((uint)(2));
            w54.LeftAttach = ((uint)(1));
            w54.RightAttach = ((uint)(2));
            w54.XOptions = ((Gtk.AttachOptions)(4));
            w54.YOptions = ((Gtk.AttachOptions)(4));
            this.hpaned2.Add(this.table3);
            this.notebook.Add(this.hpaned2);
            Gtk.Notebook.NotebookChild w56 = ((Gtk.Notebook.NotebookChild)(this.notebook[this.hpaned2]));
            w56.Position = 1;
            // Notebook tab
            this.label5 = new Gtk.Label();
            this.label5.Name = "label5";
            this.label5.LabelProp = Mono.Unix.Catalog.GetString("Physical");
            this.notebook.SetTabLabel(this.hpaned2, this.label5);
            this.label5.ShowAll();
            // Notebook tab
            Gtk.Label w57 = new Gtk.Label();
            w57.Visible = true;
            this.notebook.Add(w57);
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("GSE");
            this.notebook.SetTabLabel(w57, this.label3);
            this.label3.ShowAll();
            // Notebook tab
            Gtk.Label w58 = new Gtk.Label();
            w58.Visible = true;
            this.notebook.Add(w58);
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("SMV");
            this.notebook.SetTabLabel(w58, this.label4);
            this.label4.ShowAll();
            this.connectiondetails.Add(this.notebook);
            this.GtkLabel12 = new Gtk.Label();
            this.GtkLabel12.Name = "GtkLabel12";
            this.GtkLabel12.LabelProp = Mono.Unix.Catalog.GetString("Connection Details");
            this.GtkLabel12.UseUnderline = true;
            this.connectiondetails.LabelWidget = this.GtkLabel12;
            this.vbox1.Add(this.connectiondetails);
            Gtk.Box.BoxChild w60 = ((Gtk.Box.BoxChild)(this.vbox1[this.connectiondetails]));
            w60.Position = 2;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Hide();
        }
    }
}