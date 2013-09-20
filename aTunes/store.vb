Public Class store

    Private Sub ShowInExternalBrowserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowInExternalBrowserToolStripMenuItem.Click
        Process.Start("https://play.google.com/store/music?hl=en")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Dispose()
    End Sub
End Class