param (
    [string]$filePath,
    [string]$version
)

# Load the JSON file content
$jsonContent = Get-Content -Path $filePath -Raw | ConvertFrom-Json

# Update the version key value
$jsonContent.version = $version

# Save updated content back to the file
$jsonContent | ConvertTo-Json -Compress | Set-Content -Path $filePath

Write-Host "Updated version.json with version: $version"
