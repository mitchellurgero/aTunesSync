Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Runtime.InteropServices
'.::Metro Theme Collection v1.0::.
'Author:   UnReLaTeDScript
'Credits:  Aeonhack [Themebase]
'Version:  1.0
MustInherit Class Theme
    Inherits ContainerControl

#Region " Initialization "

    Protected G As Graphics
    Sub New()
        SetStyle(DirectCast(139270, ControlStyles), True)
    End Sub

    Private ParentIsForm As Boolean
    Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        Dock = DockStyle.Fill
        ParentIsForm = TypeOf Parent Is Form
        If ParentIsForm Then
            If Not _TransparencyKey = Color.Empty Then ParentForm.TransparencyKey = _TransparencyKey
            ParentForm.FormBorderStyle = FormBorderStyle.None
        End If
        MyBase.OnHandleCreated(e)
    End Sub

    Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal v As String)
            MyBase.Text = v
            Invalidate()
        End Set
    End Property
#End Region

#Region " Sizing and Movement "

    Private _Resizable As Boolean = True
    Property Resizable() As Boolean
        Get
            Return _Resizable
        End Get
        Set(ByVal value As Boolean)
            _Resizable = value
        End Set
    End Property

    Private _MoveHeight As Integer = 24
    Property MoveHeight() As Integer
        Get
            Return _MoveHeight
        End Get
        Set(ByVal v As Integer)
            _MoveHeight = v
            Header = New Rectangle(7, 7, Width - 14, _MoveHeight - 7)
        End Set
    End Property

    Private Flag As IntPtr
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If Not e.Button = MouseButtons.Left Then Return
        If ParentIsForm Then If ParentForm.WindowState = FormWindowState.Maximized Then Return

        If Header.Contains(e.Location) Then
            Flag = New IntPtr(2)
        ElseIf Current.Position = 0 Or Not _Resizable Then
            Return
        Else
            Flag = New IntPtr(Current.Position)
        End If

        Capture = False
        DefWndProc(Message.Create(Parent.Handle, 161, Flag, Nothing))

        MyBase.OnMouseDown(e)
    End Sub

    Private Structure Pointer
        ReadOnly Cursor As Cursor, Position As Byte
        Sub New(ByVal c As Cursor, ByVal p As Byte)
            Cursor = c
            Position = p
        End Sub
    End Structure

    Private F1, F2, F3, F4 As Boolean, PTC As Point
    Private Function GetPointer() As Pointer
        PTC = PointToClient(MousePosition)
        F1 = PTC.X < 7
        F2 = PTC.X > Width - 7
        F3 = PTC.Y < 7
        F4 = PTC.Y > Height - 7

        If F1 And F3 Then Return New Pointer(Cursors.SizeNWSE, 13)
        If F1 And F4 Then Return New Pointer(Cursors.SizeNESW, 16)
        If F2 And F3 Then Return New Pointer(Cursors.SizeNESW, 14)
        If F2 And F4 Then Return New Pointer(Cursors.SizeNWSE, 17)
        If F1 Then Return New Pointer(Cursors.SizeWE, 10)
        If F2 Then Return New Pointer(Cursors.SizeWE, 11)
        If F3 Then Return New Pointer(Cursors.SizeNS, 12)
        If F4 Then Return New Pointer(Cursors.SizeNS, 15)
        Return New Pointer(Cursors.Default, 0)
    End Function

    Private Current, Pending As Pointer
    Private Sub SetCurrent()
        Pending = GetPointer()
        If Current.Position = Pending.Position Then Return
        Current = GetPointer()
        Cursor = Current.Cursor
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If _Resizable Then SetCurrent()
        MyBase.OnMouseMove(e)
    End Sub

    Protected Header As Rectangle
    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If Width = 0 OrElse Height = 0 Then Return
        Header = New Rectangle(7, 7, Width - 14, _MoveHeight - 7)
        Invalidate()
        MyBase.OnSizeChanged(e)
    End Sub

#End Region

