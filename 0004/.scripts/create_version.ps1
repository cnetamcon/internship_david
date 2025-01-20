# Build release document in /.docs/versions
# 1. Get tasks for milestone
# 2. Get issues from tasks.md
# 3. Get release descriptions from {issue_number}.md
# 4. Build release document
#   - Tasks
#   - Feature descriptions
param(
  [string]$root,
  [string]$version,
  [string]$projectName,
  [string]$ids
)

$DIR_DOCS =  Join-Path $root ".docs"
$DIR_VERSIONS = Join-Path $DIR_DOCS "versions"
$DIR_VERSIONS_HTML = Join-Path $DIR_DOCS "versions_html"
$DIR_FEATURES = Join-Path $DIR_DOCS "features"
$PATH_TASKS = Join-Path $DIR_DOCS "tasks.md"
$PATH_NEW_VERSION = Join-Path $DIR_VERSIONS "$version.md"
$PATH_NEW_VERSION_PDF = Join-Path (Join-Path $DIR_DOCS "versions_pdf") "$version.pdf"

Write-Output "Build documentation for $projectName release $version"
Write-Output "Ids: $ids"
Write-Output "Repository: $root"
Write-Output "Output: $PATH_NEW_VERSION"

if(-not (Test-Path $DIR_VERSIONS_HTML)){
    New-Item -Path $DIR_VERSIONS_HTML -ItemType Directory -Force
}

$IDS_ARRAY = $ids -split ","

$all_tasks = Get-Content -Path $PATH_TASKS 

$CONTENT = ""
$CONTENT_TASKS = ""
$CONTENT_FEATURES = ""

foreach($id in $IDS_ARRAY) {
  $pattern = "^- \[.?\] \[$id\].*$"
  $foundLine = $all_tasks | Where-Object {$_ -match $pattern }

  if($foundLine){
    $task = $foundLine -replace "^- \[.?\]", "-"
    $CONTENT_TASKS += "$task`r`n"
  } else { 
    $CONTENT_TASKS += "- [$id]`r`n"
    Write-Output "Task [$id] not found"
  }
}

$CONTENT_TASKS = $CONTENT_TASKS -replace '- \[(\d+)\]', '- #$1'

Write-Output $CONTENT_TASKS

foreach($id in $IDS_ARRAY) {
  $path = Join-Path $DIR_FEATURES "$id.md"

  if(Test-Path $path) {
    $CONTENT_FEATURES += Get-Content $path -Raw
    $CONTENT_FEATURES += "`r`n`r`n"
  }
}

$CONTENT += "# $projectName version $version`r`n"
$CONTENT += "Date: $((Get-Date).ToString("yyy.MM.dd"))`r`n"
$CONTENT += "`r`n"
$CONTENT += "## Issues in Milestone`r`n`r`n"
$CONTENT += "---`r`n`r`n"
$CONTENT += "$CONTENT_TASKS"
$CONTENT += "`r`n"
$CONTENT += "## Features`r`n`r`n"
$CONTENT += "---`r`n`r`n"
$CONTENT += "$CONTENT_FEATURES"

Write-Output $CONTENT
Write-Output "Write new version $PATH_NEW_VERSION"

Set-Content -Path $PATH_NEW_VERSION -Value $CONTENT

# Build HTML

$FILE_HTML = Join-Path $DIR_VERSIONS_HTML "$version.html"
$FILE_HTML_TEMPLATE = Join-Path( Join-Path $PSScriptRoot "doc") "template_version.html"
$SCRIPT_HTML_GEN = Join-Path $PSScriptRoot "md_to_html_template.ps1"

& $SCRIPT_HTML_GEN $PATH_NEW_VERSION $FILE_HTML $FILE_HTML_TEMPLATE

