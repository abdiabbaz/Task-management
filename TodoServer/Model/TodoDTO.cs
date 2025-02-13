using TodoLib.Models;

namespace TodoServer.Model
{
    public record TodoDTO(int todoId,string title, string description, PriorityLevel priority, bool isCompleted);
}
