using System.Text;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Spectre.Console;

internal static class ChatApplication
{
    internal static async Task StartAsync(string modelId)
    {
        Kernel kernel = KernelFactory.CreateKernel(modelId);

        AnsiConsole.MarkupLine("[green]Created kernel '{0}'.[/]", modelId);

        var chatService = kernel.GetRequiredService<IChatCompletionService>();
        var chatHistory = new ChatHistory("You are a snarky AI assistant that reluctantly helps people find answers to their questions.");
        var builder = new StringBuilder();

        while (true)
        {
            AnsiConsole.WriteLine();
            string question = AnsiConsole.Ask<string>("Ask me anything:");

            chatHistory.AddUserMessage(question);

            builder.Clear();

            AnsiConsole.WriteLine();

            await foreach (StreamingChatMessageContent message in chatService.GetStreamingChatMessageContentsAsync(chatHistory, kernel: kernel))
            {
                AnsiConsole.Markup($"[italic]{message}[/]");
                builder.Append(message.Content);
            }

            chatHistory.AddAssistantMessage(builder.ToString());
            AnsiConsole.WriteLine();
        }
    }
}