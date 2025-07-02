using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Alor.OpenAPI.Models
{
    public class WsPingStats
    {
        public WsPingStats(WsResponseMessage? status, DateTime sendTime, DateTime? reciveTime, bool isUnsubscribe)
        {
            Status = status;
            SendTime = sendTime;
            ReciveTime = reciveTime;
            IsUnsubscribe = isUnsubscribe;
        }

        public WsResponseMessage? Status { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime? ReciveTime { get; set; }
        public bool IsUnsubscribe { get; set; }
        public double? GetDelay()
        {
            return (ReciveTime - SendTime).GetValueOrDefault().TotalMilliseconds;
        }
    }
}
