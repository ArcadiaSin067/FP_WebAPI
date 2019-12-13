using Newtonsoft.Json;
using System.Web.Http;
using FP_WebAPI.Models;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace FP_WebAPI.Controllers
{
    [RoutePrefix("api/BucketItems")]
    public class BucketItemsController : BaseController
    {
        [Route("GetBucketItemDetails")]
        public async Task<BucketItem> GetBucketItemDetails(int id, int hhId)
        {
            return await db.GetBucketItemDetails(id, hhId);
        }

        [Route("GetBucketItemDetailsAsJson")]
        [ResponseType(typeof(BucketItem))]
        public async Task<IHttpActionResult> GetBucketItemDetailsAsJson(int id, int hhId)
        {
            var data = await db.GetBucketItemDetails(id, hhId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        [Route("GetBucketItemsForBucketAsJson")]
        [ResponseType(typeof(BucketItem))]
        public async Task<IHttpActionResult> GetBucketItemsForBucketAsJson(int id)
        {
            var data = await db.GetBucketItemsForBucket(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}