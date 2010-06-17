using System;

namespace WebFormsCurrent {
    using System.Collections.Generic;
    using DAL;
    using Model;

    //
    // This technically should be the "controller", however,
    // this code has 'intimate' knowledge of the elements
    // from the view.  Thus making it, not a clear separation of concerns.
    //
    public partial class _Default : System.Web.UI.Page {
        private readonly IPersonRepository personRepo;

        public _Default()
            : this(new LinqPersonRepository())
        {
        }

        public _Default(IPersonRepository repo) {
            personRepo = repo;
        }

        protected void Page_Load(object sender, EventArgs e) {
            if(!IsPostBack) {
                BindGridView();
            }
        }

        private void BindGridView() {
            IList<Person> list = personRepo.GetAll();

            personGridView.DataSource = list;
            personGridView.DataBind();
        }
    }
}
