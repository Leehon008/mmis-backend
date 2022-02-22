using MMIS.DataAccessLayer.Shared.Contracts;
using MMIS.DomainLayer.Entities.Shared.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using MMIS.DomainLayer.Entities.Users;

namespace MMIS.DataAccessLayer.Shared
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MMISDbContext _dbContext;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(MMISDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public void UpdateItem(string id)
        {
             var commandText = "UPDATE ShiftMeetingActionItems SET status = 'Completed' Where TaskNo = @TaskNo";
             var name = new SqlParameter("@TaskNo", id);
             _dbContext.Database.ExecuteSqlRaw(commandText, name);

        }

        public void EndShift(string id,string status )
        {
    
            var commandText = "UPDATE ShiftHeader SET StatusId = @status Where ShiftNo = @shiftNo";
            var name = new SqlParameter("@shiftNo", id);
            var st = new SqlParameter("@status", status);
            _dbContext.Database.ExecuteSqlRaw(commandText, name,st);

        }



        public void UpdateWA(string id)
        {
            var commandText = "UPDATE Inspections SET status = 'Done' Where Id = @Id";
            var name = new SqlParameter("@Id", id);
            _dbContext.Database.ExecuteSqlRaw(commandText, name);

        }

        //public UserProfilevw GetProfile(string id)
        //    {
        //      UserProfilevw user = _dbContext.UserProfilevw.FromSqlRaw("SELECT * FROM dbo.UserProfilevw").Where(a=>a.UserName == id) as UserProfilevw;
        //      return user; 

        //    }

        public void Add(List<TEntity> entity)
        {
            foreach (var x in entity)
            {
                if (entity is IEntity entityAudit)
                {
                    entityAudit.DateCreated = DateTime.Now;
                    entityAudit.DateModified = DateTime.Now;
                }

                DbSet.Add(x);
            }
        }
        public void Add(TEntity entity)
        {
            if (entity is IEntity entityAudit)
            {
                entityAudit.DateCreated = DateTime.Now;
                entityAudit.DateModified = DateTime.Now;
            }

            DbSet.Add(entity);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity is IEntity entityAudit)
            {
                entityAudit.DateCreated = DateTime.Now;
                entityAudit.DateModified = DateTime.Now;
            }
            await DbSet.AddAsync(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            if (entity is IEntity entityAudit)
            {
                entityAudit.Active = true;
            }
            Update(entity);
        }

        public Task<List<TEntity>> GetAll()
        {
            return DbSet.ToListAsync();
        }

        public IQueryable<TEntity> GetAll(Func<TEntity, bool> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params object[] includes)
        {
            var query = DbSet.Where(filter).AsQueryable();
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(x => include);
                }
            }

            return query;
        }
       
        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public TEntity GetByStingId(string id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, bool>> filter2 = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            

            if (filter != null && filter2 != null)
            {
               
                query = query.Where(filter);
                query = query.Where(filter2);

            }

            foreach (var includeProperty in includeProperties.Split
           (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public async Task<List<TEntity>> GetByName(string id)
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            if (entity is IEntity entityAudit)
            {
                entityAudit.DateModified = DateTime.Now;
            }
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity is IEntity entityAudit)
            {
                entityAudit.DateModified = DateTime.Now;
            }

            DbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
