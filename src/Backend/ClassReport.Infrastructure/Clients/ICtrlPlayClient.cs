using MyRecipeBook.Domain.Dtos;
using Refit;

namespace MyRecipeBook.Infrastructure.Clients;

public interface ICtrlPlayClient
{
    [Post("/auth/token/")]
    public Task<IApiResponse<Stream>> Login([Body] RequestLoginDto request);
    
    [Get("/users/me/")]
    public Task<IApiResponse<Stream>> GetTeacherInfo([Header("Authorization")] string accessToken);

    [Get("/classes/")]
    public Task<IApiResponse<Stream>> GetClasses([Header("Authorization")] string accessToken, [AliasAs("day_of_week")] string today,
        [AliasAs("status")] string statusClass = "IN_PROGRESS", [AliasAs("status")] string statusCode = "OPEN");

    [Get("/scheduled-lessons/?is_active=true")]
    public Task<IApiResponse<Stream>> GetBookIdAndDate([Header("Authorization")] string accessToken,
        [AliasAs("klass_id")] string classId, [AliasAs("date_range_before")] string dateRangeBefore, 
        [AliasAs("date_range_after")] string dateRangeAfter);
    
    [Get("/books/{bookId}/")]
    public Task<IApiResponse<Stream>> GetBookContent([Header("Authorization")] string accessToken, string bookId);
}