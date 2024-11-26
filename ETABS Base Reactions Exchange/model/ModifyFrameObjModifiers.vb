Imports System.Windows.Forms.VisualStyles

Public Class ModifyFrameObjModifiers
    Inherits ModifyObjModifiers

    'ATTRIBUTES
    Private frameObjects As List(Of ETABSv1.cFrameObj)

    'CONSTRUCTORS
    Public Sub New(etabsModel As ETABSv1.cSapModel)
        MyBase.New(etabsModel)
    End Sub

    'METHODS

    'Setters
    Public Sub setFrameObjects(frameObjects As List(Of ETABSv1.cFrameObj))
        Me.frameObjects = frameObjects
    End Sub

    'Getters
    Public Function getFrameObjects()
        Return Me.frameObjects
    End Function


    Public Overrides Sub modify()

        For Each frameObj As ETABSv1.cFrameObj In Me.frameObjects
            ret = Me.etabsModel.FrameObj.SetModifiers(Me.objModifiers.getName(), Me.objModifiers.getValues())
        Next

    End Sub


End Class
