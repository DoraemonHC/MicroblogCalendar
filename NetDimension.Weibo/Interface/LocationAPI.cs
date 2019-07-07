using System;
using System.Collections.Generic;
#if !NET20
using System.Linq;
#endif
using System.Text;

namespace NetDimension.Weibo.Interface
{
	/// <summary>
	/// 地理信息API接口
	/// </summary>
	internal class LocationAPI:WeiboAPI
	{
		public LocationAPI(Client client)
			: base(client)
		{

		}

		public string GetMapImage(string center="", string city="", string coordinates = "", string names = null, string offsetX = "", string offsetY = "", string font = "", string lines = "", string polygons = "", string size = "240×240", string format = "png", string zoom = "", bool scale = false, bool traffic = false)
		{
			return Client.GetCommand("location/base/get_map_image",
				new WeiboParameter("center_coordinate", center),
				new WeiboParameter("city", city),
				new WeiboParameter("coordinates", coordinates),
				new WeiboParameter("names", names),
				new WeiboParameter("offset_x", offsetX),
				new WeiboParameter("offset_x", offsetY),
				new WeiboParameter("font", font),
				new WeiboParameter("lines", lines),
				new WeiboParameter("polygons", polygons),
				new WeiboParameter("size", size),
				new WeiboParameter("format", format),
				new WeiboParameter("zoom", zoom),
				new WeiboParameter("scale", scale.ToString().ToLower()),
				new WeiboParameter("traffic", traffic.ToString().ToLower()));
		}

		public string IPtoGeo(string[] ips)
		{
			return Client.GetCommand("location/geo/ip_to_geo", new WeiboParameter("ip", string.Join(",",ips)));
		}

		public string AddressToGeo(string address)
		{
			return Client.GetCommand("location/geo/address_to_geo", new WeiboParameter("address", address));
		}

		public string GeoToAddress(string coordinate)
		{
			return Client.GetCommand("location/geo/geo_to_address", new WeiboParameter("coordinate", coordinate));
		}

		public string GpsToOffset(string coordinate)
		{
			return Client.GetCommand("location/geo/gps_to_offset", new WeiboParameter("coordinate", coordinate));
		}

		public string IsDomestic(string coordinates)
		{
			return Client.GetCommand("location/geo/is_domestic", new WeiboParameter("coordinate", coordinates));
		}

		public string ShowPOIs(string[] srcids)
		{
			return Client.GetCommand("location/pois/show_batch", new WeiboParameter("srcids", string.Join(",",srcids)));
		}

		public string SearchPOIsByLocation(string q = "", string category = "", string city = "", int page = 1, int count = 20)
		{
			return Client.GetCommand("location/pois/search/by_location",
				new WeiboParameter("q", q),
				new WeiboParameter("category", category),
				new WeiboParameter("city", city),
				new WeiboParameter("page", page),
				new WeiboParameter("count", count));
		}

		public string SearchPOIsByGeo(string q = "", string category = "", string coordinate = "",string pid="", string city="",int range=500, int page = 1, int count = 20)
		{
			return Client.GetCommand("location/pois/search/by_geo",
				new WeiboParameter("q", q),
				new WeiboParameter("category", category),
				new WeiboParameter("coordinate", coordinate),
				new WeiboParameter("pid", pid),
				new WeiboParameter("city", city),
				new WeiboParameter("range", range),
				new WeiboParameter("page", page),
				new WeiboParameter("count", count));
		}

		public string SearchPOIsByArea(string q = "", string category = "", string coordinates = "", string city = "", int page = 1, int count = 20)
		{
			return Client.GetCommand("location/pois/search/by_geo",
				new WeiboParameter("q", q),
				new WeiboParameter("category", category),
				new WeiboParameter("coordinates", coordinates),
				new WeiboParameter("city", city),
				new WeiboParameter("page", page),
				new WeiboParameter("count", count));
		}

		public string AddPOI(string srcid, string name, string address, string cityName, string category, string longitude, string latitude, string phone = "", string picUrl = "", string url = "", string tags = "", string description = "", string intro = "", string traffic = "")
		{
			return Client.PostCommand("location/pois/add",
				new WeiboParameter("srcid", srcid),
				new WeiboParameter("name", name),
				new WeiboParameter("address", address),
				new WeiboParameter("cityName", cityName),
				new WeiboParameter("category", category),
				new WeiboParameter("longitude", longitude),
				new WeiboParameter("latitude", latitude),
				new WeiboParameter("telephone", phone),
				new WeiboParameter("pic_url", picUrl),
				new WeiboParameter("url", url),
				new WeiboParameter("tags", tags),
				new WeiboParameter("description", description),
				new WeiboParameter("intro", intro),
				new WeiboParameter("traffic", traffic));
		}

		public string GetLocationByMobileStation(string json)
		{
			return Client.GetCommand("location/mobile/get_location", new WeiboParameter("json", json));
		}

		public string DriveRouteLine(string beginPID = "", string beginCoordinate = "", string endPID = "", string endCoordinate = "", int type = 0)
		{
			return Client.GetCommand("location/line/drive_route",
				string.IsNullOrEmpty(beginPID) ? new WeiboParameter("begin_coordinate", beginCoordinate) : new WeiboParameter("begin_pid", beginPID),
				string.IsNullOrEmpty(endPID) ? new WeiboParameter("end_coordinate", endCoordinate) : new WeiboParameter("end_pid", endPID),
				new WeiboParameter("type", type));
		}

		public string BusRouteLine(string beginPID = "", string beginCoordinate = "", string endPID = "", string endCoordinate = "", int type = 0)
		{
			return Client.GetCommand("location/line/bus_route",
				string.IsNullOrEmpty(beginPID) ? new WeiboParameter("begin_coordinate", beginCoordinate) : new WeiboParameter("begin_pid", beginPID),
				string.IsNullOrEmpty(endPID) ? new WeiboParameter("end_coordinate", endCoordinate) : new WeiboParameter("end_pid", endPID),
				new WeiboParameter("type", type));
		}

		public string BusLine(string q, string city = "", int page = 1, int count = 10)
		{
			return Client.GetCommand("location/line/bus_line", 
				new WeiboParameter("q", q),
				new WeiboParameter("city", city),
				new WeiboParameter("page", page),
				new WeiboParameter("count", count));
		}

		public string BusStation(string q, string city = "", int page = 1, int count = 10)
		{

			return Client.GetCommand("location/line/bus_station",
				new WeiboParameter("q", q),
				new WeiboParameter("city", city),
				new WeiboParameter("page", page),
				new WeiboParameter("count", count));
		}


	}
}
