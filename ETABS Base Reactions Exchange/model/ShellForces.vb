Imports ETABS_Base_Reactions_Exchange.model

Public Class ShellForces
    Inherits ETABSData

    'ATTRIBUTES
    Private numberResults As Integer
    Private obj, elm, pointElm, loadCase, stepType As String()
    Private stepNum, f11, f22, f12, fMax, fMin, fAngle, fvm, m11, m22, m12, mMax, mMin, mAngle, v13, v23, vMax, vAngle As Double()

    'CONSTRUCTORS
    'Default
    Public Sub New()
    End Sub
    'Overloaded
    Public Sub New(numberResults As Integer, obj As String(), elm As String(), pointElm As String(), loadCase As String(), stepType As String(),
                   stepNum As Double(), f11 As Double(), f22 As Double(), f12 As Double(), fMax As Double(), fMin As Double(), fAngle As Double(),
                   fvm As Double(), m11 As Double(), m22 As Double(), m12 As Double(), mMax As Double(), mMin As Double(), mAngle As Double(),
                   v13 As Double(), v23 As Double(), vMax As Double(), vAngle As Double())
        With Me
            .numberResults = numberResults
            .obj = obj
            .elm = elm
            .pointElm = pointElm
            .loadCase = loadCase
            .stepType = stepType
            .stepNum = stepNum
            .f11 = f11
            .f22 = f22
            .f12 = f12
            .fMax = fMax
            .fMin = fMin
            .fAngle = fAngle
            .fvm = fvm
            .m11 = m11
            .m22 = m22
            .m12 = m12
            .mMax = mMax
            .mMin = mMin
            .mAngle = mAngle
            .v13 = v13
            .v23 = v23
            .vMax = vMax
            .vAngle = vAngle
        End With
    End Sub

    'METHODS

    'Setters
    Public Sub setNumberResults(numberResults As Integer)
        Me.numberResults = numberResults
    End Sub
    Public Sub setObj(obj As String())
        Me.obj = obj
    End Sub
    Public Sub setElm(elm As String())
        Me.elm = elm
    End Sub
    Public Sub setPointElm(pointElm As String())
        Me.pointElm = pointElm
    End Sub
    Public Sub setLoadCase(loadCase As String())
        Me.loadCase = loadCase
    End Sub
    Public Sub setStepType(stepType As String())
        Me.stepType = stepType
    End Sub
    Public Sub setStepNum(stepNum As Double())
        Me.stepNum = stepNum
    End Sub
    Public Sub setF11(f11 As Double())
        Me.f11 = f11
    End Sub
    Public Sub setF22(f22 As Double())
        Me.f22 = f22
    End Sub
    Public Sub setF12(f12 As Double())
        Me.f12 = f12
    End Sub
    Public Sub setFMax(fMax As Double())
        Me.fMax = fMax
    End Sub
    Public Sub setFMin(fMin As Double())
        Me.fMin = fMin
    End Sub
    Public Sub setFAngle(fAngle As Double())
        Me.fAngle = fAngle
    End Sub
    Public Sub setFvm(fvm As Double())
        Me.fvm = fvm
    End Sub
    Public Sub setM11(m11 As Double())
        Me.m11 = m11
    End Sub
    Public Sub setM22(m22 As Double())
        Me.m22 = m22
    End Sub
    Public Sub setM12(m12 As Double())
        Me.m12 = m12
    End Sub
    Public Sub setMMax(mMax As Double())
        Me.mMax = mMax
    End Sub
    Public Sub setMMin(mMin As Double())
        Me.mMin = mMin
    End Sub
    Public Sub setMAngle(mAngle As Double())
        Me.mAngle = mAngle
    End Sub
    Public Sub setV13(v13 As Double())
        Me.v13 = v13
    End Sub
    Public Sub setV23(v23 As Double())
        Me.v23 = v23
    End Sub
    Public Sub setVMax(vMax As Double())
        Me.vMax = vMax
    End Sub
    Public Sub setVAngle(vAngle As Double())
        Me.vAngle = vAngle
    End Sub


    'Getters
    Public Function getnumberResults() As Integer
        Return Me.numberResults
    End Function
    Public Function getobj() As String()
        Return Me.obj
    End Function
    Public Function getelm() As String()
        Return Me.elm
    End Function
    Public Function getpointElm() As String()
        Return Me.pointElm
    End Function
    Public Function getloadCase() As String()
        Return Me.loadCase
    End Function
    Public Function getstepType() As String()
        Return Me.stepType
    End Function
    Public Function getstepNum() As Double()
        Return Me.stepNum
    End Function
    Public Function getf11() As Double()
        Return Me.f11
    End Function
    Public Function getf22() As Double()
        Return Me.f22
    End Function
    Public Function getf12() As Double()
        Return Me.f12
    End Function
    Public Function getfMax() As Double()
        Return Me.fMax
    End Function
    Public Function getfMin() As Double()
        Return Me.fMin
    End Function
    Public Function getfAngle() As Double()
        Return Me.fAngle
    End Function
    Public Function getfvm() As Double()
        Return Me.fvm
    End Function
    Public Function getm11() As Double()
        Return Me.m11
    End Function
    Public Function getm22() As Double()
        Return Me.m22
    End Function
    Public Function getm12() As Double()
        Return Me.m12
    End Function
    Public Function getmMax() As Double()
        Return Me.mMax
    End Function
    Public Function getmMin() As Double()
        Return Me.mMin
    End Function
    Public Function getmAngle() As Double()
        Return Me.mAngle
    End Function
    Public Function getv13() As Double()
        Return Me.v13
    End Function
    Public Function getv23() As Double()
        Return Me.v23
    End Function
    Public Function getvMax() As Double()
        Return Me.vMax
    End Function
    Public Function getvAngle() As Double()
        Return Me.vAngle
    End Function



    'HASHCODE

    'Method inherited from the Object superclass and that has to be overwritten in order to generate
    'ad hoc hashcodes based on the values assigned to the specific attributes of this class.
    'The hashcode is essential to be able to sort and store instances of this class properly 
    'in whatever concrete implementation of the abstract data structure Hash Table.
    Public Overrides Function GetHashCode() As Integer
        'Determines and returns the Hashcode of the class instance as the number given by the sum 
        'of the hashcodes of a number of its attributes
        Dim hash As Integer
        hash = numberResults + obj.GetHashCode() + loadCase.GetHashCode() + fvm.GetHashCode()
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
        '1. Check input Obj Data Type to match the current class
        If Not obj.GetType().Equals(Me.GetType) Then
            Return Nothing
        End If
        '2. Down-Cast the input Object to the current class
        Dim sfObj As ShellForces
        sfObj = CType(obj, ShellForces)
        '3. Compare the two instances of the class giving precedence to the numberResults
        '   and the obj attributes
        If Me.numberResults > sfObj.getnumberResults() Then
            Return 1
        ElseIf Me.numberResults < sfObj.getnumberResults() Then
            Return -1
        ElseIf Me.loadCase(0).CompareTo(sfObj.getloadCase()(0)) <> 0 Then
            Return Me.loadCase(0).CompareTo(sfObj.getloadCase()(0))
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
        Dim sfObj As ShellForces
        sfObj = CType(obj, ShellForces)

        '3. Check if attributes values are the same
        If Me.numberResults = sfObj.getnumberResults() And
            Me.obj.Equals(sfObj.getobj()) And
            Me.pointElm.Equals(sfObj.getpointElm()) And
            Me.loadCase.Equals(sfObj.getloadCase()) And
            Me.f11.Equals(sfObj.getf11()) Then
            Return True
        Else
            Return False
        End If

    End Function

End Class
