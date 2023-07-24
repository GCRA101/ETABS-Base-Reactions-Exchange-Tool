Public Class ETABSTransferrer
    Inherits ETABSConnector

    'ATTRIBUTES ***********************************************************************************'

    'ETABS Models
    Private sourceEtabsModel As ETABSv1.cSapModel  ' ETABS Model Object Variable              'O(1)
    Private targetEtabsModel As ETABSv1.cSapModel  ' Target ETABS Model Object Variable       'O(1)
    'Source and Target FileNames
    Private sourceFileName, targetFileName As String                                          'O(1)




End Class
