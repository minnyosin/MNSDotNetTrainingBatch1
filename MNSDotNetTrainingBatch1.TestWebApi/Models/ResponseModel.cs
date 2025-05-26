namespace MNSDotNetTrainingBatch1.TestWebApi.Models
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
    }
}
