using System;

namespace AsthmaApp
{
	public class Alarm
	{
		public long Id;

		public int Hour;
		public int Minute;
		public int Second;

		public bool Activated;

		public Alarm()
		{

		}

		public Alarm(int h, int m, int s, bool activated)
		{
			Hour = h;
			Minute = m;
			Second = s;
			Activated = activated;
		}
	}
}