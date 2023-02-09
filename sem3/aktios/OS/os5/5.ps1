Get-CimInstance -ClassName Win32_VideoController | Out-File -FilePath .\VedeoControllerInfo.txt
Get-CimInstance -ClassName Win32_DisplayConfiguration | Format-list DisplayFrequency | Out-File -FilePath .\DisplayFrequencyInfo.txt
Get-CimInstance -ClassName Win32_DisplayConfiguration | Format-list BitsPerPel | Out-File -FilePath .\BitsPerPelInfo.txt
