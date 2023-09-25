using ListApi.Model;

namespace ListApi.IRepositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetTodoItems();
        Task<TodoItem> GetTodoItem(long id);
        Task AddTodoItem(TodoItem todoItem);
        Task UpdateTodoItem(TodoItem todoItem);
        Task DeleteTodoItem(long id);
    }
}
