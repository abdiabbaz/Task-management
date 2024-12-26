using TodoLib.Models;

namespace TodoServer.Model
{
    public static class Converter
    {
        public static ToDo ConvertToDTO(TodoDTO dto)
        {
            ToDo toDo = new ToDo();

            toDo.Title = dto.title;
            toDo.Description = dto.description;
            toDo.Priority = dto.priority;
            toDo.CreatedAt = dto.createdAt;
            toDo.DueDate = dto.dueDate;

            return toDo;
        }

    }
}
