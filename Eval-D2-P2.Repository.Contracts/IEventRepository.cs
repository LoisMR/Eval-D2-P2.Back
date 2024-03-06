using Eval_D2_P2.Entity;

namespace Eval_D2_P2.Repository.Contracts
{
    public interface IEventRepository
    {
        public Task Add(Event entity);

        public Task<IEnumerable<Event>> GetAll();

        public Task<bool> Update(Event entity, Guid id);

        Task<bool> Delete(Guid id);
    }
}
