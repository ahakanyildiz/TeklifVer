

namespace TeklifVer.Common.ResultPattern
{
    public interface IResult<T>
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
}
