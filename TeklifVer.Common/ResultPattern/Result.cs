namespace TeklifVer.Common.ResultPattern
{
    public class Result : IResult
    {

        public Result()
        {

        }

        public Result(bool IsSuccess, string ErrorMessage)
        {
            this.IsSuccess = IsSuccess;
            this.ErrorMessage = ErrorMessage;
        }

        public Result(bool IsSuccess)
        {
            this.IsSuccess = IsSuccess;
        }


        public string? ErrorMessage { get; set; }
        public bool IsSuccess { get; set; }
    }
}

