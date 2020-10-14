using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace MVCCRUDTEST.Models
{   
	public  class MemeberRepository : EFRepository<Memeber>, IMemeberRepository
	{
        public IQueryable<Memeber> GetAll()
        {
            IQueryable<Memeber> Result = base.All().AsNoTracking();
            return Result.OrderBy(o => o.Id);
        }

        public Memeber Find(int? Id)
        {
            return GetAll().Where(o => o.Id == Id).SingleOrDefault();
        }

        public override void Delete(Memeber entity)
        {
            UnitOfWork.Context.Entry(entity).State = EntityState.Deleted;
            UnitOfWork.Commit();
        }

        public void Update(Memeber entity)
        {
            UnitOfWork.Context.Entry(entity).State = EntityState.Modified;
            UnitOfWork.Commit();
        }

        public void Insert(Memeber entity)
        {
            Add(entity);
            UnitOfWork.Commit();
        }
    }

	public  interface IMemeberRepository : IRepository<Memeber>
	{

	}
}