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
        Me.btnOpenSourceFile.Location = New System.Drawing.Point(34, 40)
        Me.btnOpenSourceFile.Name = "btnOpenSourceFile"
        Me.btnOpenSourceFile.Size = New System.Drawing.Size(124, 33)
        Me.btnOpenSourceFile.TabIndex = 0
        Me.btnOpenSourceFile.Text = "ETABS Source File"
        Me.btnOpenSourceFile.UseVisualStyleBackColor = True
        '
        'btnOpenTargetFile
        '
        Me.btnOpenTargetFile.Location = New System.Drawing.Point(169, 40)
        Me.btnOpenTargetFile.Name = "btnOpenTargetFile"
        Me.btnOpenTargetFile.Size = New System.Drawing.Size(124, 33)
        Me.btnOpenTargetFile.TabIndex = 1
        Me.btnOpenTargetFile.Text = "ETABS Target File"
        Me.btnOpenTargetFile.UseVisualStyleBackColor = True
        '
        'cklbLoadCases
        '
        Me.cklbLoadCases.FormattingEnabled = True
        Me.cklbLoadCases.Location = New System.Drawing.Point(34, 315)
        Me.cklbLoadCases.Name = "cklbLoadCases"
        Me.cklbLoadCases.Size = New System.Drawing.Size(260, 94)
        Me.cklbLoadCases.TabIndex = 2
        '
        'lblLoadCases
        '
        Me.lblLoadCases.AutoSize = True
        Me.lblLoadCases.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLoadCases.Location = New System.Drawing.Point(32, 293)
        Me.lblLoadCases.Name = "lblLoadCases"
        Me.lblLoadCases.Size = New System.Drawing.Size(77, 15)
        Me.lblLoadCases.TabIndex = 4
        Me.lblLoadCases.Text = "LOAD CASES"
        '
        'btnTransferReactions
        '
        Me.btnTransferReactions.Location = New System.Drawing.Point(93, 474)
        Me.btnTransferReactions.Name = "btnTransferReactions"
        Me.btnTransferReactions.Size = New System.Drawing.Size(144, 38)
        Me.btnTransferReactions.TabIndex = 6
        Me.btnTransferReactions.Text = "TRANSFER REACTIONS"
        Me.btnTransferReactions.UseVisualStyleBackColor = True
        '
        'cklbStories
        '
        Me.cklbStories.FormattingEnabled = True
        Me.cklbStories.Location = New System.Drawing.Point(34, 111)
        Me.cklbStories.Name = "cklbStories"
        Me.cklbStories.Size = New System.Drawing.Size(260, 64)
        Me.cklbStories.TabIndex = 7
        '
        'lblStories
        '
        Me.lblStories.AutoSize = True
        Me.lblStories.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStories.Location = New System.Drawing.Point(32, 92)
        Me.lblStories.Name = "lblStories"
        Me.lblStories.Size = New System.Drawing.Size(58, 15)
        Me.lblStories.TabIndex = 8
        Me.lblStories.Text = "STOREYS"
        '
        'lblTolerance
        '
        Me.lblTolerance.AutoSize = True
        Me.lblTolerance.Location = New System.Drawing.Point(37, 437)
        Me.lblTolerance.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTolerance.Name = "lblTolerance"
        Me.lblTolerance.Size = New System.Drawing.Size(129, 13)
        Me.lblTolerance.TabIndex = 9
        Me.lblTolerance.Text = "Joints Location Tolerance"
        '
        'cbTolerances
        '
        Me.cbTolerances.FormattingEnabled = True
        Me.cbTolerances.Items.AddRange(New Object() {"0.1", "0.01", "0.001", "0.0001", "0.00001", "0.000001", "0.00000001"})
        Me.cbTolerances.Location = New System.Drawing.Point(162, 435)
        Me.cbTolerances.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbTolerances.Name = "cbTolerances"
        Me.cbTolerances.Size = New System.Drawing.Size(108, 21)
        Me.cbTolerances.TabIndex = 11
        '
        'lblTolUnits
        '
        Me.lblTolUnits.AutoSize = True
        Me.lblTolUnits.Location = New System.Drawing.Point(274, 437)
        Me.lblTolUnits.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTolUnits.Name = "lblTolUnits"
        Me.lblTolUnits.Size = New System.Drawing.Size(21, 13)
        Me.lblTolUnits.TabIndex = 12
        Me.lblTolUnits.Text = "[m]"
        '
        'cklbGroups
        '
        Me.cklbGroups.FormattingEnabled = True
        Me.cklbGroups.Location = New System.Drawing.Point(34, 218)
        Me.cklbGroups.Name = "cklbGroups"
        Me.cklbGroups.Size = New System.Drawing.Size(260, 64)
        Me.cklbGroups.TabIndex = 13
        '
        'lblGroups
        '
        Me.lblGroups.AutoSize = True
        Me.lblGroups.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblGroups.Location = New System.Drawing.Point(31, 194)
        Me.lblGroups.Name = "lblGroups"
        Me.lblGroups.Size = New System.Drawing.Size(56, 15)
        Me.lblGroups.TabIndex = 14
        Me.lblGroups.Text = "GROUPS"
        '
        'formMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 540)
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
