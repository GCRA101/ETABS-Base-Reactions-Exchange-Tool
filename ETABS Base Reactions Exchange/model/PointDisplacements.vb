Public Class PointDisplacements
    Inherits NodalDisplacements


    'CONSTRUCTOR ************************************************************
    'Default Constructor
    Public Sub New()
        MyBase.New()
    End Sub
    'Overloaded
    Public Sub New(numRes As Integer, obj As String(), elm As String(),
                   loadCase() As String, stepType As String(), stepNum As Double(), u1 As Double(), u2 As Double(),
                   u3 As Double(), r1 As Double(), r2 As Double(), r3 As Double())

        MyBase.New(numRes, obj, elm, loadCase, stepType, stepNum, u1, u2, u3, r1, r2, r3)

    End Sub



End Class
