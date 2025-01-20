param(
  [string]$root,
  [string]$id,
  [string]$title
)

$REPOSITORY_ROOT = $root
$DIR_DOCS = Join-Path $REPOSITORY_ROOT .docs
$DIR_FEATURES = Join-Path $DIR_DOCS features
$PATH_FEATURE = Join-Path $DIR_FEATURES "$id.md"

# Create feature file
if(Test-Path $PATH_FEATURE){
  Write-Output "Feature file $PATH_FEATURE already exists"
} else{
  Write-Output "Create new feature file $PATH_FEATURE"

  $text  = "### $title"

  Set-Content -Path $PATH_FEATURE -Value $text -Encoding UTF8
}
