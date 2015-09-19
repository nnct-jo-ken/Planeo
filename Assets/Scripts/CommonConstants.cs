using UnityEngine;
using System.Collections;

public class CommonConstants : MonoBehaviour {

	public class General {
		public static readonly float EARTH_AXIS = 23.44;    // 理科年表より
	}

	public class LatLng {
		// 各場所の緯度、経度
		// http://xn--rhqx9shfy55i.biz/000_1/cat21/
		// http://www.geocoding.jp/
		// http://www.benricho.org/chimei/latlng_data.html

		// HOCTO Culture Hall
		public static readonly float HOCTO_Lat = 36.635668;
		public static readonly float HOCTO_Lng = 138.186755;

		// Tokyo (Shinjuku)
		public static readonly float TOKYO_Lat = 35.689521;
		public static readonly float TOKYO_Lng = 139.691704;

		// Osaka (Osaka City)
		public static readonly float OSAKA_Lat = 34.686316;
		public static readonly float OSAKA_Lng = 135.519711;

		// America (Washigton, D.C.)
		public static readonly float AMERICA_Lat = 38.897159;
		public static readonly float AMERICA_Lng = -77.036207;

		// NZ (Canberra)
		public static readonly float NZ_Lat = -35.308236;
		public static readonly float NZ_Lng = 149.12515;

		// UK (London)
		public static readonly float UK_Lat = 51.499183;
		public static readonly float UK_Lng = -0.12464066;

		// Brazil (Brasilia)
		public static readonly float BRAZIL_Lat = -15.799668;
		public static readonly float BRAZIL_Lng = -47.864154;
	}


}