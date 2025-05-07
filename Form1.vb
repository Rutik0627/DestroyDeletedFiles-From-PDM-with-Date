Imports System.IO
Imports EdmLib

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Declare and create an instance of IEdmVault5
            'Cast IEdmVault5 to IEdmVault8
            Dim vault As IEdmVault8 = New EdmVault5
            Dim Views() As EdmViewInfo = Nothing

            'Populate the form with the names of 
            'the vaults on the computer
            vault.GetVaultViews(Views, False)
            VaultsComboBox.Items.Clear()
            For Each View As EdmViewInfo In Views
                VaultsComboBox.Items.Add(View.mbsVaultName)
            Next
            If VaultsComboBox.Items.Count > 0 Then
                VaultsComboBox.Text = VaultsComboBox.Items(0)
            End If

        Catch ex As Runtime.InteropServices.COMException
            MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + vbCrLf + ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub



    Private Sub CheckBox_Recursive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Recursive.CheckedChanged

    End Sub

    Private Sub VaultsLabel_Click(sender As Object, e As EventArgs) Handles VaultsLabel.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles dtpFromDate.ValueChanged

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles dtpToDate.ValueChanged

    End Sub

    Private Sub DestroyDeletedItemsButton_Click(sender As Object, e As EventArgs) Handles DestroyDeletedItemsButton.Click
        Try
            'Declare and create an instance of IEdmVault5
            Dim vault As IEdmVault5 = New EdmVault5()

            'Log into selected vault as the current user
            vault.LoginAuto(VaultsComboBox.Text, Me.Handle.ToInt32())

            'Check to see if deleted files should be
            'destroyed in all subfolders
            Dim aRecursive As Boolean = False
            If CheckBox_Recursive.Checked Then
                aRecursive = True
            End If

            Dim poDeletedItems() As EdmDeletedItems = Nothing
            Dim ppoDestroyedItems() As EdmFileInfo = Nothing
            Dim poErrors() As EdmBatchDelErrInfo = Nothing
            Dim DeletedFolder As IEdmFolder13

            'Get the root folder of the vault
            DeletedFolder = vault.RootFolder

            DeletedFolder.GetDeletedItems(poDeletedItems, aRecursive)

            DeletedFolder.DestroyDeletedItems2(poDeletedItems, ppoDestroyedItems, poErrors)

            'Destroy all deleted files in the root folder and
            'subfolders, if the check box is selected on the form
            Dim idx As Integer
            idx = LBound(ppoDestroyedItems)
            Dim msg As String = Nothing

            'If any deleted files found, display their names in a message box
            While idx <= UBound(ppoDestroyedItems)
                Dim row As String
                row = "DocumentID: " + CStr(ppoDestroyedItems(idx).mlFileID) + ", FolderID: " +
                    CStr(ppoDestroyedItems(idx).mlFolderID) + ", File path: " + ppoDestroyedItems(idx).mbsPath + vbCrLf
                If ppoDestroyedItems(idx).mhResult = 0 Then
                    row = row + "Status: OK" + vbCrLf
                Else
                    row = row + " status: Failed=" + "HRESULT = 0x" + CStr(poErrors(idx).mlErrorCode)
                End If
                idx = idx + 1
                msg = msg + row + vbCrLf
            End While

            If msg Is Nothing Then
                MessageBox.Show("No deleted files were found in the selected vault's root folder or subfolders.")
            Else
                MessageBox.Show("The status for each destroyed file is: " + vbCrLf + vbCrLf + msg)
            End If

        Catch ex As Runtime.InteropServices.COMException
            MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + vbCrLf + ex.Message)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'get selected dates
        Dim fromDate As DateTime = dtpFromDate.Value.Date
        Dim toDate As DateTime = dtpToDate.Value.Date

        ' Ensure "To Date" is not earlier than "From Date"
        If toDate < fromDate Then
            MessageBox.Show("Error: 'To Date' cannot be earlier than 'From Date'.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Get the selected folder path
        Dim folderPath As String = VaultsComboBox.SelectedItem.ToString()

        ' Check if folder exists
        If Directory.Exists(folderPath) Then
            ' Loop through each file in the folder
            For Each file As String In Directory.GetFiles(folderPath)
                Dim fileInfo As New FileInfo(file)
                Dim fileDate As DateTime = fileInfo.LastWriteTime ' Get the last modified date

                ' Check if file modification date falls within the selected range
                If fileDate >= fromDate AndAlso fileDate <= toDate Then
                    Try
                        Dim files As Object = Nothing
                        files.Delete(file)
                        Console.WriteLine("Deleted: " & file)
                    Catch ex As Exception
                        MessageBox.Show("Error deleting file: " & file & vbCrLf & ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End If
            Next

            MessageBox.Show("Files deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Selected folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnCheckDeletedFiles_Click(sender As Object, e As EventArgs) Handles btnCheckDeletedFiles.Click
        ' Validate if a vault is selected
        If VaultsComboBox.SelectedItem Is Nothing OrElse String.IsNullOrWhiteSpace(VaultsComboBox.SelectedItem.ToString()) Then
            MessageBox.Show("Please select a valid vault folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Get the selected folder path
        Dim folderPath As String = VaultsComboBox.SelectedItem.ToString()

        ' Validate folder existence
        If Not Directory.Exists(folderPath) Then
            MessageBox.Show("Selected folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Get selected dates
        Dim fromDate As DateTime = dtpFromDate.Value.Date
        Dim toDate As DateTime = dtpToDate.Value.Date

        ' Ensure 'To Date' is not before 'From Date'
        If toDate < fromDate Then
            MessageBox.Show("Error: 'To Date' cannot be earlier than 'From Date'.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Check if the "Include Subfolders" checkbox is checked
        Dim searchOption As SearchOption = If(CheckBox_Recursive.Checked, SearchOption.AllDirectories, SearchOption.TopDirectoryOnly)

        Try
            ' Get all files in the folder (including subfolders if checked)
            Dim files As String() = Directory.GetFiles(folderPath, "*.*", searchOption)

            Dim deletedFiles As Integer = 0

            ' Loop through each file and delete if within date range
            For Each file As String In files
                Dim fileInfo As New FileInfo(file)
                Dim fileDate As DateTime = fileInfo.LastWriteTime ' Get the last modified date

                'Dim Vfile As String
                ' Dim filepath As String
                'filepath = "C:\Vaults\KPCLVault_QA"

                ' Check if file modification date falls within the selected range
                If fileDate >= fromDate AndAlso fileDate <= toDate Then
                    Try
                        ' Vfile.Delete(filepath)
                        deletedFiles += 1
                    Catch ex As UnauthorizedAccessException
                        MessageBox.Show("Access denied: " & file, "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Catch ex As IOException
                        MessageBox.Show("File in use: " & file, "File Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                End If
            Next

            ' Show success message
            MessageBox.Show(deletedFiles & " files deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class