
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IPersonService
    {
        Person GetById(int id);
        int Insert(Person person);
        int Update(Person person);
        int Delete(Person person);
        List<Person> GetAll();
    }
}
