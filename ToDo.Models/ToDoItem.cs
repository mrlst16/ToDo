using Common.Models.Entities;
using ToDo.Models.Enums;

namespace ToDo.Models
{
    public class ToDoItem : EntityBase<int>
    {
        public int ToDoListId { get; set; }
        public string Label { get; set; }
        public int Priority { get; set; }
        public ToDoListStatusEnum Status { get; set; }
    }
}
