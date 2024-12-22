using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoLib.Models;

namespace TodoLib.Services
{
    public interface ITodosRepository
    {
        public Task<ToDo> Create(ToDo todo);
        public Task<ToDo> Read(int id);
        public Task<ToDo> Delete(int id);
        public Task<ToDo> Update(int id, ToDo toDo);
        public Task<IEnumerable<ToDo>> GetAll();
    }

}
