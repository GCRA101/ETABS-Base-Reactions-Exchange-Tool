'IMPORT LIBRARIES'
Imports ETABS_Base_Reactions_Exchange.view
Imports ETABS_Base_Reactions_Exchange.model

Namespace controller

    Public Class Controller

        'ATTRIBUTES ********************************************'
        'References to Model and View'
        Protected model As model.Model
        Protected view As view.View

        'CONSTRUCTOR - Overloaded ******************************'
        Public Sub New()
            '1. Instantiation of the Model'
            Me.model = model.getInstance()
            '2. Instantiation of the View'
            Me.view = New view.View(Me.model, Me)
            '3. Registering the View as Observer of the Model
            Me.model.registerObserver(Me.view)
        End Sub


        'METHODS ************************************************'

        Public Sub execute()

            Dim controller As Controller = New Controller()



        End Sub

    End Class


End Namespace
