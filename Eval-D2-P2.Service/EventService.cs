using Eval_D2_P2.Entity;
using Eval_D2_P2.Repository.Contracts;
using Eval_D2_P2.Service.Contracts;

namespace Eval_D2_P2.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task Add(Event entity) => this._eventRepository.Add(entity);

        public Task<IEnumerable<Event>> GetAll() => this._eventRepository.GetAll();

        public Task<bool> Update(Event entity, Guid id) => this._eventRepository.Update(entity, id);
    }
}
