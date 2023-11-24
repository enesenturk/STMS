namespace NS.STMS.API.Models
{
	public class BaseResponseModel
	{

		public string Type { get; set; } = "S";
		public string Message { get; set; }
		public object ResponseModel { get; set; }
		public string ErrorCode { get; set; } = "00";

	}
}
