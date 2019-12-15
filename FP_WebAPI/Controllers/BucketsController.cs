using Newtonsoft.Json;
using System.Web.Http;
using FP_WebAPI.Models;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace FP_WebAPI.Controllers
{
    /// <summary>
    /// Controller for Buckets.
    /// </summary>
    [RoutePrefix("api/Buckets"), DisplayName("Buckets")]
    public class BucketsController : BaseController
    {

        /// <summary>
        /// Add a Bucket to a specific Household.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="ownerId">Bucket Owner Id</param>
        /// <param name="hhId">Household Id</param>
        /// <returns>Json data</returns>
        [Route("AddBucketToHouseholdAsJson")]
        [ResponseType(typeof(Bucket))]
        public async Task<IHttpActionResult> AddBucketToHouseholdAsJson(string name, string ownerId, int hhId)
        {
            var data = await db.AddBucketToHousehold(name, ownerId, hhId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get all the details for a specific Bucket as XML.
        /// </summary>
        /// <param name="id">Bucket Id</param>
        /// <param name="hhId">Household Id</param>
        /// <returns>Xml data</returns>
        [Route("GetBucketDetails")]
        public async Task<Bucket> GetBucketDetails(int id, int hhId)
        {
            return await db.GetBucketDetails(id, hhId);
        }

        /// <summary>
        /// Get all the details for a specific Bucket.
        /// </summary>
        /// <param name="id">Bucket Id</param>
        /// <param name="hhId">Household Id</param>
        /// <returns>Json data</returns>
        [Route("GetBucketDetailsAsJson")]
        [ResponseType(typeof(Bucket))]
        public async Task<IHttpActionResult> GetBucketDetailsAsJson(int id, int hhId)
        {
            var data = await db.GetBucketDetails(id, hhId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get all Buckets for a specific Household.
        /// </summary>
        /// <param name="id">Household Id</param>
        /// <returns>Json data</returns>
        [Route("GetBucketsForHouseholdAsJson")]
        [ResponseType(typeof(Bucket))]
        public async Task<IHttpActionResult> GetBucketsForHouseholdAsJson(int id)
        {
            var data = await db.GetBucketsForHousehold(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}