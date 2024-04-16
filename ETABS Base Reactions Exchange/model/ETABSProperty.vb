Public MustInherit Class ETABSProperty
    Inherits ETABSData

    ' ATTRIBUTES **************************************************
    Private name As String
    Private color As ColorInterface
    Private description As String


    ' CONSTRUCTORS ************************************************
    ' Default
    Public Sub New()
    End Sub
    ' Overloaded 01
    Public Sub New(name As String)
        Me.name = name
    End Sub
    ' Overloaded 02
    Public Sub New(name As String, color As ColorInterface, description As String)
        Me.New(name)
        Me.color = color
        Me.description = description
    End Sub


    ' METHODS ******************************************************

    ' Setters
    Public Sub setName(name As String)
        Me.name = name
    End Sub
    Public Sub setColor(color As ColorInterface)
        Me.color = color
    End Sub
    Public Sub setDescription(description As String)
        Me.description = description
    End Sub

    ' Getters
    Public Function getName() As String
        Return Me.name
    End Function
    Public Function getColor() As ColorInterface
        Return Me.color
    End Function
    Public Function getDescription() As String
        Return Me.description
    End Function


End Class
