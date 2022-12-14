using System.Web.Http;

namespace PruebaTecnica.Controllers
{
    /// <summary>
    /// admin controller class for testing security token with role admin
    /// </summary>
    [Authorize(Roles = "Administrator")]
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            var adminFake = "admin-fake: " + id;
            return Ok(adminFake);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var adminList = new string[] { "admin-1", "admin-2", "admin-3" };
            return Ok(adminList);
        }
    }
}
