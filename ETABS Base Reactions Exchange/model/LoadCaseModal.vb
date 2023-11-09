Namespace model

    Public MustInherit Class LoadCaseModal
        Inherits LoadCase

        'ATTRIBUTES
        Protected initialCaseName As String
        Protected loadTypes() As String
        Protected numModesMax, numModesMin As Integer
        Protected targetParams() As Double

        'CONSTRUCTORS
        'Default
        Public Sub New()
            MyBase.New()
        End Sub
        'Overloaded
        Public Sub New(initalCaseName As String, numLoads As Integer, loadTypes() As String, loadNames() As String,
                       numModesMax As Integer, numModesMin As Integer, targetParams() As Double)
            MyBase.New(numLoads, loadNames)
            Me.initialCaseName = initialCaseName
            Me.loadTypes = loadTypes
            Me.numModesMax = numModesMax
            Me.numModesMin = numModesMin
            Me.targetParams = targetParams
        End Sub

        'METHODS

        'Setters
        Public Sub setInitialCaseName(initialCaseName As String)
            Me.initialCaseName = initialCaseName
        End Sub
        Public Sub setLoadTypes(loadTypes() As String)
            Me.loadTypes = loadTypes
        End Sub
        Public Sub setNumModesMax(numModesMax As Integer)
            Me.numModesMax = numModesMax
        End Sub
        Public Sub setNumModesMin(numModesMin As Integer)
            Me.numModesMin = numModesMin
        End Sub
        Public Sub setTargetParams(targetParams() As Double)
            Me.targetParams = targetParams
        End Sub


        'Getters
        Public Function setInitialCaseName() As String
            Return Me.initialCaseName
        End Function
        Public Function setLoadTypes() As String()
            Return Me.loadTypes
        End Function
        Public Function setNumModesMax() As Integer
            Return Me.numModesMax
        End Function
        Public Function setNumModesMin() As Integer
            Return Me.numModesMin
        End Function
        Public Function setTargetParams() As Double()
            Return Me.targetParams
        End Function


    End Class



End Namespace
