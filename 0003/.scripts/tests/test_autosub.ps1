param(
  [string]$version,
  [string]$root
)


Write-Output "Start test Auto-Subtitle project $version"

$DIR_PROJECT = Join-Path (Join-Path $root "auto-sub-service") "auto-live-sub-service"

Write-Output "$DIR_PROJECT"

Set-Location $DIR_PROJECT

dotnet test


