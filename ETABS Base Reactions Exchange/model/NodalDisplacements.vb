Public Class NodalDisplacements
    Inherits PointResults

    'ATTRIBUTES **********************************************************
    Protected u1, u2, u3, r1, r2, r3 As Double()


    'CONSTRUCTOR ************************************************************
    'Default Constructor
    Public Sub New()
        MyBase.New()
    End Sub
    'Overloaded
    Public Sub New(numRes As Integer, obj As String(), elm As String(), loadCase() As String,
                   stepType As String(), stepNum As Double(), u1 As Double(), u2 As Double(),
                   u3 As Double(), r1 As Double(), r2 As Double(), r3 As Double())

        MyBase.New(numRes, obj, elm, loadCase, stepType, stepNum)

        With Me
            .u1 = u1
            .u2 = u2
            .u3 = u3
            .r1 = r1
            .r2 = r2
            .r3 = r3
        End With
    End Sub



    'METHODS ****************************************************************

    'GETTERS and SETTERS *********************

    'Setters
    Public Sub setU1(u1 As Double())
        Me.u1 = u1
    End Sub
    Public Sub setU2(u2 As Double())
        Me.u2 = u2
    End Sub
    Public Sub setU3(u3 As Double())
        Me.u3 = u3
    End Sub
    Public Sub setR1(r1 As Double())
        Me.r1 = r1
    End Sub
    Public Sub setR2(r2 As Double())
        Me.r2 = r2
    End Sub
    Public Sub setR3(r3 As Double())
        Me.r3 = r3
    End Sub


    'Getters
    Public Function getU1() As Double()
        Return Me.u1
    End Function
    Public Function getU2() As Double()
        Return Me.u2
    End Function
    Public Function getU3() As Double()
        Return Me.u3
    End Function
    Public Function getR1() As Double()
        Return Me.r1
    End Function
    Public Function getR2() As Double()
        Return Me.r2
    End Function
    Public Function getR3() As Double()
        Return Me.r3
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
        hash = Me.numberResults + Me.obj.GetHashCode() + CInt(Me.u1.Average() + Me.r1.Average() + Me.u3.Average())
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
        Dim nDispsObj As NodalDisplacements
        nDispsObj = CType(obj, NodalDisplacements)

        '3. Check if main attributes are equal
        ' - Note : Equals method has to be used to compare all attributes since they are all Arrays/Lists so...other 
        '   data structures...they're not primitive type objects!
        If (Me.getElm.Equals(nDispsObj.getElm) And Me.getObj.Equals(nDispsObj.getObj) And
           Me.getU1.Equals(nDispsObj.getU1) And Me.getU2.Equals(nDispsObj.getU2) And Me.getU3.Equals(nDispsObj.getU3) And
           Me.getR1.Equals(nDispsObj.getR1) And Me.getR2.Equals(nDispsObj.getR2) And Me.getR3.Equals(nDispsObj.getR3)) Then
            Return True
        Else
            Return False
        End If

    End Function
End Class
