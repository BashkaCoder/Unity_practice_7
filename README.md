# Addressables 🚀 in Unity

## Task:
Добавить загрузку конфигов из Addressables в отдельный класс, который будет хранить эти конфиги. Организовать доступ к конфигам из других объектов сцены, таких как `Player` и `InAppPackageView`, через класс конфигов, загружаемых по лейблу. Основная идея — объекты сцены должны получать конфиги без прямой работы с Addressables.

## Требования:
- Объекты сцены `Player` и `Shop` должны сохранить свою функциональность (использование данных).
- Создаваемый в реальном времени `Player` должен сохранить свою функциональность.
- Конфиги должны быть типизированными — `PlayerConfig`, `InAppPackageConfig`.

## Скрипты:
### [PlayerSummoner.cs](https://github.com/BashkaCoder/Unity_practice_7/blob/Label/Assets/PlayerSummoner.cs)
Этот скрипт отвечает за создание новых экземпляров игрока с конфигом `PlayerConfig`. На нажатие клавиши **X** создается новый игрок с уже загруженной конфигурацией.

### [ConfigsProvider.cs](https://github.com/BashkaCoder/Unity_practice_7/blob/Label/Assets/Scripts/ConfigsProvider.cs)
Скрипт загружает конфиги по лейблам (`Player Config` и `App Config`) с использованием Addressables и сохраняет их в словарь. Позволяет другим объектам получать случайный конфиг, избегая прямой работы с Addressables.

### [Bootstrap.cs](https://github.com/BashkaCoder/Unity_practice_7/blob/Label/Assets/Scripts/Bootstrap.cs)
Занимается инициализацией всех объектов сцены с помощью загруженных конфигов. В момент загрузки конфигов передает их в `Player`, `PlayerSummoner` и `InAppPackageView`.

### [InAppPackageView.cs](https://github.com/BashkaCoder/Unity_practice_7/blob/Label/Assets/ConfigDependent/InAppPackageView.cs)
Этот скрипт отвечает за отображение цены в интерфейсе на основе загруженного конфига `InAppPackageConfig`.

## Использованные инструменты:
- [Cysharp UniTask](https://github.com/Cysharp/UniTask) для асинхронной загрузки ассетов.
- [Addressables](https://docs.unity3d.com/Manual/com.unity.addressables.html) для загрузки и управления ассетами.

## Инструкция:
- **Z**: Открыть-закрыть объект `Shop`.
- **X**: Создать нового игрока с использованием случайного конфигурационного файла.

## Список выполненной работы:
1. Реализована загрузка конфигов из Addressables по лейблам.
2. Конфиги загружаются в отдельный класс `ConfigsProvider`, и другие объекты получают их через публичные методы.
3. Объекты `Player` и `InAppPackageView` инициализируются с использованием данных из загруженных конфигов.
4. Создание новых объектов `Player` с уже загруженными конфигурациями.
