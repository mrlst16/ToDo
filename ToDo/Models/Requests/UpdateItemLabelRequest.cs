namespace ToDo.Models.Requests
{
    public class UpdateItemLabelRequest
    {
        public int ItemId { get; set; }
        public string Label { get; set; }
    }
}
