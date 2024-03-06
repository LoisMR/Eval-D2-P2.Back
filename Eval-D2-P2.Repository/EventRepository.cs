using Eval_D2_P2.DAL;
using Eval_D2_P2.Entity;
using Eval_D2_P2.Repository.Contracts;

namespace Eval_D2_P2.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly EvalDbContext _context;

        public EventRepository(EvalDbContext context)
        {
            _context = context;
        }
        public async Task Add(Event entity)
        {
            this._context.Add(entity);
            await this._context.SaveChangesAsync();
        }
    }
}
