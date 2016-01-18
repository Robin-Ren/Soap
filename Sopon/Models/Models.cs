using Sopon.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace Sopon.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }

    public class SummaryModel
    {

    }

    public class IncomeModel
    {
        private double incomeAmount;
        public int count;
        public double unitPrice;
        public DateTime logDate;
    }

    public class OutcomeModel
    {
        public List<OutCome> OutcomeDetails;
        public string name;

        public OutcomeModel(List<OutCome> ocCallResult)
        {
            OutcomeDetails = ocCallResult;
            name = "aadfa";
        }

        public OutcomeModel()
        {

        }
    }

    public class UpdateOutComeModel
    {
        private int m_sid;

        public int ID
        {
            get { return m_sid; }
            set { m_sid = value; }
        }
        private double m_Amout;

        public double Amout
        {
            get { return m_Amout; }
            set { m_Amout = value; }
        }
        private string m_OutcomeName;

        public string OutcomeName
        {
            get { return m_OutcomeName; }
            set { m_OutcomeName = value; }
        }
        private string m_OutcomeDesc;

        public string OutcomeDesc
        {
            get { return m_OutcomeDesc; }
            set { m_OutcomeDesc = value; }
        }
        private double m_GoodsUnitPrice;

        public double GoodsUnitPrice
        {
            get { return m_GoodsUnitPrice; }
            set { m_GoodsUnitPrice = value; }
        }
        private int m_GoodsCount;

        public int GoodsCount
        {
            get { return m_GoodsCount; }
            set { m_GoodsCount = value; }
        }

        private string m_CreatedDate;

        public string CreatedDate
        {
            get { return m_CreatedDate; }
            set { m_CreatedDate = value; }
        }

        public UpdateOutComeModel(OutCome item)
        {
            this.Amout = item.Amout;
            this.ID = item.ID;
            this.OutcomeName = item.OutcomeName;
            this.OutcomeDesc = item.OutcomeDesc;
            this.GoodsUnitPrice = item.GoodsUnitPrice;
            this.GoodsCount = item.GoodsCount;
            this.CreatedDate = item.CreatedDate;
        }
    }
}
