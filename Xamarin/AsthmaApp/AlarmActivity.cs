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
		AlarmAdapter adapter;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Alarm);

			adapter = new AlarmAdapter(this);
			AlarmList = FindViewById<ListView>(Resource.Id.AlarmListView);			
			AlarmList.Adapter = adapter;

			var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
			SetActionBar(toolbar);
			ActionBar.Title = "Alarms";
		}
		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.top_menus, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			if(item.ItemId == Resource.Id.menu_add)
			{
				Random rand = new Random();
				adapter.Alarms.Add(new Alarm(rand.Next(24), rand.Next(60), rand.Next(60), true));
				adapter.NotifyDataSetChanged();	
			}
			return base.OnOptionsItemSelected(item);
		}
	}
}