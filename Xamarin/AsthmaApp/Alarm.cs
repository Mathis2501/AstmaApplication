using System;

namespace AsthmaApp
{
	public class Alarm
	{
		public long Id;
		public Guid guid;
		public int Hour;
		public int Minute;

		public bool[] Weekdays;

		public Alarm()
		{
			Weekdays = new bool[7];
			guid = new Guid();
		}

		public Alarm(int h, int m, bool[] weekdays)
		{
			Hour = h;
			Minute = m;
			Weekdays = weekdays;
		}
	}
}