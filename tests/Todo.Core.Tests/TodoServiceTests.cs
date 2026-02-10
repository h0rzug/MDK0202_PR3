using Xunit;
using Todo.Core;

namespace Todo.Core.Tests;

public class TodoServiceTests
{
    private readonly TodoService _service;

    public TodoServiceTests()
    {
        _service = new TodoService();
    }

    [Fact]
    public void Add_ShouldIncreaseItemCount()
    {
        _service.Add("Test task");

        Assert.Single(_service.GetAll());
    }

    [Fact]
    public void Add_ShouldReturnItemWithCorrectTitle()
    {
        var item = _service.Add("Buy groceries");

        Assert.Equal("Buy groceries", item.Title);
    }

    [Fact]
    public void Add_ShouldSetIsCompletedToFalse()
    {
        var item = _service.Add("New task");

        Assert.False(item.IsCompleted);
    }

    [Fact]
    public void Remove_ExistingItem_ShouldReturnTrue()
    {
        var item = _service.Add("Task to remove");

        var result = _service.Remove(item.Id);

        Assert.True(result);
        Assert.Empty(_service.GetAll());
    }

    [Fact]
    public void Remove_NonExistingItem_ShouldReturnFalse()
    {
        var result = _service.Remove(999);

        Assert.False(result);
    }

    [Fact]
    public void MarkAsCompleted_ExistingItem_ShouldSetIsCompletedTrue()
    {
        var item = _service.Add("Task to complete");

        var result = _service.MarkAsCompleted(item.Id);

        Assert.True(result);
        Assert.True(_service.GetById(item.Id)!.IsCompleted);
    }

    [Fact]
    public void MarkAsCompleted_NonExistingItem_ShouldReturnFalse()
    {
        var result = _service.MarkAsCompleted(999);

        Assert.False(result);
    }

    [Fact]
    public void GetAll_ShouldReturnAllItems()
    {
        _service.Add("Task 1");
        _service.Add("Task 2");
        _service.Add("Task 3");

        var all = _service.GetAll();

        Assert.Equal(3, all.Count);
    }

    [Fact]
    public void GetById_ExistingItem_ShouldReturnItem()
    {
        var added = _service.Add("Find me");

        var found = _service.GetById(added.Id);

        Assert.NotNull(found);
        Assert.Equal("Find me", found.Title);
    }

    [Fact]
    public void GetById_NonExistingItem_ShouldReturnNull()
    {
        var found = _service.GetById(999);

        Assert.Null(found);
    }

    [Fact]
    public void GetCompletedCount_ShouldReturnCorrectCount()
    {
        _service.Add("Task 1");
        var item2 = _service.Add("Task 2");
        var item3 = _service.Add("Task 3");

        _service.MarkAsCompleted(item2.Id);
        _service.MarkAsCompleted(item3.Id);

        Assert.Equal(2, _service.GetCompletedCount());
    }
}
