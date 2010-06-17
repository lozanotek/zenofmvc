namespace Services
{
    using System.Collections.Generic;

    public interface IPersonService
    {
        void CreateNewPerson(PersonData data);
        List<PersonData> GetPeople();
        PersonData FindById(string id);
        void Save(PersonData data);
        void Delete(string id);
    }
}