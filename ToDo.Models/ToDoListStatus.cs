using Common.Models.Entities;
using ToDo.Models.Enums;

namespace ToDo.Models
{
    public class ToDoListStatus : EntityBase<int>
    {
        public string Name { get; set; }

        public static implicit operator ToDoListStatusEnum(ToDoListStatus status) => (ToDoListStatusEnum)status.Id;
    }
}
