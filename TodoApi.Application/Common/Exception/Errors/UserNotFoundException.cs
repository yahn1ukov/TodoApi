using TodoApi.Application.Common.Exception.Base;

namespace TodoApi.Application.Common.Exception.Errors;

public class UserNotFoundException : CustomException
{
    public UserNotFoundException()
        : base(404, "User not found") { }
}