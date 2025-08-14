using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTimetableGenerator.AllModels
{
    public class TimeSlots
    {
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public string DaySlotName { get; set; }
    }
}
