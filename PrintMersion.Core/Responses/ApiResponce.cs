using System;
using System.Collections.Generic;
using System.Text;

namespace PrintMersion.Core.Responses
{

    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}

