Imports ETABS_Base_Reactions_Exchange.model

Public Class PullPointReactions
    Inherits PullBehaviour

    'ATTRIBUTES
    'All attributes inherited from the abstract superclass PullBehaviour
    Dim loadCasesNames, StoryNames, GroupNames As String()

    'CONSTRUCTOR
    'Overloaded 1
    Public Sub New(etabsModel As ETABSv1.cSapModel)
        MyBase.New(etabsModel)
        Me.setDefault()
    End Sub
    'Overloaded 2
    Public Sub New(etabsModel As ETABSv1.cSapModel, loadCasesNames As String(),
                   StoryNames As String(), GroupNames As String())
        MyBase.New(etabsModel)
        With Me
            .loadCasesNames = loadCasesNames
            .StoryNames = StoryNames
            .GroupNames = GroupNames
        End With
    End Sub

    'METHODS

    Public Sub setDefault()
        'Local Variables
        Dim numberNames As Integer
        'Extract names of ALL load cases, groups and levels defined in the etabs model
        ret = Me.etabsModel.LoadCases.GetNameList(numberNames, Me.loadCasesNames)
        ret = Me.etabsModel.GroupDef.GetNameList(numberNames, Me.GroupNames)
        ret = Me.etabsModel.Story.GetNameList(numberNames, Me.StoryNames)
    End Sub



    Public Overrides Function pull() As IEnumerable(Of ETABSData)


        '1. RUN ETABS MODEL ANALYSIS **********************************

        '1. Unlock the Model
        ret = etabsModel.SetModelIsLocked(False)
        '2. Reset Running Load Cases to None
        ret = etabsModel.Analyze.SetRunCaseFlag("", False, True)
        '3. Set Running Load Cases 
        For Each loadCaseName In loadCasesNames
            ret = etabsModel.Analyze.SetRunCaseFlag(loadCaseName, True)
        Next
        '4. Run the Model Analysis
        ret = etabsModel.Analyze.RunAnalysis



        '2. GET POINTS AT RELEVANT LEVELS **********************************

        'Local Variables
        Dim ppNumberNames As Integer
        Dim ppNames As String()
        Dim ppNamesByStoryList As List(Of String()) = New List(Of String())

        'Loop through Storeys
        For Each storyName In Me.StoryNames
            ret = Me.etabsModel.PointObj.GetNameListOnStory(storyName, ppNumberNames, ppNames)
            ppNamesByStoryList.Add(ppNames)
        Next



        '3. GET POINTS BELONGING TO RELEVANT GROUPS ***********************

        'Local Variables
        Dim numGroups As Integer, ppGroups() As String
        Dim groupFound As Boolean
        Dim ppNamesByGroupList As List(Of String) = New List(Of String)

        'Loop through Storeys
        For Each dataRow As String() In ppNamesByStoryList
            'Flick through points at same storey...
            For Each ppName In dataRow
                'Get Group assigned to the point...
                ret = etabsModel.PointObj.GetGroupAssign(ppName, numGroups, ppGroups)
                'Check assigned group against list of relevant groups...
                For Each ppGroup In ppGroups
                    groupFound = False
                    For Each groupName In Me.GroupNames
                        If ppGroup = groupName Then
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



        '4. SET LOAD CASES FOR OUTPUTS EXTRACTION **********************************

        'Reset Load Cases for Output
        ret = etabsModel.Results.Setup.DeselectAllCasesAndCombosForOutput
        'Set Load Cases for Output
        For Each loadCaseName In Me.loadCasesNames
            ret = Me.etabsModel.Results.Setup.SetCaseSelectedForOutput(loadCaseName, True)
        Next



        '5. EXTRACT POINT REACTIONS DATA  *******************************************

        'Local Variables
        Dim pointsData As PointDataSet()
        Dim itemTypeElm As ETABSv1.eItemTypeElm
        Dim numberResults As Integer
        Dim obj, elm, loadCase, stepType As String()
        Dim StepNum As Double()
        Dim f1, f2, f3, m1, m2, m3 As Double()

        'Convert/Redim data structures
        ppNames = ppNamesByGroupList.ToArray()
        ReDim pointsData(ppNumberNames - 1)

        'Loop Through all Point Names....
        For i = 0 To UBound(ppNames) Step 1
            '1. Extract Point Coordinates and build PointObj class instance
            Dim ppObj As PointObj
            Dim x, y, z As Double
            ret = Me.etabsModel.PointObj.GetCoordCartesian(ppNames(i), x, y, z)
            ppObj = New PointObj(ppNames(i), x, y, z)
            '2. Extract Point Reactions and build ppReactions class instance
            Dim ppReactions As PointReactions
            ret = Me.etabsModel.Results.JointReact(ppNames(i), itemTypeElm, numberResults, obj, elm, loadCase,
                                             stepType, StepNum, f1, f2, f3, m1, m2, m3)
            ppReactions = New PointReactions(numberResults, obj, elm, loadCase, stepType, StepNum, f1, f2, f3, m1, m2, m3)
            '3. Build up PointDataSet class instance combining point coordinates and reactions
            pointsData(i) = New PointDataSet(ppObj, ppReactions)
        Next

        Return pointsData

    End Function

End Class
