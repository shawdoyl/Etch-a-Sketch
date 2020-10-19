Public Class Form1
    Public graph As Graphics

    Private Sub GraphicsForm_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox.MouseMove

        'create graphics object
        graph = PictureBox.CreateGraphics

        Static penColor As Color
        If penColor.IsEmpty = True Then
            penColor = Color.Black
        End If

        'constructor for pen object
        Dim myPen As New Pen(penColor)

        Static oldX As Integer
        Static oldY As Integer

        If e.Button.ToString = "Left" Then
            'draw the line
            graph.DrawLine(myPen, oldX, oldY, e.X, e.Y)
        ElseIf e.Button.ToString = "Middle" Then
            ColorDialog1.ShowDialog()
            penColor = ColorDialog1.Color
            myPen.Color = penColor
        End If

        'store position
        oldX = e.X
        oldY = e.Y

        'free up resources
        myPen.Dispose()
        graph.Dispose()

    End Sub
    Private Sub GraphicsForm_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Me.Text = e.Button.ToString
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        graph.Dispose()

    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub WaveformButton_Click(sender As Object, e As EventArgs) Handles DrawWaveformsButton.Click

        'create graphics object
        Dim graph As Graphics
        graph = PictureBox.CreateGraphics

        'constructor for pen object
        Dim myPen As New Pen(Color.Black)

        'draw the line
        graph.DrawLine(myPen, 10, 10, 200, 200)

        'free up resources
        myPen.Dispose()
        graph.Dispose()

    End Sub


    Private Sub ColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click, AboutToolStripMenuItem1.Click
        MsgBox("Etch-A-Sketch program Beta Version 1.0.001" & vbNewLine _
               & "Doyle Shaw" & vbNewLine _
               & "Fall 2020" & vbNewLine _
               & "RCET0265" & vbNewLine _
               & "In association with Al's Toy Barn.")
    End Sub

End Class
