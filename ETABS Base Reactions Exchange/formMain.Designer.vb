<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formMain))
        Me.ofdEtabsSourceFile = New System.Windows.Forms.OpenFileDialog()
        Me.ofdEtabsTargetFile = New System.Windows.Forms.OpenFileDialog()
        Me.btnOpenSourceFile = New System.Windows.Forms.Button()
        Me.btnOpenTargetFile = New System.Windows.Forms.Button()
        Me.cklbLoadCases = New System.Windows.Forms.CheckedListBox()
        Me.lblLoadCases = New System.Windows.Forms.Label()
        Me.btnTransferReactions = New System.Windows.Forms.Button()
        Me.cklbStories = New System.Windows.Forms.CheckedListBox()
        Me.lblStories = New System.Windows.Forms.Label()
        Me.lblTolerance = New System.Windows.Forms.Label()
        Me.cbTolerances = New System.Windows.Forms.ComboBox()
        Me.lblTolUnits = New System.Windows.Forms.Label()
        Me.cklbGroups = New System.Windows.Forms.CheckedListBox()
        Me.lblGroups = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ofdEtabsSourceFile
        '
        Me.ofdEtabsSourceFile.FileName = "ofdEtabsSourceFile"
        '
        'ofdEtabsTargetFile
        '
        Me.ofdEtabsTargetFile.FileName = "ofdEtabsTargetFile"
        '
        'btnOpenSourceFile
        '
        Me.btnOpenSourceFile.Location = New System.Drawing.Point(45, 49)
        Me.btnOpenSourceFile.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOpenSourceFile.Name = "btnOpenSourceFile"
        Me.btnOpenSourceFile.Size = New System.Drawing.Size(165, 41)
        Me.btnOpenSourceFile.TabIndex = 0
        Me.btnOpenSourceFile.Text = "ETABS Source File"
        Me.btnOpenSourceFile.UseVisualStyleBackColor = True
        '
        'btnOpenTargetFile
        '
        Me.btnOpenTargetFile.Location = New System.Drawing.Point(225, 49)
        Me.btnOpenTargetFile.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOpenTargetFile.Name = "btnOpenTargetFile"
        Me.btnOpenTargetFile.Size = New System.Drawing.Size(165, 41)
        Me.btnOpenTargetFile.TabIndex = 1
        Me.btnOpenTargetFile.Text = "ETABS Target File"
        Me.btnOpenTargetFile.UseVisualStyleBackColor = True
        '
        'cklbLoadCases
        '
        Me.cklbLoadCases.FormattingEnabled = True
        Me.cklbLoadCases.Location = New System.Drawing.Point(45, 388)
        Me.cklbLoadCases.Margin = New System.Windows.Forms.Padding(4)
        Me.cklbLoadCases.Name = "cklbLoadCases"
        Me.cklbLoadCases.Size = New System.Drawing.Size(345, 123)
        Me.cklbLoadCases.TabIndex = 2
        '
        'lblLoadCases
        '
        Me.lblLoadCases.AutoSize = True
        Me.lblLoadCases.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLoadCases.Location = New System.Drawing.Point(42, 361)
        Me.lblLoadCases.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLoadCases.Name = "lblLoadCases"
        Me.lblLoadCases.Size = New System.Drawing.Size(98, 20)
        Me.lblLoadCases.TabIndex = 4
        Me.lblLoadCases.Text = "LOAD CASES"
        '
        'btnTransferReactions
        '
        Me.btnTransferReactions.Location = New System.Drawing.Point(124, 584)
        Me.btnTransferReactions.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTransferReactions.Name = "btnTransferReactions"
        Me.btnTransferReactions.Size = New System.Drawing.Size(192, 47)
        Me.btnTransferReactions.TabIndex = 6
        Me.btnTransferReactions.Text = "TRANSFER REACTIONS"
        Me.btnTransferReactions.UseVisualStyleBackColor = True
        '
        'cklbStories
        '
        Me.cklbStories.FormattingEnabled = True
        Me.cklbStories.Location = New System.Drawing.Point(45, 137)
        Me.cklbStories.Margin = New System.Windows.Forms.Padding(4)
        Me.cklbStories.Name = "cklbStories"
        Me.cklbStories.Size = New System.Drawing.Size(345, 89)
        Me.cklbStories.TabIndex = 7
        '
        'lblStories
        '
        Me.lblStories.AutoSize = True
        Me.lblStories.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStories.Location = New System.Drawing.Point(43, 113)
        Me.lblStories.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStories.Name = "lblStories"
        Me.lblStories.Size = New System.Drawing.Size(71, 20)
        Me.lblStories.TabIndex = 8
        Me.lblStories.Text = "STOREYS"
        '
        'lblTolerance
        '
        Me.lblTolerance.AutoSize = True
        Me.lblTolerance.Location = New System.Drawing.Point(49, 538)
        Me.lblTolerance.Name = "lblTolerance"
        Me.lblTolerance.Size = New System.Drawing.Size(161, 16)
        Me.lblTolerance.TabIndex = 9
        Me.lblTolerance.Text = "Joints Location Tolerance"
        '
        'cbTolerances
        '
        Me.cbTolerances.FormattingEnabled = True
        Me.cbTolerances.Items.AddRange(New Object() {"0.1", "0.01", "0.001", "0.0001", "0.00001", "0.000001", "0.00000001"})
        Me.cbTolerances.Location = New System.Drawing.Point(216, 535)
        Me.cbTolerances.Name = "cbTolerances"
        Me.cbTolerances.Size = New System.Drawing.Size(143, 24)
        Me.cbTolerances.TabIndex = 11
        '
        'lblTolUnits
        '
        Me.lblTolUnits.AutoSize = True
        Me.lblTolUnits.Location = New System.Drawing.Point(365, 538)
        Me.lblTolUnits.Name = "lblTolUnits"
        Me.lblTolUnits.Size = New System.Drawing.Size(26, 16)
        Me.lblTolUnits.TabIndex = 12
        Me.lblTolUnits.Text = "[m]"
        '
        'cklbGroups
        '
        Me.cklbGroups.FormattingEnabled = True
        Me.cklbGroups.Location = New System.Drawing.Point(45, 268)
        Me.cklbGroups.Margin = New System.Windows.Forms.Padding(4)
        Me.cklbGroups.Name = "cklbGroups"
        Me.cklbGroups.Size = New System.Drawing.Size(345, 89)
        Me.cklbGroups.TabIndex = 13
        '
        'lblGroups
        '
        Me.lblGroups.AutoSize = True
        Me.lblGroups.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblGroups.Location = New System.Drawing.Point(41, 239)
        Me.lblGroups.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGroups.Name = "lblGroups"
        Me.lblGroups.Size = New System.Drawing.Size(69, 20)
        Me.lblGroups.TabIndex = 14
        Me.lblGroups.Text = "GROUPS"
        '
        'formMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 664)
        Me.Controls.Add(Me.lblGroups)
        Me.Controls.Add(Me.cklbGroups)
        Me.Controls.Add(Me.lblTolUnits)
        Me.Controls.Add(Me.cbTolerances)
        Me.Controls.Add(Me.lblTolerance)
        Me.Controls.Add(Me.lblStories)
        Me.Controls.Add(Me.cklbStories)
        Me.Controls.Add(Me.btnTransferReactions)
        Me.Controls.Add(Me.lblLoadCases)
        Me.Controls.Add(Me.cklbLoadCases)
        Me.Controls.Add(Me.btnOpenTargetFile)
        Me.Controls.Add(Me.btnOpenSourceFile)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "formMain"
        Me.Text = "ETABS Reactions Transfer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ofdEtabsSourceFile As OpenFileDialog
    Friend WithEvents ofdEtabsTargetFile As OpenFileDialog
    Friend WithEvents btnOpenSourceFile As Button
    Friend WithEvents btnOpenTargetFile As Button
    Friend WithEvents cklbLoadCases As CheckedListBox
    Friend WithEvents lblLoadCases As Label
    Friend WithEvents btnTransferReactions As Button
    Friend WithEvents cklbStories As CheckedListBox
    Friend WithEvents lblStories As Label
    Friend WithEvents lblTolerance As Label
    Friend WithEvents cbTolerances As ComboBox
    Friend WithEvents lblTolUnits As Label
    Friend WithEvents cklbGroups As CheckedListBox
    Friend WithEvents lblGroups As Label
End Class
