using Newtonsoft.Json;
using System.Web.Http;
using FP_WebAPI.Models;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace FP_WebAPI.Controllers
{
    /// <summary>
    /// Controller for Bucket Items.
    /// </summary>
    [RoutePrefix("api/BucketItems"), DisplayName("Bucket Items")]
    public class BucketItemsController : BaseController
    {
        /// <summary>
        /// Delete a specific Bucket Item.
        /// </summary>
        /// <param name="id">Bucket Item Id</param>
        /// <returns>Json data</returns>
        [HttpDelete]
        [Route("DeleteBucketItemAsJson")]
        [ResponseType(typeof(BucketItem))]
        public IHttpActionResult DeleteBucketItemAsJson(int id)
        {
            var data = db.DeleteBucketItem(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get all the details for a specific Bucket Item as XML.
        /// </summary>
        /// <param name="id">Bucket Item Id</param>
        /// <param name="bId">Bucket Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBucketItemDetails")]
        public async Task<BucketItem> GetBucketItemDetails(int id, int bId)
        {
            return await db.GetBucketItemDetails(id, bId);
        }

        /// <summary>
        /// Get all the details for a specific Bucket Item.
        /// </summary>
        /// <param name="id">Bucket Item Id</param>
        /// <param name="bId">Bucket Id</param>
        /// <returns>Json data</returns>
        [HttpGet]
        [Route("GetBucketItemDetailsAsJson")]
        [ResponseType(typeof(BucketItem))]
        public async Task<IHttpActionResult> GetBucketItemDetailsAsJson(int id, int bId)
        {
            var data = await db.GetBucketItemDetails(id, bId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get all Bucket Items for a specific Bucket.
        /// </summary>
        /// <param name="id">Bucket Id</param>
        /// <returns>Json data</returns>
        [HttpGet]
        [Route("GetBucketItemsForBucketAsJson")]
        [ResponseType(typeof(BucketItem))]
        public async Task<IHttpActionResult> GetBucketItemsForBucketAsJson(int id)
        {
            var data = await db.GetBucketItemsForBucket(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}