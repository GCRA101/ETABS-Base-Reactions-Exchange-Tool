Public Class PointReactionsTransfer
    Inherits TransferBehaviour

    'ATTRIBUTES
    Private LoadCasesNames, StoryNames, GroupNames As String()

    'CONSTRUCTORS

    'METHODS

    Public Overrides Sub transfer()

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



        Dim ppX, ppY, ppZ As Double
        Dim ppMatch As Boolean



        etabsModel.InitializeNewModel()

        ret = targetEtabsModel.File.OpenFile(targetFileName)

        ret = targetEtabsModel.View.RefreshView



        'CLOSE AND DISPOSE FORM
        Me.Close()
        Me.Dispose()

    End Sub

End Class
