Public Class PointReactionsTransferrer
    Inherits ETABSTransferrer


    'ATTRIBUTES


    'CONSTRUCTOR
    'Default
    Public Sub New()
        MyBase.New()
        Me.transferMode = New PointReactionsTransfer()
    End Sub
    'Overloaded
    Public Sub New(sourceEtabsModel As ETABSv1.cSapModel, targetEtabsModel As ETABSv1.cSapModel)
        MyBase.New(sourceEtabsModel, targetEtabsModel)
        Me.transferMode = New PointReactionsTransfer
    End Sub


    'METHODS
    Protected Overrides Sub transfer()
        Me.transferMode.transfer()
    End Sub


End Class
