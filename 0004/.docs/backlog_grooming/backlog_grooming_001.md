# Backlog grooming
---
**Date**: 2024.05.29 12:00
## Participants
---
- Andrey Shalashenko
- Anton Kuzmin

## Projects
---
- skylog

## Tasks
---
### skylog

- [x] #42 Increase or create new API method for logsheet creation to create and bind new videos with logsheet
- [x] #44 In multiview webpage, when we click on one video, we turn on the audio of the video selected 
- [x] #45 add turn on/off audio button in main player
- [x] #46 add audio metter in full screen mode - also be able to show until 8 audio meters. we can configure audio stream link to video stream in video settings. audio stream looks like same as a avideo stream ws://
- [x] #47 Query splitting error with the MSSQL 2012
- [x] #48 Show popup after clipping job done
- [x] Check the log deletion process. Some error occurs
- [x] Job request. Change job state to Error if http request to api fails

```
./scripts/workflow_new_task.ps1 -id 48 -title "Show popup after clipping job done" -body ""
```
For the export thumbnails, can you add a DONE popup? When you receive the status with text "Bedrock clip created OK" you close the clipping window and show the popup with just "clipping done" and an OK button

![](../attachments/image_2024_05_29T14_10_16_066Z.png)

- [ ] Clipping job window. Change placeholder text from the "Name" to "Titre extrait"
- [ ] Add new job api request `/isOnline` return text "OK" and status 200
- [ ] #api #ang Add a new model for the job service status
- [ ] #api Add new JobStatus observer to ping Job service status every 3 sec
### Question

### Answer

## Next backlog grooming
---
**Date**: 2024.05.30 16:00
**Goals**: Main goals for the next backlog grooming meeting

