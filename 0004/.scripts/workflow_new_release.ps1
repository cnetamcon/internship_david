param(
  [string]$version 
)

& "$(Join-Path $PSScriptRoot env.ps1)"

$PROJECT = $env:SOLUTION_NAME
$REPOSITORY_ROOT = $env:REPOSITORY_ROOT
$VERSION_NUMBER = $VERSION.Replace("v","")
$DIR_SCRIPTS = $env:DIR_SCRIPTS
$SCRIPT_RELEASE = Join-Path $DIR_SCRIPTS "release.ps1"
$PATH_VERSIONS = Join-Path $env:DIR_DOCS "tasks.md"

Write-Host "Getting tasks for the version $version"

function Get-TaskNumber {
    param (
        [string]$text
    )

    if ($text -match '\[.\]?\s*\[(\d+)\]') {
        return $matches[1]
    } else {
        return "No task number found."
    }
}

$versions = Get-Content $PATH_VERSIONS
$pattern = "^## $version.*$"

$version_line = $versions | Where-Object { $_ -match $pattern }

if ($version_line) {
  $ver = $version_line -replace '.*\[(x|\s)\] (\S+) .*', '$2'
  $ids = @()

  $inVersionBlock = $false
  
  foreach ($line in $versions) {
      if ($line -match "##\s+$version") {
          Write-Host "Found version line '$line'"
          $inVersionBlock = $true
      }
      elseif ($line -match '##\s+v') {
          if ($inVersionBlock) {

              Write-Host "End of version tasks parsing. Next version '$line'"
              break
          }
      }

      if ($inVersionBlock -and $line -match '^- \[.?\]?\s*\[(\d+)\].*$') {
 
         $lineId = Get-TaskNumber -text $line
         Write-Host "$line"
         $ids += [int]$lineId
      }
  }

  $ids_param = $ids -join ','
  Write-Host "IDs: ($ids) ($ids_param)"

  Set-Location $REPOSITORY_ROOT

  git config --global user.email "cnetamcon@gmail.com"
  git config --global user.name "GH Action"

  git fetch --all
  git checkout $VERSION_NUMBER
  git pull origin $VERSION_NUMBER

  & $SCRIPT_RELEASE -version $VERSION -tasks $ids_param -project $PROJECT

  Set-Location $REPOSITORY_ROOT

  git add .
  git commit -m"Create release $VERSION documentation"
  git push origin $VERSION_NUMBER

 } else {
    Write-Host "Version $version not found in the versions file."
}
