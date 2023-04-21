<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Splash
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Lb_splash = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Lb_splash
        '
        Me.Lb_splash.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Lb_splash.AutoSize = True
        Me.Lb_splash.Font = New System.Drawing.Font("Arial Rounded MT Bold", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lb_splash.ForeColor = System.Drawing.Color.Lime
        Me.Lb_splash.Location = New System.Drawing.Point(94, 192)
        Me.Lb_splash.Name = "Lb_splash"
        Me.Lb_splash.Size = New System.Drawing.Size(720, 111)
        Me.Lb_splash.TabIndex = 0
        Me.Lb_splash.Text = "Memory Game"
        Me.Lb_splash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Frm_Splash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(879, 530)
        Me.Controls.Add(Me.Lb_splash)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "Frm_Splash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Splash Screen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lb_splash As Label
End Class
