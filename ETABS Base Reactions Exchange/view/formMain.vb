Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Text.RegularExpressions
Imports CSiAPIv1

''' <summary>
''' IMPORTANT NOTES
'''     - MATCHING LEVELS MUST HAVE THE SAME NAME IN THE TWO MODELS
'''     - LOAD PATTERNS MUST MATCH LOAD CASES IN THE TWO MODELS
'''     - REMOVE ALL GLOBAL VARIABLES JUST BY USING PROPER DESIGN PATTERNS
'''     - ADD FUNCTION CLOSING ALL CURRENTLY OPEN ETABS INSTANCES
'''     - SORT + BINARY SEARCH FOR GROUPS SEARCHING
'''     - REFACTOR ALL CODE CREATING SETS OF SUPER AND SUB CLASSES USING INHERITANCE
'''       TO DEFINE ALL THEIR PARAMETERS CONTAINING ETABS OUTPUTS (NUMBER GROUPS, NUMBERSTORIES...)
'''     - ADD SPLASHSCREEN AND FRONT WINDOW FOR THE APP    
''' 
''' </summary>
''' 



Public Class formMain

    Public sourceFileName, targetFileName As String

    'VARIABLES
    Private ret As Integer                                                                                           'O(1)
    Private i, j, k As Integer                                                                                       'O(1)
    Private tolerance As Double                                                                                      'O(1)
    Private numDecimals As Integer                                                                                   'O(1)
    'ETABS OAPI Interoperability Variables
    Private HelperObject As ETABSv1.cHelper   ' Helper Class Object Variable                                         'O(1)
    Private ETABSApp As ETABSv1.cOAPI         ' ETABS Application Object Variable                                    'O(1)
    Private sourceEtabsModel As ETABSv1.cSapModel  ' ETABS Model Object Variable                                     'O(1)
    Private targetEtabsModel As ETABSv1.cSapModel  ' Target ETABS Model Object Variable                              'O(1)
    'ETABS OAPI Utility Variables
    Dim sourceLoadCasesNum, sourceStoryNumNames, sourceNumberStories, sourceNumberGroups As Integer                  'O(1)
    Dim targetLoadCasesNum, targetStoryNumNames, targetNumberStories, targetNumberGroups As Integer                  'O(1)
    Dim selLoadCasesNum, selStoryNumNames, selNumberStories, selNumberGroups As Integer                              'O(1)
    Dim sourceLoadCaseName, sourceStoryName As String                                                                'O(1)
    Dim targetLoadCaseName, targetStoryName As String                                                                'O(1)
    Dim selLoadCaseName, selStoryName As String                                                                      'O(1)
    Dim sourceLoadCasesNames(), sourceStoryNames(), sourceGroupNames() As String                                     'O(1)
    Dim targetLoadCasesNames(), targetStoryNames(), targetGroupNames() As String                                     'O(1)
    Dim selLoadCasesNames(), selStoryNames(), selGroupNames() As String                                              'O(1)
    Dim ReactPoints_GroupName As String                                                                              'O(1)
    Const etabsVisibility As Boolean = False                                                                         'O(1)



    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeForm()
        InitializeETABS()
    End Sub



    Private Sub btnTransferReactions_Click(sender As Object, e As EventArgs) Handles btnTransferReactions.Click
        numDecimals = CDbl(Me.cbTolerances.SelectedItem.ToString.Split(".")(1).Length)
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



    Private Sub InitializeETABS()

        'ETABS OAPI Variables Assignment

        'Helper Class Object Variable
        HelperObject = New ETABSv1.Helper                                                                            'O(1)
        'ETABS Application Object Variable                                                                           'O(1)
        ETABSApp = Nothing                                                                                           'O(1)
        ETABSApp = HelperObject.CreateObjectProgID("CSI.ETABS.API.ETABSObject")                                      'O(1)
        'ETABSApp = HelperObject.CreateObject("c:\Program Files\Computers and Structures\ETABS 20\ETABS.exe")        'O(1)
        'ETABSApp = HelperObject.GetObject("CSI.ETABS.API.ETABSObject")                                              'O(1)

    End Sub

    Private Sub lblGroups_Click(sender As Object, e As EventArgs) Handles lblGroups.Click

    End Sub

    Private Sub InitializeForm()

        Me.cklbStories.Items.Clear()
        Me.cklbLoadCases.Items.Clear()
        Me.cbTolerances.SelectedItem = Me.cbTolerances.Items(2)
        Me.btnOpenTargetFile.Enabled = False
        Me.btnTransferReactions.Enabled = False

    End Sub

    Private Sub setEtabsVisibility()
        If Not etabsVisibility Then
            ret = ETABSApp.Hide()
        End If
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


    Private Function setNewFilePath(filePath As String) As String
        Dim newFilePath As String
        Dim dateObj As Date = Date.Today

        Dim sep() As Char = {"/", "\", "//"}

        With dateObj
            newFilePath = filePath.Remove(filePath.IndexOf(filePath.Split(sep).Last())) + "BRE" +
                            .Year.ToString + .Month.ToString("D2") +
                            .Day.ToString("D2") + "_" + filePath.Split(sep).Last()
        End With

        Return newFilePath

    End Function


    Private Sub extractDataSourceFile()

        'Open ETABS Application
        ret = ETABSApp.ApplicationStart()

        'Show/Hide ETABS Application
        setEtabsVisibility()


        ''ETABS Model Object Variable
        sourceEtabsModel = ETABSApp.SapModel                                                              'O(1)

        sourceEtabsModel.InitializeNewModel()

        ret = sourceEtabsModel.File.OpenFile(sourceFileName)

        ret = sourceEtabsModel.View.RefreshView

        ret = sourceEtabsModel.SetModelIsLocked(False)

        ret = sourceEtabsModel.LoadCases.GetNameList(sourceLoadCasesNum, sourceLoadCasesNames)

        With Me.cklbLoadCases
            .CheckOnClick = True
            .Items.AddRange(sourceLoadCasesNames)
            .ClearSelected()
        End With



        Dim similarToStory() As String
        Dim isMasterStory() As Boolean
        Dim storyElevations(), storyHeights(), spliceHeight() As Double
        Dim sourceIsMasterStory(), spliceAbove() As Boolean

        'EXTRACT STORY NAMES

        ret = sourceEtabsModel.Story.GetStories(sourceNumberStories, sourceStoryNames, storyElevations,
                                                storyHeights, isMasterStory, similarToStory,
                                                spliceAbove, spliceHeight)

        With Me.cklbStories
            .SelectionMode = SelectionMode.One
            .CheckOnClick = True
            .Items.AddRange(sourceStoryNames)
            .ClearSelected()
        End With


        'EXTRACT GROUP NAMES


        ret = sourceEtabsModel.GroupDef.GetNameList(sourceNumberGroups, sourceGroupNames)

        With Me.cklbGroups
            .CheckOnClick = True
            .Items.AddRange(sourceGroupNames)
            .ClearSelected()
        End With



    End Sub


    Private Sub createGroupForReactionPoints()

        'Variables Declaration
        Dim Group_Found As Boolean

        Dim GroupObjs_Num As Long
        Dim GroupObjs_Type() As Integer
        Dim GroupObjs_Name() As String

        'Group Name Assignment
        ReactPoints_GroupName = "Reaction Points"
        'Existing Groups Names List Extraction
        ret = targetEtabsModel.GroupDef.GetNameList(targetNumberGroups, targetGroupNames)

        'Control Parameter Initialization
        Group_Found = False

        'Checking whether the reaction points group already exists...
        For i = 0 To UBound(targetGroupNames) Step 1
            If ReactPoints_GroupName = targetGroupNames(i) Then
                Group_Found = True
            End If
        Next


        'Reaction Points Group Creation/Re-Setting
        If Group_Found = True Then
            'If the Group already exists...
            'Get Objects and Number of Objects assigned to the Group
            ret = targetEtabsModel.GroupDef.GetAssignments(ReactPoints_GroupName, GroupObjs_Num, GroupObjs_Type, GroupObjs_Name)
            If GroupObjs_Num <> 0 Then
                'If the Group contains elements...
                'Select the elements belonging to the Group and REMOVE them from the ReactPoints Group
                With targetEtabsModel
                    'Select the Objects belonging to the Group
                    ret = .SelectObj.Group(ReactPoints_GroupName, False)
                    'Area Objects - Group Assignment Removal
                    ret = .AreaObj.SetGroupAssign("", ReactPoints_GroupName, True, eItemType.SelectedObjects)
                    'Frame Objects - Group Assignment Removal
                    ret = .FrameObj.SetGroupAssign("", ReactPoints_GroupName, True, eItemType.SelectedObjects)
                    'Point Objects - Group Assignment Removal
                    ret = .PointObj.SetGroupAssign("", ReactPoints_GroupName, True, eItemType.SelectedObjects)
                End With
            End If
        Else
            'If it doesn't exist already, it gets created from scratch
            ret = targetEtabsModel.GroupDef.SetGroup(ReactPoints_GroupName)
        End If
    End Sub


    Private Sub pushMissingLoadCases(loadCasesNames As String())

        Dim lcNum As Integer
        Dim lcNames() As String
        Dim lpType As ETABSv1.eLoadPatternType
        Dim swtMultiplier As Double


        For Each selLoadCaseName In selLoadCasesNames
            For Each sourceLoadCaseName In sourceLoadCasesNames
                If selLoadCaseName = sourceLoadCaseName Then
                    ret = sourceEtabsModel.LoadPatterns.GetLoadType(selLoadCaseName, lpType)
                    ret = sourceEtabsModel.LoadPatterns.GetSelfWTMultiplier(selLoadCaseName, swtMultiplier)
                    ret = targetEtabsModel.LoadPatterns.Add(selLoadCaseName, lpType, swtMultiplier, True)
                End If
            Next

        Next

    End Sub


    Private Sub runTransfer()

        'Get the selected Load Cases
        ReDim selLoadCasesNames(Me.cklbLoadCases.CheckedItems.Count - 1)
        For i = 0 To (Me.cklbLoadCases.CheckedItems.Count - 1) Step 1
            selLoadCasesNames(i) = CStr(Me.cklbLoadCases.CheckedItems(i))
        Next

        'Get the selected Stories
        ReDim selStoryNames(Me.cklbStories.CheckedItems.Count - 1)
        For i = 0 To (Me.cklbStories.CheckedItems.Count - 1) Step 1
            selStoryNames(i) = CStr(Me.cklbStories.CheckedItems(i))
        Next

        'Get the selected Groups
        ReDim selGroupNames(Me.cklbGroups.CheckedItems.Count - 1)
        For i = 0 To (Me.cklbGroups.CheckedItems.Count - 1) Step 1
            selGroupNames(i) = CStr(Me.cklbGroups.CheckedItems(i))
        Next

        'Set Load Cases to Run
        ret = sourceEtabsModel.Analyze.SetRunCaseFlag("", False, True)
        For Each selLoadCaseName In selLoadCasesNames
            ret = sourceEtabsModel.Analyze.SetRunCaseFlag(selLoadCaseName, True)
        Next

        ret = sourceEtabsModel.Analyze.RunAnalysis



        Dim baseJointsData As JointData()

        Dim Name As String
        Dim ItemTypeElm As ETABSv1.eItemTypeElm
        Dim NumberResults As Integer
        Dim Obj, Elm, LoadCase, StepType As String()
        Dim StepNum As Double()
        Dim F1, F2, F3, M1, M2, M3 As Double()
        Dim ppX, ppY, ppZ As Double
        Dim ppMatch As Boolean


        Dim ppNumberNames As Integer
        Dim ppNames As String()
        Dim targetppNamesByStoryList As List(Of String()) = New List(Of String())
        Dim sourcePPNamesByStoryList As List(Of String()) = New List(Of String())


        For Each selStoryName In selStoryNames
            ret = sourceEtabsModel.PointObj.GetNameListOnStory(selStoryName, ppNumberNames, ppNames)
            sourcePPNamesByStoryList.Add(ppNames)
        Next


        Dim numGroups As Integer, ppGroups() As String
        Dim groupFound As Boolean
        Dim ppNamesByGroupList As List(Of String) = New List(Of String)


        For Each dataRow As String() In sourcePPNamesByStoryList
            For Each ppName In dataRow
                ret = sourceEtabsModel.PointObj.GetGroupAssign(ppName, numGroups, ppGroups)
                For Each ppGroup In ppGroups
                    groupFound = False
                    For Each selGroupName In selGroupNames
                        If ppGroup = selGroupName Then
                            groupFound = True
                            ppNamesByGroupList.Add(ppName)
                            Exit For
                        End If
                    Next
                    If groupFound = True Then
                        Exit For
                    End If
                Next
            Next
        Next


        ppNumberNames = ppNamesByGroupList.Count
        ppNames = ppNamesByGroupList.ToArray()

        ReDim baseJointsData(ppNumberNames - 1)

        ret = sourceEtabsModel.Results.Setup.DeselectAllCasesAndCombosForOutput


        For Each selLoadCaseName In selLoadCasesNames
            ret = sourceEtabsModel.Results.Setup.SetCaseSelectedForOutput(selLoadCaseName, True)
        Next

        For i = 0 To UBound(ppNames) Step 1
            ret = sourceEtabsModel.Results.JointReact(ppNames(i), ItemTypeElm, NumberResults, Obj, Elm, LoadCase,
                                             StepType, StepNum, F1, F2, F3, M1, M2, M3)
            ret = sourceEtabsModel.PointObj.GetCoordCartesian(ppNames(i), ppX, ppY, ppZ)

            baseJointsData(i) = New JointData()

            With baseJointsData(i)
                .setName(ppNames(i))
                .setItemTypeElm(ItemTypeElm)
                .setNumberResults(NumberResults)
                .setObj(Obj)
                .setElm(Elm)
                .setLoadCases(LoadCase)
                .setStepType(StepType)
                .setStepNum(StepNum)
                .setX(ppX)
                .setY(ppY)
                .setZ(ppZ)
                .setF1(F1)
                .setF2(F2)
                .setF3(F3)
                .setM1(M1)
                .setM2(M2)
                .setM3(M3)
            End With

        Next

        targetEtabsModel = ETABSApp.SapModel

        targetEtabsModel.InitializeNewModel()

        ret = targetEtabsModel.File.OpenFile(targetFileName)

        ret = targetEtabsModel.View.RefreshView

        ret = targetEtabsModel.SetModelIsLocked(False)


        pushMissingLoadCases(selLoadCasesNames)

        createGroupForReactionPoints()

        For Each selStoryName In selStoryNames
            ret = targetEtabsModel.PointObj.GetNameListOnStory(selStoryName, ppNumberNames, ppNames)
            targetPPNamesByStoryList.Add(ppNames)
        Next



        For Each bjd As JointData In baseJointsData
            For Each dataRow As String() In targetppNamesByStoryList
                For i = 0 To dataRow.Count - 1 Step 1

                    ppMatch = False

                    ret = targetEtabsModel.PointObj.GetCoordCartesian(dataRow(i), ppX, ppY, ppZ)

                    ppX = Math.Round(ppX, numDecimals)
                    ppY = Math.Round(ppY, numDecimals)
                    ppZ = Math.Round(ppZ, numDecimals)

                    If ((Math.Round(bjd.getX(), numDecimals) = ppX) And (Math.Round(bjd.getY()) = ppY) And (Math.Round(bjd.getZ()) = ppZ)) Then
                        ppMatch = True
                        For j = 0 To UBound(bjd.getLoadCases) Step 1
                            Dim pointForces() As Double = {bjd.getF1(j) * (-1), bjd.getF2(j) * (-1), bjd.getF3(j) * (-1),
                                                           bjd.getM1(j) * (-1), bjd.getM2(j) * (-1), bjd.getM3(j) * (-1)}
                            ret = targetEtabsModel.PointObj.SetLoadForce(dataRow(i), bjd.getLoadCases()(j), pointForces, True)
                            ret = targetEtabsModel.PointObj.SetGroupAssign(dataRow(i), ReactPoints_GroupName, False, eItemType.Objects)
                        Next
                        Exit For
                    End If
                Next

                If ppMatch = False Then
                    Dim ppNewName As String = bjd.getName + "0000"
                    ret = targetEtabsModel.PointObj.AddCartesian(bjd.getX, bjd.getY, bjd.getZ, ppNewName)
                    For k = 0 To UBound(bjd.getLoadCases) Step 1
                        Dim pointForces() As Double = {bjd.getF1(k) * (-1), bjd.getF2(k) * (-1), bjd.getF3(k) * (-1),
                                                       bjd.getM1(k) * (-1), bjd.getM2(k) * (-1), bjd.getM3(k) * (-1)}
                        ret = targetEtabsModel.PointObj.SetLoadForce(ppNewName, bjd.getLoadCases(k), pointForces, True)
                        ret = targetEtabsModel.PointObj.SetGroupAssign(ppNewName, ReactPoints_GroupName, False, eItemType.Objects)
                    Next
                End If
            Next
        Next


        'SAVE THE MODEL
        targetEtabsModel.File.Save(setNewFilePath(targetFileName))

        'CLOSE ETABS APPLICATION
        ETABSApp.ApplicationExit(False)

        'MEMORY RELEASE
        sourceEtabsModel = Nothing                                                               'O(1)
        targetEtabsModel = Nothing
        ETABSApp = Nothing                                                                       'O(1)

        'CLOSE AND DISPOSE FORM
        Me.Close()
        Me.Dispose()

    End Sub

End Class




Public Class JointData

    'ATTRIBUTES
    Private Property Name As String
    Private Property ItemTypeElm As ETABSv1.eItemTypeElm
    Private Property NumberResults As Integer
    Private Property Obj As String()
    Private Property Elm As String()
    Private Property LoadCase As String()
    Private Property StepType As String()
    Private Property StepNum As Double()
    Private Property x As Double
    Private Property y As Double
    Private Property z As Double
    Private Property F1 As Double()
    Private Property F2 As Double()
    Private Property F3 As Double()
    Private Property M1 As Double()
    Private Property M2 As Double()
    Private Property M3 As Double()


    'CONSTRUCTOR
    'Default Constructor applies


    'GETTERS AND SETTERS

    'Setters
    Public Sub setName(Name As String)
        Me.Name = Name
    End Sub
    Public Sub setItemTypeElm(itemTypeElm As ETABSv1.eItemTypeElm)
        Me.ItemTypeElm = itemTypeElm
    End Sub
    Public Sub setNumberResults(NumberResults As Integer)
        Me.NumberResults = NumberResults
    End Sub
    Public Sub setObj(Obj As String())
        Me.Obj = Obj
    End Sub
    Public Sub setElm(Elm As String())
        Me.Elm = Elm
    End Sub
    Public Sub setLoadCases(LoadCase As String())
        Me.LoadCase = LoadCase
    End Sub
    Public Sub setStepType(StepType As String())
        Me.StepType = StepType
    End Sub
    Public Sub setStepNum(StepNum As Double())
        Me.StepNum = StepNum
    End Sub
    Public Sub setX(x As Double)
        Me.x = x
    End Sub
    Public Sub setY(y As Double)
        Me.y = y
    End Sub
    Public Sub setZ(z As Double)
        Me.z = z
    End Sub
    Public Sub setF1(F1 As Double())
        Me.F1 = F1
    End Sub
    Public Sub setF2(F2 As Double())
        Me.F2 = F2
    End Sub
    Public Sub setF3(F3 As Double())
        Me.F3 = F3
    End Sub
    Public Sub setM1(M1 As Double())
        Me.M1 = M1
    End Sub
    Public Sub setM2(M2 As Double())
        Me.M2 = M2
    End Sub
    Public Sub setM3(M3 As Double())
        Me.M3 = M3
    End Sub

    'Getters
    Public Function getName() As String
        Return Me.Name
    End Function
    Public Function getItemTypeElm() As ETABSv1.eItemTypeElm
        Return Me.ItemTypeElm
    End Function
    Public Function getNumberResults() As Integer
        Return Me.NumberResults
    End Function
    Public Function getObj() As String()
        Return Me.Obj
    End Function
    Public Function getElm() As String()
        Return Me.Elm
    End Function
    Public Function getLoadCases() As String()
        Return Me.LoadCase
    End Function
    Public Function getStepType() As String()
        Return Me.StepType
    End Function
    Public Function getStepNum() As Double()
        Return Me.StepNum
    End Function
    Public Function getX() As Double
        Return Me.x
    End Function
    Public Function getY() As Double
        Return Me.y
    End Function
    Public Function getZ() As Double
        Return Me.z
    End Function
    Public Function getF1() As Double()
        Return Me.F1
    End Function
    Public Function getF2() As Double()
        Return Me.F2
    End Function
    Public Function getF3() As Double()
        Return Me.F3
    End Function
    Public Function getM1() As Double()
        Return Me.M1
    End Function
    Public Function getM2() As Double()
        Return Me.M2
    End Function
    Public Function getM3() As Double()
        Return Me.M3
    End Function

End Class






