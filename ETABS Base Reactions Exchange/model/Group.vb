Imports ETABSv1
Imports CSiAPIv1
Imports System.Collections.Generic
Imports System.Linq
Imports System

Public Class Group
	Inherits ETABSData
	
	'ATTRIBUTES *****************************************************************************
	Private name As String
	Private colour As ColorInterface
	
	
	'CONSTRUCTORS ***************************************************************************
	
	'Overloaded 1
	Public Sub New(name As String)
		MyBase.New()
		Me.name=name
	End Sub
	'Overloaded 2
	Public Sub New(name As String, colour As ColorInterface)
		Me.New(name)
		Me.colour=colour
	End Sub


	'METHODS ********************************************************************************
	
	'Setters
	Public Sub setName(name As String)
		Me.name=name
	End Sub
	Public Sub setColour(colour As ColorInterface)
		Me.colour=colour
	End Sub
	
	'Getters
	Public Function getName() As String
		Return Me.name
	End Function
	Public Function getColour() As ColorInterface
		Return Me.colour
	End Function
	
	'HASHCODE

	'Method inherited from the Object superclass and that has to be overwritten in order to generate
	'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
	'The hashcode is essential to be able to sort and store instances of this class properly 
	'in whatever concrete implementation of the abstract data structure Hash Table.
	Public Overrides Function GetHashCode() As Integer
		'Determines and returns the Hashcode of the class instance as the integer number given 
		'by the sum of the hashcodes of the point and reactions attributes respectively.
		Dim hash As Integer
		hash = Me.Name.GetHashCode + Me.getColour.getEtabsIntValue
		Return hash
	End Function


	'COMPARETO

	'Method implemented from the IComparable Functional Interface which unique method CompareTo 
	'gets called everytime we want to compare an instance of this class with another object.
	'The method needs to be implemented accordingly with the criteria we want to use to define
	'which object is greater or smaller than the other based on the values assigned to its 
	'attributes.
	Public Overrides Function CompareTo(obj As Object) As Integer
		Throw New NotImplementedException()
		'1. Check input Obj Data Type to match the Current Class
		If Not obj.GetType().Equals(Me.GetType) Then
			Return Nothing
		End If
		'2. Down-Cast the input Object to the Current Class
		Dim grpObj As Group
		grpObj = CType(obj, Group)
		'3. Compare the two instances of the class giving precedence to the Name and the Color attributes
		If (Me.getName.CompareTo(grpObj.getName) <> 0) Then
			Return Me.getName.CompareTo(grpObj.getName)
		ElseIf Me.getColour.CompareTo(grpObj.getColour) <> 0 Then
			Return Me.getColour.CompareTo(grpObj.getColour)
		End If

		Return 0
	End Function


	'EQUALS

	'Method inherited from the Object superclass and that gets called everytime we check whether 
	'two instances of this class are equal or not. 
	'It has to be overwritten based on the values assigned to the attributes of the class instances
	Public Overrides Function Equals(obj As Object) As Boolean

		'1. Check input Obj Data Type to match the Current Class
		If Not obj.GetType().Equals(Me.GetType) Then
			Return False
		End If

		'2. Down-Cast the input object to the Current Class
		Dim grpObj As Group
		grpObj = CType(obj, Group)

		'3. Check if attributes of the two class instances are equal or not
		If Me.getName.Equals(grpObj.getName) And Me.getColour.getEtabsIntValue=grpObj.getColour.getEtabsIntValue Then
			Return True
		End If

		Return False

	End Function	
	
	

End Class