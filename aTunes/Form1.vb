Imports System.IO
Imports RegawMOD.Android

Public Class Form1
    '(C) Mitchell Urgero URGERO.ORG All Rights Reserved
    '    With help from XDA Member Beatsleigher
    '    aTunes is in no way a part of Apple Inc. or any other trademarks of Apple Inc.
    '    Just a small project on my free time.
    '    Code may be used how you like, but this must stay here. (Please? lol.)
    Dim settings As New IniFile(Application.StartupPath + "\settings\settings.ini")
    Dim misc As New IniFile(Application.StartupPath + "\settings\misc.ini")
    Dim MediaFolder As String = settings.GetString("MAIN", "MediaFolder", "NOTHING")
    Dim DeviceID As String = settings.GetString("MAIN", "DeviceID", "NOTHING")
    Dim DeviceMedia As String = settings.GetString("MAIN", "DeviceMedia", "NOTHING")
    Dim verint As Integer = 2
    Dim ver As String = "1.0.1"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label12.Text = "Version: " + ver + vbNewLine + "Build: " + verint.ToString
        If File.Exists("AndroidLib.dll") Then

        Else
            My.Computer.FileSystem.WriteAllBytes("AndroidLib.dll", My.Resources.AndroidLib, False)
        End If
        'Since I am still new, and do not know how to call across different types of threads, I disable to warning when I cross thread call (GUI - Backgroundworker - GUI)
        'Not bad to do in most cases, but I know it is not ideal, or good practice.
        CheckForIllegalCrossThreadCalls = False
        'Startup Detect if first run (Device ID, Serial, Scan for root, set directories, etc)
        If File.Exists(Application.StartupPath + "\settings\settings.ini") Then
        Else
            Directory.CreateDirectory(Application.StartupPath + "\settings")
            Dim sw As New StreamWriter(Application.StartupPath + "\settings\settings.ini")
            sw.Close()
            MsgBox("This is your first time using aTunes! Please set your settings on the left!", MsgBoxStyle.Information, "Hello there!")

            GoTo endLoad
        End If
        TextBox1.Text = DeviceID
        TextBox2.Text = MediaFolder
        TextBox3.Text = DeviceMedia
        'Then scan collection
        LoadMedia.RunWorkerAsync()
        CheckUpdates.RunWorkerAsync()
