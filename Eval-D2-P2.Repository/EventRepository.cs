using Eval_D2_P2.DAL;
using Eval_D2_P2.Entity;
using Eval_D2_P2.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

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

        public async Task<bool> Delete(Guid id)
        {
            var eventToDelete = await this._context.Events.FindAsync(id);

            if (eventToDelete == null)
            {
                return false;
            }
            else
            {
                this._context.Events.Remove(eventToDelete);
                await this._context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<IEnumerable<Event>> GetAll() 
            => await this._context.Events.ToListAsync();

        public async Task<bool> Update(Event entity, Guid id)
        {
            var theEvent = await this._context.Events.FindAsync(id);

            if (theEvent == null)
            {
                return false;
            }
            else
            {
                theEvent.Title = entity.Title;
                theEvent.Description = entity.Description;
                theEvent.Date = entity.Date;
                theEvent.Location = entity.Location;

                await this._context.SaveChangesAsync();

                return true;
            }
        }

    }
}
