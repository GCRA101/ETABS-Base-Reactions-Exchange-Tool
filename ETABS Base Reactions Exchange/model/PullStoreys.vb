Imports ETABS_Base_Reactions_Exchange.model
Imports ETABSv1

Public Class PullStoreys
    Inherits PullBehaviour

    'ATTRIBUTES
    Dim storeyNames As String()

    'CONSTRUCTORS
    'Default
    Public Sub New(etabsModel As cSapModel)
        MyBase.New(etabsModel)
    End Sub
    'Overloaded
    Public Sub New(etabsModel As cSapModel, storeyNames As String())
        Me.New(etabsModel)
        Me.storeyNames = storeyNames
    End Sub

    'METHODS
    Public Overrides Function pull() As IEnumerable(Of ETABSData)

        Dim storeys As List(Of Storey)

        If Me.storeyNames Is Nothing Then
            Dim numNames As Integer
            ret = Me.etabsModel.Story.GetNameList(numNames, storeyNames)
        End If

        storeys = storeyNames.ToList.
                    Select(Of Storey)(Function(storeyName)
                                          Dim elevation, height As Double
                                          Dim isMaster As Boolean
                                          Dim guid As String
                                          With Me.etabsModel.Story
                                              .GetHeight(storeyName, height)
                                              .GetElevation(storeyName, elevation)
                                              .GetMasterStory(storeyName, isMaster)
                                              .GetGUID(storeyName, guid)
                                          End With
                                          Return New Storey(storeyName, elevation, height,
                                                            isMaster, guid)
                                      End Function)

        Return storeys

    End Function

End Class
