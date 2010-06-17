namespace WebFormsCurrent {
    using System;
    using DAL;

    public partial class Delete : System.Web.UI.Page {
        private readonly IPersonRepository personRepo;

        public Delete()
            : this(new LinqPersonRepository()) {
        }

        public Delete(IPersonRepository repo) {
            personRepo = repo;
        }

        protected void Page_Load(object sender, EventArgs e) {
            var _personId = Request["personId"];

            if (!string.IsNullOrEmpty(_personId)) {
                DeletePerson(_personId);
            }

            Response.Redirect("~/default.aspx");
        }

        private void DeletePerson(string key) {
            var person = personRepo.GetById(key);
            personRepo.Delete(person);
        }
    }
}
