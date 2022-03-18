using Newtonsoft.Json;

namespace LetsGoBiking_tc.Lib.Models;

public class Availabilities
{
    [JsonProperty("bikes")]
    public int Bikes { get; set; }

    [JsonProperty("stands")]
    public int Stands { get; set; }

    [JsonProperty("mechanicalBikes")]
    public int MechanicalBikes { get; set; }

    [JsonProperty("electricalBikes")]
    public int ElectricalBikes { get; set; }

    [JsonProperty("electricalInternalBatteryBikes")]
    public int ElectricalInternalBatteryBikes { get; set; }

    [JsonProperty("electricalRemovableBatteryBikes")]
    public int ElectricalRemovableBatteryBikes { get; set; }

    public override string ToString()
    {
        return $"{nameof(Bikes)}: {Bikes}, {nameof(Stands)}: {Stands}, {nameof(MechanicalBikes)}: {MechanicalBikes}, {nameof(ElectricalBikes)}: {ElectricalBikes}, {nameof(ElectricalInternalBatteryBikes)}: {ElectricalInternalBatteryBikes}, {nameof(ElectricalRemovableBatteryBikes)}: {ElectricalRemovableBatteryBikes}";
    }
}