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




    End Class

End Namespace