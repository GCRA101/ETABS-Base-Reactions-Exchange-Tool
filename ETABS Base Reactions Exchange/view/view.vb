'IMPORT LIBRARIES'
Imports ETABS_Base_Reactions_Exchange.controller
Imports ETABS_Base_Reactions_Exchange.model


Namespace view

    Public Class View
        Implements Observer

        'ATTRIBUTES ********************************************'
        'References to Model and Controller
        Protected model As model.Model
        Protected controller As controller.Controller

        'CONSTRUCTOR - Overloaded ******************************'
        Public Sub New(model As model.Model, controller As controller.Controller)
            'Recording references to model and controller
            Me.model = model
            Me.controller = controller
        End Sub

        Public Sub update() Implements Observer.update
            Throw New NotImplementedException()
        End Sub

    End Class

End Namespace