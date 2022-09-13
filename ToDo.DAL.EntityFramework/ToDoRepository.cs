using Common.EntityFramework.Repository;
using Common.Models.Entities;

namespace ToDo.DAL.EntityFramework
{
    public sealed class ToDoRepository<T, TId> : EntityFrameworkSRDRepository<ToDoContext, T, TId>
        where T : EntityBase<TId>
        where TId : IEquatable<TId>
    {
        public ToDoRepository(ToDoContext context) : base(context)
        {
        }
    }
}