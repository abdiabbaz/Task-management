using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoLib.Models;

namespace TodoLib.Services
{
    public class TodosRepository : ITodosRepository
    {

        private ItemContext _itemContext;

        public TodosRepository()
        {
            _itemContext = new ItemContext();
        }

        public async Task<ToDo> Create(ToDo todo)
        {
            _itemContext.ToDos.Add(todo);
            await _itemContext.SaveChangesAsync();
            return todo;
        }

        public async Task<ToDo> Read(int id)
        {
           var item = await _itemContext.ToDos.FirstOrDefaultAsync(x => x.TodoId == id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Todo with ID {id} was not found.");
            }
            return item;
        }

        public async Task<ToDo> Delete(int id)
        {
            var todoToBeDeleted = await Read(id);

            _itemContext.ToDos.Remove(todoToBeDeleted);

            await _itemContext.SaveChangesAsync();

            return todoToBeDeleted;
        }

        public async Task<ToDo> Update(int id, ToDo toDo)
        {
            var todoToBeUpdated = await Read(id);

            todoToBeUpdated.Title = toDo.Title;
            todoToBeUpdated.Description = toDo.Description;
            todoToBeUpdated.IsCompleted = toDo.IsCompleted;
            todoToBeUpdated.Priority = toDo.Priority;   

            await _itemContext.SaveChangesAsync();
            return toDo;
        }

        public async Task<IEnumerable<ToDo>> GetAll()
        {
            return await _itemContext.ToDos.ToListAsync();
        }

        public async Task<IEnumerable<ToDo>> FilterAllCompleted()
        {
            return await _itemContext.ToDos.Where(x => x.IsCompleted == true).ToListAsync();
        }


        public async Task<IEnumerable<ToDo>> FilterAllNotCompleted()
        {
            return await _itemContext.ToDos.Where(x => x.IsCompleted == false).ToListAsync();
        }

        public async Task<IEnumerable<ToDo>> FilterByPriority(PriorityLevel priority)
        {
            return await _itemContext.ToDos.Where(x => x.Priority == priority).ToListAsync();
        }




    }
}
