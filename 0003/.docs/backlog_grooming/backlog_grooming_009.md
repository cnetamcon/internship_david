# Backlog grooming

---

**Date**: 2024.07.22 12:00

## Participants

---

- Andrey Shalashenko
- Anton Kuzmin

## Projects

---

- skylog

## Tasks

---

- [ ] [105] front - Clipping popup - hide Match CK
      Add the possibility in conf file to hide "Match CK"
      And possibility to rename "Match CK" by a custom name
- [ ] [106] Front - Clipping popup - rename Bumper
      Add the possibility to rename from conf file Bumper in and out
- [ ] [108] Front - Summarizer result
      Make the popup very much bigger to display large result.
      Also, actualy the result is not displayed
- [ ] [107] API Cliping changes
      See specification `Specifications.API.CLIPPING.pptx`
- [ ] [113] Multiview audio
      When we select a player in a multiview, it's activating the audio of the selected player.
      we add a border to the player selected.
      When we click again on it we unselected the player
- [ ] [114] Multi track audio
      Some monthe ago you start work on multitrack audio per player.
      We can add it now.
- [ ] [112] Audio Mute features
      When we load a logsheet the audio of the video is mute by default.
      We add a button to put in ON
- [ ] [116] In the search page, desable the case sensitive
- [ ] [117] Search page date start and end
      When we select All in project and All in logsheet, we don't set by default a start date.
      we let the user to choose if he want to search All or with date start and End
      When we select a logsheet, we set by default in the start and end the Event date from the logsheet
- [ ] [118] Live Time for player
      Actually we take the time from the computer.
      Do we have a way to take the time from the server ?

### Context

108
"Also, actualy the result is not displayed"
У меня отображается (скрин 1)
113
"When we select a player in a multiview, it's activating the audio of the selected player.
we add a border to the player selected.
When we click again on it we unselected the player"
Нужно будет будет выделять компоненты видео на multiview и у выделенных воспроизводить звук? Можно ли выбрать сразу несколько? Нужно ли как-то регулировать громкость при этом?
114
"Some monthe ago you start work on multitrack audio per player.
We can add it now."
Ничего не понял, какой multitrack audio?
112
"When we load a logsheet the audio of the video is mute by default.
We add a button to put in ON"
У нас же уже есть кнопка для регулирование звука на главной странице
117
"when we select All in project and All in logsheet, we don't set by default a start date.
we let the user to choose if he want to search All or with date start and End"
То есть когда мы ищем все проекты и логшиты мы не выставляем start и end date для поиска - по дефолту
118
"Live Time for player
Actually we take the time from the computer.
Do we have a way to take the time from the server?"
То есть они хотят что бы мы отображали у плеера время сервера(скрин 2)

### Questions

- [ ] #108 We need to check
- [ ] #102 We need to check
- [ ] #113 Do we select only one stream or can we select multiple streams?
      only one stream
      to have only one audio
      it's like we do the mute/on of audio by selecting the player
- [ ] #114 Could you describe more please?
      as I remeber you did something for audio stream
      able to add audio stream to a video stream
      to be able to display many audio tracks.
      Yes, on the multiview fullscreen mode, thanks

## Next backlog grooming

---

**Date**: 2024.07.26 16:00
**Goals**: Main goals for the next backlog grooming meeting