#Region " Convienence "

    MustOverride Sub PaintHook()
    Protected NotOverridable Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Width = 0 OrElse Height = 0 Then Return
        G = e.Graphics
        PaintHook()
    End Sub

    Private _TransparencyKey As Color
    Property TransparencyKey() As Color
        Get
            Return _TransparencyKey
        End Get
        Set(ByVal v As Color)
            _TransparencyKey = v
            Invalidate()
        End Set
    End Property

    Private _Image As Image
    Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal value As Image)
            _Image = value
            Invalidate()
        End Set
    End Property
    ReadOnly Property ImageWidth() As Integer
        Get
            If _Image Is Nothing Then Return 0
            Return _Image.Width
        End Get
    End Property

    Private _Size As Size
    Private _Rectangle As Rectangle
    Private _Gradient As LinearGradientBrush
    Private _Brush As SolidBrush

    Protected Sub DrawCorners(ByVal c As Color, ByVal rect As Rectangle)
        _Brush = New SolidBrush(c)
        G.FillRectangle(_Brush, rect.X, rect.Y, 1, 1)
        G.FillRectangle(_Brush, rect.X + (rect.Width - 1), rect.Y, 1, 1)
        G.FillRectangle(_Brush, rect.X, rect.Y + (rect.Height - 1), 1, 1)
        G.FillRectangle(_Brush, rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), 1, 1)
    End Sub

    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal p2 As Pen, ByVal rect As Rectangle)
        G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1)
        G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3)
    End Sub

    Protected Sub DrawText(ByVal a As HorizontalAlignment, ByVal c As Color, ByVal x As Integer)
        DrawText(a, c, x, 0)
    End Sub
    Protected Sub DrawText(ByVal a As HorizontalAlignment, ByVal c As Color, ByVal x As Integer, ByVal y As Integer)
        If String.IsNullOrEmpty(Text) Then Return
        _Size = G.MeasureString(Text, Font).ToSize
        _Brush = New SolidBrush(c)

        Select Case a
            Case HorizontalAlignment.Left
                G.DrawString(Text, Font, _Brush, x, _MoveHeight \ 2 - _Size.Height \ 2 + y)
            Case HorizontalAlignment.Right
                G.DrawString(Text, Font, _Brush, Width - _Size.Width - x, _MoveHeight \ 2 - _Size.Height \ 2 + y)
            Case HorizontalAlignment.Center
                G.DrawString(Text, Font, _Brush, Width \ 2 - _Size.Width \ 2 + x, _MoveHeight \ 2 - _Size.Height \ 2 + y)
        End Select
    End Sub

    Protected Sub DrawIcon(ByVal a As HorizontalAlignment, ByVal x As Integer)
        DrawIcon(a, x, 0)
    End Sub
    Protected Sub DrawIcon(ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        If _Image Is Nothing Then Return
        Select Case a
            Case HorizontalAlignment.Left
                G.DrawImage(_Image, x, _MoveHeight \ 2 - _Image.Height \ 2 + y)
            Case HorizontalAlignment.Right
                G.DrawImage(_Image, Width - _Image.Width - x, _MoveHeight \ 2 - _Image.Height \ 2 + y)
            Case HorizontalAlignment.Center
                G.DrawImage(_Image, Width \ 2 - _Image.Width \ 2, _MoveHeight \ 2 - _Image.Height \ 2)
        End Select
    End Sub

    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        _Rectangle = New Rectangle(x, y, width, height)
        _Gradient = New LinearGradientBrush(_Rectangle, c1, c2, angle)
        G.FillRectangle(_Gradient, _Rectangle)
    End Sub

#End Region

End Class
Module Draw
    Public Function RoundRect(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
    'Public Function RoundRect(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Curve As Integer) As GraphicsPath
    '    Dim Rectangle As Rectangle = New Rectangle(X, Y, Width, Height)
    '    Dim P As GraphicsPath = New GraphicsPath()
    '    Dim ArcRectangleWidth As Integer = Curve * 2
    '    P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
    '    P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
    '    P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
    '    P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
    '    P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
    '    Return P
    'End Function
End Module
MustInherit Class ThemeControl
    Inherits Control

#Region " Initialization "

    Protected G As Graphics, B As Bitmap
    Sub New()
        SetStyle(DirectCast(139270, ControlStyles), True)
        B = New Bitmap(1, 1)
        G = Graphics.FromImage(B)
    End Sub

    Sub AllowTransparent()
        SetStyle(ControlStyles.Opaque, False)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal v As String)
            MyBase.Text = v
            Invalidate()
        End Set
    End Property
#End Region

#Region " Mouse Handling "

    Protected Enum State As Byte
        MouseNone = 0
        MouseOver = 1
        MouseDown = 2
    End Enum

    Protected MouseState As State
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        ChangeMouseState(State.MouseNone)
        MyBase.OnMouseLeave(e)
    End Sub
    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        ChangeMouseState(State.MouseOver)
        MyBase.OnMouseEnter(e)
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        ChangeMouseState(State.MouseOver)
        MyBase.OnMouseUp(e)
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then ChangeMouseState(State.MouseDown)
        MyBase.OnMouseDown(e)
    End Sub

    Private Sub ChangeMouseState(ByVal e As State)
        MouseState = e
        Invalidate()
    End Sub

#End Region

#Region " Convienence "

    MustOverride Sub PaintHook()
    Protected NotOverridable Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Width = 0 OrElse Height = 0 Then Return
        PaintHook()
        e.Graphics.DrawImage(B, 0, 0)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If Not Width = 0 AndAlso Not Height = 0 Then
            B = New Bitmap(Width, Height)
            G = Graphics.FromImage(B)
            Invalidate()
        End If
        MyBase.OnSizeChanged(e)
    End Sub

    Private _NoRounding As Boolean
    Property NoRounding() As Boolean
        Get
            Return _NoRounding
        End Get
        Set(ByVal v As Boolean)
            _NoRounding = v
            Invalidate()
        End Set
    End Property

    Private _Image As Image
    Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal value As Image)
            _Image = value
            Invalidate()
        End Set
    End Property
    ReadOnly Property ImageWidth() As Integer
        Get
            If _Image Is Nothing Then Return 0
            Return _Image.Width
        End Get
    End Property
    ReadOnly Property ImageTop() As Integer
        Get
            If _Image Is Nothing Then Return 0
            Return Height \ 2 - _Image.Height \ 2
        End Get
    End Property

    Private _Size As Size
    Private _Rectangle As Rectangle
    Private _Gradient As LinearGradientBrush
    Private _Brush As SolidBrush

    Protected Sub DrawCorners(ByVal c As Color, ByVal rect As Rectangle)
        If _NoRounding Then Return

        B.SetPixel(rect.X, rect.Y, c)
        B.SetPixel(rect.X + (rect.Width - 1), rect.Y, c)
        B.SetPixel(rect.X, rect.Y + (rect.Height - 1), c)
        B.SetPixel(rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), c)
    End Sub

    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal p2 As Pen, ByVal rect As Rectangle)
        G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1)
        G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3)
    End Sub

    Protected Sub DrawText(ByVal a As HorizontalAlignment, ByVal c As Color, ByVal x As Integer)
        DrawText(a, c, x, 0)
    End Sub
    Protected Sub DrawText(ByVal a As HorizontalAlignment, ByVal c As Color, ByVal x As Integer, ByVal y As Integer)
        If String.IsNullOrEmpty(Text) Then Return
        _Size = G.MeasureString(Text, Font).ToSize
        _Brush = New SolidBrush(c)

        Select Case a
            Case HorizontalAlignment.Left
                G.DrawString(Text, Font, _Brush, x, Height \ 2 - _Size.Height \ 2 + y)
            Case HorizontalAlignment.Right
                G.DrawString(Text, Font, _Brush, Width - _Size.Width - x, Height \ 2 - _Size.Height \ 2 + y)
            Case HorizontalAlignment.Center
                G.DrawString(Text, Font, _Brush, Width \ 2 - _Size.Width \ 2 + x, Height \ 2 - _Size.Height \ 2 + y)
        End Select
    End Sub

    Protected Sub DrawIcon(ByVal a As HorizontalAlignment, ByVal x As Integer)
        DrawIcon(a, x, 0)
    End Sub
    Protected Sub DrawIcon(ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        If _Image Is Nothing Then Return
        Select Case a
            Case HorizontalAlignment.Left
                G.DrawImage(_Image, x, Height \ 2 - _Image.Height \ 2 + y)
            Case HorizontalAlignment.Right
                G.DrawImage(_Image, Width - _Image.Width - x, Height \ 2 - _Image.Height \ 2 + y)
            Case HorizontalAlignment.Center
                G.DrawImage(_Image, Width \ 2 - _Image.Width \ 2, Height \ 2 - _Image.Height \ 2)
        End Select
    End Sub

    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        _Rectangle = New Rectangle(x, y, width, height)
        _Gradient = New LinearGradientBrush(_Rectangle, c1, c2, angle)
        G.FillRectangle(_Gradient, _Rectangle)
    End Sub
#End Region

End Class
MustInherit Class ThemeContainerControl
    Inherits ContainerControl

#Region " Initialization "

    Protected G As Graphics, B As Bitmap
    Sub New()
        SetStyle(DirectCast(139270, ControlStyles), True)
        B = New Bitmap(1, 1)
        G = Graphics.FromImage(B)
    End Sub

    Sub AllowTransparent()
        SetStyle(ControlStyles.Opaque, False)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

#End Region
#Region " Convienence "

    MustOverride Sub PaintHook()
    Protected NotOverridable Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Width = 0 OrElse Height = 0 Then Return
        PaintHook()
        e.Graphics.DrawImage(B, 0, 0)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If Not Width = 0 AndAlso Not Height = 0 Then
            B = New Bitmap(Width, Height)
            G = Graphics.FromImage(B)
            Invalidate()
        End If
        MyBase.OnSizeChanged(e)
    End Sub

    Private _NoRounding As Boolean
    Property NoRounding() As Boolean
        Get
            Return _NoRounding
        End Get
        Set(ByVal v As Boolean)
            _NoRounding = v
            Invalidate()
        End Set
    End Property

    Private _Rectangle As Rectangle
    Private _Gradient As LinearGradientBrush

    Protected Sub DrawCorners(ByVal c As Color, ByVal rect As Rectangle)
        If _NoRounding Then Return
        B.SetPixel(rect.X, rect.Y, c)
        B.SetPixel(rect.X + (rect.Width - 1), rect.Y, c)
        B.SetPixel(rect.X, rect.Y + (rect.Height - 1), c)
        B.SetPixel(rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), c)
    End Sub

    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal p2 As Pen, ByVal rect As Rectangle)
        G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1)
        G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3)
    End Sub

    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        _Rectangle = New Rectangle(x, y, width, height)
        _Gradient = New LinearGradientBrush(_Rectangle, c1, c2, angle)
        G.FillRectangle(_Gradient, _Rectangle)
    End Sub
