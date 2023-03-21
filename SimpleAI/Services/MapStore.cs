using SimpleAI.Core;

namespace SimpleAI.Services;

public class MapStore
{
    public List<Map> Maps;
    private CoreConfig Cfg;
    public MapStore(CoreConfig cfg)
    {
        Cfg = cfg;
        Maps = new List<Map>();
        for (int i = 0; i < cfg.Nodes; i++)
        {
            Maps.Add(new Map(Cfg));
        }
    }

    internal void Improve(int nodes)
    {
        switch (nodes)
        {
            case 0:
                Maps.RemoveAt(Maps.Count-1);
                Maps.Add(new Map(Cfg));
                break;
            case 1:
                var t = Maps[0];
                Maps.RemoveAt(0);
                Maps.Insert(1, t);
                Maps.RemoveAt(Maps.Count - 1);
                Maps.Add(new Map(Cfg));
                break;
            case 2:
                Maps.Insert(0, Maps[2]);
                Maps.RemoveAt(2);
                Maps.RemoveAt(3);
                Maps.Add(new Map(Cfg));
                break;
        }
    }

    internal List<float> Process(List<float> core, int node)
    {
        return Maps[node].Calculate(core);
    }
}
