namespace TeklifVer.Common.ResultPattern
{
    public interface IResult
    {
        bool IsSuccess { get; set; }
        string ErrorMessage { get; set; }
    }
}
