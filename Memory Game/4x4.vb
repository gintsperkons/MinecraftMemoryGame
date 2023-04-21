Imports System.IO.Path
Imports System.Reflection
Imports System.IO
Public Class Frm_4x4
    Dim r As New List(Of Integer)
    Dim Img() As String = New String() {"Grass_Block", "Slime", "Emerald_Block", "Diamond_Block", "Dark_Oak_Log", "Iron_Block", "Gold_Block", "CobbleStone", "Grass_Block", "Slime", "Emerald_Block", "Diamond_Block", "Dark_Oak_Log", "Iron_Block", "Gold_Block", "CobbleStone"}
    Dim fnb, snb, test As Boolean
    Dim P1, P2, c, b1, Showtime, snh, fnh, min, sec, i, rn, b2, n As Integer
    Dim Lb1 As String
    Dim Lb2 As String
    Dim Lb3 As String
    Dim Lb4 As String
    Dim Lb5 As String
    Dim crt_score As String
    Dim score() As String = {}
    Dim scoresrd() As String
    Private originalSize As Size
    Dim win, clicksnd As New Media.SoundPlayer
    Private Sub Frm_4x4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim monitorWidth As Integer = My.Computer.Screen.WorkingArea.Size.Width
        Dim monitorHeight As Integer = My.Computer.Screen.WorkingArea.Size.Height
        Me.Width = monitorWidth / 2
        Me.Height = monitorHeight / 2
        n = 16
        readtxt()
    End Sub
    Private Sub Frm_4x4_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
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
            Me.originalSize = Me.ClientSize
        End If
        Me.Text = Me.Name & " " & Me.Width & " x " & Me.Height
    End Sub
    Private Sub Tmr_time_Tick(sender As Object, e As EventArgs) Handles Tmr_time.Tick
        sec = sec + 1
        Lb_time.Text = CStr(min) + ":" + CStr(sec)
        If sec = 60 Then
            sec = sec - 60
            min = min + 1
        End If
    End Sub
    Private Sub Game_time_Tick(sender As Object, e As EventArgs) Handles Game_time.Tick

        If snb = True Then
            If fnh = snh - (n / 2) Or snh = fnh - (n / 2) Or snh <> fnh - (n / 2) Or fnh <> snh - (n / 2) Then
                Tmr_show.Enabled = True
            End If
        End If
        For b1 = 1 To n
            If Me.Controls("Btn_" & CStr(b1)).Text = "Yes" Then
                test = True
            Else
                test = False
                Exit For
            End If
        Next
        LB_1.Text = "1." + Lb1
        LB_2.Text = "2." + Lb2
        LB_3.Text = "3." + Lb3
        LB_4.Text = "4." + Lb4
        LB_5.Text = "5." + Lb5
        If test = True Then
            playwinsound()
            While c < 1500
                c += 1
            End While
            crt_score = CStr(min) + ":" + CStr(sec)
            Lb_c.Text = "Congratulations"
            score = {CStr(Lb1), CStr(Lb2), CStr(Lb3), CStr(Lb4), CStr(Lb5), CStr(crt_score)}
            System.Array.Sort(score)
            Lb1 = score(0)
            Lb2 = score(1)
            Lb3 = score(2)
            Lb4 = score(3)
            Lb5 = score(4)
            LB_1.Text = "1." + Lb1
            LB_2.Text = "2." + Lb2
            LB_3.Text = "3." + Lb3
            LB_4.Text = "4." + Lb4
            LB_5.Text = "5." + Lb5
            Game_end()
        End If
    End Sub

    Private Sub Tmr_show_Tick(sender As Object, e As EventArgs) Handles Tmr_show.Tick
        If fnh = snh - (n / 2) Or snh = fnh - (n / 2) Then
            IFyes()
            fnh = 0
            snh = 0
            Tmr_show.Enabled = False
        ElseIf fnh <> snh - (n / 2) Or snh <> fnh - (n / 2) Then
            IFno()
            fnh = 0
            snh = 0
            Tmr_show.Enabled = False
        End If
    End Sub
    Private Sub Btn_Start_Click(sender As Object, e As EventArgs) Handles Btn_start.Click
        min = 0
        sec = 0
        fnb = False
        snb = False
        For b1 = 1 To n
            Me.Controls("Btn_" & CStr(b1)).Visible = True
            Me.Controls("Btn_" & CStr(b1)).Enabled = True
            Me.Controls("Btn_" & CStr(b1)).Text = "?"
        Next
        Btn_stop.Enabled = True
        Btn_start.Enabled = False
        Btn_exit.Enabled = False
        Btn_pause.Enabled = True
        Randomizer()
        Picture_Putter()
        Tmr_time.Start()
        Lb_c.Text = ""
        Game_time.Enabled = True
        snb = False
        fnb = False
        PlayClickSound()
    End Sub
    Private Sub Btn_pause_Click(sender As Object, e As EventArgs) Handles Btn_pause.Click
        For b1 = 1 To n
            Me.Controls("Btn_" & CStr(b1)).Enabled = Not Me.Controls("Btn_" & CStr(b1)).Enabled
        Next
        Game_time.Enabled = Not Game_time.Enabled
        Tmr_time.Enabled = Not Tmr_time.Enabled
        PlayClickSound()
    End Sub
    Private Sub Btn_stop_Click(sender As Object, e As EventArgs) Handles Btn_stop.Click
        Game_end()
        PlayClickSound()
    End Sub
    Private Sub Btn_exit_Click(sender As Object, e As EventArgs) Handles Btn_exit.Click
        PlayClickSound()
        Game_end()
        Close()
        writetxt()
    End Sub
    Private Sub Btn_back_Click(sender As Object, e As EventArgs) Handles Btn_back.Click
        PlayClickSound()
        Game_end()
        writetxt()
        Frm_Selection.Show()
        Me.Close()
    End Sub
    Private Sub Snd_onf_click(sender As Object, e As EventArgs) Handles Snd_onf.Click
        If Snd_onf.Text = "Sound On" Then
            Snd_onf.Text = "Sound Off"
        ElseIf Snd_onf.Text = "Sound Off" Then
            Snd_onf.Text = "Sound On"
        End If
    End Sub
    Private Sub Btn_1_Click(sender As Object, e As EventArgs) Handles Btn_1.Click
        Check(1)
        PlayClickSound()
    End Sub
    Private Sub Btn_2_Click(sender As Object, e As EventArgs) Handles Btn_2.Click
        Check(2)
        PlayClickSound()
    End Sub
    Private Sub Btn_3_Click(sender As Object, e As EventArgs) Handles Btn_3.Click
        Check(3)
        PlayClickSound()
    End Sub
    Private Sub Btn_4_Click(sender As Object, e As EventArgs) Handles Btn_4.Click
        Check(4)
        PlayClickSound()
    End Sub
    Private Sub Btn_5_Click(sender As Object, e As EventArgs) Handles Btn_5.Click
        Check(5)
        PlayClickSound()
    End Sub
    Private Sub Btn_6_Click(sender As Object, e As EventArgs) Handles Btn_6.Click
        Check(6)
        PlayClickSound()
    End Sub
    Private Sub Btn_7_Click(sender As Object, e As EventArgs) Handles Btn_7.Click
        Check(7)
        PlayClickSound()
    End Sub
    Private Sub Btn_8_Click(sender As Object, e As EventArgs) Handles Btn_8.Click
        Check(8)
        PlayClickSound()
    End Sub
    Private Sub Btn_9_Click(sender As Object, e As EventArgs) Handles Btn_9.Click
        Check(9)
        PlayClickSound()
    End Sub
    Private Sub Btn_10_Click(sender As Object, e As EventArgs) Handles Btn_10.Click
        Check(10)
        PlayClickSound()
    End Sub
    Private Sub Btn_11_Click(sender As Object, e As EventArgs) Handles Btn_11.Click
        Check(11)
        PlayClickSound()
    End Sub
    Private Sub Btn_12_Click(sender As Object, e As EventArgs) Handles Btn_12.Click
        Check(12)
        PlayClickSound()
    End Sub
    Private Sub Btn_13_Click(sender As Object, e As EventArgs) Handles Btn_13.Click
        Check(13)
        PlayClickSound()
    End Sub
    Private Sub Btn_14_Click(sender As Object, e As EventArgs) Handles Btn_14.Click
        Check(14)
        PlayClickSound()
    End Sub
    Private Sub Btn_15_Click(sender As Object, e As EventArgs) Handles Btn_15.Click
        Check(15)
        PlayClickSound()
    End Sub
    Private Sub Btn_16_Click(sender As Object, e As EventArgs) Handles Btn_16.Click
        Check(16)
        PlayClickSound()
    End Sub
    Private Sub IFyes()
        For b1 = 1 To n
            If Me.Controls("Btn_" & CStr(b1)).Text = "Wait" Then
                Me.Controls("Btn_" & CStr(b1)).Text = "Yes"

            End If
        Next
        snb = False
        fnb = False
    End Sub
    Private Sub IFno()
        For b1 = 1 To n
            If Me.Controls("Btn_" & CStr(b1)).Text = "Wait" Then
                Me.Controls("Btn_" & CStr(b1)).Text = "?"
                Me.Controls("PBx_" & CStr(b1)).Visible = False
            End If
        Next
        snb = False
        fnb = False
    End Sub
    Private Sub Picture_Putter()
        For b1 = 1 To n

            If Me.Controls("Btn_" & CStr(b1)).Tag > n / 2 Then
                Me.Controls("PBx_" & CStr(b1)).BackgroundImage = Me.Controls("PBx_" & CStr(Img(Me.Controls("Btn_" & CStr(b1)).Tag - (n / 2) - 1))).BackgroundImage
            Else
                Me.Controls("PBx_" & CStr(b1)).BackgroundImage = Me.Controls("PBx_" & CStr(Img(Me.Controls("Btn_" & CStr(b1)).Tag - 1))).BackgroundImage
            End If
        Next
    End Sub
    Private Sub Game_end()
        min = 0
        sec = 0
        Tmr_time.Stop()
        Lb_time.Text = CStr(min) + ":" + CStr(sec)
        For b1 = 1 To n
            Me.Controls("Btn_" & CStr(b1)).Text = ""
            Me.Controls("PBx_" & CStr(b1)).Visible = False
            Me.Controls("Btn_" & CStr(b1)).Visible = False
            Me.Controls("Btn_" & CStr(b1)).Enabled = False
        Next
        Btn_start.Enabled = True
        Btn_stop.Enabled = False
        Btn_pause.Enabled = False
        Btn_exit.Enabled = True
        r.Clear()
        Game_time.Enabled = False
        writetxt()
    End Sub
    Private Sub Randomizer()
        Randomize()
        Do
            rn = CInt(Rnd() * (n - 1) + 1)
            If Not r.Contains(rn) Then
                r.Add(rn)
            End If
        Loop Until r.Count = n
        For b1 = 1 To n
            Me.Controls("Btn_" & CStr(b1)).Tag = r(b1 - 1)
        Next
    End Sub
    Private Sub Check(ByVal idx As Integer)
        If fnb = True Then
            snh = Me.Controls("Btn_" & CStr(idx)).Tag
            Me.Controls("Pbx_" & CStr(idx)).Visible = True
            snb = True
            Me.Controls("Btn_" & CStr(idx)).Text = "Wait"
        End If
        If fnb = False Then
            fnh = Me.Controls("Btn_" & CStr(idx)).Tag
            Me.Controls("Pbx_" & CStr(idx)).Visible = True
            fnb = True
            Me.Controls("Btn_" & CStr(idx)).Text = "Wait"
        End If
    End Sub
    Private Sub PlayClickSound()
        If Snd_onf.Text = "Sound On" Then
            My.Computer.Audio.Play(My.Resources.clicksnd, AudioPlayMode.WaitToComplete)
        End If
    End Sub
    Private Sub playwinsound()
        If Snd_onf.Text = "Sound On" Then
            My.Computer.Audio.Play(My.Resources.win, AudioPlayMode.WaitToComplete)
        End If
    End Sub
    Private Sub writetxt()
        'file located in debug or executable directory in resources folder
        FileOpen(1, "1.txt", OpenMode.Output, OpenAccess.Write)
        PrintLine(1, Lb1)
        PrintLine(1, Lb2)
        PrintLine(1, Lb3)
        PrintLine(1, Lb4)
        PrintLine(1, Lb5)
        FileClose(1)
    End Sub
    Private Sub readtxt()
        'file located in debug
        FileOpen(1, "1.txt", OpenMode.Input, OpenAccess.Read)
        Lb1 = LineInput(1)
        Lb2 = LineInput(1)
        Lb3 = LineInput(1)
        Lb4 = LineInput(1)
        Lb5 = LineInput(1)
        FileClose(1)
    End Sub
End Class
