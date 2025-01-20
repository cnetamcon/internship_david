# Information for installing the new version

## v3.9.2.0

For update:

- AutoSub project
  - Replace all from STL_AutoSub/ directory without /App_Data/ directory.
  - Synchronize `./App_Data/Configuration/SpeechmaticsSettings.json` manually
    - `speaker_prefix` was added
    - `speaker_postfix` was added
    - `show_new_speaker_only` was added
    - `use_speaker_id` was added

## v3.8.3.0

https://cloud.broadteam.eu/index.php/f/28400

For update:

- AutoSub project
  - Replace all from STL_AutoSub/ directory without /App_Data/ directory.
    But `./App_Data/Configuration/ApplicationSettings.json` should be updated manually.
    - `subtitle_write_mode` was changed to Array
    - `subtitle_extract_attempts` was added

## v3.8.2.0

https://cloud.broadteam.eu/index.php/f/28388

For update:

- AutoSub project
  - Replace all from STL_AutoSub/ directory without /App_Data/ directory.
    But `./App_Data/Configuration/ApplicationSettings.json` should be updated manually.
    `subtitle_gen_line_mode` and `subtitle_start_mode` was added.

## v3.8.1.0

https://cloud.broadteam.eu/index.php/f/28335

For update:
Copy all files from ./STL_AutoSub/ without App_Data/ directory

But the settings should be added manually into App_Data/Configurations/ApplicationSettings.json

```
  "subtitle_latest_path": "./tmp/latest.txt"
```

## v3.8.0.0

https://cloud.broadteam.eu/index.php/f/28324

For update:
Copy all files from ./STL_AutoSub/ without App_Data/ directory

But the settings should be added manually into App_Data/Configurations/ApplicationSettings.json

```
  "subtitle_write_mode": 1,
  "subtitle_srt_path": "./tmp/subtitle.srt"
```

## v3.7.1.1

https://cloud.broadteam.eu/index.php/f/28147

For update:

- Replace all from STL_Service/Bin/ directory

## v3.7.1.0

For update:

- Replace all from STL_Service/Bin/ directory
