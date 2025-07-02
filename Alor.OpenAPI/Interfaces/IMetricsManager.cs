using Alor.OpenAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alor.OpenAPI.Interfaces
{
    public interface IMetricsManager : IDisposable
    {
        public void UpdatePingHandler(Action<PingStats?>? PingChangedToUser);
        Action<Action<PingStats?>?>? UpdatePingChangedToUserDelegat { get; set; }
        public void UpdateWsPingHandler(Action<WsPingStats?>? WsPingChangedToUser);
        Action<Action<WsPingStats?>?>? UpdateWsPingChangedToUserDelegat { get; set; }
    }
}
