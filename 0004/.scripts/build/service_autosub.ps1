param(
  [string]$version,
  [string]$root,
  [string]$output
)
$VERSION = $version
$VERSION_NUMBER = $VERSION.Replace("v","")
$REPOSITORY_ROOT = $root

$DIR_SERVICE = Join-Path (Join-Path $REPOSITORY_ROOT "auto-sub-service") "auto-live-sub-service"
$DIR_SERVICE_PROJ = Join-Path $DIR_SERVICE "Host.Service.gRPC"
$PATH_SERVICE_PROJ = Join-Path $DIR_SERVICE_PROJ "Host.Service.gRPC.csproj"

$PATH_CURRENT = Get-Location

Write-Output "Build $DIR_SERVICE"

Set-Location $DIR_SERVICE

dotnet build -c Release

Set-Location $DIR_SERVICE_PROJ

dotnet publish "$PATH_SERVICE_PROJ" -c Release -o "$output" --no-self-contained /p:DebugType=None -p:Version=$VERSION_NUMBER -p:FileVersion=$VERSION_NUMBER -p:AssemblyVersion=$VERSION_NUMBER -p:InformationalVersion=$VERSION_NUMBER /p:PublishSingleFile=false /p:IncludeAllContentForSelfExtract=false

# Unpack tool ffmpeg

$DIR_APP_DATA = Join-Path (Join-Path (Join-Path $DIR_SERVICE "AM.Api.Ffmpeg") "App_Data") "Tools"
$PATH_FFMPEG_ARCHIVE = Join-Path $DIR_APP_DATA "ffmpeg.zip"
$DIR_FFMPEG_OUTPUT = Join-Path (Join-Path $output "App_Data") "Tools"

New-Item -Path $DIR_FFMPEG_OUTPUT -ItemType Directory -Force

Expand-Archive $PATH_FFMPEG_ARCHIVE $DIR_FFMPEG_OUTPUT 

Set-Location $PATH_CURRENT
