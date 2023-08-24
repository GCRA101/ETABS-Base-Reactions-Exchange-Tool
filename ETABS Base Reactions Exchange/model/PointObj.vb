Public Class PointObj
    Implements IComparable

    'ATTRIBUTES  **********************************************************************
    Private name As String
    Private x, y, z As Double


    'CONSTRUCTOR  *********************************************************************

    'Default
    Public Sub New()
    End Sub
    'Overloaded
    Public Sub New(name As String, x As Double, y As Double, z As Double)
        Me.name = name
        Me.x = x
        Me.y = y
        Me.z = z
    End Sub


    'METHODS  **************************************************************************

    'Setters
    Public Sub setName(name As String)
        Me.name = name
    End Sub
    Public Sub setX(x As Double)
        Me.x = x
    End Sub
    Public Sub setY(y As Double)
        Me.y = y
    End Sub
    Public Sub setZ(z As Double)
        Me.z = z
    End Sub

    'Getters
    Public Function getName()
        Return Me.name
    End Function
    Public Function getX()
        Return Me.x
    End Function
    Public Function getY()
        Return Me.y
    End Function
    Public Function getZ()
        Return Me.z
    End Function


    'HASHCODE

    'Method inherited from the Object superclass and that has to be overwritten in order to generate
    'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    'The hashcode is essential to be able to sort and store instances of this class properly 
    'in whatever concrete implementation of the abstract data structure Hash Table.
    Public Overrides Function GetHashCode() As Integer
        'Determines and returns the Hashcode of the class instance as the number given by the sum 
        'of the name's corresponding hashcode plus the integer sum of the x,y and z coordinates
        'of the point object.
        Dim hash As Integer
        hash = Me.getName.GetHashCode + CInt(Me.getX() + Me.getY() + Me.getZ())
        Return hash
    End Function


    'COMPARETO

    'Method implemented from the IComparable Functional Interface which unique method CompareTo 
    'gets called everytime we want to compare an instance of this class with another object.
    'The method needs to be implemented accordingly with the criteria we want to use to define
    'which object is greater or smaller than the other based on the values assigned to its 
    'attributes.
    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        Throw New NotImplementedException()
        '1. Check input Obj Data Type to match the PointObj Class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return Nothing
        End If
        '2. Down-Cast the input Object to the PointObjClass
        Dim ppObj As PointObj
        ppObj = CType(obj, PointObj)
        '3. Compare the two instances of the class giving precedence to coordinates and then to name
        If (Me.getX + Me.getY + Me.getZ) > (ppObj.getX + ppObj.getY + ppObj.getZ) Then
            Return 1
        ElseIf (Me.getX + Me.getY + Me.getZ) < (ppObj.getX + ppObj.getY + ppObj.getZ) Then
            Return -1
        Else
            If Me.getName < ppObj.getName Then
                Return -1
            ElseIf Me.getName > ppObj.getName Then
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

        '1. Check input Obj Data Type to match the PointObj Class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return False
        End If

        '2. Down-Cast the input object to the PointObj Class
        Dim ppObj As PointObj
        ppObj = CType(obj, PointObj)

        '3. Check if all coordinates and name of the two objects are equal or not
        If Me.getName = ppObj.getName And
           Me.getX = ppObj.getX And
           Me.getY = ppObj.getY And
           Me.getZ = ppObj.getZ Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
