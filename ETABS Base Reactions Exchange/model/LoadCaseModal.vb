Namespace model

    Public MustInherit Class LoadCaseModal
        Inherits LoadCase

        'ATTRIBUTES
        Protected initialCaseName As String
        Protected loadTypes() As String
        Protected numModesMax, numModesMin As Integer
        Protected targetParams() As Double

        'CONSTRUCTORS
        'Default
        Public Sub New()
            MyBase.New()
        End Sub
        'Overloaded
        Public Sub New(loadCaseName As String, initalCaseName As String, numLoads As Integer, loadTypes() As String,
                       loadNames() As String, numModesMax As Integer, numModesMin As Integer, targetParams() As Double)
            MyBase.New(loadCaseName, numLoads, loadNames)
            Me.initialCaseName = initialCaseName
            Me.loadTypes = loadTypes
            Me.numModesMax = numModesMax
            Me.numModesMin = numModesMin
            Me.targetParams = targetParams
        End Sub

        'METHODS

        'Setters
        Public Sub setInitialCaseName(initialCaseName As String)
            Me.initialCaseName = initialCaseName
        End Sub
        Public Sub setLoadTypes(loadTypes() As String)
            Me.loadTypes = loadTypes
        End Sub
        Public Sub setNumModesMax(numModesMax As Integer)
            Me.numModesMax = numModesMax
        End Sub
        Public Sub setNumModesMin(numModesMin As Integer)
            Me.numModesMin = numModesMin
        End Sub
        Public Sub setTargetParams(targetParams() As Double)
            Me.targetParams = targetParams
        End Sub


        'Getters
        Public Function getInitialCaseName() As String
            Return Me.initialCaseName
        End Function
        Public Function getLoadTypes() As String()
            Return Me.loadTypes
        End Function
        Public Function getNumModesMax() As Integer
            Return Me.numModesMax
        End Function
        Public Function getNumModesMin() As Integer
            Return Me.numModesMin
        End Function
        Public Function getTargetParams() As Double()
            Return Me.targetParams
        End Function



        'HASHCODE

        'Method inherited from the Object superclass and that has to be overwritten in order to generate
        'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        'The hashcode is essential to be able to sort and store instances of this class properly 
        'in whatever concrete implementation of the abstract data structure Hash Table.
        Public Overrides Function GetHashCode() As Integer
            'Determines and returns the Hashcode of the class instance as the number given by the sum 
            'of the corresponding superclass' hashcode plus the name's corresponding hashcode
            'plus the hashcode of the loadTypes array and the sum of NumModesMax and NumModesMin
            Dim hash As Integer
            hash = MyBase.GetHashCode() + Me.initialCaseName.GetHashCode() +
                    Me.loadTypes.GetHashCode() + Me.numModesMax + Me.numModesMin
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
            Dim lcmObj As LoadCaseModal
            lcmObj = CType(obj, LoadCaseModal)
            '3. Compare the two instances of the class giving precedence to the superclass' method
            '   then the initialCaseName and finally the NumModesMax
            If MyBase.CompareTo(lcmObj) <> 0 Then
                Return MyBase.CompareTo(lcmObj)
            ElseIf Me.initialCaseName.CompareTo(lcmObj.getInitialCaseName()) <> 0 Then
                Return Me.initialCaseName.CompareTo(lcmObj.getInitialCaseName())
            ElseIf Me.numModesMax > lcmObj.getNumModesMax Then
                Return 1
            ElseIf Me.numModesMax < lcmObj.getNumModesMax Then
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
            Dim lcmObj As LoadCaseModal
            lcmObj = CType(obj, LoadCaseModal)

            '3. Check if loadcase name, initial load case name and all factors are the same
            If MyBase.Equals(lcmObj) And
               Me.initialCaseName.Equals(lcmObj.getInitialCaseName) And
               Me.getLoadTypes.SequenceEqual(lcmObj.getLoadTypes) And
               Me.numModesMax = lcmObj.getNumModesMax() Then
                Return True
            Else
                Return False
            End If

        End Function


    End Class



End Namespace
