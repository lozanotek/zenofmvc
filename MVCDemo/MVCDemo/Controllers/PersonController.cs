namespace MVCDemo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models;
    using Services;

    public class PersonController : Controller
    {
        private readonly IPersonService personService;

        public PersonController()
            : this(new PersonService())
        {
        }

        public PersonController(IPersonService service)
        {
            personService = service;
        }

        public ActionResult Index()
        {
            List<PersonData> people = personService.GetPeople();
            ViewData["people"] = people;

            return View();
        }

        public ActionResult New()
        {
            return View("CreateNew");
        }

        public ActionResult CreateNew([ModelBinder(typeof(PersonBinder))] PersonData personData)
        {
            personService.CreateNewPerson(personData);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            PersonData person = personService.FindById(id);
            ViewData["person"] = person;

            return View();
        }

        public ActionResult Update([ModelBinder(typeof(PersonBinder))] PersonData person)
        {
            personService.Save(person);
            return RedirectToAction("index");
        }

        public ActionResult Delete(string id)
        {
            personService.Delete(id);
            return RedirectToAction("index");
        }

        [HandleError(View = "DisplayError")]
        public ActionResult CauseError()
        {
            throw new Exception("Forced exception to test Rescue");
        }
    }
}
