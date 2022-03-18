using Newtonsoft.Json;

namespace LetsGoBiking_tc.Lib.Models;

public class TotalStands
{
    [JsonProperty("availabilities")]
    public Availabilities Availabilities { get; set; }

    [JsonProperty("capacity")]
    public int Capacity { get; set; }

    public override string ToString()
    {
        return $"{nameof(Availabilities)}: {Availabilities}, {nameof(Capacity)}: {Capacity}";
    }
}