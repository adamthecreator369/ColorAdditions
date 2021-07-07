'
' Created by Adam Jost May 01, 2021
'
Public Class ColorAdditionsForm

    Private Sub ColorAdditionsForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Describe the form.
        With Me
            .Text = "Color Additions"
            .Size = New Size(980, 293)
            .CenterToScreen()
            .MaximizeBox = False
            .FormBorderStyle = FormBorderStyle.FixedSingle
            .BackColor = Color.FromArgb(205, 205, 205)
            .Name = "MainForm"
        End With

        'ColorSquares 

        'Create ColorSquare objects representing left operands of the equation.
        Dim Lft_Operand_TL_Sqr As ColorSquare = New ColorSquare(23, 23, 1)
        Dim Lft_Operand_TR_Sqr As ColorSquare = New ColorSquare(131, 23, 2)
        Dim Lft_Operand_BL_Sqr As ColorSquare = New ColorSquare(23, 131, 3)
        Dim Lft_Operand_BR_Sqr As ColorSquare = New ColorSquare(131, 131, 4)

        'Add left operands of Color Addition equation to the GUI
        Controls.Add(Lft_Operand_TL_Sqr.Draw())
        Controls.Add(Lft_Operand_TR_Sqr.Draw())
        Controls.Add(Lft_Operand_BL_Sqr.Draw())
        Controls.Add(Lft_Operand_BR_Sqr.Draw())

        'Create ColorSquare objects representing right operands of the equation.
        Dim Rt_Operand_TL_Sqr As ColorSquare = New ColorSquare(309, 23, 5)
        Dim Rt_Operand_TR_Sqr As ColorSquare = New ColorSquare(417, 23, 6)
        Dim Rt_Operand_BL_Sqr As ColorSquare = New ColorSquare(309, 131, 7)
        Dim Rt_Operand_BR_Sqr As ColorSquare = New ColorSquare(417, 131, 8)

        'Add right operands of Color Addition equation to the GUI.
        Controls.Add(Rt_Operand_TL_Sqr.Draw())
        Controls.Add(Rt_Operand_TR_Sqr.Draw())
        Controls.Add(Rt_Operand_BL_Sqr.Draw())
        Controls.Add(Rt_Operand_BR_Sqr.Draw())

        'Addition symbol (+) 

        'Create the "Addition" symbol label.
        Dim Addition_Label As Label = New Label()

        'Describe the addition label
        With Addition_Label
            .Size = New Size(100, 215)
            .Location = New Size(223, 17)
            .Text = "⊹"
            .Font = New Font("Verdana", 30)
            .ForeColor = Color.FromArgb(50, 50, 50)
            .TextAlign = ContentAlignment.MiddleCenter
            .Name = "AdditionLabel"
        End With

        'Add the "Addition symbol" to the GUI.
        Controls.Add(Addition_Label)

        'Calculate button

        'Create the Calculate button.
        Dim Calc_Button As Button = New Button()

        'Describe the Calculate button.
        With Calc_Button
            .Size = New Size(142, 29)
            .Location = New Size(543, 111)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100)
            .BackColor = Color.GhostWhite
            .ForeColor = Color.Black
            .Text = "Show Result ➯ ➯"
            .Font = New Font("Verdana", 8)
            .Name = "CalcButton"
            AddHandler .Click, AddressOf CalcButton_Click
        End With

        'Add the Calculate button to the GUI.
        Controls.Add(Calc_Button)

    End Sub

    'Button click handler for the "calculate" button.
    Private Sub CalcButton_Click(Sender As Object, E As EventArgs)

        'Save all of the colors currently set in each left and right operand ColorSquare.
        Dim TL_Color_One As SquareColor = New SquareColor(Controls.Item("ColorSquare1").BackColor)
        Dim TL_Color_Two As SquareColor = New SquareColor(Controls.Item("ColorSquare5").BackColor)
        Dim TR_Color_One As SquareColor = New SquareColor(Controls.Item("ColorSquare2").BackColor)
        Dim TR_Color_Two As SquareColor = New SquareColor(Controls.Item("ColorSquare6").BackColor)
        Dim BL_Color_One As SquareColor = New SquareColor(Controls.Item("ColorSquare3").BackColor)
        Dim BL_Color_Two As SquareColor = New SquareColor(Controls.Item("ColorSquare7").BackColor)
        Dim BR_Color_One As SquareColor = New SquareColor(Controls.Item("ColorSquare4").BackColor)
        Dim BR_Color_Two As SquareColor = New SquareColor(Controls.Item("ColorSquare8").BackColor)

        'If the "result" ColorSquares do not already exist...
        If Not Controls.ContainsKey("ColorSquare9") Then

            'Create the "result" ColorSquares of the "Color Addition" equation.
            Dim Result_TL_Sqr As ColorSquare = New ColorSquare(732, 23, 9)
            Dim Result_TR_Sqr As ColorSquare = New ColorSquare(840, 23, 10)
            Dim Result_BL_Sqr As ColorSquare = New ColorSquare(732, 131, 11)
            Dim Result_BR_Sqr As ColorSquare = New ColorSquare(840, 131, 12)

            'Display initial result by adding all "result" ColorSquares to the Controls
            Controls.Add(Result_TL_Sqr.Draw())
            Controls.Add(Result_TR_Sqr.Draw())
            Controls.Add(Result_BL_Sqr.Draw())
            Controls.Add(Result_BR_Sqr.Draw())

        End If

        'Add the value of the calculated colors to the "result" ColorSquares.
        Controls.Item("ColorSquare9").BackColor = TL_Color_One + TL_Color_Two
        Controls.Item("ColorSquare10").BackColor = TR_Color_One + TR_Color_Two
        Controls.Item("ColorSquare11").BackColor = BL_Color_One + BL_Color_Two
        Controls.Item("ColorSquare12").BackColor = BR_Color_One + BR_Color_Two

    End Sub

End Class