using System;
using FP_WebAPI.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace FP_WebAPI.Models
{
    /// <summary>
    /// Properties for the Bank Account model.
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// The Bank Account Id primary key.
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// The Time the Bank Account is Created at.
        /// </summary>
        [Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// The Name of the Bank Account.
        /// </summary>
        [Required]
        [Display(Name = "Account Name"),StringLength(100, MinimumLength = 2, ErrorMessage ="{0} must be between {2} and {1} characters long.")]
        public string Name { get; set; }

        /// <summary>
        /// The Starting Balance of the Bank Account.
        /// </summary>
        [Required]
        [Display(Name = "Starting Balance"), Range(0.01, 9999999.99)]
        public double StartBal { get; set; }

        /// <summary>
        /// The Current Balance of the Bank Account.
        /// </summary>
        [Required]
        [Display(Name = "Current Balance"), Range(-999999999.99, 999999999.99)]
        public double CurrentBal { get; set; }

        /// <summary>
        /// The Low Balance alert Level for the Bank Account.
        /// </summary>
        [Required]
        [Display(Name = "Low Balance Level"), Range(0.01, 999999.99)]
        public double LowBalanceLevel { get; set; }

        /// <summary>
        /// The Account Type of the Bank Account.
        /// </summary>
        [Required]
        [Display(Name = "Account Type")]
        [EnumDataType(typeof(AccountType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountType AccountType { get; set; }
    }

    /// <summary>
    /// Properties for the Bucket model.
    /// </summary>
    public class Bucket
    {
        /// <summary>
        /// The Bucket Id primary key.
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// The Time the bucket is Created at.
        /// </summary>
        [Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// The Name of the Bucket.
        /// </summary>
        [Required]
        [Display(Name = "Bucket Name"), StringLength(100, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string Name { get; set; }

        /// <summary>
        /// The Current Amount in the Bucket.
        /// </summary>
        [Required]
        [Display(Name = "Current Amount"), Range(-999999999.99, 999999999.99)]
        public double CurrentAmount { get; set; }
    }

    /// <summary>
    /// Properties for the Bucket Item model.
    /// </summary>
    public class BucketItem
    {
        /// <summary>
        /// The Bucket Item Id primary key.
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// The Time the Bucket Item is Created at.
        /// </summary>
        [Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// The Name of the Bucket Item.
        /// </summary>
        [Required]
        [Display(Name = "Bucket Item"), StringLength(100, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string Name { get; set; }

        /// <summary>
        /// The Target Amount of the Bucket Item.
        /// </summary>
        [Required]
        [Display(Name = "Target Amount"), Range(0, 9999999.99)]
        public double TargetAmount { get; set; }

        /// <summary>
        /// The Current Amount of the Bucket Item.
        /// </summary>
        [Required]
        [Display(Name = "Current Amount"), Range(-999999999.99, 999999999.99)]
        public double CurrentAmount { get; set; }
    }

    /// <summary>
    /// Properties for the Household model.
    /// </summary>
    public class Household
    {
        /// <summary>
        /// The Household Id primary key.
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// The Time the Household is Created at.
        /// </summary>
        [Required]
        public DateTime Created { get; set; }
        /// <summary>
        /// Whether or not the Household has been configured.
        /// </summary>
        [Required]
        public bool IsConfigured { get; set; }

        /// <summary>
        /// The Name of the Household.
        /// </summary>
        [Required]
        [Display(Name = "Household Name"), StringLength(100, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string Name { get; set; }
    }

    /// <summary>
    /// Properties for Invitation model.
    /// </summary>
    public class Invitation
    {
        /// <summary>
        /// The Invitation Id primary key.
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// The Guid generated for a specific invitation.
        /// </summary>
        [Required]
        public Guid Code { get; set; }
        /// <summary>
        /// Whether of not the Invitation is still valid.
        /// </summary>
        [Required]
        public bool IsValid { get; set; }
        /// <summary>
        /// The Time the Invitation is Created at.
        /// </summary>
        [Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// The Time To Live -in days- of the Invitation.
        /// </summary>
        [Required]
        [Display(Name = "Time To Live")]
        public int TTL { get; set; }

        /// <summary>
        /// The Recipient Email for the Invitation.
        /// </summary>
        [Required]
        [Display(Name = "Recipient Email"), StringLength(150, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string RecipientEmail { get; set; }
    }

    /// <summary>
    /// Properties for the Notification model.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// The Notification Id primary key.
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Whether of not the Notification has been read.
        /// </summary>
        [Required]
        public bool IsRead { get; set; }
        /// <summary>
        /// The Time the Notification is Created at.
        /// </summary>
        [Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// The Title of the Notification.
        /// </summary>
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string Title { get; set; }

        /// <summary>
        /// The Message embedded within the Notification.
        /// </summary>
        [Required]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string Message { get; set; }
    }

    /// <summary>
    /// Properties for the Transaction model.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// The Transaction Id primary key.
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// The Time the Transaction is Created at.
        /// </summary>
        [Required]
        public DateTime Created { get; set; }

        /// <summary>
        /// The Message for the reason behind a Transaction.
        /// </summary>
        [Required]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters long.")]
        public string Memo { get; set; }

        /// <summary>
        /// The Amount of the Transaction.
        /// </summary>
        [Required]
        [Range(0.01, 1999999.99)]
        public double Amount { get; set; }

        /// <summary>
        /// The Transaction Type of the Transaction.
        /// </summary>
        [Required]
        [Display(Name = "Transaction Type")]
        [EnumDataType(typeof(TransactionType))]
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType TransactionType { get; set; }
    }
}