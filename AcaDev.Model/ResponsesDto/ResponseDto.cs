namespace AcaDev.Model.ResponsesDto
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }

        public static ResponseDto<T> Create(T dataObj) => new ResponseDto<T> { Data = dataObj };
    }
}
