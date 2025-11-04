'SplashScreen: brief startup splash displayed before main form loads
Imports System.Threading

Public NotInheritable Class SplashScreen

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).

    ' Centering coordinates
    Private xCoord, yCoord As Integer


    ' Initialize splash content and show for a short delay
    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        ' Populate version and copyright/company info
        lblVersion.Text = System.String.Format(lblVersion.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Copyright info
        lblCopyright.Text = My.Application.Info.Copyright

        'Company Info
        lblCompany.Text = My.Application.Info.CompanyName

        ' Center the splash on screen
        xCoord = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2
        yCoord = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 2

        Me.SetDesktopLocation(xCoord, yCoord)

        ' Display briefly and close
        Me.Visible = True
        Me.Refresh()

        Thread.Sleep(5000)

        Me.Close()
        Me.Dispose()


    End Sub

End Class
