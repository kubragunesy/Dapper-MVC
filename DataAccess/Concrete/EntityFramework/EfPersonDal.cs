using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal : IPersonDal
    {
        EfContext efContext = new EfContext();
        DbSet<Person> _object;

        public EfPersonDal()
        {
            _object = efContext.Set<Person>();
        }
        public int Delete(Person person)
        {
            var deletedItem = efContext.Entry(person);
            deletedItem.State = EntityState.Deleted;
            return efContext.SaveChanges();
        }

        public List<Person> GetAll()
        {
            return _object.ToList();
        }

        public Person GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Person person)
        {
            var addedItem = efContext.Entry(person);
            addedItem.State = EntityState.Added;
            return efContext.SaveChanges();
        }

        public int Update(Person person)
        {
            var updatedItem = efContext.Entry(person);
            updatedItem.State = EntityState.Modified;
            return efContext.SaveChanges();
        }
    }
}
