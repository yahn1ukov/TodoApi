namespace TodoApi.Application.Common.Exception.Base;

public class CustomException : IOException
{
    public int Code { get; set; }

    public CustomException() { }
    public CustomException(string message) : base(message) { }
    public CustomException(int code, string message) : base(message)
    {
        Code = code;
    }
}