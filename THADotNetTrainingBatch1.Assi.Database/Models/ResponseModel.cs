using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THADotNetTrainingBatch1.Assi.Database.Models
{
    public class ResponseModel
    {
        public ResponseModel(bool isSuccess,
            string message, object data = null,
            object data2 = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
            Data2 = data2;
        }

        public bool IsSuccess { get; set; } 

        public string Message { get; set; } 

        public object Data { get; set; }

        public object Data2 { get; set; }
    }
}
