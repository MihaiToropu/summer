using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SummerCamp.WebAPI.DataAccess;

namespace SummerCamp.WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
         [HttpGet]
        public HttpResponseMessage Get()
        {
            using (SummerCampDbContext ctx = new SummerCampDbContext())
            {
                var data = ctx.Categories.Select(c =>
                        new
                        {
                            Id = c.CategoryId,                         
                            Name = c.Name
                        }).ToList();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, data);
                return response;
            }
        }
    }
}
