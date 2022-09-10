using ToDo.Models;
using ToDo.Models.Enums;

namespace ToDo.Interfaces
{
    public interface IToDoItemProvider
    {
        //c.Get all TODOS for all lists
        Task<IEnumerable<ToDoItem>> GetAllToDosForUser(int userId);

        //e.Add a TODO
        Task<int> SaveAsync(ToDoItem item);

        //f. Edit a  TODOs label
        Task<int> UpdateLabel(int id, string label);

        //g.Toggle a TODO (This is intentionally vague, interpret this as you wish)
        Task<int> UpdateStatus(int id, ToDoListStatusEnum status);

        //h. Remove a TODO
        Task<bool> SoftDeleteAsync(int id);

        //d.Get all TODOs for specific list
        Task<IEnumerable<ToDoItem>> GetAllToDosForList(int listId);
    }
}
