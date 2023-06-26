Imports ETABS_Base_Reactions_Exchange.view
Imports ETABS_Base_Reactions_Exchange.model

Namespace controller

    Public Class Controller

        Protected model As model.Model
        Protected view As view.View

        Public Sub New()
            Me.model = model.getInstance()
            Me.view = New
        End Sub



    End Class


End Namespace
