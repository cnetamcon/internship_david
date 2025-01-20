
$currentBranch = git branch --show-current

Write-Output "Version v$currentBranch"

git add .
git commit -m"v$currentBranch"
git push origin "$currentBranch"
git tag -d "v$currentBranch"
git push --delete origin "v$currentBranch"
git tag "v$currentBranch"
git push origin "v$currentBranch"
