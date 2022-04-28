using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace LetsGoBiking_tc.Proxy
{
    [ServiceContract]
    public interface IProxyService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Stations")]
        Task<string> GetStationsAsync();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Station/{city}")]
        Task<string> GetStationsCityAsync(string city);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "Station/{city}/{id}")]
        Task<string> GetStationAsync(string city, string id);

        
    }
}
