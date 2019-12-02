using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sport.Core.Contracts
{
    public interface ISportEventRepository
    {
        //IQueryable<Event> GetActiveEvents();
        IQueryable<Event> GetActiveEvents();
        void Insert(Event @event);
        void Update(string id, Event @event);
        void Delete(string id);
        Event FindEvent(string id);


    }
}
