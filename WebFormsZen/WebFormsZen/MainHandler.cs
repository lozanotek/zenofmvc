namespace WebFormsZen
{
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Collections.Generic;
    using System.IO;

    using DAL;
    using Model;

    //
    // This method gets closer to the concept of a controller, however,
    // there is still some tight coupling with the pieces of the view.
    //
    public class MainHandler : IHttpHandler
    {
        private readonly IPersonRepository personRepo;

        public MainHandler()
            : this(new LinqPersonRepository())
        {
        }

        public MainHandler(IPersonRepository repo)
        {
            personRepo = repo;
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            ProcessRequest(context);
        }

        private void ProcessRequest(HttpContext context)
        {
            HtmlGenericControl html = new HtmlGenericControl("html");
            HtmlGenericControl body = new HtmlGenericControl("body");
            GridView grid = BuildPersonGridView();

            body.Controls.Add(grid);
            html.Controls.Add(body);

            TextWriter writer = context.Response.Output;
            HtmlTextWriter htmlWriter = new HtmlTextWriter(writer);
            html.RenderControl(htmlWriter);
        }

        private GridView BuildPersonGridView()
        {
            GridView personView = new GridView();
            IList<Person> list = personRepo.GetAll();

            personView.DataSource = list;
            personView.DataBind();

            return personView;
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}
