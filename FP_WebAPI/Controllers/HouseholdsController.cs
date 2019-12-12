using Newtonsoft.Json;
using System.Web.Http;
using FP_WebAPI.Models;
using System.Threading.Tasks;

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
        public async Task<IHttpActionResult> GetHouseholdDetailsAsJson(int id)
        {
            var data = await db.GetHouseholdDetails(id);
            return Json(data, new JsonSerializerSettings { Formatting = Newtonsoft.Json.Formatting.Indented });
        }






    }
}