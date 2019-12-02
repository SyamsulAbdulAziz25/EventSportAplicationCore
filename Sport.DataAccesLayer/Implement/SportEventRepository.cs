using Sport.Core;
using Sport.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sport.DataAccesLayer.Implement
{

    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        void Add(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
    }
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SportEventContext db;
        public Repository(SportEventContext db)
        {
            this.db = db;
        }
        public void Add(TEntity item)
        {
            db.Set<TEntity>().Add(item);
            db.SaveChanges();
        }

        public void Delete(TEntity item)
        {
            db.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return db.Set<TEntity>();
        }

        public void Update(TEntity item)
        {
            db.SaveChanges();
        }
    }
    public class SportEventRepository : ISportEventRepository
    {
        private readonly IRepository<Event> repository;

        public enum EventStatus
        {
            Open,
            Close
        }
        public SportEventRepository(IRepository<Event> repository)
        {
            this.repository = repository;
        }
        public IQueryable<Event> GetActiveEvents()
        {
            return repository.GetAll().Where(ev => ev.State_Delete != "IsDeleted");
        }
        public void Insert(Event @event)
        {
            @event.EventStatus = EventStatus.Open.ToString();
            @event.Id = MakeIdEvent();
            @event.State_Delete = "NotDeleted";
            repository.Add(@event);
        }

        public void Update(string id, Event @event)
        {
            var data = repository.GetAll().Where(x => x.Id == id).First();
            data.Price = @event.Price;
            data.Date = @event.Date;
            data.EventStatus = @event.EventStatus;
            repository.Update(data);

        }

        public Event FindEvent(string id)
        {
            var dataEvent = repository.GetAll().Where(x => x.Id == id && x.State_Delete != "IsDeleted").First();
            return dataEvent;

        }

        public String MakeIdEvent()
        {
            String id;
            Event dataEvent = repository.GetAll().OrderByDescending(c => c.Id).FirstOrDefault();
            if (dataEvent == null)
            {
                id = "EVT-0001";
            }
            else
            {
                id = "EVT-" + (Convert.ToInt32(dataEvent.Id.Substring(4, dataEvent.Id.Length - 4)) + 1).ToString("0000");
            }
            return id;
        }

        public void Delete(string id)
        {
            var data = repository.GetAll().Where(x => x.Id == id).First();
            data.State_Delete = "IsDeleted";
            repository.Delete(data);
        }

    }
}
