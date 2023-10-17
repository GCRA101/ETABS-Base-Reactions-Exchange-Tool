Imports System.Runtime.Remoting.Messaging

Public Class AreaObjProperty

    'ATTRIBUTES
    Protected name As String
    Protected color As Integer
    Protected notes As String
    Protected guid As String

    'CONSTRUCTORS
    'Default
    Public Sub New()
    End Sub
    'Overloaded
    Public Sub New(name As String)
        Me.name = name
    End Sub

    'METHODS

    'Setters
    Protected Sub setName(name As String)
        Me.name = name
    End Sub
    Protected Sub setColor(color As Integer)
        Me.color = color
    End Sub
    Protected Sub setNotes(notes As String)
        Me.notes = notes
    End Sub
    Protected Sub setGuid(guid As String)
        Me.guid = guid
    End Sub

    'Getters
    Protected Function getName() As String
        Return Me.name
    End Function
    Protected Function getColor() As Integer
        Return Me.color
    End Function
    Protected Function getNotes() As String
        Return Me.notes
    End Function
    Protected Function getGuid() As String
        Return Me.guid
    End Function

End Class
