
namespace SimpleAI.Core;
public class Map
{
    private List<Unit> mapList;

    private void AddRow(int count)
    {
        for (var j = 0; j < count; j++)
        {
            mapList.Add(new Unit(mapList.Count));
        }
    }
    private void ConnectRow(int rowLength, int connectionCount)
    {
        for (var j = mapList.Count- rowLength; j < mapList.Count; j++)
        {
            for (var i = 0; i < connectionCount; i++)
            {
                mapList[j].UnitConnections.Add(mapList[j-i]);
            }
        }
    }
    public Map(CoreConfig cfg)
    {
        mapList = new();
        AddRow(cfg.UnitLength);
        for (var i = 1; i< cfg.UnitWidth; i++)
        {
            AddRow(cfg.UnitLength);
            ConnectRow(cfg.UnitLength, cfg.UnitConnections);
        }
	}


    internal List<float> Calculate(List<float> input)
    {
        var result = new List<float>();
        Reset();
        for (int i = 0; i < input.Count; i++)
        {
            mapList[i].UnitPoint= (mapList[i].UnitValue+input[i])/2;
            CalculateConnections(mapList[i]);
        }
        for (int i = input.Count; i < mapList.Count; i++)
        {
            CalculateConnections(mapList[i]);
        }
        for (int i = mapList.Count- input.Count; i < mapList.Count; i++)
        {
            result.Add(mapList[i].UnitPoint);
        }

        return result;
    }

    private void CalculateConnections(Unit unit)
    {
        foreach (var conn in unit.UnitConnections)
        {
            conn.UnitPoint = unit.UnitPoint + conn.UnitPoint / 2;
        }
    }

    private void Reset()
    {
        foreach (var unit in mapList)
        {
            unit.UnitPoint = unit.UnitValue;
        }
    }
    }
