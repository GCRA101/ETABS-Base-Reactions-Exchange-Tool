Public MustInherit Class PushBehaviour
    Implements PushData

    'ATTRIBUTES
    Protected ret As Integer
    Protected etabsModel As ETABSv1.cSapModel

    'CONSTRUCTOR
    'Overloaded
    Public Sub New(etabsModel As ETABSv1.cSapModel)
        Me.etabsModel = etabsModel
    End Sub


    'METHODS
    'Implemented from the Interfaces
    Public MustOverride Sub push() Implements PushData.push


End Class
