Imports AForge.Video
Imports System.Drawing

Public Class SignalRVideoSource
    Implements IVideoSource

    '================ IVideoSource EVENTS =================

    Public Event NewFrame As NewFrameEventHandler Implements IVideoSource.NewFrame
    Public Event PlayingFinished As PlayingFinishedEventHandler Implements IVideoSource.PlayingFinished
    Public Event VideoSourceError As VideoSourceErrorEventHandler Implements IVideoSource.VideoSourceError


    '================ IVideoSource PROPERTIES =================

    Private _source As String = "SignalR"
    Private _running As Boolean = False
    Private _framesReceived As Integer = 0
    Private _bytesReceived As Long = 0

    Public Property Source As String Implements IVideoSource.Source
        Get
            Return _source
        End Get
        Set(value As String)
            _source = value
        End Set
    End Property

    Public ReadOnly Property FramesReceived As Integer Implements IVideoSource.FramesReceived
        Get
            Return _framesReceived
        End Get
    End Property

    Public ReadOnly Property BytesReceived As Long Implements IVideoSource.BytesReceived
        Get
            Return _bytesReceived
        End Get
    End Property

    Public ReadOnly Property IsRunning As Boolean Implements IVideoSource.IsRunning
        Get
            Return _running
        End Get
    End Property


    '================ IVideoSource METHODS =================

    Public Sub Start() Implements IVideoSource.Start
        _running = True
    End Sub

    ' "Stop" is a reserved VB keyword so we use [Stop] to escape it
    Public Sub [Stop]() Implements IVideoSource.Stop
        _running = False
    End Sub

    Public Sub SignalToStop() Implements IVideoSource.SignalToStop
        _running = False
    End Sub

    Public Sub WaitForStop() Implements IVideoSource.WaitForStop
        _running = False
    End Sub


    '================ PUSH FRAME FROM SIGNALR =================

    Public Sub PushFrame(bytes As Byte())
        If Not _running Then Exit Sub

        Try
            ' USING BLOCKS PREVENT MEMORY LEAKS
            Using ms As New IO.MemoryStream(bytes)
                Using bmp As New Bitmap(ms)
                    _framesReceived += 1
                    _bytesReceived += bytes.Length

                    ' Fire the event. The VideoSourcePlayer will clone it if it needs it.
                    RaiseEvent NewFrame(Me, New NewFrameEventArgs(bmp))
                End Using ' Bitmap is disposed here instantly
            End Using ' MemoryStream is disposed here instantly
        Catch
            ' Ignore corrupted frames silently to keep the stream alive
        End Try
    End Sub

End Class