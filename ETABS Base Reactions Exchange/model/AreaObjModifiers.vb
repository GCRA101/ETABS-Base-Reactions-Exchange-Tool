Public Class AreaObjModifiers
    Inherits ObjModifiers

    'ATTRIBUTES
    Private f11, f22, f12, m11, m22, m12, v13, v23 As Double

    'CONSTRUCTOR
    'Default
    Public Sub New()
        MyBase.New()
    End Sub
    'Overloaded
    Public Sub New(name As String, f11 As Double, f22 As Double, f12 As Double, m11 As Double, m22 As Double,
                   m12 As Double, v13 As Double, v23 As Double, mass As Double, weight As Double)
        MyBase.New(name)
        With Me
            .f11 = f11
            .f22 = f22
            .f12 = f12
            .m11 = m11
            .m22 = m22
            .m12 = m12
            .v13 = v13
            .v23 = v23
            .mass = mass
            .weight = weight
        End With
        Me.setValues(f11, f22, f12, m11, m22, m12, v13, v23, mass, weight)
    End Sub


    'METHODS

    'Setters and Getters

    Public Sub setValues(f11 As Double, f22 As Double, f12 As Double, m11 As Double, m22 As Double,
                            m12 As Double, v13 As Double, v23 As Double, mass As Double, weight As Double)
        Me.values = New Double() {f11, f22, f12, m11, m22, m12, v13, v23, mass, weight}
    End Sub


    'HASHCODE

    'Method inherited from the Object superclass and that has to be overwritten in order to generate
    'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    'The hashcode is essential to be able to sort and store instances of this class properly 
    'in whatever concrete implementation of the abstract data structure Hash Table.
    Public Overrides Function GetHashCode() As Integer
        'Determines and returns the Hashcode of the class instance as the number given by the sum 
        'of the name's corresponding hashcode plus the integer result of a local hashing function
        'working with the values assigned to the obj modifiers.
        Dim hash As Integer
        hash = Me.getName.GetHashCode +
            CInt(Math.Round(CDec((f11 + 3 * f22 + f12 - m11 + m12 * v13 - v23 + mass + weight) * 10)))
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
        '1. Check input Obj Data Type to match the current class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return Nothing
        End If
        '2. Down-Cast the input Object to the current class
        Dim aomObj As AreaObjModifiers
        aomObj = CType(obj, AreaObjModifiers)
        '3. Compare the two instances of the class giving precedence to name and then number of factors
        If Me.getName.CompareTo(aomObj.getName()) <> 0 Then
            Return Me.getName.CompareTo(aomObj.getName())
        ElseIf Me.getValues.Count < aomObj.getValues.Count Then
            Return -1
        ElseIf Me.getValues.Count > aomObj.getValues.Count Then
            Return 1
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

        '2. Down-Cast the input object to the current class
        Dim aomObj As AreaObjModifiers
        aomObj = CType(obj, AreaObjModifiers)

        '3. Check if all coordinates and name of the two objects are equal or not
        If Me.getName.Equals(aomObj.getName()) And
                Me.getValues().Equals(aomObj.getValues()) Then
            Return True
        Else
            Return False
        End If

    End Function


End Class
