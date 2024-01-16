Imports ETABSv1
Imports CSiAPIv1
Imports System.Collections.Generic
Imports System.Linq
Imports System


Public Class PushGroups
	Inherits PushBehaviour
	
        'ATTRIBUTES
		Private groups As List(Of Group)

    'CONSTRUCTORS
    'Default
    Public Sub New(etabsModel As ETABSv1.cSapModel)
        MyBase.New(etabsModel)
    End Sub
    'Overloaded
    Public Sub New(etabsModel As ETABSv1.cSapModel, groups As List(Of Group))
        MyBase.New(etabsModel)
        Me.groups = groups
    End Sub


    'METHODS
    'SetGroups
    Public Sub setGroups(groups As List(Of Group))
        Me.groups = groups
    End Sub

    'Push
    Public Overrides Sub push(Optional overwrite As Boolean = False)
        'Extract List of Exsiting Groups from the ETABS Model
        Dim grpNumNames As Integer, grpNames As String()
        ret = Me.etabsModel.GroupDef.GetNameList(grpNumNames, grpNames)
        'Create Groups
        Me.groups.Where(Function(grp)
                            If overwrite = True Then
                                Return Not grpNames.Contains(grp.getName())
                            End If
                            Return True
                        End Function).
                  ToList.
                  ForEach(Sub(grp)
                              If overwrite = True Then
                                  Me.etabsModel.GroupDef.Delete(grp.getName)
                              End If
                              Me.etabsModel.GroupDef.SetGroup_1(grp.getName, grp.getColour.getEtabsIntValue())
                          End Sub)
    End Sub

End Class