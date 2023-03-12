namespace ToDoListProjectMVC.Models
{
    public class Tasks
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime AssignDate { get; set; }
        public int OwnerId { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
      
        public enum StatusList
        {
            Open,
            Close,
            InProgress,
            Done

        }
        public User? User { get; set; }

        public TaskCategory? Category { get; set; }

        public Tasks(string name, string status, DateTime assignDate, int ownerId, int categoryId,
            string ? description=null)
        {
            Name = name;
            Status = status;
            AssignDate = assignDate;
            OwnerId = ownerId;
            CategoryId = categoryId;
            Description = description;
            
        }

        public Tasks()
        {

        }
    }
}
