Namespace model

    Public MustInherit Class LoadCase
        Inherits ETABSData

        'ATTRIBUTES'
        Protected loadCaseName As String
        Protected numLoads As Integer
        Protected loadNames() As String

        'CONSTRUCTOR'
        'Default
        Public Sub New()
        End Sub
        'Overloaded
        Public Sub New(loadCaseName As String, numLoads As Integer, loadNames() As String)
            With Me
                .loadCaseName = loadCaseName
                .numLoads = numLoads
                .loadNames = loadNames
            End With
        End Sub

        'METHODS'

        'Setters
        Public Sub setLoadCaseName(loadCaseName As String)
            Me.loadCaseName = loadCaseName
        End Sub
        Public Sub setNumLoads(numLoads As Integer)
            Me.numLoads = numLoads
        End Sub
        Public Sub setLoadNames(loadNames() As String)
            Me.loadNames = loadNames
        End Sub


        'Getters
        Public Function getLoadCaseName() As String
            Return Me.loadCaseName
        End Function
        Public Function getNumLoads() As Integer
            Return Me.numLoads
        End Function
        Public Function getLoadNames() As String()
            Return Me.loadNames
        End Function


        'HASHCODE

        'Method inherited from the Object superclass and that has to be overwritten in order to generate
        'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        'The hashcode is essential to be able to sort and store instances of this class properly 
        'in whatever concrete implementation of the abstract data structure Hash Table.
        Public Overrides Function GetHashCode() As Integer
            'Determines and returns the Hashcode of the class instance as the number given by the sum 
            'of the name's corresponding hashcode plus the number of load patterns
            Dim hash As Integer
            hash = Me.loadCaseName.GetHashCode() + Me.getNumLoads()
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
            Dim lcObj As LoadCase
            lcObj = CType(obj, LoadCase)
            '3. Compare the two instances of the class giving precedence to the name and the number of loads
            If Me.loadCaseName.CompareTo(lcObj.getLoadCaseName) <> 0 Then
                Return Me.loadCaseName.CompareTo(lcObj.getLoadCaseName)
            ElseIf Me.getNumLoads < lcObj.getNumLoads Then
                Return -1
            ElseIf Me.getNumLoads > lcObj.getNumLoads Then
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
            Dim lcObj As LoadCase
            lcObj = CType(obj, LoadCase)

            '3. Check if loadcase name, initial load case name and all factors are the same
            If Me.getLoadCaseName.Equals(lcObj.getLoadCaseName) And
               Me.numLoads = lcObj.getNumLoads And
               Me.getLoadNames.Equals(lcObj.getLoadNames) Then
                Return True
            Else
                Return False
            End If

        End Function


    End Class

End Namespace
