& "$(Join-Path $PSScriptRoot env.ps1)"

$VERSION = "v0.0.0.7"
$IDS = "14,15,16,17,18,19,20,21"

# Move to branch with version
$VERSION_NUMBER = $VERSION.Replace("v","")

$SCRIPT_RELEASE = Join-Path $env:DIR_SCRIPTS "workflow_new_release.ps1"

& $SCRIPT_RELEASE -version $VERSION -ids $IDS
