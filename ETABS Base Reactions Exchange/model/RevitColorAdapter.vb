Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Imports Autodesk.Revit.DB


Public Class RevitColorAdapter
	Implements ColorInterface
    
        'ATTRIBUTES 
        Private revitColor As Autodesk.Revit.DB.Color

        'CONSTRUCTOR 
		
        'Overloaded
		Public Sub New(revitColor As Autodesk.Revit.DB.Color)
			Me.revitColor=revitColor
		End Sub


        ' METHODS 

		'Implemented from Interface
		Public Function getRed() As byte
			Return Me.revitColor.Red
		End Function
		Public Function getGreen() As byte
			Return Me.revitColor.Green
		End Function
		Public Function getBlue() As byte
			Return Me.revitColor.Blue
		End Function
		Public Function getRGB() As byte()
			Dim rgb=New byte(){this.revitColor.Red, this.revitColor.Green, this.revitColor.Blue}
            Return rgb
		End Function
		Public Function getEtabsIntValue() As Integer
			Return CInt(this.getRed()) + CInt(this.getGreen()) * 256 + CInt(this.getBlue()) * 256 * 256
		End Function

    
End Class
