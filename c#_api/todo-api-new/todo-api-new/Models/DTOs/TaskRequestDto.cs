﻿using todo_api_new.Enums;

namespace todo_api_new.Models.DTOs
{
    public class TaskRequestDto
    {
        public string title { get; set; }

        public string description { get; set; }

        public DateTime date { get; set; }

        public Priority priority { get; set; } = Priority.normal;

        public Status status { get; set; } = Status.todo;
    }
}