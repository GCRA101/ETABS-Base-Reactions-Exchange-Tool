Namespace model

    Public Class LoadCaseModalEigen
        Inherits LoadCaseModal

        'ATTRIBUTES
        Private eigenShiftFreq, eigenCutOff, eigenTol As Double
        Private allowAutoFreqShift As Integer
        Private staticCorrect() As Boolean

        'CONSTRUCTORS
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(loadCaseName As String, initalCaseName As String, numLoads As Integer, loadTypes() As String, loadNames() As String,
                       numModesMax As Integer, numModesMin As Integer, targetParams() As Double, eigenShiftFreq As Double, eigenCutOff As Double,
                       eigenTol As Double, allowAutoFreqShift As Integer, staticCorrect() As Boolean)
            MyBase.New(loadCaseName, initalCaseName, numLoads, loadTypes, loadNames, numModesMax, numModesMin, targetParams)
            Me.eigenShiftFreq = eigenShiftFreq
            Me.eigenCutOff = eigenCutOff
            Me.eigenTol = eigenTol
            Me.allowAutoFreqShift = allowAutoFreqShift
            Me.staticCorrect = staticCorrect
        End Sub


        'METHODS

        'Setters
        Public Sub setEigenShiftFreq(eigenShiftFreq As Double)
            Me.eigenShiftFreq = eigenShiftFreq
        End Sub
        Public Sub setEigenCutOff(eigenCutOff As Double)
            Me.eigenCutOff = eigenCutOff
        End Sub
        Public Sub setEigenTol(eigenTol As Double)
            Me.eigenTol = eigenTol
        End Sub
        Public Sub setAllowAutoFreqShift(allowAutoFreqShift As Integer)
            Me.allowAutoFreqShift = allowAutoFreqShift
        End Sub
        Public Sub setStaticCorrect(staticCorrect As Boolean())
            Me.staticCorrect = staticCorrect
        End Sub


        'Getters
        Public Function getEigenShiftFreq() As Double
            Return Me.eigenShiftFreq
        End Function
        Public Function getEigenCutOff() As Double
            Return Me.eigenCutOff
        End Function
        Public Function getEigenTol() As Double
            Return Me.eigenTol
        End Function
        Public Function getAllowAutoFreqShift() As Integer
            Return Me.allowAutoFreqShift
        End Function
        Public Function getStaticCorrect() As Boolean()
            Return Me.staticCorrect
        End Function

    End Class


End Namespace