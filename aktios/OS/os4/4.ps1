Get-Service | where StartType -eq "Manual" | Format-List -Property Name, Description, ServiceType, Status, StartType |  Out-File -FilePath .\result.txt
Get-CimInstance -ClassName Win32_SystemProcesses | Format-list -Property PartComponent | Out-File -FilePath .\ProcessId.txt