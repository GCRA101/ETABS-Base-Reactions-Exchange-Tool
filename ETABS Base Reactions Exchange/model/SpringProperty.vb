Public Class SpringProperty
    Inherits ETABSData

    ' ATTRIBUTES  **********************************************************************
    Private name As String
    Private stiffnessValues As Double()
    Private u1, u2, u3, r1, r2, r3 As Double
    Private color As ColorInterface
    Private description As String


    ' CONSTRUCTORS  ********************************************************************

    'Overloaded 1
    Public Sub New(name As String)
        Me.name = name
    End Sub
    'Overloaded 2
    Public Sub New(name As String, stiffnessValues As Double())
        Me.New(name)
        Me.stiffnessValues = stiffnessValues
    End Sub
    'Overloaded 3
    Public Sub New(name As String, stiffnessValues As Double(), color As ColorInterface)
        Me.New(name, stiffnessValues)
        Me.color = color
    End Sub


    ' METHODS *************************************************************************


    'Setters
    Public Sub setName(name As String)
        Me.name = name
    End Sub
    Public Sub setStiffnessValues(stiffnessValues As Double())
        Me.stiffnessValues = stiffnessValues
    End Sub
    Public Sub setU1(u1 As Double)
        Me.u1 = u1
    End Sub
    Public Sub setU2(u2 As Double)
        Me.u2 = u2
    End Sub
    Public Sub setU3(u3 As Double)
        Me.u3 = u3
    End Sub
    Public Sub setR1(r1 As Double)
        Me.r1 = r1
    End Sub
    Public Sub setR2(r2 As Double)
        Me.r2 = r2
    End Sub
    Public Sub setR3(r3 As Double)
        Me.r3 = r3
    End Sub
    Public Sub setColor(color As ColorInterface)
        Me.color = color
    End Sub
    Public Sub setDescription(description As String)
        Me.description = description
    End Sub


    'Getters
    Public Function getName() As String
        Return Me.name
    End Function
    Public Function getStiffnessValues() As Double()
        Return Me.stiffnessValues
    End Function
    Public Function getU1() As Double
        Return Me.u1
    End Function
    Public Function getU2() As Double
        Return Me.u2
    End Function
    Public Function getU3() As Double
        Return Me.u3
    End Function
    Public Function getR1() As Double
        Return Me.r1
    End Function
    Public Function getR2() As Double
        Return Me.r2
    End Function
    Public Function getR3() As Double
        Return Me.r3
    End Function
    Public Function getColor() As ColorInterface
        Return Me.color
    End Function
    Public Function getDescription() As String
        Return Me.description
    End Function


    'HASHCODE

    'Method inherited from the Object superclass and that has to be overwritten in order to generate
    'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    'The hashcode is essential to be able to sort and store instances of this class properly 
    'in whatever concrete implementation of the abstract data structure Hash Table.
    Public Overrides Function GetHashCode() As Integer
        'Determines and returns the Hashcode of the class instance as the number given by the sum 
        'of the name's corresponding hashcode plus the integer sum of the stiffness values u1,u2,u3,r1,r2,r3.
        Dim hash As Integer
        hash = Me.getName.GetHashCode + CInt(Me.u1 + Me.u2 + Me.u3 + Me.r1 + Me.r2 + Me.r3)
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
        '1. Check input Obj Data Type to match the present Class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return Nothing
        End If
        '2. Down-Cast the input Object to the SpringProperty Class
        Dim spObj As SpringProperty
        spObj = CType(obj, SpringProperty)
        '3. Compare the two instances of the class giving precedence to the name and then to the other attributes
        If Me.name.GetHashCode > spObj.GetHashCode Then
            Return 1
        ElseIf Me.name.GetHashCode < spObj.GetHashCode Then
            Return -1
        Else
            If Me.stiffnessValues.Sum() < spObj.getStiffnessValues().Sum() Then
                Return -1
            ElseIf Me.stiffnessValues.Sum() > spObj.getStiffnessValues().Sum() Then
                Return 1
            End If
        End If
        Return 0
    End Function


    'EQUALS

    'Method inherited from the Object superclass and that gets called everytime we check whether 
    'two instances of this class are equal or not. 
    'It has to be overwritten based on the values assigned to the attributes of the class instances
    Public Overrides Function Equals(obj As Object) As Boolean

        '1. Check input Obj Data Type to match the SpringProperty Class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return False
        End If

        '2. Down-Cast the input Object to the SpringProperty Class
        Dim spObj As SpringProperty
        spObj = CType(obj, SpringProperty)

        '3. Check if all attributes and name of the two objects are equal or not
        If Me.getName = spObj.getName And
           Me.stiffnessValues Is spObj.getStiffnessValues() Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
