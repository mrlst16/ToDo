using ToDo.Interfaces;
using ToDo.Models;
using ToDo.Models.Enums;

namespace ToDo.BLL
{
    public class ToDoItemProvider : IToDoItemProvider
    {
        private readonly IToDoItemLoader _loader;
        private readonly IToDoListLoader _listLoader;

        public ToDoItemProvider(
            IToDoItemLoader loader,
            IToDoListLoader listLoader
            )
        {
            _loader = loader;
            _listLoader = listLoader;
        }

        public async Task<IEnumerable<ToDoItem>> GetAllToDosForUser(int userId)
        {
            var lists = await _listLoader.GetAllListsForUser(userId);
            List<ToDoItem> result = new();

            await Parallel.ForEachAsync(lists, async (list, token) =>
            {
                result.AddRange(list.Items);
            });
            return result;
        }

        public async Task<int> SaveAsync(ToDoItem item)
            => await _loader.SaveAsync(item);

        public async Task<int> UpdateLabel(int id, string label)
        {
            var item = await _loader.ReadAsync(id);
            item.Label = label;
            return await _loader.SaveAsync(item);
        }

        public async Task<int> UpdateStatus(int id, ToDoListStatusEnum status)
        {
            var item = await _loader.ReadAsync(id);
            item.Status = status;
            return await _loader.SaveAsync(item);
        }

        public async Task<bool> SoftDeleteAsync(int id)
            => await _loader.SoftDeleteAsync(id);

        public async Task<IEnumerable<ToDoItem>> GetAllToDosForList(int listId)
            => await _loader.GetAllToDosForList(listId);
    }
}
