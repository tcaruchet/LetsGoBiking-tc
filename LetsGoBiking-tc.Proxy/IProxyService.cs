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
            UriTemplate = "GetStations")]
        Task<string> GetStationsAsync();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GetStation/{id}")]
        Task<string> GetStationAsync(string id);
    }
}
