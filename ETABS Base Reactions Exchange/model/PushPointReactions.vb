
Namespace model

    Public Class PushPointReactions
        Inherits PushBehaviour

        'ATTRIBUTES
        Dim loadCaseNames As List(Of String)
        Dim storyNames, groupNames As List(Of String)
        Dim ppData As List(Of PointDataSet)
        Dim reactPointsGroupName As String = "Reaction Points"

        'CONSTRUCTOR
        'Overloaded 1
        Public Sub New(etabsModel As ETABSv1.cSapModel)
            MyBase.New(etabsModel)
        End Sub
        'Overloaded 2
        Public Sub New(etabsModel As ETABSv1.cSapModel, ppData As List(Of PointDataSet),
                       Optional storyNames As List(Of String) = Nothing,
                       Optional groupNames As List(Of String) = Nothing)
            MyBase.New(etabsModel)
            Me.ppData = ppData
            Me.storyNames = storyNames
            Me.groupNames = groupNames
        End Sub



        'METHODS


        'Setters and Getters
        Public Sub setPPData(ppData As List(Of PointDataSet))
            Me.ppData = ppData
        End Sub
        Public Function getPPData() As List(Of PointDataSet)
            Return Me.ppData
        End Function

        Public Overrides Sub push(Optional overwrite As Boolean = False)

            '1. Unlock the ETABS Model
            ret = etabsModel.SetModelIsLocked(False)

            '2. Create Group to store Reaction Points in the ETABS Model
            createGroupForReactionPoints()

            '3. Get List of Points at input stories
            Dim ppNumNames As Integer, ppNames As String()
            Dim ppNamesSelected As List(Of String)

            If storyNames Is Nothing Then
                ret = Me.etabsModel.PointObj.GetNameList(ppNumNames, ppNames)
                ppNamesSelected.AddRange(ppNames)
            Else
                For Each storyName As String In storyNames
                    ret = Me.etabsModel.PointObj.GetNameListOnStory(storyName, ppNumNames, ppNames)
                    ppNamesSelected.AddRange(ppNames)
                Next
            End If

            '4. Filter List of Points based on input groups

            If Not groupNames Is Nothing Then
                For Each ppName As String In ppNamesSelected
                    Dim numGroups As Integer, grpNames As String()
                    ret = Me.etabsModel.PointObj.GetGroupAssign(ppName, numGroups, grpNames)
                    If grpNames.Where(Function(grpName) groupNames.Contains(grpName)).Count() <> 0 Then
                        ppNamesSelected.Remove(ppName)
                    End If
                Next
            End If

            ' *************** USE THE OBSERVER PATTERN!!! ***********************
            'Dim progrBarStep As Integer = (Me.progrBar.Maximum - Me.progrBar.Minimum) \ baseJointsData.Count

            Dim ppMatch As Boolean
            Dim ppX, ppY, ppZ As Double
            Dim numDecimals As Integer

            For Each pdSet As PointDataSet In Me.ppData
                For Each ppName As String In ppNamesSelected

                    ppMatch = False

                    ret = Me.etabsModel.PointObj.GetCoordCartesian(ppName, ppX, ppY, ppZ)

                    ppX = Math.Round(ppX, numDecimals)
                    ppY = Math.Round(ppY, numDecimals)
                    ppZ = Math.Round(ppZ, numDecimals)

                    If ((Math.Round(pdSet.getPoint.getX(), numDecimals) = ppX) And
                        (Math.Round(pdSet.getPoint.getY(), numDecimals) = ppY) And
                        (Math.Round(pdSet.getPoint.getZ(), numDecimals) = ppZ)) Then
                        ppMatch = True
                        For i = 0 To UBound(pdSet.getReactions.getLoadCases()) Step 1
                            Dim pointForces() As Double = {pdSet.getReactions.getF1(i) * (-1), pdSet.getReactions.getF2(i) * (-1),
                                                           pdSet.getReactions.getF3(i) * (-1), pdSet.getReactions.getM1(i) * (-1),
                                                           pdSet.getReactions.getM2(i) * (-1), pdSet.getReactions.getM3(i) * (-1)}
                            ret = Me.etabsModel.PointObj.SetLoadForce(ppName, pdSet.getReactions.getLoadCases()(i), pointForces, True)
                            ret = Me.etabsModel.PointObj.SetGroupAssign(ppName, reactPointsGroupName, False, ETABSv1.eItemType.Objects)
                        Next
                        Exit For
                    End If

                    If ppMatch = False Then
                        Dim ppNewName As String = pdSet.getPoint.getName + "0000"
                        ret = Me.etabsModel.PointObj.AddCartesian(pdSet.getPoint.getX, pdSet.getPoint.getY, pdSet.getPoint.getZ, ppNewName)
                        For i = 0 To UBound(pdSet.getReactions.getLoadCases) Step 1
                            Dim pointForces() As Double = {pdSet.getReactions.getF1(i) * (-1), pdSet.getReactions.getF2(i) * (-1),
                                                           pdSet.getReactions.getF3(i) * (-1), pdSet.getReactions.getM1(i) * (-1),
                                                           pdSet.getReactions.getM2(i) * (-1), pdSet.getReactions.getM3(i) * (-1)}
                            ret = Me.etabsModel.PointObj.SetLoadForce(ppNewName, pdSet.getReactions.getLoadCases(i), pointForces, True)
                            ret = Me.etabsModel.PointObj.SetGroupAssign(ppNewName, reactPointsGroupName, False, ETABSv1.eItemType.Objects)
                        Next
                    End If
                Next

                'Me.progrBar.Increment(progrBarStep)
                'Me.Refresh()

            Next


            'Me.lblProgrBar.Text = "Transfer Completed!"
            'Me.Refresh()

            'Me.etabsModel.File.Save(setNewFilePath(targetFileName))


        End Sub




        Private Sub createGroupForReactionPoints()

            'Local Variables
            Dim Group_Found As Boolean
            Dim GroupObjs_Num As Long
            Dim GroupObjs_Type() As Integer
            Dim GroupObjs_Name() As String



            '1. EXTRACT LIST OF GROUPS PRESENT IN THE ETABS MODEL

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

End Namespace