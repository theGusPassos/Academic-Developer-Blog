namespace AcaDev.Model.ResponsesDto
{
    public class ErrorResponseDto
    {
        public Error Error { get; set; }

        public static ErrorResponseDto Create(int code, string details)
            => new ErrorResponseDto { Error = new Error { Code = code, Details = details } };
    }

    public class Error
    {
        public int Code { get; set; }
        
        /// <summary>
        /// Human redable error
        /// </summary>
        public string Details { get; set; }
    }
}
