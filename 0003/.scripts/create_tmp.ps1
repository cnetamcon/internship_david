param(
  [string]$root
)

$ROOT = $root

# Create directories
Write-Output "Create temp directory '$ROOT'"

if (Test-Path $ROOT) {
    Remove-Item -Path $ROOT\* -Recurse -Force
} else {
    New-Item -Path $ROOT -ItemType Directory -Force
}


