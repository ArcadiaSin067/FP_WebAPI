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
    /// Controller for Bank Accounts.
    /// </summary>
    [RoutePrefix("api/Accounts"), DisplayName("Bank Accounts")]
    public class BankAccountsController : BaseController
    {
        /// <summary>
        /// Add a bank account to a specific household.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="startBal">Starting Balance</param>
        /// <param name="accountType">Account Type</param>
        /// <param name="ownerId">Account Owner Id</param>
        /// <param name="hhId">Household Id</param>
        /// <param name="lowBalLvl">Low Balance Level</param>
        /// <returns>Json data</returns>
        [Route("AddAccountToHouseholdAsJson")]
        [ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> AddBankAccountToHouseholdAsJson(string name, double startBal, AccountType accountType, string ownerId, int hhId, double lowBalLvl)
        {
            var data = await db.AddBankAccountToHousehold(name, startBal, accountType, ownerId, hhId, lowBalLvl);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get all details for a specific Account within a Household as XML.
        /// </summary>
        /// <param name="id">Bank Account Id</param>
        /// <param name="hhId">Household Id</param>
        /// <returns>Xml data</returns>
        [Route("GetAccountDetails")]
        public async Task<BankAccount> GetBankAccountDetails(int id, int hhId)
        {
            return await db.GetBankAccountDetails(id, hhId);
        }

        /// <summary>
        /// Get all details for a specific Account within a Household.
        /// </summary>
        /// <param name="id">Bank Account Id</param>
        /// <param name="hhId">Household Id</param>
        /// <returns>Json data</returns>
        [Route("GetAccountDetailsAsJson")]
        [ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> GetBankAccountDetailsAsJson(int id, int hhId)
        {
            var data = await db.GetBankAccountDetails(id, hhId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        /// <summary>
        /// Get the details for all Accounts within a specific Household.
        /// </summary>
        /// <param name="id">Household Id</param>
        /// <returns>Json data</returns>
        [Route("GetAccountsForHouseholdAsJson")]
        [ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> GetBankAccountsForHouseholdAsJson(int id)
        {
            var data = await db.GetBankAccountsForHousehold(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}