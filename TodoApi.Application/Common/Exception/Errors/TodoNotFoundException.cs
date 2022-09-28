using TodoApi.Application.Common.Exception.Base;

namespace TodoApi.Application.Common.Exception.Errors;

public class TodoNotFoundException : CustomException
{
    public TodoNotFoundException()
        : base(404, "Todo not found") { }
}