Namespace model


    Public Class PullLoadCases
        Inherits PullBehaviour

        'ATTRIBUTES
        'All attributes inherited from the abstract superclass PullBehaviour
        Dim loadCasesNames As String()


        'CONSTRUCTOR
        'Overloaded 1
        Public Sub New(etabsModel As ETABSv1.cSapModel)
            MyBase.New(etabsModel)
        End Sub
        'Overloaded 2
        Public Sub New(etabsModel As ETABSv1.cSapModel, loadCasesNames As String())
            MyBase.New(etabsModel)
            With Me
                .loadCasesNames = loadCasesNames
            End With
        End Sub

        'METHODS

        'Pull Method from PullData Interface
        Public Overrides Function pull() As IEnumerable(Of ETABSData)


            Dim loadCases As List(Of LoadCase)

            loadCases = Me.loadCasesNames.ToDictionary(Function(lcName) lcName, Function(lcName)
                                                                                    Dim loadCaseType As ETABSv1.eLoadCaseType
                                                                                    Dim subType As Integer
                                                                                    Me.etabsModel.LoadCases.GetTypeOAPI(lcName, loadCaseType, subType)
                                                                                    Return loadCaseType
                                                                                End Function).
                                           ToList().
                                           Select(Function(kvp)

                                                      Select Case kvp.Value

                                                          Case ETABSv1.eLoadCaseType.LinearStatic

                                                              Dim initialCaseName As String
                                                              Dim numLoads As Integer
                                                              Dim loadTypes(), loadNames() As String
                                                              Dim sfs As Double()

                                                              With Me.etabsModel.LoadCases.StaticLinear
                                                                  .GetInitialCase(kvp.Key, initialCaseName)
                                                                  .GetLoads(initialCaseName, numLoads, loadTypes, loadNames, sfs)
                                                              End With

                                                              Return New LoadCaseStaticLinear(kvp.Key, initialCaseName, numLoads, loadTypes, loadNames, sfs)

                                                          Case ETABSv1.eLoadCaseType.NonlinearStatic

                                                              Dim initialCaseName As String
                                                              Dim massSource As String
                                                              Dim numLoads As Integer
                                                              Dim loadTypes(), loadNames() As String
                                                              Dim sfs As Double()
                                                              Dim modalCaseName As String
                                                              Dim nlGeomType As Integer

                                                              With Me.etabsModel.LoadCases.StaticNonlinear
                                                                  .GetMassSource(kvp.Key, massSource)
                                                                  .GetInitialCase(kvp.Key, initialCaseName)
                                                                  .GetLoads(kvp.Key, numLoads, loadTypes, loadNames, sfs)
                                                                  .GetModalCase(kvp.Key, modalCaseName)
                                                                  .GetGeometricNonlinearity(kvp.Key, nlGeomType)
                                                              End With

                                                              Return New LoadCaseStaticNonLinear(kvp.Key, initialCaseName, numLoads, loadTypes,
                                                                                                    loadNames, sfs, massSource, modalCaseName, nlGeomType)


                                                          Case ETABSv1.eLoadCaseType.ResponseSpectrum

                                                              Dim modalCaseName As String
                                                              Dim numLoads As Integer, loadNames(), functions(), csys() As String
                                                              Dim scaleFactors(), angles(), eccen As Double


                                                              With Me.etabsModel.LoadCases.ResponseSpectrum
                                                                  .GetLoads(kvp.Key, numLoads, loadNames, functions, scaleFactors, csys, angles)
                                                                  .GetModalCase(kvp.Key, modalCaseName)
                                                                  .GetEccentricity(kvp.Key, eccen)
                                                              End With

                                                              Return New LoadCaseResponseSpectrum(kvp.Key, modalCaseName, numLoads, loadNames,
                                                                                                     functions, csys, scaleFactors, angles, eccen)

                                                          Case ETABSv1.eLoadCaseType.Modal

                                                              Dim initialCaseName As String
                                                              Dim numLoads As Integer, loadTypes(), loadNames() As String
                                                              Dim targetParams() As Double, staticCorrect() As Boolean
                                                              Dim ritzMaxCyc() As Integer
                                                              Dim numModesMax, numModesMin As Integer
                                                              Dim eigenShiftFreq, eigenCutOff, eigenTol As Double
                                                              Dim allowAutoFreqShift As Integer
                                                              Dim retEigen, retRitz As Integer

                                                              With Me.etabsModel.LoadCases.ModalEigen
                                                                  .GetInitialCase(kvp.Key, initialCaseName)
                                                                  .GetNumberModes(kvp.Key, numModesMax, numModesMin)
                                                                  .GetLoads(kvp.Key, numLoads, loadTypes, loadNames, targetParams, staticCorrect)
                                                                  retEigen = .GetParameters(kvp.Key, eigenShiftFreq, eigenCutOff, eigenTol, allowAutoFreqShift)
                                                              End With

                                                              With Me.etabsModel.LoadCases.ModalRitz
                                                                  .GetInitialCase(kvp.Key, initialCaseName)
                                                                  .GetNumberModes(kvp.Key, numModesMax, numModesMin)
                                                                  retRitz = .GetLoads(kvp.Key, numLoads, loadTypes, loadNames, ritzMaxCyc, targetParams)
                                                              End With

                                                              If retEigen = 1 Then
                                                                  Return New LoadCaseModalEigen(kvp.Key, initialCaseName, numLoads, loadTypes, loadNames, numModesMax,
                                                                                                   numModesMin, targetParams, eigenShiftFreq, eigenCutOff, eigenTol,
                                                                                                   allowAutoFreqShift, staticCorrect)
                                                              ElseIf retRitz = 1 Then
                                                                  Return New LoadCaseModalRitz(kvp.Key, initialCaseName, numLoads, loadTypes, loadNames, numModesMax,
                                                                                                   numModesMin, targetParams, ritzMaxCyc)
                                                              Else
                                                                  Return Nothing
                                                              End If

                                                          Case Else
                                                              Return Nothing

                                                      End Select

                                                  End Function)

            Return loadCases

        End Function


    End Class


End Namespace
