namespace Alor.OpenAPI.Extensions
{
    public static class DateTimeUtils
    {
        public static DateTime Truncate(this DateTime date, long resolution)
        {
            return new DateTime(date.Ticks - (date.Ticks % resolution), date.Kind);
        }

        public static TimeSpan Elapsed(this DateTimeOffset date) => DateTimeOffset.Now.Subtract(date);

        private static readonly DateTime UnixEpoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long GetCurrentUnixTimestampMillis()
        {
            return (long)(DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
        }

        public static long? GetUnixTimestampMillis(this DateTime? dateTime)
        {
            if (dateTime == null) return null;
            return (long)(dateTime.Value.Subtract(UnixEpoch)).TotalMilliseconds;
        }

        public static long GetUnixTimestampMillis(this DateTime dateTime)
        {
            return (long)(dateTime.Subtract(UnixEpoch)).TotalMilliseconds;
        }


        public static long GetUnixTimestampSecondsFromDateTime(this DateTime dateTime)
        {
            return (long)(dateTime.Subtract(UnixEpoch)).TotalSeconds;
        }

        public static long? GetUnixTimestampMillis(this DateTimeOffset? dateTime)
        {
            if (dateTime == null) return null;
            return (long)(dateTime.Value.UtcDateTime.Subtract(UnixEpoch)).TotalMilliseconds;
        }

        public static long GetUnixTimestampSecondsFromDateTime(this DateTimeOffset dateTime)
        {
            return (long)(dateTime.UtcDateTime.Subtract(UnixEpoch)).TotalSeconds;
        }

        public static DateTime DateTimeFromUnixTimestampMillis(this long millis)
        {
            return UnixEpoch.AddMilliseconds(millis);
        }

        public static DateTime? DateTimeFromUnixTimestampMillis(this long? millis)
        {
            return millis?.DateTimeFromUnixTimestampMillis();
        }

        public static long GetCurrentUnixTimestampSeconds()
        {
            return (long)(DateTime.UtcNow - UnixEpoch).TotalSeconds;
        }

        public static DateTime DateTimeFromUnixTimestampSeconds(this long seconds)
        {
            return UnixEpoch.AddSeconds(seconds);
        }

        public static DateTime? DateTimeFromUnixTimestampSeconds(this long? seconds)
        {
            if (!seconds.HasValue) return null;
            return UnixEpoch.AddSeconds(seconds.Value);
        }
    }
}