#End Region

End Class


Class FlatTheme
    Inherits Theme
    Private _Checked As Boolean
    Sub New()

    End Sub
    Overrides Sub PaintHook()
        Dim f As New Font("Segoe UI Light", 20)
        G.FillRectangle(New SolidBrush(Me.BackColor), ClientRectangle)
        G.DrawRectangle(New Pen(Me.ForeColor), New Rectangle(0, 0, Width - 1, Height - 1))
        G.DrawString(Me.Text, f, New SolidBrush(Me.ForeColor), New Point(20, 20))
    End Sub
End Class
Class FlatThemeOther
    Inherits Theme
    Private _Checked As Boolean
    Sub New()

    End Sub
    Overrides Sub PaintHook()
        Dim f As New Font("Segoe UI Light", 20)
        G.FillRectangle(New SolidBrush(Me.BackColor), ClientRectangle)
        G.DrawRectangle(New Pen(Me.ForeColor), New Rectangle(0, 0, Width - 1, Height - 1))
        G.DrawString(Me.Text, f, New SolidBrush(Me.ForeColor), New Point(20, 20))
        G.FillRectangle(New SolidBrush(Me.ForeColor), 0, 30, 15, 31)
    End Sub
End Class
Class FlatButton
    Inherits ThemeControl

    Sub New()
        Me.Font = New Font("Segoe UI Light", 9)
    End Sub



    Overrides Sub PaintHook()
        Dim lsize As New Size
        lsize = G.MeasureString(Text, Font).ToSize()
        G.SmoothingMode = SmoothingMode.HighQuality
        Select Case MouseState
            Case State.MouseNone
                G.FillRectangle(New SolidBrush(Me.BackColor), ClientRectangle)
                G.DrawString(Text, Font, New SolidBrush(Me.ForeColor), Width \ 2 - lsize.Width \ 2, Height \ 2 - lsize.Height \ 2)
            Case State.MouseOver
                G.FillRectangle(New SolidBrush(Me.BackColor), ClientRectangle)
                G.DrawString(Text, Font, New SolidBrush(Me.ForeColor), Width \ 2 - lsize.Width \ 2, Height \ 2 - lsize.Height \ 2)
                G.FillRectangle(New SolidBrush(Color.FromArgb(40, Color.White)), ClientRectangle)
                G.FillRectangle(New SolidBrush(Color.FromArgb(20, Me.ForeColor)), ClientRectangle)
            Case State.MouseDown
                G.FillRectangle(New SolidBrush(Me.BackColor), ClientRectangle)
                G.DrawString(Text, Font, New SolidBrush(Me.ForeColor), Width \ 2 - lsize.Width \ 2, Height \ 2 - lsize.Height \ 2)
                G.FillRectangle(New SolidBrush(Color.FromArgb(30, Color.Black)), ClientRectangle)
                G.FillRectangle(New SolidBrush(Color.FromArgb(10, Me.ForeColor)), ClientRectangle)
        End Select
        G.DrawRectangle(New Pen(Me.ForeColor), New Rectangle(0, 0, Width - 1, Height - 1))
        Me.Cursor = Cursors.Hand
    End Sub
