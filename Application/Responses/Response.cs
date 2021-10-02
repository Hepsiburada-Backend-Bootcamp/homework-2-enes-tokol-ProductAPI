namespace Application.Responses
{
    public class Response<TEntity>
    {
        public TEntity Data { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }
        

        public Response(TEntity data)
        {
            Success = true;
            Data = data;
        }
        
        public Response(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }
        
    }
}