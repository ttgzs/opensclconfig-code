// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------



public partial class MainWindow {
    
    private Gtk.UIManager UIManager;
    
    private Gtk.Action FileAction;
    
    private Gtk.Action openAction;
    
    private Gtk.Action saveAction;
    
    private Gtk.Action saveAsAction;
    
    private Gtk.Action quitAction;
    
    private Gtk.Action newAction;
    
    private Gtk.Action AboutAction;
    
    private Gtk.Action aboutAction;
    
    private Gtk.Action newAction1;
    
    private Gtk.Action Action;
    
    private Gtk.Action FileAction1;
    
    private Gtk.Action newAction2;
    
    private Gtk.Action openAction1;
    
    private Gtk.Action saveAction1;
    
    private Gtk.Action saveAsAction1;
    
    private Gtk.Action quitAction1;
    
    private Gtk.Action AboutAction1;
    
    private Gtk.Action aboutAction1;
    
    private Gtk.Action FileAction2;
    
    private Gtk.Action newAction3;
    
    private Gtk.Action openAction2;
    
    private Gtk.Action saveAction2;
    
    private Gtk.Action saveAsAction2;
    
    private Gtk.Action quitAction2;
    
    private Gtk.Action AboutAction2;
    
    private Gtk.Action aboutAction2;
    
    private Gtk.VBox vbox1;
    
    private Gtk.MenuBar menubar1;
    
    private Gtk.Notebook notebook1;
    
    private OpenSASUI.SclEditor scleditor1;
    
    private Gtk.Label TreeView;
    
    private Gtk.Label ConsoleView;
    
    private Gtk.Statusbar statusbar1;
    
