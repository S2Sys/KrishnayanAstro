namespace KrishnyanAstro.Shared.Entities
{
    public class OperationResponse<T> //where T new class
    {

        public OperationResponse(ResponseStatus statusCode, T data)
        {
            StatusCode = statusCode;
            Data = data;
        }
        public OperationResponse(ResponseStatus statusCode, string statusMessage, T data)
        {
            StatusCode = statusCode;
            StatusMessage = statusMessage;
            Data = data;
        }
        ResponseStatus StatusCode { get; set; }
        string StatusMessage { get; set; }

        Exception Exception { get; set; }
        T Data { get; set; }

    }
}
