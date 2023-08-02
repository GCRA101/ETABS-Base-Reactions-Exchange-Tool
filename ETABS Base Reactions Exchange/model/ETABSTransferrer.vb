Public Class ETABSTransferrer
    Inherits ETABSConnector

    'ATTRIBUTES ***********************************************************************************'

    'Private Static/Shared variable for the Singleton Pattern 
    Private Shared instance As ETABSTransferrer
    'ETABS Models
    Private sourceEtabsModel As ETABSv1.cSapModel  ' ETABS Model Object Variable              'O(1)
    Private targetEtabsModel As ETABSv1.cSapModel  ' Target ETABS Model Object Variable       'O(1)
    'Source and Target FileNames
    Private sourceFileName, targetFileName As String                                          'O(1)


    'CONSTRUCTOR - PRIVATE' 'SINGLETON PATTERN ****************************************************'
    Private Sub New()

    End Sub




    'GETINSTANCE() METHOD - SINGLETON PATTERN'
    Public Shared Function getInstance() As ETABSConnector
        If instance IsNot Nothing Then
            Return instance
        Else
            instance = New ETABSTransferrer()
            Return instance
        End If
    End Function



    ' SETNEWFILEPATH() METHOD
    Private Function setNewFilePath(filePath As String) As String
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



    ' DISPOSEMODELS() METHOD
    Public Sub disposeModels()

        'Save the Model
        targetEtabsModel.File.Save(setNewFilePath(targetFileName))

        'Release Memory
        sourceEtabsModel = Nothing    'O(1)
        targetEtabsModel = Nothing    'O(1)


    End Sub


End Class
