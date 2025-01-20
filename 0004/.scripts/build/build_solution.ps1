param(
  [string]$version,
  [string]$root,
  [string]$output
)

$REPOSITORY_ROOT = $root
$VERSION = $version
$VERSION_NUMBER = $VERSION.Replace("v","")
$DIR_TEMP = Join-Path $REPOSITORY_ROOT ".tmp"
$DIR_SCRIPTS = Join-Path $root ".scripts"
$DIR_SCRIPTS_BUILD = Join-Path $DIR_SCRIPTS "build"

$DIR_BUILD = $output
$DIR_BUILD_service_stl = Join-Path $DIR_BUILD "STL_Service"
$DIR_BUILD_service_autosub = Join-Path $DIR_BUILD "STL_AutoSub"
$DIR_BUILD_service_laci = Join-Path $DIR_BUILD "LACI_Service"
$DIR_BUILD_service_newfor_proxy = Join-Path $DIR_BUILD "STL_NewforProxy"
$DIR_BUILD_app_channel_view = Join-Path $DIR_BUILD "STL_ChannelView"
$DIR_BUILD_app_stl_client = Join-Path $DIR_BUILD "STL_Client"
$DIR_BUILD_app_stl_viewer = Join-Path $DIR_BUILD "STL_Viewer"
$DIR_BUILD_web_data_router = Join-Path $DIR_BUILD "STL_DataRouter"

$SCRIPT_service_stl = Join-Path $DIR_SCRIPTS_BUILD "service_stl.ps1"
$SCRIPT_service_autosub = Join-Path $DIR_SCRIPTS_BUILD "service_autosub.ps1"
$SCRIPT_service_laci = Join-Path $DIR_SCRIPTS_BUILD "service_laci.ps1"
$SCRIPT_service_newfor_proxy = Join-Path $DIR_SCRIPTS_BUILD "service_newfor_proxy.ps1"
$SCRIPT_app_channel_view  = Join-Path $DIR_SCRIPTS_BUILD "app_channel_view.ps1"
$SCRIPT_app_stl_client  = Join-Path $DIR_SCRIPTS_BUILD "app_stl_client.ps1"
$SCRIPT_app_stl_viewer  = Join-Path $DIR_SCRIPTS_BUILD "app_stl_viewer.ps1"
$SCRIPT_web_data_router  = Join-Path $DIR_SCRIPTS_BUILD "web_data_router.ps1"

Write-Output "Start build version: $VERSION"
Write-Output "Start build version: $VERSION_NUMBER"
Write-Output "Build root: $DIR_BUILD"

# Create directories
if (Test-Path $DIR_BUILD) {
    Remove-Item -Path $DIR_BUILD\* -Recurse -Force
} else {
    New-Item -Path $DIR_BUILD -ItemType Directory -Force
}

New-Item -Path $DIR_BUILD_service_stl -ItemType Directory -Force
New-Item -Path $DIR_BUILD_service_autosub -ItemType Directory -Force
New-Item -Path $DIR_BUILD_service_laci -ItemType Directory -Force
New-Item -Path $DIR_BUILD_service_newfor_proxy -ItemType Directory -Force
New-Item -Path $DIR_BUILD_app_channel_view -ItemType Directory -Force
New-Item -Path $DIR_BUILD_app_stl_client -ItemType Directory -Force
New-Item -Path $DIR_BUILD_app_stl_viewer -ItemType Directory -Force
New-Item -Path $DIR_BUILD_web_data_router -ItemType Directory -Force

#& $SCRIPT_service_stl -version $VERSION -root $REPOSITORY_ROOT -output "$DIR_BUILD_service_stl"
#& $SCRIPT_service_autosub -version $VERSION -root $REPOSITORY_ROOT -output "$DIR_BUILD_service_autosub"
#& $SCRIPT_service_laci -version $VERSION -root $REPOSITORY_ROOT -output "$DIR_BUILD_service_laci"
#& $SCRIPT_service_newfor_proxy -version $VERSION -root $REPOSITORY_ROOT -output "$DIR_BUILD_service_newfor_proxy"
#& $SCRIPT_app_channel_view -version $VERSION -root $REPOSITORY_ROOT -output "$DIR_BUILD_app_channel_view"
#& $SCRIPT_app_stl_client -version $VERSION -root $REPOSITORY_ROOT -output "$DIR_BUILD_app_stl_client"
#& $SCRIPT_app_stl_viewer -version $VERSION -root $REPOSITORY_ROOT -output "$DIR_BUILD_app_stl_viewer"
#& $SCRIPT_web_data_router -version $VERSION -root $REPOSITORY_ROOT -output "$DIR_BUILD_web_data_router"

#Remove directories

#$DIR_BUILD_R1 = Join-Path $REPOSITORY_ROOT "public"
#
#if (Test-Path $DIR_BUILD_R1) {
#  Write-Output "Remove public dir"
#  Remove-Item -Path $DIR_BUILD_R1 -Recurse -Force
#}
