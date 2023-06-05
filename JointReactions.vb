Imports Microsoft.VisualBasic

Public Class JointReactions

    'ATTRIBUTES
    Private Property Name As String
    Private Property ItemTypeElm As ETABSv1.eItemTypeElm
    Private Property NumberResults As Integer
    Private Property Obj As String()
    Private Property Elm As String()
    Private Property LoadCase As String()
    Private Property StepType As String()
    Private Property StepNum As Double()
    Private Property x As Double
    Private Property y As Double
    Private Property z As Double
    Private Property F1 As Double()
    Private Property F2 As Double()
    Private Property F3 As Double()
    Private Property M1 As Double()
    Private Property M2 As Double()
    Private Property M3 As Double()


    'CONSTRUCTOR
    'Default Constructor applies


    'GETTERS AND SETTERS

    'Setters
    Public Sub setName(Name As String)
        Me.Name = Name
    End Sub
    Public Sub setItemTypeElm(itemTypeElm As ETABSv1.eItemTypeElm)
        Me.ItemTypeElm = itemTypeElm
    End Sub
    Public Sub setNumberResults(NumberResults As Integer)
        Me.NumberResults = NumberResults
    End Sub
    Public Sub setObj(Obj As String())
        Me.Obj = Obj
    End Sub
    Public Sub setElm(Elm As String())
        Me.Elm = Elm
    End Sub
    Public Sub setLoadCases(LoadCase As String())
        Me.LoadCase = LoadCase
    End Sub
    Public Sub setStepType(StepType As String())
        Me.StepType = StepType
    End Sub
    Public Sub setStepNum(StepNum As Double())
        Me.StepNum = StepNum
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
    Public Sub setF1(F1 As Double())
        Me.F1 = F1
    End Sub
    Public Sub setF2(F2 As Double())
        Me.F2 = F2
    End Sub
    Public Sub setF3(F3 As Double())
        Me.F3 = F3
    End Sub
    Public Sub setM1(M1 As Double())
        Me.M1 = M1
    End Sub
    Public Sub setM2(M2 As Double())
        Me.M2 = M2
    End Sub
    Public Sub setM3(M3 As Double())
        Me.M3 = M3
    End Sub

    'Getters
    Public Function getName() As String
        Return Me.Name
    End Function
    Public Function getItemTypeElm() As ETABSv1.eItemTypeElm
        Return Me.ItemTypeElm
    End Function
    Public Function getNumberResults() As Integer
        Return Me.NumberResults
    End Function
    Public Function getObj() As String()
        Return Me.Obj
    End Function
    Public Function getElm() As String()
        Return Me.Elm
    End Function
    Public Function getLoadCases() As String()
        Return Me.LoadCase
    End Function
    Public Function getStepType() As String()
        Return Me.StepType
    End Function
    Public Function getStepNum() As Double()
        Return Me.StepNum
    End Function
    Public Function getX() As Double
        Return Me.x
    End Function
    Public Function getY() As Double
        Return Me.y
    End Function
    Public Function getZ() As Double
        Return Me.z
    End Function
    Public Function getF1() As Double()
        Return Me.F1
    End Function
    Public Function getF2() As Double()
        Return Me.F2
    End Function
    Public Function getF3() As Double()
        Return Me.F3
    End Function
    Public Function getM1() As Double()
        Return Me.M1
    End Function
    Public Function getM2() As Double()
        Return Me.M2
    End Function
    Public Function getM3() As Double()
        Return Me.M3
    End Function

End Class
