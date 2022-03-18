using Newtonsoft.Json;

namespace LetsGoBiking_tc.Lib.Models;

public class Position
{
    public Position()
    {
    }

    public Position(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    [JsonProperty("latitude")]
    public double Latitude { get; set; }

    [JsonProperty("longitude")]
    public double Longitude { get; set; }

    protected bool Equals(Position other)
    {
        return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Position)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (Latitude.GetHashCode() * 397) ^ Longitude.GetHashCode();
        }
    }

    public override string ToString()
    {
        return $"{nameof(Latitude)}: {Latitude}, {nameof(Longitude)}: {Longitude}";
    }
}