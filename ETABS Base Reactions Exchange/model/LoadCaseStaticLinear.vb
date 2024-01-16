Namespace model

    Public Class LoadCaseStaticLinear
        Inherits LoadCaseStatic

        'ATTRIBUTES
        'All inherited from super-classes

        'CONSTRUCTORS
        'Default
        Public Sub New()
            'Call the default super-constructor
            MyBase.New()
        End Sub
        'Overloaded
        Public Sub New(loadCaseName As String, initialCaseName As String, numLoads As Integer,
                       loadTypes() As String, loadNames() As String, sfs() As Double)
            'Call the overloaded super-constructor
            MyBase.New(loadCaseName, initialCaseName, numLoads, loadTypes, loadNames, sfs)
        End Sub


        'METHODS
        'All inherited from super-classes

    End Class


End Namespace