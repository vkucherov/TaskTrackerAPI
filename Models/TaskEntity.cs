﻿namespace TaskTrackerAPI.Models
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = "Pending"; // default
        public string InternalNotes { get; set; } = string.Empty; // not exposed to API
    }
}
