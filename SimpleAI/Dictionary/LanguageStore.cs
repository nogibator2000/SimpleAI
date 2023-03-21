
namespace SimpleAI.Dictionary;

public class LanguageStore
{
    private static Dictionary<float, string> Dictionary { get; set; }

    public LanguageStore()
    {
        Dictionary = new();
    }

    private string[] SplitInput(string? input)
    {
            return input.Split(" ");
   }

    private void Add(string[] words)
    {
        foreach (var word in words)
        {
            if (!Dictionary.ContainsValue(word))
            {
                var stat = new Random().NextSingle();
                Dictionary.Add(stat, word);
            }
        }
    }

    public List<float> GetMask(string? input)
    {
        var response = new List<float>();
        var words = SplitInput(input);
        Add(words);
        foreach (var word in words)
        {
            response.Add(Dictionary.FirstOrDefault(x => x.Value == word).Key);
        }

        return response;
    }
    public string GetString(List<float> input)
    {
        var response = "";
        foreach (var item in input)
        {
            response += Dictionary.MinBy(x=> Math.Abs(x.Key - item)).Value +" ";
        }
        return response;
    }
}

