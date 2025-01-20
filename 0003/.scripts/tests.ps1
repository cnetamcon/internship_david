param(
  [string]$version
)

& "$(Join-Path $PSScriptRoot env.ps1)"

Write-Output "Run '$env:SOLUTION_NAME' '$version'"
Write-Output "Repository: $env:REPOSITORY_ROOT"

$SCRIPT_TEST = Join-Path (Join-Path $env:DIR_SCRIPTS "tests") "test_solution.ps1"

& $SCRIPT_TEST -version $version 

