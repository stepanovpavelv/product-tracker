# Product-tracker
Приложение Product's tracker было для отслеживания сроков годности продуктов.

## Содержание
- [Технологии](#технологии)
- [Начало работы](#начало-работы)
- [Deploy и CI/CD](#deploy-и-ci/cd)
- [Contributing](#contributing)
- [To do](#to-do)
- [Команда проекта](#команда-проекта)

## Технологии
- [NET 8](https://dotnet.microsoft.com/ru-ru/)
- Mediatr
- [Ardalis Result](https://result.ardalis.com/getting-started/)
- [Fluent Validation](https://docs.fluentvalidation.net/en/latest/)
- [Riok.Mapperly](https://mapperly.riok.app/)
- [Linq2Db](https://github.com/linq2db/linq2db)
- [Hangfire](https://www.hangfire.io/)

## Использование
Почему был выбран Riok.Mapperly - https://github.com/mjebrahimi/DotNet-Mappers-Benchmark

Для использования проекта - скачайте, соберите и запустите (либо через IDE, либо командой). Подробно об этом будет рассказано ниже.

## Разработка

### Требования
Для установки и запуска проекта, необходим [NET 8](https://dotnet.microsoft.com/ru-ru/download/dotnet/8.0).

### Установка зависимостей
Для установки зависимостей на ОС Windows x64, перейдите в директорию с решением и выполните команду:
```sh
$ dotnet restore --no-cache --force --runtime win-x64
```

Для установки зависимостей на ОС Linux x64, выполните команду:
```sh
$ dotnet restore --no-cache --force --runtime linux-x64
```

### Создание новой миграции
Команда:
```sh
dbmate -d "./src/ProductTracker.Infrastructure/DB/Migrations" -u "postgres://postgres:12345@localhost:5432/products-lab?sslmode=disable" new имя_миграции
```

### Скаффолдинг
Команда генерация моделей БД:
```sh
$ dotnet linq2db scaffold -i "./src/ProductTracker.Infrastructure/database.json" -c "Server=localhost;Port=5432;User ID=postgres;Password=12345;Database=products-lab;"
```

### Создание билда
Чтобы выполнить билд исходного кода, выполните команду: 
```sh
$ dotnet build --no-cache --force --runtime linux-x64
```

### Запуск приложения
Чтобы запустить приложение, выполните команду:
```sh
$ dotnet run --force --no-restore --project .\src\ProductTracker.Web.csproj
```

## Deploy и CI/CD
Деплой приложения происходит в пункте "Создание билда"

## Contributing
Если вы хотите помочь в разработке проекта, то можно доработку в виде оформленного pull request. Можно предложения вынести в отдельный файл — [Contributing.md](./CONTRIBUTING.md).

### Зачем был разработан данный проект?
Для оптимизации личных покупок продуктов и лекарств, т.к. большая часть приобретаемых товар имеет свой срок годности.

## To do
- [x] Добавить README
- [ ] Реализовать недостающие crud-ы
- [ ] Сделать джобы для отслеживания сроков годности
- [ ] Реализовать интеграцию с Честный Знак
- [ ] Сделать уведомления о приближающемся сроке годности
- [ ] Добавить тесты

## Команда проекта
Контакты с командой разработки:

- [Павел Степанов](https://t.me/stepanovpavelv) — Backen-End Engineer

## Источники
Был вдохновлен кол-вом испорченных продуктов, которые периодически выбрасываются из холодильника :)