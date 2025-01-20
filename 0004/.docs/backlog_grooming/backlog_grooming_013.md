# Backlog grooming

---

**Date**: 2024.12.10

## Participants

---

- Andrey Shalashenko

## Projects

---

- #datarouter
- #autosub

### Context

- [ ] #58 DATAROUTER - SETTING : Autosub become a list
      Добавить новый тип AutoSub: AI. Можно будет активировать либо Auto-Sub либо AI-Sub либо ничего.

- [ ] #59 DATAROUTER - VIEWERBOX : we want to be able to select what incoming to display

  1. Добавляем глобальную настройку группировть или нет в SubtitlePanel Incoming stream по SubGroup
  2. Добавить флаг в IncomingStream settings определяющий показывать incoming button или нет. По умолчнию - показывать
  3.

- [ ] #39 possibility to connect many Autosub on the datarouter

  1. Сделать коллекцию настраеваемых auto-sub
  2. Добавить для каждого auto-sub поле Name
  3. В Incoming stream settings page показывать выпадающий список с auto-sub

- [ ] #45 #stl STL Service licensing mechanism

  1. Добавить механизм создания лицензии
  2. При старте STL service проверять данные лицензии

- [ ] #57 #autosub Don't reopen stream after color change

  1. Когда меняем настройки цвета или линий не перезапускать стрим

- [ ] #38 #datarouter STL file record management

  1. В файле настроек `ApplicationSettings.json` задается параметр `IsGenerateStlForDestinations (boolean)` определяющий будет ли создаваться файл `STL` после связки `Incoming - Destination` и будут ли в этот файл попадать субтитры.
  2. В файле настроек `ApplicationSettings.json` задается параметр `StlForDestinationDirectory` представляющий собой базовую директорию для `STL` файлов..
  3. Если `Destination` связан с некоторым `Incoming` все субтитры отправляющиеся на этот `Destination` записываются в файл `STL`.
  4. Путь для `STL` file генерируется как `{root}/{IncomingName}-{DestinationName}.stl`. Путь `root` задан в файле настроек `ApplicationSettings.json` `StlForDestinationDirectory`.

### Tasks

### Questions

1. #38 Как определить что запись завершена? Ведь в будущем эта связка `Incoming - Destination` может повторяться, но файл будет использоваться прежний. Как именовать файлы?

## Next backlog grooming

---