End Class
Class FlatBtnInverse
    Inherits ThemeControl
    Sub New()
        Me.Font = New Font("Segoe UI Light", 9)
    End Sub
    Overrides Sub PaintHook()

        Dim lsize As New Size
        lsize = G.MeasureString(Text, Font).ToSize()
        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Me.ForeColor)
        Select Case MouseState
            Case State.MouseNone
                G.FillRectangle(New SolidBrush(Me.ForeColor), New Rectangle(0, 0, Width, Height))
                G.DrawString(Text, Font, New SolidBrush(Me.BackColor), Width \ 2 - lsize.Width \ 2, Height \ 2 - lsize.Height \ 2)
            Case State.MouseOver
                G.FillRectangle(New SolidBrush(Me.ForeColor), ClientRectangle)
                G.DrawString(Text, Font, New SolidBrush(Me.BackColor), Width \ 2 - lsize.Width \ 2, Height \ 2 - lsize.Height \ 2)
                G.FillRectangle(New SolidBrush(Color.FromArgb(40, Color.White)), ClientRectangle)
            Case State.MouseDown
                G.FillRectangle(New SolidBrush(Me.ForeColor), ClientRectangle)
                G.DrawString(Text, Font, New SolidBrush(Me.BackColor), Width \ 2 - lsize.Width \ 2, Height \ 2 - lsize.Height \ 2)
                G.FillRectangle(New SolidBrush(Color.FromArgb(20, Color.Black)), ClientRectangle)
        End Select
        Me.Cursor = Cursors.Hand
    End Sub
End Class

Class GradTheme
    Inherits Theme
    Private _Checked As Boolean
    Sub New()

    End Sub
    Overrides Sub PaintHook()
        Dim f As New Font("Segoe UI Light", 20)
        G.FillRectangle(New SolidBrush(Me.BackColor), ClientRectangle)
        G.DrawRectangle(New Pen(Color.FromArgb(70, Color.White)), New Rectangle(0, 0, Width - 1, Height - 1))
        G.DrawString(Me.Text, f, New SolidBrush(Color.FromArgb(70, Color.White)), New Point(20, 20))
        G.FillRectangle(New SolidBrush(Color.FromArgb(70, Color.White)), 0, 30, 15, 31)
    End Sub
