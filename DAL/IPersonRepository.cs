namespace DAL {
    using System.Collections.Generic;
    using Model;

    public interface IPersonRepository {
        IList<Person> GetAll();
        Person GetById(string id);
        IList<Person> GetByFirstName(string firstName);
        IList<Person> GetByLastName(string lastName);

        void Create(Person p);
        void Delete(Person p);
        void Update(Person p);
    }
}
