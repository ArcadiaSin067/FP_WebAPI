using Newtonsoft.Json;
using System.Web.Http;
using FP_WebAPI.Models;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace FP_WebAPI.Controllers
{
    /// <summary>
    /// Controller for Households.
    /// </summary>
    [RoutePrefix("api/Households"), DisplayName("Households")]
    public class HouseholdsController : BaseController
    {
        /// <summary>
        /// Get all Details for a specific household as XML.
        /// </summary>
        /// <param name="id">Household Id</param>
        /// <returns>Xml data</returns>
        [HttpGet]
        [Route("GetHouseholdDetails")]
        public async Task<Household> GetHouseholdDetails(int id)
        {
            return await db.GetHouseholdDetails(id);
        }

        /// <summary>
        /// Get all Details for a specific household.
        /// </summary>
        /// <param name="id">Household Id</param>
        /// <returns>Json data</returns>
        [HttpGet]
        [Route("GetHouseholdDetailsAsJson")]
        [ResponseType(typeof(Household))]
        public async Task<IHttpActionResult> GetHouseholdDetailsAsJson(int id)
        {
            var data = await db.GetHouseholdDetails(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Update the Name of a specific household.
        /// </summary>
        /// <param name="id">Household Id</param>
        /// <param name="name">Household Name</param>
        /// <returns>Json data</returns>
        [HttpPut]
        [Route("UpdateHouseholdAsJson")]
        public IHttpActionResult UpdateHouseholdAsJson(int id, string name)
        {
            var data = db.UpdateHousehold(id, name);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}