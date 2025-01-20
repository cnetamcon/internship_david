& "$(Join-Path $PSScriptRoot env.ps1)"

$REPOSITORY_ROOT = $env:REPOSITORY_ROOT
$WORKFLOW = Join-Path $env:DIR_SCRIPTS "workflow_new_task.ps1"


$escaped_title = "abcdefghijklmnopqrstuvwxyz1029384756!@#$%^&*()_+,-.=[]><\{}/?| ' " `"

$escaped_title = $escaped_title.Replaced('`','``').Replaced("'","`'").Replaced('"','`"').Replaced('$','`$').Replaced('&','`&').Replaced('[','`[').Replaced(']','`]').Replaced('(','`(').Replaced(')','`)').Replaced('{','`{').Replaced('}','`}')

Write-Output $escaped_title


