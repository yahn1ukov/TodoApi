using TodoApi.Application.Common.Exception.Base;

namespace TodoApi.Application.Common.Exception.Errors;

public class UserInvalidPasswordException : CustomException
{
    public UserInvalidPasswordException()
        : base(400, "Invalid password") { }   
}