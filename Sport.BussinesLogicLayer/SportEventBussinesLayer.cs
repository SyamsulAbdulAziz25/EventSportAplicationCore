using AutoMapper;
using Sport.Core;
using Sport.Core.Contracts;
using Sport.Core.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sport.BussinesLogicLayer
{
    public class SportEventBussinesLayer : ISportEventBussinesLayer
    {
        private readonly ISportEventRepository sportEventRepository;
        private readonly IMapper mapper;

        public SportEventBussinesLayer(ISportEventRepository sportEventRepository, IMapper mapper)
        {
            this.sportEventRepository = sportEventRepository;
            this.mapper = mapper;
        }

        public IEnumerable<Event> GetActiveAllEvents()
        {

            return sportEventRepository.GetActiveEvents();
        }

        public void InsertUser(Event @event)
        {
            sportEventRepository.Insert(@event);
        }

        IEnumerable<SportEventOutput> ISportEventBussinesLayer.GetActiveEvents()
        {
            var result = mapper.Map<IEnumerable<SportEventOutput>>(sportEventRepository.GetActiveEvents());
            return result;
        }
        public void UpdateUser(string id, SportEventOutput sportEventOutput)
        {
            var dataEvent = mapper.Map<Event>(sportEventOutput);
            sportEventRepository.Update(id, dataEvent);
        }
        public void DeleteUser(string id)
        {
            sportEventRepository.Delete(id);
        }

        public SportEventOutput FindUser(string id)
        {
            var dataEvent = mapper.Map<SportEventOutput>(sportEventRepository.FindEvent(id));
            return dataEvent;
        }
        public Event FindUserForDelete(string id)
        {
            return sportEventRepository.FindEvent(id);
        }
    }
}
