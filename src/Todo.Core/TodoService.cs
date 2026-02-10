namespace Todo.Core;

public class TodoService
{
    private readonly List<TodoItem> _items = new();
    private int _nextId = 1;

    public TodoItem Add(string title)
    {
        var item = new TodoItem
        {
            Id = _nextId++,
            Title = title,
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow
        };

        _items.Add(item);
        return item;
    }

    public bool Remove(int id)
    {
        var item = _items.Find(i => i.Id == id);
        if (item is null)
            return false;

        _items.Remove(item);
        return true;
    }

    public bool MarkAsCompleted(int id)
    {
        var item = _items.Find(i => i.Id == id);
        if (item is null)
            return false;

        item.IsCompleted = true;
        return true;
    }

    public IReadOnlyList<TodoItem> GetAll()
    {
        return _items.AsReadOnly();
    }

    public TodoItem? GetById(int id)
    {
        return _items.Find(i => i.Id == id);
    }

    public int GetCompletedCount()
    {
        return _items.Count(i => i.IsCompleted);
    }
}
