using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo.Interface
{
	/// <summary>
	/// 位置服务API接口
	/// </summary>
	internal class PlaceAPI : WeiboAPI
	{
		/// <summary>
		/// 构造
		/// </summary>
		/// <param name="client"></param>
		public PlaceAPI(Client client)
			: base(client)
		{

		}

		public string PublicTimeline(int count = 20, bool baseApp=false)
		{
			return Client.GetCommand("place/public_timeline",
				new WeiboParameter("count", count),
				new WeiboParameter("base_app", baseApp));
		}

		public string FriendsTimeline(string sinceID="0",string maxID="0", int count = 20, int page=1, int type=0)
		{
			return Client.GetCommand("place/friends_timeline",
				new WeiboParameter("since_id", sinceID),
				new WeiboParameter("max_id", maxID),
				new WeiboParameter("count", count),
				new WeiboParameter("page", page),
				new WeiboParameter("type", type));
		}

		public string UserTimeline(string uid, string sinceID = "0", string maxID = "0", int count = 20, int page = 1, bool baseApp = false)
		{
			return Client.GetCommand("place/user_timeline",
				new WeiboParameter("uid", uid),
				new WeiboParameter("since_id", sinceID),
				new WeiboParameter("max_id", maxID),
				new WeiboParameter("count", count),
				new WeiboParameter("page", page),
				new WeiboParameter("base_app", baseApp));
		}

		public string POITimeline(string poiID, string sinceID = "0", string maxID = "0", int count = 20, int page = 1, bool baseApp = false)
		{
			return Client.GetCommand("place/poi_timeline",
				new WeiboParameter("poiid", poiID),
				new WeiboParameter("since_id", sinceID),
				new WeiboParameter("max_id", maxID),
				new WeiboParameter("count", count),
				new WeiboParameter("page", page),
				new WeiboParameter("base_app", baseApp));
		}

		public string NearByTimeline(float lat, float log, int range = 2000, int startTime = 0, int endTime = 0, bool sort = false, int count = 20, int page = 1, bool baseApp = false, bool offset = false)
		{
			return Client.GetCommand("place/nearby_timeline",
				new WeiboParameter("lat", lat),
				new WeiboParameter("long", log),
				new WeiboParameter("starttime", startTime),
				new WeiboParameter("endtime", endTime),
				new WeiboParameter("sort", sort),
				new WeiboParameter("count", count),
				new WeiboParameter("page", page),
				new WeiboParameter("base_app", baseApp),
				new WeiboParameter("offset", offset));
		}

		public string StatusesShow(string id)
		{
			return Client.GetCommand("place/statuses/show",
				new WeiboParameter("id", id));
		}

		public string UsersShow(string uid, bool baseApp = false)
		{
			return Client.GetCommand("place/users/show",
					new WeiboParameter("uid", uid),
					new WeiboParameter("baseApp", false));
		}

		public string UserCheckins(string uid, int count = 20, int page = 1, bool baseApp = false)
		{
			return Client.GetCommand("place/users/checkins",
					new WeiboParameter("uid", uid),
					new WeiboParameter("count", count),
					new WeiboParameter("page", page),
					new WeiboParameter("base_app", baseApp),
					new WeiboParameter("baseApp", false));
		}

		public string UserPhotos(string uid, int count = 20, int page = 1, bool baseApp = false)
		{
			return Client.GetCommand("place/users/photos",
					new WeiboParameter("uid", uid),
					new WeiboParameter("count", count),
					new WeiboParameter("page", page),
					new WeiboParameter("base_app", baseApp),
					new WeiboParameter("baseApp", false));
		}

		public string UserTips(string uid, int count = 20, int page = 1, bool baseApp = false)
		{
			return Client.GetCommand("place/users/tips",
					new WeiboParameter("uid", uid),
					new WeiboParameter("count", count),
					new WeiboParameter("page", page),
					new WeiboParameter("base_app", baseApp),
					new WeiboParameter("baseApp", false));
		}

		public string UserTodos(string uid, int count = 20, int page = 1, bool baseApp = false)
		{
			return Client.GetCommand("place/users/todos",
						new WeiboParameter("uid", uid),
						new WeiboParameter("count", count),
						new WeiboParameter("page", page),
						new WeiboParameter("base_app", baseApp),
						new WeiboParameter("baseApp", false));
		}

		public string POIShow(string poiID, bool baseApp = false)
		{
			return Client.GetCommand("place/pois/show",
				new WeiboParameter("poiID", poiID),
				new WeiboParameter("base_app", baseApp));
		}

		public string POIUsers(string poiID, int count = 20, int page = 1, bool baseApp = false)
		{
			return Client.GetCommand("place/pois/users",
				new WeiboParameter("poiID", poiID),
				new WeiboParameter("count", count),
				new WeiboParameter("page", page),
				new WeiboParameter("base_app", baseApp));
		}

		public string POITips(string poiID, int count = 20, int page = 1, bool sort = false, bool baseApp = false)
		{
			return Client.GetCommand("place/pois/tips",
				new WeiboParameter("poiID", poiID),
				new WeiboParameter("count", count),
				new WeiboParameter("page", page),
				new WeiboParameter("sort", sort),
				new WeiboParameter("base_app", baseApp));
		}

		public string POIPhotos(string poiID, int count = 20, int page = 1, bool sort = false, bool baseApp = false)
		{
			return Client.GetCommand("place/pois/photos",
				new WeiboParameter("poiID", poiID),
				new WeiboParameter("count", count),
				new WeiboParameter("page", page),
				new WeiboParameter("sort", sort),
				new WeiboParameter("base_app", baseApp));
		}

		public string POISearch(string keyword, string city, string category, int count = 20, int page = 1)
		{
			return Client.GetCommand("place/pois/search",
				new WeiboParameter("keyword", keyword),
				new WeiboParameter("city", city),
				new WeiboParameter("category", category),
				new WeiboParameter("count", count),
				new WeiboParameter("page", page));
		}

		public string POICategory(string pid = "", bool flag = false)
		{
			return Client.GetCommand("place/pois/category",
				new WeiboParameter("pid", pid),
				new WeiboParameter("flag", flag));
		}

		public string NearByPOIs(float lat, float log, int range = 2000, string q = "", string category = "", int count = 20, int page = 1, bool sort = false, bool offset = false)
		{
			return Client.GetCommand("place/nearby/pois",
				new WeiboParameter("lat", lat),
				new WeiboParameter("long", log),
				new WeiboParameter("range", range),
				new WeiboParameter("q", q),
				new WeiboParameter("category", category),
				new WeiboParameter("count", count),
				new WeiboParameter("page", page),
				new WeiboParameter("sort", sort),
				new WeiboParameter("offset", offset));
		}

		public string NearByUsers(float lat, float log, int range = 2000, int count = 20, int page = 1, int startTime = 0, int endTime = 0, bool sort = false, bool offset = false)
		{
			return Client.GetCommand("place/nearby/users",
				new WeiboParameter("lat", lat),
				new WeiboParameter("long", log),
				new WeiboParameter("range", range),
				new WeiboParameter("count", count),
				new WeiboParameter("page", page),
				new WeiboParameter("starttime", startTime),
				new WeiboParameter("endtime", endTime),
				new WeiboParameter("sort", sort),
				new WeiboParameter("offset", offset));
		}

		public string NearByPhotos(float lat, float log, int range = 2000, int count = 20, int page = 1, int startTime = 0, int endTime = 0, bool sort = false, bool offset = false)
		{
			return Client.GetCommand("place/nearby/photos",
				new WeiboParameter("lat", lat),
				new WeiboParameter("long", log),
				new WeiboParameter("range", range),
				new WeiboParameter("count", count),
				new WeiboParameter("page", page),
				new WeiboParameter("starttime", startTime),
				new WeiboParameter("endtime", endTime),
				new WeiboParameter("sort", sort),
				new WeiboParameter("offset", offset));
		}

		public string NearByUserList(float lat, float log, int count = 20, int page = 1, int range = 2000, bool sort = false, int filter=0,int gender = 0, int level=0, int startAge=0,int endAge =0, bool offset = false)
		{
            return Client.GetCommand("place/nearby_users/list",
				new WeiboParameter("lat", lat),
				new WeiboParameter("long", log),
				new WeiboParameter("range", range),
				new WeiboParameter("count", count),
				new WeiboParameter("page", page),
				new WeiboParameter("filter", filter),
				new WeiboParameter("gender", gender),
				new WeiboParameter("level", level),
				new WeiboParameter("startbirth", startAge),
				new WeiboParameter("endbirth", endAge),
				new WeiboParameter("sort", sort),
				new WeiboParameter("offset", offset));
		}

		public string CreatePOI(string title, string address, string category = "500", float lat = 0.0f, float log = 0.0f, string city = "", string province = "", string country = "", string phone = "", string postcode = "", string extra = "")
		{
			return Client.PostCommand("place/pois/create",
				new WeiboParameter("title", title),
				new WeiboParameter("address", address),
				new WeiboParameter("category", category),
				new WeiboParameter("lat", lat),
				new WeiboParameter("long", log),
				new WeiboParameter("city", city),
				new WeiboParameter("province", province),
				new WeiboParameter("country", country),
				new WeiboParameter("phone", phone),
				new WeiboParameter("postcode", postcode),
				new WeiboParameter("extra", extra));
		}

		public string CheckIn(string poiID, string status, byte[] pic, bool isPublic = true)
		{
            return Client.PostCommand("place/pois/add_checkin",
				new WeiboParameter("poiid", poiID),
				new WeiboParameter("status", status),
				new WeiboParameter("pic", pic),
				new WeiboParameter("public", isPublic));
		}

		public string AddPhoto(string poiID, string status, byte[] pic, bool isPublic = true)
		{
			return Client.PostCommand("place/pois/add_photo",
				new WeiboParameter("poiid", poiID),
				new WeiboParameter("status", status),
				new WeiboParameter("pic", pic),
				new WeiboParameter("public", isPublic));
		}

		public string AddTip(string poiID, string status, bool isPublic = true)
		{
			return Client.PostCommand("place/pois/add_tip", 
				new WeiboParameter("poiid", poiID),
				new WeiboParameter("status", status),
				new WeiboParameter("public", isPublic));
		}

		public string AddTodo(string poiID, string status, bool isPublic = true)
		{
			return Client.PostCommand("place/pois/add_todo",
				new WeiboParameter("poiid", poiID),
				new WeiboParameter("status", status),
				new WeiboParameter("public", isPublic));
		}

		public string CreateUserPosition(float lat, float log)
		{
			return Client.PostCommand("place/pois/add_todo",
				  new WeiboParameter("lat", lat),
				  new WeiboParameter("long", log));
		}

		public string DestoryUserPostion()
		{
			return Client.PostCommand("place/pois/add_todo");
		}



	}
}
