Public MustInherit Class ModifyObjModifiers
    Inherits ModifyBehaviour

    'ATTRIBUTES
    Protected objModifiers As ObjModifiers

    'CONSTRUCTORS
    Public Sub New(etabsModel As ETABSv1.cSapModel)
        MyBase.New(etabsModel)
    End Sub

    'METHODS
    Protected Sub setObjModifiers(objModifiers As ObjModifiers)
        Me.objModifiers = objModifiers
    End Sub

    Protected Function getObjModifiers(objModifiers As ObjModifiers)
        Return Me.objModifiers
    End Function



End Class
