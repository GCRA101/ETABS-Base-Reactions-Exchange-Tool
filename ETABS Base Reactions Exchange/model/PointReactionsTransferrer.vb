Imports CSiAPIv1
Imports ETABS_Base_Reactions_Exchange.model

Public Class PointReactionsTransferrer
    Inherits ETABSTransferrer

    'ATTRIBUTES
    Private loadCaseNames As String()
    Private storyNames As String()
    Private groupNames As String()


    'CONSTRUCTOR
    'Overloaded
    Public Sub New(sourceEtabsModel As ETABSv1.cSapModel, targetEtabsModel As ETABSv1.cSapModel,
                   loadCaseNames As String(), storyNames As String(), groupNames As String())
        MyBase.New(sourceEtabsModel, targetEtabsModel)

        Dim pullPointReactions = New PullPointReactions(sourceEtabsModel, loadCaseNames, storyNames, groupNames)
        Dim pushPointReactions = New PushPointReactions(targetEtabsModel)
        Me.transferMode = New PointReactionsTransfer(sourceEtabsModel, targetEtabsModel, pullPointReactions, pushPointReactions)

    End Sub


    'METHODS
    Public Overrides Sub transfer(Optional overwrite As Boolean = False)
        Me.transferMode.transfer(overwrite)
    End Sub


End Class
