param(
  [string]$root,
  [string]$id,
  [string]$title,
  [string]$body
)

$REPOSITORY_ROOT = $root
$DIR_DOCS = Join-Path $REPOSITORY_ROOT .docs
$PATH_TASKS = Join-Path $DIR_DOCS tasks.md

$SCRIPT_CREATE_FEATURE = Join-Path $env:DIR_SCRIPTS "create_feature.ps1"
$SCRIPT_CREATE_TASK = Join-Path $env:DIR_SCRIPTS "create_task.ps1"
#$SCRIPT_CREATE_HISTORY = Join-Path $env:DIR_SCRIPTS "create_history.ps1"

& $SCRIPT_CREATE_FEATURE -root $REPOSITORY_ROOT -id $ID -title $title
& $SCRIPT_CREATE_TASK -root $REPOSITORY_ROOT -id $ID -title $title -body $body
#& $SCRIPT_CREATE_HISTORY -root $REPOSITORY_ROOT -title "Add new issue [$id] $title"

