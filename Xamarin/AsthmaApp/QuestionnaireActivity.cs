using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System.Threading.Tasks;

namespace AsthmaApp
{
	[Activity(Label = "QuestionnaireActivity")]
	public class QuestionnaireActivity : Activity
	{
		Button testButton;
		Button finishButton;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Questionnaire);

			testButton = FindViewById<Button>(Resource.Id.questionnairebutton);
			testButton.Click += TestButton_Click;

			finishButton = FindViewById<Button>(Resource.Id.finishbutton);
			finishButton.Click += FinishButton_Click;
		}

		private void TestButton_Click(object sender, EventArgs e)
		{
			Toast.MakeText(this, "Hello", ToastLength.Long);
		}
		private void FinishButton_Click(object sender, EventArgs e)
		{
			GetCurrentPosition(); // Wait() låser threaden
			//Finish();
		}

		private async Task<Position> GetCurrentPosition()
		{
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;
			var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(1));
			Toast.MakeText(ApplicationContext, "Lat: " + position.Latitude + " - Long: " + position.Longitude, ToastLength.Long).Show();
			return position;
		}

	}
}