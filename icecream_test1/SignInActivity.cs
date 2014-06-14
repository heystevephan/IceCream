
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
	[Activity (Label = "SignInActivity")]			
	public class SignInActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.SignInPage);

			Button SignInButton = FindViewById<Button> (Resource.Id.SignInPage_SignInButton);
			SignInButton.Click += (sender, e) =>
			{
				var intent = new Intent(this, typeof(MainActivity));
				StartActivity(intent);
			};
		}
	}
}

