using System.Text.Json;
using MyRecipeBook.Domain.Dtos;
using MyRecipeBook.Domain.Dtos.Responses;
using Refit;

namespace MyRecipeBook.Infrastructure.Clients;

public interface IOpenRouterClient
{
    [Post("/chat/completions")]
    Task<ChatCompletionResponse> Generate([Header("Authorization")] string apiKey, [Body] ChatRequestDto request);
}