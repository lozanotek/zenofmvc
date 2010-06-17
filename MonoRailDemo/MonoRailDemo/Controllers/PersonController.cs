namespace MonoRailDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using Castle.Core.Logging;
    using Castle.MonoRail.Framework;
    using Services;

    [Layout("default"), Rescue("fail")]
    public class PersonController : SmartDispatcherController
    {
        private readonly ILogger logger;
        private readonly IPersonService personService;

        public PersonController(IPersonService service, 
            ILogger logger)
        {
            personService = service;
            this.logger = logger;
        }

        public void Index()
        {
            List<PersonData> list = personService.GetPeople();
            PropertyBag["personList"] = list;

            LogMessage("index", "Found " + list.Count + " people!");
        }

        public void Edit(string id)
        {
            PersonData person = personService.FindById(id);
            PropertyBag["person"] = person;

            LogMessage("edit", "Editing person with id " + id);
        }

        public void Update([DataBind("person")] PersonData person)
        {
            try
            {
                personService.Save(person);

                LogMessage("update", "Updated person with id " + person.Id);
                RedirectToAction("index");
            }
            catch (Exception ex)
            {
                var values = new NameValueCollection {{"id", person.Id}};
                HandleException(person, ex, "edit", values);
            }
        }

        public void New()
        {
        }

        public void Create([DataBind("person")] PersonData person)
        {
            try
            {
                personService.CreateNewPerson(person);

                LogMessage("create", "Created person with id " + person.Id);

                RedirectToAction("index");
            }
            catch (Exception ex)
            {
                var values = new NameValueCollection {{"id", person.Id}};
                HandleException(person, ex, "new", values);
            }
        }

        public void Delete(string id)
        {
            personService.Delete(id);
            LogMessage("delete", "Deleted person with id " + id);

            RedirectToAction("index");
        }

        public void CauseError()
        {
            throw new Exception("Forced exception to test Rescue");
        }

        private void HandleException(PersonData person, Exception ex, string action,
                                     NameValueCollection queryStringParams)
        {
            Flash["error"] = ex.Message;
            Flash["person"] = person;

            RedirectToAction(action, queryStringParams);
        }

        private void LogMessage(string action, string message)
        {
            string msgFormat = "Message from action '{0}':\n{1}";
            logger.InfoFormat(msgFormat, action, message);
        }
    }
}