using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using SQLite;
using System.IO;

namespace icecream_test1
{
	[Activity(Label = "PlayChat", MainLauncher = false, Icon = "@drawable/PC_test_logo", Theme = "@style/MainActionBarTheme")]
	public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

			ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			SetContentView(Resource.Layout.ChatTab);

			AddTab ("Chat", Android.Resource.Color.Transparent, Resource.Layout.ChatTab);
			AddTab ("Story", Android.Resource.Color.Transparent, Resource.Layout.StoryTab);
			AddTab ("Explore", Android.Resource.Color.Transparent, Resource.Layout.ExploreTab);
			AddTab ("Friends", Android.Resource.Color.Transparent, Resource.Layout.FriendsTab);



			if (bundle != null)
				this.ActionBar.SelectTab(this.ActionBar.GetTabAt(bundle.GetInt("tab")));


            // Get our button from the layout resource,
            // and attach an event to it
			//Button button = FindViewById<Button>(Resource.Id.MyButton);

        }


		public override bool OnCreateOptionsMenu(IMenu menu) {
			var inflater = MenuInflater;
			inflater.Inflate (Resource.Menu.activity_main_actions, menu);

			return base.OnCreateOptionsMenu(menu);
		}


		protected override void OnSaveInstanceState(Bundle outState)
		{
			outState.PutInt("tab", this.ActionBar.SelectedNavigationIndex);

			base.OnSaveInstanceState(outState);
		}
			
		void AddTab (string tabText, int iconResourceId, int layoutResourceId)
		{
			var tab = this.ActionBar.NewTab ();            
			tab.SetText (tabText);
			tab.SetIcon (iconResourceId);

			// must set event handler before adding tab
			tab.TabSelected += delegate(object sender, ActionBar.TabEventArgs e)
			{

				SetContentView(layoutResourceId);

				if(layoutResourceId == Resource.Layout.ChatTab)
				{
					ChatTab();
				}
				else if(layoutResourceId == Resource.Layout.StoryTab)
				{
					StoryTab();
				}
				else if(layoutResourceId == Resource.Layout.ExploreTab)
				{
					ExploreTab();
				}
				else if(layoutResourceId == Resource.Layout.FriendsTab)
				{
					FriendsTab();
				}
					
			};
			tab.TabUnselected += delegate(object sender, ActionBar.TabEventArgs e) {

			};

			this.ActionBar.AddTab (tab);
		}

		void ChatTab()
		{
			this.Window.SetTitle ("Chat");

		}

		void StoryTab()
		{
			this.Window.SetTitle ("Story");
		}

		void ExploreTab()
		{
			this.Window.SetTitle ("Explore");
			Button MakeFriendsButton = FindViewById<Button> (Resource.Id.Button_MakeFriends);
			MakeFriendsButton.Click += (sender, e) =>
			{
				var intent = new Intent(this, typeof(MakeFriendsActivity));
				StartActivity(intent);
			};

		}

		void FriendsTab()
		{
			int count = 30;

			//Friends Tab
			this.Window.SetTitle ("Friends "+ count);
			var contactsAdapter = new ContactsAdapter (this);
			var ContactsListView = FindViewById<ListView> (Resource.Id.ContactsListView);
			ContactsListView.Adapter = contactsAdapter;

		}

    }
		


}

