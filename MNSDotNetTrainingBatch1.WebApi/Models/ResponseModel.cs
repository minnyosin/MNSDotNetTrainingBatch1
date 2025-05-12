using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;

namespace MNSDotNetTrainingBatch1.WebApi.Models
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
