using BlazorLearning.Infra.Data;
using BlazorLearning.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorLearning.Services
{      public class TodoServices : ITodoService
     {
         //readonly -> pode ser modificada somente no construtor 
         private readonly ApplicationDbContext _context;
         public TodoServices(ApplicationDbContext context)
         {
             _context = context;
         }
         public async Task<List<Todo>> GetActiveTodos()
         {
            //Where(e => e.Done == false) -> todo que nao foi finalizado
            //OrderBy(e => e.Priority) -> ordenando por prioridade
            var list = await _context.Todos
                .Where(e => e.Done == false)
                .OrderByDescending(e => e.Priority > 0 ) //-> prioridade vai ser 1 o restante todo 0
                .ThenBy(e => e.Priority) // -> ordenando por prioridade (segundo campo da ordem)
                .ToListAsync();
             return list;
         }

         public async Task NewTodo()
         {
             var todo = new Todo {
                 Title = $"Tarefa {DateTime.Now}",
                 Description = $"Tarefa {DateTime.Now}",
                 CategoryId = 1
             };

             await _context.Todos.AddAsync(todo);
             await _context.SaveChangesAsync();
         }

         public async Task<Todo> Update(Todo todo)
         {
             _context.Todos.Update(todo);
             await _context.SaveChangesAsync();
             return todo; //-> retornamos para apresentar como ficou a alteração do objeto
         }

         public async Task Remove(Todo todo)
         {
             _context.Remove(todo);
             await _context.SaveChangesAsync();
         }
     } 
}
