
Namespace model
    Public Class PointDataSet
        Inherits ETABSData

        'ATTRIBUTES *****************************************************************************
        Private Property point As PointObj
        Private Property reactions As PointReactions


        'CONSTRUCTOR *****************************************************************************
        'Default Constructor
        Public Sub New()
        End Sub
        'Overloaded Constructor 
        Public Sub New(point As PointObj, reactions As PointReactions)
            Me.point = point
            Me.reactions = reactions
        End Sub


        'METHODS  *********************************************************************************

        'GETTERS AND SETTERS

        'Setters
        Public Sub setPoint(point As PointObj)
            Me.point = point
        End Sub
        Public Sub setReactions(reactions As PointReactions)
            Me.reactions = reactions
        End Sub

        'Getters
        Public Function getPoint() As PointObj
            Return Me.point
        End Function

        Public Function getReactions() As PointReactions
            Return Me.reactions
        End Function


        'HASHCODE

        'Method inherited from the Object superclass and that has to be overwritten in order to generate
        'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        'The hashcode is essential to be able to sort and store instances of this class properly 
        'in whatever concrete implementation of the abstract data structure Hash Table.
        Public Overrides Function GetHashCode() As Integer
            'Determines and returns the Hashcode of the class instance as the integer number given 
            'by the sum of the hashcodes of the point and reactions attributes respectively.
            Dim hash As Integer
            hash = Me.getPoint.GetHashCode + Me.getReactions.GetHashCode
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
            '1. Check input Obj Data Type to match the PointObj Class
            If Not obj.GetType().Equals(Me.GetType) Then
                Return Nothing
            End If
            '2. Down-Cast the input Object to the PointObjClass
            Dim pdsObj As PointDataSet
            pdsObj = CType(obj, PointDataSet)
            '3. Compare the two instances of the class giving precedence to the point attribute and then reactions
            If (Me.getPoint.CompareTo(pdsObj.getPoint) <> 0) Then
                Return Me.getPoint.CompareTo(pdsObj.getPoint)
            ElseIf Me.getReactions.CompareTo(pdsObj.getReactions) <> 0 Then
                Return Me.getReactions.CompareTo(pdsObj.getReactions)
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

            '2. Down-Cast the input object to the PointDataSet Class
            Dim pdsObj As PointDataSet
            pdsObj = CType(obj, PointDataSet)

            '3. Check if point and reactions of the two class instances are equal or not
            If Me.getPoint.Equals(pdsObj.getPoint) And Me.getReactions.Equals(pdsObj.getReactions) Then
                Return True
            End If

            Return False

        End Function

    End Class

End Namespace
