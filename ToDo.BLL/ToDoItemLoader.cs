using Common.Interfaces.Repository;
using ToDo.Interfaces;
using ToDo.Models;

namespace ToDo.BLL
{
    public class ToDoItemLoader : IToDoItemLoader
    {
        private readonly ISRDRepository<ToDoItem, int> _repository;

        public ToDoItemLoader(
            ISRDRepository<ToDoItem, int> repository
            )
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ToDoItem>> GetAllToDosForList(int listId)
            => await _repository.ReadAsync(x => x.ToDoListId == listId && x.DeletedUTC == null);

        public async Task<ToDoItem> ReadAsync(int id)
            => await _repository.ReadAsync(id);

        public async Task<int> SaveAsync(ToDoItem item)
            => await _repository.SaveAsync(item);

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var item = await _repository.ReadAsync(id);
            if (item == null) throw new Exception($"ToDoItem {id} was not found.");
            item.DeletedUTC = DateTime.UtcNow;
            await _repository.SaveAsync(item);
            return true;
        }
    }
}