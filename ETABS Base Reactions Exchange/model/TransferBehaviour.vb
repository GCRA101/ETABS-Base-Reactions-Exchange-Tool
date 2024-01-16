Public MustInherit Class TransferBehaviour
    Implements DataTransfer

    'ATTRIBUTES 
    Protected ret As Integer
    Protected etabsModel As ETABSv1.cSapModel

    'CONSTRUCTOR
    'Overloaded
    Public Sub New(etabsModel As ETABSv1.cSapModel)
        Me.etabsModel = etabsModel
    End Sub

    'METHODS
    Public Overridable Sub transfer() Implements DataTransfer.transfer
        Throw New NotImplementedException()
    End Sub
End Class
