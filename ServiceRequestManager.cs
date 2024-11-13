using System.Collections.Generic;

namespace mary_tshabalala_MunicipalServicesApp
{
    public static class ServiceRequestManager
    {
        public static List<ServiceRequest> serviceRequests = new List<ServiceRequest>();

        public static void AddRequest(ServiceRequest request)
        {
            serviceRequests.Add(request);
        }
        public static List<ServiceRequest> GetAllRequests()
        {
            return serviceRequests;
        }

    }
}