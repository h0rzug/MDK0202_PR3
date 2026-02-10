## Фичи

- **Добавление задачи**
- **Удаление задачи**
- **Отметка выполненной**
- **Получение всех задач**
- **Поиск по ID**

## Структура

```
MDK0202_PR3/
├── src/Todo.Core/           # библиотека классов
├── tests/Todo.Core.Tests/   # xUnit
├── .github/workflows/       # CI/CD
└── Todo.sln
```
### установка пакета

```bash
dotnet add package Todo.Core --version 1.0.0
```
## CI/CD
- **CI** (`ci.yml`)
- **Publish** (`publish-package.yml`)