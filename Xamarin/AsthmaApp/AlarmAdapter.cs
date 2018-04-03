using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Provider;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace AsthmaApp
{
	class AlarmAdapter : BaseAdapter
	{
		Alarm[] Alarms;

		Activity Activity;

		public AlarmAdapter(Activity act)
		{
			Activity = act;
			Fill();
		}

		public override int Count => Alarms.Length;

		public override Java.Lang.Object GetItem(int position)
		{
			return null;
		}

		public override long GetItemId(int position)
		{
			return Alarms[position].Id;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView ?? Activity.LayoutInflater.Inflate(Resource.Layout.AlarmItem, parent, false);
			var hour = view.FindViewById<TextView>(Resource.Id.HourText);
			var minute = view.FindViewById<TextView>(Resource.Id.MinuteText);
			var second = view.FindViewById<TextView>(Resource.Id.SecondText);
			var activated = view.FindViewById<TextView>(Resource.Id.ActivatedText);
			hour.Text = Alarms[position].Hour.ToString() + "H";
			minute.Text = Alarms[position].Minute.ToString() + "M";
			second.Text = Alarms[position].Second.ToString() + "S";
			activated.Text = Alarms[position].Activated.ToString();

			return view;
		}

		private void Fill()
		{
			// Mock
			Alarms = new[]
			{
				new Alarm(12, 0, 0, true),
				new Alarm(13, 20, 0, true)
			};
			// EndMock
		}

	}
}