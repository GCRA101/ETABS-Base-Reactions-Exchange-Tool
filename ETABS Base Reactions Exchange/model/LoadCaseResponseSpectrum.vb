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

    End Class

End Namespace