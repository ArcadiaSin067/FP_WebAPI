using FP_WebAPI.Enums;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FP_WebAPI.Models
{
    public class APIContext : DbContext
    {
        public APIContext()
            : base("APIConnection") { }

        public static APIContext Create() 
            { return new APIContext(); }

        /// <summary>
        /// This will add a bank account to a specific household.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="startBal">Starting Balance</param>
        /// <param name="accountType">Account Type</param>
        /// <param name="ownerId">Account Owner Id</param>
        /// <param name="hhId">Household Id</param>
        /// <param name="lowBalLvl">Low Balance Level</param>
        /// <returns></returns>
        public async Task<BankAccount> AddBankAccountToHousehold(string name, double startBal, AccountType accountType, string ownerId, int hhId, double lowBalLvl)
        {
            return await Database.SqlQuery<BankAccount>("AddBankAccountToHousehold @name, @startBal, @accountType, @ownerId, @hhId, @lowBalLvl",
                new SqlParameter("name", name),
                new SqlParameter("startBal", startBal),
                new SqlParameter("accountType", (int)accountType),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("hhId", hhId),
                new SqlParameter("lowBalLvl", lowBalLvl)).FirstOrDefaultAsync();
        }
       
        /// <summary>
        /// This will add a Bucket to a specific Household.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="ownerId">Bucket Owner Id</param>
        /// <param name="hhId">Household Id</param>
        /// <returns></returns>
        public async Task<Bucket> AddBucketToHousehold(string name, string ownerId, int hhId)
        {
            return await Database.SqlQuery<Bucket>("AddBucketToHousehold @name, @ownerId, @hhId",
                new SqlParameter("name", name),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();
        }
        
        /// <summary>
        /// This will add a Transaction to a specific Bank Account.
        /// </summary>
        /// <param name="memo">Memo</param>
        /// <param name="amount">Name</param>
        /// <param name="transactionType">Transaction Type</param>
        /// <param name="accountId">Bank Account Id</param>
        /// <param name="bucketItemId">Bucket Item Id</param>
        /// <param name="ownerId">Transaction Owner Id</param>
        /// <returns></returns>
        public async Task<Transaction> AddTransactionToBankAccount(string memo, double amount, TransactionType transactionType, int accountId, int bucketItemId, string ownerId)
        {
            return await Database.SqlQuery<Transaction>("AddTransactionToBankAccount @memo, @amount, @transactionType, @accountId, @bucketItemId, @ownerId",
                new SqlParameter("memo", memo),
                new SqlParameter("amount", amount),
                new SqlParameter("transactionType", (int)transactionType),
                new SqlParameter("accountId", accountId),
                new SqlParameter("bucketItemId", bucketItemId),
                new SqlParameter("ownerId", ownerId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// This will get all details for a specific Bank Account within a specific Household.
        /// </summary>
        /// <param name="id">Bank Account Id</param>
        /// <param name="hhId">Household Id</param>
        /// <returns></returns>
        public async Task<BankAccount> GetBankAccountDetails(int id, int hhId)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountDetails @id, @hhId",
                new SqlParameter("id", id),
                new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// This will get the details for all Bank Accounts within a specific Household.
        /// </summary>
        /// <param name="id">Household Id</param>
        /// <returns></returns>
        public async Task<List<BankAccount>> GetBankAccountsForHousehold(int id)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountsForHousehold @id",
                new SqlParameter("id", id)).ToListAsync();
        }

        /// <summary>
        /// This will get all the details for a specific Bucket.
        /// </summary>
        /// <param name="id">Bucket Id</param>
        /// <param name="hhId">Household Id</param>
        /// <returns></returns>
        public async Task<Bucket> GetBucketDetails(int id, int hhId)
        {
            return await Database.SqlQuery<Bucket>("GetBucketDetails @id, @hhId",
                new SqlParameter("id", id),
                new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// This will get all the details for a specific Bucket Item.
        /// </summary>
        /// <param name="id">Bucket Item Id</param>
        /// <param name="bId">Household Id</param>
        /// <returns></returns>
        public async Task<BucketItem> GetBucketItemDetails(int id, int bId)
        {
            return await Database.SqlQuery<BucketItem>("GetBucketItemDetails @id, @bId",
                new SqlParameter("id", id),
                new SqlParameter("bId", bId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// This will get all Bucket Items for a specific Bucket.
        /// </summary>
        /// <param name="id">Bucket Id</param>
        /// <returns></returns>
        public async Task<List<BucketItem>> GetBucketItemsForBucket(int id)
        {
            return await Database.SqlQuery<BucketItem>("GetBucketItemsForBucket @id",
                new SqlParameter("id", id)).ToListAsync();
        }

        /// <summary>
        /// This will get all Buckets for a specific Household.
        /// </summary>
        /// <param name="id">Household Id</param>
        /// <returns></returns>
        public async Task<List<Bucket>> GetBucketsForHousehold(int id)
        {
            return await Database.SqlQuery<Bucket>("GetBucketsForHousehold @id",
                new SqlParameter("id", id)).ToListAsync();
        }

        /// <summary>
        /// This will get all Details for a specific household.
        /// </summary>
        /// <param name="id">Household Id</param>
        /// <returns></returns>
        public async Task<Household> GetHouseholdDetails(int id)
        {
            return await Database.SqlQuery<Household>("GetHouseholdDetails @id",
                new SqlParameter("id", id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// This will get all Details for a specific Transaction.
        /// </summary>
        /// <param name="id">Transaction Id</param>
        /// <param name="aId">Bank Account Id</param>
        /// <returns></returns>
        public async Task<Transaction> GetTransactionDetails(int id, int aId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @id, @aId",
                new SqlParameter("id", id),
                new SqlParameter("aId", aId)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// This will get all Transactions for a specific Bank Account.
        /// </summary>
        /// <param name="id">Bank Account Id</param>
        /// <returns></returns>
        public async Task<List<Transaction>> GetTransactionsForBankAccount(int id)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionsForBankAccount @id",
                new SqlParameter("id", id)).ToListAsync();
        }
    }
}