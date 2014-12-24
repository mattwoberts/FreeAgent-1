using System.Runtime.Serialization;

namespace FreeAgent.Model
{
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