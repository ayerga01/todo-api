using Microsoft.OpenApi.Extensions;
using todo_api_new.Enums;

namespace todo_api_new.Models.DTOs
{
    public class TaskDto
    {
        public Guid id { get; set; }
        public string title { get; set; }

        public string description { get; set; }

        public DateOnly date { get; set; }

        public string priority { get; set; } = Priority.normal.ToString();
        public string status { get; set; } = Status.todo.ToString();
    }
}
