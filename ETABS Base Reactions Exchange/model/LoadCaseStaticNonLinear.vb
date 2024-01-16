Namespace model


    Public Class LoadCaseStaticNonLinear
        Inherits LoadCaseStatic

        'ATTRIBUTES
        Private massSource As String
        Private modalCaseName As String
        Private nlGeomType As Integer

        'CONSTRUCTORS
        'Default
        Public Sub New()
            'Call the default super-constructor
            MyBase.New()
        End Sub
        'Overloaded
        Public Sub New(loadCaseName As String, initialCaseName As String, numLoads As Integer, loadTypes() As String,
                       loadNames() As String, sfs() As Double, massSource As String, modalCaseName As String, nlGeomType As Integer)
            'Call the overloaded super-constructor
            MyBase.New(loadCaseName, initialCaseName, numLoads, loadTypes, loadNames, sfs)
            'Assign additional attributes
            Me.massSource = massSource
            Me.modalCaseName = modalCaseName
            Me.nlGeomType = nlGeomType
        End Sub


        'METHODS

        'Setters
        Public Sub setMassSource(massSource As String)
            Me.massSource = massSource
        End Sub
        Public Sub setModalCaseName(modalCaseName As String)
            Me.modalCaseName = modalCaseName
        End Sub
        Public Sub setNlGeomType(nlGeomType As Integer)
            Me.nlGeomType = nlGeomType
        End Sub

        'Getters
        Public Function getMassSource() As String
            Return Me.massSource
        End Function
        Public Function getModalCaseName() As String
            Return Me.modalCaseName
        End Function
        Public Function getNlGeomType() As Integer
            Return Me.nlGeomType
        End Function


        'HASHCODE

        'Method inherited from the Object superclass and that has to be overwritten in order to generate
        'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
        'The hashcode is essential to be able to sort and store instances of this class properly 
        'in whatever concrete implementation of the abstract data structure Hash Table.
        Public Overrides Function GetHashCode() As Integer
            'Determines and returns the Hashcode of the class instance as the number given by the sum 
            'of the hashcode returned by the hashCode function of the superclass + the hashcodes corresponding
            'to the local attributes of this current class (massSource, modalCaseName and nlGeomType)
            Dim hash As Integer
            hash = MyBase.GetHashCode() + Me.massSource.GetHashCode + Me.modalCaseName.GetHashCode + Me.nlGeomType.GetHashCode
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
            Dim lcsnlObj As LoadCaseStaticNonLinear
            lcsnlObj = CType(obj, LoadCaseStaticNonLinear)
            '3. Compare the two instances of the class giving precedence to the comparison via the 
            '   CompareTo method definition of the superclass
            If MyBase.CompareTo(lcsnlObj) <> 0 Then
                Return MyBase.CompareTo(lcsnlObj)
            ElseIf Me.getNlGeomType < lcsnlObj.getNlGeomType Then
                Return -1
            ElseIf Me.getNlGeomType > lcsnlObj.getNlGeomType Then
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
            Dim lcsnlObj As LoadCaseStaticNonLinear
            lcsnlObj = CType(obj, LoadCaseStaticNonLinear)

            '3. Check if superclass equals method and local attributes return equality
            If MyBase.Equals(lcsnlObj) And
               Me.massSource.Equals(lcsnlObj.getMassSource) And
               Me.modalCaseName.Equals(lcsnlObj.getModalCaseName) And
               Me.nlGeomType = lcsnlObj.getNlGeomType Then
                Return True
            Else
                Return False
            End If

        End Function



    End Class

End Namespace