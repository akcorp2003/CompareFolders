Imports System
Imports System.IO
Imports System.Collections
Imports System.Windows.Controls

Public Class DirectorySniffer

    Public Function GetAllFiles(ByVal initialpath As String, ByVal year As String, ByVal month As String, ByVal day As String,
                                Optional ByVal bar As Object = Nothing) As List(Of String)
        Dim resultfile_list As New List(Of String)
        Dim directory_list As New Stack(Of String)
        Dim my_bar As Windows.Controls.ProgressBar = Nothing
        If bar IsNot Nothing Then
            my_bar = TryCast(bar, Windows.Controls.ProgressBar)
        End If

        'my_bar.Value = 0
        If my_bar IsNot Nothing Then
            my_bar.Value = 0
        End If

        directory_list.Push(initialpath)

        While directory_list.Count > 0
            Dim curr_directory As String = directory_list.Pop()
            Try
                Dim dirinfo As New DirectoryInfo(curr_directory)
                Dim filesindir As FileInfo() = dirinfo.GetFiles()

                Dim myfile As FileInfo
                For Each myfile In filesindir
                    Dim filewritedate As Date = myfile.LastWriteTime
                    Dim writeyear As String = Convert.ToString(filewritedate.Year)
                    Dim writemonth As String = Convert.ToString(filewritedate.Month)
                    Dim writeday As String = Convert.ToString(filewritedate.Day)

                    REM check if the user asked to check for year
                    If Not String.Compare(year, " ") = 0 Then

                        If String.Compare(writeyear, year) = 0 Then
                            REM check if user asked to check for month
                            If Not String.Compare(month, " ") = 0 Then
                                If String.Compare(month, writemonth) = 0 Then
                                    REM check if user asked to check for date
                                    If Not String.Compare(day, " ") = 0 Then
                                        If String.Compare(day, writeday) = 0 Then
                                            REM we can add the file
                                            resultfile_list.Add(myfile.ToString)
                                        End If
                                    Else
                                        REM year and month checks out, user didn't request a date
                                        resultfile_list.Add(myfile.ToString)
                                    End If

                                End If
                            Else
                                REM user doesn't ask to check for month
                                REM but may have asked to check for day
                                If Not String.Compare(day, " ") = 0 Then
                                    If String.Compare(day, writeday) = 0 Then
                                        REM we can add the file, year + day are valid
                                        resultfile_list.Add(myfile.ToString)
                                    End If
                                Else
                                    REM year checks out, user didn't request a date nor month
                                    resultfile_list.Add(myfile.ToString)
                                End If

                            End If
                        Else
                            REM don't add the file
                        End If
                    Else
                        REM user doesn't ask for year, may have asked month and day
                        REM check if user asked to check for month
                        If Not String.Compare(month, " ") = 0 Then
                            If String.Compare(month, writemonth) = 0 Then
                                REM check if user asked to check for date
                                If Not String.Compare(day, " ") = 0 Then
                                    If String.Compare(day, writeday) = 0 Then
                                        REM we can add the file
                                        resultfile_list.Add(myfile.ToString)
                                    End If
                                Else
                                    REM month checks out, user didn't request a date
                                    resultfile_list.Add(myfile.ToString)
                                End If

                            End If
                        Else
                            REM user doesn't ask to check for month
                            REM but may have asked to check for day
                            If Not String.Compare(day, " ") = 0 Then
                                If String.Compare(day, writeday) = 0 Then
                                    REM we can add the file, day is valid
                                    resultfile_list.Add(myfile.ToString)
                                End If
                            Else
                                REM user doesn't ask for anything specific, just add the file
                                resultfile_list.Add(myfile.ToString)
                            End If

                        End If
                    End If

                Next

                If my_bar IsNot Nothing Then
                    my_bar.Value += my_bar.SmallChange()
                End If


                REM and also grab all the directories currently in this folder, if applicable
                For Each directoryname As String In Directory.GetDirectories(curr_directory)
                    directory_list.Push(directoryname)
                Next
            Catch ex As Exception
                MessageBox.Show("Couldn't locate directory!!" + curr_directory, "Oh no!", MessageBoxButton.OK, MessageBoxImage.Error)
            End Try
        End While
        If my_bar IsNot Nothing Then
            my_bar.Value = 100
        End If

        Return resultfile_list
    End Function

    ''' <summary>
    ''' Returns a list of missing files in list2 compared to list1.
    ''' </summary>
    ''' <param name="list1">A directory listing of files.</param>
    ''' <param name="list2">A directory listing of files.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CompareDirectories(ByVal list1 As List(Of String), ByVal list2 As List(Of String)) As List(Of String)
        REM we will rely on the filename to represent if the files are the same
        REM we are treating list1 as the master list
        Dim result As New List(Of String) REM a list of file names

        Dim list1_filenames As New List(Of String)
        Dim list2_filenames As New List(Of String)

        For i As Integer = 0 To list1.Count - 1 Step 1
            Dim filename As String
            Try
                filename = Path.GetFileName(list1(i))
            Catch ex As Exception
                MessageBox.Show("Couldn't locate the file's location!" + list1(i), "Oh no!", MessageBoxButton.OK, MessageBoxImage.Error)
                filename = Nothing
            End Try

            list1_filenames.Add(filename)
        Next

        For i As Integer = 0 To list2.Count - 1 Step 1
            Dim filename As String
            Try
                filename = Path.GetFileName(list2(i))
            Catch ex As Exception
                MessageBox.Show("Couldn't locate the file's location!" + list2(i), "Oh no!", MessageBoxButton.OK, MessageBoxImage.Error)
                filename = Nothing
            End Try
            list2_filenames.Add(filename)
        Next

        For i As Integer = 0 To list1_filenames.Count - 1 Step 1
            If Not list2_filenames.Contains(list1_filenames(i)) Then
                Dim index As Integer = list1_filenames.IndexOf(list1_filenames(i))
                result.Add(list1_filenames(index))
            End If
        Next

        Return result
    End Function

    Public Function SameDirectories(ByVal list1 As List(Of String), ByVal list2 As List(Of String)) As List(Of String)
        REM we will rely on the filename to represent if the files are the same
        REM we are treating list1 as the master list
        Dim result As New List(Of String) REM a list of file names

        Dim list1_filenames As New List(Of String)
        Dim list2_filenames As New List(Of String)

        For i As Integer = 0 To list1.Count - 1 Step 1
            Dim filename As String
            Try
                filename = Path.GetFileName(list1(i))
            Catch ex As Exception
                MessageBox.Show("Couldn't locate the file's location!" + list1(i), "Oh no!", MessageBoxButton.OK, MessageBoxImage.Error)
                filename = Nothing
            End Try

            list1_filenames.Add(filename)
        Next

        For i As Integer = 0 To list2.Count - 1 Step 1
            Dim filename As String
            Try
                filename = Path.GetFileName(list2(i))
            Catch ex As Exception
                MessageBox.Show("Couldn't locate the file's location!" + list2(i), "Oh no!", MessageBoxButton.OK, MessageBoxImage.Error)
                filename = Nothing
            End Try
            list2_filenames.Add(filename)
        Next

        Dim limitingindex As Integer = 0
        If list1_filenames.Count > list2_filenames.Count Then
            limitingindex = list2_filenames.Count
            For i As Integer = 0 To limitingindex - 1 Step 1
                If list1_filenames.Contains(list2_filenames(i)) Then
                    Dim index As Integer = list2_filenames.IndexOf(list2_filenames(i))
                    result.Add(list2_filenames(index))
                End If
            Next
        Else
            limitingindex = list1_filenames.Count
            For i As Integer = 0 To limitingindex - 1 Step 1
                If list2_filenames.Contains(list1_filenames(i)) Then
                    Dim index As Integer = list1_filenames.IndexOf(list1_filenames(i))
                    result.Add(list1_filenames(index))
                End If
            Next
        End If

        Return result
    End Function
End Class
