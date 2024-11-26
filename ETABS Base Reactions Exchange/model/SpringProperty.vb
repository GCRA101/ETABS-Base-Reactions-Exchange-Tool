Public Class SpringProperty
    Inherits ETABSProperty

    ' ATTRIBUTES  **********************************************************************
    Private springObject As SpringObject


    ' CONSTRUCTORS  ********************************************************************
    'Default
    Public Sub New()
    End Sub
    'Overloaded 1
    Public Sub New(name As String)
        MyBase.New(name)
    End Sub
    'Overloaded 2
    Public Sub New(name As String, springObject As SpringObject)
        Me.New(name)
        Me.springObject = springObject
    End Sub
    'Overloaded 3
    Public Sub New(name As String, springObject As SpringObject, color As ColorInterface)
        Me.New(name, springObject)
        Me.color = color
    End Sub


    ' METHODS *************************************************************************

    'Setters and Getters
    Public Sub setSpringObject(springObject As SpringObject)
        Me.springObject = springObject
    End Sub

    Public Function getSpringObject() As SpringObject
        Return Me.springObject
    End Function


    'HASHCODE

    'Method inherited from the Object superclass and that has to be overwritten in order to generate
    'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    'The hashcode is essential to be able to sort and store instances of this class properly 
    'in whatever concrete implementation of the abstract data structure Hash Table.
    Public Overrides Function GetHashCode() As Integer
        'Determines and returns the Hashcode of the class instance as the number given by the sum 
        'of the hashcodes of the name, the color and the wrapped spring object
        Dim hash As Integer
        hash = Me.getName.GetHashCode + Me.color.GetHashCode() + Me.springObject.GetHashCode()
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
        Dim spProp As SpringProperty
        spProp = CType(obj, SpringProperty)
        '3. Compare the two instances of the class giving precedence to the name and then to the other attributes
        If Me.name.GetHashCode > spProp.GetHashCode Then
            Return 1
        ElseIf Me.name.GetHashCode < spProp.GetHashCode Then
            Return -1
        Else
            If Me.springObject.GetHashCode() < spProp.springObject.GetHashCode() Then
                Return -1
            ElseIf Me.springObject.GetHashCode() > spProp.springObject.GetHashCode() Then
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
        Dim spProp As SpringProperty
        spProp = CType(obj, SpringProperty)

        '3. Check if all attributes and name of the two objects are equal or not
        If Me.getName = spProp.getName And
           Me.springObject Is spProp.springObject Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
