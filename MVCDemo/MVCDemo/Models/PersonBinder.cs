namespace MVCDemo.Models
{
    using System;
    using System.Collections.Specialized;
    using System.Web.Mvc;
    using Services;

    public class PersonBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            NameValueCollection form = controllerContext.HttpContext.Request.Form;
            string id = form["id"];
            string firstName = form["firstName"];
            string lastName = form["lastName"];

            string bday = form["birthDate"];
            DateTime birthdate = string.IsNullOrEmpty(bday) ? DateTime.Now : DateTime.Parse(bday);

            return new PersonData
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthdate
            };
        }
    }
}