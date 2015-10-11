using UnityEngine;
using System.Collections;

public class CommonConstants {

	public class General {
		public static readonly float EARTH_AXIS = 23.44f;    // 理科年表より
		public static readonly float JULIAN_YEAR_TO_DAY = 365.25f;
		public static readonly float ECLIPTIC_INCLINATION_DEG = 23.439279f;
	}

	public class LatLng {
		// 各場所の緯度、経度
		// http://xn--rhqx9shfy55i.biz/000_1/cat21/  http://www.geocoding.jp/  http://www.benricho.org/chimei/latlng_data.html

		// HOCTO Culture Hall
		public static readonly float HOCTO_Lat = 36.635668f;
		public static readonly float HOCTO_Lng = 138.186755f;
		// Tokyo (Shinjuku)
		public static readonly float TOKYO_Lat = 35.689521f;
		public static readonly float TOKYO_Lng = 139.691704f;
		// Osaka (Osaka City)
		public static readonly float OSAKA_Lat = 34.686316f;
		public static readonly float OSAKA_Lng = 135.519711f;
		// America (Washigton, D.C.)
		public static readonly float AMERICA_Lat = 38.897159f;
		public static readonly float AMERICA_Lng = -77.036207f;
		// NZ (Canberra)
		public static readonly float NZ_Lat = -35.308236f;
		public static readonly float NZ_Lng = 149.12515f;
		// UK (London)
		public static readonly float UK_Lat = 51.499183f;
		public static readonly float UK_Lng = -0.12464066f;
		// Brazil (Brasilia)
		public static readonly float BRAZIL_Lat = -15.799668f;
		public static readonly float BRAZIL_Lng = -47.864154f;
	}

	public class Star {
		public const int QTY = 10000;
		public const int RADIUS = 500;
		public const float COLLIDER_RADIUS = 5f;
	}

	public class Planet {
		public const int QTY = 8;
		public const float COLLIDER_RADIUS = 4.5f;
	}
	public class Infrared {
		public const int QTY = 1672;
		public const int RADIUS = 500;
	}
}