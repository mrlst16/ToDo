namespace ToDo.Models.Requests
{
    public class CreateItemRequest
    {
        public int ListId { get; set; }
        public string Label { get; set; }
    }
}
