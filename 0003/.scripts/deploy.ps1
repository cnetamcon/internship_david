param(
  [string]$VERSION
)

$prefix = "stl"
$root_build = Join-Path $($PSScriptRoot) "build"
$root_output = "C:\_test_dir\stl" 
$root_config = Join-Path $($PSScriptRoot) "config"

$path_archive = Join-Path () "$($prefix)_$($VERSION).zip"
$dir_config = $root_config
$dir_output = Join-Path $root_output "$($prefix)_$($VERSION)"

if (Test-Path $dir_output) {
    Remove-Item -Path $dir_output -Recurse -Force -ErrorAction SilentlyContinue
} 

Expand-Archive $path_archive $dir_output

# Synchronize config

# STL Service
$path_config_stl_source = Join-Path (Join-Path $dir_config "STL_Service") "Settings"
$path_config_destination = Join-Path (Join-Path (Join-Path $dir_output "stl") "STL_Service") "Settings"

Copy-Item -Path "$($path_config_stl_source)/*" -Destination $path_config_destination -Recurse -Force

# AutSub
$path_config_stl_source = Join-Path (Join-Path $dir_config "STL_AutoSub") "Configuration"
$path_config_destination = Join-Path (Join-Path (Join-Path (Join-Path $dir_output "stl") "STL_AutoSub") "App_Data") "Configuration"

Copy-Item -Path "$($path_config_stl_source)/*" -Destination $path_config_destination -Recurse -Force

# DataRouter
$path_config_stl_source = Join-Path $dir_config "DataRouter"
$path_config_destination = Join-Path (Join-Path (Join-Path (Join-Path $dir_output "stl") "STL_DataRouter") "App_Data") "Configuration"

Copy-Item -Path "$($path_config_stl_source)/*" -Destination $path_config_destination -Recurse -Force
