using FP_WebAPI.Enums;
using Newtonsoft.Json;
using System.Web.Http;
using FP_WebAPI.Models;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace FP_WebAPI.Controllers
{
    /// <summary>
    /// Controller for Transactions.
    /// </summary>
    [RoutePrefix("api/Transactions"), DisplayName("Transactions")]
    public class TransactionsController : BaseController
    {

        /// <summary>
        /// Add a Transaction to a specific Account.
        /// </summary>
        /// <param name="memo">Memo</param>
        /// <param name="amount">Name</param>
        /// <param name="transactionType">Transaction Type</param>
        /// <param name="accountId">Bank Account Id</param>
        /// <param name="bucketItemId">Bucket Item Id</param>
        /// <param name="ownerId">Transaction Owner Id</param>
        /// <returns>Json data</returns>
        [Route("AddTransactionToBankAccountAsJson")]
        [ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> AddTransactionToBankAccountAsJson(string memo, double amount, TransactionType transactionType, int accountId, int bucketItemId, string ownerId)
        {
            var data = await db.AddTransactionToBankAccount(memo, amount, transactionType, accountId, bucketItemId, ownerId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get all Details for a specific Transaction as XML.
        /// </summary>
        /// <param name="id">Transaction Id</param>
        /// <param name="aId">Bank Account Id</param>
        /// <returns>Xml data</returns>
        [Route("GetTransactionDetails")]
        public async Task<Transaction> GetTransactionDetails(int id, int aId)
        {
            return await db.GetTransactionDetails(id, aId);
        }

        /// <summary>
        /// Get all Details for a specific Transaction.
        /// </summary>
        /// <param name="id">Transaction Id</param>
        /// <param name="aId">Bank Account Id</param>
        /// <returns>Json data</returns>
        [Route("GetTransactionDetailsAsJson")]
        [ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> GetTransactionDetailsAsJson(int id, int aId)
        {
            var data = await db.GetTransactionDetails(id, aId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get all Transactions for a specific Account.
        /// </summary>
        /// <param name="id">Bank Account Id</param>
        /// <returns>Json data</returns>
        [Route("GetTransactionsForBankAccountAsJson")]
        [ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> GetTransactionsForBankAccountAsJson(int id)
        {
            var data = await db.GetTransactionsForBankAccount(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}