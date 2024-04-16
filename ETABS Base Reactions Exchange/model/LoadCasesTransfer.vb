Imports ETABS_Base_Reactions_Exchange.model

Public Class LoadCasesTransfer
    Inherits TransferBehaviour

    'ATTRIBUTES
    Private pullLoadCases As PullLoadCases
    Private pushLoadCases As PushLoadCases

    'CONTRUCTOR
    'Default
    Public Sub New(sourceEtabsModel As ETABSv1.cSapModel, targetEtabsModel As ETABSv1.cSapModel)
        MyBase.New(sourceEtabsModel, targetEtabsModel)
    End Sub
    'Overloaded
    Public Sub New(sourceEtabsModel As ETABSv1.cSapModel, targetEtabsModel As ETABSv1.cSapModel,
                   pullLoadCases As PullLoadCases, pushLoadCases As PushLoadCases)
        Me.New(sourceEtabsModel, targetEtabsModel)
        Me.pullLoadCases = pullLoadCases
        Me.pushLoadCases = pushLoadCases
    End Sub

    'METHODS

    'Setters and Getters
    Public Sub setPullLoadCases(pullLoadCases As PullLoadCases)
        Me.pullLoadCases = pullLoadCases
    End Sub
    Public Sub setPushLoadCases(pushLoadCases As PushLoadCases)
        Me.pushLoadCases = pushLoadCases
    End Sub
    Public Function getPullLoadCases() As PullLoadCases
        Return Me.pullLoadCases
    End Function
    Public Function getPushLoadCases() As PushLoadCases
        Return Me.pushLoadCases
    End Function

    'Transfer
    Public Overrides Sub transfer(Optional overwrite As Boolean = False)
        Dim loadCases As IEnumerable(Of LoadCase) = Me.pullLoadCases.pull()
        Me.pushLoadCases.setLoadCases(loadCases)
        Me.pushLoadCases.push(overwrite)
    End Sub

End Class
