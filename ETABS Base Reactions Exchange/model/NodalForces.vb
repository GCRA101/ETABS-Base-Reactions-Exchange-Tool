Public Class NodalForces
    Inherits PointResults

    'ATTRIBUTES **********************************************************
    Protected f1, f2, f3, m1, m2, m3 As Double()


    'CONSTRUCTOR ************************************************************
    'Default Constructor
    Public Sub New()
        MyBase.New()
    End Sub
    'Overloaded
    Public Sub New(numRes As Integer, obj As String(), elm As String(), loadCase() As String,
                   stepType As String(), stepNum As Double(), f1 As Double(), f2 As Double(),
                   f3 As Double(), m1 As Double(), m2 As Double(), m3 As Double())

        MyBase.New(numRes, obj, elm, loadCase, stepType, stepNum)

        With Me
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
        hash = Me.numberResults + Me.obj.GetHashCode() + CInt(Me.f1.Average() + Me.m1.Average() + Me.f3.Average())
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
        '2. Down-Cast the input Object to the currentClass
        Dim nForcesObj As NodalForces
        nForcesObj = CType(obj, PointReactions)
        '3. Compare the two instances of the class giving precedence to the number of results
        If (Me.getNumberResults > nForcesObj.getNumberResults) Then
            Return 1
        ElseIf (Me.getNumberResults < nForcesObj.getNumberResults) Then
            Return -1
        End If

        Return 0
    End Function


    'EQUALS

    'Method inherited from the Object superclass and that gets called everytime we check whether 
    'two instances of this class are equal or not. 
    'It has to be overwritten based on the values assigned to the attributes of the class instances
    Public Overrides Function Equals(obj As Object) As Boolean

        '1. Check input Obj Data Type to match the current Class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return False
        End If

        '2. Down-Cast the input object to the current Class
        Dim nForcesObj As NodalForces
        nForcesObj = CType(obj, PointReactions)

        '3. Check if main attributes are equal
        ' - Note : Equals method has to be used to compare all attributes since they are all Arrays/Lists so...other 
        '   data structures...they're not primitive type objects!
        If (Me.getElm.Equals(nForcesObj.getElm) And Me.getObj.Equals(nForcesObj.getObj) And
           Me.getF1.Equals(nForcesObj.getF1) And Me.getF2.Equals(nForcesObj.getF2) And Me.getF3.Equals(nForcesObj.getF3) And
           Me.getM1.Equals(nForcesObj.getM1) And Me.getM2.Equals(nForcesObj.getM2) And Me.getM3.Equals(nForcesObj.getM3)) Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
