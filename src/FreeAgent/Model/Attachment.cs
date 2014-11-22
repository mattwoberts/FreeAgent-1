using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FreeAgent.Model
{
	public class Attachment
	{
		public string data {get; set;}
		public string FileName {get; set;}
		public string Description {get; set;}
		public AttachmentContentType ContentType {get; set;}
	}

    public enum AttachmentContentType
    {
        [EnumMember(Value = "image/png")] Png,
        [EnumMember(Value = "image/x-png")] XPng,
        [EnumMember(Value = "image/jpeg")] Jpeg,
        [EnumMember(Value = "image/jpg")] Jpg,
        [EnumMember(Value = "image/gif")] Gif,
        [EnumMember(Value = "application/x-pdf")] Pdf
    }
}