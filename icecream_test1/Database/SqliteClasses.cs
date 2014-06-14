
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

using SQLite;
using System.IO;

namespace icecream_test1
{
	public class Stock
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[MaxLength(8)]
		public string Symbol { get; set; }
	}

	public class Valuation
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[Indexed]
		public int StockId { get; set; }
		public DateTime Time { get; set; }
		public decimal Price { get; set; }
	}

	public class Membership
	{
		[PrimaryKey, AutoIncrement]
		public int MembershipId { get; set; }

		public string MembershipName { get; set; }

		[MaxLength(1)]
		public string MembershipActiveIndicator { get; set; }
		public string MembershipPasswordText { get; set; }
		public string MembershipPasswordSalt { get; set; }
		public string MembershipMobilePinText { get; set; }
		public string MembershipPasswordQuestion { get; set; }
		public string MembershipPasswordAnswer { get; set; }

		[MaxLength(1)]
		public string MembershipApprovedIndicator { get; set; }
		[MaxLength(1)]
		public string MembershipLockoutIndicator { get; set; }

		public DateTime MembershipLastLoginDate { get; set; }
		public DateTime MembershipLastLogoutDate { get; set; }
		public int MembershipPasswordAttemptNum { get; set; }
		public DateTime MembershipPasswordAttemptDate { get; set; }

		[Indexed]
		public int Membership_UserId { get; set; }

		public DateTime MembershipCreatedDate { get; set; }
		public int MembershipCreatedId { get; set; } //??
	}

	public class User
	{
		[PrimaryKey, AutoIncrement]
		public int UserId { get; set; }

		public bool UserActiveIndicator { get; set; }
		public DateTime UserLastactiveDate { get; set; }

		[Indexed]
		public int User_PersonId { get; set; }

		public int UserCreatedId { get; set; } //??
		public DateTime UserCreatedDate { get; set; }
	}

	public class Person
	{
		[PrimaryKey, AutoIncrement]
		public int PersonId { get; set; }

		[MaxLength(1)]
		public string PersonGender { get; set; }
		public int PersonAge { get; set; }

		[MaxLength(30)]
		public string PersonRealName{ get; set; }

		[MaxLength(30)]
		public string PersonDisplayName{ get; set; }

		public string Ethnicity{ get; set; } //separated by commas

		public byte[] PersonProfilePic { get; set; }
		public byte[] PersonProfilePicThumb { get; set; }
		public byte[] PersonCoverPic { get; set; }
		public string PersonMoodMsg { get; set; }
	}

	public class Contact
	{
		[PrimaryKey, AutoIncrement]
		public int ContactId { get; set; }

		public DateTime ContactCreatedDate { get; set; }

		[Indexed]
		public int ContactUserId { get; set; }

		[Indexed]
		public int ContactUserId2 { get; set; }

		public string ContactNotes { get; set; }
		public string ContactCustomDisplayName { get; set; }
		public bool ContactBlocked { get; set; }
		public bool ContactFavorite { get; set; }
	}

	public class Game
	{
		public int GameId { get; set; }
		public string GameName { get; set; }
		public byte[] GameImage { get; set; }
		public string GameGenre { get; set; }
		public string GamePlatforms { get; set; } //separated by commas
		public string GameRegionName { get; set; } //separated by commas
		public string ReleaseYear { get; set; }
		public string GameDescription { get; set; }
		public int GameCreatedId { get; set; }
		public DateTime GameCreatedDate { get; set; }

		[Indexed]
		public string Game_UserId { get; set; }
	}

	public class PlayedGame
	{
		[PrimaryKey, AutoIncrement]
		public int PlayedGameId { get; set; }

		public DateTime PlayedGameCreatedDate { get; set; }

		[Indexed]
		public int PlayedGamePersonId { get; set; }

		[Indexed]
		public int PlayedGameGameId { get; set; }
	}

	public class Address
	{
		[PrimaryKey, AutoIncrement]
		public int AddressId { get; set; }

		public string AddressLoc { get; set; }
		public string AddressText { get; set; }
		public string AddressCity { get; set; }
		public string AddressState { get; set; } 
		public string AddressCountry{ get; set; }
		public int AddressCreatedId { get; set; }
		public DateTime AddressCreatedDate { get; set; }
	}

	public class Email
	{
		[PrimaryKey, AutoIncrement]
		public int EmailId { get; set; }

		public bool EmailPrimaryIndicator { get; set; }

		[MaxLength(150)]
		public string EmailAddressText { get; set; }

		[Indexed]
		public string EmailPersonId { get; set; }

		public int EmailCreatedId { get; set; }
		public DateTime EmailCreatedDate { get; set; }
	}

	public class Phone
	{
		[PrimaryKey, AutoIncrement]
		public int PhoneId { get; set; }

		public bool PhonePrimaryIndicator { get; set; }
		public string PhoneNumber { get; set; }

		[Indexed]
		public int PhonePersonId { get; set; }

		public int PhoneCreatedId { get; set; }
		public DateTime PhoneCreatedDate { get; set; }
		public string PhoneType { get; set; } // ??
	}

	public class Post
	{
		[PrimaryKey, AutoIncrement]
		public int PostId { get; set; }

		[MaxLength(10000)]
		public string PostText { get; set; }
		public byte[] PostImage { get; set; }
		public DateTime PostCreatedDate { get; set; }

		[Indexed]
		public int PostPersonId { get; set; }

		public int PostLikes { get; set; } //add one per like, subtract if not like
		public int PostCreatedId { get; set; }
	}

	public class Likes
	{
		[PrimaryKey, AutoIncrement]
		public int LikesId { get; set; }

		//can only be one of the two below, a post or a comment
		[Indexed]
		public int LikesPostId { get; set; }
		[Indexed]
		public int LikesCommentId { get; set; } 

		public string LikesPersonId { get; set; }

	}

	public class Comment
	{
		[PrimaryKey, AutoIncrement]
		public int CommentId { get; set; }

		[MaxLength(10000)]
		public string CommentText { get; set; }
		public byte[] CommentImage { get; set; }
		public DateTime CommentCreatedDate { get; set; }

		public int CommentLikes { get; set; }

		[Indexed]
		public int CommentPostId { get; set; }

	}

	public class CreateDb
	{
		void createTables()
		{
			//string dbPath = Path.Combine (System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"PlayChat.db3");
			string dbPath = Path.Combine("C:\\Users\\taozh_000\\Desktop\\XamarinApps\\samples\\icecream_test1\\icecream_test1\\Database\\sqlitedb1","PlayChatTest1.sqlite");
			var db = new SQLiteConnection (dbPath);
			db.CreateTable<Membership> ();
			db.CreateTable<User> ();
			db.CreateTable<Person> ();
			db.CreateTable<Contact> ();
			db.CreateTable<Game> ();
			db.CreateTable<PlayedGame> ();
			db.CreateTable<Address> ();
			db.CreateTable<Email> ();
			db.CreateTable<Phone> ();
			db.CreateTable<Post> ();
			db.CreateTable<Likes> ();
			db.CreateTable <Comment> ();
		}

		void dbLock()
		{
			Object locker = new Object (); //class level private field

			//rest of class code

			lock (locker) {
				// Query and insert code goes here
			}
				
		}

	}

}