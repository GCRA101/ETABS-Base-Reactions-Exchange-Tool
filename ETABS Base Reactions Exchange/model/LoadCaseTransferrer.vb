Imports ETABS_Base_Reactions_Exchange.model
Imports ETABSv1

Public Class LoadCaseTransferrer
    Inherits ETABSTransferrer

    'ATTRIBUTES
    Private loadCaseNames As String()

    'CONSTRUCTOR
    'Overloaded
    Public Sub New(sourceEtabsModel As cSapModel, targetEtabsModel As cSapModel, loadCaseNames As String())
        MyBase.New(sourceEtabsModel, targetEtabsModel)
        Me.loadCaseNames = loadCaseNames
        Dim pullLoadCases = New PullLoadCases(sourceEtabsModel, loadCaseNames)
        Dim pushLoadCases = New PushLoadCases(targetEtabsModel)
        Me.transferMode = New LoadCasesTransfer(sourceEtabsModel, targetEtabsModel, pullLoadCases, pushLoadCases)
    End Sub


    'METHODS

    Public Overrides Sub transfer(Optional overwrite As Boolean = False)
        Me.transferMode.transfer(overwrite)
    End Sub


End Class
