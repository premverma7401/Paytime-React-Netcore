using System;

namespace Paytime.Domain.models.viewModels
{
    public class DetailCardViewModelShift
    {

        public string SiteName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string ShiftHourTotal { get; set; }
        public string ShiftNotes { get; set; }

    }


}