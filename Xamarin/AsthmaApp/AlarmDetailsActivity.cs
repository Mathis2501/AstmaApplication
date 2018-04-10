using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Newtonsoft.Json;

namespace AsthmaApp
{
    [Activity(Label = "AlarmDetailsActivity")]
    public class AlarmDetailsActivity : Activity
    {
        private TimePicker timepicker;

	    private string[] Weekdays;
		protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AlarmDetails);

			Weekdays = new string[]{"M", "T", "W", "T", "F", "S", "S"};

            timepicker = FindViewById<TimePicker>(Resource.Id.TimePicker);
            Alarm alarm = JsonConvert.DeserializeObject<Alarm>(Intent.GetStringExtra("AlarmData"));
            timepicker.SetIs24HourView((Java.Lang.Boolean)true);
            timepicker.Hour = alarm.Hour;
            timepicker.Minute = alarm.Minute;

	        for (int i = 0; i < 7; i++)
	        {
		        TextView tv = new TextView(this);
		        tv.Text = Weekdays[i];
		        tv.TextSize = 40f;
		        tv.SetPadding(15, 15, 15, 15);
		        tv.SetTextColor(alarm.Weekdays[i] ? new Color(255, 255, 255) : new Color(100, 100, 100));
		        int j = i;
				tv.Click +=
			        (object sender, EventArgs e) =>
			        {
				        tv.SetTextColor(alarm.Weekdays[j] ? new Color(100, 100, 100) : new Color(255, 255, 255));
				        alarm.Weekdays[j] = !alarm.Weekdays[j];
			        };
		        var wll = FindViewById<LinearLayout>(Resource.Id.WeekdayLinearLayout);
		        wll.AddView(tv);
	        }
        }
        
	}
}