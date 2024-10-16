using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrishnyanAstro.Shared.Entities
{

    public class ApiResponse<T> //where T new class
    {

        public ApiResponse(ResponseStatus statusCode, T data)
        {
            StatusCode = statusCode;
            Data = data;
        }
        public ApiResponse(ResponseStatus statusCode, string statusMessage, T data)
        {
            StatusCode = statusCode;
            StatusMessage = statusMessage;
            Data = data;
        }
        ResponseStatus StatusCode { get; set; }
        string StatusMessage { get; set; }

        T Data { get; set; }

    }
}
