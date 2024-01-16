Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks


Public Class Color
    Implements ColorInterface

    'ATTRIBUTES
    Private red,green, blue As Byte
    Private RGB As Byte()
    Private etabsIntValue As Integer

    'CONSTRUCTOR
    'Overloaded
    Public Sub New(red As Byte, green As Byte, blue As Byte)
        Me.red = red
        Me.green = green
        Me.blue = blue
        Dim rGB = New Byte() {red, green, blue}
        Me.RGB = rGB
        Me.etabsIntValue = Me.getEtabsIntValue()
    End Sub

    'METHODS

    'Methods from implemented Interfaces
    Public Function getRed() As Byte Implements ColorInterface.getRed
        Return Me.red
    End Function

    Public Function getGreen() As Byte Implements ColorInterface.getGreen
        Return Me.green
    End Function

    Public Function getBlue() As Byte Implements ColorInterface.getBlue
        Return Me.blue
    End Function

    Public Function getRGB() As Byte() Implements ColorInterface.getRGB
        Return Me.RGB
    End Function

    Public Function getEtabsIntValue() As Integer Implements ColorInterface.getEtabsIntValue
        Return CInt(Me.getRed()) + CInt(Me.getGreen()) * 256 + CInt(Me.getBlue()) * 256 * 256
    End Function


    'HASHCODE

    'Method inherited from the Object superclass and that has to be overwritten in order to generate
    'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    'The hashcode is essential to be able to sort and store instances of this class properly 
    'in whatever concrete implementation of the abstract data structure Hash Table.
    Public Overrides Function GetHashCode() As Integer
        'Determines and returns the Hashcode of the class instance as the integer number given 
        'by the sum of the red, green, blue and etabsIntValue
        Dim hash As Integer
        hash = Me.red + Me.green + Me.blue + Me.etabsIntValue
        Return hash
    End Function


    'COMPARETO

    'Method implemented from the IComparable Functional Interface which unique method CompareTo 
    'gets called everytime we want to compare an instance of this class with another object.
    'The method needs to be implemented accordingly with the criteria we want to use to define
    'which object is greater or smaller than the other based on the values assigned to its 
    'attributes.
    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        Throw New NotImplementedException()
        '1. Check input Obj Data Type to match the current class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return Nothing
        End If
        '2. Down-Cast the input Object to the current class
        Dim colorObj As Color
        colorObj = CType(obj, Color)
        '3. Compare the two instances of the class giving precedence to the etabsIntValue
        If (Me.etabsIntValue <> colorObj.getEtabsIntValue()) Then
            Return Me.etabsIntValue - colorObj.getEtabsIntValue()
        End If
        Return 0
    End Function


    'EQUALS

    'Method inherited from the Object superclass and that gets called everytime we check whether 
    'two instances of this class are equal or not. 
    'It has to be overwritten based on the values assigned to the attributes of the class instances
    Public Overrides Function Equals(obj As Object) As Boolean

        '1. Check input Obj Data Type to match the current class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return False
        End If

        '2. Down-Cast the input object to the current class
        Dim colorObj As Color
        colorObj = CType(obj, Color)

        '3. Check if the etabsIntValues of the two class instances are equal or not
        If Me.etabsIntValue = colorObj.getEtabsIntValue() Then
            Return True
        End If

        Return False

    End Function


End Class       
        
            

    

