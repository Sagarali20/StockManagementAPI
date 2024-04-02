using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
	public  static  class DateTimeExtension
	{

		public static DateTime ClientToUTCTime(this DateTime datetime)
		{
			TimeZoneInfo userTimeZone = TimeZoneInfo.Local;
			// Local time
			DateTime localTime = DateTime.Now;

			// Convert local time to UTC time
			DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(datetime, userTimeZone);
			DateTime localTime2 = DateTime.UtcNow;

			return utcTime;

		}

		public static DateTime UTCToClientTime(this DateTime datetime)
		{
    		// Get the user's time zone or a specific time zone
			TimeZoneInfo userTimeZone = TimeZoneInfo.Local;
			// Convert UTC time to local time
			DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(datetime, userTimeZone);
			return localTime;
		}
		public static DateTime CurrentUtcTime()
		{			
			return DateTime.UtcNow;
		}


	}
}
