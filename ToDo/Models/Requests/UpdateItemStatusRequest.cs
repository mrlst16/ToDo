using ToDo.Models.Enums;

namespace ToDo.Models.Requests
{
    public class UpdateItemStatusRequest
    {
        public int ItemId { get; set; }
        public ToDoListStatusEnum Status { get; set; }
    }
}
