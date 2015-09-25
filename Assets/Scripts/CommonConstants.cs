using UnityEngine;
using System.Collections;

public class CommonConstants {

	public class General {
		public static readonly float EARTH_AXIS = 23.44f;    // 理科年表より
	}

	public class LatLng {
		// 各場所の緯度、経度
		// http://xn--rhqx9shfy55i.biz/000_1/cat21/
		// http://www.geocoding.jp/
		// http://www.benricho.org/chimei/latlng_data.html

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

	public class Planet {
		// 基本的に理科年表(H.27)より
		public class Mercury {
			public static readonly float SEMI_MEJOR_AXIS_AU = 0.3871f;
			public static readonly float ECCENTRICITY = 0.2056f;
			public static readonly float SIDEREAL_PERIOD = 0.24085;
		}
		public class Venus {
			public static readonly float SEMI_MEJOR_AXIS_AU = 0.7233f;
			public static readonly float ECCENTRICITY = 0.0068f;
			public static readonly float SIDEREAL_PERIOD = 0.61520;
		}
		public class Earth {
			public static readonly float SEMI_MEJOR_AXIS_AU = 1.0f;
			public static readonly float ECCENTRICITY = 0.0167f;
			public static readonly float SIDEREAL_PERIOD = 1.00002;
		}
		public class Mars {
			public static readonly float SEMI_MEJOR_AXIS_AU = 1.5237f;
			public static readonly float ECCENTRICITY = 0.0934f;
			public static readonly float SIDEREAL_PERIOD = 1.88085;
		}
		public class Jupiter {
			public static readonly float SEMI_MEJOR_AXIS_AU = 5.2026f;
			public static readonly float ECCENTRICITY = 0.0485f;
			public static readonly float SIDEREAL_PERIOD = 11.8620;
		}
		public class Saturn {
			public static readonly float SEMI_MEJOR_AXIS_AU = 9.5549f;
			public static readonly float ECCENTRICITY = 0.0555f;
			public static readonly float SIDEREAL_PERIOD = 29.4572;
		}
		public class Uranus {
			public static readonly float SEMI_MEJOR_AXIS_AU = 19.2184f;
			public static readonly float ECCENTRICITY = 0.0463f;
			public static readonly float SIDEREAL_PERIOD = 84.0205;
		}
		public class Neptune {
			public static readonly float SEMI_MEJOR_AXIS_AU = 30.1104f;
			public static readonly float ECCENTRICITY = 0.0090f;
			public static readonly float SIDEREAL_PERIOD = 164.7700;
		}
	}
}