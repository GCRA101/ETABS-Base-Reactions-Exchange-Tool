Public Class PointReactions

    'ATTRIBUTES ******************************
    Private Property numberResults As Integer
    Private Property obj As String()
    Private Property elm As String()
    Private Property loadCase As String()
    Private Property stepType As String()
    Private Property stepNum As Double()
    Private Property f1 As Double()
    Private Property f2 As Double()
    Private Property f3 As Double()
    Private Property m1 As Double()
    Private Property m2 As Double()
    Private Property m3 As Double()



    'CONSTRUCTOR *****************************
    'Default Constructor applies



    'GETTERS and SETTERS *********************

    'Setters
    Public Sub setNumberResults(numberResults As Integer)
        Me.NumberResults = numberResults
    End Sub
    Public Sub setObj(obj As String())
        Me.obj = obj
    End Sub
    Public Sub setElm(elm As String())
        Me.elm = elm
    End Sub
    Public Sub setLoadCase(loadCase As String())
        Me.loadCase = loadCase
    End Sub
    Public Sub setStepType(stepType As String())
        Me.stepType = stepType
    End Sub
    Public Sub setStepNum(stepNum As Double())
        Me.stepNum = stepNum
    End Sub
    Public Sub setF1(f1 As Double())
        Me.f1 = f1
    End Sub
    Public Sub setF2(f2 As Double())
        Me.f2 = f2
    End Sub
    Public Sub setF3(f3 As Double())
        Me.f3 = f3
    End Sub
    Public Sub setm1(m1 As Double())
        Me.m1 = m1
    End Sub
    Public Sub setm2(m2 As Double())
        Me.m2 = m2
    End Sub
    Public Sub setm3(m3 As Double())
        Me.m3 = m3
    End Sub


    'Getters
    Public Function getNumberResults() As Integer
        Return Me.numberResults
    End Function
    Public Function getObj() As String()
        Return Me.obj
    End Function
    Public Function getElm() As String()
        Return Me.elm
    End Function
    Public Function getLoadCases() As String()
        Return Me.loadCase
    End Function
    Public Function getStepType() As String()
        Return Me.stepType
    End Function
    Public Function getStepNum() As Double()
        Return Me.stepNum
    End Function
    Public Function getF1() As Double()
        Return Me.f1
    End Function
    Public Function getF2() As Double()
        Return Me.f2
    End Function
    Public Function getF3() As Double()
        Return Me.f3
    End Function
    Public Function getM1() As Double()
        Return Me.m1
    End Function
    Public Function getM2() As Double()
        Return Me.m2
    End Function
    Public Function getM3() As Double()
        Return Me.m3
    End Function






End Class
