Option Strict On
Option Explicit OnImports System.MathPublic Class EtchaSketchForm    Public graph As Graphics    Public penColor As Color

    Sub DrawSinWave()
        'vi = vp * sin(w*t+theta)+DC
        'w = 2 * PI * f
        'w = 360 * f
        Dim g As Graphics = PictureBox.CreateGraphics
        Dim pen As New Pen(Color.DarkRed, 2)
        Dim xMax As Single = 360 ' 100 made up units wide
        Dim xScale As Single = PictureBox.Width / xMax
        Dim xCurrent As Double
        Dim xOld As Double
        Dim yMax As Single = 100 ' 100 made up units high
        Dim yScale As Single = CSng(PictureBox.Height / 2) / yMax
        Dim yCurrent As Double
        Dim yOld As Double
        g.ScaleTransform(xScale, yScale)
        g.TranslateTransform(0, (yMax))
        For xCurrent = 0 To 360
            yCurrent = yMax * Sin((PI / 180) * xCurrent)
            g.DrawLine(pen, CInt(xOld), CInt(yOld), CInt(xCurrent), CInt(yCurrent))
            xOld = xCurrent
            yOld = yCurrent
        Next
        pen.Dispose()
        g.Dispose()
    End Sub
    Sub DrawCosWave()
        Dim g As Graphics = PictureBox.CreateGraphics
        Dim pen As New Pen(Color.Blue, 2)
        Dim xMax As Single = 360 ' 100 made up units wide
        Dim xScale As Single = PictureBox.Width / xMax
        Dim xCurrent As Double
        Dim xOld As Double
        Dim yMax As Single = 100 ' 100 made up units high
        Dim yScale As Single = CSng(PictureBox.Height / 2) / yMax
        Dim yCurrent As Double
        Dim yOld As Double
        g.ScaleTransform(xScale, yScale)
        g.TranslateTransform(0, (yMax))
        For xCurrent = 0 To 360
            yCurrent = yMax * Cos((PI / 180) * xCurrent)
            g.DrawLine(pen, CInt(xOld), CInt(yOld), CInt(xCurrent), CInt(yCurrent))
            xOld = xCurrent
            yOld = yCurrent
        Next
        pen.Dispose()
        g.Dispose()
    End Sub
    Sub DrawTanWave()
        Dim g As Graphics = PictureBox.CreateGraphics
        Dim pen As New Pen(Color.Yellow, 2)
        Dim xMax As Single = 360 ' 100 made up units wide
        Dim xScale As Single = PictureBox.Width / xMax
        Dim xCurrent As Double
        Dim xOld As Double
        Dim yMax As Single = 100 ' 100 made up units high
        Dim yScale As Single = CSng(PictureBox.Height / 2) / yMax
        Dim yCurrent As Double
        Dim yOld As Double
        g.ScaleTransform(xScale, yScale)
        g.TranslateTransform(0, (yMax * -1))
        For xCurrent = 0 To 360
            yCurrent = yMax * Tan((PI / 180) * xCurrent)
            g.DrawLine(pen, CInt(xOld), CInt(yOld), CInt(xCurrent), CInt(yCurrent))
            xOld = xCurrent
            yOld = yCurrent
        Next
        pen.Dispose()
        g.Dispose()
    End Sub
    Sub DrawGraphLines()
        Dim pen As New Pen(Color.Black)
        Dim x, y As Integer
        Dim intSpacing As Integer = 50

        graph = PictureBox.CreateGraphics
        graph.Clear(Color.Silver)

        x = PictureBox.Width
        For y = 0 To PictureBox.Height Step intSpacing
            graph.DrawLine(pen, New Point(0, y), New Point(x, y))
        Next
        y = PictureBox.Height
        For x = 0 To PictureBox.Width Step intSpacing
            graph.DrawLine(pen, New Point(x, 0), New Point(x, y))
        Next
        pen.Dispose()
        graph.Dispose()
    End Sub
    Private Sub GraphicsForm_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseMove
        'constructor for pen object
        Dim myPen As New Pen(penColor)        Static oldX, oldY As Integer        graph = PictureBox.CreateGraphics        If penColor.IsEmpty = True Then            penColor = Color.Black        End If        If e.Button.ToString = "Left" Then
            'draw the line
            graph.DrawLine(myPen, oldX, oldY, e.X, e.Y)        ElseIf e.Button.ToString = "Middle" Then            ColorButton_Click(sender, e)            myPen.Color = penColor
        ElseIf e.Button.ToString = "Right" Then
            myPen.Width = 5            graph.DrawLine(myPen, oldX, oldY, e.X, e.Y)        End If
        'store position
        oldX = e.X        oldY = e.Y
        'free up resources
        myPen.Dispose()        graph.Dispose()    End Sub    Private Sub GraphicsForm_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown        Me.Text = e.Button.ToString    End Sub    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click,        ClearToolStripMenuItem.Click, ClearToolStripMenuItem1.Click        PictureBox.Image = Nothing    End Sub    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click,        ExitToolStripMenuItem.Click, ExitToolStripMenuItem1.Click        Dim Msg, Title As String        Dim Style As MsgBoxStyle        Dim Response As Integer        Msg = "Do you want to close the program?"        Title = "Close Program?"        Style = CType(vbYesNo + vbDefaultButton2, MsgBoxStyle)        Response = MsgBox(Msg, Style, Title)        If Response = vbYes Then
            Me.Close()
        Else        End If    End Sub    Private Sub WaveformButton_Click(sender As Object, e As EventArgs) Handles DrawWaveformsButton.Click,        DrawWaveformsToolStripMenuItem.Click, DrawWaveformsToolStripMenuItem1.Click

        DrawGraphLines()
        DrawSinWave()
        DrawCosWave()
        'DrawTanWave()
    End Sub    Private Sub ColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click,        SelectColorToolStripMenuItem.Click, SelectColorToolStripMenuItem1.Click        ColorDialog1.ShowDialog()        penColor = ColorDialog1.Color        SelectColorButton.BackColor = penColor    End Sub    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click, AboutToolStripMenuItem1.Click        MsgBox("Etch-A-Sketch program Beta Version 1.0.001" & vbNewLine _
                  & "Doyle Shaw" & vbNewLine _
                  & "Fall 2020" & vbNewLine _
                  & "RCET0265" & vbNewLine _
                  & "In association with Al's Toy Barn.")    End Sub
End Class