# Backlog grooming
---
**Date**: 2024.06.04 11:30
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
- [x]  #web Job window. Make the window size to width 800px height 90% , and thumbnails bigger
- [x] #web Add another field “Match CK”, send the content as parameter “match_id” in the clipping request
- [x] #api Clipping and selected thumbnails requests. Add another field “Match ID”, send the content as parameter “match_id” in the clipping request
- [x] #api Clipping and selected thumbnails requests. Add another field "log_uid" (both in the clipping and the selected thumbnail request)
- [x] #api Add new Job status - Published (enum)
- [x] #api Add new Job status - Error (enum)
- [x] #web Deactivate CLIPPING and PUBLISH buttons if job already started and status Ongoing or job service status is offline
- [x] #web Job text status color Green if job status is Done
- [x] #web Job text status color Red if job status is Error
- [x] #web Change title for thumbnail to "Chose a thumbnail"
- [x] #web Move the regenerate button to top right 
- [x] #web Show thumbnail area if job was created
- [x] #web Make a thumbnail select/hover functions
- [x] #web Move "Send" button to bottom
- [x] #web Send to bedrock all selected thumbnails
- [x] #web Change the CLIPPING button size to 176x48
- [x] #web API status button 
- [x] #web Make a settings for the Job window "Name" parameter. Display title and placeholder from the settings file

```
<?xml version="1.0" encoding="utf-8"?><!-- Uploaded to: SVG Repo, www.svgrepo.com, Generator: SVG Repo Mixer Tools -->
<svg width="800px" height="800px" viewBox="0 0 48 48" version="1" xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 48 48">
    <circle fill="#FFFFFF" cx="24" cy="24" r="21"/>
    <polygon fill="#FFFFFF" points="34.6,14.6 21,28.2 15.4,22.6 12.6,25.4 21,33.8 37.4,17.4"/>
</svg>
```



Flow of job
- Click to CLIPPING button
- Job status change to Ongoing
- Job service working
- Job service send to our backend status "Published" (after sending to external API)
	- Job status change to Published
- Waiting for external API work (~15min)
- Job service send to our backend status "Online"
	- Job status change to Done
- How to detect error status from Job api - "ERROR : FAILED TO RETRIEVE THE VIDEO"


### Questions
- [x] Make the window wider, and thumbnails bigger?  
- 800px
- [x] Do we change Name for the placeholder or for the title too?
- both
- For point 1, the best would be to put this as a parameter somewhere ;)
- [x] What request should we send for the Selected thumbnail? Should we use URI parameters or we should make a json model?
```
{baseAddress}/jobs/SelectedThumbnail?name_thumbnail={nameWithoutExtention}&job_UID={jobId}
```
- as we send now
- [x] Selected thumbnail request. Maybe to do some request where we will send all selected thumbnails?
	- no, we send only one selected thumbnail


## Next backlog grooming
---
**Date**: 2024.06.06 16:00
**Goals**: Main goals for the next backlog grooming meeting


