using UnityEngine;

namespace DoomlikeGame {
	public static class EnumUtil {
		public static T GetRandomValue<T>() where T : System.Enum {
			var res = System.Enum.GetValues(typeof(T));
			return (T)res.GetValue(Random.Range(0, res.Length));
		}
	}
}
