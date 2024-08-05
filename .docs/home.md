# Structure of documentation directory

```
- .docs
	- attachments
		- image.png
	- backlog_grooming
		backlog_grooming_001.md
		backlog_grooming.md
	- features
		- 1.md
	- tasks
		- 1.md
	- versions
		- v1.0.0.0.md
    - wiki
        - faq
        - guides
            - guide_for_administrators
            - guide_for_users
	- history.md
	- home.md
	- tasks.md
```

This directory contains files that relate to the description of the functionality being developed and the release of new versions.

## Obsidian

For more comfortable work with markdown files, it is recommended to use Obsidian.
The Obsidian configuration file is set up so that all added images go to the /.dosc/attachments directory.

Obsidian configuration.

The obsidian configuration is in the .obsidian.zip archive, it must be unzipped to /.docs/

The .obsidian directory has been added to .gitignore so changes will not affect git commits

After that you can start Obsidian with the powershell script .scripts/run_obsidian.ps1

## New project release

- Create a file with a task number in /.docs/tasks/
- Creating a version file with milestone number
- Preparing powershell files for release generation
- Task list
- Milestone
- Create a version file in /.docs/versions/
- Add an entry about the new version to /.docs/history.md
- Mark tasks in /.docs/tasks.md as completed
- We build projects into the /.tmp/ directory
- Copy the /.docs/versions folder to /.tmp/
- Copy the version file to the /.tmp/ folder
- Forming an archive

## New project task creation

- When creating a task

- create a file in features
- create an entry in /.docs/tasks.md

- task_creation.ps1
- tasks_close.ps1
- release.ps1
- release_projects_build.ps1
- release_description_build.ps1
- release_archivate.ps1

## Wiki

The **Wiki** directory contains two subdirectories **faq** and **guide**

### faq

Contains information about frequently asked questions and is divided into questions for:

- **Administrators** - File **faq_for_administrators** contains information about frequently asked questions when administering an application - deployment, port conflicts, database configuration, etc.
- **Developers** - **faq_for_dev** contains information about frequently asked questions when developing an application - how to solve the launch problem, how to use multiple databases, etc.
- **Application Users** - **faq_for_user** contains information about frequently asked questions when using the application

Also in the faq all emergency situations and ways to solve them are documented so that in the future if this situation happens again there will be instructions on how to solve it.

### guide

Contains information and a more detailed description of how the application functions and instructions on how to interact with it.

- **Administrators** - File **guide_for_administrators** contains information on application administration. About how to install the application, configure and configure the environment. Contains detailed instructions for deployment on test, production and other systems.
- **Developers** - **guide_for_dev** contains information for developers on how to set up development environments, how the process of introducing new functionality, testing and releasing new versions occurs.
- **Application Users** - **guide_for_user** contains information about the application from the user's point of view. Why is it needed, what problems does it solve and how to use it. Contains a detailed description of the application's functionality and how to use it.

For each guide (guide*for_administrators, guide_for_dev, guide_for_users) there is a separate directory in which a separate file is created for a specific topic or section and a link to this file is indicated in the (guid_for*\*) file.
