Public Class AreaDataSet
    Inherits ETABSData

    'ATTRIBUTES
    Private areaObj As AreaObj
    Private forces As ShellForces

    'CONSTRUCTORS
    'Default
    Public Sub New()
    End Sub
    'Overloaded
    Public Sub New(areaObj As AreaObj, forces As ShellForces)
        Me.areaObj = areaObj
        Me.forces = forces
    End Sub

    'METHODS

    'Setters
    Public Sub setAreaObj(areaObj As AreaObj)
        Me.areaObj = areaObj
    End Sub
    Public Sub setForces(forces As ShellForces)
        Me.forces = forces
    End Sub

    'Getters
    Public Function getAreaObj() As AreaObj
        Return Me.areaObj
    End Function
    Public Function getForces() As ShellForces
        Return Me.forces
    End Function



    'HASHCODE

    'Method inherited from the Object superclass and that has to be overwritten in order to generate
    'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    'The hashcode is essential to be able to sort and store instances of this class properly 
    'in whatever concrete implementation of the abstract data structure Hash Table.
    Public Overrides Function GetHashCode() As Integer
        'Determines and returns the Hashcode of the class instance as the integer number given 
        'by the sum of the hashcodes of the areaObj and of the shell forces
        Return Me.getAreaObj.GetHashCode + Me.getForces.GetHashCode
    End Function


    'COMPARETO

    'Method implemented from the IComparable Functional Interface which unique method CompareTo 
    'gets called everytime we want to compare an instance of this class with another object.
    'The method needs to be implemented accordingly with the criteria we want to use to define
    'which object is greater or smaller than the other based on the values assigned to its 
    'attributes.
    Public Overrides Function CompareTo(obj As Object) As Integer
        '1. Check input Obj Data Type to match the class of the present object
        If Not obj.GetType().Equals(Me.GetType) Then
            Return Nothing
        End If
        '2. Down-Cast the input Object to the AreaDataSet class
        Dim adsObj As AreaDataSet
        adsObj = CType(obj, AreaDataSet)
        '3. Compare the two instances of the class giving precedence to the Area Object
        Return Me.getAreaObj.CompareTo(adsObj.getAreaObj)
    End Function


    'EQUALS

    'Method inherited from the Object superclass and that gets called everytime we check whether 
    'two instances of this class are equal or not. 
    'It has to be overwritten based on the values assigned to the attributes of the class instances
    Public Overrides Function Equals(obj As Object) As Boolean

        '1. Check input Obj Data Type to match the class of the present object
        If Not obj.GetType().Equals(Me.GetType) Then
            Return False
        End If

        '2. Down-Cast the input Object to AreaDataSet class
        Dim adsObj As AreaDataSet
        adsObj = CType(obj, AreaDataSet)

        '3. Check if the areaObjects of the two objects are the same
        If Me.getAreaObj.Equals(adsObj.getAreaObj) And Me.forces.Equals(adsObj.getForces()) Then
            Return True
        End If

        Return False

    End Function

End Class
