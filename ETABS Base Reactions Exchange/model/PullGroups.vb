Imports ETABS_Base_Reactions_Exchange.model
Imports ETABSv1

Public Class PullGroups
    Inherits PullBehaviour

    'ATTRIBUTES
    Private groupNames As String()

    'CONSTRUCTORS
    'Default
    Public Sub New(etabsModel As cSapModel)
        MyBase.New(etabsModel)
    End Sub
    'Overloaded 1
    Public Sub New(etabsModel As cSapModel, groupNames As String())
        Me.New(etabsModel)
        Me.groupNames = groupNames
    End Sub


    'METHODS

    Public Overrides Function pull() As IEnumerable(Of ETABSData)

        If Me.groupNames.Length = 0 Then
            Dim numNames As Integer
            Me.etabsModel.GroupDef.GetNameList(numNames, Me.groupNames)
        End If

        groupNames.Select(Of Group)(Function(grpName)
                                        Dim colorInt As Integer
                                        Dim sfSelection, sfSectionCutDefinition, sfSteelDesign, sfConcreteDesign, sfAluminumDesign As Boolean
                                        Dim sfStaticNLActiveStage, sfAutoSeismicOutput, sfAutoWindOutput, sfMassAndWeight As Boolean
                                        Dim sfSteelJoistDesign, sfWallDesign, sfBasePlateDesign, sfConnectionDesign As Boolean
                                        Me.etabsModel.GroupDef.GetGroup_1(grpName, colorInt, sfSelection, sfSectionCutDefinition, sfSteelDesign,
                                                                          sfConcreteDesign, sfAluminumDesign, sfStaticNLActiveStage, sfAutoSeismicOutput,
                                                                          sfAutoWindOutput, sfMassAndWeight, sfSteelJoistDesign, sfWallDesign, sfBasePlateDesign,
                                                                          sfConnectionDesign)
                                        Return (New Group(grpName, New Color(colorInt)))
                                    End Function)
    End Function


End Class
