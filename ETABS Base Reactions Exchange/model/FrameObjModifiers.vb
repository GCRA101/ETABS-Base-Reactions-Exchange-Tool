Public Class FrameObjModifiers
    Inherits ObjModifiers

    'ATTRIBUTES
    Private crossSectionArea, shearArea2, shearArea3, torsion, momentOfInertia2, momentOfIntertia3 As Double

    'CONSTRUCTOR
    'Default
    Public Sub New()
        MyBase.New()
    End Sub
    'Overloaded
    Public Sub New(name As String, crossSectionArea As Double, shearArea2 As Double, shearArea3 As Double,
                   torsion As Double, momentOfInertia2 As Double, momentOfInertia3 As Double)
        MyBase.New(name)
        With Me
            .crossSectionArea = crossSectionArea
            .shearArea2 = shearArea2
            .shearArea3 = shearArea3
            .torsion = torsion
            .momentOfInertia2 = momentOfInertia2
            .momentOfIntertia3 = momentOfInertia3
        End With
        Me.setValues(crossSectionArea, shearArea2, shearArea3, torsion, momentOfInertia2, momentOfInertia3)

    End Sub


    'METHODS

    'Setters and Getters

    Public Sub setValues(crossSectionArea As Double, shearArea2 As Double, shearArea3 As Double,
                   torsion As Double, momentOfInertia2 As Double, momentOfInertia3 As Double)
        Me.values = New Double() {crossSectionArea, shearArea2, shearArea3, torsion, momentOfInertia2, momentOfInertia3}
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
            CInt(Math.Round(CDec((crossSectionArea + 3 * shearArea2 + shearArea3 - momentOfInertia2) * 10)))
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
        Dim fomObj As FrameObjModifiers
        fomObj = CType(obj, FrameObjModifiers)
        '3. Compare the two instances of the class giving precedence to name and then number of factors
        If Me.getName.CompareTo(fomObj.getName()) <> 0 Then
            Return Me.getName.CompareTo(fomObj.getName())
        ElseIf Me.getValues.Count < fomObj.getValues.Count Then
            Return -1
        ElseIf Me.getValues.Count > fomObj.getValues.Count Then
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
        Dim fomObj As FrameObjModifiers
        fomObj = CType(obj, FrameObjModifiers)

        '3. Check if all coordinates and name of the two objects are equal or not
        If Me.getName.Equals(fomObj.getName()) And
                Me.getValues().Equals(fomObj.getValues()) Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
