Imports ETABS_Base_Reactions_Exchange.model

Public Class PointReactionsTransfer
    Inherits TransferBehaviour

    'ATTRIBUTES
    Private pullPointReactions As PullPointReactions
    Private pushPointReactions As PushPointReactions

    'CONSTRUCTORS
    'Overloaded 1
    Public Sub New(sourceEtabsModel As ETABSv1.cSapModel, targetEtabsModel As ETABSv1.cSapModel)
        MyBase.New(sourceEtabsModel, targetEtabsModel)
    End Sub
    'Overloaded 2
    Public Sub New(sourceEtabsModel As ETABSv1.cSapModel, targetEtabsModel As ETABSv1.cSapModel,
                   pullPointReactions As PullPointReactions, pushPointReactions As PushPointReactions)
        'Call Constructor Overloaded 1
        Me.New(sourceEtabsModel, targetEtabsModel)
        'Assign Attributes
        With Me
            .pullPointReactions = pullPointReactions
            .pushPointReactions = pushPointReactions
        End With

    End Sub


    'METHODS

    'Setters and Getters
    Public Sub setPullPointReactions(pullPointReactions As PullPointReactions)
        Me.pullPointReactions = pullPointReactions
    End Sub
    Public Sub setPushPointReactions(pushPointReactions As PushPointReactions)
        Me.pushPointReactions = pushPointReactions
    End Sub
    Public Function getPullPointReactions() As PullPointReactions
        Return Me.pullPointReactions
    End Function
    Public Function getPushPointReactions() As PushPointReactions
        Return Me.pushPointReactions
    End Function

    'Transfer
    Public Overrides Sub transfer(Optional overwrite As Boolean = False)

        Dim pointReactions As IEnumerable(Of PointDataSet)
        pointReactions = Me.pullPointReactions.pull()

        Me.pushPointReactions.setPPData(pointReactions)
        Me.pushPointReactions.push(overwrite)

    End Sub

End Class
