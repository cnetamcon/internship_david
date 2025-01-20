$parentFolder = [System.IO.Path]::GetDirectoryName($PSScriptRoot)

& "$(Join-Path $parentFolder env.ps1)"

$PROJECT = $env:SOLUTION_NAME
$REPOSITORY_ROOT = $env:REPOSITORY_ROOT

Write-Output "Run tests for $PROJECT"
Write-Output "Repository: $REPOSITORY_ROOT"

$SCRIPT_TEST_1 = Join-Path (Join-Path $env:DIR_SCRIPTS "tests") "test_1.ps1"
$SCRIPT_TEST_AUTOSUB = Join-Path (Join-Path $env:DIR_SCRIPTS "tests") "test_autosub.ps1"

#& $SCRIPT_TEST_1 -version $VERSION -root "$REPOSITORY_ROOT" 
#& $SCRIPT_TEST_AUTOSUB -version $VERSION -root "$REPOSITORY_ROOT" 