End Class
Class GradButton
    Inherits ThemeControl
    Sub New()
        Me.Font = New Font("Segoe UI Light", 9)
    End Sub
    Overrides Sub PaintHook()
        Dim lsize As New Size
        lsize = G.MeasureString(Text, Font).ToSize()
        G.DrawRectangle(New Pen(Me.BackColor), New Rectangle(0, 0, Width, Height))

        G.SmoothingMode = SmoothingMode.HighQuality
        Select Case MouseState
            Case State.MouseNone
                G.FillRectangle(New SolidBrush(Me.BackColor), New Rectangle(0, 0, Width, Height))
                DrawGradient(Color.FromArgb(40, Color.White), Color.Transparent, 0, 0, Width, Height, 45S)
                G.DrawString(Text, Font, New SolidBrush(Me.ForeColor), Width \ 2 - lsize.Width \ 2, Height \ 2 - lsize.Height \ 2)

            Case State.MouseOver
                G.FillRectangle(New SolidBrush(Me.BackColor), ClientRectangle)
                G.DrawString(Text, Font, New SolidBrush(Me.ForeColor), Width \ 2 - lsize.Width \ 2, Height \ 2 - lsize.Height \ 2)
                G.FillRectangle(New SolidBrush(Color.FromArgb(40, Color.White)), ClientRectangle)
                G.FillRectangle(New SolidBrush(Color.FromArgb(20, Me.ForeColor)), ClientRectangle)
            Case State.MouseDown
                G.FillRectangle(New SolidBrush(Me.BackColor), ClientRectangle)
                G.DrawString(Text, Font, New SolidBrush(Me.ForeColor), Width \ 2 - lsize.Width \ 2, Height \ 2 - lsize.Height \ 2)
                G.FillRectangle(New SolidBrush(Color.FromArgb(30, Color.Black)), ClientRectangle)
                G.FillRectangle(New SolidBrush(Color.FromArgb(10, Me.ForeColor)), ClientRectangle)
        End Select
        Me.Cursor = Cursors.Hand
    End Sub
End Class

Class ListBoxFlat
    Inherits ThemeControl
    Public WithEvents LBox As New ListBox
    Private __Items As String() = {""}
    Public Property Items As String()
        Get
            Return __Items
            Invalidate()
        End Get
        Set(ByVal value As String())
            __Items = value
            LBox.Items.Clear()
            Invalidate()
            LBox.Items.AddRange(value)
            Invalidate()
        End Set
    End Property

    Public ReadOnly Property SelectedItem() As String
        Get
            Return LBox.SelectedItem
        End Get
    End Property

    Sub New()
        Controls.Add(LBox)
        Size = New Size(131, 101)
        Me.Font = New Font("Segoe UI Light", 7.8)
        LBox.BackColor = Me.BackColor
        LBox.BorderStyle = BorderStyle.None
        LBox.DrawMode = Windows.Forms.DrawMode.OwnerDrawVariable
        LBox.Location = New Point(1, 1)
        LBox.ForeColor = Me.ForeColor
        LBox.ItemHeight = 20
        LBox.Items.Clear()
        LBox.IntegralHeight = False
        Invalidate()
    End Sub


    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        LBox.Width = Width - 3
        LBox.Height = Height - 33
    End Sub

    Overrides Sub PaintHook()
        LBox.BackColor = Me.BackColor
        G.Clear(Me.BackColor)
        G.DrawRectangle(New Pen(New SolidBrush(Me.ForeColor)), 0, 0, Width - 2, Height - 2)
        LBox.Size = New Size(Width - 3, Height - 3)
    End Sub
    Sub DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles LBox.DrawItem
        If e.Index < 0 Then Exit Sub
        e.DrawBackground()
        e.DrawFocusRectangle()
        If InStr(e.State.ToString, "Selected,") > 0 Then
            e.Graphics.FillRectangle(New SolidBrush(Me.BackColor), e.Bounds)
            Dim x2 As Rectangle = New Rectangle(e.Bounds.Location, New Size(e.Bounds.Width, e.Bounds.Height))
            Dim g1 As New SolidBrush(Me.ForeColor)
            e.Graphics.FillRectangle(g1, x2)


            e.Graphics.DrawString(" " & LBox.Items(e.Index).ToString(), Font, New SolidBrush(Me.BackColor), e.Bounds.X, e.Bounds.Y + 2)
        Else
            e.Graphics.DrawString(" " & LBox.Items(e.Index).ToString(), Font, New SolidBrush(Me.ForeColor), e.Bounds.X, e.Bounds.Y + 2)
        End If
    End Sub
    Sub AddRange(ByVal Items As Object())
        LBox.Items.Remove("")
        LBox.Items.AddRange(Items)

    End Sub
    Sub AddItem(ByVal Item As Object)
        LBox.Items.Remove("")
        LBox.Items.Add(Item)

    End Sub
