using todo_api_new.Enums;

namespace todo_api_new.Models.DTOs
{
    public class TaskUpdateRequestDto
    {
        public Guid id { get; set; }
        public string status { get; set; } = Status.todo.ToString();
    }
}
