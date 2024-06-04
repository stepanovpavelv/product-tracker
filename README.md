# product-tracker
This web application helps to track the expiration date of products.

Для создания новой миграции:
dbmate -d "./src/ProductTracker.Infrastructure/DB/Migrations" -u "postgres://postgres:12345@localhost:5432/products-lab?sslmode=disable" new имя_миграции

Скаффолдинг, генерация моделей БД:
dotnet linq2db scaffold -i "./src/ProductTracker.Infrastructure/database.json" -c "Server=localhost;Port=5432;User ID=postgres;Password=12345;Database=products-lab;"