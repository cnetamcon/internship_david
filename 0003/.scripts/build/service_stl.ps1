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

$DIR_SLN = Join-Path $REPOSITORY_ROOT "service"
$PATH_SLN = Join-Path $DIR_SLN "STLService.Host.sln"
$DIR_PRECONFIG = Join-Path $DIR_SLN "_pre-config"
$DIR_OUTPUT = Join-Path $output "Bin"

New-Item -Path $DIR_OUTPUT -ItemType Directory -Force

copy -R "$DIR_PRECONFIG/*" "$output"

Write-Output $PATH_SLN

Set-Location $DIR_SLN

nuget restore $PATH_SLN

msbuild $PATH_SLN /t:Build /p:Configuration=Release /p:DebugType=None -p:Version=$VERSION_NUMBER -p:FileVersion=$VERSION_NUMBER -p:AssemblyVersion=$VERSION_NUMBER -p:InformationalVersion=$VERSION_NUMBER /p:OutputPath=$DIR_OUTPUT

Set-Location $PATH_CURRENT

#Remove directories

$DIR_BUILD_R1 = Join-Path $output "Binapp.publish"

if (Test-Path $DIR_BUILD_R1) {
    Remove-Item -Path $DIR_BUILD_R1 -Recurse -Force
}
