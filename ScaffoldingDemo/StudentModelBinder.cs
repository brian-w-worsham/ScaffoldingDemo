/*using ScaffoldingDemo.Models;
using System.Web.Mvc;

namespace ScaffoldingDemo
{
    public class StudentModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(StudentUIViewModel))
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;

                int formStudentId = Convert.ToInt32(request.Form.Get("StudentId").ToString());

                string firstName = request.Form.Get("FirstName");
                string lastName = request.Form.Get("lastName");

                string houseNo = request.Form.Get("HouseNo");

                string city = request.Form.Get("City");
                string state = request.Form.Get("state");
                string country = request.Form.Get("Country");
                string department = request.Form.Get("Department");

                int score = Convert.ToInt32(request.Form.Get("Score").ToString());

                return new StudentViewModel
                {
                    StudentId = formStudentId,
                    Address = houseNo + " " + city + " " + state,
                    City = city,
                    State = state,
                    Country = country,
                    Department = department,
                    Score = score
                };
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }

        }
    }
}
*/