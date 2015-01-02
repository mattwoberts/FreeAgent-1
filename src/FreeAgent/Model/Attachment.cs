using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
	public class Attachment : IUrl
	{
        public Uri Url { get; set; }
        public Uri ContentUrl { get; set; }  //TODO - this is the URL where the data is stored...
        public string Data {get; set;}  //TODO - this is base64 encoded data TO the service
		public string FileName {get; set;}
        public double FileSize { get; set; }
		public string Description {get; set;}
		public AttachmentContentType ContentType {get; set;}
	}

    public class AttachmentWrapper
    {
        public Attachment Attachment { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}