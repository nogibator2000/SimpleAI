
namespace SimpleAI.Core;
public class Unit
{
    public int UnitId { get; set; }
    public float UnitValue { get; set; }
    public float UnitPoint { get; set; }
    public List<Unit> UnitConnections { get; set; }
    public Unit(int unitId)
    {
        UnitId = unitId;
        UnitValue = new Random().NextSingle();
        UnitConnections = new List<Unit>();
    }

}
