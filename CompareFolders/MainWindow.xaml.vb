Imports System.ComponentModel

Class MainWindow

    Private Sub Compare_Click(sender As Object, e As RoutedEventArgs) Handles Compare.Click

        Me.Cursor = Cursors.Wait

        ComparingProgress.Value = 0

        Dim sniffer As New DirectorySniffer
        Dim folder1stuff As List(Of String) = sniffer.GetAllFiles(Folder1Path.Text)
        ComparingProgress.Value = 25

        Dim folder2stuff As List(Of String) = sniffer.GetAllFiles(Folder2Path.Text)

        ComparingProgress.Value = 50

        Dim finallist As List(Of String) = sniffer.CompareDirectories(folder1stuff, folder2stuff)

        ComparingProgress.Value = 75

        MissingFileList1.ItemsSource = finallist

        Dim finalist2 As List(Of String) = sniffer.CompareDirectories(folder2stuff, folder1stuff)

        ComparingProgress.Value = 100

        MissingFileList2.ItemsSource = finalist2

        Dim finallist3 As List(Of String) = sniffer.SameDirectories(folder1stuff, folder2stuff)

        SameFileList.ItemsSource = finallist3

        Me.Cursor = Cursors.Arrow


    End Sub


    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

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
End Class
