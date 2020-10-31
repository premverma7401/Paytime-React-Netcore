using System;
using System.ComponentModel.DataAnnotations.Schema;
using Paytime.Domain.models.common;

namespace Paytime.Domain.models.viewModels
{
    public class SummaryCardViewModel : Entity
    {
        public Guid TsheetId { get; set; }
        public string MainSite { get; set; }
        public string WeekRange { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal WeekHoursTotal { get; set; }
        public int DaysWorked { get; set; }
        public int DaysOff { get; set; }

    }

}