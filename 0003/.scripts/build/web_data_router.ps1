param(
  [string]$version,
  [string]$root,
  [string]$output
)
$VERSION = $version
$VERSION_NUMBER = $VERSION.Replace("v","")
$REPOSITORY_ROOT = $root
$DIR_BUILD_WEB_DATAROUTER = $output

$PATH_CURRENT = Get-Location

# Build DataRouter
$PATH_DATAROUTER_SLN = Join-Path (Join-Path $REPOSITORY_ROOT datarouter-web) DataRouter.sln
$PATH_DATAROUTER_RELEASE = Join-Path (Join-Path (Join-Path $REPOSITORY_ROOT datarouter-web) DataRouter) bin
$PATH_DATAROUTER_PROJ = Join-Path (Join-Path (Join-Path $REPOSITORY_ROOT datarouter-web) DataRouter) DataRouter.csproj 
$PATH_DATAROUTER_RELEASE_FINISH = Join-Path (Join-Path $PATH_DATAROUTER_RELEASE _PublishedWebsites) DataRouter

nuget restore $PATH_DATAROUTER_SLN

msbuild "$PATH_DATAROUTER_SLN" /p:AssemblyVersion="$VERSION_NUMBER" /p:FileVersion="$VERSION_NUMBER" /p:Version="$VERSION_NUMBER" /p:Configuration=Release /p:DebugType=None

msbuild "$PATH_DATAROUTER_PROJ" /p:Version=$VERSION_NUMBER /p:DebugType=None /p:DeployOnBuild=true /p:PublishMethod=FileSystem /p:PublishUrl="$DIR_BUILD_WEB_DATAROUTER" /p:OutputPath="$PATH_DATAROUTER_RELEASE" /p:Configuration=Release /p:Platform="Any CPU" /p:DeleteExistingFiles=True


xcopy "$PATH_DATAROUTER_RELEASE_FINISH" "$DIR_BUILD_WEB_DATAROUTER" /E /H /K /Y

Set-Location $PATH_CURRENT
