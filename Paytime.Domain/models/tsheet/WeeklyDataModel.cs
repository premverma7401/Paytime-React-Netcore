using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Paytime.Domain.models.common;

namespace Paytime.Domain
{
    public class WeeklyDataModel : Entity
    {
        [Key]
        public Guid TsheetId { get; set; }
        public string MainSite { get; set; }
        public string WeekRange { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal WeekHoursTotal { get; set; }
        public int DaysWorked { get; set; }
        public int DaysOff { get; set; }
        public string Status { get; set; }
        public List<DailyDataModel> DailyData { get; set; }
        [ForeignKey(nameof(UserModel))]
        public string UserId { get; set; }
        public UserModel UserModel { get; set; }

    }
}