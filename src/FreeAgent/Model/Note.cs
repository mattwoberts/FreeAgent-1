using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
    public class NoteItem : IUrl
	{
        public Uri Url { get; set; }
		public Uri ParentUrl { get; set; }
        public string Note { get; set; }
        public string Author { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
	}
	
	public class NoteItemWrapper
	{
		public NoteItem Note { get; set; }
        public IEnumerable<NoteItem> Notes { get; set; }
	}
}