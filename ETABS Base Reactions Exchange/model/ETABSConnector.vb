
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Text.RegularExpressions
Imports CSiAPIv1
Imports ETABSv1

Imports ETABS_Base_Reactions_Exchange.model.Model
Imports ETABS_Base_Reactions_Exchange.controller.Controller
Imports System.Threading
Imports System.Net.Http.Headers
Imports System.Net.Mime
Imports System.ComponentModel



Public Class ETABSConnector

    'ATTRIBUTES ***********************************************************************************'

    'Private Static/Shared variable for the Singleton Pattern 
    Private Shared instance As ETABSConnector

    'ETABS OAPI Interoperability Variables
    Private helperObject As ETABSv1.cHelper   ' Helper Class Object Variable                  'O(1)
    Private ETABSApp As ETABSv1.cOAPI         ' ETABS Application Object Variable             'O(1)
    Private sourceEtabsModel As ETABSv1.cSapModel  ' ETABS Model Object Variable              'O(1)
    Private targetEtabsModel As ETABSv1.cSapModel  ' Target ETABS Model Object Variable       'O(1)

    'Source and Target FileNames
    Private sourceFileName, targetFileName As String                                          'O(1)

    'Utility Variables
    Private ret As Integer
    Const etabsVisibility As Boolean = False                                                  'O(1)



    'CONSTRUCTOR - PRIVATE' 'SINGLETON PATTERN ****************************************************'
    Private Sub New()
    End Sub


    'METHODS **************************************************************************************'

    'GETINSTANCE() METHOD - SINGLETON PATTERN'
    Public Shared Function getInstance() As ETABSConnector
        If instance IsNot Nothing Then
            Return instance
        Else
            instance = New ETABSConnector()
            Return instance
        End If
    End Function


    'INITIALIZEETABS() METHOD
    Public Sub initialize()

        'Helper Class Object Variable
        helperObject = New ETABSv1.Helper                                                                            'O(1)
        'ETABS Application Object Variable                                                                           'O(1)
        ETABSApp = Nothing                                                                                           'O(1)
        ETABSApp = helperObject.CreateObjectProgID("CSI.ETABS.API.ETABSObject")                                      'O(1)
        'ETABSApp = helperObject.CreateObject("c:\Program Files\Computers and Structures\ETABS 20\ETABS.exe")        'O(1)
        'ETABSApp = helperObject.GetObject("CSI.ETABS.API.ETABSObject")                                              'O(1)

    End Sub


    ' DISPOSEETABS() METHOD
    Public Sub dispose()

        'Save the Model
        targetEtabsModel.File.Save(setNewFilePath(targetFileName))

        'Close the ETABS Application
        ETABSApp.ApplicationExit(False)

        'Release Memory
        sourceEtabsModel = Nothing    'O(1)
        targetEtabsModel = Nothing    'O(1)
        ETABSApp = Nothing            'O(1)

    End Sub


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


    ' SETETABSVISIBILITY() METHOD
    Private Sub setEtabsVisibility(bool As Boolean)
        If bool = False Then
            ret = ETABSApp.Hide()
        Else
            ret = ETABSApp.Unhide()
        End If
    End Sub




End Class
