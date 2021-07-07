'
' Created by Adam Jost May 01, 2021
'
Public Class SquareColor

    'Data field
    Private color As Color

    'Constructor
    Public Sub New(color As Color)
        Me.color = color
    End Sub

    'Property
    Public Property ColorVal() As Color
        Get
            Return color
        End Get
        Set(colorVal As Color)
            Me.color = colorVal
        End Set
    End Property

    'Overload the addition (+) operator.
    Public Shared Operator +(left As SquareColor, right As SquareColor) As Color

        'If the left operand is currently white then return the right operand's color.
        If left.color = Color.GhostWhite Then
            Return right.color
        End If

        'If the right operand is currently white then return the left operand's color.
        If right.color = Color.GhostWhite Then
            Return left.color
        End If

        'If both of the colors are the same then return their shared color.
        If left.color = right.color Then
            Return left.color
        End If

        'If the left operand is blue.
        If left.color = Color.FromArgb(0, 0, 255) Then
            'If the right operand is green return cyan.
            If right.color = Color.FromArgb(0, 180, 0) Then
                Return Color.Cyan
                'If the right operand is red return magenta.
            ElseIf right.color = Color.FromArgb(255, 0, 0) Then
                Return Color.Magenta
            End If
            'If the left operand is green.
        ElseIf left.color = Color.FromArgb(0, 180, 0) Then
            'If the right operand is red return yellow.
            If right.color = Color.FromArgb(255, 0, 0) Then
                Return Color.Yellow
                'If the right operand is blue then return cyan.
            ElseIf right.color = Color.FromArgb(0, 0, 255) Then
                Return Color.Cyan
            End If
            'If the left operand is red.
        ElseIf left.color = Color.FromArgb(255, 0, 0) Then
            'If the right operand is blue then return magenta.
            If right.color = Color.FromArgb(0, 0, 255) Then
                Return Color.Magenta
                'If the right operand is green then return yellow.
            ElseIf right.color = Color.FromArgb(0, 180, 0) Then
                Return Color.Yellow
            End If
        End If

    End Operator
End Class
