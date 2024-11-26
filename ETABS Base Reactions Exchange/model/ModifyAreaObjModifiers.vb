Public Class ModifyAreaObjModifiers
    Inherits ModifyObjModifiers

    'ATTRIBUTES
    Private areaObjects As List(Of ETABSv1.cAreaObj)

    'CONSTRUCTOR
    Public Sub New(etabsModel As ETABSv1.cSapModel)
        MyBase.New(etabsModel)
    End Sub

    'METHODS

    'Setters
    Public Sub setAreaObjects(areaObjects As List(Of ETABSv1.cAreaObj))
        Me.areaObjects = areaObjects
    End Sub

    'Getters
    Public Function getAreaObjects() As List(Of ETABSv1.cAreaObj)
        Return Me.areaObjects
    End Function

    Public Overrides Sub modify()
        'Flick through all the area objects and assign to each of them the set of stiffness modifiers
        For Each areaObj As ETABSv1.cAreaObj In Me.areaObjects
            Me.etabsModel.AreaObj.SetModifiers(Me.objModifiers.getName(), Me.objModifiers.getValues())
        Next

    End Sub


End Class
