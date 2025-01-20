param(
  [string]$version
)

& "$(Join-Path $PSScriptRoot env.ps1)"

$VERSION = $version
$VERSION_NUMBER = $VERSION.Replace("v","")
$REPOSITORY_ROOT = $env:REPOSITORY_ROOT
$PATH_VERSIONS = Join-Path $env:DIR_DOCS "versions.md"
$PATH_TASKS = Join-Path $env:DIR_DOCS "tasks.md"

$current_location = Get-Location

Write-Output "New milestone $version"

Set-Location $REPOSITORY_ROOT

git config user.name "GitHub Action"
git config user.email "action@github.com"

try{
  git fetch --all
}catch{}

try{
  git checkout main
}catch{}

try{
  git pull origin main
}catch{}

try{
  git checkout -b $VERSION_NUMBER
}catch{}

Write-Output "Write entry in the versions.md file"

$pattern = "^- \[.?\] $VERSION.*$"
$VERSION_ENTRY = "- [ ] $VERSION "
$content = Get-Content -Path $PATH_VERSIONS 
$foundLine = $content | Where-Object {$_ -match $pattern }

if($foundLine){

  Write-Output "Version entry already exist '$foundLine'"

  #$content = $content -replace [regex]::Escape($foundLine), $VERSION_ENTRY
  #$content | Set-Content -Path $PATH_TASKS
} else{
  Add-Content -Path $PATH_VERSIONS -Value "$VERSION_ENTRY"
  Write-Output "Version entry successfully added"
}

Write-Output "Write entry in the tasks.md file"

#$pattern = "^## $VERSION.*$"
#$VERSION_ENTRY = "## $VERSION"
#$content = Get-Content -Path $PATH_TASKS 
#$foundLine = $content | Where-Object {$_ -match $pattern }
#
#if($foundLine){
#
#  Write-Output "Version entry already exist '$foundLine'"
#
#  #$content = $content -replace [regex]::Escape($foundLine), $VERSION_ENTRY
#  #$content | Set-Content -Path $PATH_TASKS
#} else{
#  Add-Content -Path $PATH_TASKS -Value "$VERSION_ENTRY"
#  Write-Output "Version entry successfully added"
#}

Write-Output "Create branch $VERSION_NUMBER"

try{
  git add .
}catch{}

try{
  git commit -m"New milestone $version"
}catch{}

try{
  git push origin $VERSION_NUMBER
}catch{}

try{
  git checkout main
}catch{}

Set-Location $current_location

exit 0
