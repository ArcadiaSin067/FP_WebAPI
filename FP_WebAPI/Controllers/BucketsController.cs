using Newtonsoft.Json;
using System.Web.Http;
using FP_WebAPI.Models;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace FP_WebAPI.Controllers
{
    [RoutePrefix("api/Buckets")]
    public class BucketsController : BaseController
    {
        [Route("AddBucketToHouseholdAsJson")]
        [ResponseType(typeof(Bucket))]
        public async Task<IHttpActionResult> AddBucketToHouseholdAsJson(string name, string ownerId, int hhId)
        {
            var data = await db.AddBucketToHousehold(name, ownerId, hhId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        [Route("GetBucketDetails")]
        public async Task<Bucket> GetBucketDetails(int id, int hhId)
        {
            return await db.GetBucketDetails(id, hhId);
        }

        [Route("GetBucketDetailsAsJson")]
        [ResponseType(typeof(Bucket))]
        public async Task<IHttpActionResult> GetBucketDetailsAsJson(int id, int hhId)
        {
            var data = await db.GetBucketDetails(id, hhId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        [Route("GetBucketsForHouseholdAsJson")]
        [ResponseType(typeof(Bucket))]
        public async Task<IHttpActionResult> GetBucketsForHouseholdAsJson(int id)
        {
            var data = await db.GetBucketsForHousehold(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}