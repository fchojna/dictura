param (
    [string]$filePath,
    [string]$major,
    [string]$minor,
    [string]$patch
)

# Load the YAML file content
$yamlContent = Get-Content -Path $filePath -Raw

# Update the major, minor, and patch values
$yamlContent = $yamlContent -replace "(?m)^( *major:).*$", "`$1 $major"
$yamlContent = $yamlContent -replace "(?m)^( *minor:).*$", "`$1 $minor"
$yamlContent = $yamlContent -replace "(?m)^( *patch:).*$", "`$1 $patch"

# Save updated content back to the file
Set-Content -Path $filePath -Value $yamlContent

Write-Output "Updated dev-ci-trigger.yml with version: $major.$minor.$patch"
