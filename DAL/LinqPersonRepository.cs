namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Model;

    public class LinqPersonRepository : IPersonRepository
    {
        private static readonly List<Person> personList = CreatePersonList();

        #region IPersonRepository Members

        public IList<Person> GetAll()
        {
            return personList;
        }

        public Person GetById(string id)
        {
            IEnumerable<Person> found = PerformSearch(p => p.Id == id);

            return found.First();
        }

        public IList<Person> GetByFirstName(string firstName)
        {
            IEnumerable<Person> found = PerformSearch(p => p.FirstName == firstName);

            return found.ToList();
        }

        public IList<Person> GetByLastName(string lastName)
        {
            IEnumerable<Person> found = PerformSearch(p => p.LastName == lastName);

            return found.ToList();
        }

        public void Create(Person p)
        {
            if (p == null) return;

            p.Id = KeyGenerator.GenerateUniqueKey();
            personList.Add(p);
        }

        public void Delete(Person p)
        {
            if (p != null)
            {
                personList.Remove(p);
            }
        }

        public void Update(Person p)
        {
            if (p == null) return;

            int index = personList.FindIndex(obj => obj.Equals(p));

            if (index != -1)
            {
                personList[index] = p;
            }
        }

        #endregion

        private static List<Person> CreatePersonList()
        {
            var list = new List<Person>();
            string[] firstNames = { "Jim", "John", "Steve" };
            string[] lastNames = { "Smith", "Jones", "Miller" };

            for (int i = 0; i < 12; i++)
            {
                int mod = i % 3;
                var p = new Person
                {
                    Id = KeyGenerator.GenerateUniqueKey(),
                    FirstName = firstNames[mod],
                    LastName = lastNames[mod],
                    Birthdate = DateTime.Now
                };

                list.Add(p);
            }

            return list;
        }

        private static IEnumerable<Person> PerformSearch(Func<Person, bool> func)
        {
            return from p in personList
                   where func(p)
                   select p;
        }
    }
}