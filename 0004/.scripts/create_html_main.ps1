param(
  [string]$root,
  [string]$version,
  [string]$output
)
$REPOSITORY_ROOT = $root
$DIR_DOCS =  Join-Path $root ".docs"
$DIR_VERSIONS = Join-Path $DIR_DOCS "versions"
$DIR_VERSIONS_HTML = Join-Path $DIR_DOCS "versions_html"
$DIR_FEATURES = Join-Path $DIR_DOCS "features"
$PATH_TASKS = Join-Path $DIR_DOCS "tasks.md"
$PATH_NEW_VERSION = Join-Path $DIR_VERSIONS "$version.md"
$PATH_NEW_VERSION_PDF = Join-Path (Join-Path $DIR_DOCS "versions_pdf") "$version.pdf"
$DIR_VERSIONS_NEW = $output

Write-Output "Generating HTML documentation file"
Write-Output "Version: '$version'"
Write-Output "Root: '$root'"
Write-Output "Output: '$output'"

try{
  $html_index_template = Join-Path (Join-Path (Join-Path $REPOSITORY_ROOT .scripts) "doc") "template_home.html"

  $html_content = Get-Content -Path $html_index_template -Raw

  $file_list = Get-ChildItem -Path $DIR_VERSIONS_HTML -Filter "*.html" | 
               Sort-Object -Property Name -Descending | 
               Select-Object -ExpandProperty Name |
               ForEach-Object { $_ -replace"\.html$",""}

  $file_names = $file_list -join '", "'
  $file_names = '"' + $file_names + '"'

  Write-Output "'$file_names'"

  $html_content = $html_content -replace 'files', $file_names
  $html_content = $html_content -replace 'current-version', $version

  Set-Content -Path $output -Value $html_content

}catch{
  Write-Error "Error generating HTML documentation file. $($_.Exception.Message)"
}
