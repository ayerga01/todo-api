using todo_api_new.Enums;

namespace todo_api_new.Models.DTOs
{
    public class TaskUpdateRequestDto
    {
        public Priority priority { get; set; } = Priority.normal;

        public Status status { get; set; } = Status.todo;
    }
}
