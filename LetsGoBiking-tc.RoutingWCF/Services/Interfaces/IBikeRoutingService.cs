using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using LetsGoBiking_tc.RoutingWCF.Models;

namespace LetsGoBiking_tc.RoutingWCF.Services.Interfaces
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IRoutingService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IBikeRoutingService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Stations")]
        Task<List<Station>> GetStationsAsync();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Stations/{city}")]
        Task<List<Station>> GetStationsCityAsync(string city);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Stations/{city}/{id}")]
        Task<Station> GetStationAsync(string city, string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetRoute")]
        Task<Stream> GetRoute(RouteParameters points);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Geocode")]
        Task<Stream> Geocode(GeocodeParameters geo);
    }

    [DataContract]
    public class RouteParameters
    {
        [DataMember] public JCDPosition start { get; set; }
        [DataMember] public JCDPosition end { get; set; }
    }

    [DataContract]
    public class GeocodeParameters
    {
        [DataMember] public string query { get; set; }
        [DataMember] public JCDPosition focus { get; set; }
    }
}
