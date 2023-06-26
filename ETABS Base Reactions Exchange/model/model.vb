
Namespace model


    Public Class Model


        Private Shared instance As Model

        Private Sub New()

        End Sub


        Public Shared Function getInstance() As Model
            If instance IsNot Nothing Then
                Return instance
            Else
                instance = New Model()
                Return instance
            End If
        End Function



    End Class


End Namespace