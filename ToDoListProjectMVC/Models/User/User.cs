﻿namespace ToDoListProjectMVC.Models
{
    public class User
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public IEnumerable<Tasks>? TaskUser { get; set; }

        
        public User(string name, string email)
        {
            Name = name;
            Email = email;
          

        }
        public User()
        {
                
        }

    }
}
