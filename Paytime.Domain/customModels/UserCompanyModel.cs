using System;
using System.Collections.Generic;
using System.Text;

namespace Paytime.Domain.customModels
{
    public class UserCompanyModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string COA { get; set; }
        public string CmpName { get; set; }

    }
}
