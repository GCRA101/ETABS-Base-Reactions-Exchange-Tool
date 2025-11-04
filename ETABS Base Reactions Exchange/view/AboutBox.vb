' AboutBox: dialog showing product/version/company info
Public NotInheritable Class AboutBox

    ' Centering coordinates for the dialog
    Private xCoord, yCoord As Integer

    ' Initialize and populate AboutBox controls on load
    Private Sub AboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.lblProductName.Text = My.Application.Info.ProductName
        Me.lblVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.lblCopyRight.Text = My.Application.Info.Copyright
        Me.lblCompanyName.Text = My.Application.Info.CompanyName
        'Me.txtDescription.Text = My.Application.Info.Description
        Me.txtDescription.Text = System.IO.File.ReadAllText(My.Application.Info.DirectoryPath.Replace("\bin\Debug", "") + "\docs\" + "AboutBoxDescription.txt")


        ' Compute center position and move dialog to screen center
        xCoord = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2
        yCoord = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 2

        Me.SetDesktopLocation(xCoord, yCoord)



    End Sub

    ' Handle dialog closed event; ensure application exits if dialog was visible
    Private Sub AboutBox_Closing(sender As Object, e As EventArgs) Handles Me.Closed
        If Me.Visible = True Then
            End
        End If
    End Sub

    ' OK button closes dialog and returns to main form
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close()
        Me.Dispose()
        formMain.Visible = True
    End Sub


End Class
