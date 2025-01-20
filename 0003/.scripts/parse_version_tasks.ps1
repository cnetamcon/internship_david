param(
  [string]$version 
)

& "$(Join-Path $PSScriptRoot env.ps1)"

$PROJECT = $env:SOLUTION_NAME
$REPOSITORY_ROOT = $env:REPOSITORY_ROOT
$VERSION_NUMBER = $VERSION.Replace("v","")
$DIR_SCRIPTS = $env:DIR_SCRIPTS
$SCRIPT_RELEASE = Join-Path $DIR_SCRIPTS "release.ps1"
$PATH_VERSIONS = Join-Path $env:DIR_DOCS "versions"
$PATH_VERSION = Join-Path $PATH_VERSIONS "$version.md"
$PATH_ATTACHMENTS = Join-Path $env:DIR_DOCS "attachments"
$PATH_ATTACHMENTS = "$PATH_ATTACHMENTS`\".Replace("`\", "/")

Write-Host "$PATH_ATTACHMENTS"

$content = Get-Content $PATH_VERSION

Write-Host "Getting tasks for the version $version"
$content = $content.Replace("../attachments/", $PATH_ATTACHMENTS) 


Write-Host $content

echo $content | pandoc -f markdown -t pdf -o output.pdf
