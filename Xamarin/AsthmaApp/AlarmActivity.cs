using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AsthmaApp
{
	[Activity(Label = "AlarmActivity")]
	public class AlarmActivity : Activity
	{
		ListView AlarmList;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Alarm);

			var AlarmAdapter = new AlarmAdapter(this);
			AlarmList = FindViewById<ListView>(Resource.Id.AlarmListView);			
			AlarmList.Adapter = AlarmAdapter;

			var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			SetActionBar(toolbar);
			ActionBar.Title = "Alarms";

			FindViewById<Button>(Resource.Id.AddButton).Click += AddButton_Click;
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.top_menus, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
				ToastLength.Short).Show();
			return base.OnOptionsItemSelected(item);
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			Toast.MakeText(ApplicationContext, "Alarmer++", ToastLength.Long).Show();
		}
	}
}