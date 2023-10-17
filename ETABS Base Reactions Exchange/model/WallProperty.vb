Public Class WallProperty
    Inherits AreaObjProperty

    'ATTRIBUTES
    Private wallPropType As ETABSv1.eWallPropType
    Private shellType As ETABSv1.eShellType
    Private matProp As String
    Private thickness As Double


    'CONSTRUCTORS

    'Default
    Public Sub New()
        MyBase.New()
    End Sub
    'Overloaded1
    Public Sub New(name As String)
        MyBase.New(name)
    End Sub
    'Overloaded2
    Public Sub New(name As String, wallPropType As ETABSv1.eWallPropType, shellType _
                   As ETABSv1.eShellType, matProp As String, thickness As Double)
        MyBase.New(name)
        With Me
            .wallPropType = wallPropType
            .shellType = shellType
            .matProp = matProp
            .thickness = thickness
        End With
    End Sub


    'METHODS

    'Setters
    Public Sub setWallPropType(wallPropType As ETABSv1.eWallPropType)
        Me.wallPropType = wallPropType
    End Sub
    Public Sub setShellType(shellType As ETABSv1.eShellType)
        Me.shellType = shellType
    End Sub
    Public Sub setMatProp(matProp As String)
        Me.matProp = matProp
    End Sub
    Public Sub setThickness(thickness As Double)
        Me.thickness = thickness
    End Sub

    'Getters
    Public Function getWallPropType() As ETABSv1.eWallPropType
        Return Me.wallPropType
    End Function
    Public Function getShellType() As ETABSv1.eShellType
        Return Me.shellType
    End Function
    Public Function getMatProp() As String
        Return Me.matProp
    End Function
    Public Function getThickness() As Double
        Return Me.thickness
    End Function

End Class
