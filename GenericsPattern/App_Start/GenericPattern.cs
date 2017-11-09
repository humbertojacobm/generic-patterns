using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationInsights.Web;

namespace GenericsPattern.App_Start
{

    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }

    public class EntityOne : IEntity<int>
    {
        public int Id { get; set; }

        // Other model properties...
    }

    public class EntityTwo : IEntity<string>
    {
        public string Id { get; set; }

        // Other model properties...
    }

    public interface IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        //TEntity GetById(TId id);
        object GetById(TId id);
    }

    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : class, IEntity<TId>        
    {
        // Context setup...

        //public virtual TEntity GetById(TId id)
        //{
        //    return context.Set<TEntity>().SingleOrDefault(x => x.Id == id);
        //}

        public virtual object GetById(TId id)
        {
            return new object();
        }
    }

    public class EntityOneRepository : Repository<EntityOne, int>
    {
        // Initialise...
    }

    public class EntityTwoRepository : Repository<EntityTwo, string>
    {
        // Initialise...
    }

    public class GenericPattern
    {
    }
}