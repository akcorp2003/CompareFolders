Imports System.ComponentModel

Class MainWindow

    Private Sub Compare_Click(sender As Object, e As RoutedEventArgs) Handles Compare.Click

        Me.Cursor = Cursors.Wait

        ComparingProgress.Value = 0

        Dim sniffer As New DirectorySniffer

        Dim useryear As String
        If Year.Text = "" Then
            useryear = " "
        Else
            useryear = Year.Text
        End If

        Dim usermonth As String
        If Months.SelectedValue Is Nothing Then
            usermonth = " "
        Else
            usermonth = Months.SelectedValue.ToString
        End If

        Dim userday As String
        If Days.SelectedValue Is Nothing Then
            userday = " "
        Else
            userday = Months.SelectedValue.ToString
        End If


        Dim folder1stuff As List(Of String) = sniffer.GetAllFiles(Folder1Path.Text, useryear, usermonth, userday)
        ComparingProgress.Value = 25

        Dim folder2stuff As List(Of String) = sniffer.GetAllFiles(Folder2Path.Text, useryear, usermonth, userday)

        ComparingProgress.Value = 50

        Dim finallist As List(Of String) = sniffer.CompareDirectories(folder1stuff, folder2stuff)

        RedCount.Content = "File Count: " + Convert.ToString(finallist.Count)

        ComparingProgress.Value = 75

        MissingFileList1.ItemsSource = finallist

        Dim finalist2 As List(Of String) = sniffer.CompareDirectories(folder2stuff, folder1stuff)

        ComparingProgress.Value = 100

        YellowCount.Content = "File Count: " + Convert.ToString(finalist2.Count)

        MissingFileList2.ItemsSource = finalist2

        Dim finallist3 As List(Of String) = sniffer.SameDirectories(folder1stuff, folder2stuff)

        GreenCount.Content = "File Count: " + Convert.ToString(finallist3.Count)

        SameFileList.ItemsSource = finallist3

        Me.Cursor = Cursors.Arrow


    End Sub


    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        REM populate the ComboBox for Days since there's too many days to type into XAML
        Days.Items.Add(" ")
        For i As Integer = 1 To 31 Step 1
            Days.Items.Add(Convert.ToString(i))
        Next
        Months.Items.Add(" ")
        For i As Integer = 1 To 12 Step 1
            Months.Items.Add(Convert.ToString(i))
        Next
    End Sub

    Public ReadOnly Property Path1_Text As String
        Get
            Return Folder1Path.Text
        End Get
    End Property

    Public ReadOnly Property Path2_Text As String
        Get
            Return Folder2Path.Text
        End Get
    End Property

    Private Sub Browse1_Click(sender As Object, e As RoutedEventArgs) Handles Browse1.Click
        'Dim dialog As New Microsoft.Win32.OpenFileDialog
        'Dim result As Nullable(Of Boolean) = dialog.ShowDialog

        'If result = True Then
        '    Dim selectedfilename As String = dialog.FileName
        '    Folder1Path.Text = selectedfilename
        'End If

        Dim dialog As New System.Windows.Forms.FolderBrowserDialog
        Dim result As System.Windows.Forms.DialogResult = dialog.ShowDialog

        Dim userpath As String = dialog.SelectedPath
        Folder1Path.Text = userpath
    End Sub

    Private Sub Browse2_Click(sender As Object, e As RoutedEventArgs) Handles Browse2.Click
        Dim dialog As New System.Windows.Forms.FolderBrowserDialog
        Dim result As System.Windows.Forms.DialogResult = dialog.ShowDialog

        Dim userpath As String = dialog.SelectedPath
        Folder2Path.Text = userpath
    End Sub
End Class
