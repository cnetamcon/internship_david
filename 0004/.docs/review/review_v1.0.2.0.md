# Review v1.0.2.0

## Test info

The version is installed on server 192.168.101.52
Website:
```
http://192.168.101.52:23800
```

A test Job API service is also running on the server, which emulates the operation of a real service.

After clicking the CLIPPING button, test service
1. Copies images to thumbnails folder
2. After 5 seconds, sends the job status "Published" to the backend
3. After 20 seconds, randomly sends the job status "Online" or "Error"

The backend polls the Job API every 3 seconds by sending a request to the `/isOnline` route. This way we always know the status of the service, whether it is available or not.

The test service is located in the directory:
```
C:\_project_builds\skylog\test_job_api\net7.0
```

You can start it or stop it to check the operation of the Online status
```
TestJobApi.exe
```

The 'TITRE EXTRAIT' value must be filled in to trigger CLIPPING
![](../attachments/Screenshot_4756.png)

## Tasks to be done
- [ ] Job window. Validation for empty fields. Job doesn't start if Name is empty but CLIPPING is enable
- [ ] Already finished jobs with error sate stay with "Ongoing" status
- [ ] Check how we will operate jobs with error

## Feedback