endLoad:

    End Sub
    Private Function DirectorySize(ByVal dInfo As DirectoryInfo, _
   ByVal includeSubDir As Boolean) As Long
        ' Enumerate all the files
        Dim totalSize As Long = dInfo.EnumerateFiles() _
          .Sum(Function(file) file.Length)

        ' If Subdirectories are to be included
        If includeSubDir Then
            ' Enumerate all sub-directories
            totalSize += dInfo.EnumerateDirectories() _
             .Sum(Function(dir) DirectorySize(dir, True))
        End If
        Return totalSize
    End Function
    Private Sub LoadMedia_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles LoadMedia.DoWork
        Try
            'Loading Library from folder
            ListBox1.Items.Clear()
            MediaFolder = TextBox2.Text
            Dim folderInfo As New IO.DirectoryInfo(MediaFolder)
            Dim arrFilesInFolder() As IO.FileInfo
            Dim fileInFolder As IO.FileInfo
            Dim renamed As String
            'List MP3 files in MediaFolder
            arrFilesInFolder = folderInfo.GetFiles("*.mp3")
            ProgressBar2.Maximum = folderInfo.GetFiles("*.mp3").Count
            Label10.Text = "Total number of files: " + folderInfo.GetFiles("*.mp3").Count.ToString
            Dim dInfo As New DirectoryInfo(MediaFolder)
            Dim sizeOfDir As Long = DirectorySize(dInfo, True)
            Dim FolderSize As Integer = sizeOfDir / (1024 * 1024)
            Label11.Text = "Total Size in MB: " + FolderSize.ToString + "MB"
            For Each fileInFolder In arrFilesInFolder
                'Added to ListBox
                If fileInFolder.Name.Contains(" ") Then
                    'Remove spaces in names if any
                    My.Computer.FileSystem.RenameFile(MediaFolder + "\" + fileInFolder.Name, fileInFolder.Name.Replace(" ", ""))
                Else

                End If

                ListBox1.Items.Add(fileInFolder.Name.Replace(" ", ""))
                'Log to file
                statusLabel.Text = "Scanning file: " + fileInFolder.Name
                ProgressBar2.Value += 1
            Next
            ProgressBar2.Value = 0
            statusLabel.Text = "Finished Scanning!"
        Catch ex As Exception
            MsgBox("Error: " + ex.Message)
        End Try

    End Sub

    Private Sub Music_Tick(sender As Object, e As EventArgs) Handles Music.Tick
        'Grab time left, progress the progressbar
        Dim remain As Int32 = AxWindowsMediaPlayer1.currentMedia.duration - AxWindowsMediaPlayer1.Ctlcontrols.currentPosition

        Dim Minutes, Seconds, ElapsedTime As String

        Minutes = (remain / 60).ToString("00")

        Seconds = (remain Mod 60).ToString("00.00")

        ElapsedTime = Minutes & "." & Seconds
        ProgressBar1.Maximum = AxWindowsMediaPlayer1.currentMedia.duration
        ProgressBar1.Value = AxWindowsMediaPlayer1.Ctlcontrols.currentPosition
        Label9.Text = "Time Left: " + ElapsedTime
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedItem = "" Then
            GoTo endload
        End If
        Music.Stop()

        Music.Interval = 1000
        'If MP3 exsists then play it in the media player.
        AxWindowsMediaPlayer1.URL = MediaFolder + "\" + ListBox1.SelectedItem.ToString
        Label4.Text = AxWindowsMediaPlayer1.currentMedia.getItemInfo("Title")
        Music.Start()
endload:

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        If FolderBrowserDialog1.SelectedPath = "" Then
        Else
            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub ChromeButton1_Click(sender As Object, e As EventArgs) Handles ChromeButton1.Click
        'LoadMedia
        MediaFolder = TextBox2.Text
        DeviceID = TextBox1.Text
        DeviceMedia = TextBox3.Text
        'Save settings to ini file

        settings.WriteString("MAIN", "DeviceID", TextBox1.Text)
        settings.WriteString("MAIN", "MediaFolder", TextBox2.Text)
        settings.WriteString("MAIN", "DeviceMedia", TextBox3.Text)
        Label8.Visible = True
        'Reload main window with new files (If any)
        LoadMedia.RunWorkerAsync()
    End Sub
    'MISC Controls for the built in media player.
    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        AxWindowsMediaPlayer1.Ctlcontrols.pause()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        AxWindowsMediaPlayer1.Ctlcontrols.play()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        AxWindowsMediaPlayer1.Ctlcontrols.fastForward()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        AxWindowsMediaPlayer1.Ctlcontrols.fastReverse()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Try
            Dim selected As Integer = ListBox1.SelectedIndex
            ListBox1.SelectedIndex += 1
        Catch ex As Exception
            ListBox1.SelectedIndex = 0
        End Try

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Try
            Dim selected As Integer = ListBox1.SelectedIndex
            ListBox1.SelectedIndex -= 1
        Catch ex As Exception
            ListBox1.SelectedIndex = ListBox1.Items.Count - 1
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Connect to device
        Dim android As AndroidController
        Dim device As Device
        Dim serial As String
        Try
            android = AndroidController.Instance
            android.UpdateDeviceList()
            If android.HasConnectedDevices Then
                'If true then grab the DeviceID needed for sync.
                serial = android.ConnectedDevices(0)
                device = android.GetConnectedDevice(serial)
                'Then Save it.
                TextBox1.Text = serial
            Else
                MsgBox("There was no device found! Make sure it is plugged in and drivers are installed!", MsgBoxStyle.Information, "Oops!")

            End If
            android.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub sync_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles sync.DoWork
        'Attach to AndroidLib.dll to get android device
        Dim android As AndroidController
        Dim device As Device
        Dim serial As String
        SyncToolStripMenuItem1.Text = "Sync Started"
        SyncToolStripMenuItem1.Enabled = False

        ListBox2.Items.Add("Time: " + DateTime.Now)
        ListBox2.Items.Add("Starting sync...")
        ListBox2.Items.Add("Checking for the right DeviceID...")
        statusLabel.Text = "Starting sync please wait..."
        Try
            'Connect and get serial number and DeviceID
            android = AndroidController.Instance
            android.UpdateDeviceList()
            If android.HasConnectedDevices Then
                serial = android.ConnectedDevices(0)
                device = android.GetConnectedDevice(serial)
                ListBox2.Items.Add("Device " + serial + " found!")
                statusLabel.Text = "Device: " + serial + " found!"
                If serial = TextBox1.Text Then
                    GoTo beginMediaSync
                Else
                    ListBox2.Items.Add("Error: Device is not the same as settings! ")
                    ListBox2.Items.Add("Device found: " + serial)
                    ListBox2.Items.Add("Device needed: " + TextBox1.Text)
                End If
                'List 3rd Part installed applications
                'Not implimenting until Sync Client is in order first! leave this part alone!
                GoTo beginMediaSync
                Dim adbcmd As AdbCommand = Adb.FormAdbShellCommand(device, True, "pm", "list packages -3")
                'Checking for org.urgero.syncclient (aTunes Mobile Sync Client App)
                Dim syncClient = Adb.ExecuteAdbCommand(adbcmd)
                If syncClient.Contains("org.urgero.syncclient") Then
                    'If true then start the application remotely
                    Dim adbcmd3 As AdbCommand = Adb.FormAdbShellCommand(device, True, "am", "start org.urgero.syncclient./syncUp")
                    Dim startsyncclient = Adb.ExecuteAdbCommand(adbcmd3)
                    ListBox2.Items.Add("Sync Client Startup: " + startsyncclient.ToString)
                Else
                    'If false goto line startsync
                    GoTo startsync

                End If
beginMediaSync:

                ListBox2.Items.Add("Preparing Media Folder for sync.....")
                statusLabel.Text = "Preparing Media Folder for Sync..."
                TextBox1.Text = serial
                MediaFolder = TextBox2.Text
                'Begin listing all files (*.mp3) in the MediaFolder Dir
                Dim folderInfo As New IO.DirectoryInfo(MediaFolder)
                Dim arrFilesInFolder() As IO.FileInfo
                Dim fileInFolder As IO.FileInfo
                'Find MP3's
                arrFilesInFolder = folderInfo.GetFiles("*.mp3")
                Dim totalFiles As Integer = folderInfo.GetFiles("*.mp3").Count
                ProgressBar2.Maximum = folderInfo.GetFiles("*.mp3").Count
                ListBox2.Items.Add("NOTE: Removing spaces from file names!")
                statusLabel.Text = "Removing any spaces found..."
                Dim sw As New StreamWriter("sync_log.txt")
                sw.WriteLine("Time: " + DateTime.Now)
                'Remove spaces (For compatibility with android push command)
                For Each fileInFolder In arrFilesInFolder
                    'Added to ListBox
                    If fileInFolder.Name.Contains(" ") Then
                        My.Computer.FileSystem.RenameFile(MediaFolder + "\" + fileInFolder.Name, fileInFolder.Name.Replace(" ", ""))
                    Else

                    End If
                    'then send after removing spaces.
                    statusLabel.Text = "Sync: " + fileInFolder.Name + "..."
                    Dim arg As String = "push"
                    Dim adbcmd1 As AdbCommand = Adb.FormAdbCommand(device, "push", MediaFolder + "\" + fileInFolder.Name + " " + DeviceMedia + "/" + fileInFolder.Name.Replace(" ", ""))
                    Dim test = Adb.ExecuteAdbCommand(adbcmd1)
                    ListBox2.Items.Add("File: " + fileInFolder.Name + "::::::Status= " + test)
                    'Write to a log file AND a listbox of a running log
                    sw.WriteLine("Sync file: " + fileInFolder.Name + ":::::" + test)
                    'statusLabel.Text = "Sync file: " + fileInFolder.Name
                    ProgressBar2.Value += 1
                Next
                sw.Close()

                ProgressBar2.Value = 0
                statusLabel.Text = "Finished Sync!"
                ListBox2.Items.Add("Finished Sync!")
                ListBox2.Items.Add("Total Number of Files: " + totalFiles.ToString)
            Else
                MsgBox("There was no device found! Make sure it is plugged in and drivers are installed!", MsgBoxStyle.Information, "Oops!")
                ListBox2.Items.Add("Error scanning for device: Device not found!")
            End If
            android.Dispose()
            GoTo endline
startsync:
            'Ask user if they want to install the Sync Client
            If MsgBox("It seems you need to install the aTunes Mobile Sync Client still. Sync will still work, but installing the sync client allows better stablizaiton of the file transfers." + vbNewLine + "Would you like to install aTunes Mobile Sync Client?", MsgBoxStyle.YesNo, "Sync Client not found.") = MsgBoxResult.Yes Then
                'If true, then install
                Dim ascInstall = device.InstallApk("asc.apk")
                MsgBox("Install " + ascInstall, MsgBoxStyle.Information, "Installation")
                If MsgBox("You must reboot the device to finish the installation." + vbNewLine + "Would you like to reboot the device now?", MsgBoxStyle.YesNo, "Reboot Device?") = MsgBoxResult.Yes Then
                    'reboot
                    Shell("adb reboot")
                Else
                    'Or Not and quit sync
                    GoTo endline
                End If
            Else
                'If app was or was not installed, if user decided to sync anyway (Possible) then go back  to top and sync
                GoTo beginMediaSync
            End If
        Catch ex As Exception
            'State Error
            statusLabel.Text = "Error: " + ex.Message
            ListBox2.Items.Add("Error: " + ex.Message)
        End Try

endline:
        SyncToolStripMenuItem1.Text = "Sync"
        SyncToolStripMenuItem1.Enabled = Enabled
    End Sub
    Private Sub LoadSyncClient()


    End Sub
    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click
    End Sub

    Private Sub CheckUpdates_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles CheckUpdates.DoWork
        Try
            statusLabel.Text = "Checking For Updates..."
            Dim wc As New System.Net.WebClient()
            Dim address As String = "http://urgero.org/atunes/aversion.txt"
            Dim verDown = wc.DownloadString(address)
            If verDown > verint Then

                If MsgBox("An update has been found!" + vbNewLine + "Build Number Now: " + verint + vbNewLine + "Build Number From Update: " + verDown + vbNewLine + "Would you like to update?", MsgBoxStyle.YesNo, "Update Available!") = MsgBoxResult.Yes Then
                    Try

                        Process.Start("update.exe")
                        End
                    Catch ex1 As Exception

                        MsgBox("Cannot start updater application!")

                    End Try
                End If
            End If
        Catch ex As Exception

            'MsgBox("Cannot reach the update server, please try updating later!", MsgBoxStyle.Information, "Oops!")
        End Try
        statusLabel.Text = "Finished Scanning!"
    End Sub

    Private Sub SyncToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SyncToolStripMenuItem1.Click
        sync.RunWorkerAsync()
    End Sub

    Private Sub ReloadToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReloadToolStripMenuItem1.Click
        LoadMedia.RunWorkerAsync()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        End
    End Sub
End Class
