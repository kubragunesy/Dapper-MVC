using Dapper;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Data.SqlClient;

namespace DataAccess.Concrete.Dapper
{
    public class DapperPersonDal : IPersonDal
    {
        private readonly string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ProdaDB;Trusted_Connection=true";

        public int Delete(Person person)
        {
            var connection = new SqlConnection(_connectionString);
            return connection.Execute($"DELETE FROM Person WHERE personId = '{person.personId}'");
        }

        public List<Person> GetAll()
        {
            var connection = new SqlConnection(_connectionString);
            return connection.Query<Person>("SELECT * FROM Person").AsList();
        }

        public Person GetById(int id)
        {
            var connection = new SqlConnection(_connectionString);
            return connection.QuerySingleOrDefault<Person>($"SELECT * FROM Person WHERE personId= '{id}'");
        }

        public int Insert(Person person)
        {
          
            var connection = new SqlConnection(_connectionString);
            var query = $"INSERT INTO Person VALUES (@personName, @personLastName, @personPhone, @personGender, @personEmail, @personImage)";

            var parameters = new DynamicParameters();
            parameters.Add("personName", person.personName);
            parameters.Add("personLastName", person.personLastName);
            parameters.Add("personPhone", person.personPhone);
            parameters.Add("personGender", person.personGender);
            parameters.Add("personEmail", person.personEmail);
            parameters.Add("personImage", person.personImage);

            return connection.Execute(query, parameters);
        }

        public int Update(Person person)
        {
            var connection = new SqlConnection(_connectionString);
            return connection.Execute($"UPDATE Person SET {nameof(Person.personName)} = '{person.personName}', {nameof(Person.personLastName)} = '{person.personLastName}', {nameof(Person.personGender)} = '{person.personGender}',{nameof(Person.personEmail)} = '{person.personEmail}',{nameof(Person.personPhone)} = '{person.personPhone}',{nameof(Person.personImage)} = '{person.personImage}' WHERE personId = '{person.personId}'");
        }
    }
}