Public MustInherit Class ETABSTransferrer

    'ATTRIBUTES ***********************************************************************************'

    'Behaviour Object
    Protected transferMode As DataTransfer
    'ETABS Models
    Protected sourceEtabsModel As ETABSv1.cSapModel  ' ETABS Model Object Variable              'O(1)
    Protected targetEtabsModel As ETABSv1.cSapModel  ' Target ETABS Model Object Variable       'O(1)
    'Source and Target FileNames
    Protected sourceFileName, targetFileName As String                                          'O(1)


    'CONSTRUCTORS **********************************************************************************'
    'Default
    Public Sub New()
    End Sub
    'Overloaded
    Public Sub New(sourceEtabsModel As ETABSv1.cSapModel, targetEtabsModel As ETABSv1.cSapModel)
        Me.sourceEtabsModel = sourceEtabsModel
        Me.targetEtabsModel = targetEtabsModel
    End Sub


    'METHODS ***************************************************************************************'

    'Setters
    Public Sub setSourceEtabsModel(sourceEtabsModel As ETABSv1.cSapModel)
        Me.sourceEtabsModel = sourceEtabsModel
    End Sub
    Public Sub setTargetEtabsModel(targetEtabsModel As ETABSv1.cSapModel)
        Me.targetEtabsModel = targetEtabsModel
    End Sub

    'Getters
    Public Function getSourceEtabsModel() As ETABSv1.cSapModel
        Return Me.sourceEtabsModel
    End Function
    Public Function getTargetEtabsModel() As ETABSv1.cSapModel
        Return Me.targetEtabsModel
    End Function


    ' SETNEWFILEPATH() METHOD
    Protected Function setNewFilePath(filePath As String) As String
        Dim newFilePath As String
        Dim dateObj As Date = Date.Today

        Dim sep() As Char = {"/", "\", "//"}

        With dateObj
            newFilePath = filePath.Remove(filePath.IndexOf(filePath.Split(sep).Last())) + "BRE" +
                            .Year.ToString + .Month.ToString("D2") +
                            .Day.ToString("D2") + "_" + filePath.Split(sep).Last()
        End With

        Return newFilePath

    End Function


    ' TRANSFER METHOD
    Protected Overridable Sub transfer()
    End Sub


End Class
