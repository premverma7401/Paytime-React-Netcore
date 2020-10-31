using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paytime.Domain
{
    public class UserModel : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public ContractType Contract { get; set; }
        public string COA { get; set; }
        public string Image { get; set; }
        //    public CompanyModel CompanyModel { get; set; }
        public List<WeeklyDataModel> Timesheets { get; set; }
    }
}