    protected virtual void Build() {
        Stetic.Gui.Initialize(this);
        // Widget MainWindow
        this.UIManager = new Gtk.UIManager();
        Gtk.ActionGroup w1 = new Gtk.ActionGroup("Default");
        this.FileAction = new Gtk.Action("FileAction", Mono.Unix.Catalog.GetString("_File"), null, null);
        this.FileAction.ShortLabel = Mono.Unix.Catalog.GetString("_File");
        w1.Add(this.FileAction, null);
        this.openAction = new Gtk.Action("openAction", Mono.Unix.Catalog.GetString("_Abrir"), null, "gtk-open");
        this.openAction.ShortLabel = Mono.Unix.Catalog.GetString("_Abrir");
        w1.Add(this.openAction, null);
        this.saveAction = new Gtk.Action("saveAction", Mono.Unix.Catalog.GetString("_Guardar"), null, "gtk-save");
        this.saveAction.ShortLabel = Mono.Unix.Catalog.GetString("_Guardar");
        w1.Add(this.saveAction, null);
        this.saveAsAction = new Gtk.Action("saveAsAction", Mono.Unix.Catalog.GetString("Guardar _como"), null, "gtk-save-as");
        this.saveAsAction.ShortLabel = Mono.Unix.Catalog.GetString("Guardar _como");
        w1.Add(this.saveAsAction, null);
        this.quitAction = new Gtk.Action("quitAction", Mono.Unix.Catalog.GetString("_Salir"), null, "gtk-quit");
        this.quitAction.ShortLabel = Mono.Unix.Catalog.GetString("_Salir");
        w1.Add(this.quitAction, null);
        this.newAction = new Gtk.Action("newAction", Mono.Unix.Catalog.GetString("_Nuevo"), null, "gtk-new");
        this.newAction.ShortLabel = Mono.Unix.Catalog.GetString("_Nuevo");
        w1.Add(this.newAction, null);
        this.AboutAction = new Gtk.Action("AboutAction", Mono.Unix.Catalog.GetString("_About"), null, null);
        this.AboutAction.ShortLabel = Mono.Unix.Catalog.GetString("_About");
        w1.Add(this.AboutAction, null);
        this.aboutAction = new Gtk.Action("aboutAction", Mono.Unix.Catalog.GetString("Acerca _de"), null, "gtk-about");
        this.aboutAction.ShortLabel = Mono.Unix.Catalog.GetString("Acerca _de");
        w1.Add(this.aboutAction, null);
        this.newAction1 = new Gtk.Action("newAction1", Mono.Unix.Catalog.GetString("_Nuevo"), null, "gtk-new");
        this.newAction1.ShortLabel = Mono.Unix.Catalog.GetString("_Nuevo");
        w1.Add(this.newAction1, null);
        this.Action = new Gtk.Action("Action", null, null, null);
        w1.Add(this.Action, null);
        this.FileAction1 = new Gtk.Action("FileAction1", Mono.Unix.Catalog.GetString("_File"), null, null);
        this.FileAction1.ShortLabel = Mono.Unix.Catalog.GetString("_File");
        w1.Add(this.FileAction1, null);
        this.newAction2 = new Gtk.Action("newAction2", Mono.Unix.Catalog.GetString("_Nuevo"), null, "gtk-new");
        this.newAction2.ShortLabel = Mono.Unix.Catalog.GetString("_Nuevo");
        w1.Add(this.newAction2, null);
        this.openAction1 = new Gtk.Action("openAction1", Mono.Unix.Catalog.GetString("_Abrir"), null, "gtk-open");
        this.openAction1.ShortLabel = Mono.Unix.Catalog.GetString("_Abrir");
        w1.Add(this.openAction1, null);
        this.saveAction1 = new Gtk.Action("saveAction1", Mono.Unix.Catalog.GetString("_Guardar"), null, "gtk-save");
        this.saveAction1.ShortLabel = Mono.Unix.Catalog.GetString("_Guardar");
        w1.Add(this.saveAction1, null);
        this.saveAsAction1 = new Gtk.Action("saveAsAction1", Mono.Unix.Catalog.GetString("Guardar _como"), null, "gtk-save-as");
        this.saveAsAction1.ShortLabel = Mono.Unix.Catalog.GetString("Guardar _como");
        w1.Add(this.saveAsAction1, null);
        this.quitAction1 = new Gtk.Action("quitAction1", Mono.Unix.Catalog.GetString("_Salir"), null, "gtk-quit");
        this.quitAction1.ShortLabel = Mono.Unix.Catalog.GetString("_Salir");
        w1.Add(this.quitAction1, null);
        this.AboutAction1 = new Gtk.Action("AboutAction1", Mono.Unix.Catalog.GetString("_About"), null, null);
        this.AboutAction1.ShortLabel = Mono.Unix.Catalog.GetString("_About");
        w1.Add(this.AboutAction1, null);
        this.aboutAction1 = new Gtk.Action("aboutAction1", Mono.Unix.Catalog.GetString("Acerca _de"), null, "gtk-about");
        this.aboutAction1.ShortLabel = Mono.Unix.Catalog.GetString("Acerca _de");
        w1.Add(this.aboutAction1, null);
        this.FileAction2 = new Gtk.Action("FileAction2", Mono.Unix.Catalog.GetString("_File"), null, null);
        this.FileAction2.ShortLabel = Mono.Unix.Catalog.GetString("_File");
        w1.Add(this.FileAction2, null);
        this.newAction3 = new Gtk.Action("newAction3", Mono.Unix.Catalog.GetString("_Nuevo"), null, "gtk-new");
        this.newAction3.ShortLabel = Mono.Unix.Catalog.GetString("_Nuevo");
        w1.Add(this.newAction3, null);
        this.openAction2 = new Gtk.Action("openAction2", Mono.Unix.Catalog.GetString("_Abrir"), null, "gtk-open");
        this.openAction2.ShortLabel = Mono.Unix.Catalog.GetString("_Abrir");
        w1.Add(this.openAction2, null);
        this.saveAction2 = new Gtk.Action("saveAction2", Mono.Unix.Catalog.GetString("_Guardar"), null, "gtk-save");
        this.saveAction2.ShortLabel = Mono.Unix.Catalog.GetString("_Guardar");
        w1.Add(this.saveAction2, null);
        this.saveAsAction2 = new Gtk.Action("saveAsAction2", Mono.Unix.Catalog.GetString("Guardar _como"), null, "gtk-save-as");
        this.saveAsAction2.ShortLabel = Mono.Unix.Catalog.GetString("Guardar _como");
        w1.Add(this.saveAsAction2, null);
        this.quitAction2 = new Gtk.Action("quitAction2", Mono.Unix.Catalog.GetString("_Salir"), null, "gtk-quit");
        this.quitAction2.ShortLabel = Mono.Unix.Catalog.GetString("_Salir");
        w1.Add(this.quitAction2, null);
        this.AboutAction2 = new Gtk.Action("AboutAction2", Mono.Unix.Catalog.GetString("_About"), null, null);
        this.AboutAction2.ShortLabel = Mono.Unix.Catalog.GetString("_About");
        w1.Add(this.AboutAction2, null);
        this.aboutAction2 = new Gtk.Action("aboutAction2", Mono.Unix.Catalog.GetString("Acerca _de"), null, "gtk-about");
        this.aboutAction2.ShortLabel = Mono.Unix.Catalog.GetString("Acerca _de");
        w1.Add(this.aboutAction2, null);
        this.UIManager.InsertActionGroup(w1, 0);
        this.AddAccelGroup(this.UIManager.AccelGroup);
        this.Name = "MainWindow";
        this.Title = Mono.Unix.Catalog.GetString("OpenSASConfigurator");
        this.Icon = Gdk.Pixbuf.LoadFromResource("OpenSASConfigurator.OpenSASConfigurator-64x62.png");
        this.WindowPosition = ((Gtk.WindowPosition)(4));
        // Container child MainWindow.Gtk.Container+ContainerChild
        this.vbox1 = new Gtk.VBox();
        this.vbox1.Name = "vbox1";
        this.vbox1.Spacing = 6;
        // Container child vbox1.Gtk.Box+BoxChild
        this.UIManager.AddUiFromString("<ui><menubar name='menubar1'><menu name='FileAction2' action='FileAction2'><menuitem name='newAction3' action='newAction3'/><menuitem name='openAction2' action='openAction2'/><menuitem name='saveAction2' action='saveAction2'/><menuitem name='saveAsAction2' action='saveAsAction2'/><separator/><menuitem name='quitAction2' action='quitAction2'/></menu><menu name='AboutAction2' action='AboutAction2'><menuitem name='aboutAction2' action='aboutAction2'/></menu></menubar></ui>");
        this.menubar1 = ((Gtk.MenuBar)(this.UIManager.GetWidget("/menubar1")));
        this.menubar1.Name = "menubar1";
        this.vbox1.Add(this.menubar1);
        Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.vbox1[this.menubar1]));
        w2.Position = 0;
        w2.Expand = false;
        w2.Fill = false;
        // Container child vbox1.Gtk.Box+BoxChild
        this.notebook1 = new Gtk.Notebook();
        this.notebook1.CanFocus = true;
        this.notebook1.Name = "notebook1";
        this.notebook1.CurrentPage = 0;
        // Container child notebook1.Gtk.Notebook+NotebookChild
        this.scleditor1 = new OpenSASUI.SclEditor();
        this.scleditor1.Events = ((Gdk.EventMask)(256));
        this.scleditor1.Name = "scleditor1";
        this.notebook1.Add(this.scleditor1);
        // Notebook tab
        this.TreeView = new Gtk.Label();
        this.TreeView.Name = "TreeView";
        this.TreeView.LabelProp = Mono.Unix.Catalog.GetString("Tree View");
        this.notebook1.SetTabLabel(this.scleditor1, this.TreeView);
        this.TreeView.ShowAll();
        // Notebook tab
        Gtk.Label w4 = new Gtk.Label();
        w4.Visible = true;
        this.notebook1.Add(w4);
        this.ConsoleView = new Gtk.Label();
        this.ConsoleView.Name = "ConsoleView";
        this.ConsoleView.LabelProp = Mono.Unix.Catalog.GetString("ConsoleView");
        this.notebook1.SetTabLabel(w4, this.ConsoleView);
        this.ConsoleView.ShowAll();
        this.vbox1.Add(this.notebook1);
        Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox1[this.notebook1]));
        w5.Position = 1;
        // Container child vbox1.Gtk.Box+BoxChild
        this.statusbar1 = new Gtk.Statusbar();
        this.statusbar1.Name = "statusbar1";
        this.statusbar1.Spacing = 6;
        this.vbox1.Add(this.statusbar1);
        Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.vbox1[this.statusbar1]));
        w6.Position = 2;
        w6.Expand = false;
        w6.Fill = false;
        this.Add(this.vbox1);
        if ((this.Child != null)) {
            this.Child.ShowAll();
        }
        this.DefaultWidth = 708;
        this.DefaultHeight = 834;
        this.Show();
        this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
        this.openAction.Activated += new System.EventHandler(this.OnOpen);
        this.newAction2.Activated += new System.EventHandler(this.OnNew);
        this.openAction1.Activated += new System.EventHandler(this.OnOpen);
        this.saveAction1.Activated += new System.EventHandler(this.OnSave);
        this.saveAsAction1.Activated += new System.EventHandler(this.OnSaveAs);
        this.quitAction1.Activated += new System.EventHandler(this.OnExit);
        this.aboutAction1.Activated += new System.EventHandler(this.OnAbout);
        this.newAction3.Activated += new System.EventHandler(this.OnNew);
        this.openAction2.Activated += new System.EventHandler(this.OnOpen);
        this.saveAction2.Activated += new System.EventHandler(this.OnSave);
        this.saveAsAction2.Activated += new System.EventHandler(this.OnSaveAs);
        this.quitAction2.Activated += new System.EventHandler(this.OnExit);
        this.aboutAction2.Activated += new System.EventHandler(this.OnAbout);
    }
}
