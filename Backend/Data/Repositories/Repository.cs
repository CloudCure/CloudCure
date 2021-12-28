using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;

//Grouping of classes for data access functionality
namespace Data
{
    //Inherits methods from Repository Interface where TEntity can be any model 
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        //Repository can only be defined in its Constructor
        readonly CloudCureDbContext _context;

        //Constructor sets Repository class with DbContext class for database access
        public Repository(CloudCureDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Sets model TEntity, creates new entity in memory
        /// </summary>
        /// <param name="entity">Model entity</param>
        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Sets model TEntity, returns all db entries in table
        /// </summary>
        /// <returns>IEnumerable<TEntity></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        /// <summary>
        /// Sets model TEntity, returns exact match from db
        /// </summary>
        /// <param name="query">Table primary key (int)</param>
        /// <returns>TEntity[id]</returns>
        public TEntity GetById(int query)
        {
            return _context.Set<TEntity>().Find(query);
        }

        /// <summary>
        /// Sets model TEntity, updates entity in memory
        /// </summary>
        /// <param name="entity">Model</param>
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Sets model TEntity, deletes model from memory
        /// </summary>
        /// <param name="entity">Model</param>
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Saves changes to db
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
