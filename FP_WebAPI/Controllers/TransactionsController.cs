using FP_WebAPI.Enums;
using Newtonsoft.Json;
using System.Web.Http;
using FP_WebAPI.Models;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace FP_WebAPI.Controllers
{
    [RoutePrefix("api/Transactions")]
    public class TransactionsController : BaseController
    {
        [Route("AddTransactionToBankAccountAsJson")]
        [ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> AddTransactionToBankAccountAsJson(string memo, double amount, TransactionType transactionType, int accountId, int bucketItemId, string ownerId)
        {
            var data = await db.AddTransactionToBankAccount(memo, amount, transactionType, accountId, bucketItemId, ownerId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        [Route("GetTransactionsForBankAccountAsJson")]
        [ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> GetTransactionsForBankAccountAsJson(int id)
        {
            var data = await db.GetTransactionsForBankAccount(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        [Route("GetTransactionDetails")]
        public async Task<Transaction> GetTransactionDetails(int id, int aId)
        {
            return await db.GetTransactionDetails(id, aId);
        }

        [Route("GetTransactionDetailsAsJson")]
        [ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> GetTransactionDetailsAsJson(int id, int aId)
        {
            var data = await db.GetTransactionDetails(id, aId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}