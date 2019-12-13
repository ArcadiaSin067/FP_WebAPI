using Newtonsoft.Json;
using System.Web.Http;
using FP_WebAPI.Models;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace FP_WebAPI.Controllers
{
    [RoutePrefix("api/Households")]
    public class HouseholdsController : BaseController
    {
        [Route("GetHouseholdDetails")]
        public async Task<Household> GetHouseholdDetails(int id)
        {
            return await db.GetHouseholdDetails(id);
        }

        [Route("GetHouseholdDetailsAsJson")]
        [ResponseType(typeof(Household))]
        public async Task<IHttpActionResult> GetHouseholdDetailsAsJson(int id)
        {
            var data = await db.GetHouseholdDetails(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}