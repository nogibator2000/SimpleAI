using SimpleAI.Dictionary;
using SimpleAI.Services;

namespace SimpleAI.Core;
public class CoreEngine
{
    private LanguageStore LanguageStore { get; set; }
    public MapStore Map { get; set; }
    private CoreConfig Cfg { get; set; }

    public CoreEngine(CoreConfig cfg)
    {
        Cfg = cfg;
        LanguageStore = new();
        Map = new MapStore(Cfg);
    }

    public string Process(string? input)
    {
        var output = "";
        var core = PreProcessing.Process(input, LanguageStore);
        for (int i = 0; i < Cfg.Nodes; i++)
        {
            output += $"node {i} - ";
            output += PostProcessing.Process(Map.Process(core, i), LanguageStore);
        }

        return output;
    }

}
