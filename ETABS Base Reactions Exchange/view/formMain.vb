Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Text.RegularExpressions
Imports CSiAPIv1
Imports ETABSv1

Imports ETABS_Base_Reactions_Exchange.model.Model
Imports ETABS_Base_Reactions_Exchange.controller.Controller
Imports System.Threading
Imports System.Net.Http.Headers
Imports System.Net.Mime
Imports System.ComponentModel
Imports ETABS_Base_Reactions_Exchange.model

''' <summary>
''' IMPORTANT NOTES
'''     - LOAD PATTERNS MUST MATCH LOAD CASES IN THE TWO MODELS
'''     - REMOVE ALL GLOBAL VARIABLES JUST BY USING PROPER DESIGN PATTERNS
'''     - ADD FUNCTION CLOSING ALL CURRENTLY OPEN ETABS INSTANCES
'''     - SORT + BINARY SEARCH FOR GROUPS SEARCHING
'''     - REFACTOR ALL CODE CREATING SETS OF SUPER AND SUB CLASSES USING INHERITANCE
'''       TO DEFINE ALL THEIR PARAMETERS CONTAINING ETABS OUTPUTS (NUMBER GROUPS, NUMBERSTORIES...)
''' 
''' </summary>
''' 



Public Class formMain



    'VARIABLES
    Private i, j, k As Integer                                                                                       'O(1)
    Private tolerance As Double                                                                                      'O(1)
    Private numDecimals As Integer                                                                                   'O(1)

    'ETABS OAPI Utility Variables
    Dim sourceFileName, targetFileName As String
    Dim sourceEtabsModel, targetEtabsModel As ETABSv1.cSapModel
    Dim sourceLoadCasesNum, sourceStoryNumNames, sourceNumStories, sourceNumGroups As Integer                  'O(1)
    Dim targetLoadCasesNum, targetStoryNumNames, targetNumStories, targetNumGroups As Integer                  'O(1)
    Dim selLoadCasesNum, selStoryNumNames, selNumStories, selNumGroups As Integer                              'O(1)
    Dim sourceLoadCaseName, sourceStoryName As String                                                                'O(1)
    Dim targetLoadCaseName, targetStoryName As String                                                                'O(1)
    Dim selLoadCaseName, selStoryName As String                                                                      'O(1)
    Dim sourceLoadCasesNames(), sourceStoryNames(), sourceGroupNames() As String                                     'O(1)
    Dim targetLoadCasesNames(), targetStoryNames(), targetGroupNames() As String                                     'O(1)
    Dim selLoadCasesNames(), selStoryNames(), selGroupNames() As String                                              'O(1)
    Dim ReactPoints_GroupName As String                                                                              'O(1)


    Dim xCoord, yCoord As Integer


    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplashScreen.ShowDialog()
        AboutBox.ShowDialog()
        InitializeForm()
    End Sub


    Private Sub setFormLocation()
        xCoord = Screen.PrimaryScreen.Bounds.Width / 2 - Me.Width / 2
        yCoord = Screen.PrimaryScreen.Bounds.Height / 2 - Me.Height / 2
        Me.SetDesktopLocation(xCoord, yCoord)
    End Sub

    Private Sub btnTransferReactions_Click(sender As Object, e As EventArgs) Handles btnTransferReactions.Click
        Me.lblProgrBar.Text = "Transfer in Progress..."
        Me.lblProgrBar.Visible = True
        Me.Refresh()
        numDecimals = CDbl(cbTolerances.SelectedItem.ToString.Split(".")(1).Length)
        runTransfer()
    End Sub

    Private Sub lbTolerance_SelectedIndexChanged(sender As Object, e As EventArgs)
        tolerance = CDbl(Me.cbTolerances.SelectedItem)
    End Sub


    Private Sub btnOpenSourceFile_Click(sender As Object, e As EventArgs) Handles btnOpenSourceFile.Click

        sourceFileName = getSelectedFile("Select Source Etabs File")
        extractDataSourceFile()

        If ((sourceFileName <> "")) Then
            Me.btnOpenTargetFile.Enabled = True
            Me.btnOpenSourceFile.Enabled = False
        End If

    End Sub

    Private Sub btnOpenTargetFile_Click(sender As Object, e As EventArgs) Handles btnOpenTargetFile.Click

        targetFileName = getSelectedFile("Select Target Etabs File")

        If ((sourceFileName <> "") And (targetFileName <> "")) Then
            Me.btnTransferReactions.Enabled = True
            Me.btnOpenTargetFile.Enabled = False
        End If
    End Sub


    Private Sub InitializeForm()

        Me.cklbStories.Items.Clear()
        Me.cklbLoadCases.Items.Clear()
        Me.cbTolerances.SelectedItem = Me.cbTolerances.Items(2)
        Me.btnOpenTargetFile.Enabled = False
        Me.btnTransferReactions.Enabled = False
        Me.lblProgrBar.Visible = False
        Me.setFormLocation()

    End Sub


    Private Function getSelectedFile(dialogTitle As String) As String

        Dim fileName As String = Nothing

        With ofdEtabsSourceFile
            .Title = dialogTitle
            .InitialDirectory = "C:\"
            .Multiselect = False
            .Filter = "Etabs Files|*.edb"
            Dim dialogResult As DialogResult = .ShowDialog()
            If dialogResult = Windows.Forms.DialogResult.OK Then
                fileName = .FileName
            End If
        End With

        Return fileName

    End Function




    Private Sub extractDataSourceFile()

        With ETABSConnector.getInstance()
            'Initialize ETABS Session
            .initialize()
            'Set ETABS to Invisible
            .setEtabsVisibility(False)
            'Open New ETABS Session
            .getEtabsApp.ApplicationStart()
            'Construct ETABS Model Object
            sourceEtabsModel = .getEtabsApp.SapModel
        End With

        With sourceEtabsModel
            .InitializeNewModel()
            .File.OpenFile(sourceFileName)
            .View.RefreshView()
        End With

        Dim pullModelLoadCases As New PullLoadCases(sourceEtabsModel)
        Dim loadCases As List(Of LoadCase)
        loadCases = pullModelLoadCases.pull()


        With Me.cklbLoadCases
            .CheckOnClick = True
            .Items.AddRange(loadCases.Select(Of String)(Function(lcase) lcase.getLoadCaseName()).ToArray())
            .ClearSelected()
        End With


        Dim pullStoreys As New PullStoreys(sourceEtabsModel)
        Dim storeys As List(Of Storey)
        storeys = pullStoreys.pull()

        With Me.cklbStories
            .SelectionMode = SelectionMode.One
            .CheckOnClick = True
            .Items.AddRange(storeys.Select(Of String)(Function(storey) storey.getName()).ToArray())
            .ClearSelected()
        End With


        'EXTRACT GROUP NAMES


        ret = sourceEtabsModel.GroupDef.GetNameList(sourceNumGroups, sourceGroupNames)

        With Me.cklbGroups
            .CheckOnClick = True
            .Items.AddRange(sourceGroupNames)
            .ClearSelected()
        End With



    End Sub








    Private Sub runTransfer()

    End Sub

End Class







