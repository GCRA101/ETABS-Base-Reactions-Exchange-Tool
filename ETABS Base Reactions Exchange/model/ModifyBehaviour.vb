Public MustInherit Class ModifyBehaviour
    Implements ModifyData

    'ATTRIBUTES
    Protected ret As Integer
    Protected etabsModel As ETABSv1.cSapModel

    'CONSTRUCTORS
    'Default
    Public Sub New(etabsModel As ETABSv1.cSapModel)
        Me.etabsModel = etabsModel
    End Sub

    Public Overridable Sub modify() Implements ModifyData.modify
        Throw New NotImplementedException()
    End Sub
End Class
