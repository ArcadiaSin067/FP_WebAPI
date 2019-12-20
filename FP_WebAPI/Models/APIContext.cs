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


        public int AddBankAccountToHousehold(string name, double startBal, AccountType accountType, string ownerId, int hhId, double lowBalLvl)
        {
            return Database.ExecuteSqlCommand("AddBankAccountToHousehold @name, @startBal, @accountType, @ownerId, @hhId, @lowBalLvl",
                new SqlParameter("name", name),
                new SqlParameter("startBal", startBal),
                new SqlParameter("accountType", (int)accountType),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("hhId", hhId),
                new SqlParameter("lowBalLvl", lowBalLvl));
        }
       
        public int AddBucketToHousehold(string name, string ownerId, int hhId)
        {
            return Database.ExecuteSqlCommand("AddBucketToHousehold @name, @ownerId, @hhId",
                new SqlParameter("name", name),
                new SqlParameter("ownerId", ownerId),
                new SqlParameter("hhId", hhId));
        }
        
        public int AddTransactionToBankAccount(string memo, double amount, TransactionType transactionType, int accountId, int bucketItemId, string ownerId)
        {
            return Database.ExecuteSqlCommand("AddTransactionToBankAccount @memo, @amount, @transactionType, @accountId, @bucketItemId, @ownerId",
                new SqlParameter("memo", memo),
                new SqlParameter("amount", amount),
                new SqlParameter("transactionType", (int)transactionType),
                new SqlParameter("accountId", accountId),
                new SqlParameter("bucketItemId", bucketItemId),
                new SqlParameter("ownerId", ownerId));
        }

        public int DeleteBucketItem(int id)
        {
            return Database.ExecuteSqlCommand("DeleteBucketItem @id",
                new SqlParameter("id", id));
        }

        public async Task<BankAccount> GetBankAccountDetails(int id, int hhId)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountDetails @id, @hhId",
                new SqlParameter("id", id),
                new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();
        }

        public async Task<List<BankAccount>> GetBankAccountsForHousehold(int id)
        {
            return await Database.SqlQuery<BankAccount>("GetBankAccountsForHousehold @id",
                new SqlParameter("id", id)).ToListAsync();
        }

        public async Task<Bucket> GetBucketDetails(int id, int hhId)
        {
            return await Database.SqlQuery<Bucket>("GetBucketDetails @id, @hhId",
                new SqlParameter("id", id),
                new SqlParameter("hhId", hhId)).FirstOrDefaultAsync();
        }

        public async Task<BucketItem> GetBucketItemDetails(int id, int bId)
        {
            return await Database.SqlQuery<BucketItem>("GetBucketItemDetails @id, @bId",
                new SqlParameter("id", id),
                new SqlParameter("bId", bId)).FirstOrDefaultAsync();
        }

        public async Task<List<BucketItem>> GetBucketItemsForBucket(int id)
        {
            return await Database.SqlQuery<BucketItem>("GetBucketItemsForBucket @id",
                new SqlParameter("id", id)).ToListAsync();
        }

        public async Task<List<Bucket>> GetBucketsForHousehold(int id)
        {
            return await Database.SqlQuery<Bucket>("GetBucketsForHousehold @id",
                new SqlParameter("id", id)).ToListAsync();
        }

        public async Task<Household> GetHouseholdDetails(int id)
        {
            return await Database.SqlQuery<Household>("GetHouseholdDetails @id",
                new SqlParameter("id", id)).FirstOrDefaultAsync();
        }

        public async Task<Transaction> GetTransactionDetails(int id, int aId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @id, @aId",
                new SqlParameter("id", id),
                new SqlParameter("aId", aId)).FirstOrDefaultAsync();
        }

        public async Task<List<Transaction>> GetTransactionsForBankAccount(int id)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionsForBankAccount @id",
                new SqlParameter("id", id)).ToListAsync();
        }

        public int UpdateHousehold(int id, string name)
        {
            return Database.ExecuteSqlCommand("UpdateHousehold @id, @name",
                new SqlParameter("id", id),
                new SqlParameter("name", name));
        }
    }
}