using Eval_D2_P2.Entity;

namespace Eval_D2_P2.Repository.Contracts
{
    public interface IEventRepository
    {
        public Task Add(Event entity);

        public Task<IEnumerable<Event>> GetAll();
    }
}
