Namespace model

    Public MustInherit Class LoadCaseStatic
        Inherits LoadCase

        'ATTRIBUTES'
        Protected initialCaseName As String
        Protected loadTypes() As String
        Protected sfs() As Double

        'CONSTRUCTORS'
        'Default'
        Public Sub New()
            'Call the default super-constructor
            MyBase.New()
        End Sub

        'Overloaded'
        Public Sub New(loadCaseName As String, initialCaseName As String, numLoads As Integer, loadTypes() As String,
                       loadNames() As String, sfs() As Double)
            'Call the overloaded super-constructor
            MyBase.New(loadCaseName, numLoads, loadNames)
            'Assign additional attributes
            Me.initialCaseName = initialCaseName
            Me.loadTypes = loadTypes
            Me.sfs = sfs
        End Sub


        'METHODS'

        'Setters
        Public Sub setInitialCaseName(initialCaseName As String)
            Me.initialCaseName = initialCaseName
        End Sub
        Public Sub setLoadTypes(loadTypes() As String)
            Me.loadTypes = loadTypes
        End Sub
        Public Sub setSfs(sfs() As Double)
            Me.sfs = sfs
        End Sub

        'Getters
        Public Function getInitialCaseName() As String
            Return Me.initialCaseName
        End Function
        Public Function getLoadTypes() As String()
            Return Me.loadTypes
        End Function
        Public Function getSfs() As Double()
            Return Me.sfs
        End Function



        'HASHCODE

        'Method inherited from the Object superclass and that has to be overwritten in order to generate
        'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        'The hashcode is essential to be able to sort and store instances of this class properly 
        'in whatever concrete implementation of the abstract data structure Hash Table.
        Public Overrides Function GetHashCode() As Integer
            'Determines and returns the Hashcode of the class instance as the number given by the sum 
            'of the superclass' corresponding hashcode plus the hashcode of the loadTypes array and the sum
            'of all the sfs factors
            Dim hash As Integer
            hash = MyBase.GetHashCode + Me.loadTypes.GetHashCode() + Me.sfs.Sum()
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
            Dim lcsObj As LoadCaseStatic
            lcsObj = CType(obj, LoadCaseStatic)
            '3. Compare the two instances of the class giving precedence to superclass' method and
            '   initialCaseName
            If MyBase.CompareTo(lcsObj) <> 0 Then
                Return MyBase.CompareTo(lcsObj)
            ElseIf Me.getInitialCaseName.CompareTo(lcsObj.getInitialCaseName) <> 0 Then
                Return Me.getInitialCaseName.CompareTo(lcsObj.getInitialCaseName)
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
            Dim lcsObj As LoadCaseStaticLinear
            lcsObj = CType(obj, LoadCaseStaticLinear)

            '3. Check if loadcase name, initial load case name and all factors are the same
            If MyBase.Equals(lcsObj) And
               Me.getInitialCaseName.Equals(lcsObj.getInitialCaseName) And
               Me.getLoadTypes.SequenceEqual(lcsObj.getLoadTypes) And
               Me.sfs.SequenceEqual(lcsObj.getSfs) Then
                Return True
            Else
                Return False
            End If

        End Function


    End Class


End Namespace