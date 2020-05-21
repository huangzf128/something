<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.richTxtStoredDef = New System.Windows.Forms.RichTextBox()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.btnExeProc = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtStoredInfo = New System.Windows.Forms.TextBox()
        Me.btnExeAll = New System.Windows.Forms.Button()
        Me.btnCreateProc = New System.Windows.Forms.Button()
        Me.SuspendLayout
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = true
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(12, 66)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(144, 616)
        Me.ListBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(16, 43)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ストアド一覧"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("MS UI Gothic", 16!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(304, 17)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(339, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "STORED DEFINITION WATCHER"
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128,Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(176, 43)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "定義"
        '
        'richTxtStoredDef
        '
        Me.richTxtStoredDef.Location = New System.Drawing.Point(165, 66)
        Me.richTxtStoredDef.Margin = New System.Windows.Forms.Padding(2)
        Me.richTxtStoredDef.Name = "richTxtStoredDef"
        Me.richTxtStoredDef.Size = New System.Drawing.Size(958, 616)
        Me.richTxtStoredDef.TabIndex = 5
        Me.richTxtStoredDef.Text = ""
        '
        'btnReload
        '
        Me.btnReload.Location = New System.Drawing.Point(12, 15)
        Me.btnReload.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(68, 22)
        Me.btnReload.TabIndex = 8
        Me.btnReload.Text = "再読込み"
        Me.btnReload.UseVisualStyleBackColor = true
        '
        'btnExeProc
        '
        Me.btnExeProc.Location = New System.Drawing.Point(105, 15)
        Me.btnExeProc.Name = "btnExeProc"
        Me.btnExeProc.Size = New System.Drawing.Size(75, 23)
        Me.btnExeProc.TabIndex = 9
        Me.btnExeProc.Text = "実行(Call)"
        Me.btnExeProc.UseVisualStyleBackColor = true
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(744, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 12)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "ストアド情報："
        '
        'txtStoredInfo
        '
        Me.txtStoredInfo.Location = New System.Drawing.Point(821, 17)
        Me.txtStoredInfo.Multiline = true
        Me.txtStoredInfo.Name = "txtStoredInfo"
        Me.txtStoredInfo.Size = New System.Drawing.Size(173, 41)
        Me.txtStoredInfo.TabIndex = 11
        '
        'btnExeAll
        '
        Me.btnExeAll.Location = New System.Drawing.Point(196, 15)
        Me.btnExeAll.Name = "btnExeAll"
        Me.btnExeAll.Size = New System.Drawing.Size(75, 23)
        Me.btnExeAll.TabIndex = 12
        Me.btnExeAll.Text = "CallAll"
        Me.btnExeAll.UseVisualStyleBackColor = true
        '
        'btnCreateProc
        '
        Me.btnCreateProc.Location = New System.Drawing.Point(1018, 15)
        Me.btnCreateProc.Name = "btnCreateProc"
        Me.btnCreateProc.Size = New System.Drawing.Size(75, 23)
        Me.btnCreateProc.TabIndex = 13
        Me.btnCreateProc.Text = "Create"
        Me.btnCreateProc.UseVisualStyleBackColor = true
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 12!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 691)
        Me.Controls.Add(Me.btnCreateProc)
        Me.Controls.Add(Me.btnExeAll)
        Me.Controls.Add(Me.txtStoredInfo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnExeProc)
        Me.Controls.Add(Me.btnReload)
        Me.Controls.Add(Me.richTxtStoredDef)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form1"
        Me.Text = "Watcher"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents richTxtStoredDef As System.Windows.Forms.RichTextBox
    Friend WithEvents btnReload As System.Windows.Forms.Button
    Friend WithEvents btnExeProc As System.Windows.Forms.Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtStoredInfo As TextBox
    Friend WithEvents btnExeAll As Button
    Friend WithEvents btnCreateProc As Button
End Class
