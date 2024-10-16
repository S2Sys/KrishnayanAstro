namespace KrishnyanAstro.Shared.Entities
{
    public class ServiceResponse<T> //where T new class
    {

        public ServiceResponse(OperationStatus statusCode, T data)
        {
            Status = statusCode;
            Data = data;
        }
        public ServiceResponse(OperationStatus statusCode, string statusMessage, T data)
        {
            Status = statusCode;
            StatusMessage = statusMessage;
            Data = data;
        }

        public ServiceResponse(Exception ex, T data)
        {
            Exception = ex;
            Status = OperationStatus.TechnicalException;
            StatusMessage = ex.GetBaseException().Message;
            Data = data;
        }
        public OperationStatus Status { get; set; }
        public string StatusMessage { get; set; }
        Exception Exception { get; set; }
        public T Data { get; set; }

    }
}
