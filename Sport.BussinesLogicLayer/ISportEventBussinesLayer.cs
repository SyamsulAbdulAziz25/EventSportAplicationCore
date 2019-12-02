using System;
using System.Collections.Generic;
using System.Text;
using Sport.Core;
using Sport.Core.Output;

namespace Sport.BussinesLogicLayer
{
    public interface ISportEventBussinesLayer
    {
        IEnumerable<SportEventOutput> GetActiveEvents();
        SportEventOutput FindUser(string id);
        Event FindUserForDelete(string id);
        IEnumerable<Event> GetActiveAllEvents();
        void InsertUser(Event @event);
        void UpdateUser(string id, SportEventOutput @sportEventOutput);
        void DeleteUser(String id);
    }
}
