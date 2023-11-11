Namespace model

    Public MustInherit Class LoadCase

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

    End Class

End Namespace
