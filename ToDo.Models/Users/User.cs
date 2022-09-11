﻿using Common.Models.Entities;

namespace ToDo.Models.Users
{
    public class User : EntityBase<int>
    {
        public string UserName { get; set; }
        public string ExternalId { get; set; }
        public IEnumerable<ToDoList> Lists { get; set; }
    }
}
