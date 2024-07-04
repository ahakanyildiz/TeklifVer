
namespace TeklifVer.Common.ResultPattern
{
    public class Result<T> : IResult<T>
    {
        public Result()
        {

        }

        public Result(bool IsSuccess, string ErrorMessage, T Data)
        {
            this.IsSuccess = IsSuccess;
            this.ErrorMessage = ErrorMessage;
            this.Data = Data;
        }

        public Result(bool IsSuccess, T Data)
        {
            this.IsSuccess = IsSuccess;
            this.Data = Data;
        }

        public Result(bool IsSuccess, string ErrorMessage)
        {
            this.IsSuccess = IsSuccess;
            this.ErrorMessage = ErrorMessage;
        }

        public string? ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
    }
}
