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
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Stations/Nearest/{latitude}/{longitude}")]
        Task<Station> FindNearestStation(string latitude, string longitude);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Stations/Around/{latitude}/{longitude}/{radius}")]
        Task<List<Station>> FindStationsAround(string latitude, string longitude, string radius);

        //OpenStreetMap
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Position/{address}")]
        Task<JCDPosition> GetPosition(string address);

        //OpenService
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Route/Path")]
        Task<GeoJson> GetRoute(JCDPosition[] positions);
    }
}
