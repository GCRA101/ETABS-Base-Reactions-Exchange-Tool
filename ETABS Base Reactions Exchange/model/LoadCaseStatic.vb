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
        Public Sub New(initialCaseName As String, numLoads As Integer, loadTypes() As String, loadNames() As String, sfs() As Double)
            'Call the overloaded super-constructor
            MyBase.New(numLoads, loadNames)
            'Assign additional attributes
            Me.initialCaseName = initialCaseName
            Me.loadTypes = loadTypes
            Me.sfs = sfs
        End Sub


        'METHODS'

        'Setters
        Protected Sub setInitialCaseName(initialCaseName As String)
            Me.initialCaseName = initialCaseName
        End Sub
        Protected Sub setLoadTypes(loadTypes() As String)
            Me.loadTypes = loadTypes
        End Sub
        Protected Sub setSfs(sfs() As Double)
            Me.sfs = sfs
        End Sub

        'Getters
        Protected Function getInitialCaseName() As String
            Return Me.initialCaseName
        End Function
        Protected Function getLoadTypes() As String()
            Return Me.loadTypes
        End Function
        Protected Function setSfs() As Double()
            Return Me.sfs
        End Function


    End Class


End Namespace