End Class
Class ListBoxFlatInverse
    Inherits ThemeControl
    Public WithEvents LBox As New ListBox
    Private __Items As String() = {""}
    Public Property Items As String()
        Get
            Return __Items
            Invalidate()
        End Get
        Set(ByVal value As String())
            __Items = value
            LBox.Items.Clear()
            Invalidate()
            LBox.Items.AddRange(value)
            Invalidate()
        End Set
    End Property

    Public ReadOnly Property SelectedItem() As String
        Get
            Return LBox.SelectedItem
        End Get
    End Property

    Sub New()
        Controls.Add(LBox)
        Size = New Size(131, 101)
        Me.Font = New Font("Segoe UI Light", 7.8)
        LBox.BackColor = Me.BackColor
        LBox.BorderStyle = BorderStyle.None
        LBox.DrawMode = Windows.Forms.DrawMode.OwnerDrawVariable
        LBox.Location = New Point(2, 2)
        LBox.ForeColor = Me.ForeColor
        LBox.ItemHeight = 20
        LBox.Items.Clear()
        LBox.IntegralHeight = False
        Invalidate()
    End Sub


    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        LBox.Width = Width - 5
        LBox.Height = Height - 5
    End Sub

    Overrides Sub PaintHook()
        LBox.BackColor = Me.ForeColor
        G.Clear(Me.ForeColor)
        G.DrawRectangle(New Pen(New SolidBrush(Me.BackColor)), 1, 1, Width - 3, Height - 3)
        LBox.Size = New Size(Width - 4, Height - 4)
    End Sub
    Sub DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles LBox.DrawItem
        If e.Index < 0 Then Exit Sub
        e.DrawBackground()
        e.DrawFocusRectangle()
        If InStr(e.State.ToString, "Selected,") > 0 Then
            e.Graphics.FillRectangle(New SolidBrush(Me.ForeColor), e.Bounds)
            Dim x2 As Rectangle = New Rectangle(e.Bounds.Location, New Size(e.Bounds.Width, e.Bounds.Height))
            Dim g1 As New SolidBrush(Me.BackColor)
            e.Graphics.FillRectangle(g1, x2)


            e.Graphics.DrawString(" " & LBox.Items(e.Index).ToString(), Font, New SolidBrush(Me.ForeColor), e.Bounds.X, e.Bounds.Y + 2)
        Else
            e.Graphics.DrawString(" " & LBox.Items(e.Index).ToString(), Font, New SolidBrush(Me.BackColor), e.Bounds.X, e.Bounds.Y + 2)
        End If
    End Sub
    Sub AddRange(ByVal Items As Object())
        LBox.Items.Remove("")
        LBox.Items.AddRange(Items)

    End Sub
    Sub AddItem(ByVal Item As Object)
        LBox.Items.Remove("")
        LBox.Items.Add(Item)

    End Sub
End Class
Class ListBoxTitled
    Inherits ThemeControl
    Public WithEvents LBox As New ListBox
    Private __Items As String() = {""}
    Public Property Items As String()
        Get
            Return __Items
            Invalidate()
        End Get
        Set(ByVal value As String())
            __Items = value
            LBox.Items.Clear()
            Invalidate()
            LBox.Items.AddRange(value)
            Invalidate()
        End Set
    End Property

    Public ReadOnly Property SelectedItem() As String
        Get
            Return LBox.SelectedItem
        End Get
    End Property

    Sub New()
        Controls.Add(LBox)
        Size = New Size(131, 101)

        LBox.BackColor = Me.BackColor
        LBox.BorderStyle = BorderStyle.None
        LBox.DrawMode = Windows.Forms.DrawMode.OwnerDrawVariable
        LBox.Location = New Point(1, 1)
        LBox.ForeColor = Me.ForeColor
        LBox.ItemHeight = 48
        LBox.Items.Clear()
        LBox.IntegralHeight = False
        Invalidate()
    End Sub


    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        LBox.Width = Width - 3
        LBox.Height = Height - 33
    End Sub

    Overrides Sub PaintHook()
        LBox.BackColor = Me.BackColor
        G.Clear(Me.BackColor)
        G.DrawRectangle(New Pen(New SolidBrush(Me.ForeColor)), 0, 0, Width - 2, Height - 2)
        LBox.Size = New Size(Width - 3, Height - 3)
    End Sub
    Sub DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles LBox.DrawItem
        Dim b As New Font("Segoe UI Light", 13)
        Dim l As New Font("Segoe UI Light", 9)
        If e.Index < 0 Then Exit Sub
        e.DrawBackground()
        e.DrawFocusRectangle()
        Try
        If InStr(e.State.ToString, "Selected,") > 0 Then
            e.Graphics.FillRectangle(New SolidBrush(Me.BackColor), e.Bounds)
            Dim x2 As Rectangle = New Rectangle(e.Bounds.Location, New Size(e.Bounds.Width, e.Bounds.Height))
            Dim g1 As New SolidBrush(Me.ForeColor)
            e.Graphics.FillRectangle(g1, x2)

            e.Graphics.DrawString(" " & LBox.Items(e.Index).ToString().Split(":")(0), b, New SolidBrush(Me.BackColor), e.Bounds.X, e.Bounds.Y + 1)
            e.Graphics.DrawString(" " & LBox.Items(e.Index).ToString().Split(":")(1), l, New SolidBrush(Me.BackColor), e.Bounds.X + 10, e.Bounds.Y + 25)
        Else
            e.Graphics.DrawString(" " & LBox.Items(e.Index).ToString().Split(":")(0), b, New SolidBrush(Me.ForeColor), e.Bounds.X, e.Bounds.Y + 1)
            e.Graphics.DrawString(" " & LBox.Items(e.Index).ToString().Split(":")(1), l, New SolidBrush(Me.ForeColor), e.Bounds.X + 10, e.Bounds.Y + 25)
            End If
        Catch ex As Exception
            MsgBox("Make sure your lines are in ''Title:Description'' form.")
        End Try
    End Sub
    Sub AddRange(ByVal Items As Object())
        LBox.Items.Remove("")
        LBox.Items.AddRange(Items)

    End Sub
    Sub AddItem(ByVal Item As Object)
        LBox.Items.Remove("")
        LBox.Items.Add(Item)

    End Sub
