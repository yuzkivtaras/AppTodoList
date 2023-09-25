using ListApi.Data;
using ListApi.IRepositories;
using ListApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ListApi.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetTodoItem(long id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task AddTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTodoItem(TodoItem todoItem)
        {
            _context.Entry(todoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem != null)
            {
                _context.TodoItems.Remove(todoItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
