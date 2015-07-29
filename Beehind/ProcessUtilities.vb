Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class ProcessUtilities

    <DllImport("rstrtmgr.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function RmStartSession(ByRef pSessionHandle As UInteger, dwSessionFlags As Integer, strSessionKey As String) As Integer
    End Function

    <DllImport("rstrtmgr.dll")> _
    Private Shared Function RmEndSession(pSessionHandle As UInteger) As Integer
    End Function

    <DllImport("rstrtmgr.dll", CharSet:=CharSet.Unicode)> _
    Private Shared Function RmRegisterResources(pSessionHandle As UInteger, nFiles As UInt32, rgsFilenames As String(), nApplications As UInt32, <[In]()> rgApplications As RM_UNIQUE_PROCESS(), nServices As UInt32, _
 rgsServiceNames As String()) As Integer
    End Function

    <DllImport("rstrtmgr.dll")> _
    Private Shared Function RmGetList(dwSessionHandle As UInteger, ByRef pnProcInfoNeeded As UInteger, ByRef pnProcInfo As UInteger, <[In](), Out()> rgAffectedApps As RM_PROCESS_INFO(), ByRef lpdwRebootReasons As UInteger) As Integer
    End Function

    Private Const RmRebootReasonNone As Integer = 0
    Private Const CCH_RM_MAX_APP_NAME As Integer = 255
    Private Const CCH_RM_MAX_SVC_NAME As Integer = 63

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure RM_UNIQUE_PROCESS
        Public dwProcessId As Integer
        Public ProcessStartTime As ComTypes.FILETIME
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure RM_PROCESS_INFO
        Public Process As RM_UNIQUE_PROCESS
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=CCH_RM_MAX_APP_NAME + 1)> _
        Public strAppName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=CCH_RM_MAX_SVC_NAME + 1)> _
        Public strServiceShortName As String
        Public ApplicationType As RM_APP_TYPE
        Public AppStatus As UInteger
        Public TSSessionId As UInteger
        <MarshalAs(UnmanagedType.Bool)> _
        Public bRestartable As Boolean
    End Structure

    Private Enum RM_APP_TYPE
        RmUnknownApp = 0
        RmMainWindow = 1
        RmOtherWindow = 2
        RmService = 3
        RmExplorer = 4
        RmConsole = 5
        RmCritical = 1000
    End Enum

    Public Shared Function GetProcessesUsingFiles(filePaths As IList(Of String)) As IList(Of Process)
        Dim sessionHandle As UInteger
        Dim processes As New List(Of Process)()
        Dim rv As Integer = RmStartSession(sessionHandle, 0, Guid.NewGuid().ToString())
        If rv <> 0 Then
            Throw New Win32Exception()
        End If
        Try
            Dim pathStrings As String() = New String(filePaths.Count - 1) {}
            filePaths.CopyTo(pathStrings, 0)
            rv = RmRegisterResources(sessionHandle, CUInt(pathStrings.Length), pathStrings, 0, Nothing, 0, _
             Nothing)
            If rv <> 0 Then
                Throw New Win32Exception()
            End If
            Const ERROR_MORE_DATA As Integer = 234
            Dim pnProcInfoNeeded As UInteger = 0, pnProcInfo As UInteger = 0, lpdwRebootReasons As UInteger = RmRebootReasonNone
            rv = RmGetList(sessionHandle, pnProcInfoNeeded, pnProcInfo, Nothing, lpdwRebootReasons)
            If rv = ERROR_MORE_DATA Then
                Dim processInfo As RM_PROCESS_INFO() = New RM_PROCESS_INFO(pnProcInfoNeeded - 1) {}
                pnProcInfo = CUInt(processInfo.Length)
                rv = RmGetList(sessionHandle, pnProcInfoNeeded, pnProcInfo, processInfo, lpdwRebootReasons)
                If rv = 0 Then
                    For i As Integer = 0 To pnProcInfo - 1
                        Try
                            processes.Add(Process.GetProcessById(processInfo(i).Process.dwProcessId))
                        Catch generatedExceptionName As ArgumentException
                        End Try
                    Next
                Else
                    Throw New Win32Exception()
                End If
            ElseIf rv <> 0 Then
                Throw New Win32Exception()
            End If
        Finally
            RmEndSession(sessionHandle)
        End Try
        Return processes
    End Function
End Class
