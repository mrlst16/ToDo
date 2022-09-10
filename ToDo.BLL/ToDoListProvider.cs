using ToDo.Interfaces;
using ToDo.Models;

namespace ToDo.BLL
{
    public class ToDoListProvider : IToDoListProvider
    {
        private readonly IToDoListLoader _loader;

        public ToDoListProvider(
            IToDoListLoader loader
            )
        {
            _loader = loader;
        }

        public async Task<int> SaveAsync(ToDoList item)
            => await _loader.SaveAsync(item);

        public async Task<IEnumerable<ToDoList>> GetAllListsForUser(int userId)
            => await _loader.GetAllListsForUser(userId);
    }
}
