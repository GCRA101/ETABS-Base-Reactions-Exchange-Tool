Public MustInherit Class ObjModifiers

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
    Public Sub setValues(values() As Double)
        Me.values = values
    End Sub

    'Getters
    Public Function getName() As String
        Return Me.name
    End Function
    Public Function getValues() As Double()
        Return Me.values
    End Function

End Class
