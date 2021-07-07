'
' Created by Adam Jost May 01, 2021
'
Public Class ColorSquare

    'Data fields
    Private xCoord As UInt16
    Private yCoord As UInt16
    Private color As Color
    Private sqrNum As UInt16 'Used for .Name (e.g. 1 for "ColorSquare1").

    'Constructor
    Public Sub New(Optional x As UInt16 = 0, Optional y As UInt16 = 0, Optional sqrNum As UInt16 = 0)
        Me.xCoord = x
        Me.yCoord = y
        Me.sqrNum = sqrNum
        Me.color = Color.GhostWhite
    End Sub

    'Properties
    Public Property XCoordVal() As UInt16
        Get
            Return xCoord
        End Get
        Set(xVal As UInt16)
            Me.xCoord = xVal
        End Set
    End Property

    Public Property YCoordVal() As UInt16
        Get
            Return yCoord
        End Get
        Set(yVal As UInt16)
            Me.yCoord = yVal
        End Set
    End Property

    Public Property ColorVal() As Color
        Get
            Return color
        End Get
        Set(colorVal As Color)
            Me.color = colorVal
        End Set
    End Property

    'Class-member procedures

    'Creates and describes the Label that visually represents the ColorSquare.
    Public Function Draw() As Label

        'Create a button to visually represent the ColorSquare object.
        Dim colorSquare As Label = New Label()

        'Describe the ColorSquare object's visual representation.
        With colorSquare
            .Size = New Size(100.5, 100.5)
            .Location = New Size(xCoord, yCoord)
            .BorderStyle = BorderStyle.Fixed3D
            .BackColor = ColorVal
            .Name = "ColorSquare" + sqrNum.ToString
            AddHandler .Click, AddressOf Click_Handler
            AddHandler .MouseHover, AddressOf On_Hover
            AddHandler .MouseLeave, AddressOf On_Leave
            AddHandler .Paint, AddressOf On_Paint
        End With

        Return colorSquare

    End Function

    'Handles Paint event for the ColorSquare.
    Private Sub On_Paint(Sender As Object, e As PaintEventArgs)
        'Adds a light colored inset border around the label representing the "ColorSquare".
        ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.FromArgb(200, 200, 200), ButtonBorderStyle.Inset)
    End Sub

    'On-Hover handler for ColorSquares. Handles MouseHover event for when a cursor enters the bounds of a ColorSquare.
    Private Sub On_Hover(Sender As Object, E As EventArgs)

        'If the Sender is not a "result" ColorSquare, execute the following.
        If sqrNum < 9 Then

            With Sender

                'Show instruction text to the user.
                .TextAlign = ContentAlignment.MiddleCenter
                .Text = "Click to Change Color"
                .ForeColor = Color.FromArgb(30, 30, 30)

                'Give enabled appearance by slightly adjusting the current color value.
                If .BackColor = Color.GhostWhite Then
                    .BackColor = Color.FromArgb(220, 220, 220)
                ElseIf .BackColor = Color.FromArgb(255, 0, 0) Then
                    .BackColor = Color.FromArgb(235, 60, 60)
                ElseIf .BackColor = Color.FromArgb(0, 180, 0) Then
                    .BackColor = Color.FromArgb(60, 160, 60)
                ElseIf .BackColor = Color.FromArgb(0, 0, 255) Then
                    .BackColor = Color.FromArgb(60, 60, 235)
                End If

            End With
        End If

    End Sub

    'On-Leave Handler that handles MouseLeave event for when the cursor leaves the bounds of a ColorSquare.
    Private Sub On_Leave(Sender As Object, E As EventArgs)

        'If it is any ColorSquare other than the "result" squares...
        If sqrNum < 9 Then
            With Sender
                'Reset the color.
                .BackColor = ColorVal
                'Remove the instruction text.
                .Text = " "
            End With
        End If
    End Sub

    'Click handler of a ColorSquare.
    Private Sub Click_Handler(Sender As Object, E As EventArgs)

        'If the Sender is not a "result" ColorSquare...
        If sqrNum < 9 Then

            'Change the backcolor value of the ColorSquare to the "next" color.
            With Sender

                'Advance the color value to the next color value.
                If ColorVal = Color.GhostWhite Then
                    ColorVal = Color.FromArgb(255, 0, 0)
                ElseIf ColorVal = Color.FromArgb(255, 0, 0) Then
                    ColorVal = Color.FromArgb(0, 180, 0)
                ElseIf ColorVal = Color.FromArgb(0, 180, 0) Then
                    ColorVal = Color.FromArgb(0, 0, 255)
                Else
                    ColorVal = Color.GhostWhite
                End If

                'Set the BackColor to the color value.
                .BackColor = ColorVal

            End With
        End If

    End Sub


End Class
