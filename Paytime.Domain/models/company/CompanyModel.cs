using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paytime.Domain
{
    public class CompanyModel
    {
        [Key]
        public Guid CmpId { get; set; }
        [Required]
        public string CmpName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string CmpEmailTo { get; set; }
        [DataType(DataType.EmailAddress)]
        public string CmpEmailCc { get; set; }
        [ForeignKey(nameof(UserModel))]
        public string UserId { get; set; }
        public UserModel UserModel { get; set; }


    }
}