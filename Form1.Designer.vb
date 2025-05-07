<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.VaultsLabel = New System.Windows.Forms.Label()
        Me.VaultsComboBox = New System.Windows.Forms.ComboBox()
        Me.CheckBox_Recursive = New System.Windows.Forms.CheckBox()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.DestroyDeletedItemsButton = New System.Windows.Forms.Button()
        Me.btnCheckDeletedFiles = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(293, 72)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "This application destroys all deleted files" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in the root folder of the selected V" &
    "ault" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and also allows you to destroy all deleted" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "files in all of the selected V" &
    "ault's Subfolders."
        '
        'VaultsLabel
        '
        Me.VaultsLabel.AutoSize = True
        Me.VaultsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VaultsLabel.Location = New System.Drawing.Point(21, 101)
        Me.VaultsLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.VaultsLabel.Name = "VaultsLabel"
        Me.VaultsLabel.Size = New System.Drawing.Size(127, 20)
        Me.VaultsLabel.TabIndex = 1
        Me.VaultsLabel.Text = "Select a Vault:"
        '
        'VaultsComboBox
        '
        Me.VaultsComboBox.FormattingEnabled = True
        Me.VaultsComboBox.Items.AddRange(New Object() {"KPCLVault", "KPCLVault_QA"})
        Me.VaultsComboBox.Location = New System.Drawing.Point(24, 125)
        Me.VaultsComboBox.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.VaultsComboBox.Name = "VaultsComboBox"
        Me.VaultsComboBox.Size = New System.Drawing.Size(212, 21)
        Me.VaultsComboBox.TabIndex = 2
        '
        'CheckBox_Recursive
        '
        Me.CheckBox_Recursive.AutoSize = True
        Me.CheckBox_Recursive.Location = New System.Drawing.Point(26, 165)
        Me.CheckBox_Recursive.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CheckBox_Recursive.Name = "CheckBox_Recursive"
        Me.CheckBox_Recursive.Size = New System.Drawing.Size(122, 17)
        Me.CheckBox_Recursive.TabIndex = 3
        Me.CheckBox_Recursive.Text = "Include all Subfolder"
        Me.CheckBox_Recursive.UseVisualStyleBackColor = True
        '
        'dtpFromDate
        '
        Me.dtpFromDate.Location = New System.Drawing.Point(26, 195)
        Me.dtpFromDate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(210, 20)
        Me.dtpFromDate.TabIndex = 4
        '
        'dtpToDate
        '
        Me.dtpToDate.Location = New System.Drawing.Point(26, 227)
        Me.dtpToDate.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(210, 20)
        Me.dtpToDate.TabIndex = 5
        '
        'DestroyDeletedItemsButton
        '
        Me.DestroyDeletedItemsButton.Location = New System.Drawing.Point(24, 263)
        Me.DestroyDeletedItemsButton.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.DestroyDeletedItemsButton.Name = "DestroyDeletedItemsButton"
        Me.DestroyDeletedItemsButton.Size = New System.Drawing.Size(212, 29)
        Me.DestroyDeletedItemsButton.TabIndex = 6
        Me.DestroyDeletedItemsButton.Text = "Destroy Deleted Files"
        Me.DestroyDeletedItemsButton.UseVisualStyleBackColor = True
        '
        'btnCheckDeletedFiles
        '
        Me.btnCheckDeletedFiles.Location = New System.Drawing.Point(357, 48)
        Me.btnCheckDeletedFiles.Name = "btnCheckDeletedFiles"
        Me.btnCheckDeletedFiles.Size = New System.Drawing.Size(257, 40)
        Me.btnCheckDeletedFiles.TabIndex = 7
        Me.btnCheckDeletedFiles.Text = "Check Deleted Files"
        Me.btnCheckDeletedFiles.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(314, 110)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(358, 181)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 367)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCheckDeletedFiles)
        Me.Controls.Add(Me.DestroyDeletedItemsButton)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpFromDate)
        Me.Controls.Add(Me.CheckBox_Recursive)
        Me.Controls.Add(Me.VaultsComboBox)
        Me.Controls.Add(Me.VaultsLabel)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Form1"
        Me.Text = "Destroy Deleted files"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents VaultsLabel As Label
    Friend WithEvents VaultsComboBox As ComboBox
    Friend WithEvents CheckBox_Recursive As CheckBox
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents DestroyDeletedItemsButton As Button
    Friend WithEvents btnCheckDeletedFiles As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
