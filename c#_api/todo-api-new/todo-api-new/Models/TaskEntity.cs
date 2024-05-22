using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using todo_api_new.Enums;

namespace todo_api_new.Models
{
    public class TaskEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public DateTime date {  get; set; }

        public Priority priority { get; set; } = Priority.normal;

        public Status status { get; set; } = Status.todo;
    }
}