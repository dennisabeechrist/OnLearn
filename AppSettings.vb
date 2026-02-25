Public Class AppSettings

    Private Shared _instance As AppSettings
    Private Shared ReadOnly _lock As New Object()

    Public Property PlatformName As String
    Public Property DefaultCategory As String
    Public Property LastSearchText As String
    Public Property LastBrowsePath As String

    Private Sub New()
        PlatformName = My.Settings.PlatformName
        DefaultCategory = My.Settings.DefaultCategory
        LastSearchText = My.Settings.LastSearchText
        LastBrowsePath = My.Settings.LastBrowsePath
    End Sub

    Public Shared ReadOnly Property Instance As AppSettings
        Get
            SyncLock _lock
                If _instance Is Nothing Then
                    _instance = New AppSettings()
                End If
            End SyncLock
            Return _instance
        End Get
    End Property

    Public Sub Save()
        My.Settings.PlatformName = PlatformName
        My.Settings.DefaultCategory = DefaultCategory
        My.Settings.LastSearchText = LastSearchText
        My.Settings.LastBrowsePath = LastBrowsePath
        My.Settings.Save()
    End Sub

End Class
