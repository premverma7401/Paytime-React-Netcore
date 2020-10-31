using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paytime.Domain
{
    public class ShiftDataModel
    {
        [Key]
        public Guid ShiftId { get; set; }
        public string SiteName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string ShiftHourTotal { get; set; }
        public string ShiftNotes { get; set; }
        [ForeignKey(nameof(DailyDataModel))]
        public Guid DailyId { get; set; }
        public DailyDataModel DailyDataModel { get; set; }

    }
}