
using Business.Service;
using DataAccess.Abstract;
using DataAccess.Concrete.Dapper;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;

namespace Business.Manager
{
    public class PersonManager : IPersonService
    {
        IPersonDal _persondal;
        
        public PersonManager(IPersonDal persondal)
        {
            _persondal = persondal;
        }

        public int Delete(Person person)
        {
            return _persondal.Delete(person);

        }

        public List<Person> GetAll()
        {
            return _persondal.GetAll();
        }

        public int Insert(Person person)
        {
            return _persondal.Insert(person);
        }

        public int Update(Person person)
        {
            return _persondal.Update(person);
        }

        public Person GetById(int id)
        {
            return _persondal.GetById(id);
        }
    }
}
