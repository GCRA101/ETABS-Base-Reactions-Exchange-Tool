Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks


Public Interface ColorInterface
    Inherits IComparable
    Function getRed() As Byte
    Function getGreen() As Byte
    Function getBlue() As Byte
    Function getRGB() As Byte()
    Function getEtabsIntValue() As Integer

End Interface

