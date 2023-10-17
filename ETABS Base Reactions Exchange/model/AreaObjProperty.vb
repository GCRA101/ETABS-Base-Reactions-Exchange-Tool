Imports System.Runtime.Remoting.Messaging

Public Class AreaObjProperty

    'ATTRIBUTES
    Public name As String
    Public color As Integer
    Public notes As String
    Public guid As String

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
    Public Sub setName(name As String)
        Me.name = name
    End Sub
    Public Sub setColor(color As Integer)
        Me.color = color
    End Sub
    Public Sub setNotes(notes As String)
        Me.notes = notes
    End Sub
    Public Sub setGuid(guid As String)
        Me.guid = guid
    End Sub

    'Getters
    Public Function getName() As String
        Return Me.name
    End Function
    Public Function getColor() As Integer
        Return Me.color
    End Function
    Public Function getNotes() As String
        Return Me.notes
    End Function
    Public Function getGuid() As String
        Return Me.guid
    End Function

End Class
