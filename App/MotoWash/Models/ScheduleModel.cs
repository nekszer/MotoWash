using System;
using System.Collections.Generic;

namespace MotoWash.Models
{
    public class ScheduleModel
    {
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public double BaseCost { get; set; }
        public IEnumerable<int> Extras { get; set; }
        public IEnumerable<int> Categories { get; set; }
        public int ServiceId { get; set; }
        public DateTime ServiceDate { get; set; }
        public string Coupon { get; set; }
    }
}