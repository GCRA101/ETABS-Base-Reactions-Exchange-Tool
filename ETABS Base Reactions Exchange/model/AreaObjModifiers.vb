Public Class AreaObjModifiers
    Inherits ObjModifiers

    'ATTRIBUTES
    Private f11, f22, f12, m11, m22, m12, v13, v23 As Double

    'CONSTRUCTOR
    'Default
    Public Sub New()
        MyBase.New()
    End Sub
    'Overloaded
    Public Sub New(name As String, f11 As Double, f22 As Double, f12 As Double, m11 As Double, m22 As Double,
                   m12 As Double, v13 As Double, v23 As Double, mass As Double, weight As Double)
        MyBase.New(name)
        With Me
            .f11 = f11
            .f22 = f22
            .f12 = f12
            .m11 = m11
            .m22 = m22
            .m12 = m12
            .v13 = v13
            .v23 = v23
            .mass = mass
            .weight = weight
        End With
    End Sub





End Class
