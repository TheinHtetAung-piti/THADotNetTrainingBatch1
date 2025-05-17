﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THADotNetTrainingBatch1.Project1.Database.Models
{
    public class ResponseModel
    {
        public ResponseModel(bool isSuccess, string message, object data = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        public bool IsSuccess { get; set; }

        public string Message { get; set; } 

        public object Data { get; set; }
    }
}
