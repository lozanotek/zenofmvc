namespace WebFormsCurrent {
    using System;
    using DAL;
    using Model;

    public partial class Edit : System.Web.UI.Page {
        private readonly IPersonRepository personRepo;

        public Edit()
            : this(new LinqPersonRepository()) {
        }

        public Edit(IPersonRepository repo) {
            personRepo = repo;
        }

        protected void Page_Load(object sender, EventArgs e) {
            var _personId = Request["personId"];

            if (string.IsNullOrEmpty(_personId)) return;

            if (!IsPostBack) {
                BindModel(_personId);
            }
        }

        private void BindModel(string key) {
            var person = personRepo.GetById(key);
            if (person == null) return;

            firstName.Text = person.FirstName;
            lastName.Text = person.LastName;
            birthDate.Text = person.Birthdate.ToShortDateString();
            personId.Value = person.Id;
        }

        protected void UpdateButton_Click(object sender, EventArgs e) {
            Person updatedPerson = GetPersonFromUI();
            personRepo.Update(updatedPerson);

            Response.Redirect("~/default.aspx");
        }

        private Person GetPersonFromUI() {
            return new Person
            {
                Birthdate = DateTime.Parse(birthDate.Text),
                FirstName = firstName.Text,
                Id = personId.Value,
                LastName = lastName.Text
            };
        }
    }
}
