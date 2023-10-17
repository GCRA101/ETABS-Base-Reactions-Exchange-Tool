Imports ETABS_Base_Reactions_Exchange.model

Public Class AreaObj
    Implements IComparable

    'ATTRIBUTES
    Private name As String
    Private points As List(Of PointObj)
    Private areaProperty As AreaObjProperty
    Private groupName As String
    Private propertyModifiers As AreaObjModifiers

    'CONSTRUCTORS
    'Default
    Public Sub New()
    End Sub
    'Overloaded1
    Public Sub New(name As String)
        Me.name = name
    End Sub
    'Overloaded2
    Public Sub New(name As String, points As List(Of PointObj), areaProperty As AreaObjProperty, Optional groupName As String = "",
                   Optional propertyModifiers As AreaObjModifiers = Nothing)
        Me.name = name
        Me.points = points
        Me.areaProperty = areaProperty
        Me.groupName = groupName
        Me.propertyModifiers = propertyModifiers
    End Sub
    'Overloaded3
    Public Sub New(name As String, groupName As String, propertyModifiers As AreaObjModifiers)
        Me.name = name
        Me.groupName = groupName
        Me.propertyModifiers = propertyModifiers
    End Sub


    'METHODS

    'Setters
    Public Sub setName(name As String)
        Me.name = name
    End Sub
    Public Sub setPoints(points As List(Of PointObj))
        Me.points = points
    End Sub
    Public Sub setAreaProperty(areaProperty As areaObjProperty)
        Me.areaProperty = areaProperty
    End Sub
    Public Sub setGroupName(groupName As String)
        Me.groupName = groupName
    End Sub
    Public Sub setPropertyModifiers(propertyModifiers As AreaObjModifiers)
        Me.propertyModifiers = propertyModifiers
    End Sub

    'Getters
    Public Function getName() As String
        Return Me.name
    End Function
    Public Function getPoints() As List(Of PointObj)
        Return Me.points
    End Function

    Public Function getAreaProperty() As areaObjProperty
        Return Me.areaProperty
    End Function
    Public Function getGroupName() As String
        Return Me.groupName
    End Function
    Public Function getPropertyModifiers() As AreaObjModifiers
        Return Me.propertyModifiers
    End Function



    'HASHCODE

    'Method inherited from the Object superclass and that has to be overwritten in order to generate
    'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    'The hashcode is essential to be able to sort and store instances of this class properly 
    'in whatever concrete implementation of the abstract data structure Hash Table.
    Public Overrides Function GetHashCode() As Integer
        'Determines and returns the Hashcode of the class instance as the integer number given 
        'by the sum of the hashcodes of the name and the corner points
        Return Me.name.GetHashCode() '+ Me.getPoints().GetHashCode()
    End Function


    'COMPARETO

    'Method implemented from the IComparable Functional Interface which unique method CompareTo 
    'gets called everytime we want to compare an instance of this class with another object.
    'The method needs to be implemented accordingly with the criteria we want to use to define
    'which object is greater or smaller than the other based on the values assigned to its 
    'attributes.
    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        '1. Check input Obj Data Type to match the AreaObj Class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return Nothing
        End If
        '2. Down-Cast the input Object to the AreaObjClass
        Dim areaObj As AreaObj
        areaObj = CType(obj, AreaObj)
        '3. Compare the two instances of the class giving precedence to the name
        Return Me.getName.CompareTo(areaObj.getName())
    End Function


    'EQUALS

    'Method inherited from the Object superclass and that gets called everytime we check whether 
    'two instances of this class are equal or not. 
    'It has to be overwritten based on the values assigned to the attributes of the class instances
    Public Overrides Function Equals(obj As Object) As Boolean

        '1. Check input Obj Data Type to match the AreaObj Class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return False
        End If

        '2. Down-Cast the input Object to the AreaObjClass
        Dim areaObj As AreaObj
        areaObj = CType(obj, AreaObj)

        '3. Check if the name and the list of corner points of the two objects area the same
        If Me.getName.Equals(areaObj.getName) And Me.getPoints.Equals(areaObj.getPoints) Then
            Return True
        End If

        Return False

    End Function


End Class
