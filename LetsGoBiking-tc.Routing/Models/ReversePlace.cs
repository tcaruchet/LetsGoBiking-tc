﻿namespace LetsGoBiking_tc.Routing.Models
{
    public class ReversePlace
    {
        public int place_id { get; set; }
        public string licence { get; set; }
        public string osm_type { get; set; }
        public long osm_id { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string display_name { get; set; }
        public Address address { get; set; }
        public string[] boundingbox { get; set; }
    }
    public class Address
    {
        public string tourism { get; set; }
        public string road { get; set; }
        public string suburb { get; set; }
        public string city { get; set; }
        public string municipality { get; set; }
        public string county { get; set; }
        public string state_district { get; set; }
        public string state { get; set; }
        public string region { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
    }
}