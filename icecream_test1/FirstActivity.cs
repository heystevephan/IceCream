
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



namespace icecream_test1
{
	[Activity (Label = "FirstActivity", MainLauncher = true)]
	public class FirstActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.FirstPage);

			Button SignInButton = FindViewById<Button> (Resource.Id.FirstPage_SignInButton);
			SignInButton.Click += (sender, e) =>
			{
				var intent = new Intent(this, typeof(SignInActivity));
				StartActivity(intent);
			};


			Button SignUpButton = FindViewById<Button> (Resource.Id.FirstPage_SignUpButton);
			SignUpButton.Click += (sender, e) =>
			{
				var intent = new Intent(this, typeof(SignUpFlowActivity));
				StartActivity(intent);
			};
		}
	}
}

