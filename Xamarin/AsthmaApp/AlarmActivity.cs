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
using Newtonsoft.Json;

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
            AlarmList.ItemClick += AlarmList_ItemClick;
		}

        private void AlarmList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = new Intent(this, typeof(AlarmDetailsActivity));
            intent.PutExtra("AlarmData", JsonConvert.SerializeObject(adapter.Alarms[e.Position]));
            StartActivity(intent);
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
				adapter.Alarms.Add(new Alarm(rand.Next(24), rand.Next(60), new bool[]{true, true, true, false, false, false, true}));
				adapter.NotifyDataSetChanged();	
			}
			return base.OnOptionsItemSelected(item);
		}
	}
}