<div id="MainTitle">

# Клиентское приложение 

</div>
<div id="SubTitle"> 

### Приложение позволяющее осуществлять трекинг задач

</div>

Клиент-серверное решение состоит из двух приложений : WPF клиент (этот репозиторий) и .NET Core сервера (https://github.com/NoTh0ughts/TaskLiner)
Клиентское приложение позволяет осуществить трекинг задач в проекте и управление проектами внутри компании

---

## Технологический стек:
<div id="TechStack">

* .NET 5.0
* WPF
* MVVM

</div>

## Архитектура приложения
![image](https://user-images.githubusercontent.com/57771719/224716949-2df516f8-033a-44ce-a344-6e6bbca0e509.png)

## Экранные формы
* Авторизация

![image](https://user-images.githubusercontent.com/57771719/224717487-d64b01a3-d7c2-4751-8721-f55c0a9968f7.png)
* Создание компании

![image](https://user-images.githubusercontent.com/57771719/224717724-9da2dd53-d413-47df-b6a3-2d500dcfce29.png)
* Главный экран 

![image](https://user-images.githubusercontent.com/57771719/224717902-9a9e0711-719d-4352-a2ce-b999dd2fab5c.png)


## Как запустить?

1. Скопировать репозиторий коммандой ```git clone https://github.com/NoTh0ughts/TaskLinerClientApp TaskLinerClient```
2. Перейти в консоли в папку с проектом
3. Восстановить зависимости коммандой dotnet restore
4. Запустить клиент dotnet  run
