Public MustInherit Class TransferBehaviour
    Implements DataTransfer

    'ATTRIBUTES 
    Protected ret As Integer

    'CONSTRUCTOR
    Public Sub New()

    End Sub

    'METHODS
    Public Sub transfer() Implements DataTransfer.transfer
        Throw New NotImplementedException()
    End Sub
End Class
