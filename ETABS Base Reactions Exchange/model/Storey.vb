Public Class Storey
    Inherits ETABSData

    'ATTRIBUTES
    Private name As String
    Private elevation, height As Double
    Private isMaster As Boolean
    Private guid As String

    'CONSTRUCTORS
    'Overloaded 01
    Public Sub New(name As String)
        Me.name = name
    End Sub
    'Overloaded 02
    Public Sub New(name As String, elevation As Double, height As Double,
                   isMaster As Boolean, guid As String)
        Me.name = name
        Me.elevation = elevation
        Me.height = height
        Me.isMaster = isMaster
        Me.guid = guid
    End Sub

    'METHODS

    'Setters and Getters
    Public Sub setName(name As String)
        Me.name = name
    End Sub
    Public Sub setElevation(elevation As Double)
        Me.elevation = elevation
    End Sub
    Public Sub setHeight(height As Double)
        Me.height = height
    End Sub
    Public Sub setMaster(isMaster As Boolean)
        Me.isMaster = isMaster
    End Sub
    Public Sub setGuid(guid As String)
        Me.guid = guid
    End Sub
    Public Function getName() As String
        Return Me.name
    End Function
    Public Function getElevation() As Double
        Return Me.elevation
    End Function
    Public Function getHeight() As Double
        Return Me.height
    End Function
    Public Function getMaster() As Boolean
        Return Me.isMaster
    End Function
    Public Function getGuid() As String
        Return Me.guid
    End Function


    'HASHCODE

    'Method inherited from the Object superclass and that has to be overwritten in order to generate
    'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    'The hashcode is essential to be able to sort and store instances of this class properly 
    'in whatever concrete implementation of the abstract data structure Hash Table.
    Public Overrides Function GetHashCode() As Integer
        'Determines and returns the Hashcode of the class instance as the number given by the sum 
        'of the name's corresponding hashcode plus the integer result of a local hashing function
        'working with the values assigned to the other attributes.
        Dim hash As Integer
        hash = Me.getName.GetHashCode +
            CInt(Math.Round(CDec((Me.elevation + Me.height))))
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
        Dim strObj As Storey
        strObj = CType(obj, Storey)
        '3. Compare the two instances of the class giving precedence to name, elevation and height
        If Me.getName.CompareTo(strObj.getName()) <> 0 Then
            Return Me.getName.CompareTo(strObj.getName())
        ElseIf Me.getElevation < strObj.getElevation Then
            Return -1
        ElseIf Me.getElevation > strObj.getElevation Then
            Return 1
        End If
        Return 0
    End Function


    'EQUALS

    'Method inherited from the Object superclass and that gets called everytime we check whether 
    'two instances of this class are equal or not. 
    'It has to be overwritten based on the values assigned to the attributes of the class instances
    Public Overrides Function Equals(obj As Object) As Boolean

        '1. Check input Obj Data Type to match the current class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return False
        End If

        '2. Down-Cast the input object to the current class
        Dim strObj As Storey
        strObj = CType(obj, Storey)

        '3. Check if the main attributes of the two objects are equal or not
        If Me.getName.Equals(strObj.getName()) And
                Me.getElevation = strObj.getElevation And
                Me.getHeight = strObj.getHeight And
                Me.getGuid.Equals(strObj.getGuid()) Then
            Return True
        Else
            Return False
        End If

    End Function



End Class
