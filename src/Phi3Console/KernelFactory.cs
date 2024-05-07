using Microsoft.SemanticKernel;

internal static class KernelFactory
{
    internal static Kernel CreateKernel(string modelId)
    {
        var kernelBuilder = Kernel.CreateBuilder();
#pragma warning disable SKEXP0010 // AddOpenAIChatCompletion is for evaluation purposes only and is subject to change or removal in future updates.
        var kernel = kernelBuilder
            .AddOpenAIChatCompletion(
                modelId: modelId,
                apiKey: null,
                endpoint: new Uri("http://localhost:11434")) // With Ollama OpenAI API endpoint
            .Build();
#pragma warning restore SKEXP0010 // AddOpenAIChatCompletion is for evaluation purposes only and is subject to change or removal in future updates.
        return kernel;
    }
}