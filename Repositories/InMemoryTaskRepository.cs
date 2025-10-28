using TaskTrackerAPI.Models;

namespace TaskTrackerAPI.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<TaskEntity> _tasks = new();
        private int _nextId = 1;

        public IEnumerable<TaskEntity> GetAll() => _tasks;

        public TaskEntity? GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

        public void Add(TaskEntity task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
        }

        public void Update(TaskEntity task)
        {
            var existing = GetById(task.Id);
            if (existing != null)
            {
                existing.Title = task.Title;
                existing.Description = task.Description;
                existing.DueDate = task.DueDate;
                existing.Status = task.Status;
            }
        }

        public void Delete(int id)
        {
            var task = GetById(id);
            if (task != null)
                _tasks.Remove(task);
        }
    }
}
