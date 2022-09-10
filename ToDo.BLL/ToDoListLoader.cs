using Common.Interfaces.Repository;
using ToDo.Interfaces;
using ToDo.Models;

namespace ToDo.BLL
{
    public class ToDoListLoader : IToDoListLoader
    {
        private readonly ISRDRepository<ToDoList, int> _repository;

        public ToDoListLoader(
            ISRDRepository<ToDoList, int> repository
            )
        {
            _repository = repository;
        }

        public async Task<int> SaveAsync(ToDoList item)
            => await _repository.SaveAsync(item);

        public async Task<IEnumerable<ToDoList>> GetAllListsForUser(int userId)
            => await _repository.ReadAsync(x => x.UserId == userId && x.DeletedUTC == null);
    }
}
