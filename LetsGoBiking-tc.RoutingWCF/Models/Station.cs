using System;
using System.Runtime.Serialization;

namespace LetsGoBiking_tc.RoutingWCF.Models
{    
    [DataContract]
    public class Station
    {
        [DataMember] public int number { get; set; }
        [DataMember] public string contractName { get; set; }
        [DataMember] public string name { get; set; }
        [DataMember] public string address { get; set; }
        [DataMember] public JCDPosition position { get; set; }
        [DataMember] public bool banking { get; set; }
        [DataMember] public bool bonus { get; set; }
        [DataMember] public string status { get; set; }
        [DataMember] public DateTime lastUpdate { get; set; }
        [DataMember] public bool connected { get; set; }
        [DataMember] public StandInfo totalStands { get; set; }
    }

    [DataContract]
    public class StandInfo
    {
        [DataMember] public StandAvailability availabilities { get; set; }
        [DataMember] public int capacity { get; set; }

        public override string ToString()
        {
            return $"{availabilities.bikes}/{capacity}";
        }
    }

    [DataContract]
    public class StandAvailability
    {
        [DataMember] public int bikes { get; set; }
    }
}