End Class

Class TextBoxFlat
    Inherits TextBox

    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case 15
                Invalidate()
                MyBase.WndProc(m)
                Me.CustomPaint()
                Exit Select
            Case Else
                MyBase.WndProc(m)
                Exit Select
        End Select
    End Sub

    Sub New()
        Font = New Font("Segoe UI Light", 7.8)
        BorderStyle = Windows.Forms.BorderStyle.FixedSingle
    End Sub

    Private Sub CustomPaint()
        Dim p As New Pen(Me.ForeColor)

        CreateGraphics.DrawLine(p, 0, 0, Width, 0)
        CreateGraphics.DrawLine(p, 0, Height - 1, Width, Height - 1)
        CreateGraphics.DrawLine(p, 0, 0, 0, Height - 1)
        CreateGraphics.DrawLine(p, Width - 1, 0, Width - 1, Height - 1)

    End Sub
End Class

Class ControlBoxFlat
    Inherits ThemeControl
    Private X As Integer
    Sub New()
        Me.Size = New Size(71, 19)
        Me.Anchor = AnchorStyles.Top Or AnchorStyles.Right
    End Sub
    Overrides Sub PaintHook()
        Dim lsize As New Size
        lsize = G.MeasureString(Text, Font).ToSize()
        G.Clear(Me.BackColor)

        G.DrawString("0", New Font("Marlett", 8.25), New SolidBrush(Me.ForeColor), New Point(4, 4))
        If FindForm.WindowState <> FormWindowState.Maximized Then G.DrawString("1", New Font("Marlett", 8.25), New SolidBrush(Me.ForeColor), New Point(26, 3)) Else G.DrawString("2", New Font("Marlett", 8.25), New SolidBrush(Me.ForeColor), New Point(26, 3))
        G.DrawString("r", New Font("Marlett", 10), New SolidBrush(Me.ForeColor), New Point(46, 2))

        Select Case MouseState
            Case State.MouseOver
                If X <= 22 Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(50, Me.ForeColor)), New Rectangle(New Point(1, 1), New Size(21, Height - 2)))
                ElseIf X > 22 And X <= 44 Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(50, Me.ForeColor)), New Rectangle(New Point(23, 1), New Size(21, Height - 2)))
                ElseIf X > 44 Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.Red)), New Rectangle(New Point(45, 1), New Size(25, Height - 2)))
                End If
            Case State.MouseDown

                If X <= 22 Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(120, Me.ForeColor)), New Rectangle(New Point(1, 1), New Size(21, Height - 2)))
                ElseIf X > 22 And X <= 44 Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(120, Me.ForeColor)), New Rectangle(New Point(23, 1), New Size(21, Height - 2)))
                ElseIf X > 44 Then
                    G.FillRectangle(New SolidBrush(Color.FromArgb(120, Color.Red)), New Rectangle(New Point(45, 1), New Size(25, Height - 2)))
                End If
        End Select
        Me.Cursor = Cursors.Hand
    End Sub
    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        X = e.X
        Invalidate()
    End Sub

    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        MyBase.OnClick(e)
        If X <= 22 Then
            FindForm.WindowState = FormWindowState.Minimized
        ElseIf X > 22 And X <= 44 Then
            If FindForm.WindowState <> FormWindowState.Maximized Then FindForm.WindowState = FormWindowState.Maximized Else FindForm.WindowState = FormWindowState.Normal
        ElseIf X > 44 Then
            FindForm.Close()
        End If
    End Sub
End Class

