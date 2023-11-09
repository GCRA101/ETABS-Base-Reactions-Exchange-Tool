Namespace model

    Public MustInherit Class LoadCase

        'ATTRIBUTES'
        Protected numLoads As Integer
        Protected loadNames() As String

        'CONSTRUCTOR'
        'Default
        Public Sub New()
        End Sub
        'Overloaded
        Public Sub New(numLoads As Integer, loadNames() As String)
            With Me
                .numLoads = numLoads
                .loadNames = loadNames
            End With
        End Sub

        'METHODS'

        'Setters
        Protected Sub setNumLoads(numLoads As Integer)
            Me.numLoads = numLoads
        End Sub
        Protected Sub setLoadNames(loadNames() As String)
            Me.loadNames = loadNames
        End Sub


        'Getters
        Protected Function getNumLoads() As Integer
            Return Me.numLoads
        End Function
        Protected Function getLoadNames() As String()
            Return Me.loadNames
        End Function

    End Class

End Namespace
