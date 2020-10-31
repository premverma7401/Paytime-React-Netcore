using System.Collections.Generic;
using Paytime.Domain.models.common;

namespace Paytime.Domain.models.viewModels
{
    public class DetailLastTsSubmitted : Entity
    {
        public string WeekRange { get; set; }

        public decimal WeekHoursTotal { get; set; }
        public int DaysWorked { get; set; }
        public int DaysOff { get; set; }
        public string MainSite { get; set; }

        public List<DetailCardViewModel> DailyData { get; set; }
    }

}