
Namespace model
    Public Class PointDataSet

        'ATTRIBUTES
        Private Property point As PointObj
        Private Property reactions As PointReactions


        'CONSTRUCTOR
        'Default Constructor
        Public Sub New()
        End Sub
        'Overloaded Constructor 
        Public Sub New(point As PointObj, reactions As PointReactions)
            Me.point = point
            Me.reactions = reactions
        End Sub


        'GETTERS AND SETTERS

        'Setters
        Public Sub setPoint(point As PointObj)
            Me.point = point
        End Sub
        Public Sub setReactions(reactions As PointReactions)
            Me.reactions = reactions
        End Sub

        'Getters
        Public Function getPoint() As PointObj
            Return Me.point
        End Function

        Public Function getReactions() As PointReactions
            Return Me.reactions
        End Function

    End Class

End Namespace
