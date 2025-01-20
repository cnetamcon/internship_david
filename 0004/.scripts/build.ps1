param(
  [string]$version,
  [string]$root,
  [string]$output
)

Write-Output "Start build solution: '$version'"
Write-Output "Build root: '$root'"
Write-Output "output: '$output'"

$SCRIPT_BUILD = Join-Path (Join-Path $env:DIR_SCRIPTS build) build_solution.ps1

& $SCRIPT_BUILD -version $version -root $root -output "$output"
