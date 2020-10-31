using System.Collections.Generic;
using System;
using Paytime.Domain.models.common;

namespace Paytime.Domain.models.viewModels
{
    public class DetailCardViewModel
    {
        public DateTime Day { get; set; }
        public List<DetailCardViewModelShift> ShiftData { get; set; }
    }

}