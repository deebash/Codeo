Option Explicit On
Imports System.Windows.Forms
Imports System.IO
Imports System.Web


Public Class main
    Dim newPgeCount = 0
    Dim newPageArr As New List(Of String)

    Private Sub main_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            openFile(path)
        Next
    End Sub

    Private Sub main_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub main_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim tabName = ""
        Dim tabPath = ""
        Dim tabCount = KryptonNavigator1.Pages.Count
        For i = 0 To tabCount - 1
            If i = tabCount - 1 Then
                tabName = tabName & KryptonNavigator1.Pages(i).Text
                tabPath = tabPath & KryptonNavigator1.Pages(i).Tag
            Else
                tabName = tabName & KryptonNavigator1.Pages(i).Text & "<codeo>"
                tabPath = tabPath & KryptonNavigator1.Pages(i).Tag & "<codeo>"
            End If
            If (isNew(KryptonNavigator1.Pages(i).Text)) Then
                Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.Pages(i).Controls(0)
                SaveSetting("Codeo", "TabData", KryptonNavigator1.Pages(i).Text, editor.Text)
            End If

        Next

        SaveSetting("Codeo", "LastTab", "TabName", tabName)
        SaveSetting("Codeo", "LastTab", "TabPath", tabPath)
        Dim browsePath = ""
        For i = 0 To TreeView1.Nodes.Count - 1
            If i = TreeView1.Nodes.Count - 1 Then
                browsePath = browsePath & TreeView1.Nodes(i).Tag
            Else
                browsePath = browsePath & TreeView1.Nodes(i).Tag & "<codeo>"
            End If

        Next
        SaveSetting("Codeo", "Browse", "BrowsePath", browsePath)
        SaveSetting("Codeo", "LastTab", "Index", KryptonNavigator1.SelectedIndex)
        SaveSetting("Codeo", "Browse", "status", BrowseToolStripMenuItem.Checked)
        End
    End Sub

    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim arguments As String() = System.Environment.GetCommandLineArgs()
        If arguments.Length > 1 Then
            'openFile(arguments(1))
        End If
        BrowseToolStripMenuItem.Checked = True
        Dim tabName = GetSetting("Codeo", "LastTab", "TabName", "")
        Dim tabPath = GetSetting("Codeo", "LastTab", "TabPath", "")
        Dim browsePath = GetSetting("Codeo", "Browse", "BrowsePath", "")
        Dim selIndex = GetSetting("Codeo", "LastTab", "Index", 0)
        Dim browseStatus = GetSetting("Codeo", "Browse", "status", True)
        showBrowse(browseStatus)

        Dim delim As String() = New String(0) {"<codeo>"}
        Dim tabNames As String() = tabName.Split(delim, StringSplitOptions.None)
        Dim tabPaths As String() = tabPath.Split(delim, StringSplitOptions.None)
        Dim browsePaths As String() = browsePath.Split(delim, StringSplitOptions.None)

        Dim tabCount = tabNames.Length
        For i = 0 To tabCount - 1
            If tabPaths(i).Length = 0 Then
                openNewFileHistory(tabNames(i))
            Else
                openFile(tabPaths(i))
            End If

        Next

        Dim projCount = browsePaths.Length
        For i = 0 To projCount - 1
            If browsePaths(i).Length = 0 Then
                'openNewFileHistory(tabNames(i))
            Else
                AddProject(browsePaths(i))
                ' MsgBox(browsePaths(i))
            End If

        Next
        KryptonNavigator1.SelectedIndex = selIndex
        Me.AllowDrop = True

        For Each argument As String In My.Application.CommandLineArgs

            openFile(argument.ToString)
        Next

    End Sub
    Private Sub AddProject(ByVal folderpath)
        If (folderpath.ToString.Length <> 0) Then
            Dim split As String() = folderpath.Split("\")
            Dim FolderName As String = split(split.Length - 1)
            Dim childNode As TreeNode = Nothing
            childNode = New TreeNode(FolderName)
            childNode.Tag = folderpath
            TreeView1.Nodes.Add(childNode)
            PopulateTreeView1(folderpath, childNode)
        End If
    End Sub

    Private Sub PopulateTreeView1(ByVal dir As String, ByVal parentNode As TreeNode)
        Dim folder As String = String.Empty
        Try
            Dim folders As String() = System.IO.Directory.GetDirectories(dir)
            If folders.Length <> 0 Then
                Dim childNode As TreeNode = Nothing
                For Each folder_loopVariable As String In folders
                    folder = folder_loopVariable
                    Dim split As String() = folder_loopVariable.Split("\")
                    Dim FolderName As String = split(split.Length - 1)
                    childNode = New TreeNode(FolderName)
                    childNode.Tag = folder
                    'childNode.ImageKey = CacheShellIcon(folder)
                    'childNode.SelectedImageKey = CacheShellIcon(folder)
                    'parentNode.Nodes.Add(childNode)
                    parentNode.Nodes.Add(childNode)
                    PopulateTreeView1(folder_loopVariable, childNode)
                Next
            End If
            Dim files As String() = System.IO.Directory.GetFiles(dir)
            If files.Length <> 0 Then
                Dim childNode As TreeNode = Nothing
                For Each file As String In files
                    childNode = New TreeNode(file)
                    Dim split As String() = file.Split("\")
                    Dim fileName As String = split(split.Length - 1)
                    childNode.Text = fileName
                    'childNode.ImageKey = CacheShellIcon(dir & "\" & fileName)
                    'childNode.SelectedImageKey = CacheShellIcon(dir & "\" & fileName)
                    childNode.Tag = dir & "\" & fileName
                    parentNode.Nodes.Add(childNode)

                Next
            End If
        Catch ex As UnauthorizedAccessException
            parentNode.Nodes.Add(folder & Convert.ToString(": Access Denied"))
        End Try
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs)

    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs)

    End Sub

    Private Sub openFile(ByVal file)
        If System.IO.File.Exists(file) Then
            If (isAlreadyOpened(file)) Then
            Else
                Dim page = New ComponentFactory.Krypton.Navigator.KryptonPage
                Dim txteditor = New ICSharpCode.TextEditor.TextEditorControl
                KryptonNavigator1.Pages.Add(page)
                Dim split As String() = file.Split("\")
                Dim fileName As String = split(split.Length - 1)
                page.Text = fileName
                page.Tag = file
                page.TextTitle = fileName
                page.Controls.Add(txteditor)
                txteditor.Dock = DockStyle.Fill

                AddHandler txteditor.TextChanged, AddressOf CommonHandler
                AddHandler txteditor.ActiveTextAreaControl.Caret.PositionChanged, AddressOf updateSatus
                AddHandler txteditor.ActiveTextAreaControl.SelectionManager.SelectionChanged, AddressOf highlightSameWord

                Try
                    txteditor.LoadFile(file)
                Catch e As Exception

                End Try
                txteditor.SetHighlighting("JavaScript")
                KryptonNavigator1.SelectedIndex = KryptonNavigator1.Pages.Count - 1
                Me.Text = KryptonNavigator1.SelectedPage.Tag & " - Codeo"
                setLanguage()
                AddWatcher(file)
                watchFiles()
            End If
        Else
            'the file doesn't exist
        End If

    End Sub


    Private Sub openNewFile()
        newPgeCount = getNewPageCount()
        newPageArr.Add(newPgeCount)
        Dim page = New ComponentFactory.Krypton.Navigator.KryptonPage
        Dim txteditor = New ICSharpCode.TextEditor.TextEditorControl
        KryptonNavigator1.Pages.Add(page)
        Dim filename = "New " & newPgeCount
        page.Text = filename
        page.TextTitle = filename
        page.Controls.Add(txteditor)
        txteditor.Dock = DockStyle.Fill
        AddHandler txteditor.TextChanged, AddressOf CommonHandler
        AddHandler txteditor.ActiveTextAreaControl.Caret.PositionChanged, AddressOf updateSatus
        AddHandler txteditor.ActiveTextAreaControl.SelectionManager.SelectionChanged, AddressOf highlightSameWord
        txteditor.SetHighlighting("txt")
        KryptonNavigator1.SelectedIndex = KryptonNavigator1.Pages.Count - 1
        KryptonNavigator1.SelectedPage.Tag = ""
        Me.Text = filename & " - Codeo"
    End Sub

    Private Sub openNewFileHistory(ByVal name)
        Dim page = New ComponentFactory.Krypton.Navigator.KryptonPage
        Dim txteditor = New ICSharpCode.TextEditor.TextEditorControl
        KryptonNavigator1.Pages.Add(page)
        Dim filename = name
        page.Text = filename
        page.TextTitle = filename
        newPageArr.Add(whichNew(filename))
        page.Controls.Add(txteditor)
        txteditor.Dock = DockStyle.Fill
        Dim tabName = GetSetting("Codeo", "TabData", filename, "")
        txteditor.Text = tabName
        AddHandler txteditor.TextChanged, AddressOf CommonHandler
        AddHandler txteditor.ActiveTextAreaControl.Caret.PositionChanged, AddressOf updateSatus
        AddHandler txteditor.ActiveTextAreaControl.SelectionManager.SelectionChanged, AddressOf highlightSameWord

        txteditor.SetHighlighting("txt")
        KryptonNavigator1.SelectedIndex = KryptonNavigator1.Pages.Count - 1
        KryptonNavigator1.SelectedPage.Tag = ""
        Me.Text = filename & " - Codeo"
    End Sub

    Private Sub KryptonGroupPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub Label2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.ShowNewFolderButton = True
        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            AddProject(folderDlg.SelectedPath)
            Dim root As Environment.SpecialFolder = folderDlg.RootFolder
        End If
    End Sub

    Private Sub TreeView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            If (TreeView1.SelectedNode.Level = 0) Then
                TreeView1.SelectedNode.Remove()
            End If
        End If
    End Sub


    Private Sub TreeView1_NodeMouseDoubleClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick

        openFile(TreeView1.SelectedNode.Tag)
    End Sub

    Private Sub KryptonNavigator1_CloseAction(ByVal sender As Object, ByVal e As ComponentFactory.Krypton.Navigator.CloseActionEventArgs) Handles KryptonNavigator1.CloseAction
        Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)

        If KryptonNavigator1.SelectedPage.Tag = "" Then
            If editor.Text.Length <> 0 Then
                saveFile("show")
            Else
                newPageArr.Remove(whichNew(KryptonNavigator1.SelectedPage.Text))
            End If
        Else
            saveFile(KryptonNavigator1.SelectedPage.Tag)
        End If
    End Sub

    Private Sub KryptonNavigator1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles KryptonNavigator1.MouseDoubleClick

    End Sub

    Private Sub KryptonNavigator1_SelectedPageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles KryptonNavigator1.SelectedPageChanged
        Try
            updateStar()
            updateSatus(sender, e)
            Me.Text = KryptonNavigator1.SelectedPage.Tag & " - Codeo"
        Catch err As Exception
            Me.Text = KryptonNavigator1.SelectedPage.Text & " - Codeo"
        End Try

    End Sub

    Private Sub JavaScriptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JavaScriptToolStripMenuItem.Click
        Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)
        If editor Is Nothing Then
            Throw New Exception
        Else
            editor.SetHighlighting("JavaScript")
        End If
    End Sub

    Private Sub CSSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CSSToolStripMenuItem.Click
        Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)
        If editor Is Nothing Then
            Throw New Exception
        Else
            editor.SetHighlighting("CSS")
            'ICSharpCode.TextEditor.Document.HighlightingManager.Manager.FindHighlighter()
        End If
    End Sub

    Private Sub HTMLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HTMLToolStripMenuItem.Click
        Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)
        If editor Is Nothing Then
            Throw New Exception
        Else
            editor.SetHighlighting("HTML")
        End If
    End Sub

    Private Sub PHPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PHPToolStripMenuItem.Click
        Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)
        If editor Is Nothing Then
            Throw New Exception
        Else
            editor.SetHighlighting("PHP")
        End If
    End Sub

    Private Sub BrowseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseToolStripMenuItem.Click
        If KryptonSplitContainer1.Panel1Collapsed = True Then
            KryptonSplitContainer1.Panel1Collapsed = False
            BrowseToolStripMenuItem.Checked = True
        Else
            KryptonSplitContainer1.Panel1Collapsed = True
            BrowseToolStripMenuItem.Checked = False
        End If

    End Sub

    Private Sub SaveFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveFileToolStripMenuItem.Click
        Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)

        If KryptonNavigator1.SelectedPage.Tag = "" Then
            If editor.Text.Length <> 0 Then
                saveFile("show")
            Else
                'newPageArr.Remove(whichNew(KryptonNavigator1.SelectedPage.Text))
            End If
        Else
            saveFile(KryptonNavigator1.SelectedPage.Tag)
        End If
    End Sub

    Private Sub NewFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewFileToolStripMenuItem.Click
        openNewFile()
    End Sub
    Private Sub saveFile(ByVal path)
        Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)

        If (path = "show") Then
            Dim saveFileDialog1 As New SaveFileDialog()
            saveFileDialog1.Filter = "JavaScript File|*.js|Cascade Stylesheet|*.css|HTML|*.html"
            saveFileDialog1.Title = "Save File"
            saveFileDialog1.ShowDialog()
            If saveFileDialog1.FileName <> "" Then
                editor.SaveFile(saveFileDialog1.FileName)
                KryptonNavigator1.SelectedPage.Tag = saveFileDialog1.FileName
                If isNew(KryptonNavigator1.SelectedPage.Text) Then
                    newPageArr.Remove(whichNew(KryptonNavigator1.SelectedPage.Text))
                End If
                KryptonNavigator1.SelectedPage.Text = getFilename(saveFileDialog1.FileName)
                updateStar()
            End If
        Else
            editor.SaveFile(KryptonNavigator1.SelectedPage.Tag)
            updateStar()
        End If
    End Sub

    Private Sub CommonHandler(ByVal sender As System.Object, _
    ByVal e As System.EventArgs)
        Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)

        Dim text = CType(sender, ICSharpCode.TextEditor.TextEditorControl).Text
        Dim title As String = KryptonNavigator1.SelectedPage.Tag
        If title.ToString <> "" Then
            Dim fileName = getFilename(KryptonNavigator1.SelectedPage.Tag)
            Dim value As String = File.ReadAllText(KryptonNavigator1.SelectedPage.Tag)
            If (value = editor.Text) Then
                Me.Text = KryptonNavigator1.SelectedPage.Tag & " - Codeo"
                KryptonNavigator1.SelectedPage.Text = fileName
            Else
                Me.Text = KryptonNavigator1.SelectedPage.Tag & "* - Codeo"
                KryptonNavigator1.SelectedPage.Text = fileName & "*"
            End If

        End If
        'MsgBox(CType(sender, ICSharpCode.TextEditor.TextEditorControl).Text & "::::" & value)
        ' caretPos.Text = "Ln: " & editor.ActiveTextAreaControl.Caret.Line + 1 & " Col: " & editor.ActiveTextAreaControl.Caret.Column

    End Sub

    Function highlightSameWord(ByVal sender As System.Object, _
    ByVal e As System.EventArgs)
        Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)
        'ToolStripStatusLabel1.Text = editor.Document.MarkerStrategy.TextMarker.Count
        For i = 0 To editor.Document.MarkerStrategy.TextMarker.Count
            editor.Document.MarkerStrategy.RemoveMarker(editor.Document.MarkerStrategy.TextMarker(0))
        Next

        Dim searchStr = editor.ActiveTextAreaControl.SelectionManager.SelectedText
        Dim lastSearchIndex = 0


        highlightWord(searchStr, lastSearchIndex)
        editor.ActiveTextAreaControl.TextArea.Update()
        Dim Str = "Length: " & editor.ActiveTextAreaControl.Document.TextLength.ToString("N0") & "    Lines: " & editor.ActiveTextAreaControl.Document.TotalNumberOfLines.ToString("N0") & "    Ln: " & (editor.ActiveTextAreaControl.Caret.Line + 1).ToString("N0") & "    Col: " & (editor.ActiveTextAreaControl.Caret.Column + 1).ToString("N0") & "    Sel: " & editor.ActiveTextAreaControl.SelectionManager.SelectedText.Length.ToString("N0")
        statustxt.Text = Str
    End Function
    Function highlightWord(ByVal searchStr, ByVal lastSearchIndex)
        Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)
        'ToolStripStatusLabel1.Text = searchStr & TimeOfDay.Second
        If (searchStr <> "") Then
            Dim txtIndex = editor.ActiveTextAreaControl.Document.TextContent.IndexOf(searchStr, lastSearchIndex)
            'ToolStripStatusLabel1.Text = "Search: " & txtIndex & ";"
            If (txtIndex <> -1) Then
                Dim marker = New ICSharpCode.TextEditor.Document.TextMarker(txtIndex, searchStr.Length, ICSharpCode.TextEditor.Document.TextMarkerType.SolidBlock, Color.Yellow)
                editor.Document.MarkerStrategy.AddMarker(marker)
                lastSearchIndex = txtIndex + searchStr.Length

                highlightWord(searchStr, lastSearchIndex)
            Else
                Return True
            End If
        Else
           
        End If
    End Function
    Function updateSatus(ByVal sender As System.Object, _
    ByVal e As System.EventArgs)
        Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)
        Dim str As String
        str = "Length: " & editor.ActiveTextAreaControl.Document.TextLength.ToString("N0") & "    Lines: " & editor.ActiveTextAreaControl.Document.TotalNumberOfLines.ToString("N0") & "    Ln: " & (editor.ActiveTextAreaControl.Caret.Line + 1).ToString("N0") & "    Col: " & (editor.ActiveTextAreaControl.Caret.Column + 1).ToString("N0") & "    Sel: " & editor.ActiveTextAreaControl.SelectionManager.SelectedText.Length.ToString("N0")
        statustxt.Text = str

    End Function
    Function showBrowse(ByVal status)
        BrowseToolStripMenuItem.Checked = status
        If BrowseToolStripMenuItem.Checked = True Then
            KryptonSplitContainer1.Panel1Collapsed = False
        Else
            KryptonSplitContainer1.Panel1Collapsed = True
        End If

    End Function
    Function getFilename(ByVal path) As String
        Dim split As String() = path.Split("\")
        Dim fileName As String = split(split.Length - 1)
        getFilename = fileName
    End Function

    Function getFileExt(ByVal path) As String
        Dim str As String
        str = path
        Dim split As String() = path.Split(".")
        Dim fileExt As String = split(split.Length - 1)
        getFileExt = fileExt
    End Function

    Private Sub updateStar()
        Dim fileName = getFilename(KryptonNavigator1.SelectedPage.Tag)
        Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)
        Dim value As String = File.ReadAllText(KryptonNavigator1.SelectedPage.Tag)
        If (value = editor.Text) Then
            Me.Text = KryptonNavigator1.SelectedPage.Tag & " - Codeo"
            KryptonNavigator1.SelectedPage.Text = fileName
        Else
            Me.Text = KryptonNavigator1.SelectedPage.Tag & "* - Codeo"
            KryptonNavigator1.SelectedPage.Text = fileName & "*"
        End If
    End Sub

    Function setLanguage()
        Dim filepath = KryptonNavigator1.SelectedPage.Tag
        If (filepath.ToString.IndexOf(".") > 0) Then
            Dim ext As String = getFileExt(filepath)

            Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)
            Select Case ext
                Case "html"
                    editor.SetHighlighting("HTML")
                Case "js"
                    editor.SetHighlighting("JavaScript")
                Case "css"
                    editor.SetHighlighting("css")
                Case "xml"
                    editor.SetHighlighting("XML")
                Case "sql"
                    editor.SetHighlighting("SQL")
                Case Else

            End Select
        End If


    End Function
    Private fsWatchers As New List(Of FileSystemWatcher)()
    Public Sub AddWatcher(ByVal wPath As String)
        wPath = Path.GetDirectoryName(wPath)
        Dim fsw As New FileSystemWatcher()
        fsw.Path = wPath
        AddHandler fsw.Changed, AddressOf logchange
        AddHandler fsw.Deleted, AddressOf logchange
        fsWatchers.Add(fsw)
    End Sub
    Public Sub logchange(ByVal source As Object, ByVal e As System.IO.FileSystemEventArgs)
        'Handle change, delete and new events

        If e.ChangeType = IO.WatcherChangeTypes.Changed Then
            Threading.Thread.Sleep(1000)
            MsgBox(e.FullPath.ToString & vbCrLf & vbCrLf & "This file has been modified elsewhere. " & vbCrLf & "Do you want to reload it?", MsgBoxStyle.YesNo, e.Name)
        End If
    End Sub

    Private Sub watchFiles()
        For Each fsw In fsWatchers
            fsw.EnableRaisingEvents = False
        Next
    End Sub

    Function whichNew(ByVal name)
        name = name.ToString.Replace("*", "")
        If (name.ToString.IndexOf(".") = -1) Then
            Dim str As String() = name.split(" ")
            Return str(1)
        Else
            Return False
        End If
    End Function
    Function isNew(ByVal name)

        name = name.ToString.Replace("*", "")

        If (name.ToString.IndexOf(".") = -1) Then
            Dim str As String() = name.split(" ")
            If (str(0) = "New") Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Function getNewPageCount()
        For i = 1 To 1000
            If (newPageArr.IndexOf(i) = -1) Then
                Return i
            End If
        Next
    End Function
    Function isAlreadyOpened(ByVal file)
        For i = 0 To KryptonNavigator1.Pages.Count - 1
            If KryptonNavigator1.Pages(i).Tag = file Then
                KryptonNavigator1.SelectedIndex = i
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub NavigateWebURL(ByVal URL As String, Optional ByVal browser As String = "default")
        Dim str As String = URL.Replace(" ", "%20")
        If Not (browser = "default") Then
            Try
                '// try set browser if there was an error (browser not installed)
                Process.Start(browser, str)
            Catch ex As Exception
                '// use default browser
                Process.Start(str)
            End Try

        Else
            '// use default browser
            Process.Start(str)

        End If

    End Sub

    Private Sub MozillaFirefoxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MozillaFirefoxToolStripMenuItem.Click
        Dim str = KryptonNavigator1.SelectedPage.Tag
        NavigateWebURL(str, "Firefox")
    End Sub

    Private Sub GoogleChromeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoogleChromeToolStripMenuItem.Click
        Dim str = KryptonNavigator1.SelectedPage.Tag
        NavigateWebURL(str, "chrome")
    End Sub

    Private Sub OperaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OperaToolStripMenuItem.Click
        Dim str = KryptonNavigator1.SelectedPage.Tag
        NavigateWebURL(str, "opera")
    End Sub

    Private Sub InternetExplorerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternetExplorerToolStripMenuItem.Click
        Dim str = KryptonNavigator1.SelectedPage.Tag
        NavigateWebURL(str, "explorer")
    End Sub

    Private Sub SafariToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SafariToolStripMenuItem.Click
        Dim str = KryptonNavigator1.SelectedPage.Tag
        NavigateWebURL(str, "safari")
    End Sub

    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        find.Show()
    End Sub

    Private Sub GotoLineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GotoLineToolStripMenuItem.Click
        goto_form.Show()
    End Sub

    Private Sub ToolStripStatusLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles statustxt.Click

    End Sub

    Private Sub TreeView1_AfterSelect_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub

    Private Sub OnlineHelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OnlineHelpToolStripMenuItem.Click
        Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)

        MsgBox(editor.ActiveTextAreaControl.Document.MarkerStrategy.TextMarker.ToString)
    End Sub

    Private Sub DarkGreyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DarkGreyToolStripMenuItem.Click
        Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)
        editor.Select()
        Dim colorv = Color.White
        Dim backgroundColor = Color.FromArgb(39, 40, 34)
        Dim hs = New ICSharpCode.TextEditor.Document.DefaultHighlightingStrategy
        Dim hc = New ICSharpCode.TextEditor.Document.HighlightColor(colorv, backgroundColor, False, False)
        hs.SetColorFor("Default", hc)
        hs.SetColorFor("LineNumbers", hc)
        hs.SetColorFor("FoldLine", hc)
        editor.Document.HighlightingStrategy = hs
    End Sub

    Private Sub AboutCodeoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutCodeoToolStripMenuItem.Click
        about.Show()
    End Sub

    Function CacheShellIcon(ByVal argPath As String) As String
        Dim mKey As String = Nothing
        ' determine the icon key for the file/folder specified in argPath
        If IO.Directory.Exists(argPath) = True Then
            mKey = "folder"
        ElseIf IO.File.Exists(argPath) = True Then
            mKey = IO.Path.GetExtension(argPath)
        End If
        ' check if an icon for this key has already been added to the collection
        If ImageList1.Images.ContainsKey(mKey) = False Then
            ImageList1.Images.Add(mKey, GetShellIconAsImage(argPath))
        End If
        Return mKey
    End Function
    Function GetShellIconAsImage(ByVal argPath As String) As Image
        Dim mShellFileInfo As New SHFILEINFO
        mShellFileInfo.szDisplayName = New String(Chr(0), 260)
        mShellFileInfo.szTypeName = New String(Chr(0), 80)
        SHGetFileInfo(argPath, 0, mShellFileInfo, System.Runtime.InteropServices.Marshal.SizeOf(mShellFileInfo), SHGFI_ICON Or SHGFI_SMALLICON)
        ' attempt to create a System.Drawing.Icon from the icon handle that was returned in the SHFILEINFO structure
        Dim mIcon As System.Drawing.Icon
        Dim mImage As System.Drawing.Image
        Try
            mIcon = System.Drawing.Icon.FromHandle(mShellFileInfo.hIcon)
            mImage = mIcon.ToBitmap
        Catch ex As Exception
            ' for some reason the icon could not be converted so create a blank System.Drawing.Image to return instead
            mImage = New System.Drawing.Bitmap(16, 16)
        End Try
        ' return the final System.Drawing.Image
        Return mImage
    End Function

    Public Declare Auto Function SHGetFileInfo Lib "shell32.dll" (ByVal pszPath As String, ByVal dwFileAttributes As Integer, ByRef psfi As SHFILEINFO, ByVal cbFileInfo As Integer, ByVal uFlags As Integer) As IntPtr

    Public Const SHGFI_ICON As Integer = &H100
    Public Const SHGFI_SMALLICON As Integer = &H1
    Public Const SHGFI_LARGEICON As Integer = &H0
    Public Const SHGFI_OPENICON As Integer = &H2

    Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As Integer
        <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String
        <Runtime.InteropServices.MarshalAs(Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String
    End Structure

    Private Sub KryptonSplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles KryptonSplitContainer1.Panel1.Paint

    End Sub
End Class
