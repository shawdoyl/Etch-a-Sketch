Public Class Form1

    Private Sub GraphicsForm_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

        Me.Text = "x: " & e.X & " y: " & e.Y & " Mouse Button: " & e.Button.ToString

        'create graphics object
        Dim graph As Graphics
        graph = Me.CreateGraphics

        Dim penColor As Color
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

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click

    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub WaveformButton_Click(sender As Object, e As EventArgs) Handles WaveformButton.Click

    End Sub

    Private Sub ColorButton_Click(sender As Object, e As EventArgs) Handles ColorButton.Click
        Static penColor As Color
        Dim myPen As New Pen(penColor)

        ColorDialog1.ShowDialog()
        penColor = ColorDialog1.Color
        myPen.Color = penColor
    End Sub
End Class
