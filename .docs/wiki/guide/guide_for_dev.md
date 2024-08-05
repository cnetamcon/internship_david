# {project} guide for Developers

---

## Task workflow:

1. Go to Projects, move the desired task to the "In Progress" column
2. Open git bush, go to the dev branch and pull the latest changes
3. Create a git branch corresponding to the task number without a hash symbol (example 42)
4. After completing work on the task, check the main functionality for operability
5. Upload the current state of the dev branch to the task branch and resolve conflicts if any
6. Move the task in Projects to the "In Review" column
7. Make a pull request to merge the branch in dev
8. Write "{task number} done" in slack

Working with the repository looks like this:

```
git checkout dev
git pull origin dev

git checkout -b {number}

git commit -a -m"{number} {title}"
git push origin {number}

git checkout dev
git pull origin dev
git checkout {number}
git merge origin dev
git commit -a -m"Merge dev to {number}"

git push origin {number}
```

---

[Dev environment](./guide_for_dev/dev_environment.md)

---
