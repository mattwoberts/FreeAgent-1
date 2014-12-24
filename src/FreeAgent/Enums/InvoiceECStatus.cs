using System.Runtime.Serialization;

namespace FreeAgent.Model
{
	public enum InvoiceECStatus
	{
        [EnumMember(Value = "Non-Ec")] NonEc,
        [EnumMember(Value = "EC Goods")] ECGoods,
        [EnumMember(Value = "EC Services")] ECServices
	}
}




