viImports System.Text.RegularExpressions
Imports ETABS_Base_Reactions_Exchange.model

Public Class PushPointReactions
    Inherits PushBehaviour

    'ATTRIBUTES
    Dim loadCaseNames, storyNames, groupNames As String()
    Dim ppData As PointDataSet()

    'CONSTRUCTOR
    'Overloaded 1
    Public Sub New(etabsModel As ETABSv1.cSapModel)
        MyBase.New(etabsModel)
    End Sub
    'Overloaded 2
    Public Sub New(etabsModel As ETABSv1.cSapModel, ppData As PointDataSet())
        MyBase.New(etabsModel)
        Me.ppData = ppData
    End Sub



    'METHODS
    Public Overrides Sub push()


        ret = etabsModel.SetModelIsLocked(False)


        pushMissingLoadCases(selLoadCasesNames)

        createGroupForReactionPoints()

        For Each selStoryName In selStoryNames
            ret = Me.etabsModel.PointObj.GetNameListOnStory(selStoryName, ppNumberNames, ppNames)
            targetppNamesByStoryList.Add(ppNames)
        Next

        Dim progrBarStep As Integer = (Me.progrBar.Maximum - Me.progrBar.Minimum) \ baseJointsData.Count

        For Each bjd As model.JointData In baseJointsData
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
                            ret = targetEtabsModel.PointObj.SetGroupAssign(dataRow(i), reactPointsGroupName, False, ETABSv1.eItemType.Objects)
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
                        ret = targetEtabsModel.PointObj.SetGroupAssign(ppNewName, reactPointsGroupName, False, ETABSv1.eItemType.Objects)
                    Next
                End If
            Next

            Me.progrBar.Increment(progrBarStep)
            Me.Refresh()

        Next


        Me.lblProgrBar.Text = "Transfer Completed!"
        Me.Refresh()

        targetEtabsModel.File.Save(setNewFilePath(targetFileName))


    End Sub


    Private Sub pushMissingLoadCases(loadCasesNames As String())

        'Local Variables
        Dim lcNum As Integer
        Dim lcNames() As String
        Dim lpType As ETABSv1.eLoadPatternType
        Dim swtMultiplier As Double

        Dim loadCases As List(Of String)
        For i = 0 To UBound(ppData) Step 1
            Dim lcases As String()
            lcases = Me.ppData(i).getReactions.getLoadCases()
            loadCases.AddRange(lcases)
        Next
        loadCases.Distinct()

        etabsModel.LoadCases.

        For Each loadCase In loadCases
            For Each sourceLoadCaseName In sourceLoadCasesNames
                If selLoadCaseName = sourceLoadCaseName Then
                    ret = sourceEtabsModel.LoadPatterns.GetLoadType(selLoadCaseName, lpType)
                    ret = sourceEtabsModel.LoadPatterns.GetSelfWTMultiplier(selLoadCaseName, swtMultiplier)
                    ret = targetEtabsModel.LoadPatterns.Add(selLoadCaseName, lpType, swtMultiplier, True)
                End If
            Next

        Next

    End Sub




    Private Sub createGroupForReactionPoints()

        'Local Variables
        Dim Group_Found As Boolean
        Dim GroupObjs_Num As Long
        Dim GroupObjs_Type() As Integer
        Dim GroupObjs_Name() As String



        '1. EXTRACT LIST OF GROUPS PRESENT IN THE ETABS MODEL

        'Group Name Assignment
        Dim reactPointsGroupName As String
        reactPointsGroupName = "Reaction Points"
        'Extract list of existing Group Names
        Dim modelNumberGroups As Integer, modelGroupNames As String()
        ret = Me.etabsModel.GroupDef.GetNameList(modelNumberGroups, modelGroupNames)



        '2. CREATE GROUP IF IT DOESN'T EXIST ALREADY...
        '...OTHERWISE KEEP IT BUT REMOVE ITS ASSIGNMENT TO ANY OBJECT IN THE MODEL...

        '1. Control Parameter Initialization
        Group_Found = False

        '2. Checking whether the reaction points group already exists...
        For i = 0 To UBound(modelGroupNames) Step 1
            If reactPointsGroupName = modelGroupNames(i) Then
                Group_Found = True
            End If
        Next

        '3. Reaction Points Group Creation/Re-Setting
        If Group_Found = True Then
            'If the Group already exists...
            'Get Objects and Number of Objects assigned to the Group
            ret = Me.etabsModel.GroupDef.GetAssignments(reactPointsGroupName, GroupObjs_Num, GroupObjs_Type, GroupObjs_Name)
            If GroupObjs_Num <> 0 Then
                'If the Group contains elements...
                'Select the elements belonging to the Group and REMOVE them from the ReactPoints Group
                With Me.etabsModel
                    'Select the Objects belonging to the Group
                    ret = .SelectObj.Group(reactPointsGroupName, False)
                    'Area Objects - Group Assignment Removal
                    ret = .AreaObj.SetGroupAssign("", reactPointsGroupName, True, ETABSv1.eItemType.SelectedObjects)
                    'Frame Objects - Group Assignment Removal
                    ret = .FrameObj.SetGroupAssign("", reactPointsGroupName, True, ETABSv1.eItemType.SelectedObjects)
                    'Point Objects - Group Assignment Removal
                    ret = .PointObj.SetGroupAssign("", reactPointsGroupName, True, ETABSv1.eItemType.SelectedObjects)
                End With
            End If
        Else
            'If it doesn't exist already, it gets created from scratch
            ret = Me.etabsModel.GroupDef.SetGroup(reactPointsGroupName)
        End If
    End Sub


End Class
