param(
  [string]$version,
  [string]$root,
  [string]$output
)
$VERSION = $version
$VERSION_NUMBER = $VERSION.Replace("v","")
$REPOSITORY_ROOT = $root

$DIR_BUILD = $output

Write-Output $version

$PATH_CURRENT = Get-Location

$DIR_SLN = Join-Path $REPOSITORY_ROOT "client-stl-viewer"
$PATH_SLN = Join-Path $DIR_SLN "STLService.SubtitleViewer.sln"

Write-Output $PATH_SLN

Set-Location $DIR_SLN

nuget restore $PATH_SLN

msbuild $PATH_SLN /t:Build /p:Configuration=Release /p:DebugType=None -p:Version=$VERSION_NUMBER -p:FileVersion=$VERSION_NUMBER -p:AssemblyVersion=$VERSION_NUMBER -p:InformationalVersion=$VERSION_NUMBER /p:OutputPath=$output

Set-Location $PATH_CURRENT
