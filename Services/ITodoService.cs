using BlazorLearning.Model;

namespace BlazorLearning.Services
{
    public interface ITodoService
    {
         Task<List<Todo>> GetActiveTodos();
         Task NewTodo();
         Task<Todo> Update(Todo todo);
         Task Remove(Todo todo);
         
    }
}
