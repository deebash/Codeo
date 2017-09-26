Imports System.Windows.Forms
Imports System.IO

Public Class main
    Dim newPgeCount = 0

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
                    parentNode.Nodes.Add(fileName).Tag = dir & "\" & fileName

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
            Try
                txteditor.LoadFile(file)
            Catch e As Exception

            End Try
            txteditor.SetHighlighting("JavaScript")
            lineCount.Text = "Length: " & txteditor.Text.Length.ToString & "  Ln: "
            KryptonNavigator1.SelectedIndex = KryptonNavigator1.Pages.Count - 1
            Me.Text = fileName & " - Codeo"
        Else
            'the file doesn't exist
        End If


      

    End Sub


    Private Sub openNewFile()
        newPgeCount = newPgeCount + 1
        Dim page = New ComponentFactory.Krypton.Navigator.KryptonPage
        Dim txteditor = New ICSharpCode.TextEditor.TextEditorControl
        KryptonNavigator1.Pages.Add(page)
        Dim filename = "New " & newPgeCount
        page.Text = fileName
        page.TextTitle = fileName
        page.Controls.Add(txteditor)
        txteditor.Dock = DockStyle.Fill
        txteditor.SetHighlighting("txt")
        lineCount.Text = "Length: " & txteditor.Text.Length.ToString & "  Ln: "
        KryptonNavigator1.SelectedIndex = KryptonNavigator1.Pages.Count - 1
        Me.Text = fileName & " - Codeo"
    End Sub

    Private Sub openNewFileHistory(ByVal name)
        Dim page = New ComponentFactory.Krypton.Navigator.KryptonPage
        Dim txteditor = New ICSharpCode.TextEditor.TextEditorControl
        KryptonNavigator1.Pages.Add(page)
        Dim filename = name
        page.Text = filename
        page.TextTitle = filename
        page.Controls.Add(txteditor)
        txteditor.Dock = DockStyle.Fill
        txteditor.SetHighlighting("txt")
        lineCount.Text = "Length: " & txteditor.Text.Length.ToString & "  Ln: "
        KryptonNavigator1.SelectedIndex = KryptonNavigator1.Pages.Count - 1
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


    Private Sub TreeView1_NodeMouseDoubleClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick

        openFile(TreeView1.SelectedNode.Tag)
    End Sub

    Private Sub KryptonNavigator1_CloseAction(ByVal sender As Object, ByVal e As ComponentFactory.Krypton.Navigator.CloseActionEventArgs) Handles KryptonNavigator1.CloseAction
        Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)

        If KryptonNavigator1.SelectedPage.Tag = "" Then
            If editor.Text.Length <> 0 Then
                saveFile("show")
            End If
        Else
            saveFile(KryptonNavigator1.SelectedPage.Tag)
        End If
    End Sub

    Private Sub KryptonNavigator1_SelectedPageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles KryptonNavigator1.SelectedPageChanged
        Try
            Me.Text = KryptonNavigator1.SelectedPage.Text & " - Codeo"
            Dim value As String = File.ReadAllText(KryptonNavigator1.SelectedPage.Tag)
            Dim editor As ICSharpCode.TextEditor.TextEditorControl = KryptonNavigator1.SelectedPage.Controls(0)
            If (value = editor.Text) Then

            Else
                Me.Text = KryptonNavigator1.SelectedPage.Text & "* - Codeo"
            End If
        Catch err As Exception
            Me.Text = "Codeo"
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
            MsgBox(editor.Text.Length)
            If editor.Text.Length <> 0 Then
                saveFile("show")
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
            End If
        Else
            editor.SaveFile(KryptonNavigator1.SelectedPage.Tag)
        End If
    End Sub

    Private Sub CommonHandler(ByVal sender As System.Object, _
    ByVal e As System.EventArgs)

        MsgBox(CType(sender, TextBox).Text)

    End Sub


End Class
