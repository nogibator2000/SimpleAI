using SimpleAI.Dictionary;

namespace SimpleAI.Services;
public static class PreProcessing
{
    internal static List<float> Process(string s, LanguageStore store)
    {
       return store.GetMask(s);
    }
}
