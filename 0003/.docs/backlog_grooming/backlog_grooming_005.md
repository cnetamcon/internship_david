# Backlog grooming

---

**Date**: 2024.06.06 13:00

## Participants

---

- Andrey Shalashenko
- Anton Kuzmin

## Projects

---

- skylog

## Tasks

---

- [ ] #web Clipping job window. Make a hover video more bigger
- [ ] #api Change the /jobs/SelectedThumbnail request model
- [ ] #api Change job api statuses binding

### Context

> Do you think with the mouse hover we can make the thumbnails more bigger ?

yes, if you need we can make a thumbnail with hover much bigger and other thumbnails small
![](../attachments/Screenshot_4758.png)

> is the logsheet id required in updating a log request?

Yes. Let's change the request and we'll send you complete log model in json.

For example:

```
{
    "name": "",
    "match_id: "",
    "job_id": "",
    "bumper_in": "",
    "bumper_out": "",
    "log" :  { ... }
}
```

> can we make the button clickable when you get status :
> "Clipping done, now choose a thumbnail."

### Questions

- [ ] Do you mean change status "Published" to "Clipping done, now choose a thumbnail."?
      It means the clipping is done, and the user is now asked to choose a thumbnail between the thumbnails displayed. but it is not published yet.
      The job is not terminated. Only online status mean terminated

Yes published is when you receive clipping done. And done is when you receive Bedrock clip created ok

There are 6 steps to my API, 1) download the clip from the nimble server 2) Add bumpers 3) Upload it to an S3 bucket 4) generate thumbnails 5) upload the selected thumbnail to the same S3 buucket 6) Create a clip in another api called "bedrock"

The status clipping done is sent between steps 4 and 5

and the status bedrock clip created is sent after step 6

```
Ok so on the website we'll bind the statuses

- Ongoing - when we receive status
"on going"

- Published - when we receive statuses:
"Clipping done, now choose a thumbnail."
"Published"

- Done - when we receive statuses
"done"
"online"

- Error - when status code is not 200 and when we receive statuses
"error: {some text}"
"Failed to upload video to S3 !"
"Failed to retrieve the video"
"Bedrock clip creation failed."
"Job API Error."
```

- [x] Do we need send BumperIn and BumperOut?
      ![](../attachments/Screenshot_4759.png)

Yes

## Next backlog grooming

---

**Date**: 2024.06.07 16:00
**Goals**: Main goals for the next backlog grooming meeting