Class DropDownFlat
    Inherits ThemeContainerControl
    Private _Checked As Boolean
    Private X As Integer
    Private y As Integer
    Private _OpenedSize As Size

    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal V As Boolean)
            _Checked = V
            Invalidate()
        End Set
    End Property
    Public Property OpenSize As Size
        Get
            Return _OpenedSize
        End Get
        Set(ByVal V As Size)
            _OpenedSize = V
            Invalidate()
        End Set
    End Property
    Sub New()
        AllowTransparent()
        Size = New Size(90, 30)
        MinimumSize = New Size(5, 30)
        _Checked = True
        Me.Font = New Font("Segoe UI Light", 10.2)
    End Sub
    Overrides Sub PaintHook()
        G.Clear(Me.BackColor)

        If _Checked = True Then

            G.FillRectangle(New SolidBrush(Me.BackColor), New Rectangle(0, 0, Width, 30))
            G.FillRectangle(New SolidBrush(Color.FromArgb(15, Me.ForeColor)), New Rectangle(0, 0, Width, 30))
            G.DrawRectangle(New Pen(Me.ForeColor), 0, 0, Width - 1, Height - 1)
            G.DrawRectangle(New Pen(Me.ForeColor), 0, 0, Width - 1, 30)
            Me.Size = _OpenedSize
            G.DrawString("t", New Font("Marlett", 12), New SolidBrush(Me.ForeColor), Width - 25, 5)
        Else
            G.FillRectangle(New SolidBrush(Me.BackColor), New Rectangle(0, 0, Width, 30))
            G.FillRectangle(New SolidBrush(Color.FromArgb(15, Me.ForeColor)), New Rectangle(0, 0, Width, 30))
            G.DrawRectangle(New Pen(Me.ForeColor), 0, 0, Width - 1, Height - 1)
            G.DrawRectangle(New Pen(Me.ForeColor), 0, 0, Width - 1, 30)
            Me.Size = New Size(Width, 30)
            G.DrawString("u", New Font("Marlett", 12), New SolidBrush(Me.ForeColor), Width - 25, 5)
        End If
        G.DrawString(Text, Font, New SolidBrush(Me.ForeColor), 7, 5)
    End Sub

    Private Sub meResize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If _Checked = True Then
            _OpenedSize = Me.Size
        Else
        End If
    End Sub


    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        X = e.X
        y = e.Y
        Invalidate()
    End Sub

    Sub changeCheck() Handles Me.MouseDown


        If X >= Width - 22 Then
            If y <= 30 Then
                Select Case Checked
                    Case True
                        Checked = False
                    Case False
                        Checked = True
                End Select
            End If
        End If
    End Sub
End Class
Class ProgressBar
    Inherits ThemeControl
    Private _Maximum As Integer
    Dim Gloss As Boolean
    Dim Vertical As Boolean = True
    Public Property VerticalAlignment As Boolean
        Get
            Return Vertical
        End Get
        Set(ByVal v As Boolean)
            Vertical = v
            Invalidate()
        End Set
    End Property
    Public Property Glossy As Boolean
        Get
            Return Gloss
        End Get
        Set(ByVal v As Boolean)
            Gloss = v
            Invalidate()
        End Set
    End Property
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal v As Integer)
            Select Case v
                Case Is < _Value
                    _Value = v
            End Select
            _Maximum = v
            Invalidate()
        End Set
    End Property
    Private _Value As Integer
    Public Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal v As Integer)
            Select Case v
                Case Is > _Maximum
                    v = _Maximum
            End Select
            _Value = v
            Invalidate()
        End Set
    End Property
    Overrides Sub PaintHook()

        G.Clear(Color.Transparent)
        Dim s As Integer = 0
        DrawBorders(New Pen(New SolidBrush(ForeColor)), New Pen(New SolidBrush(BackColor)), ClientRectangle)
        'Fill
        If _Value > 1 Then
            If Vertical Then
                s = (Height - CInt(_Value / _Maximum * Height))
                If Glossy Then

                    G.FillRectangle(New SolidBrush(Me.ForeColor), New Rectangle(2, s + 3, Width - 4, CInt(_Value / _Maximum * Height) - 5))
                    G.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.White)), New Rectangle(2, s + 3, (Width / 3) - 2, CInt(_Value / _Maximum * Height) - 5))

                ElseIf Not Glossy Then
                    G.FillRectangle(New SolidBrush(Me.ForeColor), New Rectangle(2, s + 3, Width - 4, CInt(_Value / _Maximum * Height) - 5))

                End If
            ElseIf Not Vertical Then
                s = (Height - CInt(_Value / _Maximum * Width))
                If Glossy Then
                    G.FillRectangle(New SolidBrush(Me.ForeColor), New Rectangle(2, 2, CInt(_Value / _Maximum * Width) - 4, Height - 4))
                    G.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.White)), New Rectangle(2, 2, CInt(_Value / _Maximum * Width) - 4, Height / 3))

                ElseIf Not Glossy Then
                    G.FillRectangle(New SolidBrush(Me.ForeColor), New Rectangle(2, 2, CInt(_Value / _Maximum * Width) - 4, Height - 4))
                End If
            End If
        End If

        'Borders

    End Sub
    Public Sub Increment(ByVal Amount As Integer)
        If Me.Value + Amount > Maximum Then
            Me.Value = Maximum
        Else
            Me.Value += Amount
        End If
    End Sub

    Public Sub New()
        Me.Value = 0
        Me.Maximum = 100
        AllowTransparent()
    End Sub
End Class