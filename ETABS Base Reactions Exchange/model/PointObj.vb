Public Class PointObj

    'ATTRIBUTES
    Private name As String
    Private x, y, z As Double


    'CONSTRUCTOR

    'Default
    Public Sub New()
    End Sub
    'Overloaded
    Public Sub New(name As String, x As Double, y As Double, z As Double)
        Me.name = name
        Me.x = x
        Me.y = y
        Me.z = z
    End Sub


    'METHODS

    'Setters
    Public Sub setName(name As String)
        Me.name = name
    End Sub
    Public Sub setX(x As Double)
        Me.x = x
    End Sub
    Public Sub setY(y As Double)
        Me.y = y
    End Sub
    Public Sub setZ(z As Double)
        Me.z = z
    End Sub

    'Getters
    Public Function getName()
        Return Me.name
    End Function
    Public Function getX()
        Return Me.x
    End Function
    Public Function getY()
        Return Me.y
    End Function
    Public Function getZ()
        Return Me.z
    End Function

End Class
