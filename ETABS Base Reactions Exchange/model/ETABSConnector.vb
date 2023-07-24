
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



Public MustInherit Class ETABSConnector
    Implements ETABSConnection

    'ATTRIBUTES ***********************************************************************************'

    'ETABS OAPI Interoperability Variables
    Private helperObject As ETABSv1.cHelper   ' Helper Class Object Variable                  'O(1)
    Private ETABSApp As ETABSv1.cOAPI         ' ETABS Application Object Variable             'O(1)

    'Utility Variables
    Private ret As Integer                                                                    'O(1)
    Const etabsVisibility As Boolean = False                                                  'O(1)


    'CONSTRUCTOR **********************************************************************************'
    Public Sub New()
    End Sub


    'METHODS **************************************************************************************'

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
        'Close the ETABS Application
        ETABSApp.ApplicationExit(False) 'O(1)
        'Release Memory
        ETABSApp = Nothing              'O(1)
    End Sub


    ' SETETABSVISIBILITY() METHOD
    Private Sub setEtabsVisibility(bool As Boolean)
        If bool = False Then
            ret = ETABSApp.Hide()
        Else
            ret = ETABSApp.Unhide()
        End If
    End Sub


End Class
