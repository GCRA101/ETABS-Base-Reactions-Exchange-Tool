Namespace model

    Public Class LoadCaseResponseSpectrum
        Inherits LoadCase

        'ATTRIBUTES
        Private modalCaseName As String
        Private functions() As String
        Private csys() As String
        Private scaleFactors(), ang(), eccen As Double

        'CONSTRUCTORS
        'Default
        Public Sub New()
            MyBase.New()
        End Sub
        'Overloaded
        Public Sub New(loadCaseName As String, modalCaseName As String, numLoads As Integer, loadNames() As String,
                       functions() As String, csys() As String, scaleFactors() As Double, ang() As Double, eccen As Double)
            MyBase.New(loadCaseName, numLoads, loadNames)
            Me.modalCaseName = modalCaseName
            Me.functions = functions
            Me.csys = csys
            Me.scaleFactors = scaleFactors
            Me.ang = ang
            Me.eccen = eccen
        End Sub


        'METHODS

        'Setters
        Public Sub setModalCaseName(modalCaseName As String)
            Me.modalCaseName = modalCaseName
        End Sub
        Public Sub setFunctions(functions() As String)
            Me.functions = functions
        End Sub
        Public Sub setCSys(csys() As String)
            Me.csys = csys
        End Sub
        Public Sub setScaleFactors(scaleFactors() As Double)
            Me.scaleFactors = scaleFactors
        End Sub
        Public Sub setAng(ang() As Double)
            Me.ang = ang
        End Sub
        Public Sub setEccen(eccen As Double)
            Me.eccen = eccen
        End Sub

        'Getters
        Public Function getModalCaseName() As String
            Return Me.modalCaseName
        End Function
        Public Function getFunctions() As String()
            Return Me.functions
        End Function
        Public Function getCSys() As String()
            Return Me.csys
        End Function
        Public Function getScaleFactors() As Double()
            Return Me.scaleFactors
        End Function
        Public Function getAng() As Double()
            Return Me.ang
        End Function
        Public Function getEccen() As Double
            Return Me.eccen
        End Function



        'HASHCODE

        'Method inherited from the Object superclass and that has to be overwritten in order to generate
        'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        'The hashcode is essential to be able to sort and store instances of this class properly 
        'in whatever concrete implementation of the abstract data structure Hash Table.
        Public Overrides Function GetHashCode() As Integer
            'Determines and returns the Hashcode of the class instance as the number given by the sum 
            'of the corresponding superclass' hashCode + the output of an additional hashing function
            'working on the local attributes scaleFactors, ang and eccen
            Dim hash As Integer
            hash = MyBase.GetHashCode() + CInt(Math.Round(CDec(scaleFactors.Sum() + ang.Sum() + eccen)))
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
            Dim lcrsObj As LoadCaseResponseSpectrum
            lcrsObj = CType(obj, LoadCaseResponseSpectrum)
            '3. Compare the two instances of the class giving precedence to the superclass comparer
            '   then the modalCaseName
            If MyBase.CompareTo(lcrsObj) <> 0 Then
                Return MyBase.CompareTo(lcrsObj)
            ElseIf Me.modalCaseName.CompareTo(lcrsObj.getModalCaseName) <> 0 Then
                Return Me.modalCaseName.CompareTo(lcrsObj.getModalCaseName)
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
            Dim lcrsObj As LoadCaseResponseSpectrum
            lcrsObj = CType(obj, LoadCaseResponseSpectrum)

            '3. Check if modalCaseName and all functions and corresponding factors are the same
            If MyBase.Equals(lcrsObj) And
                Me.getModalCaseName.Equals(lcrsObj.getModalCaseName) And
                Me.functions.SequenceEqual(lcrsObj.getFunctions) And
                Me.scaleFactors.SequenceEqual(lcrsObj.getScaleFactors) Then
                Return True
            Else
                Return False
            End If

        End Function

    End Class

End Namespace