# Addressables 🚀 in Unity
## Task:
Поставить [unityPackage](https://drive.google.com/file/d/1rO4Vnujsu2mzXQNpzaIk6PoJWlRlY5xu/view?usp=drive_link) в пустой проект.
Вынести данные, хранящиеся в скриптах `InAppPackageView` и `Player` в отдельные конфиги. Конфиги создать с помощью Scriptable Objects. Добавить их в Addressables.
Организовать загрузку и cериализацию конфигов из адрессаблов в скриптах, а также прокидывание конфигов через инспектор(AssetReference). 

## Требования: 
Объекты сцены `Player` и `Shop` должны сохранить свою функциональность (использование данных). Создаваемый в реальном времени `Player` тоже должен сохранить свою функциональность. 
Конфиги должны быть типизированными - `PlayerConfig`, `InAppPackageConfig`.

## Инструкция: 
на Z открыть-закрыть объект Shop, на X создать нового Player.


## Выполнение:
Были созданы классы конфигов:
-  [PlayerConfig.cs](https://github.com/BashkaCoder/Unity_practice_7/blob/AssetReference/Assets/Scripts/PlayerConfig.cs)
-  [InAppPackageConfig.cs](https://github.com/BashkaCoder/Unity_practice_7/blob/AssetReference/Assets/Scripts/InAppPackageConfig.cs)

Загрузка конфигов и инициализация объектов происходит в:
- [Bootstrap.cs](https://github.com/BashkaCoder/Unity_practice_7/blob/AssetReference/Assets/Scripts/Bootstrap.cs)
  

## Использованные инструменты
- [Addressables](https://docs.unity3d.com/Manual/com.unity.addressables.html)

## Список проведенной работы:
- Создал типизированные конфиги(префабы экземпляров Scriptable Object)
- Пометил конфиги, как `Addressables`
- Сбилдил ассеты в окне `Addressables Groups`
- Запустил приложение в режиме `Use existing build`(используются именно сбилдженные ассеты) - все работает гуд
