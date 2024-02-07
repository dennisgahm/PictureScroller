Public Class Form1

    Dim strDirectoryLocation As String
    Dim myfilesJPG() As String
    Dim myfilesJPEG() As String
    Dim myfilesPNG() As String

    Dim currentlyAccessingFile As Boolean

    Dim rnd As New Random
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "C:\Users\denni\OneDrive\Pictures\"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        strDirectoryLocation = TextBox1.Text

        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        WindowState = FormWindowState.Maximized

        myfilesJPG = IO.Directory.GetFiles(strDirectoryLocation, "*.jpg", IO.SearchOption.AllDirectories)
        'myfilesJPEG = IO.Directory.GetFiles(strDirectoryLocation, "*.jpeg", IO.SearchOption.AllDirectories)
        'myfilesPNG = IO.Directory.GetFiles(strDirectoryLocation, "*.png", IO.SearchOption.AllDirectories)


        'Timer1.Enabled = True
        DisplayNextPicture()


        'implement left arrow and right arrow
    End Sub

    Private Sub DisplayNextPicture()

        currentlyAccessingFile = True
        Dim filename As String = myfilesJPG(rnd.Next(0, myfilesJPG.Length))
        Try
            Using fs As New System.IO.FileStream(filename, IO.FileMode.Open)
                PictureBox1.Image = New Bitmap(Image.FromStream(fs))
            End Using
        Catch ex As Exception
            Dim msg As String = "Filename: " & filename &
        Environment.NewLine & Environment.NewLine &
        "Exception: " & ex.ToString
            MessageBox.Show(msg, "Error Opening Image File")
        End Try

        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom

        'PictureBox1.Image = Image.FromFile("C:\Users\denni\OneDrive\Pictures\penguinsflying.png")
        PictureBox1.Dock = DockStyle.Fill

        currentlyAccessingFile = False

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DisplayNextPicture()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If Not currentlyAccessingFile Then
            DisplayNextPicture()
        End If
        e.Handled = True
    End Sub
End Class
