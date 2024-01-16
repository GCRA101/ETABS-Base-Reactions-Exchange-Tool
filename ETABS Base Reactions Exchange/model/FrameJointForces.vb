Public Class FrameJointForces
    Inherits NodalForces

    'ATTRIBUTES **********************************************************
    Private Property itemTypeElm As ETABSv1.eItemTypeElm
    Private Property pointElm As String()



    'CONSTRUCTOR ************************************************************
    'Default Constructor
    Public Sub New()
        MyBase.New()
    End Sub
    'Overloaded
    Public Sub New(itemTypeElm As ETABSv1.eItemTypeElm, numRes As Integer, obj As String(), elm As String(), pointElm As String(),
                   loadCase() As String, stepType As String(), stepNum As Double(), f1 As Double(), f2 As Double(),
                   f3 As Double(), m1 As Double(), m2 As Double(), m3 As Double())

        MyBase.New(numRes, obj, elm, loadCase, stepType, stepNum, f1, f2, f3, m1, m2, m3)

        With Me
            .itemTypeElm = itemTypeElm
            .pointElm = pointElm
        End With
    End Sub



    'METHODS ****************************************************************

    'GETTERS and SETTERS *********************

    'Setters
    Public Sub setItemTypeElm(itemTypeElm As ETABSv1.eItemTypeElm)
        Me.itemTypeElm = itemTypeElm
    End Sub
    Public Sub setPointElm(pointElm As String())
        Me.pointElm = pointElm
    End Sub


    'Getters
    Public Function getItemTypeElm() As ETABSv1.eItemTypeElm
        Return Me.itemTypeElm
    End Function
    Public Function getPointElm() As String()
        Return Me.pointElm
    End Function


End Class
