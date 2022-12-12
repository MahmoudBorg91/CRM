using Newtonsoft.Json;

namespace GSI_Internal.Models.Api.DTO.NotificationModel
{
    public class ResponseModel
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
