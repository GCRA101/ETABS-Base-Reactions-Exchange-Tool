Namespace model
    Public Class PushLoadCases
        Inherits PushBehaviour

        'ATTRIBUTES
        Dim loadCases As List(Of LoadCase)

        'CONSTRUCTOR
        'Overloaded 1
        Public Sub New(etabsModel As ETABSv1.cSapModel)
            MyBase.New(etabsModel)
        End Sub
        'Overloaded 2
        Public Sub New(etabsModel As ETABSv1.cSapModel, loadCases As List(Of LoadCase))
            MyBase.New(etabsModel)
            Me.loadCases = loadCases
        End Sub

        'METHODS

        'Setters
        Public Sub setLoadCases(loadCases As List(Of LoadCase))
            Me.loadCases = loadCases
        End Sub

        'Push Method from PushData Interface
        Public Overrides Sub push(Optional overwrite As Boolean = False)
            'Unlock ETABS Model
            ret = Me.etabsModel.SetModelIsLocked(False)

            'Extract Existing Load Case Names from Etabs Model
            Dim numNames As Integer, lcNames As String()
            ret = Me.etabsModel.LoadCases.GetNameList(numNames, lcNames)


            loadCases.Where(Function(lc)
                                If overwrite = False Then
                                    Return Not lcNames.Contains(lc.getLoadCaseName())
                                End If
                            End Function).
                            ToList.
                            ForEach(Function(lc)

                                        If overwrite = True Then
                                            ret = Me.etabsModel.LoadCases.Delete(lcNames.Where(Function(lcn) lcn.Contains(lc.getLoadCaseName())).ToString)
                                        End If

                                        Select Case lc.GetType()

                                            Case GetType(LoadCaseStaticLinear)
                                                With Me.etabsModel.LoadCases.StaticLinear
                                                    Dim lcsl As LoadCaseStaticLinear = DirectCast(lc, LoadCaseStaticLinear)
                                                    .SetCase(lcsl.getLoadCaseName)
                                                    .SetInitialCase(lcsl.getLoadCaseName, lcsl.getInitialCaseName)
                                                    .SetLoads(lcsl.getLoadCaseName, lcsl.getNumLoads, lcsl.getLoadTypes,
                                                               lcsl.getLoadNames, lcsl.getSfs)
                                                End With

                                            Case GetType(LoadCaseStaticNonLinear)
                                                With Me.etabsModel.LoadCases.StaticNonlinear
                                                    Dim lcsnl As LoadCaseStaticNonLinear = DirectCast(lc, LoadCaseStaticNonLinear)
                                                    .SetCase(lcsnl.getLoadCaseName)
                                                    .SetInitialCase(lcsnl.getLoadCaseName, lcsnl.getInitialCaseName)
                                                    .SetLoads(lcsnl.getLoadCaseName, lcsnl.getNumLoads, lcsnl.getLoadTypes,
                                                           lcsnl.getLoadNames, lcsnl.getSfs)
                                                    .SetMassSource(lcsnl.getLoadCaseName, lcsnl.getMassSource)
                                                    .SetModalCase(lcsnl.getLoadCaseName, lcsnl.getModalCaseName)
                                                    .SetGeometricNonlinearity(lcsnl.getLoadCaseName, lcsnl.getNlGeomType)
                                                End With

                                            Case GetType(LoadCaseResponseSpectrum)

                                                With Me.etabsModel.LoadCases.ResponseSpectrum
                                                    Dim lcrs As LoadCaseResponseSpectrum = DirectCast(lc, LoadCaseResponseSpectrum)
                                                    .SetCase(lcrs.getLoadCaseName)
                                                    .SetLoads(lcrs.getLoadCaseName, lcrs.getNumLoads, lcrs.getLoadNames, lcrs.getFunctions,
                                                               lcrs.getScaleFactors, lcrs.getCSys, lcrs.getAng)
                                                    .SetModalCase(lcrs.getLoadCaseName, lcrs.getModalCaseName)
                                                    .SetEccentricity(lcrs.getLoadCaseName, lcrs.getEccen)
                                                End With

                                            Case GetType(LoadCaseModalEigen)

                                                With Me.etabsModel.LoadCases.ModalEigen
                                                    Dim lcme As LoadCaseModalEigen = DirectCast(lc, LoadCaseModalEigen)
                                                    .SetCase(lcme.getLoadCaseName)
                                                    .SetInitialCase(lcme.getLoadCaseName, lcme.getInitialCaseName)
                                                    .SetLoads(lcme.getLoadCaseName, lcme.getNumLoads, lcme.getLoadTypes, lcme.getLoadNames,
                                                               lcme.getTargetParams, lcme.getStaticCorrect)
                                                    .SetNumberModes(lcme.getLoadCaseName, lcme.getNumModesMax, lcme.getNumModesMin)
                                                    .SetParameters(lcme.getLoadCaseName, lcme.getEigenShiftFreq, lcme.getEigenCutOff,
                                                                    lcme.getEigenTol, lcme.getAllowAutoFreqShift)
                                                End With

                                            Case GetType(LoadCaseModalRitz)

                                                With Me.etabsModel.LoadCases.ModalRitz
                                                    Dim lcmr As LoadCaseModalRitz = DirectCast(lc, LoadCaseModalRitz)
                                                    .SetCase(lcmr.getLoadCaseName)
                                                    .SetInitialCase(lcmr.getLoadCaseName, lcmr.getInitialCaseName)
                                                    .SetLoads(lcmr.getLoadCaseName, lcmr.getNumLoads, lcmr.getLoadTypes, lcmr.getLoadNames,
                                                               lcmr.getRitzMaxCyc, lcmr.getTargetParams)
                                                    .SetNumberModes(lcmr.getLoadCaseName, lcmr.getNumModesMax, lcmr.getNumModesMin)
                                                End With
                                            Case Else
                                                Exit Function
                                        End Select
                                    End Function)

        End Sub



    End Class


End Namespace