using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
    public class Timeslip : IUrl
	{
        public Uri Url { get; set; }
		public Uri User { get; set; }
		public Uri Project { get; set; }
		public Uri Task { get; set; }
		public DateTime DatedOn { get; set; }
		public double Hours { get; set;}
        public string Comment { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
	
	public class TimeslipWrapper
	{
		public Timeslip Timeslip { get; set; }
        public IEnumerable<Timeslip> Timeslips { get; set; }
    }
}

