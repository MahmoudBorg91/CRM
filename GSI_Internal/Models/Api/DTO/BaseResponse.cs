namespace GSI_Internal.Models.Api.DTO
{
    public class BaseResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public dynamic Data { get; set; }
    }
}
