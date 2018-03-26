using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AsthmaApp
{
    [Activity(Label = "AsthmaApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
		Button questionnaireButton;
		Button mapButton;
		Button rewardButton;
		Button alarmButton;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            
            // Get our button from the layout resource,
            // and attach an event to it
            questionnaireButton = FindViewById<Button>(Resource.Id.questionnairebutton);
			mapButton = FindViewById<Button>(Resource.Id.mapbutton);
			rewardButton = FindViewById<Button>(Resource.Id.rewardsbutton);
			alarmButton = FindViewById<Button>(Resource.Id.alarmbutton);


			questionnaireButton.Click += QuestionnaireButton_Click;
		}

		private void QuestionnaireButton_Click(object sender, EventArgs e)
		{
			StartActivity(typeof(QuestionnaireActivity));
		}
	}
}

