Write-Host "Version: $Env:LibVersion"
Get-ChildItem -Recurse |
    Where { $_.PSIsContainer -and $_.Name -match "bin|obj" } |
    Remove-Item -Recurse -Force
