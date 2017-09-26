<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.cd1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lineCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveProjectAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PublishToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ElementsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ButtonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RadioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckboxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBoxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LibraryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ButtonToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RadioToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckboxToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextboxToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SyntaxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HTMLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CSSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JavaScriptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PHPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BrowseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KryptonSplitContainer1 = New ComponentFactory.Krypton.Toolkit.KryptonSplitContainer()
        Me.TreeView1 = New ComponentFactory.Krypton.Toolkit.KryptonTreeView()
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.KryptonNavigator1 = New ComponentFactory.Krypton.Navigator.KryptonNavigator()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonSplitContainer1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer1.Panel1.SuspendLayout()
        CType(Me.KryptonSplitContainer1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonSplitContainer1.Panel2.SuspendLayout()
        Me.KryptonSplitContainer1.SuspendLayout()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.KryptonNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonNavigator1.SuspendLayout()
        Me.SuspendLayout()
        '
        'KryptonManager1
        '
        Me.KryptonManager1.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lineCount})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 443)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(701, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(80, 17)
        Me.ToolStripStatusLabel1.Text = "JavaScript File"
        '
        'lineCount
        '
        Me.lineCount.Name = "lineCount"
        Me.lineCount.Size = New System.Drawing.Size(0, 17)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.SearchToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ElementsToolStripMenuItem, Me.LibraryToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.WindowToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(701, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewProjectToolStripMenuItem, Me.NewFileToolStripMenuItem, Me.ToolStripSeparator1, Me.OpenProjectToolStripMenuItem, Me.OpenFileToolStripMenuItem, Me.ToolStripSeparator2, Me.SaveProjectToolStripMenuItem, Me.SaveFileToolStripMenuItem, Me.SaveProjectAsToolStripMenuItem, Me.SaveFileAsToolStripMenuItem, Me.ToolStripSeparator3, Me.PublishToolStripMenuItem, Me.ExportToolStripMenuItem, Me.ToolStripSeparator4, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewProjectToolStripMenuItem
        '
        Me.NewProjectToolStripMenuItem.Name = "NewProjectToolStripMenuItem"
        Me.NewProjectToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewProjectToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.NewProjectToolStripMenuItem.Text = "New Project"
        '
        'NewFileToolStripMenuItem
        '
        Me.NewFileToolStripMenuItem.Name = "NewFileToolStripMenuItem"
        Me.NewFileToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.NewFileToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.NewFileToolStripMenuItem.Text = "New File"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(207, 6)
        '
        'OpenProjectToolStripMenuItem
        '
        Me.OpenProjectToolStripMenuItem.Name = "OpenProjectToolStripMenuItem"
        Me.OpenProjectToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenProjectToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.OpenProjectToolStripMenuItem.Text = "Open Project"
        '
        'OpenFileToolStripMenuItem
        '
        Me.OpenFileToolStripMenuItem.Name = "OpenFileToolStripMenuItem"
        Me.OpenFileToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenFileToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.OpenFileToolStripMenuItem.Text = "Open File"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(207, 6)
        '
        'SaveProjectToolStripMenuItem
        '
        Me.SaveProjectToolStripMenuItem.Name = "SaveProjectToolStripMenuItem"
        Me.SaveProjectToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveProjectToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.SaveProjectToolStripMenuItem.Text = "Save Project"
        '
        'SaveFileToolStripMenuItem
        '
        Me.SaveFileToolStripMenuItem.Name = "SaveFileToolStripMenuItem"
        Me.SaveFileToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveFileToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.SaveFileToolStripMenuItem.Text = "Save File"
        '
        'SaveProjectAsToolStripMenuItem
        '
        Me.SaveProjectAsToolStripMenuItem.Name = "SaveProjectAsToolStripMenuItem"
        Me.SaveProjectAsToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.SaveProjectAsToolStripMenuItem.Text = "Save Project As"
        '
        'SaveFileAsToolStripMenuItem
        '
        Me.SaveFileAsToolStripMenuItem.Name = "SaveFileAsToolStripMenuItem"
        Me.SaveFileAsToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.SaveFileAsToolStripMenuItem.Text = "Save File As"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(207, 6)
        '
        'PublishToolStripMenuItem
        '
        Me.PublishToolStripMenuItem.Name = "PublishToolStripMenuItem"
        Me.PublishToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PublishToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.PublishToolStripMenuItem.Text = "Publish"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(207, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.SearchToolStripMenuItem.Text = "Search"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'ElementsToolStripMenuItem
        '
        Me.ElementsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonToolStripMenuItem, Me.RadioToolStripMenuItem, Me.CheckboxToolStripMenuItem, Me.TextBoxToolStripMenuItem})
        Me.ElementsToolStripMenuItem.Name = "ElementsToolStripMenuItem"
        Me.ElementsToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.ElementsToolStripMenuItem.Text = "Elements"
        '
        'ButtonToolStripMenuItem
        '
        Me.ButtonToolStripMenuItem.Name = "ButtonToolStripMenuItem"
        Me.ButtonToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ButtonToolStripMenuItem.Text = "Button"
        '
        'RadioToolStripMenuItem
        '
        Me.RadioToolStripMenuItem.Name = "RadioToolStripMenuItem"
        Me.RadioToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.RadioToolStripMenuItem.Text = "Radio"
        '
        'CheckboxToolStripMenuItem
        '
        Me.CheckboxToolStripMenuItem.Name = "CheckboxToolStripMenuItem"
        Me.CheckboxToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.CheckboxToolStripMenuItem.Text = "Checkbox"
        '
        'TextBoxToolStripMenuItem
        '
        Me.TextBoxToolStripMenuItem.Name = "TextBoxToolStripMenuItem"
        Me.TextBoxToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.TextBoxToolStripMenuItem.Text = "TextBox"
        '
        'LibraryToolStripMenuItem
        '
        Me.LibraryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonToolStripMenuItem1, Me.RadioToolStripMenuItem1, Me.CheckboxToolStripMenuItem1, Me.TextboxToolStripMenuItem1})
        Me.LibraryToolStripMenuItem.Name = "LibraryToolStripMenuItem"
        Me.LibraryToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.LibraryToolStripMenuItem.Text = "Library"
        '
        'ButtonToolStripMenuItem1
        '
        Me.ButtonToolStripMenuItem1.Name = "ButtonToolStripMenuItem1"
        Me.ButtonToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.ButtonToolStripMenuItem1.Text = "Button"
        '
        'RadioToolStripMenuItem1
        '
        Me.RadioToolStripMenuItem1.Name = "RadioToolStripMenuItem1"
        Me.RadioToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.RadioToolStripMenuItem1.Text = "Radio"
        '
        'CheckboxToolStripMenuItem1
        '
        Me.CheckboxToolStripMenuItem1.Name = "CheckboxToolStripMenuItem1"
        Me.CheckboxToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.CheckboxToolStripMenuItem1.Text = "Checkbox"
        '
        'TextboxToolStripMenuItem1
        '
        Me.TextboxToolStripMenuItem1.Name = "TextboxToolStripMenuItem1"
        Me.TextboxToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.TextboxToolStripMenuItem1.Text = "Textbox"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SyntaxToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'SyntaxToolStripMenuItem
        '
        Me.SyntaxToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HTMLToolStripMenuItem, Me.CSSToolStripMenuItem, Me.JavaScriptToolStripMenuItem, Me.PHPToolStripMenuItem, Me.CToolStripMenuItem, Me.CToolStripMenuItem1, Me.CToolStripMenuItem2, Me.VBToolStripMenuItem})
        Me.SyntaxToolStripMenuItem.Name = "SyntaxToolStripMenuItem"
        Me.SyntaxToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.SyntaxToolStripMenuItem.Text = "Syntax"
        '
        'HTMLToolStripMenuItem
        '
        Me.HTMLToolStripMenuItem.Name = "HTMLToolStripMenuItem"
        Me.HTMLToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.HTMLToolStripMenuItem.Text = "HTML"
        '
        'CSSToolStripMenuItem
        '
        Me.CSSToolStripMenuItem.Name = "CSSToolStripMenuItem"
        Me.CSSToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.CSSToolStripMenuItem.Text = "CSS"
        '
        'JavaScriptToolStripMenuItem
        '
        Me.JavaScriptToolStripMenuItem.Name = "JavaScriptToolStripMenuItem"
        Me.JavaScriptToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.JavaScriptToolStripMenuItem.Text = "JavaScript"
        '
        'PHPToolStripMenuItem
        '
        Me.PHPToolStripMenuItem.Name = "PHPToolStripMenuItem"
        Me.PHPToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.PHPToolStripMenuItem.Text = "PHP"
        '
        'CToolStripMenuItem
        '
        Me.CToolStripMenuItem.Name = "CToolStripMenuItem"
        Me.CToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.CToolStripMenuItem.Text = "C"
        '
        'CToolStripMenuItem1
        '
        Me.CToolStripMenuItem1.Name = "CToolStripMenuItem1"
        Me.CToolStripMenuItem1.Size = New System.Drawing.Size(126, 22)
        Me.CToolStripMenuItem1.Text = "C++"
        '
        'CToolStripMenuItem2
        '
        Me.CToolStripMenuItem2.Name = "CToolStripMenuItem2"
        Me.CToolStripMenuItem2.Size = New System.Drawing.Size(126, 22)
        Me.CToolStripMenuItem2.Text = "C#"
        '
        'VBToolStripMenuItem
        '
        Me.VBToolStripMenuItem.Name = "VBToolStripMenuItem"
        Me.VBToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.VBToolStripMenuItem.Text = "VB"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BrowseToolStripMenuItem})
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.WindowToolStripMenuItem.Text = "Window"
        '
        'BrowseToolStripMenuItem
        '
        Me.BrowseToolStripMenuItem.Name = "BrowseToolStripMenuItem"
        Me.BrowseToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.BrowseToolStripMenuItem.Text = "Browse"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'KryptonSplitContainer1
        '
        Me.KryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.KryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonSplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.KryptonSplitContainer1.Name = "KryptonSplitContainer1"
        Me.KryptonSplitContainer1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        '
        'KryptonSplitContainer1.Panel1
        '
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.TreeView1)
        Me.KryptonSplitContainer1.Panel1.Controls.Add(Me.KryptonPanel1)
        Me.KryptonSplitContainer1.Panel1MinSize = 100
        '
        'KryptonSplitContainer1.Panel2
        '
        Me.KryptonSplitContainer1.Panel2.Controls.Add(Me.KryptonNavigator1)
        Me.KryptonSplitContainer1.Panel2.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonSplitContainer1.Panel2MinSize = 75
        Me.KryptonSplitContainer1.Size = New System.Drawing.Size(701, 419)
        Me.KryptonSplitContainer1.SplitterDistance = 110
        Me.KryptonSplitContainer1.SplitterWidth = 3
        Me.KryptonSplitContainer1.TabIndex = 4
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(0, 28)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black
        Me.TreeView1.Size = New System.Drawing.Size(110, 391)
        Me.TreeView1.TabIndex = 1
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.Label2)
        Me.KryptonPanel1.Controls.Add(Me.Label1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver
        Me.KryptonPanel1.Size = New System.Drawing.Size(110, 28)
        Me.KryptonPanel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(59, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 28)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Add New"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(4, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Browse"
        '
        'KryptonNavigator1
        '
        Me.KryptonNavigator1.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.SlantEqualFar
        Me.KryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonNavigator1.Name = "KryptonNavigator1"
        Me.KryptonNavigator1.Size = New System.Drawing.Size(588, 419)
        Me.KryptonNavigator1.TabIndex = 0
        Me.KryptonNavigator1.Text = "KryptonNavigator1"
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 465)
        Me.Controls.Add(Me.KryptonSplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.Name = "main"
        Me.Text = "Codeo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.KryptonSplitContainer1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.KryptonSplitContainer1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.KryptonSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonSplitContainer1.ResumeLayout(False)
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.KryptonNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonNavigator1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents KryptonManager1 As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents cd1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lineCount As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KryptonSplitContainer1 As ComponentFactory.Krypton.Toolkit.KryptonSplitContainer
    Friend WithEvents TreeView1 As ComponentFactory.Krypton.Toolkit.KryptonTreeView
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents KryptonNavigator1 As ComponentFactory.Krypton.Navigator.KryptonNavigator
    Friend WithEvents SyntaxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HTMLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CSSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JavaScriptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PHPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VBToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BrowseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveProjectAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PublishToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ElementsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButtonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RadioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckboxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBoxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LibraryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButtonToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RadioToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckboxToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextboxToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem

End Class
