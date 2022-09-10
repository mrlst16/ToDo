using ToDo.Models;

namespace ToDo.Interfaces
{
    public interface IToDoListProvider
    {
        //a.Add a list
        Task<int> SaveAsync(ToDoList item);

        //b.Get all lists
        Task<IEnumerable<ToDoList>> GetAllListsForUser(int userId);
    }
}
