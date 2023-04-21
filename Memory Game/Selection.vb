Public Class Frm_Selection
    Dim oForm As Form
    Private originalSize As Size
    Private Sub Frm_Selection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' --- get client Moniter Resolution
        Dim monitorWidth As Integer = My.Computer.Screen.WorkingArea.Size.Width
        Dim monitorHeight As Integer = My.Computer.Screen.WorkingArea.Size.Height
        ' --- adjust size of this form ** this does NOT make consideration of DPI (eg. 125%, 150%) **
        Me.Width = monitorWidth / 2
        Me.Height = monitorHeight / 2
    End Sub
    ' ---
    Private Sub Frm_Selection_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        ' --- adjust size and location of Controls on this form
        If Not Me.WindowState = FormWindowState.Minimized Then
            Dim ScaleSize As New SizeF _
                (CSng((Me.ClientSize.Width / Me.originalSize.Width)),
                CSng((Me.ClientSize.Height / Me.originalSize.Height)))
            ' ---
            For Each ctrl As Control In Me.Controls
                If (TypeOf ctrl Is ListBox) Then
                    DirectCast(ctrl, ListBox).IntegralHeight = False
                End If
                Dim fntscl As Single = ctrl.Font.Size * ScaleSize.Height
                ctrl.Font = New Font(ctrl.Font.FontFamily, fntscl, ctrl.Font.Style, ctrl.Font.Unit)
                ctrl.Scale(ScaleSize)
            Next
            ' ---
            Me.originalSize = Me.ClientSize
        End If
        Me.Text = Me.Name & " " & Me.Width & " x " & Me.Height
    End Sub

    Private Sub Btn4x4_Click(sender As Object, e As EventArgs) Handles Btn4x4.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button1.Click
        Frm_4x4.Show()
        Me.Close()
    End Sub

End Class