using FP_WebAPI.Enums;
using Newtonsoft.Json;
using System.Web.Http;
using FP_WebAPI.Models;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace FP_WebAPI.Controllers
{
    [RoutePrefix("api/BankAccounts")]
    public class BankAccountsController : BaseController
    {
        [Route("AddBankAccountToHouseholdAsJson")]
        [ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> AddBankAccountToHouseholdAsJson(string name, double startBal, AccountType accountType, string ownerId, int hhId, double lowBalLvl)
        {
            var data = await db.AddBankAccountToHousehold(name, startBal, accountType, ownerId, hhId, lowBalLvl);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        [Route("GetBankAccountDetails")]
        public async Task<BankAccount> GetBankAccountDetails(int id, int hhId)
        {
            return await db.GetBankAccountDetails(id, hhId);
        }

        [Route("GetBankAccountDetailsAsJson")]
        [ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> GetBankAccountDetailsAsJson(int id, int hhId)
        {
            var data = await db.GetBankAccountDetails(id, hhId);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }

        [Route("GetBankAccountsForHouseholdAsJson")]
        [ResponseType(typeof(BankAccount))]
        public async Task<IHttpActionResult> GetBankAccountsForHouseholdAsJson(int id)
        {
            var data = await db.GetBankAccountsForHousehold(id);
            return Json(data, new JsonSerializerSettings { Formatting = Formatting.Indented });
        }
    }
}