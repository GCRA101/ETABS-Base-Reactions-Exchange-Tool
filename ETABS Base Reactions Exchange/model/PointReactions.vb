Imports System.Runtime.InteropServices.WindowsRuntime

Public Class PointReactions
    Inherits ETABSData

    'ATTRIBUTES **********************************************************
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



    'CONSTRUCTOR ************************************************************
    'Default Constructor
    Public Sub New()
        MyBase.New()
    End Sub
    'Overloaded
    Public Sub New(numRes As Integer, obj As String(), elm As String(), loadCase() As String,
                   stepType As String(), stepNum As Double(), f1 As Double(), f2 As Double(),
                   f3 As Double(), m1 As Double(), m2 As Double(), m3 As Double())
        With Me
            .numberResults = numRes
            .obj = obj
            .elm = elm
            .loadCase = loadCase
            .stepType = stepType
            .stepNum = stepNum
            .f1 = f1
            .f2 = f2
            .f3 = f3
            .m1 = m1
            .m2 = m2
            .m3 = m3
        End With
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



    'HASHCODE

    'Method inherited from the Object superclass and that has to be overwritten in order to generate
    'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    'The hashcode is essential to be able to sort and store instances of this class properly 
    'in whatever concrete implementation of the abstract data structure Hash Table.
    Public Overrides Function GetHashCode() As Integer
        'Determines and returns the Hashcode of the class instance as the number given by the sum 
        'of the hascodes/values of the most significant attributes of the class instance
        Dim hash As Integer
        hash = Me.getElm.GetHashCode + Me.getObj.GetHashCode + Me.getF1.GetHashCode +
               Me.getF2.GetHashCode + Me.getF3.GetHashCode + Me.getM1.GetHashCode +
               Me.getM2.GetHashCode + Me.getM3.GetHashCode
        Return hash
    End Function


    'COMPARETO

    'Method implemented from the IComparable Functional Interface which unique method CompareTo 
    'gets called everytime we want to compare an instance of this class with another object.
    'The method needs to be implemented accordingly with the criteria we want to use to define
    'which object is greater or smaller than the other based on the values assigned to its 
    'attributes.
    Public Overrides Function CompareTo(obj As Object) As Integer
        Throw New NotImplementedException()
        '1. Check input Obj Data Type to match the Class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return Nothing
        End If
        '2. Down-Cast the input Object to the PointReactions Class
        Dim pReactObj As PointReactions
        pReactObj = CType(obj, PointReactions)
        '3. Compare the two instances of the class giving precedence to the number of results
        If (Me.getNumberResults > pReactObj.getNumberResults) Then
            Return 1
        ElseIf (Me.getNumberResults < pReactObj.getNumberResults) Then
            Return -1
        End If

        Return 0
    End Function


    'EQUALS

    'Method inherited from the Object superclass and that gets called everytime we check whether 
    'two instances of this class are equal or not. 
    'It has to be overwritten based on the values assigned to the attributes of the class instances
    Public Overrides Function Equals(obj As Object) As Boolean

        '1. Check input Obj Data Type to match the PointObj Class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return False
        End If

        '2. Down-Cast the input object to the PointObj Class
        Dim pReactObj As PointReactions
        pReactObj = CType(obj, PointReactions)

        '3. Check if main attributes are equal
        ' - Note : Equals method has to be used to compare all attributes since they are all Arrays/Lists so...other 
        '   data structures...they're not primitive type objects!
        If (Me.getElm.Equals(pReactObj.getElm) And Me.getObj.Equals(pReactObj.getObj) And
           Me.getF1.Equals(pReactObj.getF1) And Me.getF2.Equals(pReactObj.getF2) And Me.getF3.Equals(pReactObj.getF3) And
           Me.getM1.Equals(pReactObj.getM1) And Me.getM2.Equals(pReactObj.getM2) And Me.getM3.Equals(pReactObj.getM3)) Then
            Return True
        Else
            Return False
        End If

    End Function






End Class
