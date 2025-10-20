using Azure;
using MyRecipeBook.Domain.Extensions;
using MyRecipeBook.Domain.Services.OpenAI;
using OpenAI;
using OpenAI.Chat;

namespace MyRecipeBook.Infrastructure.Services.OpenAI;

public class OpenRouterService : IGenerateReportAi
{
    private readonly ChatClient _chatClient;
    public OpenRouterService(ChatClient client) => _chatClient = client;

    public async Task<string> Generate(string lessonContent, string teacher, string lessonDate, string lessonName)
    {
        var messages = new List<ChatMessage>
        {
            new SystemChatMessage(),
            new UserChatMessage()
        };

        var completion = await _chatClient.CompleteChatAsync(messages);

        var responseList = completion.Value.Content[0].Text
            .Split("\n")
            .Where(response => response.Trim().Equals(string.Empty).IsFalse())
            .Select(item => item.Replace("[", "").Replace("]", ""))
            .ToList();

        return responseList[0];
    }
}