namespace ToDo.Models.Requests
{
    public class CreateListRequest
    {
        public int UserId { get; set; }
        public string Label { get; set; }
    }
}
