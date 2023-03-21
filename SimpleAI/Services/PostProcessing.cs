using SimpleAI.Dictionary;

namespace SimpleAI.Services;
public static class PostProcessing
{

    internal static string Process(List<float> input, LanguageStore store)
    {
        var processedString = "";
            processedString += store.GetString(input);
            processedString += Environment.NewLine;
        return processedString;
    }
}
