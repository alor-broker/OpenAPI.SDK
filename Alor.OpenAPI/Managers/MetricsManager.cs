using Alor.OpenAPI.Interfaces;
using Alor.OpenAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alor.OpenAPI.Managers
{
    public class MetricsManager : IMetricsManager
    {
        private readonly IMetricsService _service;
        internal MetricsManager(IMetricsService service) { 
            _service = service;
        }
        public void UpdatePingHandler(Action<PingStats?>? pingStatsChangedToUser)
        {
            _service.UpdatePingStatsUserDelegate(pingStatsChangedToUser);
        }
        public Action<Action<PingStats?>?>? UpdatePingChangedToUserDelegat { get; set; }
        public void UpdateWsPingHandler(Action<WsPingStats?>? wsPingStatsChangedToUser)
        {
            _service.UpdateWsPingStatsUserDelegate(wsPingStatsChangedToUser);
        }
        public Action<Action<WsPingStats?>?>? UpdateWsPingChangedToUserDelegat { get; set; }

        public void Dispose()
        {
            UpdatePingChangedToUserDelegat = null;
            UpdateWsPingChangedToUserDelegat = null;
        }
    }
}
