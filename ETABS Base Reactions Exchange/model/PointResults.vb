Public MustInherit Class PointResults
    Inherits ETABSData

    'ATTRIBUTES **********************************************************
    Protected numberResults As Integer
    Protected obj, elm, loadCase, stepType As String()
    Protected stepNum As Double()


    'CONSTRUCTOR ************************************************************
    'Default Constructor
    Public Sub New()
        MyBase.New()
    End Sub
    'Overloaded
    Public Sub New(numRes As Integer, obj As String(), elm As String(), loadCase() As String,
                   stepType As String(), stepNum As Double())
        Me.numberResults = numRes
        Me.obj = obj
        Me.elm = elm
        Me.loadCase = loadCase
        Me.stepType = stepType
        Me.stepNum = stepNum
    End Sub


    'METHODS ****************************************************************

    'GETTERS and SETTERS *********************

    'Setters
    Public Sub setNumberResults(numberResults As Integer)
        Me.numberResults = numberResults
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

End Class
