Public Class FrameObjModifiers
    Inherits ObjModifiers

    'ATTRIBUTES
    Private crossSectionArea, shearArea2, shearArea3, torsion, momentOfInertia2, momentOfIntertia3 As Double

    'CONSTRUCTOR
    'Default
    Public Sub New()
        MyBase.New()
    End Sub
    'Overloaded
    Public Sub New(name As String, crossSectionArea As Double, shearArea2 As Double, shearArea3 As Double,
                   torsion As Double, momentOfInertia2 As Double, momentOfInertia3 As Double)
        MyBase.New(name)
        With Me
            .crossSectionArea = crossSectionArea
            .shearArea2 = shearArea2
            .shearArea3 = shearArea3
            .torsion = torsion
            .momentOfInertia2 = momentOfInertia2
            .momentOfIntertia3 = momentOfInertia3
        End With

    End Sub

    'METHODS

End Class
