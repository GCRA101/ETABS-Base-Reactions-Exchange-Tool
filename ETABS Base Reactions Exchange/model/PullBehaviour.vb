Public MustInherit Class PullBehaviour
    Implements PullData


    'ATTRIBUTES
    Protected ret As Integer
    Protected etabsModel As ETABSv1.cSapModel

    'CONSTRUCTOR
    Public Sub New(etabsModel As ETABSv1.cSapModel)
        Me.etabsModel = etabsModel
    End Sub

    'METHODS
    Public Overridable Function pull() As IEnumerable(Of ETABSData) Implements PullData.pull
        Throw New NotImplementedException()
    End Function


End Class
