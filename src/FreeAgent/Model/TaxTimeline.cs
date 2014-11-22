using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeAgent.Model
{
    public class TaxTimeline
    {
        public string Description { get; set; }
        public string Nature { get; set; }
        public DateTime DatedOn { get; set; }
        public float AmountDue { get; set; }
        public bool IsPersonal { get; set; }
    }

    public class TaxTimelineWrapper
    {
        public List<TaxTimeline> TimelineItems { get; set; }
    }
}
