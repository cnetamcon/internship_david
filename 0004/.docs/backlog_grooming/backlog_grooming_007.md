# Backlog grooming

---

**Date**: 2024.06.17 11:00

## Participants

---

- Andrey Shalashenko
- Anton Kuzmin

## Projects

---

- skylog

## Tasks

---

#api #ang Rework of job api methods

- [ ] Delete Job API /jobs/CreateJob method
- [ ] Add POST /jobs/Clipping method
- [ ] Add POST /jobs/SpeechTT method
- [ ] Add POST /jobs/FullExport method
- [ ] Change POST /jobs/SelectedThumbnail method
- [ ] Change POST /jobs/RandomizeThumbnails method

```
POST /jobs/Clipping
```

```
{
    "stream_name": "string",
    "in": "string",
    "out": "string",
    "clip_name": "string",
    "BumperIn": "string",
    "BumperOut": "string",
    "job": {
            "type": 0,
            "data": "string",
            "status": "string",
            "job_status": 0,
            "result": "string",
            "log_id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "logsheet_id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "created": "2024-06-12T09:11:01.226Z",
            "updated": "2024-06-12T09:11:01.226Z"
            }
}

```

```
POST /jobs/FullExport
```

```
{
    "job": {
            "type": 0,
            "data": "string",
            "status": "string",
            "job_status": 0,
            "result": "string",
            "log_id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "logsheet_id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "created": "2024-06-12T09:11:01.226Z",
            "updated": "2024-06-12T09:11:01.226Z"
            }
}
```

```
POST /jobs/SpeechTT
```

```
{
    "stream_name": "string",
    "in": "string",
    "out": "string",
    "clip_name": "string",
    "Language": "string",
    "Target_Language": "string",
    "job": {
            "type": 1,
            "data": "string",
            "status": "string",
            "job_status": 0,
            "result": "string",
            "log_id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "logsheet_id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "created": "2024-06-12T09:11:01.226Z",
            "updated": "2024-06-12T09:11:01.226Z"
            }
}
```

```
POST /jobs/SelectedThumbnail
```

```
{
    "name_thumbnail": "string",
    "job": {
            "type": 0,
            "data": "string",
            "status": "string",
            "job_status": 0,
            "result": "string",
            "log_id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "logsheet_id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "created": "2024-06-12T09:11:01.226Z",
            "updated": "2024-06-12T09:11:01.226Z"
            }
}
```

```
POST /jobs/RandomizeThumbnails
```

```
{
    "number_thumbnails": int,
    "job": {
            "type": 0,
            "data": "string",
            "status": "string",
            "job_status": 0,
            "result": "string",
            "log_id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "logsheet_id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "created": "2024-06-12T09:11:01.226Z",
            "updated": "2024-06-12T09:11:01.226Z"
            }
}
```

### Context

We have some new tasks. Can you create a new branch for next week? (the current branch is in production already for M6 and will stay the same). I did a big update on the job API, some endpoints are changed for better communcation with skylog. The status id is now used to change the text colors in the clipping popup. Here are the specifications for the endpoint changes

[Specification](../specifications/Specifications.pptx)

### Questions

## Next backlog grooming

---

**Date**: 2024.06.21 16:00
**Goals**: Main goals for the next backlog grooming meeting
