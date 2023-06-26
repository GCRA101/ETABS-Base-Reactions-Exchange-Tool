
Namespace model


    Public Class Model
        Implements Observable

        'ATTRIBUTES ********************************************'
        Private Shared instance As Model
        Private observers As New List(Of Observer)

        'CONSTRUCTOR - PRIVATE' 'SINGLETON PATTERN *************'
        Private Sub New()
        End Sub


        'METHODS ************************************************'

        'GETINSTANCE() METHOD - SINGLETON PATTERN'
        Public Shared Function getInstance() As Model
            If instance IsNot Nothing Then
                Return instance
            Else
                instance = New Model()
                Return instance
            End If
        End Function

        'OBSERVABLE INTERFACE'S METHODS'

        'REGISTER Observers'
        Public Sub registerObserver(o As Observer) Implements Observable.registerObserver
            Me.observers.Add(o)
        End Sub

        'REMOVE Observers'
        Public Sub removeObserver(o As Observer) Implements Observable.removeObserver
            Me.observers.Remove(o)
        End Sub

        'NOTIFY Observers'
        Public Sub notifyObservers() Implements Observable.notifyObservers

        End Sub



    End Class


End Namespace