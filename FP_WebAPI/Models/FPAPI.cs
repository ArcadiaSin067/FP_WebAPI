using System;
using FP_WebAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace FP_WebAPI.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

        [Display(Name = "Account Name"),StringLength(100, MinimumLength = 2, ErrorMessage ="{0} must be between {2} and {1} characters long.")]
        public string Name { get; set; }

        [Display(Name = "Starting Balance"), Range(0.01, 9999999.99)]
        public double StartBal { get; set; }

        [Display(Name = "Current Balance"), Range(-999999999.99, 999999999.99)]
        public double CurrentBal { get; set; }

        [Display(Name = "Low Balance Level"), Range(0.01, 999999.99)]
        public double LowBalanceLevel { get; set; }

        [Display(Name = "Account Type")]
        public AccountType AccountType { get; set; }
    }

    public class Bucket
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

        [Display(Name = "Bucket Name"), StringLength(100, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string Name { get; set; }

        [Display(Name = "Current Amount"), Range(-999999999.99, 999999999.99)]
        public double CurrentAmount { get; set; }
    }

    public class BucketItem
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

        [Display(Name = "Bucket Item"), StringLength(100, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string Name { get; set; }

        [Display(Name = "Target Amount"), Range(0, 9999999.99)]
        public double TargetAmount { get; set; }

        [Display(Name = "Current Amount"), Range(-999999999.99, 999999999.99)]
        public double CurrentAmount { get; set; }

    }

    public class Household
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public bool IsConfigured { get; set; }

        [Display(Name = "Household Name"), StringLength(100, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string Name { get; set; }
    }

    public class Invitation
    {
        public int Id { get; set; }
        public Guid Code { get; set; }
        public bool IsValid { get; set; }
        public DateTime Created { get; set; }

        [Display(Name = "Time To Live")]
        public int TTL { get; set; }

        [Display(Name = "Recipient Email"), StringLength(150, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string RecipientEmail { get; set; }
    }

    public class Notification
    {
        public int Id { get; set; }
        public bool IsRead { get; set; }
        public DateTime Created { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string Title { get; set; }

        [StringLength(500, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string Message { get; set; }
    }

    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

        [StringLength(250, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string Memo { get; set; }

        [Range(0.01, 1999999.99)]
        public double Amount { get; set; }

        [Display(Name = "Transaction Type")]
        public TransactionType TransactionType { get; set; }
    }
}