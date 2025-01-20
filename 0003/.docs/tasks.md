- [x] [7] DataRouter. Live subtitles rework line numbers and color
- [x] [8] #stlconv Fix resource release while parser is running
- [ ] [9] Auto-sub service. Upgrade dotnet version from .net7 to .net8
- [x] [10] Modify Automation and the Sequence "StreamPrepare" / "StreamExecute" / StreamStop"

## v3.7.1.1

- [x] [11] Newfor parsing. Fix color detection

## v3.8.0.0

- [x] [12] #autosub Make a settings to choose between send to TCP/UDP and write into file

## v3.8.1.0

- [x] [13] #autosub Make new recording mode only last transcription

## v3.8.2.0

- [x] [14] #autosub Make new start mode to choose between auto-start or data-router
- [x] [15] #autosub Create a new subtitle generation mode. Keep latest line or generation new lines

## v3.8.3.0

- [x] [16] #autosub Add the ability to combine multiple modes "subtitle_write_mode"
- [x] [17] #autosub Wait some iterations to fill subtitle lines if there are not fully completed

## v3.8.4.0

- [x] [18] #autosub Make separate replaceByteDictionnary for the SRT and Sub.txt output
- [x] [20] #autosub Generate Newfor start depend on lines amount

## v3.8.5.0

- [x] [22] Create an architecture diagram of the subtitle building
- [x] [23] Change sequence of convert transcription to subtitle
- [x] [24] Make filter to clear duplicates from transcription
- [x] [25] Move to the next line if added symbol is punctuation
- [x] [26] Change subtitle delivery process. Wait until the subtitle is fully filled

## v3.8.6.0

- [x] [27] If the word is a punctuation symbol and is added to the beginning of the line, skip this word
- [x] [28] Add settings for Newfor and change Newfor building
- [x] [32] Fix thread race condition when adding words to the words buffer

## v3.8.8.0

- [x] [33] Subtitle building rework. Changing the punctuation behavior

## v3.8.7.0

- [x] [29] Implement OBS API and make new subtitle delivery type

## v3.8.8.1

- [x] [35] #autosub Don't remove 0x0D if there is not enough space but remove the color byte

## v3.8.9.0

- [x] [37] #datarouter Manage line from datarouter for autosub
- [x] [40] #datarouter Manage the color dynamically in Datarouter and Autosub
- [x] [44] #datarouter Remove all color management except for manual choice from Webpage
- [x] [43] #autosub Set new line for new speaker
- [x] [49] #autosub Change line completing mechanism to add check length of latest two words

## v3.9.0.0

- [x] [54] #autosub Getting speaker fullname from external api
- [x] [55] #autosub Display FullName if the received transcription is the first transcription of the speaker otherwise ShortName
- [x] [56] #autosub The first line of each subtitle should start with the speaker name
- [x] [60] #autosub Migrate project to .Net9.0

## v3.9.1.0

- [x] [65] #autosub Add a speaker confidence threshold
- [x] [67] #autosub Add char before speaker name (char should be in conf file)

## v3.9.1.1

- [ ] [69] Fix building script

## v3.9.2.0

- [ ] [74] #autosub Set speaker name first time only

## v3.8

- [ ] [19] #autosub fix of duplicate lines
