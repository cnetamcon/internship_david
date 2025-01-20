param(
  [string]$version,
  [string]$ids
)

& "$(Join-Path $PSScriptRoot env.ps1)"

$VERSION = $version
$VERSION_NUMBER = $VERSION.Replace("v","")
$REPOSITORY_ROOT = $env:REPOSITORY_ROOT
$PATH_VERSIONS = Join-Path $env:DIR_DOCS "versions.md"

$current_location = Get-Location

Write-Output "New milestone $version"

Set-Location $REPOSITORY_ROOT

git config user.name "GitHub Action"
git config user.email "action@github.com"

try{
  git checkout $VERSION_NUMBER
}catch{}

Write-Output "Write entry in the versions.md file"

$pattern = "^- \[.?\] $VERSION.*$"
$VERSION_ENTRY = "- [ ] $VERSION $ids"
$content = Get-Content -Path $PATH_VERSIONS 
$foundLine = $content | Where-Object {$_ -match $pattern }

if($foundLine){

  Write-Output "Version entry already exist '$foundLine'"
  Write-Output "New version entry '$VERSION_ENTRY'"

  $content = $content -replace [regex]::Escape($foundLine), $VERSION_ENTRY
  Write-Output "$PATH_VERSIONS `r`nContent:`r`n$content"
  Set-Content -Path $PATH_VERSIONS -Value $content
  Write-Output "success"
} else{
  Add-Content -Path $PATH_VERSIONS -Value "$VERSION_ENTRY"
  Write-Output "Version entry successfully added"
}

try{
  git status
}catch{}

try{
  git add .
}catch{}

try{
  git commit -m"New milestone $version"
}catch{}

try{
  git status
}catch{}


try{
  git push origin $VERSION_NUMBER
}catch{
  Write-Output "Error details: $($_.Exception.Message)"
}

Set-Location $current_location

exit 0
