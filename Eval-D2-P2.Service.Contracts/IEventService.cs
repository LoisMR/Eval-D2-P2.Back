using Eval_D2_P2.Entity;

namespace Eval_D2_P2.Service.Contracts
{
    public interface IEventService
    {
        public Task Add(Event entity);

        public Task<IEnumerable<Event>> GetAll();

        public Task<bool> Update(Event entity, Guid id);

        public Task<bool> Delete(Guid id);
    }
}
