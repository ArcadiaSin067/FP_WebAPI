using System.Web.Http;
using FP_WebAPI.Models;

namespace FP_WebAPI.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected APIContext db = new APIContext();
    }
}