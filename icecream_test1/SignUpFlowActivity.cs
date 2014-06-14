
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
	public class SignUpInfo
	{
		public static string userName;
		public static string password;
		public static string confirmPassword;
		public static string displayName;
		public static string mobileNumber;
		public static string email;
		public static string gender;
		public static string country;
		public static string state;
		public static string city;
		public static string ethnicity; //separated by commas
		public static int gameId;


	}

	[Activity (Label = "SignUpFlow")]			
	public class SignUpFlowActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.SignUpPage1Membership);

			SignUpMembership ();
		}

		private void SignUpMembership()
		{
			Button page1Next = FindViewById<Button> (Resource.Id.SignUpPage1_NextButton);
			page1Next.Click += (sender, e) =>
			{
				SignUpInfo.userName = GetText(Resource.Id.SignUpPage1_Username);
				SignUpInfo.password = GetText(Resource.Id.SignUpPage1_Password);
				SignUpInfo.confirmPassword = GetText(Resource.Id.SignUpPage1_PasswordConfirm);

				if(SignUpInfo.userName.Length < 3)
				{
					string toast = string.Format ("Username must be at least 3 characters "+SignUpInfo.userName.Length);
					Toast.MakeText (this, toast, ToastLength.Long).Show ();
				}
				else if(SignUpInfo.password.Length < 6)
				{
					string toast = string.Format ("Password must be at least 6 characters" + GetText(Resource.Id.SignUpPage1_Password)); //= false? wat
					Toast.MakeText (this, toast, ToastLength.Long).Show ();
				}
				else if(!SignUpInfo.password.Equals(SignUpInfo.confirmPassword))
				{
					string toast = string.Format ("Passwords must match");
					Toast.MakeText (this, toast, ToastLength.Long).Show ();
				}

				else if(SignUpInfo.userName.Equals(null) || SignUpInfo.password.Equals(null) || SignUpInfo.confirmPassword.Equals(null))
				{

				}

				SignUpGeneral();
			};
		}

		private void SignUpGeneral()
		{
			SetContentView (Resource.Layout.SignUpPage2GeneralInfo);

			
		}


	}

}

