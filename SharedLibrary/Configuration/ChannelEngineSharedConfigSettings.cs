using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngineShared.Configuration
{
    public class ChannelEngineSharedConfigOptions
    {
        public const string ServiceConfiguration = "ChannelEngineService";

        public string ApiKey { get; set; }

        public string BaseUrl { get; set; }
    }
}
