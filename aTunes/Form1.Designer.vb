<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SyncToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayStoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadMedia = New System.ComponentModel.BackgroundWorker()
        Me.sync = New System.ComponentModel.BackgroundWorker()
        Me.did = New System.ComponentModel.BackgroundWorker()
        Me.Music = New System.Windows.Forms.Timer(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.CheckUpdates = New System.ComponentModel.BackgroundWorker()
        Me.ChromeTabcontrol1 = New aTunes.ChromeTabcontrol()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.statusLabel = New System.Windows.Forms.Label()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ChromeButton1 = New aTunes.ChromeButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.ChromeTabcontrol2 = New aTunes.ChromeTabcontrol()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SyncToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.ChromeTabcontrol1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.ChromeTabcontrol2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage7.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(926, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SyncToolStripMenuItem, Me.ReloadToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SyncToolStripMenuItem
        '
        Me.SyncToolStripMenuItem.Name = "SyncToolStripMenuItem"
        Me.SyncToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.SyncToolStripMenuItem.Text = "Sync"
        '
        'ReloadToolStripMenuItem
        '
        Me.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem"
        Me.ReloadToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.ReloadToolStripMenuItem.Text = "Reload"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'PlayStoreToolStripMenuItem
        '
        Me.PlayStoreToolStripMenuItem.Name = "PlayStoreToolStripMenuItem"
        Me.PlayStoreToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.PlayStoreToolStripMenuItem.Text = "Play Store"
        '
        'LoadMedia
        '
        Me.LoadMedia.WorkerReportsProgress = True
        Me.LoadMedia.WorkerSupportsCancellation = True
        '
        'sync
        '
        '
        'Music
        '
        '
        'CheckUpdates
        '
        '
        'ChromeTabcontrol1
        '
        Me.ChromeTabcontrol1.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.ChromeTabcontrol1.Controls.Add(Me.TabPage1)
        Me.ChromeTabcontrol1.Controls.Add(Me.TabPage2)
        Me.ChromeTabcontrol1.Controls.Add(Me.TabPage3)
        Me.ChromeTabcontrol1.Controls.Add(Me.TabPage6)
        Me.ChromeTabcontrol1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChromeTabcontrol1.ItemSize = New System.Drawing.Size(30, 118)
        Me.ChromeTabcontrol1.Location = New System.Drawing.Point(0, 24)
        Me.ChromeTabcontrol1.Multiline = True
        Me.ChromeTabcontrol1.Name = "ChromeTabcontrol1"
        Me.ChromeTabcontrol1.SelectedIndex = 0
        Me.ChromeTabcontrol1.ShowOuterBorders = False
        Me.ChromeTabcontrol1.Size = New System.Drawing.Size(926, 326)
        Me.ChromeTabcontrol1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.ChromeTabcontrol1.SquareColor = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.ChromeTabcontrol1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.LightGray
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.statusLabel)
        Me.TabPage1.Controls.Add(Me.ProgressBar2)
        Me.TabPage1.Controls.Add(Me.PictureBox6)
        Me.TabPage1.Controls.Add(Me.PictureBox5)
        Me.TabPage1.Controls.Add(Me.PictureBox4)
        Me.TabPage1.Controls.Add(Me.PictureBox3)
        Me.TabPage1.Controls.Add(Me.PictureBox2)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.ProgressBar1)
        Me.TabPage1.Controls.Add(Me.ListBox1)
        Me.TabPage1.Location = New System.Drawing.Point(122, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(800, 318)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Media Library"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(228, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Time Left: "
        '
        'statusLabel
        '
        Me.statusLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.statusLabel.AutoSize = True
        Me.statusLabel.Location = New System.Drawing.Point(391, 294)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(52, 13)
        Me.statusLabel.TabIndex = 16
        Me.statusLabel.Text = "Waiting..."
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar2.Location = New System.Drawing.Point(9, 289)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(376, 23)
        Me.ProgressBar2.TabIndex = 15
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox6.Image = Global.aTunes.My.Resources.Resources._123281_matte_red_and_white_square_icon_media_a_media24_arrows_seek_forward
        Me.PictureBox6.Location = New System.Drawing.Point(758, 6)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 14
        Me.PictureBox6.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox5.Image = Global.aTunes.My.Resources.Resources._123280_matte_red_and_white_square_icon_media_a_media23_arrows_seek_back
        Me.PictureBox5.Location = New System.Drawing.Point(719, 6)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 13
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox4.Image = Global.aTunes.My.Resources.Resources.thumbs_123279_matte_red_and_white_square_icon_media_a_media22_arrow_forward1
        Me.PictureBox4.Location = New System.Drawing.Point(680, 6)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 12
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = Global.aTunes.My.Resources.Resources._123284_matte_red_and_white_square_icon_media_a_media27_pause_sign
        Me.PictureBox3.Location = New System.Drawing.Point(641, 6)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 11
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = Global.aTunes.My.Resources.Resources._123283_matte_red_and_white_square_icon_media_a_media26_arrows_skip_forward
        Me.PictureBox2.Location = New System.Drawing.Point(602, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.aTunes.My.Resources.Resources._123282_matte_red_and_white_square_icon_media_a_media25_arrows_skip_back
        Me.PictureBox1.Location = New System.Drawing.Point(563, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(33, 33)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Song Name"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.DarkRed
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 22)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(219, 14)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 7
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.BackColor = System.Drawing.Color.LightGray
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(6, 42)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(786, 238)
        Me.ListBox1.Sorted = True
        Me.ListBox1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.LightGray
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.ChromeButton1)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.TextBox3)
        Me.TabPage2.Controls.Add(Me.TextBox2)
        Me.TabPage2.Controls.Add(Me.TextBox1)
        Me.TabPage2.Location = New System.Drawing.Point(122, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(800, 318)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Settings"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(112, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 21)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Grab DeviceID"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(594, 290)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 16)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Settings Saved!"
        Me.Label8.Visible = False
        '
        'ChromeButton1
        '
        Me.ChromeButton1.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w=="
        Me.ChromeButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ChromeButton1.Image = Nothing
        Me.ChromeButton1.Location = New System.Drawing.Point(717, 287)
        Me.ChromeButton1.Name = "ChromeButton1"
        Me.ChromeButton1.NoRounding = False
        Me.ChromeButton1.Size = New System.Drawing.Size(75, 23)
        Me.ChromeButton1.TabIndex = 7
        Me.ChromeButton1.Text = "Save"
        Me.ChromeButton1.Transparent = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(237, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Browse"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(234, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(336, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Device Library (Default: /sdcard/media) Note: Do not put a trailing ""/"""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(428, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(193, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Local Media Library (Default: My Music)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(234, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(509, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Device Serial (NOTE: Only Change if you get a new device, this is so aTunes only " & _
    "syncs with your device.)"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(3, 58)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(225, 20)
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.Text = "/sdcard/media"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(3, 32)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(225, 20)
        Me.TextBox2.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(6, 6)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.LightGray
        Me.TabPage3.Controls.Add(Me.ChromeTabcontrol2)
        Me.TabPage3.Location = New System.Drawing.Point(122, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(800, 318)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "About"
        '
        'ChromeTabcontrol2
        '
        Me.ChromeTabcontrol2.Alignment = System.Windows.Forms.TabAlignment.Left
        Me.ChromeTabcontrol2.Controls.Add(Me.TabPage4)
        Me.ChromeTabcontrol2.Controls.Add(Me.TabPage5)
        Me.ChromeTabcontrol2.Controls.Add(Me.TabPage7)
        Me.ChromeTabcontrol2.ItemSize = New System.Drawing.Size(30, 115)
        Me.ChromeTabcontrol2.Location = New System.Drawing.Point(6, 6)
        Me.ChromeTabcontrol2.Multiline = True
        Me.ChromeTabcontrol2.Name = "ChromeTabcontrol2"
        Me.ChromeTabcontrol2.SelectedIndex = 0
        Me.ChromeTabcontrol2.ShowOuterBorders = False
        Me.ChromeTabcontrol2.Size = New System.Drawing.Size(788, 304)
        Me.ChromeTabcontrol2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.ChromeTabcontrol2.SquareColor = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.ChromeTabcontrol2.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.LightGray
        Me.TabPage4.Controls.Add(Me.Label12)
        Me.TabPage4.Controls.Add(Me.Label3)
        Me.TabPage4.Controls.Add(Me.Label2)
        Me.TabPage4.Controls.Add(Me.Label1)
        Me.TabPage4.Location = New System.Drawing.Point(119, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(665, 296)
        Me.TabPage4.TabIndex = 0
        Me.TabPage4.Text = "Creators"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Version:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(552, 144)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Beatsleigher (XDA Forums Member)"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(307, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Mitchell Urgero (URGERO.ORG / XDA Forums Member Sandix)"
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.LightGray
        Me.TabPage5.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.TabPage5.Location = New System.Drawing.Point(119, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(665, 296)
        Me.TabPage5.TabIndex = 1
        Me.TabPage5.Text = "Other Thanks and Credit"
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(279, 130)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(380, 160)
        Me.AxWindowsMediaPlayer1.TabIndex = 0
        Me.AxWindowsMediaPlayer1.Visible = False
        '
        'TabPage7
        '
        Me.TabPage7.BackColor = System.Drawing.Color.LightGray
        Me.TabPage7.Controls.Add(Me.Label11)
        Me.TabPage7.Controls.Add(Me.Label10)
        Me.TabPage7.Location = New System.Drawing.Point(119, 4)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(665, 296)
        Me.TabPage7.TabIndex = 2
        Me.TabPage7.Text = "About your Library"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Size in MB: "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "TNOF"
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.LightGray
        Me.TabPage6.Controls.Add(Me.ListBox2)
        Me.TabPage6.Location = New System.Drawing.Point(122, 4)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(800, 318)
        Me.TabPage6.TabIndex = 3
        Me.TabPage6.Text = "Sync Log"
        '
        'ListBox2
        '
        Me.ListBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(3, 3)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(794, 312)
        Me.ListBox2.TabIndex = 0
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SyncToolStripMenuItem1, Me.ReloadToolStripMenuItem1, Me.ExitToolStripMenuItem1})
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem1.Text = "File"
        '
        'SyncToolStripMenuItem1
        '
        Me.SyncToolStripMenuItem1.Name = "SyncToolStripMenuItem1"
        Me.SyncToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.SyncToolStripMenuItem1.Text = "Sync"
        '
        'ReloadToolStripMenuItem1
        '
        Me.ReloadToolStripMenuItem1.Name = "ReloadToolStripMenuItem1"
        Me.ReloadToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ReloadToolStripMenuItem1.Text = "Reload"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.ClientSize = New System.Drawing.Size(926, 350)
        Me.Controls.Add(Me.ChromeTabcontrol1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(934, 377)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "aTunes"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ChromeTabcontrol1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.ChromeTabcontrol2.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ChromeTabcontrol1 As aTunes.ChromeTabcontrol
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SyncToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ChromeTabcontrol2 As aTunes.ChromeTabcontrol
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents LoadMedia As System.ComponentModel.BackgroundWorker
    Friend WithEvents sync As System.ComponentModel.BackgroundWorker
    Friend WithEvents did As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PlayStoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents statusLabel As System.Windows.Forms.Label
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents Music As System.Windows.Forms.Timer
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ChromeButton1 As aTunes.ChromeButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CheckUpdates As System.ComponentModel.BackgroundWorker
    Friend WithEvents FileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SyncToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReloadToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem

End Class
