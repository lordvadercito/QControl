using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterControl.Controllers.Helpers
{
    public class NetworkStatus
    {
        public bool NetworkUp()
        {
            bool networkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            return networkUp;
        }
    }
}
