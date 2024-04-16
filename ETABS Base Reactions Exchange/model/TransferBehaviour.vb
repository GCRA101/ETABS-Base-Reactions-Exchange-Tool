Public MustInherit Class TransferBehaviour
    Implements DataTransfer

    'ATTRIBUTES 
    Protected ret As Integer
    Protected sourceEtabsModel, targetEtabsModel As ETABSv1.cSapModel

    'CONSTRUCTOR
    'Overloaded
    Public Sub New(sourceEtabsModel As ETABSv1.cSapModel, targetEtabsModel As ETABSv1.cSapModel)
        Me.sourceEtabsModel = sourceEtabsModel
        Me.targetEtabsModel = targetEtabsModel
    End Sub

    'METHODS
    Public Overridable Sub transfer(Optional overwrite As Boolean = False) Implements DataTransfer.transfer
        Throw New NotImplementedException()
    End Sub
End Class
