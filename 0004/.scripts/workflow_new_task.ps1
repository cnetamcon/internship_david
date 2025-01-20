param(
  [string]$id,
  [string]$title,
  [string]$body
)

& "$(Join-Path $PSScriptRoot env.ps1)"

$REPOSITORY_ROOT = $env:REPOSITORY_ROOT
$SCRIPT_ISSUE = Join-Path $env:DIR_SCRIPTS "issue.ps1"

$current_location = Get-Location

Set-Location $REPOSITORY_ROOT

git config user.name "GitHub Action"
git config user.email "action@github.com"

try{
  git fetch --all
}catch{
}

$current_branch = git rev-parse --abbrev-ref HEAD

if ($current_branch -ne 'main') {
    git checkout main
}

try {
    git pull origin main
} catch {
  #  Write-Output "Warning: 'git pull origin main' failed with exit code $($_.Exception.StatusCode)."
}

try {
    git checkout -b $id
} catch {
  #  Write-Output "Error: 'git checkout $id' failed with exit code $($_.Exception.StatusCode)."
  #  Write-Output "Error details: $($_.Exception.Message)"
}

& $SCRIPT_ISSUE -root $REPOSITORY_ROOT -id $id -title $TITLE -body $body

git add .
git commit -m"Create new issue $id"

try {
    git push origin $id
} catch {
  #  Write-Output "Error: 'git push origin $id' failed with exit code $($_.Exception.StatusCode)."
  #  Write-Output "Error details: $($_.Exception.Message)"
}

try {
    git checkout main
} catch {
  #  Write-Output "Error: 'git checkout $id' failed with exit code $($_.Exception.StatusCode)."
  #  Write-Output "Error details: $($_.Exception.Message)"
}

Set-Location $current_location
exit 0
