# Release project 
param(
  [string]$version,
  [string]$tasks,
  [string]$project
)

$REPOSITORY_ROOT = Split-Path -Path $($PSScriptRoot) -Parent
$PROJECT_NAME = $project
$VERSION = $version
$VERSION_NUMBER = $VERSION.Replace("v","")
$IDS = $tasks

$DIR_DOCS = Join-Path $REPOSITORY_ROOT ".docs"
$DIR_TEMP = Join-Path $REPOSITORY_ROOT ".tmp"
$DIR_BUILD = Join-Path $DIR_TEMP $project
$DIR_SCRIPTS = Join-Path $REPOSITORY_ROOT ".scripts"
$PATH_HTML_MAIN = Join-Path (Join-Path $DIR_TEMP $project)"readme.html" 
$SCRIPT_CREATE_TMP = Join-Path $DIR_SCRIPTS "create_tmp.ps1"
$SCRIPT_CREATE_HTML_MAIN = Join-Path $DIR_SCRIPTS "./create_html_main.ps1"
$SCRIPT_BUILD = Join-Path $DIR_SCRIPTS "build.ps1"
$SCRIPT_TESTS = Join-Path $DIR_SCRIPTS "tests.ps1"
$SCRIPT_CREATE_VERSION = Join-Path $DIR_SCRIPTS "create_version.ps1"
$SCRIPT_CREATE_HISTORY = Join-Path $DIR_SCRIPTS "create_history.ps1"

$archive_name = "$project" + "_"+ "$VERSION"
Write-Output $archive_name
$PATH_ARCHIVE = Join-Path $DIR_TEMP "$archive_name.zip"

Write-Output "Project: $project"
Write-Output "New release '$VERSION'"
Write-Output "Repository '$REPOSITORY_ROOT'"

# Create temp directory
& $SCRIPT_CREATE_TMP -root $DIR_TEMP

# Run tests
& $SCRIPT_TESTS $VERSION

# Build projects
& $SCRIPT_BUILD -version $VERSION -root $REPOSITORY_ROOT -output $DIR_BUILD

# Build documentation
& $SCRIPT_CREATE_VERSION -root $REPOSITORY_ROOT -version $VERSION -ids $IDS -projectName $PROJECT_NAME

# Copy version pdf documents
$DIR_VERSIONS_ATTACHMENT = Join-Path (Join-Path $REPOSITORY_ROOT .docs) attachments
$DIR_VERSIONS_HTML = Join-Path (Join-Path $REPOSITORY_ROOT .docs) versions_html
$DIR_VERSIONS_NEW = Join-Path $DIR_BUILD .docs 

New-Item -Path $DIR_VERSIONS_NEW -ItemType Directory -Force

copy -R "$DIR_VERSIONS_HTML" (Join-Path $DIR_VERSIONS_NEW "versions")
copy -R "$DIR_VERSIONS_ATTACHMENT" $DIR_VERSIONS_NEW

# Generate index html 

& $SCRIPT_CREATE_HTML_MAIN -root $REPOSITORY_ROOT -version $version -output $PATH_HTML_MAIN

# Copy update info
#copy "$(Join-Path $DIR_DOCS readme_update.md)" "$(Join-Path $DIR_BUILD readme_update.md)"

# Copy install info
#copy "$(Join-Path $DIR_DOCS readme_install.md)" "$(Join-Path $DIR_BUILD readme_install.md)"

# Archive project
Write-Output "Archive into $PATH_ARCHIVE"
Compress-Archive -Path $DIR_BUILD -DestinationPath $PATH_ARCHIVE -CompressionLevel Optimal

# Log history
#& $SCRIPT_CREATE_HISTORY -root $REPOSITORY_ROOT -title "Build new release '$PROJECT_NAME' '$VERSION' with tasks [$IDS]"

explorer $DIR_TEMP
