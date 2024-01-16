Namespace model

    Public Class LoadCaseModalRitz
        Inherits LoadCaseModal

        'ATTRIBUTES
        Private ritzMaxCyc() As Integer

        'CONSTRUCTORS
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(loadCaseName As String, initalCaseName As String, numLoads As Integer, loadTypes() As String, loadNames() As String,
                       numModesMax As Integer, numModesMin As Integer, targetParams() As Double, ritzMaxCyc() As Integer)
            MyBase.New(loadCaseName, initalCaseName, numLoads, loadTypes, loadNames, numModesMax, numModesMin, targetParams)
            Me.ritzMaxCyc = ritzMaxCyc
        End Sub


        'METHODS

        'Setters
        Public Sub setRitzMaxCyc(ritzMaxCyc As Integer())
            Me.ritzMaxCyc = ritzMaxCyc
        End Sub

        'Getters
        Public Function getRitzMaxCyc() As Integer()
            Return Me.ritzMaxCyc
        End Function


        'HASHCODE

        'Method inherited from the Object superclass and that has to be overwritten in order to generate
        'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        'The hashcode is essential to be able to sort and store instances of this class properly 
        'in whatever concrete implementation of the abstract data structure Hash Table.
        Public Overrides Function GetHashCode() As Integer
            'Determines and returns the Hashcode of the class instance as the number given by the sum 
            'of the corresponding superclass' hashcode plus the sum of all the ritzMaxCyc factors
            Dim hash As Integer
            hash = MyBase.GetHashCode() + Math.Round(CDec(ritzMaxCyc.Sum()))
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
            Dim lcmrObj As LoadCaseModalRitz
            lcmrObj = CType(obj, LoadCaseModalRitz)
            '3. Compare the two instances of the class giving precedence to the superclass' method
            '   then the RitzMaxCyc attribute
            If MyBase.CompareTo(lcmrObj) <> 0 Then
                Return MyBase.CompareTo(lcmrObj)
            ElseIf Me.ritzMaxCyc.Sum() > lcmrObj.getRitzMaxCyc.Sum() Then
                Return 1
            ElseIf Me.ritzMaxCyc.Sum() < lcmrObj.getRitzMaxCyc.Sum() Then
                Return -1
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
            Dim lcmrObj As LoadCaseModalRitz
            lcmrObj = CType(obj, LoadCaseModalRitz)

            '3. Check if all the local attributes are assigned with same values
            If MyBase.Equals(lcmrObj) And
               Me.ritzMaxCyc.Sum() = lcmrObj.getRitzMaxCyc.Sum() Then
                Return True
            Else
                Return False
            End If

        End Function

    End Class


End Namespace
