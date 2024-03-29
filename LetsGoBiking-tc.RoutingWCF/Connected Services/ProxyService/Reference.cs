﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LetsGoBiking_tc.RoutingWCF.ProxyService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProxyService.IProxyService")]
    public interface IProxyService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyService/GetStations", ReplyAction="http://tempuri.org/IProxyService/GetStationsResponse")]
        string GetStations();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyService/GetStations", ReplyAction="http://tempuri.org/IProxyService/GetStationsResponse")]
        System.Threading.Tasks.Task<string> GetStationsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyService/GetStationsCity", ReplyAction="http://tempuri.org/IProxyService/GetStationsCityResponse")]
        string GetStationsCity(string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyService/GetStationsCity", ReplyAction="http://tempuri.org/IProxyService/GetStationsCityResponse")]
        System.Threading.Tasks.Task<string> GetStationsCityAsync(string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyService/GetStation", ReplyAction="http://tempuri.org/IProxyService/GetStationResponse")]
        string GetStation(string city, string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyService/GetStation", ReplyAction="http://tempuri.org/IProxyService/GetStationResponse")]
        System.Threading.Tasks.Task<string> GetStationAsync(string city, string id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProxyServiceChannel : LetsGoBiking_tc.RoutingWCF.ProxyService.IProxyService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProxyServiceClient : System.ServiceModel.ClientBase<LetsGoBiking_tc.RoutingWCF.ProxyService.IProxyService>, LetsGoBiking_tc.RoutingWCF.ProxyService.IProxyService {
        
        public ProxyServiceClient() {
        }
        
        public ProxyServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProxyServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProxyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProxyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetStations() {
            return base.Channel.GetStations();
        }
        
        public System.Threading.Tasks.Task<string> GetStationsAsync() {
            return base.Channel.GetStationsAsync();
        }
        
        public string GetStationsCity(string city) {
            return base.Channel.GetStationsCity(city);
        }
        
        public System.Threading.Tasks.Task<string> GetStationsCityAsync(string city) {
            return base.Channel.GetStationsCityAsync(city);
        }
        
        public string GetStation(string city, string id) {
            return base.Channel.GetStation(city, id);
        }
        
        public System.Threading.Tasks.Task<string> GetStationAsync(string city, string id) {
            return base.Channel.GetStationAsync(city, id);
        }
    }
}
