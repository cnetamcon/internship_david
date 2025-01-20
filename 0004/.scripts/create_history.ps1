param(
  [string]$root,
  [string]$title
)

$REPOSITORY_ROOT = $root
$DIR_DOCS = Join-Path $REPOSITORY_ROOT .docs
$PATH_HISTORY = Join-Path $DIR_DOCS history.md

Write-Output "Add new history entry $title"

# Create history entry
$currentDateTime = Get-Date
$formattedDateTime = $currentDateTime.ToString("yyy-MM-dd HH:mm")

$TIME = $formattedDateTime
$ENTRY = "$TIME $title"

Add-Content -Path $PATH_HISTORY -Value "$ENTRY"
Write-Output "Task entry successfully added"
