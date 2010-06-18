namespace MVCDemo2.Controllers {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Web.Mvc;
    using Services;

    public class PersonController : Controller {
        private readonly IPersonService personService;

        public PersonController()
            : this(new PersonService()) {
        }

        public PersonController(IPersonService service) {
            personService = service;
        }

        public ActionResult Index() {
            return View();
        }

        public JsonResult List(TableInputModel inputModel) {
            var peopleList = personService.GetPeople();

            int pageIndex = Convert.ToInt32(inputModel.Page) - 1;
            int pageSize = inputModel.Rows;
            int totalRecords = peopleList.Count;

            int totalPages = (int)Math.Ceiling(totalRecords / (float)pageSize);


            var pagedList = peopleList.AsQueryable()
                .OrderBy(inputModel.Sidx + " " + inputModel.Sord)
                .Skip(pageIndex * pageSize)
                .Take(pageSize);

            var jsonData = new
            {
                total = totalPages,
                page = inputModel.Page,
                records = totalRecords,
                rows = pagedList.ToArray()
            };

            return new CustomJsonResult(jsonData);
        }


        public ActionResult New() {
            return View("CreateNew");
        }

        public ActionResult CreateNew(PersonData personData) {
            personService.CreateNewPerson(personData);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id) {
            PersonData person = personService.FindById(id);
            ViewData["person"] = person;

            return View();
        }

        public ActionResult Update(PersonData person) {
            personService.Save(person);
            return RedirectToAction("index");
        }

        public ActionResult Delete(string id) {
            personService.Delete(id);
            return RedirectToAction("index");
        }

        [HandleError(View = "DisplayError")]
        public ActionResult CauseError() {
            throw new Exception("Forced exception to test Rescue");
        }


    }

}
