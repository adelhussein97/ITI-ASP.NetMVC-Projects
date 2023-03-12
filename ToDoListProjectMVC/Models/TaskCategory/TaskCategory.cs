namespace ToDoListProjectMVC.Models
{
    public class TaskCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public IEnumerable<Tasks>? CategoryTasks { get; set; }

        

    }
}
