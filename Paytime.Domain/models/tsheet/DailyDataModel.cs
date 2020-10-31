using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paytime.Domain
{
    public class DailyDataModel
    {
        [Key]
        public Guid DailyId { get; set; }
        public DateTime Day { get; set; }

        [ForeignKey(nameof(WeeklyDataModel))]
        public Guid TsheetId { get; set; }
        public List<ShiftDataModel> ShiftData { get; set; }
        public WeeklyDataModel WeeklyDataModel { get; set; }
    }
}