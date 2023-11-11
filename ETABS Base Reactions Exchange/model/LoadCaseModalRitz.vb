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

    End Class


End Namespace
