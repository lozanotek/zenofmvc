namespace Services
{
    using System.Collections.Generic;
    using System.Linq;
    using DAL;
    using Model;

    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;

        public PersonService() :
            this(new LinqPersonRepository())
        {
        }

        public PersonService(IPersonRepository repository)
        {
            personRepository = repository;
        }

        #region IPersonService Members

        public void CreateNewPerson(PersonData personData)
        {
            var person = ConvertTo(personData);
            personRepository.Create(person);
        }

        public List<PersonData> GetPeople()
        {
            var list = personRepository.GetAll();
            var temp = list.ToList();
            return temp.ConvertAll(p => ConvertTo(p));
        }

        public PersonData FindById(string id)
        {
            var person = personRepository.GetById(id);
            return ConvertTo(person);
        }

        public void Save(PersonData data)
        {
            var person = ConvertTo(data);
            personRepository.Update(person);
        }

        public void Delete(string id)
        {
            var person = personRepository.GetById(id);
            personRepository.Delete(person);
        }

        private static PersonData ConvertTo(Person p)
        {
            return p == null ? null : new PersonData
                                          {
                                              Id = p.Id,
                                              FirstName = p.FirstName,
                                              LastName = p.LastName,
                                              BirthDate = p.Birthdate
                                          };
        }

        private static Person ConvertTo(PersonData p)
        {
            return p == null ? null : new Person
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Birthdate = p.BirthDate
            };
        }

        #endregion
    }
}
