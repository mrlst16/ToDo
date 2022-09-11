using ToDo.Models;

namespace ToDo.Interfaces
{
    public interface IToDoItemLoader
    {
        //c.Get all TODOS for all lists
        //d.Get all TODOs for specific list
        //e.Add a TODO
        //f. Edit a  TODOs label
        //g.Toggle a TODO (This is intentionally vague, interpret this as you wish)
        //h. Remove a TODO

        //This can be used to cover all 3 scenarios
        //Wrap this in the provider to only allow for (id, value) args
        //e.Add a TODO
        //f. Edit a  TODOs label
        //g.Toggle a TODO (This is intentionally vague, interpret this as you wish)
        Task<int> SaveAsync(ToDoItem item);

        //h. Remove a TODO
        Task<bool> SoftDeleteAsync(int id);

        //d.Get all TODOs for specific list
        Task<IEnumerable<ToDoItem>> GetAllToDosForList(int listId);
        Task<ToDoItem> ReadAsync(int id);
        Task<IEnumerable<ToDoItem>> GetAllToDosForUser(int userid);
    }
}