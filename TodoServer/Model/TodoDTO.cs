using TodoLib.Models;

namespace TodoServer.Model
{
    public record TodoDTO(string title, string description, PriorityLevel priority, bool isCompleted, DateTime createdAt, DateTime? dueDate);
}
