namespace WebFormsCurrent {
    using System;
    using DAL;
    using Model;

    public partial class CreateNew : System.Web.UI.Page {

        private readonly IPersonRepository personRepo;

        public CreateNew()
            : this(new LinqPersonRepository()) {
        }

        public CreateNew(IPersonRepository repo) {
            personRepo = repo;
        }

        
        protected void CreateButton_Click(object sender, EventArgs e) {
            CreatePerson();
        }

        private void CreatePerson() {
            var newPerson = GetPersonFromUI();
            personRepo.Create(newPerson);

            Response.Redirect("~/default.aspx");
        }

        private Person GetPersonFromUI() {
            return new Person
            {
                Birthdate = DateTime.Parse(birthDate.Text),
                FirstName = firstName.Text,
                LastName = lastName.Text
            };
        }
    }
}
