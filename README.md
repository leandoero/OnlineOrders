# OnlineOrders

## 📌 О проекте
OnlineOrders – это API для управления заказами, клиентами и продуктами. Проект разработан с использованием **ASP.NET Core** и **Entity Framework**, а также поддерживает **PostgreSQL** и **Docker**.

## 🚀 Возможности
- 📦 Управление заказами
- 🛍 Управление продуктами
- 👥 Управление клиентами
- 🗄 Поддержка **PostgreSQL**
- 📡 Развертывание через **Docker**

## 🛠 Технологии
- **C# / ASP.NET Core** – backend
- **Entity Framework Core** – ORM
- **PostgreSQL** – база данных
- **Docker** – контейнеризация

## 📂 Структура проекта
```plaintext
OnlineOrders/
├── Controllers/               # Контроллеры API
├── Data/                      # Доступ к данным и контекст базы данных
├── Mappings/                  # Маппинг моделей
├── Migrations/                # Миграции базы данных
├── Models/                    # Определение моделей данных
├── Properties/                # Свойства проекта
├── Repository/                # Репозиторий для работы с данными
├── OnlineOrders.csproj        # Файл проекта C#
├── OnlineOrders.http          # Файл запросов HTTP
├── Program.cs                 # Точка входа в приложение
├── appsettings.Development.json # Конфигурация для режима разработки
└── appsettings.json           # Основной файл конфигурации
```

## 📌 Использование API
### 🔹 Документация OpenAPI (Swagger)
После запуска API документация будет доступна по адресу:
```
http://localhost:____/swagger
```

Примеры API-запросов:
#### ➤ Получение списка клиентов
```http
GET /api/client
```
#### ➤ Создание продукта
```http
POST /api/product
Content-Type: application/json
{
  "name": "string",
  "description": "string",
  "price": 0.01
}
```

## ✅ Планы на будущее
- [ ] Добавить аутентификацию и авторизацию
- [ ] Реализовать фронтенд-интерфейс

## 👤 Автор
- **GitHub:** [leandoero](https://github.com/leandoero)
