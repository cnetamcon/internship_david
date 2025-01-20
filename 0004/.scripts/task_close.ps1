# Finishing a task
# 1. Finish commit to git
# 2. Prepare PR description based on .docs/features/{issue_number}.md file
# 3. Make a PR with gh cli
param(
  [string]$id
)

& "$(Join-Path $PSScriptRoot env.ps1)"

Set-Location $env:REPOSITORY_ROOT

Write-Output "Project $env:SOLUTION_NAME"
Write-Output "Repository $env:REPOSITORY_ROOT"
Write-Output "Prepare PR for the issue $id"
