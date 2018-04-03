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
		public List<Alarm> Alarms;

		Activity Activity;

		public AlarmAdapter(Activity act)
		{
			Activity = act;
			Fill();
		}

		public override int Count => Alarms.Count;

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
			var time = view.FindViewById<TextView>(Resource.Id.TimeText);
			var activated = view.FindViewById<TextView>(Resource.Id.ActivatedText);
			time.Text = "Tidspunkt: "+ Alarms[position].Hour.ToString() + "H " + 
				Alarms[position].Minute.ToString() + "M " + 
				Alarms[position].Second.ToString() + "S";
			activated.Text = "Aktiveret: "+Alarms[position].Activated.ToString();

			time.Click += Time_Click;
			return view;
		}

		private void Time_Click(object sender, EventArgs e)
		{
			var time = (TextView)sender;
			time.Text = "You clicked me!";
		}

		private void Fill()
		{
			// Mock
			Alarms = new List<Alarm>()
			{
				new Alarm(12, 0, 0, true),
				new Alarm(13, 20, 0, true)
			};
			// EndMock
		}

	}
}