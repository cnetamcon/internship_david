param(
  [string]$root,
  [string]$lastversion
)

$REPOSITORY_ROOT = $root
$DIR_DOCS =  Join-Path $root ".docs"
$DIR_VERSIONS = Join-Path $DIR_DOCS "versions"
$DIR_VERSIONS_HTML = Join-Path $DIR_DOCS "versions_html"

Write-Output "Generating HTML documentation file"
Write-Output "Version: '$version'"
Write-Output "Root: '$root'"

try{
  $html_index_template = Join-Path (Join-Path (Join-Path $REPOSITORY_ROOT .scripts) "doc") "template_home.html"

  $html_content = Get-Content -Path $html_index_template -Raw

  $file_list = Get-ChildItem -Path $DIR_VERSIONS -Filter "*.md" | 
               Sort-Object -Property Name -Descending | 
               Select-Object -ExpandProperty Name

  $SCRIPT_HTML_GEN = Join-Path $PSScriptRoot "md_to_html_template.ps1"
  $path_template =Join-Path (Join-Path (Join-Path $REPOSITORY_ROOT ".scripts") "doc") "template_version.html"
  
  $file_list | ForEach-Object {
    $v = $_ -replace ".md", ""
    Write-Output "file $v"

    $path_md_file = Join-Path $DIR_VERSIONS $_
    $path_html_file = Join-Path $DIR_VERSIONS_HTML "$v.html"

    & $SCRIPT_HTML_GEN $path_md_file $path_html_file $path_template
  }
}catch{
  Write-Error "Error generating HTML documentation file. $($_.Exception.Message)"
}
