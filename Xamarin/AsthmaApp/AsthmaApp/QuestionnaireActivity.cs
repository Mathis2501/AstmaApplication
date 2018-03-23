﻿using System;
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
	[Activity(Label = "QuestionnaireActivity")]
	public class QuestionnaireActivity : Activity
	{
		Button testButton;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Questionnaire);

			testButton = FindViewById<Button>(Resource.Id.questionnairebutton);

			testButton.Click += TestButton_Click;
			
		}

		private void TestButton_Click(object sender, EventArgs e)
		{
			Toast.MakeText(this, "Hello", ToastLength.Long);
		}
	}
}