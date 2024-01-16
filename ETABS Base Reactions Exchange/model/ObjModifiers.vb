Public MustInherit Class ObjModifiers
    Implements IComparable

    'ATTRIBUTES
    Protected name As String, mass As Double, weight As Double, values() As Double

    'CONSTRUCTOR
    'Default
    Public Sub New()

    End Sub
    'Overloaded
    Public Sub New(name As String)
        Me.name = name
    End Sub

    'METHODS

    'Setters
    Public Sub setName(name As String)
        Me.name = name
    End Sub

    'Getters
    Public Function getName() As String
        Return Me.name
    End Function
    Public Function getValues() As Double()
        Return Me.values
    End Function

    Public Overridable Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        Throw New NotImplementedException()
    End Function

End Class
