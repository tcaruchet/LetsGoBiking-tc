using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using LetsGoBiking_tc.Heavy.RoutingService;

namespace LetsGoBiking_tc.Heavy
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var route = new BikeRoutingServiceClient();
            try
            {
                // Making calls.
                var s = await route.GetStationsAsync();
                Console.WriteLine(s[0]);
                Console.WriteLine("Press ENTER to exit:");
                Console.ReadLine();
            }
            catch (TimeoutException timeProblem)
            {
                Console.WriteLine("The service operation timed out. " + timeProblem.Message);
                route.Abort();
                Console.ReadLine();
            }
            // Catch unrecognized faults. This handler receives exceptions thrown by WCF
            // services when ServiceDebugBehavior.IncludeExceptionDetailInFaults
            // is set to true.
            catch (FaultException faultEx)
            {
                Console.WriteLine("An unknown exception was received. "
                                  + faultEx.Message
                                  + faultEx.StackTrace
                );
                Console.Read();
                route.Abort();
            }
            // Standard communication fault handler.
            catch (CommunicationException commProblem)
            {
                Console.WriteLine("There was a communication problem. " + commProblem.Message + commProblem.StackTrace);
                Console.Read();
                route.Abort();
            }
        }
    }
}
