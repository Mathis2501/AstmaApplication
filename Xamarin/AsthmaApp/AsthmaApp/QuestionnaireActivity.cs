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
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = locator.GetPositionAsync().Result;
                Toast.MakeText(this, "Lat: " + position.Latitude + " - Long: " + position.Longitude, ToastLength.Long);
            }
            catch(Exception i)
            {
                Toast.MakeText(this, i.Message, ToastLength.Long);
            }
                //Finish();
            }

	}
}