using Paytime.Domain;

namespace Paytime.Application.User
{
    public class UserInfo
    {
        public string DisplayName { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ContractType Contract { get; set; }
        public string COA { get; set; }
    }

}