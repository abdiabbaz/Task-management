using TodoLib.Models;

namespace TodoServer.Model
{
    public static class Converter
    {
        public static ToDo ConvertToDTO(TodoDTO dto)
        {
            ToDo toDo = new ToDo();

            toDo.TodoId = dto.todoId;
            toDo.Title = dto.title;
            toDo.Description = dto.description;
            toDo.Priority = dto.priority;

            return toDo;
        }

    }
}
