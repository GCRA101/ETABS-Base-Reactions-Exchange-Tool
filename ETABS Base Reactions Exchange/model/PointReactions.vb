Imports System.Runtime.InteropServices.WindowsRuntime

Public Class PointReactions
    Inherits NodalForces


    'CONSTRUCTOR ************************************************************
    'Default Constructor
    Public Sub New()
        MyBase.New()
    End Sub
    'Overloaded
    Public Sub New(numRes As Integer, obj As String(), elm As String(),
                   loadCase() As String, stepType As String(), stepNum As Double(), f1 As Double(), f2 As Double(),
                   f3 As Double(), m1 As Double(), m2 As Double(), m3 As Double())

        MyBase.New(numRes, obj, elm, loadCase, stepType, stepNum, f1, f2, f3, m1, m2, m3)

    End Sub





End Class
