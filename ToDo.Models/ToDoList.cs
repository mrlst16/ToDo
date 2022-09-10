using Common.Models.Entities;

namespace ToDo.Models
{
    public class ToDoList : EntityBase<int>
    {
        public int UserId { get; set; }
        public string Label { get; set; }
        public IEnumerable<ToDoItem> Items { get; set; }
    }
}