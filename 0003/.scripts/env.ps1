$env:SOLUTION_NAME = "stl"
$env:REPOSITORY_ROOT = Split-Path -Path $($PSScriptRoot) -Parent
$env:DIR_SCRIPTS = Join-Path $env:REPOSITORY_ROOT ".scripts"
$env:DIR_DOCS = Join-Path $env:REPOSITORY_ROOT ".docs"
$env:DIR_TMP = Join-Path $env:REPOSITORY_ROOT ".tmp"
