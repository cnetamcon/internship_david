param(
  [string]$root,
  [string]$id,
  [string]$title,
  [string]$body
)

$REPOSITORY_ROOT = $root
$DIR_DOCS = Join-Path $REPOSITORY_ROOT .docs
$DIR_TASKS = Join-Path $DIR_DOCS tasks
$PATH_TASKS = Join-Path $DIR_DOCS tasks.md
$PATH_TASK = Join-Path $DIR_TASKS "$id.md"

Write-Output "Add new task [$id] $title"
Write-Output "Path: $PATH_TASKS"

# Create entry in the tasks file

$TASK_ENTRY = "- [ ] [$id] $title"

$content = Get-Content -Path $PATH_TASKS 

$pattern = "^- \[.?\] \[$id\].*$"

$foundLine = $content | Where-Object {$_ -match $pattern }

if($foundLine){
  Write-Output "Replase task with '[$id] $title'"

  $content = $content -replace [regex]::Escape($foundLine), $TASK_ENTRY
  $content | Set-Content -Path $PATH_TASKS
} else{
  Add-Content -Path $PATH_TASKS -Value "$TASK_ENTRY"
  Write-Output "Task entry successfully added"
}

# Create task file in tasks/ directory
if(-Not (Test-Path $DIR_TASKS)) {
  New-Item -Path $DIR_TASKS -ItemType Directory -Force
}

if(Test-Path $PATH_TASK){
  Write-Output "Task file $PATH_TASK already exists"
} else{
  Write-Output "Create new task file $PATH_TASK"

  $text = "## #$id $title`r`n`r`n---`r`n`r`n$body"  

  Set-Content -Path $PATH_TASK -Value $text -Encoding UTF8
}
