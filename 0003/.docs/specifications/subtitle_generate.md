
**Income words** - These are the words we receive from Speechmatics
**Extract subtitle** - The process of extracting a subtitle from the subtitle buffer
**Subtitle** - The subtitle to send as Newfor or write to a file
**Buffer** - The word buffer

For example:
subtitles_timeout_ms = 2000
subtitle_extract_attempts = 3

## First case - Display incompletely generated subtitle

---

Income words: some-word1 some-word2 some-word3 some-word4 some-word5 some-word6 some-word7

---

Extract subtitle: // wait 2 sec.
Subtitle:
1. some-word1 some-word2 some-word3
2. some-word4 some-word5 some-word6

Buffer: some-word7

---

Extract subtitle: // there is no prepared subtitles in the buffer. decrement subtitle_extract_attempts (2). wait 2 sec.
Subtitle:
1. 
2. 

Buffer: some-word7

---

Extract subtitle: // there is no prepared subtitles in the buffer. decrement subtitle_extract_attempts (1). wait 2 sec.
Subtitle:
1. 
2. 

Buffer: some-word7

---

Extract subtitle: // there is no prepared subtitles in the buffer. decrement subtitle_extract_attempts (0). wait 2 sec.
Subtitle:
1. 
2. 

Buffer: some-word7

---

Extract subtitle: // there is no prepared subtitles in the buffer. Move not fully subtitle to the subtitle buffer. wait 2 sec.
Subtitle:
1. some-word7
2. 

Buffer:

---


## Second case - Wait words to generate subtitle

--- 

Income words: some-word1 some-word2 some-word3 some-word4 some-word5 some-word6 some-word7

---

Extract subtitle: // wait 2 sec.
Subtitle:
1. some-word1 some-word2 some-word3
2. some-word4 some-word5 some-word6

Buffer: some-word7

---

Extract subtitle: // there is no prepared subtitles in the buffer. decrement subtitle_extract_attempts (2). wait 2 sec.
Subtitle:
1. 
2. 

Buffer: some-word7

---

Extract subtitle: // there is no prepared subtitles in the buffer. decrement subtitle_extract_attempts (1). wait 2 sec.
Subtitle:
1. 
2. 

Buffer: some-word7

---

Extract subtitle: // there is no prepared subtitles in the buffer. decrement subtitle_extract_attempts (0). wait 2 sec.
Subtitle:
1. 
2. 

Buffer: some-word7

---

Income words: some-word8 some-word9 
// Reset subtitle_extract_attempts (3)

---

Extract subtitle: // there is no prepared subtitles in the buffer. decrement subtitle_extract_attempts (2). wait 2 sec.
Subtitle:
1. 
2. 

Buffer: some-word7 some-word8 some-word9

---

Income words: some-word10 some-word11 some-word12 some-word13
// Reset subtitle_extract_attempts (3)

---

Extract subtitle: // wait 2 sec.
Subtitle:
1. some-word7 some-word8 some-word9
2. some-word10 some-word11 some-word12

Buffer: some-word13

---



