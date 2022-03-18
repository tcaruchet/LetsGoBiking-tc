using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsGoBiking_tc.Lib.Models
{
    public class Station
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("contractName")]
        public string ContractName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        [JsonProperty("banking")]
        public bool Banking { get; set; }

        [JsonProperty("bonus")]
        public bool Bonus { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("lastUpdate")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty("connected")]
        public bool Connected { get; set; }

        [JsonProperty("overflow")]
        public bool Overflow { get; set; }

        [JsonProperty("shape")]
        public object Shape { get; set; }

        [JsonProperty("totalStands")]
        public TotalStands TotalStands { get; set; }

        [JsonProperty("mainStands")]
        public MainStands MainStands { get; set; }

        [JsonProperty("overflowStands")]
        public object OverflowStands { get; set; }


        public override string ToString()
        {
            return $"{nameof(Number)}: {Number}, {nameof(ContractName)}: {ContractName}, {nameof(Name)}: {Name}, {nameof(Address)}: {Address}, {nameof(Position)}: {Position}, {nameof(Banking)}: {Banking}, {nameof(Bonus)}: {Bonus}, {nameof(Status)}: {Status}, {nameof(LastUpdate)}: {LastUpdate}, {nameof(Connected)}: {Connected}, {nameof(Overflow)}: {Overflow}, {nameof(Shape)}: {Shape}, {nameof(TotalStands)}: {TotalStands}, {nameof(MainStands)}: {MainStands}, {nameof(OverflowStands)}: {OverflowStands}";
        }
    }
}
